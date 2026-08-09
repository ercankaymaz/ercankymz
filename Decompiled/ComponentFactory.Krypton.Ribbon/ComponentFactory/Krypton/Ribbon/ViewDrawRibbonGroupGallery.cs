#define DEBUG
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupGallery : ViewComposite, IRibbonViewGroupContainerView
{
	private static readonly int NULL_CONTROL_WIDTH = 50;

	private static readonly Padding _largeImagePadding = new Padding(3, 2, 3, 3);

	private KryptonRibbon _ribbon;

	private KryptonRibbonGroupGallery _ribbonGallery;

	private ViewDrawRibbonGroup _activeGroup;

	private GalleryController _controller;

	private NeedPaintHandler _needPaint;

	private GroupItemSize _currentSize;

	private ViewDrawRibbonGroupButtonBackBorder _viewLarge;

	private ViewLayoutRibbonRowCenter _viewLargeCenter;

	private ViewDrawRibbonGroupGalleryImage _viewLargeImage;

	private ViewDrawRibbonGroupGalleryText _viewLargeText1;

	private ViewDrawRibbonGroupGalleryText _viewLargeText2;

	private ViewDrawRibbonDropArrow _viewLargeDropArrow;

	private ViewLayoutRibbonSeparator _viewLargeText2Sep1;

	private ViewLayoutRibbonSeparator _viewLargeText2Sep2;

	public KryptonRibbonGroupGallery GroupGallery => _ribbonGallery;

	private Control LastParentControl
	{
		get
		{
			return _ribbonGallery.LastParentControl;
		}
		set
		{
			_ribbonGallery.LastParentControl = value;
		}
	}

	private KryptonGallery LastGallery
	{
		get
		{
			return _ribbonGallery.LastGallery;
		}
		set
		{
			_ribbonGallery.LastGallery = value;
		}
	}

	public ViewDrawRibbonGroupGallery(KryptonRibbon ribbon, KryptonRibbonGroupGallery ribbonGallery, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(ribbonGallery != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_ribbonGallery = ribbonGallery;
		_needPaint = needPaint;
		_currentSize = _ribbonGallery.ItemSizeCurrent;
		CreateLargeButtonView();
		_ribbonGallery.MouseEnterControl += OnMouseEnterControl;
		_ribbonGallery.MouseLeaveControl += OnMouseLeaveControl;
		Component = _ribbonGallery;
		if (_ribbon.InDesignMode)
		{
			ContextClickController contextClickController = new ContextClickController();
			contextClickController.ContextClick += OnContextClick;
			MouseController = contextClickController;
		}
		_controller = new GalleryController(_ribbon, _ribbonGallery, this);
		SourceController = _controller;
		KeyController = _controller;
		_ribbon.ViewRibbonManager.LayoutBefore += OnLayoutAction;
		_ribbon.ViewRibbonManager.LayoutAfter += OnLayoutAction;
		_ribbonGallery.GalleryView = this;
		_ribbonGallery.ViewPaintDelegate = needPaint;
		_ribbonGallery.PropertyChanged += OnGalleryPropertyChanged;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupGallery:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _ribbonGallery != null)
		{
			if (_ribbonGallery.LastGallery != null)
			{
				_ribbonGallery.LastGallery.Ribbon = null;
			}
			_ribbonGallery.MouseEnterControl -= OnMouseEnterControl;
			_ribbonGallery.MouseLeaveControl -= OnMouseLeaveControl;
			_ribbonGallery.ViewPaintDelegate = null;
			_ribbonGallery.PropertyChanged -= OnGalleryPropertyChanged;
			_ribbon.ViewRibbonManager.LayoutAfter -= OnLayoutAction;
			_ribbon.ViewRibbonManager.LayoutBefore -= OnLayoutAction;
			_ribbonGallery.GalleryView = null;
			_ribbonGallery = null;
		}
		base.Dispose(disposing);
	}

	public void KeyTipSelect()
	{
		if (_ribbonGallery.LastGallery != null)
		{
			_ribbonGallery.LastGallery.ShownGalleryDropDown(_ribbonGallery.LastGallery.RectangleToScreen(_ribbonGallery.LastGallery.ClientRectangle), KryptonContextMenuPositionH.Left, KryptonContextMenuPositionV.Top, null, _ribbonGallery.DropButtonItemWidth);
		}
	}

	public override void LostFocus(Control c)
	{
		_ribbon.HideFocus(_ribbonGallery.Gallery);
		base.LostFocus(c);
	}

	public ViewBase GetFirstFocusItem()
	{
		if (_viewLarge.Visible)
		{
			if (_ribbonGallery.Visible && _ribbonGallery.Enabled)
			{
				return _viewLarge;
			}
		}
		else if (_ribbonGallery.Visible && _ribbonGallery.LastGallery != null && _ribbonGallery.LastGallery.CanSelect)
		{
			return this;
		}
		return null;
	}

	public ViewBase GetLastFocusItem()
	{
		if (_viewLarge.Visible)
		{
			if (_ribbonGallery.Visible && _ribbonGallery.Enabled)
			{
				return _viewLarge;
			}
		}
		else if (_ribbonGallery.Visible && _ribbonGallery.LastGallery != null && _ribbonGallery.LastGallery.CanSelect)
		{
			return this;
		}
		return null;
	}

	public ViewBase GetNextFocusItem(ViewBase current, ref bool matched)
	{
		matched = current == this || current == _viewLarge;
		return null;
	}

	public ViewBase GetPreviousFocusItem(ViewBase current, ref bool matched)
	{
		matched = current == this || current == _viewLarge;
		return null;
	}

	public void GetGroupKeyTips(KeyTipInfoList keyTipList)
	{
		if (_ribbonGallery.Visible)
		{
			if (_viewLarge.Visible)
			{
				Rectangle rectangle = _ribbon.KeyTipToScreen(_viewLarge);
				keyTipList.Add(new KeyTipInfo(_ribbonGallery.Enabled, _ribbonGallery.KeyTip, new Point(rectangle.Left + rectangle.Width / 2, rectangle.Bottom), ClientRectangle, _viewLarge.Controller));
			}
			else if (LastGallery.CanFocus)
			{
				Rectangle rectangle2 = _ribbon.KeyTipToScreen(this);
				keyTipList.Add(new KeyTipInfo(_ribbonGallery.Enabled, _ribbonGallery.KeyTip, new Point(rectangle2.Left + rectangle2.Width / 2, rectangle2.Bottom), ClientRectangle, _controller));
			}
		}
	}

	public ItemSizeWidth[] GetPossibleSizes(ViewLayoutContext context)
	{
		UpdateParent(context.Control);
		if (LastGallery != null)
		{
			Size preferredItemSize = LastGallery.PreferredItemSize;
			GroupItemSize currentSize = _currentSize;
			List<ItemSizeWidth> list = new List<ItemSizeWidth>();
			if (_ribbonGallery.ItemSizeMaximum == GroupItemSize.Large)
			{
				int num = Math.Max(1, (_ribbonGallery.LargeItemCount - _ribbonGallery.MediumItemCount) / 20);
				for (int num2 = _ribbonGallery.LargeItemCount; num2 > _ribbonGallery.MediumItemCount; num2 -= num)
				{
					LastGallery.InternalPreferredItemSize = new Size(num2, 1);
					list.Add(new ItemSizeWidth(GroupItemSize.Large, GetPreferredSize(context).Width, num2));
				}
			}
			if (_ribbonGallery.ItemSizeMaximum >= GroupItemSize.Medium && _ribbonGallery.ItemSizeMinimum <= GroupItemSize.Medium)
			{
				LastGallery.InternalPreferredItemSize = new Size(_ribbonGallery.MediumItemCount, 1);
				ItemSizeWidth itemSizeWidth = new ItemSizeWidth(GroupItemSize.Medium, GetPreferredSize(context).Width);
				if (_ribbon.InDesignHelperMode)
				{
					if (list.Count == 0)
					{
						list.Add(itemSizeWidth);
					}
				}
				else if (list.Count == 0 || list[list.Count - 1].Width > itemSizeWidth.Width)
				{
					list.Add(itemSizeWidth);
				}
			}
			if (_ribbonGallery.ItemSizeMinimum == GroupItemSize.Small)
			{
				_viewLarge.Visible = true;
				_currentSize = GroupItemSize.Small;
				ItemSizeWidth itemSizeWidth2 = new ItemSizeWidth(GroupItemSize.Small, GetPreferredSize(context).Width);
				if (_ribbon.InDesignHelperMode)
				{
					if (list.Count == 0)
					{
						list.Add(itemSizeWidth2);
					}
				}
				else if (list.Count == 0 || list[list.Count - 1].Width > itemSizeWidth2.Width)
				{
					list.Add(itemSizeWidth2);
				}
			}
			LastGallery.InternalPreferredItemSize = preferredItemSize;
			_currentSize = currentSize;
			return list.ToArray();
		}
		return new ItemSizeWidth[1]
		{
			new ItemSizeWidth(GroupItemSize.Large, NULL_CONTROL_WIDTH)
		};
	}

	public void SetSolutionSize(ItemSizeWidth size)
	{
		_ribbonGallery.ItemSizeCurrent = size.GroupItemSize;
		_ribbonGallery.InternalItemCount = size.Tag;
		_viewLarge.Visible = size.GroupItemSize == GroupItemSize.Small;
	}

	public void ResetSolutionSize()
	{
		_ribbonGallery.ItemSizeCurrent = _ribbonGallery.ItemSizeMaximum;
		_ribbonGallery.InternalItemCount = _ribbonGallery.LargeItemCount;
		_viewLarge.Visible = _ribbonGallery.ItemSizeCurrent == GroupItemSize.Small;
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Size result = Size.Empty;
		UpdateParent(context.Control);
		if (_currentSize == GroupItemSize.Small)
		{
			result = base.GetPreferredSize(context);
		}
		else if (LastGallery != null)
		{
			if (ActualVisible(LastGallery))
			{
				result = LastGallery.GetPreferredSize(context.DisplayRectangle.Size);
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
		if (!context.ViewManager.DoNotLayoutControls && LastGallery != null)
		{
			LastGallery.SetBounds(ClientLocation.X + 1, ClientLocation.Y + 1, ClientWidth - 2, ClientHeight - 2);
		}
		base.Layout(context);
	}

	public override void Render(RenderContext context)
	{
		Debug.Assert(context != null);
		if (_ribbonGallery.Gallery == null && _ribbon.InDesignMode)
		{
			Rectangle clientRectangle = ClientRectangle;
			clientRectangle.Inflate(-1, -1);
			clientRectangle.Height--;
			context.Graphics.FillRectangle(Brushes.Goldenrod, clientRectangle);
			context.Graphics.DrawRectangle(Pens.Gold, clientRectangle);
		}
		base.Render(context);
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

	private void CreateLargeButtonView()
	{
		_viewLarge = new ViewDrawRibbonGroupButtonBackBorder(_ribbon, _ribbonGallery, _ribbon.StateCommon.RibbonGroupButton.PaletteBack, _ribbon.StateCommon.RibbonGroupButton.PaletteBorder, constantBorder: false, _needPaint);
		_viewLarge.ButtonType = GroupButtonType.DropDown;
		_viewLarge.DropDown += OnLargeButtonDropDown;
		if (_ribbon.InDesignMode)
		{
			_viewLarge.ContextClick += OnContextClick;
		}
		ViewLayoutDocker viewLayoutDocker = new ViewLayoutDocker();
		_viewLargeImage = new ViewDrawRibbonGroupGalleryImage(_ribbon, _ribbonGallery);
		ViewLayoutRibbonCenterPadding viewLayoutRibbonCenterPadding = new ViewLayoutRibbonCenterPadding(_largeImagePadding);
		viewLayoutRibbonCenterPadding.Add(_viewLargeImage);
		viewLayoutDocker.Add(viewLayoutRibbonCenterPadding, ViewDockStyle.Top);
		_viewLargeText1 = new ViewDrawRibbonGroupGalleryText(_ribbon, _ribbonGallery, firstText: true);
		viewLayoutDocker.Add(_viewLargeText1, ViewDockStyle.Bottom);
		_viewLargeCenter = new ViewLayoutRibbonRowCenter();
		_viewLargeText2 = new ViewDrawRibbonGroupGalleryText(_ribbon, _ribbonGallery, firstText: false);
		_viewLargeDropArrow = new ViewDrawRibbonDropArrow(_ribbon);
		_viewLargeText2Sep1 = new ViewLayoutRibbonSeparator(4, ignoreMouse: false);
		_viewLargeText2Sep2 = new ViewLayoutRibbonSeparator(4, ignoreMouse: false);
		_viewLargeCenter.Add(_viewLargeText2);
		_viewLargeCenter.Add(_viewLargeText2Sep1);
		_viewLargeCenter.Add(_viewLargeDropArrow);
		_viewLargeCenter.Add(_viewLargeText2Sep2);
		viewLayoutDocker.Add(_viewLargeCenter, ViewDockStyle.Bottom);
		viewLayoutDocker.Add(new ViewLayoutRibbonSeparator(1, ignoreMouse: false), ViewDockStyle.Bottom);
		_viewLarge.Add(viewLayoutDocker);
		_viewLarge.MouseController = new ToolTipController(_ribbon.TabsArea.ButtonSpecManager.ToolTipManager, _viewLarge, _viewLarge.MouseController);
		_viewLarge.Visible = false;
		Add(_viewLarge);
	}

	private void OnLargeButtonDropDown(object sender, EventArgs e)
	{
		if (_ribbonGallery.LastGallery != null)
		{
			_ribbonGallery.LastGallery.ShownGalleryDropDown(_ribbon.ViewRectangleToScreen(_viewLarge), KryptonContextMenuPositionH.Left, KryptonContextMenuPositionV.Below, _viewLarge.FinishDelegate, _ribbonGallery.DropButtonItemWidth);
		}
	}

	private void OnContextClick(object sender, MouseEventArgs e)
	{
		_ribbonGallery.OnDesignTimeContextMenu(e);
	}

	private void OnGalleryPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		bool flag = false;
		bool flag2 = false;
		switch (e.PropertyName)
		{
		case "TextLine1":
			_viewLargeText1.MakeDirty();
			flag = true;
			break;
		case "TextLine2":
			_viewLargeText2.MakeDirty();
			flag = true;
			break;
		case "ImageLarge":
		case "ImageList":
		case "LargeItemCount":
		case "MediumItemCount":
		case "ItemSizeMinimum":
		case "ItemSizeMaximum":
		case "ItemSizeCurrent":
			flag = true;
			break;
		case "Enabled":
			UpdateEnabled(LastGallery);
			break;
		case "Visible":
			UpdateVisible(LastGallery);
			flag = true;
			break;
		}
		if (flag && _ribbonGallery.RibbonTab != null && _ribbon.SelectedTab == _ribbonGallery.RibbonTab)
		{
			OnNeedPaint(needLayout: true);
		}
		if (flag2 && (_ribbonGallery.Visible || _ribbon.InDesignMode) && _ribbonGallery.RibbonTab != null && _ribbon.SelectedTab == _ribbonGallery.RibbonTab)
		{
			OnNeedPaint(needLayout: false, ClientRectangle);
		}
	}

	private void UpdateParent(Control parentControl)
	{
		if ((parentControl != LastParentControl || LastGallery != _ribbonGallery.Gallery) && ((_ribbonGallery.RibbonGroup.ShowingAsPopup && parentControl is VisualPopupGroup) || (!_ribbonGallery.RibbonGroup.ShowingAsPopup && !(parentControl is VisualPopupGroup))))
		{
			if (LastGallery != null && LastParentControl != null && LastParentControl.Controls.Contains(LastGallery))
			{
				LastParentControl.Controls.Remove(LastGallery);
			}
			if (LastGallery != null)
			{
				LastGallery.Ribbon = null;
			}
			LastGallery = _ribbonGallery.Gallery;
			LastParentControl = parentControl;
			if (LastGallery != null)
			{
				LastGallery.Ribbon = _ribbon;
			}
			if (LastGallery != null && LastParentControl != null)
			{
				LastGallery.Location = new Point(-LastGallery.Width, -LastGallery.Height);
				UpdateVisible(LastGallery);
				UpdateEnabled(LastGallery);
				LastParentControl.Controls.Add(LastGallery);
			}
		}
	}

	private void UpdateEnabled(Control c)
	{
		if (c != null)
		{
			bool enabled = _ribbonGallery.Enabled;
			if (!_ribbon.InDesignHelperMode && _ribbonGallery.GalleryDesigner != null)
			{
				enabled = _ribbonGallery.GalleryDesigner.DesignEnabled;
			}
			c.Enabled = enabled;
		}
	}

	private bool ActualVisible(Control c)
	{
		if (c != null)
		{
			bool result = _ribbonGallery.Visible;
			if (!_ribbon.InDesignHelperMode && _ribbonGallery.GalleryDesigner != null)
			{
				result = _ribbonGallery.GalleryDesigner.DesignVisible;
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
		bool flag = _ribbonGallery.Visible;
		if (!_ribbon.InDesignHelperMode && _ribbonGallery.GalleryDesigner != null)
		{
			flag = _ribbonGallery.GalleryDesigner.DesignVisible;
		}
		if (flag)
		{
			if (_ribbonGallery.RibbonTab == null || _ribbon.SelectedTab != _ribbonGallery.RibbonTab)
			{
				flag = false;
			}
			else if (_ribbonGallery.RibbonGroup != null && !_ribbonGallery.RibbonGroup.Visible && !_ribbon.InDesignMode)
			{
				flag = false;
			}
			else if (_ribbonGallery.RibbonGroup.IsCollapsed && (_ribbon.GetControllerControl(_ribbonGallery.Gallery) is KryptonRibbon || _ribbon.GetControllerControl(_ribbonGallery.Gallery) is VisualPopupMinimized))
			{
				flag = false;
			}
		}
		c.Visible = flag && _ribbonGallery.ItemSizeCurrent != GroupItemSize.Small;
	}

	private void OnLayoutAction(object sender, EventArgs e)
	{
		if (_ribbonGallery != null)
		{
			UpdateVisible(LastGallery);
			UpdateEnabled(LastGallery);
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
