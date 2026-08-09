using System.Text;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Tokenization;

internal class StringTokenizer : ITokenizer
{
	private readonly bool usePdfDocEncoding;

	private readonly StringBuilder stringBuilder = new StringBuilder();

	public bool ReadsNextByte { get; }

	public StringTokenizer(bool usePdfDocEncoding)
	{
		this.usePdfDocEncoding = usePdfDocEncoding;
	}

	public bool TryTokenize(byte currentByte, IInputBytes inputBytes, out IToken token)
	{
		token = null;
		if (inputBytes == null)
		{
			return false;
		}
		if (currentByte != 40)
		{
			return false;
		}
		StringBuilder stringBuilder = this.stringBuilder;
		int num = 1;
		bool flag = false;
		bool isLineBreaking = false;
		bool isOctalActive = false;
		short[] array = new short[3];
		int octalsRead = 0;
		while (inputBytes.MoveNext())
		{
			char currentByte2 = (char)inputBytes.CurrentByte;
			if (isOctalActive)
			{
				bool flag2 = currentByte2 >= '0' && currentByte2 <= '7';
				if (flag2)
				{
					LeftShiftOctal(currentByte2, octalsRead, array);
					octalsRead++;
				}
				if (octalsRead == 3 || !flag2)
				{
					int num2 = OctalHelpers.FromOctalDigits(array);
					stringBuilder.Append((char)num2);
					array[0] = 0;
					array[1] = 0;
					array[2] = 0;
					octalsRead = 0;
					isOctalActive = false;
				}
				if (flag2)
				{
					continue;
				}
			}
			switch (currentByte2)
			{
			case ')':
				isLineBreaking = false;
				if (!flag)
				{
					num--;
				}
				flag = false;
				if (num > 0)
				{
					stringBuilder.Append(currentByte2);
				}
				num = CheckForEndOfString(num, inputBytes);
				break;
			case '(':
				isLineBreaking = false;
				if (!flag)
				{
					num++;
				}
				flag = false;
				stringBuilder.Append(currentByte2);
				break;
			case '\\':
				isLineBreaking = false;
				if (flag)
				{
					stringBuilder.Append(currentByte2);
					flag = false;
				}
				else
				{
					flag = true;
				}
				break;
			default:
				if (isLineBreaking)
				{
					if (ReadHelper.IsEndOfLine(currentByte2))
					{
						continue;
					}
					isLineBreaking = false;
					stringBuilder.Append(currentByte2);
				}
				else if (flag)
				{
					ProcessEscapedCharacter(currentByte2, stringBuilder, array, ref isOctalActive, ref octalsRead, ref isLineBreaking);
					flag = false;
				}
				else
				{
					stringBuilder.Append(currentByte2);
				}
				break;
			}
			if (num <= 0)
			{
				break;
			}
		}
		string data;
		StringToken.Encoding encodedWith;
		if (stringBuilder.Length >= 2)
		{
			if (stringBuilder[0] == 'þ' && stringBuilder[1] == 'ÿ')
			{
				byte[] bytes = OtherEncodings.StringAsLatin1Bytes(stringBuilder.ToString());
				data = Encoding.BigEndianUnicode.GetString(bytes).Substring(1);
				encodedWith = StringToken.Encoding.Utf16BE;
			}
			else if (stringBuilder[0] == 'ÿ' && stringBuilder[1] == 'þ')
			{
				byte[] bytes2 = OtherEncodings.StringAsLatin1Bytes(stringBuilder.ToString());
				data = Encoding.Unicode.GetString(bytes2).Substring(1);
				encodedWith = StringToken.Encoding.Utf16;
			}
			else if (usePdfDocEncoding)
			{
				string text = stringBuilder.ToString();
				if (PdfDocEncoding.TryConvertBytesToString(OtherEncodings.StringAsLatin1Bytes(text), out string result))
				{
					data = result;
					encodedWith = StringToken.Encoding.PdfDocEncoding;
				}
				else
				{
					data = text;
					encodedWith = StringToken.Encoding.Iso88591;
				}
			}
			else
			{
				data = stringBuilder.ToString();
				encodedWith = StringToken.Encoding.Iso88591;
			}
		}
		else if (usePdfDocEncoding)
		{
			string text2 = stringBuilder.ToString();
			if (PdfDocEncoding.TryConvertBytesToString(OtherEncodings.StringAsLatin1Bytes(text2), out string result2))
			{
				data = result2;
				encodedWith = StringToken.Encoding.PdfDocEncoding;
			}
			else
			{
				data = text2;
				encodedWith = StringToken.Encoding.Iso88591;
			}
		}
		else
		{
			data = stringBuilder.ToString();
			encodedWith = StringToken.Encoding.Iso88591;
		}
		stringBuilder.Clear();
		token = new StringToken(data, encodedWith);
		return true;
	}

	private static void LeftShiftOctal(char nextOctalChar, int octalsRead, short[] octals)
	{
		for (int num = octalsRead; num > 0; num--)
		{
			octals[num] = octals[num - 1];
		}
		short num2 = nextOctalChar.CharacterToShort();
		octals[0] = num2;
	}

	private static void ProcessEscapedCharacter(char c, StringBuilder builder, short[] octal, ref bool isOctalActive, ref int octalsRead, ref bool isLineBreaking)
	{
		switch (c)
		{
		case 'n':
			builder.Append('\n');
			break;
		case 'r':
			builder.Append('\r');
			break;
		case 't':
			builder.Append('\t');
			break;
		case 'b':
			builder.Append('\b');
			break;
		case 'f':
			builder.Append('\f');
			break;
		case '0':
		case '1':
		case '2':
		case '3':
		case '4':
		case '5':
		case '6':
		case '7':
			octal[0] = c.CharacterToShort();
			isOctalActive = true;
			octalsRead = 1;
			break;
		default:
			if (c == '\r' || c == '\n')
			{
				isLineBreaking = true;
			}
			else
			{
				builder.Append(c);
			}
			break;
		}
	}

	private static int CheckForEndOfString(int numberOfBrackets, IInputBytes bytes)
	{
		int result = numberOfBrackets;
		byte[] array = new byte[3];
		long currentOffset = bytes.CurrentOffset;
		int num = bytes.Read(array);
		if (num == 3 && array[0] == 13 && ((array[1] == 10 && array[2] == 47) || array[2] == 62 || array[1] == 47 || array[1] == 62))
		{
			result = 0;
		}
		if (num > 0)
		{
			bytes.Seek(currentOffset);
		}
		return result;
	}
}
