using System;
using System.ComponentModel;
using System.Globalization;
using buControls.Controls;

namespace ns23;

internal sealed class Class106 : ExpandableObjectConverter
{
	object TypeConverter.ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (!(destinationType == typeof(string)))
		{
			return base.ConvertTo(context, culture, value, destinationType);
		}
		return ((buControlProgressBarLineer)value).DoneDisplay.BackColor.ToKnownColor().ToString() + " , " + ((buControlProgressBarLineer)value).ShowPercentage;
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
