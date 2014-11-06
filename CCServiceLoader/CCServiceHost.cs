using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CC.Service.Loader
{
  public interface CCServiceHost
  {
    /// <summary>
    /// Call this to change your plugin's interval
    /// </summary>
    /// <param name="Interval">The time in milliseconds</param>
    //void ChangeInterval(double Interval);

    /// <summary>
    /// Alerts the user of your message
    /// </summary>
    /// <param name="sender">Your plugin Name</param>
    /// <param name="msg">The message you'd like to send</param>
    void ShowMessage(CCServiceInterface sender, string msg);

    /// <summary>
    /// Alerts the user of your message
    /// </summary>
    /// <param name="msg">The message you'd like to send</param>
    void ShowMessage(object sender, string msg);
  }
}
