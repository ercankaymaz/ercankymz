using System;
using System.Globalization;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class PasswordToStringConverter : IValueConverter
{
	private WatermarkPasswordBox _editor;

	public PasswordToStringConverter(WatermarkPasswordBox editor)
	{
		_editor = editor;
	}

	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		_editor.Password = value as string;
		return _editor.Text;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return _editor.Password;
	}
}
