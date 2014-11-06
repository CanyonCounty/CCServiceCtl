using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CC.Service.Loader;

namespace Plugin2
{
  public class Class1 : CCServiceInterface
  {
    private CCServiceHost _host;

    public string Name
    {
      get { return "MyOtherPlugin"; }
    }

    public double Interval
    {
      get { return 1000; }
    }

    public void Initialize(CCServiceHost host, ref bool needOwnTimer)
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
