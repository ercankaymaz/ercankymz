using System;

namespace PdfSharp.Pdf;

[Flags]
public enum PdfStringEncoding
{
	RawEncoding = 0,
	StandardEncoding = 1,
	PDFDocEncoding = 2,
	WinAnsiEncoding = 3,
	MacRomanEncoding = 5,
	MacExpertEncoding = 5,
	Unicode = 6
}
