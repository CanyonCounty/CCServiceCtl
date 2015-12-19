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
        public const double Second = 1000;

        public const double Seconds = Second; // cleaner code 5 * Seconds looks better than 5 * Second

        /// <summary>
        /// Defines One Minute
        /// </summary>
        public const double Minute = 60 * Second;

        public const double Minutes = Minute;

        /// <summary>
        /// Defines One Hour
        /// </summary>
        public const double Hour = 60 * Minute;

        public const double Hours = Hour;

        /// <summary>
        /// Defines One Day
        /// </summary>
        public const double Day = 24 * Hour;

        public const double Days = Day;

        /// <summary>
        /// Default Interval of 5 minutes
        /// </summary>
        public const double DefaultInterval = 5 * Minutes;

        /// <summary>
        /// Default Priority - directly in the middle of MaxInt (plenty of room)
        /// </summary>
        public const int DefaultPriority = int.MaxValue / 2;

        /// <summary>
        /// Helper property. If you're OnTick method takes more time then your set Interval check Die to see if your plugin got the OnStop message
        /// </summary>
        protected bool Die;

        /// <summary>
        /// Helper object. There if you don't want to override Initialize
        /// </summary>
        public ICCServiceHost Host;

        /// <summary>
        /// This is used in the Host ShowMessage more like a DisplayName
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Overridable property to set the interval you'd like OnTick to be called
        /// </summary>
        public virtual double Interval
        {
            get { return DefaultInterval; }
        }

        public virtual int Priority
        {
            get { return DefaultPriority; }
        }

        /// <summary>
        /// Overridable method that is called before your plugin can do anything. Like a Form OnLoad
        /// </summary>
        /// <param name="host">The Host controller object to send messages to the host service or application</param>
        public virtual void Initialize(ICCServiceHost host)
        {
            var needOwnThread = false;
            Initialize(host, ref needOwnThread);
        }

        /// <summary>
        /// Overridable method that is called before your plugin can do anything. Like a Form OnLoad
        /// </summary>
        /// <param name="host">The Host controller object to send messages to the host service or application</param>
        /// <param name="needOwnThread">Set this to true if you require your own thread (if you can't play nice with other plugins)</param>
        public virtual void Initialize(ICCServiceHost host, ref bool needOwnThread)
        {
            Host = host;
            needOwnThread = false;

            //AppDomain currentDomain = AppDomain.CurrentDomain;
            //currentDomain.AssemblyResolve += new ResolveEventHandler(LoadFromSameFolderResolveEventHandler);
        }

        /// <summary>
        /// This gets called ONCE when your service plugin is told to start
        /// Don't forget to add base.OnStart(); in your own method
        /// </summary>
        public virtual void OnStart()
        {
            Die = false;
        }

        /// <summary>
        /// This gets called ONCE when your service plugin is told to stop. This can occur BEFORE your OnTick is complete
        /// Don't forget to add base.OnStop(); in your own method
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
