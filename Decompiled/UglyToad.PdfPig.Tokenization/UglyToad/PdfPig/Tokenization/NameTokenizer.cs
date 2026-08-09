using System;
using System.Text;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Tokenization;

internal sealed class NameTokenizer : ITokenizer
{
	public bool ReadsNextByte { get; } = true;

	static NameTokenizer()
	{
	}

	public bool TryTokenize(byte currentByte, IInputBytes inputBytes, out IToken token)
	{
		token = null;
		if (currentByte != 47)
		{
			return false;
		}
		using ArrayPoolBufferWriter<byte> arrayPoolBufferWriter = new ArrayPoolBufferWriter<byte>();
		bool flag = false;
		int num = 0;
		Span<char> span = stackalloc char[2];
		while (inputBytes.MoveNext())
		{
			byte currentByte2 = inputBytes.CurrentByte;
			if (currentByte2 == 35)
			{
				flag = true;
			}
			else if (flag)
			{
				if (ReadHelper.IsHex((char)currentByte2))
				{
					span[num] = (char)currentByte2;
					num++;
					if (num == 2)
					{
						int num2 = ((span[0] <= '9') ? (span[0] - 48) : (char.ToUpper(span[0]) - 65 + 10));
						int num3 = ((span[1] <= '9') ? (span[1] - 48) : (char.ToUpper(span[1]) - 65 + 10));
						byte value = (byte)(num2 * 16 + num3);
						arrayPoolBufferWriter.Write(value);
						flag = false;
						num = 0;
					}
					continue;
				}
				arrayPoolBufferWriter.Write(35);
				if (num == 1)
				{
					arrayPoolBufferWriter.Write((byte)span[0]);
				}
				if (ReadHelper.IsEndOfName(currentByte2))
				{
					break;
				}
				if (currentByte2 == 35)
				{
					flag = true;
					num = 0;
				}
				else
				{
					arrayPoolBufferWriter.Write(currentByte2);
					flag = false;
					num = 0;
				}
			}
			else
			{
				if (ReadHelper.IsEndOfName(currentByte2))
				{
					break;
				}
				arrayPoolBufferWriter.Write(currentByte2);
			}
		}
		byte[] array = arrayPoolBufferWriter.WrittenSpan.ToArray();
		string name = (ReadHelper.IsValidUtf8(array) ? Encoding.UTF8.GetString(array) : Encoding.GetEncoding("windows-1252").GetString(array));
		token = NameToken.Create(name);
		return true;
	}
}
