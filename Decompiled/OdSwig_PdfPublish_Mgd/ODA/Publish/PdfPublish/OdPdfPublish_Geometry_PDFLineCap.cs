using System;

namespace ODA.Publish.PdfPublish;

[Flags]
public enum OdPdfPublish_Geometry_PDFLineCap
{
	kLineCapNotSet = -1,
	kButtCap = 0,
	kRoundCap = 1,
	kProjectingSquareCap = 2
}
