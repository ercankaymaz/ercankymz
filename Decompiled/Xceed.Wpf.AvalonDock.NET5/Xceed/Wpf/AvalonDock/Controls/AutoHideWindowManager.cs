using System;
using System.Windows.Threading;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls;

internal class AutoHideWindowManager
{
	private DockingManager _manager;

	private WeakReference _currentAutohiddenAnchor;

	private DispatcherTimer _closingTimer;

	private DispatcherTimer _closeTimer;

	internal AutoHideWindowManager(DockingManager manager)
	{
		_manager = manager;
		SetupClosingTimer();
		SetupCloseTimer();
	}

	internal void UpdateCloseTimerInterval(int newValue)
	{
		_closeTimer.Interval = TimeSpan.FromMilliseconds(newValue);
	}

	public void ShowAutoHideWindow(LayoutAnchorControl anchor)
	{
		if (_currentAutohiddenAnchor.GetValueOrDefault<LayoutAnchorControl>() != anchor)
		{
			StopClosingTimer();
			StopCloseTimer();
			_currentAutohiddenAnchor = new WeakReference(anchor);
			_manager.AutoHideWindow.Show(anchor);
			StartClosingTimer();
		}
	}

	public void HideAutoWindow(LayoutAnchorControl anchor = null)
	{
		if (anchor == null || anchor == _currentAutohiddenAnchor.GetValueOrDefault<LayoutAnchorControl>())
		{
			StopClosingTimer();
			StopCloseTimer();
		}
	}

	private void SetupClosingTimer()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		_closingTimer = new DispatcherTimer((DispatcherPriority)4);
		_closingTimer.Interval = TimeSpan.FromMilliseconds(50.0);
		_closingTimer.Tick += delegate
		{
			if (!_manager.AutoHideWindow.IsWin32MouseOver && !((LayoutAnchorable)_manager.AutoHideWindow.Model).IsActive && !_manager.AutoHideWindow.IsResizing)
			{
				StopClosingTimer();
				StartCloseTimer();
			}
		};
	}

	private void StartClosingTimer()
	{
		_closingTimer.Start();
	}

	private void StopClosingTimer()
	{
		_closingTimer.Stop();
	}

	private void SetupCloseTimer()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		_closeTimer = new DispatcherTimer((DispatcherPriority)4);
		_closeTimer.Interval = TimeSpan.FromMilliseconds(_manager.AutoHideWindowClosingTimer);
		_closeTimer.Tick += delegate
		{
			if (_manager.AutoHideWindow.IsWin32MouseOver || ((LayoutAnchorable)_manager.AutoHideWindow.Model).IsActive || _manager.AutoHideWindow.IsResizing)
			{
				_closeTimer.Stop();
				StartClosingTimer();
			}
			else
			{
				StopCloseTimer();
			}
		};
	}

	private void StartCloseTimer()
	{
		_closeTimer.Start();
	}

	private void StopCloseTimer()
	{
		_closeTimer.Stop();
		_manager.AutoHideWindow.Hide();
		_currentAutohiddenAnchor = null;
	}
}
