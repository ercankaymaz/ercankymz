using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace devDept.Eyeshot.Control.Converters;

public class MultiTouchConverter : ExpandableObjectConverter
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
		if (value is MultiTouchSettings && destinationType == typeof(InstanceDescriptor))
		{
			MultiTouchSettings multiTouchSettings = (MultiTouchSettings)value;
			object[] array = new object[4];
			Type[] array2 = new Type[4];
			int num = 0;
			array2[num] = typeof(bool);
			array[num++] = multiTouchSettings.Enabled;
			array2[num] = typeof(bool);
			array[num++] = multiTouchSettings.Zoom;
			array2[num] = typeof(bool);
			array[num++] = multiTouchSettings.Pan;
			array2[num] = typeof(bool);
			array[num++] = multiTouchSettings.Rotate;
			return new InstanceDescriptor(typeof(MultiTouchSettings).GetConstructor(array2), array);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}
}
