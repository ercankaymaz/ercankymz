using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls;

internal class DocumentPaneDropTarget : DropTarget<LayoutDocumentPaneControl>
{
	private LayoutDocumentPaneControl _targetPane;

	private int _tabIndex = -1;

	internal DocumentPaneDropTarget(LayoutDocumentPaneControl paneControl, Rect detectionRect, DropTargetType type)
		: base(paneControl, detectionRect, type)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		_targetPane = paneControl;
	}

	internal DocumentPaneDropTarget(LayoutDocumentPaneControl paneControl, Rect detectionRect, DropTargetType type, int tabIndex)
		: base(paneControl, detectionRect, type)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		_targetPane = paneControl;
		_tabIndex = tabIndex;
	}

	protected override void Drop(LayoutDocumentFloatingWindow floatingWindow)
	{
		ILayoutDocumentPane layoutDocumentPane = _targetPane.Model as ILayoutDocumentPane;
		if (layoutDocumentPane.FindParent<LayoutFloatingWindow>() == null && floatingWindow != null && floatingWindow.Root != null && floatingWindow.Root.ActiveContent != null)
		{
			floatingWindow.Root.ActiveContent.IsFloating = false;
		}
		switch (base.Type)
		{
		case DropTargetType.DocumentPaneDockBottom:
		{
			LayoutDocumentPane layoutDocumentPane6 = new LayoutDocumentPane(floatingWindow.RootDocument);
			if (layoutDocumentPane is ILayoutPositionableElement { DockHeight: { IsStar: not false } } layoutPositionableElement4)
			{
				layoutPositionableElement4.DockHeight = new GridLength(layoutPositionableElement4.DockHeight.Value / 2.0, GridUnitType.Star);
				layoutDocumentPane6.DockHeight = layoutPositionableElement4.DockHeight;
			}
			if (!(layoutDocumentPane.Parent is LayoutDocumentPaneGroup layoutDocumentPaneGroup10))
			{
				ILayoutContainer parent4 = layoutDocumentPane.Parent;
				LayoutDocumentPaneGroup layoutDocumentPaneGroup11 = new LayoutDocumentPaneGroup
				{
					Orientation = Orientation.Vertical
				};
				parent4.ReplaceChild(layoutDocumentPane, layoutDocumentPaneGroup11);
				layoutDocumentPaneGroup11.Children.Add(layoutDocumentPane as LayoutDocumentPane);
				layoutDocumentPaneGroup11.Children.Add(layoutDocumentPane6);
			}
			else if (!layoutDocumentPaneGroup10.Root.Manager.AllowMixedOrientation || layoutDocumentPaneGroup10.Orientation == Orientation.Vertical)
			{
				layoutDocumentPaneGroup10.Orientation = Orientation.Vertical;
				int num4 = layoutDocumentPaneGroup10.IndexOfChild(layoutDocumentPane);
				layoutDocumentPaneGroup10.Children.Insert(num4 + 1, layoutDocumentPane6);
			}
			else
			{
				LayoutDocumentPaneGroup layoutDocumentPaneGroup12 = new LayoutDocumentPaneGroup();
				layoutDocumentPaneGroup12.Orientation = Orientation.Vertical;
				layoutDocumentPaneGroup10.ReplaceChild(layoutDocumentPane, layoutDocumentPaneGroup12);
				layoutDocumentPaneGroup12.Children.Add(layoutDocumentPane);
				layoutDocumentPaneGroup12.Children.Add(layoutDocumentPane6);
			}
			break;
		}
		case DropTargetType.DocumentPaneDockTop:
		{
			LayoutDocumentPane layoutDocumentPane5 = new LayoutDocumentPane(floatingWindow.RootDocument);
			if (layoutDocumentPane is ILayoutPositionableElement { DockHeight: { IsStar: not false } } layoutPositionableElement3)
			{
				layoutPositionableElement3.DockHeight = new GridLength(layoutPositionableElement3.DockHeight.Value / 2.0, GridUnitType.Star);
				layoutDocumentPane5.DockHeight = layoutPositionableElement3.DockHeight;
			}
			if (!(layoutDocumentPane.Parent is LayoutDocumentPaneGroup layoutDocumentPaneGroup7))
			{
				ILayoutContainer parent3 = layoutDocumentPane.Parent;
				LayoutDocumentPaneGroup layoutDocumentPaneGroup8 = new LayoutDocumentPaneGroup
				{
					Orientation = Orientation.Vertical
				};
				parent3.ReplaceChild(layoutDocumentPane, layoutDocumentPaneGroup8);
				layoutDocumentPaneGroup8.Children.Add(layoutDocumentPane as LayoutDocumentPane);
				layoutDocumentPaneGroup8.Children.Insert(0, layoutDocumentPane5);
			}
			else if (!layoutDocumentPaneGroup7.Root.Manager.AllowMixedOrientation || layoutDocumentPaneGroup7.Orientation == Orientation.Vertical)
			{
				layoutDocumentPaneGroup7.Orientation = Orientation.Vertical;
				int index2 = layoutDocumentPaneGroup7.IndexOfChild(layoutDocumentPane);
				layoutDocumentPaneGroup7.Children.Insert(index2, layoutDocumentPane5);
			}
			else
			{
				LayoutDocumentPaneGroup layoutDocumentPaneGroup9 = new LayoutDocumentPaneGroup();
				layoutDocumentPaneGroup9.Orientation = Orientation.Vertical;
				layoutDocumentPaneGroup7.ReplaceChild(layoutDocumentPane, layoutDocumentPaneGroup9);
				layoutDocumentPaneGroup9.Children.Add(layoutDocumentPane5);
				layoutDocumentPaneGroup9.Children.Add(layoutDocumentPane);
			}
			break;
		}
		case DropTargetType.DocumentPaneDockLeft:
		{
			LayoutDocumentPane layoutDocumentPane3 = new LayoutDocumentPane(floatingWindow.RootDocument);
			if (layoutDocumentPane is ILayoutPositionableElement { DockWidth: { IsStar: not false } } layoutPositionableElement)
			{
				layoutPositionableElement.DockWidth = new GridLength(layoutPositionableElement.DockWidth.Value / 2.0, GridUnitType.Star);
				layoutDocumentPane3.DockWidth = layoutPositionableElement.DockWidth;
			}
			if (!(layoutDocumentPane.Parent is LayoutDocumentPaneGroup layoutDocumentPaneGroup))
			{
				ILayoutContainer parent = layoutDocumentPane.Parent;
				LayoutDocumentPaneGroup layoutDocumentPaneGroup2 = new LayoutDocumentPaneGroup
				{
					Orientation = Orientation.Horizontal
				};
				parent.ReplaceChild(layoutDocumentPane, layoutDocumentPaneGroup2);
				layoutDocumentPaneGroup2.Children.Add(layoutDocumentPane);
				layoutDocumentPaneGroup2.Children.Insert(0, layoutDocumentPane3);
			}
			else if (!layoutDocumentPaneGroup.Root.Manager.AllowMixedOrientation || layoutDocumentPaneGroup.Orientation == Orientation.Horizontal)
			{
				layoutDocumentPaneGroup.Orientation = Orientation.Horizontal;
				int index = layoutDocumentPaneGroup.IndexOfChild(layoutDocumentPane);
				layoutDocumentPaneGroup.Children.Insert(index, layoutDocumentPane3);
			}
			else
			{
				LayoutDocumentPaneGroup layoutDocumentPaneGroup3 = new LayoutDocumentPaneGroup();
				layoutDocumentPaneGroup3.Orientation = Orientation.Horizontal;
				layoutDocumentPaneGroup.ReplaceChild(layoutDocumentPane, layoutDocumentPaneGroup3);
				layoutDocumentPaneGroup3.Children.Add(layoutDocumentPane3);
				layoutDocumentPaneGroup3.Children.Add(layoutDocumentPane);
			}
			break;
		}
		case DropTargetType.DocumentPaneDockRight:
		{
			LayoutDocumentPane layoutDocumentPane4 = new LayoutDocumentPane(floatingWindow.RootDocument);
			if (layoutDocumentPane is ILayoutPositionableElement { DockWidth: { IsStar: not false } } layoutPositionableElement2)
			{
				layoutPositionableElement2.DockWidth = new GridLength(layoutPositionableElement2.DockWidth.Value / 2.0, GridUnitType.Star);
				layoutDocumentPane4.DockWidth = layoutPositionableElement2.DockWidth;
			}
			if (!(layoutDocumentPane.Parent is LayoutDocumentPaneGroup layoutDocumentPaneGroup4))
			{
				ILayoutContainer parent2 = layoutDocumentPane.Parent;
				LayoutDocumentPaneGroup layoutDocumentPaneGroup5 = new LayoutDocumentPaneGroup
				{
					Orientation = Orientation.Horizontal
				};
				parent2.ReplaceChild(layoutDocumentPane, layoutDocumentPaneGroup5);
				layoutDocumentPaneGroup5.Children.Add(layoutDocumentPane as LayoutDocumentPane);
				layoutDocumentPaneGroup5.Children.Add(layoutDocumentPane4);
			}
			else if (!layoutDocumentPaneGroup4.Root.Manager.AllowMixedOrientation || layoutDocumentPaneGroup4.Orientation == Orientation.Horizontal)
			{
				layoutDocumentPaneGroup4.Orientation = Orientation.Horizontal;
				int num3 = layoutDocumentPaneGroup4.IndexOfChild(layoutDocumentPane);
				layoutDocumentPaneGroup4.Children.Insert(num3 + 1, layoutDocumentPane4);
			}
			else
			{
				LayoutDocumentPaneGroup layoutDocumentPaneGroup6 = new LayoutDocumentPaneGroup();
				layoutDocumentPaneGroup6.Orientation = Orientation.Horizontal;
				layoutDocumentPaneGroup4.ReplaceChild(layoutDocumentPane, layoutDocumentPaneGroup6);
				layoutDocumentPaneGroup6.Children.Add(layoutDocumentPane);
				layoutDocumentPaneGroup6.Children.Add(layoutDocumentPane4);
			}
			break;
		}
		case DropTargetType.DocumentPaneDockInside:
		{
			LayoutDocumentPane layoutDocumentPane2 = layoutDocumentPane as LayoutDocumentPane;
			LayoutDocument rootDocument = floatingWindow.RootDocument;
			int num = 0;
			if (_tabIndex != -1)
			{
				num = _tabIndex;
			}
			else
			{
				int num2 = 0;
				if (((ILayoutPreviousContainer)rootDocument).PreviousContainer == layoutDocumentPane && rootDocument.PreviousContainerIndex != -1)
				{
					num2 = rootDocument.PreviousContainerIndex;
				}
				num = num2;
			}
			rootDocument.IsActive = false;
			layoutDocumentPane2.Children.Insert(Math.Min(num, layoutDocumentPane2.Children.Count), rootDocument);
			rootDocument.IsActive = true;
			break;
		}
		}
		base.Drop(floatingWindow);
	}

	protected override void Drop(LayoutAnchorableFloatingWindow floatingWindow)
	{
		ILayoutDocumentPane layoutDocumentPane = _targetPane.Model as ILayoutDocumentPane;
		if (layoutDocumentPane.FindParent<LayoutFloatingWindow>() == null && floatingWindow != null && floatingWindow.Root != null && floatingWindow.Root.ActiveContent != null)
		{
			floatingWindow.Root.ActiveContent.IsFloating = false;
		}
		switch (base.Type)
		{
		case DropTargetType.DocumentPaneDockBottom:
		{
			LayoutDocumentPaneGroup layoutDocumentPaneGroup10 = layoutDocumentPane.Parent as LayoutDocumentPaneGroup;
			LayoutDocumentPane layoutDocumentPane6 = new LayoutDocumentPane();
			if (layoutDocumentPane is ILayoutPositionableElement { DockHeight: { IsStar: not false } } layoutPositionableElement4)
			{
				layoutPositionableElement4.DockHeight = new GridLength(layoutPositionableElement4.DockHeight.Value / 2.0, GridUnitType.Star);
				layoutDocumentPane6.DockHeight = layoutPositionableElement4.DockHeight;
			}
			if (layoutDocumentPaneGroup10 == null)
			{
				ILayoutContainer parent4 = layoutDocumentPane.Parent;
				LayoutDocumentPaneGroup layoutDocumentPaneGroup11 = new LayoutDocumentPaneGroup
				{
					Orientation = Orientation.Vertical
				};
				parent4.ReplaceChild(layoutDocumentPane, layoutDocumentPaneGroup11);
				layoutDocumentPaneGroup11.Children.Add(layoutDocumentPane as LayoutDocumentPane);
				layoutDocumentPaneGroup11.Children.Add(layoutDocumentPane6);
			}
			else if (!layoutDocumentPaneGroup10.Root.Manager.AllowMixedOrientation || layoutDocumentPaneGroup10.Orientation == Orientation.Vertical)
			{
				layoutDocumentPaneGroup10.Orientation = Orientation.Vertical;
				int num3 = layoutDocumentPaneGroup10.IndexOfChild(layoutDocumentPane);
				layoutDocumentPaneGroup10.Children.Insert(num3 + 1, layoutDocumentPane6);
			}
			else
			{
				LayoutDocumentPaneGroup layoutDocumentPaneGroup12 = new LayoutDocumentPaneGroup();
				layoutDocumentPaneGroup12.Orientation = Orientation.Vertical;
				layoutDocumentPaneGroup10.ReplaceChild(layoutDocumentPane, layoutDocumentPaneGroup12);
				layoutDocumentPaneGroup12.Children.Add(layoutDocumentPane);
				layoutDocumentPaneGroup12.Children.Add(layoutDocumentPane6);
			}
			LayoutAnchorable[] array = floatingWindow.RootPanel.Descendents().OfType<LayoutAnchorable>().ToArray();
			foreach (LayoutAnchorable item4 in array)
			{
				layoutDocumentPane6.Children.Add(item4);
			}
			break;
		}
		case DropTargetType.DocumentPaneDockTop:
		{
			LayoutDocumentPaneGroup layoutDocumentPaneGroup = layoutDocumentPane.Parent as LayoutDocumentPaneGroup;
			LayoutDocumentPane layoutDocumentPane3 = new LayoutDocumentPane();
			if (layoutDocumentPane is ILayoutPositionableElement { DockHeight: { IsStar: not false } } layoutPositionableElement)
			{
				layoutPositionableElement.DockHeight = new GridLength(layoutPositionableElement.DockHeight.Value / 2.0, GridUnitType.Star);
				layoutDocumentPane3.DockHeight = layoutPositionableElement.DockHeight;
			}
			if (layoutDocumentPaneGroup == null)
			{
				ILayoutContainer parent = layoutDocumentPane.Parent;
				LayoutDocumentPaneGroup layoutDocumentPaneGroup2 = new LayoutDocumentPaneGroup
				{
					Orientation = Orientation.Vertical
				};
				parent.ReplaceChild(layoutDocumentPane, layoutDocumentPaneGroup2);
				layoutDocumentPaneGroup2.Children.Add(layoutDocumentPane3);
				layoutDocumentPaneGroup2.Children.Add(layoutDocumentPane as LayoutDocumentPane);
			}
			else if (!layoutDocumentPaneGroup.Root.Manager.AllowMixedOrientation || layoutDocumentPaneGroup.Orientation == Orientation.Vertical)
			{
				layoutDocumentPaneGroup.Orientation = Orientation.Vertical;
				int index = layoutDocumentPaneGroup.IndexOfChild(layoutDocumentPane);
				layoutDocumentPaneGroup.Children.Insert(index, layoutDocumentPane3);
			}
			else
			{
				LayoutDocumentPaneGroup layoutDocumentPaneGroup3 = new LayoutDocumentPaneGroup();
				layoutDocumentPaneGroup3.Orientation = Orientation.Vertical;
				layoutDocumentPaneGroup.ReplaceChild(layoutDocumentPane, layoutDocumentPaneGroup3);
				layoutDocumentPaneGroup3.Children.Add(layoutDocumentPane3);
				layoutDocumentPaneGroup3.Children.Add(layoutDocumentPane);
			}
			LayoutAnchorable[] array = floatingWindow.RootPanel.Descendents().OfType<LayoutAnchorable>().ToArray();
			foreach (LayoutAnchorable item in array)
			{
				layoutDocumentPane3.Children.Add(item);
			}
			break;
		}
		case DropTargetType.DocumentPaneDockLeft:
		{
			LayoutDocumentPaneGroup layoutDocumentPaneGroup7 = layoutDocumentPane.Parent as LayoutDocumentPaneGroup;
			LayoutDocumentPane layoutDocumentPane5 = new LayoutDocumentPane();
			if (layoutDocumentPane is ILayoutPositionableElement { DockWidth: { IsStar: not false } } layoutPositionableElement3)
			{
				layoutPositionableElement3.DockWidth = new GridLength(layoutPositionableElement3.DockWidth.Value / 2.0, GridUnitType.Star);
				layoutDocumentPane5.DockWidth = layoutPositionableElement3.DockWidth;
			}
			if (layoutDocumentPaneGroup7 == null)
			{
				ILayoutContainer parent3 = layoutDocumentPane.Parent;
				LayoutDocumentPaneGroup layoutDocumentPaneGroup8 = new LayoutDocumentPaneGroup
				{
					Orientation = Orientation.Horizontal
				};
				parent3.ReplaceChild(layoutDocumentPane, layoutDocumentPaneGroup8);
				layoutDocumentPaneGroup8.Children.Add(layoutDocumentPane5);
				layoutDocumentPaneGroup8.Children.Add(layoutDocumentPane as LayoutDocumentPane);
			}
			else if (!layoutDocumentPaneGroup7.Root.Manager.AllowMixedOrientation || layoutDocumentPaneGroup7.Orientation == Orientation.Horizontal)
			{
				layoutDocumentPaneGroup7.Orientation = Orientation.Horizontal;
				int index2 = layoutDocumentPaneGroup7.IndexOfChild(layoutDocumentPane);
				layoutDocumentPaneGroup7.Children.Insert(index2, layoutDocumentPane5);
			}
			else
			{
				LayoutDocumentPaneGroup layoutDocumentPaneGroup9 = new LayoutDocumentPaneGroup();
				layoutDocumentPaneGroup9.Orientation = Orientation.Horizontal;
				layoutDocumentPaneGroup7.ReplaceChild(layoutDocumentPane, layoutDocumentPaneGroup9);
				layoutDocumentPaneGroup9.Children.Add(layoutDocumentPane5);
				layoutDocumentPaneGroup9.Children.Add(layoutDocumentPane);
			}
			LayoutAnchorable[] array = floatingWindow.RootPanel.Descendents().OfType<LayoutAnchorable>().ToArray();
			foreach (LayoutAnchorable item3 in array)
			{
				layoutDocumentPane5.Children.Add(item3);
			}
			break;
		}
		case DropTargetType.DocumentPaneDockRight:
		{
			LayoutDocumentPaneGroup layoutDocumentPaneGroup4 = layoutDocumentPane.Parent as LayoutDocumentPaneGroup;
			LayoutDocumentPane layoutDocumentPane4 = new LayoutDocumentPane();
			if (layoutDocumentPane is ILayoutPositionableElement { DockWidth: { IsStar: not false } } layoutPositionableElement2)
			{
				layoutPositionableElement2.DockWidth = new GridLength(layoutPositionableElement2.DockWidth.Value / 2.0, GridUnitType.Star);
				layoutDocumentPane4.DockWidth = layoutPositionableElement2.DockWidth;
			}
			if (layoutDocumentPaneGroup4 == null)
			{
				ILayoutContainer parent2 = layoutDocumentPane.Parent;
				LayoutDocumentPaneGroup layoutDocumentPaneGroup5 = new LayoutDocumentPaneGroup
				{
					Orientation = Orientation.Horizontal
				};
				parent2.ReplaceChild(layoutDocumentPane, layoutDocumentPaneGroup5);
				layoutDocumentPaneGroup5.Children.Add(layoutDocumentPane as LayoutDocumentPane);
				layoutDocumentPaneGroup5.Children.Add(layoutDocumentPane4);
			}
			else if (!layoutDocumentPaneGroup4.Root.Manager.AllowMixedOrientation || layoutDocumentPaneGroup4.Orientation == Orientation.Horizontal)
			{
				layoutDocumentPaneGroup4.Orientation = Orientation.Horizontal;
				int num2 = layoutDocumentPaneGroup4.IndexOfChild(layoutDocumentPane);
				layoutDocumentPaneGroup4.Children.Insert(num2 + 1, layoutDocumentPane4);
			}
			else
			{
				LayoutDocumentPaneGroup layoutDocumentPaneGroup6 = new LayoutDocumentPaneGroup();
				layoutDocumentPaneGroup6.Orientation = Orientation.Horizontal;
				layoutDocumentPaneGroup4.ReplaceChild(layoutDocumentPane, layoutDocumentPaneGroup6);
				layoutDocumentPaneGroup6.Children.Add(layoutDocumentPane);
				layoutDocumentPaneGroup6.Children.Add(layoutDocumentPane4);
			}
			LayoutAnchorable[] array = floatingWindow.RootPanel.Descendents().OfType<LayoutAnchorable>().ToArray();
			foreach (LayoutAnchorable item2 in array)
			{
				layoutDocumentPane4.Children.Add(item2);
			}
			break;
		}
		case DropTargetType.DocumentPaneDockInside:
		{
			LayoutDocumentPane layoutDocumentPane2 = layoutDocumentPane as LayoutDocumentPane;
			LayoutAnchorablePaneGroup rootPanel = floatingWindow.RootPanel;
			bool flag = true;
			int num = 0;
			if (_tabIndex != -1)
			{
				num = _tabIndex;
				flag = false;
			}
			LayoutAnchorable layoutAnchorable = null;
			LayoutAnchorable[] array = rootPanel.Descendents().OfType<LayoutAnchorable>().ToArray();
			foreach (LayoutAnchorable layoutAnchorable2 in array)
			{
				if (flag)
				{
					if (((ILayoutPreviousContainer)layoutAnchorable2).PreviousContainer == layoutDocumentPane && layoutAnchorable2.PreviousContainerIndex != -1)
					{
						num = layoutAnchorable2.PreviousContainerIndex;
					}
					flag = false;
				}
				if (layoutAnchorable2.CanClose)
				{
					layoutAnchorable2.SetCanCloseInternal(canClose: true);
				}
				layoutDocumentPane2.Children.Insert(Math.Min(num, layoutDocumentPane2.Children.Count), layoutAnchorable2);
				num++;
				layoutAnchorable = layoutAnchorable2;
			}
			layoutAnchorable.IsActive = true;
			break;
		}
		}
		base.Drop(floatingWindow);
	}

	public override Geometry GetPreviewPath(OverlayWindow overlayWindow, LayoutFloatingWindow floatingWindowModel)
	{
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		switch (base.Type)
		{
		case DropTargetType.DocumentPaneDockInside:
		{
			Rect screenArea5 = base.TargetElement.GetScreenArea();
			((Rect)(ref screenArea5)).Offset(0.0 - overlayWindow.Left, 0.0 - overlayWindow.Top);
			if (_tabIndex == -1)
			{
				return new RectangleGeometry(screenArea5);
			}
			Rect val = default(Rect);
			((Rect)(ref val))._002Ector(((Rect)(ref base.DetectionRects[0])).TopLeft, ((Rect)(ref base.DetectionRects[0])).BottomRight);
			((Rect)(ref val)).Offset(0.0 - overlayWindow.Left, 0.0 - overlayWindow.Top);
			PathFigure pathFigure = new PathFigure();
			pathFigure.StartPoint = ((Rect)(ref screenArea5)).BottomRight;
			pathFigure.Segments.Add(new LineSegment
			{
				Point = new Point(((Rect)(ref screenArea5)).Right, ((Rect)(ref val)).Bottom)
			});
			pathFigure.Segments.Add(new LineSegment
			{
				Point = ((Rect)(ref val)).BottomRight
			});
			pathFigure.Segments.Add(new LineSegment
			{
				Point = ((Rect)(ref val)).TopRight
			});
			pathFigure.Segments.Add(new LineSegment
			{
				Point = ((Rect)(ref val)).TopLeft
			});
			pathFigure.Segments.Add(new LineSegment
			{
				Point = ((Rect)(ref val)).BottomLeft
			});
			pathFigure.Segments.Add(new LineSegment
			{
				Point = new Point(((Rect)(ref screenArea5)).Left, ((Rect)(ref val)).Bottom)
			});
			pathFigure.Segments.Add(new LineSegment
			{
				Point = ((Rect)(ref screenArea5)).BottomLeft
			});
			pathFigure.IsClosed = true;
			pathFigure.IsFilled = true;
			((Freezable)pathFigure).Freeze();
			return new PathGeometry(new PathFigure[1] { pathFigure });
		}
		case DropTargetType.DocumentPaneDockBottom:
		{
			Rect screenArea4 = base.TargetElement.GetScreenArea();
			((Rect)(ref screenArea4)).Offset(0.0 - overlayWindow.Left, 0.0 - overlayWindow.Top);
			((Rect)(ref screenArea4)).Offset(0.0, ((Rect)(ref screenArea4)).Height / 2.0);
			((Rect)(ref screenArea4)).Height = ((Rect)(ref screenArea4)).Height / 2.0;
			return new RectangleGeometry(screenArea4);
		}
		case DropTargetType.DocumentPaneDockTop:
		{
			Rect screenArea3 = base.TargetElement.GetScreenArea();
			((Rect)(ref screenArea3)).Offset(0.0 - overlayWindow.Left, 0.0 - overlayWindow.Top);
			((Rect)(ref screenArea3)).Height = ((Rect)(ref screenArea3)).Height / 2.0;
			return new RectangleGeometry(screenArea3);
		}
		case DropTargetType.DocumentPaneDockLeft:
		{
			Rect screenArea2 = base.TargetElement.GetScreenArea();
			((Rect)(ref screenArea2)).Offset(0.0 - overlayWindow.Left, 0.0 - overlayWindow.Top);
			((Rect)(ref screenArea2)).Width = ((Rect)(ref screenArea2)).Width / 2.0;
			return new RectangleGeometry(screenArea2);
		}
		case DropTargetType.DocumentPaneDockRight:
		{
			Rect screenArea = base.TargetElement.GetScreenArea();
			((Rect)(ref screenArea)).Offset(0.0 - overlayWindow.Left, 0.0 - overlayWindow.Top);
			((Rect)(ref screenArea)).Offset(((Rect)(ref screenArea)).Width / 2.0, 0.0);
			((Rect)(ref screenArea)).Width = ((Rect)(ref screenArea)).Width / 2.0;
			return new RectangleGeometry(screenArea);
		}
		default:
			return null;
		}
	}
}
