using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using devDept.Geometry;

namespace devDept.Eyeshot.Control.Converters;

public class BoundingBoxConverter : ExpandableObjectConverter
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
		if (value is BoundingBoxSettings && destinationType == typeof(InstanceDescriptor))
		{
			BoundingBoxSettings boundingBoxSettings = (BoundingBoxSettings)value;
			object[] array = new object[6];
			Type[] array2 = new Type[6];
			int num = 0;
			array2[num] = typeof(ushort);
			array[num++] = boundingBoxSettings.LinePattern;
			array2[num] = typeof(bool);
			array[num++] = boundingBoxSettings.Visible;
			array2[num] = typeof(bool);
			array[num++] = boundingBoxSettings.OverrideSceneExtents;
			array2[num] = typeof(Point3D);
			array[num++] = boundingBoxSettings.Min;
			array2[num] = typeof(Point3D);
			array[num++] = boundingBoxSettings.Max;
			array2[num] = typeof(string);
			array[num++] = boundingBoxSettings.NotApplicableText;
			return new InstanceDescriptor(typeof(BoundingBoxSettings).GetConstructor(array2), array, isComplete: false);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
	{
		return true;
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		return new BoundingBoxSettings((ushort)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650584)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650566)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650598)], (Point3D)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650891)], (Point3D)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650881)], (string)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650903)], (string)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650918)]);
	}
}
