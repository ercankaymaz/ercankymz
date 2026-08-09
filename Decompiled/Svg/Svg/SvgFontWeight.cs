using System;
using System.ComponentModel;

namespace Svg;

[TypeConverter(typeof(SvgFontWeightConverter))]
[Flags]
public enum SvgFontWeight
{
	Inherit = 0,
	Normal = 1,
	Bold = 2,
	Bolder = 4,
	Lighter = 8,
	W100 = 0x100,
	W200 = 0x200,
	W300 = 0x400,
	W400 = 0x800,
	W500 = 0x1000,
	W600 = 0x2000,
	W700 = 0x4000,
	W800 = 0x8000,
	W900 = 0x10000,
	All = 0x1FF03
}
