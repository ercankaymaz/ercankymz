using System;
using System.ComponentModel;
using System.Globalization;

namespace ComponentFactory.Krypton.Toolkit;

public class ButtonSpecFormFixedConverter : ExpandableObjectConverter
{
	public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
	{
		if (destinationType == typeof(string))
		{
			return true;
		}
		return base.CanConvertTo(context, destinationType);
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (destinationType == typeof(string))
		{
			ButtonSpecFormFixed buttonSpecFormFixed = (ButtonSpecFormFixed)value;
			return buttonSpecFormFixed.ToString();
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}
}
