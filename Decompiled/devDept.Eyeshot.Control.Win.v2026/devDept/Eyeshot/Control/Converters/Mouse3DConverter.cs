using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace devDept.Eyeshot.Control.Converters;

public class Mouse3DConverter : ExpandableObjectConverter
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
		if (value is Mouse3DSettings && destinationType == typeof(InstanceDescriptor))
		{
			Mouse3DSettings mouse3DSettings = (Mouse3DSettings)value;
			object[] array = new object[6];
			Type[] array2 = new Type[6];
			int num = 0;
			array2[num] = typeof(bool);
			array[num++] = mouse3DSettings.Enabled;
			array2[num] = typeof(double);
			array[num++] = mouse3DSettings.SpeedFactor;
			array2[num] = typeof(bool);
			array[num++] = mouse3DSettings.LockHorizon;
			array2[num] = typeof(bool);
			array[num++] = mouse3DSettings.SingleAxisFilter;
			array2[num] = typeof(bool);
			array[num++] = mouse3DSettings.AutoCenterOfRotation;
			array2[num] = typeof(centerOfRotationVisibilityType);
			array[num] = mouse3DSettings.CenterOfRotationVisibilityMode;
			return new InstanceDescriptor(typeof(Mouse3DSettings).GetConstructor(array2), array);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}
}
