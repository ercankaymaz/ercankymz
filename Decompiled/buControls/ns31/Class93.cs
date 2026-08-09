using System;
using System.ComponentModel;
using System.Globalization;
using buControls.Controls;

namespace ns31;

internal sealed class Class93 : ExpandableObjectConverter
{
	object TypeConverter.ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		string text = ((buControlInterpolatedGradient)value).FirstColor.ToString();
		if (((buControlInterpolatedGradient)value).FirstColor.IsKnownColor)
		{
			text = ((buControlInterpolatedGradient)value).FirstColor.ToKnownColor().ToString();
		}
		string text2 = ((buControlInterpolatedGradient)value).SecondColor.ToString();
		if (((buControlInterpolatedGradient)value).SecondColor.IsKnownColor)
		{
			text2 = ((buControlInterpolatedGradient)value).SecondColor.ToKnownColor().ToString();
		}
		string text3 = ((buControlInterpolatedGradient)value).ThirdColor.ToString();
		if (((buControlInterpolatedGradient)value).ThirdColor.IsKnownColor)
		{
			text3 = ((buControlInterpolatedGradient)value).ThirdColor.ToKnownColor().ToString();
		}
		string text4 = ((buControlInterpolatedGradient)value).FourthColor.ToString();
		if (((buControlInterpolatedGradient)value).FourthColor.IsKnownColor)
		{
			text4 = ((buControlInterpolatedGradient)value).FourthColor.ToKnownColor().ToString();
		}
		if (!(destinationType == typeof(string)))
		{
			return base.ConvertTo(context, culture, value, destinationType);
		}
		return text + " , " + text2 + " ,  , " + text3 + " , " + text4 + " , " + ((buControlInterpolatedGradient)value).ColorCount;
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
