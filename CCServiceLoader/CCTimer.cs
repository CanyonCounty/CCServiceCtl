using System;
using System.Collections.Generic;
using System.Timers;

namespace CC.Service.Loader
{
    internal class CCTimer
    {
        private readonly Timer _timer;
        private readonly List<ICCServiceInterface> _plugins;
        private bool _enable;

        public CCTimer(double interval)
        {
            _plugins = new List<ICCServiceInterface>();
            _timer = new Timer(interval);
            _timer.Elapsed += TimerTick;

            _timer.Enabled = false;
            MyOwn = false;
        }

        public bool MyOwn { get; set; }

        public bool Enabled
        {
            get { return _timer.Enabled; }
            set
            {
                _timer.Enabled = value;
                _enable = value;
            }
        }

        public double Interval
        {
            get { return _timer.Interval; }
        }

        public void Add(ICCServiceInterface plugin)
        {
            _plugins.Add(plugin);
        }

        public void AddRange(IEnumerable<ICCServiceInterface> plugins)
        {
            _plugins.AddRange(plugins);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            _timer.Enabled = false;
            foreach (var plugin in _plugins)
            {
                plugin.OnTick();
            }

            // Check to see if we should continue
            if (_enable) _timer.Enabled = true;
        }
    }
}
