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
    private Boolean _die;

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
      _die = false;
    }

    public void OnStop()
    {
      _die = true;
      _host.ShowMessage(this, "OnStop");
    }

    public void OnTick()
    {
      // This should take some time
      _host.ShowMessage(this, "Doing some processing");
      for (int i = 0; i < 5000; i++)
      {
        System.Threading.Thread.Sleep(1);
        if (_die) break;
      }
      _host.ShowMessage(this, "Done with the processing");
    }
  }
}
