using System;

namespace Microsoft.Isam.Esent.Interop.Windows7;

[Flags]
public enum CrashDumpGrbit
{
	None = 0,
	Minimum = 1,
	Maximum = 2,
	CacheMinimum = 4,
	CacheMaximum = 8,
	CacheIncludeDirtyPages = 0x10,
	CacheIncludeCachedPages = 0x20,
	CacheIncludeCorruptedPages = 0x40
}
