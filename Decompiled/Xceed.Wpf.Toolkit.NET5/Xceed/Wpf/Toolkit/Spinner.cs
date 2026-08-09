using System;
using System.Windows;
using System.Windows.Controls;

namespace Xceed.Wpf.Toolkit;

public abstract class Spinner : Control
{
	public static readonly DependencyProperty ValidSpinDirectionProperty = DependencyProperty.Register("ValidSpinDirection", typeof(ValidSpinDirections), typeof(Spinner), new PropertyMetadata((object)(ValidSpinDirections.Increase | ValidSpinDirections.Decrease), new PropertyChangedCallback(OnValidSpinDirectionPropertyChanged)));

	public static readonly RoutedEvent SpinnerSpinEvent = EventManager.RegisterRoutedEvent("SpinnerSpin", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Spinner));

	public ValidSpinDirections ValidSpinDirection
	{
		get
		{
			return (ValidSpinDirections)((DependencyObject)this).GetValue(ValidSpinDirectionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ValidSpinDirectionProperty, (object)value);
		}
	}

	public event EventHandler<SpinEventArgs> Spin;

	public event RoutedEventHandler SpinnerSpin
	{
		add
		{
			AddHandler(SpinnerSpinEvent, value);
		}
		remove
		{
			RemoveHandler(SpinnerSpinEvent, value);
		}
	}

	private static void OnValidSpinDirectionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		Spinner obj = (Spinner)(object)d;
		ValidSpinDirections oldValue = (ValidSpinDirections)((DependencyPropertyChangedEventArgs)(ref e)).OldValue;
		ValidSpinDirections newValue = (ValidSpinDirections)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		obj.OnValidSpinDirectionChanged(oldValue, newValue);
	}

	protected virtual void OnSpin(SpinEventArgs e)
	{
		ValidSpinDirections validSpinDirections = ((e.Direction == SpinDirection.Increase) ? ValidSpinDirections.Increase : ValidSpinDirections.Decrease);
		if ((ValidSpinDirection & validSpinDirections) == validSpinDirections)
		{
			this.Spin?.Invoke(this, e);
		}
	}

	protected virtual void OnValidSpinDirectionChanged(ValidSpinDirections oldValue, ValidSpinDirections newValue)
	{
	}
}
