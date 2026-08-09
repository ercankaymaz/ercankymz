using System.Windows;

namespace Xceed.Wpf.AvalonDock.Controls;

public class OverlayWindowDropTarget : IOverlayWindowDropTarget
{
	private IOverlayWindowArea _overlayArea;

	private Rect _screenDetectionArea;

	private OverlayWindowDropTargetType _type;

	Rect IOverlayWindowDropTarget.ScreenDetectionArea => _screenDetectionArea;

	OverlayWindowDropTargetType IOverlayWindowDropTarget.Type => _type;

	internal OverlayWindowDropTarget(IOverlayWindowArea overlayArea, OverlayWindowDropTargetType targetType, FrameworkElement element)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		_overlayArea = overlayArea;
		_type = targetType;
		_screenDetectionArea = new Rect(element.TransformToDeviceDPI(default(Point)), element.TransformActualSizeToAncestor());
	}
}
