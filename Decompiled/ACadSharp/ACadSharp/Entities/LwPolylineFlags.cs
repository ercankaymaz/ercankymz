using System;

namespace ACadSharp.Entities;

[Flags]
public enum LwPolylineFlags
{
	Default = 0,
	Closed = 1,
	Plinegen = 0x80
}
