
namespace CC.Service.Console
{
  public static class Program
  {
    public static void Main(/*string[] args*/)
    {
      //Create our console object, 
      //call OnStart, OnTick, OnStop then exit
      var ctl = new ConsoleCtl();
      ctl.PerformAction();
    }
  }
}
