namespace Zen.Barcode;

public sealed class Code11GlyphFactory : GlyphFactory
{
	private static Code11GlyphFactory _theFactory;

	private static object _syncFactory = new object();

	private BarGlyph[] _glyphs;

	public static Code11GlyphFactory Instance
	{
		get
		{
			if (_theFactory == null)
			{
				lock (_syncFactory)
				{
					if (_theFactory == null)
					{
						_theFactory = new Code11GlyphFactory();
					}
				}
			}
			return _theFactory;
		}
	}

	private Code11GlyphFactory()
	{
	}

	protected override BarGlyph[] GetGlyphs()
	{
		if (_glyphs == null)
		{
			_glyphs = new BarGlyph[12]
			{
				new BinaryPitchVaryLengthGlyph('0', 43, 1, 6),
				new BinaryPitchVaryLengthGlyph('1', 107, 17, 7),
				new BinaryPitchVaryLengthGlyph('2', 75, 9, 7),
				new BinaryPitchVaryLengthGlyph('3', 101, 24, 7),
				new BinaryPitchVaryLengthGlyph('4', 91, 5, 7),
				new BinaryPitchVaryLengthGlyph('5', 109, 20, 7),
				new BinaryPitchVaryLengthGlyph('6', 77, 12, 7),
				new BinaryPitchVaryLengthGlyph('7', 83, 3, 7),
				new BinaryPitchVaryLengthGlyph('8', 105, 18, 7),
				new BinaryPitchVaryLengthGlyph('9', 53, 16, 6),
				new BinaryPitchVaryLengthGlyph('-', 45, 4, 6),
				new BinaryPitchVaryLengthGlyph('*', 89, 6, 7)
			};
		}
		return _glyphs;
	}

	protected override CompositeGlyph[] GetCompositeGlyphs()
	{
		return new CompositeGlyph[0];
	}
}
