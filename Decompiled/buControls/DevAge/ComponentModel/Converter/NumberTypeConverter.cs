using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using ns27;

namespace DevAge.ComponentModel.Converter;

public class NumberTypeConverter : TypeConverter
{
	private TypeConverter typeConverter_0;

	private Type type_0;

	private string string_0 = "G";

	private NumberStyles numberStyles_0 = NumberStyles.Number;

	public TypeConverter BaseTypeConverter
	{
		get
		{
			return typeConverter_0;
		}
		set
		{
			typeConverter_0 = value;
		}
	}

	public Type BaseType
	{
		get
		{
			return type_0;
		}
		set
		{
			if (value != typeof(double) && value != typeof(float) && value != typeof(decimal) && value != typeof(int))
			{
				throw new ArgumentException("Type not supported", "BaseType");
			}
			typeConverter_0 = TypeDescriptor.GetConverter(value);
			type_0 = value;
		}
	}

	public string Format
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public NumberStyles NumberStyles
	{
		get
		{
			return numberStyles_0;
		}
		set
		{
			numberStyles_0 = value;
		}
	}

	public NumberTypeConverter(Type p_BaseType)
	{
		BaseType = p_BaseType;
	}

	public NumberTypeConverter(Type p_BaseType, string p_Format)
		: this(p_BaseType)
	{
		Format = p_Format;
	}

	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		if (!(sourceType == typeof(string)))
		{
			return typeConverter_0.CanConvertFrom(context, sourceType);
		}
		return true;
	}

	public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
	{
		if (!(destinationType == typeof(string)))
		{
			return typeConverter_0.CanConvertTo(context, destinationType);
		}
		return true;
	}

	public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
	{
		return typeConverter_0.CreateInstance(context, propertyValues);
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (value == null || !(value.GetType() == typeof(string)))
		{
			return typeConverter_0.ConvertFrom(context, culture, value);
		}
		if (!(BaseType == typeof(double)))
		{
			if (!(BaseType == typeof(decimal)))
			{
				if (!(BaseType == typeof(float)))
				{
					if (!(BaseType == typeof(int)))
					{
						throw new ArgumentException("Not supported type");
					}
					return StringToInt((string)value, NumberStyles, Class76.smethod_478(this, culture).NumberFormat);
				}
				return StringToFloat((string)value, NumberStyles, Class76.smethod_478(this, culture).NumberFormat);
			}
			return StringToDecimal((string)value, NumberStyles, Class76.smethod_478(this, culture).NumberFormat);
		}
		return StringToDouble((string)value, NumberStyles, Class76.smethod_478(this, culture).NumberFormat);
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (!(destinationType == typeof(string)) || value == null)
		{
			return typeConverter_0.ConvertTo(context, culture, value, destinationType);
		}
		if (!(BaseType == typeof(double)))
		{
			if (!(BaseType == typeof(decimal)))
			{
				if (!(BaseType == typeof(float)))
				{
					if (!(BaseType == typeof(int)))
					{
						return typeConverter_0.ConvertTo(context, culture, value, destinationType);
					}
					return IntToString((int)value, Format, Class76.smethod_478(this, culture).NumberFormat);
				}
				return FloatToString((float)value, Format, Class76.smethod_478(this, culture).NumberFormat);
			}
			return DecimalToString((decimal)value, Format, Class76.smethod_478(this, culture).NumberFormat);
		}
		return DoubleToString((double)value, Format, Class76.smethod_478(this, culture).NumberFormat);
	}

	public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
	{
		return typeConverter_0.GetCreateInstanceSupported(context);
	}

	public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
	{
		return typeConverter_0.GetProperties(context, value, attributes);
	}

	public override bool GetPropertiesSupported(ITypeDescriptorContext context)
	{
		return typeConverter_0.GetPropertiesSupported(context);
	}

	public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
	{
		return typeConverter_0.GetStandardValues(context);
	}

	public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
	{
		return typeConverter_0.GetStandardValuesExclusive(context);
	}

	public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
	{
		return typeConverter_0.GetStandardValuesSupported(context);
	}

	public override bool IsValid(ITypeDescriptorContext context, object value)
	{
		if (value == null || !(value.GetType() == typeof(string)))
		{
			return typeConverter_0.IsValid(context, value);
		}
		try
		{
			ConvertFrom(context, CultureInfo.CurrentCulture, value);
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public static double StringToDouble(string p_strVal, NumberStyles style, IFormatProvider provider)
	{
		return double.Parse(p_strVal, style, provider);
	}

	public static float StringToFloat(string p_strVal, NumberStyles style, IFormatProvider provider)
	{
		return float.Parse(p_strVal, style, provider);
	}

	public static decimal StringToDecimal(string p_strVal, NumberStyles style, IFormatProvider provider)
	{
		return decimal.Parse(p_strVal, style, provider);
	}

	public static int StringToInt(string p_strVal, NumberStyles style, IFormatProvider provider)
	{
		return int.Parse(p_strVal, style, provider);
	}

	public static string DoubleToString(double p_Val, string format, IFormatProvider provider)
	{
		return p_Val.ToString(format, provider);
	}

	public static string FloatToString(float p_Val, string format, IFormatProvider provider)
	{
		return p_Val.ToString(format, provider);
	}

	public static string DecimalToString(decimal p_Val, string format, IFormatProvider provider)
	{
		return p_Val.ToString(format, provider);
	}

	public static string IntToString(int p_Val, string format, IFormatProvider provider)
	{
		return p_Val.ToString(format, provider);
	}
}
