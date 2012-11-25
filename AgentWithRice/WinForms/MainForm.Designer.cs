namespace dlech.AgentWithRice.WinForms
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
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.removeAllbutton = new System.Windows.Forms.Button();
      this.keyInfoViewer = new dlech.AgentWithRice.WinForms.KeyInfoViewer();
      this.keyWrapperBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.keyWrapperBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // addKeyButton
      // 
      this.addKeyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.addKeyButton.AutoSize = true;
      this.addKeyButton.Location = new System.Drawing.Point(165, 3);
      this.addKeyButton.Name = "addKeyButton";
      this.addKeyButton.Size = new System.Drawing.Size(75, 23);
      this.addKeyButton.TabIndex = 1;
      this.addKeyButton.Text = "Add...";
      this.addKeyButton.UseVisualStyleBackColor = true;
      this.addKeyButton.Click += new System.EventHandler(this.addKeyButton_Click);
      // 
      // removeKeyButton
      // 
      this.removeKeyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.removeKeyButton.AutoSize = true;
      this.removeKeyButton.Location = new System.Drawing.Point(246, 3);
      this.removeKeyButton.Name = "removeKeyButton";
      this.removeKeyButton.Size = new System.Drawing.Size(75, 23);
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
      this.unlockButton.Location = new System.Drawing.Point(84, 3);
      this.unlockButton.Name = "unlockButton";
      this.unlockButton.Size = new System.Drawing.Size(75, 23);
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
      this.lockButton.Size = new System.Drawing.Size(75, 23);
      this.lockButton.TabIndex = 4;
      this.lockButton.Text = "Lock";
      this.lockButton.UseVisualStyleBackColor = true;
      this.lockButton.Click += new System.EventHandler(this.lockButton_Click);
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.tableLayoutPanel1.AutoSize = true;
      this.tableLayoutPanel1.ColumnCount = 5;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel1.Controls.Add(this.removeAllbutton, 4, 0);
      this.tableLayoutPanel1.Controls.Add(this.lockButton, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.unlockButton, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.removeKeyButton, 3, 0);
      this.tableLayoutPanel1.Controls.Add(this.addKeyButton, 2, 0);
      this.tableLayoutPanel1.Location = new System.Drawing.Point(142, 170);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(405, 29);
      this.tableLayoutPanel1.TabIndex = 6;
      // 
      // removeAllbutton
      // 
      this.removeAllbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.removeAllbutton.AutoSize = true;
      this.removeAllbutton.Location = new System.Drawing.Point(327, 3);
      this.removeAllbutton.Name = "removeAllbutton";
      this.removeAllbutton.Size = new System.Drawing.Size(75, 23);
      this.removeAllbutton.TabIndex = 5;
      this.removeAllbutton.Text = "Remove All";
      this.removeAllbutton.UseVisualStyleBackColor = true;
      this.removeAllbutton.Click += new System.EventHandler(this.removeAllbutton_Click);
      // 
      // keyInfoDataGridView1
      // 
      this.keyInfoViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.keyInfoViewer.Location = new System.Drawing.Point(12, 12);
      this.keyInfoViewer.Name = "keyInfoDataGridView1";
      this.keyInfoViewer.Size = new System.Drawing.Size(678, 152);
      this.keyInfoViewer.TabIndex = 5;
      // 
      // keyWrapperBindingSource
      // 
      this.keyWrapperBindingSource.DataSource = typeof(dlech.AgentWithRice.KeyWrapper);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(702, 211);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Controls.Add(this.keyInfoViewer);
      this.Name = "MainForm";
      this.Text = "Agent With Rice";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.keyWrapperBindingSource)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.BindingSource keyWrapperBindingSource;
    private System.Windows.Forms.Button addKeyButton;
    private System.Windows.Forms.Button removeKeyButton;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.Button unlockButton;
    private System.Windows.Forms.Button lockButton;
    private WinForms.KeyInfoViewer keyInfoViewer;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Button removeAllbutton;
  }
}

