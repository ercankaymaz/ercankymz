using System.Linq;
using System.Windows;
using System.Windows.Media;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls;

internal class DocumentPaneGroupDropTarget : DropTarget<LayoutDocumentPaneGroupControl>
{
	private LayoutDocumentPaneGroupControl _targetPane;

	internal DocumentPaneGroupDropTarget(LayoutDocumentPaneGroupControl paneControl, Rect detectionRect, DropTargetType type)
		: base(paneControl, detectionRect, type)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		_targetPane = paneControl;
	}

	protected override void Drop(LayoutDocumentFloatingWindow floatingWindow)
	{
		ILayoutPane layoutPane = _targetPane.Model as ILayoutPane;
		if (layoutPane.FindParent<LayoutFloatingWindow>() == null && floatingWindow != null && floatingWindow.Root != null && floatingWindow.Root.ActiveContent != null)
		{
			floatingWindow.Root.ActiveContent.IsFloating = false;
		}
		if (base.Type == DropTargetType.DocumentPaneGroupDockInside)
		{
			LayoutDocumentPane obj = (layoutPane as LayoutDocumentPaneGroup).Children[0] as LayoutDocumentPane;
			LayoutDocument rootDocument = floatingWindow.RootDocument;
			obj.Children.Insert(0, rootDocument);
		}
		base.Drop(floatingWindow);
	}

	protected override void Drop(LayoutAnchorableFloatingWindow floatingWindow)
	{
		ILayoutPane layoutPane = _targetPane.Model as ILayoutPane;
		if (layoutPane.FindParent<LayoutFloatingWindow>() == null && floatingWindow != null && floatingWindow.Root != null && floatingWindow.Root.ActiveContent != null)
		{
			floatingWindow.Root.ActiveContent.IsFloating = false;
		}
		if (base.Type == DropTargetType.DocumentPaneGroupDockInside)
		{
			LayoutDocumentPane layoutDocumentPane = (layoutPane as LayoutDocumentPaneGroup).Children[0] as LayoutDocumentPane;
			LayoutAnchorablePaneGroup rootPanel = floatingWindow.RootPanel;
			int num = 0;
			LayoutAnchorable[] array = rootPanel.Descendents().OfType<LayoutAnchorable>().ToArray();
			foreach (LayoutAnchorable layoutAnchorable in array)
			{
				if (layoutAnchorable.CanClose)
				{
					layoutAnchorable.SetCanCloseInternal(canClose: true);
				}
				layoutDocumentPane.Children.Insert(num, layoutAnchorable);
				num++;
			}
		}
		base.Drop(floatingWindow);
	}

	public override Geometry GetPreviewPath(OverlayWindow overlayWindow, LayoutFloatingWindow floatingWindowModel)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		if (base.Type == DropTargetType.DocumentPaneGroupDockInside)
		{
			Rect screenArea = base.TargetElement.GetScreenArea();
			((Rect)(ref screenArea)).Offset(0.0 - overlayWindow.Left, 0.0 - overlayWindow.Top);
			return new RectangleGeometry(screenArea);
		}
		return null;
	}
}
