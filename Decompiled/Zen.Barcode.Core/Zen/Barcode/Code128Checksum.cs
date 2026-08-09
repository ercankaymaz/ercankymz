using System;

namespace Zen.Barcode;

public sealed class Code128Checksum : FactoryChecksum<Code128GlyphFactory>
{
	private static Code128Checksum _theChecksum;

	private static object _syncChecksum = new object();

	public static Code128Checksum Instance
	{
		get
		{
			if (_theChecksum == null)
			{
				lock (_syncChecksum)
				{
					if (_theChecksum == null)
					{
						_theChecksum = new Code128Checksum();
					}
				}
			}
			return _theChecksum;
		}
	}

	private Code128Checksum()
		: base(Code128GlyphFactory.Instance)
	{
	}

	public override Glyph[] GetChecksum(string text, bool allowComposite)
	{
		if (string.IsNullOrEmpty(text))
		{
			throw new ArgumentNullException("text");
		}
		Glyph[] glyphs = base.Factory.GetGlyphs(text, allowComposite: false);
		long num = base.Factory.GetRawGlyphIndex((BarGlyph)glyphs[0]);
		for (int i = 1; i < glyphs.Length; i++)
		{
			num += i * base.Factory.GetRawGlyphIndex((BarGlyph)glyphs[i]);
		}
		num %= 103;
		return new Glyph[1] { base.Factory.GetRawGlyph((int)num) };
	}

	private char GetChecksumChar(string text, int weighting)
	{
		int num = 0;
		for (int i = 0; i < text.Length; i++)
		{
			int rawCharIndex = base.Factory.GetRawCharIndex(text[text.Length - i - 1]);
			int num2 = i % weighting + 1;
			num += num2 * rawCharIndex;
		}
		return base.Factory.GetRawGlyph(num % 47).Character;
	}
}
