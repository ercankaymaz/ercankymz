using System.Text;

namespace PdfSharp.Pdf.Internal;

internal sealed class RawUnicodeEncoding : Encoding
{
	public override int GetByteCount(char[] chars, int index, int count)
	{
		return 2 * count;
	}

	public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
	{
		for (int num = charCount; num > 0; num--)
		{
			char c = chars[charIndex];
			bytes[byteIndex++] = (byte)((int)c >> 8);
			bytes[byteIndex++] = (byte)c;
			charIndex++;
		}
		return charCount * 2;
	}

	public override int GetCharCount(byte[] bytes, int index, int count)
	{
		return count / 2;
	}

	public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
	{
		for (int num = byteCount; num > 0; num--)
		{
			chars[charIndex] = (char)(bytes[byteIndex] << 8 + bytes[byteIndex + 1]);
			byteIndex += 2;
			charIndex++;
		}
		return byteCount;
	}

	public override int GetMaxByteCount(int charCount)
	{
		return charCount * 2;
	}

	public override int GetMaxCharCount(int byteCount)
	{
		return byteCount / 2;
	}
}
