using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls;

internal class AnchorablePaneDropTarget : DropTarget<LayoutAnchorablePaneControl>
{
	private LayoutAnchorablePaneControl _targetPane;

	private int _tabIndex = -1;

	internal AnchorablePaneDropTarget(LayoutAnchorablePaneControl paneControl, Rect detectionRect, DropTargetType type)
		: base(paneControl, detectionRect, type)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		_targetPane = paneControl;
	}

	internal AnchorablePaneDropTarget(LayoutAnchorablePaneControl paneControl, Rect detectionRect, DropTargetType type, int tabIndex)
		: base(paneControl, detectionRect, type)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		_targetPane = paneControl;
		_tabIndex = tabIndex;
	}

	protected override void Drop(LayoutAnchorableFloatingWindow floatingWindow)
	{
		ILayoutAnchorablePane layoutAnchorablePane = _targetPane.Model as ILayoutAnchorablePane;
		LayoutAnchorable layoutAnchorable = floatingWindow.Descendents().OfType<LayoutAnchorable>().FirstOrDefault();
		if (layoutAnchorablePane.FindParent<LayoutFloatingWindow>() == null && layoutAnchorable != null)
		{
			layoutAnchorable.IsFloating = false;
		}
		switch (base.Type)
		{
		case DropTargetType.AnchorablePaneDockBottom:
		{
			ILayoutGroup layoutGroup = layoutAnchorablePane.Parent as ILayoutGroup;
			ILayoutOrientableGroup layoutOrientableGroup = layoutAnchorablePane.Parent as ILayoutOrientableGroup;
			int num2 = layoutGroup.IndexOfChild(layoutAnchorablePane);
			if (layoutOrientableGroup.Orientation != Orientation.Vertical && layoutGroup.ChildrenCount == 1)
			{
				layoutOrientableGroup.Orientation = Orientation.Vertical;
			}
			if (layoutOrientableGroup.Orientation == Orientation.Vertical)
			{
				LayoutAnchorablePaneGroup rootPanel2 = floatingWindow.RootPanel;
				if (rootPanel2 != null && (rootPanel2.Children.Count == 1 || rootPanel2.Orientation == Orientation.Vertical))
				{
					ILayoutAnchorablePane[] array2 = rootPanel2.Children.ToArray();
					for (int j = 0; j < array2.Length; j++)
					{
						layoutGroup.InsertChildAt(num2 + 1 + j, array2[j]);
					}
				}
				else
				{
					layoutGroup.InsertChildAt(num2 + 1, floatingWindow.RootPanel);
				}
			}
			else
			{
				ILayoutPositionableElement layoutPositionableElement = layoutAnchorablePane as ILayoutPositionableElement;
				LayoutAnchorablePaneGroup layoutAnchorablePaneGroup = new LayoutAnchorablePaneGroup
				{
					Orientation = Orientation.Vertical,
					DockWidth = layoutPositionableElement.DockWidth,
					DockHeight = layoutPositionableElement.DockHeight
				};
				layoutGroup.InsertChildAt(num2, layoutAnchorablePaneGroup);
				layoutAnchorablePaneGroup.Children.Add(layoutAnchorablePane);
				layoutAnchorablePaneGroup.Children.Add(floatingWindow.RootPanel);
			}
			break;
		}
		case DropTargetType.AnchorablePaneDockTop:
		{
			ILayoutGroup layoutGroup2 = layoutAnchorablePane.Parent as ILayoutGroup;
			ILayoutOrientableGroup layoutOrientableGroup2 = layoutAnchorablePane.Parent as ILayoutOrientableGroup;
			int num3 = layoutGroup2.IndexOfChild(layoutAnchorablePane);
			if (layoutOrientableGroup2.Orientation != Orientation.Vertical && layoutGroup2.ChildrenCount == 1)
			{
				layoutOrientableGroup2.Orientation = Orientation.Vertical;
			}
			if (layoutOrientableGroup2.Orientation == Orientation.Vertical)
			{
				LayoutAnchorablePaneGroup rootPanel3 = floatingWindow.RootPanel;
				if (rootPanel3 != null && (rootPanel3.Children.Count == 1 || rootPanel3.Orientation == Orientation.Vertical))
				{
					ILayoutAnchorablePane[] array3 = rootPanel3.Children.ToArray();
					for (int k = 0; k < array3.Length; k++)
					{
						layoutGroup2.InsertChildAt(num3 + k, array3[k]);
					}
				}
				else
				{
					layoutGroup2.InsertChildAt(num3, floatingWindow.RootPanel);
				}
			}
			else
			{
				ILayoutPositionableElement layoutPositionableElement2 = layoutAnchorablePane as ILayoutPositionableElement;
				LayoutAnchorablePaneGroup layoutAnchorablePaneGroup2 = new LayoutAnchorablePaneGroup
				{
					Orientation = Orientation.Vertical,
					DockWidth = layoutPositionableElement2.DockWidth,
					DockHeight = layoutPositionableElement2.DockHeight
				};
				layoutGroup2.InsertChildAt(num3, layoutAnchorablePaneGroup2);
				layoutAnchorablePaneGroup2.Children.Add(layoutAnchorablePane);
				layoutAnchorablePaneGroup2.Children.Insert(0, floatingWindow.RootPanel);
			}
			break;
		}
		case DropTargetType.AnchorablePaneDockLeft:
		{
			ILayoutGroup layoutGroup4 = layoutAnchorablePane.Parent as ILayoutGroup;
			ILayoutOrientableGroup layoutOrientableGroup4 = layoutAnchorablePane.Parent as ILayoutOrientableGroup;
			int num5 = layoutGroup4.IndexOfChild(layoutAnchorablePane);
			if (layoutOrientableGroup4.Orientation != Orientation.Horizontal && layoutGroup4.ChildrenCount == 1)
			{
				layoutOrientableGroup4.Orientation = Orientation.Horizontal;
			}
			if (layoutOrientableGroup4.Orientation == Orientation.Horizontal)
			{
				LayoutAnchorablePaneGroup rootPanel5 = floatingWindow.RootPanel;
				if (rootPanel5 != null && (rootPanel5.Children.Count == 1 || rootPanel5.Orientation == Orientation.Horizontal))
				{
					ILayoutAnchorablePane[] array5 = rootPanel5.Children.ToArray();
					for (int m = 0; m < array5.Length; m++)
					{
						layoutGroup4.InsertChildAt(num5 + m, array5[m]);
					}
				}
				else
				{
					layoutGroup4.InsertChildAt(num5, floatingWindow.RootPanel);
				}
			}
			else
			{
				ILayoutPositionableElement layoutPositionableElement4 = layoutAnchorablePane as ILayoutPositionableElement;
				LayoutAnchorablePaneGroup layoutAnchorablePaneGroup4 = new LayoutAnchorablePaneGroup
				{
					Orientation = Orientation.Horizontal,
					DockWidth = layoutPositionableElement4.DockWidth,
					DockHeight = layoutPositionableElement4.DockHeight
				};
				layoutGroup4.InsertChildAt(num5, layoutAnchorablePaneGroup4);
				layoutAnchorablePaneGroup4.Children.Add(layoutAnchorablePane);
				layoutAnchorablePaneGroup4.Children.Insert(0, floatingWindow.RootPanel);
			}
			break;
		}
		case DropTargetType.AnchorablePaneDockRight:
		{
			ILayoutGroup layoutGroup3 = layoutAnchorablePane.Parent as ILayoutGroup;
			ILayoutOrientableGroup layoutOrientableGroup3 = layoutAnchorablePane.Parent as ILayoutOrientableGroup;
			int num4 = layoutGroup3.IndexOfChild(layoutAnchorablePane);
			if (layoutOrientableGroup3.Orientation != Orientation.Horizontal && layoutGroup3.ChildrenCount == 1)
			{
				layoutOrientableGroup3.Orientation = Orientation.Horizontal;
			}
			if (layoutOrientableGroup3.Orientation == Orientation.Horizontal)
			{
				LayoutAnchorablePaneGroup rootPanel4 = floatingWindow.RootPanel;
				if (rootPanel4 != null && (rootPanel4.Children.Count == 1 || rootPanel4.Orientation == Orientation.Horizontal))
				{
					ILayoutAnchorablePane[] array4 = rootPanel4.Children.ToArray();
					for (int l = 0; l < array4.Length; l++)
					{
						layoutGroup3.InsertChildAt(num4 + 1 + l, array4[l]);
					}
				}
				else
				{
					layoutGroup3.InsertChildAt(num4 + 1, floatingWindow.RootPanel);
				}
			}
			else
			{
				ILayoutPositionableElement layoutPositionableElement3 = layoutAnchorablePane as ILayoutPositionableElement;
				LayoutAnchorablePaneGroup layoutAnchorablePaneGroup3 = new LayoutAnchorablePaneGroup
				{
					Orientation = Orientation.Horizontal,
					DockWidth = layoutPositionableElement3.DockWidth,
					DockHeight = layoutPositionableElement3.DockHeight
				};
				layoutGroup3.InsertChildAt(num4, layoutAnchorablePaneGroup3);
				layoutAnchorablePaneGroup3.Children.Add(layoutAnchorablePane);
				layoutAnchorablePaneGroup3.Children.Add(floatingWindow.RootPanel);
			}
			break;
		}
		case DropTargetType.AnchorablePaneDockInside:
		{
			LayoutAnchorablePane layoutAnchorablePane2 = layoutAnchorablePane as LayoutAnchorablePane;
			LayoutAnchorablePaneGroup rootPanel = floatingWindow.RootPanel;
			int num = ((_tabIndex != -1) ? _tabIndex : 0);
			LayoutAnchorable[] array = rootPanel.Descendents().OfType<LayoutAnchorable>().ToArray();
			foreach (LayoutAnchorable item in array)
			{
				layoutAnchorablePane2.Children.Insert(num, item);
				num++;
			}
			break;
		}
		}
		layoutAnchorable.IsActive = true;
		base.Drop(floatingWindow);
	}

	public override Geometry GetPreviewPath(OverlayWindow overlayWindow, LayoutFloatingWindow floatingWindowModel)
	{
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		LayoutAnchorableFloatingWindow obj = floatingWindowModel as LayoutAnchorableFloatingWindow;
		_ = obj.RootPanel;
		_ = obj.RootPanel;
		switch (base.Type)
		{
		case DropTargetType.AnchorablePaneDockBottom:
		{
			Rect screenArea3 = base.TargetElement.GetScreenArea();
			((Rect)(ref screenArea3)).Offset(0.0 - overlayWindow.Left, 0.0 - overlayWindow.Top);
			((Rect)(ref screenArea3)).Offset(0.0, ((Rect)(ref screenArea3)).Height / 2.0);
			((Rect)(ref screenArea3)).Height = ((Rect)(ref screenArea3)).Height / 2.0;
			return new RectangleGeometry(screenArea3);
		}
		case DropTargetType.AnchorablePaneDockTop:
		{
			Rect screenArea2 = base.TargetElement.GetScreenArea();
			((Rect)(ref screenArea2)).Offset(0.0 - overlayWindow.Left, 0.0 - overlayWindow.Top);
			((Rect)(ref screenArea2)).Height = ((Rect)(ref screenArea2)).Height / 2.0;
			return new RectangleGeometry(screenArea2);
		}
		case DropTargetType.AnchorablePaneDockLeft:
		{
			Rect screenArea5 = base.TargetElement.GetScreenArea();
			((Rect)(ref screenArea5)).Offset(0.0 - overlayWindow.Left, 0.0 - overlayWindow.Top);
			((Rect)(ref screenArea5)).Width = ((Rect)(ref screenArea5)).Width / 2.0;
			return new RectangleGeometry(screenArea5);
		}
		case DropTargetType.AnchorablePaneDockRight:
		{
			Rect screenArea4 = base.TargetElement.GetScreenArea();
			((Rect)(ref screenArea4)).Offset(0.0 - overlayWindow.Left, 0.0 - overlayWindow.Top);
			((Rect)(ref screenArea4)).Offset(((Rect)(ref screenArea4)).Width / 2.0, 0.0);
			((Rect)(ref screenArea4)).Width = ((Rect)(ref screenArea4)).Width / 2.0;
			return new RectangleGeometry(screenArea4);
		}
		case DropTargetType.AnchorablePaneDockInside:
		{
			Rect screenArea = base.TargetElement.GetScreenArea();
			((Rect)(ref screenArea)).Offset(0.0 - overlayWindow.Left, 0.0 - overlayWindow.Top);
			if (_tabIndex == -1)
			{
				return new RectangleGeometry(screenArea);
			}
			Rect val = default(Rect);
			((Rect)(ref val))._002Ector(((Rect)(ref base.DetectionRects[0])).TopLeft, ((Rect)(ref base.DetectionRects[0])).BottomRight);
			((Rect)(ref val)).Offset(0.0 - overlayWindow.Left, 0.0 - overlayWindow.Top);
			PathFigure pathFigure = new PathFigure();
			pathFigure.StartPoint = ((Rect)(ref screenArea)).TopLeft;
			pathFigure.Segments.Add(new LineSegment
			{
				Point = new Point(((Rect)(ref screenArea)).Left, ((Rect)(ref val)).Top)
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
				Point = ((Rect)(ref val)).BottomRight
			});
			pathFigure.Segments.Add(new LineSegment
			{
				Point = ((Rect)(ref val)).TopRight
			});
			pathFigure.Segments.Add(new LineSegment
			{
				Point = new Point(((Rect)(ref screenArea)).Right, ((Rect)(ref val)).Top)
			});
			pathFigure.Segments.Add(new LineSegment
			{
				Point = ((Rect)(ref screenArea)).TopRight
			});
			pathFigure.IsClosed = true;
			pathFigure.IsFilled = true;
			((Freezable)pathFigure).Freeze();
			return new PathGeometry(new PathFigure[1] { pathFigure });
		}
		default:
			return null;
		}
	}
}
