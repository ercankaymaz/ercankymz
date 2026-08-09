using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Text;

namespace UglyToad.PdfPig.Core;

public static class ReadHelper
{
	public const byte AsciiLineFeed = 10;

	public const byte AsciiCarriageReturn = 13;

	private static readonly HashSet<int> EndOfNameCharacters = new HashSet<int>
	{
		32, 13, 10, 9, 62, 60, 91, 47, 93, 41,
		40, 0, 12
	};

	public static string ReadLine(IInputBytes bytes)
	{
		if (bytes == null)
		{
			throw new ArgumentNullException("bytes");
		}
		if (bytes.IsAtEnd())
		{
			throw new InvalidOperationException("Error: End-of-File, expected line");
		}
		StringBuilder stringBuilder = new StringBuilder(11);
		byte b = 0;
		while (bytes.MoveNext())
		{
			b = bytes.CurrentByte;
			if (IsEndOfLine(b))
			{
				break;
			}
			stringBuilder.Append((char)b);
		}
		if (IsCarriageReturn(b) && IsLineFeed(bytes.Peek()))
		{
			bytes.MoveNext();
		}
		return stringBuilder.ToString();
	}

	public static void SkipSpaces(IInputBytes bytes)
	{
		bytes.MoveNext();
		byte currentByte = bytes.CurrentByte;
		while (IsWhitespace(currentByte) || currentByte == 37)
		{
			if (currentByte == 37)
			{
				bytes.MoveNext();
				currentByte = bytes.CurrentByte;
				while (!IsEndOfLine(currentByte))
				{
					bytes.MoveNext();
					currentByte = bytes.CurrentByte;
				}
			}
			else
			{
				bytes.MoveNext();
				currentByte = bytes.CurrentByte;
			}
		}
		if (!bytes.IsAtEnd())
		{
			bytes.Seek(bytes.CurrentOffset - 1);
		}
	}

	public static bool IsEndOfName(int ch)
	{
		return EndOfNameCharacters.Contains(ch);
	}

	public static bool IsWhitespace(byte c)
	{
		switch (c)
		{
		case 0:
		case 9:
		case 10:
		case 12:
		case 13:
		case 32:
			return true;
		default:
			return false;
		}
	}

	public static bool IsEndOfLine(char c)
	{
		return IsEndOfLine((byte)c);
	}

	public static bool IsEndOfLine(byte b)
	{
		if (!IsLineFeed(b))
		{
			return IsCarriageReturn(b);
		}
		return true;
	}

	public static bool IsLineFeed(byte? c)
	{
		return 10 == c;
	}

	public static bool IsCarriageReturn(byte c)
	{
		return 13 == c;
	}

	public static bool IsString(IInputBytes bytes, string s)
	{
		bool result = true;
		long currentOffset = bytes.CurrentOffset;
		foreach (char c in s)
		{
			if (bytes.CurrentByte != c)
			{
				result = false;
				break;
			}
			bytes.MoveNext();
		}
		bytes.Seek(currentOffset);
		return result;
	}

	public static bool IsString(IInputBytes bytes, ReadOnlySpan<byte> s)
	{
		bool result = true;
		long currentOffset = bytes.CurrentOffset;
		ReadOnlySpan<byte> readOnlySpan = s;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			byte b = readOnlySpan[i];
			if (bytes.CurrentByte != b)
			{
				result = false;
				break;
			}
			bytes.MoveNext();
		}
		bytes.Seek(currentOffset);
		return result;
	}

	public static long ReadLong(IInputBytes bytes)
	{
		SkipSpaces(bytes);
		Span<byte> buffer = stackalloc byte[19];
		ReadNumberAsUtf8Bytes(bytes, buffer, out var bytesRead);
		ReadOnlySpan<byte> readOnlySpan = buffer.Slice(0, bytesRead);
		if (Utf8Parser.TryParse(readOnlySpan, out long value, out int _, '\0'))
		{
			return value;
		}
		bytes.Seek(bytes.CurrentOffset - bytesRead);
		throw new InvalidOperationException($"Error: Expected a long type at offset {bytes.CurrentOffset}, instead got '{OtherEncodings.BytesAsLatin1String(readOnlySpan)}'");
	}

	public static bool IsDigit(int c)
	{
		if (c >= 48)
		{
			return c <= 57;
		}
		return false;
	}

	public static int ReadInt(IInputBytes bytes)
	{
		if (bytes == null)
		{
			throw new ArgumentNullException("bytes");
		}
		SkipSpaces(bytes);
		Span<byte> buffer = stackalloc byte[10];
		ReadNumberAsUtf8Bytes(bytes, buffer, out var bytesRead);
		Span<byte> span = buffer.Slice(0, bytesRead);
		if (Utf8Parser.TryParse((ReadOnlySpan<byte>)span, out int value, out int _, '\0'))
		{
			return value;
		}
		bytes.Seek(bytes.CurrentOffset - bytesRead);
		throw new PdfDocumentFormatException($"Error: Expected an integer type at offset {bytes.CurrentOffset}, instead got '{OtherEncodings.BytesAsLatin1String(span)}'");
	}

	public static bool IsHex(byte b)
	{
		return IsHex((char)b);
	}

	public static bool IsHex(char ch)
	{
		if (!char.IsDigit(ch) && (ch < 'a' || ch > 'f'))
		{
			if (ch >= 'A')
			{
				return ch <= 'F';
			}
			return false;
		}
		return true;
	}

	public static bool IsValidUtf8(byte[] input)
	{
		try
		{
			Decoder decoder = Encoding.UTF8.GetDecoder();
			int charCount = decoder.GetCharCount(input, 0, input.Length);
			decoder.Convert(chars: new char[charCount], bytes: input, byteIndex: 0, byteCount: input.Length, charIndex: 0, charCount: charCount, flush: true, bytesUsed: out var _, charsUsed: out var _, completed: out var _);
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private static void ReadNumberAsUtf8Bytes(IInputBytes reader, scoped Span<byte> buffer, out int bytesRead)
	{
		int num = 0;
		byte currentByte;
		while (reader.MoveNext() && (currentByte = reader.CurrentByte) != 32 && currentByte != 10 && currentByte != 13 && currentByte != 60 && currentByte != 91 && currentByte != 40 && currentByte != 0)
		{
			if (num >= buffer.Length)
			{
				throw new InvalidOperationException($"Number '{OtherEncodings.BytesAsLatin1String(buffer.Slice(0, num))}' is getting too long, stop reading at offset {reader.CurrentOffset}");
			}
			buffer[num++] = currentByte;
		}
		if (!reader.IsAtEnd())
		{
			reader.Seek(reader.CurrentOffset - 1);
		}
		bytesRead = num;
	}
}
