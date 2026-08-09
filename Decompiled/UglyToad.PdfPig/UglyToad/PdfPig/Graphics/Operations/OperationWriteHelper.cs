using System;
using System.Buffers;
using System.Buffers.Text;
using System.Globalization;
using System.IO;
using System.Text;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Graphics.Operations;

internal static class OperationWriteHelper
{
	private const byte Whitespace = 32;

	private const byte NewLine = 10;

	private const byte Zero = 48;

	private const byte Point = 46;

	private static readonly StandardFormat StandardFormatDouble = new StandardFormat('F', 9);

	public static void WriteText(this Stream stream, string text, bool appendWhitespace = false)
	{
		byte[] array = OtherEncodings.StringAsLatin1Bytes(text);
		stream.Write(array, 0, array.Length);
		if (appendWhitespace)
		{
			stream.WriteByte(32);
		}
	}

	public static void WriteText(this Stream stream, ReadOnlySpan<byte> asciiBytes, bool appendWhitespace = false)
	{
		stream.Write(asciiBytes);
		if (appendWhitespace)
		{
			stream.WriteByte(32);
		}
	}

	public static void WriteHex(this Stream stream, ReadOnlySpan<byte> bytes)
	{
		Span<byte> span = ((bytes.Length > 64) ? ((Span<byte>)new byte[bytes.Length * 2]) : stackalloc byte[bytes.Length * 2]);
		Span<byte> span2 = span;
		Hex.GetUtf8Chars(bytes, span2);
		stream.WriteByte(60);
		stream.Write(span2);
		stream.WriteByte(62);
	}

	public static void WriteWhiteSpace(this Stream stream)
	{
		stream.WriteByte(32);
	}

	public static void WriteNewLine(this Stream stream)
	{
		stream.WriteByte(10);
	}

	public static void WriteDouble(this Stream stream, double value)
	{
		int num = 32;
		bool flag = TryWriteDouble(stream, value, num);
		while (!flag && num <= 1024)
		{
			num *= 2;
			flag = TryWriteDouble(stream, value, num);
		}
		if (!flag)
		{
			ReadOnlySpan<byte> buffer = Encoding.UTF8.GetBytes(value.ToString("F9", CultureInfo.InvariantCulture));
			int lastSignificantDigitIndex = GetLastSignificantDigitIndex(buffer, buffer.Length);
			stream.Write(buffer.Slice(0, lastSignificantDigitIndex));
		}
	}

	private static bool TryWriteDouble(Stream stream, double value, int stackSize)
	{
		Span<byte> span = stackalloc byte[stackSize];
		if (Utf8Formatter.TryFormat(value, span, out var bytesWritten, StandardFormatDouble))
		{
			int lastSignificantDigitIndex = GetLastSignificantDigitIndex(span, bytesWritten);
			stream.Write(span.Slice(0, lastSignificantDigitIndex));
			return true;
		}
		return false;
	}

	private static int GetLastSignificantDigitIndex(ReadOnlySpan<byte> buffer, int bytesWritten)
	{
		int num = bytesWritten;
		int num2 = bytesWritten - 1;
		while (num2 > 1 && buffer[num2] == 48)
		{
			num--;
			num2--;
		}
		if (buffer[num - 1] == 46)
		{
			num--;
		}
		return num;
	}

	public static void WriteNumberText(this Stream stream, int number, string text)
	{
		stream.WriteDouble(number);
		stream.WriteByte(32);
		stream.WriteText(text);
		stream.WriteNewLine();
	}

	public static void WriteNumberText(this Stream stream, int number, ReadOnlySpan<byte> asciiBytes)
	{
		stream.WriteDouble(number);
		stream.WriteByte(32);
		stream.WriteText(asciiBytes);
		stream.WriteNewLine();
	}

	public static void WriteNumberText(this Stream stream, double number, string text)
	{
		stream.WriteDouble(number);
		stream.WriteByte(32);
		stream.WriteText(text);
		stream.WriteNewLine();
	}
}
