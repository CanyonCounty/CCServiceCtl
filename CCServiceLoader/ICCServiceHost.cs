
namespace CC.Service.Loader
{
    public interface ICCServiceHost
    {
        //// <summary>
        //// Call this to change your plugin's interval
        //// </summary>
        //// <param name="Interval">The time in milliseconds</param>
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
        /// <param name="sender">The objec that's calling this method - captured in the log file</param>
        /// <param name="msg">The message you'd like to send</param>
        void ShowMessage(object sender, string msg);

        /// <summary>
        /// Sends a Debug Message to Host. It's up to the host as to how it's handled
        /// </summary>
        /// <param name="sender">Your plugin Name</param>
        /// <param name="msg">The message you'd like to send</param>
        void DebugMessage(CCServiceInterface sender, string msg);

        /// <summary>
        /// Sends a Debug Message to Host. It's up to the host as to how it's handled
        /// </summary>
        /// <param name="sender">The objec that's calling this method - captured in the log file</param>
        /// <param name="msg">The message you'd like to send</param>
        void DebugMessage(object sender, string msg);
    }
}
