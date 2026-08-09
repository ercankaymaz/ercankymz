using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using devDept.Geometry;

namespace devDept.Eyeshot.Control.Converters;

public class GridConverter : ExpandableObjectConverter
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
		if (value is Grid && destinationType == typeof(InstanceDescriptor))
		{
			Grid grid = (Grid)value;
			object[] array = new object[18];
			Type[] array2 = new Type[18];
			int num = 0;
			array2[num] = typeof(Point2D);
			array[num++] = grid.Min;
			array2[num] = typeof(Point2D);
			array[num++] = grid.Max;
			array2[num] = typeof(double);
			array[num++] = grid.Step;
			array2[num] = typeof(Plane);
			array[num++] = grid.Plane;
			array2[num] = typeof(Color);
			array[num++] = grid.LineColor;
			array2[num] = typeof(Color);
			array[num++] = grid.ColorAxisX;
			array2[num] = typeof(Color);
			array[num++] = grid.ColorAxisY;
			array2[num] = typeof(bool);
			array[num++] = grid.AutoSize;
			array2[num] = typeof(bool);
			array[num++] = grid.Visible;
			array2[num] = typeof(bool);
			array[num++] = grid.AlwaysBehind;
			array2[num] = typeof(bool);
			array[num++] = grid.AutoStep;
			array2[num] = typeof(int);
			array[num++] = grid.MinNumberOfLines;
			array2[num] = typeof(int);
			array[num++] = grid.MaxNumberOfLines;
			array2[num] = typeof(int);
			array[num++] = grid.MajorLinesEvery;
			array2[num] = typeof(Color);
			array[num++] = grid.MajorLineColor;
			array2[num] = typeof(Color);
			array[num++] = grid.FillColor;
			array2[num] = typeof(bool);
			array[num++] = grid.Lighting;
			array2[num] = typeof(Color);
			array[num++] = grid.BorderColor;
			return new InstanceDescriptor(typeof(Grid).GetConstructor(array2), array, isComplete: false);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		Grid grid = (Grid)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648279)];
		if (grid == null)
		{
			return new Grid((Point2D)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650891)], (Point2D)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650881)], (double)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648299)], (Plane)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648288)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648308)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647556)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647571)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647586)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650566)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647603)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647616)], (int)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647633)], (int)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647674)], (int)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647427)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647469)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647480)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648159)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647496)]);
		}
		return grid;
	}
}
