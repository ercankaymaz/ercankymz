using System.IO;
using System.Text;

namespace System.IdentityModel;

internal abstract class CanonicalFormWriter
{
	internal static readonly Encoding Utf8WithoutPreamble = Encoding.UTF8;

	protected static void EncodeAndWrite(Stream stream, byte[] workBuffer, string s)
	{
		if (s.Length > workBuffer.Length)
		{
			EncodeAndWrite(stream, s);
			return;
		}
		for (int i = 0; i < s.Length; i++)
		{
			char c = s[i];
			if (c < '\u007f')
			{
				workBuffer[i] = (byte)c;
				continue;
			}
			EncodeAndWrite(stream, s);
			return;
		}
		stream.Write(workBuffer, 0, s.Length);
	}

	protected static void EncodeAndWrite(Stream stream, byte[] workBuffer, char[] chars)
	{
		EncodeAndWrite(stream, workBuffer, chars, chars.Length);
	}

	protected static void EncodeAndWrite(Stream stream, byte[] workBuffer, char[] chars, int count)
	{
		if (count > workBuffer.Length)
		{
			EncodeAndWrite(stream, chars, count);
			return;
		}
		for (int i = 0; i < count; i++)
		{
			char c = chars[i];
			if (c < '\u007f')
			{
				workBuffer[i] = (byte)c;
				continue;
			}
			EncodeAndWrite(stream, chars, count);
			return;
		}
		stream.Write(workBuffer, 0, count);
	}

	private static void EncodeAndWrite(Stream stream, string s)
	{
		byte[] bytes = Utf8WithoutPreamble.GetBytes(s);
		stream.Write(bytes, 0, bytes.Length);
	}

	private static void EncodeAndWrite(Stream stream, char[] chars, int count)
	{
		byte[] bytes = Utf8WithoutPreamble.GetBytes(chars, 0, count);
		stream.Write(bytes, 0, bytes.Length);
	}
}
