using System;
using System.ComponentModel;
using System.Globalization;

namespace devDept.Eyeshot.Converters;

public class OpacityConverter : TypeConverter
{
	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		if (!(sourceType == typeof(string)))
		{
			return base.CanConvertFrom(context, sourceType);
		}
		return true;
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (!(value is string))
		{
			return base.ConvertFrom(context, culture, value);
		}
		string text = ((string)value).Replace('%', ' ').Trim();
		double num = double.Parse(text, CultureInfo.CurrentCulture);
		if (((string)value).IndexOf(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953488)) > 0 && num >= 0.0 && num <= 1.0)
		{
			text = (num / 100.0).ToString(CultureInfo.CurrentCulture);
		}
		double num2;
		try
		{
			num2 = (double)TypeDescriptor.GetConverter(typeof(double)).ConvertFrom(context, culture, text);
			if (num2 > 1.0)
			{
				num2 /= 100.0;
			}
		}
		catch (FormatException innerException)
		{
			throw new FormatException(_0023_003Dzl43ZTCXv5lHo_CCNLd8QgHs_003D._0023_003DzCSptaQY_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953720), new object[4]
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953681),
				text,
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953695),
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953674)
			}), innerException);
		}
		if (!(num2 >= 0.0) || !(num2 <= 1.0))
		{
			throw new FormatException(_0023_003Dzl43ZTCXv5lHo_CCNLd8QgHs_003D._0023_003DzCSptaQY_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953720), new object[4]
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953681),
				text,
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953695),
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953674)
			}));
		}
		return num2;
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (destinationType == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953651));
		}
		if (!(destinationType == typeof(string)))
		{
			return base.ConvertTo(context, culture, value, destinationType);
		}
		return ((int)((double)value * 100.0)).ToString(CultureInfo.CurrentCulture) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953488);
	}
}
