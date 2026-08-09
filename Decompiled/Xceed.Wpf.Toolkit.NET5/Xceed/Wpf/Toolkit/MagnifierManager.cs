using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace Xceed.Wpf.Toolkit;

public class MagnifierManager : DependencyObject
{
	private MagnifierAdorner _adorner;

	private UIElement _element;

	public static readonly DependencyProperty CurrentProperty = DependencyProperty.RegisterAttached("Magnifier", typeof(Magnifier), typeof(UIElement), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnMagnifierChanged)));

	public static void SetMagnifier(UIElement element, Magnifier value)
	{
		((DependencyObject)element).SetValue(CurrentProperty, (object)value);
	}

	public static Magnifier GetMagnifier(UIElement element)
	{
		return (Magnifier)((DependencyObject)element).GetValue(CurrentProperty);
	}

	private static void OnMagnifierChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (!(d is UIElement element))
		{
			throw new ArgumentException("Magnifier can only be attached to a UIElement.");
		}
		new MagnifierManager().AttachToMagnifier(element, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as Magnifier);
	}

	private void Element_MouseLeave(object sender, MouseEventArgs e)
	{
		Magnifier magnifier = GetMagnifier(_element);
		if (magnifier == null || !magnifier.IsFrozen)
		{
			HideAdorner();
		}
	}

	private void Element_MouseEnter(object sender, MouseEventArgs e)
	{
		ShowAdorner();
	}

	private void Element_MouseWheel(object sender, MouseWheelEventArgs e)
	{
		Magnifier magnifier = GetMagnifier(_element);
		if (magnifier != null && magnifier.IsUsingZoomOnMouseWheel)
		{
			if (e.Delta < 0)
			{
				double num = magnifier.ZoomFactor + magnifier.ZoomFactorOnMouseWheel;
				((DependencyObject)magnifier).SetCurrentValue(Magnifier.ZoomFactorProperty, (object)num);
			}
			else if (e.Delta > 0)
			{
				double num2 = ((magnifier.ZoomFactor >= magnifier.ZoomFactorOnMouseWheel) ? (magnifier.ZoomFactor - magnifier.ZoomFactorOnMouseWheel) : 0.0);
				((DependencyObject)magnifier).SetCurrentValue(Magnifier.ZoomFactorProperty, (object)num2);
			}
			_adorner.UpdateViewBox();
		}
	}

	private void AttachToMagnifier(UIElement element, Magnifier magnifier)
	{
		_element = element;
		_element.MouseEnter += Element_MouseEnter;
		_element.MouseLeave += Element_MouseLeave;
		_element.MouseWheel += Element_MouseWheel;
		magnifier.Target = _element;
		_adorner = new MagnifierAdorner(_element, magnifier);
	}

	private void ShowAdorner()
	{
		VerifyAdornerLayer();
		_adorner.Visibility = Visibility.Visible;
	}

	private bool VerifyAdornerLayer()
	{
		if (_adorner.Parent != null)
		{
			return true;
		}
		AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(_element);
		if (adornerLayer == null)
		{
			return false;
		}
		adornerLayer.Add(_adorner);
		return true;
	}

	private void HideAdorner()
	{
		if (_adorner.Visibility == Visibility.Visible)
		{
			_adorner.Visibility = Visibility.Collapsed;
		}
	}
}
