using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Writer.Fonts;

internal interface IWritingFont
{
	bool HasWidths { get; }

	string Name { get; }

	bool TryGetBoundingBox(char character, out PdfRectangle boundingBox);

	bool TryGetAdvanceWidth(char character, out double width);

	TransformationMatrix GetFontMatrix();

	IndirectReferenceToken WriteFont(IPdfStreamWriter writer, IndirectReferenceToken? reservedIndirect = null);

	byte GetValueForCharacter(char character);
}
