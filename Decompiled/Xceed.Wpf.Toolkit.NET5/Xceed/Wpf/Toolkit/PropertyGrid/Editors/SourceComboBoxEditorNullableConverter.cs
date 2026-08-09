using System;
using System.Globalization;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

internal class SourceComboBoxEditorNullableConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return value ?? SourceComboBoxEditor.ComboBoxNullValue;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (!value.Equals(SourceComboBoxEditor.ComboBoxNullValue))
		{
			return value;
		}
		return null;
	}
}
