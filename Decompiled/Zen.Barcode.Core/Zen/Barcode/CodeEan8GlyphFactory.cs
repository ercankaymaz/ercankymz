using System;
using System.Collections.Generic;

namespace Zen.Barcode;

public sealed class CodeEan8GlyphFactory : GlyphFactory
{
	private static CodeEan8GlyphFactory _theFactory;

	private static object _syncFactory = new object();

	private BarGlyph[] _glyphs;

	private CompositeGlyph[] _compositeGlyphs;

	public static CodeEan8GlyphFactory Instance
	{
		get
		{
			if (_theFactory == null)
			{
				lock (_syncFactory)
				{
					if (_theFactory == null)
					{
						_theFactory = new CodeEan8GlyphFactory();
					}
				}
			}
			return _theFactory;
		}
	}

	private CodeEan8GlyphFactory()
	{
	}

	public override Glyph[] GetGlyphs(string text, bool allowComposite)
	{
		List<Glyph> list = new List<Glyph>();
		for (int i = 0; i < text.Length; i++)
		{
			int num = text[i] - 48;
			if (num < 0 || num > 9)
			{
				throw new ArgumentException("EAN13 barcode invalid.");
			}
			list.AddRange(GetGlyphs(text[i], allowComposite));
		}
		return list.ToArray();
	}

	protected override BarGlyph[] GetGlyphs()
	{
		if (_glyphs == null)
		{
			_glyphs = new BarGlyph[22]
			{
				new VaryLengthGlyph('*', 5, 3),
				new VaryLengthGlyph('|', 10, 5),
				new BarGlyph('A', 13),
				new BarGlyph('B', 25),
				new BarGlyph('C', 19),
				new BarGlyph('D', 61),
				new BarGlyph('E', 35),
				new BarGlyph('F', 49),
				new BarGlyph('G', 47),
				new BarGlyph('H', 59),
				new BarGlyph('I', 55),
				new BarGlyph('J', 11),
				new BarGlyph('a', 114),
				new BarGlyph('b', 102),
				new BarGlyph('c', 108),
				new BarGlyph('d', 66),
				new BarGlyph('e', 92),
				new BarGlyph('f', 78),
				new BarGlyph('g', 80),
				new BarGlyph('h', 68),
				new BarGlyph('i', 72),
				new BarGlyph('j', 116)
			};
		}
		return _glyphs;
	}

	protected override CompositeGlyph[] GetCompositeGlyphs()
	{
		if (_compositeGlyphs == null)
		{
			_compositeGlyphs = new CompositeGlyph[10]
			{
				new CompositeGlyph('0', GetRawGlyph('A'), GetRawGlyph('a')),
				new CompositeGlyph('1', GetRawGlyph('B'), GetRawGlyph('b')),
				new CompositeGlyph('2', GetRawGlyph('C'), GetRawGlyph('c')),
				new CompositeGlyph('3', GetRawGlyph('D'), GetRawGlyph('d')),
				new CompositeGlyph('4', GetRawGlyph('E'), GetRawGlyph('e')),
				new CompositeGlyph('5', GetRawGlyph('F'), GetRawGlyph('f')),
				new CompositeGlyph('6', GetRawGlyph('G'), GetRawGlyph('g')),
				new CompositeGlyph('7', GetRawGlyph('H'), GetRawGlyph('h')),
				new CompositeGlyph('8', GetRawGlyph('I'), GetRawGlyph('i')),
				new CompositeGlyph('9', GetRawGlyph('J'), GetRawGlyph('j'))
			};
		}
		return _compositeGlyphs;
	}
}
