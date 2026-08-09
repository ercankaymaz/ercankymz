using System;

namespace ACadSharp.Entities;

[Flags]
public enum TextMirrorFlag : short
{
	None = 0,
	Backward = 2,
	UpsideDown = 4
}
