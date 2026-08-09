using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts.CompactFontFormat;

namespace UglyToad.PdfPig.PdfFonts.CidFonts;

internal sealed class PdfCidCompactFontFormatFont : ICidFontProgram
{
	private readonly CompactFontFormatFontCollection fontCollection;

	public FontDetails Details { get; }

	public PdfCidCompactFontFormatFont(CompactFontFormatFontCollection fontCollection)
	{
		this.fontCollection = fontCollection;
		Details = GetDetails(fontCollection?.FirstFont);
	}

	private static FontDetails GetDetails(CompactFontFormatFont? font)
	{
		if (font == null)
		{
			return FontDetails.GetDefault();
		}
		return font.Weight?.ToLowerInvariant() switch
		{
			"light" => WithWeightValues(isBold: false, 300), 
			"semibold" => WithWeightValues(isBold: true, 600), 
			"bold" => WithWeightValues(isBold: true, 700), 
			"black" => WithWeightValues(isBold: true, 900), 
			_ => WithWeightValues(isBold: false, 500), 
		};
		FontDetails WithWeightValues(bool isBold, int weight)
		{
			return new FontDetails(null, isBold, weight, font.ItalicAngle != 0.0);
		}
	}

	public TransformationMatrix GetFontTransformationMatrix()
	{
		return fontCollection.GetFirstTransformationMatrix();
	}

	public PdfRectangle? GetCharacterBoundingBox(string characterName)
	{
		return fontCollection.GetCharacterBoundingBox(characterName);
	}

	public double? GetDescent()
	{
		return null;
	}

	public double? GetAscent()
	{
		return null;
	}

	public bool TryGetBoundingBox(int characterIdentifier, out PdfRectangle boundingBox)
	{
		boundingBox = new PdfRectangle(0, 0, 500, 0);
		CompactFontFormatFont font = GetFont();
		string characterName = GetCharacterName(characterIdentifier);
		if (string.Equals(characterName, ".notdef", StringComparison.OrdinalIgnoreCase))
		{
			return false;
		}
		boundingBox = font.GetCharacterBoundingBox(characterName) ?? new PdfRectangle(0, 0, 500, 0);
		return true;
	}

	public bool TryGetBoundingBox(int characterIdentifier, Func<int, int?> characterCodeToGlyphId, out PdfRectangle boundingBox)
	{
		CompactFontFormatFont font = GetFont();
		int? num = characterCodeToGlyphId(characterIdentifier);
		string characterName = (num.HasValue ? GetCharacterName(num.Value) : GetCharacterName(characterIdentifier));
		PdfRectangle? characterBoundingBox = font.GetCharacterBoundingBox(characterName);
		if (characterBoundingBox.HasValue)
		{
			boundingBox = characterBoundingBox.Value;
			return true;
		}
		boundingBox = default(PdfRectangle);
		return false;
	}

	public bool TryGetBoundingAdvancedWidth(int characterIdentifier, Func<int, int?> characterCodeToGlyphId, out double width)
	{
		return TryGetBoundingAdvancedWidth(characterIdentifier, out width);
	}

	public bool TryGetBoundingAdvancedWidth(int characterIdentifier, out double width)
	{
		width = double.NaN;
		return false;
	}

	public int GetFontMatrixMultiplier()
	{
		return 1000;
	}

	public bool TryGetFontMatrix(int characterCode, [NotNullWhen(true)] out TransformationMatrix? matrix)
	{
		CompactFontFormatFont font = GetFont();
		string characterName = font.GetCharacterName(characterCode, isCid: true);
		if (characterName == null)
		{
			matrix = null;
			return false;
		}
		matrix = font.GetFontMatrix(characterName);
		return matrix.HasValue;
	}

	public string GetCharacterName(int characterCode)
	{
		return GetFont().GetCharacterName(characterCode, isCid: true) ?? ".notdef";
	}

	private CompactFontFormatFont GetFont()
	{
		return fontCollection.FirstFont;
	}

	public bool TryGetPath(int characterCode, [NotNullWhen(true)] out IReadOnlyList<PdfSubpath>? path)
	{
		path = null;
		CompactFontFormatFont font = GetFont();
		string characterName = GetCharacterName(characterCode);
		if (string.Equals(characterName, ".notdef", StringComparison.OrdinalIgnoreCase))
		{
			return false;
		}
		if (font.TryGetPath(characterName, out path))
		{
			return true;
		}
		return false;
	}

	public bool TryGetPath(int characterCode, Func<int, int?> characterCodeToGlyphId, out IReadOnlyList<PdfSubpath> path)
	{
		path = null;
		int? num = characterCodeToGlyphId(characterCode);
		string text = (num.HasValue ? GetCharacterName(num.Value) : GetCharacterName(characterCode));
		if (string.Equals(text, ".notdef", StringComparison.OrdinalIgnoreCase))
		{
			return false;
		}
		if (GetFont().TryGetPath(text, out path))
		{
			return true;
		}
		return false;
	}
}
