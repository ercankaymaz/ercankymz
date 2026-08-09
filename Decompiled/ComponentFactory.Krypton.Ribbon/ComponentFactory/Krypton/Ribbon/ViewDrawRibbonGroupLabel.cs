#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroupLabel : ViewComposite, IRibbonViewGroupItemView
{
	private static readonly Padding _largeImagePadding = new Padding(3, 2, 3, 3);

	private static readonly Padding _smallImagePadding = new Padding(3);

	private KryptonRibbon _ribbon;

	private KryptonRibbonGroupLabel _ribbonLabel;

	private NeedPaintHandler _needPaint;

	private ViewLayoutDocker _viewLarge;

	private ViewLayoutRibbonCenterPadding _viewLargeImage;

	private ViewDrawRibbonGroupLabelImage _viewLargeLabelImage;

	private ViewDrawRibbonGroupLabelText _viewLargeText1;

	private ViewDrawRibbonGroupLabelText _viewLargeText2;

	private ViewLayoutDocker _viewMediumSmall;

	private ViewLayoutRibbonRowCenter _viewMediumSmallCenter;

	private ViewLayoutRibbonCenterPadding _viewMediumSmallImage;

	private ViewDrawRibbonGroupLabelImage _viewMediumSmallLabelImage;

	private ViewDrawRibbonGroupLabelText _viewMediumSmallText1;

	private ViewDrawRibbonGroupLabelText _viewMediumSmallText2;

	private GroupItemSize _currentSize;

	public KryptonRibbonGroupLabel GroupLabel => _ribbonLabel;

	public ViewDrawRibbonGroupLabel(KryptonRibbon ribbon, KryptonRibbonGroupLabel ribbonLabel, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(ribbonLabel != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_ribbonLabel = ribbonLabel;
		_needPaint = needPaint;
		Component = _ribbonLabel;
		_ribbonLabel.ViewPaintDelegate = needPaint;
		CreateLargeLabelView();
		CreateMediumSmallLabelView();
		UpdateEnabledState();
		UpdateImageSmallState();
		UpdateItemSizeState();
		_ribbonLabel.PropertyChanged += OnLabelPropertyChanged;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroupLabel:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _ribbonLabel != null)
		{
			_ribbonLabel.ViewPaintDelegate = null;
			_ribbonLabel.PropertyChanged -= OnLabelPropertyChanged;
			_ribbonLabel.LabelView = null;
			_ribbonLabel = null;
		}
		base.Dispose(disposing);
	}

	public ViewBase GetFirstFocusItem()
	{
		return null;
	}

	public ViewBase GetLastFocusItem()
	{
		return null;
	}

	public ViewBase GetNextFocusItem(ViewBase current, ref bool matched)
	{
		return null;
	}

	public ViewBase GetPreviousFocusItem(ViewBase current, ref bool matched)
	{
		return null;
	}

	public void GetGroupKeyTips(KeyTipInfoList keyTipList, int lineHint)
	{
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
		UpdateImageSmallState();
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

	private void CreateLargeLabelView()
	{
		_viewLarge = new ViewLayoutDocker();
		if (_ribbon.InDesignMode)
		{
			ContextClickController contextClickController = new ContextClickController();
			contextClickController.ContextClick += OnContextClick;
			_viewLarge.MouseController = contextClickController;
		}
		_viewLargeLabelImage = new ViewDrawRibbonGroupLabelImage(_ribbon, _ribbonLabel, large: true);
		_viewLargeImage = new ViewLayoutRibbonCenterPadding(_largeImagePadding);
		_viewLargeImage.Add(_viewLargeLabelImage);
		_viewLarge.Add(_viewLargeImage, ViewDockStyle.Top);
		_viewLargeText1 = new ViewDrawRibbonGroupLabelText(_ribbon, _ribbonLabel, firstText: true);
		_viewLarge.Add(_viewLargeText1, ViewDockStyle.Bottom);
		_viewLargeText2 = new ViewDrawRibbonGroupLabelText(_ribbon, _ribbonLabel, firstText: false);
		_viewLarge.Add(_viewLargeText2, ViewDockStyle.Bottom);
		_viewLarge.Add(new ViewLayoutRibbonSeparator(1, ignoreMouse: false), ViewDockStyle.Bottom);
		_viewLarge.MouseController = new ToolTipController(_ribbon.TabsArea.ButtonSpecManager.ToolTipManager, _viewLarge, _viewLarge.MouseController);
	}

	private void CreateMediumSmallLabelView()
	{
		_viewMediumSmall = new ViewLayoutDocker();
		if (_ribbon.InDesignMode)
		{
			ContextClickController contextClickController = new ContextClickController();
			contextClickController.ContextClick += OnContextClick;
			_viewMediumSmall.MouseController = contextClickController;
		}
		_viewMediumSmallLabelImage = new ViewDrawRibbonGroupLabelImage(_ribbon, _ribbonLabel, large: false);
		_viewMediumSmallText1 = new ViewDrawRibbonGroupLabelText(_ribbon, _ribbonLabel, firstText: true);
		_viewMediumSmallText2 = new ViewDrawRibbonGroupLabelText(_ribbon, _ribbonLabel, firstText: false);
		_viewMediumSmallImage = new ViewLayoutRibbonCenterPadding(_smallImagePadding);
		_viewMediumSmallImage.Add(_viewMediumSmallLabelImage);
		_viewMediumSmallCenter = new ViewLayoutRibbonRowCenter();
		_viewMediumSmallCenter.Add(_viewMediumSmallImage);
		_viewMediumSmallCenter.Add(_viewMediumSmallText1);
		_viewMediumSmallCenter.Add(_viewMediumSmallText2);
		_viewMediumSmall.Add(_viewMediumSmallCenter, ViewDockStyle.Fill);
		_viewMediumSmall.MouseController = new ToolTipController(_ribbon.TabsArea.ButtonSpecManager.ToolTipManager, _viewMediumSmall, _viewMediumSmall.MouseController);
	}

	private void DefineRootView(ViewBase view)
	{
		Clear();
		Add(view);
		_ribbonLabel.LabelView = view;
	}

	private void UpdateEnabledState()
	{
		bool enabled = _ribbonLabel.Enabled;
		if (_ribbonLabel.KryptonCommand != null)
		{
			enabled = _ribbonLabel.KryptonCommand.Enabled;
		}
		bool enabled2 = _ribbon.InDesignHelperMode || (enabled && _ribbon.Enabled);
		_viewLarge.Enabled = enabled2;
		_viewLargeImage.Enabled = enabled2;
		_viewLargeLabelImage.Enabled = enabled2;
		_viewLargeText1.Enabled = enabled2;
		_viewLargeText2.Enabled = enabled2;
		_viewMediumSmall.Enabled = enabled2;
		_viewMediumSmallImage.Enabled = enabled2;
		_viewMediumSmallLabelImage.Enabled = enabled2;
		_viewMediumSmallText1.Enabled = enabled2;
		_viewMediumSmallText2.Enabled = enabled2;
	}

	private void UpdateImageSmallState()
	{
		_viewMediumSmallImage.Visible = _ribbonLabel.ImageSmall != null;
	}

	private void UpdateItemSizeState()
	{
		UpdateItemSizeState(_ribbonLabel.ItemSizeCurrent);
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
			_viewMediumSmallText2.Visible = visible;
			DefineRootView(_viewMediumSmall);
			break;
		}
		case GroupItemSize.Large:
			DefineRootView(_viewLarge);
			break;
		}
	}

	private void OnContextClick(object sender, MouseEventArgs e)
	{
		_ribbonLabel.OnDesignTimeContextMenu(e);
	}

	private void OnLabelPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		bool flag = false;
		bool flag2 = false;
		switch (e.PropertyName)
		{
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
			flag = true;
			break;
		case "ImageSmall":
			UpdateImageSmallState();
			flag = true;
			break;
		case "Enabled":
			UpdateEnabledState();
			flag2 = true;
			break;
		case "ImageLarge":
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
			flag = true;
			break;
		}
		if (flag && _ribbonLabel.RibbonTab != null && _ribbon.SelectedTab == _ribbonLabel.RibbonTab)
		{
			OnNeedPaint(needLayout: true);
		}
		if (flag2 && (_ribbonLabel.Visible || _ribbon.InDesignMode) && _ribbonLabel.RibbonTab != null && _ribbon.SelectedTab == _ribbonLabel.RibbonTab)
		{
			OnNeedPaint(needLayout: false, ClientRectangle);
		}
	}
}
