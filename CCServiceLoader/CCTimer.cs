using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace CC.Service.Loader
{
  public class CCTimer
  {
    private Timer timer;
    private List<CCServiceInterface> plugins;

    public CCTimer(double Interval)
    {
      plugins = new List<CCServiceInterface>();
      timer = new Timer(Interval);
      timer.Elapsed += new ElapsedEventHandler(TimerTick);
      
      timer.Enabled = false;
      this.MyOwn = false;
    }

    public Boolean MyOwn { get; set; }

    public Boolean Enabled
    {
      get { return timer.Enabled; }
      set { timer.Enabled = value; }
    }

    public Double Interval
    {
      get { return timer.Interval; }
    }

    public void Add(CCServiceInterface plugin)
    {
      this.plugins.Add(plugin);
    }

    public void AddRange(CCServiceInterface[] plugins)
    {
      this.plugins.AddRange(plugins);
    }

    private void TimerTick(object sender, EventArgs e)
    {
      timer.Enabled = false;
      foreach (CCServiceInterface plugin in plugins)
      {
        plugin.OnTick();
      }
      timer.Enabled = true;
    }
  }
}
