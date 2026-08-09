using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls;

internal class DockingManagerDropTarget : DropTarget<DockingManager>
{
	private DockingManager _manager;

	internal DockingManagerDropTarget(DockingManager manager, Rect detectionRect, DropTargetType type)
		: base(manager, detectionRect, type)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		_manager = manager;
	}

	protected override void Drop(LayoutAnchorableFloatingWindow floatingWindow)
	{
		if (floatingWindow != null && floatingWindow.Root != null && floatingWindow.Root.ActiveContent != null)
		{
			floatingWindow.Root.ActiveContent.IsFloating = false;
		}
		switch (base.Type)
		{
		case DropTargetType.DockingManagerDockLeft:
		{
			if (_manager.Layout.RootPanel.Orientation != Orientation.Horizontal && _manager.Layout.RootPanel.Children.Count == 1)
			{
				_manager.Layout.RootPanel.Orientation = Orientation.Horizontal;
			}
			if (_manager.Layout.RootPanel.Orientation == Orientation.Horizontal)
			{
				LayoutAnchorablePaneGroup rootPanel5 = floatingWindow.RootPanel;
				if (rootPanel5 != null && rootPanel5.Orientation == Orientation.Horizontal)
				{
					ILayoutAnchorablePane[] array5 = rootPanel5.Children.ToArray();
					for (int m = 0; m < array5.Length; m++)
					{
						_manager.Layout.RootPanel.Children.Insert(m, array5[m]);
					}
				}
				else
				{
					_manager.Layout.RootPanel.Children.Insert(0, floatingWindow.RootPanel);
				}
				break;
			}
			LayoutPanel layoutPanel3 = new LayoutPanel
			{
				Orientation = Orientation.Horizontal
			};
			LayoutAnchorablePaneGroup rootPanel6 = floatingWindow.RootPanel;
			if (rootPanel6 != null && rootPanel6.Orientation == Orientation.Horizontal)
			{
				ILayoutAnchorablePane[] array6 = rootPanel6.Children.ToArray();
				for (int n = 0; n < array6.Length; n++)
				{
					layoutPanel3.Children.Insert(n, array6[n]);
				}
			}
			else
			{
				layoutPanel3.Children.Add(floatingWindow.RootPanel);
			}
			layoutPanel3.Children.Add(_manager.Layout.RootPanel);
			_manager.Layout.RootPanel = layoutPanel3;
			break;
		}
		case DropTargetType.DockingManagerDockRight:
		{
			if (_manager.Layout.RootPanel.Orientation != Orientation.Horizontal && _manager.Layout.RootPanel.Children.Count == 1)
			{
				_manager.Layout.RootPanel.Orientation = Orientation.Horizontal;
			}
			if (_manager.Layout.RootPanel.Orientation == Orientation.Horizontal)
			{
				LayoutAnchorablePaneGroup rootPanel7 = floatingWindow.RootPanel;
				if (rootPanel7 != null && rootPanel7.Orientation == Orientation.Horizontal)
				{
					ILayoutAnchorablePane[] array7 = rootPanel7.Children.ToArray();
					for (int num = 0; num < array7.Length; num++)
					{
						_manager.Layout.RootPanel.Children.Add(array7[num]);
					}
				}
				else
				{
					_manager.Layout.RootPanel.Children.Add(floatingWindow.RootPanel);
				}
				break;
			}
			LayoutPanel layoutPanel4 = new LayoutPanel
			{
				Orientation = Orientation.Horizontal
			};
			LayoutAnchorablePaneGroup rootPanel8 = floatingWindow.RootPanel;
			if (rootPanel8 != null && rootPanel8.Orientation == Orientation.Horizontal)
			{
				ILayoutAnchorablePane[] array8 = rootPanel8.Children.ToArray();
				for (int num2 = 0; num2 < array8.Length; num2++)
				{
					layoutPanel4.Children.Add(array8[num2]);
				}
			}
			else
			{
				layoutPanel4.Children.Add(floatingWindow.RootPanel);
			}
			layoutPanel4.Children.Insert(0, _manager.Layout.RootPanel);
			_manager.Layout.RootPanel = layoutPanel4;
			break;
		}
		case DropTargetType.DockingManagerDockTop:
		{
			if (_manager.Layout.RootPanel.Orientation != Orientation.Vertical && _manager.Layout.RootPanel.Children.Count == 1)
			{
				_manager.Layout.RootPanel.Orientation = Orientation.Vertical;
			}
			if (_manager.Layout.RootPanel.Orientation == Orientation.Vertical)
			{
				LayoutAnchorablePaneGroup rootPanel3 = floatingWindow.RootPanel;
				if (rootPanel3 != null && rootPanel3.Orientation == Orientation.Vertical)
				{
					ILayoutAnchorablePane[] array3 = rootPanel3.Children.ToArray();
					for (int k = 0; k < array3.Length; k++)
					{
						_manager.Layout.RootPanel.Children.Insert(k, array3[k]);
					}
				}
				else
				{
					_manager.Layout.RootPanel.Children.Insert(0, floatingWindow.RootPanel);
				}
				break;
			}
			LayoutPanel layoutPanel2 = new LayoutPanel
			{
				Orientation = Orientation.Vertical
			};
			LayoutAnchorablePaneGroup rootPanel4 = floatingWindow.RootPanel;
			if (rootPanel4 != null && rootPanel4.Orientation == Orientation.Vertical)
			{
				ILayoutAnchorablePane[] array4 = rootPanel4.Children.ToArray();
				for (int l = 0; l < array4.Length; l++)
				{
					layoutPanel2.Children.Insert(l, array4[l]);
				}
			}
			else
			{
				layoutPanel2.Children.Add(floatingWindow.RootPanel);
			}
			layoutPanel2.Children.Add(_manager.Layout.RootPanel);
			_manager.Layout.RootPanel = layoutPanel2;
			break;
		}
		case DropTargetType.DockingManagerDockBottom:
		{
			if (_manager.Layout.RootPanel.Orientation != Orientation.Vertical && _manager.Layout.RootPanel.Children.Count == 1)
			{
				_manager.Layout.RootPanel.Orientation = Orientation.Vertical;
			}
			if (_manager.Layout.RootPanel.Orientation == Orientation.Vertical)
			{
				LayoutAnchorablePaneGroup rootPanel = floatingWindow.RootPanel;
				if (rootPanel != null && rootPanel.Orientation == Orientation.Vertical)
				{
					ILayoutAnchorablePane[] array = rootPanel.Children.ToArray();
					for (int i = 0; i < array.Length; i++)
					{
						_manager.Layout.RootPanel.Children.Add(array[i]);
					}
				}
				else
				{
					_manager.Layout.RootPanel.Children.Add(floatingWindow.RootPanel);
				}
				break;
			}
			LayoutPanel layoutPanel = new LayoutPanel
			{
				Orientation = Orientation.Vertical
			};
			LayoutAnchorablePaneGroup rootPanel2 = floatingWindow.RootPanel;
			if (rootPanel2 != null && rootPanel2.Orientation == Orientation.Vertical)
			{
				ILayoutAnchorablePane[] array2 = rootPanel2.Children.ToArray();
				for (int j = 0; j < array2.Length; j++)
				{
					layoutPanel.Children.Add(array2[j]);
				}
			}
			else
			{
				layoutPanel.Children.Add(floatingWindow.RootPanel);
			}
			layoutPanel.Children.Insert(0, _manager.Layout.RootPanel);
			_manager.Layout.RootPanel = layoutPanel;
			break;
		}
		}
		base.Drop(floatingWindow);
	}

	public override Geometry GetPreviewPath(OverlayWindow overlayWindow, LayoutFloatingWindow floatingWindowModel)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		LayoutAnchorableFloatingWindow obj = floatingWindowModel as LayoutAnchorableFloatingWindow;
		ILayoutPositionableElement rootPanel = obj.RootPanel;
		ILayoutPositionableElementWithActualSize rootPanel2 = obj.RootPanel;
		Rect screenArea = base.TargetElement.GetScreenArea();
		switch (base.Type)
		{
		case DropTargetType.DockingManagerDockLeft:
		{
			double val3 = (rootPanel.DockWidth.IsAbsolute ? rootPanel.DockWidth.Value : rootPanel2.ActualWidth);
			return new RectangleGeometry(new Rect(((Rect)(ref screenArea)).Left - overlayWindow.Left, ((Rect)(ref screenArea)).Top - overlayWindow.Top, Math.Min(val3, ((Rect)(ref screenArea)).Width / 2.0), ((Rect)(ref screenArea)).Height));
		}
		case DropTargetType.DockingManagerDockTop:
		{
			double val2 = (rootPanel.DockHeight.IsAbsolute ? rootPanel.DockHeight.Value : rootPanel2.ActualHeight);
			return new RectangleGeometry(new Rect(((Rect)(ref screenArea)).Left - overlayWindow.Left, ((Rect)(ref screenArea)).Top - overlayWindow.Top, ((Rect)(ref screenArea)).Width, Math.Min(val2, ((Rect)(ref screenArea)).Height / 2.0)));
		}
		case DropTargetType.DockingManagerDockRight:
		{
			double val4 = (rootPanel.DockWidth.IsAbsolute ? rootPanel.DockWidth.Value : rootPanel2.ActualWidth);
			return new RectangleGeometry(new Rect(((Rect)(ref screenArea)).Right - overlayWindow.Left - Math.Min(val4, ((Rect)(ref screenArea)).Width / 2.0), ((Rect)(ref screenArea)).Top - overlayWindow.Top, Math.Min(val4, ((Rect)(ref screenArea)).Width / 2.0), ((Rect)(ref screenArea)).Height));
		}
		case DropTargetType.DockingManagerDockBottom:
		{
			double val = (rootPanel.DockHeight.IsAbsolute ? rootPanel.DockHeight.Value : rootPanel2.ActualHeight);
			return new RectangleGeometry(new Rect(((Rect)(ref screenArea)).Left - overlayWindow.Left, ((Rect)(ref screenArea)).Bottom - overlayWindow.Top - Math.Min(val, ((Rect)(ref screenArea)).Height / 2.0), ((Rect)(ref screenArea)).Width, Math.Min(val, ((Rect)(ref screenArea)).Height / 2.0)));
		}
		default:
			throw new InvalidOperationException();
		}
	}
}
