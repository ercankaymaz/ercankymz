using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_IncreaseButton", Type = typeof(ButtonBase))]
[TemplatePart(Name = "PART_DecreaseButton", Type = typeof(ButtonBase))]
[ContentProperty("Content")]
public class ButtonSpinner : Spinner
{
	private const string PART_IncreaseButton = "PART_IncreaseButton";

	private const string PART_DecreaseButton = "PART_DecreaseButton";

	public static readonly DependencyProperty AllowSpinProperty;

	[Obsolete("ButtonSpinnerLocation is obsolete. Use SpinnerLocation instead.")]
	public static readonly DependencyProperty ButtonSpinnerLocationProperty;

	public static readonly DependencyProperty SpinnerLocationProperty;

	public static readonly DependencyProperty SpinnerWidthProperty;

	public static readonly DependencyProperty SpinnerHeightProperty;

	public static readonly DependencyProperty SpinnerDownContentTemplateProperty;

	public static readonly DependencyProperty SpinnerDownDisabledContentTemplateProperty;

	public static readonly DependencyProperty SpinnerUpContentTemplateProperty;

	public static readonly DependencyProperty SpinnerUpDisabledContentTemplateProperty;

	public static readonly DependencyProperty ContentProperty;

	[Obsolete("ShowButtonSpinner is obsolete. Use ShowSpinner instead.")]
	public static readonly DependencyProperty ShowButtonSpinnerProperty;

	public static readonly DependencyProperty ShowSpinnerProperty;

	private ButtonBase _decreaseButton;

	private ButtonBase _increaseButton;

	public bool AllowSpin
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AllowSpinProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AllowSpinProperty, (object)value);
		}
	}

	[Obsolete("ButtonSpinnerLocation is obsolete. Use SpinnerLocation instead.")]
	public Location ButtonSpinnerLocation
	{
		get
		{
			return (Location)((DependencyObject)this).GetValue(ButtonSpinnerLocationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ButtonSpinnerLocationProperty, (object)value);
		}
	}

	public Location SpinnerLocation
	{
		get
		{
			return (Location)((DependencyObject)this).GetValue(SpinnerLocationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SpinnerLocationProperty, (object)value);
		}
	}

	public double SpinnerWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(SpinnerWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SpinnerWidthProperty, (object)value);
		}
	}

	public double SpinnerHeight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(SpinnerHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SpinnerHeightProperty, (object)value);
		}
	}

	public DataTemplate SpinnerDownContentTemplate
	{
		get
		{
			return (DataTemplate)((DependencyObject)this).GetValue(SpinnerDownContentTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SpinnerDownContentTemplateProperty, (object)value);
		}
	}

	public DataTemplate SpinnerDownDisabledContentTemplate
	{
		get
		{
			return (DataTemplate)((DependencyObject)this).GetValue(SpinnerDownDisabledContentTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SpinnerDownDisabledContentTemplateProperty, (object)value);
		}
	}

	public DataTemplate SpinnerUpContentTemplate
	{
		get
		{
			return (DataTemplate)((DependencyObject)this).GetValue(SpinnerUpContentTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SpinnerUpContentTemplateProperty, (object)value);
		}
	}

	public DataTemplate SpinnerUpDisabledContentTemplate
	{
		get
		{
			return (DataTemplate)((DependencyObject)this).GetValue(SpinnerUpDisabledContentTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SpinnerUpDisabledContentTemplateProperty, (object)value);
		}
	}

	public object Content
	{
		get
		{
			return ((DependencyObject)this).GetValue(ContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ContentProperty, value);
		}
	}

	[Obsolete("ShowButtonSpinner is obsolete. Use ShowSpinner instead.")]
	public bool ShowButtonSpinner
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowButtonSpinnerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowButtonSpinnerProperty, (object)value);
		}
	}

	public bool ShowSpinner
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowSpinnerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowSpinnerProperty, (object)value);
		}
	}

	private ButtonBase DecreaseButton
	{
		get
		{
			return _decreaseButton;
		}
		set
		{
			if (_decreaseButton != null)
			{
				_decreaseButton.Click -= OnButtonClick;
			}
			_decreaseButton = value;
			if (_decreaseButton != null)
			{
				_decreaseButton.Click += OnButtonClick;
			}
		}
	}

	private ButtonBase IncreaseButton
	{
		get
		{
			return _increaseButton;
		}
		set
		{
			if (_increaseButton != null)
			{
				_increaseButton.Click -= OnButtonClick;
			}
			_increaseButton = value;
			if (_increaseButton != null)
			{
				_increaseButton.Click += OnButtonClick;
			}
		}
	}

	private static void AllowSpinPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as ButtonSpinner).OnAllowSpinChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnContentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as ButtonSpinner).OnContentChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	static ButtonSpinner()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		AllowSpinProperty = DependencyProperty.Register("AllowSpin", typeof(bool), typeof(ButtonSpinner), (PropertyMetadata)(object)new UIPropertyMetadata(true, new PropertyChangedCallback(AllowSpinPropertyChanged)));
		ButtonSpinnerLocationProperty = DependencyProperty.Register("ButtonSpinnerLocation", typeof(Location), typeof(ButtonSpinner), (PropertyMetadata)(object)new UIPropertyMetadata((object)Location.Right));
		SpinnerLocationProperty = DependencyProperty.Register("SpinnerLocation", typeof(Location), typeof(ButtonSpinner), (PropertyMetadata)(object)new UIPropertyMetadata((object)Location.Right));
		SpinnerWidthProperty = DependencyProperty.Register("SpinnerWidth", typeof(double), typeof(ButtonSpinner), (PropertyMetadata)(object)new UIPropertyMetadata((object)SystemParameters.VerticalScrollBarWidth));
		SpinnerHeightProperty = DependencyProperty.Register("SpinnerHeight", typeof(double), typeof(ButtonSpinner), (PropertyMetadata)(object)new UIPropertyMetadata((object)double.NaN));
		SpinnerDownContentTemplateProperty = DependencyProperty.Register("SpinnerDownContentTemplate", typeof(DataTemplate), typeof(ButtonSpinner), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		SpinnerDownDisabledContentTemplateProperty = DependencyProperty.Register("SpinnerDownDisabledContentTemplate", typeof(DataTemplate), typeof(ButtonSpinner), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		SpinnerUpContentTemplateProperty = DependencyProperty.Register("SpinnerUpContentTemplate", typeof(DataTemplate), typeof(ButtonSpinner), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		SpinnerUpDisabledContentTemplateProperty = DependencyProperty.Register("SpinnerUpDisabledContentTemplate", typeof(DataTemplate), typeof(ButtonSpinner), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		ContentProperty = DependencyProperty.Register("Content", typeof(object), typeof(ButtonSpinner), new PropertyMetadata((object)null, new PropertyChangedCallback(OnContentPropertyChanged)));
		ShowButtonSpinnerProperty = DependencyProperty.Register("ShowButtonSpinner", typeof(bool), typeof(ButtonSpinner), (PropertyMetadata)(object)new UIPropertyMetadata((object)true));
		ShowSpinnerProperty = DependencyProperty.Register("ShowSpinner", typeof(bool), typeof(ButtonSpinner), (PropertyMetadata)(object)new UIPropertyMetadata((object)true));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ButtonSpinner), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(ButtonSpinner)));
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		IncreaseButton = GetTemplateChild("PART_IncreaseButton") as ButtonBase;
		DecreaseButton = GetTemplateChild("PART_DecreaseButton") as ButtonBase;
		SetButtonUsage();
	}

	protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		base.OnMouseLeftButtonUp(e);
		Point position;
		if (IncreaseButton != null && !IncreaseButton.IsEnabled)
		{
			position = e.GetPosition(IncreaseButton);
			if (((Point)(ref position)).X > 0.0 && ((Point)(ref position)).X < IncreaseButton.ActualWidth && ((Point)(ref position)).Y > 0.0 && ((Point)(ref position)).Y < IncreaseButton.ActualHeight)
			{
				e.Handled = true;
			}
		}
		if (DecreaseButton != null && !DecreaseButton.IsEnabled)
		{
			position = e.GetPosition(DecreaseButton);
			if (((Point)(ref position)).X > 0.0 && ((Point)(ref position)).X < DecreaseButton.ActualWidth && ((Point)(ref position)).Y > 0.0 && ((Point)(ref position)).Y < DecreaseButton.ActualHeight)
			{
				e.Handled = true;
			}
		}
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Invalid comparison between Unknown and I4
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Invalid comparison between Unknown and I4
		Key key = e.Key;
		if ((int)key != 6)
		{
			if ((int)key != 24)
			{
				if ((int)key == 26 && AllowSpin)
				{
					OnSpin(new SpinEventArgs(Spinner.SpinnerSpinEvent, SpinDirection.Decrease));
					e.Handled = true;
				}
			}
			else if (AllowSpin)
			{
				OnSpin(new SpinEventArgs(Spinner.SpinnerSpinEvent, SpinDirection.Increase));
				e.Handled = true;
			}
		}
		else if ((IncreaseButton != null && IncreaseButton.IsFocused) || (DecreaseButton != null && DecreaseButton.IsFocused))
		{
			e.Handled = true;
		}
	}

	protected override void OnMouseWheel(MouseWheelEventArgs e)
	{
		base.OnMouseWheel(e);
		if (!e.Handled && AllowSpin && e.Delta != 0)
		{
			SpinEventArgs e2 = new SpinEventArgs(Spinner.SpinnerSpinEvent, (e.Delta < 0) ? SpinDirection.Decrease : SpinDirection.Increase, usingMouseWheel: true);
			OnSpin(e2);
			e.Handled = e2.Handled;
		}
	}

	protected override void OnValidSpinDirectionChanged(ValidSpinDirections oldValue, ValidSpinDirections newValue)
	{
		SetButtonUsage();
	}

	private void OnButtonClick(object sender, RoutedEventArgs e)
	{
		if (AllowSpin)
		{
			SpinDirection direction = ((sender != IncreaseButton) ? SpinDirection.Decrease : SpinDirection.Increase);
			OnSpin(new SpinEventArgs(Spinner.SpinnerSpinEvent, direction));
		}
	}

	protected virtual void OnContentChanged(object oldValue, object newValue)
	{
	}

	protected virtual void OnAllowSpinChanged(bool oldValue, bool newValue)
	{
		SetButtonUsage();
	}

	private void SetButtonUsage()
	{
		if (IncreaseButton != null)
		{
			IncreaseButton.IsEnabled = AllowSpin && (base.ValidSpinDirection & ValidSpinDirections.Increase) == ValidSpinDirections.Increase;
		}
		if (DecreaseButton != null)
		{
			DecreaseButton.IsEnabled = AllowSpin && (base.ValidSpinDirection & ValidSpinDirections.Decrease) == ValidSpinDirections.Decrease;
		}
	}
}
