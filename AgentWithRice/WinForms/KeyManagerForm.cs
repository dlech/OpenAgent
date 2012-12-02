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

namespace dlech.AgentWithRice.WinForms
{
  public partial class KeyManagerForm : Form
  {
    public KeyManagerForm()
    {
      InitializeComponent();      
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      keyInfoViewer.SetAgent(Program.Agent);      
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      Properties.Settings.Default.Save();      
    }
  }
}
