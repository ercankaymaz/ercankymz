using System;
using System.Globalization;

namespace DevAge.ComponentModel.Converter;

public class CurrencyTypeConverter : NumberTypeConverter
{
	public CurrencyTypeConverter(Type p_BaseType)
		: base(p_BaseType)
	{
		base.Format = "C";
		base.NumberStyles = NumberStyles.Currency;
	}

	public CurrencyTypeConverter(Type p_BaseType, string p_Format)
		: this(p_BaseType)
	{
		base.Format = p_Format;
	}
}
