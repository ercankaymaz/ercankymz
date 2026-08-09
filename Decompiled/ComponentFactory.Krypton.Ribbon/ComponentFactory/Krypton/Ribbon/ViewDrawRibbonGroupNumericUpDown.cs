#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupNumericUpDown : ViewComposite, IRibbonViewGroupItemView
{
	private static readonly int NULL_CONTROL_WIDTH = 50;

	private KryptonRibbon _ribbon;

	private KryptonRibbonGroupNumericUpDown _ribbonNumericUpDown;

	private ViewDrawRibbonGroup _activeGroup;

	private NumericUpDownController _controller;

	private NeedPaintHandler _needPaint;

	private GroupItemSize _currentSize;

	public KryptonRibbonGroupNumericUpDown GroupNumericUpDown => _ribbonNumericUpDown;

	private Control LastParentControl
	{
		get
		{
			return _ribbonNumericUpDown.LastParentControl;
		}
		set
		{
			_ribbonNumericUpDown.LastParentControl = value;
		}
	}

	private KryptonNumericUpDown LastNumericUpDown
	{
		get
		{
			return _ribbonNumericUpDown.LastNumericUpDown;
		}
		set
		{
			_ribbonNumericUpDown.LastNumericUpDown = value;
		}
	}

	public ViewDrawRibbonGroupNumericUpDown(KryptonRibbon ribbon, KryptonRibbonGroupNumericUpDown ribbonNumericUpDown, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(ribbonNumericUpDown != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_ribbonNumericUpDown = ribbonNumericUpDown;
		_needPaint = needPaint;
		_currentSize = _ribbonNumericUpDown.ItemSizeCurrent;
		_ribbonNumericUpDown.MouseEnterControl += OnMouseEnterControl;
		_ribbonNumericUpDown.MouseLeaveControl += OnMouseLeaveControl;
		Component = _ribbonNumericUpDown;
		if (_ribbon.InDesignMode)
		{
			ContextClickController contextClickController = new ContextClickController();
			contextClickController.ContextClick += OnContextClick;
			MouseController = contextClickController;
		}
		_controller = new NumericUpDownController(_ribbon, _ribbonNumericUpDown, this);
		SourceController = _controller;
		KeyController = _controller;
		_ribbon.ViewRibbonManager.LayoutBefore += OnLayoutAction;
		_ribbon.ViewRibbonManager.LayoutAfter += OnLayoutAction;
		_ribbonNumericUpDown.NumericUpDownView = this;
		_ribbonNumericUpDown.ViewPaintDelegate = needPaint;
		_ribbonNumericUpDown.PropertyChanged += OnNumericUpDownPropertyChanged;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupNumericUpDown:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _ribbonNumericUpDown != null)
		{
			_ribbonNumericUpDown.MouseEnterControl -= OnMouseEnterControl;
			_ribbonNumericUpDown.MouseLeaveControl -= OnMouseLeaveControl;
			_ribbonNumericUpDown.ViewPaintDelegate = null;
			_ribbonNumericUpDown.PropertyChanged -= OnNumericUpDownPropertyChanged;
			_ribbon.ViewRibbonManager.LayoutAfter -= OnLayoutAction;
			_ribbon.ViewRibbonManager.LayoutBefore -= OnLayoutAction;
			_ribbonNumericUpDown.NumericUpDownView = null;
			_ribbonNumericUpDown = null;
		}
		base.Dispose(disposing);
	}

	public override void LostFocus(Control c)
	{
		_ribbon.HideFocus(_ribbonNumericUpDown.NumericUpDown);
		base.LostFocus(c);
	}

	public ViewBase GetFirstFocusItem()
	{
		if (_ribbonNumericUpDown.Visible && _ribbonNumericUpDown.LastNumericUpDown != null && _ribbonNumericUpDown.LastNumericUpDown.NumericUpDown != null && _ribbonNumericUpDown.LastNumericUpDown.NumericUpDown.CanSelect)
		{
			return this;
		}
		return null;
	}

	public ViewBase GetLastFocusItem()
	{
		if (_ribbonNumericUpDown.Visible && _ribbonNumericUpDown.LastNumericUpDown != null && _ribbonNumericUpDown.LastNumericUpDown.NumericUpDown != null && _ribbonNumericUpDown.LastNumericUpDown.NumericUpDown.CanSelect)
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
		if (Visible && LastNumericUpDown.CanFocus)
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
			keyTipList.Add(new KeyTipInfo(_ribbonNumericUpDown.Enabled, _ribbonNumericUpDown.KeyTip, screenPt, ClientRectangle, _controller));
		}
	}

	public void SetGroupItemSize(GroupItemSize size)
	{
		_currentSize = size;
	}

	public void ResetGroupItemSize()
	{
		_currentSize = _ribbonNumericUpDown.ItemSizeCurrent;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Size result = Size.Empty;
		UpdateParent(context.Control);
		if (LastNumericUpDown != null)
		{
			if (ActualVisible(LastNumericUpDown))
			{
				result = LastNumericUpDown.GetPreferredSize(context.DisplayRectangle.Size);
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
		if (!context.ViewManager.DoNotLayoutControls && LastNumericUpDown != null)
		{
			LastNumericUpDown.SetBounds(ClientLocation.X + 1, ClientLocation.Y + 1, ClientWidth - 2, ClientHeight - 2);
		}
		base.Layout(context);
	}

	public override void Render(RenderContext context)
	{
		Debug.Assert(context != null);
		if (_ribbonNumericUpDown.NumericUpDown == null && _ribbon.InDesignMode)
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
		_ribbonNumericUpDown.OnDesignTimeContextMenu(e);
	}

	private void OnNumericUpDownPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		bool flag = false;
		bool flag2 = false;
		switch (e.PropertyName)
		{
		case "Enabled":
			UpdateEnabled(LastNumericUpDown);
			break;
		case "Visible":
			UpdateVisible(LastNumericUpDown);
			flag = true;
			break;
		case "CustomControl":
			flag = true;
			break;
		}
		if (flag && _ribbonNumericUpDown.RibbonTab != null && _ribbon.SelectedTab == _ribbonNumericUpDown.RibbonTab)
		{
			OnNeedPaint(needLayout: true);
		}
		if (flag2 && (_ribbonNumericUpDown.Visible || _ribbon.InDesignMode) && _ribbonNumericUpDown.RibbonTab != null && _ribbon.SelectedTab == _ribbonNumericUpDown.RibbonTab)
		{
			OnNeedPaint(needLayout: false, ClientRectangle);
		}
	}

	private void UpdateParent(Control parentControl)
	{
		if ((parentControl != LastParentControl || LastNumericUpDown != _ribbonNumericUpDown.NumericUpDown) && ((_ribbonNumericUpDown.RibbonContainer.RibbonGroup.ShowingAsPopup && parentControl is VisualPopupGroup) || (!_ribbonNumericUpDown.RibbonContainer.RibbonGroup.ShowingAsPopup && !(parentControl is VisualPopupGroup))))
		{
			if (LastNumericUpDown != null && LastParentControl != null && LastParentControl.Controls.Contains(LastNumericUpDown))
			{
				LastParentControl.Controls.Remove(LastNumericUpDown);
			}
			LastNumericUpDown = _ribbonNumericUpDown.NumericUpDown;
			LastParentControl = parentControl;
			if (LastNumericUpDown != null && LastParentControl != null)
			{
				LastNumericUpDown.Location = new Point(-LastNumericUpDown.Width, -LastNumericUpDown.Height);
				UpdateVisible(LastNumericUpDown);
				LastParentControl.Controls.Add(LastNumericUpDown);
			}
		}
	}

	private void UpdateEnabled(Control c)
	{
		if (c != null)
		{
			bool enabled = _ribbonNumericUpDown.Enabled;
			if (!_ribbon.InDesignHelperMode && _ribbonNumericUpDown.NumericUpDownDesigner != null)
			{
				enabled = _ribbonNumericUpDown.NumericUpDownDesigner.DesignEnabled;
			}
			c.Enabled = enabled;
		}
	}

	private bool ActualVisible(Control c)
	{
		if (c != null)
		{
			bool result = _ribbonNumericUpDown.Visible;
			if (!_ribbon.InDesignHelperMode && _ribbonNumericUpDown.NumericUpDownDesigner != null)
			{
				result = _ribbonNumericUpDown.NumericUpDownDesigner.DesignVisible;
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
		bool flag = _ribbonNumericUpDown.Visible;
		if (!_ribbon.InDesignHelperMode && _ribbonNumericUpDown.NumericUpDownDesigner != null)
		{
			flag = _ribbonNumericUpDown.NumericUpDownDesigner.DesignVisible;
		}
		if (flag)
		{
			if (_ribbonNumericUpDown.RibbonTab == null || _ribbon.SelectedTab != _ribbonNumericUpDown.RibbonTab)
			{
				flag = false;
			}
			else if (_ribbonNumericUpDown.RibbonContainer != null && _ribbonNumericUpDown.RibbonContainer.RibbonGroup != null && !_ribbonNumericUpDown.RibbonContainer.RibbonGroup.Visible && !_ribbon.InDesignMode)
			{
				flag = false;
			}
			else if (_ribbonNumericUpDown.RibbonContainer.RibbonGroup.IsCollapsed && (_ribbon.GetControllerControl(_ribbonNumericUpDown.NumericUpDown) is KryptonRibbon || _ribbon.GetControllerControl(_ribbonNumericUpDown.NumericUpDown) is VisualPopupMinimized))
			{
				flag = false;
			}
			else
			{
				for (KryptonRibbonGroupContainer ribbonContainer = _ribbonNumericUpDown.RibbonContainer; ribbonContainer != null; ribbonContainer = ribbonContainer.RibbonContainer)
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
		if (_ribbonNumericUpDown != null)
		{
			UpdateVisible(LastNumericUpDown);
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
