using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_LowerRange", Type = typeof(RepeatButton))]
[TemplatePart(Name = "PART_HigherRange", Type = typeof(RepeatButton))]
[TemplatePart(Name = "PART_HigherSlider", Type = typeof(Slider))]
[TemplatePart(Name = "PART_LowerSlider", Type = typeof(Slider))]
[TemplatePart(Name = "PART_Track", Type = typeof(Track))]
public class RangeSlider : Control
{
	private struct CoercedValues
	{
		public double Minimum;

		public double Maximum;

		public double LowerValue;

		public double HigherValue;
	}

	private const string PART_LowerRange = "PART_LowerRange";

	private const string PART_Range = "PART_Range";

	private const string PART_HigherRange = "PART_HigherRange";

	private const string PART_HigherSlider = "PART_HigherSlider";

	private const string PART_LowerSlider = "PART_LowerSlider";

	private const string PART_Track = "PART_Track";

	private RepeatButton _lowerRange;

	private RepeatButton _higherRange;

	private Slider _lowerSlider;

	private Slider _higherSlider;

	private Track _lowerTrack;

	private Track _higherTrack;

	private double? _deferredUpdateValue;

	public static readonly DependencyProperty AutoToolTipPlacementProperty;

	public static readonly DependencyProperty AutoToolTipPrecisionProperty;

	public static readonly DependencyProperty HigherRangeBackgroundProperty;

	public static readonly DependencyProperty HigherRangeStyleProperty;

	private static readonly DependencyPropertyKey HigherRangeWidthPropertyKey;

	public static readonly DependencyProperty HigherRangeWidthProperty;

	public static readonly DependencyProperty HigherThumbBackgroundProperty;

	public static readonly DependencyProperty HigherValueProperty;

	public static readonly DependencyProperty IsDeferredUpdateValuesProperty;

	public static readonly DependencyProperty IsSnapToTickEnabledProperty;

	public static readonly DependencyProperty LowerRangeBackgroundProperty;

	public static readonly DependencyProperty LowerRangeStyleProperty;

	private static DependencyPropertyKey LowerRangeWidthPropertyKey;

	public static readonly DependencyProperty LowerRangeWidthProperty;

	public static readonly DependencyProperty LowerThumbBackgroundProperty;

	public static readonly DependencyProperty LowerValueProperty;

	public static readonly DependencyProperty MaximumProperty;

	public static readonly DependencyProperty MinimumProperty;

	public static readonly DependencyProperty OrientationProperty;

	public static readonly DependencyProperty RangeBackgroundProperty;

	public static readonly DependencyProperty RangeStyleProperty;

	private static readonly DependencyPropertyKey RangeWidthPropertyKey;

	public static readonly DependencyProperty RangeWidthProperty;

	private static readonly DependencyProperty StepProperty;

	public static readonly DependencyProperty TickFrequencyProperty;

	public static readonly DependencyProperty TickPlacementProperty;

	public static readonly RoutedEvent LowerValueChangedEvent;

	public static readonly RoutedEvent HigherValueChangedEvent;

	public AutoToolTipPlacement AutoToolTipPlacement
	{
		get
		{
			return (AutoToolTipPlacement)((DependencyObject)this).GetValue(AutoToolTipPlacementProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoToolTipPlacementProperty, (object)value);
		}
	}

	public int AutoToolTipPrecision
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(AutoToolTipPrecisionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoToolTipPrecisionProperty, (object)value);
		}
	}

	public Brush HigherRangeBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(HigherRangeBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HigherRangeBackgroundProperty, (object)value);
		}
	}

	public Style HigherRangeStyle
	{
		get
		{
			return (Style)((DependencyObject)this).GetValue(HigherRangeStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HigherRangeStyleProperty, (object)value);
		}
	}

	public double HigherRangeWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(HigherRangeWidthProperty);
		}
		private set
		{
			((DependencyObject)this).SetValue(HigherRangeWidthPropertyKey, (object)value);
		}
	}

	public Brush HigherThumbBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(HigherThumbBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HigherThumbBackgroundProperty, (object)value);
		}
	}

	public double HigherValue
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(HigherValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HigherValueProperty, (object)value);
		}
	}

	public bool IsDeferredUpdateValues
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsDeferredUpdateValuesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsDeferredUpdateValuesProperty, (object)value);
		}
	}

	public bool IsSnapToTickEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsSnapToTickEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsSnapToTickEnabledProperty, (object)value);
		}
	}

	public Brush LowerRangeBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(LowerRangeBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LowerRangeBackgroundProperty, (object)value);
		}
	}

	public Style LowerRangeStyle
	{
		get
		{
			return (Style)((DependencyObject)this).GetValue(LowerRangeStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LowerRangeStyleProperty, (object)value);
		}
	}

	public double LowerRangeWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(LowerRangeWidthProperty);
		}
		private set
		{
			((DependencyObject)this).SetValue(LowerRangeWidthPropertyKey, (object)value);
		}
	}

	public Brush LowerThumbBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(LowerThumbBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LowerThumbBackgroundProperty, (object)value);
		}
	}

	public double LowerValue
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(LowerValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LowerValueProperty, (object)value);
		}
	}

	public double Maximum
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MaximumProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaximumProperty, (object)value);
		}
	}

	public double Minimum
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MinimumProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MinimumProperty, (object)value);
		}
	}

	public Orientation Orientation
	{
		get
		{
			return (Orientation)((DependencyObject)this).GetValue(OrientationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OrientationProperty, (object)value);
		}
	}

	public Brush RangeBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(RangeBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RangeBackgroundProperty, (object)value);
		}
	}

	public Style RangeStyle
	{
		get
		{
			return (Style)((DependencyObject)this).GetValue(RangeStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RangeStyleProperty, (object)value);
		}
	}

	public double RangeWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(RangeWidthProperty);
		}
		private set
		{
			((DependencyObject)this).SetValue(RangeWidthPropertyKey, (object)value);
		}
	}

	public double Step
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(StepProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StepProperty, (object)value);
		}
	}

	public double TickFrequency
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(TickFrequencyProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TickFrequencyProperty, (object)value);
		}
	}

	public TickPlacement TickPlacement
	{
		get
		{
			return (TickPlacement)((DependencyObject)this).GetValue(TickPlacementProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TickPlacementProperty, (object)value);
		}
	}

	public event RoutedEventHandler LowerValueChanged
	{
		add
		{
			AddHandler(LowerValueChangedEvent, value);
		}
		remove
		{
			RemoveHandler(LowerValueChangedEvent, value);
		}
	}

	public event RoutedEventHandler HigherValueChanged
	{
		add
		{
			AddHandler(HigherValueChangedEvent, value);
		}
		remove
		{
			RemoveHandler(HigherValueChangedEvent, value);
		}
	}

	static RangeSlider()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected O, but got Unknown
		//IL_016f: Expected O, but got Unknown
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Expected O, but got Unknown
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected O, but got Unknown
		//IL_02dc: Expected O, but got Unknown
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Expected O, but got Unknown
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Expected O, but got Unknown
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_037e: Expected O, but got Unknown
		//IL_0405: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Expected O, but got Unknown
		//IL_0452: Unknown result type (might be due to invalid IL or missing references)
		//IL_045c: Expected O, but got Unknown
		//IL_0457: Unknown result type (might be due to invalid IL or missing references)
		//IL_0461: Expected O, but got Unknown
		//IL_0494: Unknown result type (might be due to invalid IL or missing references)
		//IL_049e: Expected O, but got Unknown
		//IL_04ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d8: Expected O, but got Unknown
		AutoToolTipPlacementProperty = DependencyProperty.Register("AutoToolTipPlacement", typeof(AutoToolTipPlacement), typeof(RangeSlider), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)AutoToolTipPlacement.None, new PropertyChangedCallback(OnAutoToolTipPlacementChanged)));
		AutoToolTipPrecisionProperty = DependencyProperty.Register("AutoToolTipPrecision", typeof(int), typeof(RangeSlider), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0));
		HigherRangeBackgroundProperty = DependencyProperty.Register("HigherRangeBackground", typeof(Brush), typeof(RangeSlider), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.Transparent));
		HigherRangeStyleProperty = DependencyProperty.Register("HigherRangeStyle", typeof(Style), typeof(RangeSlider), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null));
		HigherRangeWidthPropertyKey = DependencyProperty.RegisterAttachedReadOnly("HigherRangeWidth", typeof(double), typeof(RangeSlider), new PropertyMetadata((object)0.0));
		HigherRangeWidthProperty = HigherRangeWidthPropertyKey.DependencyProperty;
		HigherThumbBackgroundProperty = DependencyProperty.Register("HigherThumbBackground", typeof(Brush), typeof(RangeSlider));
		HigherValueProperty = DependencyProperty.Register("HigherValue", typeof(double), typeof(RangeSlider), (PropertyMetadata)(object)new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnHigherValueChanged), new CoerceValueCallback(OnCoerceHigherValueChanged)));
		IsDeferredUpdateValuesProperty = DependencyProperty.Register("IsDeferredUpdateValues", typeof(bool), typeof(RangeSlider), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
		IsSnapToTickEnabledProperty = DependencyProperty.Register("IsSnapToTickEnabled", typeof(bool), typeof(RangeSlider), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
		LowerRangeBackgroundProperty = DependencyProperty.Register("LowerRangeBackground", typeof(Brush), typeof(RangeSlider), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.Transparent));
		LowerRangeStyleProperty = DependencyProperty.Register("LowerRangeStyle", typeof(Style), typeof(RangeSlider), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null));
		LowerRangeWidthPropertyKey = DependencyProperty.RegisterAttachedReadOnly("LowerRangeWidth", typeof(double), typeof(RangeSlider), new PropertyMetadata((object)0.0));
		LowerRangeWidthProperty = LowerRangeWidthPropertyKey.DependencyProperty;
		LowerThumbBackgroundProperty = DependencyProperty.Register("LowerThumbBackground", typeof(Brush), typeof(RangeSlider));
		LowerValueProperty = DependencyProperty.Register("LowerValue", typeof(double), typeof(RangeSlider), (PropertyMetadata)(object)new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnLowerValueChanged), new CoerceValueCallback(OnCoerceLowerValueChanged)));
		MaximumProperty = DependencyProperty.Register("Maximum", typeof(double), typeof(RangeSlider), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnMaximumChanged)));
		MinimumProperty = DependencyProperty.Register("Minimum", typeof(double), typeof(RangeSlider), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnMinimumChanged)));
		OrientationProperty = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(RangeSlider), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Orientation.Horizontal, new PropertyChangedCallback(OnOrientationChanged)));
		RangeBackgroundProperty = DependencyProperty.Register("RangeBackground", typeof(Brush), typeof(RangeSlider), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.Transparent));
		RangeStyleProperty = DependencyProperty.Register("RangeStyle", typeof(Style), typeof(RangeSlider), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null));
		RangeWidthPropertyKey = DependencyProperty.RegisterAttachedReadOnly("RangeWidth", typeof(double), typeof(RangeSlider), new PropertyMetadata((object)0.0));
		RangeWidthProperty = RangeWidthPropertyKey.DependencyProperty;
		StepProperty = DependencyProperty.Register("Step", typeof(double), typeof(RangeSlider), new PropertyMetadata((object)1.0, (PropertyChangedCallback)null, new CoerceValueCallback(CoerceStep)));
		TickFrequencyProperty = DependencyProperty.Register("TickFrequency", typeof(double), typeof(RangeSlider), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1.0, new PropertyChangedCallback(OnTickFrequencyChanged)));
		TickPlacementProperty = DependencyProperty.Register("TickPlacement", typeof(TickPlacement), typeof(RangeSlider), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)TickPlacement.None, new PropertyChangedCallback(OnTickPlacementChanged)));
		LowerValueChangedEvent = EventManager.RegisterRoutedEvent("LowerValueChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(RangeSlider));
		HigherValueChangedEvent = EventManager.RegisterRoutedEvent("HigherValueChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(RangeSlider));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(RangeSlider), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(RangeSlider)));
	}

	public RangeSlider()
	{
		base.SizeChanged += RangeSlider_SizeChanged;
	}

	private static void OnAutoToolTipPlacementChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
	{
		if (sender is RangeSlider rangeSlider)
		{
			rangeSlider.OnAutoToolTipPlacementChanged((AutoToolTipPlacement)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (AutoToolTipPlacement)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnAutoToolTipPlacementChanged(AutoToolTipPlacement oldValue, AutoToolTipPlacement newValue)
	{
	}

	private static object OnCoerceHigherValueChanged(DependencyObject d, object basevalue)
	{
		RangeSlider rangeSlider = (RangeSlider)(object)d;
		if (rangeSlider == null || !rangeSlider.IsLoaded)
		{
			return basevalue;
		}
		Math.Min(rangeSlider.Minimum, rangeSlider.Maximum);
		Math.Max(rangeSlider.Minimum, rangeSlider.Maximum);
		Math.Max(rangeSlider.Minimum, Math.Min(rangeSlider.Maximum, (double)basevalue));
		return Math.Max(rangeSlider.LowerValue, (double)basevalue);
	}

	private static void OnHigherValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		if (sender is RangeSlider rangeSlider)
		{
			rangeSlider.OnHigherValueChanged((double)((DependencyPropertyChangedEventArgs)(ref args)).OldValue, (double)((DependencyPropertyChangedEventArgs)(ref args)).NewValue);
		}
	}

	protected virtual void OnHigherValueChanged(double oldValue, double newValue)
	{
		AdjustView();
		RoutedEventArgs e = new RoutedEventArgs();
		e.RoutedEvent = HigherValueChangedEvent;
		RaiseEvent(e);
	}

	private static object OnCoerceLowerValueChanged(DependencyObject d, object basevalue)
	{
		RangeSlider rangeSlider = (RangeSlider)(object)d;
		if (rangeSlider == null || !rangeSlider.IsLoaded)
		{
			return basevalue;
		}
		Math.Min(rangeSlider.Minimum, rangeSlider.Maximum);
		Math.Max(rangeSlider.Minimum, rangeSlider.Maximum);
		Math.Max(rangeSlider.Minimum, Math.Min(rangeSlider.Maximum, (double)basevalue));
		return Math.Min((double)basevalue, rangeSlider.HigherValue);
	}

	private static void OnLowerValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		if (sender is RangeSlider rangeSlider)
		{
			rangeSlider.OnLowerValueChanged((double)((DependencyPropertyChangedEventArgs)(ref args)).OldValue, (double)((DependencyPropertyChangedEventArgs)(ref args)).NewValue);
		}
	}

	protected virtual void OnLowerValueChanged(double oldValue, double newValue)
	{
		AdjustView();
		RoutedEventArgs e = new RoutedEventArgs();
		e.RoutedEvent = LowerValueChangedEvent;
		RaiseEvent(e);
	}

	private static void OnMaximumChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		if (sender is RangeSlider rangeSlider)
		{
			rangeSlider.OnMaximumChanged((double)((DependencyPropertyChangedEventArgs)(ref args)).OldValue, (double)((DependencyPropertyChangedEventArgs)(ref args)).NewValue);
		}
	}

	protected virtual void OnMaximumChanged(double oldValue, double newValue)
	{
		AdjustView();
	}

	private static void OnMinimumChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		if (sender is RangeSlider rangeSlider)
		{
			rangeSlider.OnMinimumChanged((double)((DependencyPropertyChangedEventArgs)(ref args)).OldValue, (double)((DependencyPropertyChangedEventArgs)(ref args)).NewValue);
		}
	}

	protected virtual void OnMinimumChanged(double oldValue, double newValue)
	{
		AdjustView();
	}

	private static void OnOrientationChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
	{
		if (sender is RangeSlider rangeSlider)
		{
			rangeSlider.OnOrientationChanged((Orientation)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (Orientation)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnOrientationChanged(Orientation oldValue, Orientation newValue)
	{
	}

	private static object CoerceStep(DependencyObject sender, object value)
	{
		double val = (double)value;
		return Math.Max(0.01, val);
	}

	private static void OnTickFrequencyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		if (sender is RangeSlider rangeSlider)
		{
			rangeSlider.OnTickFrequencyChanged((double)((DependencyPropertyChangedEventArgs)(ref args)).OldValue, (double)((DependencyPropertyChangedEventArgs)(ref args)).NewValue);
		}
	}

	protected virtual void OnTickFrequencyChanged(double oldValue, double newValue)
	{
	}

	private static void OnTickPlacementChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
	{
		if (sender is RangeSlider rangeSlider)
		{
			rangeSlider.OnTickPlacementChanged((TickPlacement)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (TickPlacement)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnTickPlacementChanged(TickPlacement oldValue, TickPlacement newValue)
	{
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		if (_lowerRange != null)
		{
			_lowerRange.Click -= LowerRange_Click;
		}
		_lowerRange = base.Template.FindName("PART_LowerRange", this) as RepeatButton;
		if (_lowerRange != null)
		{
			_lowerRange.Click += LowerRange_Click;
		}
		if (_higherRange != null)
		{
			_higherRange.Click -= HigherRange_Click;
		}
		_higherRange = base.Template.FindName("PART_HigherRange", this) as RepeatButton;
		if (_higherRange != null)
		{
			_higherRange.Click += HigherRange_Click;
		}
		if (_lowerSlider != null)
		{
			_lowerSlider.Loaded -= Slider_Loaded;
			_lowerSlider.ValueChanged -= LowerSlider_ValueChanged;
			if (_lowerTrack != null)
			{
				_lowerTrack.Thumb.DragCompleted -= LowerSlider_DragCompleted;
			}
		}
		_lowerSlider = base.Template.FindName("PART_LowerSlider", this) as Slider;
		if (_lowerSlider != null)
		{
			_lowerSlider.Loaded += Slider_Loaded;
			_lowerSlider.ValueChanged += LowerSlider_ValueChanged;
			_lowerSlider.ApplyTemplate();
			_lowerTrack = _lowerSlider.Template.FindName("PART_Track", _lowerSlider) as Track;
			if (_lowerTrack != null)
			{
				_lowerTrack.Thumb.DragCompleted += LowerSlider_DragCompleted;
			}
		}
		if (_higherSlider != null)
		{
			_higherSlider.Loaded -= Slider_Loaded;
			_higherSlider.ValueChanged -= HigherSlider_ValueChanged;
			if (_higherTrack != null)
			{
				_higherTrack.Thumb.DragCompleted -= HigherSlider_DragCompleted;
			}
		}
		_higherSlider = base.Template.FindName("PART_HigherSlider", this) as Slider;
		if (_higherSlider != null)
		{
			_higherSlider.Loaded += Slider_Loaded;
			_higherSlider.ValueChanged += HigherSlider_ValueChanged;
			_higherSlider.ApplyTemplate();
			_higherTrack = _higherSlider.Template.FindName("PART_Track", _higherSlider) as Track;
			if (_higherTrack != null)
			{
				_higherTrack.Thumb.DragCompleted += HigherSlider_DragCompleted;
			}
		}
	}

	public override string ToString()
	{
		return LowerValue + "-" + HigherValue;
	}

	internal static double GetThumbWidth(Slider slider)
	{
		if (slider != null)
		{
			Track track = (Track)slider.Template.FindName("PART_Track", slider);
			if (track != null)
			{
				return track.Thumb.ActualWidth;
			}
		}
		return 0.0;
	}

	internal static double GetThumbHeight(Slider slider)
	{
		if (slider != null)
		{
			Track track = (Track)slider.Template.FindName("PART_Track", slider);
			if (track != null)
			{
				return track.Thumb.ActualHeight;
			}
		}
		return 0.0;
	}

	private void AdjustView(bool isHigherValueChanged = false)
	{
		CoercedValues coercedValues = GetCoercedValues();
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		if (Orientation == Orientation.Horizontal)
		{
			num = base.ActualWidth;
			num2 = GetThumbWidth(_lowerSlider);
			num3 = GetThumbWidth(_higherSlider);
		}
		else if (Orientation == Orientation.Vertical)
		{
			num = base.ActualHeight;
			num2 = GetThumbHeight(_lowerSlider);
			num3 = GetThumbHeight(_higherSlider);
		}
		num -= num2 + num3;
		if (!IsDeferredUpdateValues || !_deferredUpdateValue.HasValue)
		{
			SetLowerSliderValues(coercedValues.LowerValue, coercedValues.Minimum, coercedValues.Maximum);
			SetHigherSliderValues(coercedValues.HigherValue, coercedValues.Minimum, coercedValues.Maximum);
		}
		double num4 = coercedValues.Maximum - coercedValues.Minimum;
		if (num4 > 0.0)
		{
			double num5 = ((IsDeferredUpdateValues && isHigherValueChanged && _deferredUpdateValue.HasValue) ? _deferredUpdateValue.Value : coercedValues.HigherValue);
			double num6 = ((IsDeferredUpdateValues && !isHigherValueChanged && _deferredUpdateValue.HasValue) ? _deferredUpdateValue.Value : coercedValues.LowerValue);
			HigherRangeWidth = num * (coercedValues.Maximum - num5) / num4;
			RangeWidth = num * (num5 - num6) / num4;
			LowerRangeWidth = num * (num6 - coercedValues.Minimum) / num4;
		}
		else
		{
			HigherRangeWidth = 0.0;
			RangeWidth = 0.0;
			LowerRangeWidth = num;
		}
	}

	private void SetSlidersMargins()
	{
		if (_lowerSlider != null && _higherSlider != null)
		{
			if (Orientation == Orientation.Horizontal)
			{
				double thumbWidth = GetThumbWidth(_lowerSlider);
				double thumbWidth2 = GetThumbWidth(_higherSlider);
				_higherSlider.Margin = new Thickness(thumbWidth, 0.0, 0.0, 0.0);
				_lowerSlider.Margin = new Thickness(0.0, 0.0, thumbWidth2, 0.0);
			}
			else
			{
				double thumbHeight = GetThumbHeight(_lowerSlider);
				double thumbHeight2 = GetThumbHeight(_higherSlider);
				_higherSlider.Margin = new Thickness(0.0, 0.0, 0.0, thumbHeight);
				_lowerSlider.Margin = new Thickness(0.0, thumbHeight2, 0.0, 0.0);
			}
		}
	}

	private CoercedValues GetCoercedValues()
	{
		CoercedValues result = default(CoercedValues);
		result.Minimum = Math.Min(Minimum, Maximum);
		result.Maximum = Math.Max(result.Minimum, Maximum);
		result.LowerValue = Math.Max(result.Minimum, Math.Min(result.Maximum, LowerValue));
		result.HigherValue = Math.Max(result.Minimum, Math.Min(result.Maximum, HigherValue));
		result.HigherValue = Math.Max(result.LowerValue, result.HigherValue);
		return result;
	}

	private void SetLowerSliderValues(double value, double? minimum, double? maximum)
	{
		SetSliderValues(_lowerSlider, LowerSlider_ValueChanged, value, minimum, maximum);
	}

	private void SetHigherSliderValues(double value, double? minimum, double? maximum)
	{
		SetSliderValues(_higherSlider, HigherSlider_ValueChanged, value, minimum, maximum);
	}

	private void SetSliderValues(Slider slider, RoutedPropertyChangedEventHandler<double> handler, double value, double? minimum, double? maximum)
	{
		if (slider != null)
		{
			slider.ValueChanged -= handler;
			slider.Value = value;
			if (minimum.HasValue)
			{
				slider.Minimum = minimum.Value;
			}
			if (maximum.HasValue)
			{
				slider.Maximum = maximum.Value;
			}
			slider.ValueChanged += handler;
		}
	}

	private void UpdateHigherValue(double? value)
	{
		CoercedValues coercedValues = GetCoercedValues();
		double val = Math.Max(coercedValues.Minimum, Math.Min(coercedValues.Maximum, value.HasValue ? value.Value : 0.0));
		val = Math.Max(val, coercedValues.LowerValue);
		SetHigherSliderValues(val, null, null);
		HigherValue = val;
	}

	private void UpdateLowerValue(double? value)
	{
		CoercedValues coercedValues = GetCoercedValues();
		double val = Math.Max(coercedValues.Minimum, Math.Min(coercedValues.Maximum, value.HasValue ? value.Value : 0.0));
		val = Math.Min(val, coercedValues.HigherValue);
		SetLowerSliderValues(val, null, null);
		LowerValue = val;
	}

	private void LowerRange_Click(object sender, RoutedEventArgs e)
	{
		CoercedValues coercedValues = GetCoercedValues();
		if (coercedValues.Minimum < coercedValues.Maximum)
		{
			double val = coercedValues.LowerValue - Step;
			LowerValue = Math.Min(coercedValues.Maximum, Math.Max(coercedValues.Minimum, val));
		}
	}

	private void HigherRange_Click(object sender, RoutedEventArgs e)
	{
		CoercedValues coercedValues = GetCoercedValues();
		if (coercedValues.Minimum < coercedValues.Maximum)
		{
			double val = coercedValues.HigherValue + Step;
			HigherValue = Math.Min(coercedValues.Maximum, Math.Max(coercedValues.Minimum, val));
		}
	}

	private void RangeSlider_SizeChanged(object sender, SizeChangedEventArgs e)
	{
		AdjustView();
	}

	private void Slider_Loaded(object sender, RoutedEventArgs e)
	{
		SetSlidersMargins();
		AdjustView();
	}

	private void LowerSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
	{
		if (_lowerSlider != null && _lowerSlider.IsLoaded)
		{
			if (!IsDeferredUpdateValues)
			{
				UpdateLowerValue(e.NewValue);
				return;
			}
			_deferredUpdateValue = e.NewValue;
			AdjustView();
		}
	}

	private void HigherSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
	{
		if (_higherSlider != null && _higherSlider.IsLoaded)
		{
			if (!IsDeferredUpdateValues)
			{
				UpdateHigherValue(e.NewValue);
				return;
			}
			_deferredUpdateValue = e.NewValue;
			AdjustView(isHigherValueChanged: true);
		}
	}

	private void HigherSlider_DragCompleted(object sender, DragCompletedEventArgs e)
	{
		if (IsDeferredUpdateValues)
		{
			UpdateHigherValue(_deferredUpdateValue);
			_deferredUpdateValue = null;
			AdjustView();
		}
	}

	private void LowerSlider_DragCompleted(object sender, DragCompletedEventArgs e)
	{
		if (IsDeferredUpdateValues)
		{
			UpdateLowerValue(_deferredUpdateValue);
			_deferredUpdateValue = null;
			AdjustView();
		}
	}
}
