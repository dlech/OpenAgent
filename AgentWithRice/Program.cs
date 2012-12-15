using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using dlech.SshAgentLib.WinForms;
using dlech.SshAgentLib;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using SshAgentLib.WinForm;

namespace dlech.AgentWithRice
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
      if (CommandLineArgs.Mode == AgentMode.Auto) {
        if (PageantAgent.CheckPageantRunning()) {
          CommandLineArgs.Mode = AgentMode.Client;
        } else {
          CommandLineArgs.Mode = AgentMode.Server;
        }
      }
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      switch (CommandLineArgs.Mode) {
        case AgentMode.Server:
          try {
            Agent = new PageantAgent();            
          } catch (PageantRunningException) {
            Debug.Fail("should not get here unless Pageant started in last few msec.");
            Environment.Exit(1);
            return;
          }
          break;
        case AgentMode.Client:
          Agent = new PageantClient();
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
