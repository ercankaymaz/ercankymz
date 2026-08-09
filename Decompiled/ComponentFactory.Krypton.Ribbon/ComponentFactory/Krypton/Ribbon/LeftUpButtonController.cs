#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class LeftUpButtonController : GlobalId, IMouseController
{
	private KryptonRibbon _ribbon;

	private bool _active;

	private bool _captured;

	private bool _mouseOver;

	private ViewBase _target;

	private NeedPaintHandler _needPaint;

	public KryptonRibbon Ribbon => _ribbon;

	public ViewBase Target => _target;

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

	protected virtual bool IsOnlyPressedWhenOver
	{
		get
		{
			return true;
		}
		set
		{
		}
	}

	protected bool Captured
	{
		get
		{
			return _captured;
		}
		set
		{
			_captured = value;
		}
	}

	public event MouseEventHandler Click;

	public LeftUpButtonController(KryptonRibbon ribbon, ViewBase target, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(target != null);
		_ribbon = ribbon;
		_target = target;
		NeedPaint = needPaint;
	}

	public virtual void MouseEnter(Control c)
	{
		_mouseOver = true;
		KryptonForm kryptonForm = _ribbon.FindKryptonForm();
		_active = (kryptonForm != null && kryptonForm.WindowActive) || VisualPopupManager.Singleton.IsTracking || _ribbon.InDesignMode || CommonHelper.ActiveFloatingWindow != null;
		UpdateTargetState(c);
	}

	public virtual void MouseMove(Control c, Point pt)
	{
		UpdateTargetState(pt);
	}

	public virtual bool MouseDown(Control c, Point pt, MouseButtons button)
	{
		_active = true;
		if (button == MouseButtons.Left)
		{
			_captured = true;
			UpdateTargetState(pt);
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
				if (_target.Enabled)
				{
					OnClick(new MouseEventArgs(MouseButtons.Left, 1, pt.X, pt.Y, 0));
				}
			}
			OnNeedPaint(needLayout: false);
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

	protected virtual void UpdateTargetState(Point pt)
	{
		PaletteState paletteState;
		if (!_target.Enabled)
		{
			paletteState = PaletteState.Disabled;
		}
		else
		{
			paletteState = PaletteState.Normal;
			paletteState = (_captured ? ((!IsOnlyPressedWhenOver) ? PaletteState.Pressed : ((!_target.ClientRectangle.Contains(pt)) ? PaletteState.Normal : PaletteState.Pressed)) : ((!_mouseOver || !_active) ? PaletteState.Normal : PaletteState.Tracking));
		}
		if (_target.ElementState != paletteState)
		{
			_target.ElementState = paletteState;
			OnNeedPaint(needLayout: false);
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
			_needPaint(this, new NeedLayoutEventArgs(needLayout));
		}
	}
}
