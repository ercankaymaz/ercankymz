using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.PdfFonts;

public interface IFont
{
	NameToken? Name { get; }

	bool IsVertical { get; }

	FontDetails Details { get; }

	int ReadCharacterCode(IInputBytes bytes, out int codeLength);

	bool TryGetUnicode(int characterCode, [NotNullWhen(true)] out string? value);

	CharacterBoundingBox GetBoundingBox(int characterCode);

	TransformationMatrix GetFontMatrix();

	double GetDescent();

	double GetAscent();

	bool TryGetPath(int characterCode, [NotNullWhen(true)] out IReadOnlyList<PdfSubpath>? path);

	bool TryGetNormalisedPath(int characterCode, [NotNullWhen(true)] out IReadOnlyList<PdfSubpath>? path);
}
