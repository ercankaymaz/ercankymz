#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupRichTextBox : ViewComposite, IRibbonViewGroupItemView
{
	private static readonly int NULL_CONTROL_WIDTH = 50;

	private KryptonRibbon _ribbon;

	private KryptonRibbonGroupRichTextBox _ribbonRichTextBox;

	private ViewDrawRibbonGroup _activeGroup;

	private RichTextBoxController _controller;

	private NeedPaintHandler _needPaint;

	private GroupItemSize _currentSize;

	public KryptonRibbonGroupRichTextBox GroupRichTextBox => _ribbonRichTextBox;

	private Control LastParentControl
	{
		get
		{
			return _ribbonRichTextBox.LastParentControl;
		}
		set
		{
			_ribbonRichTextBox.LastParentControl = value;
		}
	}

	private KryptonRichTextBox LastRichTextBox
	{
		get
		{
			return _ribbonRichTextBox.LastRichTextBox;
		}
		set
		{
			_ribbonRichTextBox.LastRichTextBox = value;
		}
	}

	public ViewDrawRibbonGroupRichTextBox(KryptonRibbon ribbon, KryptonRibbonGroupRichTextBox ribbonRichTextBox, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(ribbonRichTextBox != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_ribbonRichTextBox = ribbonRichTextBox;
		_needPaint = needPaint;
		_currentSize = _ribbonRichTextBox.ItemSizeCurrent;
		_ribbonRichTextBox.MouseEnterControl += OnMouseEnterControl;
		_ribbonRichTextBox.MouseLeaveControl += OnMouseLeaveControl;
		Component = _ribbonRichTextBox;
		if (_ribbon.InDesignMode)
		{
			ContextClickController contextClickController = new ContextClickController();
			contextClickController.ContextClick += OnContextClick;
			MouseController = contextClickController;
		}
		_controller = new RichTextBoxController(_ribbon, _ribbonRichTextBox, this);
		SourceController = _controller;
		KeyController = _controller;
		_ribbon.ViewRibbonManager.LayoutBefore += OnLayoutAction;
		_ribbon.ViewRibbonManager.LayoutAfter += OnLayoutAction;
		_ribbonRichTextBox.RichTextBoxView = this;
		_ribbonRichTextBox.ViewPaintDelegate = needPaint;
		_ribbonRichTextBox.PropertyChanged += OnRichTextBoxPropertyChanged;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupRichTextBox:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _ribbonRichTextBox != null)
		{
			_ribbonRichTextBox.MouseEnterControl -= OnMouseEnterControl;
			_ribbonRichTextBox.MouseLeaveControl -= OnMouseLeaveControl;
			_ribbonRichTextBox.ViewPaintDelegate = null;
			_ribbonRichTextBox.PropertyChanged -= OnRichTextBoxPropertyChanged;
			_ribbon.ViewRibbonManager.LayoutAfter -= OnLayoutAction;
			_ribbon.ViewRibbonManager.LayoutBefore -= OnLayoutAction;
			_ribbonRichTextBox.RichTextBoxView = null;
			_ribbonRichTextBox = null;
		}
		base.Dispose(disposing);
	}

	public override void LostFocus(Control c)
	{
		_ribbon.HideFocus(_ribbonRichTextBox.RichTextBox);
		base.LostFocus(c);
	}

	public ViewBase GetFirstFocusItem()
	{
		if (_ribbonRichTextBox.Visible && _ribbonRichTextBox.LastRichTextBox != null && _ribbonRichTextBox.LastRichTextBox.RichTextBox != null && _ribbonRichTextBox.LastRichTextBox.RichTextBox.CanSelect)
		{
			return this;
		}
		return null;
	}

	public ViewBase GetLastFocusItem()
	{
		if (_ribbonRichTextBox.Visible && _ribbonRichTextBox.LastRichTextBox != null && _ribbonRichTextBox.LastRichTextBox.RichTextBox != null && _ribbonRichTextBox.LastRichTextBox.RichTextBox.CanSelect)
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
		if (Visible && LastRichTextBox.CanFocus)
		{
			Rectangle viewRect = LastRichTextBox.Parent.RectangleToScreen(ClientRectangle);
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
			keyTipList.Add(new KeyTipInfo(_ribbonRichTextBox.Enabled, _ribbonRichTextBox.KeyTip, screenPt, ClientRectangle, _controller));
		}
	}

	public void SetGroupItemSize(GroupItemSize size)
	{
		_currentSize = size;
	}

	public void ResetGroupItemSize()
	{
		_currentSize = _ribbonRichTextBox.ItemSizeCurrent;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Size result = Size.Empty;
		UpdateParent(context.Control);
		if (LastRichTextBox != null)
		{
			if (ActualVisible(LastRichTextBox))
			{
				result = LastRichTextBox.GetPreferredSize(context.DisplayRectangle.Size);
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
		if (!context.ViewManager.DoNotLayoutControls && LastRichTextBox != null)
		{
			LastRichTextBox.SetBounds(ClientLocation.X + 1, ClientLocation.Y + 1, ClientWidth - 2, ClientHeight - 2);
		}
		base.Layout(context);
	}

	public override void Render(RenderContext context)
	{
		Debug.Assert(context != null);
		if (_ribbonRichTextBox.RichTextBox == null && _ribbon.InDesignMode)
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
		_ribbonRichTextBox.OnDesignTimeContextMenu(e);
	}

	private void OnRichTextBoxPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		bool flag = false;
		bool flag2 = false;
		switch (e.PropertyName)
		{
		case "Enabled":
			UpdateEnabled(LastRichTextBox);
			break;
		case "Visible":
			UpdateVisible(LastRichTextBox);
			flag = true;
			break;
		case "CustomControl":
			flag = true;
			break;
		}
		if (flag && _ribbonRichTextBox.RibbonTab != null && _ribbon.SelectedTab == _ribbonRichTextBox.RibbonTab)
		{
			OnNeedPaint(needLayout: true);
		}
		if (flag2 && (_ribbonRichTextBox.Visible || _ribbon.InDesignMode) && _ribbonRichTextBox.RibbonTab != null && _ribbon.SelectedTab == _ribbonRichTextBox.RibbonTab)
		{
			OnNeedPaint(needLayout: false, ClientRectangle);
		}
	}

	private void UpdateParent(Control parentControl)
	{
		if ((parentControl != LastParentControl || LastRichTextBox != _ribbonRichTextBox.RichTextBox) && ((_ribbonRichTextBox.RibbonContainer.RibbonGroup.ShowingAsPopup && parentControl is VisualPopupGroup) || (!_ribbonRichTextBox.RibbonContainer.RibbonGroup.ShowingAsPopup && !(parentControl is VisualPopupGroup))))
		{
			if (LastRichTextBox != null && LastParentControl != null && LastParentControl.Controls.Contains(LastRichTextBox))
			{
				LastParentControl.Controls.Remove(LastRichTextBox);
			}
			LastRichTextBox = _ribbonRichTextBox.RichTextBox;
			LastParentControl = parentControl;
			if (LastRichTextBox != null && LastParentControl != null)
			{
				LastRichTextBox.Location = new Point(-LastRichTextBox.Width, -LastRichTextBox.Height);
				UpdateVisible(LastRichTextBox);
				UpdateEnabled(LastRichTextBox);
				LastParentControl.Controls.Add(LastRichTextBox);
			}
		}
	}

	private void UpdateEnabled(Control c)
	{
		if (c != null)
		{
			bool enabled = _ribbonRichTextBox.Enabled;
			if (!_ribbon.InDesignHelperMode && _ribbonRichTextBox.RichTextBoxDesigner != null)
			{
				enabled = _ribbonRichTextBox.RichTextBoxDesigner.DesignEnabled;
			}
			c.Enabled = enabled;
		}
	}

	private bool ActualVisible(Control c)
	{
		if (c != null)
		{
			bool result = _ribbonRichTextBox.Visible;
			if (!_ribbon.InDesignHelperMode && _ribbonRichTextBox.RichTextBoxDesigner != null)
			{
				result = _ribbonRichTextBox.RichTextBoxDesigner.DesignVisible;
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
		bool flag = _ribbonRichTextBox.Visible;
		if (!_ribbon.InDesignHelperMode && _ribbonRichTextBox.RichTextBoxDesigner != null)
		{
			flag = _ribbonRichTextBox.RichTextBoxDesigner.DesignVisible;
		}
		if (flag)
		{
			if (_ribbonRichTextBox.RibbonTab == null || _ribbon.SelectedTab != _ribbonRichTextBox.RibbonTab)
			{
				flag = false;
			}
			else if (_ribbonRichTextBox.RibbonContainer != null && _ribbonRichTextBox.RibbonContainer.RibbonGroup != null && !_ribbonRichTextBox.RibbonContainer.RibbonGroup.Visible && !_ribbon.InDesignMode)
			{
				flag = false;
			}
			else if (_ribbonRichTextBox.RibbonContainer.RibbonGroup.IsCollapsed && (_ribbon.GetControllerControl(_ribbonRichTextBox.RichTextBox) is KryptonRibbon || _ribbon.GetControllerControl(_ribbonRichTextBox.RichTextBox) is VisualPopupMinimized))
			{
				flag = false;
			}
			else
			{
				for (KryptonRibbonGroupContainer ribbonContainer = _ribbonRichTextBox.RibbonContainer; ribbonContainer != null; ribbonContainer = ribbonContainer.RibbonContainer)
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
		if (_ribbonRichTextBox != null)
		{
			UpdateVisible(LastRichTextBox);
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
