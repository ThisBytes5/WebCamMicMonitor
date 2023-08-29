namespace WebCamMicMonitor
{
  partial class SettingsForm
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
      if (disposing && (components != null))
      {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
      this.LogListBox = new System.Windows.Forms.ListBox();
      this.label1 = new System.Windows.Forms.Label();
      this.startMinimizedCB = new System.Windows.Forms.CheckBox();
      this.autoStartCB = new System.Windows.Forms.CheckBox();
      this.label2 = new System.Windows.Forms.Label();
      this.postURLTxt = new System.Windows.Forms.TextBox();
      this.saveBTN = new System.Windows.Forms.Button();
      this.cancelBTN = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // LogListBox
      // 
      this.LogListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.LogListBox.FormattingEnabled = true;
      this.LogListBox.Location = new System.Drawing.Point(12, 139);
      this.LogListBox.Name = "LogListBox";
      this.LogListBox.Size = new System.Drawing.Size(776, 303);
      this.LogListBox.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 120);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(25, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Log";
      // 
      // startMinimizedCB
      // 
      this.startMinimizedCB.AutoSize = true;
      this.startMinimizedCB.Location = new System.Drawing.Point(12, 12);
      this.startMinimizedCB.Name = "startMinimizedCB";
      this.startMinimizedCB.Size = new System.Drawing.Size(97, 17);
      this.startMinimizedCB.TabIndex = 2;
      this.startMinimizedCB.Text = "Start Minimized";
      this.startMinimizedCB.UseVisualStyleBackColor = true;
      // 
      // autoStartCB
      // 
      this.autoStartCB.AutoSize = true;
      this.autoStartCB.Location = new System.Drawing.Point(115, 12);
      this.autoStartCB.Name = "autoStartCB";
      this.autoStartCB.Size = new System.Drawing.Size(152, 17);
      this.autoStartCB.TabIndex = 3;
      this.autoStartCB.Text = "Start when computer starts";
      this.autoStartCB.UseVisualStyleBackColor = true;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 38);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(53, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "Post URL";
      // 
      // postURLTxt
      // 
      this.postURLTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.postURLTxt.Location = new System.Drawing.Point(71, 35);
      this.postURLTxt.Name = "postURLTxt";
      this.postURLTxt.Size = new System.Drawing.Size(717, 20);
      this.postURLTxt.TabIndex = 5;
      // 
      // saveBTN
      // 
      this.saveBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.saveBTN.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.saveBTN.Location = new System.Drawing.Point(632, 61);
      this.saveBTN.Name = "saveBTN";
      this.saveBTN.Size = new System.Drawing.Size(75, 23);
      this.saveBTN.TabIndex = 6;
      this.saveBTN.Text = "Save";
      this.saveBTN.UseVisualStyleBackColor = true;
      this.saveBTN.Click += new System.EventHandler(this.saveBTN_Click);
      // 
      // cancelBTN
      // 
      this.cancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelBTN.Location = new System.Drawing.Point(713, 61);
      this.cancelBTN.Name = "cancelBTN";
      this.cancelBTN.Size = new System.Drawing.Size(75, 23);
      this.cancelBTN.TabIndex = 7;
      this.cancelBTN.Text = "Cancel";
      this.cancelBTN.UseVisualStyleBackColor = true;
      // 
      // SettingsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.cancelBTN);
      this.Controls.Add(this.saveBTN);
      this.Controls.Add(this.postURLTxt);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.autoStartCB);
      this.Controls.Add(this.startMinimizedCB);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.LogListBox);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "SettingsForm";
      this.Text = "Settings";
      this.Load += new System.EventHandler(this.SettingsForm_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ListBox LogListBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox startMinimizedCB;
    private System.Windows.Forms.CheckBox autoStartCB;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox postURLTxt;
    private System.Windows.Forms.Button saveBTN;
    private System.Windows.Forms.Button cancelBTN;
  }
}