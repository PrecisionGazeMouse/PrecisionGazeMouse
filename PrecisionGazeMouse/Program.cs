//-----------------------------------------------------------------------
// Copyright 2014 Tobii Technology AB. All rights reserved.
//-----------------------------------------------------------------------

namespace PrecisionGazeMouse
{
    using System;
    using System.Windows.Forms;
    using Tobii.Interaction;

    static class Program
    {
        private static Host _eyeXHost = new Host();

        /// <summary>
        /// Gets the singleton EyeX host instance.
        /// </summary>
        public static Host EyeXHost
        {
            get { return _eyeXHost; }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            _eyeXHost.InitializeWpfAgent();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PrecisionGazeMouseForm());

            _eyeXHost.Dispose();
        }
    }
}
