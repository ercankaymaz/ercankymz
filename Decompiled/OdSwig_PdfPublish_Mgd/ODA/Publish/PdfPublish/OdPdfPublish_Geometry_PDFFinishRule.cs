using System;

namespace ODA.Publish.PdfPublish;

[Flags]
public enum OdPdfPublish_Geometry_PDFFinishRule
{
	kFillNotSet = 0,
	kEnd = 1,
	kStroke = 2,
	kClose = 4,
	kFillEvenOdd = 8,
	kFillNonZero = 0x10
}
