#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class LinkLabelController : GlobalId, IMouseController, IKeyController, ISourceController
{
	private bool _captured;

	private bool _mouseOver;

	private DateTime _clickTime;

	private ViewDrawContent _target;

	private IPaletteContent _paletteDisabled;

	private IPaletteContent _paletteNormal;

	private IPaletteContent _paletteTracking;

	private IPaletteContent _palettePressed;

	private PaletteContentInheritOverride _pressed;

	private NeedPaintHandler _needPaint;

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

	protected virtual bool IsOperating
	{
		get
		{
			return true;
		}
		set
		{
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

	public LinkLabelController(ViewDrawContent target, IPaletteContent paletteDisabled, IPaletteContent paletteNormal, IPaletteContent paletteTracking, IPaletteContent palettePressed, PaletteContentInheritOverride pressed, NeedPaintHandler needPaint)
	{
		Debug.Assert(target != null);
		NeedPaint = needPaint;
		_target = target;
		_paletteDisabled = paletteDisabled;
		_paletteNormal = paletteNormal;
		_paletteTracking = paletteTracking;
		_palettePressed = palettePressed;
		_pressed = pressed;
		_clickTime = default(DateTime);
	}

	public virtual void MouseEnter(Control c)
	{
		if (IsOperating)
		{
			_mouseOver = true;
			UpdateTargetState(c);
		}
	}

	public virtual void MouseMove(Control c, Point pt)
	{
		if (IsOperating)
		{
			if (_target.Enabled)
			{
				c.Cursor = Cursors.Hand;
			}
			UpdateTargetState(c);
		}
	}

	public virtual bool MouseDown(Control c, Point pt, MouseButtons button)
	{
		if (IsOperating && button == MouseButtons.Left)
		{
			_captured = true;
			UpdateTargetState(c);
			if (c.CanFocus)
			{
				c.Focus();
			}
		}
		return _captured;
	}

	public virtual void MouseUp(Control c, Point pt, MouseButtons button)
	{
		if (!IsOperating || !_captured)
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
			UpdateTargetPalette();
		}
		else
		{
			UpdateTargetState(c);
		}
	}

	public virtual void MouseLeave(Control c, ViewBase next)
	{
		if (IsOperating && !_target.ContainsRecurse(next))
		{
			_mouseOver = false;
			_captured = false;
			UpdateTargetState(c);
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
		if (e.KeyCode == Keys.Return)
		{
			OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
		}
	}

	public virtual void KeyPress(Control c, KeyPressEventArgs e)
	{
	}

	public virtual bool KeyUp(Control c, KeyEventArgs e)
	{
		return _captured;
	}

	public virtual void GotFocus(Control c)
	{
	}

	public virtual void LostFocus(Control c)
	{
		if (_captured)
		{
			c.Capture = false;
			_captured = false;
			_mouseOver = _target.ClientRectangle.Contains(c.PointToClient(Control.MousePosition));
			UpdateTargetState(c);
		}
	}

	public void Update(Control c)
	{
		UpdateTargetState(c);
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
		PaletteState paletteState = ((!_target.Enabled) ? PaletteState.Disabled : (_captured ? ((!_target.ClientRectangle.Contains(pt)) ? PaletteState.Tracking : PaletteState.Pressed) : ((!_mouseOver) ? PaletteState.Normal : PaletteState.Tracking)));
		if (_target.ElementState != paletteState || _target.IsFixed)
		{
			_target.ElementState = paletteState;
			UpdateTargetPalette();
		}
	}

	protected virtual void UpdateTargetPalette()
	{
		_pressed.Apply = _target.State == PaletteState.Pressed;
		switch (_target.State)
		{
		case PaletteState.Disabled:
			_target.SetPalette(_paletteDisabled);
			break;
		case PaletteState.Normal:
			_target.SetPalette(_paletteNormal);
			break;
		case PaletteState.Tracking:
			_target.SetPalette(_paletteTracking);
			break;
		case PaletteState.Pressed:
			_target.SetPalette(_palettePressed);
			break;
		default:
			Debug.Assert(condition: false);
			break;
		}
		OnNeedPaint(needLayout: true);
	}

	protected virtual void OnClick(MouseEventArgs e)
	{
		TimeSpan timeSpan = DateTime.Now - _clickTime;
		if ((double)SystemInformation.DoubleClickTime < timeSpan.TotalMilliseconds)
		{
			_clickTime = DateTime.Now;
			if (this.Click != null)
			{
				this.Click(_target, e);
			}
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
