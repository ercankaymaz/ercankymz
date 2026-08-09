#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupCheckBox : ViewComposite, IRibbonViewGroupItemView, IContentValues
{
	private static readonly Padding _largeImagePadding = new Padding(3, 2, 3, 3);

	private static readonly Padding _smallImagePadding = new Padding(3);

	private KryptonRibbon _ribbon;

	private KryptonRibbonGroupCheckBox _ribbonCheckBox;

	private ViewLayoutRibbonCheckBox _viewLarge;

	private ViewDrawRibbonGroupCheckBoxImage _viewLargeImage;

	private ViewDrawRibbonGroupCheckBoxText _viewLargeText1;

	private ViewDrawRibbonGroupCheckBoxText _viewLargeText2;

	private GroupCheckBoxController _viewLargeController;

	private EventHandler _finishDelegateLarge;

	private ViewLayoutRibbonCheckBox _viewMediumSmall;

	private ViewLayoutRibbonRowCenter _viewMediumSmallCenter;

	private ViewDrawRibbonGroupCheckBoxImage _viewMediumSmallImage;

	private ViewDrawRibbonGroupCheckBoxText _viewMediumSmallText1;

	private ViewDrawRibbonGroupCheckBoxText _viewMediumSmallText2;

	private GroupCheckBoxController _viewMediumSmallController;

	private EventHandler _finishDelegateMediumSmall;

	private NeedPaintHandler _needPaint;

	private GroupItemSize _currentSize;

	public KryptonRibbonGroupCheckBox GroupCheckBox => _ribbonCheckBox;

	public ViewDrawRibbonGroupCheckBox(KryptonRibbon ribbon, KryptonRibbonGroupCheckBox ribbonCheckBox, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(ribbonCheckBox != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_ribbonCheckBox = ribbonCheckBox;
		_needPaint = needPaint;
		_currentSize = _ribbonCheckBox.ItemSizeCurrent;
		_finishDelegateLarge = ActionFinishedLarge;
		_finishDelegateMediumSmall = ActionFinishedMediumSmall;
		Component = _ribbonCheckBox;
		CreateLargeCheckBoxView();
		CreateMediumSmallCheckBoxView();
		UpdateEnabledState();
		UpdateCheckState();
		UpdateItemSizeState();
		_ribbonCheckBox.PropertyChanged += OnCheckBoxPropertyChanged;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupCheckBox:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _ribbonCheckBox != null)
		{
			_ribbonCheckBox.PropertyChanged -= OnCheckBoxPropertyChanged;
			_ribbonCheckBox.CheckBoxView = null;
			_ribbonCheckBox = null;
		}
		base.Dispose(disposing);
	}

	public ViewBase GetFirstFocusItem()
	{
		if (_ribbonCheckBox.Visible && _ribbonCheckBox.Enabled)
		{
			if (_viewLarge == _ribbonCheckBox.CheckBoxView)
			{
				return _viewLarge;
			}
			return _viewMediumSmall;
		}
		return null;
	}

	public ViewBase GetLastFocusItem()
	{
		if (_ribbonCheckBox.Visible && _ribbonCheckBox.Enabled)
		{
			if (_viewLarge == _ribbonCheckBox.CheckBoxView)
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
			GroupCheckBoxController target = null;
			switch (_currentSize)
			{
			case GroupItemSize.Large:
				screenPt = new Point(viewRect.Left + viewRect.Width / 2, viewRect.Bottom);
				target = _viewLargeController;
				break;
			case GroupItemSize.Small:
			case GroupItemSize.Medium:
				screenPt = _ribbon.CalculatedValues.KeyTipRectToPoint(viewRect, lineHint);
				target = _viewMediumSmallController;
				break;
			}
			keyTipList.Add(new KeyTipInfo(_ribbonCheckBox.Enabled, _ribbonCheckBox.KeyTip, screenPt, this[0].ClientRectangle, target));
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
		UpdateCheckState();
		UpdateItemSizeState();
		ClientRectangle = context.DisplayRectangle;
		base.Layout(context);
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

	private void CreateLargeCheckBoxView()
	{
		_viewLarge = new ViewLayoutRibbonCheckBox();
		_viewLargeImage = new ViewDrawRibbonGroupCheckBoxImage(_ribbon, _ribbonCheckBox, large: true);
		ViewLayoutRibbonCenterPadding viewLayoutRibbonCenterPadding = new ViewLayoutRibbonCenterPadding(_largeImagePadding);
		viewLayoutRibbonCenterPadding.Add(_viewLargeImage);
		_viewLarge.Add(viewLayoutRibbonCenterPadding, ViewDockStyle.Top);
		_viewLargeText1 = new ViewDrawRibbonGroupCheckBoxText(_ribbon, _ribbonCheckBox, firstText: true);
		_viewLarge.Add(_viewLargeText1, ViewDockStyle.Bottom);
		_viewLargeText2 = new ViewDrawRibbonGroupCheckBoxText(_ribbon, _ribbonCheckBox, firstText: false);
		_viewLarge.Add(_viewLargeText2, ViewDockStyle.Bottom);
		_viewLarge.Add(new ViewLayoutRibbonSeparator(1, ignoreMouse: false), ViewDockStyle.Bottom);
		_viewLargeController = new GroupCheckBoxController(_ribbon, _viewLarge, _viewLargeImage, _needPaint);
		_viewLargeController.Click += OnLargeCheckBoxClick;
		_viewLargeController.ContextClick += OnContextClick;
		_viewLarge.MouseController = _viewLargeController;
		_viewLarge.SourceController = _viewLargeController;
		_viewLarge.KeyController = _viewLargeController;
		_viewLarge.MouseController = new ToolTipController(_ribbon.TabsArea.ButtonSpecManager.ToolTipManager, _viewLarge, _viewLarge.MouseController);
	}

	private void CreateMediumSmallCheckBoxView()
	{
		_viewMediumSmall = new ViewLayoutRibbonCheckBox();
		_viewMediumSmallImage = new ViewDrawRibbonGroupCheckBoxImage(_ribbon, _ribbonCheckBox, large: false);
		_viewMediumSmallText1 = new ViewDrawRibbonGroupCheckBoxText(_ribbon, _ribbonCheckBox, firstText: true);
		_viewMediumSmallText2 = new ViewDrawRibbonGroupCheckBoxText(_ribbon, _ribbonCheckBox, firstText: false);
		ViewLayoutRibbonCenterPadding viewLayoutRibbonCenterPadding = new ViewLayoutRibbonCenterPadding(_smallImagePadding);
		viewLayoutRibbonCenterPadding.Add(_viewMediumSmallImage);
		_viewMediumSmallCenter = new ViewLayoutRibbonRowCenter();
		_viewMediumSmallCenter.Add(viewLayoutRibbonCenterPadding);
		_viewMediumSmallCenter.Add(_viewMediumSmallText1);
		_viewMediumSmallCenter.Add(_viewMediumSmallText2);
		_viewMediumSmall.Add(_viewMediumSmallCenter, ViewDockStyle.Fill);
		_viewMediumSmallController = new GroupCheckBoxController(_ribbon, _viewMediumSmall, _viewMediumSmallImage, _needPaint);
		_viewMediumSmallController.Click += OnMediumSmallCheckBoxClick;
		_viewMediumSmallController.ContextClick += OnContextClick;
		_viewMediumSmall.MouseController = _viewMediumSmallController;
		_viewMediumSmall.SourceController = _viewMediumSmallController;
		_viewMediumSmall.KeyController = _viewMediumSmallController;
		_viewMediumSmall.MouseController = new ToolTipController(_ribbon.TabsArea.ButtonSpecManager.ToolTipManager, _viewMediumSmall, _viewMediumSmall.MouseController);
	}

	private void DefineRootView(ViewBase view)
	{
		Clear();
		Add(view);
		_ribbonCheckBox.CheckBoxView = view;
	}

	private void UpdateEnabledState()
	{
		bool enabled = _ribbonCheckBox.Enabled;
		if (_ribbonCheckBox.KryptonCommand != null)
		{
			enabled = _ribbonCheckBox.KryptonCommand.Enabled;
		}
		bool enabled2 = _ribbon.InDesignHelperMode || (enabled && _ribbon.Enabled);
		_viewLarge.Enabled = enabled2;
		_viewLargeImage.Enabled = enabled2;
		_viewLargeText1.Enabled = enabled2;
		_viewLargeText2.Enabled = enabled2;
		_viewMediumSmall.Enabled = enabled2;
		_viewMediumSmallText1.Enabled = enabled2;
		_viewMediumSmallText2.Enabled = enabled2;
		_viewMediumSmallImage.Enabled = enabled2;
	}

	private void UpdateCheckState()
	{
		CheckState checkState = CheckState.Unchecked;
		checkState = ((_ribbonCheckBox.KryptonCommand == null) ? _ribbonCheckBox.CheckState : _ribbonCheckBox.KryptonCommand.CheckState);
		_viewLargeImage.CheckState = checkState;
		_viewMediumSmallImage.CheckState = checkState;
	}

	private void UpdateItemSizeState()
	{
		UpdateItemSizeState(_ribbonCheckBox.ItemSizeCurrent);
	}

	private void UpdateItemSizeState(GroupItemSize size)
	{
		_currentSize = size;
		switch (size)
		{
		case GroupItemSize.Small:
		case GroupItemSize.Medium:
			DefineRootView(_viewMediumSmall);
			break;
		case GroupItemSize.Large:
			DefineRootView(_viewLarge);
			break;
		}
	}

	private void OnLargeCheckBoxClick(object sender, EventArgs e)
	{
		GroupCheckBox.PerformClick(_finishDelegateLarge);
	}

	private void OnMediumSmallCheckBoxClick(object sender, EventArgs e)
	{
		GroupCheckBox.PerformClick(_finishDelegateMediumSmall);
	}

	private void OnContextClick(object sender, MouseEventArgs e)
	{
		GroupCheckBox.OnDesignTimeContextMenu(e);
	}

	private void ActionFinishedLarge(object sender, EventArgs e)
	{
		if (_ribbon != null)
		{
			_ribbon.ActionOccured();
		}
		_viewLargeController.RemoveFixed();
	}

	private void ActionFinishedMediumSmall(object sender, EventArgs e)
	{
		if (_ribbon != null)
		{
			_ribbon.ActionOccured();
		}
		_viewMediumSmallController.RemoveFixed();
	}

	private void OnCheckBoxPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		bool flag = false;
		bool flag2 = false;
		switch (e.PropertyName)
		{
		case "Visible":
			flag = true;
			break;
		case "TextLine1":
			flag = true;
			_viewLargeText1.MakeDirty();
			_viewMediumSmallText1.MakeDirty();
			break;
		case "TextLine2":
			flag = true;
			_viewLargeText2.MakeDirty();
			_viewMediumSmallText2.MakeDirty();
			break;
		case "Checked":
		case "CheckState":
			UpdateCheckState();
			flag2 = true;
			break;
		case "Enabled":
			UpdateEnabledState();
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
			_viewMediumSmallText1.MakeDirty();
			_viewMediumSmallText2.MakeDirty();
			UpdateEnabledState();
			UpdateCheckState();
			flag = true;
			break;
		}
		if (flag && _ribbonCheckBox.RibbonTab != null && _ribbon.SelectedTab == _ribbonCheckBox.RibbonTab)
		{
			OnNeedPaint(needLayout: true);
		}
		if (flag2 && (_ribbonCheckBox.Visible || _ribbon.InDesignMode) && _ribbonCheckBox.RibbonTab != null && _ribbon.SelectedTab == _ribbonCheckBox.RibbonTab)
		{
			OnNeedPaint(needLayout: false, ClientRectangle);
		}
	}

	public Image GetImage(PaletteState state)
	{
		return null;
	}

	public Color GetImageTransparentColor(PaletteState state)
	{
		return Color.Empty;
	}

	public string GetShortText()
	{
		return _ribbonCheckBox.TextLine1;
	}

	public string GetLongText()
	{
		return _ribbonCheckBox.TextLine2;
	}
}
