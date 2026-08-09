using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using System.Reflection;

namespace devDept.Geometry.Converters;

public class PointConverter : TypeConverter
{
	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		if (!(sourceType == typeof(string)))
		{
			return base.CanConvertFrom(context, sourceType);
		}
		return true;
	}

	public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
	{
		if (!(destinationType == typeof(InstanceDescriptor)))
		{
			return base.CanConvertTo(context, destinationType);
		}
		return true;
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (!(value is string text))
		{
			return base.ConvertFrom(context, culture, value);
		}
		string text2 = text.Trim();
		if (text2.Length == 0)
		{
			return null;
		}
		if (culture == null)
		{
			culture = CultureInfo.CurrentCulture;
		}
		char c = culture.TextInfo.ListSeparator[0];
		string[] array = text2.Split(c);
		int[] array2 = new int[array.Length];
		TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] = (int)converter.ConvertFromString(context, culture, array[i]);
		}
		if (array2.Length != 2)
		{
			throw new ArgumentException(_0023_003Dzl43ZTCXv5lHo_CCNLd8QgHs_003D._0023_003DzCSptaQY_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657622), new object[2]
			{
				text2,
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657586)
			}));
		}
		return new Point(array2[0], array2[1]);
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (destinationType == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657595));
		}
		if (value is Point)
		{
			if (destinationType == typeof(string))
			{
				Point point = (Point)value;
				if (culture == null)
				{
					culture = CultureInfo.CurrentCulture;
				}
				string separator = culture.TextInfo.ListSeparator + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382);
				TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
				string[] array = new string[2];
				string[] array2 = array;
				int num = 0;
				int num2 = num + 1;
				string text = converter.ConvertToString(context, culture, point.X);
				array2[num] = text;
				int num3 = num2;
				string text2 = converter.ConvertToString(context, culture, point.Y);
				array[num3] = text2;
				return string.Join(separator, array);
			}
			if (destinationType == typeof(InstanceDescriptor))
			{
				Point point2 = (Point)value;
				ConstructorInfo constructor = typeof(Point).GetConstructor(new Type[2]
				{
					typeof(int),
					typeof(int)
				});
				if (constructor != null)
				{
					return new InstanceDescriptor(constructor, new object[2] { point2.X, point2.Y });
				}
			}
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		if (propertyValues == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657576));
		}
		object obj = propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981817)];
		object obj2 = propertyValues[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302912525)];
		if (obj == null || obj2 == null || !(obj is int) || !(obj2 is int y))
		{
			throw new ArgumentException(_0023_003Dzl43ZTCXv5lHo_CCNLd8QgHs_003D._0023_003DzCSptaQY_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657553)));
		}
		return new Point((int)obj, y);
	}

	public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
	{
		return true;
	}

	public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
	{
		return TypeDescriptor.GetProperties(typeof(Point), attributes).Sort(new string[2]
		{
			_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981817),
			_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302912525)
		});
	}

	public override bool GetPropertiesSupported(ITypeDescriptorContext context)
	{
		return true;
	}
}
