#define DEBUG
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class ViewDrawRibbonGroup : ViewComposite, IRibbonViewGroupSize
{
	private static readonly int MINIMUM_GROUP_WIDTH = 32;

	private static readonly int NORMAL_BORDER_TOPLEFT2007 = 2;

	private static readonly int NORMAL_BORDER_RIGHT2007 = 4;

	private static readonly int NORMAL_BORDER_TOP2010 = 3;

	private static readonly int NORMAL_BORDER_LEFT2010 = 3;

	private static readonly int NORMAL_BORDER_RIGHT2010 = 6;

	private static readonly int TOTAL_LEFT_RIGHT_BORDERS_2007 = 7;

	private static readonly int TOTAL_LEFT_RIGHT_BORDERS_2010 = 10;

	private static readonly int VERT_OFFSET_2007 = 0;

	private static readonly int VERT_OFFSET_2010 = 2;

	private static readonly Padding COLLAPSED_PADDING = new Padding(2);

	private static readonly Padding COLLAPSED_IMAGE_PADDING_2007 = new Padding(3, 3, 3, 4);

	private static readonly Padding COLLAPSED_IMAGE_PADDING_2010 = new Padding(3, 1, 5, 5);

	private KryptonRibbon _ribbon;

	private KryptonRibbonGroup _ribbonGroup;

	private VisualPopupGroup _popupGroup;

	private ViewLayoutDocker _layoutCollapsedMain;

	private ViewDrawRibbonGroupText _viewCollapsedText1;

	private ViewDrawRibbonGroupText _viewCollapsedText2;

	private ViewLayoutRibbonCenterPadding _layoutCollapsedImagePadding;

	private CollapsedGroupController _collapsedController;

	private ViewLayoutRibbonTitle _layoutNormalMain;

	private ViewLayoutRibbonSeparator _layoutNormalSepTop;

	private ViewLayoutRibbonSeparator _layoutNormalSepLeft;

	private ViewLayoutRibbonSeparator _layoutNormalSepRight;

	private ViewLayoutRibbonGroupContent _layoutNormalContent;

	private ViewLayoutRibbonGroupButton _viewNormalDialog;

	private ViewLayoutDocker _layoutNormalTitle;

	private ViewDrawRibbonGroupTitle _viewNormalTitle;

	private PaletteRibbonContextBack _paletteContextBack;

	private PaletteRibbonShape _lastRibbonShape;

	private NeedPaintHandler _needPaint;

	private IDisposable _mementoRibbonBack1;

	private IDisposable _mementoRibbonBack2;

	private IDisposable _mementoStandardBack;

	private Control _container;

	private bool _collapsed;

	private bool _tracking;

	private bool _pressed;

	private int _totalBorders;

	public bool Collapsed
	{
		get
		{
			return _collapsed;
		}
		set
		{
			_collapsed = value;
			_ribbonGroup.IsCollapsed = value;
			Clear();
			Add(Collapsed ? _layoutCollapsedMain : _layoutNormalMain);
			DisposeMementos();
		}
	}

	public bool Tracking
	{
		get
		{
			return _tracking;
		}
		set
		{
			_tracking = value;
		}
	}

	public bool Pressed
	{
		get
		{
			return _pressed;
		}
		set
		{
			_pressed = value;
		}
	}

	public ViewDrawRibbonGroup(KryptonRibbon ribbon, KryptonRibbonGroup ribbonGroup, NeedPaintHandler needPaint)
	{
		Debug.Assert(ribbon != null);
		Debug.Assert(ribbonGroup != null);
		Debug.Assert(needPaint != null);
		_ribbon = ribbon;
		_ribbonGroup = ribbonGroup;
		_needPaint = needPaint;
		Component = _ribbonGroup;
		CreateNormalView();
		CreateCollapsedView();
		Add(_layoutNormalMain);
		_ribbonGroup.GroupView = this;
		_ribbonGroup.PropertyChanged += OnGroupPropertyChanged;
	}

	public override string ToString()
	{
		return "ViewDrawRibbonGroup:" + base.Id;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			_ribbonGroup.PropertyChanged -= OnGroupPropertyChanged;
			DisposeMementos();
		}
		base.Dispose(disposing);
	}

	public void GetGroupKeyTips(KeyTipInfoList keyTipList)
	{
		if (Collapsed)
		{
			Rectangle rectangle = _ribbon.KeyTipToScreen(_layoutCollapsedMain);
			keyTipList.Add(new KeyTipInfo(screenPt: new Point(rectangle.Left + rectangle.Width / 2, rectangle.Bottom + 4), enabled: true, keyString: _ribbonGroup.KeyTipGroup, clientRect: _layoutCollapsedMain.ClientRectangle, target: _collapsedController));
			return;
		}
		if (_ribbonGroup.DialogBoxLauncher)
		{
			Rectangle rectangle2 = _ribbon.KeyTipToScreen(_viewNormalDialog);
			keyTipList.Add(new KeyTipInfo(screenPt: new Point(rectangle2.Left + rectangle2.Width / 2, rectangle2.Bottom + 4), enabled: true, keyString: _ribbonGroup.KeyTipDialogLauncher, clientRect: _viewNormalDialog.ClientRectangle, target: _viewNormalDialog.DialogButtonController));
		}
		_layoutNormalContent.GetGroupKeyTips(keyTipList);
	}

	public ViewBase GetFirstFocusItem()
	{
		ViewBase viewBase = null;
		if (Collapsed)
		{
			return _layoutCollapsedMain;
		}
		return _layoutNormalContent.GetFirstFocusItem();
	}

	public ViewBase GetLastFocusItem()
	{
		ViewBase viewBase = null;
		if (Collapsed)
		{
			return _layoutCollapsedMain;
		}
		return _layoutNormalContent.GetLastFocusItem();
	}

	public ViewBase GetNextFocusItem(ViewBase current, ref bool matched)
	{
		ViewBase result = null;
		if (Collapsed)
		{
			if (matched)
			{
				result = _layoutCollapsedMain;
			}
			else
			{
				matched = current == _layoutCollapsedMain;
			}
		}
		else
		{
			result = _layoutNormalContent.GetNextFocusItem(current, ref matched);
		}
		return result;
	}

	public ViewBase GetPreviousFocusItem(ViewBase current, ref bool matched)
	{
		ViewBase result = null;
		if (Collapsed)
		{
			if (matched)
			{
				result = _layoutCollapsedMain;
			}
			else
			{
				matched = current == _layoutCollapsedMain;
			}
		}
		else
		{
			result = _layoutNormalContent.GetPreviousFocusItem(current, ref matched);
		}
		return result;
	}

	public void PerformNeedPaint(bool needLayout, Rectangle invalidRect)
	{
		OnNeedPaint(needLayout, invalidRect);
	}

	public GroupSizeWidth[] GetPossibleSizes(ViewLayoutContext context)
	{
		UpdateShapeValues();
		IRibbonViewGroupSize layoutNormalContent = _layoutNormalContent;
		List<GroupSizeWidth> list = new List<GroupSizeWidth>();
		list.AddRange(layoutNormalContent.GetPossibleSizes(context));
		int num = _ribbonGroup.MinimumWidth;
		int num2 = _ribbonGroup.MaximumWidth;
		bool flag = num < 0;
		if (num2 <= 0)
		{
			num2 = int.MaxValue;
		}
		if (num < 0)
		{
			num = 0;
		}
		num = Math.Min(num, num2);
		int num3 = -1;
		int num4 = -1;
		int num5 = int.MaxValue;
		for (int i = 0; i < list.Count; i++)
		{
			GroupSizeWidth groupSizeWidth = list[i];
			groupSizeWidth.Width += _totalBorders;
			if (groupSizeWidth.Width <= num2 && num3 == -1)
			{
				num3 = i;
			}
			if (groupSizeWidth.Width >= num)
			{
				num4 = i;
			}
			num5 = Math.Min(num5, groupSizeWidth.Width);
		}
		if (!_ribbon.InDesignHelperMode)
		{
			if (num3 == -1)
			{
				if (list.Count > 0)
				{
					list.RemoveRange(0, list.Count - 2);
					list[0].Width = num2;
					num5 = num2;
				}
			}
			else if (num4 == -1)
			{
				if (list.Count > 0)
				{
					list.RemoveRange(1, list.Count - 1);
					list[0].Width = num;
					num5 = num;
				}
			}
			else if (num3 > 0 || num5 < num)
			{
				List<GroupSizeWidth> list2 = new List<GroupSizeWidth>();
				if (num3 > num4)
				{
					num4 = num3;
				}
				num5 = int.MaxValue;
				for (int j = num3; j <= num4; j++)
				{
					GroupSizeWidth groupSizeWidth2 = list[j];
					if (!flag && j == num4 && groupSizeWidth2.Width < num)
					{
						groupSizeWidth2.Width = num;
					}
					list2.Add(groupSizeWidth2);
					num5 = Math.Min(num5, groupSizeWidth2.Width);
				}
				list = list2;
			}
		}
		if (_ribbonGroup.AllowCollapsed && !_ribbon.InDesignHelperMode && num5 > MINIMUM_GROUP_WIDTH)
		{
			bool collapsed = Collapsed;
			Collapsed = true;
			GroupSizeWidth groupSizeWidth3 = new GroupSizeWidth(GetPreferredSize(context).Width, null);
			Collapsed = collapsed;
			if (num5 > groupSizeWidth3.Width)
			{
				list.Add(groupSizeWidth3);
			}
		}
		return list.ToArray();
	}

	public void SetSolutionSize(ItemSizeWidth[] size)
	{
		Collapsed = size == null;
		IRibbonViewGroupSize layoutNormalContent = _layoutNormalContent;
		layoutNormalContent.SetSolutionSize(size);
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Size preferredSize = base.GetPreferredSize(context);
		preferredSize.Width = Math.Max(preferredSize.Width, MINIMUM_GROUP_WIDTH);
		preferredSize.Height = _ribbon.CalculatedValues.GroupHeight;
		return preferredSize;
	}

	public override void Layout(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		ClientRectangle = context.DisplayRectangle;
		_viewNormalTitle.Height = _ribbon.CalculatedValues.GroupTitleHeight;
		_viewNormalDialog.Visible = _ribbonGroup.DialogBoxLauncher;
		base.Layout(context);
		context.DisplayRectangle = ClientRectangle;
	}

	public override void RenderBefore(RenderContext context)
	{
		_container = context.Control;
		if (Collapsed)
		{
			if (Pressed)
			{
				RenderCollapsedPressedBefore(context);
			}
			else
			{
				RenderCollapsedBefore(context);
			}
		}
		else
		{
			RenderNormalBefore(context);
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

	private void UpdateShapeValues()
	{
		if (_ribbon != null && _lastRibbonShape != _ribbon.RibbonShape)
		{
			PaletteRibbonShape ribbonShape = _ribbon.RibbonShape;
			PaletteRibbonShape paletteRibbonShape = ribbonShape;
			if (paletteRibbonShape == PaletteRibbonShape.Office2007 || paletteRibbonShape != PaletteRibbonShape.Office2010)
			{
				_totalBorders = TOTAL_LEFT_RIGHT_BORDERS_2007;
				_layoutNormalMain.VertOffset = VERT_OFFSET_2007;
				_layoutNormalSepTop.SeparatorSize = new Size(NORMAL_BORDER_TOPLEFT2007, NORMAL_BORDER_TOPLEFT2007);
				_layoutNormalSepLeft.SeparatorSize = new Size(NORMAL_BORDER_TOPLEFT2007, NORMAL_BORDER_TOPLEFT2007);
				_layoutNormalSepRight.SeparatorSize = new Size(NORMAL_BORDER_RIGHT2007, NORMAL_BORDER_RIGHT2007);
				_layoutCollapsedImagePadding.PreferredPadding = COLLAPSED_IMAGE_PADDING_2007;
				_lastRibbonShape = PaletteRibbonShape.Office2007;
			}
			else
			{
				_totalBorders = TOTAL_LEFT_RIGHT_BORDERS_2010;
				_layoutNormalMain.VertOffset = VERT_OFFSET_2010;
				_layoutNormalSepTop.SeparatorSize = new Size(NORMAL_BORDER_TOP2010, NORMAL_BORDER_TOP2010);
				_layoutNormalSepLeft.SeparatorSize = new Size(NORMAL_BORDER_LEFT2010, NORMAL_BORDER_LEFT2010);
				_layoutNormalSepRight.SeparatorSize = new Size(NORMAL_BORDER_RIGHT2010, NORMAL_BORDER_RIGHT2010);
				_layoutCollapsedImagePadding.PreferredPadding = COLLAPSED_IMAGE_PADDING_2010;
				_lastRibbonShape = PaletteRibbonShape.Office2010;
			}
		}
	}

	private void CreateNormalView()
	{
		_layoutNormalMain = new ViewLayoutRibbonTitle();
		if (_ribbon.InDesignMode)
		{
			ContextClickController contextClickController = new ContextClickController();
			contextClickController.ContextClick += OnContextClick;
			_layoutNormalMain.MouseController = contextClickController;
		}
		_layoutNormalTitle = new ViewLayoutDocker();
		_layoutNormalContent = new ViewLayoutRibbonGroupContent(_ribbon, _ribbonGroup, _needPaint);
		_layoutNormalSepTop = new ViewLayoutRibbonSeparator(NORMAL_BORDER_TOPLEFT2007, ignoreMouse: true);
		_layoutNormalSepLeft = new ViewLayoutRibbonSeparator(NORMAL_BORDER_TOPLEFT2007, ignoreMouse: true);
		_layoutNormalSepRight = new ViewLayoutRibbonSeparator(NORMAL_BORDER_RIGHT2007, ignoreMouse: true);
		_layoutNormalMain.Add(_layoutNormalTitle, ViewDockStyle.Bottom);
		_layoutNormalMain.Add(_layoutNormalSepTop, ViewDockStyle.Top);
		_layoutNormalMain.Add(_layoutNormalSepLeft, ViewDockStyle.Left);
		_layoutNormalMain.Add(_layoutNormalSepRight, ViewDockStyle.Right);
		_layoutNormalMain.Add(_layoutNormalContent, ViewDockStyle.Fill);
		_viewNormalTitle = new ViewDrawRibbonGroupTitle(_ribbon, _ribbonGroup);
		_layoutNormalTitle.Add(_viewNormalTitle, ViewDockStyle.Fill);
		_viewNormalDialog = new ViewLayoutRibbonGroupButton(_ribbon, _ribbonGroup, _needPaint);
		_layoutNormalContent.DialogView = _viewNormalDialog;
		_layoutNormalTitle.Add(_viewNormalDialog, ViewDockStyle.Right);
		_paletteContextBack = new PaletteRibbonContextBack(_ribbon);
		_lastRibbonShape = PaletteRibbonShape.Office2007;
		_totalBorders = TOTAL_LEFT_RIGHT_BORDERS_2007;
	}

	private void CreateCollapsedView()
	{
		_layoutCollapsedMain = new ViewLayoutDocker();
		_collapsedController = new CollapsedGroupController(_ribbon, _layoutCollapsedMain, _needPaint);
		_collapsedController.Click += OnCollapsedClick;
		_layoutCollapsedMain.MouseController = _collapsedController;
		_layoutCollapsedMain.SourceController = _collapsedController;
		_layoutCollapsedMain.KeyController = _collapsedController;
		ViewLayoutRibbonPadding viewLayoutRibbonPadding = new ViewLayoutRibbonPadding(COLLAPSED_PADDING);
		_layoutCollapsedMain.Add(viewLayoutRibbonPadding, ViewDockStyle.Fill);
		ViewLayoutDocker viewLayoutDocker = new ViewLayoutDocker();
		viewLayoutRibbonPadding.Add(viewLayoutDocker);
		ViewLayoutRibbonRowCenter viewLayoutRibbonRowCenter = new ViewLayoutRibbonRowCenter();
		_viewCollapsedText2 = new ViewDrawRibbonGroupText(_ribbon, _ribbonGroup, firstText: false);
		viewLayoutRibbonRowCenter.Add(_viewCollapsedText2);
		viewLayoutRibbonRowCenter.Add(new ViewLayoutRibbonSeparator(2, 10, ignoreMouse: true));
		viewLayoutRibbonRowCenter.Add(new ViewDrawRibbonDropArrow(_ribbon));
		viewLayoutRibbonRowCenter.Add(new ViewLayoutRibbonSeparator(2, 10, ignoreMouse: true));
		viewLayoutDocker.Add(viewLayoutRibbonRowCenter, ViewDockStyle.Top);
		_viewCollapsedText1 = new ViewDrawRibbonGroupText(_ribbon, _ribbonGroup, firstText: true);
		viewLayoutDocker.Add(_viewCollapsedText1, ViewDockStyle.Top);
		_layoutCollapsedImagePadding = new ViewLayoutRibbonCenterPadding(COLLAPSED_IMAGE_PADDING_2007);
		viewLayoutDocker.Add(_layoutCollapsedImagePadding, ViewDockStyle.Top);
		ViewDrawRibbonGroupImage item = new ViewDrawRibbonGroupImage(_ribbon, _ribbonGroup, this);
		_layoutCollapsedImagePadding.Add(item);
	}

	private void RenderNormalBefore(RenderContext context)
	{
		Rectangle clientRectangle = ClientRectangle;
		PaletteState paletteState = ((_ribbon.SelectedTab == null || string.IsNullOrEmpty(_ribbon.SelectedTab.ContextName)) ? (Tracking ? PaletteState.Tracking : PaletteState.Normal) : (Tracking ? PaletteState.ContextTracking : PaletteState.ContextNormal));
		IPaletteRibbonBack ribbonGroupNormalBorder;
		IPaletteRibbonBack ribbonGroupNormalTitle;
		switch (paletteState)
		{
		case PaletteState.ContextNormal:
			ribbonGroupNormalBorder = _ribbon.StateContextNormal.RibbonGroupNormalBorder;
			ribbonGroupNormalTitle = _ribbon.StateContextNormal.RibbonGroupNormalTitle;
			break;
		case PaletteState.ContextTracking:
			ribbonGroupNormalBorder = _ribbon.StateContextTracking.RibbonGroupNormalBorder;
			ribbonGroupNormalTitle = _ribbon.StateContextTracking.RibbonGroupNormalTitle;
			break;
		case PaletteState.Tracking:
			ribbonGroupNormalBorder = _ribbon.StateTracking.RibbonGroupNormalBorder;
			ribbonGroupNormalTitle = _ribbon.StateTracking.RibbonGroupNormalTitle;
			break;
		default:
			ribbonGroupNormalBorder = _ribbon.StateNormal.RibbonGroupNormalBorder;
			ribbonGroupNormalTitle = _ribbon.StateNormal.RibbonGroupNormalTitle;
			break;
		}
		ElementState = paletteState;
		if (_ribbonGroup.ShowingAsPopup)
		{
			paletteState |= PaletteState.FocusOverride;
		}
		_paletteContextBack.SetInherit(ribbonGroupNormalBorder);
		_mementoRibbonBack1 = context.Renderer.RenderRibbon.DrawRibbonBack(_ribbon.RibbonShape, context, clientRectangle, paletteState, _paletteContextBack, VisualOrientation.Top, composition: false, _mementoRibbonBack1);
		Rectangle rect = clientRectangle;
		rect.X++;
		rect.Width -= 2;
		rect.Y = rect.Bottom - _viewNormalTitle.Height;
		rect.Height = _viewNormalTitle.Height - 1;
		if (ribbonGroupNormalBorder.GetRibbonBackColorStyle(State) == PaletteRibbonColorStyle.RibbonGroupNormalBorderTrackingLight)
		{
			rect.X++;
			rect.Width -= 2;
			rect.Height--;
		}
		_mementoRibbonBack2 = context.Renderer.RenderRibbon.DrawRibbonBack(_ribbon.RibbonShape, context, rect, State, ribbonGroupNormalTitle, VisualOrientation.Top, composition: false, _mementoRibbonBack2);
	}

	private void RenderCollapsedBefore(RenderContext context)
	{
		Rectangle clientRectangle = ClientRectangle;
		if (_collapsedController.HasFocus)
		{
			ElementState = PaletteState.Tracking;
		}
		else if (_ribbon.SelectedTab != null && !string.IsNullOrEmpty(_ribbon.SelectedTab.ContextName))
		{
			ElementState = (Tracking ? PaletteState.ContextTracking : PaletteState.ContextNormal);
		}
		else
		{
			ElementState = (Tracking ? PaletteState.Tracking : PaletteState.Normal);
		}
		IPaletteRibbonBack ribbonGroupCollapsedBack;
		IPaletteRibbonBack ribbonGroupCollapsedBorder;
		switch (State)
		{
		case PaletteState.ContextNormal:
			ribbonGroupCollapsedBack = _ribbon.StateContextNormal.RibbonGroupCollapsedBack;
			ribbonGroupCollapsedBorder = _ribbon.StateContextNormal.RibbonGroupCollapsedBorder;
			break;
		case PaletteState.ContextTracking:
			ribbonGroupCollapsedBack = _ribbon.StateContextTracking.RibbonGroupCollapsedBack;
			ribbonGroupCollapsedBorder = _ribbon.StateContextTracking.RibbonGroupCollapsedBorder;
			break;
		case PaletteState.Tracking:
			ribbonGroupCollapsedBack = _ribbon.StateTracking.RibbonGroupCollapsedBack;
			ribbonGroupCollapsedBorder = _ribbon.StateTracking.RibbonGroupCollapsedBorder;
			break;
		default:
			ribbonGroupCollapsedBack = _ribbon.StateNormal.RibbonGroupCollapsedBack;
			ribbonGroupCollapsedBorder = _ribbon.StateNormal.RibbonGroupCollapsedBorder;
			break;
		}
		_paletteContextBack.SetInherit(ribbonGroupCollapsedBorder);
		_mementoRibbonBack1 = context.Renderer.RenderRibbon.DrawRibbonBack(_ribbon.RibbonShape, context, clientRectangle, State, _paletteContextBack, VisualOrientation.Top, composition: false, _mementoRibbonBack1);
		Rectangle rect = clientRectangle;
		rect.Inflate(-2, -2);
		_mementoRibbonBack2 = context.Renderer.RenderRibbon.DrawRibbonBack(_ribbon.RibbonShape, context, rect, State, ribbonGroupCollapsedBack, VisualOrientation.Top, composition: false, _mementoRibbonBack2);
	}

	private void RenderCollapsedPressedBefore(RenderContext context)
	{
		PaletteRibbonShape lastRibbonShape = _lastRibbonShape;
		PaletteRibbonShape paletteRibbonShape = lastRibbonShape;
		if (paletteRibbonShape == PaletteRibbonShape.Office2007 || paletteRibbonShape != PaletteRibbonShape.Office2010)
		{
			IPaletteBack paletteBack = _ribbon.StateCommon.RibbonGroupCollapsedButton.PaletteBack;
			IPaletteBorder paletteBorder = _ribbon.StateCommon.RibbonGroupCollapsedButton.PaletteBorder;
			if (paletteBack.GetBackDraw(PaletteState.Pressed) == InheritBool.True)
			{
				using GraphicsPath path = context.Renderer.RenderStandardBorder.GetBackPath(context, ClientRectangle, paletteBorder, VisualOrientation.Top, PaletteState.Pressed);
				Padding borderRawPadding = context.Renderer.RenderStandardBorder.GetBorderRawPadding(paletteBorder, PaletteState.Pressed, VisualOrientation.Top);
				Rectangle rect = CommonHelper.ApplyPadding(VisualOrientation.Top, ClientRectangle, borderRawPadding);
				_mementoStandardBack = context.Renderer.RenderStandardBack.DrawBack(context, rect, path, paletteBack, VisualOrientation.Top, PaletteState.Pressed, _mementoStandardBack);
			}
			if (paletteBorder.GetBorderDraw(PaletteState.Pressed) == InheritBool.True)
			{
				context.Renderer.RenderStandardBorder.DrawBorder(context, ClientRectangle, paletteBorder, VisualOrientation.Top, PaletteState.Pressed);
			}
			return;
		}
		Rectangle clientRectangle = ClientRectangle;
		IPaletteRibbonBack ribbonGroupCollapsedBack = _ribbon.StatePressed.RibbonGroupCollapsedBack;
		IPaletteRibbonBack ribbonGroupCollapsedBorder = _ribbon.StatePressed.RibbonGroupCollapsedBorder;
		PaletteState state = PaletteState.Pressed;
		if (_ribbon.SelectedTab != null && !string.IsNullOrEmpty(_ribbon.SelectedTab.ContextName))
		{
			state = PaletteState.ContextPressed;
		}
		_paletteContextBack.SetInherit(ribbonGroupCollapsedBorder);
		_mementoRibbonBack1 = context.Renderer.RenderRibbon.DrawRibbonBack(_ribbon.RibbonShape, context, clientRectangle, state, _paletteContextBack, VisualOrientation.Top, composition: false, _mementoRibbonBack1);
		Rectangle rect2 = clientRectangle;
		rect2.Inflate(-2, -2);
		_mementoRibbonBack2 = context.Renderer.RenderRibbon.DrawRibbonBack(_ribbon.RibbonShape, context, rect2, state, ribbonGroupCollapsedBack, VisualOrientation.Top, composition: false, _mementoRibbonBack2);
	}

	private void DisposeMementos()
	{
		if (_mementoRibbonBack1 != null)
		{
			_mementoRibbonBack1.Dispose();
			_mementoRibbonBack1 = null;
		}
		if (_mementoRibbonBack2 != null)
		{
			_mementoRibbonBack2.Dispose();
			_mementoRibbonBack2 = null;
		}
		if (_mementoStandardBack != null)
		{
			_mementoStandardBack.Dispose();
			_mementoStandardBack = null;
		}
	}

	private void OnCollapsedClick(object sender, MouseEventArgs e)
	{
		if (!_ribbon.InDesignMode)
		{
			_pressed = true;
			_container.Refresh();
			_popupGroup = new VisualPopupGroup(_ribbon, _ribbonGroup, _ribbon.Renderer);
			_popupGroup.Disposed += OnVisualPopupGroupDisposed;
			_popupGroup.ShowCalculatingSize(this, _container.RectangleToScreen(ClientRectangle));
		}
	}

	private void OnVisualPopupGroupDisposed(object sender, EventArgs e)
	{
		_popupGroup = null;
		_pressed = false;
		_tracking = false;
		_container.Refresh();
	}

	private void OnGroupPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		bool flag = false;
		bool flag2 = false;
		switch (e.PropertyName)
		{
		case "Visible":
		case "AllowCollapsed":
		case "DialogBoxLauncher":
		case "MaximumWidth":
		case "MinimumWidth":
			flag = true;
			break;
		case "TextLine1":
			_viewNormalTitle.MakeDirty();
			_viewCollapsedText1.MakeDirty();
			flag = true;
			break;
		case "TextLine2":
			_viewNormalTitle.MakeDirty();
			_viewCollapsedText2.MakeDirty();
			flag = true;
			break;
		case "Image":
			flag2 = true;
			break;
		}
		if (flag && _ribbonGroup.RibbonTab != null && _ribbon.SelectedTab == _ribbonGroup.RibbonTab)
		{
			OnNeedPaint(needLayout: true);
		}
		if (flag2 && _ribbonGroup.Visible && _ribbonGroup.RibbonTab != null && _ribbon.SelectedTab == _ribbonGroup.RibbonTab)
		{
			OnNeedPaint(needLayout: false, ClientRectangle);
		}
	}

	private void OnContextClick(object sender, MouseEventArgs e)
	{
		_ribbonGroup.OnDesignTimeContextMenu(new MouseEventArgs(MouseButtons.Right, 1, e.X, e.Y, 0));
	}
}
