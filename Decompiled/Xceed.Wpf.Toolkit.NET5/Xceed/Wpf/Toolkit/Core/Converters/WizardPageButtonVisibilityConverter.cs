using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.Core.Converters;

public class WizardPageButtonVisibilityConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		if (values == null || values.Length != 2)
		{
			throw new ArgumentException("Wrong number of arguments for WizardPageButtonVisibilityConverter.");
		}
		Visibility visibility = ((values[0] == null || values[0] == DependencyProperty.UnsetValue) ? Visibility.Hidden : ((Visibility)values[0]));
		WizardPageButtonVisibility wizardPageButtonVisibility = ((values[1] == null || values[1] == DependencyProperty.UnsetValue) ? WizardPageButtonVisibility.Hidden : ((WizardPageButtonVisibility)values[1]));
		Visibility visibility2 = Visibility.Visible;
		switch (wizardPageButtonVisibility)
		{
		case WizardPageButtonVisibility.Inherit:
			visibility2 = visibility;
			break;
		case WizardPageButtonVisibility.Collapsed:
			visibility2 = Visibility.Collapsed;
			break;
		case WizardPageButtonVisibility.Hidden:
			visibility2 = Visibility.Hidden;
			break;
		case WizardPageButtonVisibility.Visible:
			visibility2 = Visibility.Visible;
			break;
		}
		return visibility2;
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
