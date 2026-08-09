using System;
using System.Windows;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

public class CustomPropertyItem : PropertyItemBase
{
	public static readonly DependencyProperty CategoryProperty = DependencyProperty.Register("Category", typeof(string), typeof(CustomPropertyItem), (PropertyMetadata)(object)new UIPropertyMetadata(null));

	private int _categoryOrder;

	public static readonly DependencyProperty PropertyOrderProperty = DependencyProperty.Register("PropertyOrder", typeof(int), typeof(CustomPropertyItem), (PropertyMetadata)(object)new UIPropertyMetadata((object)0));

	public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(object), typeof(CustomPropertyItem), (PropertyMetadata)(object)new UIPropertyMetadata(null, new PropertyChangedCallback(OnValueChanged), new CoerceValueCallback(OnCoerceValueChanged)));

	public string Category
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(CategoryProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CategoryProperty, (object)value);
		}
	}

	public int CategoryOrder
	{
		get
		{
			return _categoryOrder;
		}
		set
		{
			if (_categoryOrder != value)
			{
				_categoryOrder = value;
				RaisePropertyChanged(() => CategoryOrder);
			}
		}
	}

	public int PropertyOrder
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(PropertyOrderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PropertyOrderProperty, (object)value);
		}
	}

	public object Value
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

	internal CustomPropertyItem()
	{
	}

	internal CustomPropertyItem(bool isPropertyGridCategorized, bool isSortedAlphabetically)
	{
		_isPropertyGridCategorized = isPropertyGridCategorized;
		_isSortedAlphabetically = isSortedAlphabetically;
	}

	private static object OnCoerceValueChanged(DependencyObject o, object baseValue)
	{
		if (o is CustomPropertyItem customPropertyItem)
		{
			return customPropertyItem.OnCoerceValueChanged(baseValue);
		}
		return baseValue;
	}

	protected virtual object OnCoerceValueChanged(object baseValue)
	{
		return baseValue;
	}

	private static void OnValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is CustomPropertyItem customPropertyItem)
		{
			customPropertyItem.OnValueChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnValueChanged(object oldValue, object newValue)
	{
		if (base.IsInitialized)
		{
			RaiseEvent(new PropertyValueChangedEventArgs(PropertyGrid.PropertyValueChangedEvent, this, oldValue, newValue));
		}
	}

	protected override Type GetPropertyItemType()
	{
		return Value.GetType();
	}

	protected override void OnEditorChanged(FrameworkElement oldValue, FrameworkElement newValue)
	{
		if (oldValue != null)
		{
			oldValue.DataContext = null;
		}
		if (newValue != null && newValue.DataContext == null)
		{
			newValue.DataContext = this;
		}
	}
}
