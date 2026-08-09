#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class GalleryButtonController : GlobalId, IMouseController
{
	private ViewBase _target;

	private bool _pressed;

	private bool _mouseOver;

	private NeedPaintHandler _needPaint;

	private Timer _repeatTimer;

	public virtual bool IgnoreVisualFormLeftButtonDown => false;

	public NeedPaintHandler NeedPaint
	{
		get
		{
			return _needPaint;
		}
		set
		{
			Debug.Assert((_needPaint == null && value != null) || (_needPaint != null && value == null));
			_needPaint = value;
		}
	}

	public ViewBase Target => _target;

	public event MouseEventHandler Click;

	public GalleryButtonController(ViewBase target, NeedPaintHandler needPaint, bool repeatTimer)
	{
		Debug.Assert(target != null);
		_target = target;
		NeedPaint = needPaint;
		if (repeatTimer)
		{
			_repeatTimer = new Timer();
			_repeatTimer.Interval = 250;
			_repeatTimer.Tick += OnRepeatTick;
		}
	}

	public void ForceLeave()
	{
		if (_mouseOver)
		{
			_pressed = false;
			_mouseOver = false;
			UpdateTargetState(new Point(int.MaxValue, int.MaxValue));
			if (_repeatTimer != null)
			{
				_repeatTimer.Stop();
			}
		}
	}

	public virtual void MouseEnter(Control c)
	{
		_mouseOver = true;
		UpdateTargetState(c);
	}

	public virtual void MouseMove(Control c, Point pt)
	{
	}

	public virtual bool MouseDown(Control c, Point pt, MouseButtons button)
	{
		if (button == MouseButtons.Left)
		{
			_pressed = true;
			UpdateTargetState(pt);
			if (_target.Enabled)
			{
				OnClick(new MouseEventArgs(MouseButtons.Left, 1, pt.X, pt.Y, 0));
				if (_repeatTimer != null)
				{
					_repeatTimer.Start();
				}
			}
		}
		return false;
	}

	public virtual void MouseUp(Control c, Point pt, MouseButtons button)
	{
		if (_pressed)
		{
			_pressed = false;
			UpdateTargetState(pt);
			if (_repeatTimer != null)
			{
				_repeatTimer.Stop();
			}
		}
	}

	public virtual void MouseLeave(Control c, ViewBase next)
	{
		if (!_target.ContainsRecurse(next))
		{
			_pressed = false;
			_mouseOver = false;
			UpdateTargetState(c);
			if (_repeatTimer != null)
			{
				_repeatTimer.Stop();
			}
		}
	}

	public virtual void DoubleClick(Point pt)
	{
	}

	public void PerformNeedPaint()
	{
		OnNeedPaint(needLayout: false);
	}

	public void PerformNeedPaint(bool needLayout)
	{
		OnNeedPaint(needLayout);
	}

	protected void UpdateTargetState(Control c)
	{
		if (c != null && !c.IsDisposed)
		{
			Form form = c.FindForm();
			if (form != null && form.Visible)
			{
				UpdateTargetState(c.PointToClient(Control.MousePosition));
				return;
			}
		}
		UpdateTargetState(new Point(int.MaxValue, int.MaxValue));
	}

	protected virtual void UpdateTargetState(Point pt)
	{
		PaletteState paletteState;
		if (_target.Enabled)
		{
			paletteState = ((!_mouseOver) ? PaletteState.Normal : ((!_pressed) ? PaletteState.Tracking : PaletteState.Pressed));
		}
		else
		{
			paletteState = PaletteState.Disabled;
			if (_repeatTimer != null)
			{
				_repeatTimer.Stop();
			}
		}
		if (_target.ElementState != paletteState)
		{
			_target.ElementState = paletteState;
			OnNeedPaint(needLayout: true);
		}
	}

	protected virtual void OnClick(MouseEventArgs e)
	{
		if (this.Click != null)
		{
			this.Click(_target, e);
		}
	}

	protected virtual void OnNeedPaint(bool needLayout)
	{
		if (_needPaint != null)
		{
			_needPaint(this, new NeedLayoutEventArgs(needLayout, _target.ClientRectangle));
		}
	}

	private void OnRepeatTick(object sender, EventArgs e)
	{
		if (_target.Enabled)
		{
			OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
		}
		else
		{
			_repeatTimer.Stop();
		}
	}
}
