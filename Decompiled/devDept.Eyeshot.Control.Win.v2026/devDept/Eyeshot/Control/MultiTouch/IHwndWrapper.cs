using System;
using System.Drawing;

namespace devDept.Eyeshot.Control.MultiTouch;

public interface IHwndWrapper
{
	IntPtr Handle { get; }

	object Source { get; }

	bool IsHandleCreated { get; }

	event EventHandler HandleCreated;

	event EventHandler HandleDestroyed;

	Point PointToClient(Point point);
}
