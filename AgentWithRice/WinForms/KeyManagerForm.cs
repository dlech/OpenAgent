using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using dlech.SshAgentLib;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.IO;
using System.Security;
using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.WindowsAPICodePack.Dialogs.Controls;

namespace dlech.AgentWithRice.WinForms
{
  public partial class KeyManagerForm : Form
  {
    private string cConfirmConstraintCheckBox = "ConfirmConstraintCheckBox";
    private string cLifetimeConstraintCheckBox = "LifeteimConstraintCheckBox";
    private string cLifetimeConstraintTextBox = "LifeteimConstraintTextBox";

    PasswordDialog mPasswordDialog;
    CommonOpenFileDialog mWin7OpenFileDialog;

    private PasswordDialog PasswordDialog
    {
      get
      {
        if (mPasswordDialog == null) {
          mPasswordDialog = new PasswordDialog();
        }
        return mPasswordDialog;
      }
    }

    public KeyManagerForm()
    {
      InitializeComponent();
      if (CommonOpenFileDialog.IsPlatformSupported) {
        mWin7OpenFileDialog = new CommonOpenFileDialog();
        mWin7OpenFileDialog.Multiselect = true;
        mWin7OpenFileDialog.EnsureFileExists = true;
        
        var confirmConstraintCheckBox =
          new CommonFileDialogCheckBox(cConfirmConstraintCheckBox,
          "Require user confirmation");
        var lifetimeConstraintTextBox =
          new CommonFileDialogTextBox(cLifetimeConstraintTextBox, string.Empty);
        lifetimeConstraintTextBox.Visible = false;
        var lifetimeConstraintCheckBox =
          new CommonFileDialogCheckBox(cLifetimeConstraintCheckBox,
          "Set lifetime (in seconds)");
        lifetimeConstraintCheckBox.CheckedChanged +=
          delegate(object aSender, EventArgs aEventArgs)
          {
            lifetimeConstraintTextBox.Visible =
              lifetimeConstraintCheckBox.IsChecked;
          };

        var confirmConstraintGroupBox = new CommonFileDialogGroupBox();
        var lifetimeConstraintGroupBox = new CommonFileDialogGroupBox();

        confirmConstraintGroupBox.Items.Add(confirmConstraintCheckBox);
        lifetimeConstraintGroupBox.Items.Add(lifetimeConstraintCheckBox);
        lifetimeConstraintGroupBox.Items.Add(lifetimeConstraintTextBox);

        mWin7OpenFileDialog.Controls.Add(confirmConstraintGroupBox);
        mWin7OpenFileDialog.Controls.Add(lifetimeConstraintGroupBox);

        mWin7OpenFileDialog.Filters.Add(new CommonFileDialogFilter("PuTTY Private Key Files", "*.ppk"));
        mWin7OpenFileDialog.Filters.Add(new CommonFileDialogFilter("All Files", "*.*"));

        mWin7OpenFileDialog.FileOk += openFileDialog_FileOk;
      }
      //mWin7OpenFileDialog = null;
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      keyInfoViewer.SetAgent(Program.Agent);
      if (Program.Agent is Agent) {
        var agent = Program.Agent as Agent;
        agent.KeyListChanged += AgentKeyListChangeHandler;
        agent.Locked += AgentLockHandler;
        buttonTableLayoutPanel.Controls.Remove(refreshButton);
        buttonTableLayoutPanel.ColumnCount -= 1;
      }
      keyInfoViewer.dataGridView.SelectionChanged += keyInfoViewer_SelectionChanged;
      UpdateButtonStates();
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {

      Properties.Settings.Default.Save();
      if (Program.Agent is Agent) {
        var agent = Program.Agent as Agent;
        agent.KeyListChanged -= AgentKeyListChangeHandler;
        agent.Locked -= AgentLockHandler;
      }
      keyInfoViewer.dataGridView.SelectionChanged -= keyInfoViewer_SelectionChanged;
    }

    private void addKeyButton_Click(object sender, EventArgs e)
    { 
      string[] fileNames;
      List<Agent.KeyConstraint> constraints = new List<Agent.KeyConstraint>();
      if (mWin7OpenFileDialog != null) {
        var result = mWin7OpenFileDialog.ShowDialog();
        if (result != CommonFileDialogResult.Ok) {
          return;
        }
        var confirmConstraintCheckBox =
          mWin7OpenFileDialog.Controls[cConfirmConstraintCheckBox] as
          CommonFileDialogCheckBox;
        if (confirmConstraintCheckBox.IsChecked) {
          var constraint = new Agent.KeyConstraint();
          constraint.Type = Agent.KeyConstraintType.SSH_AGENT_CONSTRAIN_CONFIRM;
          constraints.Add(constraint);
        }
        var lifetimeConstraintCheckBox =
          mWin7OpenFileDialog.Controls[cLifetimeConstraintCheckBox] as
          CommonFileDialogCheckBox;
        var lifetimeConstraintTextBox =
          mWin7OpenFileDialog.Controls[cLifetimeConstraintTextBox] as
          CommonFileDialogTextBox;
        if (lifetimeConstraintCheckBox.IsChecked) {
          // error checking for parse done in fileOK event handler
          uint lifetime = uint.Parse(lifetimeConstraintTextBox.Text); 
          var constraint = new Agent.KeyConstraint();
          constraint.Type = Agent.KeyConstraintType.SSH_AGENT_CONSTRAIN_LIFETIME;
          constraint.Data = lifetime;
          constraints.Add(constraint);
        }
        fileNames = mWin7OpenFileDialog.FileNames.ToArray();
      } else {
        var result = openFileDialog.ShowDialog();
        if (result != DialogResult.OK) {
          return;
        }
        fileNames = openFileDialog.FileNames;
      }
      UseWaitCursor = true;
      Program.Agent.AddKeysFromFiles(fileNames, constraints);
      if (!(Program.Agent is Agent)) {
        ReloadKeyListView();
      }
      UseWaitCursor = false;
    }

    private void openFileDialog_FileOk(object sender, CancelEventArgs e)
    {
      if (mWin7OpenFileDialog != null) {
        var lifetimeConstraintCheckBox =
          mWin7OpenFileDialog.Controls[cLifetimeConstraintCheckBox] as
          CommonFileDialogCheckBox;
        var lifetimeConstraintTextBox =
          mWin7OpenFileDialog.Controls[cLifetimeConstraintTextBox] as
          CommonFileDialogTextBox;
        if (lifetimeConstraintCheckBox.IsChecked) {          
          uint lifetime;
          var success = uint.TryParse(lifetimeConstraintTextBox.Text, out lifetime);
          if (!success) {
            MessageBox.Show("Invalid lifetime", Program.AssemblyTitle,
              MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            e.Cancel = true;
            return;
          }
        }
      }
    }

    private void keyInfoViewer_SelectionChanged(object sender, EventArgs e)
    {
      UpdateButtonStates();
    }

    private void removeKeyButton_Click(object sender, EventArgs e)
    {
      foreach (DataGridViewRow row in keyInfoViewer.dataGridView.SelectedRows) {
        var keyWrapper = row.DataBoundItem as KeyWrapper;
        var key = keyWrapper.GetKey();
        var success = Program.Agent.RemoveKey(key);
        if (!success) {
          MessageBox.Show(String.Format(Strings.errRemoveFailed,
            key.MD5Fingerprint.ToHexString()), Program.AssemblyTitle,
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
      if (!(Program.Agent is Agent)) {
        ReloadKeyListView();
      }
    }

    private void AgentLockHandler(object aSender, Agent.LockEventArgs aArgs)
    {
      Invoke((MethodInvoker)delegate()
      {
        UpdateButtonStates();
      });
    }

    private void UpdateButtonStates()
    {
      var isLocked = false;
      var agent = Program.Agent as Agent;
      if (agent != null) {
        isLocked = agent.IsLocked;
      }
      lockButton.Enabled = !isLocked;
      unlockButton.Enabled = agent == null || isLocked;
      addKeyButton.Enabled = !isLocked;
      removeKeyButton.Enabled = keyInfoViewer.dataGridView.SelectedRows.Count > 0 &&
        !isLocked;
      removeAllbutton.Enabled = keyInfoViewer.dataGridView.Rows.Count > 0 &&
        !isLocked;
    }

    private void lockButton_Click(object sender, EventArgs e)
    {
      var result = PasswordDialog.ShowDialog();
      if (result != DialogResult.OK) {
        return;
      }
      if (PasswordDialog.SecureEdit.TextLength == 0) {
        result = MessageBox.Show(Strings.keyManagerAreYouSureLockPassphraseEmpty,
          Program.AssemblyTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
          MessageBoxDefaultButton.Button2);
        if (result != DialogResult.Yes) {
          return;
        }
      }
      var success = Program.Agent.Lock(PasswordDialog.SecureEdit.ToUtf8());
      if (!success) {
        MessageBox.Show(Strings.errLockFailed, Program.AssemblyTitle,
          MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      if (!(Program.Agent is Agent)) {
        ReloadKeyListView();
      }
    }

    private void unlockButton_Click(object sender, EventArgs e)
    {
      var result = PasswordDialog.ShowDialog();
      if (result != DialogResult.OK) {
        return;
      }
      var success = Program.Agent.Unlock(PasswordDialog.SecureEdit.ToUtf8());
      if (!success) {
        MessageBox.Show(Strings.errUnlockFailed, Program.AssemblyTitle,
          MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      if (!(Program.Agent is Agent)) {
        ReloadKeyListView();
      }
    }


    private void removeAllbutton_Click(object sender, EventArgs e)
    {
      Program.Agent.RemoveAllKeys();
      if (!(Program.Agent is Agent)) {
        ReloadKeyListView();
      }
    }

    private void refreshButton_Click(object sender, EventArgs e)
    {
      ReloadKeyListView();
    }

    private void ReloadKeyListView()
    {
      keyInfoViewer.SetAgent(Program.Agent);
    }

    private void AgentKeyListChangeHandler(object aSender,
      Agent.KeyListChangeEventArgs aArgs)
    {
      Invoke((MethodInvoker)delegate()
      {
        UpdateButtonStates();
      });
    }
  }
}
