using System;
using System.Threading;

namespace PdfSharp.Internal;

internal static class Lock
{
	private static readonly object GdiPlus = new object();

	private static int _gdiPlusLockCount;

	private static readonly object FontFactory = new object();

	[ThreadStatic]
	private static int _fontFactoryLockCount;

	public static void EnterGdiPlus()
	{
		Monitor.Enter(GdiPlus);
		_gdiPlusLockCount++;
	}

	public static void ExitGdiPlus()
	{
		_gdiPlusLockCount--;
		Monitor.Exit(GdiPlus);
	}

	public static void EnterFontFactory()
	{
		Monitor.Enter(FontFactory);
		_fontFactoryLockCount++;
	}

	public static void ExitFontFactory()
	{
		_fontFactoryLockCount--;
		Monitor.Exit(FontFactory);
	}
}
