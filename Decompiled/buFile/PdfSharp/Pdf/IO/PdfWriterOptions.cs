using System;

namespace PdfSharp.Pdf.IO;

[Flags]
internal enum PdfWriterOptions
{
	Regular = 0,
	OmitStream = 1,
	OmitInflation = 2
}
