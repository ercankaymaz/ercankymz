using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts.TrueType;
using UglyToad.PdfPig.Fonts.TrueType.Tables;

namespace UglyToad.PdfPig.PdfFonts.CidFonts;

internal sealed class PdfCidTrueTypeFont : ICidFontProgram
{
	private readonly TrueTypeFont font;

	public FontDetails Details { get; }

	public PdfCidTrueTypeFont(TrueTypeFont font)
	{
		this.font = font ?? throw new ArgumentNullException("font");
		HeaderTable headerTable = font.TableRegister.HeaderTable;
		bool flag = headerTable.MacStyle.HasFlag(HeaderTable.HeaderMacStyle.Bold);
		Details = new FontDetails(font.Name, flag, flag ? 700 : 500, headerTable.MacStyle.HasFlag(HeaderTable.HeaderMacStyle.Italic));
	}

	public bool TryGetBoundingBox(int characterIdentifier, out PdfRectangle boundingBox)
	{
		return TryGetBoundingBox(characterIdentifier, null, out boundingBox);
	}

	public bool TryGetBoundingBox(int characterIdentifier, Func<int, int?>? characterCodeToGlyphId, out PdfRectangle boundingBox)
	{
		return font.TryGetBoundingBox(characterIdentifier, characterCodeToGlyphId, out boundingBox);
	}

	public bool TryGetBoundingAdvancedWidth(int characterIdentifier, out double width)
	{
		return TryGetBoundingAdvancedWidth(characterIdentifier, null, out width);
	}

	public bool TryGetBoundingAdvancedWidth(int characterIdentifier, Func<int, int?>? characterCodeToGlyphId, out double width)
	{
		return font.TryGetAdvanceWidth(characterIdentifier, characterCodeToGlyphId, out width);
	}

	public int GetFontMatrixMultiplier()
	{
		return font.GetUnitsPerEm();
	}

	public double? GetDescent()
	{
		return font.TableRegister.HorizontalHeaderTable.Descent;
	}

	public double? GetAscent()
	{
		return font.TableRegister.HorizontalHeaderTable.Ascent;
	}

	public bool TryGetFontMatrix(int characterCode, [NotNullWhen(true)] out TransformationMatrix? matrix)
	{
		matrix = null;
		return false;
	}

	public bool TryGetPath(int characterCode, [NotNullWhen(true)] out IReadOnlyList<PdfSubpath>? path)
	{
		return font.TryGetPath(characterCode, out path);
	}

	public bool TryGetPath(int characterCode, Func<int, int?> characterCodeToGlyphId, out IReadOnlyList<PdfSubpath> path)
	{
		return font.TryGetPath(characterCode, characterCodeToGlyphId, out path);
	}
}
