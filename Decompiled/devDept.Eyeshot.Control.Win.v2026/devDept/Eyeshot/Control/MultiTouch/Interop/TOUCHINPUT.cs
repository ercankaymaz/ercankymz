using System;

namespace devDept.Eyeshot.Control.MultiTouch.Interop;

public struct TOUCHINPUT
{
	public int x;

	public int y;

	public IntPtr hSource;

	public int dwID;

	public int dwFlags;

	public int dwMask;

	public int dwTime;

	public IntPtr dwExtraInfo;

	public int cxContact;

	public int cyContact;
}
