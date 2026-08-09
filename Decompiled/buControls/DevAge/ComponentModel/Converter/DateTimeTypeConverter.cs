using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using ns27;

namespace DevAge.ComponentModel.Converter;

public class DateTimeTypeConverter : TypeConverter
{
	private TypeConverter typeConverter_0 = TypeDescriptor.GetConverter(typeof(DateTime));

	private DateTimeStyles p_DateTimeStyles = DateTimeStyles.AllowWhiteSpaces;

	private string p_ToStringFormat = "G";

	private string[] p_ParseFormats = null;

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

	public DateTimeStyles DateTimeStyles
	{
		get
		{
			return p_DateTimeStyles;
		}
		set
		{
			p_DateTimeStyles = value;
		}
	}

	public string Format
	{
		get
		{
			return p_ToStringFormat;
		}
		set
		{
			p_ToStringFormat = value;
		}
	}

	public string[] ParseFormats
	{
		get
		{
			return p_ParseFormats;
		}
		set
		{
			p_ParseFormats = value;
		}
	}

	public DateTimeTypeConverter()
	{
	}

	public DateTimeTypeConverter(string p_ToStringFormat)
	{
		this.p_ToStringFormat = p_ToStringFormat;
	}

	public DateTimeTypeConverter(string p_ToStringFormat, string[] p_ParseFormats)
	{
		this.p_ParseFormats = p_ParseFormats;
		this.p_ToStringFormat = p_ToStringFormat;
	}

	public DateTimeTypeConverter(string p_ToStringFormat, string[] p_ParseFormats, DateTimeStyles p_DateTimeStyles)
	{
		this.p_ParseFormats = p_ParseFormats;
		this.p_ToStringFormat = p_ToStringFormat;
		this.p_DateTimeStyles = p_DateTimeStyles;
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
		if (p_ParseFormats == null)
		{
			return DateTime.Parse((string)value, Class76.smethod_661(this, culture).DateTimeFormat, p_DateTimeStyles);
		}
		return DateTime.ParseExact((string)value, p_ParseFormats, Class76.smethod_661(this, culture).DateTimeFormat, p_DateTimeStyles);
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (!(destinationType == typeof(string)) || value == null)
		{
			return typeConverter_0.ConvertTo(context, culture, value, destinationType);
		}
		return ((DateTime)value).ToString(p_ToStringFormat, Class76.smethod_661(this, culture).DateTimeFormat);
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
}
