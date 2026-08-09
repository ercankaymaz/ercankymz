using System;

namespace ModuleWorks;

[Serializable]
public enum ColorGradientType
{
	Horizontal = 1,
	Vertical,
	DiagonalFalling,
	DiagonalAscending,
	TwoThirdsOfStartColor,
	OneHalfOfStartColor
}
