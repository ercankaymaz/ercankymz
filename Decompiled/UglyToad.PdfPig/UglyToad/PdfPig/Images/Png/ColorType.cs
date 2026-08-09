using System;

namespace UglyToad.PdfPig.Images.Png;

[Flags]
internal enum ColorType : byte
{
	None = 0,
	PaletteUsed = 1,
	ColorUsed = 2,
	AlphaChannelUsed = 4
}
