namespace dlech.AgentWithRice.WinForms
{
  partial class KeyManagerForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.addKeyButton = new System.Windows.Forms.Button();
      this.removeKeyButton = new System.Windows.Forms.Button();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.unlockButton = new System.Windows.Forms.Button();
      this.lockButton = new System.Windows.Forms.Button();
      this.buttonTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
      this.removeAllbutton = new System.Windows.Forms.Button();
      this.refreshButton = new System.Windows.Forms.Button();
      this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
      this.keyInfoViewer = new dlech.AgentWithRice.WinForms.KeyInfoView();
      this.keyWrapperBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.buttonTableLayoutPanel.SuspendLayout();
      this.mainTableLayoutPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.keyWrapperBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // addKeyButton
      // 
      this.addKeyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.addKeyButton.AutoSize = true;
      this.addKeyButton.Location = new System.Drawing.Point(233, 3);
      this.addKeyButton.Name = "addKeyButton";
      this.addKeyButton.Size = new System.Drawing.Size(109, 23);
      this.addKeyButton.TabIndex = 1;
      this.addKeyButton.Text = "Add...";
      this.addKeyButton.UseVisualStyleBackColor = true;
      this.addKeyButton.Click += new System.EventHandler(this.addKeyButton_Click);
      // 
      // removeKeyButton
      // 
      this.removeKeyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.removeKeyButton.AutoSize = true;
      this.removeKeyButton.Location = new System.Drawing.Point(348, 3);
      this.removeKeyButton.Name = "removeKeyButton";
      this.removeKeyButton.Size = new System.Drawing.Size(109, 23);
      this.removeKeyButton.TabIndex = 2;
      this.removeKeyButton.Text = "Remove";
      this.removeKeyButton.UseVisualStyleBackColor = true;
      this.removeKeyButton.Click += new System.EventHandler(this.removeKeyButton_Click);
      // 
      // openFileDialog
      // 
      this.openFileDialog.Filter = "Putty Private Key files|*.ppk|All files|*.*";
      this.openFileDialog.Multiselect = true;
      this.openFileDialog.Title = "Open SSH Key File";
      this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
      // 
      // unlockButton
      // 
      this.unlockButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.unlockButton.AutoSize = true;
      this.unlockButton.Location = new System.Drawing.Point(118, 3);
      this.unlockButton.Name = "unlockButton";
      this.unlockButton.Size = new System.Drawing.Size(109, 23);
      this.unlockButton.TabIndex = 3;
      this.unlockButton.Text = "Unlock";
      this.unlockButton.UseVisualStyleBackColor = true;
      this.unlockButton.Click += new System.EventHandler(this.unlockButton_Click);
      // 
      // lockButton
      // 
      this.lockButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.lockButton.AutoSize = true;
      this.lockButton.Location = new System.Drawing.Point(3, 3);
      this.lockButton.Name = "lockButton";
      this.lockButton.Size = new System.Drawing.Size(109, 23);
      this.lockButton.TabIndex = 4;
      this.lockButton.Text = "Lock";
      this.lockButton.UseVisualStyleBackColor = true;
      this.lockButton.Click += new System.EventHandler(this.lockButton_Click);
      // 
      // buttonTableLayoutPanel
      // 
      this.buttonTableLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.buttonTableLayoutPanel.AutoSize = true;
      this.buttonTableLayoutPanel.ColumnCount = 6;
      this.buttonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
      this.buttonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
      this.buttonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
      this.buttonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
      this.buttonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
      this.buttonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
      this.buttonTableLayoutPanel.Controls.Add(this.lockButton, 0, 0);
      this.buttonTableLayoutPanel.Controls.Add(this.unlockButton, 1, 0);
      this.buttonTableLayoutPanel.Controls.Add(this.addKeyButton, 2, 0);
      this.buttonTableLayoutPanel.Controls.Add(this.removeKeyButton, 3, 0);
      this.buttonTableLayoutPanel.Controls.Add(this.removeAllbutton, 4, 0);
      this.buttonTableLayoutPanel.Controls.Add(this.refreshButton, 6, 0);
      this.buttonTableLayoutPanel.Location = new System.Drawing.Point(3, 170);
      this.buttonTableLayoutPanel.Name = "buttonTableLayoutPanel";
      this.buttonTableLayoutPanel.RowCount = 1;
      this.buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.buttonTableLayoutPanel.Size = new System.Drawing.Size(693, 29);
      this.buttonTableLayoutPanel.TabIndex = 6;
      // 
      // removeAllbutton
      // 
      this.removeAllbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.removeAllbutton.AutoSize = true;
      this.removeAllbutton.Location = new System.Drawing.Point(463, 3);
      this.removeAllbutton.Name = "removeAllbutton";
      this.removeAllbutton.Size = new System.Drawing.Size(109, 23);
      this.removeAllbutton.TabIndex = 5;
      this.removeAllbutton.Text = "Remove All";
      this.removeAllbutton.UseVisualStyleBackColor = true;
      this.removeAllbutton.Click += new System.EventHandler(this.removeAllbutton_Click);
      // 
      // refreshButton
      // 
      this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.refreshButton.AutoSize = true;
      this.refreshButton.Location = new System.Drawing.Point(578, 3);
      this.refreshButton.Name = "refreshButton";
      this.refreshButton.Size = new System.Drawing.Size(112, 23);
      this.refreshButton.TabIndex = 6;
      this.refreshButton.Text = "Refresh";
      this.refreshButton.UseVisualStyleBackColor = true;
      this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
      // 
      // mainTableLayoutPanel
      // 
      this.mainTableLayoutPanel.ColumnCount = 1;
      this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.mainTableLayoutPanel.Controls.Add(this.keyInfoViewer, 0, 0);
      this.mainTableLayoutPanel.Controls.Add(this.buttonTableLayoutPanel, 0, 1);
      this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
      this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
      this.mainTableLayoutPanel.RowCount = 2;
      this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.mainTableLayoutPanel.Size = new System.Drawing.Size(699, 202);
      this.mainTableLayoutPanel.TabIndex = 7;
      // 
      // keyInfoViewer
      // 
      this.keyInfoViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.keyInfoViewer.AutoSize = true;
      this.keyInfoViewer.Location = new System.Drawing.Point(3, 3);
      this.keyInfoViewer.Name = "keyInfoViewer";
      this.keyInfoViewer.Size = new System.Drawing.Size(693, 161);
      this.keyInfoViewer.TabIndex = 5;
      // 
      // keyWrapperBindingSource
      // 
      this.keyWrapperBindingSource.DataSource = typeof(dlech.AgentWithRice.KeyWrapper);
      // 
      // KeyManagerForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(699, 202);
      this.Controls.Add(this.mainTableLayoutPanel);
      this.Name = "KeyManagerForm";
      this.Text = "Agent With Rice";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.buttonTableLayoutPanel.ResumeLayout(false);
      this.buttonTableLayoutPanel.PerformLayout();
      this.mainTableLayoutPanel.ResumeLayout(false);
      this.mainTableLayoutPanel.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.keyWrapperBindingSource)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.BindingSource keyWrapperBindingSource;
    private System.Windows.Forms.Button addKeyButton;
    private System.Windows.Forms.Button removeKeyButton;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.Button unlockButton;
    private System.Windows.Forms.Button lockButton;
    private WinForms.KeyInfoView keyInfoViewer;
    private System.Windows.Forms.TableLayoutPanel buttonTableLayoutPanel;
    private System.Windows.Forms.Button removeAllbutton;
    private System.Windows.Forms.Button refreshButton;
    private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
  }
}

