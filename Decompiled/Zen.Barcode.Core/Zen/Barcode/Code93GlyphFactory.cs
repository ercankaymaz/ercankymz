namespace Zen.Barcode;

public class Code93GlyphFactory : GlyphFactory
{
	private static Code93GlyphFactory _theFactory;

	private static object _syncFactory = new object();

	private BarGlyph[] _glyphs;

	private CompositeGlyph[] _compositeGlyphs;

	public static Code93GlyphFactory Instance
	{
		get
		{
			if (_theFactory == null)
			{
				lock (_syncFactory)
				{
					if (_theFactory == null)
					{
						_theFactory = new Code93GlyphFactory();
					}
				}
			}
			return _theFactory;
		}
	}

	private Code93GlyphFactory()
	{
	}

	protected override BarGlyph[] GetGlyphs()
	{
		if (_glyphs == null)
		{
			_glyphs = new BarGlyph[49]
			{
				new BarGlyph('0', 276),
				new BarGlyph('1', 328),
				new BarGlyph('2', 324),
				new BarGlyph('3', 322),
				new BarGlyph('4', 296),
				new BarGlyph('5', 292),
				new BarGlyph('6', 290),
				new BarGlyph('7', 336),
				new BarGlyph('8', 274),
				new BarGlyph('9', 266),
				new BarGlyph('A', 424),
				new BarGlyph('B', 420),
				new BarGlyph('C', 418),
				new BarGlyph('D', 404),
				new BarGlyph('E', 402),
				new BarGlyph('F', 394),
				new BarGlyph('G', 360),
				new BarGlyph('H', 356),
				new BarGlyph('I', 354),
				new BarGlyph('J', 308),
				new BarGlyph('K', 282),
				new BarGlyph('L', 344),
				new BarGlyph('M', 332),
				new BarGlyph('N', 326),
				new BarGlyph('O', 300),
				new BarGlyph('P', 278),
				new BarGlyph('Q', 436),
				new BarGlyph('R', 434),
				new BarGlyph('S', 428),
				new BarGlyph('T', 422),
				new BarGlyph('U', 406),
				new BarGlyph('V', 410),
				new BarGlyph('W', 364),
				new BarGlyph('X', 358),
				new BarGlyph('Y', 310),
				new BarGlyph('Z', 314),
				new BarGlyph('-', 302),
				new BarGlyph('.', 468),
				new BarGlyph(' ', 466),
				new BarGlyph('$', 458),
				new BarGlyph('/', 366),
				new BarGlyph('+', 374),
				new BarGlyph('%', 430),
				new BarGlyph('<', 294),
				new BarGlyph('=', 474),
				new BarGlyph('>', 470),
				new BarGlyph('?', 306),
				new BarGlyph('*', 350),
				new BarGlyph('|', 256)
			};
		}
		return _glyphs;
	}

	protected override CompositeGlyph[] GetCompositeGlyphs()
	{
		if (_compositeGlyphs == null)
		{
			_compositeGlyphs = new CompositeGlyph[87]
			{
				new CompositeGlyph('\0', GetRawGlyph('='), GetRawGlyph('U')),
				new CompositeGlyph('\u0001', GetRawGlyph('<'), GetRawGlyph('A')),
				new CompositeGlyph('\u0002', GetRawGlyph('<'), GetRawGlyph('B')),
				new CompositeGlyph('\u0003', GetRawGlyph('<'), GetRawGlyph('C')),
				new CompositeGlyph('\u0004', GetRawGlyph('<'), GetRawGlyph('D')),
				new CompositeGlyph('\u0005', GetRawGlyph('<'), GetRawGlyph('E')),
				new CompositeGlyph('\u0006', GetRawGlyph('<'), GetRawGlyph('F')),
				new CompositeGlyph('\a', GetRawGlyph('<'), GetRawGlyph('G')),
				new CompositeGlyph('\b', GetRawGlyph('<'), GetRawGlyph('H')),
				new CompositeGlyph('\t', GetRawGlyph('<'), GetRawGlyph('I')),
				new CompositeGlyph('\n', GetRawGlyph('<'), GetRawGlyph('J')),
				new CompositeGlyph('\v', GetRawGlyph('<'), GetRawGlyph('K')),
				new CompositeGlyph('\f', GetRawGlyph('<'), GetRawGlyph('L')),
				new CompositeGlyph('\r', GetRawGlyph('<'), GetRawGlyph('M')),
				new CompositeGlyph('\u000e', GetRawGlyph('<'), GetRawGlyph('N')),
				new CompositeGlyph('\u000f', GetRawGlyph('<'), GetRawGlyph('O')),
				new CompositeGlyph('\u0010', GetRawGlyph('<'), GetRawGlyph('P')),
				new CompositeGlyph('\u0011', GetRawGlyph('<'), GetRawGlyph('Q')),
				new CompositeGlyph('\u0012', GetRawGlyph('<'), GetRawGlyph('R')),
				new CompositeGlyph('\u0013', GetRawGlyph('<'), GetRawGlyph('S')),
				new CompositeGlyph('\u0014', GetRawGlyph('<'), GetRawGlyph('T')),
				new CompositeGlyph('\u0015', GetRawGlyph('<'), GetRawGlyph('U')),
				new CompositeGlyph('\u0016', GetRawGlyph('<'), GetRawGlyph('V')),
				new CompositeGlyph('\u0017', GetRawGlyph('<'), GetRawGlyph('W')),
				new CompositeGlyph('\u0018', GetRawGlyph('<'), GetRawGlyph('X')),
				new CompositeGlyph('\u0019', GetRawGlyph('<'), GetRawGlyph('Y')),
				new CompositeGlyph('\u001a', GetRawGlyph('<'), GetRawGlyph('Z')),
				new CompositeGlyph('\u001b', GetRawGlyph('='), GetRawGlyph('A')),
				new CompositeGlyph('\u001c', GetRawGlyph('='), GetRawGlyph('B')),
				new CompositeGlyph('\u001d', GetRawGlyph('='), GetRawGlyph('C')),
				new CompositeGlyph('\u001e', GetRawGlyph('='), GetRawGlyph('D')),
				new CompositeGlyph('\u001f', GetRawGlyph('='), GetRawGlyph('E')),
				new CompositeGlyph(';', GetRawGlyph('='), GetRawGlyph('F')),
				new CompositeGlyph('<', GetRawGlyph('='), GetRawGlyph('G')),
				new CompositeGlyph('=', GetRawGlyph('='), GetRawGlyph('H')),
				new CompositeGlyph('>', GetRawGlyph('='), GetRawGlyph('I')),
				new CompositeGlyph('?', GetRawGlyph('='), GetRawGlyph('J')),
				new CompositeGlyph('[', GetRawGlyph('='), GetRawGlyph('K')),
				new CompositeGlyph('\\', GetRawGlyph('='), GetRawGlyph('L')),
				new CompositeGlyph(']', GetRawGlyph('='), GetRawGlyph('M')),
				new CompositeGlyph('^', GetRawGlyph('='), GetRawGlyph('N')),
				new CompositeGlyph('_', GetRawGlyph('='), GetRawGlyph('O')),
				new CompositeGlyph('{', GetRawGlyph('='), GetRawGlyph('P')),
				new CompositeGlyph('|', GetRawGlyph('='), GetRawGlyph('Q')),
				new CompositeGlyph('}', GetRawGlyph('='), GetRawGlyph('R')),
				new CompositeGlyph('~', GetRawGlyph('='), GetRawGlyph('S')),
				new CompositeGlyph('@', GetRawGlyph('='), GetRawGlyph('V')),
				new CompositeGlyph('`', GetRawGlyph('='), GetRawGlyph('W')),
				new CompositeGlyph('\u007f', GetRawGlyph('='), GetRawGlyph('Z')),
				new CompositeGlyph('!', GetRawGlyph('>'), GetRawGlyph('A')),
				new CompositeGlyph('"', GetRawGlyph('>'), GetRawGlyph('B')),
				new CompositeGlyph('#', GetRawGlyph('>'), GetRawGlyph('C')),
				new CompositeGlyph('$', GetRawGlyph('>'), GetRawGlyph('D')),
				new CompositeGlyph('%', GetRawGlyph('>'), GetRawGlyph('E')),
				new CompositeGlyph('&', GetRawGlyph('>'), GetRawGlyph('F')),
				new CompositeGlyph('\'', GetRawGlyph('>'), GetRawGlyph('G')),
				new CompositeGlyph('(', GetRawGlyph('>'), GetRawGlyph('H')),
				new CompositeGlyph(')', GetRawGlyph('>'), GetRawGlyph('I')),
				new CompositeGlyph('*', GetRawGlyph('>'), GetRawGlyph('J')),
				new CompositeGlyph('+', GetRawGlyph('>'), GetRawGlyph('K')),
				new CompositeGlyph(',', GetRawGlyph('>'), GetRawGlyph('L')),
				new CompositeGlyph('a', GetRawGlyph('?'), GetRawGlyph('A')),
				new CompositeGlyph('b', GetRawGlyph('?'), GetRawGlyph('B')),
				new CompositeGlyph('c', GetRawGlyph('?'), GetRawGlyph('C')),
				new CompositeGlyph('d', GetRawGlyph('?'), GetRawGlyph('D')),
				new CompositeGlyph('e', GetRawGlyph('?'), GetRawGlyph('E')),
				new CompositeGlyph('f', GetRawGlyph('?'), GetRawGlyph('F')),
				new CompositeGlyph('g', GetRawGlyph('?'), GetRawGlyph('G')),
				new CompositeGlyph('h', GetRawGlyph('?'), GetRawGlyph('H')),
				new CompositeGlyph('i', GetRawGlyph('?'), GetRawGlyph('I')),
				new CompositeGlyph('j', GetRawGlyph('?'), GetRawGlyph('J')),
				new CompositeGlyph('k', GetRawGlyph('?'), GetRawGlyph('K')),
				new CompositeGlyph('l', GetRawGlyph('?'), GetRawGlyph('L')),
				new CompositeGlyph('m', GetRawGlyph('?'), GetRawGlyph('M')),
				new CompositeGlyph('n', GetRawGlyph('?'), GetRawGlyph('N')),
				new CompositeGlyph('o', GetRawGlyph('?'), GetRawGlyph('O')),
				new CompositeGlyph('p', GetRawGlyph('?'), GetRawGlyph('P')),
				new CompositeGlyph('q', GetRawGlyph('?'), GetRawGlyph('Q')),
				new CompositeGlyph('r', GetRawGlyph('?'), GetRawGlyph('R')),
				new CompositeGlyph('s', GetRawGlyph('?'), GetRawGlyph('S')),
				new CompositeGlyph('t', GetRawGlyph('?'), GetRawGlyph('T')),
				new CompositeGlyph('u', GetRawGlyph('?'), GetRawGlyph('U')),
				new CompositeGlyph('v', GetRawGlyph('?'), GetRawGlyph('V')),
				new CompositeGlyph('w', GetRawGlyph('?'), GetRawGlyph('W')),
				new CompositeGlyph('x', GetRawGlyph('?'), GetRawGlyph('X')),
				new CompositeGlyph('y', GetRawGlyph('?'), GetRawGlyph('Y')),
				new CompositeGlyph('z', GetRawGlyph('?'), GetRawGlyph('Z'))
			};
		}
		return _compositeGlyphs;
	}
}
