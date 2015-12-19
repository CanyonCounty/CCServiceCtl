using System.ComponentModel;
using System.Configuration.Install;

namespace CC.Service.Ctl
{
  [RunInstaller(true)]
  public partial class ProjectInstaller : Installer
  {
    public ProjectInstaller()
    {
      InitializeComponent();
    }
  }
}
