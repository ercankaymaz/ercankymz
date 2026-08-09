using System.Diagnostics;

namespace System.Runtime.Caching;

internal static class Dbg
{
	[Conditional("DEBUG")]
	internal static void Trace(string tagName, string message, Exception e = null)
	{
	}
}
