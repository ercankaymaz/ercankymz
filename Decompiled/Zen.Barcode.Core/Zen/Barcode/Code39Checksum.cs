using System;

namespace Zen.Barcode;

public sealed class Code39Checksum : FactoryChecksum<Code39GlyphFactory>
{
	private static Code39Checksum _theChecksum;

	private static object _syncChecksum = new object();

	public static Code39Checksum Instance
	{
		get
		{
			if (_theChecksum == null)
			{
				lock (_syncChecksum)
				{
					if (_theChecksum == null)
					{
						_theChecksum = new Code39Checksum();
					}
				}
			}
			return _theChecksum;
		}
	}

	private Code39Checksum()
		: base(Code39GlyphFactory.Instance)
	{
	}

	public override Glyph[] GetChecksum(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			throw new ArgumentNullException("text");
		}
		char checksumChar = GetChecksumChar(text);
		return base.Factory.GetGlyphs(checksumChar);
	}

	private char GetChecksumChar(string text)
	{
		int num = 0;
		for (int i = 0; i < text.Length; i++)
		{
			int rawCharIndex = base.Factory.GetRawCharIndex(text[i]);
			if (rawCharIndex > 42)
			{
				throw new ArgumentException("text string invalid for code39");
			}
			num += rawCharIndex;
		}
		return base.Factory.GetRawGlyph(num % 43).Character;
	}
}
