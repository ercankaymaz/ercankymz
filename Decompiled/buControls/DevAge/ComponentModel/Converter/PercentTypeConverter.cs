using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using ns27;

namespace DevAge.ComponentModel.Converter;

public class PercentTypeConverter : TypeConverter
{
	private TypeConverter typeConverter_0;

	private Type type_0;

	private string string_0 = "P";

	private bool bool_0 = true;

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
			if (value != typeof(double) && value != typeof(float) && value != typeof(decimal))
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

	public bool ConsiderAllStringAsPercent
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
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

	public PercentTypeConverter(Type p_BaseType)
	{
		BaseType = p_BaseType;
	}

	public PercentTypeConverter(Type p_BaseType, string p_Format)
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
					throw new ArgumentException("Not supported type");
				}
				return StringToFloat((string)value, NumberStyles, Class76.smethod_22(culture, this).NumberFormat, ConsiderAllStringAsPercent);
			}
			return StringToDecimal((string)value, NumberStyles, Class76.smethod_22(culture, this).NumberFormat, ConsiderAllStringAsPercent);
		}
		return StringToDouble((string)value, NumberStyles, Class76.smethod_22(culture, this).NumberFormat, ConsiderAllStringAsPercent);
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
					return typeConverter_0.ConvertTo(context, culture, value, destinationType);
				}
				return FloatToString((float)value, Format, Class76.smethod_22(culture, this).NumberFormat);
			}
			return DecimalToString((decimal)value, Format, Class76.smethod_22(culture, this).NumberFormat);
		}
		return DoubleToString((double)value, Format, Class76.smethod_22(culture, this).NumberFormat);
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

	public static bool IsPercentString(string p_strVal, IFormatProvider provider)
	{
		NumberFormatInfo numberFormatInfo = ((provider == null) ? CultureInfo.CurrentCulture.NumberFormat : ((NumberFormatInfo)provider.GetFormat(typeof(NumberFormatInfo))));
		if (p_strVal.IndexOf(numberFormatInfo.PercentSymbol) != -1)
		{
			return true;
		}
		return false;
	}

	public static double StringToDouble(string p_strVal, NumberStyles style, IFormatProvider provider, bool p_ConsiderAllStringAsPercent)
	{
		if (!IsPercentString(p_strVal, provider))
		{
			if (!p_ConsiderAllStringAsPercent)
			{
				return double.Parse(p_strVal, style, provider);
			}
			return double.Parse(p_strVal, style, provider) / 100.0;
		}
		return double.Parse(p_strVal.Replace("%", ""), style, provider) / 100.0;
	}

	public static float StringToFloat(string p_strVal, NumberStyles style, IFormatProvider provider, bool p_ConsiderAllStringAsPercent)
	{
		if (!IsPercentString(p_strVal, provider))
		{
			if (!p_ConsiderAllStringAsPercent)
			{
				return float.Parse(p_strVal, style, provider);
			}
			return float.Parse(p_strVal, style, provider) / 100f;
		}
		return float.Parse(p_strVal.Replace("%", ""), style, provider) / 100f;
	}

	public static decimal StringToDecimal(string p_strVal, NumberStyles style, IFormatProvider provider, bool p_ConsiderAllStringAsPercent)
	{
		if (!IsPercentString(p_strVal, provider))
		{
			if (!p_ConsiderAllStringAsPercent)
			{
				return decimal.Parse(p_strVal, style, provider);
			}
			return decimal.Parse(p_strVal, style, provider) / 100.0m;
		}
		return decimal.Parse(p_strVal.Replace("%", ""), style, provider) / 100.0m;
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
}
