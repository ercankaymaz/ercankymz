using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts;
using UglyToad.PdfPig.Fonts.Encodings;
using UglyToad.PdfPig.PdfFonts.Cmap;
using UglyToad.PdfPig.PdfFonts.Composite;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.PdfFonts.Simple;

internal class Type3Font : IFont
{
	private readonly PdfRectangle boundingBox;

	private readonly TransformationMatrix fontMatrix;

	private readonly double ascent;

	private readonly double descent;

	private readonly Encoding encoding;

	private readonly int firstChar;

	private readonly int lastChar;

	private readonly double[] widths;

	private readonly ToUnicodeCMap toUnicodeCMap;

	public NameToken Name { get; }

	public bool IsVertical { get; }

	public FontDetails Details { get; }

	public Type3Font(NameToken name, PdfRectangle boundingBox, TransformationMatrix fontMatrix, Encoding encoding, int firstChar, int lastChar, double[] widths, CMap toUnicodeCMap)
	{
		Name = name;
		this.boundingBox = boundingBox;
		this.fontMatrix = fontMatrix;
		this.encoding = encoding;
		this.firstChar = firstChar;
		this.lastChar = lastChar;
		this.widths = widths;
		this.toUnicodeCMap = new ToUnicodeCMap(toUnicodeCMap);
		Details = FontDetails.GetDefault(name?.Data);
		descent = ComputeDescent();
		ascent = ComputeAscent();
	}

	private double ComputeDescent()
	{
		return 0.0;
	}

	private double ComputeAscent()
	{
		return fontMatrix.TransformY(boundingBox.Top);
	}

	public int ReadCharacterCode(IInputBytes bytes, out int codeLength)
	{
		codeLength = 1;
		return bytes.CurrentByte;
	}

	public bool TryGetUnicode(int characterCode, [NotNullWhen(true)] out string? value)
	{
		value = null;
		if (toUnicodeCMap.CanMapToUnicode && toUnicodeCMap.TryGet(characterCode, out value))
		{
			return true;
		}
		if (encoding == null)
		{
			return false;
		}
		try
		{
			string name = encoding.GetName(characterCode);
			value = GlyphList.AdobeGlyphList.NameToUnicode(name);
		}
		catch
		{
			return false;
		}
		return value != null;
	}

	public CharacterBoundingBox GetBoundingBox(int characterCode)
	{
		PdfRectangle boundingBoxInGlyphSpace = GetBoundingBoxInGlyphSpace(characterCode);
		boundingBoxInGlyphSpace = fontMatrix.Transform(boundingBoxInGlyphSpace);
		double width = fontMatrix.TransformX(widths[characterCode - firstChar]);
		return new CharacterBoundingBox(boundingBoxInGlyphSpace, width);
	}

	private PdfRectangle GetBoundingBoxInGlyphSpace(int characterCode)
	{
		if (characterCode < firstChar || characterCode > lastChar)
		{
			throw new InvalidFontFormatException($"The character code was not contained in the widths array: {characterCode}.");
		}
		return new PdfRectangle(0.0, 0.0, widths[characterCode - firstChar], boundingBox.Height);
	}

	public TransformationMatrix GetFontMatrix()
	{
		return fontMatrix;
	}

	public double GetDescent()
	{
		return descent;
	}

	public double GetAscent()
	{
		return ascent;
	}

	public bool TryGetPath(int characterCode, [NotNullWhen(true)] out IReadOnlyList<PdfSubpath>? path)
	{
		path = null;
		return false;
	}

	public bool TryGetNormalisedPath(int characterCode, [NotNullWhen(true)] out IReadOnlyList<PdfSubpath>? path)
	{
		return TryGetPath(characterCode, out path);
	}
}
