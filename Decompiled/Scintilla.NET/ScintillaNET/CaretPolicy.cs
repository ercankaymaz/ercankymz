using System;

namespace ScintillaNET;

[Flags]
public enum CaretPolicy
{
	Slop = 1,
	Strict = 4,
	Jumps = 0x10,
	Even = 8
}
