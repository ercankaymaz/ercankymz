using System.Text;

namespace PdfSharp.Pdf.Internal;

public sealed class RawEncoding : Encoding
{
	public override int GetByteCount(char[] chars, int index, int count)
	{
		return count;
	}

	public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex)
	{
		for (int num = charCount; num > 0; num--)
		{
			bytes[byteIndex] = (byte)chars[charIndex];
			charIndex++;
			byteIndex++;
		}
		return charCount;
	}

	public override int GetCharCount(byte[] bytes, int index, int count)
	{
		return count;
	}

	public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
	{
		for (int num = byteCount; num > 0; num--)
		{
			chars[charIndex] = (char)bytes[byteIndex];
			byteIndex++;
			charIndex++;
		}
		return byteCount;
	}

	public override int GetMaxByteCount(int charCount)
	{
		return charCount;
	}

	public override int GetMaxCharCount(int byteCount)
	{
		return byteCount;
	}
}
