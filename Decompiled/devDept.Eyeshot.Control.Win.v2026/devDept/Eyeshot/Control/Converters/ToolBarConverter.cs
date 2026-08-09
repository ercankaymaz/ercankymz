using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;

namespace devDept.Eyeshot.Control.Converters;

public class ToolBarConverter : ExpandableObjectConverter
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
		if (value is ToolBar && destinationType == typeof(InstanceDescriptor))
		{
			ToolBar toolBar = (ToolBar)value;
			object[] array = new object[9];
			Type[] array2 = new Type[9];
			int num = 0;
			array2[num] = typeof(ToolBar.positionType);
			array[num++] = toolBar.Position;
			array2[num] = typeof(bool);
			array[num++] = toolBar.Visible;
			array2[num] = typeof(ToolBarButton[]);
			array[num++] = toolBar.Buttons.ToArray();
			array2[num] = typeof(int);
			array[num++] = toolBar.Margin;
			array2[num] = typeof(int);
			array[num++] = toolBar.Padding;
			array2[num] = typeof(Color);
			array[num++] = toolBar.BackgroundColor;
			array2[num] = typeof(double);
			array[num++] = toolBar.BackgroundCornerRadius;
			array2[num] = typeof(Color);
			array[num++] = toolBar.BackgroundBorderColor;
			array2[num] = typeof(double);
			array[num++] = toolBar.BackgroundBorderWidth;
			return new InstanceDescriptor(typeof(ToolBar).GetConstructor(array2), array, isComplete: false);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		ToolBar toolBar = (ToolBar)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648279)];
		if (toolBar == null)
		{
			ToolBarButtonList toolBarButtonList = (ToolBarButtonList)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588518)];
			return new ToolBar((ToolBar.positionType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648142)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650566)], toolBarButtonList.ToArray(), (int)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588536)], (int)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588299)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647803)], (double)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588317)], (Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588320)], (double)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588356)]);
		}
		return toolBar;
	}
}
