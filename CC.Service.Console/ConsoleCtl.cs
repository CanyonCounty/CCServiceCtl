using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CC.Service.Loader;
using CC.Common.Utils;

namespace CC.Service.Console
{
  public class ConsoleCtl : CCServiceHost
  {
    private CCServiceLoader _loader;
    private CCLogger _logger;

    public ConsoleCtl()
    {
      _logger = new CCLogger();
      // Since this guy is designed to start and stop whenever, I don't want to clear the log EVER
      //_logger.Clear();
      
      _loader = new CCServiceLoader(this);
      _loader.LoadPlugins();
      foreach (CCServiceInterface plugin in _loader.plugins)
      {
        _logger.Write("Loading Plugin: " + plugin.Name + ". Ignoring Interval of: " + plugin.Interval.ToString());
      }
    }

    public void PerformAction()
    {
      // The loader.StartPlugins assumes a timer will be used
      // Roll your own to skip it.
      foreach (CCServiceInterface plugin in _loader.plugins)
      {
        plugin.OnStart();
        plugin.OnTick();
        plugin.OnStop();
      }
    }

    public void Start()
    {
      foreach (CCServiceInterface plugin in _loader.plugins)
        plugin.OnStart();
    }

    public void Stop()
    {
      foreach (CCServiceInterface plugin in _loader.plugins)
        plugin.OnStop();
    }

    public void Tick()
    {
      foreach (CCServiceInterface plugin in _loader.plugins)
        plugin.OnTick();
    }

    private void HandleMessages(string name, string msg, bool debug)
    {
      string _name = name;
      String _msg = msg;

      if (debug) _msg = "DEBUG: " + _msg;
      _logger.Write(_name + ": " + _msg);
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
  }
}
