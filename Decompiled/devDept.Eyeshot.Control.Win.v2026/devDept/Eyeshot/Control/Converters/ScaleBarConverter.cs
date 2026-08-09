using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using devDept.Geometry;

namespace devDept.Eyeshot.Control.Converters;

public class ScaleBarConverter : ExpandableObjectConverter
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
		if (value is ScaleBar && destinationType == typeof(InstanceDescriptor))
		{
			ScaleBar scaleBar = (ScaleBar)value;
			object[] array = new object[13];
			Type[] array2 = new Type[13];
			int num = 0;
			array2[num] = typeof(bool);
			array[num++] = scaleBar.Visible;
			array2[num] = typeof(Color);
			array[num++] = scaleBar.BackgroundColor1;
			array2[num] = typeof(Color);
			array[num++] = scaleBar.BackgroundColor2;
			array2[num] = typeof(Color);
			array[num++] = scaleBar.TextColor;
			array2[num] = typeof(string);
			array[num++] = scaleBar.FormatString;
			array2[num] = typeof(bool);
			array[num++] = scaleBar.Lighting;
			array2[num] = typeof(ScaleBar.styleType);
			array[num++] = scaleBar.StyleMode;
			array2[num] = typeof(int);
			array[num++] = scaleBar.MaxNumberOfBars;
			array2[num] = typeof(int);
			array[num++] = scaleBar.BarsHeight;
			array2[num] = typeof(double);
			array[num++] = scaleBar.MaxWidth;
			array2[num] = typeof(ScaleBar.positionType);
			array[num++] = scaleBar.Position;
			array2[num] = typeof(Font);
			array[num++] = scaleBar.Font;
			array2[num] = typeof(linearUnitsType?);
			array[num++] = scaleBar.UnitsOverride;
			return new InstanceDescriptor(typeof(ScaleBar).GetConstructor(array2), array, isComplete: false);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		ScaleBar scaleBar = (ScaleBar)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648279)];
		if (scaleBar == null)
		{
			scaleBar = new ScaleBar((bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650566)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588238)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588247)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649093)], (string)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649164)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648159)], (ScaleBar.styleType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650632)], (int)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588256)], (int)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588042)], (double)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588057)], (ScaleBar.positionType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648142)], (Font)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588074)], (linearUnitsType?)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588095)]);
		}
		return scaleBar;
	}
}
