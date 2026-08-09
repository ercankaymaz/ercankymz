using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class QATButtonController : LeftUpButtonController, ISourceController, IKeyController, IRibbonKeyTipTarget
{
	private bool _hasFocus;

	public override bool IgnoreVisualFormLeftButtonDown => true;

	public QATButtonController(KryptonRibbon ribbon, ViewBase target, NeedPaintHandler needPaint)
		: base(ribbon, target, needPaint)
	{
	}

	public override void MouseEnter(Control c)
	{
		base.MouseEnter(c);
	}

	public virtual void GotFocus(Control c)
	{
		_hasFocus = true;
		UpdateTargetState(Point.Empty);
		OnNeedPaint(needLayout: false);
	}

	public virtual void LostFocus(Control c)
	{
		_hasFocus = false;
		UpdateTargetState(Point.Empty);
		OnNeedPaint(needLayout: false);
	}

	public void KeyDown(Control c, KeyEventArgs e)
	{
		if (c is VisualPopupQATOverflow)
		{
			KeyDownPopupOverflow(c as VisualPopupQATOverflow, e);
		}
		else
		{
			KeyDownRibbon(e);
		}
	}

	public void KeyPress(Control c, KeyPressEventArgs e)
	{
	}

	public bool KeyUp(Control c, KeyEventArgs e)
	{
		return false;
	}

	public void KeyTipSelect(KryptonRibbon ribbon)
	{
		ribbon.KillKeyboardMode();
		OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
	}

	protected override void UpdateTargetState(Point pt)
	{
		if (_hasFocus)
		{
			if (base.Target.ElementState != PaletteState.Tracking)
			{
				base.Target.ElementState = PaletteState.Tracking;
				OnNeedPaint(needLayout: false);
			}
		}
		else
		{
			base.UpdateTargetState(pt);
		}
	}

	private void KeyDownRibbon(KeyEventArgs e)
	{
		ViewBase viewBase = null;
		switch (e.KeyData)
		{
		case Keys.Tab:
		case Keys.Right:
			viewBase = base.Ribbon.GetNextQATView(base.Target, e.KeyData == Keys.Tab);
			break;
		case Keys.Left:
		case Keys.Tab | Keys.Shift:
			viewBase = base.Ribbon.GetPreviousQATView(base.Target);
			break;
		case Keys.Return:
		case Keys.Space:
			base.Ribbon.KillKeyboardMode();
			OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
			break;
		}
		if (viewBase != null && viewBase != base.Target)
		{
			if (viewBase is ViewDrawRibbonTab && !base.Ribbon.RealMinimizedMode)
			{
				base.Ribbon.SelectedTab = ((ViewDrawRibbonTab)viewBase).RibbonTab;
			}
			base.Ribbon.FocusView = viewBase;
		}
	}

	private void KeyDownPopupOverflow(VisualPopupQATOverflow c, KeyEventArgs e)
	{
		switch (e.KeyData)
		{
		case Keys.Tab:
		case Keys.Right:
			c.SetNextFocusItem();
			break;
		case Keys.Left:
		case Keys.Tab | Keys.Shift:
			c.SetPreviousFocusItem();
			break;
		case Keys.Return:
		case Keys.Space:
			base.Ribbon.KillKeyboardMode();
			OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
			break;
		}
	}
}
