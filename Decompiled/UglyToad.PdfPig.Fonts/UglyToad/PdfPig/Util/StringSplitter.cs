using System;
using System.IO;

namespace UglyToad.PdfPig.Util;

internal ref struct StringSplitter(ReadOnlySpan<char> text, char separator)
{
	private readonly ReadOnlySpan<char> text = text;

	private readonly char separator = separator;

	private int position = 0;

	public readonly bool IsEof => position == text.Length;

	public bool TryRead(out ReadOnlySpan<char> result)
	{
		if (IsEof)
		{
			result = default(ReadOnlySpan<char>);
			return false;
		}
		int num = text.Slice(position).IndexOf(separator);
		if (num > -1)
		{
			result = text.Slice(position, num);
			position += num + 1;
		}
		else
		{
			result = text.Slice(position);
			position = text.Length;
		}
		return true;
	}

	public ReadOnlySpan<char> Read()
	{
		if (IsEof)
		{
			ThrowEof();
		}
		int start = position;
		int num = text.Slice(position).IndexOf(separator);
		if (num > -1)
		{
			position += num + 1;
			return text.Slice(start, num);
		}
		position = text.Length;
		return text.Slice(start);
	}

	private static void ThrowEof()
	{
		throw new EndOfStreamException();
	}
}
