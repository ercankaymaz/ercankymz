using System.Windows;

namespace Xceed.Wpf.AvalonDock.Controls;

public class DocumentPaneControlOverlayArea : OverlayArea
{
	private LayoutDocumentPaneControl _documentPaneControl;

	internal DocumentPaneControlOverlayArea(IOverlayWindow overlayWindow, LayoutDocumentPaneControl documentPaneControl)
		: base(overlayWindow)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		_documentPaneControl = documentPaneControl;
		SetScreenDetectionArea(new Rect(_documentPaneControl.PointToScreenDPI(default(Point)), _documentPaneControl.TransformActualSizeToAncestor()));
	}
}
