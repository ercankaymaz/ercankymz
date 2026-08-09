using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.Panels;

public static class SwitchTemplate
{
	public static readonly DependencyProperty IDProperty = DependencyProperty.RegisterAttached("ID", typeof(string), typeof(SwitchTemplate), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnIDChanged)));

	public static string GetID(DependencyObject d)
	{
		return (string)d.GetValue(IDProperty);
	}

	public static void SetID(DependencyObject d, string value)
	{
		d.SetValue(IDProperty, (object)value);
	}

	private static void OnIDChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue == null || !(d is UIElement))
		{
			return;
		}
		SwitchPresenter parentPresenter = VisualTreeHelperEx.FindAncestorByType<SwitchPresenter>(d);
		if (parentPresenter != null)
		{
			parentPresenter.RegisterID(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as string, d as FrameworkElement);
			return;
		}
		((DispatcherObject)d).Dispatcher.BeginInvoke((DispatcherPriority)6, (Delegate)(ThreadStart)delegate
		{
			parentPresenter = VisualTreeHelperEx.FindAncestorByType<SwitchPresenter>(d);
			if (parentPresenter != null)
			{
				parentPresenter.RegisterID(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as string, d as FrameworkElement);
			}
		});
	}
}
