using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace devDept.Geometry.Converters;

public class Vector2DConverter : ExpandableObjectConverter
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
				return new Point2D(Utility.DoubleParse(array[0]), Utility.DoubleParse(array[1]));
			}
			catch
			{
				throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657995));
			}
		}
		return base.ConvertFrom(context, info, value);
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (value is Point2D)
		{
			if (destinationType == typeof(string))
			{
				Vector2D vector2D = (Vector2D)value;
				return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982525), vector2D.X, vector2D.Y);
			}
			if (destinationType == typeof(InstanceDescriptor))
			{
				Vector2D vector2D2 = (Vector2D)value;
				object[] array = new object[2];
				Type[] array2 = new Type[2]
				{
					typeof(double),
					null
				};
				array[0] = vector2D2.X;
				array2[1] = typeof(double);
				array[1] = vector2D2.Y;
				return new InstanceDescriptor(typeof(Vector2D).GetConstructor(array2), array);
			}
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}
}
