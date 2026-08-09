using System;
using System.Collections.Generic;
using System.Linq;
using CSUtilities.Text;

namespace ACadSharp;

internal static class CadUtils
{
	private static Dictionary<string, CodePage> _dxfEncodingMap = new Dictionary<string, CodePage>
	{
		{
			"gb2312",
			CodePage.Gb2312
		},
		{
			"kcs5601",
			CodePage.Ksc5601
		},
		{
			"ascii",
			CodePage.Usascii
		},
		{
			"big5",
			CodePage.big5
		},
		{
			"johab",
			CodePage.Johab
		},
		{
			"mac-roman",
			CodePage.Xmacromanian
		},
		{
			"dos437",
			CodePage.Ibm437
		},
		{
			"dos850",
			CodePage.Ibm850
		},
		{
			"dos852",
			CodePage.Ibm852
		},
		{
			"dos737",
			CodePage.Ibm737
		},
		{
			"dos866",
			CodePage.Cp866
		},
		{
			"dos855",
			CodePage.Ibm855
		},
		{
			"dos857",
			CodePage.Ibm857
		},
		{
			"dos860",
			CodePage.Ibm860
		},
		{
			"dos861",
			CodePage.Ibm861
		},
		{
			"dos863",
			CodePage.Ibm863
		},
		{
			"dos864",
			CodePage.Ibm864
		},
		{
			"dos865",
			CodePage.Ibm865
		},
		{
			"dos869",
			CodePage.Ibm869
		},
		{
			"dos720",
			CodePage.Dos720
		},
		{
			"dos775",
			CodePage.Ibm775
		},
		{
			"dos932",
			CodePage.Shift_jis
		},
		{
			"dos950",
			CodePage.big5
		},
		{
			"ansi_874",
			CodePage.Windows874
		},
		{
			"ansi_932",
			CodePage.Shift_jis
		},
		{
			"ansi_936",
			CodePage.Gb2312
		},
		{
			"ansi_950",
			CodePage.big5
		},
		{
			"ansi_1250",
			CodePage.Windows1250
		},
		{
			"ansi1250",
			CodePage.Windows1250
		},
		{
			"ansi_1251",
			CodePage.Windows1251
		},
		{
			"ansi1251",
			CodePage.Windows1251
		},
		{
			"ansi_1252",
			CodePage.Windows1252
		},
		{
			"ansi1252",
			CodePage.Windows1252
		},
		{
			"ansi_1253",
			CodePage.Windows1253
		},
		{
			"ansi1253",
			CodePage.Windows1253
		},
		{
			"ansi_1254",
			CodePage.Windows1254
		},
		{
			"ansi1254",
			CodePage.Windows1254
		},
		{
			"ansi_1255",
			CodePage.Windows1255
		},
		{
			"ansi1255",
			CodePage.Windows1255
		},
		{
			"ansi_1256",
			CodePage.Windows1256
		},
		{
			"ansi1256",
			CodePage.Windows1256
		},
		{
			"ansi_1257",
			CodePage.Windows1257
		},
		{
			"ansi1257",
			CodePage.Windows1257
		},
		{
			"iso8859-1",
			CodePage.Iso88591
		},
		{
			"iso88591",
			CodePage.Iso88591
		},
		{
			"iso8859-2",
			CodePage.Iso88592
		},
		{
			"iso88592",
			CodePage.Iso88592
		},
		{
			"iso8859-3",
			CodePage.Iso88593
		},
		{
			"iso88593",
			CodePage.Iso88593
		},
		{
			"iso8859-4",
			CodePage.Iso88594
		},
		{
			"iso88594",
			CodePage.Iso88594
		},
		{
			"iso8859-5",
			CodePage.Iso88595
		},
		{
			"iso88595",
			CodePage.Iso88595
		},
		{
			"iso8859-6",
			CodePage.Iso88596
		},
		{
			"iso88596",
			CodePage.Iso88596
		},
		{
			"iso8859-7",
			CodePage.Iso88597
		},
		{
			"iso88597",
			CodePage.Iso88597
		},
		{
			"iso8859-8",
			CodePage.Iso88598
		},
		{
			"iso88598",
			CodePage.Iso88598
		},
		{
			"iso8859-9",
			CodePage.Iso88599
		},
		{
			"iso88599",
			CodePage.Iso88599
		},
		{
			"iso8859-10",
			CodePage.Iso885910
		},
		{
			"iso885910",
			CodePage.Iso885910
		},
		{
			"iso8859-13",
			CodePage.Iso885913
		},
		{
			"iso885913",
			CodePage.Iso885913
		},
		{
			"iso885915",
			CodePage.Iso885915
		},
		{
			"iso8859-15",
			CodePage.Iso885915
		}
	};

	private static readonly LineWeightType[] _indexedValue = new LineWeightType[24]
	{
		LineWeightType.W0,
		LineWeightType.W5,
		LineWeightType.W9,
		LineWeightType.W13,
		LineWeightType.W15,
		LineWeightType.W18,
		LineWeightType.W20,
		LineWeightType.W25,
		LineWeightType.W30,
		LineWeightType.W35,
		LineWeightType.W40,
		LineWeightType.W50,
		LineWeightType.W53,
		LineWeightType.W60,
		LineWeightType.W70,
		LineWeightType.W80,
		LineWeightType.W90,
		LineWeightType.W100,
		LineWeightType.W106,
		LineWeightType.W120,
		LineWeightType.W140,
		LineWeightType.W158,
		LineWeightType.W200,
		LineWeightType.W211
	};

	private static readonly CodePage[] _pageCodes = new CodePage[45]
	{
		CodePage.Unknown,
		CodePage.Usascii,
		CodePage.Iso88591,
		CodePage.Iso88592,
		CodePage.Iso88593,
		CodePage.Iso88594,
		CodePage.Iso88595,
		CodePage.Iso88596,
		CodePage.Iso88597,
		CodePage.Iso88598,
		CodePage.Iso88599,
		CodePage.Ibm437,
		CodePage.Ibm850,
		CodePage.Ibm852,
		CodePage.Ibm855,
		CodePage.Ibm857,
		CodePage.Ibm860,
		CodePage.Ibm861,
		CodePage.Ibm863,
		CodePage.Ibm864,
		CodePage.Ibm865,
		CodePage.Ibm869,
		CodePage.Shift_jis,
		CodePage.Macintosh,
		CodePage.big5,
		CodePage.Ksc5601,
		CodePage.Johab,
		CodePage.Cp866,
		CodePage.Windows1250,
		CodePage.Windows1251,
		CodePage.Windows1252,
		CodePage.Gb2312,
		CodePage.Windows1253,
		CodePage.Windows1254,
		CodePage.Windows1255,
		CodePage.Windows1256,
		CodePage.Windows1257,
		CodePage.Windows874,
		CodePage.Shift_jis,
		CodePage.Gb2312,
		CodePage.Ksc5601,
		CodePage.big5,
		CodePage.Johab,
		CodePage.Utf16,
		CodePage.Windows1258
	};

	public static LineWeightType ToValue(byte b)
	{
		switch (b)
		{
		case 28:
		case 29:
			return LineWeightType.ByLayer;
		case 30:
			return LineWeightType.ByBlock;
		case 31:
			return LineWeightType.Default;
		default:
			if (b < 0 || b >= _indexedValue.Length)
			{
				return LineWeightType.Default;
			}
			return _indexedValue[b];
		}
	}

	public static byte ToIndex(LineWeightType value)
	{
		byte b = 0;
		switch (value)
		{
		case LineWeightType.Default:
			b = 31;
			break;
		case LineWeightType.ByBlock:
			b = 30;
			break;
		case LineWeightType.ByLayer:
			b = 29;
			break;
		default:
			b = (byte)Array.IndexOf(_indexedValue, value);
			if (b < 0)
			{
				b = 31;
			}
			break;
		}
		return b;
	}

	public static CodePage GetCodePage(string value)
	{
		if (_dxfEncodingMap.TryGetValue(value.ToLower(), out var value2))
		{
			return value2;
		}
		return CodePage.Unknown;
	}

	public static string GetCodePageName(CodePage value)
	{
		return _dxfEncodingMap.FirstOrDefault((KeyValuePair<string, CodePage> o) => o.Value == value).Key;
	}

	public static CodePage GetCodePage(int value)
	{
		return _pageCodes.ElementAtOrDefault(value);
	}

	public static int GetCodeIndex(CodePage code)
	{
		return _pageCodes.ToList().IndexOf(code);
	}

	public static ACadVersion GetVersionFromName(string name)
	{
		if (Enum.TryParse<ACadVersion>(name.Replace('.', '_').ToUpper(), out var result))
		{
			return result;
		}
		return ACadVersion.Unknown;
	}

	public static string GetNameFromVersion(ACadVersion version)
	{
		return version.ToString().Replace('_', '.');
	}

	public static double ToJulianCalendar(DateTime date)
	{
		int num = date.Year;
		int num2 = date.Month;
		int day = date.Day;
		double num3 = date.Hour;
		double num4 = date.Minute;
		double num5 = date.Second;
		double num6 = date.Millisecond;
		double num7 = (double)day + num3 / 24.0 + num4 / 1440.0 + (num5 + num6 / 1000.0) / 86400.0;
		if (num2 < 3)
		{
			num--;
			num2 += 12;
		}
		int num8 = num / 100;
		int num9 = 2 - num8 + num8 / 4;
		int num10 = ((num >= 0) ? ((int)(365.25 * (double)num)) : ((int)(365.25 * (double)num - 0.75)));
		int num11 = (int)(30.6001 * (double)(num2 + 1));
		return (double)(num9 + num10 + num11 + 1720995) + num7;
	}

	public static DateTime FromJulianCalendar(double date)
	{
		if (date < 1721426.0 || date > 5373484.0)
		{
			throw new ArgumentOutOfRangeException("date", "The valid values range from 1721426 and 5373484 that correspond to January 1, 1 and December 31, 9999 respectively.");
		}
		double num = (int)date;
		double num2 = date - num;
		int num3 = (int)((num - 1867216.25) / 36524.25);
		num = num + 1.0 + (double)num3 - (double)(int)((double)num3 / 4.0);
		int num4 = (int)num + 1524;
		int num5 = (int)(((double)num4 - 122.1) / 365.25);
		int num6 = (int)(365.25 * (double)num5);
		int num7 = (int)((double)(num4 - num6) / 30.6001);
		int num8 = ((num7 < 14) ? (num7 - 1) : (num7 - 13));
		int year = ((num8 > 2) ? (num5 - 4716) : (num5 - 4715));
		int day = num4 - num6 - (int)(30.6001 * (double)num7);
		int num9 = (int)(num2 * 24.0);
		double num10 = num2 - (double)num9 / 24.0;
		int num11 = (int)(num10 * 1440.0);
		double num12 = (num10 - (double)num11 / 1440.0) * 86400.0;
		int num13 = (int)num12;
		int millisecond = (int)((num12 - (double)num13) * 1000.0);
		return new DateTime(year, num8, day, num9, num11, num13, millisecond);
	}

	public static TimeSpan EditingTime(double elapsed)
	{
		int num = (int)elapsed;
		double num2 = elapsed - (double)num;
		int num3 = (int)(num2 * 24.0);
		double num4 = num2 - (double)num3 / 24.0;
		int num5 = (int)(num4 * 1440.0);
		double num6 = (num4 - (double)num5 / 1440.0) * 86400.0;
		int num7 = (int)num6;
		int milliseconds = (int)((num6 - (double)num7) * 1000.0);
		return new TimeSpan(num, num3, num5, num7, milliseconds);
	}

	public static void DateToJulian(DateTime date, out int jdate, out int miliseconds)
	{
		if (date < new DateTime(1, 1, 1, 12, 0, 0))
		{
			jdate = 0;
			miliseconds = 0;
			return;
		}
		date = date.AddHours(-12.0);
		int num = (int)Math.Floor((14.0 - (double)date.Month) / 12.0);
		int num2 = date.Year + 4800 - num;
		int month = date.Month;
		jdate = date.Day + (int)Math.Floor((153.0 * (double)(month + 12 * num - 3) + 2.0) / 5.0) + 365 * num2 + (int)Math.Floor((double)num2 / 4.0) - (int)Math.Floor((double)num2 / 100.0) + (int)Math.Floor((double)num2 / 400.0) - 32045;
		miliseconds = date.Millisecond + date.Second * 1000 + date.Minute * 60000 + date.Hour * 3600000;
	}
}
