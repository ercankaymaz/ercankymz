namespace Zen.Barcode;

public sealed class Code25InterleavedGlyphFactory : Code25GlyphFactory
{
	private BarGlyph[] _glyphs;

	protected override BarGlyph[] GetGlyphs()
	{
		if (_glyphs == null)
		{
			_glyphs = new BarGlyph[12]
			{
				new VaryLengthGlyph('0', 6, 5),
				new VaryLengthGlyph('1', 17, 5),
				new VaryLengthGlyph('2', 9, 5),
				new VaryLengthGlyph('3', 24, 5),
				new VaryLengthGlyph('4', 5, 5),
				new VaryLengthGlyph('5', 20, 5),
				new VaryLengthGlyph('6', 12, 5),
				new VaryLengthGlyph('7', 3, 5),
				new VaryLengthGlyph('8', 18, 5),
				new VaryLengthGlyph('9', 10, 5),
				new VaryLengthGlyph('-', 10, 4),
				new VaryLengthGlyph('*', 13, 4)
			};
		}
		return _glyphs;
	}
}
