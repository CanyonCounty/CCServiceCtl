using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using CC.Common.Utils;
using System.Timers;
using CC.Service.Loader;

namespace CC.Service.Ctl
{
  partial class CCServiceCtl : ServiceBase, CCServiceHost
  {
    private CCServiceLoader loader;
    private bool logDebug;
    private bool logMsg;
    
    public CCServiceCtl()
    {
      InitializeComponent();

      logDebug = Properties.Settings.Default.LogDebug;
      logMsg = Properties.Settings.Default.LogMsg;

      loader = new CCServiceLoader(this);
      loader.LoadPlugins();
    }

    protected override void OnStart(string[] args)
    {
      CCLogger.ClearLog();
      CCLogger.WriteLog("Starting Plugins");
      loader.StartPlugins();
    }

    protected override void OnStop()
    {
      CCLogger.WriteLog("Stopping Plugins");
      loader.StopPlugins();
    }

    private void HandleMessages(string name, string msg, bool debug)
    {
      if (debug)
      {
        msg = "DEBUG: " + msg;
      }
      CCLogger.WriteLog(name + ": " + msg);
    }

    public void ShowMessage(CCServiceInterface sender, string msg)
    {
      if (logMsg)
        HandleMessages(sender.Name, msg, false);
    }

    public void ShowMessage(object sender, string msg)
    {
      if (logMsg)
        HandleMessages(sender.ToString(), msg, false);
    }
    
    public void DebugMessage(CCServiceInterface sender, string msg)
    {
      if (logDebug)
        HandleMessages(sender.Name, msg, true);
    }

    public void DebugMessage(object sender, string msg)
    {
      if (logDebug)
        HandleMessages(sender.ToString(), msg, true);
    }

  }
}
