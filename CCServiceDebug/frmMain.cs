using System;
using System.Globalization;
using System.Windows.Forms;
using CC.Service.Loader;

namespace CC.Service.Debug
{
  public partial class FrmMain : Form, ICCServiceHost
  {
    private readonly ListViewColumnSorter _lvwColumnSorter;
    private CCServiceLoader _loader;
    private readonly CCLogger _logger;
    //private CCServiceInterface _sender;
    //private String _msg;

    public FrmMain()
    {
      InitializeComponent();
      _lvwColumnSorter = new ListViewColumnSorter();
      lvMessage.ListViewItemSorter = _lvwColumnSorter;
      _logger = new CCLogger();
      _logger.Clear();
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
      _loader = new CCServiceLoader(this);
      _loader.LoadPlugins();
      foreach (var plugin in _loader.plugins)
      {
        //listBox1.Items.Add(plugin.Name);
        listBox1.Items.Add(plugin.Name + " (" + plugin.Priority.ToString() + ")");
      }
    }

    private void HandleMessages(string name, string msg, bool debug)
    {
      var now = DateTime.Now;

      if (debug) msg = "DEBUG: " + msg;

      Invoke((MethodInvoker)delegate
      {
        var item = new ListViewItem(now.ToString(CultureInfo.CurrentCulture));
        item.SubItems.Add(name);
        item.SubItems.Add(msg);
        lvMessage.Items.Add(item);
        _logger.Write(name + ": " + msg);
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
      _loader.StartPlugins();
    }

    private void btnStop_Click(object sender, EventArgs e)
    {
      _loader.StopPlugins();
    }

    private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      _loader.StopPlugins();
    }

    private void lvMessage_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      // Determine if clicked column is already the column that is being sorted.
      if (e.Column == _lvwColumnSorter.SortColumn)
      {
        // Reverse the current sort direction for this column.
        _lvwColumnSorter.Order = _lvwColumnSorter.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
      }
      else
      {
        // Set the column number that is to be sorted; default to ascending.
        _lvwColumnSorter.SortColumn = e.Column;
        _lvwColumnSorter.Order = SortOrder.Ascending;
      }

      // Perform the sort with these new sort options.
      lvMessage.Sort();

    }
  }
}
