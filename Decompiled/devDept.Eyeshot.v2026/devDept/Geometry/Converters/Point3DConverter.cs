using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace devDept.Geometry.Converters;

public class Point3DConverter : ExpandableObjectConverter
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
				if (array.Length == 3)
				{
					return new Point3D(Utility.DoubleParse(array[0]), Utility.DoubleParse(array[1]), Utility.DoubleParse(array[2]));
				}
				if (array.Length != 6)
				{
					throw new ArgumentException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657958), array.Length));
				}
				return new PointRGB(Utility.DoubleParse(array[0]), Utility.DoubleParse(array[1]), Utility.DoubleParse(array[2]), byte.Parse(array[3]), byte.Parse(array[4]), byte.Parse(array[5]));
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
		if (value is Point3D)
		{
			if (destinationType == typeof(string))
			{
				PointRGB pointRGB = value as PointRGB;
				if (pointRGB != null)
				{
					return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657649), pointRGB.X, pointRGB.Y, pointRGB.Z, pointRGB.R, pointRGB.G, pointRGB.B);
				}
				Point3D point3D = (Point3D)value;
				return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985861), point3D.X, point3D.Y, point3D.Z);
			}
			if (destinationType == typeof(InstanceDescriptor))
			{
				if (value is PointRGB)
				{
					PointRGB pointRGB2 = (PointRGB)value;
					object[] array = new object[6];
					Type[] array2 = new Type[6]
					{
						typeof(double),
						null,
						null,
						null,
						null,
						null
					};
					array[0] = pointRGB2.X;
					array2[1] = typeof(double);
					array[1] = pointRGB2.Y;
					array2[2] = typeof(double);
					array[2] = pointRGB2.Z;
					array2[3] = typeof(byte);
					array[3] = pointRGB2.R;
					array2[4] = typeof(byte);
					array[4] = pointRGB2.G;
					array2[5] = typeof(byte);
					array[5] = pointRGB2.B;
					return new InstanceDescriptor(typeof(PointRGB).GetConstructor(array2), array);
				}
				Point3D point3D2 = (Point3D)value;
				object[] array3 = new object[3];
				Type[] array4 = new Type[3]
				{
					typeof(double),
					null,
					null
				};
				array3[0] = point3D2.X;
				array4[1] = typeof(double);
				array3[1] = point3D2.Y;
				array4[2] = typeof(double);
				array3[2] = point3D2.Z;
				return new InstanceDescriptor(typeof(Point3D).GetConstructor(array4), array3);
			}
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}
}
