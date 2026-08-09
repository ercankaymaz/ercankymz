using System;
using System.ComponentModel;
using System.Globalization;
using buControls.Controls;

namespace ns39;

internal sealed class Class88 : ExpandableObjectConverter
{
	object TypeConverter.ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		string text = ((buControlSeparator)value).Color.ToString();
		if (((buControlSeparator)value).Color.IsKnownColor)
		{
			text = ((buControlSeparator)value).Color.ToKnownColor().ToString();
		}
		if (!(destinationType == typeof(string)))
		{
			return base.ConvertTo(context, culture, value, destinationType);
		}
		return ((buControlSeparator)value).Visible + " , " + text + " , " + ((buControlSeparator)value).Thickness;
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
