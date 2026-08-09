using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls;

public class LayoutAutoHideWindowControl : HwndHost, ILayoutControl
{
	internal LayoutAnchorableControl _internalHost;

	private LayoutAnchorControl _anchor;

	private LayoutAnchorable _model;

	private HwndSource _internalHwndSource;

	private IntPtr parentWindowHandle;

	private ContentPresenter _internalHostPresenter = new ContentPresenter();

	private Grid _internalGrid;

	private AnchorSide _side;

	private LayoutGridResizerControl _resizer;

	private DockingManager _manager;

	private Border _resizerGhost;

	private Window _resizerWindowHost;

	private Vector _initialStartPoint;

	public static readonly DependencyProperty AnchorableStyleProperty;

	public static readonly DependencyProperty BackgroundProperty;

	public Style AnchorableStyle
	{
		get
		{
			return (Style)((DependencyObject)this).GetValue(AnchorableStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AnchorableStyleProperty, (object)value);
		}
	}

	public Brush Background
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(BackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BackgroundProperty, (object)value);
		}
	}

	public ILayoutElement Model => _model;

	internal bool IsResizing { get; private set; }

	protected override IEnumerator LogicalChildren
	{
		get
		{
			if (_internalHostPresenter == null)
			{
				return new UIElement[0].GetEnumerator();
			}
			return new UIElement[1] { _internalHostPresenter }.GetEnumerator();
		}
	}

	internal bool IsWin32MouseOver
	{
		get
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			Win32Helper.Win32Point pt = default(Win32Helper.Win32Point);
			if (!Win32Helper.GetCursorPos(ref pt))
			{
				return false;
			}
			this.PointToScreenDPI(default(Point));
			Rect screenArea = this.GetScreenArea();
			if (((Rect)(ref screenArea)).Contains(new Point((double)pt.X, (double)pt.Y)))
			{
				return true;
			}
			LayoutAnchorControl layoutAnchorControl = (from c in ((DependencyObject)(object)Model.Root.Manager).FindVisualChildren<LayoutAnchorControl>()
				where c.Model == Model
				select c).FirstOrDefault();
			if (layoutAnchorControl == null)
			{
				return false;
			}
			layoutAnchorControl.PointToScreenDPI(default(Point));
			if (layoutAnchorControl.IsMouseOver)
			{
				return true;
			}
			return false;
		}
	}

	static LayoutAutoHideWindowControl()
	{
		AnchorableStyleProperty = DependencyProperty.Register("AnchorableStyle", typeof(Style), typeof(LayoutAutoHideWindowControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null));
		BackgroundProperty = DependencyProperty.Register("Background", typeof(Brush), typeof(LayoutAutoHideWindowControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(LayoutAutoHideWindowControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(LayoutAutoHideWindowControl)));
		UIElement.FocusableProperty.OverrideMetadata(typeof(LayoutAutoHideWindowControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		Control.IsTabStopProperty.OverrideMetadata(typeof(LayoutAutoHideWindowControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		UIElement.VisibilityProperty.OverrideMetadata(typeof(LayoutAutoHideWindowControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Visibility.Hidden));
	}

	internal LayoutAutoHideWindowControl()
	{
	}

	protected override HandleRef BuildWindowCore(HandleRef hwndParent)
	{
		parentWindowHandle = hwndParent.Handle;
		_internalHwndSource = new HwndSource(new HwndSourceParameters
		{
			ParentWindow = hwndParent.Handle,
			WindowStyle = 1442840576,
			Width = 0,
			Height = 0
		});
		_internalHwndSource.RootVisual = _internalHostPresenter;
		AddLogicalChild(_internalHostPresenter);
		Win32Helper.BringWindowToTop(_internalHwndSource.Handle);
		return new HandleRef(this, _internalHwndSource.Handle);
	}

	protected override void DestroyWindowCore(HandleRef hwnd)
	{
		if (_internalHwndSource != null)
		{
			_internalHwndSource.Dispose();
			_internalHwndSource = null;
		}
	}

	protected override bool HasFocusWithinCore()
	{
		return false;
	}

	protected override Size MeasureOverride(Size constraint)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		if (_internalHostPresenter == null)
		{
			return base.MeasureOverride(constraint);
		}
		_internalHostPresenter.Measure(constraint);
		return _internalHostPresenter.DesiredSize;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		if (_internalHostPresenter == null)
		{
			return base.ArrangeOverride(finalSize);
		}
		_internalHostPresenter.Arrange(new Rect(finalSize));
		return base.ArrangeOverride(finalSize);
	}

	internal void Show(LayoutAnchorControl anchor)
	{
		if (_model != null)
		{
			throw new InvalidOperationException();
		}
		_anchor = anchor;
		_model = anchor.Model as LayoutAnchorable;
		_side = (anchor.Model.Parent.Parent as LayoutAnchorSide).Side;
		_manager = _model.Root.Manager;
		CreateInternalGrid();
		_model.PropertyChanged += _model_PropertyChanged;
		base.Visibility = Visibility.Visible;
		InvalidateMeasure();
		UpdateWindowPos();
		Win32Helper.BringWindowToTop(_internalHwndSource.Handle);
	}

	internal void Hide()
	{
		if (_model != null)
		{
			_model.PropertyChanged -= _model_PropertyChanged;
			RemoveInternalGrid();
			_anchor = null;
			_model = null;
			_manager = null;
			base.Visibility = Visibility.Hidden;
		}
	}

	private void _model_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "IsAutoHidden" && !_model.IsAutoHidden)
		{
			_manager.HideAutoHideWindow(_anchor);
		}
	}

	private void CreateInternalGrid()
	{
		_internalGrid = new Grid
		{
			FlowDirection = FlowDirection.LeftToRight
		};
		_internalGrid.SetBinding(Panel.BackgroundProperty, new Binding("Background")
		{
			Source = this
		});
		_internalHost = new LayoutAnchorableControl
		{
			Model = _model,
			Style = AnchorableStyle
		};
		_internalHost.SetBinding(FrameworkElement.FlowDirectionProperty, new Binding("Model.Root.Manager.FlowDirection")
		{
			Source = this
		});
		KeyboardNavigation.SetTabNavigation((DependencyObject)(object)_internalGrid, KeyboardNavigationMode.Cycle);
		_resizer = new LayoutGridResizerControl();
		_resizer.DragStarted += OnResizerDragStarted;
		_resizer.DragDelta += OnResizerDragDelta;
		_resizer.DragCompleted += OnResizerDragCompleted;
		if (_side == AnchorSide.Right)
		{
			_internalGrid.ColumnDefinitions.Add(new ColumnDefinition
			{
				Width = new GridLength(double.IsNaN(_manager.GridSplitterWidth) ? 6.0 : _manager.GridSplitterWidth)
			});
			_internalGrid.ColumnDefinitions.Add(new ColumnDefinition
			{
				Width = ((_model.AutoHideWidth == 0.0) ? new GridLength(double.IsNaN(_model.AutoHideMinWidth) ? 100.0 : _model.AutoHideMinWidth) : new GridLength(double.IsNaN(_model.AutoHideWidth) ? 0.0 : _model.AutoHideWidth, GridUnitType.Pixel))
			});
			Grid.SetColumn(_resizer, 0);
			Grid.SetColumn(_internalHost, 1);
			_resizer.Cursor = Cursors.SizeWE;
			base.HorizontalAlignment = HorizontalAlignment.Right;
			base.VerticalAlignment = VerticalAlignment.Stretch;
		}
		else if (_side == AnchorSide.Left)
		{
			_internalGrid.ColumnDefinitions.Add(new ColumnDefinition
			{
				Width = ((_model.AutoHideWidth == 0.0) ? new GridLength(double.IsNaN(_model.AutoHideMinWidth) ? 100.0 : _model.AutoHideMinWidth) : new GridLength(double.IsNaN(_model.AutoHideWidth) ? 0.0 : _model.AutoHideWidth, GridUnitType.Pixel))
			});
			_internalGrid.ColumnDefinitions.Add(new ColumnDefinition
			{
				Width = new GridLength(double.IsNaN(_manager.GridSplitterWidth) ? 6.0 : _manager.GridSplitterWidth)
			});
			Grid.SetColumn(_internalHost, 0);
			Grid.SetColumn(_resizer, 1);
			_resizer.Cursor = Cursors.SizeWE;
			base.HorizontalAlignment = HorizontalAlignment.Left;
			base.VerticalAlignment = VerticalAlignment.Stretch;
		}
		else if (_side == AnchorSide.Top)
		{
			_internalGrid.RowDefinitions.Add(new RowDefinition
			{
				Height = ((_model.AutoHideHeight == 0.0) ? new GridLength(double.IsNaN(_model.AutoHideMinHeight) ? 100.0 : _model.AutoHideMinHeight) : new GridLength(double.IsNaN(_model.AutoHideHeight) ? 0.0 : _model.AutoHideHeight, GridUnitType.Pixel))
			});
			_internalGrid.RowDefinitions.Add(new RowDefinition
			{
				Height = new GridLength(double.IsNaN(_manager.GridSplitterHeight) ? 6.0 : _manager.GridSplitterHeight)
			});
			Grid.SetRow(_internalHost, 0);
			Grid.SetRow(_resizer, 1);
			_resizer.Cursor = Cursors.SizeNS;
			base.VerticalAlignment = VerticalAlignment.Top;
			base.HorizontalAlignment = HorizontalAlignment.Stretch;
		}
		else if (_side == AnchorSide.Bottom)
		{
			_internalGrid.RowDefinitions.Add(new RowDefinition
			{
				Height = new GridLength(double.IsNaN(_manager.GridSplitterHeight) ? 6.0 : _manager.GridSplitterHeight)
			});
			_internalGrid.RowDefinitions.Add(new RowDefinition
			{
				Height = ((_model.AutoHideHeight == 0.0) ? new GridLength(double.IsNaN(_model.AutoHideMinHeight) ? 100.0 : _model.AutoHideMinHeight) : new GridLength(double.IsNaN(_model.AutoHideHeight) ? 0.0 : _model.AutoHideHeight, GridUnitType.Pixel))
			});
			Grid.SetRow(_resizer, 0);
			Grid.SetRow(_internalHost, 1);
			_resizer.Cursor = Cursors.SizeNS;
			base.VerticalAlignment = VerticalAlignment.Bottom;
			base.HorizontalAlignment = HorizontalAlignment.Stretch;
		}
		_internalGrid.Children.Add(_resizer);
		_internalGrid.Children.Add(_internalHost);
		_internalHostPresenter.Content = _internalGrid;
	}

	private void RemoveInternalGrid()
	{
		_resizer.DragStarted -= OnResizerDragStarted;
		_resizer.DragDelta -= OnResizerDragDelta;
		_resizer.DragCompleted -= OnResizerDragCompleted;
		_internalHostPresenter.Content = null;
	}

	private void ShowResizerOverlayWindow(LayoutGridResizerControl splitter)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		_resizerGhost = new Border
		{
			Background = splitter.BackgroundWhileDragging,
			Opacity = splitter.OpacityWhileDragging
		};
		FrameworkElement autoHideAreaElement = _manager.GetAutoHideAreaElement();
		_internalHost.TransformActualSizeToAncestor();
		Point val = autoHideAreaElement.PointToScreenDPIWithoutFlowDirection(default(Point));
		Size val2 = autoHideAreaElement.TransformActualSizeToAncestor();
		Size val3 = default(Size);
		if (_side == AnchorSide.Right || _side == AnchorSide.Left)
		{
			((Size)(ref val3))._002Ector(((Size)(ref val2)).Width - 25.0 + splitter.ActualWidth, ((Size)(ref val2)).Height);
			_resizerGhost.Width = splitter.ActualWidth;
			_resizerGhost.Height = ((Size)(ref val3)).Height;
			((Point)(ref val)).Offset(25.0, 0.0);
		}
		else
		{
			((Size)(ref val3))._002Ector(((Size)(ref val2)).Width, ((Size)(ref val2)).Height - _model.AutoHideMinHeight - 25.0 + splitter.ActualHeight);
			_resizerGhost.Height = splitter.ActualHeight;
			_resizerGhost.Width = ((Size)(ref val3)).Width;
			((Point)(ref val)).Offset(0.0, 25.0);
		}
		_initialStartPoint = splitter.PointToScreenDPIWithoutFlowDirection(default(Point)) - val;
		if (_side == AnchorSide.Right || _side == AnchorSide.Left)
		{
			Canvas.SetLeft(_resizerGhost, ((Vector)(ref _initialStartPoint)).X);
		}
		else
		{
			Canvas.SetTop(_resizerGhost, ((Vector)(ref _initialStartPoint)).Y);
		}
		Canvas canvas = new Canvas
		{
			HorizontalAlignment = HorizontalAlignment.Stretch,
			VerticalAlignment = VerticalAlignment.Stretch
		};
		canvas.Children.Add(_resizerGhost);
		_resizerWindowHost = new Window
		{
			ResizeMode = ResizeMode.NoResize,
			WindowStyle = WindowStyle.None,
			ShowInTaskbar = false,
			AllowsTransparency = true,
			Background = null,
			Width = ((Size)(ref val3)).Width,
			Height = ((Size)(ref val3)).Height,
			Left = ((Point)(ref val)).X,
			Top = ((Point)(ref val)).Y,
			ShowActivated = false,
			Owner = Window.GetWindow((DependencyObject)(object)this),
			Content = canvas
		};
		_resizerWindowHost.Show();
	}

	private void HideResizerOverlayWindow()
	{
		if (_resizerWindowHost != null)
		{
			_resizerWindowHost.Close();
			_resizerWindowHost = null;
		}
	}

	private void OnResizerDragCompleted(object sender, DragCompletedEventArgs e)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		Visual ancestor = ((DependencyObject)(object)this).FindVisualTreeRoot() as Visual;
		GeneralTransform generalTransform = TransformToAncestor(ancestor);
		_ = generalTransform.Transform(new Point(e.HorizontalChange, e.VerticalChange)) - generalTransform.Transform(default(Point));
		double num = ((_side != AnchorSide.Right && _side != AnchorSide.Left) ? (Canvas.GetTop(_resizerGhost) - ((Vector)(ref _initialStartPoint)).Y) : (Canvas.GetLeft(_resizerGhost) - ((Vector)(ref _initialStartPoint)).X));
		if (_side == AnchorSide.Right)
		{
			if (_model.AutoHideWidth == 0.0)
			{
				_model.AutoHideWidth = _internalHost.ActualWidth - num;
			}
			else
			{
				_model.AutoHideWidth -= num;
			}
			_internalGrid.ColumnDefinitions[1].Width = new GridLength(double.IsNaN(_model.AutoHideWidth) ? 0.0 : _model.AutoHideWidth, GridUnitType.Pixel);
		}
		else if (_side == AnchorSide.Left)
		{
			if (_model.AutoHideWidth == 0.0)
			{
				_model.AutoHideWidth = _internalHost.ActualWidth + num;
			}
			else
			{
				_model.AutoHideWidth += num;
			}
			_internalGrid.ColumnDefinitions[0].Width = new GridLength(double.IsNaN(_model.AutoHideWidth) ? 0.0 : _model.AutoHideWidth, GridUnitType.Pixel);
		}
		else if (_side == AnchorSide.Top)
		{
			if (_model.AutoHideHeight == 0.0)
			{
				_model.AutoHideHeight = _internalHost.ActualHeight + num;
			}
			else
			{
				_model.AutoHideHeight += num;
			}
			_internalGrid.RowDefinitions[0].Height = new GridLength(double.IsNaN(_model.AutoHideHeight) ? 0.0 : _model.AutoHideHeight, GridUnitType.Pixel);
		}
		else if (_side == AnchorSide.Bottom)
		{
			if (_model.AutoHideHeight == 0.0)
			{
				_model.AutoHideHeight = _internalHost.ActualHeight - num;
			}
			else
			{
				_model.AutoHideHeight -= num;
			}
			_internalGrid.RowDefinitions[1].Height = new GridLength(double.IsNaN(_model.AutoHideHeight) ? 0.0 : _model.AutoHideHeight, GridUnitType.Pixel);
		}
		HideResizerOverlayWindow();
		IsResizing = false;
		InvalidateMeasure();
	}

	private void OnResizerDragDelta(object sender, DragDeltaEventArgs e)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		Visual ancestor = ((DependencyObject)(object)this).FindVisualTreeRoot() as Visual;
		GeneralTransform generalTransform = TransformToAncestor(ancestor);
		Vector val = generalTransform.Transform(new Point(e.HorizontalChange, e.VerticalChange)) - generalTransform.Transform(default(Point));
		if (_side == AnchorSide.Right || _side == AnchorSide.Left)
		{
			if (FrameworkElement.GetFlowDirection((DependencyObject)(object)_internalHost) == FlowDirection.RightToLeft)
			{
				((Vector)(ref val)).X = 0.0 - ((Vector)(ref val)).X;
			}
			Canvas.SetLeft(_resizerGhost, MathHelper.MinMax(((Vector)(ref _initialStartPoint)).X + ((Vector)(ref val)).X, 0.0, _resizerWindowHost.Width - _resizerGhost.Width));
		}
		else
		{
			Canvas.SetTop(_resizerGhost, MathHelper.MinMax(((Vector)(ref _initialStartPoint)).Y + ((Vector)(ref val)).Y, 0.0, _resizerWindowHost.Height - _resizerGhost.Height));
		}
	}

	private void OnResizerDragStarted(object sender, DragStartedEventArgs e)
	{
		LayoutGridResizerControl splitter = sender as LayoutGridResizerControl;
		ShowResizerOverlayWindow(splitter);
		IsResizing = true;
	}
}
