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

namespace dlech.AgentWithRice.WinForms
{
  public partial class KeyManagerForm : Form
  {
    PasswordDialog mPasswordDialog;

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
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      
      keyInfoViewer.SetAgent(Program.Agent);
      if (Program.Agent is Agent) {
        var agent = Program.Agent as Agent;
        agent.KeyListChanged += AgentKeyListChangeHandler;
        agent.Locked += AgentLockHandler;
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
      openFileDialog.ShowDialog();
    }

    private void openFileDialog_FileOk(object sender, CancelEventArgs e)
    {
      UseWaitCursor = true;
      Program.Agent.AddKeysFromFiles(openFileDialog.FileNames);
      UseWaitCursor = false;
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
        Program.Agent.RemoveKey(key);
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
          string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
          MessageBoxDefaultButton.Button2);
        if (result != DialogResult.Yes) {
          return;
        }
      }
      Program.Agent.Lock(PasswordDialog.SecureEdit.ToUtf8());
    }

    private void unlockButton_Click(object sender, EventArgs e)
    {
      var result = PasswordDialog.ShowDialog();
      if (result == DialogResult.OK) {
        Program.Agent.Unlock(PasswordDialog.SecureEdit.ToUtf8());
      }
    }

    
    private void removeAllbutton_Click(object sender, EventArgs e)
    {
      Program.Agent.RemoveAllKeys();
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
