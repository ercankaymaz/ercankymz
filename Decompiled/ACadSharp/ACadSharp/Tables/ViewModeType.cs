using System;

namespace ACadSharp.Tables;

[Flags]
public enum ViewModeType
{
	Off = 0,
	PerspectiveView = 1,
	FrontClipping = 2,
	BackClipping = 4,
	Follow = 8,
	FrontClippingZ = 0x10
}
