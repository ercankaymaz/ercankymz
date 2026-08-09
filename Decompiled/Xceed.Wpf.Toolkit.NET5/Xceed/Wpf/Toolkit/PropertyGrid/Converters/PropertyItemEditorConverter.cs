using System;
using System.Globalization;
using System.Reflection;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Converters;

public class PropertyItemEditorConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		if (values == null || values.Length != 3)
		{
			return null;
		}
		object obj = values[0];
		bool? flag = values[1] as bool?;
		bool? flag2 = values[2] as bool?;
		if (obj == null || !flag.HasValue || !flag2.HasValue)
		{
			return obj;
		}
		Type type = obj.GetType();
		PropertyInfo property = type.GetProperty("IsReadOnly");
		if (property != null)
		{
			if (!IsPropertySetLocally(obj, TextBoxBase.IsReadOnlyProperty))
			{
				bool flag3 = flag.Value || (!(obj is PropertyGridEditorCollectionControl) && flag2.Value);
				property.SetValue(obj, flag3, null);
			}
		}
		else
		{
			PropertyInfo property2 = type.GetProperty("IsEnabled");
			if (property2 != null && !IsPropertySetLocally(obj, UIElement.IsEnabledProperty))
			{
				bool flag4 = !flag.Value && (obj is PropertyGridEditorCollectionControl || !flag2.Value);
				property2.SetValue(obj, flag4, null);
			}
		}
		return obj;
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}

	private bool IsPropertySetLocally(object editor, DependencyProperty dp)
	{
		if (dp == null)
		{
			return false;
		}
		DependencyObject val = (DependencyObject)((editor is DependencyObject) ? editor : null);
		if (val == null)
		{
			return false;
		}
		return DependencyPropertyHelper.GetValueSource(val, dp).BaseValueSource == BaseValueSource.Local;
	}
}
