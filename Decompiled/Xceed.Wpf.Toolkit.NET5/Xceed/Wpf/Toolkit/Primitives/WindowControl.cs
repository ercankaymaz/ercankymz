using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Xceed.Wpf.Toolkit.Primitives;

[TemplatePart(Name = "PART_HeaderThumb", Type = typeof(Thumb))]
[TemplatePart(Name = "PART_Icon", Type = typeof(Image))]
[TemplatePart(Name = "PART_CloseButton", Type = typeof(Button))]
[TemplatePart(Name = "PART_ToolWindowCloseButton", Type = typeof(Button))]
[TemplatePart(Name = "PART_BlockMouseInputsBorder", Type = typeof(Border))]
[TemplatePart(Name = "PART_HeaderGrid", Type = typeof(Grid))]
public class WindowControl : ContentControl
{
	public static readonly ComponentResourceKey DefaultCloseButtonStyleKey;

	private const string PART_HeaderThumb = "PART_HeaderThumb";

	private const string PART_Icon = "PART_Icon";

	private const string PART_CloseButton = "PART_CloseButton";

	private const string PART_ToolWindowCloseButton = "PART_ToolWindowCloseButton";

	private const string PART_BlockMouseInputsBorder = "PART_BlockMouseInputsBorder";

	private const string PART_HeaderGrid = "PART_HeaderGrid";

	private Thumb _headerThumb;

	private Image _icon;

	private Button _closeButton;

	private Button _windowToolboxCloseButton;

	private bool _setIsActiveInternal;

	internal Border _windowBlockMouseInputsPanel;

	public static readonly DependencyProperty CaptionProperty;

	public static readonly DependencyProperty CaptionFontSizeProperty;

	public static readonly DependencyProperty CaptionForegroundProperty;

	public static readonly DependencyProperty CaptionShadowBrushProperty;

	public static readonly DependencyProperty CaptionIconProperty;

	public static readonly DependencyProperty CloseButtonStyleProperty;

	public static readonly DependencyProperty CloseButtonVisibilityProperty;

	public static readonly DependencyProperty IsActiveProperty;

	public static readonly DependencyProperty LeftProperty;

	public static readonly DependencyProperty TopProperty;

	public static readonly DependencyProperty WindowBackgroundProperty;

	public static readonly DependencyProperty WindowBorderBrushProperty;

	public static readonly DependencyProperty WindowBorderThicknessProperty;

	public static readonly DependencyProperty WindowInactiveBackgroundProperty;

	public static readonly DependencyProperty WindowOpacityProperty;

	public static readonly DependencyProperty WindowStyleProperty;

	public static readonly DependencyProperty WindowThicknessProperty;

	private bool _IsBlockMouseInputsPanelActive;

	public static readonly RoutedEvent ActivatedEvent;

	public static readonly RoutedEvent HeaderMouseLeftButtonClickedEvent;

	public static readonly RoutedEvent HeaderMouseRightButtonClickedEvent;

	public static readonly RoutedEvent HeaderMouseLeftButtonDoubleClickedEvent;

	public static readonly RoutedEvent HeaderDragDeltaEvent;

	public static readonly RoutedEvent HeaderIconClickedEvent;

	public static readonly RoutedEvent HeaderIconDoubleClickedEvent;

	public static readonly RoutedEvent CloseButtonClickedEvent;

	public string Caption
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(CaptionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CaptionProperty, (object)value);
		}
	}

	public double CaptionFontSize
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(CaptionFontSizeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CaptionFontSizeProperty, (object)value);
		}
	}

	public Brush CaptionForeground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(CaptionForegroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CaptionForegroundProperty, (object)value);
		}
	}

	public Brush CaptionShadowBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(CaptionShadowBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CaptionShadowBrushProperty, (object)value);
		}
	}

	public ImageSource CaptionIcon
	{
		get
		{
			return (ImageSource)((DependencyObject)this).GetValue(CaptionIconProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CaptionIconProperty, (object)value);
		}
	}

	public Style CloseButtonStyle
	{
		get
		{
			return (Style)((DependencyObject)this).GetValue(CloseButtonStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CloseButtonStyleProperty, (object)value);
		}
	}

	public Visibility CloseButtonVisibility
	{
		get
		{
			return (Visibility)((DependencyObject)this).GetValue(CloseButtonVisibilityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CloseButtonVisibilityProperty, (object)value);
		}
	}

	public bool IsActive
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsActiveProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsActiveProperty, (object)value);
		}
	}

	public double Left
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(LeftProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LeftProperty, (object)value);
		}
	}

	public double Top
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(TopProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TopProperty, (object)value);
		}
	}

	public Brush WindowBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(WindowBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WindowBackgroundProperty, (object)value);
		}
	}

	public Brush WindowBorderBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(WindowBorderBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WindowBorderBrushProperty, (object)value);
		}
	}

	public Thickness WindowBorderThickness
	{
		get
		{
			return (Thickness)((DependencyObject)this).GetValue(WindowBorderThicknessProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WindowBorderThicknessProperty, (object)value);
		}
	}

	public Brush WindowInactiveBackground
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(WindowInactiveBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WindowInactiveBackgroundProperty, (object)value);
		}
	}

	public double WindowOpacity
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(WindowOpacityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WindowOpacityProperty, (object)value);
		}
	}

	public WindowStyle WindowStyle
	{
		get
		{
			return (WindowStyle)((DependencyObject)this).GetValue(WindowStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WindowStyleProperty, (object)value);
		}
	}

	public Thickness WindowThickness
	{
		get
		{
			return (Thickness)((DependencyObject)this).GetValue(WindowThicknessProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WindowThicknessProperty, (object)value);
		}
	}

	internal bool IsStartupPositionInitialized { get; set; }

	internal bool IsBlockMouseInputsPanelActive
	{
		get
		{
			return _IsBlockMouseInputsPanelActive;
		}
		set
		{
			if (value != _IsBlockMouseInputsPanelActive)
			{
				_IsBlockMouseInputsPanelActive = value;
				UpdateBlockMouseInputsPanel();
			}
		}
	}

	internal virtual bool AllowPublicIsActiveChange => true;

	internal event EventHandler<EventArgs> LeftChanged;

	internal event EventHandler<EventArgs> TopChanged;

	public event RoutedEventHandler Activated
	{
		add
		{
			AddHandler(ActivatedEvent, value);
		}
		remove
		{
			RemoveHandler(ActivatedEvent, value);
		}
	}

	public event MouseButtonEventHandler HeaderMouseLeftButtonClicked
	{
		add
		{
			AddHandler(HeaderMouseLeftButtonClickedEvent, value);
		}
		remove
		{
			RemoveHandler(HeaderMouseLeftButtonClickedEvent, value);
		}
	}

	public event MouseButtonEventHandler HeaderMouseRightButtonClicked
	{
		add
		{
			AddHandler(HeaderMouseRightButtonClickedEvent, value);
		}
		remove
		{
			RemoveHandler(HeaderMouseRightButtonClickedEvent, value);
		}
	}

	public event MouseButtonEventHandler HeaderMouseLeftButtonDoubleClicked
	{
		add
		{
			AddHandler(HeaderMouseLeftButtonDoubleClickedEvent, value);
		}
		remove
		{
			RemoveHandler(HeaderMouseLeftButtonDoubleClickedEvent, value);
		}
	}

	public event DragDeltaEventHandler HeaderDragDelta
	{
		add
		{
			AddHandler(HeaderDragDeltaEvent, value);
		}
		remove
		{
			RemoveHandler(HeaderDragDeltaEvent, value);
		}
	}

	public event MouseButtonEventHandler HeaderIconClicked
	{
		add
		{
			AddHandler(HeaderIconClickedEvent, value);
		}
		remove
		{
			RemoveHandler(HeaderIconClickedEvent, value);
		}
	}

	public event MouseButtonEventHandler HeaderIconDoubleClicked
	{
		add
		{
			AddHandler(HeaderIconDoubleClickedEvent, value);
		}
		remove
		{
			RemoveHandler(HeaderIconDoubleClickedEvent, value);
		}
	}

	public event RoutedEventHandler CloseButtonClicked
	{
		add
		{
			AddHandler(CloseButtonClickedEvent, value);
		}
		remove
		{
			RemoveHandler(CloseButtonClickedEvent, value);
		}
	}

	static WindowControl()
	{
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Expected O, but got Unknown
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_01b4: Expected O, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Expected O, but got Unknown
		//IL_0202: Expected O, but got Unknown
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected O, but got Unknown
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Expected O, but got Unknown
		//IL_0250: Expected O, but got Unknown
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected O, but got Unknown
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Expected O, but got Unknown
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Expected O, but got Unknown
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Expected O, but got Unknown
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Expected O, but got Unknown
		//IL_0337: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Expected O, but got Unknown
		//IL_036d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0377: Expected O, but got Unknown
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Expected O, but got Unknown
		//IL_03e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ea: Expected O, but got Unknown
		DefaultCloseButtonStyleKey = new ComponentResourceKey(typeof(WindowControl), "DefaultCloseButtonStyle");
		CaptionProperty = DependencyProperty.Register("Caption", typeof(string), typeof(WindowControl), (PropertyMetadata)(object)new UIPropertyMetadata((object)string.Empty));
		CaptionFontSizeProperty = DependencyProperty.Register("CaptionFontSize", typeof(double), typeof(WindowControl), (PropertyMetadata)(object)new UIPropertyMetadata((object)15.0));
		CaptionForegroundProperty = DependencyProperty.Register("CaptionForeground", typeof(Brush), typeof(WindowControl), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		CaptionShadowBrushProperty = DependencyProperty.Register("CaptionShadowBrush", typeof(Brush), typeof(WindowControl), (PropertyMetadata)(object)new UIPropertyMetadata((object)new SolidColorBrush(Color.FromArgb(179, byte.MaxValue, byte.MaxValue, byte.MaxValue))));
		CaptionIconProperty = DependencyProperty.Register("CaptionIcon", typeof(ImageSource), typeof(WindowControl), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		CloseButtonStyleProperty = DependencyProperty.Register("CloseButtonStyle", typeof(Style), typeof(WindowControl), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		CloseButtonVisibilityProperty = DependencyProperty.Register("CloseButtonVisibility", typeof(Visibility), typeof(WindowControl), new PropertyMetadata((object)Visibility.Visible, (PropertyChangedCallback)null, new CoerceValueCallback(OnCoerceCloseButtonVisibility)));
		IsActiveProperty = DependencyProperty.Register("IsActive", typeof(bool), typeof(WindowControl), (PropertyMetadata)(object)new UIPropertyMetadata(true, new PropertyChangedCallback(OnIsActiveChanged), new CoerceValueCallback(OnCoerceIsActive)));
		LeftProperty = DependencyProperty.Register("Left", typeof(double), typeof(WindowControl), new PropertyMetadata((object)0.0, new PropertyChangedCallback(OnLeftPropertyChanged), new CoerceValueCallback(OnCoerceLeft)));
		TopProperty = DependencyProperty.Register("Top", typeof(double), typeof(WindowControl), new PropertyMetadata((object)0.0, new PropertyChangedCallback(OnTopPropertyChanged), new CoerceValueCallback(OnCoerceTop)));
		WindowBackgroundProperty = DependencyProperty.Register("WindowBackground", typeof(Brush), typeof(WindowControl), new PropertyMetadata((PropertyChangedCallback)null));
		WindowBorderBrushProperty = DependencyProperty.Register("WindowBorderBrush", typeof(Brush), typeof(WindowControl), new PropertyMetadata((PropertyChangedCallback)null));
		WindowBorderThicknessProperty = DependencyProperty.Register("WindowBorderThickness", typeof(Thickness), typeof(WindowControl), new PropertyMetadata((object)new Thickness(0.0)));
		WindowInactiveBackgroundProperty = DependencyProperty.Register("WindowInactiveBackground", typeof(Brush), typeof(WindowControl), new PropertyMetadata((PropertyChangedCallback)null));
		WindowOpacityProperty = DependencyProperty.Register("WindowOpacity", typeof(double), typeof(WindowControl), new PropertyMetadata((object)1.0));
		WindowStyleProperty = DependencyProperty.Register("WindowStyle", typeof(WindowStyle), typeof(WindowControl), new PropertyMetadata((object)WindowStyle.SingleBorderWindow, (PropertyChangedCallback)null, new CoerceValueCallback(OnCoerceWindowStyle)));
		WindowThicknessProperty = DependencyProperty.Register("WindowThickness", typeof(Thickness), typeof(WindowControl), new PropertyMetadata((object)new Thickness(SystemParameters.ResizeFrameVerticalBorderWidth - 3.0, SystemParameters.ResizeFrameHorizontalBorderHeight - 3.0, SystemParameters.ResizeFrameVerticalBorderWidth - 3.0, SystemParameters.ResizeFrameHorizontalBorderHeight - 3.0)));
		ActivatedEvent = EventManager.RegisterRoutedEvent("Activated", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(WindowControl));
		HeaderMouseLeftButtonClickedEvent = EventManager.RegisterRoutedEvent("HeaderMouseLeftButtonClicked", RoutingStrategy.Bubble, typeof(MouseButtonEventHandler), typeof(WindowControl));
		HeaderMouseRightButtonClickedEvent = EventManager.RegisterRoutedEvent("HeaderMouseRightButtonClicked", RoutingStrategy.Bubble, typeof(MouseButtonEventHandler), typeof(WindowControl));
		HeaderMouseLeftButtonDoubleClickedEvent = EventManager.RegisterRoutedEvent("HeaderMouseLeftButtonDoubleClicked", RoutingStrategy.Bubble, typeof(MouseButtonEventHandler), typeof(WindowControl));
		HeaderDragDeltaEvent = EventManager.RegisterRoutedEvent("HeaderDragDelta", RoutingStrategy.Bubble, typeof(DragDeltaEventHandler), typeof(WindowControl));
		HeaderIconClickedEvent = EventManager.RegisterRoutedEvent("HeaderIconClicked", RoutingStrategy.Bubble, typeof(MouseButtonEventHandler), typeof(WindowControl));
		HeaderIconDoubleClickedEvent = EventManager.RegisterRoutedEvent("HeaderIconDoubleClicked", RoutingStrategy.Bubble, typeof(MouseButtonEventHandler), typeof(WindowControl));
		CloseButtonClickedEvent = EventManager.RegisterRoutedEvent("CloseButtonClicked", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(WindowControl));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(WindowControl)));
	}

	private static object OnCoerceCloseButtonVisibility(DependencyObject d, object basevalue)
	{
		if (basevalue == DependencyProperty.UnsetValue)
		{
			return basevalue;
		}
		if (!(d is WindowControl windowControl))
		{
			return basevalue;
		}
		return windowControl.OnCoerceCloseButtonVisibility((Visibility)basevalue);
	}

	protected virtual object OnCoerceCloseButtonVisibility(Visibility newValue)
	{
		return newValue;
	}

	private static object OnCoerceIsActive(DependencyObject d, object basevalue)
	{
		if (d is WindowControl { _setIsActiveInternal: false, AllowPublicIsActiveChange: false })
		{
			throw new InvalidOperationException("Cannot set IsActive directly. This is handled by the underlying system");
		}
		return basevalue;
	}

	private static void OnIsActiveChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
	{
		if (obj is WindowControl windowControl)
		{
			windowControl.OnIsActiveChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnIsActiveChanged(bool oldValue, bool newValue)
	{
		if (newValue && ((object)this).GetType() == typeof(WindowControl))
		{
			RaiseEvent(new RoutedEventArgs(ActivatedEvent, this));
		}
	}

	internal void SetIsActiveInternal(bool isActive)
	{
		_setIsActiveInternal = true;
		IsActive = isActive;
		_setIsActiveInternal = false;
	}

	private static object OnCoerceLeft(DependencyObject d, object basevalue)
	{
		if (basevalue == DependencyProperty.UnsetValue)
		{
			return basevalue;
		}
		WindowControl windowControl = (WindowControl)(object)d;
		if (windowControl == null)
		{
			return basevalue;
		}
		return windowControl.OnCoerceLeft(basevalue);
	}

	private object OnCoerceLeft(object newValue)
	{
		if (object.Equals((double)newValue, double.NaN))
		{
			return 0.0;
		}
		return newValue;
	}

	private static void OnLeftPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
	{
		if (obj is WindowControl windowControl)
		{
			windowControl.OnLeftPropertyChanged((double)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnLeftPropertyChanged(double oldValue, double newValue)
	{
		this.LeftChanged?.Invoke(this, EventArgs.Empty);
	}

	private static object OnCoerceTop(DependencyObject d, object basevalue)
	{
		if (basevalue == DependencyProperty.UnsetValue)
		{
			return basevalue;
		}
		WindowControl windowControl = (WindowControl)(object)d;
		if (windowControl == null)
		{
			return basevalue;
		}
		return windowControl.OnCoerceTop(basevalue);
	}

	private object OnCoerceTop(object newValue)
	{
		if (object.Equals((double)newValue, double.NaN))
		{
			return 0.0;
		}
		return newValue;
	}

	private static void OnTopPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
	{
		if (obj is WindowControl windowControl)
		{
			windowControl.OnTopPropertyChanged((double)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnTopPropertyChanged(double oldValue, double newValue)
	{
		this.TopChanged?.Invoke(this, EventArgs.Empty);
	}

	private static object OnCoerceWindowStyle(DependencyObject d, object basevalue)
	{
		if (basevalue == DependencyProperty.UnsetValue)
		{
			return basevalue;
		}
		if (!(d is WindowControl windowControl))
		{
			return basevalue;
		}
		return windowControl.OnCoerceWindowStyle((WindowStyle)basevalue);
	}

	protected virtual object OnCoerceWindowStyle(WindowStyle newValue)
	{
		return newValue;
	}

	private static void OnWindowStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((WindowControl)(object)d)?.OnWindowStyleChanged((WindowStyle)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (WindowStyle)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	protected virtual void OnWindowStyleChanged(WindowStyle oldValue, WindowStyle newValue)
	{
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		if (_headerThumb != null)
		{
			_headerThumb.PreviewMouseLeftButtonDown -= HeaderPreviewMouseLeftButtonDown;
			_headerThumb.PreviewMouseRightButtonDown -= HeaderPreviewMouseRightButtonDown;
			_headerThumb.DragDelta -= HeaderThumbDragDelta;
		}
		_headerThumb = base.Template.FindName("PART_HeaderThumb", this) as Thumb;
		if (_headerThumb != null)
		{
			_headerThumb.PreviewMouseLeftButtonDown += HeaderPreviewMouseLeftButtonDown;
			_headerThumb.PreviewMouseRightButtonDown += HeaderPreviewMouseRightButtonDown;
			_headerThumb.DragDelta += HeaderThumbDragDelta;
		}
		if (_icon != null)
		{
			_icon.MouseLeftButtonDown -= IconMouseLeftButtonDown;
		}
		_icon = base.Template.FindName("PART_Icon", this) as Image;
		if (_icon != null)
		{
			_icon.MouseLeftButtonDown += IconMouseLeftButtonDown;
		}
		if (_closeButton != null)
		{
			_closeButton.Click -= Close;
		}
		_closeButton = base.Template.FindName("PART_CloseButton", this) as Button;
		if (_closeButton != null)
		{
			_closeButton.Click += Close;
		}
		if (_windowToolboxCloseButton != null)
		{
			_windowToolboxCloseButton.Click -= Close;
		}
		_windowToolboxCloseButton = base.Template.FindName("PART_ToolWindowCloseButton", this) as Button;
		if (_windowToolboxCloseButton != null)
		{
			_windowToolboxCloseButton.Click += Close;
		}
		_windowBlockMouseInputsPanel = base.Template.FindName("PART_BlockMouseInputsBorder", this) as Border;
		UpdateBlockMouseInputsPanel();
	}

	private void HeaderPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		MouseButtonEventArgs e2 = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left);
		e2.RoutedEvent = ((e.ClickCount == 2) ? HeaderMouseLeftButtonDoubleClickedEvent : HeaderMouseLeftButtonClickedEvent);
		e2.Source = this;
		RaiseEvent(e2);
	}

	private void HeaderPreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
	{
		MouseButtonEventArgs e2 = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Right);
		e2.RoutedEvent = HeaderMouseRightButtonClickedEvent;
		e2.Source = this;
		RaiseEvent(e2);
	}

	private void HeaderThumbDragDelta(object sender, DragDeltaEventArgs e)
	{
		DragDeltaEventArgs e2 = new DragDeltaEventArgs(e.HorizontalChange, e.VerticalChange);
		e2.RoutedEvent = HeaderDragDeltaEvent;
		e2.Source = this;
		RaiseEvent(e2);
	}

	private void IconMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		MouseButtonEventArgs e2 = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left);
		e2.RoutedEvent = ((e.ClickCount == 2) ? HeaderIconDoubleClickedEvent : HeaderIconClickedEvent);
		e2.Source = this;
		RaiseEvent(e2);
	}

	private void Close(object sender, RoutedEventArgs e)
	{
		RaiseEvent(new RoutedEventArgs(CloseButtonClickedEvent, this));
	}

	internal virtual void UpdateBlockMouseInputsPanel()
	{
		if (_windowBlockMouseInputsPanel != null)
		{
			_windowBlockMouseInputsPanel.Visibility = ((!IsBlockMouseInputsPanelActive) ? Visibility.Collapsed : Visibility.Visible);
		}
	}

	internal double GetHeaderHeight()
	{
		if (base.Template.FindName("PART_HeaderGrid", this) is Grid grid)
		{
			return grid.ActualHeight;
		}
		return 0.0;
	}
}
