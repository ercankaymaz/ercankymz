using System;

namespace ODA.Publish.PdfPublish;

[Flags]
public enum OdPdfPublish_Border_Style
{
	kSolid = 0,
	kDashed = 1,
	kBeveled = 2,
	kInset = 3,
	kUnderlined = 4
}
