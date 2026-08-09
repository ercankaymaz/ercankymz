using System.Windows;
using System.Windows.Media;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls;

internal interface IDropTarget
{
	DropTargetType Type { get; }

	Geometry GetPreviewPath(OverlayWindow overlayWindow, LayoutFloatingWindow floatingWindow);

	bool HitTest(Point dragPoint);

	void Drop(LayoutFloatingWindow floatingWindow);

	void DragEnter();

	void DragLeave();
}
