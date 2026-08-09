#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class TrackBarController : GlobalId, IMouseController, IKeyController, ISourceController
{
	private ViewDrawTP _drawTB;

	private Timer _repeatTimer;

	private bool _captured;

	private bool _targetHigher;

	private int _targetValue;

	private Point _lastMovePt;

	public virtual bool IgnoreVisualFormLeftButtonDown => false;

	public TrackBarController(ViewDrawTP drawTB)
	{
		_drawTB = drawTB;
	}

	public virtual void MouseEnter(Control c)
	{
	}

	public virtual void MouseMove(Control c, Point pt)
	{
		if (!_captured || !_drawTB.ClientRectangle.Contains(pt))
		{
			return;
		}
		_ = _lastMovePt;
		if (!(_lastMovePt != pt))
		{
			return;
		}
		_lastMovePt = pt;
		_repeatTimer.Stop();
		_repeatTimer.Start();
		int num = _drawTB.NearestValueFromPoint(pt);
		int value = _drawTB.ViewDrawTrackBar.Value;
		if (_targetHigher)
		{
			if (num > value)
			{
				_targetValue = num;
			}
		}
		else if (num < value)
		{
			_targetValue = num;
		}
		OnRepeatTimer(_repeatTimer, EventArgs.Empty);
	}

	public virtual bool MouseDown(Control c, Point pt, MouseButtons button)
	{
		if (button == MouseButtons.Left && _drawTB.ClientRectangle.Contains(pt))
		{
			_captured = true;
			_targetValue = _drawTB.NearestValueFromPoint(pt);
			_targetHigher = _targetValue > _drawTB.ViewDrawTrackBar.Value;
			OnRepeatTimer(_repeatTimer, EventArgs.Empty);
			_repeatTimer = new Timer();
			_repeatTimer.Interval = SystemInformation.DoubleClickTime;
			_repeatTimer.Tick += OnRepeatTimer;
			_repeatTimer.Start();
		}
		return _captured;
	}

	public virtual void MouseUp(Control c, Point pt, MouseButtons button)
	{
		if (_repeatTimer != null)
		{
			_repeatTimer.Stop();
			_repeatTimer.Dispose();
			_repeatTimer = null;
		}
		if (_captured)
		{
			_captured = false;
		}
	}

	public virtual void MouseLeave(Control c, ViewBase next)
	{
		if (_repeatTimer != null)
		{
			_repeatTimer.Stop();
			_repeatTimer.Dispose();
			_repeatTimer = null;
		}
		_lastMovePt = Point.Empty;
	}

	public virtual void DoubleClick(Point pt)
	{
	}

	public virtual void KeyDown(Control c, KeyEventArgs e)
	{
		Debug.Assert(c != null);
		Debug.Assert(e != null);
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		switch (e.KeyCode)
		{
		case Keys.Left:
		case Keys.Up:
			if (_drawTB.ViewDrawTrackBar.Orientation == Orientation.Horizontal)
			{
				_drawTB.ViewDrawTrackBar.ScrollValue = Math.Max(_drawTB.ViewDrawTrackBar.Minimum, Math.Min(_drawTB.ViewDrawTrackBar.Value - _drawTB.ViewDrawTrackBar.SmallChange, _drawTB.ViewDrawTrackBar.Maximum));
			}
			else
			{
				_drawTB.ViewDrawTrackBar.ScrollValue = Math.Max(_drawTB.ViewDrawTrackBar.Minimum, Math.Min(_drawTB.ViewDrawTrackBar.Value + _drawTB.ViewDrawTrackBar.SmallChange, _drawTB.ViewDrawTrackBar.Maximum));
			}
			break;
		case Keys.Right:
		case Keys.Down:
			if (_drawTB.ViewDrawTrackBar.Orientation == Orientation.Horizontal)
			{
				_drawTB.ViewDrawTrackBar.ScrollValue = Math.Max(_drawTB.ViewDrawTrackBar.Minimum, Math.Min(_drawTB.ViewDrawTrackBar.Value + _drawTB.ViewDrawTrackBar.SmallChange, _drawTB.ViewDrawTrackBar.Maximum));
			}
			else
			{
				_drawTB.ViewDrawTrackBar.ScrollValue = Math.Max(_drawTB.ViewDrawTrackBar.Minimum, Math.Min(_drawTB.ViewDrawTrackBar.Value - _drawTB.ViewDrawTrackBar.SmallChange, _drawTB.ViewDrawTrackBar.Maximum));
			}
			break;
		case Keys.Home:
			if (_drawTB.ViewDrawTrackBar.Orientation == Orientation.Horizontal)
			{
				_drawTB.ViewDrawTrackBar.ScrollValue = _drawTB.ViewDrawTrackBar.Minimum;
			}
			else
			{
				_drawTB.ViewDrawTrackBar.ScrollValue = _drawTB.ViewDrawTrackBar.Maximum;
			}
			break;
		case Keys.End:
			if (_drawTB.ViewDrawTrackBar.Orientation == Orientation.Horizontal)
			{
				_drawTB.ViewDrawTrackBar.ScrollValue = _drawTB.ViewDrawTrackBar.Maximum;
			}
			else
			{
				_drawTB.ViewDrawTrackBar.ScrollValue = _drawTB.ViewDrawTrackBar.Minimum;
			}
			break;
		case Keys.Next:
			if (_drawTB.ViewDrawTrackBar.Orientation == Orientation.Horizontal)
			{
				_drawTB.ViewDrawTrackBar.ScrollValue = Math.Max(_drawTB.ViewDrawTrackBar.Minimum, Math.Min(_drawTB.ViewDrawTrackBar.Value + _drawTB.ViewDrawTrackBar.LargeChange, _drawTB.ViewDrawTrackBar.Maximum));
			}
			else
			{
				_drawTB.ViewDrawTrackBar.ScrollValue = Math.Max(_drawTB.ViewDrawTrackBar.Minimum, Math.Min(_drawTB.ViewDrawTrackBar.Value - _drawTB.ViewDrawTrackBar.LargeChange, _drawTB.ViewDrawTrackBar.Maximum));
			}
			break;
		case Keys.Prior:
			if (_drawTB.ViewDrawTrackBar.Orientation == Orientation.Horizontal)
			{
				_drawTB.ViewDrawTrackBar.ScrollValue = Math.Max(_drawTB.ViewDrawTrackBar.Minimum, Math.Min(_drawTB.ViewDrawTrackBar.Value - _drawTB.ViewDrawTrackBar.LargeChange, _drawTB.ViewDrawTrackBar.Maximum));
			}
			else
			{
				_drawTB.ViewDrawTrackBar.ScrollValue = Math.Max(_drawTB.ViewDrawTrackBar.Minimum, Math.Min(_drawTB.ViewDrawTrackBar.Value + _drawTB.ViewDrawTrackBar.LargeChange, _drawTB.ViewDrawTrackBar.Maximum));
			}
			break;
		}
	}

	public virtual void KeyPress(Control c, KeyPressEventArgs e)
	{
	}

	public virtual bool KeyUp(Control c, KeyEventArgs e)
	{
		Debug.Assert(c != null);
		Debug.Assert(e != null);
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		return _captured;
	}

	public virtual void GotFocus(Control c)
	{
	}

	public virtual void LostFocus(Control c)
	{
		Debug.Assert(c != null);
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		if (_captured)
		{
			c.Capture = false;
			_captured = false;
			if (_repeatTimer != null)
			{
				_repeatTimer.Stop();
				_repeatTimer.Dispose();
				_repeatTimer = null;
			}
		}
	}

	private void OnRepeatTimer(object sender, EventArgs e)
	{
		int value = _drawTB.ViewDrawTrackBar.Value;
		if (value != _targetValue)
		{
			if (value < _targetValue)
			{
				_drawTB.ViewDrawTrackBar.ScrollValue = Math.Min(_targetValue, value + _drawTB.ViewDrawTrackBar.LargeChange);
			}
			else
			{
				_drawTB.ViewDrawTrackBar.ScrollValue = Math.Max(_targetValue, value - _drawTB.ViewDrawTrackBar.LargeChange);
			}
		}
	}
}
