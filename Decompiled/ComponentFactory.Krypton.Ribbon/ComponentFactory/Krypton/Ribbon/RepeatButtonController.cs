#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class RepeatButtonController : GlobalId, IMouseController
{
	private KryptonRibbon _ribbon;

	private bool _captured;

	private bool _mouseOver;

	private ViewBase _target;

	private NeedPaintHandler _needPaint;

	private Timer _repeatTimer;

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

	public virtual bool IgnoreVisualFormLeftButtonDown => false;

	private bool Active
	{
		get
		{
			if (_ribbon == null)
			{
				return false;
			}
			if (_ribbon.InDesignMode)
			{
				return true;
			}
			Form form = _ribbon.FindForm();
			return CommonHelper.ActiveFloatingWindow != null || (form != null && (form.ContainsFocus || (form.Parent != null && form.Visible && form.Enabled)));
		}
	}

	public event MouseEventHandler Click;

	public RepeatButtonController(KryptonRibbon ribbon, ViewBase target, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(target != null);
		_target = target;
		_ribbon = ribbon;
		NeedPaint = needPaint;
		_repeatTimer = new Timer();
		_repeatTimer.Interval = 50;
		_repeatTimer.Tick += OnRepeatTick;
	}

	public void PerformNeedPaint(bool needLayout)
	{
		OnNeedPaint(needLayout);
	}

	public virtual void MouseEnter(Control c)
	{
		if (Active)
		{
			_mouseOver = true;
			UpdateTargetState(c);
		}
	}

	public virtual void MouseMove(Control c, Point pt)
	{
		if (Active)
		{
			UpdateTargetState(pt);
		}
	}

	public virtual bool MouseDown(Control c, Point pt, MouseButtons button)
	{
		if (Active && button == MouseButtons.Left)
		{
			_captured = true;
			UpdateTargetState(pt);
			OnClick(new MouseEventArgs(MouseButtons.Left, 1, pt.X, pt.Y, 0));
			PerformNeedPaint(needLayout: false);
		}
		return _captured;
	}

	public virtual void MouseUp(Control c, Point pt, MouseButtons button)
	{
		if (!_captured)
		{
			return;
		}
		_captured = false;
		if (button == MouseButtons.Left)
		{
			if (_target.ElementState == PaletteState.Pressed)
			{
				_target.ElementState = PaletteState.Tracking;
			}
			_repeatTimer.Stop();
			PerformNeedPaint(needLayout: false);
		}
		else
		{
			UpdateTargetState(pt);
		}
	}

	public virtual void MouseLeave(Control c, ViewBase next)
	{
		if (!_target.ContainsRecurse(next))
		{
			_mouseOver = false;
			_captured = false;
			UpdateTargetState(c);
		}
	}

	public virtual void DoubleClick(Point pt)
	{
	}

	protected void UpdateTargetState(Control c)
	{
		if (c == null || c.IsDisposed)
		{
			UpdateTargetState(new Point(int.MaxValue, int.MaxValue));
		}
		else
		{
			UpdateTargetState(c.PointToClient(Control.MousePosition));
		}
	}

	protected void UpdateTargetState(Point pt)
	{
		PaletteState paletteState;
		if (!_target.Enabled)
		{
			paletteState = PaletteState.Disabled;
		}
		else
		{
			paletteState = PaletteState.Normal;
			paletteState = (_captured ? PaletteState.Pressed : ((!_mouseOver) ? PaletteState.Normal : PaletteState.Tracking));
		}
		if (_target.ElementState != paletteState)
		{
			_target.ElementState = paletteState;
			PerformNeedPaint(needLayout: false);
		}
	}

	protected virtual void OnNeedPaint(bool needLayout)
	{
		if (_needPaint != null)
		{
			_needPaint(this, new NeedLayoutEventArgs(needLayout));
		}
	}

	protected virtual void OnClick(MouseEventArgs e)
	{
		if (this.Click != null)
		{
			this.Click(_target, e);
		}
		_repeatTimer.Start();
	}

	private void OnRepeatTick(object sender, EventArgs e)
	{
		OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
	}
}
