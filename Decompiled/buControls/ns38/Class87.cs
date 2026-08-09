using System;
using System.ComponentModel;
using System.Globalization;
using buControls.Controls;

namespace ns38;

internal sealed class Class87 : ExpandableObjectConverter
{
	object TypeConverter.ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		string text = ((buControlFont)value).ForeColor.ToString();
		if (((buControlFont)value).ForeColor.IsKnownColor)
		{
			text = ((buControlFont)value).ForeColor.ToKnownColor().ToString();
		}
		if (!(destinationType == typeof(string)))
		{
			return base.ConvertTo(context, culture, value, destinationType);
		}
		return ((buControlFont)value).Font.Name + " , " + ((buControlFont)value).Font.Size + " , " + text;
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
