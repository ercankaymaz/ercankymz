using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

internal class SourceComboBoxEditorStringConverter : IValueConverter
{
	private TypeConverter _typeConverter;

	internal SourceComboBoxEditorStringConverter(TypeConverter typeConverter)
	{
		_typeConverter = typeConverter;
	}

	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (_typeConverter != null && _typeConverter.CanConvertTo(typeof(string)))
		{
			return _typeConverter.ConvertTo(value, typeof(string));
		}
		return value;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (_typeConverter != null && _typeConverter.CanConvertFrom(value.GetType()))
		{
			return _typeConverter.ConvertFrom(value);
		}
		return value;
	}
}
