using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts;
using UglyToad.PdfPig.Fonts.Encodings;
using UglyToad.PdfPig.Fonts.TrueType;
using UglyToad.PdfPig.PdfFonts.Cmap;
using UglyToad.PdfPig.PdfFonts.Composite;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.PdfFonts.Simple;

internal sealed class TrueTypeSimpleFont : IFont
{
	private static readonly TransformationMatrix DefaultTransformation = TransformationMatrix.FromValues(0.001, 0.0, 0.0, 0.001, 0.0, 0.0);

	private readonly FontDescriptor? descriptor;

	private readonly Dictionary<int, CharacterBoundingBox> boundingBoxCache = new Dictionary<int, CharacterBoundingBox>();

	private readonly Dictionary<int, string> unicodeValuesCache = new Dictionary<int, string>();

	private readonly Encoding? encoding;

	private readonly TrueTypeFont? font;

	private readonly int firstCharacter;

	private readonly double[] widths;

	private readonly bool isZapfDingbats;

	private readonly TransformationMatrix fontMatrix;

	private readonly double descent;

	private readonly double ascent;

	public NameToken Name { get; }

	public bool IsVertical { get; }

	public FontDetails Details { get; }

	public ToUnicodeCMap ToUnicode { get; set; }

	public TrueTypeSimpleFont(NameToken name, FontDescriptor? descriptor, CMap? toUnicodeCMap, Encoding? encoding, TrueTypeFont? font, int firstCharacter, double[] widths)
	{
		this.descriptor = descriptor;
		this.encoding = encoding;
		this.font = font;
		this.firstCharacter = firstCharacter;
		this.widths = widths;
		Name = name;
		IsVertical = false;
		ToUnicode = new ToUnicodeCMap(toUnicodeCMap);
		Details = descriptor?.ToDetails(Name?.Data) ?? FontDetails.GetDefault(Name?.Data);
		isZapfDingbats = encoding is ZapfDingbatsEncoding || Details.Name.Contains("ZapfDingbats");
		double num = 1000.0;
		if (this.font?.TableRegister.HeaderTable != null)
		{
			num = this.font.GetUnitsPerEm();
		}
		fontMatrix = TransformationMatrix.FromValues(1.0 / num, 0.0, 0.0, 1.0 / num, 0.0, 0.0);
		descent = ComputeDescent();
		ascent = ComputeAscent();
	}

	private double ComputeDescent()
	{
		if (font == null)
		{
			return DefaultTransformation.TransformY(descriptor.Descent);
		}
		return GetFontMatrix().TransformY(font.TableRegister.HorizontalHeaderTable.Descent);
	}

	private double ComputeAscent()
	{
		if (font == null)
		{
			return DefaultTransformation.TransformY(descriptor.Ascent);
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
		if (unicodeValuesCache.TryGetValue(characterCode, out value))
		{
			return true;
		}
		if (ToUnicode.CanMapToUnicode && ToUnicode.TryGet(characterCode, out value))
		{
			unicodeValuesCache[characterCode] = value;
			return true;
		}
		if (encoding == null)
		{
			return false;
		}
		string name = encoding.GetName(characterCode);
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
		if (value != null)
		{
			unicodeValuesCache[characterCode] = value;
		}
		return value != null;
	}

	public CharacterBoundingBox GetBoundingBox(int characterCode)
	{
		if (boundingBoxCache.TryGetValue(characterCode, out CharacterBoundingBox value))
		{
			return value;
		}
		TransformationMatrix transformationMatrix = GetFontMatrix();
		PdfRectangle boundingBoxInGlyphSpace = GetBoundingBoxInGlyphSpace(characterCode, out var fromFont);
		double width = boundingBoxInGlyphSpace.Width;
		boundingBoxInGlyphSpace = ((!fromFont) ? DefaultTransformation.Transform(boundingBoxInGlyphSpace) : transformationMatrix.Transform(boundingBoxInGlyphSpace));
		int num = characterCode - firstCharacter;
		double width2;
		if (widths != null && num >= 0 && num < widths.Length)
		{
			fromFont = false;
			width2 = widths[num];
		}
		else if (font != null)
		{
			if (!font.TryGetAdvanceWidth(characterCode, out width2))
			{
				width2 = width;
			}
		}
		else
		{
			double[] array = widths;
			if (array == null || array.Length == 0)
			{
				throw new InvalidOperationException($"Could not retrieve width for character code: {characterCode} in font {Name}.");
			}
			width2 = widths[0];
		}
		width2 = ((!fromFont) ? DefaultTransformation.TransformX(width2) : transformationMatrix.TransformX(width2));
		CharacterBoundingBox characterBoundingBox = new CharacterBoundingBox(boundingBoxInGlyphSpace, width2);
		boundingBoxCache[characterCode] = characterBoundingBox;
		return characterBoundingBox;
	}

	public TransformationMatrix GetFontMatrix()
	{
		return fontMatrix;
	}

	private PdfRectangle GetBoundingBoxInGlyphSpace(int characterCode, out bool fromFont)
	{
		fromFont = true;
		if (font == null)
		{
			return descriptor.BoundingBox;
		}
		if (font.TryGetBoundingBox(characterCode, CharacterCodeToGlyphId, out var boundingBox))
		{
			return boundingBox;
		}
		if (font.TryGetAdvanceWidth(characterCode, out var width))
		{
			return new PdfRectangle(0.0, 0.0, width, 0.0);
		}
		fromFont = false;
		return new PdfRectangle(0.0, 0.0, GetWidth(characterCode), 0.0);
	}

	private int? CharacterCodeToGlyphId(int characterCode)
	{
		if (descriptor == null || !unicodeValuesCache.TryGetValue(characterCode, out string value) || font.TableRegister.CMapTable == null || encoding == null || !encoding.CodeToNameMap.TryGetValue(characterCode, out string value2) || value2 == null)
		{
			return null;
		}
		if (string.Equals(value2, ".notdef", StringComparison.OrdinalIgnoreCase))
		{
			return 0;
		}
		int num = 0;
		if (HasFlag(descriptor.Flags, FontDescriptorFlags.Symbolic) && font.WindowsSymbolCMap != null)
		{
			num = font.WindowsSymbolCMap.CharacterCodeToGlyphIndex(characterCode);
			if (num == 0 && characterCode >= 0 && characterCode <= 255)
			{
				num = font.WindowsSymbolCMap.CharacterCodeToGlyphIndex(characterCode + 61440);
				if (num == 0)
				{
					num = font.WindowsSymbolCMap.CharacterCodeToGlyphIndex(characterCode + 61696);
				}
				if (num == 0)
				{
					num = font.WindowsSymbolCMap.CharacterCodeToGlyphIndex(characterCode + 61952);
				}
			}
			if (num == 0 && font.WindowsUnicodeCMap != null && !string.IsNullOrEmpty(value))
			{
				num = font.WindowsUnicodeCMap.CharacterCodeToGlyphIndex(value[0]);
			}
		}
		else
		{
			if (font.WindowsUnicodeCMap != null && !string.IsNullOrEmpty(value))
			{
				num = font.WindowsUnicodeCMap.CharacterCodeToGlyphIndex(value[0]);
			}
			if (num == 0 && font.MacRomanCMap != null && MacOsRomanEncoding.Instance.NameToCodeMap.TryGetValue(value2, out var value3))
			{
				num = font.MacRomanCMap.CharacterCodeToGlyphIndex(value3);
			}
			if (num == 0 && font.TableRegister.PostScriptTable != null)
			{
				for (int i = 0; i < font.TableRegister.PostScriptTable.GlyphNames.Count; i++)
				{
					if (string.Equals(font.TableRegister.PostScriptTable.GlyphNames[i], value2, StringComparison.OrdinalIgnoreCase))
					{
						return i;
					}
				}
			}
		}
		if (num != 0)
		{
			return num;
		}
		return null;
		static bool HasFlag(FontDescriptorFlags fontDescriptorFlags, FontDescriptorFlags target)
		{
			return (fontDescriptorFlags & target) == target;
		}
	}

	private double GetWidth(int characterCode)
	{
		int num = characterCode - firstCharacter;
		if (num < 0 || num >= widths.Length)
		{
			return descriptor.MissingWidth;
		}
		return widths[num];
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
		if (font == null)
		{
			path = null;
			return false;
		}
		return font.TryGetPath(characterCode, CharacterCodeToGlyphId, out path);
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
