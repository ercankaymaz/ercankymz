using System.Diagnostics;

namespace Microsoft.Isam.Esent.Interop;

internal static class Caches
{
	private const int KeyMostMost = 2000;

	private const int LimitKeyMostMost = 2001;

	private const int MaxBuffers = 16;

	private static readonly MemoryCache TheColumnCache = new MemoryCache(131072, 16);

	private static readonly MemoryCache TheBookmarkCache = new MemoryCache(2001, 16);

	private static readonly MemoryCache TheSecondaryBookmarkCache = new MemoryCache(2001, 16);

	public static MemoryCache ColumnCache
	{
		[DebuggerStepThrough]
		get
		{
			return TheColumnCache;
		}
	}

	public static MemoryCache BookmarkCache
	{
		[DebuggerStepThrough]
		get
		{
			return TheBookmarkCache;
		}
	}

	public static MemoryCache SecondaryBookmarkCache
	{
		[DebuggerStepThrough]
		get
		{
			return TheSecondaryBookmarkCache;
		}
	}
}
