using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace devDept.Eyeshot.Control.Converters;

public class DefaultToolBarButtonConverter<T> : ToolBarButtonConverter where T : DefaultToolBarButton, new()
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
		if (value is T && destinationType == typeof(InstanceDescriptor))
		{
			T button = (T)value;
			object[] array = new object[4];
			Type[] types = new Type[4];
			int count = 0;
			ToolBarButtonConverter.GetCommonProperties(types, array, button, ref count);
			return new InstanceDescriptor(typeof(T).GetConstructor(types), array, isComplete: false);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		return new T
		{
			ToolTipText = (string)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648144)],
			StyleMode = (ToolBarButton.styleType)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648190)],
			Visible = (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650566)],
			Enabled = (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647950)]
		};
	}
}
