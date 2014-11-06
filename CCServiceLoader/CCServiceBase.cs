using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CC.Service.Loader;
using System.Reflection;
using System.IO;

namespace CC.Service.Loader
{
  /// <summary>
  /// Helper class that makes implementing CCServiceInterface easier
  /// Defaults to a five minute interval
  /// All you have to define is the Name property and OnTick method
  /// </summary>
  public abstract class CCServiceBase : CCServiceInterface
  {
    /// <summary>
    /// Defines One Second
    /// </summary>
    public const double SECOND = 1000;
    public const double SECONDS = SECOND; // cleaner code 5 * SECONDS looks better than 5 * SECOND
    /// <summary>
    /// Defines One Minute
    /// </summary>
    public const double MINUTE = 60 * SECOND;
    public const double MINUTES = MINUTE;
    /// <summary>
    /// Defines One Hour
    /// </summary>
    public const double HOUR = 60 * MINUTE;
    public const double HOURS = HOUR;
    /// <summary>
    /// Defines One Day
    /// </summary>
    public const double DAY = 24 * HOUR;
    public const double DAYS = DAY;
    /// <summary>
    /// Default Interval of 5 minutes
    /// </summary>
    public const double DEFAULT_INTERVAL = 5 * MINUTE;

    /// <summary>
    /// Helper property. If you're OnTick method takes more time then your set Interval check Die to see if your plugin got the OnStop message
    /// </summary>
    public bool Die;
    /// <summary>
    /// Helper object. There if you don't want to override Initialize
    /// </summary>
    public CCServiceHost Host;

    /// <summary>
    /// This is used in the Host ShowMessage more like a DisplayName
    /// </summary>
    public abstract string Name { get; }
    /// <summary>
    /// Overridable property to set the interval you'd like OnTick to be called
    /// </summary>
    public virtual Double Interval
    {
      get { return DEFAULT_INTERVAL; }
    }

    /// <summary>
    /// Overridable method that is called before your plugin can do anything. Like a Form OnLoad
    /// </summary>
    /// <param name="host">The Host controller object to send messages to the host service or application</param>
    /// <param name="needOwnThread">Set this to true if you require your own thread (if you can't play nice with other plugins)</param>
    public virtual void Initialize(CCServiceHost host, ref bool needOwnThread)
    {
      Host = host;
      needOwnThread = false;
      
      //AppDomain currentDomain = AppDomain.CurrentDomain;
      //currentDomain.AssemblyResolve += new ResolveEventHandler(LoadFromSameFolderResolveEventHandler);
    }
    /// <summary>
    /// This gets called ONCE when your service plugin is told to start
    /// </summary>
    public virtual void OnStart()
    {
      Die = false;
    }
    /// <summary>
    /// This gets called ONCE when your service plugin is told to stop. This can occur BEFORE your OnTick is complete
    /// </summary>
    public virtual void OnStop()
    {
      Die = true;
    }
    /// <summary>
    /// Use OnTick to define what code gets executed each interval. Break your code into workable chuncks. Between each chunk check Die to see if you should continue.
    /// </summary>
    public abstract void OnTick();

    /*
    static Assembly LoadFromSameFolderResolveEventHandler(object sender, ResolveEventArgs args) 
    { 
      string folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); 
      string assemblyPath = Path.Combine(folderPath, args.Name.Split(',')[0] + ".dll"); 
      Assembly assembly = Assembly.LoadFrom(assemblyPath); return assembly; 
    }
    */
  }
}
