using System.Windows;

namespace Xceed.Wpf.AvalonDock.Controls;

public class DockingManagerOverlayArea : OverlayArea
{
	private DockingManager _manager;

	internal DockingManagerOverlayArea(IOverlayWindow overlayWindow, DockingManager manager)
		: base(overlayWindow)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		_manager = manager;
		SetScreenDetectionArea(new Rect(_manager.PointToScreenDPI(default(Point)), _manager.TransformActualSizeToAncestor()));
	}
}
