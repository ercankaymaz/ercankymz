using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;

namespace devDept.Eyeshot.Control;

public class LegendItemConverter : ExpandableObjectConverter
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
		if (value is LegendItem && destinationType == typeof(InstanceDescriptor))
		{
			LegendItem legendItem = (LegendItem)value;
			object[] array = new object[3];
			Type[] array2 = new Type[3]
			{
				typeof(int),
				null,
				null
			};
			array[0] = legendItem.Width;
			array2[1] = typeof(int);
			array[1] = legendItem.Height;
			array2[2] = typeof(Color);
			array[2] = legendItem.Color;
			return new InstanceDescriptor(typeof(LegendItem).GetConstructor(array2), array, isComplete: false);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
	{
		if (context != null && context.Instance is Legend)
		{
			return true;
		}
		return base.GetCreateInstanceSupported(context);
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		LegendItem legendItem = (LegendItem)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648279)];
		if (legendItem == null)
		{
			legendItem = new LegendItem((int)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348586512)], (int)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348586532)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650533)]);
		}
		return legendItem;
	}
}
