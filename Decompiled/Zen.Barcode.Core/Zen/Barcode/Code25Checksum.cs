using System;

namespace Zen.Barcode;

public sealed class Code25Checksum : FactoryChecksum<Code25GlyphFactory>
{
	private static Code25Checksum _theStdChecksum;

	private static Code25Checksum _theIntChecksum;

	private static object _syncChecksum = new object();

	public static Code25Checksum StandardInstance
	{
		get
		{
			if (_theStdChecksum == null)
			{
				lock (_syncChecksum)
				{
					if (_theStdChecksum == null)
					{
						_theStdChecksum = new Code25Checksum(Code25GlyphFactory.StandardInstance);
					}
				}
			}
			return _theStdChecksum;
		}
	}

	public static Code25Checksum InterleavedInstance
	{
		get
		{
			if (_theIntChecksum == null)
			{
				lock (_syncChecksum)
				{
					if (_theIntChecksum == null)
					{
						_theIntChecksum = new Code25Checksum(Code25GlyphFactory.InterleavedInstance);
					}
				}
			}
			return _theIntChecksum;
		}
	}

	private Code25Checksum(Code25GlyphFactory factory)
		: base(factory)
	{
	}

	public override Glyph[] GetChecksum(string text, bool allowComposite)
	{
		if (string.IsNullOrEmpty(text))
		{
			throw new ArgumentNullException("text");
		}
		bool flag = true;
		int num = 0;
		int num2 = 0;
		int num3 = text.Length - 1;
		while (num3 >= 0)
		{
			char c = text[num3];
			if (!char.IsDigit(c))
			{
				throw new InvalidOperationException("text contains invalid characters - numbers only.");
			}
			int num4 = c - 48;
			if (flag)
			{
				num2 += num4 * 3;
			}
			else
			{
				num += num4;
			}
			num3--;
			flag = !flag;
		}
		int index = 10 - (num2 + num) % 10;
		return new Glyph[1] { base.Factory.GetRawGlyph(index) };
	}
}
