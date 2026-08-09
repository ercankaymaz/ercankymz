using System;
using System.Collections.Generic;

namespace Zen.Barcode;

public class Code128GlyphFactory : GlyphFactory
{
	private enum BlockParserState
	{
		Free,
		UseSetA,
		UseUpgradableSetA,
		UseSetB,
		UseSetC
	}

	private static Code128GlyphFactory _theFactory;

	private static object _syncFactory = new object();

	private Code128Glyph[] _glyphs;

	public static Code128GlyphFactory Instance
	{
		get
		{
			if (_theFactory == null)
			{
				lock (_syncFactory)
				{
					if (_theFactory == null)
					{
						_theFactory = new Code128GlyphFactory();
					}
				}
			}
			return _theFactory;
		}
	}

	private Code128GlyphFactory()
	{
	}

	public override Glyph[] GetGlyphs(string text, bool allowComposite)
	{
		if (allowComposite)
		{
			throw new NotSupportedException("Return of composite glyphs not supported.");
		}
		List<Glyph> list = new List<Glyph>();
		while (!string.IsNullOrEmpty(text))
		{
			text = GetSetBlock(text, out var set, out var subBlock);
			if (list.Count == 0)
			{
				switch (set)
				{
				case 0:
					list.Add(_glyphs[103]);
					break;
				case 1:
					list.Add(_glyphs[104]);
					break;
				case 2:
					list.Add(_glyphs[105]);
					break;
				}
			}
			else
			{
				switch (set)
				{
				case 0:
					list.Add(_glyphs[101]);
					break;
				case 1:
					list.Add(_glyphs[100]);
					break;
				case 2:
					list.Add(_glyphs[99]);
					break;
				}
			}
			for (int i = 0; i < subBlock.Length; i++)
			{
				bool flag = i == subBlock.Length - 1;
				char c = subBlock[i];
				int num = -1;
				if (set == 2 && char.IsDigit(c))
				{
					if (!flag && char.IsDigit(subBlock[i + 1]))
					{
						num = int.Parse(subBlock.Substring(i, 2));
						i++;
					}
					else
					{
						num = int.Parse(subBlock.Substring(i, 1));
					}
				}
				else
				{
					num = GetSetIndex(set, c);
				}
				list.Add(_glyphs[num]);
			}
		}
		return list.ToArray();
	}

	protected override BarGlyph[] GetGlyphs()
	{
		if (_glyphs == null)
		{
			_glyphs = new Code128Glyph[108]
			{
				new Code128Glyph(' ', ' ', '\0', 1740),
				new Code128Glyph('!', '!', '\u0001', 1644),
				new Code128Glyph('"', '"', '\u0002', 1638),
				new Code128Glyph('#', '#', '\u0003', 1176),
				new Code128Glyph('$', '$', '\u0004', 1164),
				new Code128Glyph('%', '%', '\u0005', 1100),
				new Code128Glyph('&', '&', '\u0006', 1224),
				new Code128Glyph('\'', '\'', '\a', 1220),
				new Code128Glyph('(', '(', '\b', 1124),
				new Code128Glyph(')', ')', '\t', 1608),
				new Code128Glyph('*', '*', '\n', 1604),
				new Code128Glyph('+', '+', '\v', 1572),
				new Code128Glyph(',', ',', '\f', 1436),
				new Code128Glyph('-', '-', '\r', 1244),
				new Code128Glyph('.', '.', '\u000e', 1230),
				new Code128Glyph('/', '/', '\u000f', 1484),
				new Code128Glyph('0', '0', '\u0010', 1260),
				new Code128Glyph('1', '1', '\u0011', 1254),
				new Code128Glyph('2', '2', '\u0012', 1650),
				new Code128Glyph('3', '3', '\u0013', 1628),
				new Code128Glyph('4', '4', '\u0014', 1614),
				new Code128Glyph('5', '5', '\u0015', 1764),
				new Code128Glyph('6', '6', '\u0016', 1652),
				new Code128Glyph('7', '7', '\u0017', 1902),
				new Code128Glyph('8', '8', '\u0018', 1868),
				new Code128Glyph('9', '9', '\u0019', 1836),
				new Code128Glyph(':', ':', '\u001a', 1830),
				new Code128Glyph(';', ';', '\u001b', 1892),
				new Code128Glyph('<', '<', '\u001c', 1844),
				new Code128Glyph('=', '=', '\u001d', 1842),
				new Code128Glyph('>', '>', '\u001e', 1752),
				new Code128Glyph('?', '?', '\u001f', 1734),
				new Code128Glyph('@', '@', ' ', 1590),
				new Code128Glyph('A', 'A', '!', 1304),
				new Code128Glyph('B', 'B', '"', 1112),
				new Code128Glyph('C', 'C', '#', 1094),
				new Code128Glyph('D', 'D', '$', 1416),
				new Code128Glyph('E', 'E', '%', 1128),
				new Code128Glyph('F', 'F', '&', 1122),
				new Code128Glyph('G', 'G', '\'', 1672),
				new Code128Glyph('H', 'H', '(', 1576),
				new Code128Glyph('I', 'I', ')', 1570),
				new Code128Glyph('J', 'J', '*', 1464),
				new Code128Glyph('K', 'K', '+', 1422),
				new Code128Glyph('L', 'L', ',', 1134),
				new Code128Glyph('M', 'M', '-', 1496),
				new Code128Glyph('N', 'N', '.', 1478),
				new Code128Glyph('O', 'O', '/', 1142),
				new Code128Glyph('P', 'P', '0', 1910),
				new Code128Glyph('Q', 'Q', '1', 1678),
				new Code128Glyph('R', 'R', '2', 1582),
				new Code128Glyph('S', 'S', '3', 1768),
				new Code128Glyph('T', 'T', '4', 1762),
				new Code128Glyph('U', 'U', '5', 1774),
				new Code128Glyph('V', 'V', '6', 1880),
				new Code128Glyph('W', 'W', '7', 1862),
				new Code128Glyph('X', 'X', '8', 1814),
				new Code128Glyph('Y', 'Y', '9', 1896),
				new Code128Glyph('Z', 'Z', ':', 1890),
				new Code128Glyph('[', '[', ';', 1818),
				new Code128Glyph('\\', '\\', '<', 1914),
				new Code128Glyph(']', ']', '=', 1602),
				new Code128Glyph('^', '^', '>', 1930),
				new Code128Glyph('_', '_', '?', 1328),
				new Code128Glyph('\0', '`', '@', 1292),
				new Code128Glyph('\u0001', 'a', 'A', 1200),
				new Code128Glyph('\u0002', 'b', 'B', 1158),
				new Code128Glyph('\u0003', 'c', 'C', 1068),
				new Code128Glyph('\u0004', 'd', 'D', 1062),
				new Code128Glyph('\u0005', 'e', 'E', 1424),
				new Code128Glyph('\u0006', 'f', 'F', 1412),
				new Code128Glyph('\a', 'g', 'G', 1232),
				new Code128Glyph('\b', 'h', 'H', 1218),
				new Code128Glyph('\t', 'i', 'I', 1076),
				new Code128Glyph('\n', 'j', 'J', 1074),
				new Code128Glyph('\v', 'k', 'K', 1554),
				new Code128Glyph('\f', 'l', 'L', 1616),
				new Code128Glyph('\r', 'm', 'M', 1978),
				new Code128Glyph('\u000e', 'n', 'N', 1556),
				new Code128Glyph('\u000f', 'o', 'O', 1146),
				new Code128Glyph('\u0010', 'p', 'P', 1340),
				new Code128Glyph('\u0011', 'q', 'Q', 1212),
				new Code128Glyph('\u0012', 'r', 'R', 1182),
				new Code128Glyph('\u0013', 's', 'S', 1508),
				new Code128Glyph('\u0014', 't', 'T', 1268),
				new Code128Glyph('\u0015', 'u', 'U', 1266),
				new Code128Glyph('\u0016', 'v', 'V', 1956),
				new Code128Glyph('\u0017', 'w', 'W', 1940),
				new Code128Glyph('\u0018', 'x', 'X', 1938),
				new Code128Glyph('\u0019', 'y', 'Y', 1758),
				new Code128Glyph('\u001a', 'z', 'Z', 1782),
				new Code128Glyph('\u001b', '{', '[', 1974),
				new Code128Glyph('\u001c', '|', '\\', 1400),
				new Code128Glyph('\u001d', '}', ']', 1310),
				new Code128Glyph('\u001e', '~', '^', 1118),
				new Code128Glyph('\u001f', '\u007f', '_', 1512),
				new Code128Glyph(Code128SpecialGlyph.Func3, Code128SpecialGlyph.Func3, '`', 1506),
				new Code128Glyph(Code128SpecialGlyph.Func2, Code128SpecialGlyph.Func2, 'a', 1960),
				new Code128Glyph(Code128SpecialGlyph.Shift, Code128SpecialGlyph.Shift, 'b', 1954),
				new Code128Glyph(Code128SpecialGlyph.SwitchToC, Code128SpecialGlyph.SwitchToC, 'c', 1502),
				new Code128Glyph(Code128SpecialGlyph.SwitchToB, Code128SpecialGlyph.Func4, Code128SpecialGlyph.SwitchToB, 1518),
				new Code128Glyph(Code128SpecialGlyph.Func4, Code128SpecialGlyph.SwitchToA, Code128SpecialGlyph.SwitchToA, 1886),
				new Code128Glyph(Code128SpecialGlyph.Func1, Code128SpecialGlyph.Func1, Code128SpecialGlyph.Func1, 1966),
				new Code128Glyph(Code128SpecialGlyph.StartSetA, Code128SpecialGlyph.StartSetA, Code128SpecialGlyph.StartSetA, 1668),
				new Code128Glyph(Code128SpecialGlyph.StartSetB, Code128SpecialGlyph.StartSetB, Code128SpecialGlyph.StartSetB, 1680),
				new Code128Glyph(Code128SpecialGlyph.StartSetC, Code128SpecialGlyph.StartSetC, Code128SpecialGlyph.StartSetC, 1692),
				new Code128Glyph(Code128SpecialGlyph.Stop, Code128SpecialGlyph.Stop, Code128SpecialGlyph.Stop, 1594),
				new Code128Glyph(Code128SpecialGlyph.Terminal, Code128SpecialGlyph.Terminal, Code128SpecialGlyph.Terminal, 1536)
			};
		}
		return _glyphs;
	}

	protected override CompositeGlyph[] GetCompositeGlyphs()
	{
		return new CompositeGlyph[0];
	}

	internal BarGlyph[] GetGlyphArray()
	{
		return GetGlyphs();
	}

	private bool IsInSet(int set, char character)
	{
		return GetSetIndex(set, character, Code128SpecialGlyph.None) != -1;
	}

	private bool IsInSet(int set, Code128SpecialGlyph special)
	{
		return GetSetIndex(set, '\0', special) != -1;
	}

	private int GetSetIndex(int set, char character)
	{
		return GetSetIndex(set, character, Code128SpecialGlyph.None);
	}

	private int GetSetIndex(int set, Code128SpecialGlyph special)
	{
		return GetSetIndex(set, '\0', special);
	}

	private int GetSetIndex(int set, char character, Code128SpecialGlyph special)
	{
		GetGlyphs();
		for (int i = 0; i < _glyphs.Length; i++)
		{
			if ((special != Code128SpecialGlyph.None && _glyphs[i].GetSpecialBySet(set) == special) || (special == Code128SpecialGlyph.None && _glyphs[i].GetCharacterBySet(set) == character))
			{
				return i;
			}
		}
		return -1;
	}

	private string GetSetBlock(string text, out int set, out string subBlock)
	{
		GetGlyphs();
		BlockParserState blockParserState = BlockParserState.Free;
		int i;
		for (i = 0; i < text.Length; i++)
		{
			if (char.IsDigit(text[i]) && i < text.Length - 1 && char.IsDigit(text[i + 1]))
			{
				switch (blockParserState)
				{
				case BlockParserState.Free:
					blockParserState = BlockParserState.UseSetC;
					i++;
					continue;
				case BlockParserState.UseSetC:
					i++;
					continue;
				}
			}
			else if (IsInSet(0, text[i]))
			{
				switch (blockParserState)
				{
				case BlockParserState.Free:
					blockParserState = ((!IsInSet(1, text[i])) ? BlockParserState.UseSetA : BlockParserState.UseUpgradableSetA);
					continue;
				case BlockParserState.UseUpgradableSetA:
					if (!IsInSet(1, text[i]))
					{
						blockParserState = BlockParserState.UseSetA;
					}
					continue;
				case BlockParserState.UseSetA:
					continue;
				}
			}
			else if (IsInSet(1, text[i]))
			{
				switch (blockParserState)
				{
				case BlockParserState.Free:
				case BlockParserState.UseUpgradableSetA:
					blockParserState = BlockParserState.UseSetB;
					continue;
				case BlockParserState.UseSetB:
					continue;
				}
			}
			break;
		}
		subBlock = text.Substring(0, i);
		switch (blockParserState)
		{
		case BlockParserState.UseSetA:
		case BlockParserState.UseUpgradableSetA:
			set = 0;
			break;
		case BlockParserState.UseSetB:
			set = 1;
			break;
		case BlockParserState.UseSetC:
			set = 2;
			break;
		default:
			throw new InvalidOperationException("Invalid state.");
		}
		return text.Substring(i);
	}
}
