using System;
using System.Runtime.InteropServices;
using System.Security;

namespace MS.Internal;

[SuppressUnmanagedCodeSecurity]
internal static class SharedUnsafeNativeMethods
{
	[DllImport("User32.dll")]
	public static extern IntPtr GetDC(IntPtr hwnd);

	[DllImport("Gdi32.dll")]
	public static extern int GetDeviceCaps(IntPtr hdc, int index);
}
