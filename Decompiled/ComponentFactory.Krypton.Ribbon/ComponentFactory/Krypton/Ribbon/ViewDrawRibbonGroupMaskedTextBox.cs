#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupMaskedTextBox : ViewComposite, IRibbonViewGroupItemView
{
	private static readonly int NULL_CONTROL_WIDTH = 50;

	private KryptonRibbon _ribbon;

	private KryptonRibbonGroupMaskedTextBox _ribbonMaskedTextBox;

	private ViewDrawRibbonGroup _activeGroup;

	private MaskedTextBoxController _controller;

	private NeedPaintHandler _needPaint;

	private GroupItemSize _currentSize;

	public KryptonRibbonGroupMaskedTextBox GroupMaskedTextBox => _ribbonMaskedTextBox;

	private Control LastParentControl
	{
		get
		{
			return _ribbonMaskedTextBox.LastParentControl;
		}
		set
		{
			_ribbonMaskedTextBox.LastParentControl = value;
		}
	}

	private KryptonMaskedTextBox LastMaskedTextBox
	{
		get
		{
			return _ribbonMaskedTextBox.LastMaskedTextBox;
		}
		set
		{
			_ribbonMaskedTextBox.LastMaskedTextBox = value;
		}
	}

	public ViewDrawRibbonGroupMaskedTextBox(KryptonRibbon ribbon, KryptonRibbonGroupMaskedTextBox ribbonMaskedTextBox, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(ribbonMaskedTextBox != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_ribbonMaskedTextBox = ribbonMaskedTextBox;
		_needPaint = needPaint;
		_currentSize = _ribbonMaskedTextBox.ItemSizeCurrent;
		_ribbonMaskedTextBox.MouseEnterControl += OnMouseEnterControl;
		_ribbonMaskedTextBox.MouseLeaveControl += OnMouseLeaveControl;
		Component = _ribbonMaskedTextBox;
		if (_ribbon.InDesignMode)
		{
			ContextClickController contextClickController = new ContextClickController();
			contextClickController.ContextClick += OnContextClick;
			MouseController = contextClickController;
		}
		_controller = new MaskedTextBoxController(_ribbon, _ribbonMaskedTextBox, this);
		SourceController = _controller;
		KeyController = _controller;
		_ribbon.ViewRibbonManager.LayoutBefore += OnLayoutAction;
		_ribbon.ViewRibbonManager.LayoutAfter += OnLayoutAction;
		_ribbonMaskedTextBox.MaskedTextBoxView = this;
		_ribbonMaskedTextBox.ViewPaintDelegate = needPaint;
		_ribbonMaskedTextBox.PropertyChanged += OnMaskedTextBoxPropertyChanged;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupMaskedTextBox:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _ribbonMaskedTextBox != null)
		{
			_ribbonMaskedTextBox.MouseEnterControl -= OnMouseEnterControl;
			_ribbonMaskedTextBox.MouseLeaveControl -= OnMouseLeaveControl;
			_ribbonMaskedTextBox.ViewPaintDelegate = null;
			_ribbonMaskedTextBox.PropertyChanged -= OnMaskedTextBoxPropertyChanged;
			_ribbon.ViewRibbonManager.LayoutAfter -= OnLayoutAction;
			_ribbon.ViewRibbonManager.LayoutBefore -= OnLayoutAction;
			_ribbonMaskedTextBox.MaskedTextBoxView = null;
			_ribbonMaskedTextBox = null;
		}
		base.Dispose(disposing);
	}

	public override void LostFocus(Control c)
	{
		_ribbon.HideFocus(_ribbonMaskedTextBox.MaskedTextBox);
		base.LostFocus(c);
	}

	public ViewBase GetFirstFocusItem()
	{
		if (_ribbonMaskedTextBox.Visible && _ribbonMaskedTextBox.LastMaskedTextBox != null && _ribbonMaskedTextBox.LastMaskedTextBox.MaskedTextBox != null && _ribbonMaskedTextBox.LastMaskedTextBox.MaskedTextBox.CanSelect)
		{
			return this;
		}
		return null;
	}

	public ViewBase GetLastFocusItem()
	{
		if (_ribbonMaskedTextBox.Visible && _ribbonMaskedTextBox.LastMaskedTextBox != null && _ribbonMaskedTextBox.LastMaskedTextBox.MaskedTextBox != null && _ribbonMaskedTextBox.LastMaskedTextBox.MaskedTextBox.CanSelect)
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
		if (Visible && LastMaskedTextBox.CanFocus)
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
			keyTipList.Add(new KeyTipInfo(_ribbonMaskedTextBox.Enabled, _ribbonMaskedTextBox.KeyTip, screenPt, ClientRectangle, _controller));
		}
	}

	public void SetGroupItemSize(GroupItemSize size)
	{
		_currentSize = size;
	}

	public void ResetGroupItemSize()
	{
		_currentSize = _ribbonMaskedTextBox.ItemSizeCurrent;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Size result = Size.Empty;
		UpdateParent(context.Control);
		if (LastMaskedTextBox != null)
		{
			if (ActualVisible(LastMaskedTextBox))
			{
				result = LastMaskedTextBox.GetPreferredSize(context.DisplayRectangle.Size);
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
		if (!context.ViewManager.DoNotLayoutControls && LastMaskedTextBox != null)
		{
			LastMaskedTextBox.SetBounds(ClientLocation.X + 1, ClientLocation.Y + 1, ClientWidth - 2, ClientHeight - 2);
		}
		base.Layout(context);
	}

	public override void Render(RenderContext context)
	{
		Debug.Assert(context != null);
		if (_ribbonMaskedTextBox.MaskedTextBox == null && _ribbon.InDesignMode)
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
		_ribbonMaskedTextBox.OnDesignTimeContextMenu(e);
	}

	private void OnMaskedTextBoxPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		bool flag = false;
		bool flag2 = false;
		switch (e.PropertyName)
		{
		case "Enabled":
			UpdateEnabled(LastMaskedTextBox);
			break;
		case "Visible":
			UpdateVisible(LastMaskedTextBox);
			flag = true;
			break;
		case "CustomControl":
			flag = true;
			break;
		}
		if (flag && _ribbonMaskedTextBox.RibbonTab != null && _ribbon.SelectedTab == _ribbonMaskedTextBox.RibbonTab)
		{
			OnNeedPaint(needLayout: true);
		}
		if (flag2 && (_ribbonMaskedTextBox.Visible || _ribbon.InDesignMode) && _ribbonMaskedTextBox.RibbonTab != null && _ribbon.SelectedTab == _ribbonMaskedTextBox.RibbonTab)
		{
			OnNeedPaint(needLayout: false, ClientRectangle);
		}
	}

	private void UpdateParent(Control parentControl)
	{
		if ((parentControl != LastParentControl || LastMaskedTextBox != _ribbonMaskedTextBox.MaskedTextBox) && ((_ribbonMaskedTextBox.RibbonContainer.RibbonGroup.ShowingAsPopup && parentControl is VisualPopupGroup) || (!_ribbonMaskedTextBox.RibbonContainer.RibbonGroup.ShowingAsPopup && !(parentControl is VisualPopupGroup))))
		{
			if (LastMaskedTextBox != null && LastParentControl != null && LastParentControl.Controls.Contains(LastMaskedTextBox))
			{
				LastParentControl.Controls.Remove(LastMaskedTextBox);
			}
			LastMaskedTextBox = _ribbonMaskedTextBox.MaskedTextBox;
			LastParentControl = parentControl;
			if (LastMaskedTextBox != null && LastParentControl != null)
			{
				LastMaskedTextBox.Location = new Point(-LastMaskedTextBox.Width, -LastMaskedTextBox.Height);
				UpdateVisible(LastMaskedTextBox);
				UpdateEnabled(LastMaskedTextBox);
				LastParentControl.Controls.Add(LastMaskedTextBox);
			}
		}
	}

	private void UpdateEnabled(Control c)
	{
		if (c != null)
		{
			bool enabled = _ribbonMaskedTextBox.Enabled;
			if (!_ribbon.InDesignHelperMode && _ribbonMaskedTextBox.MaskedTextBoxDesigner != null)
			{
				enabled = _ribbonMaskedTextBox.MaskedTextBoxDesigner.DesignEnabled;
			}
			c.Enabled = enabled;
		}
	}

	private bool ActualVisible(Control c)
	{
		if (c != null)
		{
			bool result = _ribbonMaskedTextBox.Visible;
			if (!_ribbon.InDesignHelperMode && _ribbonMaskedTextBox.MaskedTextBoxDesigner != null)
			{
				result = _ribbonMaskedTextBox.MaskedTextBoxDesigner.DesignVisible;
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
		bool flag = _ribbonMaskedTextBox.Visible;
		if (!_ribbon.InDesignHelperMode && _ribbonMaskedTextBox.MaskedTextBoxDesigner != null)
		{
			flag = _ribbonMaskedTextBox.MaskedTextBoxDesigner.DesignVisible;
		}
		if (flag)
		{
			if (_ribbonMaskedTextBox.RibbonTab == null || _ribbon.SelectedTab != _ribbonMaskedTextBox.RibbonTab)
			{
				flag = false;
			}
			else if (_ribbonMaskedTextBox.RibbonContainer != null && _ribbonMaskedTextBox.RibbonContainer.RibbonGroup != null && !_ribbonMaskedTextBox.RibbonContainer.RibbonGroup.Visible && !_ribbon.InDesignMode)
			{
				flag = false;
			}
			else if (_ribbonMaskedTextBox.RibbonContainer.RibbonGroup.IsCollapsed && (_ribbon.GetControllerControl(_ribbonMaskedTextBox.MaskedTextBox) is KryptonRibbon || _ribbon.GetControllerControl(_ribbonMaskedTextBox.MaskedTextBox) is VisualPopupMinimized))
			{
				flag = false;
			}
			else
			{
				for (KryptonRibbonGroupContainer ribbonContainer = _ribbonMaskedTextBox.RibbonContainer; ribbonContainer != null; ribbonContainer = ribbonContainer.RibbonContainer)
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
		if (_ribbonMaskedTextBox != null)
		{
			UpdateVisible(LastMaskedTextBox);
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
