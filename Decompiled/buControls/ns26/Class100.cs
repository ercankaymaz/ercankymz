using System;
using System.ComponentModel;
using System.Globalization;
using buControls.Controls;

namespace ns26;

internal sealed class Class100 : ExpandableObjectConverter
{
	object TypeConverter.ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (!(destinationType == typeof(string)))
		{
			return base.ConvertTo(context, culture, value, destinationType);
		}
		return ((buControlStatus)value).InformationText.ToString() + " , " + ((buControlStatus)value).WarningText.ToString() + " , " + ((buControlStatus)value).AlarmText.ToString();
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
