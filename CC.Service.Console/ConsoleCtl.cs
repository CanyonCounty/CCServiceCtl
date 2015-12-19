using CC.Service.Loader;

namespace CC.Service.Console
{
  public class ConsoleCtl : ICCServiceHost
  {
    private readonly CCServiceLoader _loader;
    private readonly CCLogger _logger;

    public ConsoleCtl()
    {
      _logger = new CCLogger();
      // Since this guy is designed to start and stop whenever, I don't want to clear the log EVER
      //_logger.Clear();
      
      _loader = new CCServiceLoader(this);
      _loader.LoadPlugins();
      foreach (var plugin in _loader.Plugins)
      {
        _logger.Write("Loading Plugin: " + plugin.Name + ". Ignoring Interval of: " + plugin.Interval);
      }
    }

    public void PerformAction()
    {
      // The loader.StartPlugins assumes a timer will be used
      // Roll your own to skip it.
      foreach (var plugin in _loader.Plugins)
      {
        plugin.OnStart();
        plugin.OnTick();
        plugin.OnStop();
      }
    }

    public void Start()
    {
      foreach (var plugin in _loader.Plugins)
        plugin.OnStart();
    }

    public void Stop()
    {
      foreach (var plugin in _loader.Plugins)
        plugin.OnStop();
    }

    public void Tick()
    {
      foreach (var plugin in _loader.Plugins)
        plugin.OnTick();
    }

    private void HandleMessages(string name, string msg, bool debug)
    {
      if (debug) msg = "DEBUG: " + msg;
      _logger.Write(name + ": " + msg);
    }

    public void ShowMessage(ICCServiceInterface sender, string msg)
    {
      HandleMessages(sender.Name, msg, false);
    }

    public void ShowMessage(object sender, string msg)
    {
      HandleMessages(sender.ToString(), msg, false);
    }

    public void DebugMessage(ICCServiceInterface sender, string msg)
    {
      HandleMessages(sender.Name, msg, true);
    }

    public void DebugMessage(object sender, string msg)
    {
      HandleMessages(sender.ToString(), msg, true);
    }
  }
}
