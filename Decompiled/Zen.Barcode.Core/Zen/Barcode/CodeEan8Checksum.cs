using System;

namespace Zen.Barcode;

public sealed class CodeEan8Checksum : FactoryChecksum<CodeEan8GlyphFactory>
{
	private static CodeEan8Checksum _theChecksum;

	private static object _syncChecksum = new object();

	public static CodeEan8Checksum Instance
	{
		get
		{
			if (_theChecksum == null)
			{
				lock (_syncChecksum)
				{
					if (_theChecksum == null)
					{
						_theChecksum = new CodeEan8Checksum();
					}
				}
			}
			return _theChecksum;
		}
	}

	private CodeEan8Checksum()
		: base(CodeEan8GlyphFactory.Instance)
	{
	}

	public override Glyph[] GetChecksum(string text, bool allowComposite)
	{
		if (string.IsNullOrEmpty(text))
		{
			throw new ArgumentNullException("text");
		}
		char checksumChar = GetChecksumChar(text);
		return base.Factory.GetGlyphs(checksumChar, allowComposite);
	}

	public char GetChecksumChar(string text)
	{
		int num = 0;
		int num2 = text.Length - 1;
		for (int i = 0; i < text.Length; i++)
		{
			int num3 = text[num2 - i] - 48;
			num = ((i % 2 != 0) ? (num + num3) : (num + num3 * 3));
		}
		num %= 10;
		if (num > 0)
		{
			num = 10 - num;
		}
		return (char)(48 + num);
	}
}
