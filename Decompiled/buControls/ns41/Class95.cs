using System;
using System.ComponentModel;
using System.Globalization;
using buControls.Controls;

namespace ns41;

internal sealed class Class95 : ExpandableObjectConverter
{
	object TypeConverter.ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (!(destinationType == typeof(string)))
		{
			return base.ConvertTo(context, culture, value, destinationType);
		}
		return ((buControlUnit)value).Visible + " , " + ((buControlUnit)value).Caption.ToString() + " , " + ((buControlUnit)value).Width;
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
