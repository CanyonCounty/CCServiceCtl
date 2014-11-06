using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.IO;
using System.Reflection;

namespace CC.Service.Loader
{
  /// <summary>
  /// CCServiceLoader loads up plugins that implement the interface CCServiceInterface
  /// It searches in the Application Directory and any sub directories
  /// For each object that implements CCServiceInterface it creates a System.Timers.Timers
  /// for each Interval.
  /// For Instance. If you have Three Plugins and they each have a five minute interval you will only
  /// end up with one Timer object.
  /// Each timer object will pause itself, then call the OnTick method in each plugin object
  /// If you need your own space or don't want to interrupt any other process set the
  /// needOwnTimer to true. This will force the system to create a Timer object just for you
  /// </summary>
  public class CCServiceLoader
  {
    //public List<string> pluginList;
    public List<CCServiceInterface> plugins;
    private List<CCTimer> timers;
    private CCServiceHost host;

    public CCServiceLoader(CCServiceHost host)
    {
      this.plugins = new List<CCServiceInterface>();
      this.timers = new List<CCTimer>();
      this.host = host;
    }

    /// <summary>
    /// Only Loads plugins in the same directory or below from the application.
    /// This allows you to have your own directory or resources.
    /// </summary>
    public void LoadPlugins()
    {
      string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar;
      string[] files = Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories);
      //AppDomainSetup setup = new AppDomainSetup();
      //setup.ApplicationBase = path;
      foreach (string file in files)
      {
        Assembly assembly = Assembly.LoadFile(file);
        foreach (Type t in assembly.GetTypes())
        {
          // Only look for public classes
          if (t.IsPublic)
          {
            // That are not Abstract Classes
            if (!((t.Attributes & TypeAttributes.Abstract) == TypeAttributes.Abstract))
            {
              Type obj = t.GetInterface("CCServiceInterface", true);
              if (obj != null)
              {
                //string binPath = Path.GetDirectoryName(file) + Path.DirectorySeparatorChar;
                //if (!binPath.Equals(path))
                //  setup.PrivateBinPath += binPath + ";";
                
                //pluginList.Add(file.Replace(path, ""));
                CCServiceInterface plugin = (CCServiceInterface)assembly.CreateInstance(t.FullName);
                bool needOwnTimer = false;
                plugin.Initialize(this.host, ref needOwnTimer);
                plugins.Add(plugin);
                
                CCTimer timer = GetTimer(plugin.Interval, needOwnTimer);
                timer.Add(plugin);
                //timers.Add(timer);
              }
            }
          }
        }
      }

      // Debug
      host.ShowMessage(this, "Timers = " + timers.Count.ToString());
    }
    
    /*
    public CCServiceInterface FindPlugin(string name)
    {
      CCServiceInterface ret = null;

      foreach (CCServiceInterface plugin in plugins)
      {
        if (plugin.Name == name)
        {
          ret = plugin;
          break;
        }
      }

      return ret;
    }
    */
    
    internal CCTimer GetTimer(double Interval, bool needsOwnTimer)
    {
      CCTimer ret = null;

      if (!needsOwnTimer)
      {
        foreach (CCTimer timer in timers)
        {
          if (!timer.MyOwn)
          {
            if (timer.Interval == Interval)
            {
              ret = timer;
              break;
            }
          }
        }
      }

      if (ret == null)
      {
        ret = new CCTimer(Interval);
        ret.MyOwn = needsOwnTimer;
        timers.Add(ret);
      }

      return ret; // Should never be null
    }

    /*
    public void StartPlugin(string name)
    {
      CCServiceInterface plugin = FindPlugin(name);
      if (plugin != null)
        plugin.OnStart();
    }

    public void StopPlugin(string name)
    {
      CCServiceInterface plugin = FindPlugin(name);
      if (plugin != null)
        plugin.OnStop();
    }
    */

    public void StartPlugins()
    {
      foreach (CCServiceInterface plugin in plugins)
        plugin.OnStart();

      foreach (CCTimer timer in timers)
        timer.Enabled = true;
    }

    public void StopPlugins()
    {
      foreach (CCTimer timer in timers)
        timer.Enabled = false;

      foreach (CCServiceInterface plugin in plugins)
        plugin.OnStop();
    }

    public override string ToString()
    {
      return "CCServiceLoader";
    }
  }
}
