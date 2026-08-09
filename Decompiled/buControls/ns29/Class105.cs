using System;
using System.ComponentModel;
using System.Globalization;
using buControls.Controls;

namespace ns29;

internal sealed class Class105 : ExpandableObjectConverter
{
	object TypeConverter.ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		string text = ((buControlProgressBarCircular)value).ProgressColor1.ToKnownColor().ToString();
		string text2 = ((buControlProgressBarCircular)value).ProgressColor2.ToKnownColor().ToString();
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
