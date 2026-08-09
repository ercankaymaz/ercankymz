using System.IO;
using System.Text;

namespace QUT.GplexBuffers;

public static class BlockReaderFactory
{
	public static BlockReader Raw(Stream stream)
	{
		return delegate(char[] block, int index, int number)
		{
			byte[] array = new byte[number];
			int num = stream.Read(array, 0, number);
			int num2 = 0;
			int num3 = index;
			while (num2 < num)
			{
				block[num3] = (char)array[num2];
				num2++;
				num3++;
			}
			return num;
		};
	}

	public static BlockReader Get(Stream stream, int fallbackCodePage)
	{
		int num = Preamble(stream);
		Encoding encoding;
		if (num != 0)
		{
			encoding = Encoding.GetEncoding(num);
		}
		else
		{
			switch (fallbackCodePage)
			{
			case -1:
				return Raw(stream);
			default:
				encoding = Encoding.GetEncoding(fallbackCodePage);
				break;
			case -2:
			{
				int num2 = new Guesser(stream).GuessCodePage();
				stream.Seek(0L, SeekOrigin.Begin);
				encoding = num2 switch
				{
					-1 => Encoding.ASCII, 
					65001 => Encoding.UTF8, 
					_ => Encoding.Default, 
				};
				break;
			}
			}
		}
		return new StreamReader(stream, encoding).Read;
	}

	private static int Preamble(Stream stream)
	{
		int num = stream.ReadByte();
		int num2 = stream.ReadByte();
		if (num == 254 && num2 == 255)
		{
			return 1201;
		}
		if (num == 255 && num2 == 254)
		{
			return 1200;
		}
		int num3 = stream.ReadByte();
		if (num == 239 && num2 == 187 && num3 == 191)
		{
			return 65001;
		}
		stream.Seek(0L, SeekOrigin.Begin);
		return 0;
	}
}
