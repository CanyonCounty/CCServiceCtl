using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CC.Service.Loader;

namespace Plugin3
{
  public class MyLogPlugin : CCServiceBase
  {
    private CCServiceHost _host;

    public override string Name
    {
      get { return "MyLogPlugin"; }
    }

    public override double Interval
    {
      get { return 1000; }
    }

    public override void Initialize(CCServiceHost host, ref bool needOwnTimer)
    {
      _host = host;
      host.ShowMessage(this, "Initialize");
      needOwnTimer = true;
    }

    public override void OnStart()
    {
      base.OnStart();
      _host.ShowMessage(this, "OnStart");
    }

    public override void OnStop()
    {
      base.OnStop();
      _host.ShowMessage(this, "OnStop");
    }

    public override void OnTick()
    {
      // This should take some time
      _host.ShowMessage(this, "Doing some processing");
      for (int i = 0; i < 5000; i++)
      {
        _host.ShowMessage(this, "Processing...");
        System.Threading.Thread.Sleep(1000);        
        if (Die)
        {
          _host.ShowMessage(this, "Breaking...");
          break;
        }
      }
      _host.ShowMessage(this, "Done with the processing");
    }
  }
}
