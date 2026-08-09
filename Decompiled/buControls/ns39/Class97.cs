using System;
using System.ComponentModel;
using System.Globalization;
using buControls.Controls;

namespace ns39;

internal sealed class Class97 : ExpandableObjectConverter
{
	object TypeConverter.ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (!(destinationType == typeof(string)))
		{
			return base.ConvertTo(context, culture, value, destinationType);
		}
		return ((buControlSecurity)value).Enable + " , " + ((buControlSecurity)value).Level;
	}

	bool TypeConverter.CanConvertTo(ITypeDescriptorContext context, Type destinationType)
	{
		if (!(destinationType == typeof(string)))
		{
			return base.CanConvertTo(context, destinationType);
		}
		return true;
	}
}
