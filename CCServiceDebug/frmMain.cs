using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CC.Service.Loader;

namespace CCServiceDebug
{
  public partial class frmMain : Form, CCServiceHost
  {
    private CCServiceLoader loader;
    //private CCServiceInterface _sender;
    //private String _msg;

    public frmMain()
    {
      InitializeComponent();
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
      loader = new CCServiceLoader(this);
      loader.LoadPlugins();
      foreach (CCServiceInterface plugin in loader.plugins)
      {
        listBox1.Items.Add(plugin.Name);
      }
    }

    public void ShowMessage(CCServiceInterface sender, string msg)
    {
      //MessageBox.Show(sender.Name + ": " + msg);
      CCServiceInterface _sender = sender;
      String _msg = msg;
      this.Invoke((MethodInvoker)delegate
      {
        ListViewItem item = new ListViewItem(_sender.Name);
        item.SubItems.Add(_msg);
        lvMessage.Items.Add(item);
      });
    }
    
    public void ShowMessage(object sender, string msg)
    {
      object _sender = sender;
      String _msg = msg;
      this.Invoke((MethodInvoker)delegate
      {
        ListViewItem item = new ListViewItem(sender.ToString());
        item.SubItems.Add(_msg);
        lvMessage.Items.Add(item);
      });
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
      loader.StartPlugins();
    }

    private void btnStop_Click(object sender, EventArgs e)
    {
      loader.StopPlugins();
    }

    private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      loader.StopPlugins();
    }
  }
}
