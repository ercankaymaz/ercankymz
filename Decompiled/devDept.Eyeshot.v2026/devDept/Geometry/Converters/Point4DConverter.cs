using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace devDept.Geometry.Converters;

public class Point4DConverter : ExpandableObjectConverter
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
				return new Point4D(Utility.DoubleParse(array[0]), Utility.DoubleParse(array[1]), Utility.DoubleParse(array[2]), Utility.DoubleParse(array[3]));
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
		if (value is Point4D)
		{
			if (destinationType == typeof(string))
			{
				Point4D point4D = (Point4D)value;
				return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302988079), point4D.X, point4D.Y, point4D.Z, point4D.W);
			}
			if (destinationType == typeof(InstanceDescriptor))
			{
				Point4D point4D2 = (Point4D)value;
				object[] array = new object[4];
				Type[] array2 = new Type[4]
				{
					typeof(double),
					null,
					null,
					null
				};
				array[0] = point4D2.X;
				array2[1] = typeof(double);
				array[1] = point4D2.Y;
				array2[2] = typeof(double);
				array[2] = point4D2.Z;
				array2[3] = typeof(double);
				array[3] = point4D2.W;
				return new InstanceDescriptor(typeof(Point3D).GetConstructor(array2), array);
			}
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}
}
