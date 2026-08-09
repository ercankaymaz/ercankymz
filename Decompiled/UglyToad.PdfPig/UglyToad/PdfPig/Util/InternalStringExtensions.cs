using System;

namespace UglyToad.PdfPig.Util;

internal static class InternalStringExtensions
{
	public static bool StartsWithOffset(this string value, ReadOnlySpan<char> start, int offset)
	{
		if (offset < 0)
		{
			throw new ArgumentOutOfRangeException("offset", $"Offset cannot be negative: {offset}");
		}
		if (value == null)
		{
			if (start.Length == 0 && offset == 0)
			{
				return true;
			}
			return false;
		}
		if (offset > value.Length - 1)
		{
			return false;
		}
		return value.AsSpan(offset).StartsWith(start, StringComparison.Ordinal);
	}

	public static string AsSpanOrSubstring(this string text, int start)
	{
		return text.Substring(start);
	}

	public static string AsSpanOrSubstring(this string text, int start, int length)
	{
		return text.Substring(start, length);
	}
}
