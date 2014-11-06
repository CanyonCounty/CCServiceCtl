using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CC.Service.Console
{
  public class Program
  {
    static void Main(string[] args)
    {
      //Create our console object, 
      //call OnStart, OnTick, OnStop then exit
      ConsoleCtl ctl = new ConsoleCtl();
      ctl.PerformAction();
    }
  }
}
