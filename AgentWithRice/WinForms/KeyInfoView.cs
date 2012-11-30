﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dlech.SshAgentLib;
using System.Security;
using System.IO;

namespace dlech.AgentWithRice.WinForms
{
  public partial class KeyInfoView : UserControl
  {
    private IAgent mAgent;
    BindingList<KeyWrapper> mKeyCollection;

    public KeyInfoView()
    {
      InitializeComponent();
    }

    public void SetAgent(IAgent aAgent)
    {
      mAgent = aAgent;

      mKeyCollection = new BindingList<KeyWrapper>();
      foreach (var key in mAgent.GetAllKeys()) {
        mKeyCollection.Add(new KeyWrapper(key));
      }
      dataGridView.DataSource = mKeyCollection;
      if (mAgent is Agent) {
        var agent = mAgent as Agent;
        agent.KeyListChanged += AgentKeyListChangeHandler;
        agent.Locked += AgentLockHandler;
      }
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
      var agent = mAgent as Agent;
      dataGridView.Visible = agent != null && agent.KeyCount > 0 &&
        !agent.IsLocked;
      if (agent != null && agent.IsLocked) {
        messageLabel.Text = Strings.keyInfoViewLocked;
      } else if (agent != null) {
        messageLabel.Text = Strings.keyInfoViewNoKeys;
      } else {
        messageLabel.Text = Strings.keyInfoViewClickRefresh;
      }
    }

    private void any_DragEnter(object sender, DragEventArgs e)
    {
      if ((mAgent != null) && e.Data.GetDataPresent(DataFormats.FileDrop)) {
        e.Effect = DragDropEffects.Move;
      } else {
        e.Effect = DragDropEffects.None;
      }
    }

    private void any_DragDrop(object sender, DragEventArgs e)
    {
      if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
        var fileNames = e.Data.GetData(DataFormats.FileDrop) as string[];
        if (mAgent != null) {
          UseWaitCursor = true;
          mAgent.AddKeysFromFiles(fileNames);
          UseWaitCursor = false;
        }
      }
    }
  }
}
