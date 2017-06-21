using System;
using System.Drawing;

namespace PrecisionGazeMouse.WarpPointers
{
    class NoWarpPointer : WarpPointer
    {
        Point warpPoint;

        public NoWarpPointer(Point centerOfScreen)
        {
            warpPoint = centerOfScreen;
        }

        public bool IsStarted()
        {
            return true;
        }

        public bool IsWarpReady()
        {
            return true;
        }

        public Point calculateSmoothedPoint()
        {
            return warpPoint;
        }

        public override String ToString()
        {
            return String.Format("({0:0}, {1:0})", warpPoint.X, warpPoint.Y);
        }

        public Point GetGazePoint()
        {
            return warpPoint;
        }

        public int GetSampleCount()
        {
            return 1;
        }

        public int GetWarpTreshold()
        {
            return 0;
        }

        public Point GetWarpPoint()
        {
            return warpPoint;
        }

        public Point GetNextPoint(Point currentPoint)
        {
            return warpPoint;
        }

        public void Dispose()
        {
        }
    }
}