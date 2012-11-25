using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dlech.SshAgentLib;
using System.Security;

namespace dlech.AgentWithRice.WinForms
{
  public partial class KeyInfoViewer : UserControl
  {
    private Agent mAgent;
    BindingList<KeyWrapper> mKeyCollection;
    
    public KeyInfoViewer()
    {
      InitializeComponent();
    }

    public void SetAgent(Agent aAgent)
    {      
      mAgent = aAgent;

      mKeyCollection = new BindingList<KeyWrapper>();
      dataGridView.DataSource = mKeyCollection;
      mAgent.KeyListChanged += AgentKeyListChangeHandler;
      mAgent.Locked += AgentLockHandler;
      UpdateVisibility();
    }

    private void AgentLockHandler(object aSender, Agent.LockEventArgs aArgs)
    {
      Invoke((MethodInvoker)delegate()
      {
        UpdateVisibility();
      });
    }

    private void AgentKeyListChangeHandler(object aSender,
      Agent.KeyListChangeEventArgs aArgs)
    {
      if (IsDisposed) {
        return;
      }
      switch (aArgs.Action) {
        case Agent.KeyListChangeEventAction.Add:
          Invoke((MethodInvoker)delegate()
          {
            mKeyCollection.Add(new KeyWrapper(aArgs.Key));
            UpdateVisibility();
          });
          break;
        case Agent.KeyListChangeEventAction.Remove:
          Invoke((MethodInvoker)delegate()
          {
            var matchFingerprint = aArgs.Key.MD5Fingerprint.ToHexString();
            var matches = mKeyCollection.Where(k =>
              k.Fingerprint == matchFingerprint).ToList();
            foreach (var key in matches) {
              mKeyCollection.Remove(key);
            }
            UpdateVisibility();
          });
          break;
      }
    }

    private void UpdateVisibility()
    {
      dataGridView.Visible = mAgent.KeyList.Count() > 0 && !mAgent.IsLocked;
      if (mAgent.IsLocked) {
        messageLabel.Text = "Locked";
      } else {
        messageLabel.Text = "No Keys Loaded";
      }
    }

    private void any_DragEnter(object sender, DragEventArgs e)
    {
      if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
        e.Effect = DragDropEffects.Move;
      } else {
        e.Effect = DragDropEffects.None;
      }
    }

    private void any_DragDrop(object sender, DragEventArgs e)
    {
      if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
        var fileNames = e.Data.GetData(DataFormats.FileDrop) as string[];
        var addFileResults = mAgent.AddFiles(fileNames, GetPassword);
        foreach (var result in addFileResults) {
          MessageBox.Show(string.Format("File '{0}' failed with error: {1}",
            result.Key, result.Value.Message));
        }
      }
    }

    private SecureString GetPassword()
    {
      var dialog = new PasswordDialog();
      var result = dialog.ShowDialog();
      if (result != DialogResult.OK) {
        return null;
      }
      return dialog.SecureEdit.SecureString;
    }
    
  }
}
