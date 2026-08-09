using System.Runtime.InteropServices;

namespace System.Runtime.Caching;

[StructLayout(LayoutKind.Explicit)]
internal struct ExpiresEntry
{
	[FieldOffset(0)]
	internal DateTime _utcExpires;

	[FieldOffset(0)]
	internal ExpiresEntryRef _next;

	[FieldOffset(4)]
	internal int _cFree;

	[FieldOffset(8)]
	internal MemoryCacheEntry _cacheEntry;
}
