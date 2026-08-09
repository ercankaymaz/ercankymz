using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts;
using UglyToad.PdfPig.Fonts.CompactFontFormat;
using UglyToad.PdfPig.Fonts.Encodings;
using UglyToad.PdfPig.Fonts.Type1;
using UglyToad.PdfPig.PdfFonts.Cmap;
using UglyToad.PdfPig.PdfFonts.Composite;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.PdfFonts.Simple;

internal sealed class Type1FontSimple : IFont
{
	private static readonly TransformationMatrix DefaultTransformationMatrix = TransformationMatrix.FromValues(0.001, 0.0, 0.0, 0.001, 0.0, 0.0);

	private readonly Dictionary<int, CharacterBoundingBox> cachedBoundingBoxes = new Dictionary<int, CharacterBoundingBox>();

	private readonly int firstChar;

	private readonly int lastChar;

	private readonly double[] widths;

	private readonly FontDescriptor fontDescriptor;

	private readonly Encoding encoding;

	private readonly Union<Type1Font, CompactFontFormatFontCollection>? fontProgram;

	private readonly ToUnicodeCMap toUnicodeCMap;

	private readonly TransformationMatrix fontMatrix;

	private readonly double ascent;

	private readonly double descent;

	private readonly bool isZapfDingbats;

	public NameToken Name { get; }

	public bool IsVertical { get; }

	public FontDetails Details { get; }

	public Type1FontSimple(NameToken name, int firstChar, int lastChar, double[] widths, FontDescriptor fontDescriptor, Encoding encoding, CMap toUnicodeCMap, Union<Type1Font, CompactFontFormatFontCollection> fontProgram)
	{
		this.firstChar = firstChar;
		this.lastChar = lastChar;
		this.widths = widths;
		this.fontDescriptor = fontDescriptor;
		this.encoding = encoding;
		this.fontProgram = fontProgram;
		this.toUnicodeCMap = new ToUnicodeCMap(toUnicodeCMap);
		TransformationMatrix transformationMatrix = DefaultTransformationMatrix;
		if (fontProgram != null)
		{
			CompactFontFormatFontCollection b;
			if (fontProgram.TryGetFirst(out Type1Font a))
			{
				transformationMatrix = a.FontMatrix;
			}
			else if (fontProgram.TryGetSecond(out b))
			{
				transformationMatrix = b.GetFirstTransformationMatrix();
			}
		}
		fontMatrix = transformationMatrix;
		Name = name;
		Details = fontDescriptor?.ToDetails(name?.Data) ?? FontDetails.GetDefault(name?.Data);
		isZapfDingbats = encoding is ZapfDingbatsEncoding || Details.Name.Contains("ZapfDingbats");
		descent = ComputeDescent();
		ascent = ComputeAscent();
	}

	private double ComputeDescent()
	{
		if (Math.Abs(fontDescriptor.Descent) > double.Epsilon)
		{
			return fontMatrix.TransformY(fontDescriptor.Descent);
		}
		return -0.25;
	}

	private double ComputeAscent()
	{
		if (Math.Abs(fontDescriptor.Ascent) > double.Epsilon)
		{
			return fontMatrix.TransformY(fontDescriptor.Ascent);
		}
		return 0.75;
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
			try
			{
				value = char.ConvertFromUtf32(characterCode);
				return true;
			}
			catch
			{
				if (fontProgram == null)
				{
					return false;
				}
				bool result = false;
				if (fontProgram.TryGetFirst(out Type1Font a))
				{
					result = a.Encoding.TryGetValue(characterCode, out value);
				}
				return result;
			}
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
		return value != null;
	}

	public CharacterBoundingBox GetBoundingBox(int characterCode)
	{
		if (cachedBoundingBoxes.TryGetValue(characterCode, out CharacterBoundingBox value))
		{
			return value;
		}
		PdfRectangle boundingBoxInGlyphSpace = GetBoundingBoxInGlyphSpace(characterCode);
		TransformationMatrix transformationMatrix = fontMatrix;
		boundingBoxInGlyphSpace = transformationMatrix.Transform(boundingBoxInGlyphSpace);
		double width = GetWidth(characterCode, boundingBoxInGlyphSpace);
		CharacterBoundingBox characterBoundingBox = new CharacterBoundingBox(boundingBoxInGlyphSpace, width / 1000.0);
		cachedBoundingBoxes[characterCode] = characterBoundingBox;
		return characterBoundingBox;
	}

	private double GetWidth(int characterCode, PdfRectangle boundingBox)
	{
		int num = characterCode - firstChar;
		if (num >= 0 && num < widths.Length)
		{
			return widths[num];
		}
		FontDescriptor obj = fontDescriptor;
		if (obj != null)
		{
			_ = obj.MissingWidth;
			if (true)
			{
				return fontDescriptor.MissingWidth;
			}
		}
		return boundingBox.Width;
	}

	private PdfRectangle GetBoundingBoxInGlyphSpace(int characterCode)
	{
		if (characterCode < firstChar || characterCode > lastChar)
		{
			return new PdfRectangle(0, 0, 250, 0);
		}
		if (fontProgram == null)
		{
			return new PdfRectangle(0.0, 0.0, widths[characterCode - firstChar], 0.0);
		}
		PdfRectangle? pdfRectangle = null;
		CompactFontFormatFontCollection b;
		if (fontProgram.TryGetFirst(out Type1Font a))
		{
			string name = encoding.GetName(characterCode);
			pdfRectangle = a.GetCharacterBoundingBox(name);
		}
		else if (fontProgram.TryGetSecond(out b))
		{
			CompactFontFormatFont firstFont = b.FirstFont;
			string characterName = ((encoding == null) ? b.GetCharacterName(characterCode, isCid: false) : encoding.GetName(characterCode));
			pdfRectangle = firstFont.GetCharacterBoundingBox(characterName);
		}
		if (!pdfRectangle.HasValue)
		{
			return new PdfRectangle(0.0, 0.0, widths[characterCode - firstChar], 0.0);
		}
		return pdfRectangle.Value;
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
		IReadOnlyList<PdfSubpath> readOnlyList = null;
		if (characterCode < firstChar || characterCode > lastChar)
		{
			return false;
		}
		if (fontProgram == null)
		{
			return false;
		}
		CompactFontFormatFontCollection b;
		if (fontProgram.TryGetFirst(out Type1Font a))
		{
			string name = encoding.GetName(characterCode);
			readOnlyList = a.GetCharacterPath(name);
		}
		else if (fontProgram.TryGetSecond(out b))
		{
			CompactFontFormatFont firstFont = b.FirstFont;
			string characterName = ((encoding == null) ? b.GetCharacterName(characterCode, isCid: false) : encoding.GetName(characterCode));
			readOnlyList = firstFont.GetCharacterPath(characterName);
		}
		if (readOnlyList != null)
		{
			path = readOnlyList;
			return true;
		}
		return false;
	}

	public bool TryGetNormalisedPath(int characterCode, [NotNullWhen(true)] out IReadOnlyList<PdfSubpath>? path)
	{
		if (TryGetPath(characterCode, out path))
		{
			path = fontMatrix.Transform(path).ToArray();
			return true;
		}
		return false;
	}
}
