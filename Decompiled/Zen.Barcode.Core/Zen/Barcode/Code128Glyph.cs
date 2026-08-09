using System;

namespace Zen.Barcode;

public class Code128Glyph : MultisetGlyph
{
	private Code128SpecialGlyph[] _special;

	public Code128Glyph(char first, char second, char third, short bitEncoding)
		: base(new char[3] { first, second, third }, bitEncoding)
	{
		Code128SpecialGlyph[] special = new Code128SpecialGlyph[3];
		_special = special;
	}

	public Code128Glyph(Code128SpecialGlyph first, char second, char third, short bitEncoding)
		: base(new char[3] { '\0', second, third }, bitEncoding)
	{
		if (first == Code128SpecialGlyph.None)
		{
			throw new ArgumentException("first cannot be None.");
		}
		_special = new Code128SpecialGlyph[3]
		{
			first,
			Code128SpecialGlyph.None,
			Code128SpecialGlyph.None
		};
	}

	public Code128Glyph(Code128SpecialGlyph first, Code128SpecialGlyph second, char third, short bitEncoding)
		: base(new char[3] { '\0', '\0', third }, bitEncoding)
	{
		if (first == Code128SpecialGlyph.None)
		{
			throw new ArgumentException("first cannot be None.");
		}
		if (second == Code128SpecialGlyph.None)
		{
			throw new ArgumentException("second cannot be None.");
		}
		_special = new Code128SpecialGlyph[3]
		{
			first,
			second,
			Code128SpecialGlyph.None
		};
	}

	public Code128Glyph(Code128SpecialGlyph first, Code128SpecialGlyph second, Code128SpecialGlyph third, short bitEncoding)
		: base(new char[3], bitEncoding)
	{
		if (first == Code128SpecialGlyph.None)
		{
			throw new ArgumentException("first cannot be None.");
		}
		if (second == Code128SpecialGlyph.None)
		{
			throw new ArgumentException("second cannot be None.");
		}
		if (third == Code128SpecialGlyph.None)
		{
			throw new ArgumentException("third cannot be None.");
		}
		_special = new Code128SpecialGlyph[3] { first, second, third };
	}

	public Code128SpecialGlyph GetSpecialBySet(int set)
	{
		if (set < 0 || set >= _special.Length)
		{
			throw new ArgumentOutOfRangeException("set", set, "set out of range.");
		}
		return _special[set];
	}
}
