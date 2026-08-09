using System;
using System.Globalization;
using System.Windows;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit;

public abstract class NumericUpDown<T> : UpDownBase<T>
{
	public static readonly DependencyProperty AutoMoveFocusProperty = DependencyProperty.Register("AutoMoveFocus", typeof(bool), typeof(NumericUpDown<T>), (PropertyMetadata)(object)new UIPropertyMetadata((object)false));

	public static readonly DependencyProperty AutoSelectBehaviorProperty = DependencyProperty.Register("AutoSelectBehavior", typeof(AutoSelectBehavior), typeof(NumericUpDown<T>), (PropertyMetadata)(object)new UIPropertyMetadata((object)AutoSelectBehavior.OnFocus));

	public static readonly DependencyProperty FormatStringProperty = DependencyProperty.Register("FormatString", typeof(string), typeof(NumericUpDown<T>), (PropertyMetadata)(object)new UIPropertyMetadata(string.Empty, new PropertyChangedCallback(OnFormatStringChanged), new CoerceValueCallback(OnCoerceFormatString)));

	public static readonly DependencyProperty IncrementProperty = DependencyProperty.Register("Increment", typeof(T), typeof(NumericUpDown<T>), new PropertyMetadata((object)default(T), new PropertyChangedCallback(OnIncrementChanged), new CoerceValueCallback(OnCoerceIncrement)));

	public static readonly DependencyProperty MaxLengthProperty = DependencyProperty.Register("MaxLength", typeof(int), typeof(NumericUpDown<T>), (PropertyMetadata)(object)new UIPropertyMetadata((object)0));

	public bool AutoMoveFocus
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AutoMoveFocusProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoMoveFocusProperty, (object)value);
		}
	}

	public AutoSelectBehavior AutoSelectBehavior
	{
		get
		{
			return (AutoSelectBehavior)((DependencyObject)this).GetValue(AutoSelectBehaviorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoSelectBehaviorProperty, (object)value);
		}
	}

	public string FormatString
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(FormatStringProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FormatStringProperty, (object)value);
		}
	}

	public T Increment
	{
		get
		{
			return (T)((DependencyObject)this).GetValue(IncrementProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IncrementProperty, (object)value);
		}
	}

	public int MaxLength
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(MaxLengthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaxLengthProperty, (object)value);
		}
	}

	private static object OnCoerceFormatString(DependencyObject o, object baseValue)
	{
		if (o is NumericUpDown<T> numericUpDown)
		{
			return numericUpDown.OnCoerceFormatString((string)baseValue);
		}
		return baseValue;
	}

	protected virtual string OnCoerceFormatString(string baseValue)
	{
		return baseValue ?? string.Empty;
	}

	private static void OnFormatStringChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is NumericUpDown<T> numericUpDown)
		{
			numericUpDown.OnFormatStringChanged((string)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnFormatStringChanged(string oldValue, string newValue)
	{
		if (base.IsInitialized)
		{
			SyncTextAndValueProperties(updateValueFromText: false, null);
		}
	}

	private static void OnIncrementChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is NumericUpDown<T> numericUpDown)
		{
			numericUpDown.OnIncrementChanged((T)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (T)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnIncrementChanged(T oldValue, T newValue)
	{
		if (base.IsInitialized)
		{
			SetValidSpinDirection();
		}
	}

	private static object OnCoerceIncrement(DependencyObject d, object baseValue)
	{
		if (d is NumericUpDown<T> numericUpDown)
		{
			return numericUpDown.OnCoerceIncrement((T)baseValue);
		}
		return baseValue;
	}

	protected virtual T OnCoerceIncrement(T baseValue)
	{
		return baseValue;
	}

	protected static decimal ParsePercent(string text, IFormatProvider cultureInfo)
	{
		NumberFormatInfo instance = NumberFormatInfo.GetInstance(cultureInfo);
		text = text.Replace(instance.PercentSymbol, null);
		return decimal.Parse(text, NumberStyles.Any, instance) / 100m;
	}
}
