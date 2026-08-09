using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Xceed.Wpf.Toolkit;

internal class DateTimeParser
{
	public static bool TryParse(string value, string format, DateTime currentDate, CultureInfo cultureInfo, bool autoClipTimeParts, out DateTime result)
	{
		bool flag = false;
		result = currentDate;
		if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(format))
		{
			return false;
		}
		UpdateValueFormatForQuotes(ref value, ref format);
		string text = ComputeDateTimeString(value, format, currentDate, cultureInfo, autoClipTimeParts).Trim();
		if (!string.IsNullOrEmpty(text))
		{
			flag = DateTime.TryParse(text, cultureInfo.DateTimeFormat, DateTimeStyles.None, out result);
		}
		if (!flag)
		{
			result = currentDate;
		}
		return flag;
	}

	private static void UpdateValueFormatForQuotes(ref string value, ref string format)
	{
		int num = format.IndexOf("'");
		if (num > -1)
		{
			int num2 = format.IndexOf("'", num + 1);
			if (num2 > -1)
			{
				string oldValue = format.Substring(num + 1, num2 - num - 1);
				value = value.Replace(oldValue, "");
				format = format.Remove(num, num2 - num + 1);
				UpdateValueFormatForQuotes(ref value, ref format);
			}
		}
	}

	private static string ComputeDateTimeString(string dateTime, string format, DateTime currentDate, CultureInfo cultureInfo, bool autoClipTimeParts)
	{
		Dictionary<string, string> dateParts = GetDateParts(currentDate, cultureInfo);
		string[] array = new string[3]
		{
			currentDate.Hour.ToString(),
			currentDate.Minute.ToString(),
			currentDate.Second.ToString()
		};
		string text = currentDate.Millisecond.ToString();
		string arg = "";
		string[] array2 = new string[7]
		{
			",",
			" ",
			"-",
			".",
			"/",
			cultureInfo.DateTimeFormat.DateSeparator,
			cultureInfo.DateTimeFormat.TimeSeparator
		};
		bool flag = false;
		UpdateSortableDateTimeString(ref dateTime, ref format, cultureInfo);
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		if (array2.Any((string s) => dateTime.Contains(s)))
		{
			list = dateTime.Split(array2, StringSplitOptions.RemoveEmptyEntries).ToList();
			list2 = format.Split(array2, StringSplitOptions.RemoveEmptyEntries).ToList();
		}
		else
		{
			string text2 = "";
			string text3 = "";
			char[] array3 = format.ToCharArray();
			for (int num = 0; num < array3.Count(); num++)
			{
				char c = array3[num];
				if (!text2.Contains(c))
				{
					if (!string.IsNullOrEmpty(text2))
					{
						list2.Add(text2);
						list.Add(text3);
					}
					text2 = c.ToString();
					text3 = ((num < dateTime.Length) ? dateTime[num].ToString() : "");
				}
				else
				{
					text2 += c;
					text3 += ((num < dateTime.Length) ? dateTime[num] : '\0');
				}
			}
			if (!string.IsNullOrEmpty(text2))
			{
				list2.Add(text2);
				list.Add(text3);
			}
		}
		if (list.Count < list2.Count)
		{
			while (list.Count != list2.Count)
			{
				list.Add("0");
			}
		}
		if (list.Count != list2.Count)
		{
			return string.Empty;
		}
		for (int num2 = 0; num2 < list2.Count; num2++)
		{
			string text4 = list2[num2];
			if (text4.Contains("ddd") || text4.Contains("GMT"))
			{
				continue;
			}
			if (text4.Contains("M"))
			{
				dateParts["Month"] = list[num2];
			}
			else if (text4.Contains("d"))
			{
				dateParts["Day"] = list[num2];
			}
			else if (text4.Contains("y"))
			{
				dateParts["Year"] = ((list[num2] != "0") ? list[num2] : "0000");
				if (dateParts["Year"].Length == 2)
				{
					int num3 = int.Parse(dateParts["Year"]);
					int twoDigitYearMax = cultureInfo.Calendar.TwoDigitYearMax;
					int num4 = ((num3 <= twoDigitYearMax % 100) ? (twoDigitYearMax / 100) : (twoDigitYearMax / 100 - 1));
					dateParts["Year"] = string.Format("{0}{1}", num4, dateParts["Year"]);
				}
			}
			else if (text4.Contains("hh") || text4.Contains("HH"))
			{
				int num5 = Convert.ToInt32(list[num2]) % 24;
				array[0] = (autoClipTimeParts ? num5.ToString() : list[num2]);
			}
			else if (text4.Contains("h") || text4.Contains("H"))
			{
				if (autoClipTimeParts)
				{
					int num6 = Convert.ToInt32(list[num2]) % 24;
					if (num6 > 11)
					{
						num6 -= 12;
						flag = true;
					}
					array[0] = num6.ToString();
				}
				else
				{
					array[0] = list[num2];
				}
			}
			else if (text4.Contains("m"))
			{
				int num7 = Convert.ToInt32(list[num2]) % 60;
				array[1] = (autoClipTimeParts ? num7.ToString() : list[num2]);
			}
			else if (text4.Contains("s"))
			{
				int num8 = Convert.ToInt32(list[num2]) % 60;
				array[2] = (autoClipTimeParts ? num8.ToString() : list[num2]);
			}
			else if (text4.Contains("f"))
			{
				text = list[num2];
			}
			else if (text4.Contains("t"))
			{
				arg = (flag ? "PM" : list[num2]);
			}
		}
		string arg2 = string.Join(cultureInfo.DateTimeFormat.DateSeparator, dateParts.Select((KeyValuePair<string, string> x) => x.Value).ToArray());
		string text5 = string.Join(cultureInfo.DateTimeFormat.TimeSeparator, array);
		text5 = text5 + "." + text;
		return $"{arg2} {text5} {arg}";
	}

	private static void UpdateSortableDateTimeString(ref string dateTime, ref string format, CultureInfo cultureInfo)
	{
		if (format == cultureInfo.DateTimeFormat.SortableDateTimePattern)
		{
			format = format.Replace("'", "").Replace("T", " ");
			dateTime = dateTime.Replace("'", "").Replace("T", " ");
		}
		else if (format == cultureInfo.DateTimeFormat.UniversalSortableDateTimePattern)
		{
			format = format.Replace("'", "").Replace("Z", "");
			dateTime = dateTime.Replace("'", "").Replace("Z", "");
		}
	}

	private static Dictionary<string, string> GetDateParts(DateTime currentDate, CultureInfo cultureInfo)
	{
		Dictionary<string, string> dateParts = new Dictionary<string, string>();
		string[] separator = new string[7]
		{
			",",
			" ",
			"-",
			".",
			"/",
			cultureInfo.DateTimeFormat.DateSeparator,
			cultureInfo.DateTimeFormat.TimeSeparator
		};
		cultureInfo.DateTimeFormat.ShortDatePattern.Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(delegate(string item)
		{
			string key = string.Empty;
			string value = string.Empty;
			if (item.Contains("M"))
			{
				key = "Month";
				value = currentDate.Month.ToString();
			}
			else if (item.Contains("d"))
			{
				key = "Day";
				value = currentDate.Day.ToString();
			}
			else if (item.Contains("y"))
			{
				key = "Year";
				value = currentDate.Year.ToString("D4");
			}
			if (!dateParts.ContainsKey(key))
			{
				dateParts.Add(key, value);
			}
		});
		return dateParts;
	}
}
