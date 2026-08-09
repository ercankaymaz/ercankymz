using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

internal class SourceComboBoxEditorMultiStringConverter : IValueConverter
{
	private Type enumType;

	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		enumType = value.GetType();
		IEnumerable<Enum> flags = GetFlags(value as Enum);
		return string.Join(",", flags);
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		List<string> source = (value as string).Split(new char[1] { ',' }).ToList();
		if (!source.Any((string x) => !string.IsNullOrEmpty(x)))
		{
			return Enum.ToObject(enumType, 0);
		}
		object value2 = source.Select((string x) => Enum.Parse(enumType, x)).Aggregate((object prev, object next) => (int)prev | (int)next);
		return Enum.ToObject(enumType, value2);
	}

	private static IEnumerable<Enum> GetFlags(Enum input)
	{
		foreach (Enum value in Enum.GetValues(input.GetType()))
		{
			if (input.HasFlag(value))
			{
				yield return value;
			}
		}
	}
}
