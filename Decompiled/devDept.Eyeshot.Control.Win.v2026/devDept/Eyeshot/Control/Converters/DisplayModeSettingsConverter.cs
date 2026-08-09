using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;

namespace devDept.Eyeshot.Control.Converters;

public class DisplayModeSettingsConverter : ExpandableObjectConverter
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
		if (value is DisplayModeSettings && destinationType == typeof(InstanceDescriptor))
		{
			DisplayModeSettings displayMode = (DisplayModeSettings)value;
			object[] array = new object[7];
			Type[] types = new Type[7];
			GetDisplayModeSettingsProperties(types, array, displayMode);
			return new InstanceDescriptor(value.GetType().GetConstructor(types), array, isComplete: false);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	protected virtual void GetDisplayModeSettingsProperties(Type[] types, object[] properties, DisplayModeSettings displayMode)
	{
		int num = 0;
		types[num] = typeof(bool);
		properties[num++] = displayMode.ShowEdges;
		types[num] = typeof(edgeColorMethodType);
		properties[num++] = displayMode.EdgeColorMethod;
		types[num] = typeof(Color);
		properties[num++] = displayMode.EdgeColor;
		types[num] = typeof(float);
		properties[num++] = displayMode.EdgeThickness;
		types[num] = typeof(float);
		properties[num++] = displayMode.SilhouetteThickness;
		types[num] = typeof(silhouettesDrawingType);
		properties[num++] = displayMode.SilhouettesDrawingMode;
		types[num] = typeof(bool);
		properties[num++] = displayMode.ShowInternalWires;
	}

	public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
	{
		return true;
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		return new DisplayModeSettings((bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647936)], (edgeColorMethodType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647952)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647994)], (float)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648010)], (float)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648022)], (silhouettesDrawingType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648060)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648351)]);
	}
}
