using System;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class TrackPositionController : GlobalId, IMouseController
{
	private ViewDrawTP _drawTB;

	private Point _lastMovePt;

	private bool _captured;

	private bool _mouseOver;

	public virtual bool IgnoreVisualFormLeftButtonDown => false;

	public TrackPositionController(ViewDrawTP drawTB)
	{
		_drawTB = drawTB;
	}

	public virtual void MouseEnter(Control c)
	{
		_mouseOver = true;
		UpdateTargetState();
	}

	public virtual void MouseMove(Control c, Point pt)
	{
		if (!_captured)
		{
			return;
		}
		_ = _lastMovePt;
		if (_lastMovePt != pt)
		{
			_lastMovePt = pt;
			int num = _drawTB.NearestValueFromPoint(pt);
			if (_drawTB.ViewDrawTrackBar.Value != num)
			{
				_drawTB.ViewDrawTrackBar.ScrollValue = Math.Max(_drawTB.ViewDrawTrackBar.Minimum, Math.Min(num, _drawTB.ViewDrawTrackBar.Maximum));
			}
		}
	}

	public virtual bool MouseDown(Control c, Point pt, MouseButtons button)
	{
		if (button == MouseButtons.Left)
		{
			_captured = true;
			UpdateTargetState();
		}
		return _captured;
	}

	public virtual void MouseUp(Control c, Point pt, MouseButtons button)
	{
		if (_captured)
		{
			_captured = false;
			UpdateTargetState();
		}
	}

	public virtual void MouseLeave(Control c, ViewBase next)
	{
		_mouseOver = false;
		_lastMovePt = Point.Empty;
		UpdateTargetState();
	}

	public virtual void DoubleClick(Point pt)
	{
	}

	private void UpdateTargetState()
	{
		PaletteState paletteState = PaletteState.Normal;
		if (_mouseOver)
		{
			paletteState = ((!_captured) ? PaletteState.Tracking : PaletteState.Pressed);
		}
		if (_drawTB.ViewDrawTrackPosition.ElementState != paletteState)
		{
			_drawTB.ViewDrawTrackPosition.ElementState = paletteState;
			_drawTB.ViewDrawTrackBar.PerformNeedPaint(needLayout: true);
		}
	}
}
