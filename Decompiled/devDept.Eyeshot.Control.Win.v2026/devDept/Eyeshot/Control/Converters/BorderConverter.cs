using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;

namespace devDept.Eyeshot.Control.Converters;

public class BorderConverter : ExpandableObjectConverter
{
	public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
	{
		if (destinationType == typeof(InstanceDescriptor))
		{
			return true;
		}
		return base.CanConvertTo(context, destinationType);
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (value is BorderSettings && destinationType == typeof(InstanceDescriptor))
		{
			BorderSettings borderSettings = (BorderSettings)value;
			object[] array = new object[3];
			Type[] array2 = new Type[3]
			{
				typeof(Color),
				null,
				null
			};
			array[0] = borderSettings.Color;
			array2[1] = typeof(int);
			array[1] = borderSettings.CornerRadius;
			array2[2] = typeof(bool);
			array[2] = borderSettings.Visible;
			return new InstanceDescriptor(typeof(BorderSettings).GetConstructor(array2), array);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
	{
		return true;
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		return new BorderSettings((Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650533)], (int)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650553)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650566)]);
	}
}
