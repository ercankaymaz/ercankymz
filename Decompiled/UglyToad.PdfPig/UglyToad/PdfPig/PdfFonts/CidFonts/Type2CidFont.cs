using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Geometry;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.PdfFonts.CidFonts;

internal sealed class Type2CidFont : ICidFont
{
	private readonly ICidFontProgram? fontProgram;

	private readonly VerticalWritingMetrics verticalWritingMetrics;

	private readonly IReadOnlyDictionary<int, double> widths;

	private readonly double? defaultWidth;

	private readonly CharacterIdentifierToGlyphIndexMap cidToGid;

	public NameToken Type { get; }

	public NameToken SubType { get; }

	public NameToken BaseFont { get; }

	public CharacterIdentifierSystemInfo SystemInfo { get; }

	public TransformationMatrix FontMatrix { get; }

	public CidFontType CidFontType => CidFontType.Type2;

	public FontDescriptor Descriptor { get; }

	public FontDetails Details => fontProgram?.Details ?? Descriptor?.ToDetails(BaseFont?.Data) ?? FontDetails.GetDefault(BaseFont?.Data);

	public Type2CidFont(NameToken type, NameToken subType, NameToken baseFont, CharacterIdentifierSystemInfo systemInfo, FontDescriptor descriptor, ICidFontProgram? fontProgram, VerticalWritingMetrics verticalWritingMetrics, IReadOnlyDictionary<int, double> widths, double? defaultWidth, CharacterIdentifierToGlyphIndexMap cidToGid)
	{
		Type = type;
		SubType = subType;
		BaseFont = baseFont;
		SystemInfo = systemInfo;
		Descriptor = descriptor;
		this.fontProgram = fontProgram;
		this.verticalWritingMetrics = verticalWritingMetrics;
		this.widths = widths;
		this.defaultWidth = defaultWidth;
		this.cidToGid = cidToGid;
		double num = 1.0 / (double)(fontProgram?.GetFontMatrixMultiplier() ?? 1000);
		FontMatrix = TransformationMatrix.FromValues(num, 0.0, 0.0, num, 0.0, 0.0);
	}

	public double GetWidthFromFont(int characterIdentifier)
	{
		if (fontProgram == null)
		{
			return GetWidthFromDictionary(characterIdentifier);
		}
		if (fontProgram.TryGetBoundingAdvancedWidth(characterIdentifier, cidToGid.GetGlyphIndex, out var width))
		{
			return width;
		}
		return GetWidthFromDictionary(characterIdentifier);
	}

	public double GetWidthFromDictionary(int characterIdentifier)
	{
		if (widths.TryGetValue(characterIdentifier, out var value))
		{
			return value;
		}
		if (defaultWidth.HasValue)
		{
			return defaultWidth.Value;
		}
		return Descriptor?.MissingWidth ?? 1000.0;
	}

	public PdfRectangle GetBoundingBox(int characterIdentifier)
	{
		if (fontProgram == null)
		{
			return Descriptor.BoundingBox;
		}
		if (fontProgram.TryGetBoundingBox(characterIdentifier, cidToGid.GetGlyphIndex, out var boundingBox))
		{
			return boundingBox;
		}
		return Descriptor.BoundingBox;
	}

	public PdfVector GetPositionVector(int characterIdentifier)
	{
		double widthFromFont = GetWidthFromFont(characterIdentifier);
		return verticalWritingMetrics.GetPositionVector(characterIdentifier, widthFromFont);
	}

	public PdfVector GetDisplacementVector(int characterIdentifier)
	{
		return verticalWritingMetrics.GetDisplacementVector(characterIdentifier);
	}

	public TransformationMatrix GetFontMatrix(int characterIdentifier)
	{
		return FontMatrix;
	}

	public double GetDescent()
	{
		if (fontProgram == null)
		{
			return Descriptor.Descent;
		}
		double? descent = fontProgram.GetDescent();
		if (descent.HasValue)
		{
			return descent.Value;
		}
		return Descriptor.Descent;
	}

	public double GetAscent()
	{
		if (fontProgram == null)
		{
			return Descriptor.Ascent;
		}
		double? ascent = fontProgram.GetAscent();
		if (ascent.HasValue)
		{
			return ascent.Value;
		}
		return Descriptor.Ascent;
	}

	public bool TryGetPath(int characterCode, [NotNullWhen(true)] out IReadOnlyList<PdfSubpath>? path)
	{
		return TryGetPath(characterCode, cidToGid.GetGlyphIndex, out path);
	}

	public bool TryGetPath(int characterCode, Func<int, int?> characterCodeToGlyphId, [NotNullWhen(true)] out IReadOnlyList<PdfSubpath>? path)
	{
		path = null;
		if (fontProgram == null)
		{
			return false;
		}
		return fontProgram.TryGetPath(characterCode, characterCodeToGlyphId, out path);
	}

	public bool TryGetNormalisedPath(int characterCode, [NotNullWhen(true)] out IReadOnlyList<PdfSubpath>? path)
	{
		return TryGetNormalisedPath(characterCode, cidToGid.GetGlyphIndex, out path);
	}

	public bool TryGetNormalisedPath(int characterCode, Func<int, int?> characterCodeToGlyphId, [NotNullWhen(true)] out IReadOnlyList<PdfSubpath>? path)
	{
		path = null;
		if (fontProgram == null)
		{
			return false;
		}
		if (fontProgram.TryGetPath(characterCode, characterCodeToGlyphId, out path))
		{
			path = GetFontMatrix(characterCode).Transform(path).ToArray();
			return true;
		}
		return false;
	}
}
