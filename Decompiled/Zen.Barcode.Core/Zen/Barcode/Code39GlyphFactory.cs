namespace Zen.Barcode;

public sealed class Code39GlyphFactory : GlyphFactory
{
	private static Code39GlyphFactory _theFactory;

	private static object _syncFactory = new object();

	private BarGlyph[] _glyphs;

	private CompositeGlyph[] _compositeGlyphs;

	public static Code39GlyphFactory Instance
	{
		get
		{
			if (_theFactory == null)
			{
				lock (_syncFactory)
				{
					if (_theFactory == null)
					{
						_theFactory = new Code39GlyphFactory();
					}
				}
			}
			return _theFactory;
		}
	}

	private Code39GlyphFactory()
	{
	}

	protected override BarGlyph[] GetGlyphs()
	{
		if (_glyphs == null)
		{
			_glyphs = new BarGlyph[44]
			{
				new BinaryPitchGlyph('0', 2669, 52),
				new BinaryPitchGlyph('1', 3371, 289),
				new BinaryPitchGlyph('2', 2859, 97),
				new BinaryPitchGlyph('3', 3477, 352),
				new BinaryPitchGlyph('4', 2667, 49),
				new BinaryPitchGlyph('5', 3381, 304),
				new BinaryPitchGlyph('6', 2869, 112),
				new BinaryPitchGlyph('7', 2651, 37),
				new BinaryPitchGlyph('8', 3373, 292),
				new BinaryPitchGlyph('9', 2861, 100),
				new BinaryPitchGlyph('A', 3403, 265),
				new BinaryPitchGlyph('B', 2891, 73),
				new BinaryPitchGlyph('C', 3493, 328),
				new BinaryPitchGlyph('D', 2763, 25),
				new BinaryPitchGlyph('E', 3429, 280),
				new BinaryPitchGlyph('F', 2917, 88),
				new BinaryPitchGlyph('G', 2715, 13),
				new BinaryPitchGlyph('H', 3405, 268),
				new BinaryPitchGlyph('I', 2893, 76),
				new BinaryPitchGlyph('J', 2765, 28),
				new BinaryPitchGlyph('K', 3411, 259),
				new BinaryPitchGlyph('L', 2899, 67),
				new BinaryPitchGlyph('M', 3497, 322),
				new BinaryPitchGlyph('N', 2771, 19),
				new BinaryPitchGlyph('O', 3433, 274),
				new BinaryPitchGlyph('P', 2921, 82),
				new BinaryPitchGlyph('Q', 2739, 7),
				new BinaryPitchGlyph('R', 3417, 262),
				new BinaryPitchGlyph('S', 2905, 70),
				new BinaryPitchGlyph('T', 2777, 22),
				new BinaryPitchGlyph('U', 3243, 385),
				new BinaryPitchGlyph('V', 2475, 193),
				new BinaryPitchGlyph('W', 3285, 448),
				new BinaryPitchGlyph('X', 2411, 145),
				new BinaryPitchGlyph('Y', 3253, 400),
				new BinaryPitchGlyph('Z', 2485, 208),
				new BinaryPitchGlyph('-', 2395, 133),
				new BinaryPitchGlyph('.', 3245, 388),
				new BinaryPitchGlyph(' ', 2477, 196),
				new BinaryPitchGlyph('$', 2341, 168),
				new BinaryPitchGlyph('/', 2345, 162),
				new BinaryPitchGlyph('+', 2377, 138),
				new BinaryPitchGlyph('%', 2633, 42),
				new BinaryPitchGlyph('*', 2413, 148)
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
				new CompositeGlyph('\0', GetRawGlyph('%'), GetRawGlyph('U')),
				new CompositeGlyph('\u0001', GetRawGlyph('$'), GetRawGlyph('A')),
				new CompositeGlyph('\u0002', GetRawGlyph('$'), GetRawGlyph('B')),
				new CompositeGlyph('\u0003', GetRawGlyph('$'), GetRawGlyph('C')),
				new CompositeGlyph('\u0004', GetRawGlyph('$'), GetRawGlyph('D')),
				new CompositeGlyph('\u0005', GetRawGlyph('$'), GetRawGlyph('E')),
				new CompositeGlyph('\u0006', GetRawGlyph('$'), GetRawGlyph('F')),
				new CompositeGlyph('\a', GetRawGlyph('$'), GetRawGlyph('G')),
				new CompositeGlyph('\b', GetRawGlyph('$'), GetRawGlyph('H')),
				new CompositeGlyph('\t', GetRawGlyph('$'), GetRawGlyph('I')),
				new CompositeGlyph('\n', GetRawGlyph('$'), GetRawGlyph('J')),
				new CompositeGlyph('\v', GetRawGlyph('$'), GetRawGlyph('K')),
				new CompositeGlyph('\f', GetRawGlyph('$'), GetRawGlyph('L')),
				new CompositeGlyph('\r', GetRawGlyph('$'), GetRawGlyph('M')),
				new CompositeGlyph('\u000e', GetRawGlyph('$'), GetRawGlyph('N')),
				new CompositeGlyph('\u000f', GetRawGlyph('$'), GetRawGlyph('O')),
				new CompositeGlyph('\u0010', GetRawGlyph('$'), GetRawGlyph('P')),
				new CompositeGlyph('\u0011', GetRawGlyph('$'), GetRawGlyph('Q')),
				new CompositeGlyph('\u0012', GetRawGlyph('$'), GetRawGlyph('R')),
				new CompositeGlyph('\u0013', GetRawGlyph('$'), GetRawGlyph('S')),
				new CompositeGlyph('\u0014', GetRawGlyph('$'), GetRawGlyph('T')),
				new CompositeGlyph('\u0015', GetRawGlyph('$'), GetRawGlyph('U')),
				new CompositeGlyph('\u0016', GetRawGlyph('$'), GetRawGlyph('V')),
				new CompositeGlyph('\u0017', GetRawGlyph('$'), GetRawGlyph('W')),
				new CompositeGlyph('\u0018', GetRawGlyph('$'), GetRawGlyph('X')),
				new CompositeGlyph('\u0019', GetRawGlyph('$'), GetRawGlyph('Y')),
				new CompositeGlyph('\u001a', GetRawGlyph('$'), GetRawGlyph('Z')),
				new CompositeGlyph('\u001b', GetRawGlyph('%'), GetRawGlyph('A')),
				new CompositeGlyph('\u001c', GetRawGlyph('%'), GetRawGlyph('B')),
				new CompositeGlyph('\u001d', GetRawGlyph('%'), GetRawGlyph('C')),
				new CompositeGlyph('\u001e', GetRawGlyph('%'), GetRawGlyph('D')),
				new CompositeGlyph('\u001f', GetRawGlyph('%'), GetRawGlyph('E')),
				new CompositeGlyph(';', GetRawGlyph('%'), GetRawGlyph('F')),
				new CompositeGlyph('<', GetRawGlyph('%'), GetRawGlyph('G')),
				new CompositeGlyph('=', GetRawGlyph('%'), GetRawGlyph('H')),
				new CompositeGlyph('>', GetRawGlyph('%'), GetRawGlyph('I')),
				new CompositeGlyph('?', GetRawGlyph('%'), GetRawGlyph('J')),
				new CompositeGlyph('[', GetRawGlyph('%'), GetRawGlyph('K')),
				new CompositeGlyph('\\', GetRawGlyph('%'), GetRawGlyph('L')),
				new CompositeGlyph(']', GetRawGlyph('%'), GetRawGlyph('M')),
				new CompositeGlyph('^', GetRawGlyph('%'), GetRawGlyph('N')),
				new CompositeGlyph('_', GetRawGlyph('%'), GetRawGlyph('O')),
				new CompositeGlyph('{', GetRawGlyph('%'), GetRawGlyph('P')),
				new CompositeGlyph('|', GetRawGlyph('%'), GetRawGlyph('Q')),
				new CompositeGlyph('}', GetRawGlyph('%'), GetRawGlyph('R')),
				new CompositeGlyph('~', GetRawGlyph('%'), GetRawGlyph('S')),
				new CompositeGlyph('@', GetRawGlyph('%'), GetRawGlyph('V')),
				new CompositeGlyph('`', GetRawGlyph('%'), GetRawGlyph('W')),
				new CompositeGlyph('\u007f', GetRawGlyph('%'), GetRawGlyph('Z')),
				new CompositeGlyph('!', GetRawGlyph('/'), GetRawGlyph('A')),
				new CompositeGlyph('"', GetRawGlyph('/'), GetRawGlyph('B')),
				new CompositeGlyph('#', GetRawGlyph('/'), GetRawGlyph('C')),
				new CompositeGlyph('$', GetRawGlyph('/'), GetRawGlyph('D')),
				new CompositeGlyph('%', GetRawGlyph('/'), GetRawGlyph('E')),
				new CompositeGlyph('&', GetRawGlyph('/'), GetRawGlyph('F')),
				new CompositeGlyph('\'', GetRawGlyph('/'), GetRawGlyph('G')),
				new CompositeGlyph('(', GetRawGlyph('/'), GetRawGlyph('H')),
				new CompositeGlyph(')', GetRawGlyph('/'), GetRawGlyph('I')),
				new CompositeGlyph('*', GetRawGlyph('/'), GetRawGlyph('J')),
				new CompositeGlyph('+', GetRawGlyph('/'), GetRawGlyph('K')),
				new CompositeGlyph(',', GetRawGlyph('/'), GetRawGlyph('L')),
				new CompositeGlyph('a', GetRawGlyph('+'), GetRawGlyph('A')),
				new CompositeGlyph('b', GetRawGlyph('+'), GetRawGlyph('B')),
				new CompositeGlyph('c', GetRawGlyph('+'), GetRawGlyph('C')),
				new CompositeGlyph('d', GetRawGlyph('+'), GetRawGlyph('D')),
				new CompositeGlyph('e', GetRawGlyph('+'), GetRawGlyph('E')),
				new CompositeGlyph('f', GetRawGlyph('+'), GetRawGlyph('F')),
				new CompositeGlyph('g', GetRawGlyph('+'), GetRawGlyph('G')),
				new CompositeGlyph('h', GetRawGlyph('+'), GetRawGlyph('H')),
				new CompositeGlyph('i', GetRawGlyph('+'), GetRawGlyph('I')),
				new CompositeGlyph('j', GetRawGlyph('+'), GetRawGlyph('J')),
				new CompositeGlyph('k', GetRawGlyph('+'), GetRawGlyph('K')),
				new CompositeGlyph('l', GetRawGlyph('+'), GetRawGlyph('L')),
				new CompositeGlyph('m', GetRawGlyph('+'), GetRawGlyph('M')),
				new CompositeGlyph('n', GetRawGlyph('+'), GetRawGlyph('N')),
				new CompositeGlyph('o', GetRawGlyph('+'), GetRawGlyph('O')),
				new CompositeGlyph('p', GetRawGlyph('+'), GetRawGlyph('P')),
				new CompositeGlyph('q', GetRawGlyph('+'), GetRawGlyph('Q')),
				new CompositeGlyph('r', GetRawGlyph('+'), GetRawGlyph('R')),
				new CompositeGlyph('s', GetRawGlyph('+'), GetRawGlyph('S')),
				new CompositeGlyph('t', GetRawGlyph('+'), GetRawGlyph('T')),
				new CompositeGlyph('u', GetRawGlyph('+'), GetRawGlyph('U')),
				new CompositeGlyph('v', GetRawGlyph('+'), GetRawGlyph('V')),
				new CompositeGlyph('w', GetRawGlyph('+'), GetRawGlyph('W')),
				new CompositeGlyph('x', GetRawGlyph('+'), GetRawGlyph('X')),
				new CompositeGlyph('y', GetRawGlyph('+'), GetRawGlyph('Y')),
				new CompositeGlyph('z', GetRawGlyph('+'), GetRawGlyph('Z'))
			};
		}
		return _compositeGlyphs;
	}
}
