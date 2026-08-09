using System;
using System.ComponentModel;
using System.Globalization;
using buControls.Controls;

namespace ns27;

internal sealed class Class85 : ExpandableObjectConverter
{
	object TypeConverter.ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		string text = ((buControlDisplay)value).BackColor.ToString();
		if (((buControlDisplay)value).BackColor.IsKnownColor)
		{
			text = ((buControlDisplay)value).BackColor.ToKnownColor().ToString();
		}
		if (!(destinationType == typeof(string)))
		{
			return base.ConvertTo(context, culture, value, destinationType);
		}
		return text + " , " + ((buControlDisplay)value).GradientType;
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
