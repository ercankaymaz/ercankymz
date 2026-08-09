using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;

namespace devDept.Eyeshot.Control.Converters;

public class ToolBarButtonConverter : ExpandableObjectConverter
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
		if (value is ToolBarButton && destinationType == typeof(InstanceDescriptor))
		{
			ToolBarButton _0023_003DzkGobcLg_003D = (ToolBarButton)value;
			object[] array = new object[8];
			Type[] array2 = new Type[8];
			_0023_003DzPS33JX8_003D(array2, array, _0023_003DzkGobcLg_003D);
			return new InstanceDescriptor(typeof(ToolBarButton).GetConstructor(array2), array, isComplete: false);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	private static int _0023_003DzPS33JX8_003D(Type[] _0023_003Dzy2y_0024Edk_003D, object[] _0023_003DzdZ6CayI_003D, ToolBarButton _0023_003DzkGobcLg_003D)
	{
		int count = 0;
		_0023_003Dzy2y_0024Edk_003D[count] = typeof(Image);
		_0023_003DzdZ6CayI_003D[count++] = _0023_003DzkGobcLg_003D.Image;
		_0023_003Dzy2y_0024Edk_003D[count] = typeof(string);
		_0023_003DzdZ6CayI_003D[count++] = _0023_003DzkGobcLg_003D.Name;
		GetCommonProperties(_0023_003Dzy2y_0024Edk_003D, _0023_003DzdZ6CayI_003D, _0023_003DzkGobcLg_003D, ref count);
		_0023_003Dzy2y_0024Edk_003D[count] = typeof(Image);
		_0023_003DzdZ6CayI_003D[count++] = _0023_003DzkGobcLg_003D.DownImage;
		_0023_003Dzy2y_0024Edk_003D[count] = typeof(Image);
		_0023_003DzdZ6CayI_003D[count++] = _0023_003DzkGobcLg_003D.HoverImage;
		return count;
	}

	protected static void GetCommonProperties(Type[] types, object[] properties, ToolBarButton button, ref int count)
	{
		types[count] = typeof(string);
		properties[count++] = button.ToolTipText;
		types[count] = typeof(ToolBarButton.styleType);
		properties[count++] = button.StyleMode;
		types[count] = typeof(bool);
		properties[count++] = button.Visible;
		types[count] = typeof(bool);
		properties[count++] = button.Enabled;
	}

	public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
	{
		if (context != null && context.Instance is ProgressBar)
		{
			return true;
		}
		return base.GetCreateInstanceSupported(context);
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		return new ToolBarButton((Image)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650751)], (string)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588466)], (string)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648144)], (ToolBarButton.styleType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648190)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650566)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647950)], (Image)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588487)], (Image)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588503)]);
	}
}
