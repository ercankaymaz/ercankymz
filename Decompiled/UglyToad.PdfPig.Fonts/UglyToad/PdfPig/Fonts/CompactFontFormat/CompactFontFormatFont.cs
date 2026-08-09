using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts.CompactFontFormat.CharStrings;
using UglyToad.PdfPig.Fonts.CompactFontFormat.Charsets;
using UglyToad.PdfPig.Fonts.CompactFontFormat.Dictionaries;
using UglyToad.PdfPig.Fonts.Encodings;
using UglyToad.PdfPig.Fonts.Type1.CharStrings;

namespace UglyToad.PdfPig.Fonts.CompactFontFormat;

public class CompactFontFormatFont
{
	internal CompactFontFormatTopLevelDictionary TopDictionary { get; }

	internal CompactFontFormatPrivateDictionary PrivateDictionary { get; }

	internal ICompactFontFormatCharset Charset { get; }

	internal Union<Type1CharStrings, Type2CharStrings> CharStrings { get; }

	public Encoding Encoding { get; }

	public TransformationMatrix FontMatrix => TopDictionary.FontMatrix ?? TransformationMatrix.FromValues(0.001, 0.0, 0.0, 0.001, 0.0, 0.0);

	public string Weight => TopDictionary?.Weight;

	public double ItalicAngle => TopDictionary?.ItalicAngle ?? 0.0;

	internal CompactFontFormatFont(CompactFontFormatTopLevelDictionary topDictionary, CompactFontFormatPrivateDictionary privateDictionary, ICompactFontFormatCharset charset, Union<Type1CharStrings, Type2CharStrings> charStrings, Encoding fontEncoding)
	{
		TopDictionary = topDictionary;
		PrivateDictionary = privateDictionary;
		Charset = charset;
		CharStrings = charStrings;
		Encoding = fontEncoding;
	}

	public string GetCharacterName(int characterCode, bool isCid)
	{
		if (Encoding != null)
		{
			return Encoding.GetName(characterCode);
		}
		if (Charset.IsCidCharset || isCid)
		{
			return Charset?.GetNameByStringId(characterCode);
		}
		string text = GlyphList.AdobeGlyphList.UnicodeCodePointToName(characterCode);
		if (text.Equals(".notdef", StringComparison.OrdinalIgnoreCase))
		{
			return Charset?.GetNameByStringId(characterCode);
		}
		return text;
	}

	public PdfRectangle? GetCharacterBoundingBox(string characterName)
	{
		double defaultWidthX = GetDefaultWidthX(characterName);
		double nominalWidthX = GetNominalWidthX(characterName);
		if (CharStrings.TryGetFirst(out Type1CharStrings _))
		{
			throw new NotImplementedException("Type 1 CharStrings in a CFF font are currently unsupported.");
		}
		if (!CharStrings.TryGetSecond(out Type2CharStrings b))
		{
			return null;
		}
		Type2Glyph type2Glyph = b.Generate(characterName, defaultWidthX, nominalWidthX);
		PdfRectangle? boundingRectangle = PdfSubpath.GetBoundingRectangle(type2Glyph.Path);
		if (boundingRectangle.HasValue)
		{
			return boundingRectangle;
		}
		PdfRectangle fontBoundingBox = TopDictionary.FontBoundingBox;
		return new PdfRectangle(0.0, 0.0, type2Glyph.Width.GetValueOrDefault(), fontBoundingBox.Height);
	}

	public bool TryGetPath(string characterName, out IReadOnlyList<PdfSubpath> path)
	{
		double defaultWidthX = GetDefaultWidthX(characterName);
		double nominalWidthX = GetNominalWidthX(characterName);
		if (CharStrings.TryGetFirst(out Type1CharStrings _))
		{
			throw new NotImplementedException("Type 1 CharStrings in a CFF font are currently unsupported.");
		}
		if (!CharStrings.TryGetSecond(out Type2CharStrings b))
		{
			path = null;
			return false;
		}
		path = b.Generate(characterName, defaultWidthX, nominalWidthX).Path;
		return true;
	}

	public IReadOnlyList<PdfSubpath> GetCharacterPath(string characterName)
	{
		double defaultWidthX = GetDefaultWidthX(characterName);
		double nominalWidthX = GetNominalWidthX(characterName);
		if (CharStrings.TryGetFirst(out Type1CharStrings _))
		{
			throw new NotImplementedException("Type 1 CharStrings in a CFF font are currently unsupported.");
		}
		if (!CharStrings.TryGetSecond(out Type2CharStrings b))
		{
			return null;
		}
		return b.Generate(characterName, defaultWidthX, nominalWidthX).Path;
	}

	protected virtual double GetDefaultWidthX(string characterName)
	{
		return PrivateDictionary.DefaultWidthX;
	}

	protected virtual double GetNominalWidthX(string characterName)
	{
		return PrivateDictionary.NominalWidthX;
	}

	public virtual TransformationMatrix? GetFontMatrix(string characterName)
	{
		return TopDictionary.FontMatrix;
	}
}
