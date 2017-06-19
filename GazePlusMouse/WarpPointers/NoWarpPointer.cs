using System;
using System.Drawing;

namespace GazePlusMouse.WarpPointers
{
    class NoWarpPointer : WarpPointer
    {
        Point warpPoint;
        int warpThreshold;

        public NoWarpPointer(Point centerOfScreen)
        {
            warpThreshold = 0;
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
            return warpThreshold;
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