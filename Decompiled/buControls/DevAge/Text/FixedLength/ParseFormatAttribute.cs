using System;
using System.Globalization;

namespace DevAge.Text.FixedLength;

[AttributeUsage(AttributeTargets.Property)]
public class ParseFormatAttribute : Attribute
{
	private string string_0;

	private string string_1;

	private bool bool_0;

	private CultureInfo cultureInfo_0;

	public CultureInfo CultureInfo
	{
		get
		{
			return cultureInfo_0;
		}
		set
		{
			cultureInfo_0 = value;
		}
	}

	public string DateTimeFormat
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public string NumberFormat
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public bool TrimBeforeParse
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public ParseFormatAttribute()
	{
		CultureInfo invariantCulture = CultureInfo.InvariantCulture;
		DateTimeFormat = invariantCulture.DateTimeFormat.ShortDatePattern;
		NumberFormat = "+00000000.0000;-00000000.0000";
		TrimBeforeParse = true;
		CultureInfo = invariantCulture;
	}
}
