using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;

namespace devDept.Eyeshot.Control.Converters;

public class DisplayModeSettingsFlatConverter : DisplayModeSettingsConverter
{
	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (value is DisplayModeSettingsFlat && destinationType == typeof(InstanceDescriptor))
		{
			DisplayModeSettingsFlat displayModeSettingsFlat = (DisplayModeSettingsFlat)value;
			object[] array = new object[8];
			Type[] array2 = new Type[8];
			GetDisplayModeSettingsProperties(array2, array, displayModeSettingsFlat);
			int num = 7;
			array2[num] = typeof(flatColorMethodType);
			array[num++] = displayModeSettingsFlat.ColorMethod;
			return new InstanceDescriptor(value.GetType().GetConstructor(array2), array, isComplete: false);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		return new DisplayModeSettingsFlat((bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647936)], (edgeColorMethodType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647952)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647994)], (float)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648010)], (float)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648022)], (silhouettesDrawingType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648060)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648351)], (flatColorMethodType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648359)]);
	}
}
