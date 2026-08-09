using System;

namespace ACadSharp.Entities;

[Flags]
public enum BackgroundFillFlags : byte
{
	None = 0,
	UseBackgroundFillColor = 1,
	UseDrawingWindowColor = 2,
	TextFrame = 0x10
}
