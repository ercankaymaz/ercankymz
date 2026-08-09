using System;
using System.Text;

namespace UglyToad.PdfPig.Core;

public static class OtherEncodings
{
	public static readonly Encoding Iso88591 = Encoding.GetEncoding("ISO-8859-1");

	public static byte[]? StringAsLatin1Bytes(string? s)
	{
		if (s == null)
		{
			return null;
		}
		return Iso88591.GetBytes(s);
	}

	public static string BytesAsLatin1String(ReadOnlySpan<byte> bytes)
	{
		return Iso88591.GetString(bytes);
	}
}
