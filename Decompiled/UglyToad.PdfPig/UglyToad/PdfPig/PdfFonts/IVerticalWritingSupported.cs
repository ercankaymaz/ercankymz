using UglyToad.PdfPig.Geometry;

namespace UglyToad.PdfPig.PdfFonts;

internal interface IVerticalWritingSupported
{
	PdfVector GetPositionVector(int characterCode);

	PdfVector GetDisplacementVector(int characterCode);
}
