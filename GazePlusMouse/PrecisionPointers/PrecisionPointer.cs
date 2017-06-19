using System.Drawing;

namespace GazePlusMouse.PrecisionPointers
{
    enum PrecisionPointerMode
    {
        ROTATION,
        TRANSLATION,
        BOTH
    }

    interface PrecisionPointer : System.IDisposable
    {
        // Whether it's started tracking
        bool IsStarted();

        // Get the next precision point based on the warp point
        Point GetNextPoint(Point warpPoint);

        // The mode for precision pointing, can be rotation or translation
        PrecisionPointerMode Mode { get; set; }
    }
}
