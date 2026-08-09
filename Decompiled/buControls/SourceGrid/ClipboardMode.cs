using System;

namespace SourceGrid;

[Flags]
public enum ClipboardMode
{
	None = 0,
	Copy = 1,
	Cut = 2,
	Paste = 4,
	Delete = 8,
	All = 0xF
}
