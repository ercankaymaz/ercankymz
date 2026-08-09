using System;
using System.Globalization;

namespace Xbim.IO.Step21;

public class Part21Formatter : IFormatProvider, ICustomFormatter
{
	private static readonly CultureInfo _cInfo = new CultureInfo("en-US", useUserOverride: false);

	public object GetFormat(Type formatType)
	{
		if (!(formatType == typeof(ICustomFormatter)))
		{
			return null;
		}
		return this;
	}

	public string Format(string fmt, object arg, IFormatProvider formatProvider)
	{
		if (!string.IsNullOrEmpty(fmt) && fmt.ToUpper() == "R" && arg is double num)
		{
			string text = num.ToString("R", StepText.DoubleCulture);
			if (text.Contains("."))
			{
				return text;
			}
			if (text.Contains("E"))
			{
				return text.Replace("E", ".E");
			}
			return text + ".";
		}
		if (!string.IsNullOrEmpty(fmt) && fmt.ToUpper() == "G17" && arg is double num2)
		{
			string text2 = num2.ToString("G17", StepText.DoubleCulture);
			if (text2.Contains("."))
			{
				return text2;
			}
			if (text2.Contains("E"))
			{
				return text2.Replace("E", ".E");
			}
			return text2 + ".";
		}
		if (!string.IsNullOrEmpty(fmt) && fmt.ToUpper() == "T")
		{
			if (!(arg is DateTime dateTime))
			{
				throw new ArgumentException("Only valid DateTime objects can be converted to Part21 Timestamp");
			}
			DateTime value = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			return Convert.ToInt32(dateTime.Subtract(value).TotalSeconds).ToString();
		}
		if (!string.IsNullOrEmpty(fmt) && fmt.ToUpper() == "G")
		{
			Guid guid = (Guid)arg;
			return $"'{guid.ToPart21()}'";
		}
		return $"'{arg.ToString().ToPart21()}'";
	}
}
