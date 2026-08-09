using System;
using System.Globalization;

namespace UglyToad.PdfPig.Util;

public static class DateFormatHelper
{
	public static bool TryParseDateTimeOffset(string s, out DateTimeOffset offset)
	{
		offset = DateTimeOffset.MinValue;
		if (s == null || s.Length < 4)
		{
			return false;
		}
		try
		{
			int num = 0;
			if (s[0] == 'D' && s[1] == ':')
			{
				num = 2;
			}
			if (!HasRemainingCharacters(num, 4))
			{
				return false;
			}
			if (!int.TryParse(s.AsSpanOrSubstring(num, 4), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
			{
				return false;
			}
			num += 4;
			if (!HasRemainingCharacters(num, 2))
			{
				if (!IsAtEnd(num))
				{
					return false;
				}
				offset = new DateTimeOffset(result, 1, 1, 0, 0, 0, TimeSpan.Zero);
				return true;
			}
			if (!int.TryParse(s.AsSpanOrSubstring(num, 2), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result2) || !IsWithinRange(result2, 1, 12))
			{
				return false;
			}
			num += 2;
			if (!HasRemainingCharacters(num, 2))
			{
				if (!IsAtEnd(num))
				{
					return false;
				}
				offset = new DateTimeOffset(result, result2, 1, 0, 0, 0, TimeSpan.Zero);
				return true;
			}
			if (!int.TryParse(s.AsSpanOrSubstring(num, 2), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result3) || !IsWithinRange(result3, 1, 31))
			{
				return false;
			}
			num += 2;
			if (!HasRemainingCharacters(num, 2))
			{
				if (!IsAtEnd(num))
				{
					return false;
				}
				offset = new DateTimeOffset(result, result2, result3, 0, 0, 0, TimeSpan.Zero);
				return true;
			}
			if (!int.TryParse(s.AsSpanOrSubstring(num, 2), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result4) || !IsWithinRange(result4, 0, 23))
			{
				return false;
			}
			num += 2;
			if (!HasRemainingCharacters(num, 2))
			{
				if (!IsAtEnd(num))
				{
					return false;
				}
				offset = new DateTimeOffset(result, result2, result3, result4, 0, 0, TimeSpan.Zero);
				return true;
			}
			if (!int.TryParse(s.AsSpanOrSubstring(num, 2), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result5) || !IsWithinRange(result5, 0, 59))
			{
				return false;
			}
			num += 2;
			if (!HasRemainingCharacters(num, 2))
			{
				if (!IsAtEnd(num))
				{
					return false;
				}
				offset = new DateTimeOffset(result, result2, result3, result4, result5, 0, TimeSpan.Zero);
				return true;
			}
			if (!int.TryParse(s.AsSpanOrSubstring(num, 2), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result6) || !IsWithinRange(result6, 0, 59))
			{
				return false;
			}
			num += 2;
			if (!HasRemainingCharacters(num, 1))
			{
				if (!IsAtEnd(num))
				{
					return false;
				}
				offset = new DateTimeOffset(result, result2, result3, result4, result5, result6, TimeSpan.Zero);
				return true;
			}
			char c = s[num++];
			if (c != '-' && c != '+' && c != 'Z')
			{
				return false;
			}
			int num2 = ((c == '-') ? (-1) : ((c == '+') ? 1 : 0));
			if (IsAtEnd(num))
			{
				offset = new DateTimeOffset(result, result2, result3, result4, result5, result6, TimeSpan.Zero);
				return true;
			}
			if (!HasRemainingCharacters(num, 3) || !int.TryParse(s.AsSpanOrSubstring(num, 2), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result7) || s[num + 2] != '\'' || !IsWithinRange(result7, 0, 23))
			{
				return false;
			}
			num += 3;
			if (IsAtEnd(num))
			{
				offset = new DateTimeOffset(result, result2, result3, result4, result5, result6, TimeSpan.FromHours(result7 * num2));
				return true;
			}
			if (!HasRemainingCharacters(num, 3) || !int.TryParse(s.AsSpanOrSubstring(num, 2), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result8) || s[num + 2] != '\'' || !IsWithinRange(result8, 0, 59))
			{
				return false;
			}
			num += 3;
			if (IsAtEnd(num))
			{
				offset = new DateTimeOffset(result, result2, result3, result4, result5, result6, new TimeSpan(result7 * num2, result8 * num2, 0));
				return true;
			}
			return false;
		}
		catch
		{
			return false;
		}
		bool HasRemainingCharacters(int pos, int len)
		{
			return pos + len <= s.Length;
		}
		bool IsAtEnd(int pos)
		{
			return pos == s.Length;
		}
		static bool IsWithinRange(int val, int min, int max)
		{
			if (val >= min)
			{
				return val <= max;
			}
			return false;
		}
	}
}
