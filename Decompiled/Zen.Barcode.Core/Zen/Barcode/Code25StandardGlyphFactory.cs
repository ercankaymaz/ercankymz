namespace Zen.Barcode;

public sealed class Code25StandardGlyphFactory : Code25GlyphFactory
{
	private BarGlyph[] _glyphs;

	protected override BarGlyph[] GetGlyphs()
	{
		if (_glyphs == null)
		{
			_glyphs = new BarGlyph[12]
			{
				new VaryLengthGlyph('0', 5597, 13),
				new VaryLengthGlyph('1', 7511, 13),
				new VaryLengthGlyph('2', 5975, 13),
				new VaryLengthGlyph('3', 7637, 13),
				new VaryLengthGlyph('4', 5591, 13),
				new VaryLengthGlyph('5', 7541, 13),
				new VaryLengthGlyph('6', 6005, 13),
				new VaryLengthGlyph('7', 5495, 13),
				new VaryLengthGlyph('8', 7517, 13),
				new VaryLengthGlyph('9', 5981, 13),
				new VaryLengthGlyph('-', 109, 7),
				new VaryLengthGlyph('*', 107, 7)
			};
		}
		return _glyphs;
	}
}
