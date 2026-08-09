using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts;
using UglyToad.PdfPig.Fonts.AdobeFontMetrics;
using UglyToad.PdfPig.Fonts.Encodings;
using UglyToad.PdfPig.Fonts.TrueType;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.PdfFonts.Simple;

internal sealed class TrueTypeStandard14FallbackSimpleFont : IFont
{
	public class MetricOverrides
	{
		public int? FirstCharacterCode { get; }

		public IReadOnlyList<double>? Widths { get; }

		public bool HasOverriddenMetrics { get; }

		public MetricOverrides(int? firstCharacterCode, IReadOnlyList<double>? widths)
		{
			FirstCharacterCode = firstCharacterCode;
			Widths = widths;
			HasOverriddenMetrics = FirstCharacterCode.HasValue && Widths != null && Widths.Count > 0;
		}

		public bool TryGetWidth(int characterCode, out double width)
		{
			width = 0.0;
			if (!HasOverriddenMetrics || !FirstCharacterCode.HasValue)
			{
				return false;
			}
			int num = characterCode - FirstCharacterCode.Value;
			if (num < 0 || num >= Widths.Count)
			{
				return false;
			}
			width = Widths[num];
			return true;
		}
	}

	private static readonly TransformationMatrix DefaultTransformation = TransformationMatrix.FromValues(0.001, 0.0, 0.0, 0.001, 0.0, 0.0);

	private readonly TransformationMatrix fontMatrix;

	private readonly double ascent;

	private readonly double descent;

	private readonly AdobeFontMetrics fontMetrics;

	private readonly Encoding encoding;

	private readonly TrueTypeFont font;

	private readonly MetricOverrides overrides;

	public NameToken? Name { get; }

	public bool IsVertical { get; }

	public FontDetails Details { get; set; }

	public TrueTypeStandard14FallbackSimpleFont(NameToken name, AdobeFontMetrics fontMetrics, Encoding encoding, TrueTypeFont font, MetricOverrides overrides)
	{
		this.fontMetrics = fontMetrics;
		this.encoding = encoding ?? throw new ArgumentNullException("encoding");
		this.font = font;
		this.overrides = overrides;
		Name = name;
		Details = ((fontMetrics == null) ? FontDetails.GetDefault(Name?.Data) : new FontDetails(Name?.Data, fontMetrics.Weight == "Bold", (fontMetrics.Weight == "Bold") ? 700 : 500, fontMetrics.ItalicAngle != 0.0));
		if (this.font?.TableRegister.HeaderTable != null)
		{
			double num = this.font.GetUnitsPerEm();
			fontMatrix = TransformationMatrix.FromValues(1.0 / num, 0.0, 0.0, 1.0 / num, 0.0, 0.0);
		}
		else
		{
			fontMatrix = DefaultTransformation;
		}
		descent = ComputeDescent();
		ascent = ComputeAscent();
	}

	private double ComputeDescent()
	{
		if (fontMetrics != null)
		{
			return GetFontMatrix().TransformY(fontMetrics.Descender);
		}
		return GetFontMatrix().TransformY(font.TableRegister.HorizontalHeaderTable.Descent);
	}

	private double ComputeAscent()
	{
		if (fontMetrics != null)
		{
			return GetFontMatrix().TransformY(fontMetrics.Ascender);
		}
		return GetFontMatrix().TransformY(font.TableRegister.HorizontalHeaderTable.Ascent);
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
		try
		{
			value = GlyphList.AdobeGlyphList.NameToUnicode(name);
		}
		catch
		{
			return false;
		}
		return true;
	}

	public CharacterBoundingBox GetBoundingBox(int characterCode)
	{
		double width = 0.0;
		TransformationMatrix transformationMatrix = GetFontMatrix();
		if (font != null && font.TryGetBoundingBox(characterCode, out var boundingBox))
		{
			boundingBox = transformationMatrix.Transform(boundingBox);
			MetricOverrides metricOverrides = overrides;
			if (metricOverrides == null || !metricOverrides.TryGetWidth(characterCode, out width))
			{
				string name = encoding.GetName(characterCode);
				width = ((!fontMetrics.CharacterMetrics.TryGetValue(name, out AdobeFontMetricsIndividualCharacterMetric value)) ? boundingBox.Width : DefaultTransformation.TransformX(value.Width.X));
			}
			else
			{
				width = DefaultTransformation.TransformX(width);
			}
			return new CharacterBoundingBox(boundingBox, width);
		}
		string name2 = encoding.GetName(characterCode);
		if (!fontMetrics.CharacterMetrics.TryGetValue(name2, out AdobeFontMetricsIndividualCharacterMetric value2))
		{
			return new CharacterBoundingBox(default(PdfRectangle), 0.0);
		}
		MetricOverrides metricOverrides2 = overrides;
		width = ((metricOverrides2 != null && metricOverrides2.TryGetWidth(characterCode, out width)) ? DefaultTransformation.TransformX(width) : transformationMatrix.TransformX(value2.Width.X));
		boundingBox = transformationMatrix.Transform(value2.BoundingBox);
		return new CharacterBoundingBox(boundingBox, width);
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
		if (font == null)
		{
			return false;
		}
		return font.TryGetPath(characterCode, out path);
	}

	public bool TryGetNormalisedPath(int characterCode, [NotNullWhen(true)] out IReadOnlyList<PdfSubpath>? path)
	{
		if (!TryGetPath(characterCode, out path))
		{
			return false;
		}
		path = GetFontMatrix().Transform(path).ToArray();
		return true;
	}
}
