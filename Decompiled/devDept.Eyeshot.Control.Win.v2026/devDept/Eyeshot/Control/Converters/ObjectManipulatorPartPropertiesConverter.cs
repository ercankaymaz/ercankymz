using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;

namespace devDept.Eyeshot.Control.Converters;

public class ObjectManipulatorPartPropertiesConverter : ExpandableObjectConverter
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
		if (value is ObjectManipulatorPartProperties && destinationType == typeof(InstanceDescriptor))
		{
			ObjectManipulatorPartProperties objectManipulatorPartProperties = (ObjectManipulatorPartProperties)value;
			object[] array = new object[3];
			Type[] array2 = new Type[3];
			int num = 0;
			array2[num] = typeof(Color);
			array[num++] = objectManipulatorPartProperties.Color;
			array2[num] = typeof(bool);
			array[num++] = objectManipulatorPartProperties.Visible;
			array2[num] = typeof(bool);
			array[num++] = objectManipulatorPartProperties.Selectable;
			return new InstanceDescriptor(typeof(ObjectManipulatorPartProperties).GetConstructor(array2), array, isComplete: false);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
	{
		return true;
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		return new ObjectManipulatorPartProperties((Color)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650533)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650566)], (bool)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588978)]);
	}
}
