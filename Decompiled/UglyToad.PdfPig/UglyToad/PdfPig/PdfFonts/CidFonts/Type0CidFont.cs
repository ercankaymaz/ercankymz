using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Geometry;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.PdfFonts.CidFonts;

internal sealed class Type0CidFont : ICidFont
{
	private readonly ICidFontProgram fontProgram;

	private readonly VerticalWritingMetrics verticalWritingMetrics;

	private readonly double? defaultWidth;

	private readonly double scale;

	public NameToken Type { get; }

	public NameToken SubType { get; }

	public NameToken BaseFont { get; }

	public CharacterIdentifierSystemInfo SystemInfo { get; }

	public FontDetails Details => fontProgram?.Details ?? Descriptor?.ToDetails(BaseFont?.Data) ?? FontDetails.GetDefault(BaseFont?.Data);

	public TransformationMatrix FontMatrix { get; }

	public CidFontType CidFontType => CidFontType.Type0;

	public FontDescriptor Descriptor { get; }

	public IReadOnlyDictionary<int, double> Widths { get; }

	public Type0CidFont(ICidFontProgram fontProgram, NameToken type, NameToken subType, NameToken baseFont, CharacterIdentifierSystemInfo systemInfo, FontDescriptor descriptor, VerticalWritingMetrics verticalWritingMetrics, IReadOnlyDictionary<int, double> widths, double? defaultWidth)
	{
		this.fontProgram = fontProgram;
		this.verticalWritingMetrics = verticalWritingMetrics;
		this.defaultWidth = defaultWidth;
		scale = 1.0 / (double)(fontProgram?.GetFontMatrixMultiplier() ?? 1000);
		Type = type;
		SubType = subType;
		BaseFont = baseFont;
		SystemInfo = systemInfo;
		FontMatrix = TransformationMatrix.FromValues(scale, 0.0, 0.0, scale, 0.0, 0.0);
		Descriptor = descriptor;
		Widths = widths;
	}

	public double GetWidthFromFont(int characterCode)
	{
		return GetWidthFromDictionary(characterCode);
	}

	public double GetWidthFromDictionary(int cid)
	{
		if (cid < 0)
		{
			throw new ArgumentException($"The provided character code was negative: {cid}.");
		}
		if (Widths.TryGetValue(cid, out var value))
		{
			return value;
		}
		if (defaultWidth.HasValue)
		{
			return defaultWidth.Value;
		}
		if (Descriptor == null)
		{
			return 1000.0;
		}
		return Descriptor.MissingWidth;
	}

	public PdfRectangle GetBoundingBox(int characterIdentifier)
	{
		if (characterIdentifier < 0)
		{
			throw new ArgumentException($"The provided character identifier was negative: {characterIdentifier}.");
		}
		if (fontProgram == null)
		{
			return Descriptor?.BoundingBox ?? new PdfRectangle(0.0, 0.0, 1000.0, 1.0 / scale);
		}
		if (fontProgram.TryGetBoundingBox(characterIdentifier, out var boundingBox))
		{
			return boundingBox;
		}
		if (Widths.TryGetValue(characterIdentifier, out var value))
		{
			return new PdfRectangle(0.0, 0.0, value, 1.0 / scale);
		}
		if (defaultWidth.HasValue)
		{
			return new PdfRectangle(0.0, 0.0, defaultWidth.Value, 1.0 / scale);
		}
		return new PdfRectangle(0.0, 0.0, 1000.0, 1.0 / scale);
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
		if (fontProgram == null)
		{
			return FontMatrix;
		}
		if (!fontProgram.TryGetFontMatrix(characterIdentifier, out var matrix))
		{
			return FontMatrix;
		}
		return matrix.Value;
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
		path = null;
		if (fontProgram == null)
		{
			return false;
		}
		return fontProgram.TryGetPath(characterCode, out path);
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
		path = null;
		if (fontProgram == null)
		{
			return false;
		}
		if (fontProgram.TryGetPath(characterCode, out path))
		{
			path = GetFontMatrix(characterCode).Transform(path).ToArray();
			return true;
		}
		return false;
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
