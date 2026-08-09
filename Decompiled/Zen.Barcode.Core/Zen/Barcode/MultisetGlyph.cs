using System;

namespace Zen.Barcode;

public class MultisetGlyph : BarGlyph
{
	private char[] _characters;

	public int Sets => _characters.Length;

	public MultisetGlyph(char[] characters, short bitEncoding)
		: base(characters[0], bitEncoding)
	{
		_characters = characters;
	}

	public char GetCharacterBySet(int set)
	{
		if (set < 0 || set >= _characters.Length)
		{
			throw new ArgumentOutOfRangeException("set", set, "set out of range.");
		}
		return _characters[set];
	}
}
