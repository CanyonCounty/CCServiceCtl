namespace CCServiceDebug
{
  partial class frmMain
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
      this.listBox1 = new System.Windows.Forms.ListBox();
      this.btnStart = new System.Windows.Forms.Button();
      this.btnStop = new System.Windows.Forms.Button();
      this.lvMessage = new System.Windows.Forms.ListView();
      this.ColumnPlugin = new System.Windows.Forms.ColumnHeader();
      this.ColumnMsg = new System.Windows.Forms.ColumnHeader();
      this.SuspendLayout();
      // 
      // listBox1
      // 
      this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)));
      this.listBox1.FormattingEnabled = true;
      this.listBox1.Location = new System.Drawing.Point(13, 13);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new System.Drawing.Size(130, 186);
      this.listBox1.TabIndex = 0;
      // 
      // btnStart
      // 
      this.btnStart.Location = new System.Drawing.Point(149, 13);
      this.btnStart.Name = "btnStart";
      this.btnStart.Size = new System.Drawing.Size(75, 23);
      this.btnStart.TabIndex = 1;
      this.btnStart.Text = "Start";
      this.btnStart.UseVisualStyleBackColor = true;
      this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
      // 
      // btnStop
      // 
      this.btnStop.Location = new System.Drawing.Point(230, 13);
      this.btnStop.Name = "btnStop";
      this.btnStop.Size = new System.Drawing.Size(75, 23);
      this.btnStop.TabIndex = 2;
      this.btnStop.Text = "Stop";
      this.btnStop.UseVisualStyleBackColor = true;
      this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
      // 
      // lvMessage
      // 
      this.lvMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lvMessage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnPlugin,
            this.ColumnMsg});
      this.lvMessage.FullRowSelect = true;
      this.lvMessage.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.lvMessage.Location = new System.Drawing.Point(149, 42);
      this.lvMessage.MultiSelect = false;
      this.lvMessage.Name = "lvMessage";
      this.lvMessage.Size = new System.Drawing.Size(274, 157);
      this.lvMessage.TabIndex = 3;
      this.lvMessage.UseCompatibleStateImageBehavior = false;
      this.lvMessage.View = System.Windows.Forms.View.Details;
      // 
      // ColumnPlugin
      // 
      this.ColumnPlugin.Text = "Plugin";
      this.ColumnPlugin.Width = 70;
      // 
      // ColumnMsg
      // 
      this.ColumnMsg.Text = "Message";
      this.ColumnMsg.Width = 190;
      // 
      // frmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(435, 218);
      this.Controls.Add(this.lvMessage);
      this.Controls.Add(this.btnStop);
      this.Controls.Add(this.btnStart);
      this.Controls.Add(this.listBox1);
      this.Name = "frmMain";
      this.Text = "Service Debug";
      this.Load += new System.EventHandler(this.frmMain_Load);
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.Button btnStart;
    private System.Windows.Forms.Button btnStop;
    internal System.Windows.Forms.ListView lvMessage;
    internal System.Windows.Forms.ColumnHeader ColumnPlugin;
    internal System.Windows.Forms.ColumnHeader ColumnMsg;
  }
}

