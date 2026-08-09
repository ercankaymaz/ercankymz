using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using devDept.Geometry;

namespace devDept.Eyeshot.Control.Converters;

public class ViewCubeConverter : ExpandableObjectConverter
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
		if (value is ViewCubeIcon && destinationType == typeof(InstanceDescriptor))
		{
			ViewCubeIcon viewCubeIcon = (ViewCubeIcon)value;
			object[] array = new object[36];
			Type[] array2 = new Type[36];
			int num = 0;
			array2[num] = typeof(coordinateSystemPositionType);
			array[num++] = viewCubeIcon.Position;
			array2[num] = typeof(bool);
			array[num++] = viewCubeIcon.Visible;
			array2[num] = typeof(Color);
			array[num++] = viewCubeIcon.HighlightColor;
			array2[num] = typeof(bool);
			array[num++] = viewCubeIcon.AnimateCamera;
			array2[num] = typeof(string);
			array[num++] = viewCubeIcon.FrontText;
			array2[num] = typeof(string);
			array[num++] = viewCubeIcon.BackText;
			array2[num] = typeof(string);
			array[num++] = viewCubeIcon.LeftText;
			array2[num] = typeof(string);
			array[num++] = viewCubeIcon.RightText;
			array2[num] = typeof(string);
			array[num++] = viewCubeIcon.TopText;
			array2[num] = typeof(string);
			array[num++] = viewCubeIcon.BottomText;
			array2[num] = typeof(Color);
			array[num++] = viewCubeIcon.FrontColor;
			array2[num] = typeof(Color);
			array[num++] = viewCubeIcon.BackColor;
			array2[num] = typeof(Color);
			array[num++] = viewCubeIcon.LeftColor;
			array2[num] = typeof(Color);
			array[num++] = viewCubeIcon.RightColor;
			array2[num] = typeof(Color);
			array[num++] = viewCubeIcon.TopColor;
			array2[num] = typeof(Color);
			array[num++] = viewCubeIcon.BottomColor;
			array2[num] = typeof(char);
			array[num++] = viewCubeIcon.FrontRingLabel;
			array2[num] = typeof(char);
			array[num++] = viewCubeIcon.BackRingLabel;
			array2[num] = typeof(char);
			array[num++] = viewCubeIcon.LeftRingLabel;
			array2[num] = typeof(char);
			array[num++] = viewCubeIcon.RightRingLabel;
			array2[num] = typeof(bool);
			array[num++] = viewCubeIcon.ShowRing;
			array2[num] = typeof(Font);
			array[num++] = viewCubeIcon.Font;
			array2[num] = typeof(Color);
			array[num++] = viewCubeIcon.TextColor;
			array2[num] = typeof(Color);
			array[num++] = viewCubeIcon.EdgeColor;
			array2[num] = typeof(int);
			array[num++] = viewCubeIcon.Size;
			array2[num] = typeof(bool);
			array[num++] = viewCubeIcon.FitAfterViewChange;
			array2[num] = typeof(bool);
			array[num++] = viewCubeIcon.Enabled;
			array2[num] = typeof(Image);
			array[num++] = viewCubeIcon.FrontImage;
			array2[num] = typeof(Image);
			array[num++] = viewCubeIcon.BackImage;
			array2[num] = typeof(Image);
			array[num++] = viewCubeIcon.LeftImage;
			array2[num] = typeof(Image);
			array[num++] = viewCubeIcon.RightImage;
			array2[num] = typeof(Image);
			array[num++] = viewCubeIcon.TopImage;
			array2[num] = typeof(Image);
			array[num++] = viewCubeIcon.BottomImage;
			array2[num] = typeof(bool);
			array[num++] = viewCubeIcon.Lighting;
			array2[num] = typeof(Quaternion);
			array[num++] = viewCubeIcon.InitialRotation;
			array2[num] = typeof(bool);
			array[num++] = viewCubeIcon.ShowShadow;
			return new InstanceDescriptor(typeof(ViewCubeIcon).GetConstructor(array2), array, isComplete: false);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
	{
		return true;
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		return new ViewCubeIcon((coordinateSystemPositionType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648142)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650566)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650969)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588392)], (string)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588404)], (string)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589700)], (string)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589717)], (string)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589734)], (string)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589750)], (string)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589768)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589783)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589798)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589814)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589574)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650702)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650648)], (char)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589589)], (char)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589600)], (char)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589644)], (char)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589656)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589667)], (Font)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588074)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649093)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647994)], (int)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650958)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589684)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647950)], (Image)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589979)], (Image)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589994)], (Image)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590010)], (Image)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590026)], (Image)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590041)], (Image)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590058)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648159)], (Quaternion)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348590072)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589826)]);
	}
}
