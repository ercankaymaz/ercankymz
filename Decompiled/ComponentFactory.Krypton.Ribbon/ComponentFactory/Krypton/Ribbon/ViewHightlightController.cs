#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewHightlightController : GlobalId, IMouseController
{
	private NeedPaintHandler _needPaint;

	private ViewBase _target;

	private bool _mouseOver;

	private bool _rightButtonDown;

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

	public event EventHandler Click;

	public event MouseEventHandler ContextClick;

	public ViewHightlightController(ViewBase target, NeedPaintHandler needPaint)
	{
		Debug.Assert(target != null);
		Debug.Assert(needPaint != null);
		_target = target;
		NeedPaint = needPaint;
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
		if (_mouseOver && button == MouseButtons.Left)
		{
			OnClick(EventArgs.Empty);
		}
		if (button == MouseButtons.Right)
		{
			_rightButtonDown = true;
		}
		return false;
	}

	public virtual void MouseUp(Control c, Point pt, MouseButtons button)
	{
		if (button == MouseButtons.Right && _rightButtonDown)
		{
			_rightButtonDown = false;
			OnContextClick(new MouseEventArgs(MouseButtons.Right, 1, pt.X, pt.Y, 0));
		}
	}

	public virtual void MouseLeave(Control c, ViewBase next)
	{
		_mouseOver = false;
		UpdateTargetState(c);
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
		PaletteState paletteState = (_mouseOver ? PaletteState.Tracking : PaletteState.Normal);
		if (_target.ElementState != paletteState)
		{
			_target.ElementState = paletteState;
			OnNeedPaint(needLayout: false);
		}
	}

	protected virtual void OnNeedPaint(bool needLayout)
	{
		if (_needPaint != null)
		{
			_needPaint(this, new NeedLayoutEventArgs(needLayout, _target.ClientRectangle));
		}
	}

	protected virtual void OnClick(EventArgs e)
	{
		if (this.Click != null)
		{
			this.Click(this, e);
		}
	}

	protected virtual void OnContextClick(MouseEventArgs e)
	{
		if (this.ContextClick != null)
		{
			this.ContextClick(this, e);
		}
	}
}
