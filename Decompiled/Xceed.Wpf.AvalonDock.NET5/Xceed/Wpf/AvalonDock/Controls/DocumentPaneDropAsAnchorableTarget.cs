using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls;

internal class DocumentPaneDropAsAnchorableTarget : DropTarget<LayoutDocumentPaneControl>
{
	private LayoutDocumentPaneControl _targetPane;

	private int _tabIndex = -1;

	internal DocumentPaneDropAsAnchorableTarget(LayoutDocumentPaneControl paneControl, Rect detectionRect, DropTargetType type)
		: base(paneControl, detectionRect, type)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		_targetPane = paneControl;
	}

	internal DocumentPaneDropAsAnchorableTarget(LayoutDocumentPaneControl paneControl, Rect detectionRect, DropTargetType type, int tabIndex)
		: base(paneControl, detectionRect, type)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		_targetPane = paneControl;
		_tabIndex = tabIndex;
	}

	protected override void Drop(LayoutAnchorableFloatingWindow floatingWindow)
	{
		ILayoutDocumentPane layoutDocumentPane = _targetPane.Model as ILayoutDocumentPane;
		FindParentLayoutDocumentPane(layoutDocumentPane, out var containerPaneGroup, out var containerPanel);
		if (layoutDocumentPane.FindParent<LayoutFloatingWindow>() == null && floatingWindow != null && floatingWindow.Root != null && floatingWindow.Root.ActiveContent != null)
		{
			floatingWindow.Root.ActiveContent.IsFloating = false;
		}
		switch (base.Type)
		{
		case DropTargetType.DocumentPaneDockAsAnchorableBottom:
			if (containerPanel != null && containerPanel.ChildrenCount == 1)
			{
				containerPanel.Orientation = Orientation.Vertical;
			}
			if (containerPanel != null && containerPanel.Orientation == Orientation.Vertical)
			{
				ObservableCollection<ILayoutPanelElement> children3 = containerPanel.Children;
				LayoutPanel layoutPanel4 = containerPanel;
				ILayoutDocumentPane element2;
				if (containerPaneGroup == null)
				{
					element2 = layoutDocumentPane;
				}
				else
				{
					ILayoutDocumentPane layoutDocumentPane2 = containerPaneGroup;
					element2 = layoutDocumentPane2;
				}
				children3.Insert(layoutPanel4.IndexOfChild(element2) + 1, floatingWindow.RootPanel);
				break;
			}
			if (containerPanel != null)
			{
				LayoutPanel layoutPanel5 = new LayoutPanel
				{
					Orientation = Orientation.Vertical
				};
				LayoutPanel layoutPanel6 = containerPanel;
				ILayoutDocumentPane oldElement2;
				if (containerPaneGroup == null)
				{
					oldElement2 = layoutDocumentPane;
				}
				else
				{
					ILayoutDocumentPane layoutDocumentPane2 = containerPaneGroup;
					oldElement2 = layoutDocumentPane2;
				}
				layoutPanel6.ReplaceChild(oldElement2, layoutPanel5);
				ObservableCollection<ILayoutPanelElement> children4 = layoutPanel5.Children;
				ILayoutDocumentPane item2;
				if (containerPaneGroup == null)
				{
					item2 = layoutDocumentPane;
				}
				else
				{
					ILayoutDocumentPane layoutDocumentPane2 = containerPaneGroup;
					item2 = layoutDocumentPane2;
				}
				children4.Add(item2);
				layoutPanel5.Children.Add(floatingWindow.RootPanel);
				break;
			}
			throw new NotImplementedException();
		case DropTargetType.DocumentPaneDockAsAnchorableTop:
			if (containerPanel != null && containerPanel.ChildrenCount == 1)
			{
				containerPanel.Orientation = Orientation.Vertical;
			}
			if (containerPanel != null && containerPanel.Orientation == Orientation.Vertical)
			{
				ObservableCollection<ILayoutPanelElement> children7 = containerPanel.Children;
				LayoutPanel layoutPanel10 = containerPanel;
				ILayoutDocumentPane element4;
				if (containerPaneGroup == null)
				{
					element4 = layoutDocumentPane;
				}
				else
				{
					ILayoutDocumentPane layoutDocumentPane2 = containerPaneGroup;
					element4 = layoutDocumentPane2;
				}
				children7.Insert(layoutPanel10.IndexOfChild(element4), floatingWindow.RootPanel);
				break;
			}
			if (containerPanel != null)
			{
				LayoutPanel layoutPanel11 = new LayoutPanel
				{
					Orientation = Orientation.Vertical
				};
				LayoutPanel layoutPanel12 = containerPanel;
				ILayoutDocumentPane oldElement4;
				if (containerPaneGroup == null)
				{
					oldElement4 = layoutDocumentPane;
				}
				else
				{
					ILayoutDocumentPane layoutDocumentPane2 = containerPaneGroup;
					oldElement4 = layoutDocumentPane2;
				}
				layoutPanel12.ReplaceChild(oldElement4, layoutPanel11);
				ObservableCollection<ILayoutPanelElement> children8 = layoutPanel11.Children;
				ILayoutDocumentPane item4;
				if (containerPaneGroup == null)
				{
					item4 = layoutDocumentPane;
				}
				else
				{
					ILayoutDocumentPane layoutDocumentPane2 = containerPaneGroup;
					item4 = layoutDocumentPane2;
				}
				children8.Add(item4);
				layoutPanel11.Children.Insert(0, floatingWindow.RootPanel);
				break;
			}
			throw new NotImplementedException();
		case DropTargetType.DocumentPaneDockAsAnchorableLeft:
			if (containerPanel != null && containerPanel.ChildrenCount == 1)
			{
				containerPanel.Orientation = Orientation.Horizontal;
			}
			if (containerPanel != null && containerPanel.Orientation == Orientation.Horizontal)
			{
				ObservableCollection<ILayoutPanelElement> children5 = containerPanel.Children;
				LayoutPanel layoutPanel7 = containerPanel;
				ILayoutDocumentPane element3;
				if (containerPaneGroup == null)
				{
					element3 = layoutDocumentPane;
				}
				else
				{
					ILayoutDocumentPane layoutDocumentPane2 = containerPaneGroup;
					element3 = layoutDocumentPane2;
				}
				children5.Insert(layoutPanel7.IndexOfChild(element3), floatingWindow.RootPanel);
				break;
			}
			if (containerPanel != null)
			{
				LayoutPanel layoutPanel8 = new LayoutPanel
				{
					Orientation = Orientation.Horizontal
				};
				LayoutPanel layoutPanel9 = containerPanel;
				ILayoutDocumentPane oldElement3;
				if (containerPaneGroup == null)
				{
					oldElement3 = layoutDocumentPane;
				}
				else
				{
					ILayoutDocumentPane layoutDocumentPane2 = containerPaneGroup;
					oldElement3 = layoutDocumentPane2;
				}
				layoutPanel9.ReplaceChild(oldElement3, layoutPanel8);
				ObservableCollection<ILayoutPanelElement> children6 = layoutPanel8.Children;
				ILayoutDocumentPane item3;
				if (containerPaneGroup == null)
				{
					item3 = layoutDocumentPane;
				}
				else
				{
					ILayoutDocumentPane layoutDocumentPane2 = containerPaneGroup;
					item3 = layoutDocumentPane2;
				}
				children6.Add(item3);
				layoutPanel8.Children.Insert(0, floatingWindow.RootPanel);
				break;
			}
			throw new NotImplementedException();
		case DropTargetType.DocumentPaneDockAsAnchorableRight:
			if (containerPanel != null && containerPanel.ChildrenCount == 1)
			{
				containerPanel.Orientation = Orientation.Horizontal;
			}
			if (containerPanel != null && containerPanel.Orientation == Orientation.Horizontal)
			{
				ObservableCollection<ILayoutPanelElement> children = containerPanel.Children;
				LayoutPanel layoutPanel = containerPanel;
				ILayoutDocumentPane element;
				if (containerPaneGroup == null)
				{
					element = layoutDocumentPane;
				}
				else
				{
					ILayoutDocumentPane layoutDocumentPane2 = containerPaneGroup;
					element = layoutDocumentPane2;
				}
				children.Insert(layoutPanel.IndexOfChild(element) + 1, floatingWindow.RootPanel);
				break;
			}
			if (containerPanel != null)
			{
				LayoutPanel layoutPanel2 = new LayoutPanel
				{
					Orientation = Orientation.Horizontal
				};
				LayoutPanel layoutPanel3 = containerPanel;
				ILayoutDocumentPane oldElement;
				if (containerPaneGroup == null)
				{
					oldElement = layoutDocumentPane;
				}
				else
				{
					ILayoutDocumentPane layoutDocumentPane2 = containerPaneGroup;
					oldElement = layoutDocumentPane2;
				}
				layoutPanel3.ReplaceChild(oldElement, layoutPanel2);
				ObservableCollection<ILayoutPanelElement> children2 = layoutPanel2.Children;
				ILayoutDocumentPane item;
				if (containerPaneGroup == null)
				{
					item = layoutDocumentPane;
				}
				else
				{
					ILayoutDocumentPane layoutDocumentPane2 = containerPaneGroup;
					item = layoutDocumentPane2;
				}
				children2.Add(item);
				layoutPanel2.Children.Add(floatingWindow.RootPanel);
				break;
			}
			throw new NotImplementedException();
		}
		base.Drop(floatingWindow);
	}

	public override Geometry GetPreviewPath(OverlayWindow overlayWindow, LayoutFloatingWindow floatingWindowModel)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		ILayoutDocumentPane layoutDocumentPane = _targetPane.Model as ILayoutDocumentPane;
		DockingManager manager = layoutDocumentPane.Root.Manager;
		if (!FindParentLayoutDocumentPane(layoutDocumentPane, out var parentGroup, out var parentGroupPanel))
		{
			return null;
		}
		Rect screenArea = (((DependencyObject)(object)manager).FindLogicalChildren<FrameworkElement>().OfType<ILayoutControl>().First((ILayoutControl d) => (parentGroup == null) ? (d.Model == parentGroupPanel) : (d.Model == parentGroup)) as FrameworkElement).GetScreenArea();
		switch (base.Type)
		{
		case DropTargetType.DocumentPaneDockAsAnchorableBottom:
			((Rect)(ref screenArea)).Offset(0.0 - overlayWindow.Left, 0.0 - overlayWindow.Top);
			((Rect)(ref screenArea)).Offset(0.0, ((Rect)(ref screenArea)).Height - ((Rect)(ref screenArea)).Height / 3.0);
			((Rect)(ref screenArea)).Height = ((Rect)(ref screenArea)).Height / 3.0;
			return new RectangleGeometry(screenArea);
		case DropTargetType.DocumentPaneDockAsAnchorableTop:
			((Rect)(ref screenArea)).Offset(0.0 - overlayWindow.Left, 0.0 - overlayWindow.Top);
			((Rect)(ref screenArea)).Height = ((Rect)(ref screenArea)).Height / 3.0;
			return new RectangleGeometry(screenArea);
		case DropTargetType.DocumentPaneDockAsAnchorableRight:
			((Rect)(ref screenArea)).Offset(0.0 - overlayWindow.Left, 0.0 - overlayWindow.Top);
			((Rect)(ref screenArea)).Offset(((Rect)(ref screenArea)).Width - ((Rect)(ref screenArea)).Width / 3.0, 0.0);
			((Rect)(ref screenArea)).Width = ((Rect)(ref screenArea)).Width / 3.0;
			return new RectangleGeometry(screenArea);
		case DropTargetType.DocumentPaneDockAsAnchorableLeft:
			((Rect)(ref screenArea)).Offset(0.0 - overlayWindow.Left, 0.0 - overlayWindow.Top);
			((Rect)(ref screenArea)).Width = ((Rect)(ref screenArea)).Width / 3.0;
			return new RectangleGeometry(screenArea);
		default:
			return null;
		}
	}

	private bool FindParentLayoutDocumentPane(ILayoutDocumentPane documentPane, out LayoutDocumentPaneGroup containerPaneGroup, out LayoutPanel containerPanel)
	{
		containerPaneGroup = null;
		containerPanel = null;
		if (documentPane.Parent is LayoutPanel)
		{
			containerPaneGroup = null;
			containerPanel = documentPane.Parent as LayoutPanel;
			return true;
		}
		if (documentPane.Parent is LayoutDocumentPaneGroup)
		{
			LayoutDocumentPaneGroup layoutDocumentPaneGroup = documentPane.Parent as LayoutDocumentPaneGroup;
			while (!(layoutDocumentPaneGroup.Parent is LayoutPanel))
			{
				layoutDocumentPaneGroup = layoutDocumentPaneGroup.Parent as LayoutDocumentPaneGroup;
				if (layoutDocumentPaneGroup == null)
				{
					break;
				}
			}
			if (layoutDocumentPaneGroup == null)
			{
				return false;
			}
			containerPaneGroup = layoutDocumentPaneGroup;
			containerPanel = layoutDocumentPaneGroup.Parent as LayoutPanel;
			return true;
		}
		return false;
	}
}
