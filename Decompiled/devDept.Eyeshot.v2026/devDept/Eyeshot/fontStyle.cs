using System;

namespace devDept.Eyeshot;

[Flags]
public enum fontStyle : byte
{
	Regular = 0,
	Bold = 1,
	Italic = 2,
	Underline = 4,
	Strikeout = 8
}
