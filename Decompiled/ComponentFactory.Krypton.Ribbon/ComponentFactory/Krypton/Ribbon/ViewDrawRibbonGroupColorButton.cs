#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupColorButton : ViewComposite, IRibbonViewGroupItemView
{
	private static readonly Padding _largeImagePadding = new Padding(3, 2, 3, 3);

	private static readonly Padding _smallImagePadding = new Padding(3);

	private KryptonRibbon _ribbon;

	private KryptonRibbonGroupColorButton _ribbonColorButton;

	private NeedPaintHandler _needPaint;

	private ViewDrawRibbonGroupButtonBackBorder _viewLarge;

	private ViewLayoutRibbonRowCenter _viewLargeCenter;

	private ViewDrawRibbonGroupColorButtonImage _viewLargeImage;

	private ViewDrawRibbonGroupColorButtonText _viewLargeText1;

	private ViewDrawRibbonGroupColorButtonText _viewLargeText2;

	private ViewDrawRibbonDropArrow _viewLargeDropArrow;

	private ViewLayoutRibbonSeparator _viewLargeText2Sep1;

	private ViewLayoutRibbonSeparator _viewLargeText2Sep2;

	private ViewDrawRibbonGroupButtonBackBorder _viewMediumSmall;

	private ViewLayoutRibbonRowCenter _viewMediumSmallCenter;

	private ViewDrawRibbonGroupColorButtonImage _viewMediumSmallImage;

	private ViewDrawRibbonGroupColorButtonText _viewMediumSmallText1;

	private ViewDrawRibbonGroupColorButtonText _viewMediumSmallText2;

	private ViewDrawRibbonDropArrow _viewMediumSmallDropArrow;

	private ViewLayoutRibbonSeparator _viewMediumSmallText2Sep2;

	private ViewLayoutRibbonSeparator _viewMediumSmallText2Sep3;

	private GroupItemSize _currentSize;

	public KryptonRibbonGroupColorButton GroupColorButton => _ribbonColorButton;

	public ViewDrawRibbonGroupColorButton(KryptonRibbon ribbon, KryptonRibbonGroupColorButton ribbonColorButton, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(ribbonColorButton != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_ribbonColorButton = ribbonColorButton;
		_needPaint = needPaint;
		_currentSize = _ribbonColorButton.ItemSizeCurrent;
		Component = _ribbonColorButton;
		CreateLargeButtonView();
		CreateMediumSmallButtonView();
		UpdateEnabledState();
		UpdateCheckedState();
		UpdateDropDownState();
		UpdateItemSizeState();
		_ribbonColorButton.PropertyChanged += OnButtonPropertyChanged;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupColorButton:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _ribbonColorButton != null)
		{
			_ribbonColorButton.PropertyChanged -= OnButtonPropertyChanged;
			_ribbonColorButton.ColorButtonView = null;
			_ribbonColorButton = null;
		}
		base.Dispose(disposing);
	}

	public ViewBase GetFirstFocusItem()
	{
		if (_ribbonColorButton.Visible && _ribbonColorButton.Enabled)
		{
			if (_viewLarge == _ribbonColorButton.ColorButtonView)
			{
				return _viewLarge;
			}
			return _viewMediumSmall;
		}
		return null;
	}

	public ViewBase GetLastFocusItem()
	{
		if (_ribbonColorButton.Visible && _ribbonColorButton.Enabled)
		{
			if (_viewLarge == _ribbonColorButton.ColorButtonView)
			{
				return _viewLarge;
			}
			return _viewMediumSmall;
		}
		return null;
	}

	public ViewBase GetNextFocusItem(ViewBase current, ref bool matched)
	{
		matched = current == _viewLarge || current == _viewMediumSmall;
		return null;
	}

	public ViewBase GetPreviousFocusItem(ViewBase current, ref bool matched)
	{
		matched = current == _viewLarge || current == _viewMediumSmall;
		return null;
	}

	public void GetGroupKeyTips(KeyTipInfoList keyTipList, int lineHint)
	{
		if (Visible)
		{
			Rectangle viewRect = _ribbon.KeyTipToScreen(this[0]);
			Point screenPt = Point.Empty;
			GroupButtonController target = null;
			switch (_currentSize)
			{
			case GroupItemSize.Large:
				screenPt = new Point(viewRect.Left + viewRect.Width / 2, viewRect.Bottom);
				target = _viewLarge.Controller;
				break;
			case GroupItemSize.Small:
			case GroupItemSize.Medium:
				screenPt = _ribbon.CalculatedValues.KeyTipRectToPoint(viewRect, lineHint);
				target = _viewMediumSmall.Controller;
				break;
			}
			keyTipList.Add(new KeyTipInfo(_ribbonColorButton.Enabled, _ribbonColorButton.KeyTip, screenPt, this[0].ClientRectangle, target));
		}
	}

	public void SetGroupItemSize(GroupItemSize size)
	{
		UpdateItemSizeState(size);
	}

	public void ResetGroupItemSize()
	{
		UpdateItemSizeState();
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		bool drawNonTrackingAreas = _ribbon.RibbonShape != PaletteRibbonShape.Office2010;
		_viewLarge.ButtonType = _ribbonColorButton.ButtonType;
		_viewLarge.DrawNonTrackingAreas = drawNonTrackingAreas;
		_viewMediumSmall.ButtonType = _ribbonColorButton.ButtonType;
		_viewMediumSmall.DrawNonTrackingAreas = drawNonTrackingAreas;
		Size preferredSize = base.GetPreferredSize(context);
		if (_currentSize == GroupItemSize.Large)
		{
			preferredSize.Height = _ribbon.CalculatedValues.GroupTripleHeight;
		}
		else
		{
			preferredSize.Height = _ribbon.CalculatedValues.GroupLineHeight;
		}
		return preferredSize;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		UpdateEnabledState();
		UpdateCheckedState();
		UpdateDropDownState();
		ClientRectangle = context.DisplayRectangle;
		base.Layout(context);
		if (_ribbonColorButton.ButtonType == GroupButtonType.Split)
		{
			int num = _viewLargeImage.ClientRectangle.Bottom + 2;
			int x = _viewMediumSmallText2Sep2.ClientLocation.X;
			_viewLarge.SplitRectangle = new Rectangle(ClientLocation.X, num, ClientWidth, ClientRectangle.Bottom - num);
			_viewMediumSmall.SplitRectangle = new Rectangle(x, ClientLocation.Y, ClientRectangle.Right - x, ClientHeight);
		}
		else
		{
			_viewLarge.SplitRectangle = Rectangle.Empty;
			_viewMediumSmall.SplitRectangle = Rectangle.Empty;
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
			_needPaint(this, new NeedLayoutEventArgs(needLayout, invalidRect));
			if (needLayout)
			{
				_ribbon.PerformLayout();
			}
		}
	}

	private void CreateLargeButtonView()
	{
		_viewLarge = new ViewDrawRibbonGroupButtonBackBorder(_ribbon, _ribbonColorButton, _ribbon.StateCommon.RibbonGroupButton.PaletteBack, _ribbon.StateCommon.RibbonGroupButton.PaletteBorder, constantBorder: false, _needPaint);
		_viewLarge.SplitVertical = true;
		_viewLarge.Click += OnLargeButtonClick;
		_viewLarge.DropDown += OnLargeButtonDropDown;
		if (_ribbon.InDesignMode)
		{
			_viewLarge.ContextClick += OnContextClick;
		}
		ViewLayoutDocker viewLayoutDocker = new ViewLayoutDocker();
		_viewLargeImage = new ViewDrawRibbonGroupColorButtonImage(_ribbon, _ribbonColorButton, large: true);
		ViewLayoutRibbonCenterPadding viewLayoutRibbonCenterPadding = new ViewLayoutRibbonCenterPadding(_largeImagePadding);
		viewLayoutRibbonCenterPadding.Add(_viewLargeImage);
		viewLayoutDocker.Add(viewLayoutRibbonCenterPadding, ViewDockStyle.Top);
		_viewLargeText1 = new ViewDrawRibbonGroupColorButtonText(_ribbon, _ribbonColorButton, firstText: true);
		viewLayoutDocker.Add(_viewLargeText1, ViewDockStyle.Bottom);
		_viewLargeCenter = new ViewLayoutRibbonRowCenter();
		_viewLargeText2 = new ViewDrawRibbonGroupColorButtonText(_ribbon, _ribbonColorButton, firstText: false);
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
	}

	private void CreateMediumSmallButtonView()
	{
		_viewMediumSmall = new ViewDrawRibbonGroupButtonBackBorder(_ribbon, _ribbonColorButton, _ribbon.StateCommon.RibbonGroupButton.PaletteBack, _ribbon.StateCommon.RibbonGroupButton.PaletteBorder, constantBorder: false, _needPaint);
		_viewMediumSmall.SplitVertical = false;
		_viewMediumSmall.Click += OnMediumSmallButtonClick;
		_viewMediumSmall.DropDown += OnMediumSmallButtonDropDown;
		if (_ribbon.InDesignMode)
		{
			_viewMediumSmall.ContextClick += OnContextClick;
		}
		ViewLayoutDocker viewLayoutDocker = new ViewLayoutDocker();
		_viewMediumSmallImage = new ViewDrawRibbonGroupColorButtonImage(_ribbon, _ribbonColorButton, large: false);
		_viewMediumSmallText1 = new ViewDrawRibbonGroupColorButtonText(_ribbon, _ribbonColorButton, firstText: true);
		_viewMediumSmallText2 = new ViewDrawRibbonGroupColorButtonText(_ribbon, _ribbonColorButton, firstText: false);
		_viewMediumSmallDropArrow = new ViewDrawRibbonDropArrow(_ribbon);
		_viewMediumSmallText2Sep2 = new ViewLayoutRibbonSeparator(3, ignoreMouse: false);
		_viewMediumSmallText2Sep3 = new ViewLayoutRibbonSeparator(3, ignoreMouse: false);
		ViewLayoutRibbonCenterPadding viewLayoutRibbonCenterPadding = new ViewLayoutRibbonCenterPadding(_smallImagePadding);
		viewLayoutRibbonCenterPadding.Add(_viewMediumSmallImage);
		_viewMediumSmallCenter = new ViewLayoutRibbonRowCenter();
		_viewMediumSmallCenter.Add(viewLayoutRibbonCenterPadding);
		_viewMediumSmallCenter.Add(_viewMediumSmallText1);
		_viewMediumSmallCenter.Add(_viewMediumSmallText2);
		_viewMediumSmallCenter.Add(_viewMediumSmallText2Sep2);
		_viewMediumSmallCenter.Add(_viewMediumSmallDropArrow);
		_viewMediumSmallCenter.Add(_viewMediumSmallText2Sep3);
		viewLayoutDocker.Add(_viewMediumSmallCenter, ViewDockStyle.Fill);
		_viewMediumSmall.Add(viewLayoutDocker);
		_viewMediumSmall.MouseController = new ToolTipController(_ribbon.TabsArea.ButtonSpecManager.ToolTipManager, _viewMediumSmall, _viewMediumSmall.MouseController);
	}

	private void DefineRootView(ViewBase view)
	{
		Clear();
		Add(view);
		_ribbonColorButton.ColorButtonView = view;
	}

	private void UpdateEnabledState()
	{
		bool enabled = _ribbonColorButton.Enabled;
		if (_ribbonColorButton.KryptonCommand != null)
		{
			enabled = _ribbonColorButton.KryptonCommand.Enabled;
		}
		bool enabled2 = _ribbon.InDesignHelperMode || (enabled && _ribbon.Enabled);
		_viewLarge.Enabled = enabled2;
		_viewLargeImage.Enabled = enabled2;
		_viewLargeText1.Enabled = enabled2;
		_viewLargeText2.Enabled = enabled2;
		_viewLargeDropArrow.Enabled = enabled2;
		_viewMediumSmall.Enabled = enabled2;
		_viewMediumSmallText1.Enabled = enabled2;
		_viewMediumSmallText2.Enabled = enabled2;
		_viewMediumSmallImage.Enabled = enabled2;
		_viewMediumSmallDropArrow.Enabled = enabled2;
	}

	private void UpdateCheckedState()
	{
		bool flag = false;
		if (_ribbonColorButton.ButtonType == GroupButtonType.Check)
		{
			flag = ((_ribbonColorButton.KryptonCommand == null) ? _ribbonColorButton.Checked : _ribbonColorButton.KryptonCommand.Checked);
		}
		_viewLarge.Checked = flag;
		_viewMediumSmall.Checked = flag;
	}

	private void UpdateDropDownState()
	{
		bool flag = _ribbonColorButton.ButtonType == GroupButtonType.DropDown || _ribbonColorButton.ButtonType == GroupButtonType.Split;
		bool visible = flag && !string.IsNullOrEmpty(_ribbonColorButton.TextLine2);
		_viewLargeDropArrow.Visible = flag;
		_viewLargeText2Sep1.Visible = visible;
		_viewLargeText2Sep2.Visible = visible;
		_viewMediumSmallDropArrow.Visible = flag;
		_viewMediumSmallText2Sep2.Visible = flag;
		_viewMediumSmallText2Sep3.Visible = flag;
	}

	private void UpdateItemSizeState()
	{
		UpdateItemSizeState(_ribbonColorButton.ItemSizeCurrent);
	}

	private void UpdateItemSizeState(GroupItemSize size)
	{
		_currentSize = size;
		switch (size)
		{
		case GroupItemSize.Small:
		case GroupItemSize.Medium:
		{
			bool visible = size == GroupItemSize.Medium;
			_viewMediumSmallCenter.CurrentSize = size;
			_viewMediumSmallText1.Visible = visible;
			_viewMediumSmallText2.Visible = visible;
			DefineRootView(_viewMediumSmall);
			break;
		}
		case GroupItemSize.Large:
			_viewLargeCenter.CurrentSize = size;
			DefineRootView(_viewLarge);
			break;
		}
	}

	private void OnLargeButtonClick(object sender, EventArgs e)
	{
		GroupColorButton.PerformClick(_viewLarge.FinishDelegate);
	}

	private void OnLargeButtonDropDown(object sender, EventArgs e)
	{
		GroupColorButton.PerformDropDown(_viewLarge.FinishDelegate);
	}

	private void OnMediumSmallButtonClick(object sender, EventArgs e)
	{
		GroupColorButton.PerformClick(_viewMediumSmall.FinishDelegate);
	}

	private void OnMediumSmallButtonDropDown(object sender, EventArgs e)
	{
		GroupColorButton.PerformDropDown(_viewMediumSmall.FinishDelegate);
	}

	private void OnContextClick(object sender, MouseEventArgs e)
	{
		GroupColorButton.OnDesignTimeContextMenu(e);
	}

	private void OnButtonPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		bool flag = false;
		bool flag2 = false;
		switch (e.PropertyName)
		{
		case "SelectedColor":
		case "EmptyBorderColor":
		case "SelectedRectSmall":
		case "SelectedRectLarge":
			_viewMediumSmallImage.SelectedColorRectChanged();
			_viewLargeImage.SelectedColorRectChanged();
			flag2 = true;
			break;
		case "Visible":
			flag = true;
			break;
		case "TextLine1":
			_viewLargeText1.MakeDirty();
			_viewMediumSmallText1.MakeDirty();
			flag = true;
			break;
		case "TextLine2":
			_viewLargeText2.MakeDirty();
			_viewMediumSmallText2.MakeDirty();
			UpdateDropDownState();
			flag = true;
			break;
		case "ButtonType":
			UpdateDropDownState();
			flag = true;
			break;
		case "Checked":
			UpdateCheckedState();
			flag2 = true;
			break;
		case "Enabled":
			UpdateEnabledState();
			flag2 = true;
			break;
		case "ImageLarge":
		case "ImageSmall":
			_viewMediumSmallImage.SelectedColorRectChanged();
			_viewLargeImage.SelectedColorRectChanged();
			flag2 = true;
			break;
		case "ItemSizeMinimum":
		case "ItemSizeMaximum":
		case "ItemSizeCurrent":
			UpdateItemSizeState();
			flag = true;
			break;
		case "KryptonCommand":
			_viewLargeText1.MakeDirty();
			_viewLargeText2.MakeDirty();
			_viewLargeImage.SelectedColorRectChanged();
			_viewMediumSmallText1.MakeDirty();
			_viewMediumSmallText2.MakeDirty();
			_viewMediumSmallImage.SelectedColorRectChanged();
			UpdateEnabledState();
			UpdateCheckedState();
			flag = true;
			break;
		}
		if (flag && _ribbonColorButton.RibbonTab != null && _ribbon.SelectedTab == _ribbonColorButton.RibbonTab)
		{
			OnNeedPaint(needLayout: true);
		}
		if (flag2 && (_ribbonColorButton.Visible || _ribbon.InDesignMode) && _ribbonColorButton.RibbonTab != null && _ribbon.SelectedTab == _ribbonColorButton.RibbonTab)
		{
			OnNeedPaint(needLayout: false, ClientRectangle);
		}
	}
}
