using System.Drawing;

namespace GazePlusMouse
{
    interface WarpPointer
    {
        // Whether it's started tracking gaze
        bool IsStarted();

        // Whether it's ready to warp to a new point
        bool IsWarpReady();

        // Smoothed point for drawing
        Point calculateSmoothedPoint();

        // Gaze point for drawing
        Point GetGazePoint();

        // Sample count for printing
        int GetSampleCount();

        // Warp threshold in pixels
        int GetWarpTreshold();

        // Warp point for drawing, no update made
        Point GetWarpPoint();

        // Get the next warp point based on the current pointer location and gaze
        Point GetNextPoint(Point currentPoint);
    }
}
