using System;
using System.Drawing;
using System.Windows.Forms;
using ns8;

namespace buCadCamResVer5;

public static class ScreenExtensions
{
	public static void GetDpi(this Screen screen, DpiType dpiType, out uint dpiX, out uint dpiY)
	{
		Point point_ = new Point(screen.Bounds.Left + 1, screen.Bounds.Top + 1);
		IntPtr intptr_ = Class5.MonitorFromPoint(point_, 2u);
		Class5.GetDpiForMonitor(intptr_, dpiType, out dpiX, out dpiY);
	}
}
