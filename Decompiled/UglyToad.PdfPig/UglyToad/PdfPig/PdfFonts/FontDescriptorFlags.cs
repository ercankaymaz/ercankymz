using System;

namespace UglyToad.PdfPig.PdfFonts;

[Flags]
public enum FontDescriptorFlags
{
	None = 0,
	FixedPitch = 1,
	Serif = 2,
	Symbolic = 4,
	Script = 8,
	NonSymbolic = 0x20,
	Italic = 0x40,
	AllCap = 0x10000,
	SmallCap = 0x20000,
	ForceBold = 0x40000
}
