using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls;

public class LayoutAnchorablePaneControl : LayoutCachePaneControl, ILayoutControl
{
	private LayoutAnchorablePane _model;

	public ILayoutElement Model => _model;

	static LayoutAnchorablePaneControl()
	{
		UIElement.FocusableProperty.OverrideMetadata(typeof(LayoutAnchorablePaneControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
	}

	public LayoutAnchorablePaneControl(LayoutAnchorablePane model)
	{
		if (model == null)
		{
			throw new ArgumentNullException("model");
		}
		_model = model;
		SetBinding(ItemsControl.ItemsSourceProperty, new Binding("Model.Children")
		{
			Source = this
		});
		SetBinding(FrameworkElement.FlowDirectionProperty, new Binding("Model.Root.Manager.FlowDirection")
		{
			Source = this
		});
		base.LayoutUpdated += OnLayoutUpdated;
	}

	protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
	{
		if (_model != null && _model.SelectedContent != null)
		{
			_model.SelectedContent.IsActive = true;
		}
		base.OnGotKeyboardFocus(e);
	}

	protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		base.OnMouseLeftButtonDown(e);
		if (e.OriginalSource is Visual)
		{
			DockingManager obj = ((DependencyObject)(object)(Visual)e.OriginalSource).FindVisualAncestor<DockingManager>();
			if (Model != null && Model.Root != null && Model.Root.Manager != null && ((object)Model.Root.Manager).Equals((object?)obj) && !e.Handled && _model != null && _model.SelectedContent != null)
			{
				_model.SelectedContent.IsActive = true;
			}
		}
	}

	protected override void OnMouseRightButtonDown(MouseButtonEventArgs e)
	{
		base.OnMouseRightButtonDown(e);
		if (e.OriginalSource is Visual)
		{
			DockingManager obj = ((DependencyObject)(object)(Visual)e.OriginalSource).FindVisualAncestor<DockingManager>();
			if (Model != null && Model.Root != null && Model.Root.Manager != null && ((object)Model.Root.Manager).Equals((object?)obj) && !e.Handled && _model != null && _model.SelectedContent != null)
			{
				_model.SelectedContent.IsActive = true;
			}
		}
	}

	private void OnLayoutUpdated(object sender, EventArgs e)
	{
		LayoutAnchorablePane model = _model;
		((ILayoutPositionableElementWithActualSize)model).ActualWidth = base.ActualWidth;
		((ILayoutPositionableElementWithActualSize)model).ActualHeight = base.ActualHeight;
	}
}
