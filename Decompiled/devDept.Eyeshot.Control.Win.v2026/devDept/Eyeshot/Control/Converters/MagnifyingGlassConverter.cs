using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;

namespace devDept.Eyeshot.Control.Converters;

public class MagnifyingGlassConverter : ExpandableObjectConverter
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
		if (value is MagnifyingGlassSettings && destinationType == typeof(InstanceDescriptor))
		{
			MagnifyingGlassSettings magnifyingGlassSettings = (MagnifyingGlassSettings)value;
			int num = 4;
			object[] array = new object[num];
			Type[] array2 = new Type[num];
			num = 0;
			array2[num] = typeof(Size);
			array[num++] = magnifyingGlassSettings.Size;
			array2[num] = typeof(double);
			array[num++] = magnifyingGlassSettings.Factor;
			array2[num] = typeof(bool);
			array[num++] = magnifyingGlassSettings.ScaleLineWeight;
			array2[num] = typeof(Point);
			array[num++] = magnifyingGlassSettings.Offset;
			return new InstanceDescriptor(typeof(MagnifyingGlassSettings).GetConstructor(array2), array);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
	{
		return true;
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		return new MagnifyingGlassSettings((Size)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650958)], (double)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649360)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649379)], (Point)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649421)]);
	}
}
