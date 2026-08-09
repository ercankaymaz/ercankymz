#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

internal class RadioButtonController : GlobalId, IMouseController, IKeyController
{
	private bool _captured;

	private bool _enabled;

	private ViewDrawRadioButton _target;

	private ViewBase _top;

	private NeedPaintHandler _needPaint;

	public virtual bool IgnoreVisualFormLeftButtonDown => false;

	public bool Enabled
	{
		get
		{
			return _enabled;
		}
		set
		{
			_enabled = value;
		}
	}

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

	public event EventHandler Click;

	public RadioButtonController(ViewDrawRadioButton target, ViewBase top, NeedPaintHandler needPaint)
	{
		Debug.Assert(target != null);
		Debug.Assert(top != null);
		NeedPaint = needPaint;
		_target = target;
		_top = top;
	}

	public virtual void MouseEnter(Control c)
	{
		if (Enabled)
		{
			_target.Tracking = true;
			PerformNeedPaint();
		}
	}

	public virtual void MouseMove(Control c, Point pt)
	{
		if (_captured && Enabled)
		{
			bool flag = _top.ClientRectangle.Contains(pt);
			if (_target.Pressed != flag)
			{
				_target.Pressed = flag;
				PerformNeedPaint();
			}
		}
	}

	public virtual bool MouseDown(Control c, Point pt, MouseButtons button)
	{
		if (button == MouseButtons.Left)
		{
			_captured = true;
			if (Enabled)
			{
				_target.Pressed = true;
				PerformNeedPaint();
			}
			if (c.CanFocus)
			{
				c.Focus();
			}
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
		if (Enabled)
		{
			if (button == MouseButtons.Left && _target.Pressed && _target.Enabled)
			{
				OnClick(EventArgs.Empty);
			}
			_target.Pressed = false;
		}
		PerformNeedPaint();
	}

	public virtual void MouseLeave(Control c, ViewBase next)
	{
		if (!_target.ContainsRecurse(next))
		{
			if (Enabled)
			{
				_target.Tracking = false;
			}
			_captured = false;
			PerformNeedPaint();
		}
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
		if (e.KeyCode == Keys.Space && Enabled)
		{
			_captured = true;
			_target.Pressed = true;
			PerformNeedPaint();
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
		if ((e.KeyCode == Keys.Escape || e.KeyCode == Keys.Space) && _captured)
		{
			c.Capture = false;
			_captured = false;
			if (Enabled)
			{
				_target.Pressed = false;
			}
			if (e.KeyCode == Keys.Space && _target.Enabled)
			{
				OnClick(EventArgs.Empty);
			}
			PerformNeedPaint();
		}
		return _captured;
	}

	public void PerformNeedPaint()
	{
		OnNeedPaint(needLayout: false);
	}

	public void PerformNeedPaint(bool needLayout)
	{
		OnNeedPaint(needLayout);
	}

	protected virtual void OnClick(EventArgs e)
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
			_needPaint(this, new NeedLayoutEventArgs(needLayout));
		}
	}
}
