#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupTextBox : ViewComposite, IRibbonViewGroupItemView
{
	private static readonly int NULL_CONTROL_WIDTH = 50;

	private KryptonRibbon _ribbon;

	private KryptonRibbonGroupTextBox _ribbonTextBox;

	private ViewDrawRibbonGroup _activeGroup;

	private TextBoxController _controller;

	private NeedPaintHandler _needPaint;

	private GroupItemSize _currentSize;

	public KryptonRibbonGroupTextBox GroupTextBox => _ribbonTextBox;

	private Control LastParentControl
	{
		get
		{
			return _ribbonTextBox.LastParentControl;
		}
		set
		{
			_ribbonTextBox.LastParentControl = value;
		}
	}

	private KryptonTextBox LastTextBox
	{
		get
		{
			return _ribbonTextBox.LastTextBox;
		}
		set
		{
			_ribbonTextBox.LastTextBox = value;
		}
	}

	public ViewDrawRibbonGroupTextBox(KryptonRibbon ribbon, KryptonRibbonGroupTextBox ribbonTextBox, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(ribbonTextBox != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_ribbonTextBox = ribbonTextBox;
		_needPaint = needPaint;
		_currentSize = _ribbonTextBox.ItemSizeCurrent;
		_ribbonTextBox.MouseEnterControl += OnMouseEnterControl;
		_ribbonTextBox.MouseLeaveControl += OnMouseLeaveControl;
		Component = _ribbonTextBox;
		if (_ribbon.InDesignMode)
		{
			ContextClickController contextClickController = new ContextClickController();
			contextClickController.ContextClick += OnContextClick;
			MouseController = contextClickController;
		}
		_controller = new TextBoxController(_ribbon, _ribbonTextBox, this);
		SourceController = _controller;
		KeyController = _controller;
		_ribbon.ViewRibbonManager.LayoutBefore += OnLayoutAction;
		_ribbon.ViewRibbonManager.LayoutAfter += OnLayoutAction;
		_ribbonTextBox.TextBoxView = this;
		_ribbonTextBox.ViewPaintDelegate = needPaint;
		_ribbonTextBox.PropertyChanged += OnTextBoxPropertyChanged;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupTextBox:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _ribbonTextBox != null)
		{
			_ribbonTextBox.MouseEnterControl -= OnMouseEnterControl;
			_ribbonTextBox.MouseLeaveControl -= OnMouseLeaveControl;
			_ribbonTextBox.ViewPaintDelegate = null;
			_ribbonTextBox.PropertyChanged -= OnTextBoxPropertyChanged;
			_ribbon.ViewRibbonManager.LayoutAfter -= OnLayoutAction;
			_ribbon.ViewRibbonManager.LayoutBefore -= OnLayoutAction;
			_ribbonTextBox.TextBoxView = null;
			_ribbonTextBox = null;
		}
		base.Dispose(disposing);
	}

	public override void LostFocus(Control c)
	{
		_ribbon.HideFocus(_ribbonTextBox.TextBox);
		base.LostFocus(c);
	}

	public ViewBase GetFirstFocusItem()
	{
		if (_ribbonTextBox.Visible && _ribbonTextBox.LastTextBox != null && _ribbonTextBox.LastTextBox.TextBox != null && _ribbonTextBox.LastTextBox.TextBox.CanSelect)
		{
			return this;
		}
		return null;
	}

	public ViewBase GetLastFocusItem()
	{
		if (_ribbonTextBox.Visible && _ribbonTextBox.LastTextBox != null && _ribbonTextBox.LastTextBox.TextBox != null && _ribbonTextBox.LastTextBox.TextBox.CanSelect)
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
		if (Visible && LastTextBox.CanFocus)
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
			keyTipList.Add(new KeyTipInfo(_ribbonTextBox.Enabled, _ribbonTextBox.KeyTip, screenPt, ClientRectangle, _controller));
		}
	}

	public void SetGroupItemSize(GroupItemSize size)
	{
		_currentSize = size;
	}

	public void ResetGroupItemSize()
	{
		_currentSize = _ribbonTextBox.ItemSizeCurrent;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Size result = Size.Empty;
		UpdateParent(context.Control);
		if (LastTextBox != null)
		{
			if (ActualVisible(LastTextBox))
			{
				result = LastTextBox.GetPreferredSize(context.DisplayRectangle.Size);
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
		if (!context.ViewManager.DoNotLayoutControls && LastTextBox != null)
		{
			LastTextBox.SetBounds(ClientLocation.X + 1, ClientLocation.Y + 1, ClientWidth - 2, ClientHeight - 2);
		}
		base.Layout(context);
	}

	public override void Render(RenderContext context)
	{
		Debug.Assert(context != null);
		if (_ribbonTextBox.TextBox == null && _ribbon.InDesignMode)
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
		_ribbonTextBox.OnDesignTimeContextMenu(e);
	}

	private void OnTextBoxPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		bool flag = false;
		bool flag2 = false;
		switch (e.PropertyName)
		{
		case "Enabled":
			UpdateEnabled(LastTextBox);
			break;
		case "Visible":
			UpdateVisible(LastTextBox);
			flag = true;
			break;
		case "CustomControl":
			flag = true;
			break;
		}
		if (flag && _ribbonTextBox.RibbonTab != null && _ribbon.SelectedTab == _ribbonTextBox.RibbonTab)
		{
			OnNeedPaint(needLayout: true);
		}
		if (flag2 && (_ribbonTextBox.Visible || _ribbon.InDesignMode) && _ribbonTextBox.RibbonTab != null && _ribbon.SelectedTab == _ribbonTextBox.RibbonTab)
		{
			OnNeedPaint(needLayout: false, ClientRectangle);
		}
	}

	private void UpdateParent(Control parentControl)
	{
		if ((parentControl != LastParentControl || LastTextBox != _ribbonTextBox.TextBox) && ((_ribbonTextBox.RibbonContainer.RibbonGroup.ShowingAsPopup && parentControl is VisualPopupGroup) || (!_ribbonTextBox.RibbonContainer.RibbonGroup.ShowingAsPopup && !(parentControl is VisualPopupGroup))))
		{
			if (LastTextBox != null && LastParentControl != null && LastParentControl.Controls.Contains(LastTextBox))
			{
				LastParentControl.Controls.Remove(LastTextBox);
			}
			LastTextBox = _ribbonTextBox.TextBox;
			LastParentControl = parentControl;
			if (LastTextBox != null && LastParentControl != null)
			{
				LastTextBox.Location = new Point(-LastTextBox.Width, -LastTextBox.Height);
				UpdateVisible(LastTextBox);
				LastParentControl.Controls.Add(LastTextBox);
			}
		}
	}

	private void UpdateEnabled(Control c)
	{
		if (c != null)
		{
			bool enabled = _ribbonTextBox.Enabled;
			if (!_ribbon.InDesignHelperMode && _ribbonTextBox.TextBoxDesigner != null)
			{
				enabled = _ribbonTextBox.TextBoxDesigner.DesignEnabled;
			}
			c.Enabled = enabled;
		}
	}

	private bool ActualVisible(Control c)
	{
		if (c != null)
		{
			bool result = _ribbonTextBox.Visible;
			if (!_ribbon.InDesignHelperMode && _ribbonTextBox.TextBoxDesigner != null)
			{
				result = _ribbonTextBox.TextBoxDesigner.DesignVisible;
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
		bool flag = _ribbonTextBox.Visible;
		if (!_ribbon.InDesignHelperMode && _ribbonTextBox.TextBoxDesigner != null)
		{
			flag = _ribbonTextBox.TextBoxDesigner.DesignVisible;
		}
		if (flag)
		{
			if (_ribbonTextBox.RibbonTab == null || _ribbon.SelectedTab != _ribbonTextBox.RibbonTab)
			{
				flag = false;
			}
			else if (_ribbonTextBox.RibbonContainer != null && _ribbonTextBox.RibbonContainer.RibbonGroup != null && !_ribbonTextBox.RibbonContainer.RibbonGroup.Visible && !_ribbon.InDesignMode)
			{
				flag = false;
			}
			else if (_ribbonTextBox.RibbonContainer.RibbonGroup.IsCollapsed && (_ribbon.GetControllerControl(_ribbonTextBox.TextBox) is KryptonRibbon || _ribbon.GetControllerControl(_ribbonTextBox.TextBox) is VisualPopupMinimized))
			{
				flag = false;
			}
			else
			{
				for (KryptonRibbonGroupContainer ribbonContainer = _ribbonTextBox.RibbonContainer; ribbonContainer != null; ribbonContainer = ribbonContainer.RibbonContainer)
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
		if (_ribbonTextBox != null)
		{
			UpdateVisible(LastTextBox);
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
