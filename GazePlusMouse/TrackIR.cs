using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TrackIRUnity;

namespace GazePlusMouse
{
    public class HeadRotation
    {
        public float pitch { get; set; }
        public float yaw { get; set; }
    }

    public class HeadTranslation
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    /*
     * Using https://github.com/medsouz/Unity-TrackIR-Plugin-DLL
     */
    class TrackIR
    {
        TrackIRUnity.TrackIRClient trackIRclient;
        bool running;
        Timer aTimer;
        TrackIRClient.LPTRACKIRDATA tid;

        public TrackIR()
        {
            trackIRclient = new TrackIRUnity.TrackIRClient();  // Create an instance of the TrackerIR Client to get data from.
            if (trackIRclient != null)
            {
                string status = trackIRclient.TrackIR_Enhanced_Init();
                if (status != null)
                {
                    running = true;
                    
                    aTimer = new System.Timers.Timer(33);
                    aTimer.Elapsed += Update;
                    aTimer.AutoReset = false;
                    aTimer.Enabled = true;
                }
            }
        }

        public bool IsRunning()
        {
            return running;
        }

        ~TrackIR()
        {
            if (trackIRclient != null && running)
            {                         // Stop tracking
                string status = trackIRclient.TrackIR_Shutdown();
                running = false;
            }
        }

        // Update is called once per frame
        void Update(Object source, ElapsedEventArgs e)
        {
            if (running)
            {
                //data = trackIRclient.client_TestTrackIRData();          // Data for debugging output, can be removed if not debugging/testing
                tid = trackIRclient.client_HandleTrackIRData(); // Data for head tracking
            }
            aTimer.Start();
        }
        
        public HeadRotation GetRotation()
        {
            HeadRotation o = new HeadRotation();
            o.pitch = tid.fNPPitch;
            o.yaw = tid.fNPYaw;
            return o;
        }

        public HeadTranslation GetTranslation()
        {
            HeadTranslation o = new HeadTranslation();
            o.x = -1 * (int)tid.fNPX;
            o.y = (int)tid.fNPZ;
            return o;
        }
    }
}
