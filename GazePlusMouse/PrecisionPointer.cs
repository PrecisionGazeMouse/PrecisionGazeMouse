using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GazePlusMouse
{
    class PrecisionPointer
    {
        TrackIR tir;
        HeadRotation rot;
        HeadTranslation trans;
        enum Mode
        {
            ROTATION,
            TRANSLATION
        }
        Mode mode;

        public PrecisionPointer()
        {
            tir = new TrackIR();
            mode = Mode.ROTATION;
        }

        public bool IsStarted()
        {
            return tir.IsRunning();
        }

        public String PrintRawValue()
        {
            switch(mode)
            {
                case (Mode.ROTATION):
                    if (rot == null)
                        return "";
                    else
                        return String.Format("({0:0}, {1:0})", rot.yaw, rot.pitch);
                case (Mode.TRANSLATION):
                    if (trans == null)
                        return "";
                    else
                        return String.Format("({0:0}, {1:0})", trans.x, trans.y);
            }

            return "";
        }

        public Point GetPoint(Point p)
        {
            switch (mode)
            {
                case (Mode.ROTATION):
                    Rectangle screenSize = GazePlusMouseForm.GetScreenSize();
                    rot = tir.GetRotation();
                    if (rot != null)
                    {
                        double basePitch = (p.Y - screenSize.Height / 2.0) / (screenSize.Height / 2.0) * 200.0;
                        int yOffset = (int)((rot.pitch - basePitch) / 5);

                        double baseYaw = (p.X - screenSize.Width / 2.0) / (screenSize.Width / 2.0) * 600.0;
                        int xOffset = (int)((-1 * rot.yaw - baseYaw) / 5);

                        p.Offset(xOffset, yOffset);

                        return p;
                    }
                    break;
                case (Mode.TRANSLATION):
                    trans = tir.GetTranslation();
                    if (trans != null)
                    {
                        p.Offset(trans.x / 5, trans.y / 5);
                        return p;
                    }
                    break;
            }

            return p;
        }
    }
}
