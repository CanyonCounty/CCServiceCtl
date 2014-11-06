using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CC.Service.Loader;

namespace Plugin3
{
  public class Class1 : CCServiceInterface
  {
    private CCServiceHost _host;

    public string Name
    {
      get { return "MyLogPlugin"; }
    }

    public double Interval
    {
      get { return 1000; }
    }

    public void Initialize(CCServiceHost host, ref bool needOwnTimer)
    {
      _host = host;
      host.ShowMessage(this, "Initialize");
      needOwnTimer = true;
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
      // This should take some time
      _host.ShowMessage(this, "Doing some processing");
      System.Threading.Thread.Sleep(5000);
      _host.ShowMessage(this, "Done with the processing");
    }
  }
}
