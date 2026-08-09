using System;
using System.ComponentModel;
using System.Globalization;

namespace ComponentFactory.Krypton.Toolkit;

public class DateTimeNullableConverter : DateTimeConverter
{
	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (value is string)
		{
			string text = value.ToString().ToLower();
			if (text == "dbnull" || text == "null" || text == "nothing")
			{
				return DBNull.Value;
			}
		}
		return base.ConvertFrom(context, culture, value);
	}
}
