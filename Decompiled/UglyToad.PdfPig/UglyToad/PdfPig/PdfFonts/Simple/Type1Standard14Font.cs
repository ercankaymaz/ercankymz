using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts;
using UglyToad.PdfPig.Fonts.AdobeFontMetrics;
using UglyToad.PdfPig.Fonts.Encodings;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.PdfFonts.Simple;

internal sealed class Type1Standard14Font : IFont
{
	private readonly AdobeFontMetrics standardFontMetrics;

	private readonly Encoding encoding;

	private readonly bool isZapfDingbats;

	private readonly TransformationMatrix fontMatrix = TransformationMatrix.FromValues(0.001, 0.0, 0.0, 0.001, 0.0, 0.0);

	private readonly double ascent;

	private readonly double descent;

	public NameToken Name { get; }

	public bool IsVertical { get; }

	public FontDetails Details { get; }

	public Type1Standard14Font(AdobeFontMetrics standardFontMetrics, Encoding? overrideEncoding = null)
	{
		this.standardFontMetrics = standardFontMetrics ?? throw new ArgumentNullException("standardFontMetrics");
		encoding = overrideEncoding ?? new AdobeFontMetricsEncoding(standardFontMetrics);
		Name = NameToken.Create(standardFontMetrics.FontName);
		IsVertical = false;
		Details = new FontDetails(Name.Data, standardFontMetrics.Weight == "Bold", (standardFontMetrics.Weight == "Bold") ? 700 : 500, standardFontMetrics.ItalicAngle != 0.0);
		isZapfDingbats = encoding is ZapfDingbatsEncoding || Details.Name.Contains("ZapfDingbats");
		descent = ComputeDescent();
		ascent = ComputeAscent();
	}

	private double ComputeDescent()
	{
		if (Math.Abs(standardFontMetrics.Descender) < double.Epsilon)
		{
			return -0.25;
		}
		return fontMatrix.TransformY(standardFontMetrics.Descender);
	}

	private double ComputeAscent()
	{
		if (Math.Abs(standardFontMetrics.Ascender) < double.Epsilon)
		{
			return 0.75;
		}
		return fontMatrix.TransformY(standardFontMetrics.Ascender);
	}

	public int ReadCharacterCode(IInputBytes bytes, out int codeLength)
	{
		codeLength = 1;
		return bytes.CurrentByte;
	}

	public bool TryGetUnicode(int characterCode, [NotNullWhen(true)] out string? value)
	{
		value = null;
		string name = encoding.GetName(characterCode);
		if (string.Equals(name, ".notdef", StringComparison.OrdinalIgnoreCase))
		{
			return false;
		}
		try
		{
			if (isZapfDingbats)
			{
				value = GlyphList.ZapfDingbats.NameToUnicode(name);
				if (value != null)
				{
					return true;
				}
			}
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
		(PdfRectangle bounds, double advanceWidth) boundingBoxInGlyphSpace = GetBoundingBoxInGlyphSpace(characterCode);
		PdfRectangle item = boundingBoxInGlyphSpace.bounds;
		double item2 = boundingBoxInGlyphSpace.advanceWidth;
		item = fontMatrix.Transform(item);
		item2 = fontMatrix.TransformX(item2);
		return new CharacterBoundingBox(item, item2);
	}

	private (PdfRectangle bounds, double advanceWidth) GetBoundingBoxInGlyphSpace(int characterCode)
	{
		string name = encoding.GetName(characterCode);
		if (!standardFontMetrics.CharacterMetrics.TryGetValue(name, out AdobeFontMetricsIndividualCharacterMetric value))
		{
			return (bounds: new PdfRectangle(0, 0, 250, 0), advanceWidth: 250.0);
		}
		double item = value.Width.X;
		if (value.Width.X == 0.0 && value.BoundingBox.Width > 0.0)
		{
			item = value.BoundingBox.Width;
		}
		return (bounds: value.BoundingBox, advanceWidth: item);
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
