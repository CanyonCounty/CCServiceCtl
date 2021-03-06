﻿namespace CC.Service.Loader
{
    public interface ICCServiceInterface
    {
        /// <summary>
        /// This is like an OnLoad event for a form. You will get a host object that will
        /// allow you to communitate with the Service Controler
        /// </summary>
        /// <param name="host">The host object (if you want it)</param>
        /// <param name="needOwnTimer">Set to true if your plugin needs it's own timer (If you're worried by interupting other Plugins). False by default and recommended</param>
        void Initialize(ICCServiceHost host, ref bool needOwnTimer);

        /// <summary>
        /// Read-Only Property - return the Timer Interval in milliseconds
        /// </summary>
        double Interval { get; }

        /// <summary>
        /// Read-Only Property - return the Plugin Name. Spaces will be removed
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Read-Only Property - return the priority needed. (in case plugin 1 needs to run before plugin 2)
        /// </summary>
        int Priority { get; }

        /// <summary>
        /// Called After Initialize it's fired when the service Starts
        /// </summary>
        void OnStart();

        /// <summary>
        /// Called When the Service it told to stop
        /// </summary>
        void OnStop();

        /// <summary>
        /// Called after every Interval (approx).
        /// </summary>
        void OnTick();
    }
}
