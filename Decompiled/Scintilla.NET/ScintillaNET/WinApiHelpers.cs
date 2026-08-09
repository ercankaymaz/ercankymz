using System;
using System.Runtime.InteropServices;

namespace ScintillaNET;

internal static class WinApiHelpers
{
	internal const long WS_EX_LAYOUTRTL = 4194304L;

	internal const int GWL_EXSTYLE = -20;

	internal static nint SetWindowLongPtr(this nint hWnd, int nIndex, nint dwNewLong)
	{
		if (Environment.Is64BitProcess)
		{
			return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
		}
		return new IntPtr(SetWindowLong32(hWnd, nIndex, ((IntPtr)dwNewLong).ToInt32()));
	}

	internal static nint GetWindowLongPtr(this nint hWnd, int nIndex)
	{
		return GetWindowLong(hWnd, nIndex);
	}

	[DllImport("user32.dll", EntryPoint = "SetWindowLong")]
	private static extern int SetWindowLong32(nint hWnd, int nIndex, int dwNewLong);

	[DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
	private static extern nint SetWindowLongPtr64(nint hWnd, int nIndex, nint dwNewLong);

	[DllImport("user32.dll")]
	private static extern nint GetWindowLong(nint hWnd, int nIndex);
}
