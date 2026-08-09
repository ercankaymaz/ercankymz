using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;

namespace devDept.Eyeshot.Control.Converters;

public class ObjectManipulatorConverter : ExpandableObjectConverter
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
		if (value is ObjectManipulator && destinationType == typeof(InstanceDescriptor))
		{
			ObjectManipulator objectManipulator = (ObjectManipulator)value;
			object[] array = new object[22];
			Type[] array2 = new Type[22];
			int num = 0;
			array2[num] = typeof(int);
			array[num++] = objectManipulator.Size;
			array2[num] = typeof(bool);
			array[num++] = objectManipulator.Visible;
			array2[num] = typeof(bool);
			array[num++] = objectManipulator.ShowOriginalWhileEditing;
			array2[num] = typeof(ObjectManipulator.styleType);
			array[num++] = objectManipulator.StyleMode;
			array2[num] = typeof(ObjectManipulator.ballActionType);
			array[num++] = objectManipulator.BallActionMode;
			array2[num] = typeof(ObjectManipulatorPartProperties);
			array[num++] = objectManipulator.Ball;
			array2[num] = typeof(ObjectManipulatorPartProperties);
			array[num++] = objectManipulator.TranslateX;
			array2[num] = typeof(ObjectManipulatorPartProperties);
			array[num++] = objectManipulator.TranslateY;
			array2[num] = typeof(ObjectManipulatorPartProperties);
			array[num++] = objectManipulator.TranslateZ;
			array2[num] = typeof(ObjectManipulatorPartProperties);
			array[num++] = objectManipulator.RotateX;
			array2[num] = typeof(ObjectManipulatorPartProperties);
			array[num++] = objectManipulator.RotateY;
			array2[num] = typeof(ObjectManipulatorPartProperties);
			array[num++] = objectManipulator.RotateZ;
			array2[num] = typeof(ObjectManipulatorPartProperties);
			array[num++] = objectManipulator.ScaleX;
			array2[num] = typeof(ObjectManipulatorPartProperties);
			array[num++] = objectManipulator.ScaleY;
			array2[num] = typeof(ObjectManipulatorPartProperties);
			array[num++] = objectManipulator.ScaleZ;
			array2[num] = typeof(double);
			array[num++] = objectManipulator.RotationStep;
			array2[num] = typeof(double);
			array[num++] = objectManipulator.TranslationStep;
			array2[num] = typeof(double);
			array[num++] = objectManipulator.ScalingStep;
			array2[num] = typeof(Color);
			array[num++] = objectManipulator.TransformationLabelFillColor;
			array2[num] = typeof(Color);
			array[num++] = objectManipulator.TransformationLabelTextColor;
			array2[num] = typeof(Font);
			array[num++] = objectManipulator.LabelFont;
			array2[num] = typeof(bool);
			array[num++] = objectManipulator.Lighting;
			return new InstanceDescriptor(typeof(ObjectManipulator).GetConstructor(array2), array, isComplete: false);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
	{
		return true;
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		return new ObjectManipulator((int)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650958)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650566)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648822)], (ObjectManipulator.styleType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650632)], (ObjectManipulator.ballActionType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588695)], (ObjectManipulatorPartProperties)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588706)], (ObjectManipulatorPartProperties)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588727)], (ObjectManipulatorPartProperties)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588742)], (ObjectManipulatorPartProperties)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588757)], (ObjectManipulatorPartProperties)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588772)], (ObjectManipulatorPartProperties)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588790)], (ObjectManipulatorPartProperties)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588552)], (ObjectManipulatorPartProperties)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588570)], (ObjectManipulatorPartProperties)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588589)], (ObjectManipulatorPartProperties)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588576)], (double)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588595)], (double)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588608)], (double)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588650)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588664)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588949)], (Font)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650980)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648159)]);
	}
}
