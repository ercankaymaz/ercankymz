using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Geometry;
using UglyToad.PdfPig.PdfFonts.CidFonts;
using UglyToad.PdfPig.PdfFonts.Cmap;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.PdfFonts.Composite;

internal sealed class Type0Font : IFont, IVerticalWritingSupported
{
	private readonly CMap? ucs2CMap;

	private readonly bool isChineseJapaneseOrKorean;

	private readonly Dictionary<int, CharacterBoundingBox> boundingBoxCache = new Dictionary<int, CharacterBoundingBox>();

	private readonly bool useLenientParsing;

	private readonly double ascent;

	private readonly double descent;

	public NameToken Name => BaseFont;

	public NameToken BaseFont { get; }

	public ICidFont CidFont { get; }

	public CMap CMap { get; }

	public ToUnicodeCMap ToUnicode { get; }

	public bool IsVertical => CMap.WritingMode == WritingMode.Vertical;

	public FontDetails Details { get; }

	public Type0Font(NameToken baseFont, ICidFont cidFont, CMap cmap, CMap? toUnicodeCMap, CMap? ucs2CMap, ParsingOptions parsingOptions, bool isChineseJapaneseOrKorean)
	{
		this.ucs2CMap = ucs2CMap;
		this.isChineseJapaneseOrKorean = isChineseJapaneseOrKorean;
		BaseFont = baseFont ?? throw new ArgumentNullException("baseFont");
		CidFont = cidFont ?? throw new ArgumentNullException("cidFont");
		CMap = cmap ?? throw new ArgumentNullException("cmap");
		ToUnicode = new ToUnicodeCMap(toUnicodeCMap);
		Details = cidFont.Details?.WithName(Name.Data) ?? FontDetails.GetDefault(Name.Data);
		useLenientParsing = parsingOptions.UseLenientParsing;
		ascent = ComputeAscent();
		descent = ComputeDescent();
	}

	private double ComputeDescent()
	{
		double num = CidFont.GetDescent();
		if (Math.Abs(num) > double.Epsilon)
		{
			return GetFontMatrix().TransformY(num);
		}
		return -0.25;
	}

	private double ComputeAscent()
	{
		double num = CidFont.GetAscent();
		if (Math.Abs(num) > double.Epsilon)
		{
			return GetFontMatrix().TransformY(num);
		}
		return 0.75;
	}

	public int ReadCharacterCode(IInputBytes bytes, out int codeLength)
	{
		long currentOffset = bytes.CurrentOffset;
		int result = CMap.ReadCode(bytes, useLenientParsing);
		codeLength = (int)(bytes.CurrentOffset - currentOffset);
		return result;
	}

	public bool TryGetUnicode(int characterCode, [NotNullWhen(true)] out string? value)
	{
		value = null;
		if (!ToUnicode.CanMapToUnicode && ucs2CMap != null)
		{
			int num = CMap.ConvertToCid(characterCode);
			if (num == 0)
			{
				return false;
			}
			if (ucs2CMap.TryConvertToUnicode(num, out value))
			{
				return value != null;
			}
			if (ucs2CMap.TryConvertToUnicode(characterCode, out value))
			{
				return value != null;
			}
		}
		if (ToUnicode.IsUsingIdentityAsUnicodeMap)
		{
			value = new string((char)characterCode, 1);
			return true;
		}
		return ToUnicode.TryGet(characterCode, out value);
	}

	public CharacterBoundingBox GetBoundingBox(int characterCode)
	{
		if (boundingBoxCache.TryGetValue(characterCode, out CharacterBoundingBox value))
		{
			return value;
		}
		int characterIdentifier = CMap.ConvertToCid(characterCode);
		PdfRectangle boundingBox = CidFont.GetBoundingBox(characterIdentifier);
		boundingBox = CidFont.GetFontMatrix(characterIdentifier).Transform(boundingBox);
		double widthFromFont = CidFont.GetWidthFromFont(characterIdentifier);
		double width = GetFontMatrix().TransformX(widthFromFont);
		CharacterBoundingBox characterBoundingBox = new CharacterBoundingBox(boundingBox, width);
		boundingBoxCache[characterCode] = characterBoundingBox;
		return characterBoundingBox;
	}

	public TransformationMatrix GetFontMatrix()
	{
		return CidFont.FontMatrix;
	}

	public double GetDescent()
	{
		return descent;
	}

	public double GetAscent()
	{
		return ascent;
	}

	public PdfVector GetPositionVector(int characterCode)
	{
		int characterIdentifier = CMap.ConvertToCid(characterCode);
		return CidFont.GetPositionVector(characterIdentifier).Scale(-0.001);
	}

	public PdfVector GetDisplacementVector(int characterCode)
	{
		int characterIdentifier = CMap.ConvertToCid(characterCode);
		return CidFont.GetDisplacementVector(characterIdentifier).Scale(0.001);
	}

	public bool TryGetPath(int characterCode, [NotNullWhen(true)] out IReadOnlyList<PdfSubpath>? path)
	{
		int characterCode2 = CMap.ConvertToCid(characterCode);
		return CidFont.TryGetPath(characterCode2, out path);
	}

	public bool TryGetNormalisedPath(int characterCode, [NotNullWhen(true)] out IReadOnlyList<PdfSubpath>? path)
	{
		int characterCode2 = CMap.ConvertToCid(characterCode);
		return CidFont.TryGetNormalisedPath(characterCode2, out path);
	}
}
