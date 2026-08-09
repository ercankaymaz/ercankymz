using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_WindowRoot", Type = typeof(Grid))]
[TemplatePart(Name = "PART_Root", Type = typeof(Grid))]
[TemplatePart(Name = "PART_WindowControl", Type = typeof(WindowControl))]
public class ChildWindow : WindowControl
{
	private const string PART_WindowRoot = "PART_WindowRoot";

	private const string PART_Root = "PART_Root";

	private const string PART_WindowControl = "PART_WindowControl";

	private const int _horizontalOffset = 3;

	private const int _verticalOffset = 3;

	private Grid _root;

	private TranslateTransform _moveTransform = new TranslateTransform();

	private bool _startupPositionInitialized;

	private FrameworkElement _parentContainer;

	private Rectangle _modalLayer = new Rectangle();

	private Canvas _modalLayerPanel = new Canvas();

	private Grid _windowRoot;

	private WindowControl _windowControl;

	private bool _ignorePropertyChanged;

	private bool _hasChildren;

	private bool _hasWindowContainer;

	private bool? _dialogResult;

	public static readonly DependencyProperty DesignerWindowStateProperty;

	public static readonly DependencyProperty FocusedElementProperty;

	public static readonly DependencyProperty IsModalProperty;

	[Obsolete("This property is obsolete and should no longer be used. Use WindowContainer.ModalBackgroundBrushProperty instead.")]
	public static readonly DependencyProperty OverlayBrushProperty;

	[Obsolete("This property is obsolete and should no longer be used. Use WindowContainer.ModalBackgroundBrushProperty instead.")]
	public static readonly DependencyProperty OverlayOpacityProperty;

	public static readonly DependencyProperty WindowStartupLocationProperty;

	public static readonly DependencyProperty WindowStateProperty;

	[TypeConverter(typeof(NullableBoolConverter))]
	public bool? DialogResult
	{
		get
		{
			return _dialogResult;
		}
		set
		{
			if (_dialogResult != value)
			{
				_dialogResult = value;
				Close();
			}
		}
	}

	public WindowState DesignerWindowState
	{
		get
		{
			return (WindowState)((DependencyObject)this).GetValue(DesignerWindowStateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DesignerWindowStateProperty, (object)value);
		}
	}

	public FrameworkElement FocusedElement
	{
		get
		{
			return (FrameworkElement)((DependencyObject)this).GetValue(FocusedElementProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FocusedElementProperty, (object)value);
		}
	}

	public bool IsModal
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsModalProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsModalProperty, (object)value);
		}
	}

	[Obsolete("This property is obsolete and should no longer be used. Use WindowContainer.ModalBackgroundBrushProperty instead.")]
	public Brush OverlayBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(OverlayBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OverlayBrushProperty, (object)value);
		}
	}

	[Obsolete("This property is obsolete and should no longer be used. Use WindowContainer.ModalBackgroundBrushProperty instead.")]
	public double OverlayOpacity
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(OverlayOpacityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OverlayOpacityProperty, (object)value);
		}
	}

	public WindowStartupLocation WindowStartupLocation
	{
		get
		{
			return (WindowStartupLocation)((DependencyObject)this).GetValue(WindowStartupLocationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WindowStartupLocationProperty, (object)value);
		}
	}

	public WindowState WindowState
	{
		get
		{
			return (WindowState)((DependencyObject)this).GetValue(WindowStateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WindowStateProperty, (object)value);
		}
	}

	internal override bool AllowPublicIsActiveChange => false;

	internal event EventHandler<EventArgs> IsModalChanged;

	public event EventHandler Closed;

	public event EventHandler<CancelEventArgs> Closing;

	private static void OnDesignerWindowStatePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is ChildWindow childWindow)
		{
			childWindow.OnDesignerWindowStatePropertyChanged((WindowState)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (WindowState)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnDesignerWindowStatePropertyChanged(WindowState oldValue, WindowState newValue)
	{
		if (DesignerProperties.GetIsInDesignMode((DependencyObject)(object)this))
		{
			base.Visibility = ((newValue != WindowState.Open) ? Visibility.Collapsed : Visibility.Visible);
		}
	}

	private static void OnIsModalPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is ChildWindow childWindow)
		{
			childWindow.OnIsModalChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	private void OnIsModalChanged(bool oldValue, bool newValue)
	{
		this.IsModalChanged?.Invoke(this, EventArgs.Empty);
		if (!_hasWindowContainer)
		{
			if (newValue)
			{
				KeyboardNavigation.SetTabNavigation((DependencyObject)(object)this, KeyboardNavigationMode.Cycle);
				ShowModalLayer();
			}
			else
			{
				KeyboardNavigation.SetTabNavigation((DependencyObject)(object)this, KeyboardNavigationMode.Continue);
				HideModalLayer();
			}
		}
	}

	private static void OnOverlayBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is ChildWindow childWindow)
		{
			childWindow.OnOverlayBrushChanged((Brush)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (Brush)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	[Obsolete("This method is obsolete and should no longer be used. Use WindowContainer.ModalBackgroundBrushProperty instead.")]
	protected virtual void OnOverlayBrushChanged(Brush oldValue, Brush newValue)
	{
		_modalLayer.Fill = newValue;
	}

	private static void OnOverlayOpacityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is ChildWindow childWindow)
		{
			childWindow.OnOverlayOpacityChanged((double)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	[Obsolete("This method is obsolete and should no longer be used. Use WindowContainer.ModalBackgroundBrushProperty instead.")]
	protected virtual void OnOverlayOpacityChanged(double oldValue, double newValue)
	{
		_modalLayer.Opacity = newValue;
	}

	private static void OnWindowStartupLocationChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ChildWindow childWindow)
		{
			childWindow.OnWindowStartupLocationChanged((WindowStartupLocation)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (WindowStartupLocation)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnWindowStartupLocationChanged(WindowStartupLocation oldValue, WindowStartupLocation newValue)
	{
	}

	private static void OnWindowStatePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is ChildWindow childWindow)
		{
			childWindow.OnWindowStatePropertyChanged((WindowState)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (WindowState)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	protected virtual void OnWindowStatePropertyChanged(WindowState oldValue, WindowState newValue)
	{
		if (!DesignerProperties.GetIsInDesignMode((DependencyObject)(object)this))
		{
			if (!_ignorePropertyChanged)
			{
				SetWindowState(newValue);
			}
		}
		else
		{
			base.Visibility = ((DesignerWindowState != WindowState.Open) ? Visibility.Collapsed : Visibility.Visible);
		}
	}

	static ChildWindow()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Expected O, but got Unknown
		DesignerWindowStateProperty = DependencyProperty.Register("DesignerWindowState", typeof(WindowState), typeof(ChildWindow), new PropertyMetadata((object)WindowState.Closed, new PropertyChangedCallback(OnDesignerWindowStatePropertyChanged)));
		FocusedElementProperty = DependencyProperty.Register("FocusedElement", typeof(FrameworkElement), typeof(ChildWindow), (PropertyMetadata)(object)new UIPropertyMetadata(null));
		IsModalProperty = DependencyProperty.Register("IsModal", typeof(bool), typeof(ChildWindow), (PropertyMetadata)(object)new UIPropertyMetadata(false, new PropertyChangedCallback(OnIsModalPropertyChanged)));
		OverlayBrushProperty = DependencyProperty.Register("OverlayBrush", typeof(Brush), typeof(ChildWindow), new PropertyMetadata((object)Brushes.Gray, new PropertyChangedCallback(OnOverlayBrushChanged)));
		OverlayOpacityProperty = DependencyProperty.Register("OverlayOpacity", typeof(double), typeof(ChildWindow), new PropertyMetadata((object)0.5, new PropertyChangedCallback(OnOverlayOpacityChanged)));
		WindowStartupLocationProperty = DependencyProperty.Register("WindowStartupLocation", typeof(WindowStartupLocation), typeof(ChildWindow), (PropertyMetadata)(object)new UIPropertyMetadata(WindowStartupLocation.Manual, new PropertyChangedCallback(OnWindowStartupLocationChanged)));
		WindowStateProperty = DependencyProperty.Register("WindowState", typeof(WindowState), typeof(ChildWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata(WindowState.Closed, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnWindowStatePropertyChanged)));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ChildWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(ChildWindow)));
	}

	public ChildWindow()
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		DesignerWindowState = WindowState.Open;
		_modalLayer.Fill = OverlayBrush;
		_modalLayer.Opacity = OverlayOpacity;
		base.IsVisibleChanged += new DependencyPropertyChangedEventHandler(ChildWindow_IsVisibleChanged);
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		if (_windowControl != null)
		{
			_windowControl.HeaderDragDelta -= delegate(object o, DragDeltaEventArgs e)
			{
				OnHeaderDragDelta(e);
			};
			_windowControl.HeaderIconDoubleClicked -= delegate(object o, MouseButtonEventArgs e)
			{
				OnHeaderIconDoubleClick(e);
			};
			_windowControl.CloseButtonClicked -= delegate(object o, RoutedEventArgs e)
			{
				OnCloseButtonClicked(e);
			};
		}
		_windowControl = GetTemplateChild("PART_WindowControl") as WindowControl;
		if (_windowControl != null)
		{
			_windowControl.HeaderDragDelta += delegate(object o, DragDeltaEventArgs e)
			{
				OnHeaderDragDelta(e);
			};
			_windowControl.HeaderIconDoubleClicked += delegate(object o, MouseButtonEventArgs e)
			{
				OnHeaderIconDoubleClick(e);
			};
			_windowControl.CloseButtonClicked += delegate(object o, RoutedEventArgs e)
			{
				OnCloseButtonClicked(e);
			};
		}
		UpdateBlockMouseInputsPanel();
		_windowRoot = GetTemplateChild("PART_WindowRoot") as Grid;
		if (_windowRoot != null)
		{
			_windowRoot.RenderTransform = _moveTransform;
		}
		_hasWindowContainer = VisualTreeHelper.GetParent((DependencyObject)(object)this) is WindowContainer;
		if (_hasWindowContainer)
		{
			return;
		}
		_parentContainer = VisualTreeHelper.GetParent((DependencyObject)(object)this) as FrameworkElement;
		if (_parentContainer != null)
		{
			_parentContainer.LayoutUpdated += ParentContainer_LayoutUpdated;
			_parentContainer.SizeChanged += ParentContainer_SizeChanged;
			if (BrowserInteropHelper.IsBrowserHosted)
			{
				_parentContainer.Loaded += delegate
				{
					ExecuteOpen();
				};
			}
		}
		base.Unloaded += ChildWindow_Unloaded;
		_modalLayer.Height = _parentContainer.ActualHeight;
		_modalLayer.Width = _parentContainer.ActualWidth;
		_root = GetTemplateChild("PART_Root") as Grid;
		Style style = ((_root != null) ? (_root.Resources["FocusVisualStyle"] as Style) : null);
		if (style != null)
		{
			Setter item = new Setter(FrameworkElement.DataContextProperty, this);
			style.Setters.Add(item);
			base.FocusVisualStyle = style;
		}
		if (_root != null)
		{
			_root.Children.Add(_modalLayerPanel);
		}
	}

	protected override void OnGotFocus(RoutedEventArgs e)
	{
		base.OnGotFocus(e);
		Action action = delegate
		{
			if (FocusedElement != null)
			{
				_hasChildren = true;
				FocusedElement.Focus();
			}
			else
			{
				object content = base.Content;
				FrameworkElement frameworkElement = TreeHelper.FindChild((DependencyObject)((content is DependencyObject) ? content : null), (FrameworkElement x) => x.Focusable);
				if (frameworkElement != null)
				{
					_hasChildren = true;
					frameworkElement.Focus();
				}
				else
				{
					_hasChildren = false;
				}
			}
		};
		((DispatcherObject)this).Dispatcher.BeginInvoke((DispatcherPriority)2, (Delegate)action);
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Invalid comparison between Unknown and I4
		base.OnPreviewKeyDown(e);
		if (IsModal)
		{
			if (Keyboard.IsKeyDown((Key)120) || Keyboard.IsKeyDown((Key)121))
			{
				e.Handled = true;
			}
			else if ((int)e.Key == 3 && !_hasChildren)
			{
				e.Handled = true;
			}
		}
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected I4, but got Unknown
		base.OnKeyDown(e);
		if (WindowState == WindowState.Open)
		{
			Key key = e.Key;
			switch (key - 23)
			{
			case 0:
				base.Left -= 3.0;
				e.Handled = true;
				break;
			case 2:
				base.Left += 3.0;
				e.Handled = true;
				break;
			case 3:
				base.Top += 3.0;
				e.Handled = true;
				break;
			case 1:
				base.Top -= 3.0;
				e.Handled = true;
				break;
			}
		}
	}

	protected override void OnLeftPropertyChanged(double oldValue, double newValue)
	{
		base.OnLeftPropertyChanged(oldValue, newValue);
		_hasWindowContainer = VisualTreeHelper.GetParent((DependencyObject)(object)this) is WindowContainer;
		if (!_hasWindowContainer)
		{
			base.Left = GetRestrictedLeft();
			ProcessMove(newValue - oldValue, 0.0);
		}
	}

	protected override void OnTopPropertyChanged(double oldValue, double newValue)
	{
		base.OnTopPropertyChanged(oldValue, newValue);
		_hasWindowContainer = VisualTreeHelper.GetParent((DependencyObject)(object)this) is WindowContainer;
		if (!_hasWindowContainer)
		{
			base.Top = GetRestrictedTop();
			ProcessMove(0.0, newValue - oldValue);
		}
	}

	internal override void UpdateBlockMouseInputsPanel()
	{
		if (_windowControl != null)
		{
			_windowControl.IsBlockMouseInputsPanelActive = base.IsBlockMouseInputsPanelActive;
		}
	}

	protected virtual void OnHeaderDragDelta(DragDeltaEventArgs e)
	{
		if (IsCurrentWindow(e.OriginalSource))
		{
			e.Handled = true;
			DragDeltaEventArgs e2 = new DragDeltaEventArgs(e.HorizontalChange, e.VerticalChange);
			e2.RoutedEvent = WindowControl.HeaderDragDeltaEvent;
			e2.Source = this;
			RaiseEvent(e2);
			if (!e2.Handled && object.Equals(e.OriginalSource, _windowControl))
			{
				double num = 0.0;
				num = ((base.FlowDirection != FlowDirection.RightToLeft) ? (base.Left + e.HorizontalChange) : (base.Left - e.HorizontalChange));
				base.Left = num;
				base.Top += e.VerticalChange;
			}
		}
	}

	protected virtual void OnHeaderIconDoubleClick(MouseButtonEventArgs e)
	{
		if (IsCurrentWindow(e.OriginalSource))
		{
			e.Handled = true;
			MouseButtonEventArgs e2 = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left);
			e2.RoutedEvent = WindowControl.HeaderIconDoubleClickedEvent;
			e2.Source = this;
			RaiseEvent(e2);
			if (!e2.Handled)
			{
				Close();
			}
		}
	}

	protected virtual void OnCloseButtonClicked(RoutedEventArgs e)
	{
		if (IsCurrentWindow(e.OriginalSource))
		{
			e.Handled = true;
			RoutedEventArgs e2 = new RoutedEventArgs(WindowControl.CloseButtonClickedEvent, this);
			RaiseEvent(e2);
			if (!e2.Handled)
			{
				Close();
			}
		}
	}

	[Obsolete("This method is obsolete and should no longer be used.")]
	private void ParentContainer_LayoutUpdated(object sender, EventArgs e)
	{
		if (!DesignerProperties.GetIsInDesignMode((DependencyObject)(object)this) && !_startupPositionInitialized)
		{
			ExecuteOpen();
			_startupPositionInitialized = true;
		}
	}

	[Obsolete("This method is obsolete and should no longer be used.")]
	private void ChildWindow_Unloaded(object sender, RoutedEventArgs e)
	{
		if (_parentContainer == null)
		{
			return;
		}
		_parentContainer.LayoutUpdated -= ParentContainer_LayoutUpdated;
		_parentContainer.SizeChanged -= ParentContainer_SizeChanged;
		if (BrowserInteropHelper.IsBrowserHosted)
		{
			_parentContainer.Loaded -= delegate
			{
				ExecuteOpen();
			};
		}
	}

	[Obsolete("This method is obsolete and should no longer be used.")]
	private void ParentContainer_SizeChanged(object sender, SizeChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		Rectangle modalLayer = _modalLayer;
		Size newSize = e.NewSize;
		modalLayer.Height = ((Size)(ref newSize)).Height;
		Rectangle modalLayer2 = _modalLayer;
		newSize = e.NewSize;
		modalLayer2.Width = ((Size)(ref newSize)).Width;
		base.Left = GetRestrictedLeft();
		base.Top = GetRestrictedTop();
	}

	private void ChildWindow_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
	{
		if ((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue && IsModal)
		{
			Focus();
		}
	}

	[Obsolete("This method is obsolete and should no longer be used. Use WindowContainer.GetRestrictedLeft() instead.")]
	private double GetRestrictedLeft()
	{
		if (base.Left < 0.0)
		{
			return 0.0;
		}
		if (_parentContainer != null && _windowRoot != null && base.Left + _windowRoot.ActualWidth > _parentContainer.ActualWidth && _parentContainer.ActualWidth != 0.0)
		{
			double num = _parentContainer.ActualWidth - _windowRoot.ActualWidth;
			if (!(num < 0.0))
			{
				return num;
			}
			return 0.0;
		}
		return base.Left;
	}

	[Obsolete("This method is obsolete and should no longer be used. Use WindowContainer.GetRestrictedTop() instead.")]
	private double GetRestrictedTop()
	{
		if (base.Top < 0.0)
		{
			return 0.0;
		}
		if (_parentContainer != null && _windowRoot != null && base.Top + _windowRoot.ActualHeight > _parentContainer.ActualHeight && _parentContainer.ActualHeight != 0.0)
		{
			double num = _parentContainer.ActualHeight - _windowRoot.ActualHeight;
			if (!(num < 0.0))
			{
				return num;
			}
			return 0.0;
		}
		return base.Top;
	}

	private void SetWindowState(WindowState state)
	{
		switch (state)
		{
		case WindowState.Closed:
			ExecuteClose();
			break;
		case WindowState.Open:
			ExecuteOpen();
			break;
		}
	}

	private void ExecuteClose()
	{
		CancelEventArgs e = new CancelEventArgs();
		OnClosing(e);
		if (!e.Cancel)
		{
			if (!_dialogResult.HasValue)
			{
				_dialogResult = false;
			}
			OnClosed(EventArgs.Empty);
		}
		else
		{
			CancelClose();
		}
	}

	private void CancelClose()
	{
		_dialogResult = null;
		_ignorePropertyChanged = true;
		WindowState = WindowState.Open;
		_ignorePropertyChanged = false;
	}

	private void ExecuteOpen()
	{
		_dialogResult = null;
		if (!_hasWindowContainer && WindowStartupLocation == WindowStartupLocation.Center)
		{
			CenterChildWindow();
		}
		if (!_hasWindowContainer)
		{
			BringToFront();
		}
	}

	private bool IsCurrentWindow(object windowtoTest)
	{
		return object.Equals(_windowControl, windowtoTest);
	}

	[Obsolete("This method is obsolete and should no longer be used. Use WindowContainer.BringToFront() instead.")]
	private void BringToFront()
	{
		int num = 0;
		if (_parentContainer != null)
		{
			num = (int)((DependencyObject)_parentContainer).GetValue(Panel.ZIndexProperty);
		}
		((DependencyObject)this).SetValue(Panel.ZIndexProperty, (object)(++num));
		if (IsModal)
		{
			Panel.SetZIndex(_modalLayerPanel, num - 2);
		}
	}

	[Obsolete("This method is obsolete and should no longer be used. Use WindowContainer.CenterChild() instead.")]
	private void CenterChildWindow()
	{
		if (_parentContainer != null && _windowRoot != null)
		{
			_windowRoot.UpdateLayout();
			base.Left = (_parentContainer.ActualWidth - _windowRoot.ActualWidth) / 2.0;
			base.Top = (_parentContainer.ActualHeight - _windowRoot.ActualHeight) / 2.0;
		}
	}

	[Obsolete("This method is obsolete and should no longer be used.")]
	private void ShowModalLayer()
	{
		if (!DesignerProperties.GetIsInDesignMode((DependencyObject)(object)this))
		{
			if (!_modalLayerPanel.Children.Contains(_modalLayer))
			{
				_modalLayerPanel.Children.Add(_modalLayer);
			}
			_modalLayer.Visibility = Visibility.Visible;
		}
	}

	[Obsolete("This method is obsolete and should no longer be used.")]
	private void HideModalLayer()
	{
		_modalLayer.Visibility = Visibility.Collapsed;
	}

	[Obsolete("This method is obsolete and should no longer be used. Use the ChildWindow in a WindowContainer instead.")]
	private void ProcessMove(double x, double y)
	{
		_moveTransform.X += x;
		_moveTransform.Y += y;
		InvalidateArrange();
	}

	public void Show()
	{
		WindowState = WindowState.Open;
	}

	public void Close()
	{
		WindowState = WindowState.Closed;
	}

	protected virtual void OnClosed(EventArgs e)
	{
		if (this.Closed != null)
		{
			this.Closed(this, e);
		}
	}

	protected virtual void OnClosing(CancelEventArgs e)
	{
		if (this.Closing != null)
		{
			this.Closing(this, e);
		}
	}
}
