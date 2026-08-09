using System;

namespace ODA.Publish.PdfPublish;

[Flags]
public enum OdPdfPublish_Geometry_PDFLineJoin
{
	kLineJoinNotSet = -1,
	kMiterJoin = 0,
	kRoundJoin = 1,
	kBevelJoin = 2
}
