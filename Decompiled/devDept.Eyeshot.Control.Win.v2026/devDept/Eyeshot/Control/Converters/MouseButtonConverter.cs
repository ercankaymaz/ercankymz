using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace devDept.Eyeshot.Control.Converters;

public class MouseButtonConverter : ExpandableObjectConverter
{
	public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
	{
		if (destinationType == typeof(string))
		{
			return true;
		}
		if (destinationType == typeof(InstanceDescriptor))
		{
			return true;
		}
		return base.CanConvertTo(context, destinationType);
	}

	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		if (sourceType == typeof(string))
		{
			return true;
		}
		return base.CanConvertFrom(context, sourceType);
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo info, object value)
	{
		if (value is string)
		{
			try
			{
				string[] array = ((string)value).Split(',');
				return new MouseButton((mouseButtonsZPR)Enum.Parse(typeof(mouseButtonsZPR), array[0]), (modifierKeys)Enum.Parse(typeof(modifierKeys), array[1]));
			}
			catch
			{
				throw new ArgumentException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648936));
			}
		}
		return base.ConvertFrom(context, info, value);
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (value is MouseButton)
		{
			if (destinationType == typeof(string))
			{
				return ((MouseButton)value/*cast due to constrained. prefix*/).ToString();
			}
			if (destinationType == typeof(InstanceDescriptor))
			{
				MouseButton mouseButton = (MouseButton)value;
				object[] array = new object[2];
				Type[] array2 = new Type[2]
				{
					typeof(mouseButtonsZPR),
					null
				};
				array[0] = mouseButton.Button;
				array2[1] = typeof(modifierKeys);
				array[1] = mouseButton.ModifierKey;
				return new InstanceDescriptor(typeof(MouseButton).GetConstructor(array2), array);
			}
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		return new MouseButton((mouseButtonsZPR)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648709)], (modifierKeys)propertyValues[_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348648728)]);
	}
}
