using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls;

internal class DragService
{
	private DockingManager _manager;

	private LayoutFloatingWindowControl _floatingWindow;

	private List<IOverlayWindowHost> _overlayWindowHosts = new List<IOverlayWindowHost>();

	private IOverlayWindowHost _currentHost;

	private IOverlayWindow _currentWindow;

	private List<IDropArea> _currentWindowAreas = new List<IDropArea>();

	private IDropTarget _currentDropTarget;

	public DragService(LayoutFloatingWindowControl floatingWindow)
	{
		_floatingWindow = floatingWindow;
		_manager = floatingWindow.Model.Root.Manager;
		GetOverlayWindowHosts();
	}

	public void UpdateMouseLocation(Point dragPosition)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		_ = _floatingWindow.Model;
		IOverlayWindowHost overlayWindowHost = _overlayWindowHosts.FirstOrDefault((IOverlayWindowHost oh) => oh.HitTest(dragPosition));
		if (_currentHost != null || _currentHost != overlayWindowHost)
		{
			if ((_currentHost != null && !_currentHost.HitTest(dragPosition)) || _currentHost != overlayWindowHost)
			{
				if (_currentDropTarget != null)
				{
					_currentWindow.DragLeave(_currentDropTarget);
				}
				_currentDropTarget = null;
				_currentWindowAreas.ForEach(delegate(IDropArea a)
				{
					_currentWindow.DragLeave(a);
				});
				_currentWindowAreas.Clear();
				if (_currentWindow != null)
				{
					_currentWindow.DragLeave(_floatingWindow);
				}
				if (_currentHost != null)
				{
					_currentHost.HideOverlayWindow();
				}
				_currentHost = null;
			}
			if (_currentHost != overlayWindowHost)
			{
				_currentHost = overlayWindowHost;
				_currentWindow = _currentHost.ShowOverlayWindow(_floatingWindow);
				_currentWindow.DragEnter(_floatingWindow);
			}
		}
		if (_currentHost == null)
		{
			return;
		}
		if (_currentDropTarget != null && !_currentDropTarget.HitTest(dragPosition))
		{
			_currentWindow.DragLeave(_currentDropTarget);
			_currentDropTarget = null;
		}
		List<IDropArea> areasToRemove = new List<IDropArea>();
		_currentWindowAreas.ForEach(delegate(IDropArea a)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000a: Unknown result type (might be due to invalid IL or missing references)
			Rect detectionRect = a.DetectionRect;
			if (!((Rect)(ref detectionRect)).Contains(dragPosition))
			{
				_currentWindow.DragLeave(a);
				areasToRemove.Add(a);
			}
		});
		areasToRemove.ForEach(delegate(IDropArea a)
		{
			_currentWindowAreas.Remove(a);
		});
		List<IDropArea> list = _currentHost.GetDropAreas(_floatingWindow).Where(delegate(IDropArea cw)
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			if (!_currentWindowAreas.Contains(cw))
			{
				Rect detectionRect = cw.DetectionRect;
				return ((Rect)(ref detectionRect)).Contains(dragPosition);
			}
			return false;
		}).ToList();
		_currentWindowAreas.AddRange(list);
		list.ForEach(delegate(IDropArea a)
		{
			_currentWindow.DragEnter(a);
		});
		if (_currentDropTarget != null)
		{
			return;
		}
		_currentWindowAreas.ForEach(delegate
		{
			if (_currentDropTarget == null)
			{
				_currentDropTarget = _currentWindow.GetTargets().FirstOrDefault((IDropTarget dt) => dt.HitTest(dragPosition));
				if (_currentDropTarget != null)
				{
					_currentWindow.DragEnter(_currentDropTarget);
				}
			}
		});
	}

	public void Drop(Point dropLocation, out bool dropHandled)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		dropHandled = false;
		UpdateMouseLocation(dropLocation);
		ILayoutRoot root = (_floatingWindow.Model as LayoutFloatingWindow).Root;
		if (_currentHost != null)
		{
			_currentHost.HideOverlayWindow();
		}
		if (_currentDropTarget != null)
		{
			_currentWindow.DragDrop(_currentDropTarget);
			root.CollectGarbage();
			dropHandled = true;
		}
		_currentWindowAreas.ForEach(delegate(IDropArea a)
		{
			_currentWindow.DragLeave(a);
		});
		if (_currentDropTarget != null)
		{
			_currentWindow.DragLeave(_currentDropTarget);
		}
		if (_currentWindow != null)
		{
			_currentWindow.DragLeave(_floatingWindow);
		}
		_currentWindow = null;
		_currentHost = null;
	}

	internal void Abort()
	{
		_ = _floatingWindow.Model;
		_currentWindowAreas.ForEach(delegate(IDropArea a)
		{
			_currentWindow.DragLeave(a);
		});
		if (_currentDropTarget != null)
		{
			_currentWindow.DragLeave(_currentDropTarget);
		}
		if (_currentWindow != null)
		{
			_currentWindow.DragLeave(_floatingWindow);
		}
		_currentWindow = null;
		if (_currentHost != null)
		{
			_currentHost.HideOverlayWindow();
		}
		_currentHost = null;
	}

	private void GetOverlayWindowHosts()
	{
		foreach (Window item in from w in _manager.GetWindowsByZOrder()
			where w != _floatingWindow && w.IsVisible
			select w)
		{
			if (item == Window.GetWindow((DependencyObject)(object)_manager))
			{
				_overlayWindowHosts.Add(_manager);
			}
			else if (item is LayoutAnchorableFloatingWindowControl)
			{
				_overlayWindowHosts.Add(item as LayoutAnchorableFloatingWindowControl);
			}
		}
	}
}
