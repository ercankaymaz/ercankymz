using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using Standard;

namespace Microsoft.Windows.Shell;

public class WindowChrome : Freezable
{
	private struct _SystemParameterBoundProperty
	{
		public string SystemParameterPropertyName { get; set; }

		public DependencyProperty DependencyProperty { get; set; }
	}

	public static readonly DependencyProperty WindowChromeProperty = DependencyProperty.RegisterAttached("WindowChrome", typeof(WindowChrome), typeof(WindowChrome), new PropertyMetadata((object)null, new PropertyChangedCallback(_OnChromeChanged)));

	public static readonly DependencyProperty IsHitTestVisibleInChromeProperty = DependencyProperty.RegisterAttached("IsHitTestVisibleInChrome", typeof(bool), typeof(WindowChrome), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, FrameworkPropertyMetadataOptions.Inherits));

	public static readonly DependencyProperty CaptionHeightProperty = DependencyProperty.Register("CaptionHeight", typeof(double), typeof(WindowChrome), new PropertyMetadata((object)0.0, (PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((WindowChrome)(object)d)._OnPropertyChangedThatRequiresRepaint();
	}), (ValidateValueCallback)((object value) => (double)value >= 0.0));

	public static readonly DependencyProperty ResizeBorderThicknessProperty = DependencyProperty.Register("ResizeBorderThickness", typeof(Thickness), typeof(WindowChrome), new PropertyMetadata((object)default(Thickness)), (ValidateValueCallback)((object value) => Standard.Utility.IsThicknessNonNegative((Thickness)value)));

	public static readonly DependencyProperty GlassFrameThicknessProperty = DependencyProperty.Register("GlassFrameThickness", typeof(Thickness), typeof(WindowChrome), new PropertyMetadata((object)default(Thickness), (PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((WindowChrome)(object)d)._OnPropertyChangedThatRequiresRepaint();
	}, (CoerceValueCallback)((DependencyObject d, object o) => _CoerceGlassFrameThickness((Thickness)o))));

	public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(WindowChrome), new PropertyMetadata((object)default(CornerRadius), (PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((WindowChrome)(object)d)._OnPropertyChangedThatRequiresRepaint();
	}), (ValidateValueCallback)((object value) => Standard.Utility.IsCornerRadiusValid((CornerRadius)value)));

	private static readonly List<_SystemParameterBoundProperty> _BoundProperties = new List<_SystemParameterBoundProperty>
	{
		new _SystemParameterBoundProperty
		{
			DependencyProperty = CornerRadiusProperty,
			SystemParameterPropertyName = "WindowCornerRadius"
		},
		new _SystemParameterBoundProperty
		{
			DependencyProperty = CaptionHeightProperty,
			SystemParameterPropertyName = "WindowCaptionHeight"
		},
		new _SystemParameterBoundProperty
		{
			DependencyProperty = ResizeBorderThicknessProperty,
			SystemParameterPropertyName = "WindowResizeBorderThickness"
		},
		new _SystemParameterBoundProperty
		{
			DependencyProperty = GlassFrameThicknessProperty,
			SystemParameterPropertyName = "WindowNonClientFrameThickness"
		}
	};

	public static Thickness GlassFrameCompleteThickness => new Thickness(-1.0);

	public double CaptionHeight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(CaptionHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CaptionHeightProperty, (object)value);
		}
	}

	public Thickness ResizeBorderThickness
	{
		get
		{
			return (Thickness)((DependencyObject)this).GetValue(ResizeBorderThicknessProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ResizeBorderThicknessProperty, (object)value);
		}
	}

	public Thickness GlassFrameThickness
	{
		get
		{
			return (Thickness)((DependencyObject)this).GetValue(GlassFrameThicknessProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(GlassFrameThicknessProperty, (object)value);
		}
	}

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

	public bool ShowSystemMenu { get; set; }

	internal event EventHandler PropertyChangedThatRequiresRepaint;

	private static void _OnChromeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (!DesignerProperties.GetIsInDesignMode(d))
		{
			Window window = (Window)(object)d;
			WindowChrome windowChrome = (WindowChrome)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
			WindowChromeWorker windowChromeWorker = WindowChromeWorker.GetWindowChromeWorker(window);
			if (windowChromeWorker == null)
			{
				windowChromeWorker = new WindowChromeWorker();
				WindowChromeWorker.SetWindowChromeWorker(window, windowChromeWorker);
			}
			windowChromeWorker.SetWindowChrome(windowChrome);
		}
	}

	public static WindowChrome GetWindowChrome(Window window)
	{
		Standard.Verify.IsNotNull(window, "window");
		return (WindowChrome)((DependencyObject)window).GetValue(WindowChromeProperty);
	}

	public static void SetWindowChrome(Window window, WindowChrome chrome)
	{
		Standard.Verify.IsNotNull(window, "window");
		((DependencyObject)window).SetValue(WindowChromeProperty, (object)chrome);
	}

	public static bool GetIsHitTestVisibleInChrome(IInputElement inputElement)
	{
		Standard.Verify.IsNotNull(inputElement, "inputElement");
		return (bool)((DependencyObject)(((inputElement is DependencyObject) ? inputElement : null) ?? throw new ArgumentException("The element must be a DependencyObject", "inputElement"))).GetValue(IsHitTestVisibleInChromeProperty);
	}

	public static void SetIsHitTestVisibleInChrome(IInputElement inputElement, bool hitTestVisible)
	{
		Standard.Verify.IsNotNull(inputElement, "inputElement");
		((DependencyObject)(((inputElement is DependencyObject) ? inputElement : null) ?? throw new ArgumentException("The element must be a DependencyObject", "inputElement"))).SetValue(IsHitTestVisibleInChromeProperty, (object)hitTestVisible);
	}

	private static object _CoerceGlassFrameThickness(Thickness thickness)
	{
		if (!Standard.Utility.IsThicknessNonNegative(thickness))
		{
			return GlassFrameCompleteThickness;
		}
		return thickness;
	}

	protected override Freezable CreateInstanceCore()
	{
		return (Freezable)(object)new WindowChrome();
	}

	public WindowChrome()
	{
		foreach (_SystemParameterBoundProperty boundProperty in _BoundProperties)
		{
			BindingOperations.SetBinding((DependencyObject)(object)this, boundProperty.DependencyProperty, new Binding
			{
				Source = SystemParameters2.Current,
				Path = new PropertyPath(boundProperty.SystemParameterPropertyName),
				Mode = BindingMode.OneWay,
				UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
			});
		}
	}

	private void _OnPropertyChangedThatRequiresRepaint()
	{
		this.PropertyChangedThatRequiresRepaint?.Invoke(this, EventArgs.Empty);
	}
}
