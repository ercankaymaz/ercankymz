using System;

namespace Zen.Barcode;

public sealed class Code11Checksum : FactoryChecksum<Code11GlyphFactory>
{
	private static Code11Checksum _theChecksum;

	private static object _syncChecksum = new object();

	public static Code11Checksum Instance
	{
		get
		{
			if (_theChecksum == null)
			{
				lock (_syncChecksum)
				{
					if (_theChecksum == null)
					{
						_theChecksum = new Code11Checksum();
					}
				}
			}
			return _theChecksum;
		}
	}

	private Code11Checksum()
		: base(Code11GlyphFactory.Instance)
	{
	}

	public override Glyph[] GetChecksum(string text, bool allowComposite)
	{
		if (string.IsNullOrEmpty(text))
		{
			throw new ArgumentNullException("text");
		}
		if (text.Length > 10)
		{
			char checksumChar = GetChecksumChar(text, 11);
			text += checksumChar;
			char checksumChar2 = GetChecksumChar(text, 9);
			string text2 = $"{checksumChar}{checksumChar2}";
			return base.Factory.GetGlyphs(text2, allowComposite);
		}
		char checksumChar3 = GetChecksumChar(text, 11);
		return base.Factory.GetGlyphs(checksumChar3, allowComposite);
	}

	private char GetChecksumChar(string text, int weight)
	{
		int num = 0;
		for (int i = 0; i < text.Length; i++)
		{
			int rawCharIndex = base.Factory.GetRawCharIndex(text[text.Length - i - 1]);
			num += rawCharIndex * (i % 10 + 1);
		}
		return base.Factory.GetRawGlyph(num % weight).Character;
	}
}
