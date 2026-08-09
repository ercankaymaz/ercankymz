using System.Windows;

namespace Xceed.Wpf.AvalonDock.Controls;

public abstract class OverlayArea : IOverlayWindowArea
{
	private IOverlayWindow _overlayWindow;

	private Rect? _screenDetectionArea;

	Rect IOverlayWindowArea.ScreenDetectionArea => _screenDetectionArea.Value;

	internal OverlayArea(IOverlayWindow overlayWindow)
	{
		_overlayWindow = overlayWindow;
	}

	protected void SetScreenDetectionArea(Rect rect)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		_screenDetectionArea = rect;
	}
}
