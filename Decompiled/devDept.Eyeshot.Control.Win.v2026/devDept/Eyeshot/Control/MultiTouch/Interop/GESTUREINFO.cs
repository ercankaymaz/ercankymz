using System;

namespace devDept.Eyeshot.Control.MultiTouch.Interop;

[CLSCompliant(false)]
public struct GESTUREINFO
{
	public uint cbSize;

	public uint dwFlags;

	public uint dwID;

	public IntPtr hwndTarget;

	public POINTS ptsLocation;

	public uint dwInstanceID;

	public uint dwSequenceID;

	public ulong ullArguments;

	public uint cbExtraArgs;
}
