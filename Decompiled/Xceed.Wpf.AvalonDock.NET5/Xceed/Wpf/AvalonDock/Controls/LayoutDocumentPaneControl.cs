using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls;

public class LayoutDocumentPaneControl : LayoutCachePaneControl, ILayoutControl
{
	private List<object> _logicalChildren = new List<object>();

	private LayoutDocumentPane _model;

	public ILayoutElement Model => _model;

	protected override IEnumerator LogicalChildren => _logicalChildren.GetEnumerator();

	static LayoutDocumentPaneControl()
	{
		UIElement.FocusableProperty.OverrideMetadata(typeof(LayoutDocumentPaneControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
	}

	internal LayoutDocumentPaneControl(LayoutDocumentPane model)
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

	protected override void OnSelectionChanged(SelectionChangedEventArgs e)
	{
		base.OnSelectionChanged(e);
		if (_model.SelectedContent != null)
		{
			_model.SelectedContent.IsActive = true;
		}
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
		if (base.IsLoaded)
		{
			LayoutDocumentPane model = _model;
			((ILayoutPositionableElementWithActualSize)model).ActualWidth = base.ActualWidth;
			((ILayoutPositionableElementWithActualSize)model).ActualHeight = base.ActualHeight;
		}
	}
}
