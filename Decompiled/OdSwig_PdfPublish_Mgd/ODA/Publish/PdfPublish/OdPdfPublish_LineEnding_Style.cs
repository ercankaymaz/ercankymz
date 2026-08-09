using System;

namespace ODA.Publish.PdfPublish;

[Flags]
public enum OdPdfPublish_LineEnding_Style
{
	kNone = 0,
	kSquare = 1,
	kCircle = 2,
	kDiamond = 3,
	kOpenArrow = 4,
	kClosedArrow = 5,
	kButt = 6,
	kROpenArrow = 7,
	kRClosedArrow = 8,
	kSlash = 9
}
