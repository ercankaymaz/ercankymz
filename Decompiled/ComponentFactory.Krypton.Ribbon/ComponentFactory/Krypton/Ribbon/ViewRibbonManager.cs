#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewRibbonManager : ViewManager
{
	private KryptonRibbon _ribbon;

	private ViewDrawRibbonGroupsBorderSynch _viewGroups;

	private ViewDrawRibbonGroup _activeGroup;

	private NeedPaintHandler _needPaintDelegate;

	private bool _minimizedMode;

	private bool _active;

	private bool _layingOut;

	public ViewRibbonManager(KryptonRibbon control, ViewDrawRibbonGroupsBorderSynch viewGroups, ViewBase root, bool minimizedMode, NeedPaintHandler needPaintDelegate)
		: base(control, root)
	{
		Debug.Assert(viewGroups != null);
		Debug.Assert(root != null);
		Debug.Assert(needPaintDelegate != null);
		_ribbon = control;
		_viewGroups = viewGroups;
		_needPaintDelegate = needPaintDelegate;
		_active = true;
		_minimizedMode = minimizedMode;
	}

	public void Active()
	{
		_active = true;
	}

	public void Inactive()
	{
		if (_active)
		{
			MouseLeave(EventArgs.Empty);
			_active = false;
		}
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
			Form form = _ribbon.FindForm();
			if (form != null && (form == null || form.WindowState != FormWindowState.Minimized))
			{
				_layingOut = true;
				_ribbon.CalculatedValues.Recalculate();
				base.Layout(context);
				_layingOut = false;
			}
		}
	}

	public override void MouseMove(MouseEventArgs e, Point rawPt)
	{
		Debug.Assert(e != null);
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		if (!_ribbon.InDesignMode && (_active || CommonHelper.ActiveFloatingWindow != null) && _minimizedMode == _ribbon.RealMinimizedMode)
		{
			ViewDrawRibbonGroup viewDrawRibbonGroup = _viewGroups.ViewGroupFromPoint(new Point(e.X, e.Y));
			if (viewDrawRibbonGroup != _activeGroup)
			{
				if (_activeGroup != null)
				{
					_activeGroup.Tracking = false;
					_activeGroup.PerformNeedPaint(needLayout: false, _activeGroup.ClientRectangle);
				}
				_activeGroup = viewDrawRibbonGroup;
				if (_activeGroup != null)
				{
					_activeGroup.Tracking = true;
					_activeGroup.PerformNeedPaint(needLayout: false, _activeGroup.ClientRectangle);
				}
			}
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
		if (!_ribbon.InDesignMode && (_active || CommonHelper.ActiveFloatingWindow != null) && _activeGroup != null)
		{
			_activeGroup.PerformNeedPaint(needLayout: false, _activeGroup.ClientRectangle);
			_activeGroup.Tracking = false;
			_activeGroup = null;
		}
		base.MouseLeave(e);
	}

	protected override void UpdateViewFromPoint(Control control, Point pt)
	{
		if (!_active && CommonHelper.ActiveFloatingWindow == null)
		{
			if (!base.MouseCaptured)
			{
				ViewBase viewBase = base.Root.ViewFromPoint(pt);
				if (viewBase is ViewDrawRibbonAppButton)
				{
					base.ActiveView = viewBase;
				}
				else
				{
					base.ActiveView = null;
				}
			}
		}
		else
		{
			base.UpdateViewFromPoint(control, pt);
		}
	}

	private void PerformNeedPaint(bool needLayout)
	{
		PerformNeedPaint(needLayout, Rectangle.Empty);
	}

	private void PerformNeedPaint(bool needLayout, Rectangle invalidRect)
	{
		if (_needPaintDelegate != null)
		{
			_needPaintDelegate(this, new NeedLayoutEventArgs(needLayout, invalidRect));
		}
	}
}
