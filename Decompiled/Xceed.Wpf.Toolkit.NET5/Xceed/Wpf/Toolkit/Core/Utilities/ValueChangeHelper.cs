using System;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.Core.Utilities;

internal class ValueChangeHelper : DependencyObject
{
	private class BlankMultiValueConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			return new object();
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new InvalidOperationException();
		}
	}

	private static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(object), typeof(ValueChangeHelper), (PropertyMetadata)(object)new UIPropertyMetadata(null, new PropertyChangedCallback(OnValueChanged)));

	private object Value
	{
		get
		{
			return ((DependencyObject)this).GetValue(ValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ValueProperty, value);
		}
	}

	public event EventHandler ValueChanged;

	private static void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		((ValueChangeHelper)(object)sender).RaiseValueChanged();
	}

	public ValueChangeHelper(Action changeCallback)
	{
		if (changeCallback == null)
		{
			throw new ArgumentNullException("changeCallback");
		}
		ValueChanged += delegate
		{
			changeCallback();
		};
	}

	public void UpdateValueSource(object sourceItem, string path)
	{
		BindingBase binding = null;
		if (sourceItem != null && path != null)
		{
			binding = new Binding(path)
			{
				Source = sourceItem
			};
		}
		UpdateBinding(binding);
	}

	public void UpdateValueSource(IEnumerable sourceItems, string path)
	{
		BindingBase binding = null;
		if (sourceItems != null && path != null)
		{
			MultiBinding multiBinding = new MultiBinding();
			multiBinding.Converter = new BlankMultiValueConverter();
			foreach (object sourceItem in sourceItems)
			{
				multiBinding.Bindings.Add(new Binding(path)
				{
					Source = sourceItem
				});
			}
			binding = multiBinding;
		}
		UpdateBinding(binding);
	}

	private void UpdateBinding(BindingBase binding)
	{
		if (binding != null)
		{
			BindingOperations.SetBinding((DependencyObject)(object)this, ValueProperty, binding);
		}
		else
		{
			ClearBinding();
		}
	}

	private void ClearBinding()
	{
		BindingOperations.ClearBinding((DependencyObject)(object)this, ValueProperty);
	}

	private void RaiseValueChanged()
	{
		if (this.ValueChanged != null)
		{
			this.ValueChanged(this, EventArgs.Empty);
		}
	}
}
