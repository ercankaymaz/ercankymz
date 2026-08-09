using System;

namespace ACadSharp.Entities;

[Flags]
public enum AttributeFlags
{
	None = 0,
	Hidden = 1,
	Constant = 2,
	Verify = 4,
	Preset = 8
}
