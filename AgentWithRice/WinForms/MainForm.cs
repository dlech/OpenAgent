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

namespace dlech.AgentWithRice
{
  public partial class MainForm : Form
  {    
    Agent mAgent;

    public MainForm()
    {
      InitializeComponent();
            
      try {
        mAgent = new PageantAgent();
      } catch (PageantRunningException) {
        MessageBox.Show("Pageant is running");
        return;
      }
      keyInfoDataGridView1.SetAgent(mAgent);
      mAgent.Locked += AgentLockHandler;
      UpdateButtonStates();
    }
       
       
    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      Properties.Settings.Default.Save();
      mAgent.Locked -= AgentLockHandler;
      mAgent.Dispose();
    }

    private void addKeyButton_Click(object sender, EventArgs e)
    {
      openFileDialog.ShowDialog();
    }   

    private void openFileDialog_FileOk(object sender, CancelEventArgs e)
    {
      KeyFormatter formatter;
      switch (openFileDialog.FilterIndex) {
        case 1: // *.ppk
          formatter = new PpkFormatter();
          break;
        case 2: // OpenSSH
          formatter = new Ssh2KeyFormatter();
          break;
        default:
          Debug.Fail("Unknown filter selection");
          return;
      }
      foreach (var fileName in openFileDialog.FileNames) {
        try {
          var key = formatter.DeserializeFile(fileName);
          if (string.IsNullOrEmpty(key.Comment)) {
            key.Comment = Path.GetFileName(fileName);
          }
          mAgent.AddKey(key);
        } catch (Exception) {
          MessageBox.Show("Error loading file: " + fileName);
        }
      }
    }

    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {
      UpdateButtonStates();
    }

    private void removeKeyButton_Click(object sender, EventArgs e)
    {
      foreach (DataGridViewRow row in keyInfoDataGridView1.SelectedRows) {
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
      removeKeyButton.Enabled = keyInfoDataGridView1.SelectedRows.Count != 0 &&
        !mAgent.IsLocked;      
    }

    private void lockButton_Click(object sender, EventArgs e)
    {
      mAgent.Lock(null);
    }

    private void unlockButton_Click(object sender, EventArgs e)
    {
      mAgent.Unlock(null);
    }
  }
}
