using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Windows.Shell;
using Xceed.Wpf.AvalonDock.Commands;
using Xceed.Wpf.AvalonDock.Converters;
using Xceed.Wpf.AvalonDock.Layout;
using Xceed.Wpf.AvalonDock.Themes;

namespace Xceed.Wpf.AvalonDock.Controls;

public class LayoutAnchorableFloatingWindowControl : LayoutFloatingWindowControl, IOverlayWindowHost
{
	private LayoutAnchorableFloatingWindow _model;

	private OverlayWindow _overlayWindow;

	private List<IDropArea> _dropAreas;

	public static readonly DependencyProperty SingleContentLayoutItemProperty;

	public LayoutItem SingleContentLayoutItem
	{
		get
		{
			return (LayoutItem)((DependencyObject)this).GetValue(SingleContentLayoutItemProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SingleContentLayoutItemProperty, (object)value);
		}
	}

	public override ILayoutElement Model => _model;

	public ICommand HideWindowCommand { get; private set; }

	public ICommand CloseWindowCommand { get; private set; }

	DockingManager IOverlayWindowHost.Manager => _model.Root.Manager;

	static LayoutAnchorableFloatingWindowControl()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		SingleContentLayoutItemProperty = DependencyProperty.Register("SingleContentLayoutItem", typeof(LayoutItem), typeof(LayoutAnchorableFloatingWindowControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnSingleContentLayoutItemChanged)));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(LayoutAnchorableFloatingWindowControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(LayoutAnchorableFloatingWindowControl)));
	}

	internal LayoutAnchorableFloatingWindowControl(LayoutAnchorableFloatingWindow model, bool isContentImmutable)
		: base(model, isContentImmutable)
	{
		_model = model;
		HideWindowCommand = new RelayCommand(delegate(object p)
		{
			OnExecuteHideWindowCommand(p);
		}, (object p) => CanExecuteHideWindowCommand(p));
		CloseWindowCommand = new RelayCommand(delegate(object p)
		{
			OnExecuteCloseWindowCommand(p);
		}, (object p) => CanExecuteCloseWindowCommand(p));
		UpdateThemeResources();
	}

	internal LayoutAnchorableFloatingWindowControl(LayoutAnchorableFloatingWindow model)
		: this(model, isContentImmutable: false)
	{
	}

	private static void OnSingleContentLayoutItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((LayoutAnchorableFloatingWindowControl)(object)d).OnSingleContentLayoutItemChanged(e);
	}

	protected virtual void OnSingleContentLayoutItemChanged(DependencyPropertyChangedEventArgs e)
	{
	}

	protected override void OnInitialized(EventArgs e)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		base.OnInitialized(e);
		DockingManager manager = _model.Root.Manager;
		base.Content = manager.CreateUIElementForModel(_model.RootPanel);
		base.IsVisibleChanged += new DependencyPropertyChangedEventHandler(LayoutAnchorableFloatingWindowControl_IsVisibleChanged);
		SetBinding(SingleContentLayoutItemProperty, new Binding("Model.SinglePane.SelectedContent")
		{
			Source = this,
			Converter = new LayoutItemFromLayoutModelConverter()
		});
		_model.PropertyChanged += _model_PropertyChanged;
	}

	protected override void OnClosed(EventArgs e)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		if (_overlayWindow != null)
		{
			_overlayWindow.Close();
			_overlayWindow = null;
		}
		base.OnClosed(e);
		_model.PropertyChanged -= _model_PropertyChanged;
		base.IsVisibleChanged -= new DependencyPropertyChangedEventHandler(LayoutAnchorableFloatingWindowControl_IsVisibleChanged);
		BindingOperations.ClearBinding((DependencyObject)(object)this, UIElement.VisibilityProperty);
		BindingOperations.ClearBinding((DependencyObject)(object)this, SingleContentLayoutItemProperty);
	}

	protected override IntPtr FilterMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
	{
		switch (msg)
		{
		case 161:
			if (wParam.ToInt32() == 2)
			{
				_model.Descendents().OfType<LayoutAnchorablePane>().First((LayoutAnchorablePane p) => p.ChildrenCount > 0 && p.SelectedContent != null)
					.SelectedContent.IsActive = true;
				handled = true;
			}
			break;
		case 165:
			if (wParam.ToInt32() == 2)
			{
				if (OpenContextMenu())
				{
					handled = true;
				}
				if (_model.Root.Manager.ShowSystemMenu)
				{
					WindowChrome.GetWindowChrome(this).ShowSystemMenu = !handled;
				}
				else
				{
					WindowChrome.GetWindowChrome(this).ShowSystemMenu = false;
				}
			}
			break;
		}
		return base.FilterMessage(hwnd, msg, wParam, lParam, ref handled);
	}

	internal override void UpdateThemeResources(Theme oldTheme = null)
	{
		base.UpdateThemeResources(oldTheme);
		if (_overlayWindow != null)
		{
			_overlayWindow.UpdateThemeResources(oldTheme);
		}
	}

	protected override bool CanClose(object parameter = null)
	{
		if (Model == null)
		{
			return false;
		}
		ILayoutRoot root = Model.Root;
		if (root == null)
		{
			return false;
		}
		DockingManager manager = root.Manager;
		if (manager == null)
		{
			return false;
		}
		LayoutAnchorable[] array = Model.Descendents().OfType<LayoutAnchorable>().ToArray();
		foreach (LayoutAnchorable layoutAnchorable in array)
		{
			if (!layoutAnchorable.CanClose)
			{
				return false;
			}
			if (!(manager.GetLayoutItemFromModel(layoutAnchorable) is LayoutAnchorableItem { CloseCommand: not null } layoutAnchorableItem) || !layoutAnchorableItem.CloseCommand.CanExecute(parameter))
			{
				return false;
			}
		}
		return true;
	}

	protected override bool CanHide(object parameter = null)
	{
		if (Model == null)
		{
			return false;
		}
		ILayoutRoot root = Model.Root;
		if (root == null)
		{
			return false;
		}
		DockingManager manager = root.Manager;
		if (manager == null)
		{
			return false;
		}
		LayoutAnchorable[] array = Model.Descendents().OfType<LayoutAnchorable>().ToArray();
		foreach (LayoutAnchorable layoutAnchorable in array)
		{
			if (!layoutAnchorable.CanHide)
			{
				return false;
			}
			if (!(manager.GetLayoutItemFromModel(layoutAnchorable) is LayoutAnchorableItem { HideCommand: not null } layoutAnchorableItem) || !layoutAnchorableItem.HideCommand.CanExecute(parameter))
			{
				return false;
			}
		}
		return true;
	}

	protected override void DoHide()
	{
		OnExecuteHideWindowCommand(null);
	}

	private void _model_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "RootPanel" && _model.RootPanel == null)
		{
			InternalClose();
		}
	}

	private void CreateOverlayWindow()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		if (_overlayWindow == null)
		{
			_overlayWindow = new OverlayWindow(this);
		}
		Rect val = default(Rect);
		((Rect)(ref val))._002Ector(this.PointToScreenDPIWithoutFlowDirection(default(Point)), this.TransformActualSizeToAncestor());
		_overlayWindow.Left = ((Rect)(ref val)).Left;
		_overlayWindow.Top = ((Rect)(ref val)).Top;
		_overlayWindow.Width = ((Rect)(ref val)).Width;
		_overlayWindow.Height = ((Rect)(ref val)).Height;
	}

	private bool OpenContextMenu()
	{
		ContextMenu anchorableContextMenu = _model.Root.Manager.AnchorableContextMenu;
		if (anchorableContextMenu != null && SingleContentLayoutItem != null)
		{
			anchorableContextMenu.PlacementTarget = null;
			anchorableContextMenu.Placement = PlacementMode.MousePoint;
			anchorableContextMenu.DataContext = SingleContentLayoutItem;
			anchorableContextMenu.IsOpen = true;
			return true;
		}
		return false;
	}

	private bool IsContextMenuOpen()
	{
		ContextMenu anchorableContextMenu = _model.Root.Manager.AnchorableContextMenu;
		if (anchorableContextMenu != null && SingleContentLayoutItem != null)
		{
			return anchorableContextMenu.IsOpen;
		}
		return false;
	}

	private void LayoutAnchorableFloatingWindowControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
	{
		BindingExpression bindingExpression = GetBindingExpression(UIElement.VisibilityProperty);
		if (base.IsVisible && bindingExpression == null)
		{
			SetBinding(UIElement.VisibilityProperty, new Binding("IsVisible")
			{
				Source = _model,
				Converter = new BoolToVisibilityConverter(),
				Mode = BindingMode.OneWay,
				ConverterParameter = Visibility.Hidden
			});
		}
	}

	private bool CanExecuteHideWindowCommand(object parameter)
	{
		return CanHide(parameter);
	}

	private void OnExecuteHideWindowCommand(object parameter)
	{
		DockingManager manager = Model.Root.Manager;
		LayoutAnchorable[] array = Model.Descendents().OfType<LayoutAnchorable>().ToArray();
		foreach (LayoutAnchorable content in array)
		{
			(manager.GetLayoutItemFromModel(content) as LayoutAnchorableItem).HideCommand.Execute(parameter);
		}
		BringFocusOnDockingManager();
	}

	private bool CanExecuteCloseWindowCommand(object parameter)
	{
		return CanClose(parameter);
	}

	private void OnExecuteCloseWindowCommand(object parameter)
	{
		DockingManager manager = Model.Root.Manager;
		LayoutAnchorable[] array = Model.Descendents().OfType<LayoutAnchorable>().ToArray();
		foreach (LayoutAnchorable content in array)
		{
			(manager.GetLayoutItemFromModel(content) as LayoutAnchorableItem).CloseCommand.Execute(parameter);
		}
	}

	bool IOverlayWindowHost.HitTest(Point dragPoint)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		Rect val = default(Rect);
		((Rect)(ref val))._002Ector(this.PointToScreenDPIWithoutFlowDirection(default(Point)), this.TransformActualSizeToAncestor());
		return ((Rect)(ref val)).Contains(dragPoint);
	}

	IOverlayWindow IOverlayWindowHost.ShowOverlayWindow(LayoutFloatingWindowControl draggingWindow)
	{
		CreateOverlayWindow();
		_overlayWindow.Owner = draggingWindow;
		_overlayWindow.EnableDropTargets();
		_overlayWindow.Show();
		return _overlayWindow;
	}

	void IOverlayWindowHost.HideOverlayWindow()
	{
		_dropAreas = null;
		_overlayWindow.Owner = null;
		_overlayWindow.HideDropTargets();
	}

	IEnumerable<IDropArea> IOverlayWindowHost.GetDropAreas(LayoutFloatingWindowControl draggingWindow)
	{
		if (_dropAreas != null)
		{
			return _dropAreas;
		}
		DockingManager manager = draggingWindow.Model.Root.Manager;
		_dropAreas = new List<IDropArea>();
		if (draggingWindow.Model is LayoutDocumentFloatingWindow)
		{
			return _dropAreas;
		}
		Visual depObj = base.Content as Visual;
		foreach (LayoutAnchorablePaneControl item in ((DependencyObject)(object)depObj).FindVisualChildren<LayoutAnchorablePaneControl>())
		{
			if (manager == item.Model.Root.Manager)
			{
				_dropAreas.Add(new DropArea<LayoutAnchorablePaneControl>(item, DropAreaType.AnchorablePane));
			}
		}
		foreach (LayoutDocumentPaneControl item2 in ((DependencyObject)(object)depObj).FindVisualChildren<LayoutDocumentPaneControl>())
		{
			if (manager == item2.Model.Root.Manager)
			{
				_dropAreas.Add(new DropArea<LayoutDocumentPaneControl>(item2, DropAreaType.DocumentPane));
			}
		}
		return _dropAreas;
	}
}
