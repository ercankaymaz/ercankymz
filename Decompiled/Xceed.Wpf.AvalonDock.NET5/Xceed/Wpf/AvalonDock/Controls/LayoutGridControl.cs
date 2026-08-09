using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls;

public abstract class LayoutGridControl<T> : Grid, ILayoutControl where T : class, ILayoutPanelElement
{
	private LayoutPositionableGroup<T> _model;

	private Orientation _orientation;

	private bool _initialized;

	private ChildrenTreeChange? _asyncRefreshCalled;

	private ReentrantFlag _fixingChildrenDockLengths = new ReentrantFlag();

	private Border _resizerGhost;

	private Window _resizerWindowHost;

	private Vector _initialStartPoint;

	public ILayoutElement Model => _model;

	public Orientation Orientation => (_model as ILayoutOrientableGroup).Orientation;

	private bool AsyncRefreshCalled => _asyncRefreshCalled.HasValue;

	static LayoutGridControl()
	{
	}

	internal LayoutGridControl(LayoutPositionableGroup<T> model, Orientation orientation)
	{
		if (model == null)
		{
			throw new ArgumentNullException("model");
		}
		_model = model;
		_orientation = orientation;
		base.FlowDirection = FlowDirection.LeftToRight;
	}

	protected override void OnInitialized(EventArgs e)
	{
		base.OnInitialized(e);
		_model.ChildrenTreeChanged += delegate(object? s, ChildrenTreeChangedEventArgs args)
		{
			if (args.Change == ChildrenTreeChange.DirectChildrenChanged && (!_asyncRefreshCalled.HasValue || _asyncRefreshCalled.Value != args.Change))
			{
				_asyncRefreshCalled = args.Change;
				((DispatcherObject)this).Dispatcher.BeginInvoke((Delegate)(Action)delegate
				{
					_asyncRefreshCalled = null;
					UpdateChildren();
				}, (DispatcherPriority)9, (object[])null);
			}
		};
		base.LayoutUpdated += OnLayoutUpdated;
	}

	protected void FixChildrenDockLengths()
	{
		using (_fixingChildrenDockLengths.Enter())
		{
			OnFixChildrenDockLengths();
		}
	}

	protected abstract void OnFixChildrenDockLengths();

	private void OnLayoutUpdated(object sender, EventArgs e)
	{
		LayoutPositionableGroup<T> model = _model;
		((ILayoutPositionableElementWithActualSize)model).ActualWidth = base.ActualWidth;
		((ILayoutPositionableElementWithActualSize)model).ActualHeight = base.ActualHeight;
		if (!_initialized)
		{
			_initialized = true;
			UpdateChildren();
		}
	}

	private void UpdateChildren()
	{
		ILayoutControl[] source = base.Children.OfType<ILayoutControl>().ToArray();
		DetachOldSplitters();
		DetachPropertChangeHandler();
		base.Children.Clear();
		base.ColumnDefinitions.Clear();
		base.RowDefinitions.Clear();
		if (_model == null || _model.Root == null)
		{
			return;
		}
		DockingManager manager = _model.Root.Manager;
		if (manager == null)
		{
			return;
		}
		foreach (T child in _model.Children)
		{
			ILayoutControl layoutControl = source.FirstOrDefault((ILayoutControl chVM) => chVM.Model == child);
			if (layoutControl != null)
			{
				base.Children.Add(layoutControl as UIElement);
			}
			else
			{
				base.Children.Add(manager.CreateUIElementForModel(child));
			}
		}
		CreateSplitters();
		UpdateRowColDefinitions();
		AttachNewSplitters();
		AttachPropertyChangeHandler();
	}

	private void AttachPropertyChangeHandler()
	{
		foreach (ILayoutControl item in base.InternalChildren.OfType<ILayoutControl>())
		{
			item.Model.PropertyChanged += OnChildModelPropertyChanged;
		}
	}

	private void DetachPropertChangeHandler()
	{
		foreach (ILayoutControl item in base.InternalChildren.OfType<ILayoutControl>())
		{
			item.Model.PropertyChanged -= OnChildModelPropertyChanged;
		}
	}

	private void OnChildModelPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		if (AsyncRefreshCalled)
		{
			return;
		}
		if (_fixingChildrenDockLengths.CanEnter && e.PropertyName == "DockWidth" && Orientation == Orientation.Horizontal)
		{
			if (base.ColumnDefinitions.Count == base.InternalChildren.Count)
			{
				ILayoutPositionableElement changedElement = sender as ILayoutPositionableElement;
				UIElement element = base.InternalChildren.OfType<ILayoutControl>().First((ILayoutControl ch) => ch.Model == changedElement) as UIElement;
				int index = base.InternalChildren.IndexOf(element);
				base.ColumnDefinitions[index].Width = changedElement.DockWidth;
			}
		}
		else if (_fixingChildrenDockLengths.CanEnter && e.PropertyName == "DockHeight" && Orientation == Orientation.Vertical)
		{
			if (base.RowDefinitions.Count == base.InternalChildren.Count)
			{
				ILayoutPositionableElement changedElement2 = sender as ILayoutPositionableElement;
				UIElement element2 = base.InternalChildren.OfType<ILayoutControl>().First((ILayoutControl ch) => ch.Model == changedElement2) as UIElement;
				int index2 = base.InternalChildren.IndexOf(element2);
				base.RowDefinitions[index2].Height = changedElement2.DockHeight;
			}
		}
		else if (e.PropertyName == "IsVisible")
		{
			UpdateRowColDefinitions();
		}
	}

	private void UpdateRowColDefinitions()
	{
		ILayoutRoot root = _model.Root;
		if (root == null)
		{
			return;
		}
		DockingManager manager = root.Manager;
		if (manager == null)
		{
			return;
		}
		FixChildrenDockLengths();
		base.RowDefinitions.Clear();
		base.ColumnDefinitions.Clear();
		if (Orientation == Orientation.Horizontal)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			while (num3 < _model.Children.Count)
			{
				ILayoutPositionableElement layoutPositionableElement = _model.Children[num3] as ILayoutPositionableElement;
				base.ColumnDefinitions.Add(new ColumnDefinition
				{
					Width = (layoutPositionableElement.IsVisible ? layoutPositionableElement.DockWidth : new GridLength(0.0, GridUnitType.Pixel)),
					MinWidth = (layoutPositionableElement.IsVisible ? layoutPositionableElement.DockMinWidth : 0.0)
				});
				Grid.SetColumn(base.InternalChildren[num2], num);
				if (num2 < base.InternalChildren.Count - 1)
				{
					num2++;
					num++;
					bool flag = false;
					for (int i = num3 + 1; i < _model.Children.Count; i++)
					{
						if ((_model.Children[i] as ILayoutPositionableElement).IsVisible)
						{
							flag = true;
							break;
						}
					}
					base.ColumnDefinitions.Add(new ColumnDefinition
					{
						Width = ((layoutPositionableElement.IsVisible && flag) ? new GridLength(double.IsNaN(manager.GridSplitterWidth) ? 6.0 : manager.GridSplitterWidth) : new GridLength(0.0, GridUnitType.Pixel))
					});
					Grid.SetColumn(base.InternalChildren[num2], num);
				}
				num3++;
				num++;
				num2++;
			}
			return;
		}
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		while (num6 < _model.Children.Count)
		{
			ILayoutPositionableElement layoutPositionableElement2 = _model.Children[num6] as ILayoutPositionableElement;
			base.RowDefinitions.Add(new RowDefinition
			{
				Height = (layoutPositionableElement2.IsVisible ? layoutPositionableElement2.DockHeight : new GridLength(0.0, GridUnitType.Pixel)),
				MinHeight = (layoutPositionableElement2.IsVisible ? layoutPositionableElement2.DockMinHeight : 0.0)
			});
			Grid.SetRow(base.InternalChildren[num5], num4);
			if (num5 < base.InternalChildren.Count - 1)
			{
				num5++;
				num4++;
				bool flag2 = false;
				for (int j = num6 + 1; j < _model.Children.Count; j++)
				{
					if ((_model.Children[j] as ILayoutPositionableElement).IsVisible)
					{
						flag2 = true;
						break;
					}
				}
				base.RowDefinitions.Add(new RowDefinition
				{
					Height = ((layoutPositionableElement2.IsVisible && flag2) ? new GridLength(double.IsNaN(manager.GridSplitterHeight) ? 6.0 : manager.GridSplitterHeight) : new GridLength(0.0, GridUnitType.Pixel))
				});
				Grid.SetRow(base.InternalChildren[num5], num4);
			}
			num6++;
			num4++;
			num5++;
		}
	}

	private void CreateSplitters()
	{
		int num;
		for (num = 1; num < base.Children.Count; num++)
		{
			LayoutGridResizerControl layoutGridResizerControl = new LayoutGridResizerControl();
			layoutGridResizerControl.Cursor = ((Orientation == Orientation.Horizontal) ? Cursors.SizeWE : Cursors.SizeNS);
			base.Children.Insert(num, layoutGridResizerControl);
			num++;
		}
	}

	private void DetachOldSplitters()
	{
		foreach (LayoutGridResizerControl item in base.Children.OfType<LayoutGridResizerControl>())
		{
			item.DragStarted -= OnSplitterDragStarted;
			item.DragDelta -= OnSplitterDragDelta;
			item.DragCompleted -= OnSplitterDragCompleted;
		}
	}

	private void AttachNewSplitters()
	{
		foreach (LayoutGridResizerControl item in base.Children.OfType<LayoutGridResizerControl>())
		{
			item.DragStarted += OnSplitterDragStarted;
			item.DragDelta += OnSplitterDragDelta;
			item.DragCompleted += OnSplitterDragCompleted;
		}
	}

	private void OnSplitterDragStarted(object sender, DragStartedEventArgs e)
	{
		LayoutGridResizerControl splitter = sender as LayoutGridResizerControl;
		ShowResizerOverlayWindow(splitter);
	}

	private void OnSplitterDragDelta(object sender, DragDeltaEventArgs e)
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
		if (Orientation == Orientation.Horizontal)
		{
			Canvas.SetLeft(_resizerGhost, MathHelper.MinMax(((Vector)(ref _initialStartPoint)).X + ((Vector)(ref val)).X, 0.0, _resizerWindowHost.Width - _resizerGhost.Width));
		}
		else
		{
			Canvas.SetTop(_resizerGhost, MathHelper.MinMax(((Vector)(ref _initialStartPoint)).Y + ((Vector)(ref val)).Y, 0.0, _resizerWindowHost.Height - _resizerGhost.Height));
		}
	}

	private void OnSplitterDragCompleted(object sender, DragCompletedEventArgs e)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		LayoutGridResizerControl element = sender as LayoutGridResizerControl;
		Visual ancestor = ((DependencyObject)(object)this).FindVisualTreeRoot() as Visual;
		GeneralTransform generalTransform = TransformToAncestor(ancestor);
		_ = generalTransform.Transform(new Point(e.HorizontalChange, e.VerticalChange)) - generalTransform.Transform(default(Point));
		double num = ((Orientation != Orientation.Horizontal) ? (Canvas.GetTop(_resizerGhost) - ((Vector)(ref _initialStartPoint)).Y) : (Canvas.GetLeft(_resizerGhost) - ((Vector)(ref _initialStartPoint)).X));
		int num2 = base.InternalChildren.IndexOf(element);
		FrameworkElement obj = base.InternalChildren[num2 - 1] as FrameworkElement;
		FrameworkElement nextVisibleChild = GetNextVisibleChild(num2);
		Size val = obj.TransformActualSizeToAncestor();
		Size val2 = (Size)(((_003F?)nextVisibleChild?.TransformActualSizeToAncestor()) ?? default(Size));
		Size val3 = default(Size);
		((Size)(ref val3))._002Ector(((Size)(ref val)).Width + ((Size)(ref val2)).Width, ((Size)(ref val)).Height + ((Size)(ref val2)).Height);
		ILayoutPositionableElement layoutPositionableElement = (ILayoutPositionableElement)(obj as ILayoutControl).Model;
		ILayoutPositionableElement layoutPositionableElement2 = ((nextVisibleChild != null) ? ((ILayoutPositionableElement)(nextVisibleChild as ILayoutControl).Model) : null);
		Size val4 = default(Size);
		((Size)(ref val4))._002Ector((layoutPositionableElement.DockWidth.IsStar && layoutPositionableElement2.DockWidth.IsStar) ? (layoutPositionableElement.DockWidth.Value + layoutPositionableElement2.DockWidth.Value) : 1.0, (layoutPositionableElement.DockHeight.IsStar && layoutPositionableElement2.DockHeight.IsStar) ? (layoutPositionableElement.DockHeight.Value + layoutPositionableElement2.DockHeight.Value) : 1.0);
		if (Orientation == Orientation.Horizontal)
		{
			if (layoutPositionableElement.DockWidth.IsStar)
			{
				layoutPositionableElement.DockWidth = new GridLength((((Size)(ref val)).Width + num) / ((Size)(ref val3)).Width * ((Size)(ref val4)).Width, GridUnitType.Star);
			}
			else
			{
				double value = Math.Max((layoutPositionableElement.DockWidth.IsAuto ? ((Size)(ref val)).Width : layoutPositionableElement.DockWidth.Value) + num, layoutPositionableElement.DockMinWidth);
				layoutPositionableElement.DockWidth = new GridLength(value, GridUnitType.Pixel);
			}
			if (layoutPositionableElement2 != null)
			{
				if (layoutPositionableElement2.DockWidth.IsStar)
				{
					layoutPositionableElement2.DockWidth = new GridLength((((Size)(ref val2)).Width - num) / ((Size)(ref val3)).Width * ((Size)(ref val4)).Width, GridUnitType.Star);
				}
				else
				{
					double value2 = Math.Max((layoutPositionableElement2.DockWidth.IsAuto ? ((Size)(ref val2)).Width : layoutPositionableElement2.DockWidth.Value) - num, layoutPositionableElement2.DockMinWidth);
					layoutPositionableElement2.DockWidth = new GridLength(value2, GridUnitType.Pixel);
				}
			}
		}
		else
		{
			if (layoutPositionableElement.DockHeight.IsStar)
			{
				layoutPositionableElement.DockHeight = new GridLength((((Size)(ref val)).Height + num) / ((Size)(ref val3)).Height * ((Size)(ref val4)).Height, GridUnitType.Star);
			}
			else
			{
				double value3 = Math.Max((layoutPositionableElement.DockHeight.IsAuto ? ((Size)(ref val)).Height : layoutPositionableElement.DockHeight.Value) + num, layoutPositionableElement.DockMinHeight);
				layoutPositionableElement.DockHeight = new GridLength(value3, GridUnitType.Pixel);
			}
			if (layoutPositionableElement2 != null)
			{
				if (layoutPositionableElement2.DockHeight.IsStar)
				{
					layoutPositionableElement2.DockHeight = new GridLength((((Size)(ref val2)).Height - num) / ((Size)(ref val3)).Height * ((Size)(ref val4)).Height, GridUnitType.Star);
				}
				else
				{
					double value4 = Math.Max((layoutPositionableElement2.DockHeight.IsAuto ? ((Size)(ref val2)).Height : layoutPositionableElement2.DockHeight.Value) - num, layoutPositionableElement2.DockMinHeight);
					layoutPositionableElement2.DockHeight = new GridLength(value4, GridUnitType.Pixel);
				}
			}
		}
		HideResizerOverlayWindow();
	}

	private FrameworkElement GetNextVisibleChild(int index)
	{
		for (int i = index + 1; i < base.InternalChildren.Count; i++)
		{
			if (base.InternalChildren[i] is LayoutGridResizerControl)
			{
				continue;
			}
			if (Orientation == Orientation.Horizontal)
			{
				if (base.ColumnDefinitions[i].Width.IsStar || base.ColumnDefinitions[i].Width.Value > 0.0)
				{
					return base.InternalChildren[i] as FrameworkElement;
				}
			}
			else if (base.RowDefinitions[i].Height.IsStar || base.RowDefinitions[i].Height.Value > 0.0)
			{
				return base.InternalChildren[i] as FrameworkElement;
			}
		}
		return null;
	}

	private void ShowResizerOverlayWindow(LayoutGridResizerControl splitter)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		_resizerGhost = new Border
		{
			Background = splitter.BackgroundWhileDragging,
			Opacity = splitter.OpacityWhileDragging
		};
		int num = base.InternalChildren.IndexOf(splitter);
		FrameworkElement obj = base.InternalChildren[num - 1] as FrameworkElement;
		FrameworkElement nextVisibleChild = GetNextVisibleChild(num);
		Size val = obj.TransformActualSizeToAncestor();
		Size val2 = (Size)(((_003F?)nextVisibleChild?.TransformActualSizeToAncestor()) ?? default(Size));
		ILayoutPositionableElement layoutPositionableElement = (ILayoutPositionableElement)(obj as ILayoutControl).Model;
		ILayoutPositionableElement layoutPositionableElement2 = ((nextVisibleChild != null) ? ((ILayoutPositionableElement)(nextVisibleChild as ILayoutControl).Model) : null);
		Point val3 = obj.PointToScreenDPIWithoutFlowDirection(default(Point));
		Size val4 = default(Size);
		if (Orientation == Orientation.Horizontal)
		{
			double num2 = layoutPositionableElement2?.DockMinWidth ?? 0.0;
			((Size)(ref val4))._002Ector(((Size)(ref val)).Width - layoutPositionableElement.DockMinWidth + splitter.ActualWidth + ((Size)(ref val2)).Width - num2, ((Size)(ref val2)).Height);
			_resizerGhost.Width = splitter.ActualWidth;
			_resizerGhost.Height = ((Size)(ref val4)).Height;
			((Point)(ref val3)).Offset(layoutPositionableElement.DockMinWidth, 0.0);
		}
		else
		{
			double num3 = layoutPositionableElement2?.DockMinHeight ?? 0.0;
			((Size)(ref val4))._002Ector(((Size)(ref val)).Width, ((Size)(ref val)).Height - layoutPositionableElement.DockMinHeight + splitter.ActualHeight + ((Size)(ref val2)).Height - num3);
			_resizerGhost.Height = splitter.ActualHeight;
			_resizerGhost.Width = ((Size)(ref val4)).Width;
			((Point)(ref val3)).Offset(0.0, layoutPositionableElement.DockMinHeight);
		}
		_initialStartPoint = splitter.PointToScreenDPIWithoutFlowDirection(default(Point)) - val3;
		if (Orientation == Orientation.Horizontal)
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
			SizeToContent = SizeToContent.Manual,
			ResizeMode = ResizeMode.NoResize,
			WindowStyle = WindowStyle.None,
			ShowInTaskbar = false,
			AllowsTransparency = true,
			Background = null,
			Width = ((Size)(ref val4)).Width,
			Height = ((Size)(ref val4)).Height,
			Left = ((Point)(ref val3)).X,
			Top = ((Point)(ref val3)).Y,
			ShowActivated = false,
			Content = canvas
		};
		_resizerWindowHost.Loaded += delegate
		{
			_resizerWindowHost.SetParentToMainWindowOf(this);
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
}
