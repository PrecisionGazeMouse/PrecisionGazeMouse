# PrecisionGazeMouse
I wanted to design a mouse that is as fast or faster than a regular mouse, but operated without hands. Eye gaze is really fast because eyes can quickly fix on a point, as known as a saccade. However, the precision is low due and it's only good for looking in a general area.  Head tracking can provide precise movements but can cause fatigue if used too much. This offers the best of both: the speed of gaze with the precision of head tracking. 

This uses gaze to quickly "warp" to an area of the screen (about 1-2 inches in diameter), and then the head tracking can precisely move the mouse around that warp point. Thus the two main classes in this project are WarpPointer and PrecisionPointer.

In the screenshot below, you can see the PrecisionGazeMouse window on the left-hand side and the TrackIR window on the right side.  These are useful to see how it works but can be minimized or run in the background.  On the PrecisionGazeMouse window, the blue circle indicates the warp point, the green dot is where the gaze is currently looking, and the red dot is the offset of the precision porinter from the warp point. The red dot becomes the final mouse position. When the green dot quickly travels outside the warp circle, it will calculate a new warp point. Thus big movements are controlled by gaze and small movements with head tracking.

![Screenshot of PrecisionGazeMouse](PrecisionGazeMouse.png?raw=true "Screenshot")

This project currently supports Tobii EyeX for gaze tracking and the TrackIR for head tracking on Windows computers. To run the software download the latest release. Next, start TrackIR and EyeX and calibrate them as needed. Choose PrecisionGazeMouse in the TrackIR titles tab and set it to use the One:One profile. Lastly, start the PrecisionGazeMouse program.

Required Hardware:
* Windows operating system
* Tobii EyeX
* NaturalPoint TrackIR 
* A switch input device for clicking

If you're a developer and would like to build the code for PrecisionGazeMouse, you must have a developer SDK for Tobii EyeX. To rebuild the TrackIRUnity DLL you'll need a developer SDK for TrackIR.