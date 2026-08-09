using System;

namespace PdfSharp.Pdf;

[Flags]
internal enum PdfStringFlags
{
	RawEncoding = 0,
	StandardEncoding = 1,
	PDFDocEncoding = 2,
	WinAnsiEncoding = 3,
	MacRomanEncoding = 4,
	MacExpertEncoding = 5,
	Unicode = 6,
	EncodingMask = 0xF,
	HexLiteral = 0x80
}
