using System.Windows;

namespace Xceed.Wpf.AvalonDock.Controls;

public class AnchorablePaneControlOverlayArea : OverlayArea
{
	private LayoutAnchorablePaneControl _anchorablePaneControl;

	internal AnchorablePaneControlOverlayArea(IOverlayWindow overlayWindow, LayoutAnchorablePaneControl anchorablePaneControl)
		: base(overlayWindow)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		_anchorablePaneControl = anchorablePaneControl;
		SetScreenDetectionArea(new Rect(_anchorablePaneControl.PointToScreenDPI(default(Point)), _anchorablePaneControl.TransformActualSizeToAncestor()));
	}
}
