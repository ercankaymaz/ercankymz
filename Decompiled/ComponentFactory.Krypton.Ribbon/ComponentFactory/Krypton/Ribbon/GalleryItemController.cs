#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class GalleryItemController : GlobalId, IMouseController, ISourceController, IKeyController
{
	private ViewDrawRibbonGalleryItem _target;

	private ViewLayoutRibbonGalleryItems _layout;

	private NeedPaintHandler _needPaint;

	private Point _mousePoint;

	private bool _captured;

	private bool _mouseOver;

	public Point MousePoint => _mousePoint;

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

	public GalleryItemController(ViewDrawRibbonGalleryItem target, ViewLayoutRibbonGalleryItems layout, NeedPaintHandler needPaint)
	{
		Debug.Assert(target != null);
		Debug.Assert(layout != null);
		_mousePoint = CommonHelper.NullPoint;
		_target = target;
		_layout = layout;
		NeedPaint = needPaint;
	}

	public virtual void MouseEnter(Control c)
	{
		_mouseOver = true;
		UpdateTargetState(c);
	}

	public virtual void MouseMove(Control c, Point pt)
	{
		_mousePoint = pt;
		UpdateTargetState(pt);
	}

	public virtual bool MouseDown(Control c, Point pt, MouseButtons button)
	{
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
					if (!c.ContainsFocus)
					{
						if (c is KryptonGallery)
						{
							KryptonGallery kryptonGallery = (KryptonGallery)c;
							if (kryptonGallery.Ribbon == null)
							{
								kryptonGallery.Focus();
							}
						}
						else
						{
							c.Focus();
						}
					}
				}
			}
			OnNeedPaint(needLayout: true);
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
			_mousePoint = CommonHelper.NullPoint;
			_captured = false;
			UpdateTargetState(c);
		}
	}

	public virtual void DoubleClick(Point pt)
	{
	}

	public void GotFocus(Control c)
	{
	}

	public void LostFocus(Control c)
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
		case Keys.Up:
			_layout.TrackMoveUp();
			break;
		case Keys.Down:
			_layout.TrackMoveDown();
			break;
		case Keys.Left:
			_layout.TrackMoveLeft();
			break;
		case Keys.Right:
			_layout.TrackMoveRight();
			break;
		case Keys.Home:
			_layout.TrackMoveHome();
			break;
		case Keys.End:
			_layout.TrackMoveEnd();
			break;
		case Keys.Next:
			_layout.TrackMovePageDown();
			break;
		case Keys.Prior:
			_layout.TrackMovePageUp();
			break;
		case Keys.Return:
		case Keys.Space:
			if (_target.Enabled)
			{
				OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
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
		return false;
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
		if (!_target.Enabled)
		{
			paletteState = PaletteState.Disabled;
		}
		else
		{
			paletteState = PaletteState.Normal;
			paletteState = (_captured ? ((!_target.ClientRectangle.Contains(pt)) ? PaletteState.Tracking : PaletteState.Pressed) : ((!_mouseOver) ? PaletteState.Normal : PaletteState.Tracking));
		}
		if (_target.ElementState != paletteState)
		{
			if (paletteState == PaletteState.Tracking)
			{
				_target.Track();
			}
			else
			{
				_target.Untrack();
			}
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
}
