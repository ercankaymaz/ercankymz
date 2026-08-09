using System;

namespace ACadSharp;

[Flags]
public enum DxfReferenceType : byte
{
	None = 0,
	Handle = 1,
	Name = 2,
	Count = 4,
	Optional = 8,
	Ignored = 0x10,
	IsAngle = 0x20,
	Unprocess = 0x40
}
