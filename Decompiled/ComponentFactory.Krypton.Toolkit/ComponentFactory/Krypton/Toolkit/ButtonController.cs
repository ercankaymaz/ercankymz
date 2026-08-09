#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ButtonController : GlobalId, IMouseController, IKeyController, ISourceController
{
	private bool _captured;

	private bool _mouseOver;

	private bool _nonClientAsNormal;

	private bool _fixedPressed;

	private bool _becomesFixed;

	private bool _becomesRightFixed;

	private bool _inSplitRectangle;

	private bool _dragging;

	private bool _allowDragging;

	private bool _clickOnDown;

	private bool _repeat;

	private bool _draggingAttempt;

	private bool _preDragOffset;

	private Point _mousePoint;

	private ViewBase _target;

	private NeedPaintHandler _needPaint;

	private Timer _repeatTimer;

	private Rectangle _splitRectangle;

	private Rectangle _dragRect;

	private object _tag;

	public object Tag
	{
		get
		{
			return _tag;
		}
		set
		{
			_tag = value;
		}
	}

	public bool BecomesFixed
	{
		get
		{
			return _becomesFixed;
		}
		set
		{
			_becomesFixed = value;
		}
	}

	public bool BecomesRightFixed
	{
		get
		{
			return _becomesRightFixed;
		}
		set
		{
			_becomesRightFixed = value;
		}
	}

	public Point MousePoint => _mousePoint;

	public bool AllowDragging
	{
		get
		{
			return _allowDragging;
		}
		set
		{
			_allowDragging = value;
		}
	}

	public bool ClickOnDown
	{
		get
		{
			return _clickOnDown;
		}
		set
		{
			_clickOnDown = value;
		}
	}

	public Rectangle SplitRectangle
	{
		get
		{
			return _splitRectangle;
		}
		set
		{
			_splitRectangle = value;
		}
	}

	public bool NonClientAsNormal
	{
		get
		{
			return _nonClientAsNormal;
		}
		set
		{
			_nonClientAsNormal = value;
		}
	}

	public bool Repeat
	{
		get
		{
			return _repeat;
		}
		set
		{
			_repeat = value;
		}
	}

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

	public event MouseEventHandler RightClick;

	public event MouseEventHandler MouseSelect;

	public event EventHandler<DragStartEventCancelArgs> DragStart;

	public event EventHandler<PointEventArgs> DragMove;

	public event EventHandler<PointEventArgs> DragEnd;

	public event EventHandler DragQuit;

	public event EventHandler<ButtonDragRectangleEventArgs> ButtonDragRectangle;

	public event EventHandler<ButtonDragOffsetEventArgs> ButtonDragOffset;

	public ButtonController(ViewBase target, NeedPaintHandler needPaint)
	{
		Debug.Assert(target != null);
		_mousePoint = CommonHelper.NullPoint;
		_splitRectangle = CommonHelper.NullRectangle;
		_inSplitRectangle = false;
		_allowDragging = false;
		_dragging = false;
		_clickOnDown = false;
		_target = target;
		_repeat = false;
		NeedPaint = needPaint;
	}

	public void RemoveFixed()
	{
		if (_fixedPressed)
		{
			_captured = false;
			_fixedPressed = false;
			UpdateTargetState(Point.Empty);
		}
	}

	public void ClearDragRect()
	{
		_dragRect = Rectangle.Empty;
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
		if (!IsOperating)
		{
			return;
		}
		_mousePoint = pt;
		UpdateTargetState(pt);
		if (!Captured)
		{
			return;
		}
		if (AllowDragging)
		{
			if (_dragging)
			{
				OnDragMove(_mousePoint);
			}
			else if (!_dragRect.IsEmpty && !_dragRect.Contains(_mousePoint) && !_draggingAttempt)
			{
				_draggingAttempt = true;
				Point clientLocation = _target.ClientLocation;
				OnDragStart(offset: new Point(_mousePoint.X - clientLocation.X, _mousePoint.Y - clientLocation.Y), mousePt: _mousePoint, c: c);
			}
		}
		if (!_dragging && !_dragRect.IsEmpty && _preDragOffset)
		{
			ButtonDragOffsetEventArgs e = new ButtonDragOffsetEventArgs(pt);
			OnButtonDragOffset(e);
		}
	}

	public virtual bool MouseDown(Control c, Point pt, MouseButtons button)
	{
		if (IsOperating && _target.Enabled)
		{
			switch (button)
			{
			case MouseButtons.Left:
			{
				_captured = true;
				_draggingAttempt = false;
				ButtonDragRectangleEventArgs e = new ButtonDragRectangleEventArgs(pt);
				OnButtonDragRectangle(e);
				_dragRect = e.DragRect;
				_preDragOffset = e.PreDragOffset;
				if (_fixedPressed)
				{
					break;
				}
				UpdateTargetState(pt);
				if (BecomesFixed)
				{
					_fixedPressed = true;
				}
				OnMouseSelect(new MouseEventArgs(MouseButtons.Left, 1, pt.X, pt.Y, 0));
				if (ClickOnDown)
				{
					OnClick(new MouseEventArgs(MouseButtons.Left, 1, pt.X, pt.Y, 0));
					if (Repeat)
					{
						_repeatTimer = new Timer();
						_repeatTimer.Interval = SystemInformation.DoubleClickTime;
						_repeatTimer.Tick += OnRepeatTimer;
						_repeatTimer.Start();
					}
				}
				break;
			}
			case MouseButtons.Right:
				if (!_fixedPressed)
				{
					if (BecomesRightFixed)
					{
						_fixedPressed = true;
					}
					OnRightClick(new MouseEventArgs(MouseButtons.Right, 1, pt.X, pt.Y, 0));
				}
				break;
			}
		}
		return _captured;
	}

	public virtual void MouseUp(Control c, Point pt, MouseButtons button)
	{
		if (!IsOperating || !_target.Enabled)
		{
			return;
		}
		if (_repeatTimer != null)
		{
			_repeatTimer.Stop();
			_repeatTimer.Dispose();
			_repeatTimer = null;
		}
		if (!_captured)
		{
			return;
		}
		_captured = false;
		if (button == MouseButtons.Left)
		{
			if (_dragging)
			{
				OnDragEnd(pt);
			}
			if (_target.ElementState == PaletteState.Pressed || _target.ElementState == PaletteState.CheckedPressed)
			{
				if (!_fixedPressed)
				{
					_target.ElementState = PaletteState.Tracking;
				}
				if (_target.Enabled && !ClickOnDown)
				{
					OnClick(new MouseEventArgs(MouseButtons.Left, 1, pt.X, pt.Y, 0));
				}
			}
			OnNeedPaint(needLayout: true);
		}
		else
		{
			if (_dragging)
			{
				OnDragQuit();
			}
			UpdateTargetState(pt);
		}
	}

	public virtual void MouseLeave(Control c, ViewBase next)
	{
		if (!IsOperating || ViewIsPartOfButton(next))
		{
			return;
		}
		if (_repeatTimer != null)
		{
			_repeatTimer.Stop();
			_repeatTimer.Dispose();
			_repeatTimer = null;
		}
		_mouseOver = false;
		if (!_fixedPressed)
		{
			_mousePoint = CommonHelper.NullPoint;
			_captured = false;
			if (_dragging)
			{
				OnDragQuit();
			}
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
		if (e.KeyCode == Keys.Space)
		{
			_captured = true;
			_mouseOver = true;
			if (BecomesFixed)
			{
				_fixedPressed = true;
			}
			_target.ElementState = PaletteState.Pressed;
			OnNeedPaint(needLayout: true);
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
			if (_dragging)
			{
				OnDragQuit();
			}
			_mouseOver = _target.ClientRectangle.Contains(c.PointToClient(Control.MousePosition));
			if (e.KeyCode == Keys.Space && _target.Enabled)
			{
				OnClick(new MouseEventArgs(MouseButtons.Left, 1, -1, -1, 0));
			}
			UpdateTargetState(c);
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
			if (_dragging)
			{
				OnDragQuit();
			}
			else
			{
				c.Capture = false;
				_captured = false;
			}
			_mouseOver = _target.ClientRectangle.Contains(c.PointToClient(Control.MousePosition));
			UpdateTargetState(c);
		}
	}

	public void PerformNeedPaint()
	{
		OnNeedPaint(needLayout: false);
	}

	public void PerformNeedPaint(bool needLayout)
	{
		OnNeedPaint(needLayout);
	}

	protected virtual bool ViewIsPartOfButton(ViewBase next)
	{
		return _target.ContainsRecurse(next);
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
		if (!_target.Enabled)
		{
			paletteState = PaletteState.Disabled;
		}
		else
		{
			paletteState = PaletteState.Normal;
			paletteState = (_fixedPressed ? PaletteState.Pressed : (_captured ? ((!IsOnlyPressedWhenOver) ? PaletteState.Pressed : (_target.ClientRectangle.Contains(pt) ? PaletteState.Pressed : ((!NonClientAsNormal) ? PaletteState.Tracking : PaletteState.Normal))) : ((!_mouseOver) ? PaletteState.Normal : PaletteState.Tracking)));
		}
		bool flag = SplitRectangle.Contains(pt);
		if (_target.ElementState != paletteState || flag != _inSplitRectangle)
		{
			_inSplitRectangle = flag;
			_target.ElementState = paletteState;
			OnNeedPaint(needLayout: true);
		}
	}

	protected virtual void OnButtonDragRectangle(ButtonDragRectangleEventArgs e)
	{
		if (this.ButtonDragRectangle != null)
		{
			this.ButtonDragRectangle(this, e);
		}
	}

	protected virtual void OnButtonDragOffset(ButtonDragOffsetEventArgs e)
	{
		if (this.ButtonDragOffset != null)
		{
			this.ButtonDragOffset(this, e);
		}
	}

	protected virtual void OnDragStart(Point mousePt, Point offset, Control c)
	{
		mousePt = _target.OwningControl.PointToScreen(mousePt);
		DragStartEventCancelArgs dragStartEventCancelArgs = new DragStartEventCancelArgs(mousePt, offset, c);
		if (this.DragStart != null)
		{
			this.DragStart(this, dragStartEventCancelArgs);
		}
		_dragging = !dragStartEventCancelArgs.Cancel;
	}

	protected virtual void OnDragMove(Point mousePt)
	{
		if (this.DragMove != null)
		{
			mousePt = _target.OwningControl.PointToScreen(mousePt);
			this.DragMove(this, new PointEventArgs(mousePt));
		}
	}

	protected virtual void OnDragEnd(Point mousePt)
	{
		_dragging = false;
		if (this.DragEnd != null)
		{
			mousePt = _target.OwningControl.PointToScreen(mousePt);
			this.DragEnd(this, new PointEventArgs(mousePt));
		}
	}

	protected virtual void OnDragQuit()
	{
		_dragging = false;
		if (this.DragQuit != null)
		{
			this.DragQuit(this, EventArgs.Empty);
		}
	}

	protected virtual void OnClick(MouseEventArgs e)
	{
		if (this.Click != null)
		{
			this.Click(_target, e);
		}
	}

	protected virtual void OnRightClick(MouseEventArgs e)
	{
		if (this.RightClick != null)
		{
			this.RightClick(_target, e);
		}
	}

	protected virtual void OnMouseSelect(MouseEventArgs e)
	{
		if (this.MouseSelect != null)
		{
			this.MouseSelect(_target, e);
		}
	}

	protected virtual void OnNeedPaint(bool needLayout)
	{
		if (_needPaint != null)
		{
			_needPaint(this, new NeedLayoutEventArgs(needLayout, _target.ClientRectangle));
		}
	}

	private void OnRepeatTimer(object sender, EventArgs e)
	{
		Timer timer = (Timer)sender;
		timer.Interval = Math.Max(SystemInformation.DoubleClickTime / 4, 100);
		OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
	}
}
