using System;
using System.Collections.Generic;

namespace Zen.Barcode;

public sealed class Code93Checksum : FactoryChecksum<Code93GlyphFactory>
{
	private static Code93Checksum _theChecksum;

	private static object _syncChecksum = new object();

	public static Code93Checksum Instance
	{
		get
		{
			if (_theChecksum == null)
			{
				lock (_syncChecksum)
				{
					if (_theChecksum == null)
					{
						_theChecksum = new Code93Checksum();
					}
				}
			}
			return _theChecksum;
		}
	}

	private Code93Checksum()
		: base(Code93GlyphFactory.Instance)
	{
	}

	public override Glyph[] GetChecksum(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			throw new ArgumentNullException("text");
		}
		char checksumChar = GetChecksumChar(text, 20);
		text += checksumChar;
		char checksumChar2 = GetChecksumChar(text, 15);
		List<Glyph> list = new List<Glyph>();
		list.Add(base.Factory.GetRawGlyph(checksumChar));
		list.Add(base.Factory.GetRawGlyph(checksumChar2));
		return list.ToArray();
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
