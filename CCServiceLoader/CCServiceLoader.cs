using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CC.Service.Loader
{
    /// <summary>
    /// CCServiceLoader loads up Plugins that implement the interface ICCServiceInterface
    /// It searches in the Application Directory and any sub directories
    /// For each object that implements ICCServiceInterface it creates a System.Timers.Timers
    /// for each interval.
    /// For Instance. If you have Three Plugins and they each have a five minute interval you will only
    /// end up with one Timer object.
    /// Each timer object will pause itself, then call the OnTick method in each plugin object
    /// If you need your own space or don't want to interrupt any other process set the
    /// needOwnTimer to true. This will force the system to create a Timer object just for you
    /// </summary>
    public class CCServiceLoader
    {
        //public List<string> pluginList;
        public readonly List<ICCServiceInterface> Plugins;
        private readonly List<CCTimer> _timers;
        private readonly ICCServiceHost _host;

        public CCServiceLoader(ICCServiceHost host)
        {
            Plugins = new List<ICCServiceInterface>();
            _timers = new List<CCTimer>();
            _host = host;
        }

        private static int ComparePluginPriority(ICCServiceInterface a, ICCServiceInterface b)
        {
            return a.Priority.CompareTo(b.Priority);
        }

        /// <summary>
        /// Only Loads Plugins in the same directory or below from the application.
        /// This allows you to have your own directory or resources.
        /// </summary>
        public void LoadPlugins()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar;
            var files = Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories);
            //AppDomainSetup setup = new AppDomainSetup();
            //setup.ApplicationBase = path;
            foreach (var file in files)
            {
                var assembly = Assembly.LoadFile(file);
                foreach (var t in assembly.GetTypes())
                {
                    // Only look for public classes
                    if (!t.IsPublic) continue;
                    // That are not Abstract Classes
                    if ((t.Attributes & TypeAttributes.Abstract) == TypeAttributes.Abstract) continue;
                    var obj = t.GetInterface("ICCServiceInterface", true);
                    if (obj == null) continue;
                    //string binPath = Path.GetDirectoryName(file) + Path.DirectorySeparatorChar;
                    //if (!binPath.Equals(path))
                    //  setup.PrivateBinPath += binPath + ";";

                    //pluginList.Add(file.Replace(path, ""));
                    var plugin = (ICCServiceInterface) assembly.CreateInstance(t.FullName);
                    var needOwnTimer = false;
                    if (plugin == null) continue;
                    plugin.Initialize(_host, ref needOwnTimer);
                    Plugins.Add(plugin);

                    var timer = GetTimer(plugin.Interval, needOwnTimer);
                    timer.Add(plugin);
                    //_timers.Add(timer);
                }
            }

            Plugins.Sort(ComparePluginPriority);

            // Debug
            _host.ShowMessage(this, "Timers = " + _timers.Count.ToString());
        }

        internal CCTimer GetTimer(double interval, bool needsOwnTimer)
        {
            CCTimer ret = null;

            if (!needsOwnTimer)
            {
                foreach (var timer in _timers)
                {
                    if (timer.MyOwn) continue;
                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    if (timer.Interval != interval) continue;
                    ret = timer;
                    break;
                }
            }

            if (ret != null) return ret; // Should never be null
            ret = new CCTimer(interval) {MyOwn = needsOwnTimer};
            _timers.Add(ret);

            return ret; // Should never be null
        }

        public void StartPlugins()
        {
            foreach (var plugin in Plugins)
                plugin.OnStart();

            foreach (var timer in _timers)
                timer.Enabled = true;
        }

        public void StopPlugins()
        {
            foreach (var timer in _timers)
                timer.Enabled = false;

            foreach (var plugin in Plugins)
                plugin.OnStop();
        }

        public override string ToString()
        {
            return "CCServiceLoader";
        }

        //I'm not using this now, but it may be handy in the future - YAGNI
        /*
        public ICCServiceInterface FindPlugin(string name)
        {
            return Plugins.FirstOrDefault(plugin => plugin.Name == name);
        }

        public void StartPlugin(string name)
        {
            var plugin = FindPlugin(name);
            if (plugin != null)
                plugin.OnStart();
        }

        public void StopPlugin(string name)
        {
            var plugin = FindPlugin(name);
            if (plugin != null)
                plugin.OnStop();
        }
        */
    }
}
