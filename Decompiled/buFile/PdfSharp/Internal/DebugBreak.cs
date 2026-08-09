using System.Diagnostics;

namespace PdfSharp.Internal;

public static class DebugBreak
{
	public static void Break()
	{
		Break(always: false);
	}

	public static void Break(bool always)
	{
		if (always || Debugger.IsAttached)
		{
			Debugger.Break();
		}
	}
}
