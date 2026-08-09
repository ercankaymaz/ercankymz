using System;

namespace devDept.Graphics;

[Flags]
public enum colorMaskFlags : byte
{
	None = 0,
	Red = 1,
	Green = 2,
	Blue = 4,
	Alpha = 8,
	RGB = 7,
	RGBA = 0xF
}
