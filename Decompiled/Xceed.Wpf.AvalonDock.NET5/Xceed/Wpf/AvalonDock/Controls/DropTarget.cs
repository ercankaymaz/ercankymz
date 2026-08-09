using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls;

internal abstract class DropTarget<T> : DropTargetBase, IDropTarget where T : FrameworkElement
{
	private Rect[] _detectionRect;

	private T _targetElement;

	private DropTargetType _type;

	public Rect[] DetectionRects => _detectionRect;

	public T TargetElement => _targetElement;

	public DropTargetType Type => _type;

	protected DropTarget(T targetElement, Rect detectionRect, DropTargetType type)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		_targetElement = targetElement;
		_detectionRect = (Rect[])(object)new Rect[1] { detectionRect };
		_type = type;
	}

	protected DropTarget(T targetElement, IEnumerable<Rect> detectionRects, DropTargetType type)
	{
		_targetElement = targetElement;
		_detectionRect = detectionRects.ToArray();
		_type = type;
	}

	protected virtual void Drop(LayoutAnchorableFloatingWindow floatingWindow)
	{
	}

	protected virtual void Drop(LayoutDocumentFloatingWindow floatingWindow)
	{
	}

	public void Drop(LayoutFloatingWindow floatingWindow)
	{
		ILayoutRoot root = floatingWindow.Root;
		LayoutContent currentActiveContent = floatingWindow.Root.ActiveContent;
		DockingManager manager = root.Manager;
		if (floatingWindow is LayoutAnchorableFloatingWindow floatingWindow2)
		{
			LayoutAnchorable layoutContent = floatingWindow.Descendents().OfType<LayoutAnchorable>().FirstOrDefault((LayoutAnchorable l) => l != null);
			manager.RaisePreviewDockEvent(layoutContent);
			Drop(floatingWindow2);
			manager.RaiseDockedEvent(layoutContent);
		}
		else
		{
			LayoutDocumentFloatingWindow floatingWindow3 = floatingWindow as LayoutDocumentFloatingWindow;
			LayoutDocument layoutContent2 = floatingWindow.Descendents().OfType<LayoutDocument>().FirstOrDefault((LayoutDocument l) => l != null);
			manager.RaisePreviewDockEvent(layoutContent2);
			Drop(floatingWindow3);
			manager.RaiseDockedEvent(layoutContent2);
		}
		if (currentActiveContent != null)
		{
			((DispatcherObject)this).Dispatcher.BeginInvoke((Delegate)(Action)delegate
			{
				currentActiveContent.IsSelected = false;
				currentActiveContent.IsActive = false;
				currentActiveContent.IsActive = true;
			}, (DispatcherPriority)4, Array.Empty<object>());
		}
	}

	public virtual bool HitTest(Point dragPoint)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return _detectionRect.Any((Rect dr) => ((Rect)(ref dr)).Contains(dragPoint));
	}

	public abstract Geometry GetPreviewPath(OverlayWindow overlayWindow, LayoutFloatingWindow floatingWindow);

	public void DragEnter()
	{
		DropTargetBase.SetIsDraggingOver((DependencyObject)(object)TargetElement, value: true);
	}

	public void DragLeave()
	{
		DropTargetBase.SetIsDraggingOver((DependencyObject)(object)TargetElement, value: false);
	}
}
