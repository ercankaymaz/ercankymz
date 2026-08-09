using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace devDept.Geometry.Converters;

public class Vector3DConverter : ExpandableObjectConverter
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
				return new Vector3D(Utility.DoubleParse(array[0]), Utility.DoubleParse(array[1]), Utility.DoubleParse(array[2]));
			}
			catch
			{
				throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657873));
			}
		}
		return base.ConvertFrom(context, info, value);
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (value is Vector3D)
		{
			if (destinationType == typeof(string))
			{
				Vector3D vector3D = (Vector3D)value;
				return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985861), vector3D.X, vector3D.Y, vector3D.Z);
			}
			if (destinationType == typeof(InstanceDescriptor))
			{
				Vector3D vector3D2 = (Vector3D)value;
				object[] array = new object[3];
				Type[] array2 = new Type[3]
				{
					typeof(double),
					null,
					null
				};
				array[0] = vector3D2.X;
				array2[1] = typeof(double);
				array[1] = vector3D2.Y;
				array2[2] = typeof(double);
				array[2] = vector3D2.Z;
				return new InstanceDescriptor(typeof(Vector3D).GetConstructor(array2), array);
			}
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}
}
