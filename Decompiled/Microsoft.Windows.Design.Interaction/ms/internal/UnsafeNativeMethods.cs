using System;
using System.Runtime.InteropServices;
using System.Security;

namespace MS.Internal;

[SuppressUnmanagedCodeSecurity]
internal static class UnsafeNativeMethods
{
	[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
	public static extern short GetKeyState(int keyCode);

	[DllImport("User32.dll")]
	public static extern IntPtr GetDC(IntPtr hwnd);

	[DllImport("Gdi32.dll")]
	public static extern int GetDeviceCaps(IntPtr hdc, int index);
}
