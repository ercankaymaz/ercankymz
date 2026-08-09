using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;

namespace devDept.Eyeshot.Control.Converters;

public class HiddenLinesConverter : DisplayModeSettingsConverter
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
		if (value is HiddenLinesSettings && destinationType == typeof(InstanceDescriptor))
		{
			HiddenLinesSettings hiddenLinesSettings = (HiddenLinesSettings)value;
			object[] array = new object[18];
			Type[] array2 = new Type[18];
			int num = 0;
			array2[num] = typeof(bool);
			array[num++] = hiddenLinesSettings.Lighting;
			array2[num] = typeof(hiddenLinesColorMethodType);
			array[num++] = hiddenLinesSettings.ColorMethod;
			array2[num] = typeof(bool);
			array[num++] = hiddenLinesSettings.ShowEdges;
			array2[num] = typeof(edgeColorMethodType);
			array[num++] = hiddenLinesSettings.EdgeColorMethod;
			array2[num] = typeof(float);
			array[num++] = hiddenLinesSettings.SilhouetteThickness;
			array2[num] = typeof(float);
			array[num++] = hiddenLinesSettings.EdgeThickness;
			array2[num] = typeof(float);
			array[num++] = hiddenLinesSettings.WireThickness;
			array2[num] = typeof(float);
			array[num++] = hiddenLinesSettings.DashedHiddenLinesThickness;
			array2[num] = typeof(bool);
			array[num++] = hiddenLinesSettings.DashedHiddenLines;
			array2[num] = typeof(silhouettesDrawingType);
			array[num++] = hiddenLinesSettings.SilhouettesDrawingMode;
			array2[num] = typeof(bool);
			array[num++] = hiddenLinesSettings.ShowInternalWires;
			array2[num] = typeof(Color);
			array[num++] = hiddenLinesSettings.SilhouetteColor;
			array2[num] = typeof(Color);
			array[num++] = hiddenLinesSettings.EdgeColor;
			array2[num] = typeof(Color);
			array[num++] = hiddenLinesSettings.WireColor;
			array2[num] = typeof(Color);
			array[num++] = hiddenLinesSettings.DashedHiddenLinesColor;
			array2[num] = typeof(ushort);
			array[num++] = hiddenLinesSettings.DashedHiddenLinesPattern;
			array2[num] = typeof(edgeColorMethodType);
			array[num++] = hiddenLinesSettings.WireColorMethod;
			array2[num] = typeof(Color);
			array[num++] = hiddenLinesSettings.PolygonColor;
			return new InstanceDescriptor(value.GetType().GetConstructor(array2), array, isComplete: false);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		return new HiddenLinesSettings((bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648159)], (hiddenLinesColorMethodType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648359)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647936)], (edgeColorMethodType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647952)], (float)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648022)], (float)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648010)], (float)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647510)], (float)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647522)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647809)], (silhouettesDrawingType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648060)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648351)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647849)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647994)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647859)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647875)], (ushort)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647910)], (edgeColorMethodType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647687)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647697)]);
	}
}
