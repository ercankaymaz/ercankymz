using System;

namespace ACadSharp.Entities;

[Flags]
public enum MLineFlags
{
	Has = 1,
	Closed = 2,
	NoStartCaps = 4,
	NoEndCaps = 8
}
