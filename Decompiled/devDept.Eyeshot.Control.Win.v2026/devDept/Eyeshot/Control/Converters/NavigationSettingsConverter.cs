using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using devDept.Geometry;

namespace devDept.Eyeshot.Control.Converters;

public class NavigationSettingsConverter : ExpandableObjectConverter
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
		if (value is NavigationSettings && destinationType == typeof(InstanceDescriptor))
		{
			NavigationSettings navigationSettings = (NavigationSettings)value;
			object[] array = new object[7];
			Type[] array2 = new Type[7];
			int num = 0;
			array2[num] = typeof(Camera.navigationType);
			array[num++] = navigationSettings.Mode;
			array2[num] = typeof(MouseButton);
			array[num++] = navigationSettings.MouseButton;
			array2[num] = typeof(Point3D);
			array[num++] = navigationSettings.Min;
			array2[num] = typeof(Point3D);
			array[num++] = navigationSettings.Max;
			array2[num] = typeof(double);
			array[num++] = navigationSettings.Acceleration;
			array2[num] = typeof(double);
			array[num++] = navigationSettings.Speed;
			array2[num] = typeof(double);
			array[num++] = navigationSettings.RotationSpeed;
			return new InstanceDescriptor(typeof(NavigationSettings).GetConstructor(array2), array, isComplete: false);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
	{
		return true;
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		return new NavigationSettings((Camera.navigationType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648742)], (MouseButton)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648763)], (Point3D)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650891)], (Point3D)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650881)], (double)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648777)], (double)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648790)], (double)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648810)]);
	}
}
