#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit.Properties;
using Microsoft.Win32;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteSparkleBase : PaletteBase
{
	private static readonly Padding _contentPaddingGrid = new Padding(2, 1, 2, 1);

	private static readonly Padding _contentPaddingHeader1 = new Padding(3, 2, 2, 2);

	private static readonly Padding _contentPaddingHeader2 = new Padding(3, 2, 2, 2);

	private static readonly Padding _contentPaddingHeader3 = new Padding(2, 1, 2, 1);

	private static readonly Padding _contentPaddingCalendar = new Padding(2);

	private static readonly Padding _contentPaddingHeaderForm = new Padding(5, -3, 3, -3);

	private static readonly Padding _contentPaddingLabel = new Padding(3, 1, 3, 1);

	private static readonly Padding _contentPaddingLabel2 = new Padding(8, 2, 8, 2);

	private static readonly Padding _contentPaddingButtonInputControl = new Padding(0);

	private static readonly Padding _contentPaddingButton12 = new Padding(1);

	private static readonly Padding _contentPaddingButton3 = new Padding(1, 0, 1, 0);

	private static readonly Padding _contentPaddingButton4 = new Padding(3, 2, 3, 1);

	private static readonly Padding _contentPaddingButton5 = new Padding(3, 3, 3, 1);

	private static readonly Padding _contentPaddingButton6 = new Padding(3);

	private static readonly Padding _contentPaddingButton7 = new Padding(1, 1, 0, 1);

	private static readonly Padding _contentPaddingButtonForm = new Padding(0);

	private static readonly Padding _contentPaddingButtonGallery = new Padding(3, 0, 3, 0);

	private static readonly Padding _contentPaddingButtonListItem = new Padding(0, -1, 0, -1);

	private static readonly Padding _contentPaddingToolTip = new Padding(2);

	private static readonly Padding _contentPaddingSuperTip = new Padding(4);

	private static readonly Padding _contentPaddingKeyTip = new Padding(0, -1, 0, -3);

	private static readonly Padding _contentPaddingContextMenuHeading = new Padding(8, 2, 8, 0);

	private static readonly Padding _contentPaddingContextMenuImage = new Padding(0);

	private static readonly Padding _contentPaddingContextMenuItemText = new Padding(9, 1, 7, 0);

	private static readonly Padding _contentPaddingContextMenuItemTextAlt = new Padding(7, 1, 6, 0);

	private static readonly Padding _contentPaddingContextMenuItemShortcutText = new Padding(3, 1, 4, 0);

	private static readonly Padding _metricPaddingMenuOuter = new Padding(1);

	private static readonly Padding _metricPaddingRibbon = new Padding(0, 1, 1, 1);

	private static readonly Padding _metricPaddingRibbonAppButton = new Padding(3, 0, 3, 0);

	private static readonly Padding _metricPaddingHeader = new Padding(0, 3, 1, 3);

	private static readonly Padding _metricPaddingHeaderForm = new Padding(0);

	private static readonly Padding _metricPaddingInputControl = new Padding(0, 1, 0, 1);

	private static readonly Padding _metricPaddingBarInside = new Padding(3);

	private static readonly Padding _metricPaddingBarTabs = new Padding(0);

	private static readonly Padding _metricPaddingBarOutside = new Padding(0, 0, 0, 3);

	private static readonly Padding _metricPaddingPageButtons = new Padding(1, 3, 1, 3);

	private static readonly Padding _metricPaddingContextMenuItemHighlight = new Padding(1, 0, 1, 0);

	private static readonly Image _disabledDropDown = Resources.DisabledDropDownButton2;

	private static readonly Image _disabledDropUp = Resources.DisabledDropUpButton;

	private static readonly Image _disabledGalleryDrop = Resources.DisabledGalleryDropButton;

	private static readonly Image _buttonSpecClose = Resources.WhiteCloseButton;

	private static readonly Image _buttonSpecContext = Resources.WhiteContextButton;

	private static readonly Image _buttonSpecNext = Resources.WhiteNextButton;

	private static readonly Image _buttonSpecPrevious = Resources.WhitePreviousButton;

	private static readonly Image _buttonSpecArrowLeft = Resources.WhiteArrowLeftButton;

	private static readonly Image _buttonSpecArrowRight = Resources.WhiteArrowRightButton;

	private static readonly Image _buttonSpecArrowUp = Resources.WhiteArrowUpButton;

	private static readonly Image _buttonSpecArrowDown = Resources.WhiteArrowDownButton;

	private static readonly Image _buttonSpecDropDown = Resources.WhiteDropDownButton;

	private static readonly Image _buttonSpecPinVertical = Resources.WhitePinVerticalButton;

	private static readonly Image _buttonSpecPinHorizontal = Resources.WhitePinHorizontalButton;

	private static readonly Image _buttonSpecPendantClose = Resources.WhitePendantCloseA;

	private static readonly Image _buttonSpecPendantMin = Resources.WhitePendantMinA;

	private static readonly Image _buttonSpecPendantRestore = Resources.WhitePendantRestoreA;

	private static readonly Image _buttonSpecWorkspaceMaximize = Resources.WhiteMaximize;

	private static readonly Image _buttonSpecWorkspaceRestore = Resources.WhiteRestore;

	private static readonly Image _buttonSpecRibbonMinimize = Resources.WhitePendantRibbonMinimize;

	private static readonly Image _buttonSpecRibbonExpand = Resources.WhitePendantRibbonExpand;

	private static readonly Image _sparkleDropDownOutlineButton = Resources.SparkleDropDownOutlineButton;

	private static readonly Image _sparkleDropDownButton = Resources.SparkleDropDownButton;

	private static readonly Image _sparkleDropUpButton = Resources.SparkleDropUpButton;

	private static readonly Image _sparkleGalleryDropButton = Resources.SparkleGalleryDropButton;

	private static readonly Image _sparkleCloseA = Resources.SparkleButtonCloseA;

	private static readonly Image _sparkleCloseI = Resources.SparkleButtonCloseI;

	private static readonly Image _sparkleMaxA = Resources.SparkleButtonMaxA;

	private static readonly Image _sparkleMaxI = Resources.SparkleButtonMaxI;

	private static readonly Image _sparkleMinA = Resources.SparkleButtonMinA;

	private static readonly Image _sparkleMinI = Resources.SparkleButtonMinI;

	private static readonly Image _sparkleRestoreA = Resources.SparkleButtonRestoreA;

	private static readonly Image _sparkleRestoreI = Resources.SparkleButtonRestoreI;

	private static readonly Image _contextMenuChecked = Resources.SparkleGrayChecked;

	private static readonly Image _contextMenuIndeterminate = Resources.SparkleGrayIndeterminate;

	private static readonly Image _contextMenuSubMenu = Resources.BlackContextMenuSub;

	private static readonly Image _treeExpandWhite = Resources.TreeExpandWhite;

	private static readonly Image _treeCollapseBlack = Resources.TreeCollapseBlack;

	private static readonly Color _disabledText = Color.FromArgb(160, 160, 160);

	private static readonly Color _disabledBack = Color.FromArgb(224, 224, 224);

	private static readonly Color _disabledBack2 = Color.FromArgb(240, 240, 240);

	private static readonly Color _disabledBorder = Color.FromArgb(212, 212, 212);

	private static readonly Color _disabledGlyphDark = Color.FromArgb(183, 183, 183);

	private static readonly Color _disabledGlyphLight = Color.FromArgb(237, 237, 237);

	private static readonly Color _contextGroupFrameTop = Color.FromArgb(200, 249, 249, 249);

	private static readonly Color _contextGroupFrameBottom = Color.FromArgb(249, 249, 249);

	private static readonly Color _ribbonFrameBack4 = Color.White;

	private static readonly Color _toolTipBack1 = Color.FromArgb(255, 255, 234);

	private static readonly Color _toolTipBack2 = Color.FromArgb(255, 255, 204);

	private static readonly Color _contextMenuInnerBack = Color.FromArgb(250, 250, 250);

	private static readonly Color _contextMenuOuterBack = Color.FromArgb(245, 245, 245);

	private static readonly Color _contextMenuBorder = Color.FromArgb(134, 134, 134);

	private static readonly Color _contextMenuHeadingBorder = Color.FromArgb(197, 197, 197);

	private static readonly Color _contextMenuImageBackChecked = Color.FromArgb(255, 227, 149);

	private static readonly Color _contextMenuImageBorderChecked = Color.FromArgb(242, 149, 54);

	private static readonly Color[] _ribbonGroupCollapsedBackContext = new Color[2]
	{
		Color.FromArgb(48, 255, 255, 255),
		Color.FromArgb(235, 235, 235)
	};

	private static readonly Color[] _ribbonGroupCollapsedBackContextTracking = new Color[2]
	{
		Color.FromArgb(48, 255, 255, 255),
		Color.FromArgb(235, 235, 235)
	};

	private static readonly Color[] _ribbonGroupCollapsedBorderContext = new Color[4]
	{
		Color.FromArgb(128, 199, 199, 199),
		Color.FromArgb(199, 199, 199),
		Color.FromArgb(48, 255, 255, 255),
		Color.FromArgb(235, 235, 235)
	};

	private static readonly Color[] _trackBarColors = new Color[6]
	{
		Color.FromArgb(180, 180, 180),
		Color.FromArgb(33, 37, 50),
		Color.FromArgb(126, 131, 142),
		Color.FromArgb(99, 99, 99),
		Color.FromArgb(32, Color.White),
		Color.FromArgb(35, 35, 35)
	};

	private static readonly Color _inputControlTextDisabled = Color.FromArgb(172, 168, 153);

	private static readonly Color _colorDark00 = Color.Black;

	private static readonly Color _colorWhite119 = Color.FromArgb(119, 119, 119);

	private static readonly Color _colorWhite128 = Color.FromArgb(128, 128, 128);

	private static readonly Color _colorWhite150 = Color.FromArgb(150, 150, 150);

	private static readonly Color _colorWhite167 = Color.FromArgb(167, 167, 167);

	private static readonly Color _colorWhite192 = Color.FromArgb(192, 192, 192);

	private static readonly Color _colorWhite215 = Color.FromArgb(215, 219, 225);

	private static readonly Color _colorWhite220 = Color.FromArgb(220, 220, 220);

	private static readonly Color _colorWhite224 = Color.FromArgb(224, 224, 224);

	private static readonly Color _colorWhite238 = Color.FromArgb(238, 243, 250);

	private static readonly Color _colorWhite240 = Color.FromArgb(240, 240, 240);

	private static readonly Color _colorWhite245 = Color.FromArgb(245, 245, 245);

	private static readonly Color _colorWhite255 = Color.White;

	private static readonly Color _gridHeaderNormal1 = Color.FromArgb(210, 210, 210);

	private static readonly Color _gridHeaderNormal2 = Color.FromArgb(235, 235, 235);

	private static readonly Color _gridHeaderBorder = Color.FromArgb(124, 124, 124);

	private static readonly Color _menuItemDisabledBack1 = Color.FromArgb(164, 220, 220, 220);

	private static readonly Color _menuItemDisabledBack2 = Color.FromArgb(164, 190, 190, 190);

	private static readonly Color _menuItemDisabledBorder = Color.FromArgb(164, 172, 172, 172);

	private static readonly Color _menuItemDisabledImageBorder = Color.FromArgb(200, 200, 200);

	private KryptonColorTableSparkle _table;

	private Font _header1ShortFont;

	private Font _header2ShortFont;

	private Font _header1LongFont;

	private Font _header2LongFont;

	private Font _superToolFont;

	private Font _headerFormFont;

	private Font _buttonFont;

	private Font _buttonFontNavigatorStack;

	private Font _buttonFontNavigatorMini;

	private Font _tabFontNormal;

	private Font _tabFontSelected;

	private Font _ribbonTabFont;

	private Font _gridFont;

	private Font _calendarFont;

	private Font _calendarBoldFont;

	private Font _boldFont;

	private Font _italicFont;

	private Color[] _ribbonColors;

	private Color[] _sparkleColors;

	private Color[] _appButtonNormal;

	private Color[] _appButtonTrack;

	private Color[] _appButtonPressed;

	private Color[] _ribbonGroupCollapsedBorderContextTracking;

	private ImageList _checkBoxList;

	private Image[] _radioButtonArray;

	private string _baseFontName;

	public virtual string BaseFontName
	{
		get
		{
			if (string.IsNullOrEmpty(_baseFontName))
			{
				return "Segoe UI";
			}
			return _baseFontName;
		}
		set
		{
			if ((string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(_baseFontName)) || (!string.IsNullOrEmpty(value) && string.IsNullOrEmpty(_baseFontName)))
			{
				_baseFontName = value;
				DefineFonts();
				OnPalettePaint(this, new PaletteLayoutEventArgs(needLayout: true, needColorTable: false));
			}
		}
	}

	public override KryptonColorTable ColorTable
	{
		get
		{
			if (_table == null)
			{
				_table = new KryptonColorTableSparkle(_ribbonColors, _sparkleColors, InheritBool.True, this);
			}
			return _table;
		}
	}

	public PaletteSparkleBase(Color[] ribbonColors, Color[] sparkleColors, Color[] appButtonNormal, Color[] appButtonTrack, Color[] appButtonPressed, Color[] ribbonGroupCollapsedBorderContextTracking, ImageList checkBoxList, Image[] radioButtonArray)
	{
		_ribbonColors = ribbonColors;
		_sparkleColors = sparkleColors;
		_appButtonNormal = appButtonNormal;
		_appButtonTrack = appButtonTrack;
		_appButtonPressed = appButtonPressed;
		_ribbonGroupCollapsedBorderContextTracking = ribbonGroupCollapsedBorderContextTracking;
		_checkBoxList = checkBoxList;
		_radioButtonArray = radioButtonArray;
		DefineFonts();
	}

	public override InheritBool GetAllowFormChrome()
	{
		return InheritBool.True;
	}

	public override IRenderer GetRenderer()
	{
		return KryptonManager.RenderSparkle;
	}

	public override InheritBool GetBackDraw(PaletteBackStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return InheritBool.Inherit;
		}
		switch (style)
		{
		case PaletteBackStyle.SeparatorLowProfile:
		case PaletteBackStyle.SeparatorCustom1:
			return InheritBool.False;
		case PaletteBackStyle.ButtonLowProfile:
		case PaletteBackStyle.ButtonButtonSpec:
		case PaletteBackStyle.ButtonBreadCrumb:
		case PaletteBackStyle.ButtonCalendarDay:
		case PaletteBackStyle.ButtonNavigatorOverflow:
		case PaletteBackStyle.ButtonListItem:
		case PaletteBackStyle.ButtonForm:
		case PaletteBackStyle.ButtonFormClose:
		case PaletteBackStyle.ButtonCommand:
			if ((uint)(state - 1) <= 1u || state == PaletteState.NormalDefaultOverride)
			{
				return InheritBool.False;
			}
			return InheritBool.True;
		case PaletteBackStyle.ContextMenuItemImage:
		case PaletteBackStyle.ContextMenuItemHighlight:
			if (state == PaletteState.Normal || state == PaletteState.NormalDefaultOverride)
			{
				return InheritBool.False;
			}
			return InheritBool.True;
		case PaletteBackStyle.ButtonInputControl:
			if (state == PaletteState.Disabled || state == PaletteState.Normal)
			{
				return InheritBool.False;
			}
			return InheritBool.True;
		case PaletteBackStyle.TabLowProfile:
			if (state == PaletteState.CheckedNormal || state == PaletteState.CheckedTracking || state == PaletteState.CheckedPressed)
			{
				return InheritBool.True;
			}
			return InheritBool.False;
		default:
			return InheritBool.True;
		}
	}

	public override PaletteGraphicsHint GetBackGraphicsHint(PaletteBackStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteGraphicsHint.Inherit;
		}
		switch (style)
		{
		case PaletteBackStyle.HeaderForm:
		case PaletteBackStyle.FormMain:
		case PaletteBackStyle.FormCustom1:
			return PaletteGraphicsHint.AntiAlias;
		case PaletteBackStyle.ButtonStandalone:
		case PaletteBackStyle.ButtonAlternate:
		case PaletteBackStyle.ButtonLowProfile:
		case PaletteBackStyle.ButtonButtonSpec:
		case PaletteBackStyle.ButtonBreadCrumb:
		case PaletteBackStyle.ButtonCalendarDay:
		case PaletteBackStyle.ButtonCluster:
		case PaletteBackStyle.ButtonGallery:
		case PaletteBackStyle.ButtonNavigatorStack:
		case PaletteBackStyle.ButtonNavigatorOverflow:
		case PaletteBackStyle.ButtonNavigatorMini:
		case PaletteBackStyle.ButtonInputControl:
		case PaletteBackStyle.ButtonListItem:
		case PaletteBackStyle.ButtonForm:
		case PaletteBackStyle.ButtonFormClose:
		case PaletteBackStyle.ButtonCommand:
		case PaletteBackStyle.ButtonCustom1:
		case PaletteBackStyle.ButtonCustom2:
		case PaletteBackStyle.ButtonCustom3:
		case PaletteBackStyle.ControlClient:
		case PaletteBackStyle.ControlAlternate:
		case PaletteBackStyle.ControlGroupBox:
		case PaletteBackStyle.ControlToolTip:
		case PaletteBackStyle.ControlRibbon:
		case PaletteBackStyle.ControlRibbonAppMenu:
		case PaletteBackStyle.ControlCustom1:
		case PaletteBackStyle.ContextMenuOuter:
		case PaletteBackStyle.ContextMenuInner:
		case PaletteBackStyle.ContextMenuHeading:
		case PaletteBackStyle.ContextMenuSeparator:
		case PaletteBackStyle.ContextMenuItemImage:
		case PaletteBackStyle.ContextMenuItemSplit:
		case PaletteBackStyle.ContextMenuItemImageColumn:
		case PaletteBackStyle.ContextMenuItemHighlight:
		case PaletteBackStyle.InputControlStandalone:
		case PaletteBackStyle.InputControlRibbon:
		case PaletteBackStyle.InputControlCustom1:
		case PaletteBackStyle.GridHeaderColumnList:
		case PaletteBackStyle.GridHeaderRowList:
		case PaletteBackStyle.GridDataCellList:
		case PaletteBackStyle.GridBackgroundList:
		case PaletteBackStyle.GridHeaderColumnSheet:
		case PaletteBackStyle.GridHeaderRowSheet:
		case PaletteBackStyle.GridDataCellSheet:
		case PaletteBackStyle.GridBackgroundSheet:
		case PaletteBackStyle.GridHeaderColumnCustom1:
		case PaletteBackStyle.GridHeaderRowCustom1:
		case PaletteBackStyle.GridDataCellCustom1:
		case PaletteBackStyle.GridBackgroundCustom1:
		case PaletteBackStyle.HeaderPrimary:
		case PaletteBackStyle.HeaderSecondary:
		case PaletteBackStyle.HeaderDockInactive:
		case PaletteBackStyle.HeaderDockActive:
		case PaletteBackStyle.HeaderCalendar:
		case PaletteBackStyle.HeaderCustom1:
		case PaletteBackStyle.HeaderCustom2:
		case PaletteBackStyle.PanelClient:
		case PaletteBackStyle.PanelAlternate:
		case PaletteBackStyle.PanelRibbonInactive:
		case PaletteBackStyle.PanelCustom1:
		case PaletteBackStyle.SeparatorLowProfile:
		case PaletteBackStyle.SeparatorHighProfile:
		case PaletteBackStyle.SeparatorHighInternalProfile:
		case PaletteBackStyle.SeparatorCustom1:
		case PaletteBackStyle.TabHighProfile:
		case PaletteBackStyle.TabStandardProfile:
		case PaletteBackStyle.TabLowProfile:
		case PaletteBackStyle.TabOneNote:
		case PaletteBackStyle.TabDock:
		case PaletteBackStyle.TabDockAutoHidden:
		case PaletteBackStyle.TabCustom1:
		case PaletteBackStyle.TabCustom2:
		case PaletteBackStyle.TabCustom3:
			return PaletteGraphicsHint.None;
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override Color GetBackColor1(PaletteBackStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideStateExclude(state, PaletteState.NormalDefaultOverride))
		{
			return Color.Empty;
		}
		switch (style)
		{
		case PaletteBackStyle.ControlGroupBox:
		case PaletteBackStyle.GridBackgroundList:
		case PaletteBackStyle.GridBackgroundSheet:
		case PaletteBackStyle.GridBackgroundCustom1:
		case PaletteBackStyle.PanelClient:
		case PaletteBackStyle.PanelRibbonInactive:
		case PaletteBackStyle.PanelCustom1:
		case PaletteBackStyle.SeparatorLowProfile:
		case PaletteBackStyle.SeparatorCustom1:
		case PaletteBackStyle.FormMain:
		case PaletteBackStyle.FormCustom1:
			return _sparkleColors[0];
		case PaletteBackStyle.PanelAlternate:
			return _sparkleColors[1];
		case PaletteBackStyle.HeaderForm:
			return _colorDark00;
		case PaletteBackStyle.HeaderPrimary:
		case PaletteBackStyle.HeaderDockInactive:
		case PaletteBackStyle.HeaderCustom1:
		case PaletteBackStyle.HeaderCustom2:
			if (state == PaletteState.Disabled)
			{
				return _disabledBack;
			}
			return _sparkleColors[5];
		case PaletteBackStyle.HeaderDockActive:
			if (state == PaletteState.Disabled)
			{
				return _disabledBack;
			}
			return _sparkleColors[10];
		case PaletteBackStyle.HeaderSecondary:
		case PaletteBackStyle.HeaderCalendar:
			if (state == PaletteState.Disabled)
			{
				return _disabledBack;
			}
			return _sparkleColors[2];
		case PaletteBackStyle.ControlClient:
		case PaletteBackStyle.ControlAlternate:
		case PaletteBackStyle.ControlCustom1:
			return _colorWhite238;
		case PaletteBackStyle.ButtonStandalone:
		case PaletteBackStyle.ButtonAlternate:
		case PaletteBackStyle.ButtonLowProfile:
		case PaletteBackStyle.ButtonButtonSpec:
		case PaletteBackStyle.ButtonBreadCrumb:
		case PaletteBackStyle.ButtonCluster:
		case PaletteBackStyle.ButtonGallery:
		case PaletteBackStyle.ButtonNavigatorStack:
		case PaletteBackStyle.ButtonNavigatorOverflow:
		case PaletteBackStyle.ButtonNavigatorMini:
		case PaletteBackStyle.ButtonInputControl:
		case PaletteBackStyle.ButtonCustom1:
		case PaletteBackStyle.ButtonCustom2:
		case PaletteBackStyle.ButtonCustom3:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBack;
			case PaletteState.Normal:
				if (style == PaletteBackStyle.ButtonNavigatorStack)
				{
					return _sparkleColors[2];
				}
				return _sparkleColors[5];
			case PaletteState.NormalDefaultOverride:
				return Color.Empty;
			case PaletteState.Tracking:
				return _sparkleColors[6];
			case PaletteState.Pressed:
				return _sparkleColors[8];
			case PaletteState.CheckedNormal:
				if (style == PaletteBackStyle.ButtonInputControl)
				{
					return _sparkleColors[5];
				}
				return _sparkleColors[10];
			case PaletteState.CheckedTracking:
				if (style == PaletteBackStyle.ButtonInputControl)
				{
					return _sparkleColors[5];
				}
				return _sparkleColors[12];
			case PaletteState.CheckedPressed:
				return _sparkleColors[14];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.ButtonCalendarDay:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBack;
			case PaletteState.Normal:
				return _sparkleColors[5];
			case PaletteState.NormalDefaultOverride:
				return Color.Empty;
			case PaletteState.Tracking:
				return _sparkleColors[27];
			case PaletteState.Pressed:
			case PaletteState.CheckedNormal:
				return _sparkleColors[15];
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _sparkleColors[12];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.ButtonForm:
		case PaletteBackStyle.ButtonFormClose:
			switch (state)
			{
			case PaletteState.Disabled:
			case PaletteState.Normal:
			case PaletteState.NormalDefaultOverride:
				return Color.Empty;
			case PaletteState.CheckedNormal:
				return _sparkleColors[10];
			case PaletteState.Tracking:
				return _sparkleColors[5];
			case PaletteState.CheckedTracking:
				return _sparkleColors[12];
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				return _sparkleColors[14];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.ButtonListItem:
		case PaletteBackStyle.ButtonCommand:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBack;
			case PaletteState.Normal:
			case PaletteState.Tracking:
			case PaletteState.NormalDefaultOverride:
				return _colorWhite215;
			case PaletteState.Pressed:
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _sparkleColors[15];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.ContextMenuOuter:
		case PaletteBackStyle.ContextMenuInner:
		case PaletteBackStyle.ContextMenuItemImageColumn:
			return _colorWhite240;
		case PaletteBackStyle.ContextMenuSeparator:
			return _colorWhite255;
		case PaletteBackStyle.ContextMenuHeading:
			return _sparkleColors[16];
		case PaletteBackStyle.ContextMenuItemHighlight:
			if (state == PaletteState.Disabled)
			{
				return _menuItemDisabledBack1;
			}
			return _sparkleColors[17];
		case PaletteBackStyle.ContextMenuItemImage:
			if (state == PaletteState.Disabled)
			{
				return _menuItemDisabledBack1;
			}
			return _sparkleColors[20];
		case PaletteBackStyle.InputControlStandalone:
		case PaletteBackStyle.InputControlRibbon:
		case PaletteBackStyle.InputControlCustom1:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBack;
			default:
				if (style != PaletteBackStyle.InputControlStandalone)
				{
					return _colorWhite192;
				}
				goto case PaletteState.Tracking;
			case PaletteState.Tracking:
				return _colorWhite238;
			}
		case PaletteBackStyle.GridDataCellList:
		case PaletteBackStyle.GridDataCellCustom1:
			if (state == PaletteState.CheckedNormal)
			{
				return _sparkleColors[15];
			}
			return _colorWhite238;
		case PaletteBackStyle.GridDataCellSheet:
			if (state == PaletteState.CheckedNormal)
			{
				return _sparkleColors[10];
			}
			return _colorWhite238;
		case PaletteBackStyle.GridHeaderColumnList:
		case PaletteBackStyle.GridHeaderColumnCustom1:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBack;
			default:
				return _gridHeaderNormal1;
			case PaletteState.Tracking:
				return _sparkleColors[24];
			case PaletteState.Pressed:
			case PaletteState.CheckedNormal:
				return _sparkleColors[26];
			}
		case PaletteBackStyle.GridHeaderRowList:
		case PaletteBackStyle.GridHeaderRowCustom1:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBack;
			default:
				return _gridHeaderNormal2;
			case PaletteState.Tracking:
				return _sparkleColors[25];
			case PaletteState.Pressed:
			case PaletteState.CheckedNormal:
				return _sparkleColors[27];
			}
		case PaletteBackStyle.GridHeaderColumnSheet:
		case PaletteBackStyle.GridHeaderRowSheet:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBack;
			default:
				return _gridHeaderNormal1;
			case PaletteState.Tracking:
				return _sparkleColors[24];
			case PaletteState.Pressed:
			case PaletteState.CheckedNormal:
				return _sparkleColors[15];
			}
		case PaletteBackStyle.SeparatorHighInternalProfile:
			if (state == PaletteState.Disabled)
			{
				return _disabledBack;
			}
			return _colorWhite240;
		case PaletteBackStyle.SeparatorHighProfile:
			if (state == PaletteState.Disabled)
			{
				return _disabledBack;
			}
			return _colorWhite167;
		case PaletteBackStyle.ControlToolTip:
			return _toolTipBack1;
		case PaletteBackStyle.ContextMenuItemSplit:
			if (state == PaletteState.Disabled)
			{
				return _colorWhite240;
			}
			return _colorWhite255;
		case PaletteBackStyle.TabHighProfile:
		case PaletteBackStyle.TabStandardProfile:
		case PaletteBackStyle.TabLowProfile:
		case PaletteBackStyle.TabOneNote:
		case PaletteBackStyle.TabCustom1:
		case PaletteBackStyle.TabCustom2:
		case PaletteBackStyle.TabCustom3:
			switch (state)
			{
			case PaletteState.Disabled:
				if (style == PaletteBackStyle.TabLowProfile)
				{
					return Color.Empty;
				}
				return _disabledBack;
			case PaletteState.Normal:
				if (style == PaletteBackStyle.TabLowProfile)
				{
					return Color.Empty;
				}
				return _colorWhite220;
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				if (style == PaletteBackStyle.TabLowProfile)
				{
					return Color.Empty;
				}
				return _colorWhite220;
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				if (style == PaletteBackStyle.TabHighProfile)
				{
					return _sparkleColors[29];
				}
				return _colorWhite220;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.TabDock:
		case PaletteBackStyle.TabDockAutoHidden:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBack;
			case PaletteState.Normal:
			case PaletteState.Tracking:
			case PaletteState.Pressed:
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _colorWhite220;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.ControlRibbon:
			return _ribbonColors[75];
		case PaletteBackStyle.ControlRibbonAppMenu:
			return _ribbonColors[190];
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override Color GetBackColor2(PaletteBackStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideStateExclude(state, PaletteState.NormalDefaultOverride))
		{
			return Color.Empty;
		}
		switch (style)
		{
		case PaletteBackStyle.ControlGroupBox:
		case PaletteBackStyle.GridBackgroundList:
		case PaletteBackStyle.GridBackgroundSheet:
		case PaletteBackStyle.GridBackgroundCustom1:
		case PaletteBackStyle.HeaderForm:
		case PaletteBackStyle.PanelClient:
		case PaletteBackStyle.PanelRibbonInactive:
		case PaletteBackStyle.PanelCustom1:
		case PaletteBackStyle.SeparatorLowProfile:
		case PaletteBackStyle.SeparatorCustom1:
		case PaletteBackStyle.FormMain:
		case PaletteBackStyle.FormCustom1:
			return _sparkleColors[0];
		case PaletteBackStyle.PanelAlternate:
			return _sparkleColors[1];
		case PaletteBackStyle.HeaderCalendar:
			if (state == PaletteState.Disabled)
			{
				return _disabledBack2;
			}
			return _sparkleColors[2];
		case PaletteBackStyle.HeaderPrimary:
		case PaletteBackStyle.HeaderSecondary:
		case PaletteBackStyle.HeaderDockInactive:
		case PaletteBackStyle.HeaderCustom1:
		case PaletteBackStyle.HeaderCustom2:
			if (state == PaletteState.Disabled)
			{
				return _disabledBack2;
			}
			return _sparkleColors[0];
		case PaletteBackStyle.HeaderDockActive:
			if (state == PaletteState.Disabled)
			{
				return _disabledBack2;
			}
			return _sparkleColors[11];
		case PaletteBackStyle.ControlClient:
		case PaletteBackStyle.ControlAlternate:
		case PaletteBackStyle.ControlCustom1:
			return _colorWhite238;
		case PaletteBackStyle.ButtonStandalone:
		case PaletteBackStyle.ButtonAlternate:
		case PaletteBackStyle.ButtonLowProfile:
		case PaletteBackStyle.ButtonButtonSpec:
		case PaletteBackStyle.ButtonBreadCrumb:
		case PaletteBackStyle.ButtonCluster:
		case PaletteBackStyle.ButtonGallery:
		case PaletteBackStyle.ButtonNavigatorStack:
		case PaletteBackStyle.ButtonNavigatorOverflow:
		case PaletteBackStyle.ButtonNavigatorMini:
		case PaletteBackStyle.ButtonInputControl:
		case PaletteBackStyle.ButtonCustom1:
		case PaletteBackStyle.ButtonCustom2:
		case PaletteBackStyle.ButtonCustom3:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBack2;
			case PaletteState.Normal:
				return _sparkleColors[22];
			case PaletteState.NormalDefaultOverride:
				return _sparkleColors[23];
			case PaletteState.Tracking:
				return _sparkleColors[7];
			case PaletteState.Pressed:
				return _sparkleColors[9];
			case PaletteState.CheckedNormal:
				if (style == PaletteBackStyle.ButtonInputControl)
				{
					return _sparkleColors[22];
				}
				return _sparkleColors[11];
			case PaletteState.CheckedTracking:
				if (style == PaletteBackStyle.ButtonInputControl)
				{
					return _sparkleColors[22];
				}
				return _sparkleColors[13];
			case PaletteState.CheckedPressed:
				return _sparkleColors[11];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.ButtonCalendarDay:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBack;
			case PaletteState.Normal:
				return _sparkleColors[5];
			case PaletteState.NormalDefaultOverride:
				return Color.Empty;
			case PaletteState.Tracking:
				return _sparkleColors[27];
			case PaletteState.Pressed:
			case PaletteState.CheckedNormal:
				return _sparkleColors[15];
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _sparkleColors[12];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.ButtonForm:
		case PaletteBackStyle.ButtonFormClose:
			switch (state)
			{
			case PaletteState.Disabled:
			case PaletteState.Normal:
			case PaletteState.NormalDefaultOverride:
				return Color.Empty;
			case PaletteState.CheckedNormal:
				return _sparkleColors[11];
			case PaletteState.Tracking:
				return _sparkleColors[22];
			case PaletteState.CheckedTracking:
				return _sparkleColors[13];
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				return _sparkleColors[11];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.ButtonListItem:
		case PaletteBackStyle.ButtonCommand:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBack2;
			case PaletteState.Normal:
			case PaletteState.Tracking:
			case PaletteState.NormalDefaultOverride:
				return _colorWhite215;
			case PaletteState.Pressed:
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _sparkleColors[15];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.ContextMenuInner:
			return _colorWhite240;
		case PaletteBackStyle.ContextMenuOuter:
			return _colorWhite245;
		case PaletteBackStyle.ContextMenuSeparator:
			return _colorWhite255;
		case PaletteBackStyle.ContextMenuItemImageColumn:
			return _colorWhite224;
		case PaletteBackStyle.ContextMenuHeading:
			return _sparkleColors[16];
		case PaletteBackStyle.ContextMenuItemHighlight:
			if (state == PaletteState.Disabled)
			{
				return _menuItemDisabledBack2;
			}
			return _sparkleColors[18];
		case PaletteBackStyle.ContextMenuItemImage:
			if (state == PaletteState.Disabled)
			{
				return _menuItemDisabledBack1;
			}
			return _sparkleColors[20];
		case PaletteBackStyle.InputControlStandalone:
		case PaletteBackStyle.InputControlRibbon:
		case PaletteBackStyle.InputControlCustom1:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBack2;
			default:
				if (style != PaletteBackStyle.InputControlStandalone)
				{
					return _colorWhite192;
				}
				goto case PaletteState.Tracking;
			case PaletteState.Tracking:
				return _colorWhite238;
			}
		case PaletteBackStyle.GridDataCellList:
		case PaletteBackStyle.GridDataCellCustom1:
			if (state == PaletteState.CheckedNormal)
			{
				return _sparkleColors[15];
			}
			return _colorWhite238;
		case PaletteBackStyle.GridDataCellSheet:
			if (state == PaletteState.CheckedNormal)
			{
				return _sparkleColors[11];
			}
			return _colorWhite238;
		case PaletteBackStyle.GridHeaderColumnList:
		case PaletteBackStyle.GridHeaderColumnCustom1:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBack;
			default:
				return _gridHeaderNormal2;
			case PaletteState.Tracking:
				return _sparkleColors[25];
			case PaletteState.Pressed:
			case PaletteState.CheckedNormal:
				return _sparkleColors[27];
			}
		case PaletteBackStyle.GridHeaderRowList:
		case PaletteBackStyle.GridHeaderRowCustom1:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBack;
			default:
				return _gridHeaderNormal1;
			case PaletteState.Tracking:
				return _sparkleColors[24];
			case PaletteState.Pressed:
			case PaletteState.CheckedNormal:
				return _sparkleColors[26];
			}
		case PaletteBackStyle.GridHeaderColumnSheet:
		case PaletteBackStyle.GridHeaderRowSheet:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBack2;
			default:
				return _gridHeaderNormal1;
			case PaletteState.Tracking:
				return _sparkleColors[24];
			case PaletteState.Pressed:
			case PaletteState.CheckedNormal:
				return _sparkleColors[15];
			}
		case PaletteBackStyle.SeparatorHighInternalProfile:
			if (state == PaletteState.Disabled)
			{
				return _disabledBack;
			}
			return _colorWhite192;
		case PaletteBackStyle.SeparatorHighProfile:
			if (state == PaletteState.Disabled)
			{
				return _disabledBack2;
			}
			return _colorWhite119;
		case PaletteBackStyle.TabHighProfile:
		case PaletteBackStyle.TabStandardProfile:
		case PaletteBackStyle.TabLowProfile:
		case PaletteBackStyle.TabOneNote:
		case PaletteBackStyle.TabCustom1:
		case PaletteBackStyle.TabCustom2:
		case PaletteBackStyle.TabCustom3:
			switch (state)
			{
			case PaletteState.Disabled:
				if (style == PaletteBackStyle.TabLowProfile)
				{
					return Color.Empty;
				}
				return _disabledBack;
			case PaletteState.Normal:
				if (style == PaletteBackStyle.TabLowProfile)
				{
					return Color.Empty;
				}
				return _colorWhite220;
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				if (style == PaletteBackStyle.TabLowProfile)
				{
					return Color.Empty;
				}
				return _colorWhite238;
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _colorWhite238;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.TabDock:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBack;
			case PaletteState.Normal:
				return _colorWhite220;
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				return _ribbonColors[50];
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _colorWhite238;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.TabDockAutoHidden:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBack;
			case PaletteState.Normal:
			case PaletteState.CheckedNormal:
				return _colorWhite220;
			case PaletteState.Tracking:
			case PaletteState.Pressed:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _ribbonColors[50];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.ContextMenuItemSplit:
			if (state == PaletteState.Disabled)
			{
				return _colorWhite240;
			}
			return _colorWhite255;
		case PaletteBackStyle.ControlRibbon:
			return _ribbonColors[75];
		case PaletteBackStyle.ControlRibbonAppMenu:
			return _ribbonColors[191];
		case PaletteBackStyle.ControlToolTip:
			return _toolTipBack2;
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override PaletteColorStyle GetBackColorStyle(PaletteBackStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteColorStyle.Inherit;
		}
		switch (style)
		{
		case PaletteBackStyle.ButtonCalendarDay:
		case PaletteBackStyle.HeaderCalendar:
		case PaletteBackStyle.FormMain:
		case PaletteBackStyle.FormCustom1:
			return PaletteColorStyle.Solid;
		case PaletteBackStyle.HeaderForm:
			return PaletteColorStyle.Linear;
		case PaletteBackStyle.HeaderPrimary:
		case PaletteBackStyle.HeaderSecondary:
		case PaletteBackStyle.HeaderDockInactive:
		case PaletteBackStyle.HeaderCustom1:
		case PaletteBackStyle.HeaderCustom2:
			if (state == PaletteState.Disabled)
			{
				return PaletteColorStyle.GlassBottom;
			}
			return PaletteColorStyle.GlassSimpleFull;
		case PaletteBackStyle.HeaderDockActive:
			return PaletteColorStyle.GlassBottom;
		case PaletteBackStyle.ControlClient:
		case PaletteBackStyle.ControlAlternate:
		case PaletteBackStyle.ControlGroupBox:
		case PaletteBackStyle.ControlRibbon:
		case PaletteBackStyle.ControlCustom1:
		case PaletteBackStyle.ContextMenuInner:
		case PaletteBackStyle.PanelClient:
		case PaletteBackStyle.PanelAlternate:
		case PaletteBackStyle.PanelRibbonInactive:
		case PaletteBackStyle.PanelCustom1:
			return PaletteColorStyle.Solid;
		case PaletteBackStyle.ContextMenuHeading:
			return PaletteColorStyle.SolidBottomLine;
		case PaletteBackStyle.ContextMenuItemImageColumn:
			return PaletteColorStyle.SolidRightLine;
		case PaletteBackStyle.ContextMenuOuter:
			return PaletteColorStyle.SolidAllLine;
		case PaletteBackStyle.ButtonListItem:
		case PaletteBackStyle.ButtonCommand:
		case PaletteBackStyle.ContextMenuItemHighlight:
			return PaletteColorStyle.Linear;
		case PaletteBackStyle.ButtonStandalone:
		case PaletteBackStyle.ButtonLowProfile:
		case PaletteBackStyle.ButtonButtonSpec:
		case PaletteBackStyle.ButtonBreadCrumb:
		case PaletteBackStyle.ButtonCluster:
		case PaletteBackStyle.ButtonGallery:
		case PaletteBackStyle.ButtonNavigatorStack:
		case PaletteBackStyle.ButtonNavigatorOverflow:
		case PaletteBackStyle.ButtonNavigatorMini:
		case PaletteBackStyle.ButtonForm:
		case PaletteBackStyle.ButtonFormClose:
		case PaletteBackStyle.ButtonCustom1:
		case PaletteBackStyle.ButtonCustom2:
		case PaletteBackStyle.ButtonCustom3:
			return PaletteColorStyle.GlassBottom;
		case PaletteBackStyle.ButtonAlternate:
			return PaletteColorStyle.Linear50;
		case PaletteBackStyle.GridDataCellList:
		case PaletteBackStyle.GridBackgroundList:
		case PaletteBackStyle.GridBackgroundSheet:
		case PaletteBackStyle.GridDataCellCustom1:
		case PaletteBackStyle.GridBackgroundCustom1:
			return PaletteColorStyle.Solid;
		case PaletteBackStyle.GridHeaderRowList:
		case PaletteBackStyle.GridHeaderRowCustom1:
			return PaletteColorStyle.Linear;
		case PaletteBackStyle.GridHeaderColumnList:
		case PaletteBackStyle.GridHeaderColumnCustom1:
			return PaletteColorStyle.GlassBottom;
		case PaletteBackStyle.GridDataCellSheet:
			if (state == PaletteState.CheckedNormal)
			{
				return PaletteColorStyle.GlassBottom;
			}
			return PaletteColorStyle.Solid;
		case PaletteBackStyle.GridHeaderColumnSheet:
		case PaletteBackStyle.GridHeaderRowSheet:
			return PaletteColorStyle.Solid;
		case PaletteBackStyle.TabHighProfile:
		case PaletteBackStyle.TabStandardProfile:
		case PaletteBackStyle.TabLowProfile:
		case PaletteBackStyle.TabCustom1:
		case PaletteBackStyle.TabCustom2:
		case PaletteBackStyle.TabCustom3:
			return PaletteColorStyle.GlassFade;
		case PaletteBackStyle.TabOneNote:
		case PaletteBackStyle.TabDock:
		case PaletteBackStyle.TabDockAutoHidden:
			return PaletteColorStyle.OneNote;
		case PaletteBackStyle.InputControlStandalone:
		case PaletteBackStyle.InputControlRibbon:
		case PaletteBackStyle.InputControlCustom1:
		case PaletteBackStyle.SeparatorLowProfile:
		case PaletteBackStyle.SeparatorCustom1:
			return PaletteColorStyle.Solid;
		case PaletteBackStyle.ControlRibbonAppMenu:
			return PaletteColorStyle.Switch90;
		case PaletteBackStyle.ContextMenuSeparator:
		case PaletteBackStyle.ContextMenuItemSplit:
			if (state == PaletteState.Tracking)
			{
				return PaletteColorStyle.GlassTrackingFull;
			}
			return PaletteColorStyle.Solid;
		case PaletteBackStyle.ControlToolTip:
			return PaletteColorStyle.Linear;
		case PaletteBackStyle.SeparatorHighProfile:
		case PaletteBackStyle.SeparatorHighInternalProfile:
			return PaletteColorStyle.RoundedTopLight;
		case PaletteBackStyle.ContextMenuItemImage:
			return PaletteColorStyle.Solid;
		case PaletteBackStyle.ButtonInputControl:
			switch (state)
			{
			case PaletteState.Disabled:
			case PaletteState.Normal:
				return PaletteColorStyle.GlassNormalSimple;
			case PaletteState.Tracking:
				return PaletteColorStyle.GlassTrackingSimple;
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				return PaletteColorStyle.GlassPressedSimple;
			case PaletteState.CheckedNormal:
				return PaletteColorStyle.GlassCheckedSimple;
			case PaletteState.CheckedTracking:
				return PaletteColorStyle.GlassCheckedTrackingSimple;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override PaletteRectangleAlign GetBackColorAlign(PaletteBackStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteRectangleAlign.Inherit;
		}
		switch (style)
		{
		case PaletteBackStyle.ControlClient:
		case PaletteBackStyle.ControlAlternate:
		case PaletteBackStyle.ControlGroupBox:
		case PaletteBackStyle.ControlRibbon:
		case PaletteBackStyle.ControlRibbonAppMenu:
		case PaletteBackStyle.ControlCustom1:
		case PaletteBackStyle.InputControlStandalone:
		case PaletteBackStyle.InputControlRibbon:
		case PaletteBackStyle.InputControlCustom1:
		case PaletteBackStyle.GridBackgroundList:
		case PaletteBackStyle.GridBackgroundSheet:
		case PaletteBackStyle.GridBackgroundCustom1:
		case PaletteBackStyle.PanelClient:
		case PaletteBackStyle.PanelAlternate:
		case PaletteBackStyle.PanelRibbonInactive:
		case PaletteBackStyle.PanelCustom1:
		case PaletteBackStyle.FormMain:
		case PaletteBackStyle.FormCustom1:
			return PaletteRectangleAlign.Control;
		case PaletteBackStyle.ButtonStandalone:
		case PaletteBackStyle.ButtonAlternate:
		case PaletteBackStyle.ButtonLowProfile:
		case PaletteBackStyle.ButtonButtonSpec:
		case PaletteBackStyle.ButtonBreadCrumb:
		case PaletteBackStyle.ButtonCalendarDay:
		case PaletteBackStyle.ButtonCluster:
		case PaletteBackStyle.ButtonGallery:
		case PaletteBackStyle.ButtonNavigatorStack:
		case PaletteBackStyle.ButtonNavigatorOverflow:
		case PaletteBackStyle.ButtonNavigatorMini:
		case PaletteBackStyle.ButtonInputControl:
		case PaletteBackStyle.ButtonListItem:
		case PaletteBackStyle.ButtonForm:
		case PaletteBackStyle.ButtonFormClose:
		case PaletteBackStyle.ButtonCommand:
		case PaletteBackStyle.ButtonCustom1:
		case PaletteBackStyle.ButtonCustom2:
		case PaletteBackStyle.ButtonCustom3:
		case PaletteBackStyle.ControlToolTip:
		case PaletteBackStyle.ContextMenuOuter:
		case PaletteBackStyle.ContextMenuInner:
		case PaletteBackStyle.ContextMenuHeading:
		case PaletteBackStyle.ContextMenuSeparator:
		case PaletteBackStyle.ContextMenuItemImage:
		case PaletteBackStyle.ContextMenuItemSplit:
		case PaletteBackStyle.ContextMenuItemImageColumn:
		case PaletteBackStyle.ContextMenuItemHighlight:
		case PaletteBackStyle.GridHeaderColumnList:
		case PaletteBackStyle.GridHeaderRowList:
		case PaletteBackStyle.GridDataCellList:
		case PaletteBackStyle.GridHeaderColumnSheet:
		case PaletteBackStyle.GridHeaderRowSheet:
		case PaletteBackStyle.GridDataCellSheet:
		case PaletteBackStyle.GridHeaderColumnCustom1:
		case PaletteBackStyle.GridHeaderRowCustom1:
		case PaletteBackStyle.GridDataCellCustom1:
		case PaletteBackStyle.HeaderPrimary:
		case PaletteBackStyle.HeaderSecondary:
		case PaletteBackStyle.HeaderDockInactive:
		case PaletteBackStyle.HeaderDockActive:
		case PaletteBackStyle.HeaderForm:
		case PaletteBackStyle.HeaderCalendar:
		case PaletteBackStyle.HeaderCustom1:
		case PaletteBackStyle.HeaderCustom2:
		case PaletteBackStyle.SeparatorLowProfile:
		case PaletteBackStyle.SeparatorHighProfile:
		case PaletteBackStyle.SeparatorHighInternalProfile:
		case PaletteBackStyle.SeparatorCustom1:
		case PaletteBackStyle.TabHighProfile:
		case PaletteBackStyle.TabStandardProfile:
		case PaletteBackStyle.TabLowProfile:
		case PaletteBackStyle.TabOneNote:
		case PaletteBackStyle.TabDock:
		case PaletteBackStyle.TabDockAutoHidden:
		case PaletteBackStyle.TabCustom1:
		case PaletteBackStyle.TabCustom2:
		case PaletteBackStyle.TabCustom3:
			return PaletteRectangleAlign.Local;
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override float GetBackColorAngle(PaletteBackStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return -1f;
		}
		if ((uint)style <= 75u)
		{
			return 90f;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override Image GetBackImage(PaletteBackStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return null;
		}
		if ((uint)style <= 75u)
		{
			return null;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override PaletteImageStyle GetBackImageStyle(PaletteBackStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteImageStyle.Inherit;
		}
		if ((uint)style <= 75u)
		{
			return PaletteImageStyle.Tile;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override PaletteRectangleAlign GetBackImageAlign(PaletteBackStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteRectangleAlign.Inherit;
		}
		if ((uint)style <= 75u)
		{
			return PaletteRectangleAlign.Local;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override InheritBool GetBorderDraw(PaletteBorderStyle style, PaletteState state)
	{
		if (state == PaletteState.TodayOverride && style == PaletteBorderStyle.ButtonCalendarDay)
		{
			return InheritBool.True;
		}
		if (CommonHelper.IsOverrideState(state))
		{
			return InheritBool.Inherit;
		}
		switch (style)
		{
		case PaletteBorderStyle.ButtonNavigatorMini:
		case PaletteBorderStyle.ContextMenuInner:
		case PaletteBorderStyle.HeaderForm:
		case PaletteBorderStyle.SeparatorLowProfile:
		case PaletteBorderStyle.SeparatorHighProfile:
		case PaletteBorderStyle.SeparatorHighInternalProfile:
		case PaletteBorderStyle.SeparatorCustom1:
			return InheritBool.False;
		case PaletteBorderStyle.ButtonStandalone:
		case PaletteBorderStyle.ButtonAlternate:
		case PaletteBorderStyle.ButtonCluster:
		case PaletteBorderStyle.ButtonGallery:
		case PaletteBorderStyle.ButtonCustom1:
		case PaletteBorderStyle.ButtonCustom2:
		case PaletteBorderStyle.ButtonCustom3:
		case PaletteBorderStyle.ControlClient:
		case PaletteBorderStyle.ControlAlternate:
		case PaletteBorderStyle.ControlGroupBox:
		case PaletteBorderStyle.ControlToolTip:
		case PaletteBorderStyle.ControlRibbon:
		case PaletteBorderStyle.ControlRibbonAppMenu:
		case PaletteBorderStyle.ControlCustom1:
		case PaletteBorderStyle.ContextMenuOuter:
		case PaletteBorderStyle.ContextMenuHeading:
		case PaletteBorderStyle.ContextMenuSeparator:
		case PaletteBorderStyle.ContextMenuItemSplit:
		case PaletteBorderStyle.ContextMenuItemImageColumn:
		case PaletteBorderStyle.InputControlStandalone:
		case PaletteBorderStyle.InputControlRibbon:
		case PaletteBorderStyle.InputControlCustom1:
		case PaletteBorderStyle.GridHeaderColumnList:
		case PaletteBorderStyle.GridHeaderRowList:
		case PaletteBorderStyle.GridDataCellList:
		case PaletteBorderStyle.GridHeaderColumnSheet:
		case PaletteBorderStyle.GridHeaderRowSheet:
		case PaletteBorderStyle.GridDataCellSheet:
		case PaletteBorderStyle.GridHeaderColumnCustom1:
		case PaletteBorderStyle.GridHeaderRowCustom1:
		case PaletteBorderStyle.GridDataCellCustom1:
		case PaletteBorderStyle.HeaderPrimary:
		case PaletteBorderStyle.HeaderSecondary:
		case PaletteBorderStyle.HeaderDockInactive:
		case PaletteBorderStyle.HeaderDockActive:
		case PaletteBorderStyle.HeaderCalendar:
		case PaletteBorderStyle.HeaderCustom1:
		case PaletteBorderStyle.HeaderCustom2:
		case PaletteBorderStyle.TabHighProfile:
		case PaletteBorderStyle.TabStandardProfile:
		case PaletteBorderStyle.TabOneNote:
		case PaletteBorderStyle.TabDock:
		case PaletteBorderStyle.TabDockAutoHidden:
		case PaletteBorderStyle.TabCustom1:
		case PaletteBorderStyle.TabCustom2:
		case PaletteBorderStyle.TabCustom3:
		case PaletteBorderStyle.FormMain:
		case PaletteBorderStyle.FormCustom1:
			return InheritBool.True;
		case PaletteBorderStyle.ButtonLowProfile:
		case PaletteBorderStyle.ButtonButtonSpec:
		case PaletteBorderStyle.ButtonBreadCrumb:
		case PaletteBorderStyle.ButtonCalendarDay:
		case PaletteBorderStyle.ButtonNavigatorStack:
		case PaletteBorderStyle.ButtonNavigatorOverflow:
		case PaletteBorderStyle.ButtonInputControl:
		case PaletteBorderStyle.ButtonListItem:
		case PaletteBorderStyle.ButtonForm:
		case PaletteBorderStyle.ButtonFormClose:
		case PaletteBorderStyle.ButtonCommand:
			if ((uint)(state - 1) <= 1u || state == PaletteState.NormalDefaultOverride)
			{
				return InheritBool.False;
			}
			return InheritBool.True;
		case PaletteBorderStyle.ContextMenuItemImage:
		case PaletteBorderStyle.ContextMenuItemHighlight:
			if (state == PaletteState.Normal || state == PaletteState.NormalDefaultOverride)
			{
				return InheritBool.False;
			}
			return InheritBool.True;
		case PaletteBorderStyle.TabLowProfile:
			if (state == PaletteState.CheckedNormal || state == PaletteState.CheckedTracking || state == PaletteState.CheckedPressed)
			{
				return InheritBool.True;
			}
			return InheritBool.False;
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override PaletteDrawBorders GetBorderDrawBorders(PaletteBorderStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteDrawBorders.Inherit;
		}
		switch (style)
		{
		case PaletteBorderStyle.ButtonStandalone:
		case PaletteBorderStyle.ButtonAlternate:
		case PaletteBorderStyle.ButtonLowProfile:
		case PaletteBorderStyle.ButtonButtonSpec:
		case PaletteBorderStyle.ButtonBreadCrumb:
		case PaletteBorderStyle.ButtonCalendarDay:
		case PaletteBorderStyle.ButtonCluster:
		case PaletteBorderStyle.ButtonGallery:
		case PaletteBorderStyle.ButtonListItem:
		case PaletteBorderStyle.ButtonForm:
		case PaletteBorderStyle.ButtonFormClose:
		case PaletteBorderStyle.ButtonCommand:
		case PaletteBorderStyle.ButtonCustom1:
		case PaletteBorderStyle.ButtonCustom2:
		case PaletteBorderStyle.ButtonCustom3:
		case PaletteBorderStyle.ControlClient:
		case PaletteBorderStyle.ControlAlternate:
		case PaletteBorderStyle.ControlGroupBox:
		case PaletteBorderStyle.ControlToolTip:
		case PaletteBorderStyle.ControlRibbon:
		case PaletteBorderStyle.ControlRibbonAppMenu:
		case PaletteBorderStyle.ControlCustom1:
		case PaletteBorderStyle.ContextMenuOuter:
		case PaletteBorderStyle.ContextMenuItemImage:
		case PaletteBorderStyle.ContextMenuItemHighlight:
		case PaletteBorderStyle.InputControlStandalone:
		case PaletteBorderStyle.InputControlRibbon:
		case PaletteBorderStyle.InputControlCustom1:
		case PaletteBorderStyle.GridHeaderColumnList:
		case PaletteBorderStyle.GridHeaderRowList:
		case PaletteBorderStyle.GridDataCellList:
		case PaletteBorderStyle.GridHeaderColumnSheet:
		case PaletteBorderStyle.GridHeaderRowSheet:
		case PaletteBorderStyle.GridDataCellSheet:
		case PaletteBorderStyle.GridHeaderColumnCustom1:
		case PaletteBorderStyle.GridHeaderRowCustom1:
		case PaletteBorderStyle.GridDataCellCustom1:
		case PaletteBorderStyle.HeaderPrimary:
		case PaletteBorderStyle.HeaderSecondary:
		case PaletteBorderStyle.HeaderDockInactive:
		case PaletteBorderStyle.HeaderDockActive:
		case PaletteBorderStyle.HeaderForm:
		case PaletteBorderStyle.HeaderCalendar:
		case PaletteBorderStyle.HeaderCustom1:
		case PaletteBorderStyle.HeaderCustom2:
		case PaletteBorderStyle.SeparatorLowProfile:
		case PaletteBorderStyle.SeparatorHighProfile:
		case PaletteBorderStyle.SeparatorHighInternalProfile:
		case PaletteBorderStyle.SeparatorCustom1:
		case PaletteBorderStyle.TabHighProfile:
		case PaletteBorderStyle.TabStandardProfile:
		case PaletteBorderStyle.TabLowProfile:
		case PaletteBorderStyle.TabOneNote:
		case PaletteBorderStyle.TabDock:
		case PaletteBorderStyle.TabDockAutoHidden:
		case PaletteBorderStyle.TabCustom1:
		case PaletteBorderStyle.TabCustom2:
		case PaletteBorderStyle.TabCustom3:
		case PaletteBorderStyle.FormMain:
		case PaletteBorderStyle.FormCustom1:
			return PaletteDrawBorders.All;
		case PaletteBorderStyle.ContextMenuHeading:
			return PaletteDrawBorders.Bottom;
		case PaletteBorderStyle.ContextMenuSeparator:
		case PaletteBorderStyle.ContextMenuItemSplit:
			return PaletteDrawBorders.Top;
		case PaletteBorderStyle.ContextMenuItemImageColumn:
			return PaletteDrawBorders.Right;
		case PaletteBorderStyle.ButtonNavigatorStack:
		case PaletteBorderStyle.ButtonNavigatorOverflow:
		case PaletteBorderStyle.ButtonNavigatorMini:
		case PaletteBorderStyle.ButtonInputControl:
		case PaletteBorderStyle.ContextMenuInner:
			return PaletteDrawBorders.None;
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override PaletteGraphicsHint GetBorderGraphicsHint(PaletteBorderStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteGraphicsHint.Inherit;
		}
		switch (style)
		{
		case PaletteBorderStyle.ButtonStandalone:
		case PaletteBorderStyle.ButtonAlternate:
		case PaletteBorderStyle.ButtonLowProfile:
		case PaletteBorderStyle.ButtonButtonSpec:
		case PaletteBorderStyle.ButtonBreadCrumb:
		case PaletteBorderStyle.ButtonCalendarDay:
		case PaletteBorderStyle.ButtonCluster:
		case PaletteBorderStyle.ButtonGallery:
		case PaletteBorderStyle.ButtonNavigatorStack:
		case PaletteBorderStyle.ButtonNavigatorOverflow:
		case PaletteBorderStyle.ButtonNavigatorMini:
		case PaletteBorderStyle.ButtonInputControl:
		case PaletteBorderStyle.ButtonListItem:
		case PaletteBorderStyle.ButtonForm:
		case PaletteBorderStyle.ButtonFormClose:
		case PaletteBorderStyle.ButtonCommand:
		case PaletteBorderStyle.ButtonCustom1:
		case PaletteBorderStyle.ButtonCustom2:
		case PaletteBorderStyle.ButtonCustom3:
		case PaletteBorderStyle.ControlClient:
		case PaletteBorderStyle.ControlAlternate:
		case PaletteBorderStyle.ControlGroupBox:
		case PaletteBorderStyle.ControlToolTip:
		case PaletteBorderStyle.ControlRibbon:
		case PaletteBorderStyle.ControlRibbonAppMenu:
		case PaletteBorderStyle.ControlCustom1:
		case PaletteBorderStyle.ContextMenuInner:
		case PaletteBorderStyle.ContextMenuHeading:
		case PaletteBorderStyle.ContextMenuSeparator:
		case PaletteBorderStyle.ContextMenuItemImage:
		case PaletteBorderStyle.ContextMenuItemSplit:
		case PaletteBorderStyle.ContextMenuItemImageColumn:
		case PaletteBorderStyle.ContextMenuItemHighlight:
		case PaletteBorderStyle.InputControlStandalone:
		case PaletteBorderStyle.InputControlRibbon:
		case PaletteBorderStyle.InputControlCustom1:
		case PaletteBorderStyle.GridHeaderColumnList:
		case PaletteBorderStyle.GridHeaderRowList:
		case PaletteBorderStyle.GridDataCellList:
		case PaletteBorderStyle.GridHeaderColumnSheet:
		case PaletteBorderStyle.GridHeaderRowSheet:
		case PaletteBorderStyle.GridDataCellSheet:
		case PaletteBorderStyle.GridHeaderColumnCustom1:
		case PaletteBorderStyle.GridHeaderRowCustom1:
		case PaletteBorderStyle.GridDataCellCustom1:
		case PaletteBorderStyle.HeaderPrimary:
		case PaletteBorderStyle.HeaderSecondary:
		case PaletteBorderStyle.HeaderDockInactive:
		case PaletteBorderStyle.HeaderDockActive:
		case PaletteBorderStyle.HeaderForm:
		case PaletteBorderStyle.HeaderCalendar:
		case PaletteBorderStyle.HeaderCustom1:
		case PaletteBorderStyle.HeaderCustom2:
		case PaletteBorderStyle.SeparatorLowProfile:
		case PaletteBorderStyle.SeparatorHighProfile:
		case PaletteBorderStyle.SeparatorHighInternalProfile:
		case PaletteBorderStyle.SeparatorCustom1:
		case PaletteBorderStyle.TabHighProfile:
		case PaletteBorderStyle.TabStandardProfile:
		case PaletteBorderStyle.TabLowProfile:
		case PaletteBorderStyle.TabOneNote:
		case PaletteBorderStyle.TabDock:
		case PaletteBorderStyle.TabDockAutoHidden:
		case PaletteBorderStyle.TabCustom1:
		case PaletteBorderStyle.TabCustom2:
		case PaletteBorderStyle.TabCustom3:
		case PaletteBorderStyle.FormMain:
		case PaletteBorderStyle.FormCustom1:
			return PaletteGraphicsHint.AntiAlias;
		case PaletteBorderStyle.ContextMenuOuter:
			return PaletteGraphicsHint.None;
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override Color GetBorderColor1(PaletteBorderStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			if (state == PaletteState.TodayOverride && style == PaletteBorderStyle.ButtonCalendarDay)
			{
				if (state == PaletteState.Disabled)
				{
					return _disabledBorder;
				}
				return _sparkleColors[2];
			}
			return Color.Empty;
		}
		switch (style)
		{
		case PaletteBorderStyle.FormMain:
		case PaletteBorderStyle.FormCustom1:
			return _sparkleColors[4];
		case PaletteBorderStyle.ContextMenuOuter:
		case PaletteBorderStyle.HeaderForm:
			return _colorDark00;
		case PaletteBorderStyle.ButtonStandalone:
		case PaletteBorderStyle.ButtonAlternate:
		case PaletteBorderStyle.ButtonLowProfile:
		case PaletteBorderStyle.ButtonButtonSpec:
		case PaletteBorderStyle.ButtonBreadCrumb:
		case PaletteBorderStyle.ButtonCluster:
		case PaletteBorderStyle.ButtonNavigatorStack:
		case PaletteBorderStyle.ButtonNavigatorOverflow:
		case PaletteBorderStyle.ButtonNavigatorMini:
		case PaletteBorderStyle.ButtonInputControl:
		case PaletteBorderStyle.ButtonForm:
		case PaletteBorderStyle.ButtonFormClose:
		case PaletteBorderStyle.ButtonCustom1:
		case PaletteBorderStyle.ButtonCustom2:
		case PaletteBorderStyle.ButtonCustom3:
			return state switch
			{
				PaletteState.Disabled => _disabledBorder, 
				PaletteState.Normal => _colorDark00, 
				_ => _colorDark00, 
			};
		case PaletteBorderStyle.ButtonCalendarDay:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBack;
			case PaletteState.Normal:
				return _sparkleColors[5];
			case PaletteState.NormalDefaultOverride:
				return Color.Empty;
			case PaletteState.Tracking:
				return _sparkleColors[27];
			case PaletteState.Pressed:
			case PaletteState.CheckedNormal:
				return _sparkleColors[15];
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _sparkleColors[12];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBorderStyle.ButtonGallery:
			return _colorDark00;
		case PaletteBorderStyle.ButtonListItem:
		case PaletteBorderStyle.ButtonCommand:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBack;
			case PaletteState.Normal:
			case PaletteState.Tracking:
			case PaletteState.NormalDefaultOverride:
				return _colorWhite215;
			case PaletteState.Pressed:
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _sparkleColors[15];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBorderStyle.ContextMenuSeparator:
			return _colorWhite224;
		case PaletteBorderStyle.ContextMenuHeading:
		case PaletteBorderStyle.ContextMenuItemImageColumn:
			return _colorWhite255;
		case PaletteBorderStyle.ContextMenuItemHighlight:
			if (state == PaletteState.Disabled)
			{
				return _menuItemDisabledBorder;
			}
			return _sparkleColors[19];
		case PaletteBorderStyle.ContextMenuItemImage:
			if (state == PaletteState.Disabled)
			{
				return _menuItemDisabledImageBorder;
			}
			return _sparkleColors[21];
		case PaletteBorderStyle.InputControlStandalone:
		case PaletteBorderStyle.InputControlRibbon:
		case PaletteBorderStyle.InputControlCustom1:
			if (state == PaletteState.Disabled)
			{
				return _disabledBorder;
			}
			return _colorDark00;
		case PaletteBorderStyle.GridDataCellList:
		case PaletteBorderStyle.GridDataCellSheet:
		case PaletteBorderStyle.GridDataCellCustom1:
			if (state == PaletteState.Disabled)
			{
				return _disabledBorder;
			}
			return _sparkleColors[28];
		case PaletteBorderStyle.GridHeaderColumnList:
		case PaletteBorderStyle.GridHeaderRowList:
		case PaletteBorderStyle.GridHeaderColumnSheet:
		case PaletteBorderStyle.GridHeaderRowSheet:
		case PaletteBorderStyle.GridHeaderColumnCustom1:
		case PaletteBorderStyle.GridHeaderRowCustom1:
			if (state == PaletteState.Disabled)
			{
				return _disabledBorder;
			}
			return _gridHeaderBorder;
		case PaletteBorderStyle.ControlToolTip:
			if (state == PaletteState.Disabled)
			{
				return _disabledBorder;
			}
			return _colorDark00;
		case PaletteBorderStyle.ContextMenuInner:
			return _contextMenuInnerBack;
		case PaletteBorderStyle.HeaderCalendar:
			if (state == PaletteState.Disabled)
			{
				return _disabledBack;
			}
			return _sparkleColors[2];
		case PaletteBorderStyle.ControlClient:
		case PaletteBorderStyle.ControlAlternate:
		case PaletteBorderStyle.ControlGroupBox:
		case PaletteBorderStyle.ControlCustom1:
		case PaletteBorderStyle.HeaderPrimary:
		case PaletteBorderStyle.HeaderSecondary:
		case PaletteBorderStyle.HeaderDockInactive:
		case PaletteBorderStyle.HeaderDockActive:
		case PaletteBorderStyle.HeaderCustom1:
		case PaletteBorderStyle.HeaderCustom2:
		case PaletteBorderStyle.SeparatorLowProfile:
		case PaletteBorderStyle.SeparatorHighProfile:
		case PaletteBorderStyle.SeparatorHighInternalProfile:
		case PaletteBorderStyle.SeparatorCustom1:
			if (state == PaletteState.Disabled)
			{
				return _disabledBorder;
			}
			return _colorDark00;
		case PaletteBorderStyle.ContextMenuItemSplit:
			if (state == PaletteState.Disabled)
			{
				return _colorWhite220;
			}
			return _colorWhite167;
		case PaletteBorderStyle.TabHighProfile:
		case PaletteBorderStyle.TabStandardProfile:
		case PaletteBorderStyle.TabLowProfile:
		case PaletteBorderStyle.TabOneNote:
		case PaletteBorderStyle.TabDock:
		case PaletteBorderStyle.TabDockAutoHidden:
		case PaletteBorderStyle.TabCustom1:
		case PaletteBorderStyle.TabCustom2:
		case PaletteBorderStyle.TabCustom3:
			switch (state)
			{
			case PaletteState.Disabled:
				if (style == PaletteBorderStyle.TabLowProfile)
				{
					return Color.Empty;
				}
				return _disabledBorder;
			case PaletteState.Normal:
			case PaletteState.Tracking:
			case PaletteState.Pressed:
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _colorDark00;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBorderStyle.ControlRibbon:
			if (state == PaletteState.Disabled)
			{
				return _disabledBorder;
			}
			return _ribbonColors[85];
		case PaletteBorderStyle.ControlRibbonAppMenu:
			if (state == PaletteState.Disabled)
			{
				return _disabledBorder;
			}
			return _ribbonColors[192];
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override Color GetBorderColor2(PaletteBorderStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			if (state == PaletteState.TodayOverride && style == PaletteBorderStyle.ButtonCalendarDay)
			{
				if (state == PaletteState.Disabled)
				{
					return _disabledBorder;
				}
				return _sparkleColors[2];
			}
			return Color.Empty;
		}
		switch (style)
		{
		case PaletteBorderStyle.FormMain:
		case PaletteBorderStyle.FormCustom1:
			return _sparkleColors[4];
		case PaletteBorderStyle.ContextMenuOuter:
		case PaletteBorderStyle.HeaderForm:
			return _colorDark00;
		case PaletteBorderStyle.ButtonStandalone:
		case PaletteBorderStyle.ButtonAlternate:
		case PaletteBorderStyle.ButtonLowProfile:
		case PaletteBorderStyle.ButtonButtonSpec:
		case PaletteBorderStyle.ButtonBreadCrumb:
		case PaletteBorderStyle.ButtonCluster:
		case PaletteBorderStyle.ButtonGallery:
		case PaletteBorderStyle.ButtonNavigatorStack:
		case PaletteBorderStyle.ButtonNavigatorOverflow:
		case PaletteBorderStyle.ButtonNavigatorMini:
		case PaletteBorderStyle.ButtonInputControl:
		case PaletteBorderStyle.ButtonForm:
		case PaletteBorderStyle.ButtonFormClose:
		case PaletteBorderStyle.ButtonCustom1:
		case PaletteBorderStyle.ButtonCustom2:
		case PaletteBorderStyle.ButtonCustom3:
			return state switch
			{
				PaletteState.Disabled => _disabledBorder, 
				PaletteState.Normal => _colorDark00, 
				_ => _colorDark00, 
			};
		case PaletteBorderStyle.ButtonCalendarDay:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBack;
			case PaletteState.Normal:
				return _sparkleColors[5];
			case PaletteState.NormalDefaultOverride:
				return Color.Empty;
			case PaletteState.Tracking:
				return _sparkleColors[27];
			case PaletteState.Pressed:
			case PaletteState.CheckedNormal:
				return _sparkleColors[15];
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _sparkleColors[12];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBorderStyle.ButtonListItem:
		case PaletteBorderStyle.ButtonCommand:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBack;
			case PaletteState.Normal:
			case PaletteState.Tracking:
			case PaletteState.NormalDefaultOverride:
				return _colorWhite215;
			case PaletteState.Pressed:
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _sparkleColors[15];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBorderStyle.ContextMenuSeparator:
			return _colorWhite224;
		case PaletteBorderStyle.ContextMenuHeading:
		case PaletteBorderStyle.ContextMenuItemImageColumn:
			return _colorWhite255;
		case PaletteBorderStyle.ContextMenuItemHighlight:
			if (state == PaletteState.Disabled)
			{
				return _menuItemDisabledBorder;
			}
			return _sparkleColors[19];
		case PaletteBorderStyle.ContextMenuItemImage:
			if (state == PaletteState.Disabled)
			{
				return _menuItemDisabledImageBorder;
			}
			return _sparkleColors[21];
		case PaletteBorderStyle.InputControlStandalone:
		case PaletteBorderStyle.InputControlRibbon:
		case PaletteBorderStyle.InputControlCustom1:
			if (state == PaletteState.Disabled)
			{
				return _disabledBorder;
			}
			return _colorDark00;
		case PaletteBorderStyle.GridDataCellList:
		case PaletteBorderStyle.GridDataCellSheet:
		case PaletteBorderStyle.GridDataCellCustom1:
			if (state == PaletteState.Disabled)
			{
				return _disabledBorder;
			}
			return _sparkleColors[28];
		case PaletteBorderStyle.GridHeaderColumnList:
		case PaletteBorderStyle.GridHeaderRowList:
		case PaletteBorderStyle.GridHeaderColumnSheet:
		case PaletteBorderStyle.GridHeaderRowSheet:
		case PaletteBorderStyle.GridHeaderColumnCustom1:
		case PaletteBorderStyle.GridHeaderRowCustom1:
			if (state == PaletteState.Disabled)
			{
				return _disabledBorder;
			}
			return _gridHeaderBorder;
		case PaletteBorderStyle.ContextMenuInner:
			return _contextMenuInnerBack;
		case PaletteBorderStyle.ControlToolTip:
			if (state == PaletteState.Disabled)
			{
				return _disabledBorder;
			}
			return _colorDark00;
		case PaletteBorderStyle.ControlClient:
		case PaletteBorderStyle.ControlAlternate:
		case PaletteBorderStyle.ControlGroupBox:
		case PaletteBorderStyle.ControlCustom1:
		case PaletteBorderStyle.HeaderPrimary:
		case PaletteBorderStyle.HeaderSecondary:
		case PaletteBorderStyle.HeaderDockInactive:
		case PaletteBorderStyle.HeaderDockActive:
		case PaletteBorderStyle.HeaderCustom1:
		case PaletteBorderStyle.HeaderCustom2:
		case PaletteBorderStyle.SeparatorLowProfile:
		case PaletteBorderStyle.SeparatorHighProfile:
		case PaletteBorderStyle.SeparatorHighInternalProfile:
		case PaletteBorderStyle.SeparatorCustom1:
			if (state == PaletteState.Disabled)
			{
				return _disabledBorder;
			}
			return _colorDark00;
		case PaletteBorderStyle.HeaderCalendar:
			if (state == PaletteState.Disabled)
			{
				return _disabledBack;
			}
			return _sparkleColors[2];
		case PaletteBorderStyle.ContextMenuItemSplit:
			if (state == PaletteState.Disabled)
			{
				return _colorWhite220;
			}
			return _colorWhite167;
		case PaletteBorderStyle.TabHighProfile:
		case PaletteBorderStyle.TabStandardProfile:
		case PaletteBorderStyle.TabLowProfile:
		case PaletteBorderStyle.TabOneNote:
		case PaletteBorderStyle.TabDock:
		case PaletteBorderStyle.TabDockAutoHidden:
		case PaletteBorderStyle.TabCustom1:
		case PaletteBorderStyle.TabCustom2:
		case PaletteBorderStyle.TabCustom3:
			switch (state)
			{
			case PaletteState.Disabled:
				if (style == PaletteBorderStyle.TabLowProfile)
				{
					return Color.Empty;
				}
				return _disabledBorder;
			case PaletteState.Normal:
			case PaletteState.Tracking:
			case PaletteState.Pressed:
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _colorDark00;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBorderStyle.ControlRibbon:
			if (state == PaletteState.Disabled)
			{
				return _disabledBorder;
			}
			return _ribbonColors[85];
		case PaletteBorderStyle.ControlRibbonAppMenu:
			if (state == PaletteState.Disabled)
			{
				return _disabledBorder;
			}
			return _ribbonColors[192];
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override PaletteColorStyle GetBorderColorStyle(PaletteBorderStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideStateExclude(state, PaletteState.NormalDefaultOverride))
		{
			return PaletteColorStyle.Inherit;
		}
		switch (style)
		{
		case PaletteBorderStyle.HeaderPrimary:
		case PaletteBorderStyle.HeaderSecondary:
		case PaletteBorderStyle.HeaderDockInactive:
		case PaletteBorderStyle.HeaderDockActive:
		case PaletteBorderStyle.HeaderCustom1:
		case PaletteBorderStyle.HeaderCustom2:
		case PaletteBorderStyle.SeparatorLowProfile:
		case PaletteBorderStyle.SeparatorHighProfile:
		case PaletteBorderStyle.SeparatorHighInternalProfile:
		case PaletteBorderStyle.SeparatorCustom1:
		case PaletteBorderStyle.TabHighProfile:
		case PaletteBorderStyle.TabStandardProfile:
		case PaletteBorderStyle.TabLowProfile:
		case PaletteBorderStyle.TabOneNote:
		case PaletteBorderStyle.TabDock:
		case PaletteBorderStyle.TabDockAutoHidden:
		case PaletteBorderStyle.TabCustom1:
		case PaletteBorderStyle.TabCustom2:
		case PaletteBorderStyle.TabCustom3:
			return PaletteColorStyle.Sigma;
		case PaletteBorderStyle.ButtonStandalone:
		case PaletteBorderStyle.ButtonAlternate:
		case PaletteBorderStyle.ButtonLowProfile:
		case PaletteBorderStyle.ButtonButtonSpec:
		case PaletteBorderStyle.ButtonBreadCrumb:
		case PaletteBorderStyle.ButtonCalendarDay:
		case PaletteBorderStyle.ButtonCluster:
		case PaletteBorderStyle.ButtonGallery:
		case PaletteBorderStyle.ButtonNavigatorStack:
		case PaletteBorderStyle.ButtonNavigatorOverflow:
		case PaletteBorderStyle.ButtonNavigatorMini:
		case PaletteBorderStyle.ButtonInputControl:
		case PaletteBorderStyle.ButtonListItem:
		case PaletteBorderStyle.ButtonForm:
		case PaletteBorderStyle.ButtonFormClose:
		case PaletteBorderStyle.ButtonCommand:
		case PaletteBorderStyle.ButtonCustom1:
		case PaletteBorderStyle.ButtonCustom2:
		case PaletteBorderStyle.ButtonCustom3:
		case PaletteBorderStyle.ControlClient:
		case PaletteBorderStyle.ControlAlternate:
		case PaletteBorderStyle.ControlGroupBox:
		case PaletteBorderStyle.ControlToolTip:
		case PaletteBorderStyle.ControlRibbon:
		case PaletteBorderStyle.ControlRibbonAppMenu:
		case PaletteBorderStyle.ControlCustom1:
		case PaletteBorderStyle.ContextMenuOuter:
		case PaletteBorderStyle.ContextMenuInner:
		case PaletteBorderStyle.ContextMenuHeading:
		case PaletteBorderStyle.ContextMenuItemImage:
		case PaletteBorderStyle.ContextMenuItemImageColumn:
		case PaletteBorderStyle.InputControlStandalone:
		case PaletteBorderStyle.InputControlRibbon:
		case PaletteBorderStyle.InputControlCustom1:
		case PaletteBorderStyle.GridHeaderColumnList:
		case PaletteBorderStyle.GridHeaderRowList:
		case PaletteBorderStyle.GridDataCellList:
		case PaletteBorderStyle.GridHeaderColumnSheet:
		case PaletteBorderStyle.GridHeaderRowSheet:
		case PaletteBorderStyle.GridDataCellSheet:
		case PaletteBorderStyle.GridHeaderColumnCustom1:
		case PaletteBorderStyle.GridHeaderRowCustom1:
		case PaletteBorderStyle.GridDataCellCustom1:
		case PaletteBorderStyle.HeaderForm:
		case PaletteBorderStyle.HeaderCalendar:
		case PaletteBorderStyle.FormMain:
		case PaletteBorderStyle.FormCustom1:
			return PaletteColorStyle.Solid;
		case PaletteBorderStyle.ContextMenuSeparator:
		case PaletteBorderStyle.ContextMenuItemSplit:
			if (state == PaletteState.Tracking)
			{
				return PaletteColorStyle.Sigma;
			}
			return PaletteColorStyle.Solid;
		case PaletteBorderStyle.ContextMenuItemHighlight:
			switch (state)
			{
			case PaletteState.Normal:
				if (style == PaletteBorderStyle.ButtonCluster)
				{
					return PaletteColorStyle.Sigma;
				}
				return PaletteColorStyle.Solid;
			case PaletteState.Disabled:
			case PaletteState.NormalDefaultOverride:
				return PaletteColorStyle.Solid;
			case PaletteState.Pressed:
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return PaletteColorStyle.Linear;
			default:
				return PaletteColorStyle.Sigma;
			}
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override PaletteRectangleAlign GetBorderColorAlign(PaletteBorderStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteRectangleAlign.Inherit;
		}
		switch (style)
		{
		case PaletteBorderStyle.ControlClient:
		case PaletteBorderStyle.ControlAlternate:
		case PaletteBorderStyle.ControlGroupBox:
		case PaletteBorderStyle.ControlToolTip:
		case PaletteBorderStyle.ControlRibbon:
		case PaletteBorderStyle.ControlRibbonAppMenu:
		case PaletteBorderStyle.ControlCustom1:
		case PaletteBorderStyle.InputControlStandalone:
		case PaletteBorderStyle.InputControlRibbon:
		case PaletteBorderStyle.InputControlCustom1:
		case PaletteBorderStyle.FormMain:
		case PaletteBorderStyle.FormCustom1:
			return PaletteRectangleAlign.Control;
		case PaletteBorderStyle.ButtonStandalone:
		case PaletteBorderStyle.ButtonAlternate:
		case PaletteBorderStyle.ButtonLowProfile:
		case PaletteBorderStyle.ButtonButtonSpec:
		case PaletteBorderStyle.ButtonBreadCrumb:
		case PaletteBorderStyle.ButtonCalendarDay:
		case PaletteBorderStyle.ButtonCluster:
		case PaletteBorderStyle.ButtonGallery:
		case PaletteBorderStyle.ButtonNavigatorStack:
		case PaletteBorderStyle.ButtonNavigatorOverflow:
		case PaletteBorderStyle.ButtonNavigatorMini:
		case PaletteBorderStyle.ButtonInputControl:
		case PaletteBorderStyle.ButtonListItem:
		case PaletteBorderStyle.ButtonForm:
		case PaletteBorderStyle.ButtonFormClose:
		case PaletteBorderStyle.ButtonCommand:
		case PaletteBorderStyle.ButtonCustom1:
		case PaletteBorderStyle.ButtonCustom2:
		case PaletteBorderStyle.ButtonCustom3:
		case PaletteBorderStyle.ContextMenuOuter:
		case PaletteBorderStyle.ContextMenuInner:
		case PaletteBorderStyle.ContextMenuHeading:
		case PaletteBorderStyle.ContextMenuSeparator:
		case PaletteBorderStyle.ContextMenuItemImage:
		case PaletteBorderStyle.ContextMenuItemSplit:
		case PaletteBorderStyle.ContextMenuItemImageColumn:
		case PaletteBorderStyle.ContextMenuItemHighlight:
		case PaletteBorderStyle.GridHeaderColumnList:
		case PaletteBorderStyle.GridHeaderRowList:
		case PaletteBorderStyle.GridDataCellList:
		case PaletteBorderStyle.GridHeaderColumnSheet:
		case PaletteBorderStyle.GridHeaderRowSheet:
		case PaletteBorderStyle.GridDataCellSheet:
		case PaletteBorderStyle.GridHeaderColumnCustom1:
		case PaletteBorderStyle.GridHeaderRowCustom1:
		case PaletteBorderStyle.GridDataCellCustom1:
		case PaletteBorderStyle.HeaderPrimary:
		case PaletteBorderStyle.HeaderSecondary:
		case PaletteBorderStyle.HeaderDockInactive:
		case PaletteBorderStyle.HeaderDockActive:
		case PaletteBorderStyle.HeaderForm:
		case PaletteBorderStyle.HeaderCalendar:
		case PaletteBorderStyle.HeaderCustom1:
		case PaletteBorderStyle.HeaderCustom2:
		case PaletteBorderStyle.SeparatorLowProfile:
		case PaletteBorderStyle.SeparatorHighProfile:
		case PaletteBorderStyle.SeparatorHighInternalProfile:
		case PaletteBorderStyle.SeparatorCustom1:
		case PaletteBorderStyle.TabHighProfile:
		case PaletteBorderStyle.TabStandardProfile:
		case PaletteBorderStyle.TabLowProfile:
		case PaletteBorderStyle.TabOneNote:
		case PaletteBorderStyle.TabDock:
		case PaletteBorderStyle.TabDockAutoHidden:
		case PaletteBorderStyle.TabCustom1:
		case PaletteBorderStyle.TabCustom2:
		case PaletteBorderStyle.TabCustom3:
			return PaletteRectangleAlign.Local;
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override float GetBorderColorAngle(PaletteBorderStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return -1f;
		}
		if ((uint)style <= 68u)
		{
			return 90f;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override int GetBorderWidth(PaletteBorderStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return -1;
		}
		switch (style)
		{
		case PaletteBorderStyle.HeaderForm:
			return 4;
		case PaletteBorderStyle.ButtonInputControl:
		case PaletteBorderStyle.ContextMenuInner:
		case PaletteBorderStyle.SeparatorLowProfile:
		case PaletteBorderStyle.SeparatorHighProfile:
		case PaletteBorderStyle.SeparatorHighInternalProfile:
		case PaletteBorderStyle.SeparatorCustom1:
			return 0;
		case PaletteBorderStyle.ButtonStandalone:
		case PaletteBorderStyle.ButtonAlternate:
		case PaletteBorderStyle.ButtonLowProfile:
		case PaletteBorderStyle.ButtonButtonSpec:
		case PaletteBorderStyle.ButtonBreadCrumb:
		case PaletteBorderStyle.ButtonCalendarDay:
		case PaletteBorderStyle.ButtonCluster:
		case PaletteBorderStyle.ButtonGallery:
		case PaletteBorderStyle.ButtonNavigatorStack:
		case PaletteBorderStyle.ButtonNavigatorOverflow:
		case PaletteBorderStyle.ButtonNavigatorMini:
		case PaletteBorderStyle.ButtonListItem:
		case PaletteBorderStyle.ButtonForm:
		case PaletteBorderStyle.ButtonFormClose:
		case PaletteBorderStyle.ButtonCommand:
		case PaletteBorderStyle.ButtonCustom1:
		case PaletteBorderStyle.ButtonCustom2:
		case PaletteBorderStyle.ButtonCustom3:
		case PaletteBorderStyle.ControlClient:
		case PaletteBorderStyle.ControlAlternate:
		case PaletteBorderStyle.ControlGroupBox:
		case PaletteBorderStyle.ControlToolTip:
		case PaletteBorderStyle.ControlRibbon:
		case PaletteBorderStyle.ControlRibbonAppMenu:
		case PaletteBorderStyle.ControlCustom1:
		case PaletteBorderStyle.ContextMenuOuter:
		case PaletteBorderStyle.ContextMenuHeading:
		case PaletteBorderStyle.ContextMenuSeparator:
		case PaletteBorderStyle.ContextMenuItemImage:
		case PaletteBorderStyle.ContextMenuItemSplit:
		case PaletteBorderStyle.ContextMenuItemImageColumn:
		case PaletteBorderStyle.ContextMenuItemHighlight:
		case PaletteBorderStyle.InputControlStandalone:
		case PaletteBorderStyle.InputControlRibbon:
		case PaletteBorderStyle.InputControlCustom1:
		case PaletteBorderStyle.GridHeaderColumnList:
		case PaletteBorderStyle.GridHeaderRowList:
		case PaletteBorderStyle.GridDataCellList:
		case PaletteBorderStyle.GridHeaderColumnSheet:
		case PaletteBorderStyle.GridHeaderRowSheet:
		case PaletteBorderStyle.GridDataCellSheet:
		case PaletteBorderStyle.GridHeaderColumnCustom1:
		case PaletteBorderStyle.GridHeaderRowCustom1:
		case PaletteBorderStyle.GridDataCellCustom1:
		case PaletteBorderStyle.HeaderPrimary:
		case PaletteBorderStyle.HeaderSecondary:
		case PaletteBorderStyle.HeaderDockInactive:
		case PaletteBorderStyle.HeaderDockActive:
		case PaletteBorderStyle.HeaderCalendar:
		case PaletteBorderStyle.HeaderCustom1:
		case PaletteBorderStyle.HeaderCustom2:
		case PaletteBorderStyle.TabHighProfile:
		case PaletteBorderStyle.TabStandardProfile:
		case PaletteBorderStyle.TabLowProfile:
		case PaletteBorderStyle.TabOneNote:
		case PaletteBorderStyle.TabDock:
		case PaletteBorderStyle.TabDockAutoHidden:
		case PaletteBorderStyle.TabCustom1:
		case PaletteBorderStyle.TabCustom2:
		case PaletteBorderStyle.TabCustom3:
		case PaletteBorderStyle.FormMain:
		case PaletteBorderStyle.FormCustom1:
			return 1;
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override int GetBorderRounding(PaletteBorderStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return -1;
		}
		switch (style)
		{
		case PaletteBorderStyle.ButtonCalendarDay:
		case PaletteBorderStyle.ButtonInputControl:
		case PaletteBorderStyle.ButtonListItem:
		case PaletteBorderStyle.ButtonCommand:
		case PaletteBorderStyle.ControlClient:
		case PaletteBorderStyle.ControlAlternate:
		case PaletteBorderStyle.ControlToolTip:
		case PaletteBorderStyle.ControlCustom1:
		case PaletteBorderStyle.ContextMenuOuter:
		case PaletteBorderStyle.ContextMenuInner:
		case PaletteBorderStyle.ContextMenuHeading:
		case PaletteBorderStyle.ContextMenuSeparator:
		case PaletteBorderStyle.ContextMenuItemSplit:
		case PaletteBorderStyle.ContextMenuItemImageColumn:
		case PaletteBorderStyle.InputControlStandalone:
		case PaletteBorderStyle.InputControlRibbon:
		case PaletteBorderStyle.InputControlCustom1:
		case PaletteBorderStyle.GridHeaderColumnList:
		case PaletteBorderStyle.GridHeaderRowList:
		case PaletteBorderStyle.GridDataCellList:
		case PaletteBorderStyle.GridHeaderColumnSheet:
		case PaletteBorderStyle.GridHeaderRowSheet:
		case PaletteBorderStyle.GridDataCellSheet:
		case PaletteBorderStyle.GridHeaderColumnCustom1:
		case PaletteBorderStyle.GridHeaderRowCustom1:
		case PaletteBorderStyle.GridDataCellCustom1:
		case PaletteBorderStyle.HeaderPrimary:
		case PaletteBorderStyle.HeaderSecondary:
		case PaletteBorderStyle.HeaderDockInactive:
		case PaletteBorderStyle.HeaderDockActive:
		case PaletteBorderStyle.HeaderCalendar:
		case PaletteBorderStyle.HeaderCustom1:
		case PaletteBorderStyle.HeaderCustom2:
		case PaletteBorderStyle.SeparatorLowProfile:
		case PaletteBorderStyle.SeparatorHighProfile:
		case PaletteBorderStyle.SeparatorHighInternalProfile:
		case PaletteBorderStyle.SeparatorCustom1:
		case PaletteBorderStyle.TabHighProfile:
		case PaletteBorderStyle.TabStandardProfile:
		case PaletteBorderStyle.TabLowProfile:
		case PaletteBorderStyle.TabOneNote:
		case PaletteBorderStyle.TabDock:
		case PaletteBorderStyle.TabDockAutoHidden:
		case PaletteBorderStyle.TabCustom1:
		case PaletteBorderStyle.TabCustom2:
		case PaletteBorderStyle.TabCustom3:
			return 0;
		case PaletteBorderStyle.ButtonStandalone:
		case PaletteBorderStyle.ButtonAlternate:
		case PaletteBorderStyle.ButtonLowProfile:
		case PaletteBorderStyle.ButtonButtonSpec:
		case PaletteBorderStyle.ButtonBreadCrumb:
		case PaletteBorderStyle.ButtonCluster:
		case PaletteBorderStyle.ButtonGallery:
		case PaletteBorderStyle.ButtonNavigatorStack:
		case PaletteBorderStyle.ButtonNavigatorOverflow:
		case PaletteBorderStyle.ButtonNavigatorMini:
		case PaletteBorderStyle.ButtonForm:
		case PaletteBorderStyle.ButtonFormClose:
		case PaletteBorderStyle.ButtonCustom1:
		case PaletteBorderStyle.ButtonCustom2:
		case PaletteBorderStyle.ButtonCustom3:
		case PaletteBorderStyle.ContextMenuItemImage:
		case PaletteBorderStyle.ContextMenuItemHighlight:
			return 2;
		case PaletteBorderStyle.ControlGroupBox:
		case PaletteBorderStyle.ControlRibbon:
		case PaletteBorderStyle.ControlRibbonAppMenu:
		case PaletteBorderStyle.HeaderForm:
			return 3;
		case PaletteBorderStyle.FormMain:
		case PaletteBorderStyle.FormCustom1:
			return 5;
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override Image GetBorderImage(PaletteBorderStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return null;
		}
		if ((uint)style <= 68u)
		{
			return null;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override PaletteImageStyle GetBorderImageStyle(PaletteBorderStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteImageStyle.Inherit;
		}
		if ((uint)style <= 68u)
		{
			return PaletteImageStyle.Tile;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override PaletteRectangleAlign GetBorderImageAlign(PaletteBorderStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteRectangleAlign.Inherit;
		}
		if ((uint)style <= 68u)
		{
			return PaletteRectangleAlign.Local;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override InheritBool GetContentDraw(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return InheritBool.Inherit;
		}
		return InheritBool.True;
	}

	public override InheritBool GetContentDrawFocus(PaletteContentStyle style, PaletteState state)
	{
		if (state == PaletteState.FocusOverride)
		{
			return InheritBool.True;
		}
		if (CommonHelper.IsOverrideState(state))
		{
			return InheritBool.Inherit;
		}
		return InheritBool.False;
	}

	public override PaletteRelativeAlign GetContentImageH(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteRelativeAlign.Inherit;
		}
		switch (style)
		{
		case PaletteContentStyle.ButtonNavigatorStack:
		case PaletteContentStyle.ButtonNavigatorOverflow:
		case PaletteContentStyle.ButtonListItem:
		case PaletteContentStyle.ButtonCommand:
		case PaletteContentStyle.ContextMenuHeading:
		case PaletteContentStyle.GridHeaderColumnList:
		case PaletteContentStyle.GridHeaderRowList:
		case PaletteContentStyle.GridDataCellList:
		case PaletteContentStyle.GridHeaderColumnSheet:
		case PaletteContentStyle.GridHeaderRowSheet:
		case PaletteContentStyle.GridDataCellSheet:
		case PaletteContentStyle.GridHeaderColumnCustom1:
		case PaletteContentStyle.GridHeaderRowCustom1:
		case PaletteContentStyle.GridDataCellCustom1:
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderSecondary:
		case PaletteContentStyle.HeaderDockInactive:
		case PaletteContentStyle.HeaderDockActive:
		case PaletteContentStyle.HeaderForm:
		case PaletteContentStyle.HeaderCalendar:
		case PaletteContentStyle.HeaderCustom1:
		case PaletteContentStyle.HeaderCustom2:
		case PaletteContentStyle.LabelNormalControl:
		case PaletteContentStyle.LabelBoldControl:
		case PaletteContentStyle.LabelItalicControl:
		case PaletteContentStyle.LabelTitleControl:
		case PaletteContentStyle.LabelNormalPanel:
		case PaletteContentStyle.LabelBoldPanel:
		case PaletteContentStyle.LabelItalicPanel:
		case PaletteContentStyle.LabelTitlePanel:
		case PaletteContentStyle.LabelGroupBoxCaption:
		case PaletteContentStyle.LabelToolTip:
		case PaletteContentStyle.LabelSuperTip:
		case PaletteContentStyle.LabelKeyTip:
		case PaletteContentStyle.LabelCustom1:
		case PaletteContentStyle.LabelCustom2:
		case PaletteContentStyle.LabelCustom3:
			return PaletteRelativeAlign.Near;
		case PaletteContentStyle.ButtonNavigatorMini:
		case PaletteContentStyle.ContextMenuItemImage:
		case PaletteContentStyle.ContextMenuItemTextStandard:
		case PaletteContentStyle.ContextMenuItemTextAlternate:
		case PaletteContentStyle.ContextMenuItemShortcutText:
			return PaletteRelativeAlign.Center;
		case PaletteContentStyle.ButtonStandalone:
		case PaletteContentStyle.ButtonAlternate:
		case PaletteContentStyle.ButtonLowProfile:
		case PaletteContentStyle.ButtonButtonSpec:
		case PaletteContentStyle.ButtonBreadCrumb:
		case PaletteContentStyle.ButtonCalendarDay:
		case PaletteContentStyle.ButtonCluster:
		case PaletteContentStyle.ButtonGallery:
		case PaletteContentStyle.ButtonInputControl:
		case PaletteContentStyle.ButtonForm:
		case PaletteContentStyle.ButtonFormClose:
		case PaletteContentStyle.ButtonCustom1:
		case PaletteContentStyle.ButtonCustom2:
		case PaletteContentStyle.ButtonCustom3:
		case PaletteContentStyle.TabHighProfile:
		case PaletteContentStyle.TabStandardProfile:
		case PaletteContentStyle.TabLowProfile:
		case PaletteContentStyle.TabOneNote:
		case PaletteContentStyle.TabDock:
		case PaletteContentStyle.TabDockAutoHidden:
		case PaletteContentStyle.TabCustom1:
		case PaletteContentStyle.TabCustom2:
		case PaletteContentStyle.TabCustom3:
		case PaletteContentStyle.InputControlStandalone:
		case PaletteContentStyle.InputControlRibbon:
		case PaletteContentStyle.InputControlCustom1:
			return PaletteRelativeAlign.Center;
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override PaletteRelativeAlign GetContentImageV(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteRelativeAlign.Inherit;
		}
		if ((uint)style <= 67u)
		{
			return PaletteRelativeAlign.Center;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override PaletteImageEffect GetContentImageEffect(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteImageEffect.Inherit;
		}
		switch (style)
		{
		case PaletteContentStyle.HeaderForm:
			return PaletteImageEffect.Normal;
		case PaletteContentStyle.ButtonStandalone:
		case PaletteContentStyle.ButtonAlternate:
		case PaletteContentStyle.ButtonLowProfile:
		case PaletteContentStyle.ButtonButtonSpec:
		case PaletteContentStyle.ButtonBreadCrumb:
		case PaletteContentStyle.ButtonCalendarDay:
		case PaletteContentStyle.ButtonCluster:
		case PaletteContentStyle.ButtonGallery:
		case PaletteContentStyle.ButtonNavigatorStack:
		case PaletteContentStyle.ButtonNavigatorOverflow:
		case PaletteContentStyle.ButtonNavigatorMini:
		case PaletteContentStyle.ButtonInputControl:
		case PaletteContentStyle.ButtonListItem:
		case PaletteContentStyle.ButtonForm:
		case PaletteContentStyle.ButtonFormClose:
		case PaletteContentStyle.ButtonCommand:
		case PaletteContentStyle.ButtonCustom1:
		case PaletteContentStyle.ButtonCustom2:
		case PaletteContentStyle.ButtonCustom3:
		case PaletteContentStyle.ContextMenuHeading:
		case PaletteContentStyle.ContextMenuItemImage:
		case PaletteContentStyle.ContextMenuItemTextStandard:
		case PaletteContentStyle.ContextMenuItemTextAlternate:
		case PaletteContentStyle.ContextMenuItemShortcutText:
		case PaletteContentStyle.GridHeaderColumnList:
		case PaletteContentStyle.GridHeaderRowList:
		case PaletteContentStyle.GridDataCellList:
		case PaletteContentStyle.GridHeaderColumnSheet:
		case PaletteContentStyle.GridHeaderRowSheet:
		case PaletteContentStyle.GridDataCellSheet:
		case PaletteContentStyle.GridHeaderColumnCustom1:
		case PaletteContentStyle.GridHeaderRowCustom1:
		case PaletteContentStyle.GridDataCellCustom1:
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderSecondary:
		case PaletteContentStyle.HeaderDockInactive:
		case PaletteContentStyle.HeaderDockActive:
		case PaletteContentStyle.HeaderCalendar:
		case PaletteContentStyle.HeaderCustom1:
		case PaletteContentStyle.HeaderCustom2:
		case PaletteContentStyle.LabelNormalControl:
		case PaletteContentStyle.LabelBoldControl:
		case PaletteContentStyle.LabelItalicControl:
		case PaletteContentStyle.LabelTitleControl:
		case PaletteContentStyle.LabelNormalPanel:
		case PaletteContentStyle.LabelBoldPanel:
		case PaletteContentStyle.LabelItalicPanel:
		case PaletteContentStyle.LabelTitlePanel:
		case PaletteContentStyle.LabelGroupBoxCaption:
		case PaletteContentStyle.LabelToolTip:
		case PaletteContentStyle.LabelSuperTip:
		case PaletteContentStyle.LabelKeyTip:
		case PaletteContentStyle.LabelCustom1:
		case PaletteContentStyle.LabelCustom2:
		case PaletteContentStyle.LabelCustom3:
		case PaletteContentStyle.TabHighProfile:
		case PaletteContentStyle.TabStandardProfile:
		case PaletteContentStyle.TabLowProfile:
		case PaletteContentStyle.TabOneNote:
		case PaletteContentStyle.TabDock:
		case PaletteContentStyle.TabDockAutoHidden:
		case PaletteContentStyle.TabCustom1:
		case PaletteContentStyle.TabCustom2:
		case PaletteContentStyle.TabCustom3:
		case PaletteContentStyle.InputControlStandalone:
		case PaletteContentStyle.InputControlRibbon:
		case PaletteContentStyle.InputControlCustom1:
			if (state == PaletteState.Disabled)
			{
				return PaletteImageEffect.Disabled;
			}
			return PaletteImageEffect.Normal;
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override Color GetContentImageColorMap(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return Color.Empty;
		}
		if ((uint)style <= 67u)
		{
			return Color.Empty;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override Color GetContentImageColorTo(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return Color.Empty;
		}
		if ((uint)style <= 67u)
		{
			return Color.Empty;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override Color GetContentImageColorTransparent(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return Color.Empty;
		}
		if ((uint)style <= 67u)
		{
			return Color.Empty;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override Font GetContentShortTextFont(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			if (state == PaletteState.BoldedOverride && style == PaletteContentStyle.ButtonCalendarDay)
			{
				return _calendarBoldFont;
			}
			return null;
		}
		switch (style)
		{
		case PaletteContentStyle.HeaderForm:
			return _headerFormFont;
		case PaletteContentStyle.ButtonCommand:
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderCustom1:
		case PaletteContentStyle.HeaderCustom2:
		case PaletteContentStyle.LabelTitleControl:
		case PaletteContentStyle.LabelTitlePanel:
			return _header1ShortFont;
		case PaletteContentStyle.ContextMenuHeading:
		case PaletteContentStyle.LabelSuperTip:
			return _superToolFont;
		case PaletteContentStyle.ContextMenuItemImage:
		case PaletteContentStyle.ContextMenuItemTextStandard:
		case PaletteContentStyle.ContextMenuItemShortcutText:
		case PaletteContentStyle.HeaderSecondary:
		case PaletteContentStyle.HeaderDockInactive:
		case PaletteContentStyle.HeaderDockActive:
		case PaletteContentStyle.LabelNormalControl:
		case PaletteContentStyle.LabelNormalPanel:
		case PaletteContentStyle.LabelGroupBoxCaption:
		case PaletteContentStyle.LabelToolTip:
		case PaletteContentStyle.LabelKeyTip:
		case PaletteContentStyle.LabelCustom1:
		case PaletteContentStyle.LabelCustom2:
		case PaletteContentStyle.LabelCustom3:
		case PaletteContentStyle.InputControlStandalone:
		case PaletteContentStyle.InputControlRibbon:
		case PaletteContentStyle.InputControlCustom1:
			return _header2ShortFont;
		case PaletteContentStyle.LabelBoldControl:
		case PaletteContentStyle.LabelBoldPanel:
			return _boldFont;
		case PaletteContentStyle.LabelItalicControl:
		case PaletteContentStyle.LabelItalicPanel:
			return _italicFont;
		case PaletteContentStyle.ContextMenuItemTextAlternate:
			return _superToolFont;
		case PaletteContentStyle.TabLowProfile:
		case PaletteContentStyle.TabDock:
		case PaletteContentStyle.TabDockAutoHidden:
			return _tabFontNormal;
		case PaletteContentStyle.TabHighProfile:
		case PaletteContentStyle.TabStandardProfile:
		case PaletteContentStyle.TabOneNote:
		case PaletteContentStyle.TabCustom1:
		case PaletteContentStyle.TabCustom2:
		case PaletteContentStyle.TabCustom3:
			if (state == PaletteState.CheckedNormal || state == PaletteState.CheckedTracking || state == PaletteState.CheckedPressed)
			{
				return _tabFontSelected;
			}
			return _tabFontNormal;
		case PaletteContentStyle.ButtonStandalone:
		case PaletteContentStyle.ButtonAlternate:
		case PaletteContentStyle.ButtonLowProfile:
		case PaletteContentStyle.ButtonButtonSpec:
		case PaletteContentStyle.ButtonBreadCrumb:
		case PaletteContentStyle.ButtonCluster:
		case PaletteContentStyle.ButtonGallery:
		case PaletteContentStyle.ButtonInputControl:
		case PaletteContentStyle.ButtonListItem:
		case PaletteContentStyle.ButtonForm:
		case PaletteContentStyle.ButtonFormClose:
		case PaletteContentStyle.ButtonCustom1:
		case PaletteContentStyle.ButtonCustom2:
		case PaletteContentStyle.ButtonCustom3:
			return _buttonFont;
		case PaletteContentStyle.ButtonNavigatorStack:
		case PaletteContentStyle.ButtonNavigatorOverflow:
			return _buttonFontNavigatorStack;
		case PaletteContentStyle.ButtonNavigatorMini:
			return _buttonFontNavigatorMini;
		case PaletteContentStyle.GridHeaderColumnList:
		case PaletteContentStyle.GridHeaderRowList:
		case PaletteContentStyle.GridDataCellList:
		case PaletteContentStyle.GridHeaderColumnSheet:
		case PaletteContentStyle.GridHeaderRowSheet:
		case PaletteContentStyle.GridDataCellSheet:
		case PaletteContentStyle.GridHeaderColumnCustom1:
		case PaletteContentStyle.GridHeaderRowCustom1:
		case PaletteContentStyle.GridDataCellCustom1:
		case PaletteContentStyle.HeaderCalendar:
			return _gridFont;
		case PaletteContentStyle.ButtonCalendarDay:
			return _calendarFont;
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override Font GetContentShortTextNewFont(PaletteContentStyle style, PaletteState state)
	{
		DefineFonts();
		return GetContentShortTextFont(style, state);
	}

	public override PaletteTextHint GetContentShortTextHint(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteTextHint.Inherit;
		}
		if ((uint)style <= 67u)
		{
			return PaletteTextHint.ClearTypeGridFit;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override PaletteTextHotkeyPrefix GetContentShortTextPrefix(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteTextHotkeyPrefix.Inherit;
		}
		switch (style)
		{
		case PaletteContentStyle.ButtonStandalone:
		case PaletteContentStyle.ButtonAlternate:
		case PaletteContentStyle.ButtonLowProfile:
		case PaletteContentStyle.ButtonButtonSpec:
		case PaletteContentStyle.ButtonBreadCrumb:
		case PaletteContentStyle.ButtonCalendarDay:
		case PaletteContentStyle.ButtonCluster:
		case PaletteContentStyle.ButtonGallery:
		case PaletteContentStyle.ButtonNavigatorStack:
		case PaletteContentStyle.ButtonNavigatorOverflow:
		case PaletteContentStyle.ButtonNavigatorMini:
		case PaletteContentStyle.ButtonInputControl:
		case PaletteContentStyle.ButtonForm:
		case PaletteContentStyle.ButtonFormClose:
		case PaletteContentStyle.ButtonCommand:
		case PaletteContentStyle.ButtonCustom1:
		case PaletteContentStyle.ButtonCustom2:
		case PaletteContentStyle.ButtonCustom3:
		case PaletteContentStyle.ContextMenuItemTextStandard:
		case PaletteContentStyle.ContextMenuItemTextAlternate:
		case PaletteContentStyle.HeaderForm:
		case PaletteContentStyle.LabelNormalControl:
		case PaletteContentStyle.LabelBoldControl:
		case PaletteContentStyle.LabelItalicControl:
		case PaletteContentStyle.LabelTitleControl:
		case PaletteContentStyle.LabelNormalPanel:
		case PaletteContentStyle.LabelBoldPanel:
		case PaletteContentStyle.LabelItalicPanel:
		case PaletteContentStyle.LabelTitlePanel:
		case PaletteContentStyle.LabelGroupBoxCaption:
		case PaletteContentStyle.LabelCustom1:
		case PaletteContentStyle.LabelCustom2:
		case PaletteContentStyle.LabelCustom3:
		case PaletteContentStyle.TabHighProfile:
		case PaletteContentStyle.TabStandardProfile:
		case PaletteContentStyle.TabLowProfile:
		case PaletteContentStyle.TabOneNote:
		case PaletteContentStyle.TabDock:
		case PaletteContentStyle.TabDockAutoHidden:
		case PaletteContentStyle.TabCustom1:
		case PaletteContentStyle.TabCustom2:
		case PaletteContentStyle.TabCustom3:
		case PaletteContentStyle.InputControlStandalone:
		case PaletteContentStyle.InputControlRibbon:
		case PaletteContentStyle.InputControlCustom1:
			return PaletteTextHotkeyPrefix.Show;
		case PaletteContentStyle.ButtonListItem:
		case PaletteContentStyle.ContextMenuHeading:
		case PaletteContentStyle.ContextMenuItemImage:
		case PaletteContentStyle.ContextMenuItemShortcutText:
		case PaletteContentStyle.GridHeaderColumnList:
		case PaletteContentStyle.GridHeaderRowList:
		case PaletteContentStyle.GridDataCellList:
		case PaletteContentStyle.GridHeaderColumnSheet:
		case PaletteContentStyle.GridHeaderRowSheet:
		case PaletteContentStyle.GridDataCellSheet:
		case PaletteContentStyle.GridHeaderColumnCustom1:
		case PaletteContentStyle.GridHeaderRowCustom1:
		case PaletteContentStyle.GridDataCellCustom1:
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderSecondary:
		case PaletteContentStyle.HeaderDockInactive:
		case PaletteContentStyle.HeaderDockActive:
		case PaletteContentStyle.HeaderCalendar:
		case PaletteContentStyle.HeaderCustom1:
		case PaletteContentStyle.HeaderCustom2:
		case PaletteContentStyle.LabelToolTip:
		case PaletteContentStyle.LabelSuperTip:
		case PaletteContentStyle.LabelKeyTip:
			return PaletteTextHotkeyPrefix.None;
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override InheritBool GetContentShortTextMultiLine(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return InheritBool.Inherit;
		}
		if ((uint)style <= 67u)
		{
			return InheritBool.True;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override PaletteTextTrim GetContentShortTextTrim(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteTextTrim.Inherit;
		}
		if ((uint)style <= 67u)
		{
			return PaletteTextTrim.EllipsisCharacter;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override PaletteRelativeAlign GetContentShortTextH(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteRelativeAlign.Inherit;
		}
		switch (style)
		{
		case PaletteContentStyle.ButtonNavigatorStack:
		case PaletteContentStyle.ButtonNavigatorOverflow:
		case PaletteContentStyle.ButtonListItem:
		case PaletteContentStyle.ButtonCommand:
		case PaletteContentStyle.ContextMenuHeading:
		case PaletteContentStyle.ContextMenuItemImage:
		case PaletteContentStyle.ContextMenuItemTextStandard:
		case PaletteContentStyle.ContextMenuItemTextAlternate:
		case PaletteContentStyle.GridHeaderColumnList:
		case PaletteContentStyle.GridHeaderRowList:
		case PaletteContentStyle.GridDataCellList:
		case PaletteContentStyle.GridHeaderRowSheet:
		case PaletteContentStyle.GridDataCellSheet:
		case PaletteContentStyle.GridHeaderColumnCustom1:
		case PaletteContentStyle.GridHeaderRowCustom1:
		case PaletteContentStyle.GridDataCellCustom1:
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderSecondary:
		case PaletteContentStyle.HeaderDockInactive:
		case PaletteContentStyle.HeaderDockActive:
		case PaletteContentStyle.HeaderForm:
		case PaletteContentStyle.HeaderCustom1:
		case PaletteContentStyle.HeaderCustom2:
		case PaletteContentStyle.LabelNormalControl:
		case PaletteContentStyle.LabelBoldControl:
		case PaletteContentStyle.LabelItalicControl:
		case PaletteContentStyle.LabelTitleControl:
		case PaletteContentStyle.LabelNormalPanel:
		case PaletteContentStyle.LabelBoldPanel:
		case PaletteContentStyle.LabelItalicPanel:
		case PaletteContentStyle.LabelTitlePanel:
		case PaletteContentStyle.LabelGroupBoxCaption:
		case PaletteContentStyle.LabelToolTip:
		case PaletteContentStyle.LabelSuperTip:
		case PaletteContentStyle.LabelKeyTip:
		case PaletteContentStyle.LabelCustom1:
		case PaletteContentStyle.LabelCustom2:
		case PaletteContentStyle.LabelCustom3:
			return PaletteRelativeAlign.Near;
		case PaletteContentStyle.GridHeaderColumnSheet:
		case PaletteContentStyle.HeaderCalendar:
			return PaletteRelativeAlign.Center;
		case PaletteContentStyle.ButtonStandalone:
		case PaletteContentStyle.ButtonAlternate:
		case PaletteContentStyle.ButtonLowProfile:
		case PaletteContentStyle.ButtonButtonSpec:
		case PaletteContentStyle.ButtonBreadCrumb:
		case PaletteContentStyle.ButtonCalendarDay:
		case PaletteContentStyle.ButtonCluster:
		case PaletteContentStyle.ButtonGallery:
		case PaletteContentStyle.ButtonNavigatorMini:
		case PaletteContentStyle.ButtonInputControl:
		case PaletteContentStyle.ButtonForm:
		case PaletteContentStyle.ButtonFormClose:
		case PaletteContentStyle.ButtonCustom1:
		case PaletteContentStyle.ButtonCustom2:
		case PaletteContentStyle.ButtonCustom3:
		case PaletteContentStyle.TabHighProfile:
		case PaletteContentStyle.TabStandardProfile:
		case PaletteContentStyle.TabLowProfile:
		case PaletteContentStyle.TabOneNote:
		case PaletteContentStyle.TabDock:
		case PaletteContentStyle.TabDockAutoHidden:
		case PaletteContentStyle.TabCustom1:
		case PaletteContentStyle.TabCustom2:
		case PaletteContentStyle.TabCustom3:
		case PaletteContentStyle.InputControlStandalone:
		case PaletteContentStyle.InputControlRibbon:
		case PaletteContentStyle.InputControlCustom1:
			return PaletteRelativeAlign.Center;
		case PaletteContentStyle.ContextMenuItemShortcutText:
			return PaletteRelativeAlign.Far;
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override PaletteRelativeAlign GetContentShortTextV(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteRelativeAlign.Inherit;
		}
		switch (style)
		{
		case PaletteContentStyle.ButtonStandalone:
		case PaletteContentStyle.ButtonAlternate:
		case PaletteContentStyle.ButtonLowProfile:
		case PaletteContentStyle.ButtonButtonSpec:
		case PaletteContentStyle.ButtonBreadCrumb:
		case PaletteContentStyle.ButtonCalendarDay:
		case PaletteContentStyle.ButtonCluster:
		case PaletteContentStyle.ButtonGallery:
		case PaletteContentStyle.ButtonNavigatorStack:
		case PaletteContentStyle.ButtonNavigatorOverflow:
		case PaletteContentStyle.ButtonNavigatorMini:
		case PaletteContentStyle.ButtonInputControl:
		case PaletteContentStyle.ButtonListItem:
		case PaletteContentStyle.ButtonForm:
		case PaletteContentStyle.ButtonFormClose:
		case PaletteContentStyle.ButtonCommand:
		case PaletteContentStyle.ButtonCustom1:
		case PaletteContentStyle.ButtonCustom2:
		case PaletteContentStyle.ButtonCustom3:
		case PaletteContentStyle.ContextMenuHeading:
		case PaletteContentStyle.ContextMenuItemImage:
		case PaletteContentStyle.ContextMenuItemTextStandard:
		case PaletteContentStyle.ContextMenuItemTextAlternate:
		case PaletteContentStyle.ContextMenuItemShortcutText:
		case PaletteContentStyle.GridHeaderColumnList:
		case PaletteContentStyle.GridHeaderRowList:
		case PaletteContentStyle.GridDataCellList:
		case PaletteContentStyle.GridHeaderColumnSheet:
		case PaletteContentStyle.GridHeaderRowSheet:
		case PaletteContentStyle.GridDataCellSheet:
		case PaletteContentStyle.GridHeaderColumnCustom1:
		case PaletteContentStyle.GridHeaderRowCustom1:
		case PaletteContentStyle.GridDataCellCustom1:
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderSecondary:
		case PaletteContentStyle.HeaderDockInactive:
		case PaletteContentStyle.HeaderDockActive:
		case PaletteContentStyle.HeaderForm:
		case PaletteContentStyle.HeaderCalendar:
		case PaletteContentStyle.HeaderCustom1:
		case PaletteContentStyle.HeaderCustom2:
		case PaletteContentStyle.LabelNormalControl:
		case PaletteContentStyle.LabelBoldControl:
		case PaletteContentStyle.LabelItalicControl:
		case PaletteContentStyle.LabelTitleControl:
		case PaletteContentStyle.LabelNormalPanel:
		case PaletteContentStyle.LabelBoldPanel:
		case PaletteContentStyle.LabelItalicPanel:
		case PaletteContentStyle.LabelTitlePanel:
		case PaletteContentStyle.LabelGroupBoxCaption:
		case PaletteContentStyle.LabelToolTip:
		case PaletteContentStyle.LabelKeyTip:
		case PaletteContentStyle.LabelCustom1:
		case PaletteContentStyle.LabelCustom2:
		case PaletteContentStyle.LabelCustom3:
		case PaletteContentStyle.TabHighProfile:
		case PaletteContentStyle.TabStandardProfile:
		case PaletteContentStyle.TabLowProfile:
		case PaletteContentStyle.TabOneNote:
		case PaletteContentStyle.TabDock:
		case PaletteContentStyle.TabDockAutoHidden:
		case PaletteContentStyle.TabCustom1:
		case PaletteContentStyle.TabCustom2:
		case PaletteContentStyle.TabCustom3:
		case PaletteContentStyle.InputControlStandalone:
		case PaletteContentStyle.InputControlRibbon:
		case PaletteContentStyle.InputControlCustom1:
			return PaletteRelativeAlign.Center;
		case PaletteContentStyle.LabelSuperTip:
			return PaletteRelativeAlign.Near;
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override PaletteRelativeAlign GetContentShortTextMultiLineH(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteRelativeAlign.Inherit;
		}
		if ((uint)style <= 67u)
		{
			return PaletteRelativeAlign.Near;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override Color GetContentShortTextColor1(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			switch (style)
			{
			case PaletteContentStyle.LabelNormalControl:
			case PaletteContentStyle.LabelBoldControl:
			case PaletteContentStyle.LabelItalicControl:
			case PaletteContentStyle.LabelTitleControl:
				return state switch
				{
					PaletteState.LinkNotVisitedOverride => _ribbonColors[63], 
					PaletteState.LinkVisitedOverride => _ribbonColors[64], 
					PaletteState.LinkPressedOverride => _ribbonColors[65], 
					_ => Color.Empty, 
				};
			case PaletteContentStyle.LabelNormalPanel:
			case PaletteContentStyle.LabelBoldPanel:
			case PaletteContentStyle.LabelItalicPanel:
			case PaletteContentStyle.LabelTitlePanel:
			case PaletteContentStyle.LabelGroupBoxCaption:
				return state switch
				{
					PaletteState.LinkNotVisitedOverride => _ribbonColors[66], 
					PaletteState.LinkVisitedOverride => _ribbonColors[67], 
					PaletteState.LinkPressedOverride => _ribbonColors[68], 
					_ => Color.Empty, 
				};
			default:
				return Color.Empty;
			}
		}
		if (style == PaletteContentStyle.HeaderForm)
		{
			if (state == PaletteState.Disabled)
			{
				return _disabledText;
			}
			return _colorWhite255;
		}
		if (state == PaletteState.Disabled && style != PaletteContentStyle.LabelToolTip && style != PaletteContentStyle.LabelSuperTip && style != PaletteContentStyle.LabelKeyTip && style != PaletteContentStyle.InputControlStandalone && style != PaletteContentStyle.InputControlRibbon && style != PaletteContentStyle.InputControlCustom1 && style != PaletteContentStyle.ButtonCalendarDay)
		{
			return _disabledText;
		}
		switch (style)
		{
		case PaletteContentStyle.ContextMenuItemImage:
		case PaletteContentStyle.ContextMenuItemTextStandard:
		case PaletteContentStyle.ContextMenuItemTextAlternate:
		case PaletteContentStyle.ContextMenuItemShortcutText:
		case PaletteContentStyle.LabelNormalControl:
		case PaletteContentStyle.LabelBoldControl:
		case PaletteContentStyle.LabelItalicControl:
		case PaletteContentStyle.LabelTitleControl:
		case PaletteContentStyle.LabelToolTip:
		case PaletteContentStyle.LabelSuperTip:
		case PaletteContentStyle.LabelKeyTip:
		case PaletteContentStyle.LabelCustom1:
		case PaletteContentStyle.LabelCustom2:
		case PaletteContentStyle.LabelCustom3:
			return _colorDark00;
		case PaletteContentStyle.ButtonListItem:
		case PaletteContentStyle.ButtonCommand:
			if ((uint)(state - 1) <= 1u || state == PaletteState.Tracking || state == PaletteState.NormalDefaultOverride)
			{
				return _colorDark00;
			}
			return _colorWhite255;
		case PaletteContentStyle.ButtonStandalone:
		case PaletteContentStyle.ButtonAlternate:
		case PaletteContentStyle.ButtonBreadCrumb:
		case PaletteContentStyle.ButtonCluster:
		case PaletteContentStyle.ButtonGallery:
		case PaletteContentStyle.ButtonNavigatorStack:
		case PaletteContentStyle.ButtonNavigatorOverflow:
		case PaletteContentStyle.ButtonNavigatorMini:
		case PaletteContentStyle.ButtonCustom1:
		case PaletteContentStyle.ButtonCustom2:
		case PaletteContentStyle.ButtonCustom3:
		case PaletteContentStyle.ContextMenuHeading:
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderSecondary:
		case PaletteContentStyle.HeaderDockInactive:
		case PaletteContentStyle.HeaderDockActive:
		case PaletteContentStyle.HeaderCalendar:
		case PaletteContentStyle.HeaderCustom1:
		case PaletteContentStyle.HeaderCustom2:
		case PaletteContentStyle.LabelNormalPanel:
		case PaletteContentStyle.LabelBoldPanel:
		case PaletteContentStyle.LabelItalicPanel:
		case PaletteContentStyle.LabelTitlePanel:
		case PaletteContentStyle.LabelGroupBoxCaption:
			return _colorWhite255;
		case PaletteContentStyle.ButtonCalendarDay:
			switch (state)
			{
			case PaletteState.Disabled:
				return _colorWhite128;
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.FocusOverride:
				return _colorWhite255;
			default:
				return _colorDark00;
			}
		case PaletteContentStyle.ButtonLowProfile:
		case PaletteContentStyle.ButtonInputControl:
		case PaletteContentStyle.ButtonForm:
		case PaletteContentStyle.ButtonFormClose:
			if (state == PaletteState.Normal || state == PaletteState.NormalDefaultOverride)
			{
				return _colorDark00;
			}
			return _colorWhite255;
		case PaletteContentStyle.ButtonButtonSpec:
			return _colorWhite255;
		case PaletteContentStyle.GridDataCellList:
		case PaletteContentStyle.GridDataCellSheet:
		case PaletteContentStyle.GridDataCellCustom1:
			if (state == PaletteState.CheckedNormal)
			{
				return _colorWhite255;
			}
			return _colorDark00;
		case PaletteContentStyle.GridHeaderColumnSheet:
		case PaletteContentStyle.GridHeaderRowSheet:
			if (state != PaletteState.Pressed)
			{
				return _colorDark00;
			}
			return _colorWhite255;
		case PaletteContentStyle.GridHeaderColumnList:
		case PaletteContentStyle.GridHeaderRowList:
		case PaletteContentStyle.GridHeaderColumnCustom1:
		case PaletteContentStyle.GridHeaderRowCustom1:
			return _colorDark00;
		case PaletteContentStyle.InputControlStandalone:
		case PaletteContentStyle.InputControlRibbon:
		case PaletteContentStyle.InputControlCustom1:
			if (state == PaletteState.Disabled)
			{
				return _inputControlTextDisabled;
			}
			return _colorDark00;
		case PaletteContentStyle.TabHighProfile:
		case PaletteContentStyle.TabStandardProfile:
		case PaletteContentStyle.TabOneNote:
		case PaletteContentStyle.TabDock:
		case PaletteContentStyle.TabCustom1:
		case PaletteContentStyle.TabCustom2:
		case PaletteContentStyle.TabCustom3:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledText;
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
			case PaletteState.FocusOverride:
				return _colorDark00;
			default:
				return _sparkleColors[4];
			}
		case PaletteContentStyle.TabDockAutoHidden:
			return state switch
			{
				PaletteState.Disabled => _disabledText, 
				PaletteState.FocusOverride => _colorDark00, 
				_ => _sparkleColors[4], 
			};
		case PaletteContentStyle.TabLowProfile:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledText;
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
			case PaletteState.FocusOverride:
				return _colorDark00;
			default:
				return _colorWhite255;
			}
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override Color GetContentShortTextColor2(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return Color.Empty;
		}
		if (style == PaletteContentStyle.HeaderForm)
		{
			if (state == PaletteState.Disabled)
			{
				return PaletteBase.FadedColor(_colorWhite255);
			}
			return _colorWhite255;
		}
		if (state == PaletteState.Disabled && style != PaletteContentStyle.LabelToolTip && style != PaletteContentStyle.LabelSuperTip && style != PaletteContentStyle.LabelKeyTip && style != PaletteContentStyle.InputControlStandalone && style != PaletteContentStyle.InputControlRibbon && style != PaletteContentStyle.InputControlCustom1 && style != PaletteContentStyle.ButtonCalendarDay)
		{
			return _disabledText;
		}
		switch (style)
		{
		case PaletteContentStyle.ContextMenuItemImage:
		case PaletteContentStyle.ContextMenuItemTextStandard:
		case PaletteContentStyle.ContextMenuItemTextAlternate:
		case PaletteContentStyle.ContextMenuItemShortcutText:
		case PaletteContentStyle.LabelNormalControl:
		case PaletteContentStyle.LabelBoldControl:
		case PaletteContentStyle.LabelItalicControl:
		case PaletteContentStyle.LabelTitleControl:
		case PaletteContentStyle.LabelToolTip:
		case PaletteContentStyle.LabelSuperTip:
		case PaletteContentStyle.LabelKeyTip:
		case PaletteContentStyle.LabelCustom1:
		case PaletteContentStyle.LabelCustom2:
		case PaletteContentStyle.LabelCustom3:
			return _colorDark00;
		case PaletteContentStyle.ButtonListItem:
		case PaletteContentStyle.ButtonCommand:
			switch (state)
			{
			case PaletteState.Disabled:
			case PaletteState.Normal:
			case PaletteState.Tracking:
			case PaletteState.NormalDefaultOverride:
				return _colorDark00;
			case PaletteState.Pressed:
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _colorWhite255;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteContentStyle.ButtonStandalone:
		case PaletteContentStyle.ButtonAlternate:
		case PaletteContentStyle.ButtonBreadCrumb:
		case PaletteContentStyle.ButtonCluster:
		case PaletteContentStyle.ButtonGallery:
		case PaletteContentStyle.ButtonNavigatorStack:
		case PaletteContentStyle.ButtonNavigatorOverflow:
		case PaletteContentStyle.ButtonNavigatorMini:
		case PaletteContentStyle.ButtonCustom1:
		case PaletteContentStyle.ButtonCustom2:
		case PaletteContentStyle.ButtonCustom3:
		case PaletteContentStyle.ContextMenuHeading:
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderSecondary:
		case PaletteContentStyle.HeaderDockInactive:
		case PaletteContentStyle.HeaderDockActive:
		case PaletteContentStyle.HeaderCalendar:
		case PaletteContentStyle.HeaderCustom1:
		case PaletteContentStyle.HeaderCustom2:
		case PaletteContentStyle.LabelNormalPanel:
		case PaletteContentStyle.LabelBoldPanel:
		case PaletteContentStyle.LabelItalicPanel:
		case PaletteContentStyle.LabelTitlePanel:
		case PaletteContentStyle.LabelGroupBoxCaption:
			return _colorWhite255;
		case PaletteContentStyle.ButtonCalendarDay:
			switch (state)
			{
			case PaletteState.Disabled:
				return _colorWhite128;
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.FocusOverride:
				return _colorWhite255;
			default:
				return _colorDark00;
			}
		case PaletteContentStyle.ButtonLowProfile:
		case PaletteContentStyle.ButtonButtonSpec:
		case PaletteContentStyle.ButtonInputControl:
		case PaletteContentStyle.ButtonForm:
		case PaletteContentStyle.ButtonFormClose:
			if (state == PaletteState.Normal || state == PaletteState.NormalDefaultOverride)
			{
				return _colorDark00;
			}
			return _colorWhite255;
		case PaletteContentStyle.GridDataCellList:
		case PaletteContentStyle.GridDataCellSheet:
		case PaletteContentStyle.GridDataCellCustom1:
			if (state == PaletteState.CheckedNormal)
			{
				return _colorWhite255;
			}
			return _colorDark00;
		case PaletteContentStyle.GridHeaderColumnSheet:
		case PaletteContentStyle.GridHeaderRowSheet:
			if (state != PaletteState.Pressed)
			{
				return _colorDark00;
			}
			return _colorWhite255;
		case PaletteContentStyle.GridHeaderColumnList:
		case PaletteContentStyle.GridHeaderRowList:
		case PaletteContentStyle.GridHeaderColumnCustom1:
		case PaletteContentStyle.GridHeaderRowCustom1:
			return _colorDark00;
		case PaletteContentStyle.InputControlStandalone:
		case PaletteContentStyle.InputControlRibbon:
		case PaletteContentStyle.InputControlCustom1:
			if (state == PaletteState.Disabled)
			{
				return _inputControlTextDisabled;
			}
			return _colorDark00;
		case PaletteContentStyle.TabHighProfile:
		case PaletteContentStyle.TabStandardProfile:
		case PaletteContentStyle.TabOneNote:
		case PaletteContentStyle.TabDock:
		case PaletteContentStyle.TabCustom1:
		case PaletteContentStyle.TabCustom2:
		case PaletteContentStyle.TabCustom3:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledText;
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _colorDark00;
			default:
				return _sparkleColors[4];
			}
		case PaletteContentStyle.TabDockAutoHidden:
			if (state == PaletteState.Disabled)
			{
				return _disabledText;
			}
			return _sparkleColors[4];
		case PaletteContentStyle.TabLowProfile:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledText;
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _colorDark00;
			default:
				return _colorWhite255;
			}
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override PaletteColorStyle GetContentShortTextColorStyle(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteColorStyle.Inherit;
		}
		if ((uint)style <= 67u)
		{
			return PaletteColorStyle.Solid;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override PaletteRectangleAlign GetContentShortTextColorAlign(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteRectangleAlign.Inherit;
		}
		if ((uint)style <= 67u)
		{
			return PaletteRectangleAlign.Local;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override float GetContentShortTextColorAngle(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return -1f;
		}
		if ((uint)style <= 67u)
		{
			return 90f;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override Image GetContentShortTextImage(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return null;
		}
		if ((uint)style <= 67u)
		{
			return null;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override PaletteImageStyle GetContentShortTextImageStyle(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteImageStyle.Inherit;
		}
		if ((uint)style <= 67u)
		{
			return PaletteImageStyle.TileFlipXY;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override PaletteRectangleAlign GetContentShortTextImageAlign(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteRectangleAlign.Inherit;
		}
		if ((uint)style <= 67u)
		{
			return PaletteRectangleAlign.Local;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override Font GetContentLongTextFont(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			if (state == PaletteState.BoldedOverride && style == PaletteContentStyle.ButtonCalendarDay)
			{
				return _calendarBoldFont;
			}
			return null;
		}
		switch (style)
		{
		case PaletteContentStyle.GridHeaderColumnList:
		case PaletteContentStyle.GridHeaderRowList:
		case PaletteContentStyle.GridDataCellList:
		case PaletteContentStyle.GridHeaderColumnSheet:
		case PaletteContentStyle.GridHeaderRowSheet:
		case PaletteContentStyle.GridDataCellSheet:
		case PaletteContentStyle.GridHeaderColumnCustom1:
		case PaletteContentStyle.GridHeaderRowCustom1:
		case PaletteContentStyle.GridDataCellCustom1:
		case PaletteContentStyle.HeaderCalendar:
			return _gridFont;
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderDockInactive:
		case PaletteContentStyle.HeaderDockActive:
		case PaletteContentStyle.HeaderForm:
		case PaletteContentStyle.HeaderCustom1:
		case PaletteContentStyle.HeaderCustom2:
		case PaletteContentStyle.LabelTitleControl:
		case PaletteContentStyle.LabelTitlePanel:
			return _header1LongFont;
		case PaletteContentStyle.ContextMenuHeading:
		case PaletteContentStyle.ContextMenuItemImage:
		case PaletteContentStyle.ContextMenuItemTextStandard:
		case PaletteContentStyle.ContextMenuItemTextAlternate:
		case PaletteContentStyle.ContextMenuItemShortcutText:
		case PaletteContentStyle.HeaderSecondary:
		case PaletteContentStyle.LabelNormalControl:
		case PaletteContentStyle.LabelBoldControl:
		case PaletteContentStyle.LabelItalicControl:
		case PaletteContentStyle.LabelNormalPanel:
		case PaletteContentStyle.LabelBoldPanel:
		case PaletteContentStyle.LabelItalicPanel:
		case PaletteContentStyle.LabelGroupBoxCaption:
		case PaletteContentStyle.LabelToolTip:
		case PaletteContentStyle.LabelSuperTip:
		case PaletteContentStyle.LabelKeyTip:
		case PaletteContentStyle.LabelCustom1:
		case PaletteContentStyle.LabelCustom2:
		case PaletteContentStyle.LabelCustom3:
		case PaletteContentStyle.InputControlStandalone:
		case PaletteContentStyle.InputControlRibbon:
		case PaletteContentStyle.InputControlCustom1:
			return _header2LongFont;
		case PaletteContentStyle.TabLowProfile:
		case PaletteContentStyle.TabDock:
		case PaletteContentStyle.TabDockAutoHidden:
			return _tabFontNormal;
		case PaletteContentStyle.TabHighProfile:
		case PaletteContentStyle.TabStandardProfile:
		case PaletteContentStyle.TabOneNote:
		case PaletteContentStyle.TabCustom1:
		case PaletteContentStyle.TabCustom2:
		case PaletteContentStyle.TabCustom3:
			if (state == PaletteState.CheckedNormal || state == PaletteState.CheckedTracking || state == PaletteState.CheckedPressed)
			{
				return _tabFontSelected;
			}
			return _tabFontNormal;
		case PaletteContentStyle.ButtonStandalone:
		case PaletteContentStyle.ButtonAlternate:
		case PaletteContentStyle.ButtonLowProfile:
		case PaletteContentStyle.ButtonButtonSpec:
		case PaletteContentStyle.ButtonBreadCrumb:
		case PaletteContentStyle.ButtonCluster:
		case PaletteContentStyle.ButtonGallery:
		case PaletteContentStyle.ButtonNavigatorStack:
		case PaletteContentStyle.ButtonNavigatorOverflow:
		case PaletteContentStyle.ButtonNavigatorMini:
		case PaletteContentStyle.ButtonInputControl:
		case PaletteContentStyle.ButtonListItem:
		case PaletteContentStyle.ButtonForm:
		case PaletteContentStyle.ButtonFormClose:
		case PaletteContentStyle.ButtonCommand:
		case PaletteContentStyle.ButtonCustom1:
		case PaletteContentStyle.ButtonCustom2:
		case PaletteContentStyle.ButtonCustom3:
			return _buttonFont;
		case PaletteContentStyle.ButtonCalendarDay:
			return _calendarFont;
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override Font GetContentLongTextNewFont(PaletteContentStyle style, PaletteState state)
	{
		DefineFonts();
		return GetContentLongTextFont(style, state);
	}

	public override PaletteTextHint GetContentLongTextHint(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteTextHint.Inherit;
		}
		if ((uint)style <= 67u)
		{
			return PaletteTextHint.ClearTypeGridFit;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override InheritBool GetContentLongTextMultiLine(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return InheritBool.Inherit;
		}
		if ((uint)style <= 67u)
		{
			return InheritBool.True;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override PaletteTextTrim GetContentLongTextTrim(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteTextTrim.Inherit;
		}
		if ((uint)style <= 67u)
		{
			return PaletteTextTrim.EllipsisCharacter;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override PaletteTextHotkeyPrefix GetContentLongTextPrefix(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteTextHotkeyPrefix.Inherit;
		}
		switch (style)
		{
		case PaletteContentStyle.ButtonStandalone:
		case PaletteContentStyle.ButtonAlternate:
		case PaletteContentStyle.ButtonLowProfile:
		case PaletteContentStyle.ButtonButtonSpec:
		case PaletteContentStyle.ButtonBreadCrumb:
		case PaletteContentStyle.ButtonCalendarDay:
		case PaletteContentStyle.ButtonCluster:
		case PaletteContentStyle.ButtonGallery:
		case PaletteContentStyle.ButtonNavigatorStack:
		case PaletteContentStyle.ButtonNavigatorOverflow:
		case PaletteContentStyle.ButtonNavigatorMini:
		case PaletteContentStyle.ButtonInputControl:
		case PaletteContentStyle.ButtonForm:
		case PaletteContentStyle.ButtonFormClose:
		case PaletteContentStyle.ButtonCommand:
		case PaletteContentStyle.ButtonCustom1:
		case PaletteContentStyle.ButtonCustom2:
		case PaletteContentStyle.ButtonCustom3:
		case PaletteContentStyle.TabHighProfile:
		case PaletteContentStyle.TabStandardProfile:
		case PaletteContentStyle.TabLowProfile:
		case PaletteContentStyle.TabOneNote:
		case PaletteContentStyle.TabDock:
		case PaletteContentStyle.TabDockAutoHidden:
		case PaletteContentStyle.TabCustom1:
		case PaletteContentStyle.TabCustom2:
		case PaletteContentStyle.TabCustom3:
			return PaletteTextHotkeyPrefix.Show;
		case PaletteContentStyle.ButtonListItem:
		case PaletteContentStyle.ContextMenuHeading:
		case PaletteContentStyle.ContextMenuItemImage:
		case PaletteContentStyle.ContextMenuItemTextStandard:
		case PaletteContentStyle.ContextMenuItemTextAlternate:
		case PaletteContentStyle.ContextMenuItemShortcutText:
		case PaletteContentStyle.GridHeaderColumnList:
		case PaletteContentStyle.GridHeaderRowList:
		case PaletteContentStyle.GridDataCellList:
		case PaletteContentStyle.GridHeaderColumnSheet:
		case PaletteContentStyle.GridHeaderRowSheet:
		case PaletteContentStyle.GridDataCellSheet:
		case PaletteContentStyle.GridHeaderColumnCustom1:
		case PaletteContentStyle.GridHeaderRowCustom1:
		case PaletteContentStyle.GridDataCellCustom1:
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderSecondary:
		case PaletteContentStyle.HeaderDockInactive:
		case PaletteContentStyle.HeaderDockActive:
		case PaletteContentStyle.HeaderForm:
		case PaletteContentStyle.HeaderCalendar:
		case PaletteContentStyle.HeaderCustom1:
		case PaletteContentStyle.HeaderCustom2:
		case PaletteContentStyle.LabelNormalControl:
		case PaletteContentStyle.LabelBoldControl:
		case PaletteContentStyle.LabelItalicControl:
		case PaletteContentStyle.LabelTitleControl:
		case PaletteContentStyle.LabelNormalPanel:
		case PaletteContentStyle.LabelBoldPanel:
		case PaletteContentStyle.LabelItalicPanel:
		case PaletteContentStyle.LabelTitlePanel:
		case PaletteContentStyle.LabelGroupBoxCaption:
		case PaletteContentStyle.LabelToolTip:
		case PaletteContentStyle.LabelSuperTip:
		case PaletteContentStyle.LabelKeyTip:
		case PaletteContentStyle.LabelCustom1:
		case PaletteContentStyle.LabelCustom2:
		case PaletteContentStyle.LabelCustom3:
		case PaletteContentStyle.InputControlStandalone:
		case PaletteContentStyle.InputControlRibbon:
		case PaletteContentStyle.InputControlCustom1:
			return PaletteTextHotkeyPrefix.None;
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override PaletteRelativeAlign GetContentLongTextH(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteRelativeAlign.Inherit;
		}
		switch (style)
		{
		case PaletteContentStyle.ContextMenuItemTextAlternate:
		case PaletteContentStyle.LabelToolTip:
		case PaletteContentStyle.LabelSuperTip:
		case PaletteContentStyle.LabelKeyTip:
			return PaletteRelativeAlign.Near;
		case PaletteContentStyle.ButtonNavigatorStack:
		case PaletteContentStyle.ButtonNavigatorOverflow:
		case PaletteContentStyle.ButtonListItem:
		case PaletteContentStyle.ButtonCommand:
		case PaletteContentStyle.ContextMenuHeading:
		case PaletteContentStyle.ContextMenuItemImage:
		case PaletteContentStyle.ContextMenuItemTextStandard:
		case PaletteContentStyle.ContextMenuItemShortcutText:
		case PaletteContentStyle.GridHeaderColumnList:
		case PaletteContentStyle.GridHeaderRowList:
		case PaletteContentStyle.GridDataCellList:
		case PaletteContentStyle.GridHeaderRowSheet:
		case PaletteContentStyle.GridDataCellSheet:
		case PaletteContentStyle.GridHeaderColumnCustom1:
		case PaletteContentStyle.GridHeaderRowCustom1:
		case PaletteContentStyle.GridDataCellCustom1:
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderSecondary:
		case PaletteContentStyle.HeaderDockInactive:
		case PaletteContentStyle.HeaderDockActive:
		case PaletteContentStyle.HeaderForm:
		case PaletteContentStyle.HeaderCalendar:
		case PaletteContentStyle.HeaderCustom1:
		case PaletteContentStyle.HeaderCustom2:
		case PaletteContentStyle.LabelNormalControl:
		case PaletteContentStyle.LabelBoldControl:
		case PaletteContentStyle.LabelItalicControl:
		case PaletteContentStyle.LabelTitleControl:
		case PaletteContentStyle.LabelNormalPanel:
		case PaletteContentStyle.LabelBoldPanel:
		case PaletteContentStyle.LabelItalicPanel:
		case PaletteContentStyle.LabelTitlePanel:
		case PaletteContentStyle.LabelGroupBoxCaption:
		case PaletteContentStyle.LabelCustom1:
		case PaletteContentStyle.LabelCustom2:
		case PaletteContentStyle.LabelCustom3:
			return PaletteRelativeAlign.Far;
		case PaletteContentStyle.ButtonStandalone:
		case PaletteContentStyle.ButtonAlternate:
		case PaletteContentStyle.ButtonLowProfile:
		case PaletteContentStyle.ButtonButtonSpec:
		case PaletteContentStyle.ButtonBreadCrumb:
		case PaletteContentStyle.ButtonCalendarDay:
		case PaletteContentStyle.ButtonCluster:
		case PaletteContentStyle.ButtonGallery:
		case PaletteContentStyle.ButtonNavigatorMini:
		case PaletteContentStyle.ButtonInputControl:
		case PaletteContentStyle.ButtonForm:
		case PaletteContentStyle.ButtonFormClose:
		case PaletteContentStyle.ButtonCustom1:
		case PaletteContentStyle.ButtonCustom2:
		case PaletteContentStyle.ButtonCustom3:
		case PaletteContentStyle.GridHeaderColumnSheet:
		case PaletteContentStyle.TabHighProfile:
		case PaletteContentStyle.TabStandardProfile:
		case PaletteContentStyle.TabLowProfile:
		case PaletteContentStyle.TabOneNote:
		case PaletteContentStyle.TabDock:
		case PaletteContentStyle.TabDockAutoHidden:
		case PaletteContentStyle.TabCustom1:
		case PaletteContentStyle.TabCustom2:
		case PaletteContentStyle.TabCustom3:
		case PaletteContentStyle.InputControlStandalone:
		case PaletteContentStyle.InputControlRibbon:
		case PaletteContentStyle.InputControlCustom1:
			return PaletteRelativeAlign.Center;
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override PaletteRelativeAlign GetContentLongTextV(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteRelativeAlign.Inherit;
		}
		switch (style)
		{
		case PaletteContentStyle.ButtonStandalone:
		case PaletteContentStyle.ButtonAlternate:
		case PaletteContentStyle.ButtonLowProfile:
		case PaletteContentStyle.ButtonButtonSpec:
		case PaletteContentStyle.ButtonBreadCrumb:
		case PaletteContentStyle.ButtonCalendarDay:
		case PaletteContentStyle.ButtonCluster:
		case PaletteContentStyle.ButtonGallery:
		case PaletteContentStyle.ButtonNavigatorStack:
		case PaletteContentStyle.ButtonNavigatorOverflow:
		case PaletteContentStyle.ButtonNavigatorMini:
		case PaletteContentStyle.ButtonInputControl:
		case PaletteContentStyle.ButtonListItem:
		case PaletteContentStyle.ButtonForm:
		case PaletteContentStyle.ButtonFormClose:
		case PaletteContentStyle.ButtonCommand:
		case PaletteContentStyle.ButtonCustom1:
		case PaletteContentStyle.ButtonCustom2:
		case PaletteContentStyle.ButtonCustom3:
		case PaletteContentStyle.ContextMenuHeading:
		case PaletteContentStyle.ContextMenuItemImage:
		case PaletteContentStyle.ContextMenuItemTextStandard:
		case PaletteContentStyle.ContextMenuItemShortcutText:
		case PaletteContentStyle.GridHeaderColumnList:
		case PaletteContentStyle.GridHeaderRowList:
		case PaletteContentStyle.GridDataCellList:
		case PaletteContentStyle.GridHeaderColumnSheet:
		case PaletteContentStyle.GridHeaderRowSheet:
		case PaletteContentStyle.GridDataCellSheet:
		case PaletteContentStyle.GridHeaderColumnCustom1:
		case PaletteContentStyle.GridHeaderRowCustom1:
		case PaletteContentStyle.GridDataCellCustom1:
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderSecondary:
		case PaletteContentStyle.HeaderDockInactive:
		case PaletteContentStyle.HeaderDockActive:
		case PaletteContentStyle.HeaderForm:
		case PaletteContentStyle.HeaderCalendar:
		case PaletteContentStyle.HeaderCustom1:
		case PaletteContentStyle.HeaderCustom2:
		case PaletteContentStyle.LabelNormalControl:
		case PaletteContentStyle.LabelBoldControl:
		case PaletteContentStyle.LabelItalicControl:
		case PaletteContentStyle.LabelTitleControl:
		case PaletteContentStyle.LabelNormalPanel:
		case PaletteContentStyle.LabelBoldPanel:
		case PaletteContentStyle.LabelItalicPanel:
		case PaletteContentStyle.LabelTitlePanel:
		case PaletteContentStyle.LabelGroupBoxCaption:
		case PaletteContentStyle.LabelCustom1:
		case PaletteContentStyle.LabelCustom2:
		case PaletteContentStyle.LabelCustom3:
		case PaletteContentStyle.TabHighProfile:
		case PaletteContentStyle.TabStandardProfile:
		case PaletteContentStyle.TabLowProfile:
		case PaletteContentStyle.TabOneNote:
		case PaletteContentStyle.TabDock:
		case PaletteContentStyle.TabDockAutoHidden:
		case PaletteContentStyle.TabCustom1:
		case PaletteContentStyle.TabCustom2:
		case PaletteContentStyle.TabCustom3:
		case PaletteContentStyle.InputControlStandalone:
		case PaletteContentStyle.InputControlRibbon:
		case PaletteContentStyle.InputControlCustom1:
			return PaletteRelativeAlign.Center;
		case PaletteContentStyle.ContextMenuItemTextAlternate:
		case PaletteContentStyle.LabelToolTip:
		case PaletteContentStyle.LabelKeyTip:
			return PaletteRelativeAlign.Far;
		case PaletteContentStyle.LabelSuperTip:
			return PaletteRelativeAlign.Center;
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override PaletteRelativeAlign GetContentLongTextMultiLineH(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteRelativeAlign.Inherit;
		}
		switch (style)
		{
		case PaletteContentStyle.ButtonStandalone:
		case PaletteContentStyle.ButtonAlternate:
		case PaletteContentStyle.ButtonLowProfile:
		case PaletteContentStyle.ButtonButtonSpec:
		case PaletteContentStyle.ButtonBreadCrumb:
		case PaletteContentStyle.ButtonCalendarDay:
		case PaletteContentStyle.ButtonCluster:
		case PaletteContentStyle.ButtonGallery:
		case PaletteContentStyle.ButtonNavigatorStack:
		case PaletteContentStyle.ButtonNavigatorOverflow:
		case PaletteContentStyle.ButtonNavigatorMini:
		case PaletteContentStyle.ButtonInputControl:
		case PaletteContentStyle.ButtonListItem:
		case PaletteContentStyle.ButtonForm:
		case PaletteContentStyle.ButtonFormClose:
		case PaletteContentStyle.ButtonCustom1:
		case PaletteContentStyle.ButtonCustom2:
		case PaletteContentStyle.ButtonCustom3:
		case PaletteContentStyle.ContextMenuHeading:
		case PaletteContentStyle.ContextMenuItemImage:
		case PaletteContentStyle.GridHeaderColumnList:
		case PaletteContentStyle.GridHeaderRowList:
		case PaletteContentStyle.GridDataCellList:
		case PaletteContentStyle.GridHeaderColumnSheet:
		case PaletteContentStyle.GridHeaderRowSheet:
		case PaletteContentStyle.GridDataCellSheet:
		case PaletteContentStyle.GridHeaderColumnCustom1:
		case PaletteContentStyle.GridHeaderRowCustom1:
		case PaletteContentStyle.GridDataCellCustom1:
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderSecondary:
		case PaletteContentStyle.HeaderDockInactive:
		case PaletteContentStyle.HeaderDockActive:
		case PaletteContentStyle.HeaderForm:
		case PaletteContentStyle.HeaderCalendar:
		case PaletteContentStyle.HeaderCustom1:
		case PaletteContentStyle.HeaderCustom2:
		case PaletteContentStyle.LabelNormalControl:
		case PaletteContentStyle.LabelBoldControl:
		case PaletteContentStyle.LabelItalicControl:
		case PaletteContentStyle.LabelTitleControl:
		case PaletteContentStyle.LabelNormalPanel:
		case PaletteContentStyle.LabelBoldPanel:
		case PaletteContentStyle.LabelItalicPanel:
		case PaletteContentStyle.LabelTitlePanel:
		case PaletteContentStyle.LabelGroupBoxCaption:
		case PaletteContentStyle.LabelCustom1:
		case PaletteContentStyle.LabelCustom2:
		case PaletteContentStyle.LabelCustom3:
		case PaletteContentStyle.TabHighProfile:
		case PaletteContentStyle.TabStandardProfile:
		case PaletteContentStyle.TabLowProfile:
		case PaletteContentStyle.TabOneNote:
		case PaletteContentStyle.TabDock:
		case PaletteContentStyle.TabDockAutoHidden:
		case PaletteContentStyle.TabCustom1:
		case PaletteContentStyle.TabCustom2:
		case PaletteContentStyle.TabCustom3:
		case PaletteContentStyle.InputControlStandalone:
		case PaletteContentStyle.InputControlRibbon:
		case PaletteContentStyle.InputControlCustom1:
			return PaletteRelativeAlign.Center;
		case PaletteContentStyle.ButtonCommand:
		case PaletteContentStyle.ContextMenuItemTextStandard:
		case PaletteContentStyle.ContextMenuItemTextAlternate:
		case PaletteContentStyle.LabelToolTip:
		case PaletteContentStyle.LabelSuperTip:
		case PaletteContentStyle.LabelKeyTip:
			return PaletteRelativeAlign.Near;
		case PaletteContentStyle.ContextMenuItemShortcutText:
			return PaletteRelativeAlign.Far;
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override Color GetContentLongTextColor1(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return Color.Empty;
		}
		if (style == PaletteContentStyle.HeaderForm)
		{
			if (state == PaletteState.Disabled)
			{
				return PaletteBase.FadedColor(_colorWhite255);
			}
			return _colorWhite255;
		}
		if (state == PaletteState.Disabled && style != PaletteContentStyle.LabelToolTip && style != PaletteContentStyle.LabelSuperTip && style != PaletteContentStyle.LabelKeyTip && style != PaletteContentStyle.InputControlStandalone && style != PaletteContentStyle.InputControlRibbon && style != PaletteContentStyle.InputControlCustom1)
		{
			return _disabledText;
		}
		switch (style)
		{
		case PaletteContentStyle.ContextMenuItemImage:
		case PaletteContentStyle.ContextMenuItemTextStandard:
		case PaletteContentStyle.ContextMenuItemTextAlternate:
		case PaletteContentStyle.ContextMenuItemShortcutText:
		case PaletteContentStyle.LabelNormalControl:
		case PaletteContentStyle.LabelBoldControl:
		case PaletteContentStyle.LabelItalicControl:
		case PaletteContentStyle.LabelTitleControl:
		case PaletteContentStyle.LabelToolTip:
		case PaletteContentStyle.LabelSuperTip:
		case PaletteContentStyle.LabelKeyTip:
		case PaletteContentStyle.LabelCustom1:
		case PaletteContentStyle.LabelCustom2:
		case PaletteContentStyle.LabelCustom3:
			return _colorDark00;
		case PaletteContentStyle.ButtonListItem:
		case PaletteContentStyle.ButtonCommand:
			switch (state)
			{
			case PaletteState.Disabled:
			case PaletteState.Normal:
			case PaletteState.Tracking:
			case PaletteState.NormalDefaultOverride:
				return _colorDark00;
			case PaletteState.Pressed:
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _colorWhite255;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteContentStyle.ButtonCalendarDay:
			switch (state)
			{
			case PaletteState.Disabled:
				return _colorWhite128;
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.FocusOverride:
				return _colorWhite255;
			default:
				return _colorDark00;
			}
		case PaletteContentStyle.ButtonStandalone:
		case PaletteContentStyle.ButtonAlternate:
		case PaletteContentStyle.ButtonBreadCrumb:
		case PaletteContentStyle.ButtonCluster:
		case PaletteContentStyle.ButtonGallery:
		case PaletteContentStyle.ButtonNavigatorStack:
		case PaletteContentStyle.ButtonNavigatorOverflow:
		case PaletteContentStyle.ButtonNavigatorMini:
		case PaletteContentStyle.ButtonCustom1:
		case PaletteContentStyle.ButtonCustom2:
		case PaletteContentStyle.ButtonCustom3:
		case PaletteContentStyle.ContextMenuHeading:
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderSecondary:
		case PaletteContentStyle.HeaderDockInactive:
		case PaletteContentStyle.HeaderDockActive:
		case PaletteContentStyle.HeaderCalendar:
		case PaletteContentStyle.HeaderCustom1:
		case PaletteContentStyle.HeaderCustom2:
		case PaletteContentStyle.LabelNormalPanel:
		case PaletteContentStyle.LabelBoldPanel:
		case PaletteContentStyle.LabelItalicPanel:
		case PaletteContentStyle.LabelTitlePanel:
		case PaletteContentStyle.LabelGroupBoxCaption:
			return _colorWhite255;
		case PaletteContentStyle.ButtonLowProfile:
		case PaletteContentStyle.ButtonButtonSpec:
		case PaletteContentStyle.ButtonInputControl:
		case PaletteContentStyle.ButtonForm:
		case PaletteContentStyle.ButtonFormClose:
			if (state == PaletteState.Normal || state == PaletteState.NormalDefaultOverride)
			{
				return _colorDark00;
			}
			return _colorWhite255;
		case PaletteContentStyle.GridDataCellList:
		case PaletteContentStyle.GridDataCellSheet:
		case PaletteContentStyle.GridDataCellCustom1:
			if (state == PaletteState.CheckedNormal)
			{
				return _colorWhite255;
			}
			return _colorDark00;
		case PaletteContentStyle.GridHeaderColumnSheet:
		case PaletteContentStyle.GridHeaderRowSheet:
			if (state != PaletteState.Pressed)
			{
				return _colorDark00;
			}
			return _colorWhite255;
		case PaletteContentStyle.GridHeaderColumnList:
		case PaletteContentStyle.GridHeaderRowList:
		case PaletteContentStyle.GridHeaderColumnCustom1:
		case PaletteContentStyle.GridHeaderRowCustom1:
			return _colorDark00;
		case PaletteContentStyle.InputControlStandalone:
		case PaletteContentStyle.InputControlRibbon:
		case PaletteContentStyle.InputControlCustom1:
			if (state == PaletteState.Disabled)
			{
				return _inputControlTextDisabled;
			}
			return _colorDark00;
		case PaletteContentStyle.TabHighProfile:
		case PaletteContentStyle.TabStandardProfile:
		case PaletteContentStyle.TabOneNote:
		case PaletteContentStyle.TabDock:
		case PaletteContentStyle.TabCustom1:
		case PaletteContentStyle.TabCustom2:
		case PaletteContentStyle.TabCustom3:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledText;
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _colorDark00;
			default:
				return _sparkleColors[4];
			}
		case PaletteContentStyle.TabDockAutoHidden:
			if (state == PaletteState.Disabled)
			{
				return _disabledText;
			}
			return _sparkleColors[4];
		case PaletteContentStyle.TabLowProfile:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledText;
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _colorDark00;
			default:
				return _colorWhite255;
			}
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override Color GetContentLongTextColor2(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return Color.Empty;
		}
		if (style == PaletteContentStyle.HeaderForm)
		{
			if (state == PaletteState.Disabled)
			{
				return PaletteBase.FadedColor(_colorWhite255);
			}
			return _colorWhite255;
		}
		if (state == PaletteState.Disabled && style != PaletteContentStyle.LabelToolTip && style != PaletteContentStyle.LabelSuperTip && style != PaletteContentStyle.LabelKeyTip && style != PaletteContentStyle.InputControlStandalone && style != PaletteContentStyle.InputControlRibbon && style != PaletteContentStyle.InputControlCustom1)
		{
			return _disabledText;
		}
		switch (style)
		{
		case PaletteContentStyle.ContextMenuItemImage:
		case PaletteContentStyle.ContextMenuItemTextStandard:
		case PaletteContentStyle.ContextMenuItemTextAlternate:
		case PaletteContentStyle.ContextMenuItemShortcutText:
		case PaletteContentStyle.LabelNormalControl:
		case PaletteContentStyle.LabelBoldControl:
		case PaletteContentStyle.LabelItalicControl:
		case PaletteContentStyle.LabelTitleControl:
		case PaletteContentStyle.LabelToolTip:
		case PaletteContentStyle.LabelSuperTip:
		case PaletteContentStyle.LabelKeyTip:
		case PaletteContentStyle.LabelCustom1:
		case PaletteContentStyle.LabelCustom2:
		case PaletteContentStyle.LabelCustom3:
			return _colorDark00;
		case PaletteContentStyle.ButtonListItem:
		case PaletteContentStyle.ButtonCommand:
			switch (state)
			{
			case PaletteState.Disabled:
			case PaletteState.Normal:
			case PaletteState.Tracking:
			case PaletteState.NormalDefaultOverride:
				return _colorDark00;
			case PaletteState.Pressed:
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _colorWhite255;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteContentStyle.ButtonCalendarDay:
			switch (state)
			{
			case PaletteState.Disabled:
				return _colorWhite128;
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.FocusOverride:
				return _colorWhite255;
			default:
				return _colorDark00;
			}
		case PaletteContentStyle.ButtonStandalone:
		case PaletteContentStyle.ButtonAlternate:
		case PaletteContentStyle.ButtonBreadCrumb:
		case PaletteContentStyle.ButtonCluster:
		case PaletteContentStyle.ButtonGallery:
		case PaletteContentStyle.ButtonNavigatorStack:
		case PaletteContentStyle.ButtonNavigatorOverflow:
		case PaletteContentStyle.ButtonNavigatorMini:
		case PaletteContentStyle.ButtonCustom1:
		case PaletteContentStyle.ButtonCustom2:
		case PaletteContentStyle.ButtonCustom3:
		case PaletteContentStyle.ContextMenuHeading:
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderSecondary:
		case PaletteContentStyle.HeaderDockInactive:
		case PaletteContentStyle.HeaderDockActive:
		case PaletteContentStyle.HeaderCalendar:
		case PaletteContentStyle.HeaderCustom1:
		case PaletteContentStyle.HeaderCustom2:
		case PaletteContentStyle.LabelNormalPanel:
		case PaletteContentStyle.LabelBoldPanel:
		case PaletteContentStyle.LabelItalicPanel:
		case PaletteContentStyle.LabelTitlePanel:
		case PaletteContentStyle.LabelGroupBoxCaption:
			return _colorWhite255;
		case PaletteContentStyle.ButtonLowProfile:
		case PaletteContentStyle.ButtonButtonSpec:
		case PaletteContentStyle.ButtonInputControl:
		case PaletteContentStyle.ButtonForm:
		case PaletteContentStyle.ButtonFormClose:
			if (state == PaletteState.Normal || state == PaletteState.NormalDefaultOverride)
			{
				return _colorDark00;
			}
			return _colorWhite255;
		case PaletteContentStyle.GridDataCellList:
		case PaletteContentStyle.GridDataCellSheet:
		case PaletteContentStyle.GridDataCellCustom1:
			if (state == PaletteState.CheckedNormal)
			{
				return _colorWhite255;
			}
			return _colorDark00;
		case PaletteContentStyle.GridHeaderColumnSheet:
		case PaletteContentStyle.GridHeaderRowSheet:
			if (state != PaletteState.Pressed)
			{
				return _colorDark00;
			}
			return _colorWhite255;
		case PaletteContentStyle.GridHeaderColumnList:
		case PaletteContentStyle.GridHeaderRowList:
		case PaletteContentStyle.GridHeaderColumnCustom1:
		case PaletteContentStyle.GridHeaderRowCustom1:
			return _colorDark00;
		case PaletteContentStyle.InputControlStandalone:
		case PaletteContentStyle.InputControlRibbon:
		case PaletteContentStyle.InputControlCustom1:
			if (state == PaletteState.Disabled)
			{
				return _inputControlTextDisabled;
			}
			return _colorDark00;
		case PaletteContentStyle.TabHighProfile:
		case PaletteContentStyle.TabStandardProfile:
		case PaletteContentStyle.TabOneNote:
		case PaletteContentStyle.TabDock:
		case PaletteContentStyle.TabCustom1:
		case PaletteContentStyle.TabCustom2:
		case PaletteContentStyle.TabCustom3:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledText;
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _colorDark00;
			default:
				return _sparkleColors[4];
			}
		case PaletteContentStyle.TabDockAutoHidden:
			if (state == PaletteState.Disabled)
			{
				return _disabledText;
			}
			return _sparkleColors[4];
		case PaletteContentStyle.TabLowProfile:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledText;
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _colorDark00;
			default:
				return _colorWhite255;
			}
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override PaletteColorStyle GetContentLongTextColorStyle(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteColorStyle.Inherit;
		}
		if ((uint)style <= 67u)
		{
			return PaletteColorStyle.Solid;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override PaletteRectangleAlign GetContentLongTextColorAlign(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteRectangleAlign.Inherit;
		}
		if ((uint)style <= 67u)
		{
			return PaletteRectangleAlign.Local;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override float GetContentLongTextColorAngle(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return -1f;
		}
		if ((uint)style <= 67u)
		{
			return 90f;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override Image GetContentLongTextImage(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return null;
		}
		if ((uint)style <= 67u)
		{
			return null;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override PaletteImageStyle GetContentLongTextImageStyle(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteImageStyle.Inherit;
		}
		if ((uint)style <= 67u)
		{
			return PaletteImageStyle.TileFlipXY;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override PaletteRectangleAlign GetContentLongTextImageAlign(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteRectangleAlign.Inherit;
		}
		if ((uint)style <= 67u)
		{
			return PaletteRectangleAlign.Local;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override Padding GetContentPadding(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return CommonHelper.InheritPadding;
		}
		switch (style)
		{
		case PaletteContentStyle.GridHeaderColumnList:
		case PaletteContentStyle.GridHeaderRowList:
		case PaletteContentStyle.GridDataCellList:
		case PaletteContentStyle.GridHeaderColumnSheet:
		case PaletteContentStyle.GridHeaderRowSheet:
		case PaletteContentStyle.GridDataCellSheet:
		case PaletteContentStyle.GridHeaderColumnCustom1:
		case PaletteContentStyle.GridHeaderRowCustom1:
		case PaletteContentStyle.GridDataCellCustom1:
			return _contentPaddingGrid;
		case PaletteContentStyle.HeaderForm:
			return _contentPaddingHeaderForm;
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderCustom1:
		case PaletteContentStyle.HeaderCustom2:
			return _contentPaddingHeader1;
		case PaletteContentStyle.HeaderSecondary:
			return _contentPaddingHeader2;
		case PaletteContentStyle.HeaderDockInactive:
		case PaletteContentStyle.HeaderDockActive:
			return _contentPaddingHeader3;
		case PaletteContentStyle.HeaderCalendar:
			return _contentPaddingCalendar;
		case PaletteContentStyle.LabelNormalControl:
		case PaletteContentStyle.LabelBoldControl:
		case PaletteContentStyle.LabelItalicControl:
		case PaletteContentStyle.LabelTitleControl:
		case PaletteContentStyle.LabelNormalPanel:
		case PaletteContentStyle.LabelBoldPanel:
		case PaletteContentStyle.LabelItalicPanel:
		case PaletteContentStyle.LabelTitlePanel:
		case PaletteContentStyle.LabelCustom1:
		case PaletteContentStyle.LabelCustom2:
		case PaletteContentStyle.LabelCustom3:
			return _contentPaddingLabel;
		case PaletteContentStyle.LabelGroupBoxCaption:
			return _contentPaddingLabel2;
		case PaletteContentStyle.ContextMenuItemTextStandard:
			return _contentPaddingContextMenuItemText;
		case PaletteContentStyle.ContextMenuItemTextAlternate:
			return _contentPaddingContextMenuItemTextAlt;
		case PaletteContentStyle.ContextMenuItemShortcutText:
			return _contentPaddingContextMenuItemShortcutText;
		case PaletteContentStyle.ContextMenuItemImage:
			return _contentPaddingContextMenuImage;
		case PaletteContentStyle.LabelToolTip:
			return _contentPaddingToolTip;
		case PaletteContentStyle.LabelSuperTip:
			return _contentPaddingSuperTip;
		case PaletteContentStyle.LabelKeyTip:
			return _contentPaddingKeyTip;
		case PaletteContentStyle.ContextMenuHeading:
			return _contentPaddingContextMenuHeading;
		case PaletteContentStyle.InputControlStandalone:
		case PaletteContentStyle.InputControlRibbon:
		case PaletteContentStyle.InputControlCustom1:
			return InputControlPadding;
		case PaletteContentStyle.ButtonStandalone:
		case PaletteContentStyle.ButtonAlternate:
		case PaletteContentStyle.ButtonLowProfile:
		case PaletteContentStyle.ButtonCluster:
		case PaletteContentStyle.ButtonNavigatorMini:
		case PaletteContentStyle.ButtonCommand:
		case PaletteContentStyle.ButtonCustom1:
		case PaletteContentStyle.ButtonCustom2:
		case PaletteContentStyle.ButtonCustom3:
			return _contentPaddingButton12;
		case PaletteContentStyle.ButtonCalendarDay:
		case PaletteContentStyle.ButtonInputControl:
			return _contentPaddingButtonInputControl;
		case PaletteContentStyle.ButtonButtonSpec:
			return _contentPaddingButton3;
		case PaletteContentStyle.ButtonNavigatorStack:
		case PaletteContentStyle.ButtonNavigatorOverflow:
			return _contentPaddingButton4;
		case PaletteContentStyle.ButtonBreadCrumb:
			return _contentPaddingButton6;
		case PaletteContentStyle.ButtonForm:
		case PaletteContentStyle.ButtonFormClose:
			return _contentPaddingButtonForm;
		case PaletteContentStyle.ButtonGallery:
			return _contentPaddingButtonGallery;
		case PaletteContentStyle.ButtonListItem:
			return _contentPaddingButtonListItem;
		case PaletteContentStyle.TabHighProfile:
		case PaletteContentStyle.TabStandardProfile:
		case PaletteContentStyle.TabLowProfile:
		case PaletteContentStyle.TabOneNote:
		case PaletteContentStyle.TabCustom1:
		case PaletteContentStyle.TabCustom2:
		case PaletteContentStyle.TabCustom3:
			return _contentPaddingButton5;
		case PaletteContentStyle.TabDock:
		case PaletteContentStyle.TabDockAutoHidden:
			return _contentPaddingButton7;
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override int GetContentAdjacentGap(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return -1;
		}
		switch (style)
		{
		case PaletteContentStyle.ButtonStandalone:
		case PaletteContentStyle.ButtonAlternate:
		case PaletteContentStyle.ButtonLowProfile:
		case PaletteContentStyle.ButtonButtonSpec:
		case PaletteContentStyle.ButtonBreadCrumb:
		case PaletteContentStyle.ButtonCalendarDay:
		case PaletteContentStyle.ButtonCluster:
		case PaletteContentStyle.ButtonGallery:
		case PaletteContentStyle.ButtonNavigatorStack:
		case PaletteContentStyle.ButtonNavigatorOverflow:
		case PaletteContentStyle.ButtonNavigatorMini:
		case PaletteContentStyle.ButtonInputControl:
		case PaletteContentStyle.ButtonListItem:
		case PaletteContentStyle.ButtonForm:
		case PaletteContentStyle.ButtonFormClose:
		case PaletteContentStyle.ButtonCommand:
		case PaletteContentStyle.ButtonCustom1:
		case PaletteContentStyle.ButtonCustom2:
		case PaletteContentStyle.ButtonCustom3:
		case PaletteContentStyle.ContextMenuHeading:
		case PaletteContentStyle.ContextMenuItemImage:
		case PaletteContentStyle.ContextMenuItemTextStandard:
		case PaletteContentStyle.ContextMenuItemTextAlternate:
		case PaletteContentStyle.ContextMenuItemShortcutText:
		case PaletteContentStyle.GridHeaderColumnList:
		case PaletteContentStyle.GridHeaderRowList:
		case PaletteContentStyle.GridDataCellList:
		case PaletteContentStyle.GridHeaderColumnSheet:
		case PaletteContentStyle.GridHeaderRowSheet:
		case PaletteContentStyle.GridDataCellSheet:
		case PaletteContentStyle.GridHeaderColumnCustom1:
		case PaletteContentStyle.GridHeaderRowCustom1:
		case PaletteContentStyle.GridDataCellCustom1:
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderSecondary:
		case PaletteContentStyle.HeaderDockInactive:
		case PaletteContentStyle.HeaderDockActive:
		case PaletteContentStyle.HeaderForm:
		case PaletteContentStyle.HeaderCalendar:
		case PaletteContentStyle.HeaderCustom1:
		case PaletteContentStyle.HeaderCustom2:
		case PaletteContentStyle.LabelNormalControl:
		case PaletteContentStyle.LabelBoldControl:
		case PaletteContentStyle.LabelItalicControl:
		case PaletteContentStyle.LabelTitleControl:
		case PaletteContentStyle.LabelNormalPanel:
		case PaletteContentStyle.LabelBoldPanel:
		case PaletteContentStyle.LabelItalicPanel:
		case PaletteContentStyle.LabelTitlePanel:
		case PaletteContentStyle.LabelGroupBoxCaption:
		case PaletteContentStyle.LabelToolTip:
		case PaletteContentStyle.LabelKeyTip:
		case PaletteContentStyle.LabelCustom1:
		case PaletteContentStyle.LabelCustom2:
		case PaletteContentStyle.LabelCustom3:
		case PaletteContentStyle.TabHighProfile:
		case PaletteContentStyle.TabStandardProfile:
		case PaletteContentStyle.TabLowProfile:
		case PaletteContentStyle.TabOneNote:
		case PaletteContentStyle.TabDock:
		case PaletteContentStyle.TabDockAutoHidden:
		case PaletteContentStyle.TabCustom1:
		case PaletteContentStyle.TabCustom2:
		case PaletteContentStyle.TabCustom3:
		case PaletteContentStyle.InputControlStandalone:
		case PaletteContentStyle.InputControlRibbon:
		case PaletteContentStyle.InputControlCustom1:
			return 1;
		case PaletteContentStyle.LabelSuperTip:
			return 5;
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override int GetMetricInt(PaletteState state, PaletteMetricInt metric)
	{
		switch (metric)
		{
		case PaletteMetricInt.HeaderButtonEdgeInsetCalendar:
		case PaletteMetricInt.PageButtonInset:
		case PaletteMetricInt.RibbonTabGap:
			return 2;
		case PaletteMetricInt.CheckButtonGap:
			return 5;
		case PaletteMetricInt.HeaderButtonEdgeInsetForm:
			return 4;
		case PaletteMetricInt.HeaderButtonEdgeInsetInputControl:
			return 1;
		case PaletteMetricInt.HeaderButtonEdgeInsetPrimary:
		case PaletteMetricInt.HeaderButtonEdgeInsetSecondary:
		case PaletteMetricInt.HeaderButtonEdgeInsetDockInactive:
		case PaletteMetricInt.HeaderButtonEdgeInsetDockActive:
		case PaletteMetricInt.HeaderButtonEdgeInsetCustom1:
		case PaletteMetricInt.HeaderButtonEdgeInsetCustom2:
		case PaletteMetricInt.BarButtonEdgeOutside:
		case PaletteMetricInt.BarButtonEdgeInside:
			return 3;
		case PaletteMetricInt.None:
			return 0;
		default:
			Debug.Assert(condition: false);
			return -1;
		}
	}

	public override InheritBool GetMetricBool(PaletteState state, PaletteMetricBool metric)
	{
		if ((uint)(metric - 1) <= 3u)
		{
			return InheritBool.False;
		}
		Debug.Assert(condition: false);
		return InheritBool.Inherit;
	}

	public override Padding GetMetricPadding(PaletteState state, PaletteMetricPadding metric)
	{
		switch (metric)
		{
		case PaletteMetricPadding.PageButtonPadding:
			return _metricPaddingPageButtons;
		case PaletteMetricPadding.BarPaddingTabs:
			return _metricPaddingBarTabs;
		case PaletteMetricPadding.BarPaddingInside:
		case PaletteMetricPadding.BarPaddingOnly:
			return _metricPaddingBarInside;
		case PaletteMetricPadding.BarPaddingOutside:
			return _metricPaddingBarOutside;
		case PaletteMetricPadding.HeaderButtonPaddingForm:
			return _metricPaddingHeaderForm;
		case PaletteMetricPadding.RibbonButtonPadding:
			return _metricPaddingRibbon;
		case PaletteMetricPadding.RibbonAppButton:
			return _metricPaddingRibbonAppButton;
		case PaletteMetricPadding.HeaderButtonPaddingInputControl:
			return _metricPaddingInputControl;
		case PaletteMetricPadding.HeaderButtonPaddingPrimary:
		case PaletteMetricPadding.HeaderButtonPaddingSecondary:
		case PaletteMetricPadding.HeaderButtonPaddingDockInactive:
		case PaletteMetricPadding.HeaderButtonPaddingDockActive:
		case PaletteMetricPadding.HeaderButtonPaddingCalendar:
		case PaletteMetricPadding.HeaderButtonPaddingCustom1:
		case PaletteMetricPadding.HeaderButtonPaddingCustom2:
		case PaletteMetricPadding.BarButtonPadding:
			return _metricPaddingHeader;
		case PaletteMetricPadding.ContextMenuItemOuter:
			return _metricPaddingMenuOuter;
		case PaletteMetricPadding.HeaderGroupPaddingPrimary:
		case PaletteMetricPadding.HeaderGroupPaddingSecondary:
		case PaletteMetricPadding.HeaderGroupPaddingDockInactive:
		case PaletteMetricPadding.HeaderGroupPaddingDockActive:
		case PaletteMetricPadding.SeparatorPaddingLowProfile:
		case PaletteMetricPadding.SeparatorPaddingHighProfile:
		case PaletteMetricPadding.SeparatorPaddingHighInternalProfile:
		case PaletteMetricPadding.SeparatorPaddingCustom1:
		case PaletteMetricPadding.ContextMenuItemsCollection:
			return Padding.Empty;
		case PaletteMetricPadding.ContextMenuItemHighlight:
			return _metricPaddingContextMenuItemHighlight;
		default:
			Debug.Assert(condition: false);
			return Padding.Empty;
		}
	}

	public override Image GetTreeViewImage(bool expanded)
	{
		if (expanded)
		{
			return _treeCollapseBlack;
		}
		return _treeExpandWhite;
	}

	public override Image GetCheckBoxImage(bool enabled, CheckState checkState, bool tracking, bool pressed)
	{
		switch (checkState)
		{
		default:
			if (!enabled)
			{
				return _checkBoxList.Images[0];
			}
			if (pressed)
			{
				return _checkBoxList.Images[3];
			}
			if (tracking)
			{
				return _checkBoxList.Images[2];
			}
			return _checkBoxList.Images[1];
		case CheckState.Checked:
			if (!enabled)
			{
				return _checkBoxList.Images[4];
			}
			if (pressed)
			{
				return _checkBoxList.Images[7];
			}
			if (tracking)
			{
				return _checkBoxList.Images[6];
			}
			return _checkBoxList.Images[5];
		case CheckState.Indeterminate:
			if (!enabled)
			{
				return _checkBoxList.Images[8];
			}
			if (pressed)
			{
				return _checkBoxList.Images[11];
			}
			if (tracking)
			{
				return _checkBoxList.Images[10];
			}
			return _checkBoxList.Images[9];
		}
	}

	public override Image GetRadioButtonImage(bool enabled, bool checkState, bool tracking, bool pressed)
	{
		if (!checkState)
		{
			if (!enabled)
			{
				return _radioButtonArray[0];
			}
			if (pressed)
			{
				return _radioButtonArray[3];
			}
			if (tracking)
			{
				return _radioButtonArray[2];
			}
			return _radioButtonArray[1];
		}
		if (!enabled)
		{
			return _radioButtonArray[4];
		}
		if (pressed)
		{
			return _radioButtonArray[7];
		}
		if (tracking)
		{
			return _radioButtonArray[6];
		}
		return _radioButtonArray[5];
	}

	public override Image GetDropDownButtonImage(PaletteState state)
	{
		if (state == PaletteState.Disabled)
		{
			return _disabledDropDown;
		}
		return _sparkleDropDownOutlineButton;
	}

	public override Image GetContextMenuCheckedImage()
	{
		return _contextMenuChecked;
	}

	public override Image GetContextMenuIndeterminateImage()
	{
		return _contextMenuIndeterminate;
	}

	public override Image GetContextMenuSubMenuImage()
	{
		return _contextMenuSubMenu;
	}

	public override Image GetGalleryButtonImage(PaletteRibbonGalleryButton button, PaletteState state)
	{
		switch (button)
		{
		default:
			if (state == PaletteState.Disabled)
			{
				return _disabledDropDown;
			}
			return _sparkleDropDownButton;
		case PaletteRibbonGalleryButton.Up:
			if (state == PaletteState.Disabled)
			{
				return _disabledDropUp;
			}
			return _sparkleDropUpButton;
		case PaletteRibbonGalleryButton.DropDown:
			if (state == PaletteState.Disabled)
			{
				return _disabledGalleryDrop;
			}
			return _sparkleGalleryDropButton;
		}
	}

	public override Icon GetButtonSpecIcon(PaletteButtonSpecStyle style)
	{
		if ((uint)style <= 22u)
		{
			return null;
		}
		Debug.Assert(condition: false);
		return null;
	}

	public override Image GetButtonSpecImage(PaletteButtonSpecStyle style, PaletteState state)
	{
		switch (style)
		{
		case PaletteButtonSpecStyle.FormClose:
			if (state == PaletteState.Disabled)
			{
				return _sparkleCloseI;
			}
			return _sparkleCloseA;
		case PaletteButtonSpecStyle.FormMin:
			if (state == PaletteState.Disabled)
			{
				return _sparkleMinI;
			}
			return _sparkleMinA;
		case PaletteButtonSpecStyle.FormMax:
			if (state == PaletteState.Disabled)
			{
				return _sparkleMaxI;
			}
			return _sparkleMaxA;
		case PaletteButtonSpecStyle.FormRestore:
			if (state == PaletteState.Disabled)
			{
				return _sparkleRestoreI;
			}
			return _sparkleRestoreA;
		case PaletteButtonSpecStyle.Close:
			return _buttonSpecClose;
		case PaletteButtonSpecStyle.Context:
			return _buttonSpecContext;
		case PaletteButtonSpecStyle.Next:
			return _buttonSpecNext;
		case PaletteButtonSpecStyle.Previous:
			return _buttonSpecPrevious;
		case PaletteButtonSpecStyle.ArrowLeft:
			return _buttonSpecArrowLeft;
		case PaletteButtonSpecStyle.ArrowRight:
			return _buttonSpecArrowRight;
		case PaletteButtonSpecStyle.ArrowUp:
			return _buttonSpecArrowUp;
		case PaletteButtonSpecStyle.ArrowDown:
			return _buttonSpecArrowDown;
		case PaletteButtonSpecStyle.DropDown:
			return _buttonSpecDropDown;
		case PaletteButtonSpecStyle.PinVertical:
			return _buttonSpecPinVertical;
		case PaletteButtonSpecStyle.PinHorizontal:
			return _buttonSpecPinHorizontal;
		case PaletteButtonSpecStyle.PendantClose:
			return _buttonSpecPendantClose;
		case PaletteButtonSpecStyle.PendantMin:
			return _buttonSpecPendantMin;
		case PaletteButtonSpecStyle.PendantRestore:
			return _buttonSpecPendantRestore;
		case PaletteButtonSpecStyle.WorkspaceMaximize:
			return _buttonSpecWorkspaceMaximize;
		case PaletteButtonSpecStyle.WorkspaceRestore:
			return _buttonSpecWorkspaceRestore;
		case PaletteButtonSpecStyle.RibbonMinimize:
			return _buttonSpecRibbonMinimize;
		case PaletteButtonSpecStyle.RibbonExpand:
			return _buttonSpecRibbonExpand;
		case PaletteButtonSpecStyle.Generic:
			return null;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	public override Color GetButtonSpecImageTransparentColor(PaletteButtonSpecStyle style)
	{
		switch (style)
		{
		case PaletteButtonSpecStyle.Generic:
			return Color.Empty;
		case PaletteButtonSpecStyle.Close:
		case PaletteButtonSpecStyle.Context:
		case PaletteButtonSpecStyle.Next:
		case PaletteButtonSpecStyle.Previous:
		case PaletteButtonSpecStyle.ArrowLeft:
		case PaletteButtonSpecStyle.ArrowRight:
		case PaletteButtonSpecStyle.ArrowUp:
		case PaletteButtonSpecStyle.ArrowDown:
		case PaletteButtonSpecStyle.DropDown:
		case PaletteButtonSpecStyle.PinVertical:
		case PaletteButtonSpecStyle.PinHorizontal:
		case PaletteButtonSpecStyle.FormClose:
		case PaletteButtonSpecStyle.FormMin:
		case PaletteButtonSpecStyle.FormMax:
		case PaletteButtonSpecStyle.FormRestore:
		case PaletteButtonSpecStyle.PendantClose:
		case PaletteButtonSpecStyle.PendantMin:
		case PaletteButtonSpecStyle.PendantRestore:
		case PaletteButtonSpecStyle.WorkspaceMaximize:
		case PaletteButtonSpecStyle.WorkspaceRestore:
		case PaletteButtonSpecStyle.RibbonMinimize:
		case PaletteButtonSpecStyle.RibbonExpand:
			return Color.Magenta;
		default:
			Debug.Assert(condition: false);
			return Color.Empty;
		}
	}

	public override string GetButtonSpecShortText(PaletteButtonSpecStyle style)
	{
		if ((uint)style <= 22u)
		{
			return string.Empty;
		}
		Debug.Assert(condition: false);
		return null;
	}

	public override string GetButtonSpecLongText(PaletteButtonSpecStyle style)
	{
		if ((uint)style <= 22u)
		{
			return string.Empty;
		}
		Debug.Assert(condition: false);
		return null;
	}

	public override Color GetButtonSpecColorMap(PaletteButtonSpecStyle style)
	{
		switch (style)
		{
		case PaletteButtonSpecStyle.Generic:
		case PaletteButtonSpecStyle.FormClose:
		case PaletteButtonSpecStyle.FormMin:
		case PaletteButtonSpecStyle.FormMax:
		case PaletteButtonSpecStyle.FormRestore:
		case PaletteButtonSpecStyle.PendantClose:
		case PaletteButtonSpecStyle.PendantMin:
		case PaletteButtonSpecStyle.PendantRestore:
			return Color.Empty;
		case PaletteButtonSpecStyle.Close:
		case PaletteButtonSpecStyle.Context:
		case PaletteButtonSpecStyle.Next:
		case PaletteButtonSpecStyle.Previous:
		case PaletteButtonSpecStyle.ArrowLeft:
		case PaletteButtonSpecStyle.ArrowRight:
		case PaletteButtonSpecStyle.ArrowUp:
		case PaletteButtonSpecStyle.ArrowDown:
		case PaletteButtonSpecStyle.DropDown:
		case PaletteButtonSpecStyle.PinVertical:
		case PaletteButtonSpecStyle.PinHorizontal:
		case PaletteButtonSpecStyle.WorkspaceMaximize:
		case PaletteButtonSpecStyle.WorkspaceRestore:
		case PaletteButtonSpecStyle.RibbonMinimize:
		case PaletteButtonSpecStyle.RibbonExpand:
			return Color.White;
		default:
			Debug.Assert(condition: false);
			return Color.Empty;
		}
	}

	public override Color GetButtonSpecColorTransparent(PaletteButtonSpecStyle style)
	{
		switch (style)
		{
		case PaletteButtonSpecStyle.Generic:
			return Color.Empty;
		case PaletteButtonSpecStyle.Close:
		case PaletteButtonSpecStyle.Context:
		case PaletteButtonSpecStyle.Next:
		case PaletteButtonSpecStyle.Previous:
		case PaletteButtonSpecStyle.ArrowLeft:
		case PaletteButtonSpecStyle.ArrowRight:
		case PaletteButtonSpecStyle.ArrowUp:
		case PaletteButtonSpecStyle.DropDown:
		case PaletteButtonSpecStyle.PinVertical:
		case PaletteButtonSpecStyle.PinHorizontal:
		case PaletteButtonSpecStyle.FormClose:
		case PaletteButtonSpecStyle.FormMin:
		case PaletteButtonSpecStyle.FormMax:
		case PaletteButtonSpecStyle.FormRestore:
		case PaletteButtonSpecStyle.PendantClose:
		case PaletteButtonSpecStyle.PendantMin:
		case PaletteButtonSpecStyle.PendantRestore:
		case PaletteButtonSpecStyle.WorkspaceMaximize:
		case PaletteButtonSpecStyle.WorkspaceRestore:
		case PaletteButtonSpecStyle.RibbonMinimize:
		case PaletteButtonSpecStyle.RibbonExpand:
			return Color.Magenta;
		default:
			Debug.Assert(condition: false);
			return Color.Empty;
		}
	}

	public override PaletteButtonStyle GetButtonSpecStyle(PaletteButtonSpecStyle style)
	{
		switch (style)
		{
		case PaletteButtonSpecStyle.FormMin:
		case PaletteButtonSpecStyle.FormMax:
		case PaletteButtonSpecStyle.FormRestore:
			return PaletteButtonStyle.Form;
		case PaletteButtonSpecStyle.FormClose:
			return PaletteButtonStyle.FormClose;
		case PaletteButtonSpecStyle.Generic:
		case PaletteButtonSpecStyle.Close:
		case PaletteButtonSpecStyle.Context:
		case PaletteButtonSpecStyle.Next:
		case PaletteButtonSpecStyle.Previous:
		case PaletteButtonSpecStyle.ArrowLeft:
		case PaletteButtonSpecStyle.ArrowRight:
		case PaletteButtonSpecStyle.ArrowUp:
		case PaletteButtonSpecStyle.ArrowDown:
		case PaletteButtonSpecStyle.DropDown:
		case PaletteButtonSpecStyle.PinVertical:
		case PaletteButtonSpecStyle.PinHorizontal:
		case PaletteButtonSpecStyle.PendantClose:
		case PaletteButtonSpecStyle.PendantMin:
		case PaletteButtonSpecStyle.PendantRestore:
		case PaletteButtonSpecStyle.WorkspaceMaximize:
		case PaletteButtonSpecStyle.WorkspaceRestore:
		case PaletteButtonSpecStyle.RibbonMinimize:
		case PaletteButtonSpecStyle.RibbonExpand:
			return PaletteButtonStyle.ButtonSpec;
		default:
			Debug.Assert(condition: false);
			return PaletteButtonStyle.ButtonSpec;
		}
	}

	public override HeaderLocation GetButtonSpecLocation(PaletteButtonSpecStyle style)
	{
		if ((uint)style <= 22u)
		{
			return HeaderLocation.PrimaryHeader;
		}
		Debug.Assert(condition: false);
		return HeaderLocation.PrimaryHeader;
	}

	public override PaletteRelativeEdgeAlign GetButtonSpecEdge(PaletteButtonSpecStyle style)
	{
		if ((uint)style <= 22u)
		{
			return PaletteRelativeEdgeAlign.Far;
		}
		Debug.Assert(condition: false);
		return PaletteRelativeEdgeAlign.Far;
	}

	public override PaletteButtonOrientation GetButtonSpecOrientation(PaletteButtonSpecStyle style)
	{
		switch (style)
		{
		case PaletteButtonSpecStyle.Close:
		case PaletteButtonSpecStyle.Context:
		case PaletteButtonSpecStyle.ArrowLeft:
		case PaletteButtonSpecStyle.ArrowRight:
		case PaletteButtonSpecStyle.ArrowUp:
		case PaletteButtonSpecStyle.ArrowDown:
		case PaletteButtonSpecStyle.DropDown:
		case PaletteButtonSpecStyle.PinVertical:
		case PaletteButtonSpecStyle.PinHorizontal:
		case PaletteButtonSpecStyle.FormClose:
		case PaletteButtonSpecStyle.FormMin:
		case PaletteButtonSpecStyle.FormMax:
		case PaletteButtonSpecStyle.FormRestore:
		case PaletteButtonSpecStyle.PendantClose:
		case PaletteButtonSpecStyle.PendantMin:
		case PaletteButtonSpecStyle.PendantRestore:
		case PaletteButtonSpecStyle.WorkspaceMaximize:
		case PaletteButtonSpecStyle.WorkspaceRestore:
		case PaletteButtonSpecStyle.RibbonMinimize:
		case PaletteButtonSpecStyle.RibbonExpand:
			return PaletteButtonOrientation.FixedTop;
		case PaletteButtonSpecStyle.Generic:
		case PaletteButtonSpecStyle.Next:
		case PaletteButtonSpecStyle.Previous:
			return PaletteButtonOrientation.Auto;
		default:
			Debug.Assert(condition: false);
			return PaletteButtonOrientation.Auto;
		}
	}

	public override PaletteRibbonShape GetRibbonShape()
	{
		return PaletteRibbonShape.Office2007;
	}

	public override PaletteRelativeAlign GetRibbonContextTextAlign(PaletteState state)
	{
		return PaletteRelativeAlign.Near;
	}

	public override Font GetRibbonContextTextFont(PaletteState state)
	{
		return _ribbonTabFont;
	}

	public override Color GetRibbonContextTextColor(PaletteState state)
	{
		return _ribbonColors[70];
	}

	public override Color GetRibbonDisabledDark(PaletteState state)
	{
		return _disabledGlyphDark;
	}

	public override Color GetRibbonDisabledLight(PaletteState state)
	{
		return _disabledGlyphLight;
	}

	public override Color GetRibbonDropArrowLight(PaletteState state)
	{
		return _ribbonColors[99];
	}

	public override Color GetRibbonDropArrowDark(PaletteState state)
	{
		return _ribbonColors[98];
	}

	public override Color GetRibbonGroupDialogDark(PaletteState state)
	{
		return _ribbonColors[98];
	}

	public override Color GetRibbonGroupDialogLight(PaletteState state)
	{
		return _ribbonColors[99];
	}

	public override Color GetRibbonGroupSeparatorDark(PaletteState state)
	{
		return _ribbonColors[153];
	}

	public override Color GetRibbonGroupSeparatorLight(PaletteState state)
	{
		return _ribbonColors[154];
	}

	public override Color GetRibbonMinimizeBarDark(PaletteState state)
	{
		return _ribbonColors[102];
	}

	public override Color GetRibbonMinimizeBarLight(PaletteState state)
	{
		return _ribbonColors[103];
	}

	public override Color GetRibbonTabSeparatorColor(PaletteState state)
	{
		return _ribbonColors[84];
	}

	public override Color GetRibbonTabSeparatorContextColor(PaletteState state)
	{
		return _sparkleColors[3];
	}

	public override Font GetRibbonTextFont(PaletteState state)
	{
		return _ribbonTabFont;
	}

	public override PaletteTextHint GetRibbonTextHint(PaletteState state)
	{
		return PaletteTextHint.ClearTypeGridFit;
	}

	public override Color GetRibbonQATButtonDark(PaletteState state)
	{
		return _ribbonColors[149];
	}

	public override Color GetRibbonQATButtonLight(PaletteState state)
	{
		return _ribbonColors[150];
	}

	public override PaletteRibbonColorStyle GetRibbonBackColorStyle(PaletteRibbonBackStyle style, PaletteState state)
	{
		switch (style)
		{
		case PaletteRibbonBackStyle.RibbonAppMenuDocs:
			return PaletteRibbonColorStyle.Solid;
		case PaletteRibbonBackStyle.RibbonAppMenuInner:
			return PaletteRibbonColorStyle.RibbonAppMenuInner;
		case PaletteRibbonBackStyle.RibbonAppMenuOuter:
			return PaletteRibbonColorStyle.RibbonAppMenuOuter;
		case PaletteRibbonBackStyle.RibbonQATMinibar:
			if (state == PaletteState.CheckedNormal)
			{
				return PaletteRibbonColorStyle.RibbonQATMinibarDouble;
			}
			return PaletteRibbonColorStyle.RibbonQATMinibarSingle;
		case PaletteRibbonBackStyle.RibbonQATFullbar:
			return PaletteRibbonColorStyle.RibbonQATFullbarRound;
		case PaletteRibbonBackStyle.RibbonQATOverflow:
			return PaletteRibbonColorStyle.RibbonQATOverflow;
		case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBorder:
			return PaletteRibbonColorStyle.RibbonGroupCollapsedFrameBorder;
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBorder:
			return PaletteRibbonColorStyle.RibbonGroupCollapsedBorder;
		case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBack:
			if (state == PaletteState.ContextNormal || state == PaletteState.ContextTracking)
			{
				return PaletteRibbonColorStyle.RibbonGroupGradientOne;
			}
			return PaletteRibbonColorStyle.RibbonGroupCollapsedFrameBack;
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBack:
			switch (state)
			{
			case PaletteState.Normal:
			case PaletteState.Tracking:
				return PaletteRibbonColorStyle.RibbonGroupGradientTwo;
			case PaletteState.ContextNormal:
			case PaletteState.ContextTracking:
				return PaletteRibbonColorStyle.RibbonGroupGradientOne;
			}
			Debug.Assert(condition: false);
			break;
		case PaletteRibbonBackStyle.RibbonGroupNormalBorder:
			switch (state)
			{
			case PaletteState.Normal:
			case PaletteState.ContextNormal:
				return PaletteRibbonColorStyle.RibbonGroupNormalBorder;
			case PaletteState.Tracking:
			case PaletteState.ContextTracking:
				return PaletteRibbonColorStyle.RibbonGroupNormalBorderTracking;
			}
			Debug.Assert(condition: false);
			break;
		case PaletteRibbonBackStyle.RibbonGroupNormalTitle:
			return PaletteRibbonColorStyle.RibbonGroupNormalTitle;
		case PaletteRibbonBackStyle.RibbonGroupArea:
			if (state == PaletteState.Normal || state == PaletteState.CheckedNormal || state == PaletteState.ContextCheckedNormal)
			{
				return PaletteRibbonColorStyle.RibbonGroupAreaBorder2;
			}
			Debug.Assert(condition: false);
			break;
		case PaletteRibbonBackStyle.RibbonTab:
			switch (state)
			{
			case PaletteState.Disabled:
			case PaletteState.Normal:
				return PaletteRibbonColorStyle.Empty;
			case PaletteState.Tracking:
			case PaletteState.ContextTracking:
				return PaletteRibbonColorStyle.RibbonTabGlowing;
			case PaletteState.Pressed:
				return PaletteRibbonColorStyle.RibbonTabTracking2007;
			case PaletteState.CheckedNormal:
				return PaletteRibbonColorStyle.RibbonTabSelected2007;
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return PaletteRibbonColorStyle.RibbonTabSelected2007;
			case PaletteState.ContextCheckedNormal:
			case PaletteState.ContextCheckedTracking:
			case PaletteState.FocusOverride:
				return PaletteRibbonColorStyle.RibbonTabContextSelected;
			}
			Debug.Assert(condition: false);
			break;
		default:
			Debug.Assert(condition: false);
			break;
		}
		return PaletteRibbonColorStyle.Empty;
	}

	public override Color GetRibbonBackColor1(PaletteRibbonBackStyle style, PaletteState state)
	{
		switch (style)
		{
		case PaletteRibbonBackStyle.RibbonGalleryBack:
			return state switch
			{
				PaletteState.Disabled => _disabledBack, 
				PaletteState.Tracking => _colorWhite238, 
				_ => _colorWhite192, 
			};
		case PaletteRibbonBackStyle.RibbonGalleryBorder:
			return state switch
			{
				PaletteState.Disabled => _disabledBorder, 
				_ => _ribbonColors[202], 
			};
		case PaletteRibbonBackStyle.RibbonAppMenuDocs:
			return _ribbonColors[198];
		case PaletteRibbonBackStyle.RibbonAppMenuInner:
			return _ribbonColors[196];
		case PaletteRibbonBackStyle.RibbonAppMenuOuter:
			return _ribbonColors[193];
		case PaletteRibbonBackStyle.RibbonQATMinibar:
			if (state == PaletteState.Normal)
			{
				return _ribbonColors[136];
			}
			return _ribbonColors[141];
		case PaletteRibbonBackStyle.RibbonQATFullbar:
			return _ribbonColors[146];
		case PaletteRibbonBackStyle.RibbonQATOverflow:
			return _ribbonColors[151];
		case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBorder:
			if (state == PaletteState.Tracking || state == PaletteState.Pressed)
			{
				return _sparkleColors[30];
			}
			return _ribbonColors[120];
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBorder:
			switch (state)
			{
			case PaletteState.Normal:
				return _ribbonColors[104];
			case PaletteState.Tracking:
				return _ribbonColors[112];
			case PaletteState.ContextNormal:
				return _ribbonGroupCollapsedBorderContext[0];
			case PaletteState.Pressed:
			case PaletteState.ContextTracking:
				return _ribbonGroupCollapsedBorderContextTracking[0];
			}
			Debug.Assert(condition: false);
			break;
		case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBack:
			switch (state)
			{
			case PaletteState.ContextNormal:
			case PaletteState.ContextTracking:
				return _contextGroupFrameTop;
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				return _sparkleColors[32];
			default:
				return _ribbonColors[122];
			}
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBack:
			switch (state)
			{
			case PaletteState.Normal:
				return _ribbonColors[108];
			case PaletteState.Tracking:
				return _ribbonColors[116];
			case PaletteState.ContextNormal:
				return _ribbonGroupCollapsedBackContext[0];
			case PaletteState.ContextTracking:
				return _ribbonGroupCollapsedBackContextTracking[0];
			}
			Debug.Assert(condition: false);
			break;
		case PaletteRibbonBackStyle.RibbonGroupNormalTitle:
			switch (state)
			{
			case PaletteState.Normal:
				return _ribbonColors[92];
			case PaletteState.ContextNormal:
				return _ribbonColors[96];
			case PaletteState.Tracking:
			case PaletteState.ContextTracking:
				return _ribbonColors[100];
			}
			Debug.Assert(condition: false);
			break;
		case PaletteRibbonBackStyle.RibbonGroupNormalBorder:
			switch (state)
			{
			case PaletteState.Normal:
			case PaletteState.Tracking:
				return _ribbonColors[90];
			case PaletteState.ContextNormal:
			case PaletteState.ContextTracking:
				return _ribbonColors[94];
			}
			Debug.Assert(condition: false);
			break;
		case PaletteRibbonBackStyle.RibbonAppButton:
			switch (state)
			{
			case PaletteState.Normal:
				return _appButtonNormal[0];
			case PaletteState.Tracking:
				return _appButtonTrack[0];
			case PaletteState.Pressed:
				return _appButtonPressed[0];
			}
			Debug.Assert(condition: false);
			break;
		case PaletteRibbonBackStyle.RibbonGroupArea:
			return _ribbonColors[85];
		case PaletteRibbonBackStyle.RibbonTab:
			switch (state)
			{
			case PaletteState.Tracking:
			case PaletteState.Pressed:
			case PaletteState.ContextTracking:
				return _ribbonColors[77];
			case PaletteState.CheckedNormal:
				return _ribbonColors[72];
			case PaletteState.CheckedTracking:
				return _colorDark00;
			case PaletteState.CheckedPressed:
				return _ribbonColors[79];
			case PaletteState.ContextCheckedNormal:
			case PaletteState.ContextCheckedTracking:
			case PaletteState.FocusOverride:
				return _colorDark00;
			case PaletteState.Normal:
				return Color.Empty;
			}
			Debug.Assert(condition: false);
			break;
		default:
			Debug.Assert(condition: false);
			break;
		}
		return Color.Red;
	}

	public override Color GetRibbonBackColor2(PaletteRibbonBackStyle style, PaletteState state)
	{
		switch (style)
		{
		case PaletteRibbonBackStyle.RibbonAppMenuInner:
			return _ribbonColors[197];
		case PaletteRibbonBackStyle.RibbonAppMenuOuter:
			return _ribbonColors[194];
		case PaletteRibbonBackStyle.RibbonQATMinibar:
			if (state == PaletteState.Normal)
			{
				return _ribbonColors[137];
			}
			return _ribbonColors[142];
		case PaletteRibbonBackStyle.RibbonQATFullbar:
			return _ribbonColors[147];
		case PaletteRibbonBackStyle.RibbonQATOverflow:
			return _ribbonColors[152];
		case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBorder:
			if (state == PaletteState.Tracking || state == PaletteState.Pressed)
			{
				return _sparkleColors[31];
			}
			return _ribbonColors[121];
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBorder:
			switch (state)
			{
			case PaletteState.Normal:
				return _ribbonColors[105];
			case PaletteState.Tracking:
				return _ribbonColors[113];
			case PaletteState.ContextNormal:
				return _ribbonGroupCollapsedBorderContext[1];
			case PaletteState.Pressed:
			case PaletteState.ContextTracking:
				return _ribbonGroupCollapsedBorderContextTracking[1];
			}
			Debug.Assert(condition: false);
			break;
		case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBack:
			switch (state)
			{
			case PaletteState.ContextNormal:
			case PaletteState.ContextTracking:
				return _contextGroupFrameBottom;
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				return _sparkleColors[33];
			default:
				return _ribbonColors[123];
			}
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBack:
			switch (state)
			{
			case PaletteState.Normal:
				return _ribbonColors[109];
			case PaletteState.Tracking:
				return _ribbonColors[117];
			case PaletteState.ContextNormal:
				return _ribbonGroupCollapsedBackContext[1];
			case PaletteState.ContextTracking:
				return _ribbonGroupCollapsedBackContextTracking[1];
			}
			Debug.Assert(condition: false);
			break;
		case PaletteRibbonBackStyle.RibbonGroupNormalTitle:
			switch (state)
			{
			case PaletteState.Normal:
				return _ribbonColors[93];
			case PaletteState.ContextNormal:
				return _ribbonColors[97];
			case PaletteState.Tracking:
			case PaletteState.ContextTracking:
				return _ribbonColors[101];
			}
			Debug.Assert(condition: false);
			break;
		case PaletteRibbonBackStyle.RibbonGroupNormalBorder:
			switch (state)
			{
			case PaletteState.Normal:
			case PaletteState.Tracking:
				return _ribbonColors[91];
			case PaletteState.ContextNormal:
			case PaletteState.ContextTracking:
				return _ribbonColors[95];
			}
			Debug.Assert(condition: false);
			break;
		case PaletteRibbonBackStyle.RibbonAppButton:
			switch (state)
			{
			case PaletteState.Normal:
				return _appButtonNormal[1];
			case PaletteState.Tracking:
				return _appButtonTrack[1];
			case PaletteState.Pressed:
				return _appButtonPressed[1];
			}
			Debug.Assert(condition: false);
			break;
		case PaletteRibbonBackStyle.RibbonGroupArea:
			return _ribbonColors[86];
		case PaletteRibbonBackStyle.RibbonTab:
			switch (state)
			{
			case PaletteState.Tracking:
				return _sparkleColors[35];
			case PaletteState.Pressed:
				return _ribbonColors[78];
			case PaletteState.CheckedNormal:
				return _ribbonColors[73];
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _ribbonColors[80];
			case PaletteState.ContextCheckedTracking:
				return _sparkleColors[36];
			case PaletteState.FocusOverride:
				return _sparkleColors[37];
			case PaletteState.ContextTracking:
			case PaletteState.ContextCheckedNormal:
				return Color.Empty;
			case PaletteState.Normal:
				return Color.Empty;
			}
			Debug.Assert(condition: false);
			break;
		case PaletteRibbonBackStyle.RibbonAppMenuDocs:
		case PaletteRibbonBackStyle.RibbonGalleryBack:
		case PaletteRibbonBackStyle.RibbonGalleryBorder:
			return Color.Empty;
		default:
			Debug.Assert(condition: false);
			break;
		}
		return Color.Red;
	}

	public override Color GetRibbonBackColor3(PaletteRibbonBackStyle style, PaletteState state)
	{
		switch (style)
		{
		case PaletteRibbonBackStyle.RibbonAppMenuOuter:
			return _ribbonColors[195];
		case PaletteRibbonBackStyle.RibbonQATMinibar:
			if (state == PaletteState.Normal)
			{
				return _ribbonColors[138];
			}
			return _ribbonColors[143];
		case PaletteRibbonBackStyle.RibbonQATFullbar:
			return _ribbonColors[148];
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBorder:
			switch (state)
			{
			case PaletteState.Normal:
				return _ribbonColors[106];
			case PaletteState.Tracking:
				return _ribbonColors[114];
			case PaletteState.ContextNormal:
				return _ribbonGroupCollapsedBorderContext[2];
			case PaletteState.Pressed:
			case PaletteState.ContextTracking:
				return _ribbonGroupCollapsedBorderContextTracking[2];
			}
			Debug.Assert(condition: false);
			break;
		case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBack:
			switch (state)
			{
			case PaletteState.ContextNormal:
			case PaletteState.ContextTracking:
				return Color.Empty;
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				return _sparkleColors[34];
			default:
				return _ribbonColors[124];
			}
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBack:
			switch (state)
			{
			case PaletteState.Normal:
				return _ribbonColors[110];
			case PaletteState.Tracking:
				return _ribbonColors[118];
			case PaletteState.ContextNormal:
			case PaletteState.ContextTracking:
				return Color.Empty;
			}
			Debug.Assert(condition: false);
			break;
		case PaletteRibbonBackStyle.RibbonAppMenuInner:
		case PaletteRibbonBackStyle.RibbonAppMenuDocs:
		case PaletteRibbonBackStyle.RibbonGroupNormalBorder:
		case PaletteRibbonBackStyle.RibbonGroupNormalTitle:
		case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBorder:
		case PaletteRibbonBackStyle.RibbonQATOverflow:
		case PaletteRibbonBackStyle.RibbonGalleryBack:
		case PaletteRibbonBackStyle.RibbonGalleryBorder:
			return Color.Empty;
		case PaletteRibbonBackStyle.RibbonAppButton:
			switch (state)
			{
			case PaletteState.Normal:
				return _appButtonNormal[2];
			case PaletteState.Tracking:
				return _appButtonTrack[2];
			case PaletteState.Pressed:
				return _appButtonPressed[2];
			}
			Debug.Assert(condition: false);
			break;
		case PaletteRibbonBackStyle.RibbonGroupArea:
			return _ribbonColors[87];
		case PaletteRibbonBackStyle.RibbonTab:
			switch (state)
			{
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				return _ribbonColors[78];
			case PaletteState.CheckedNormal:
				return _ribbonColors[74];
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _ribbonColors[81];
			case PaletteState.Normal:
			case PaletteState.ContextTracking:
			case PaletteState.ContextCheckedNormal:
			case PaletteState.ContextCheckedTracking:
			case PaletteState.FocusOverride:
				return Color.Empty;
			}
			Debug.Assert(condition: false);
			break;
		default:
			Debug.Assert(condition: false);
			break;
		}
		return Color.Red;
	}

	public override Color GetRibbonBackColor4(PaletteRibbonBackStyle style, PaletteState state)
	{
		switch (style)
		{
		case PaletteRibbonBackStyle.RibbonQATMinibar:
			if (state == PaletteState.Normal)
			{
				return _ribbonColors[139];
			}
			return _ribbonColors[144];
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBorder:
			switch (state)
			{
			case PaletteState.Normal:
				return _ribbonColors[107];
			case PaletteState.Tracking:
				return _ribbonColors[115];
			case PaletteState.ContextNormal:
				return _ribbonGroupCollapsedBorderContext[3];
			case PaletteState.Pressed:
			case PaletteState.ContextTracking:
				return _ribbonGroupCollapsedBorderContextTracking[3];
			}
			Debug.Assert(condition: false);
			break;
		case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBack:
			switch (state)
			{
			case PaletteState.ContextNormal:
			case PaletteState.ContextTracking:
				return Color.Empty;
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				return _ribbonFrameBack4;
			default:
				return _ribbonColors[125];
			}
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBack:
			switch (state)
			{
			case PaletteState.Normal:
				return _ribbonColors[111];
			case PaletteState.Tracking:
				return _ribbonColors[119];
			case PaletteState.ContextNormal:
			case PaletteState.ContextTracking:
				return Color.Empty;
			}
			Debug.Assert(condition: false);
			break;
		case PaletteRibbonBackStyle.RibbonAppMenuInner:
		case PaletteRibbonBackStyle.RibbonAppMenuOuter:
		case PaletteRibbonBackStyle.RibbonAppMenuDocs:
		case PaletteRibbonBackStyle.RibbonGroupNormalBorder:
		case PaletteRibbonBackStyle.RibbonGroupNormalTitle:
		case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBorder:
		case PaletteRibbonBackStyle.RibbonQATFullbar:
		case PaletteRibbonBackStyle.RibbonQATOverflow:
		case PaletteRibbonBackStyle.RibbonGalleryBack:
		case PaletteRibbonBackStyle.RibbonGalleryBorder:
			return Color.Empty;
		case PaletteRibbonBackStyle.RibbonAppButton:
			switch (state)
			{
			case PaletteState.Normal:
				return _appButtonNormal[3];
			case PaletteState.Tracking:
				return _appButtonTrack[3];
			case PaletteState.Pressed:
				return _appButtonPressed[3];
			}
			Debug.Assert(condition: false);
			break;
		case PaletteRibbonBackStyle.RibbonGroupArea:
			return _ribbonColors[88];
		case PaletteRibbonBackStyle.RibbonTab:
			switch (state)
			{
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				return _ribbonColors[78];
			case PaletteState.CheckedNormal:
				return _ribbonColors[75];
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _ribbonColors[82];
			case PaletteState.Normal:
			case PaletteState.ContextTracking:
			case PaletteState.ContextCheckedNormal:
			case PaletteState.ContextCheckedTracking:
			case PaletteState.FocusOverride:
				return Color.Empty;
			}
			Debug.Assert(condition: false);
			break;
		default:
			Debug.Assert(condition: false);
			break;
		}
		return Color.Red;
	}

	public override Color GetRibbonBackColor5(PaletteRibbonBackStyle style, PaletteState state)
	{
		switch (style)
		{
		case PaletteRibbonBackStyle.RibbonAppMenuInner:
		case PaletteRibbonBackStyle.RibbonAppMenuOuter:
		case PaletteRibbonBackStyle.RibbonAppMenuDocs:
		case PaletteRibbonBackStyle.RibbonGroupNormalBorder:
		case PaletteRibbonBackStyle.RibbonGroupNormalTitle:
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBack:
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBorder:
		case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBack:
		case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBorder:
		case PaletteRibbonBackStyle.RibbonQATFullbar:
		case PaletteRibbonBackStyle.RibbonQATOverflow:
		case PaletteRibbonBackStyle.RibbonGalleryBack:
		case PaletteRibbonBackStyle.RibbonGalleryBorder:
			return Color.Empty;
		case PaletteRibbonBackStyle.RibbonQATMinibar:
			if (state == PaletteState.Normal)
			{
				return _ribbonColors[140];
			}
			return _ribbonColors[145];
		case PaletteRibbonBackStyle.RibbonAppButton:
			switch (state)
			{
			case PaletteState.Normal:
				return _appButtonNormal[4];
			case PaletteState.Tracking:
				return _appButtonTrack[4];
			case PaletteState.Pressed:
				return _appButtonPressed[4];
			}
			Debug.Assert(condition: false);
			break;
		case PaletteRibbonBackStyle.RibbonGroupArea:
			if (state == PaletteState.ContextCheckedNormal)
			{
				return Color.Empty;
			}
			return _ribbonColors[89];
		case PaletteRibbonBackStyle.RibbonTab:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledText;
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				return _ribbonColors[78];
			case PaletteState.CheckedNormal:
				return _ribbonColors[76];
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _ribbonColors[83];
			case PaletteState.Normal:
			case PaletteState.ContextTracking:
			case PaletteState.ContextCheckedNormal:
			case PaletteState.ContextCheckedTracking:
			case PaletteState.FocusOverride:
				return Color.Empty;
			}
			Debug.Assert(condition: false);
			break;
		default:
			Debug.Assert(condition: false);
			break;
		}
		return Color.Red;
	}

	public override Color GetRibbonTextColor(PaletteRibbonTextStyle style, PaletteState state)
	{
		switch (style)
		{
		case PaletteRibbonTextStyle.RibbonAppMenuDocsTitle:
		case PaletteRibbonTextStyle.RibbonAppMenuDocsEntry:
			return _ribbonColors[199];
		case PaletteRibbonTextStyle.RibbonTab:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledText;
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _colorWhite255;
			case PaletteState.ContextCheckedNormal:
			case PaletteState.ContextCheckedTracking:
			case PaletteState.FocusOverride:
				return _ribbonColors[71];
			default:
				return _ribbonColors[70];
			}
		case PaletteRibbonTextStyle.RibbonGroupNormalTitle:
		case PaletteRibbonTextStyle.RibbonGroupCollapsedText:
		case PaletteRibbonTextStyle.RibbonGroupButtonText:
		case PaletteRibbonTextStyle.RibbonGroupLabelText:
		case PaletteRibbonTextStyle.RibbonGroupCheckBoxText:
		case PaletteRibbonTextStyle.RibbonGroupRadioButtonText:
			if (state == PaletteState.Disabled)
			{
				return _disabledText;
			}
			return _ribbonColors[126];
		default:
			Debug.Assert(condition: false);
			return Color.Red;
		}
	}

	public override Color GetElementColor1(PaletteElement element, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return Color.Empty;
		}
		switch (element)
		{
		case PaletteElement.TrackBarTick:
			return _trackBarColors[0];
		case PaletteElement.TrackBarTrack:
			return _trackBarColors[1];
		case PaletteElement.TrackBarPosition:
			return _trackBarColors[4];
		default:
			Debug.Assert(condition: false);
			return Color.Red;
		}
	}

	public override Color GetElementColor2(PaletteElement element, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return Color.Empty;
		}
		switch (element)
		{
		case PaletteElement.TrackBarTick:
			return _trackBarColors[0];
		case PaletteElement.TrackBarTrack:
			return _trackBarColors[2];
		case PaletteElement.TrackBarPosition:
			switch (state)
			{
			case PaletteState.Disabled:
				return ControlPaint.Light(_colorDark00);
			case PaletteState.Normal:
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				return _colorDark00;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		default:
			Debug.Assert(condition: false);
			return Color.Red;
		}
	}

	public override Color GetElementColor3(PaletteElement element, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return Color.Empty;
		}
		switch (element)
		{
		case PaletteElement.TrackBarTick:
			return _trackBarColors[0];
		case PaletteElement.TrackBarTrack:
			return _trackBarColors[3];
		case PaletteElement.TrackBarPosition:
			switch (state)
			{
			case PaletteState.Disabled:
				return ControlPaint.LightLight(_sparkleColors[5]);
			case PaletteState.Normal:
			case PaletteState.FocusOverride:
				return ControlPaint.Light(_sparkleColors[5]);
			case PaletteState.Tracking:
				return ControlPaint.Light(_sparkleColors[6]);
			case PaletteState.Pressed:
				return ControlPaint.Light(_sparkleColors[8]);
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		default:
			Debug.Assert(condition: false);
			return Color.Red;
		}
	}

	public override Color GetElementColor4(PaletteElement element, PaletteState state)
	{
		switch (element)
		{
		case PaletteElement.TrackBarTick:
			if (CommonHelper.IsOverrideState(state))
			{
				return Color.Empty;
			}
			return _trackBarColors[0];
		case PaletteElement.TrackBarTrack:
			if (CommonHelper.IsOverrideState(state))
			{
				return Color.Empty;
			}
			return _trackBarColors[3];
		case PaletteElement.TrackBarPosition:
			if (CommonHelper.IsOverrideStateExclude(state, PaletteState.FocusOverride))
			{
				return Color.Empty;
			}
			switch (state)
			{
			case PaletteState.Disabled:
				return ControlPaint.LightLight(_sparkleColors[5]);
			case PaletteState.Normal:
				return _sparkleColors[5];
			case PaletteState.Tracking:
			case PaletteState.FocusOverride:
				return _sparkleColors[6];
			case PaletteState.Pressed:
				return _sparkleColors[8];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		default:
			Debug.Assert(condition: false);
			return Color.Red;
		}
	}

	public override Color GetElementColor5(PaletteElement element, PaletteState state)
	{
		switch (element)
		{
		case PaletteElement.TrackBarTick:
			if (CommonHelper.IsOverrideState(state))
			{
				return Color.Empty;
			}
			return _trackBarColors[0];
		case PaletteElement.TrackBarTrack:
			if (CommonHelper.IsOverrideState(state))
			{
				return Color.Empty;
			}
			return _trackBarColors[3];
		case PaletteElement.TrackBarPosition:
			if (CommonHelper.IsOverrideStateExclude(state, PaletteState.FocusOverride))
			{
				return Color.Empty;
			}
			switch (state)
			{
			case PaletteState.Disabled:
				return ControlPaint.LightLight(_sparkleColors[5]);
			case PaletteState.Normal:
				return _sparkleColors[22];
			case PaletteState.Tracking:
			case PaletteState.FocusOverride:
				return _sparkleColors[7];
			case PaletteState.Pressed:
				return _sparkleColors[9];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		default:
			Debug.Assert(condition: false);
			return Color.Red;
		}
	}

	protected override void DefineFonts()
	{
		if (_header1ShortFont != null)
		{
			_header1ShortFont.Dispose();
		}
		if (_header2ShortFont != null)
		{
			_header2ShortFont.Dispose();
		}
		if (_headerFormFont != null)
		{
			_headerFormFont.Dispose();
		}
		if (_header1LongFont != null)
		{
			_header1LongFont.Dispose();
		}
		if (_header2LongFont != null)
		{
			_header2LongFont.Dispose();
		}
		if (_buttonFont != null)
		{
			_buttonFont.Dispose();
		}
		if (_buttonFontNavigatorStack != null)
		{
			_buttonFontNavigatorStack.Dispose();
		}
		if (_buttonFontNavigatorMini != null)
		{
			_buttonFontNavigatorMini.Dispose();
		}
		if (_tabFontSelected != null)
		{
			_tabFontSelected.Dispose();
		}
		if (_tabFontNormal != null)
		{
			_tabFontNormal.Dispose();
		}
		if (_ribbonTabFont != null)
		{
			_ribbonTabFont.Dispose();
		}
		if (_gridFont != null)
		{
			_gridFont.Dispose();
		}
		if (_calendarFont != null)
		{
			_calendarFont.Dispose();
		}
		if (_calendarBoldFont != null)
		{
			_calendarBoldFont.Dispose();
		}
		if (_superToolFont != null)
		{
			_superToolFont.Dispose();
		}
		if (_boldFont != null)
		{
			_boldFont.Dispose();
		}
		if (_italicFont != null)
		{
			_italicFont.Dispose();
		}
		float baseFontSize = BaseFontSize;
		string baseFontName = BaseFontName;
		_header1ShortFont = new Font(baseFontName, baseFontSize + 4.5f, FontStyle.Bold);
		_header2ShortFont = new Font(baseFontName, baseFontSize, FontStyle.Regular);
		_headerFormFont = new Font(baseFontName, SystemFonts.CaptionFont.SizeInPoints, FontStyle.Regular);
		_header1LongFont = new Font(baseFontName, baseFontSize + 1.5f, FontStyle.Regular);
		_header2LongFont = new Font(baseFontName, baseFontSize, FontStyle.Regular);
		_buttonFont = new Font(baseFontName, baseFontSize, FontStyle.Regular);
		_buttonFontNavigatorStack = new Font(_buttonFont, FontStyle.Bold);
		_buttonFontNavigatorMini = new Font(baseFontName, baseFontSize + 3.5f, FontStyle.Bold);
		_tabFontNormal = new Font(baseFontName, baseFontSize, FontStyle.Regular);
		_tabFontSelected = new Font(_tabFontNormal, FontStyle.Bold);
		_ribbonTabFont = new Font(baseFontName, baseFontSize, FontStyle.Regular);
		_gridFont = new Font(baseFontName, baseFontSize, FontStyle.Regular);
		_superToolFont = new Font(baseFontName, baseFontSize, FontStyle.Bold);
		_calendarFont = new Font(baseFontName, baseFontSize, FontStyle.Regular);
		_calendarBoldFont = new Font(baseFontName, baseFontSize, FontStyle.Bold);
		_boldFont = new Font(baseFontName, baseFontSize, FontStyle.Bold);
		_italicFont = new Font(baseFontName, baseFontSize, FontStyle.Italic);
	}

	protected override void OnUserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
	{
		_table = null;
		DefineFonts();
		base.OnUserPreferenceChanged(sender, e);
	}
}
