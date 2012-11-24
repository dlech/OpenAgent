﻿namespace dlech.AgentWithRice.WinForms
{
  partial class KeyInfoDataGridView
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.messageLabel = new System.Windows.Forms.Label();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.confirmDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.lifetimeDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.sizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.fingerprintDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.commentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.keyWrapperBindingSource = new System.Windows.Forms.BindingSource(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.keyWrapperBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // messageLabel
      // 
      this.messageLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.messageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.messageLabel.Location = new System.Drawing.Point(0, 0);
      this.messageLabel.Name = "messageLabel";
      this.messageLabel.Size = new System.Drawing.Size(553, 257);
      this.messageLabel.TabIndex = 0;
      this.messageLabel.Text = "Message";
      this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // dataGridView1
      // 
      this.dataGridView1.AllowDrop = true;
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.AllowUserToResizeRows = false;
      this.dataGridView1.AutoGenerateColumns = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.confirmDataGridViewCheckBoxColumn,
            this.lifetimeDataGridViewCheckBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.sizeDataGridViewTextBoxColumn,
            this.fingerprintDataGridViewTextBoxColumn,
            this.commentDataGridViewTextBoxColumn});
      this.dataGridView1.DataSource = this.keyWrapperBindingSource;
      this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView1.Location = new System.Drawing.Point(0, 0);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.ReadOnly = true;
      this.dataGridView1.RowHeadersVisible = false;
      this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new System.Drawing.Size(553, 257);
      this.dataGridView1.TabIndex = 1;
      // 
      // confirmDataGridViewCheckBoxColumn
      // 
      this.confirmDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.confirmDataGridViewCheckBoxColumn.DataPropertyName = "Confirm";
      this.confirmDataGridViewCheckBoxColumn.HeaderText = "C";
      this.confirmDataGridViewCheckBoxColumn.Name = "confirmDataGridViewCheckBoxColumn";
      this.confirmDataGridViewCheckBoxColumn.ReadOnly = true;
      this.confirmDataGridViewCheckBoxColumn.ToolTipText = "Confirm Constraint";
      this.confirmDataGridViewCheckBoxColumn.Width = 20;
      // 
      // lifetimeDataGridViewCheckBoxColumn
      // 
      this.lifetimeDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.lifetimeDataGridViewCheckBoxColumn.DataPropertyName = "Lifetime";
      this.lifetimeDataGridViewCheckBoxColumn.HeaderText = "L";
      this.lifetimeDataGridViewCheckBoxColumn.Name = "lifetimeDataGridViewCheckBoxColumn";
      this.lifetimeDataGridViewCheckBoxColumn.ReadOnly = true;
      this.lifetimeDataGridViewCheckBoxColumn.ToolTipText = "Lifetime Constraint";
      this.lifetimeDataGridViewCheckBoxColumn.Width = 19;
      // 
      // typeDataGridViewTextBoxColumn
      // 
      this.typeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
      this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
      this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
      this.typeDataGridViewTextBoxColumn.ReadOnly = true;
      this.typeDataGridViewTextBoxColumn.Width = 56;
      // 
      // sizeDataGridViewTextBoxColumn
      // 
      this.sizeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.sizeDataGridViewTextBoxColumn.DataPropertyName = "Size";
      this.sizeDataGridViewTextBoxColumn.HeaderText = "Size";
      this.sizeDataGridViewTextBoxColumn.Name = "sizeDataGridViewTextBoxColumn";
      this.sizeDataGridViewTextBoxColumn.ReadOnly = true;
      this.sizeDataGridViewTextBoxColumn.Width = 52;
      // 
      // fingerprintDataGridViewTextBoxColumn
      // 
      this.fingerprintDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.fingerprintDataGridViewTextBoxColumn.DataPropertyName = "Fingerprint";
      this.fingerprintDataGridViewTextBoxColumn.HeaderText = "Fingerprint";
      this.fingerprintDataGridViewTextBoxColumn.Name = "fingerprintDataGridViewTextBoxColumn";
      this.fingerprintDataGridViewTextBoxColumn.ReadOnly = true;
      this.fingerprintDataGridViewTextBoxColumn.Width = 81;
      // 
      // commentDataGridViewTextBoxColumn
      // 
      this.commentDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.commentDataGridViewTextBoxColumn.DataPropertyName = "Comment";
      this.commentDataGridViewTextBoxColumn.HeaderText = "Comment";
      this.commentDataGridViewTextBoxColumn.Name = "commentDataGridViewTextBoxColumn";
      this.commentDataGridViewTextBoxColumn.ReadOnly = true;
      this.commentDataGridViewTextBoxColumn.Width = 76;
      // 
      // keyWrapperBindingSource
      // 
      this.keyWrapperBindingSource.DataSource = typeof(dlech.AgentWithRice.KeyWrapper);
      // 
      // KeyInfoDataGridView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.dataGridView1);
      this.Controls.Add(this.messageLabel);
      this.Name = "KeyInfoDataGridView";
      this.Size = new System.Drawing.Size(553, 257);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.keyWrapperBindingSource)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label messageLabel;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.DataGridViewCheckBoxColumn confirmDataGridViewCheckBoxColumn;
    private System.Windows.Forms.DataGridViewCheckBoxColumn lifetimeDataGridViewCheckBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn sizeDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn fingerprintDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
    private System.Windows.Forms.BindingSource keyWrapperBindingSource;
  }
}
