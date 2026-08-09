using System;
using System.ComponentModel;
using System.Globalization;
using buControls.Controls;

namespace ns39;

internal sealed class Class94 : ExpandableObjectConverter
{
	object TypeConverter.ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (!(destinationType == typeof(string)))
		{
			return base.ConvertTo(context, culture, value, destinationType);
		}
		return ((buControlCaption)value).Visible + " , " + ((buControlCaption)value).Caption.ToString() + " , " + ((buControlCaption)value).Width;
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
