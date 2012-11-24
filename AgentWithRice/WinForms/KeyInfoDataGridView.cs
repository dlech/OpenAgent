using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dlech.SshAgentLib;

namespace dlech.AgentWithRice.WinForms
{
  public partial class KeyInfoDataGridView : UserControl
  {
    private Agent mAgent;
    BindingList<KeyWrapper> mKeyCollection;

    public DataGridViewSelectedRowCollection SelectedRows
    {
      get
      {
        return dataGridView1.SelectedRows;
      }
    }


    public KeyInfoDataGridView()
    {
      InitializeComponent();
    }

    public void SetAgent(Agent aAgent)
    {      
      mAgent = aAgent;

      mKeyCollection = new BindingList<KeyWrapper>();
      dataGridView1.DataSource = mKeyCollection;
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
      dataGridView1.Visible = mAgent.KeyList.Count() > 0 && !mAgent.IsLocked;
      if (mAgent.IsLocked) {
        messageLabel.Text = "Locked";
      } else {
        messageLabel.Text = "No Keys Loaded";
      }
    }
  }
}
