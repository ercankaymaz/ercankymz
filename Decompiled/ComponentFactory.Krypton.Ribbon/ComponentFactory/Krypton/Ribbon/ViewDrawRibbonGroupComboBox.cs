#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupComboBox : ViewComposite, IRibbonViewGroupItemView
{
	private static readonly int NULL_CONTROL_WIDTH = 50;

	private KryptonRibbon _ribbon;

	private KryptonRibbonGroupComboBox _ribbonComboBox;

	private ViewDrawRibbonGroup _activeGroup;

	private ComboBoxController _controller;

	private NeedPaintHandler _needPaint;

	private GroupItemSize _currentSize;

	public KryptonRibbonGroupComboBox GroupComboBox => _ribbonComboBox;

	private Control LastParentControl
	{
		get
		{
			return _ribbonComboBox.LastParentControl;
		}
		set
		{
			_ribbonComboBox.LastParentControl = value;
		}
	}

	private KryptonComboBox LastComboBox
	{
		get
		{
			return _ribbonComboBox.LastComboBox;
		}
		set
		{
			_ribbonComboBox.LastComboBox = value;
		}
	}

	public ViewDrawRibbonGroupComboBox(KryptonRibbon ribbon, KryptonRibbonGroupComboBox ribbonComboBox, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(ribbonComboBox != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_ribbonComboBox = ribbonComboBox;
		_needPaint = needPaint;
		_currentSize = _ribbonComboBox.ItemSizeCurrent;
		_ribbonComboBox.MouseEnterControl += OnMouseEnterControl;
		_ribbonComboBox.MouseLeaveControl += OnMouseLeaveControl;
		Component = _ribbonComboBox;
		if (_ribbon.InDesignMode)
		{
			ContextClickController contextClickController = new ContextClickController();
			contextClickController.ContextClick += OnContextClick;
			MouseController = contextClickController;
		}
		_controller = new ComboBoxController(_ribbon, _ribbonComboBox, this);
		SourceController = _controller;
		KeyController = _controller;
		_ribbon.ViewRibbonManager.LayoutBefore += OnLayoutAction;
		_ribbon.ViewRibbonManager.LayoutAfter += OnLayoutAction;
		_ribbonComboBox.ComboBoxView = this;
		_ribbonComboBox.ViewPaintDelegate = needPaint;
		_ribbonComboBox.PropertyChanged += OnComboBoxPropertyChanged;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupComboBox:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _ribbonComboBox != null)
		{
			_ribbonComboBox.MouseEnterControl -= OnMouseEnterControl;
			_ribbonComboBox.MouseLeaveControl -= OnMouseLeaveControl;
			_ribbonComboBox.ViewPaintDelegate = null;
			_ribbonComboBox.PropertyChanged -= OnComboBoxPropertyChanged;
			_ribbon.ViewRibbonManager.LayoutAfter -= OnLayoutAction;
			_ribbon.ViewRibbonManager.LayoutBefore -= OnLayoutAction;
			_ribbonComboBox.ComboBoxView = null;
			_ribbonComboBox = null;
		}
		base.Dispose(disposing);
	}

	public override void LostFocus(Control c)
	{
		_ribbon.HideFocus(_ribbonComboBox.ComboBox);
		base.LostFocus(c);
	}

	public ViewBase GetFirstFocusItem()
	{
		if (_ribbonComboBox.Visible && _ribbonComboBox.LastComboBox != null && _ribbonComboBox.LastComboBox.ComboBox != null && _ribbonComboBox.LastComboBox.ComboBox.CanSelect)
		{
			return this;
		}
		return null;
	}

	public ViewBase GetLastFocusItem()
	{
		if (_ribbonComboBox.Visible && _ribbonComboBox.LastComboBox != null && _ribbonComboBox.LastComboBox.ComboBox != null && _ribbonComboBox.LastComboBox.ComboBox.CanSelect)
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
		if (Visible && LastComboBox.CanFocus)
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
			keyTipList.Add(new KeyTipInfo(_ribbonComboBox.Enabled, _ribbonComboBox.KeyTip, screenPt, ClientRectangle, _controller));
		}
	}

	public void SetGroupItemSize(GroupItemSize size)
	{
		_currentSize = size;
	}

	public void ResetGroupItemSize()
	{
		_currentSize = _ribbonComboBox.ItemSizeCurrent;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Size result = Size.Empty;
		UpdateParent(context.Control);
		if (LastComboBox != null)
		{
			if (ActualVisible(LastComboBox))
			{
				result = LastComboBox.GetPreferredSize(context.DisplayRectangle.Size);
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
		if (!context.ViewManager.DoNotLayoutControls && LastComboBox != null)
		{
			LastComboBox.SetBounds(ClientLocation.X + 1, ClientLocation.Y + 1, ClientWidth - 2, ClientHeight - 2);
		}
		base.Layout(context);
	}

	public override void Render(RenderContext context)
	{
		Debug.Assert(context != null);
		if (_ribbonComboBox.ComboBox == null && _ribbon.InDesignMode)
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
		_ribbonComboBox.OnDesignTimeContextMenu(e);
	}

	private void OnComboBoxPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		bool flag = false;
		bool flag2 = false;
		switch (e.PropertyName)
		{
		case "Enabled":
			UpdateEnabled(LastComboBox);
			break;
		case "Visible":
			UpdateVisible(LastComboBox);
			flag = true;
			break;
		case "CustomControl":
			flag = true;
			break;
		}
		if (flag && _ribbonComboBox.RibbonTab != null && _ribbon.SelectedTab == _ribbonComboBox.RibbonTab)
		{
			OnNeedPaint(needLayout: true);
		}
		if (flag2 && (_ribbonComboBox.Visible || _ribbon.InDesignMode) && _ribbonComboBox.RibbonTab != null && _ribbon.SelectedTab == _ribbonComboBox.RibbonTab)
		{
			OnNeedPaint(needLayout: false, ClientRectangle);
		}
	}

	private void UpdateParent(Control parentControl)
	{
		if ((parentControl != LastParentControl || LastComboBox != _ribbonComboBox.ComboBox) && ((_ribbonComboBox.RibbonContainer.RibbonGroup.ShowingAsPopup && parentControl is VisualPopupGroup) || (!_ribbonComboBox.RibbonContainer.RibbonGroup.ShowingAsPopup && !(parentControl is VisualPopupGroup))))
		{
			if (LastComboBox != null && LastParentControl != null && LastParentControl.Controls.Contains(LastComboBox))
			{
				LastParentControl.Controls.Remove(LastComboBox);
			}
			LastComboBox = _ribbonComboBox.ComboBox;
			LastParentControl = parentControl;
			if (LastComboBox != null && LastParentControl != null)
			{
				LastComboBox.Location = new Point(-LastComboBox.Width, -LastComboBox.Height);
				UpdateVisible(LastComboBox);
				UpdateEnabled(LastComboBox);
				LastParentControl.Controls.Add(LastComboBox);
			}
		}
	}

	private void UpdateEnabled(Control c)
	{
		if (c != null)
		{
			bool enabled = _ribbonComboBox.Enabled;
			if (!_ribbon.InDesignHelperMode && _ribbonComboBox.ComboBoxDesigner != null)
			{
				enabled = _ribbonComboBox.ComboBoxDesigner.DesignEnabled;
			}
			c.Enabled = enabled;
		}
	}

	private bool ActualVisible(Control c)
	{
		if (c != null)
		{
			bool result = _ribbonComboBox.Visible;
			if (!_ribbon.InDesignHelperMode && _ribbonComboBox.ComboBoxDesigner != null)
			{
				result = _ribbonComboBox.ComboBoxDesigner.DesignVisible;
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
		bool flag = _ribbonComboBox.Visible;
		if (!_ribbon.InDesignHelperMode && _ribbonComboBox.ComboBoxDesigner != null)
		{
			flag = _ribbonComboBox.ComboBoxDesigner.DesignVisible;
		}
		if (flag)
		{
			if (_ribbonComboBox.RibbonTab == null || _ribbon.SelectedTab != _ribbonComboBox.RibbonTab)
			{
				flag = false;
			}
			else if (_ribbonComboBox.RibbonContainer != null && _ribbonComboBox.RibbonContainer.RibbonGroup != null && !_ribbonComboBox.RibbonContainer.RibbonGroup.Visible && !_ribbon.InDesignMode)
			{
				flag = false;
			}
			else if (_ribbonComboBox.RibbonContainer.RibbonGroup.IsCollapsed && (_ribbon.GetControllerControl(_ribbonComboBox.ComboBox) is KryptonRibbon || _ribbon.GetControllerControl(_ribbonComboBox.ComboBox) is VisualPopupMinimized))
			{
				flag = false;
			}
			else
			{
				for (KryptonRibbonGroupContainer ribbonContainer = _ribbonComboBox.RibbonContainer; ribbonContainer != null; ribbonContainer = ribbonContainer.RibbonContainer)
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
		if (_ribbonComboBox != null)
		{
			UpdateVisible(LastComboBox);
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
