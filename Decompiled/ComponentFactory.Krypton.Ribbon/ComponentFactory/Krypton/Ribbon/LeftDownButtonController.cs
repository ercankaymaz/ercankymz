#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class LeftDownButtonController : GlobalId, IMouseController
{
	private KryptonRibbon _ribbon;

	private bool _active;

	private bool _mouseOver;

	private bool _mouseDown;

	private bool _fixedPressed;

	private bool _hasFocus;

	private ViewBase _target;

	private NeedPaintHandler _needPaint;

	private Timer _updateTimer;

	public KryptonRibbon Ribbon => _ribbon;

	public ViewBase Target => _target;

	public bool HasFocus
	{
		get
		{
			return _hasFocus;
		}
		set
		{
			_hasFocus = value;
		}
	}

	public bool IsFixed => _fixedPressed;

	public virtual bool IgnoreVisualFormLeftButtonDown => false;

	public event MouseEventHandler Click;

	public LeftDownButtonController(KryptonRibbon ribbon, ViewBase target, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(target != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_target = target;
		_needPaint = needPaint;
		_updateTimer = new Timer();
		_updateTimer.Interval = 1;
		_updateTimer.Tick += OnUpdateTimer;
	}

	public void SetFixed()
	{
		_fixedPressed = true;
	}

	public void RemoveFixed()
	{
		if (_fixedPressed)
		{
			_mouseDown = false;
			_fixedPressed = false;
			_updateTimer.Start();
		}
	}

	public virtual void MouseEnter(Control c)
	{
		_mouseOver = true;
		KryptonForm kryptonForm = _ribbon.FindKryptonForm();
		_active = (kryptonForm != null && kryptonForm.WindowActive) || VisualPopupManager.Singleton.IsTracking || _ribbon.InDesignMode || CommonHelper.ActiveFloatingWindow != null;
		if (!_fixedPressed)
		{
			_updateTimer.Start();
		}
	}

	public virtual void MouseMove(Control c, Point pt)
	{
		if (!_fixedPressed && !_mouseOver)
		{
			_mouseOver = true;
			_updateTimer.Start();
		}
	}

	public virtual bool MouseDown(Control c, Point pt, MouseButtons button)
	{
		_active = true;
		if (button == MouseButtons.Left)
		{
			_mouseDown = true;
			if (!_fixedPressed && _ribbon.Enabled)
			{
				UpdateTargetState();
				SetFixed();
				OnClick(new MouseEventArgs(MouseButtons.Left, 1, pt.X, pt.Y, 0));
			}
		}
		return true;
	}

	public virtual void MouseUp(Control c, Point pt, MouseButtons button)
	{
	}

	public virtual void MouseLeave(Control c, ViewBase next)
	{
		_mouseOver = false;
		if (!_fixedPressed)
		{
			_updateTimer.Start();
		}
	}

	public virtual void DoubleClick(Point pt)
	{
	}

	protected virtual void UpdateTargetState()
	{
		PaletteState paletteState = PaletteState.Normal;
		if (_ribbon.Enabled)
		{
			if (_fixedPressed)
			{
				paletteState = PaletteState.Pressed;
			}
			else if (_mouseDown)
			{
				paletteState = PaletteState.Pressed;
			}
			else if (_mouseOver && _active)
			{
				paletteState = PaletteState.Tracking;
			}
		}
		if (_target.ElementState != paletteState)
		{
			_target.ElementState = paletteState;
			OnNeedPaint(needLayout: false, _target.ClientRectangle);
			if (!_ribbon.InKeyboardMode)
			{
				Application.DoEvents();
			}
		}
	}

	protected virtual void OnNeedPaint(bool needLayout, Rectangle invalidRect)
	{
		if (_needPaint != null)
		{
			_needPaint(this, new NeedLayoutEventArgs(needLayout, invalidRect));
		}
	}

	protected virtual void OnClick(MouseEventArgs e)
	{
		if (this.Click != null)
		{
			this.Click(this, e);
		}
	}

	private void OnUpdateTimer(object sender, EventArgs e)
	{
		_updateTimer.Stop();
		UpdateTargetState();
	}
}
