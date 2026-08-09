using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using devDept.Geometry;

namespace devDept.Eyeshot.Control.Converters;

public class CoordinateSystemIconConverter : ExpandableObjectConverter
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
		if (value is CoordinateSystemIcon && destinationType == typeof(InstanceDescriptor))
		{
			CoordinateSystemIcon coordinateSystemIcon = (CoordinateSystemIcon)value;
			object[] array = new object[17];
			Type[] array2 = new Type[17]
			{
				typeof(Font),
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null
			};
			array[0] = coordinateSystemIcon.LabelFont;
			GetTypesAndProperties(coordinateSystemIcon, 1, array2, array);
			int num = 13;
			array2[num] = typeof(coordinateSystemPositionType);
			array[num++] = coordinateSystemIcon.Position;
			array2[num] = typeof(int);
			array[num++] = coordinateSystemIcon.Size;
			array2[num] = typeof(Transformation);
			array[num++] = coordinateSystemIcon.Transformation;
			array2[num] = typeof(bool);
			array[num++] = coordinateSystemIcon.Lighting;
			return new InstanceDescriptor(typeof(CoordinateSystemIcon).GetConstructor(array2), array, isComplete: false);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	protected static void GetTypesAndProperties(CoordinateSystemBase originSymbol, int startIndex, Type[] types, object[] properties)
	{
		int num = startIndex;
		types[num] = typeof(Color);
		properties[num++] = originSymbol.LabelColorName;
		types[num] = typeof(Color);
		properties[num++] = originSymbol.LabelColorX;
		types[num] = typeof(Color);
		properties[num++] = originSymbol.LabelColorY;
		types[num] = typeof(Color);
		properties[num++] = originSymbol.LabelColorZ;
		types[num] = typeof(Color);
		properties[num++] = originSymbol.ArrowColorX;
		types[num] = typeof(Color);
		properties[num++] = originSymbol.ArrowColorY;
		types[num] = typeof(Color);
		properties[num++] = originSymbol.ArrowColorZ;
		types[num] = typeof(string);
		properties[num++] = originSymbol.LabelOrigin;
		types[num] = typeof(string);
		properties[num++] = originSymbol.LabelAxisX;
		types[num] = typeof(string);
		properties[num++] = originSymbol.LabelAxisY;
		types[num] = typeof(string);
		properties[num++] = originSymbol.LabelAxisZ;
		types[num] = typeof(bool);
		properties[num++] = originSymbol.Visible;
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		return new CoordinateSystemIcon((Font)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650980)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650996)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650783)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650797)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650811)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650825)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650839)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650853)], (string)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650867)], (string)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648065)], (string)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648080)], (string)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648127)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650566)], (coordinateSystemPositionType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648142)], (int)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650958)], null, (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648159)])
		{
			LabelFont = (Font)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650980)]
		};
	}
}
