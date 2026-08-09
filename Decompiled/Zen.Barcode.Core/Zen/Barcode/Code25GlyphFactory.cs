namespace Zen.Barcode;

public abstract class Code25GlyphFactory : GlyphFactory
{
	private static Code25StandardGlyphFactory _theStdFactory;

	private static Code25InterleavedGlyphFactory _theIntFactory;

	private static object _syncFactory = new object();

	public static Code25StandardGlyphFactory StandardInstance
	{
		get
		{
			if (_theStdFactory == null)
			{
				lock (_syncFactory)
				{
					if (_theStdFactory == null)
					{
						_theStdFactory = new Code25StandardGlyphFactory();
					}
				}
			}
			return _theStdFactory;
		}
	}

	public static Code25InterleavedGlyphFactory InterleavedInstance
	{
		get
		{
			if (_theIntFactory == null)
			{
				lock (_syncFactory)
				{
					if (_theIntFactory == null)
					{
						_theIntFactory = new Code25InterleavedGlyphFactory();
					}
				}
			}
			return _theIntFactory;
		}
	}

	protected override CompositeGlyph[] GetCompositeGlyphs()
	{
		return new CompositeGlyph[0];
	}
}
