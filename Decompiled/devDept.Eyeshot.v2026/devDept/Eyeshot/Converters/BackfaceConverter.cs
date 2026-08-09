using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using devDept.Graphics;

namespace devDept.Eyeshot.Converters;

public class BackfaceConverter : ExpandableObjectConverter
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
		if (value is BackfaceSettings && destinationType == typeof(InstanceDescriptor))
		{
			BackfaceSettings backfaceSettings = (BackfaceSettings)value;
			object[] array = new object[2];
			Type[] array2 = new Type[2]
			{
				typeof(backfaceColorMethodType),
				null
			};
			array[0] = backfaceSettings.ColorMethod;
			array2[1] = typeof(Color);
			array[1] = backfaceSettings.Color;
			return new InstanceDescriptor(typeof(BackfaceSettings).GetConstructor(array2), array);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
	{
		return true;
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		return new BackfaceSettings((backfaceColorMethodType)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953843)], (Color)propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953829)]);
	}
}
