using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.Core.Converters;

public class ObjectTypeToNameConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value != null)
		{
			if (value is Type)
			{
				DisplayNameAttribute displayNameAttribute = ((Type)value).GetCustomAttributes(inherit: false).OfType<DisplayNameAttribute>().FirstOrDefault();
				if (displayNameAttribute == null)
				{
					return ((Type)value).Name;
				}
				return displayNameAttribute.DisplayName;
			}
			Type type = value.GetType();
			string text = value.ToString();
			if (string.IsNullOrEmpty(text) || text == type.UnderlyingSystemType.ToString())
			{
				DisplayNameAttribute displayNameAttribute2 = type.GetCustomAttributes(inherit: false).OfType<DisplayNameAttribute>().FirstOrDefault();
				if (displayNameAttribute2 == null)
				{
					return type.Name;
				}
				return displayNameAttribute2.DisplayName;
			}
			return value;
		}
		return null;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
