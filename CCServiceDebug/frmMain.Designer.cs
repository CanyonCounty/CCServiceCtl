namespace CC.Service.Debug
{
  partial class FrmMain
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lvMessage = new System.Windows.Forms.ListView();
            this.ColumnDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnPlugin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnMsg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.listBox1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.lvMessage);
            this.splitContainer.Panel2.Controls.Add(this.btnStop);
            this.splitContainer.Panel2.Controls.Add(this.btnStart);
            this.splitContainer.Size = new System.Drawing.Size(525, 306);
            this.splitContainer.SplitterDistance = 146;
            this.splitContainer.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.IntegralHeight = false;
            this.listBox1.Location = new System.Drawing.Point(2, 16);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(144, 274);
            this.listBox1.TabIndex = 1;
            // 
            // lvMessage
            // 
            this.lvMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvMessage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnDate,
            this.ColumnPlugin,
            this.ColumnMsg});
            this.lvMessage.FullRowSelect = true;
            this.lvMessage.Location = new System.Drawing.Point(-1, 45);
            this.lvMessage.MultiSelect = false;
            this.lvMessage.Name = "lvMessage";
            this.lvMessage.Size = new System.Drawing.Size(370, 245);
            this.lvMessage.TabIndex = 6;
            this.lvMessage.UseCompatibleStateImageBehavior = false;
            this.lvMessage.View = System.Windows.Forms.View.Details;
            this.lvMessage.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvMessage_ColumnClick);
            // 
            // ColumnDate
            // 
            this.ColumnDate.Text = "Date";
            // 
            // ColumnPlugin
            // 
            this.ColumnPlugin.Text = "Plugin";
            this.ColumnPlugin.Width = 111;
            // 
            // ColumnMsg
            // 
            this.ColumnMsg.Text = "Message";
            this.ColumnMsg.Width = 147;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(80, 16);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(-1, 16);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 306);
            this.Controls.Add(this.splitContainer);
            this.Name = "FrmMain";
            this.Text = "Service Debug";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer;
    private System.Windows.Forms.ListBox listBox1;
    internal System.Windows.Forms.ListView lvMessage;
    private System.Windows.Forms.ColumnHeader ColumnDate;
    internal System.Windows.Forms.ColumnHeader ColumnPlugin;
    internal System.Windows.Forms.ColumnHeader ColumnMsg;
    private System.Windows.Forms.Button btnStop;
    private System.Windows.Forms.Button btnStart;

  }
}

