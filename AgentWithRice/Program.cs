using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using dlech.AgentWithRice.WinForms;
using dlech.SshAgentLib;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace dlech.AgentWithRice
{
  static class Program
  {
    internal static IAgent Agent { get; private set; }

    private static string mAssemblyTitle;

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
          MessageBox.Show(Strings.errPageantRunning, AssemblyTitle,
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
      var keyManagerForm = new KeyManagerForm();
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

    public static void AddKeysFromFiles(this IAgent aAgent, string[] aFileNames,
      ICollection<Agent.KeyConstraint> aConstraints = null)
    {
      foreach (var fileName in aFileNames) {
        try {
          Agent.AddKeyFromFile(fileName, aConstraints);
        } catch (Exception ex) {
          MessageBox.Show(string.Format(Strings.errFileOpenFailed,
            fileName, ex.Message), AssemblyTitle, MessageBoxButtons.OK,
            MessageBoxIcon.Error);
        }
      }
    }

    public static void AddKeyFromFile(this IAgent aAgent, string aFileName,
      ICollection<Agent.KeyConstraint> aConstraints)
    {
      var getPassword = PasswordCallbackFactory(
        string.Format(Strings.msgEnterPassphrase, Path.GetFileName(aFileName)));
      var success = Agent.AddKeyFromFile(aFileName, getPassword, aConstraints);
      if (!success) {
        throw new Exception(Strings.errAddKeyFailed);
      }
    }

    public static KeyFormatter.GetPassphraseCallback
      PasswordCallbackFactory(string aMessage)
    {
      return new KeyFormatter.GetPassphraseCallback(delegate()
      {
        var dialog = new PasswordDialog();
        dialog.Text = aMessage;
        var result = dialog.ShowDialog();
        if (result != DialogResult.OK) {
          return null;
        }
        return dialog.SecureEdit.SecureString;
      });
    }

    /// <summary>
    /// Gets the assembly title.
    /// </summary>
    /// <value>The assembly title.</value>
    /// <remarks>
    /// from http://www.codekeep.net/snippets/170dc91f-1077-4c7f-ab05-8f82b9d1b682.aspx
    /// </remarks>
    public static string AssemblyTitle
    {
      get
      {
        if (mAssemblyTitle == null) {
          // Get all Title attributes on this assembly
          object[] attributes = Assembly.GetExecutingAssembly()
            .GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
          // If there is at least one Title attribute
          if (attributes.Length > 0) {
            // Select the first one
            AssemblyTitleAttribute titleAttribute =
              (AssemblyTitleAttribute)attributes[0];
            // If it is not an empty string, return it
            if (titleAttribute.Title != "")
              return titleAttribute.Title;
          }
          // If there was no Title attribute, or if the Title attribute was the
          // empty string, return the .exe name
          mAssemblyTitle = System.IO.Path.GetFileNameWithoutExtension(
            Assembly.GetExecutingAssembly().CodeBase);
        }
        return mAssemblyTitle;
      }
    }

  }
}
