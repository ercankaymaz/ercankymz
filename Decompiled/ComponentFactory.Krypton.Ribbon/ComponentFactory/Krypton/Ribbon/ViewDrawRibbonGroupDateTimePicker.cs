#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupDateTimePicker : ViewComposite, IRibbonViewGroupItemView
{
	private static readonly int NULL_CONTROL_WIDTH = 50;

	private KryptonRibbon _ribbon;

	private KryptonRibbonGroupDateTimePicker _ribbonDateTimePicker;

	private ViewDrawRibbonGroup _activeGroup;

	private DateTimePickerController _controller;

	private NeedPaintHandler _needPaint;

	private GroupItemSize _currentSize;

	public KryptonRibbonGroupDateTimePicker GroupDateTimePicker => _ribbonDateTimePicker;

	private Control LastParentControl
	{
		get
		{
			return _ribbonDateTimePicker.LastParentControl;
		}
		set
		{
			_ribbonDateTimePicker.LastParentControl = value;
		}
	}

	private KryptonDateTimePicker LastDateTimePicker
	{
		get
		{
			return _ribbonDateTimePicker.LastDateTimePicker;
		}
		set
		{
			_ribbonDateTimePicker.LastDateTimePicker = value;
		}
	}

	public ViewDrawRibbonGroupDateTimePicker(KryptonRibbon ribbon, KryptonRibbonGroupDateTimePicker ribbonDateTimePicker, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(ribbonDateTimePicker != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_ribbonDateTimePicker = ribbonDateTimePicker;
		_needPaint = needPaint;
		_currentSize = _ribbonDateTimePicker.ItemSizeCurrent;
		_ribbonDateTimePicker.MouseEnterControl += OnMouseEnterControl;
		_ribbonDateTimePicker.MouseLeaveControl += OnMouseLeaveControl;
		Component = _ribbonDateTimePicker;
		if (_ribbon.InDesignMode)
		{
			ContextClickController contextClickController = new ContextClickController();
			contextClickController.ContextClick += OnContextClick;
			MouseController = contextClickController;
		}
		_controller = new DateTimePickerController(_ribbon, _ribbonDateTimePicker, this);
		SourceController = _controller;
		KeyController = _controller;
		_ribbon.ViewRibbonManager.LayoutBefore += OnLayoutAction;
		_ribbon.ViewRibbonManager.LayoutAfter += OnLayoutAction;
		_ribbonDateTimePicker.DateTimePickerView = this;
		_ribbonDateTimePicker.ViewPaintDelegate = needPaint;
		_ribbonDateTimePicker.PropertyChanged += OnDateTimePickerPropertyChanged;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupDateTimePicker:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _ribbonDateTimePicker != null)
		{
			_ribbonDateTimePicker.MouseEnterControl -= OnMouseEnterControl;
			_ribbonDateTimePicker.MouseLeaveControl -= OnMouseLeaveControl;
			_ribbonDateTimePicker.ViewPaintDelegate = null;
			_ribbonDateTimePicker.PropertyChanged -= OnDateTimePickerPropertyChanged;
			_ribbon.ViewRibbonManager.LayoutAfter -= OnLayoutAction;
			_ribbon.ViewRibbonManager.LayoutBefore -= OnLayoutAction;
			_ribbonDateTimePicker.DateTimePickerView = null;
			_ribbonDateTimePicker = null;
		}
		base.Dispose(disposing);
	}

	public override void LostFocus(Control c)
	{
		_ribbon.HideFocus(_ribbonDateTimePicker.DateTimePicker);
		base.LostFocus(c);
	}

	public ViewBase GetFirstFocusItem()
	{
		if (_ribbonDateTimePicker.Visible && _ribbonDateTimePicker.LastDateTimePicker != null && _ribbonDateTimePicker.LastDateTimePicker.CanSelect)
		{
			return this;
		}
		return null;
	}

	public ViewBase GetLastFocusItem()
	{
		if (_ribbonDateTimePicker.Visible && _ribbonDateTimePicker.LastDateTimePicker != null && _ribbonDateTimePicker.LastDateTimePicker.CanSelect)
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
		if (Visible && LastDateTimePicker.CanFocus)
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
			keyTipList.Add(new KeyTipInfo(_ribbonDateTimePicker.Enabled, _ribbonDateTimePicker.KeyTip, screenPt, ClientRectangle, _controller));
		}
	}

	public void SetGroupItemSize(GroupItemSize size)
	{
		_currentSize = size;
	}

	public void ResetGroupItemSize()
	{
		_currentSize = _ribbonDateTimePicker.ItemSizeCurrent;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Size result = Size.Empty;
		UpdateParent(context.Control);
		if (LastDateTimePicker != null)
		{
			if (ActualVisible(LastDateTimePicker))
			{
				result = LastDateTimePicker.GetPreferredSize(context.DisplayRectangle.Size);
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
		if (!context.ViewManager.DoNotLayoutControls && LastDateTimePicker != null)
		{
			LastDateTimePicker.SetBounds(ClientLocation.X + 1, ClientLocation.Y + 1, ClientWidth - 2, ClientHeight - 2);
		}
		base.Layout(context);
	}

	public override void Render(RenderContext context)
	{
		Debug.Assert(context != null);
		if (_ribbonDateTimePicker.DateTimePicker == null && _ribbon.InDesignMode)
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
		_ribbonDateTimePicker.OnDesignTimeContextMenu(e);
	}

	private void OnDateTimePickerPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		bool flag = false;
		bool flag2 = false;
		switch (e.PropertyName)
		{
		case "Enabled":
			UpdateEnabled(LastDateTimePicker);
			break;
		case "Visible":
			UpdateVisible(LastDateTimePicker);
			flag = true;
			break;
		case "CustomControl":
			flag = true;
			break;
		}
		if (flag && _ribbonDateTimePicker.RibbonTab != null && _ribbon.SelectedTab == _ribbonDateTimePicker.RibbonTab)
		{
			OnNeedPaint(needLayout: true);
		}
		if (flag2 && (_ribbonDateTimePicker.Visible || _ribbon.InDesignMode) && _ribbonDateTimePicker.RibbonTab != null && _ribbon.SelectedTab == _ribbonDateTimePicker.RibbonTab)
		{
			OnNeedPaint(needLayout: false, ClientRectangle);
		}
	}

	private void UpdateParent(Control parentControl)
	{
		if ((parentControl != LastParentControl || LastDateTimePicker != _ribbonDateTimePicker.DateTimePicker) && ((_ribbonDateTimePicker.RibbonContainer.RibbonGroup.ShowingAsPopup && parentControl is VisualPopupGroup) || (!_ribbonDateTimePicker.RibbonContainer.RibbonGroup.ShowingAsPopup && !(parentControl is VisualPopupGroup))))
		{
			if (LastDateTimePicker != null && LastParentControl != null && LastParentControl.Controls.Contains(LastDateTimePicker))
			{
				LastParentControl.Controls.Remove(LastDateTimePicker);
			}
			LastDateTimePicker = _ribbonDateTimePicker.DateTimePicker;
			LastParentControl = parentControl;
			if (LastDateTimePicker != null && LastParentControl != null)
			{
				LastDateTimePicker.Location = new Point(-LastDateTimePicker.Width, -LastDateTimePicker.Height);
				UpdateVisible(LastDateTimePicker);
				LastParentControl.Controls.Add(LastDateTimePicker);
			}
		}
	}

	private void UpdateEnabled(Control c)
	{
		if (c != null)
		{
			bool enabled = _ribbonDateTimePicker.Enabled;
			if (!_ribbon.InDesignHelperMode && _ribbonDateTimePicker.DateTimePickerDesigner != null)
			{
				enabled = _ribbonDateTimePicker.DateTimePickerDesigner.DesignEnabled;
			}
			c.Enabled = enabled;
		}
	}

	private bool ActualVisible(Control c)
	{
		if (c != null)
		{
			bool result = _ribbonDateTimePicker.Visible;
			if (!_ribbon.InDesignHelperMode && _ribbonDateTimePicker.DateTimePickerDesigner != null)
			{
				result = _ribbonDateTimePicker.DateTimePickerDesigner.DesignVisible;
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
		bool flag = _ribbonDateTimePicker.Visible;
		if (!_ribbon.InDesignHelperMode && _ribbonDateTimePicker.DateTimePickerDesigner != null)
		{
			flag = _ribbonDateTimePicker.DateTimePickerDesigner.DesignVisible;
		}
		if (flag)
		{
			if (_ribbonDateTimePicker.RibbonTab == null || _ribbon.SelectedTab != _ribbonDateTimePicker.RibbonTab)
			{
				flag = false;
			}
			else if (_ribbonDateTimePicker.RibbonContainer != null && _ribbonDateTimePicker.RibbonContainer.RibbonGroup != null && !_ribbonDateTimePicker.RibbonContainer.RibbonGroup.Visible && !_ribbon.InDesignMode)
			{
				flag = false;
			}
			else if (_ribbonDateTimePicker.RibbonContainer.RibbonGroup.IsCollapsed && (_ribbon.GetControllerControl(_ribbonDateTimePicker.DateTimePicker) is KryptonRibbon || _ribbon.GetControllerControl(_ribbonDateTimePicker.DateTimePicker) is VisualPopupMinimized))
			{
				flag = false;
			}
			else
			{
				for (KryptonRibbonGroupContainer ribbonContainer = _ribbonDateTimePicker.RibbonContainer; ribbonContainer != null; ribbonContainer = ribbonContainer.RibbonContainer)
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
		if (_ribbonDateTimePicker != null)
		{
			UpdateVisible(LastDateTimePicker);
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
