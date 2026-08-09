using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using devDept.Geometry;

namespace devDept.Eyeshot.Control.Converters;

public class RotateConverter : MovementConverterBase
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
		if (value is RotateSettings && destinationType == typeof(InstanceDescriptor))
		{
			RotateSettings rotateSettings = (RotateSettings)value;
			object[] array = new object[8];
			Type[] array2 = new Type[8];
			GetTypesAndProperties((MovementSettingsBase)value, array2, array);
			array2[1] = typeof(double);
			array[1] = rotateSettings.KeysStep;
			int num = 3;
			array2[num] = typeof(double);
			array[num++] = rotateSettings.Speed;
			array2[num] = typeof(rotationType);
			array[num++] = rotateSettings.RotationMode;
			array2[num] = typeof(rotationCenterType);
			array[num++] = rotateSettings.RotationCenter;
			array2[num] = typeof(Point3D);
			array[num++] = rotateSettings.Center;
			array2[num] = typeof(bool);
			array[num] = rotateSettings.ShowCenter;
			return new InstanceDescriptor(typeof(RotateSettings).GetConstructor(array2), array, isComplete: false);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
	{
		return true;
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		return new RotateSettings((MouseButton)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648763)], (double)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589008)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647950)], (double)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648790)], (rotationType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588904)], (rotationCenterType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588917)], (Point3D)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588160)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588179)]);
	}
}
