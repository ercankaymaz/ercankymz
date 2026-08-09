using System;
using System.ComponentModel;
using System.Globalization;
using buControls.Controls;

namespace ns40;

internal sealed class Class90 : ExpandableObjectConverter
{
	object TypeConverter.ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (!(destinationType == typeof(string)))
		{
			return base.ConvertTo(context, culture, value, destinationType);
		}
		return ((buControlMotion)value).Address.ToString() + " , " + ((buControlMotion)value).Value + " , " + ((buControlMotion)value).AxisIndex + " , " + ((buControlMotion)value).Aux + " , " + ((buControlMotion)value).Note;
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
