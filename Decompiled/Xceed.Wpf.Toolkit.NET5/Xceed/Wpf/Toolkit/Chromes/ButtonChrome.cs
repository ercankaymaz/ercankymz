using System;
using System.Windows;
using System.Windows.Controls;

namespace Xceed.Wpf.Toolkit.Chromes;

public class ButtonChrome : ContentControl
{
	public static readonly DependencyProperty CornerRadiusProperty;

	public static readonly DependencyProperty InnerCornerRadiusProperty;

	public static readonly DependencyProperty RenderCheckedProperty;

	public static readonly DependencyProperty RenderEnabledProperty;

	public static readonly DependencyProperty RenderFocusedProperty;

	public static readonly DependencyProperty RenderMouseOverProperty;

	public static readonly DependencyProperty RenderNormalProperty;

	public static readonly DependencyProperty RenderPressedProperty;

	public CornerRadius CornerRadius
	{
		get
		{
			return (CornerRadius)((DependencyObject)this).GetValue(CornerRadiusProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CornerRadiusProperty, (object)value);
		}
	}

	public CornerRadius InnerCornerRadius
	{
		get
		{
			return (CornerRadius)((DependencyObject)this).GetValue(InnerCornerRadiusProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(InnerCornerRadiusProperty, (object)value);
		}
	}

	public bool RenderChecked
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(RenderCheckedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RenderCheckedProperty, (object)value);
		}
	}

	public bool RenderEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(RenderEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RenderEnabledProperty, (object)value);
		}
	}

	public bool RenderFocused
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(RenderFocusedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RenderFocusedProperty, (object)value);
		}
	}

	public bool RenderMouseOver
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(RenderMouseOverProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RenderMouseOverProperty, (object)value);
		}
	}

	public bool RenderNormal
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(RenderNormalProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RenderNormalProperty, (object)value);
		}
	}

	public bool RenderPressed
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(RenderPressedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RenderPressedProperty, (object)value);
		}
	}

	private static void OnCornerRadiusChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ButtonChrome buttonChrome)
		{
			buttonChrome.OnCornerRadiusChanged((CornerRadius)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (CornerRadius)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnCornerRadiusChanged(CornerRadius oldValue, CornerRadius newValue)
	{
		CornerRadius innerCornerRadius = new CornerRadius(Math.Max(0.0, newValue.TopLeft - 1.0), Math.Max(0.0, newValue.TopRight - 1.0), Math.Max(0.0, newValue.BottomRight - 1.0), Math.Max(0.0, newValue.BottomLeft - 1.0));
		InnerCornerRadius = innerCornerRadius;
	}

	private static void OnInnerCornerRadiusChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ButtonChrome buttonChrome)
		{
			buttonChrome.OnInnerCornerRadiusChanged((CornerRadius)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (CornerRadius)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnInnerCornerRadiusChanged(CornerRadius oldValue, CornerRadius newValue)
	{
	}

	private static void OnRenderCheckedChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ButtonChrome buttonChrome)
		{
			buttonChrome.OnRenderCheckedChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnRenderCheckedChanged(bool oldValue, bool newValue)
	{
	}

	private static void OnRenderEnabledChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ButtonChrome buttonChrome)
		{
			buttonChrome.OnRenderEnabledChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnRenderEnabledChanged(bool oldValue, bool newValue)
	{
	}

	private static void OnRenderFocusedChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ButtonChrome buttonChrome)
		{
			buttonChrome.OnRenderFocusedChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnRenderFocusedChanged(bool oldValue, bool newValue)
	{
	}

	private static void OnRenderMouseOverChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ButtonChrome buttonChrome)
		{
			buttonChrome.OnRenderMouseOverChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnRenderMouseOverChanged(bool oldValue, bool newValue)
	{
	}

	private static void OnRenderNormalChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ButtonChrome buttonChrome)
		{
			buttonChrome.OnRenderNormalChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnRenderNormalChanged(bool oldValue, bool newValue)
	{
	}

	private static void OnRenderPressedChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ButtonChrome buttonChrome)
		{
			buttonChrome.OnRenderPressedChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnRenderPressedChanged(bool oldValue, bool newValue)
	{
	}

	static ButtonChrome()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected O, but got Unknown
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Expected O, but got Unknown
		CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ButtonChrome), (PropertyMetadata)(object)new UIPropertyMetadata(default(CornerRadius), new PropertyChangedCallback(OnCornerRadiusChanged)));
		InnerCornerRadiusProperty = DependencyProperty.Register("InnerCornerRadius", typeof(CornerRadius), typeof(ButtonChrome), (PropertyMetadata)(object)new UIPropertyMetadata(default(CornerRadius), new PropertyChangedCallback(OnInnerCornerRadiusChanged)));
		RenderCheckedProperty = DependencyProperty.Register("RenderChecked", typeof(bool), typeof(ButtonChrome), (PropertyMetadata)(object)new UIPropertyMetadata(false, new PropertyChangedCallback(OnRenderCheckedChanged)));
		RenderEnabledProperty = DependencyProperty.Register("RenderEnabled", typeof(bool), typeof(ButtonChrome), (PropertyMetadata)(object)new UIPropertyMetadata(true, new PropertyChangedCallback(OnRenderEnabledChanged)));
		RenderFocusedProperty = DependencyProperty.Register("RenderFocused", typeof(bool), typeof(ButtonChrome), (PropertyMetadata)(object)new UIPropertyMetadata(false, new PropertyChangedCallback(OnRenderFocusedChanged)));
		RenderMouseOverProperty = DependencyProperty.Register("RenderMouseOver", typeof(bool), typeof(ButtonChrome), (PropertyMetadata)(object)new UIPropertyMetadata(false, new PropertyChangedCallback(OnRenderMouseOverChanged)));
		RenderNormalProperty = DependencyProperty.Register("RenderNormal", typeof(bool), typeof(ButtonChrome), (PropertyMetadata)(object)new UIPropertyMetadata(true, new PropertyChangedCallback(OnRenderNormalChanged)));
		RenderPressedProperty = DependencyProperty.Register("RenderPressed", typeof(bool), typeof(ButtonChrome), (PropertyMetadata)(object)new UIPropertyMetadata(false, new PropertyChangedCallback(OnRenderPressedChanged)));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ButtonChrome), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(ButtonChrome)));
	}
}
