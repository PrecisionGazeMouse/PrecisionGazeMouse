# Users

If you need help, please file an issue by clicking the Issues tab near the top of this page.

# Software Developers
I welcome contributions from other software developers! This program is written in C# with Visual Studio .NET. The main classes you should know about include PrecisionGazeMouseForm, which contains the code for the user interface and it's settings. The MouseController class controls the mouse pointer and hotkeys to simulate clicks. 

The code is designed to be very extensible so that it's possible to add new trackers easily. There are two folders for PrecisionPointers and WarpPointers. These offer a general interface so that we can implement a design pattern that allows you to set any implementation of each type of pointer.  They allow to quickly turn on EyeX, TrackIR, SmartNav or no pointer. If you would like to add support for a new device you can add them here.

If you would like to build the code for Precision Gaze Mouse, you'll need the free [developer SDK for Tobii EyeX](http://developer.tobii.com/). You shouldn't need to rebuild the TrackIRUnity DLL since it's just a wrapper and you can use the DLL from the release. However, if you'd like to, you'll need a [developer SDK for TrackIR](https://www.naturalpoint.com/trackir/developers/).
