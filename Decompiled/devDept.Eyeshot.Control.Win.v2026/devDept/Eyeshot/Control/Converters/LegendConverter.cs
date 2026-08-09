using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;

namespace devDept.Eyeshot.Control.Converters;

public class LegendConverter : ExpandableObjectConverter
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
		if (value is Legend && destinationType == typeof(InstanceDescriptor))
		{
			Legend legend = (Legend)value;
			object[] array = new object[19];
			Type[] array2 = new Type[19];
			int num = 0;
			array2[num] = typeof(double);
			array[num++] = legend.Min;
			array2[num] = typeof(double);
			array[num++] = legend.Max;
			array2[num] = typeof(string);
			array[num++] = legend.Title;
			array2[num] = typeof(string);
			array[num++] = legend.Subtitle;
			array2[num] = typeof(bool);
			array[num++] = legend.Slave;
			array2[num] = typeof(bool);
			array[num++] = legend.Visible;
			array2[num] = typeof(bool);
			array[num++] = legend.AlignValuesRight;
			array2[num] = typeof(string);
			array[num++] = legend.FormatString;
			array2[num] = typeof(Color);
			array[num++] = legend.TextBackgroundColor;
			array2[num] = typeof(Color);
			array[num++] = legend.TitleColor;
			array2[num] = typeof(Color);
			array[num++] = legend.TextColor;
			array2[num] = typeof(Font);
			array[num++] = legend.TitleFont;
			array2[num] = typeof(Font);
			array[num++] = legend.TextFont;
			array2[num] = typeof(LegendItem[]);
			array[num++] = legend.Items;
			array2[num] = typeof(bool);
			array[num++] = legend.Lighting;
			array2[num] = typeof(bool);
			array[num++] = legend.AlignValuesVerticalMiddle;
			array2[num] = typeof(bool);
			array[num++] = legend.Tapered;
			array2[num] = typeof(int);
			array[num++] = legend.Gap;
			array2[num] = typeof(Legend.positionType);
			array[num++] = legend.PositionMode;
			return new InstanceDescriptor(typeof(Legend).GetConstructor(array2), array, isComplete: false);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		Legend legend = (Legend)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648279)];
		if (legend == null)
		{
			legend = new Legend((double)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650891)], (double)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650881)], (string)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647769)], (string)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649177)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649194)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650566)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649214)], (string)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649164)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648967)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649005)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649093)], (Font)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649020)], (Font)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649036)], (LegendItem[])propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649053)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648159)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649041)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649073)], (int)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650947)], (Legend.positionType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649347)]);
		}
		return legend;
	}
}
