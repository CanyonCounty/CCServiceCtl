using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CC.Service.Loader;
using CC.Common.Utils;

namespace CCServiceDebug
{
  public partial class frmMain : Form, CCServiceHost
  {
    private ListViewColumnSorter lvwColumnSorter;
    private CCServiceLoader loader;
    private CCLogger logger;
    //private CCServiceInterface _sender;
    //private String _msg;

    public frmMain()
    {
      InitializeComponent();
      lvwColumnSorter = new ListViewColumnSorter();
      this.lvMessage.ListViewItemSorter = lvwColumnSorter;
      this.logger = new CCLogger();
      logger.Clear();
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
      loader = new CCServiceLoader(this);
      loader.LoadPlugins();
      foreach (CCServiceInterface plugin in loader.plugins)
      {
        //listBox1.Items.Add(plugin.Name);
        listBox1.Items.Add(plugin.Name + " (" + plugin.Priority.ToString() + ")");
      }
    }

    private void HandleMessages(string name, string msg, bool debug)
    {
      string _name = name;
      String _msg = msg;
      DateTime _now = DateTime.Now;

      if (debug) _msg = "DEBUG: " + _msg;

      this.Invoke((MethodInvoker)delegate
      {
        ListViewItem item = new ListViewItem(_now.ToString());
        item.SubItems.Add(_name);
        item.SubItems.Add(_msg);
        lvMessage.Items.Add(item);
        logger.Write(_name + ": " + _msg);
      });

      Application.DoEvents();
    }

    public void ShowMessage(CCServiceInterface sender, string msg)
    {
      HandleMessages(sender.Name, msg, false);
    }
    
    public void ShowMessage(object sender, string msg)
    {
      HandleMessages(sender.ToString(), msg, false);
    }

    public void DebugMessage(CCServiceInterface sender, string msg)
    {
      HandleMessages(sender.Name, msg, true);
    }

    public void DebugMessage(object sender, string msg)
    {
      HandleMessages(sender.ToString(), msg, true);
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

    private void lvMessage_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      // Determine if clicked column is already the column that is being sorted.
      if (e.Column == lvwColumnSorter.SortColumn)
      {
        // Reverse the current sort direction for this column.
        if (lvwColumnSorter.Order == SortOrder.Ascending)
        {
          lvwColumnSorter.Order = SortOrder.Descending;
        }
        else
        {
          lvwColumnSorter.Order = SortOrder.Ascending;
        }
      }
      else
      {
        // Set the column number that is to be sorted; default to ascending.
        lvwColumnSorter.SortColumn = e.Column;
        lvwColumnSorter.Order = SortOrder.Ascending;
      }

      // Perform the sort with these new sort options.
      this.lvMessage.Sort();

    }
  }
}
