using System;

namespace ACadSharp.Entities;

[Flags]
public enum ImageDisplayFlags : short
{
	None = 0,
	ShowImage = 1,
	ShowNotAlignedImage = 2,
	UseClippingBoundary = 4,
	TransparencyIsOn = 8
}
