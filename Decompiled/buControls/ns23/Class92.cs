using System;
using System.ComponentModel;
using System.Globalization;
using buControls.Controls;

namespace ns23;

internal sealed class Class92 : ExpandableObjectConverter
{
	object TypeConverter.ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		string text = ((buControlPathGradient)value).CenterColor.ToString();
		if (((buControlPathGradient)value).CenterColor.IsKnownColor)
		{
			text = ((buControlPathGradient)value).CenterColor.ToKnownColor().ToString();
		}
		string text2 = ((buControlPathGradient)value).SurroundColor.ToString();
		if (((buControlPathGradient)value).SurroundColor.IsKnownColor)
		{
			text2 = ((buControlPathGradient)value).SurroundColor.ToKnownColor().ToString();
		}
		if (!(destinationType == typeof(string)))
		{
			return base.ConvertTo(context, culture, value, destinationType);
		}
		return text + " , " + text2;
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
