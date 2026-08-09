#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewRibbonPopupGroupManager : ViewManager
{
	private KryptonRibbon _ribbon;

	private ViewDrawRibbonGroup _viewGroup;

	private NeedPaintHandler _needPaintDelegate;

	private ViewBase _focusView;

	private bool _layingOut;

	public ViewBase FocusView
	{
		get
		{
			return _focusView;
		}
		set
		{
			if (_focusView != value)
			{
				if (_focusView != null)
				{
					_focusView.LostFocus(base.Root.OwningControl);
				}
				_focusView = value;
				if (_focusView != null)
				{
					_focusView.GotFocus(base.Root.OwningControl);
				}
			}
		}
	}

	public ViewRibbonPopupGroupManager(Control control, KryptonRibbon ribbon, ViewBase root, ViewDrawRibbonGroup viewGroup, NeedPaintHandler needPaintDelegate)
		: base(control, root)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(viewGroup != null);
		Debug.Assert(needPaintDelegate != null);
		_ribbon = ribbon;
		_viewGroup = viewGroup;
		_needPaintDelegate = needPaintDelegate;
	}

	public override void Dispose()
	{
		FocusView = null;
		base.Dispose();
	}

	public override Size GetPreferredSize(IRenderer renderer, Size proposedSize)
	{
		_ribbon.CalculatedValues.Recalculate();
		return base.GetPreferredSize(renderer, proposedSize);
	}

	public override void Layout(ViewLayoutContext context)
	{
		if (!_layingOut)
		{
			_layingOut = true;
			_ribbon.CalculatedValues.Recalculate();
			base.Layout(context);
			_layingOut = false;
		}
	}

	public override void MouseMove(MouseEventArgs e, Point rawPt)
	{
		Debug.Assert(e != null);
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		bool flag = _viewGroup.ClientRectangle.Contains(new Point(e.X, e.Y));
		if (flag != _viewGroup.Tracking)
		{
			_viewGroup.Tracking = flag;
			_viewGroup.PerformNeedPaint(needLayout: false, _viewGroup.ClientRectangle);
		}
		base.MouseMove(e, rawPt);
	}

	public override void MouseLeave(EventArgs e)
	{
		Debug.Assert(e != null);
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		if (_viewGroup.Tracking)
		{
			_viewGroup.Tracking = false;
			_viewGroup.PerformNeedPaint(needLayout: false, _viewGroup.ClientRectangle);
		}
		base.MouseLeave(e);
	}

	public override void KeyDown(KeyEventArgs e)
	{
		if (FocusView != null)
		{
			FocusView.KeyDown(e);
		}
	}

	public override void KeyPress(KeyPressEventArgs e)
	{
		if (FocusView != null)
		{
			FocusView.KeyPress(e);
		}
	}

	public override void KeyUp(KeyEventArgs e)
	{
		if (FocusView != null)
		{
			base.MouseCaptured = FocusView.KeyUp(e);
		}
	}

	private void PerformNeedPaint(bool needLayout, Rectangle invalidRect)
	{
		if (_needPaintDelegate != null)
		{
			_needPaintDelegate(this, new NeedLayoutEventArgs(needLayout, invalidRect));
		}
	}
}
