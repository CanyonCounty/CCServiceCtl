﻿using CC.Service.Loader;

namespace Plugin2
{
    public class MyOtherPlugin : ICCServiceInterface
    {
        private ICCServiceHost _host;

        public string Name
        {
            get { return "MyOtherPlugin"; }
        }

        public double Interval
        {
            get { return 1000; }
        }

        public int Priority
        {
            get { return int.MaxValue - 20; }
        }

        public void Initialize(ICCServiceHost host, ref bool needOwnTimer)
        {
            _host = host;
            host.ShowMessage(this, "Initialize");
        }

        public void OnStart()
        {
            _host.ShowMessage(this, "OnStart");
        }

        public void OnStop()
        {
            _host.ShowMessage(this, "OnStop");
        }

        public void OnTick()
        {
            _host.ShowMessage(this, "OnTick");
        }
    }
}
