using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;

namespace Xceed.Wpf.AvalonDock.Controls;

internal class BindingHelper
{
	public static void RebindInactiveBindings(DependencyObject dependencyObject)
	{
		foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(((object)dependencyObject).GetType()))
		{
			DependencyPropertyDescriptor dpd = DependencyPropertyDescriptor.FromProperty(property);
			if (dpd == null)
			{
				continue;
			}
			BindingExpressionBase binding = BindingOperations.GetBindingExpressionBase(dependencyObject, dpd.DependencyProperty);
			if (binding != null)
			{
				Dispatcher.CurrentDispatcher.BeginInvoke((DispatcherPriority)1, (Delegate)(Action)delegate
				{
					dependencyObject.ClearValue(dpd.DependencyProperty);
					BindingOperations.SetBinding(dependencyObject, dpd.DependencyProperty, binding.ParentBindingBase);
				});
			}
		}
	}
}
