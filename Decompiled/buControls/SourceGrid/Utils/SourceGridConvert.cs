using System;
using System.ComponentModel;

namespace SourceGrid.Utils;

public static class SourceGridConvert
{
	public static T To<T>(object value)
	{
		try
		{
			object obj = To(value, typeof(T));
			return (obj == null) ? default(T) : ((T)obj);
		}
		catch (FormatException)
		{
			return default(T);
		}
	}

	public static object To(object value, Type type)
	{
		if (value != null)
		{
			if (!(value.GetType() == type))
			{
				if (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
				{
					if (value is string && value.ToString() == string.Empty)
					{
						return null;
					}
					NullableConverter nullableConverter = new NullableConverter(type);
					type = nullableConverter.UnderlyingType;
				}
				if (!type.IsEnum || !Enum.IsDefined(type, value))
				{
					TypeConverter converter = TypeDescriptor.GetConverter(type);
					if (!converter.CanConvertFrom(value.GetType()))
					{
						converter = TypeDescriptor.GetConverter(value.GetType());
						if (!converter.CanConvertTo(type))
						{
							return Convert.ChangeType(value, type);
						}
						return converter.ConvertTo(value, type);
					}
					return converter.ConvertFrom(value);
				}
				return Enum.Parse(type, value.ToString(), ignoreCase: false);
			}
			return value;
		}
		return null;
	}
}
