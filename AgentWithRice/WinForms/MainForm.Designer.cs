namespace dlech.AgentWithRice
{
  partial class MainForm
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
      this.keyWrapperBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.keyInfoDataGridView1 = new dlech.AgentWithRice.WinForms.KeyInfoDataGridView();
      ((System.ComponentModel.ISupportInitialize)(this.keyWrapperBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // addKeyButton
      // 
      this.addKeyButton.Location = new System.Drawing.Point(341, 236);
      this.addKeyButton.Name = "addKeyButton";
      this.addKeyButton.Size = new System.Drawing.Size(75, 23);
      this.addKeyButton.TabIndex = 1;
      this.addKeyButton.Text = "Add...";
      this.addKeyButton.UseVisualStyleBackColor = true;
      this.addKeyButton.Click += new System.EventHandler(this.addKeyButton_Click);
      // 
      // removeKeyButton
      // 
      this.removeKeyButton.Location = new System.Drawing.Point(422, 236);
      this.removeKeyButton.Name = "removeKeyButton";
      this.removeKeyButton.Size = new System.Drawing.Size(75, 23);
      this.removeKeyButton.TabIndex = 2;
      this.removeKeyButton.Text = "Remove Key";
      this.removeKeyButton.UseVisualStyleBackColor = true;
      this.removeKeyButton.Click += new System.EventHandler(this.removeKeyButton_Click);
      // 
      // openFileDialog
      // 
      this.openFileDialog.Filter = "Putty Private Key files|*.ppk|OpenSSH SSH2 Private Key files|*.*";
      this.openFileDialog.Multiselect = true;
      this.openFileDialog.Title = "Open SSH Key File";
      this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
      // 
      // unlockButton
      // 
      this.unlockButton.Location = new System.Drawing.Point(260, 235);
      this.unlockButton.Name = "unlockButton";
      this.unlockButton.Size = new System.Drawing.Size(75, 23);
      this.unlockButton.TabIndex = 3;
      this.unlockButton.Text = "Unlock";
      this.unlockButton.UseVisualStyleBackColor = true;
      this.unlockButton.Click += new System.EventHandler(this.unlockButton_Click);
      // 
      // lockButton
      // 
      this.lockButton.Location = new System.Drawing.Point(179, 235);
      this.lockButton.Name = "lockButton";
      this.lockButton.Size = new System.Drawing.Size(75, 23);
      this.lockButton.TabIndex = 4;
      this.lockButton.Text = "Lock";
      this.lockButton.UseVisualStyleBackColor = true;
      this.lockButton.Click += new System.EventHandler(this.lockButton_Click);
      // 
      // keyWrapperBindingSource
      // 
      this.keyWrapperBindingSource.DataSource = typeof(dlech.AgentWithRice.KeyWrapper);
      // 
      // keyInfoDataGridView1
      // 
      this.keyInfoDataGridView1.Location = new System.Drawing.Point(130, 43);
      this.keyInfoDataGridView1.Name = "keyInfoDataGridView1";
      this.keyInfoDataGridView1.Size = new System.Drawing.Size(424, 129);
      this.keyInfoDataGridView1.TabIndex = 5;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(732, 434);
      this.Controls.Add(this.keyInfoDataGridView1);
      this.Controls.Add(this.lockButton);
      this.Controls.Add(this.unlockButton);
      this.Controls.Add(this.removeKeyButton);
      this.Controls.Add(this.addKeyButton);
      this.Name = "MainForm";
      this.Text = "Form1";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
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
    private WinForms.KeyInfoDataGridView keyInfoDataGridView1;
  }
}

