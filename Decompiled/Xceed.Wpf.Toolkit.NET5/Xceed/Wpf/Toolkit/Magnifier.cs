using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_VisualBrush", Type = typeof(VisualBrush))]
public class Magnifier : Control
{
	private const double DEFAULT_SIZE = 100.0;

	private const string PART_VisualBrush = "PART_VisualBrush";

	private VisualBrush _visualBrush = new VisualBrush();

	public static readonly DependencyProperty FrameTypeProperty;

	public static readonly DependencyProperty IsUsingZoomOnMouseWheelProperty;

	public static readonly DependencyProperty RadiusProperty;

	public static readonly DependencyProperty TargetProperty;

	public static readonly DependencyProperty ZoomFactorProperty;

	public static readonly DependencyProperty ZoomFactorOnMouseWheelProperty;

	public FrameType FrameType
	{
		get
		{
			return (FrameType)((DependencyObject)this).GetValue(FrameTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FrameTypeProperty, (object)value);
		}
	}

	public bool IsUsingZoomOnMouseWheel
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsUsingZoomOnMouseWheelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsUsingZoomOnMouseWheelProperty, (object)value);
		}
	}

	public bool IsFrozen { get; private set; }

	public double Radius
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(RadiusProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RadiusProperty, (object)value);
		}
	}

	public UIElement Target
	{
		get
		{
			return (UIElement)((DependencyObject)this).GetValue(TargetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TargetProperty, (object)value);
		}
	}

	internal Rect ViewBox
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return _visualBrush.Viewbox;
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			_visualBrush.Viewbox = value;
		}
	}

	public double ZoomFactor
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ZoomFactorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ZoomFactorProperty, (object)value);
		}
	}

	public double ZoomFactorOnMouseWheel
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ZoomFactorOnMouseWheelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ZoomFactorOnMouseWheelProperty, (object)value);
		}
	}

	private static void OnFrameTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((Magnifier)(object)d).OnFrameTypeChanged((FrameType)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (FrameType)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	protected virtual void OnFrameTypeChanged(FrameType oldValue, FrameType newValue)
	{
		UpdateSizeFromRadius();
	}

	private static void OnRadiusPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((Magnifier)(object)d).OnRadiusChanged(e);
	}

	protected virtual void OnRadiusChanged(DependencyPropertyChangedEventArgs e)
	{
		UpdateSizeFromRadius();
	}

	private static bool OnValidationCallback(object baseValue)
	{
		return (double)baseValue >= 0.0;
	}

	private static void OnZoomFactorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((Magnifier)(object)d).OnZoomFactorChanged(e);
	}

	protected virtual void OnZoomFactorChanged(DependencyPropertyChangedEventArgs e)
	{
		UpdateViewBox();
	}

	private static bool OnZoomFactorOnMouseWheelValidationCallback(object baseValue)
	{
		return (double)baseValue >= 0.0;
	}

	private static void OnZoomFactorOnMouseWheelPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((Magnifier)(object)d).OnZoomFactorOnMouseWheelChanged(e);
	}

	protected virtual void OnZoomFactorOnMouseWheelChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	static Magnifier()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		FrameTypeProperty = DependencyProperty.Register("FrameType", typeof(FrameType), typeof(Magnifier), (PropertyMetadata)(object)new UIPropertyMetadata(FrameType.Circle, new PropertyChangedCallback(OnFrameTypeChanged)));
		IsUsingZoomOnMouseWheelProperty = DependencyProperty.Register("IsUsingZoomOnMouseWheel", typeof(bool), typeof(Magnifier), (PropertyMetadata)(object)new UIPropertyMetadata((object)true));
		RadiusProperty = DependencyProperty.Register("Radius", typeof(double), typeof(Magnifier), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)50.0, new PropertyChangedCallback(OnRadiusPropertyChanged)));
		TargetProperty = DependencyProperty.Register("Target", typeof(UIElement), typeof(Magnifier));
		ZoomFactorProperty = DependencyProperty.Register("ZoomFactor", typeof(double), typeof(Magnifier), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.5, new PropertyChangedCallback(OnZoomFactorPropertyChanged)), new ValidateValueCallback(OnValidationCallback));
		ZoomFactorOnMouseWheelProperty = DependencyProperty.Register("ZoomFactorOnMouseWheel", typeof(double), typeof(Magnifier), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.1, new PropertyChangedCallback(OnZoomFactorOnMouseWheelPropertyChanged)), new ValidateValueCallback(OnZoomFactorOnMouseWheelValidationCallback));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(Magnifier), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(Magnifier)));
		FrameworkElement.HeightProperty.OverrideMetadata(typeof(Magnifier), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)100.0));
		FrameworkElement.WidthProperty.OverrideMetadata(typeof(Magnifier), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)100.0));
	}

	public Magnifier()
	{
		base.SizeChanged += OnSizeChangedEvent;
	}

	private void OnSizeChangedEvent(object sender, SizeChangedEventArgs e)
	{
		UpdateViewBox();
	}

	private void UpdateSizeFromRadius()
	{
		if (FrameType == FrameType.Circle)
		{
			double num = Radius * 2.0;
			if (!DoubleHelper.AreVirtuallyEqual(base.Width, num))
			{
				base.Width = num;
			}
			if (!DoubleHelper.AreVirtuallyEqual(base.Height, num))
			{
				base.Height = num;
			}
		}
	}

	public override void OnApplyTemplate()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		base.OnApplyTemplate();
		VisualBrush visualBrush = GetTemplateChild("PART_VisualBrush") as VisualBrush;
		if (visualBrush == null)
		{
			visualBrush = new VisualBrush();
		}
		visualBrush.Viewbox = _visualBrush.Viewbox;
		_visualBrush = visualBrush;
	}

	public void Freeze(bool freeze)
	{
		IsFrozen = freeze;
	}

	private void UpdateViewBox()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		if (base.IsInitialized)
		{
			Rect viewBox = ViewBox;
			ViewBox = new Rect(((Rect)(ref viewBox)).Location, new Size(base.ActualWidth * ZoomFactor, base.ActualHeight * ZoomFactor));
		}
	}
}
