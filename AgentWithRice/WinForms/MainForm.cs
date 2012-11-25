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
  public partial class MainForm : Form
  {
    Agent mAgent;
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

    public MainForm()
    {
      InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      try {
        mAgent = new PageantAgent();
      } catch (PageantRunningException) {
        MessageBox.Show("Another instance of Pageant is running. Application will now close.");
        Close();
        return;
      }
      keyInfoViewer.SetAgent(mAgent);
      mAgent.KeyListChanged += AgentKeyListChangeHandler;
      mAgent.Locked += AgentLockHandler;
      keyInfoViewer.dataGridView.SelectionChanged += keyInfoViewer_SelectionChanged;
      UpdateButtonStates();
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      
      Properties.Settings.Default.Save();
      mAgent.KeyListChanged -= AgentKeyListChangeHandler;
      mAgent.Locked -= AgentLockHandler;
      keyInfoViewer.dataGridView.SelectionChanged -= keyInfoViewer_SelectionChanged;
      mAgent.Dispose();
    }

    private void addKeyButton_Click(object sender, EventArgs e)
    {
      openFileDialog.ShowDialog();
    }

    private void openFileDialog_FileOk(object sender, CancelEventArgs e)
    {
      UseWaitCursor = true;
      var addFileResults = mAgent.AddFiles(openFileDialog.FileNames, GetPassword);
      foreach (var result in addFileResults) {
        MessageBox.Show(string.Format("File '{0}' failed with error: {1}",
          result.Key, result.Value.Message));
      }
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
        mAgent.RemoveKey(key);
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
      lockButton.Enabled = !mAgent.IsLocked;
      unlockButton.Enabled = mAgent.IsLocked;
      addKeyButton.Enabled = !mAgent.IsLocked;
      removeKeyButton.Enabled = keyInfoViewer.dataGridView.SelectedRows.Count > 0 &&
        !mAgent.IsLocked;
      removeAllbutton.Enabled = keyInfoViewer.dataGridView.Rows.Count > 0 &&
        !mAgent.IsLocked;
    }

    private void lockButton_Click(object sender, EventArgs e)
    {
      var result = PasswordDialog.ShowDialog();
      if (result != DialogResult.OK) {
        return;
      }
      if (PasswordDialog.SecureEdit.TextLength == 0) {
        result = MessageBox.Show("Are you sure you want to lock using an empty passphrase?",
          "", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
          MessageBoxDefaultButton.Button2);
        if (result != DialogResult.Yes) {
          return;
        }
      }
      mAgent.Lock(PasswordDialog.SecureEdit.ToUtf8());
    }

    private void unlockButton_Click(object sender, EventArgs e)
    {
      var result = PasswordDialog.ShowDialog();
      if (result == DialogResult.OK) {
        mAgent.Unlock(PasswordDialog.SecureEdit.ToUtf8());
      }
    }

    
    private void removeAllbutton_Click(object sender, EventArgs e)
    {
      var keyList = mAgent.KeyList.ToList();
      foreach (var key in keyList) {
        mAgent.RemoveKey(key);
      }
    }

    private void AgentKeyListChangeHandler(object aSender,
      Agent.KeyListChangeEventArgs aArgs)
    {
      Invoke((MethodInvoker)delegate()
      {
        UpdateButtonStates();
      });
    }

    private SecureString GetPassword()
    {
      var result = mPasswordDialog.ShowDialog();
      if (result != DialogResult.OK) {
        return null;
      }
      return mPasswordDialog.SecureEdit.SecureString;
    }
  }
}
