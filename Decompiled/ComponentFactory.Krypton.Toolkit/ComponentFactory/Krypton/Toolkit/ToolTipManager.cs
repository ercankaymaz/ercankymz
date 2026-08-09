using System;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ToolTipManager
{
	private Timer _startTimer;

	private Timer _stopTimer;

	private ViewBase _startTarget;

	private ViewBase _currentTarget;

	private bool _showingToolTips;

	public int ShowInterval
	{
		get
		{
			return _startTimer.Interval;
		}
		set
		{
			if (value < 0)
			{
				value = 1;
			}
			_startTimer.Interval = value;
		}
	}

	public int CloseInterval
	{
		get
		{
			return _stopTimer.Interval;
		}
		set
		{
			if (value < 0)
			{
				value = 1;
			}
			_stopTimer.Interval = value;
		}
	}

	public event EventHandler<ToolTipEventArgs> ShowToolTip;

	public event EventHandler CancelToolTip;

	public ToolTipManager()
	{
		_startTimer = new Timer();
		_startTimer.Interval = 1200;
		_startTimer.Tick += OnStartTimerTick;
		_stopTimer = new Timer();
		_stopTimer.Interval = 100;
		_stopTimer.Tick += OnStopTimerTick;
	}

	public void MouseEnter(ViewBase targetElement, Control c)
	{
		_currentTarget = targetElement;
		if (_showingToolTips)
		{
			return;
		}
		try
		{
			if (_startTarget == null)
			{
				_startTarget = targetElement;
				_startTimer.Start();
			}
			else if (_startTarget != targetElement)
			{
				_startTimer.Stop();
				_startTarget = targetElement;
				_startTimer.Start();
			}
		}
		catch
		{
		}
	}

	public void MouseMove(ViewBase targetElement, Control c, Point pt)
	{
	}

	public void MouseDown(ViewBase targetElement, Control c, Point pt, MouseButtons button)
	{
		_startTimer.Stop();
		_stopTimer.Stop();
		_currentTarget = null;
		_startTarget = null;
		if (_showingToolTips)
		{
			_showingToolTips = false;
			OnCancelToolTip();
		}
	}

	public void MouseUp(ViewBase targetElement, Control c, Point pt, MouseButtons button)
	{
	}

	public void MouseLeave(ViewBase targetElement, Control c, ViewBase next)
	{
		_currentTarget = null;
		if (_showingToolTips)
		{
			try
			{
				_stopTimer.Stop();
				_stopTimer.Start();
			}
			catch
			{
			}
		}
	}

	public void DoubleClick(ViewBase targetElement, Point pt)
	{
	}

	protected virtual void OnShowToolTip(ToolTipEventArgs e)
	{
		if (this.ShowToolTip != null)
		{
			this.ShowToolTip(this, e);
		}
	}

	protected virtual void OnCancelToolTip()
	{
		if (this.CancelToolTip != null)
		{
			this.CancelToolTip(this, EventArgs.Empty);
		}
	}

	private void OnStartTimerTick(object sender, EventArgs e)
	{
		_startTimer.Stop();
		if (_currentTarget == _startTarget)
		{
			_showingToolTips = true;
			OnShowToolTip(new ToolTipEventArgs(_startTarget, Control.MousePosition));
		}
		else
		{
			_startTarget = null;
		}
	}

	private void OnStopTimerTick(object sender, EventArgs e)
	{
		_stopTimer.Stop();
		if (_currentTarget != _startTarget)
		{
			_startTarget = null;
			_showingToolTips = false;
			OnCancelToolTip();
			if (_currentTarget != null)
			{
				_showingToolTips = true;
				_startTarget = _currentTarget;
				OnShowToolTip(new ToolTipEventArgs(_startTarget, Control.MousePosition));
			}
		}
	}
}
