using System;
using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

[Flags]
[TypeConverter(typeof(PaletteDrawBordersConverter))]
public enum PaletteDrawBorders
{
	Inherit = 0x10,
	None = 0,
	Top = 1,
	Bottom = 2,
	TopBottom = 3,
	Left = 4,
	TopLeft = 5,
	BottomLeft = 6,
	TopBottomLeft = 7,
	Right = 8,
	TopRight = 9,
	BottomRight = 0xA,
	TopBottomRight = 0xB,
	LeftRight = 0xC,
	TopLeftRight = 0xD,
	BottomLeftRight = 0xE,
	All = 0xF
}
