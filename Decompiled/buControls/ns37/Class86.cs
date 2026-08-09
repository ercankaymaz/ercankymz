using System;
using System.ComponentModel;
using System.Globalization;
using buControls.Controls;

namespace ns37;

internal sealed class Class86 : ExpandableObjectConverter
{
	object TypeConverter.ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		string text = ((buControlBorder)value).Color.ToString();
		if (((buControlBorder)value).Color.IsKnownColor)
		{
			text = ((buControlBorder)value).Color.ToKnownColor().ToString();
		}
		if (!(destinationType == typeof(string)))
		{
			return base.ConvertTo(context, culture, value, destinationType);
		}
		return ((buControlBorder)value).Visible + " , " + text + " , " + ((buControlBorder)value).Thickness;
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
