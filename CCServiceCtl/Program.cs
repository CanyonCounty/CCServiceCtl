﻿using System.ServiceProcess;

namespace CC.Service.Ctl
{
  public static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    public static void Main()
    {
        var servicesToRun = new ServiceBase[] 
        { 
            new IccServiceCtl()
        };
        ServiceBase.Run(servicesToRun);
    }
  }
}
