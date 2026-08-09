#define DEBUG
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class CollapsedGroupController : GlobalId, IMouseController, ISourceController, IKeyController, IRibbonKeyTipTarget
{
	private KryptonRibbon _ribbon;

	private bool _hasFocus;

	private bool _mouseOver;

	private NeedPaintHandler _needPaint;

	private ViewLayoutDocker _target;

	public bool HasFocus => _hasFocus;

	public virtual bool IgnoreVisualFormLeftButtonDown => false;

	public event MouseEventHandler Click;

	public CollapsedGroupController(KryptonRibbon ribbon, ViewLayoutDocker target, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(target != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_target = target;
		_needPaint = needPaint;
	}

	public virtual void MouseEnter(Control c)
	{
		_mouseOver = true;
	}

	public virtual void MouseMove(Control c, Point pt)
	{
	}

	public virtual bool MouseDown(Control c, Point pt, MouseButtons button)
	{
		if (_mouseOver && button == MouseButtons.Left)
		{
			OnClick(new MouseEventArgs(button, 1, pt.X, pt.Y, 0));
		}
		return false;
	}

	public virtual void MouseUp(Control c, Point pt, MouseButtons button)
	{
	}

	public virtual void MouseLeave(Control c, ViewBase next)
	{
		_mouseOver = false;
	}

	public virtual void DoubleClick(Point pt)
	{
	}

	public virtual void KeyDown(Control c, KeyEventArgs e)
	{
		c = _ribbon.GetControllerControl(c);
		if (c is KryptonRibbon)
		{
			KeyDownRibbon(c as KryptonRibbon, e);
		}
		else if (c is VisualPopupGroup)
		{
			KeyDownPopupGroup(c as VisualPopupGroup, e);
		}
		else if (c is VisualPopupMinimized)
		{
			KeyDownPopupMinimized(c as VisualPopupMinimized, e);
		}
	}

	public virtual void KeyPress(Control c, KeyPressEventArgs e)
	{
	}

	public virtual bool KeyUp(Control c, KeyEventArgs e)
	{
		return false;
	}

	public virtual void GotFocus(Control c)
	{
		_hasFocus = true;
		OnNeedPaint(needLayout: false, _target.ClientRectangle);
	}

	public virtual void LostFocus(Control c)
	{
		_hasFocus = false;
		OnNeedPaint(needLayout: false, _target.ClientRectangle);
	}

	public void KeyTipSelect(KryptonRibbon ribbon)
	{
		OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
		if (VisualPopupManager.Singleton.IsTracking && VisualPopupManager.Singleton.CurrentPopup is VisualPopupGroup)
		{
			VisualPopupGroup visualPopupGroup = (VisualPopupGroup)VisualPopupManager.Singleton.CurrentPopup;
			_ribbon.KeyTipMode = KeyTipMode.PopupGroup;
			KeyTipInfoList keyTipList = new KeyTipInfoList();
			visualPopupGroup.ViewGroup.GetGroupKeyTips(keyTipList);
			_ribbon.SetKeyTips(keyTipList, KeyTipMode.PopupGroup);
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

	private void KeyDownRibbon(KryptonRibbon ribbon, KeyEventArgs e)
	{
		ViewBase viewBase = null;
		switch (e.KeyData)
		{
		case Keys.Left:
		case Keys.Tab | Keys.Shift:
			viewBase = ribbon.GroupsArea.ViewGroups.GetPreviousFocusItem(_target);
			if (viewBase == null)
			{
				viewBase = ribbon.TabsArea.LayoutTabs.GetViewForRibbonTab(ribbon.SelectedTab);
			}
			break;
		case Keys.Tab:
		case Keys.Right:
			viewBase = ribbon.GroupsArea.ViewGroups.GetNextFocusItem(_target);
			if (viewBase == null)
			{
				viewBase = ribbon.TabsArea.ButtonSpecManager.GetFirstVisibleViewButton(PaletteRelativeEdgeAlign.Far);
			}
			if (viewBase == null)
			{
				viewBase = ribbon.TabsArea.ButtonSpecManager.GetFirstVisibleViewButton(PaletteRelativeEdgeAlign.Inherit);
			}
			if (viewBase == null)
			{
				if (ribbon.TabsArea.LayoutAppButton.Visible)
				{
					viewBase = ribbon.TabsArea.LayoutAppButton.AppButton;
				}
				else if (ribbon.TabsArea.LayoutAppTab.Visible)
				{
					viewBase = ribbon.TabsArea.LayoutAppTab.AppTab;
				}
			}
			break;
		case Keys.Return:
		case Keys.Space:
			OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
			if (VisualPopupManager.Singleton.CurrentPopup != null && VisualPopupManager.Singleton.CurrentPopup is VisualPopupGroup)
			{
				VisualPopupGroup visualPopupGroup = (VisualPopupGroup)VisualPopupManager.Singleton.CurrentPopup;
				visualPopupGroup.SetFirstFocusItem();
			}
			break;
		}
		if (viewBase != null && viewBase != _target)
		{
			if (viewBase is ViewDrawRibbonTab && !ribbon.RealMinimizedMode)
			{
				ribbon.SelectedTab = ((ViewDrawRibbonTab)viewBase).RibbonTab;
			}
			ribbon.FocusView = viewBase;
		}
	}

	private void KeyDownPopupGroup(VisualPopupGroup popupGroup, KeyEventArgs e)
	{
		switch (e.KeyData)
		{
		case Keys.Left:
		case Keys.Tab | Keys.Shift:
			popupGroup.SetPreviousFocusItem();
			break;
		case Keys.Tab:
		case Keys.Right:
			popupGroup.SetNextFocusItem();
			break;
		case Keys.Return:
		case Keys.Space:
			OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
			if (VisualPopupManager.Singleton.CurrentPopup != null && VisualPopupManager.Singleton.CurrentPopup is VisualPopupGroup)
			{
				VisualPopupGroup visualPopupGroup = (VisualPopupGroup)VisualPopupManager.Singleton.CurrentPopup;
				visualPopupGroup.SetFirstFocusItem();
			}
			break;
		}
	}

	private void KeyDownPopupMinimized(VisualPopupMinimized popupMinimized, KeyEventArgs e)
	{
		switch (e.KeyData)
		{
		case Keys.Left:
		case Keys.Tab | Keys.Shift:
			popupMinimized.SetPreviousFocusItem();
			break;
		case Keys.Tab:
		case Keys.Right:
			popupMinimized.SetNextFocusItem();
			break;
		case Keys.Return:
		case Keys.Space:
			OnClick(new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
			if (VisualPopupManager.Singleton.CurrentPopup != null && VisualPopupManager.Singleton.CurrentPopup is VisualPopupGroup)
			{
				VisualPopupGroup visualPopupGroup = (VisualPopupGroup)VisualPopupManager.Singleton.CurrentPopup;
				visualPopupGroup.SetFirstFocusItem();
			}
			break;
		}
	}
}
