using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;

namespace devDept.Eyeshot.Control.Converters;

public class SelectionBoxColorsConverter : ExpandableObjectConverter
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
		if (value is SelectionBoxColorsSettings && destinationType == typeof(InstanceDescriptor))
		{
			SelectionBoxColorsSettings selectionBoxColorsSettings = (SelectionBoxColorsSettings)value;
			int num = 4;
			object[] array = new object[num];
			Type[] array2 = new Type[num];
			num = 0;
			array2[num] = typeof(Color);
			array[num++] = selectionBoxColorsSettings.Crossing;
			array2[num] = typeof(Color);
			array[num++] = selectionBoxColorsSettings.Enclosed;
			array2[num] = typeof(Color);
			array[num++] = selectionBoxColorsSettings.Visible;
			array2[num] = typeof(bool);
			array[num++] = selectionBoxColorsSettings.BorderXOR;
			return new InstanceDescriptor(typeof(SelectionBoxColorsSettings).GetConstructor(array2), array);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
	{
		return true;
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		return new SelectionBoxColorsSettings((Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588107)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588124)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650566)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588141)]);
	}
}
