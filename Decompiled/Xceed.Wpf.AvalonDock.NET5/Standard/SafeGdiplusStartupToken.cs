using System;
using Microsoft.Win32.SafeHandles;

namespace Standard;

internal sealed class SafeGdiplusStartupToken : SafeHandleZeroOrMinusOneIsInvalid
{
	private SafeGdiplusStartupToken()
		: base(ownsHandle: true)
	{
	}

	protected override bool ReleaseHandle()
	{
		return Standard.NativeMethods.GdiplusShutdown(handle) == Standard.Status.Ok;
	}

	public static Standard.SafeGdiplusStartupToken Startup()
	{
		Standard.SafeGdiplusStartupToken safeGdiplusStartupToken = new Standard.SafeGdiplusStartupToken();
		if (Standard.NativeMethods.GdiplusStartup(out var token, new Standard.StartupInput(), out var _) == Standard.Status.Ok)
		{
			safeGdiplusStartupToken.handle = token;
			return safeGdiplusStartupToken;
		}
		safeGdiplusStartupToken.Dispose();
		throw new Exception("Unable to initialize GDI+");
	}
}
