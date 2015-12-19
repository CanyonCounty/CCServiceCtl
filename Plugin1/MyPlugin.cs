﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CC.Service.Loader;

namespace Plugin1
{
  public class MyPlugin : CCServiceInterface
  {
    private ICCServiceHost _host;

    public string Name
    {
      get { return "MyPlugin"; }
    }

    public double Interval
    {
      get { return 1000; }
    }

    public int Priority
    {
      get { return int.MaxValue - 10; }
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
