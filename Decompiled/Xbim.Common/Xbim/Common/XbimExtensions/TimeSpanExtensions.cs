using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Xbim.Common.XbimExtensions;

public static class TimeSpanExtensions
{
	public static TimeSpan Iso8601DurationToTimeSpan(this string value)
	{
		if ((string.IsNullOrWhiteSpace(value) || value[0] != 'P') && value[0] != '-' && value[1] != 'P')
		{
			return default(TimeSpan);
		}
		int num = ((value[0] != '-') ? 1 : (-1));
		int num2 = 0;
		Match match = new Regex("(?<Y>[0-9]+)Y", RegexOptions.Compiled).Match(value);
		if (match.Success)
		{
			num2 += (int)((double)int.Parse(match.Groups["Y"].Value) * 365.25);
		}
		Match match2 = new Regex("^[^T]+(?<M>[0-9]+)M", RegexOptions.Compiled).Match(value);
		if (match2.Success)
		{
			num2 += (int)((double)int.Parse(match2.Groups["M"].Value) * 30.4166780729);
		}
		Match match3 = new Regex("(?<D>[0-9]+)D", RegexOptions.Compiled).Match(value);
		if (match3.Success)
		{
			num2 += int.Parse(match3.Groups["D"].Value);
		}
		int num3 = 0;
		Match match4 = new Regex("(?<H>[0-9]+)H", RegexOptions.Compiled).Match(value);
		if (match4.Success)
		{
			num3 = int.Parse(match4.Groups["H"].Value);
		}
		int num4 = 0;
		Match match5 = new Regex("T[0-9]*H?(?<M>[0-9]+)M", RegexOptions.Compiled).Match(value);
		if (match5.Success)
		{
			num4 = int.Parse(match5.Groups["M"].Value);
		}
		double num5 = 0.0;
		Match match6 = new Regex("(?<S>[0-9]+\\.?[0-9]*)S", RegexOptions.Compiled).Match(value);
		if (match6.Success)
		{
			num5 = float.Parse(match6.Groups["S"].Value, NumberStyles.Any, CultureInfo.InvariantCulture);
		}
		return new TimeSpan(num * num2, num * num3, num * num4, num * (int)num5, num * (int)((num5 - (double)(int)num5) * 1000.0));
	}

	public static string ToIso8601Representation(this TimeSpan span)
	{
		StringBuilder stringBuilder = new StringBuilder(20);
		if (span.Days < 0 || span.Hours < 0 || span.Minutes < 0 || span.Seconds < 0 || span.Milliseconds < 0)
		{
			stringBuilder.Append('-');
		}
		stringBuilder.Append('P');
		if (span.Days != 0)
		{
			stringBuilder.Append(Math.Abs(span.Days));
			stringBuilder.Append('D');
		}
		if (span.Hours != 0 || span.Minutes != 0 || span.Seconds != 0 || span.Milliseconds != 0)
		{
			stringBuilder.Append('T');
			if (span.Hours != 0)
			{
				stringBuilder.Append(Math.Abs(span.Hours));
				stringBuilder.Append('H');
			}
			if (span.Minutes != 0)
			{
				stringBuilder.Append(Math.Abs(span.Minutes));
				stringBuilder.Append('M');
			}
			if (span.Seconds != 0 || span.Milliseconds != 0)
			{
				stringBuilder.Append(((float)Math.Abs(span.Seconds) + (float)Math.Abs(span.Milliseconds) / 1000f).ToString("F3", CultureInfo.InvariantCulture));
				stringBuilder.Append('S');
			}
		}
		if (stringBuilder[stringBuilder.Length - 1] == 'P')
		{
			stringBuilder.Append("T0S");
		}
		return stringBuilder.ToString();
	}
}
