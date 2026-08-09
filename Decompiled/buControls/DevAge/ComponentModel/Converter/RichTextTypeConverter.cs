using System;
using System.ComponentModel;
using System.Globalization;
using DevAge.Windows.Forms;

namespace DevAge.ComponentModel.Converter;

public class RichTextTypeConverter : TypeConverter
{
	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		if (!(sourceType == typeof(string)))
		{
			if (!(sourceType == typeof(RichText)))
			{
				if (!(sourceType == typeof(int)))
				{
					return false;
				}
				return true;
			}
			return true;
		}
		return true;
	}

	public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
	{
		if (!(destinationType == typeof(RichText)))
		{
			if (!(destinationType == typeof(string)))
			{
				return false;
			}
			return true;
		}
		return true;
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (value == null || (!(value.GetType() == typeof(string)) && !(value.GetType() == typeof(int))))
		{
			if (value == null || !(value.GetType() == typeof(RichText)))
			{
				throw new ArgumentException("Not supported type");
			}
			return value;
		}
		return RichTextConversion.StringToRichText(value.ToString());
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (!(destinationType == typeof(string)) || value == null || !(value.GetType() == typeof(RichText)))
		{
			if (!(destinationType == typeof(RichText)) || !IsValid(value))
			{
				if (!(destinationType == typeof(RichText)) || value == null || !(value.GetType() == typeof(string)))
				{
					if (value == null || !(destinationType == value.GetType()))
					{
						throw new ArgumentException("Not supported type");
					}
					return value;
				}
				return RichTextConversion.StringToRichText(value as string);
			}
			return new RichText(value as string);
		}
		return RichTextConversion.RichTextToString(value as RichText);
	}

	public override bool IsValid(ITypeDescriptorContext context, object value)
	{
		if (value == null || !(value.GetType() == typeof(string)))
		{
			return false;
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
