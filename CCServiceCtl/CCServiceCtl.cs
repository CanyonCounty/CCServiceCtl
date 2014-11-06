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

namespace CCServiceCtl
{
  partial class CCServiceCtl : ServiceBase, CCServiceHost
  {
    private CCServiceLoader loader;
    
    public CCServiceCtl()
    {
      InitializeComponent();
      
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

    public void ShowMessage(CCServiceInterface sender, string msg)
    {
      CCLogger.WriteLog(sender.Name + ": " + msg);
    }

    public void ShowMessage(object sender, string msg)
    {
      CCLogger.WriteLog(sender.ToString() + ": " + msg);
    }

  }
}
