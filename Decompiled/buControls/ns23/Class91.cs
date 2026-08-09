using System;
using System.ComponentModel;
using System.Globalization;
using buControls.Controls;

namespace ns23;

internal sealed class Class91 : ExpandableObjectConverter
{
	object TypeConverter.ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		string text = ((buControlLineerGradient)value).FirstColor.ToString();
		if (((buControlLineerGradient)value).FirstColor.IsKnownColor)
		{
			text = ((buControlLineerGradient)value).FirstColor.ToKnownColor().ToString();
		}
		string text2 = ((buControlLineerGradient)value).SecondColor.ToString();
		if (((buControlLineerGradient)value).SecondColor.IsKnownColor)
		{
			text2 = ((buControlLineerGradient)value).SecondColor.ToKnownColor().ToString();
		}
		if (!(destinationType == typeof(string)))
		{
			return base.ConvertTo(context, culture, value, destinationType);
		}
		return text + " , " + text2 + " , " + ((buControlLineerGradient)value).GradientAngle;
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
