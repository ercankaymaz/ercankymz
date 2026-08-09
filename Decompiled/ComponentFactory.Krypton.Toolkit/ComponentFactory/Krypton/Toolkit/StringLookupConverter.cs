using System;
using System.ComponentModel;
using System.Globalization;

namespace ComponentFactory.Krypton.Toolkit;

public abstract class StringLookupConverter : EnumConverter
{
	protected struct Pair(object obj, string str)
	{
		public object Enum = obj;

		public string Display = str;
	}

	protected abstract Pair[] Pairs { get; }

	public StringLookupConverter(Type enumType)
		: base(enumType)
	{
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (destinationType == typeof(string))
		{
			Pair[] pairs = Pairs;
			for (int i = 0; i < pairs.Length; i++)
			{
				Pair pair = pairs[i];
				if (pair.Enum.Equals(value))
				{
					return pair.Display;
				}
			}
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (value is string)
		{
			Pair[] pairs = Pairs;
			for (int i = 0; i < pairs.Length; i++)
			{
				Pair pair = pairs[i];
				if (pair.Display.Equals(value))
				{
					return pair.Enum;
				}
			}
		}
		return base.ConvertFrom(context, culture, value);
	}
}
