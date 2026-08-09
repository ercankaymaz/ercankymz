#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupCustomControl : ViewComposite, IRibbonViewGroupItemView
{
	private static readonly int NULL_CONTROL_WIDTH = 50;

	private KryptonRibbon _ribbon;

	private KryptonRibbonGroupCustomControl _ribbonCustomControl;

	private ViewDrawRibbonGroup _activeGroup;

	private CustomControlController _controller;

	private NeedPaintHandler _needPaint;

	private GroupItemSize _currentSize;

	public KryptonRibbonGroupCustomControl GroupCustomControl => _ribbonCustomControl;

	private Control LastParentControl
	{
		get
		{
			return _ribbonCustomControl.LastParentControl;
		}
		set
		{
			_ribbonCustomControl.LastParentControl = value;
		}
	}

	private Control LastCustomControl
	{
		get
		{
			return _ribbonCustomControl.LastCustomControl;
		}
		set
		{
			_ribbonCustomControl.LastCustomControl = value;
		}
	}

	public ViewDrawRibbonGroupCustomControl(KryptonRibbon ribbon, KryptonRibbonGroupCustomControl ribbonCustom, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(ribbonCustom != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_ribbonCustomControl = ribbonCustom;
		_needPaint = needPaint;
		_currentSize = _ribbonCustomControl.ItemSizeCurrent;
		_ribbonCustomControl.MouseEnterControl += OnMouseEnterControl;
		_ribbonCustomControl.MouseLeaveControl += OnMouseLeaveControl;
		Component = _ribbonCustomControl;
		if (_ribbon.InDesignMode)
		{
			ContextClickController contextClickController = new ContextClickController();
			contextClickController.ContextClick += OnContextClick;
			MouseController = contextClickController;
		}
		_controller = new CustomControlController(_ribbon, _ribbonCustomControl, this);
		SourceController = _controller;
		KeyController = _controller;
		_ribbon.ViewRibbonManager.LayoutBefore += OnLayoutAction;
		_ribbon.ViewRibbonManager.LayoutAfter += OnLayoutAction;
		_ribbonCustomControl.CustomControlView = this;
		_ribbonCustomControl.ViewPaintDelegate = needPaint;
		_ribbonCustomControl.PropertyChanged += OnCustomPropertyChanged;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupCustom:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _ribbonCustomControl != null)
		{
			_ribbonCustomControl.MouseEnterControl -= OnMouseEnterControl;
			_ribbonCustomControl.MouseLeaveControl -= OnMouseLeaveControl;
			_ribbonCustomControl.ViewPaintDelegate = null;
			_ribbonCustomControl.PropertyChanged -= OnCustomPropertyChanged;
			_ribbon.ViewRibbonManager.LayoutAfter -= OnLayoutAction;
			_ribbon.ViewRibbonManager.LayoutBefore -= OnLayoutAction;
			_ribbonCustomControl.CustomControlView = null;
			_ribbonCustomControl = null;
		}
		base.Dispose(disposing);
	}

	public override void LostFocus(Control c)
	{
		_ribbon.HideFocus(_ribbonCustomControl.CustomControl);
		base.LostFocus(c);
	}

	public ViewBase GetFirstFocusItem()
	{
		if (_ribbonCustomControl.Visible && _ribbonCustomControl.LastCustomControl != null && _ribbonCustomControl.LastCustomControl.CanSelect)
		{
			return this;
		}
		return null;
	}

	public ViewBase GetLastFocusItem()
	{
		if (_ribbonCustomControl.Visible && _ribbonCustomControl.LastCustomControl != null && _ribbonCustomControl.LastCustomControl.CanSelect)
		{
			return this;
		}
		return null;
	}

	public ViewBase GetNextFocusItem(ViewBase current, ref bool matched)
	{
		matched = current == this;
		return null;
	}

	public ViewBase GetPreviousFocusItem(ViewBase current, ref bool matched)
	{
		matched = current == this;
		return null;
	}

	public void GetGroupKeyTips(KeyTipInfoList keyTipList, int lineHint)
	{
		if (Visible && LastCustomControl != null && LastCustomControl.CanFocus)
		{
			Rectangle viewRect = _ribbon.KeyTipToScreen(this);
			Point screenPt = Point.Empty;
			switch (_currentSize)
			{
			case GroupItemSize.Large:
				screenPt = new Point(viewRect.Left + viewRect.Width / 2, viewRect.Bottom);
				break;
			case GroupItemSize.Small:
			case GroupItemSize.Medium:
				screenPt = _ribbon.CalculatedValues.KeyTipRectToPoint(viewRect, lineHint);
				break;
			}
			keyTipList.Add(new KeyTipInfo(_ribbonCustomControl.Enabled, _ribbonCustomControl.KeyTip, screenPt, ClientRectangle, _controller));
		}
	}

	public void SetGroupItemSize(GroupItemSize size)
	{
		_currentSize = size;
	}

	public void ResetGroupItemSize()
	{
		_currentSize = _ribbonCustomControl.ItemSizeCurrent;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Size result = Size.Empty;
		UpdateParent(context.Control);
		if (LastCustomControl != null)
		{
			if (ActualVisible(LastCustomControl))
			{
				result = LastCustomControl.GetPreferredSize(context.DisplayRectangle.Size);
				result.Width += 2;
			}
		}
		else
		{
			result.Width = NULL_CONTROL_WIDTH;
		}
		if (_currentSize == GroupItemSize.Large)
		{
			result.Height = _ribbon.CalculatedValues.GroupTripleHeight;
		}
		else
		{
			result.Height = _ribbon.CalculatedValues.GroupLineHeight;
		}
		return result;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		if (!context.ViewManager.DoNotLayoutControls && LastCustomControl != null)
		{
			LastCustomControl.SetBounds(ClientLocation.X + 1, ClientLocation.Y + 1, ClientWidth - 2, ClientHeight - 2);
		}
		base.Layout(context);
	}

	public override void Render(RenderContext context)
	{
		Debug.Assert(context != null);
		if (_ribbonCustomControl.CustomControl == null && _ribbon.InDesignMode)
		{
			Rectangle clientRectangle = ClientRectangle;
			clientRectangle.Inflate(-1, -1);
			clientRectangle.Height--;
			context.Graphics.FillRectangle(Brushes.Salmon, clientRectangle);
			context.Graphics.DrawRectangle(Pens.Red, clientRectangle);
		}
	}

	protected virtual void OnNeedPaint(bool needLayout)
	{
		OnNeedPaint(needLayout, Rectangle.Empty);
	}

	protected virtual void OnNeedPaint(bool needLayout, Rectangle invalidRect)
	{
		if (_needPaint != null)
		{
			_needPaint(this, new NeedLayoutEventArgs(needLayout));
			if (needLayout)
			{
				_ribbon.PerformLayout();
			}
		}
	}

	private void OnContextClick(object sender, MouseEventArgs e)
	{
		_ribbonCustomControl.OnDesignTimeContextMenu(e);
	}

	private void OnCustomPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		bool flag = false;
		bool flag2 = false;
		switch (e.PropertyName)
		{
		case "Enabled":
			UpdateEnabled(LastCustomControl);
			break;
		case "Visible":
			UpdateVisible(LastCustomControl);
			flag = true;
			break;
		case "CustomControl":
			flag = true;
			break;
		}
		if (flag && _ribbonCustomControl.RibbonTab != null && _ribbon.SelectedTab == _ribbonCustomControl.RibbonTab)
		{
			OnNeedPaint(needLayout: true);
		}
		if (flag2 && (_ribbonCustomControl.Visible || _ribbon.InDesignMode) && _ribbonCustomControl.RibbonTab != null && _ribbon.SelectedTab == _ribbonCustomControl.RibbonTab)
		{
			OnNeedPaint(needLayout: false, ClientRectangle);
		}
	}

	private void UpdateParent(Control parentControl)
	{
		if ((parentControl != LastParentControl || LastCustomControl != _ribbonCustomControl.CustomControl) && ((_ribbonCustomControl.RibbonContainer.RibbonGroup.ShowingAsPopup && parentControl is VisualPopupGroup) || (!_ribbonCustomControl.RibbonContainer.RibbonGroup.ShowingAsPopup && !(parentControl is VisualPopupGroup))))
		{
			if (LastCustomControl != null && LastParentControl != null && LastParentControl.Controls.Contains(LastCustomControl))
			{
				LastParentControl.Controls.Remove(LastCustomControl);
			}
			LastCustomControl = _ribbonCustomControl.CustomControl;
			LastParentControl = parentControl;
			if (LastCustomControl != null && LastParentControl != null)
			{
				LastCustomControl.Location = new Point(-LastCustomControl.Width, -LastCustomControl.Height);
				UpdateVisible(LastCustomControl);
				UpdateEnabled(LastCustomControl);
				LastParentControl.Controls.Add(LastCustomControl);
			}
		}
	}

	private void UpdateEnabled(Control c)
	{
		if (c != null)
		{
			bool enabled = _ribbonCustomControl.Enabled;
			if (!_ribbon.InDesignHelperMode && _ribbonCustomControl.CustomControlDesigner != null)
			{
				enabled = _ribbonCustomControl.CustomControlDesigner.DesignEnabled;
			}
			c.Enabled = enabled;
		}
	}

	private bool ActualVisible(Control c)
	{
		if (c != null)
		{
			bool result = _ribbonCustomControl.Visible;
			if (!_ribbon.InDesignHelperMode && _ribbonCustomControl.CustomControlDesigner != null)
			{
				result = _ribbonCustomControl.CustomControlDesigner.DesignVisible;
			}
			return result;
		}
		return false;
	}

	private void UpdateVisible(Control c)
	{
		if (c == null)
		{
			return;
		}
		bool flag = _ribbonCustomControl.Visible;
		if (!_ribbon.InDesignHelperMode && _ribbonCustomControl.CustomControlDesigner != null)
		{
			flag = _ribbonCustomControl.CustomControlDesigner.DesignVisible;
		}
		if (flag)
		{
			if (_ribbonCustomControl.RibbonTab == null || _ribbon.SelectedTab != _ribbonCustomControl.RibbonTab)
			{
				flag = false;
			}
			else if (_ribbonCustomControl.RibbonContainer != null && _ribbonCustomControl.RibbonContainer.RibbonGroup != null && !_ribbonCustomControl.RibbonContainer.RibbonGroup.Visible && !_ribbon.InDesignMode)
			{
				flag = false;
			}
			else if (_ribbonCustomControl.RibbonContainer.RibbonGroup.IsCollapsed && (_ribbon.GetControllerControl(_ribbonCustomControl.LastCustomControl) is KryptonRibbon || _ribbon.GetControllerControl(_ribbonCustomControl.LastCustomControl) is VisualPopupMinimized))
			{
				flag = false;
			}
			else
			{
				for (KryptonRibbonGroupContainer ribbonContainer = _ribbonCustomControl.RibbonContainer; ribbonContainer != null; ribbonContainer = ribbonContainer.RibbonContainer)
				{
					if (!ribbonContainer.Visible)
					{
						flag = false;
						break;
					}
				}
			}
		}
		c.Visible = flag;
	}

	private void OnLayoutAction(object sender, EventArgs e)
	{
		if (_ribbonCustomControl != null)
		{
			UpdateVisible(LastCustomControl);
			UpdateEnabled(LastCustomControl);
		}
	}

	private void OnMouseEnterControl(object sender, EventArgs e)
	{
		_activeGroup = null;
		for (ViewBase parent = base.Parent; parent != null; parent = parent.Parent)
		{
			if (parent is ViewDrawRibbonGroup)
			{
				_activeGroup = (ViewDrawRibbonGroup)parent;
				break;
			}
		}
		if (_activeGroup != null)
		{
			_activeGroup.Tracking = true;
			_needPaint(this, new NeedLayoutEventArgs(needLayout: false, _activeGroup.ClientRectangle));
		}
	}

	private void OnMouseLeaveControl(object sender, EventArgs e)
	{
		if (_activeGroup != null)
		{
			_activeGroup.Tracking = false;
			_needPaint(this, new NeedLayoutEventArgs(needLayout: false, _activeGroup.ClientRectangle));
			_activeGroup = null;
		}
	}
}
