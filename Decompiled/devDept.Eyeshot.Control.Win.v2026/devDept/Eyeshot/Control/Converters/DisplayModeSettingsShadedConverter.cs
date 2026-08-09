using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using devDept.Graphics;

namespace devDept.Eyeshot.Control.Converters;

public class DisplayModeSettingsShadedConverter : DisplayModeSettingsConverter
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
		if (value is DisplayModeSettingsShaded && destinationType == typeof(InstanceDescriptor))
		{
			DisplayModeSettingsShaded displayMode = (DisplayModeSettingsShaded)value;
			object[] array = new object[8];
			Type[] types = new Type[8];
			GetDisplayModeSettingsProperties(types, array, displayMode);
			return new InstanceDescriptor(value.GetType().GetConstructor(types), array, isComplete: false);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	protected override void GetDisplayModeSettingsProperties(Type[] types, object[] properties, DisplayModeSettings displayMode)
	{
		base.GetDisplayModeSettingsProperties(types, properties, displayMode);
		int num = 7;
		types[num] = typeof(shadowType);
		properties[num] = ((DisplayModeSettingsShaded)displayMode).ShadowMode;
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		return new DisplayModeSettingsShaded((bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647936)], (edgeColorMethodType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647952)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647994)], (float)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648010)], (float)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648022)], (silhouettesDrawingType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648060)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648351)], (shadowType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648373)]);
	}
}
