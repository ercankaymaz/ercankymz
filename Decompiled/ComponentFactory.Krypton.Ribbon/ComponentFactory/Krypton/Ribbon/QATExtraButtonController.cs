using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class QATExtraButtonController : LeftDownButtonController, ISourceController, IKeyController, IRibbonKeyTipTarget
{
	private bool _hasFocus;

	public override bool IgnoreVisualFormLeftButtonDown => true;

	public QATExtraButtonController(KryptonRibbon ribbon, ViewBase target, NeedPaintHandler needPaint)
		: base(ribbon, target, needPaint)
	{
	}

	public override bool MouseDown(Control c, Point pt, MouseButtons button)
	{
		base.MouseDown(c, pt, button);
		return false;
	}

	public virtual void GotFocus(Control c)
	{
		_hasFocus = true;
		UpdateTargetState();
		OnNeedPaint(needLayout: false, base.Target.ClientRectangle);
	}

	public virtual void LostFocus(Control c)
	{
		_hasFocus = false;
		UpdateTargetState();
		OnNeedPaint(needLayout: false, base.Target.ClientRectangle);
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
		SetFixed();
		UpdateTargetState();
		OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
		if (VisualPopupManager.Singleton.IsTracking && VisualPopupManager.Singleton.CurrentPopup is VisualPopupQATOverflow)
		{
			VisualPopupQATOverflow visualPopupQATOverflow = (VisualPopupQATOverflow)VisualPopupManager.Singleton.CurrentPopup;
			base.Ribbon.KeyTipMode = KeyTipMode.PopupQATOverflow;
			KeyTipInfoList keyTipInfoList = new KeyTipInfoList();
			keyTipInfoList.AddRange(visualPopupQATOverflow.ViewQATContents.GetQATKeyTips(null));
			base.Ribbon.SetKeyTips(keyTipInfoList, KeyTipMode.PopupQATOverflow);
		}
	}

	protected override void UpdateTargetState()
	{
		if (_hasFocus && !base.IsFixed)
		{
			if (base.Target.ElementState != PaletteState.Tracking)
			{
				base.Target.ElementState = PaletteState.Tracking;
				OnNeedPaint(needLayout: false, base.Target.ClientRectangle);
			}
		}
		else
		{
			base.UpdateTargetState();
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
		case Keys.Down:
			SetFixed();
			UpdateTargetState();
			OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
			if (!VisualPopupManager.Singleton.IsShowingCMS && VisualPopupManager.Singleton.CurrentPopup != null && VisualPopupManager.Singleton.CurrentPopup is VisualPopupQATOverflow)
			{
				VisualPopupQATOverflow visualPopupQATOverflow = (VisualPopupQATOverflow)VisualPopupManager.Singleton.CurrentPopup;
				visualPopupQATOverflow.SetFirstFocusItem();
			}
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
			SetFixed();
			UpdateTargetState();
			OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
			if (!VisualPopupManager.Singleton.IsShowingCMS && VisualPopupManager.Singleton.CurrentPopup != null && VisualPopupManager.Singleton.CurrentPopup is VisualPopupQATOverflow)
			{
				VisualPopupQATOverflow visualPopupQATOverflow = (VisualPopupQATOverflow)VisualPopupManager.Singleton.CurrentPopup;
				visualPopupQATOverflow.SetFirstFocusItem();
			}
			break;
		}
	}
}
