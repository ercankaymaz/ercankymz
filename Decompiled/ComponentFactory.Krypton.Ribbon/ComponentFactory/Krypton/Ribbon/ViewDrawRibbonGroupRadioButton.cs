#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupRadioButton : ViewComposite, IRibbonViewGroupItemView, IContentValues
{
	private static readonly Padding _largeImagePadding = new Padding(3, 2, 3, 3);

	private static readonly Padding _smallImagePadding = new Padding(3);

	private KryptonRibbon _ribbon;

	private KryptonRibbonGroupRadioButton _ribbonRadioButton;

	private ViewLayoutRibbonRadioButton _viewLarge;

	private ViewDrawRibbonGroupRadioButtonImage _viewLargeImage;

	private ViewDrawRibbonGroupRadioButtonText _viewLargeText1;

	private ViewDrawRibbonGroupRadioButtonText _viewLargeText2;

	private GroupRadioButtonController _viewLargeController;

	private EventHandler _finishDelegateLarge;

	private ViewLayoutRibbonRadioButton _viewMediumSmall;

	private ViewLayoutRibbonRowCenter _viewMediumSmallCenter;

	private ViewDrawRibbonGroupRadioButtonImage _viewMediumSmallImage;

	private ViewDrawRibbonGroupRadioButtonText _viewMediumSmallText1;

	private ViewDrawRibbonGroupRadioButtonText _viewMediumSmallText2;

	private GroupRadioButtonController _viewMediumSmallController;

	private EventHandler _finishDelegateMediumSmall;

	private NeedPaintHandler _needPaint;

	private GroupItemSize _currentSize;

	public KryptonRibbonGroupRadioButton GroupRadioButton => _ribbonRadioButton;

	public ViewDrawRibbonGroupRadioButton(KryptonRibbon ribbon, KryptonRibbonGroupRadioButton ribbonRadioButton, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(ribbonRadioButton != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_ribbonRadioButton = ribbonRadioButton;
		_needPaint = needPaint;
		_currentSize = _ribbonRadioButton.ItemSizeCurrent;
		_finishDelegateLarge = ActionFinishedLarge;
		_finishDelegateMediumSmall = ActionFinishedMediumSmall;
		Component = _ribbonRadioButton;
		CreateLargeRadioButtonView();
		CreateMediumSmallRadioButtonView();
		UpdateEnabledState();
		UpdateCheckedState();
		UpdateItemSizeState();
		_ribbonRadioButton.PropertyChanged += OnRadioButtonPropertyChanged;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupRadioButton:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _ribbonRadioButton != null)
		{
			_ribbonRadioButton.PropertyChanged -= OnRadioButtonPropertyChanged;
			_ribbonRadioButton.RadioButtonView = null;
			_ribbonRadioButton = null;
		}
		base.Dispose(disposing);
	}

	public ViewBase GetFirstFocusItem()
	{
		if (_ribbonRadioButton.Visible && _ribbonRadioButton.Enabled)
		{
			if (_viewLarge == _ribbonRadioButton.RadioButtonView)
			{
				return _viewLarge;
			}
			return _viewMediumSmall;
		}
		return null;
	}

	public ViewBase GetLastFocusItem()
	{
		if (_ribbonRadioButton.Visible && _ribbonRadioButton.Enabled)
		{
			if (_viewLarge == _ribbonRadioButton.RadioButtonView)
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
			GroupRadioButtonController target = null;
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
			keyTipList.Add(new KeyTipInfo(_ribbonRadioButton.Enabled, _ribbonRadioButton.KeyTip, screenPt, this[0].ClientRectangle, target));
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
		UpdateCheckedState();
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

	private void CreateLargeRadioButtonView()
	{
		_viewLarge = new ViewLayoutRibbonRadioButton();
		_viewLargeImage = new ViewDrawRibbonGroupRadioButtonImage(_ribbon, _ribbonRadioButton, large: true);
		ViewLayoutRibbonCenterPadding viewLayoutRibbonCenterPadding = new ViewLayoutRibbonCenterPadding(_largeImagePadding);
		viewLayoutRibbonCenterPadding.Add(_viewLargeImage);
		_viewLarge.Add(viewLayoutRibbonCenterPadding, ViewDockStyle.Top);
		_viewLargeText1 = new ViewDrawRibbonGroupRadioButtonText(_ribbon, _ribbonRadioButton, firstText: true);
		_viewLarge.Add(_viewLargeText1, ViewDockStyle.Bottom);
		_viewLargeText2 = new ViewDrawRibbonGroupRadioButtonText(_ribbon, _ribbonRadioButton, firstText: false);
		_viewLarge.Add(_viewLargeText2, ViewDockStyle.Bottom);
		_viewLarge.Add(new ViewLayoutRibbonSeparator(1, ignoreMouse: false), ViewDockStyle.Bottom);
		_viewLargeController = new GroupRadioButtonController(_ribbon, _viewLarge, _viewLargeImage, _needPaint);
		_viewLargeController.Click += OnLargeRadioButtonClick;
		_viewLargeController.ContextClick += OnContextClick;
		_viewLarge.MouseController = _viewLargeController;
		_viewLarge.SourceController = _viewLargeController;
		_viewLarge.KeyController = _viewLargeController;
		_viewLarge.MouseController = new ToolTipController(_ribbon.TabsArea.ButtonSpecManager.ToolTipManager, _viewLarge, _viewLarge.MouseController);
	}

	private void CreateMediumSmallRadioButtonView()
	{
		_viewMediumSmall = new ViewLayoutRibbonRadioButton();
		_viewMediumSmallImage = new ViewDrawRibbonGroupRadioButtonImage(_ribbon, _ribbonRadioButton, large: false);
		_viewMediumSmallText1 = new ViewDrawRibbonGroupRadioButtonText(_ribbon, _ribbonRadioButton, firstText: true);
		_viewMediumSmallText2 = new ViewDrawRibbonGroupRadioButtonText(_ribbon, _ribbonRadioButton, firstText: false);
		ViewLayoutRibbonCenterPadding viewLayoutRibbonCenterPadding = new ViewLayoutRibbonCenterPadding(_smallImagePadding);
		viewLayoutRibbonCenterPadding.Add(_viewMediumSmallImage);
		_viewMediumSmallCenter = new ViewLayoutRibbonRowCenter();
		_viewMediumSmallCenter.Add(viewLayoutRibbonCenterPadding);
		_viewMediumSmallCenter.Add(_viewMediumSmallText1);
		_viewMediumSmallCenter.Add(_viewMediumSmallText2);
		_viewMediumSmall.Add(_viewMediumSmallCenter, ViewDockStyle.Fill);
		_viewMediumSmallController = new GroupRadioButtonController(_ribbon, _viewMediumSmall, _viewMediumSmallImage, _needPaint);
		_viewMediumSmallController.Click += OnMediumSmallRadioButtonClick;
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
		_ribbonRadioButton.RadioButtonView = view;
	}

	private void UpdateEnabledState()
	{
		bool enabled = _ribbon.InDesignHelperMode || (_ribbonRadioButton.Enabled && _ribbon.Enabled);
		_viewLarge.Enabled = enabled;
		_viewLargeImage.Enabled = enabled;
		_viewLargeText1.Enabled = enabled;
		_viewLargeText2.Enabled = enabled;
		_viewMediumSmall.Enabled = enabled;
		_viewMediumSmallText1.Enabled = enabled;
		_viewMediumSmallText2.Enabled = enabled;
		_viewMediumSmallImage.Enabled = enabled;
	}

	private void UpdateCheckedState()
	{
		_viewLargeImage.Checked = _ribbonRadioButton.Checked;
		_viewMediumSmallImage.Checked = _ribbonRadioButton.Checked;
	}

	private void UpdateItemSizeState()
	{
		UpdateItemSizeState(_ribbonRadioButton.ItemSizeCurrent);
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

	private void OnLargeRadioButtonClick(object sender, EventArgs e)
	{
		GroupRadioButton.PerformClick(_finishDelegateLarge);
	}

	private void OnMediumSmallRadioButtonClick(object sender, EventArgs e)
	{
		GroupRadioButton.PerformClick(_finishDelegateMediumSmall);
	}

	private void OnContextClick(object sender, MouseEventArgs e)
	{
		GroupRadioButton.OnDesignTimeContextMenu(e);
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

	private void OnRadioButtonPropertyChanged(object sender, PropertyChangedEventArgs e)
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
			UpdateCheckedState();
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
		}
		if (flag && _ribbonRadioButton.RibbonTab != null && _ribbon.SelectedTab == _ribbonRadioButton.RibbonTab)
		{
			OnNeedPaint(needLayout: true);
		}
		if (flag2 && (_ribbonRadioButton.Visible || _ribbon.InDesignMode) && _ribbonRadioButton.RibbonTab != null && _ribbon.SelectedTab == _ribbonRadioButton.RibbonTab)
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
		return _ribbonRadioButton.TextLine1;
	}

	public string GetLongText()
	{
		return _ribbonRadioButton.TextLine2;
	}
}
