using System;
using System.Drawing;

namespace PrecisionGazeMouse.PrecisionPointers
{
    class NoPrecisionPointer : PrecisionPointer
    {
        PrecisionPointerMode mode;

        public PrecisionPointerMode Mode
        {
            get { return mode; }
            set { mode = value; }
        }

        public override String ToString()
        {
            return "";
        }

        public bool IsStarted()
        {
            return true;
        }

        public Point GetNextPoint(Point warpPoint)
        {
            return warpPoint;
        }

        public void Dispose()
        {
        }
    }
}
