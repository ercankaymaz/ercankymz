using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using devDept.Eyeshot;

namespace devDept.Geometry.Converters;

public class QuaternionConverter : ExpandableObjectConverter
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
			if (TryGetViewType(value.ToString(), out var result))
			{
				return Camera.GetViewRotation(result);
			}
			try
			{
				string[] array = ((string)value).Split(',');
				return new Quaternion(Utility.DoubleParse(array[0]), Utility.DoubleParse(array[1]), Utility.DoubleParse(array[2]), Utility.DoubleParse(array[3]));
			}
			catch
			{
				throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657873));
			}
		}
		return base.ConvertFrom(context, info, value);
	}

	public static bool TryGetViewType(string value, out viewType result)
	{
		return Enum.TryParse<viewType>(value, ignoreCase: true, out result);
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (value is Quaternion)
		{
			if (destinationType == typeof(string))
			{
				if (TryGetViewType(value.ToString(), out var _))
				{
					return value;
				}
				Quaternion quaternion = (Quaternion)value;
				return string.Format(CultureInfo.InvariantCulture, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988079), quaternion.X, quaternion.Y, quaternion.Z, quaternion.W);
			}
			if (destinationType == typeof(InstanceDescriptor))
			{
				Quaternion quaternion2 = (Quaternion)value;
				object[] array = new object[4];
				Type[] array2 = new Type[4]
				{
					typeof(double),
					null,
					null,
					null
				};
				array[0] = quaternion2.X;
				array2[1] = typeof(double);
				array[1] = quaternion2.Y;
				array2[2] = typeof(double);
				array[2] = quaternion2.Z;
				array2[3] = typeof(double);
				array[3] = quaternion2.W;
				return new InstanceDescriptor(typeof(Quaternion).GetConstructor(array2), array);
			}
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}
}
