#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupClusterColorButton : ViewComposite, IRibbonViewGroupItemView
{
	private static readonly Padding _smallImagePadding = new Padding(3);

	private KryptonRibbon _ribbon;

	private KryptonRibbonGroupClusterColorButton _ribbonColorButton;

	private NeedPaintHandler _needPaint;

	private PaletteBackInheritForced _backForced;

	private PaletteBorderInheritForced _borderForced;

	private ViewDrawRibbonGroupButtonBackBorder _viewMediumSmall;

	private ViewLayoutRibbonRowCenter _viewMediumSmallCenter;

	private ViewDrawRibbonGroupClusterColorButtonImage _viewMediumSmallImage;

	private ViewDrawRibbonGroupClusterColorButtonText _viewMediumSmallText1;

	private ViewDrawRibbonDropArrow _viewMediumSmallDropArrow;

	private ViewLayoutRibbonSeparator _viewMediumSmallText2Sep1;

	private ViewLayoutRibbonSeparator _viewMediumSmallText2Sep2;

	private GroupItemSize _currentSize;

	public KryptonRibbonGroupClusterColorButton GroupClusterColorButton => _ribbonColorButton;

	public PaletteDrawBorders MaxBorderEdges
	{
		get
		{
			return _borderForced.MaxBorderEdges;
		}
		set
		{
			_borderForced.MaxBorderEdges = value;
		}
	}

	public bool BorderIgnoreNormal
	{
		get
		{
			return _borderForced.BorderIgnoreNormal;
		}
		set
		{
			_backForced.BorderIgnoreNormal = value;
			_borderForced.BorderIgnoreNormal = value;
		}
	}

	public bool ConstantBorder
	{
		get
		{
			return _viewMediumSmall.ConstantBorder;
		}
		set
		{
			_viewMediumSmall.ConstantBorder = value;
		}
	}

	public bool DrawNonTrackingAreas
	{
		get
		{
			return _viewMediumSmall.DrawNonTrackingAreas;
		}
		set
		{
			_viewMediumSmall.DrawNonTrackingAreas = value;
		}
	}

	public ViewDrawRibbonGroupClusterColorButton(KryptonRibbon ribbon, KryptonRibbonGroupClusterColorButton ribbonButton, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(ribbonButton != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_ribbonColorButton = ribbonButton;
		_needPaint = needPaint;
		_currentSize = _ribbonColorButton.ItemSizeCurrent;
		Component = _ribbonColorButton;
		CreateView();
		UpdateEnabledState();
		UpdateCheckedState();
		UpdateDropDownState();
		UpdateItemSizeState();
		_ribbonColorButton.PropertyChanged += OnButtonPropertyChanged;
	}

	public override string ToString()
	{
		return "KryptonRibbonGroupClusterColorButton:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _ribbonColorButton != null)
		{
			_ribbonColorButton.PropertyChanged -= OnButtonPropertyChanged;
			_ribbonColorButton.ClusterColorButtonView = null;
			_ribbonColorButton = null;
		}
		base.Dispose(disposing);
	}

	public ViewBase GetFirstFocusItem()
	{
		if (_ribbonColorButton.Visible && _ribbonColorButton.Enabled)
		{
			return _viewMediumSmall;
		}
		return null;
	}

	public ViewBase GetLastFocusItem()
	{
		if (_ribbonColorButton.Visible && _ribbonColorButton.Enabled)
		{
			return _viewMediumSmall;
		}
		return null;
	}

	public ViewBase GetNextFocusItem(ViewBase current, ref bool matched)
	{
		matched = current == _viewMediumSmall;
		return null;
	}

	public ViewBase GetPreviousFocusItem(ViewBase current, ref bool matched)
	{
		matched = current == _viewMediumSmall;
		return null;
	}

	public void GetGroupKeyTips(KeyTipInfoList keyTipList, int lineHint)
	{
		if (Visible)
		{
			Rectangle viewRect = _ribbon.KeyTipToScreen(this[0]);
			Point screenPt = _ribbon.CalculatedValues.KeyTipRectToPoint(viewRect, lineHint);
			keyTipList.Add(new KeyTipInfo(_ribbonColorButton.Enabled, _ribbonColorButton.KeyTip, screenPt, this[0].ClientRectangle, _viewMediumSmall.Controller));
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
		Size preferredSize = base.GetPreferredSize(context);
		preferredSize.Height = _ribbon.CalculatedValues.GroupLineHeight;
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
			int x = _viewMediumSmallText2Sep1.ClientLocation.X;
			_viewMediumSmall.SplitRectangle = new Rectangle(x, ClientLocation.Y, ClientRectangle.Right - x, ClientHeight);
		}
		else
		{
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
			_needPaint(this, new NeedLayoutEventArgs(needLayout));
			if (needLayout)
			{
				_ribbon.PerformLayout();
			}
		}
	}

	private void CreateView()
	{
		_backForced = new PaletteBackInheritForced(_ribbon.StateCommon.RibbonGroupClusterButton.PaletteBack);
		_borderForced = new PaletteBorderInheritForced(_ribbon.StateCommon.RibbonGroupClusterButton.PaletteBorder);
		_viewMediumSmall = new ViewDrawRibbonGroupButtonBackBorder(_ribbon, _ribbonColorButton, _backForced, _borderForced, constantBorder: true, _needPaint);
		_viewMediumSmall.SplitVertical = false;
		_viewMediumSmall.Click += OnSmallButtonClick;
		_viewMediumSmall.DropDown += OnSmallButtonDropDown;
		if (_ribbon.InDesignMode)
		{
			_viewMediumSmall.ContextClick += OnContextClick;
		}
		ViewLayoutDocker viewLayoutDocker = new ViewLayoutDocker();
		_viewMediumSmallImage = new ViewDrawRibbonGroupClusterColorButtonImage(_ribbon, _ribbonColorButton);
		_viewMediumSmallText1 = new ViewDrawRibbonGroupClusterColorButtonText(_ribbon, _ribbonColorButton);
		_viewMediumSmallText1.Visible = _currentSize != GroupItemSize.Small;
		_viewMediumSmallDropArrow = new ViewDrawRibbonDropArrow(_ribbon);
		_viewMediumSmallText2Sep1 = new ViewLayoutRibbonSeparator(3, ignoreMouse: false);
		_viewMediumSmallText2Sep2 = new ViewLayoutRibbonSeparator(3, ignoreMouse: false);
		ViewLayoutRibbonCenterPadding viewLayoutRibbonCenterPadding = new ViewLayoutRibbonCenterPadding(_smallImagePadding);
		viewLayoutRibbonCenterPadding.Add(_viewMediumSmallImage);
		_viewMediumSmallCenter = new ViewLayoutRibbonRowCenter();
		_viewMediumSmallCenter.Add(viewLayoutRibbonCenterPadding);
		_viewMediumSmallCenter.Add(_viewMediumSmallText1);
		_viewMediumSmallCenter.Add(_viewMediumSmallText2Sep1);
		_viewMediumSmallCenter.Add(_viewMediumSmallDropArrow);
		_viewMediumSmallCenter.Add(_viewMediumSmallText2Sep2);
		viewLayoutDocker.Add(_viewMediumSmallCenter, ViewDockStyle.Fill);
		_viewMediumSmall.Add(viewLayoutDocker);
		_viewMediumSmall.MouseController = new ToolTipController(_ribbon.TabsArea.ButtonSpecManager.ToolTipManager, _viewMediumSmall, _viewMediumSmall.MouseController);
		_ribbonColorButton.ClusterColorButtonView = _viewMediumSmall;
		Add(_viewMediumSmall);
	}

	private void UpdateItemSizeState()
	{
		UpdateItemSizeState(_ribbonColorButton.ItemSizeCurrent);
	}

	private void UpdateItemSizeState(GroupItemSize size)
	{
		_currentSize = size;
		_viewMediumSmallCenter.CurrentSize = size;
		_viewMediumSmallText1.Visible = size != GroupItemSize.Small;
	}

	private void UpdateEnabledState()
	{
		bool enabled = _ribbonColorButton.Enabled;
		if (_ribbonColorButton.KryptonCommand != null)
		{
			enabled = _ribbonColorButton.KryptonCommand.Enabled;
		}
		bool enabled2 = _ribbon.InDesignHelperMode || (enabled && _ribbon.Enabled);
		_viewMediumSmall.Enabled = enabled2;
		_viewMediumSmallText1.Enabled = enabled2;
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
		_viewMediumSmall.Checked = flag;
	}

	private void UpdateDropDownState()
	{
		bool visible = _ribbonColorButton.ButtonType == GroupButtonType.DropDown || _ribbonColorButton.ButtonType == GroupButtonType.Split;
		_viewMediumSmallDropArrow.Visible = visible;
		_viewMediumSmallText2Sep2.Visible = visible;
		_viewMediumSmall.ButtonType = _ribbonColorButton.ButtonType;
	}

	private void OnSmallButtonClick(object sender, EventArgs e)
	{
		GroupClusterColorButton.PerformClick(_viewMediumSmall.FinishDelegate);
	}

	private void OnSmallButtonDropDown(object sender, EventArgs e)
	{
		GroupClusterColorButton.PerformDropDown(_viewMediumSmall.FinishDelegate);
	}

	private void OnContextClick(object sender, MouseEventArgs e)
	{
		GroupClusterColorButton.OnDesignTimeContextMenu(e);
	}

	private void OnButtonPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		bool flag = false;
		bool flag2 = false;
		switch (e.PropertyName)
		{
		case "SelectedColor":
		case "SelectedRect":
		case "EmptyBorderColor":
			_viewMediumSmallImage.SelectedColorRectChanged();
			flag2 = true;
			break;
		case "Visible":
			flag = true;
			break;
		case "TextLine":
			_viewMediumSmallText1.MakeDirty();
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
		case "ImageSmall":
			_viewMediumSmallImage.SelectedColorRectChanged();
			flag2 = true;
			break;
		case "ItemSizeMinimum":
		case "ItemSizeMaximum":
		case "ItemSizeCurrent":
			UpdateItemSizeState();
			flag = true;
			break;
		case "KryptonCommand":
			_viewMediumSmallText1.MakeDirty();
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
