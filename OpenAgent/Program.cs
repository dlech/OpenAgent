using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using dlech.SshAgentLib.WinForms;
using dlech.SshAgentLib;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace dlech.OpenAgent
{
  static class Program
  {
    internal static IAgent Agent { get; private set; }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] aArgs)
    {
      //Debugger.Launch();
      CommandLineArgs.Parse(aArgs);
      if (CommandLineArgs.Mode == AgentMode.Server &&
        PageantAgent.CheckPageantRunning()) {
          MessageBox.Show(Strings.errPageantRunning, Util.AssemblyTitle,
            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        Environment.Exit(1);
        return;
      }
      var isWindows = Environment.OSVersion.Platform == PlatformID.Win32NT;
      var agentSocketFile = 
        Environment.GetEnvironmentVariable (UnixClient.SSH_AUTHSOCKET_ENV_NAME);
      if (CommandLineArgs.Mode == AgentMode.Auto)
      {
        if ((isWindows && PageantAgent.CheckPageantRunning()) || 
            !string.IsNullOrWhiteSpace(agentSocketFile))
        {
          CommandLineArgs.Mode = AgentMode.Client;
        } else {
          CommandLineArgs.Mode = AgentMode.Server;
        }
      }
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      switch (CommandLineArgs.Mode) {
        case AgentMode.Server:
          if (isWindows) {
            try {
              Agent = new PageantAgent();
              break;
            } catch (PageantRunningException) {
              Debug.Fail("should not get here unless Pageant started in last few msec.");
              Environment.Exit(1);
              return;
            } catch (NotSupportedException) {
              // we wil just try unix socket then
            }
          }
          Agent = new UnixAgent();
          break;
        case AgentMode.Client:
          if (isWindows) {
            Agent = new PageantClient();
            break;
          }
          Agent = new UnixClient();
          break;
        default:
          Debug.Fail("unknown mode");
          Environment.Exit(1);
          return;
      }     
      Agent.AddKeysFromFiles(CommandLineArgs.Files);
      Application.ApplicationExit +=
        delegate(object aSender, EventArgs aEventArgs)
        {
          if (Agent is Agent) {
            ((Agent)Agent).Dispose();
          }
        };
      var keyManagerForm = new KeyManagerForm(Agent);
      if (!(Agent is Agent)) {
        keyManagerForm.Text += " - client mode";
      }
      keyManagerForm.FormClosed +=
        delegate(object aSender, FormClosedEventArgs aEventArgs)
        {
          Environment.Exit(0);
        };
      keyManagerForm.Show();
      Application.Run();
    }
  }
}
