#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupDomainUpDown : ViewComposite, IRibbonViewGroupItemView
{
	private static readonly int NULL_CONTROL_WIDTH = 50;

	private KryptonRibbon _ribbon;

	private KryptonRibbonGroupDomainUpDown _ribbonDomainUpDown;

	private ViewDrawRibbonGroup _activeGroup;

	private DomainUpDownController _controller;

	private NeedPaintHandler _needPaint;

	private GroupItemSize _currentSize;

	public KryptonRibbonGroupDomainUpDown GroupDomainUpDown => _ribbonDomainUpDown;

	private Control LastParentControl
	{
		get
		{
			return _ribbonDomainUpDown.LastParentControl;
		}
		set
		{
			_ribbonDomainUpDown.LastParentControl = value;
		}
	}

	private KryptonDomainUpDown LastDomainUpDown
	{
		get
		{
			return _ribbonDomainUpDown.LastDomainUpDown;
		}
		set
		{
			_ribbonDomainUpDown.LastDomainUpDown = value;
		}
	}

	public ViewDrawRibbonGroupDomainUpDown(KryptonRibbon ribbon, KryptonRibbonGroupDomainUpDown ribbonDomainUpDown, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(ribbonDomainUpDown != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_ribbonDomainUpDown = ribbonDomainUpDown;
		_needPaint = needPaint;
		_currentSize = _ribbonDomainUpDown.ItemSizeCurrent;
		_ribbonDomainUpDown.MouseEnterControl += OnMouseEnterControl;
		_ribbonDomainUpDown.MouseLeaveControl += OnMouseLeaveControl;
		Component = _ribbonDomainUpDown;
		if (_ribbon.InDesignMode)
		{
			ContextClickController contextClickController = new ContextClickController();
			contextClickController.ContextClick += OnContextClick;
			MouseController = contextClickController;
		}
		_controller = new DomainUpDownController(_ribbon, _ribbonDomainUpDown, this);
		SourceController = _controller;
		KeyController = _controller;
		_ribbon.ViewRibbonManager.LayoutBefore += OnLayoutAction;
		_ribbon.ViewRibbonManager.LayoutAfter += OnLayoutAction;
		_ribbonDomainUpDown.DomainUpDownView = this;
		_ribbonDomainUpDown.ViewPaintDelegate = needPaint;
		_ribbonDomainUpDown.PropertyChanged += OnDomainUpDownPropertyChanged;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupDomainUpDown:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _ribbonDomainUpDown != null)
		{
			_ribbonDomainUpDown.MouseEnterControl -= OnMouseEnterControl;
			_ribbonDomainUpDown.MouseLeaveControl -= OnMouseLeaveControl;
			_ribbonDomainUpDown.ViewPaintDelegate = null;
			_ribbonDomainUpDown.PropertyChanged -= OnDomainUpDownPropertyChanged;
			_ribbon.ViewRibbonManager.LayoutAfter -= OnLayoutAction;
			_ribbon.ViewRibbonManager.LayoutBefore -= OnLayoutAction;
			_ribbonDomainUpDown.DomainUpDownView = null;
			_ribbonDomainUpDown = null;
		}
		base.Dispose(disposing);
	}

	public override void LostFocus(Control c)
	{
		_ribbon.HideFocus(_ribbonDomainUpDown.DomainUpDown);
		base.LostFocus(c);
	}

	public ViewBase GetFirstFocusItem()
	{
		if (_ribbonDomainUpDown.Visible && _ribbonDomainUpDown.LastDomainUpDown != null && _ribbonDomainUpDown.LastDomainUpDown.DomainUpDown != null && _ribbonDomainUpDown.LastDomainUpDown.DomainUpDown.CanSelect)
		{
			return this;
		}
		return null;
	}

	public ViewBase GetLastFocusItem()
	{
		if (_ribbonDomainUpDown.Visible && _ribbonDomainUpDown.LastDomainUpDown != null && _ribbonDomainUpDown.LastDomainUpDown.DomainUpDown != null && _ribbonDomainUpDown.LastDomainUpDown.DomainUpDown.CanSelect)
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
		if (Visible && LastDomainUpDown.CanFocus)
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
			keyTipList.Add(new KeyTipInfo(_ribbonDomainUpDown.Enabled, _ribbonDomainUpDown.KeyTip, screenPt, ClientRectangle, _controller));
		}
	}

	public void SetGroupItemSize(GroupItemSize size)
	{
		_currentSize = size;
	}

	public void ResetGroupItemSize()
	{
		_currentSize = _ribbonDomainUpDown.ItemSizeCurrent;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Size result = Size.Empty;
		UpdateParent(context.Control);
		if (LastDomainUpDown != null)
		{
			if (ActualVisible(LastDomainUpDown))
			{
				result = LastDomainUpDown.GetPreferredSize(context.DisplayRectangle.Size);
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
		if (!context.ViewManager.DoNotLayoutControls && LastDomainUpDown != null)
		{
			LastDomainUpDown.SetBounds(ClientLocation.X + 1, ClientLocation.Y + 1, ClientWidth - 2, ClientHeight - 2);
		}
		base.Layout(context);
	}

	public override void Render(RenderContext context)
	{
		Debug.Assert(context != null);
		if (_ribbonDomainUpDown.DomainUpDown == null && _ribbon.InDesignMode)
		{
			Rectangle clientRectangle = ClientRectangle;
			clientRectangle.Inflate(-1, -1);
			clientRectangle.Height--;
			context.Graphics.FillRectangle(Brushes.Goldenrod, clientRectangle);
			context.Graphics.DrawRectangle(Pens.Gold, clientRectangle);
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
		_ribbonDomainUpDown.OnDesignTimeContextMenu(e);
	}

	private void OnDomainUpDownPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		bool flag = false;
		bool flag2 = false;
		switch (e.PropertyName)
		{
		case "Enabled":
			UpdateEnabled(LastDomainUpDown);
			break;
		case "Visible":
			UpdateVisible(LastDomainUpDown);
			flag = true;
			break;
		case "CustomControl":
			flag = true;
			break;
		}
		if (flag && _ribbonDomainUpDown.RibbonTab != null && _ribbon.SelectedTab == _ribbonDomainUpDown.RibbonTab)
		{
			OnNeedPaint(needLayout: true);
		}
		if (flag2 && (_ribbonDomainUpDown.Visible || _ribbon.InDesignMode) && _ribbonDomainUpDown.RibbonTab != null && _ribbon.SelectedTab == _ribbonDomainUpDown.RibbonTab)
		{
			OnNeedPaint(needLayout: false, ClientRectangle);
		}
	}

	private void UpdateParent(Control parentControl)
	{
		if ((parentControl != LastParentControl || LastDomainUpDown != _ribbonDomainUpDown.DomainUpDown) && ((_ribbonDomainUpDown.RibbonContainer.RibbonGroup.ShowingAsPopup && parentControl is VisualPopupGroup) || (!_ribbonDomainUpDown.RibbonContainer.RibbonGroup.ShowingAsPopup && !(parentControl is VisualPopupGroup))))
		{
			if (LastDomainUpDown != null && LastParentControl != null && LastParentControl.Controls.Contains(LastDomainUpDown))
			{
				LastParentControl.Controls.Remove(LastDomainUpDown);
			}
			LastDomainUpDown = _ribbonDomainUpDown.DomainUpDown;
			LastParentControl = parentControl;
			if (LastDomainUpDown != null && LastParentControl != null)
			{
				LastDomainUpDown.Location = new Point(-LastDomainUpDown.Width, -LastDomainUpDown.Height);
				UpdateVisible(LastDomainUpDown);
				LastParentControl.Controls.Add(LastDomainUpDown);
			}
		}
	}

	private void UpdateEnabled(Control c)
	{
		if (c != null)
		{
			bool enabled = _ribbonDomainUpDown.Enabled;
			if (!_ribbon.InDesignHelperMode && _ribbonDomainUpDown.DomainUpDownDesigner != null)
			{
				enabled = _ribbonDomainUpDown.DomainUpDownDesigner.DesignEnabled;
			}
			c.Enabled = enabled;
		}
	}

	private bool ActualVisible(Control c)
	{
		if (c != null)
		{
			bool result = _ribbonDomainUpDown.Visible;
			if (!_ribbon.InDesignHelperMode && _ribbonDomainUpDown.DomainUpDownDesigner != null)
			{
				result = _ribbonDomainUpDown.DomainUpDownDesigner.DesignVisible;
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
		bool flag = _ribbonDomainUpDown.Visible;
		if (!_ribbon.InDesignHelperMode && _ribbonDomainUpDown.DomainUpDownDesigner != null)
		{
			flag = _ribbonDomainUpDown.DomainUpDownDesigner.DesignVisible;
		}
		if (flag)
		{
			if (_ribbonDomainUpDown.RibbonTab == null || _ribbon.SelectedTab != _ribbonDomainUpDown.RibbonTab)
			{
				flag = false;
			}
			else if (_ribbonDomainUpDown.RibbonContainer != null && _ribbonDomainUpDown.RibbonContainer.RibbonGroup != null && !_ribbonDomainUpDown.RibbonContainer.RibbonGroup.Visible && !_ribbon.InDesignMode)
			{
				flag = false;
			}
			else if (_ribbonDomainUpDown.RibbonContainer.RibbonGroup.IsCollapsed && (_ribbon.GetControllerControl(_ribbonDomainUpDown.DomainUpDown) is KryptonRibbon || _ribbon.GetControllerControl(_ribbonDomainUpDown.DomainUpDown) is VisualPopupMinimized))
			{
				flag = false;
			}
			else
			{
				for (KryptonRibbonGroupContainer ribbonContainer = _ribbonDomainUpDown.RibbonContainer; ribbonContainer != null; ribbonContainer = ribbonContainer.RibbonContainer)
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
		if (_ribbonDomainUpDown != null)
		{
			UpdateVisible(LastDomainUpDown);
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
