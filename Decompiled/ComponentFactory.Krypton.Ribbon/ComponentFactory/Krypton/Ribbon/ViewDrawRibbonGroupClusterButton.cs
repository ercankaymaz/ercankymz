#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupClusterButton : ViewComposite, IRibbonViewGroupItemView
{
	private static readonly Padding _smallImagePadding = new Padding(3);

	private KryptonRibbon _ribbon;

	private KryptonRibbonGroupClusterButton _ribbonButton;

	private NeedPaintHandler _needPaint;

	private PaletteBackInheritForced _backForced;

	private PaletteBorderInheritForced _borderForced;

	private ViewDrawRibbonGroupButtonBackBorder _viewMediumSmall;

	private ViewLayoutRibbonRowCenter _viewMediumSmallCenter;

	private ViewDrawRibbonGroupClusterButtonImage _viewMediumSmallImage;

	private ViewDrawRibbonGroupClusterButtonText _viewMediumSmallText1;

	private ViewDrawRibbonDropArrow _viewMediumSmallDropArrow;

	private ViewLayoutRibbonSeparator _viewMediumSmallText2Sep1;

	private ViewLayoutRibbonSeparator _viewMediumSmallText2Sep2;

	private GroupItemSize _currentSize;

	public KryptonRibbonGroupClusterButton GroupClusterButton => _ribbonButton;

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

	public ViewDrawRibbonGroupClusterButton(KryptonRibbon ribbon, KryptonRibbonGroupClusterButton ribbonButton, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(ribbonButton != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_ribbonButton = ribbonButton;
		_needPaint = needPaint;
		_currentSize = _ribbonButton.ItemSizeCurrent;
		Component = _ribbonButton;
		CreateView();
		UpdateEnabledState();
		UpdateCheckedState();
		UpdateDropDownState();
		UpdateItemSizeState();
		_ribbonButton.PropertyChanged += OnButtonPropertyChanged;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupClusterButton:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _ribbonButton != null)
		{
			_ribbonButton.PropertyChanged -= OnButtonPropertyChanged;
			_ribbonButton.ClusterButtonView = null;
			_ribbonButton = null;
		}
		base.Dispose(disposing);
	}

	public ViewBase GetFirstFocusItem()
	{
		if (_ribbonButton.Visible && _ribbonButton.Enabled)
		{
			return _viewMediumSmall;
		}
		return null;
	}

	public ViewBase GetLastFocusItem()
	{
		if (_ribbonButton.Visible && _ribbonButton.Enabled)
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
			keyTipList.Add(new KeyTipInfo(_ribbonButton.Enabled, _ribbonButton.KeyTip, screenPt, this[0].ClientRectangle, _viewMediumSmall.Controller));
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
		if (_ribbonButton.ButtonType == GroupButtonType.Split)
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
		_viewMediumSmall = new ViewDrawRibbonGroupButtonBackBorder(_ribbon, _ribbonButton, _backForced, _borderForced, constantBorder: true, _needPaint);
		_viewMediumSmall.SplitVertical = false;
		_viewMediumSmall.Click += OnSmallButtonClick;
		_viewMediumSmall.DropDown += OnSmallButtonDropDown;
		if (_ribbon.InDesignMode)
		{
			_viewMediumSmall.ContextClick += OnContextClick;
		}
		ViewLayoutDocker viewLayoutDocker = new ViewLayoutDocker();
		_viewMediumSmallImage = new ViewDrawRibbonGroupClusterButtonImage(_ribbon, _ribbonButton);
		_viewMediumSmallText1 = new ViewDrawRibbonGroupClusterButtonText(_ribbon, _ribbonButton);
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
		_ribbonButton.ClusterButtonView = _viewMediumSmall;
		Add(_viewMediumSmall);
	}

	private void UpdateItemSizeState()
	{
		UpdateItemSizeState(_ribbonButton.ItemSizeCurrent);
	}

	private void UpdateItemSizeState(GroupItemSize size)
	{
		_currentSize = size;
		_viewMediumSmallCenter.CurrentSize = size;
		_viewMediumSmallText1.Visible = size != GroupItemSize.Small;
	}

	private void UpdateEnabledState()
	{
		bool enabled = _ribbonButton.Enabled;
		if (_ribbonButton.KryptonCommand != null)
		{
			enabled = _ribbonButton.KryptonCommand.Enabled;
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
		if (_ribbonButton.ButtonType == GroupButtonType.Check)
		{
			flag = ((_ribbonButton.KryptonCommand == null) ? _ribbonButton.Checked : _ribbonButton.KryptonCommand.Checked);
		}
		_viewMediumSmall.Checked = flag;
	}

	private void UpdateDropDownState()
	{
		bool visible = _ribbonButton.ButtonType == GroupButtonType.DropDown || _ribbonButton.ButtonType == GroupButtonType.Split;
		bool visible2 = _ribbonButton.ButtonType == GroupButtonType.Split;
		_viewMediumSmallText2Sep1.Visible = visible2;
		_viewMediumSmallDropArrow.Visible = visible;
		_viewMediumSmallText2Sep2.Visible = visible;
		_viewMediumSmall.ButtonType = _ribbonButton.ButtonType;
	}

	private void OnSmallButtonClick(object sender, EventArgs e)
	{
		GroupClusterButton.PerformClick(_viewMediumSmall.FinishDelegate);
	}

	private void OnSmallButtonDropDown(object sender, EventArgs e)
	{
		GroupClusterButton.PerformDropDown(_viewMediumSmall.FinishDelegate);
	}

	private void OnContextClick(object sender, MouseEventArgs e)
	{
		GroupClusterButton.OnDesignTimeContextMenu(e);
	}

	private void OnButtonPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		bool flag = false;
		bool flag2 = false;
		switch (e.PropertyName)
		{
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
			UpdateEnabledState();
			UpdateCheckedState();
			flag = true;
			break;
		}
		if (flag && _ribbonButton.RibbonTab != null && _ribbon.SelectedTab == _ribbonButton.RibbonTab)
		{
			OnNeedPaint(needLayout: true);
		}
		if (flag2 && (_ribbonButton.Visible || _ribbon.InDesignMode) && _ribbonButton.RibbonTab != null && _ribbon.SelectedTab == _ribbonButton.RibbonTab)
		{
			OnNeedPaint(needLayout: false, ClientRectangle);
		}
	}
}
