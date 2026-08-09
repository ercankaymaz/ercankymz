#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupTrackBar : ViewComposite, IRibbonViewGroupItemView
{
	private static readonly int NULL_CONTROL_WIDTH = 50;

	private KryptonRibbon _ribbon;

	private KryptonRibbonGroupTrackBar _ribbonTrackBar;

	private ViewDrawRibbonGroup _activeGroup;

	private TrackBarController _controller;

	private NeedPaintHandler _needPaint;

	private GroupItemSize _currentSize;

	public KryptonRibbonGroupTrackBar GroupTrackBar => _ribbonTrackBar;

	private Control LastParentControl
	{
		get
		{
			return _ribbonTrackBar.LastParentControl;
		}
		set
		{
			_ribbonTrackBar.LastParentControl = value;
		}
	}

	private KryptonTrackBar LastTrackBar
	{
		get
		{
			return _ribbonTrackBar.LastTrackBar;
		}
		set
		{
			_ribbonTrackBar.LastTrackBar = value;
		}
	}

	public ViewDrawRibbonGroupTrackBar(KryptonRibbon ribbon, KryptonRibbonGroupTrackBar ribbonTrackBar, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(ribbonTrackBar != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_ribbonTrackBar = ribbonTrackBar;
		_needPaint = needPaint;
		_currentSize = _ribbonTrackBar.ItemSizeCurrent;
		_ribbonTrackBar.MouseEnterControl += OnMouseEnterControl;
		_ribbonTrackBar.MouseLeaveControl += OnMouseLeaveControl;
		Component = _ribbonTrackBar;
		if (_ribbon.InDesignMode)
		{
			ContextClickController contextClickController = new ContextClickController();
			contextClickController.ContextClick += OnContextClick;
			MouseController = contextClickController;
		}
		_controller = new TrackBarController(_ribbon, _ribbonTrackBar, this);
		SourceController = _controller;
		KeyController = _controller;
		_ribbon.ViewRibbonManager.LayoutBefore += OnLayoutAction;
		_ribbon.ViewRibbonManager.LayoutAfter += OnLayoutAction;
		_ribbonTrackBar.TrackBarView = this;
		_ribbonTrackBar.ViewPaintDelegate = needPaint;
		_ribbonTrackBar.PropertyChanged += OnTextBoxPropertyChanged;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupTrackBar:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _ribbonTrackBar != null)
		{
			_ribbonTrackBar.MouseEnterControl -= OnMouseEnterControl;
			_ribbonTrackBar.MouseLeaveControl -= OnMouseLeaveControl;
			_ribbonTrackBar.ViewPaintDelegate = null;
			_ribbonTrackBar.PropertyChanged -= OnTextBoxPropertyChanged;
			_ribbon.ViewRibbonManager.LayoutAfter -= OnLayoutAction;
			_ribbon.ViewRibbonManager.LayoutBefore -= OnLayoutAction;
			_ribbonTrackBar.TrackBarView = null;
			_ribbonTrackBar = null;
		}
		base.Dispose(disposing);
	}

	public override void LostFocus(Control c)
	{
		_ribbon.HideFocus(_ribbonTrackBar.TrackBar);
		base.LostFocus(c);
	}

	public ViewBase GetFirstFocusItem()
	{
		if (_ribbonTrackBar.Visible && _ribbonTrackBar.LastTrackBar != null && _ribbonTrackBar.LastTrackBar.CanSelect)
		{
			return this;
		}
		return null;
	}

	public ViewBase GetLastFocusItem()
	{
		if (_ribbonTrackBar.Visible && _ribbonTrackBar.LastTrackBar != null && _ribbonTrackBar.LastTrackBar.CanSelect)
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
		if (Visible && LastTrackBar.CanFocus)
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
			keyTipList.Add(new KeyTipInfo(_ribbonTrackBar.Enabled, _ribbonTrackBar.KeyTip, screenPt, ClientRectangle, _controller));
		}
	}

	public void SetGroupItemSize(GroupItemSize size)
	{
		_currentSize = size;
	}

	public void ResetGroupItemSize()
	{
		_currentSize = _ribbonTrackBar.ItemSizeCurrent;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Size result = Size.Empty;
		UpdateParent(context.Control);
		if (LastTrackBar != null)
		{
			if (ActualVisible(LastTrackBar))
			{
				result = LastTrackBar.GetPreferredSize(context.DisplayRectangle.Size);
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
		if (!context.ViewManager.DoNotLayoutControls && LastTrackBar != null)
		{
			LastTrackBar.SetBounds(ClientLocation.X + 1, ClientLocation.Y + 1, ClientWidth - 2, ClientHeight - 2);
		}
		base.Layout(context);
	}

	public override void Render(RenderContext context)
	{
		Debug.Assert(context != null);
		if (_ribbonTrackBar.TrackBar == null && _ribbon.InDesignMode)
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
		_ribbonTrackBar.OnDesignTimeContextMenu(e);
	}

	private void OnTextBoxPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		bool flag = false;
		bool flag2 = false;
		switch (e.PropertyName)
		{
		case "Enabled":
			UpdateEnabled(LastTrackBar);
			break;
		case "Visible":
			UpdateVisible(LastTrackBar);
			flag = true;
			break;
		case "CustomControl":
			flag = true;
			break;
		}
		if (flag && _ribbonTrackBar.RibbonTab != null && _ribbon.SelectedTab == _ribbonTrackBar.RibbonTab)
		{
			OnNeedPaint(needLayout: true);
		}
		if (flag2 && (_ribbonTrackBar.Visible || _ribbon.InDesignMode) && _ribbonTrackBar.RibbonTab != null && _ribbon.SelectedTab == _ribbonTrackBar.RibbonTab)
		{
			OnNeedPaint(needLayout: false, ClientRectangle);
		}
	}

	private void UpdateParent(Control parentControl)
	{
		if ((parentControl != LastParentControl || LastTrackBar != _ribbonTrackBar.TrackBar) && ((_ribbonTrackBar.RibbonContainer.RibbonGroup.ShowingAsPopup && parentControl is VisualPopupGroup) || (!_ribbonTrackBar.RibbonContainer.RibbonGroup.ShowingAsPopup && !(parentControl is VisualPopupGroup))))
		{
			if (LastTrackBar != null && LastParentControl != null && LastParentControl.Controls.Contains(LastTrackBar))
			{
				LastParentControl.Controls.Remove(LastTrackBar);
			}
			LastTrackBar = _ribbonTrackBar.TrackBar;
			LastParentControl = parentControl;
			if (LastTrackBar != null && LastParentControl != null)
			{
				LastTrackBar.Location = new Point(-LastTrackBar.Width, -LastTrackBar.Height);
				UpdateVisible(LastTrackBar);
				LastParentControl.Controls.Add(LastTrackBar);
			}
		}
	}

	private void UpdateEnabled(Control c)
	{
		if (c != null)
		{
			bool enabled = _ribbonTrackBar.Enabled;
			if (!_ribbon.InDesignHelperMode && _ribbonTrackBar.TrackBarDesigner != null)
			{
				enabled = _ribbonTrackBar.TrackBarDesigner.DesignEnabled;
			}
			c.Enabled = enabled;
		}
	}

	private bool ActualVisible(Control c)
	{
		if (c != null)
		{
			bool result = _ribbonTrackBar.Visible;
			if (!_ribbon.InDesignHelperMode && _ribbonTrackBar.TrackBarDesigner != null)
			{
				result = _ribbonTrackBar.TrackBarDesigner.DesignVisible;
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
		bool flag = _ribbonTrackBar.Visible;
		if (!_ribbon.InDesignHelperMode && _ribbonTrackBar.TrackBarDesigner != null)
		{
			flag = _ribbonTrackBar.TrackBarDesigner.DesignVisible;
		}
		if (flag)
		{
			if (_ribbonTrackBar.RibbonTab == null || _ribbon.SelectedTab != _ribbonTrackBar.RibbonTab)
			{
				flag = false;
			}
			else if (_ribbonTrackBar.RibbonContainer != null && _ribbonTrackBar.RibbonContainer.RibbonGroup != null && !_ribbonTrackBar.RibbonContainer.RibbonGroup.Visible && !_ribbon.InDesignMode)
			{
				flag = false;
			}
			else if (_ribbonTrackBar.RibbonContainer.RibbonGroup.IsCollapsed && (_ribbon.GetControllerControl(_ribbonTrackBar.TrackBar) is KryptonRibbon || _ribbon.GetControllerControl(_ribbonTrackBar.TrackBar) is VisualPopupMinimized))
			{
				flag = false;
			}
			else
			{
				for (KryptonRibbonGroupContainer ribbonContainer = _ribbonTrackBar.RibbonContainer; ribbonContainer != null; ribbonContainer = ribbonContainer.RibbonContainer)
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
		if (_ribbonTrackBar != null)
		{
			UpdateVisible(LastTrackBar);
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
