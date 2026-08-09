using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using devDept.Graphics;

namespace devDept.Eyeshot.Control.Converters;

public class DisplayModeSettingsRenderedConverter : DisplayModeSettingsShadedConverter
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
		if (value is DisplayModeSettingsRendered && destinationType == typeof(InstanceDescriptor))
		{
			DisplayModeSettingsRendered displayModeSettingsRendered = (DisplayModeSettingsRendered)value;
			object[] array = new object[13];
			Type[] array2 = new Type[13];
			GetDisplayModeSettingsProperties(array2, array, displayModeSettingsRendered);
			int num = 8;
			array2[num] = typeof(Image);
			array[num++] = displayModeSettingsRendered.EnvironmentMappingImage;
			array2[num] = typeof(bool);
			array[num++] = displayModeSettingsRendered.EnvironmentMapping;
			array2[num] = typeof(bool);
			array[num++] = displayModeSettingsRendered.PlanarReflections;
			array2[num] = typeof(float);
			array[num++] = displayModeSettingsRendered.PlanarReflectionsIntensity;
			array2[num] = typeof(realisticShadowQualityType);
			array[num++] = displayModeSettingsRendered.RealisticShadowQuality;
			return new InstanceDescriptor(value.GetType().GetConstructor(array2), array, isComplete: false);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		return new DisplayModeSettingsRendered((bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647936)], (edgeColorMethodType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647952)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647994)], (float)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648010)], (float)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648022)], (silhouettesDrawingType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648060)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648351)], (shadowType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648373)], (Image)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648388)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648422)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648205)], (float)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648213)], (realisticShadowQualityType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648244)]);
	}
}
