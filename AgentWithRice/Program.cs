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
    internal static Agent Agent { get; private set; }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] aArgs)
    {
      Debugger.Launch();
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
            var keyManagerForm = new KeyManagerForm();
            keyManagerForm.FormClosed +=
              delegate(object aSender, FormClosedEventArgs aEventArgs)
              {
                Environment.Exit(0);
              };
            keyManagerForm.Show();
          } catch (PageantRunningException) {
            Debug.Fail("should not get here unless Pageant started in last few msec.");
            Environment.Exit(1);
            return;
          }
          break;
        case AgentMode.Client:
        default:
          Debug.Fail("unknown mode");
          Environment.Exit(1);
          return;
      }
      Agent.AddKeysFromFiles(CommandLineArgs.Files);
      Application.ApplicationExit +=
        delegate(object aSender, EventArgs aEventArgs)
        {
          Agent.Dispose();
        };      
      Application.Run();
      Environment.Exit(0);
    }

    public static void AddKeysFromFiles(this Agent aAgent, string[] aFileNames)
    {
      foreach (var fileName in aFileNames) {
        try {
          Agent.AddKeyFromFile(fileName);
        } catch (Exception ex) {
          MessageBox.Show(string.Format(Strings.errFileOpenFailed,
            fileName, ex.Message));
        }
      }
    }

    public static void AddKeyFromFile(this Agent aAgent, string aFileName)
    {
      var getPassword = PasswordCallbackFactory(
        string.Format(Strings.msgEnterPassphrase, Path.GetFileName(aFileName)));
      Agent.AddKeyFromFile(aFileName, getPassword);
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
        return System.IO.Path.GetFileNameWithoutExtension(
          Assembly.GetExecutingAssembly().CodeBase);
      }
    }

  }
}
