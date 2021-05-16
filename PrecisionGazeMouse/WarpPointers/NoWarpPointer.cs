using System;
using System.Drawing;

namespace PrecisionGazeMouse.WarpPointers
{
    class NoWarpPointer : WarpPointer
    {
        Point warpPoint;
        bool warpToInitialPoint;

        public int Sensitivity { get; set; }

        public NoWarpPointer()
        {
            this.warpPoint = new Point(0, 0);
            this.warpToInitialPoint = false;
        }

        public NoWarpPointer(Point warpPoint)
        {
            this.warpPoint = warpPoint;
            this.warpToInitialPoint = true;
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
            return String.Format("None ({0:0}, {1:0})", warpPoint.X, warpPoint.Y);
        }

        public Point GetGazePoint()
        {
            return warpPoint;
        }

        public int GetSampleCount()
        {
            return 1;
        }

        public Point GetWarpPoint()
        {
            return warpPoint;
        }

        public Point GetNextPoint(Point currentPoint)
        {
            if (warpToInitialPoint)
                return warpPoint;
            else
                return currentPoint;
        }

        public void Dispose()
        {
        }

        public void RefreshTracking()
        {
        }
    }
}