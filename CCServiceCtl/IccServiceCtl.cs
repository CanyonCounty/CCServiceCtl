using System.ServiceProcess;
using CC.Service.Loader;

namespace CC.Service.Ctl
{
  internal partial class IccServiceCtl : ServiceBase, ICCServiceHost
  {
    private readonly CCServiceLoader _loader;
    private readonly bool _logDebug;
    private readonly bool _logMsg;
    
    public IccServiceCtl()
    {
      InitializeComponent();

      _logDebug = Properties.Settings.Default.LogDebug;
      _logMsg = Properties.Settings.Default.LogMsg;

      _loader = new CCServiceLoader(this);
      _loader.LoadPlugins();
    }

    protected override void OnStart(string[] args)
    {
      CCLogger.ClearLog();
      CCLogger.WriteLog("Starting Plugins");
      _loader.StartPlugins();
    }

    protected override void OnStop()
    {
      CCLogger.WriteLog("Stopping Plugins");
      _loader.StopPlugins();
    }

    private static void HandleMessages(string name, string msg, bool debug)
    {
      if (debug)
      {
        msg = "DEBUG: " + msg;
      }
      CCLogger.WriteLog(name + ": " + msg);
    }

    public void ShowMessage(CCServiceInterface sender, string msg)
    {
        if (_logMsg)
        {
            HandleMessages(sender.Name, msg, false);
        }
    }

    public void ShowMessage(object sender, string msg)
    {
        if (_logMsg)
        {
            HandleMessages(sender.ToString(), msg, false);
        }
    }
    
    public void DebugMessage(CCServiceInterface sender, string msg)
    {
        if (_logDebug)
        {
            HandleMessages(sender.Name, msg, true);
        }
    }

    public void DebugMessage(object sender, string msg)
    {
        if (_logDebug)
        {
            HandleMessages(sender.ToString(), msg, true);
        }
    }

  }
}
