#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit.Properties;
using Microsoft.Win32;

namespace ComponentFactory.Krypton.Toolkit;

public abstract class PaletteOffice2010Base : PaletteBase
{
	private static readonly Padding _contentPaddingGrid = new Padding(2, 1, 2, 1);

	private static readonly Padding _contentPaddingHeader1 = new Padding(2, 1, 2, 1);

	private static readonly Padding _contentPaddingHeader2 = new Padding(2, 1, 2, 1);

	private static readonly Padding _contentPaddingDock = new Padding(2, 2, 2, 1);

	private static readonly Padding _contentPaddingCalendar = new Padding(2);

	private static readonly Padding _contentPaddingHeaderForm = new Padding(5, 2, 3, 0);

	private static readonly Padding _contentPaddingLabel = new Padding(3, 1, 3, 1);

	private static readonly Padding _contentPaddingLabel2 = new Padding(8, 2, 8, 2);

	private static readonly Padding _contentPaddingButtonInputControl = new Padding(0);

	private static readonly Padding _contentPaddingButton12 = new Padding(1);

	private static readonly Padding _contentPaddingButton3 = new Padding(1, 0, 1, 0);

	private static readonly Padding _contentPaddingButton4 = new Padding(4, 3, 4, 3);

	private static readonly Padding _contentPaddingButton5 = new Padding(3, 3, 3, 2);

	private static readonly Padding _contentPaddingButton6 = new Padding(3);

	private static readonly Padding _contentPaddingButton7 = new Padding(1, 1, 0, 1);

	private static readonly Padding _contentPaddingButtonForm = new Padding(0);

	private static readonly Padding _contentPaddingButtonGallery = new Padding(1, 0, 1, 0);

	private static readonly Padding _contentPaddingButtonListItem = new Padding(0, -1, 0, -1);

	private static readonly Padding _contentPaddingToolTip = new Padding(2);

	private static readonly Padding _contentPaddingSuperTip = new Padding(4);

	private static readonly Padding _contentPaddingKeyTip = new Padding(0, -1, 0, -3);

	private static readonly Padding _contentPaddingContextMenuHeading = new Padding(8, 2, 8, 0);

	private static readonly Padding _contentPaddingContextMenuImage = new Padding(0);

	private static readonly Padding _contentPaddingContextMenuItemText = new Padding(9, 1, 7, 0);

	private static readonly Padding _contentPaddingContextMenuItemTextAlt = new Padding(7, 1, 6, 0);

	private static readonly Padding _contentPaddingContextMenuItemShortcutText = new Padding(3, 1, 4, 0);

	private static readonly Padding _metricPaddingRibbon = new Padding(0, 1, 1, 1);

	private static readonly Padding _metricPaddingRibbonAppButton = new Padding(3, 0, 3, 0);

	private static readonly Padding _metricPaddingHeader = new Padding(0, 3, 1, 3);

	private static readonly Padding _metricPaddingHeaderForm = new Padding(0);

	private static readonly Padding _metricPaddingInputControl = new Padding(0, 1, 0, 1);

	private static readonly Padding _metricPaddingBarInside = new Padding(3);

	private static readonly Padding _metricPaddingBarTabs = new Padding(0);

	private static readonly Padding _metricPaddingBarOutside = new Padding(0, 0, 0, 3);

	private static readonly Padding _metricPaddingPageButtons = new Padding(1, 3, 1, 3);

	private static readonly Image _disabledDropDown = Resources.DisabledDropDownButton;

	private static readonly Image _buttonSpecClose = Resources.ProfessionalCloseButton;

	private static readonly Image _buttonSpecContext = Resources.ProfessionalContextButton;

	private static readonly Image _buttonSpecNext = Resources.ProfessionalNextButton;

	private static readonly Image _buttonSpecPrevious = Resources.ProfessionalPreviousButton;

	private static readonly Image _buttonSpecArrowLeft = Resources.ProfessionalArrowLeftButton;

	private static readonly Image _buttonSpecArrowRight = Resources.ProfessionalArrowRightButton;

	private static readonly Image _buttonSpecArrowUp = Resources.ProfessionalArrowUpButton;

	private static readonly Image _buttonSpecArrowDown = Resources.ProfessionalArrowDownButton;

	private static readonly Image _buttonSpecDropDown = Resources.ProfessionalDropDownButton;

	private static readonly Image _buttonSpecPinVertical = Resources.ProfessionalPinVerticalButton;

	private static readonly Image _buttonSpecPinHorizontal = Resources.ProfessionalPinHorizontalButton;

	private static readonly Image _buttonSpecPendantClose = Resources._2010ButtonMDIClose;

	private static readonly Image _buttonSpecPendantMin = Resources._2010ButtonMDIMin;

	private static readonly Image _buttonSpecPendantRestore = Resources._2010ButtonMDIRestore;

	private static readonly Image _buttonSpecWorkspaceMaximize = Resources.ProfessionalMaximize;

	private static readonly Image _buttonSpecWorkspaceRestore = Resources.ProfessionalRestore;

	private static readonly Image _buttonSpecRibbonMinimize = Resources.RibbonUp2010;

	private static readonly Image _buttonSpecRibbonExpand = Resources.RibbonDown2010;

	private static readonly Image _contextMenuChecked = Resources.Office2007Checked;

	private static readonly Image _contextMenuIndeterminate = Resources.Office2007Indeterminate;

	private static readonly Image _treeExpandWhite = Resources.TreeExpandWhite;

	private static readonly Image _treeCollapseBlack = Resources.TreeCollapseBlack;

	private static readonly Color _gridTextColor = Color.Black;

	private static readonly Color _disabledText2 = Color.FromArgb(128, 128, 128);

	private static readonly Color _disabledText = Color.FromArgb(167, 167, 167);

	private static readonly Color _disabledBack = Color.FromArgb(235, 235, 235);

	private static readonly Color _disabledBorder = Color.FromArgb(212, 212, 212);

	private static readonly Color _disabledGlyphDark = Color.FromArgb(183, 183, 183);

	private static readonly Color _disabledGlyphLight = Color.FromArgb(237, 237, 237);

	private static readonly Color _contextCheckedTabBorder1 = Color.FromArgb(223, 119, 0);

	private static readonly Color _contextCheckedTabBorder2 = Color.FromArgb(230, 190, 129);

	private static readonly Color _contextCheckedTabBorder3 = Color.FromArgb(220, 202, 171);

	private static readonly Color _contextCheckedTabBorder4 = Color.FromArgb(255, 252, 247);

	private static readonly Color _contextTabSeparator = Color.White;

	private static readonly Color _contextTextColor = Color.White;

	private static readonly Color _todayBorder = Color.FromArgb(187, 85, 3);

	private static readonly Color _toolTipBack1 = Color.FromArgb(255, 255, 255);

	private static readonly Color _toolTipBack2 = Color.FromArgb(201, 217, 239);

	private static readonly Color _toolTipBorder = Color.FromArgb(118, 118, 118);

	private static readonly Color _toolTipText = Color.FromArgb(76, 76, 76);

	private static readonly Color _contextMenuBack = Color.White;

	private static readonly Color _contextMenuBorder = Color.FromArgb(134, 134, 134);

	private static readonly Color _contextMenuHeadingBorder = Color.FromArgb(197, 197, 197);

	private static readonly Color _contextMenuImageBackChecked = Color.FromArgb(252, 241, 194);

	private static readonly Color _contextMenuImageBorderChecked = Color.FromArgb(242, 149, 54);

	private static readonly Color _formCloseBorderTracking = Color.FromArgb(155, 61, 61);

	private static readonly Color _formCloseBorderPressed = Color.FromArgb(155, 61, 61);

	private static readonly Color _formCloseBorderCheckedNormal = Color.FromArgb(155, 61, 61);

	private static readonly Color _formCloseTracking1 = Color.FromArgb(255, 132, 130);

	private static readonly Color _formCloseTracking2 = Color.FromArgb(227, 97, 98);

	private static readonly Color _formClosePressed1 = Color.FromArgb(242, 119, 118);

	private static readonly Color _formClosePressed2 = Color.FromArgb(206, 85, 84);

	private static readonly Color _formCloseChecked1 = Color.FromArgb(255, 132, 130);

	private static readonly Color _formCloseChecked2 = Color.FromArgb(255, 132, 130);

	private static readonly Color _formCloseCheckedTracking1 = Color.FromArgb(255, 132, 130);

	private static readonly Color _formCloseCheckedTracking2 = Color.FromArgb(255, 132, 130);

	private static readonly Color[] _appButtonNormal = new Color[5]
	{
		Color.FromArgb(243, 245, 248),
		Color.FromArgb(214, 220, 231),
		Color.FromArgb(188, 198, 211),
		Color.FromArgb(254, 254, 255),
		Color.FromArgb(206, 213, 225)
	};

	private static readonly Color[] _appButtonTrack = new Color[5]
	{
		Color.FromArgb(255, 251, 230),
		Color.FromArgb(248, 230, 143),
		Color.FromArgb(238, 213, 126),
		Color.FromArgb(254, 247, 129),
		Color.FromArgb(240, 201, 41)
	};

	private static readonly Color[] _appButtonPressed = new Color[5]
	{
		Color.FromArgb(235, 227, 196),
		Color.FromArgb(228, 198, 149),
		Color.FromArgb(166, 97, 7),
		Color.FromArgb(242, 155, 57),
		Color.FromArgb(236, 136, 9)
	};

	private static readonly Color[] _buttonBorderColors = new Color[7]
	{
		Color.FromArgb(180, 180, 180),
		Color.FromArgb(237, 201, 88),
		Color.FromArgb(243, 213, 73),
		Color.FromArgb(194, 118, 43),
		Color.FromArgb(194, 158, 71),
		Color.FromArgb(194, 138, 48),
		Color.FromArgb(194, 164, 77)
	};

	private static readonly Color[] _buttonBackColors = new Color[10]
	{
		Color.FromArgb(250, 250, 250),
		Color.FromArgb(250, 250, 250),
		Color.FromArgb(248, 225, 135),
		Color.FromArgb(251, 248, 224),
		Color.FromArgb(255, 228, 138),
		Color.FromArgb(194, 118, 43),
		Color.FromArgb(255, 216, 108),
		Color.FromArgb(255, 244, 128),
		Color.FromArgb(255, 225, 104),
		Color.FromArgb(255, 249, 196)
	};

	private KryptonColorTable2010 _table;

	private Color[] _ribbonColors;

	private Color[] _trackBarColors;

	private ImageList _checkBoxList;

	private ImageList _galleryButtonList;

	private Image[] _radioButtonArray;

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

	private Font _ribbonTabContextFont;

	private Font _gridFont;

	private Font _calendarFont;

	private Font _calendarBoldFont;

	private Font _boldFont;

	private Font _italicFont;

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
				_table = new KryptonColorTable2010(_ribbonColors, InheritBool.True, this);
			}
			return _table;
		}
	}

	public PaletteOffice2010Base(Color[] schemeColors, ImageList checkBoxList, ImageList galleryButtonList, Image[] radioButtonArray, Color[] trackBarColors)
	{
		Debug.Assert(schemeColors != null);
		Debug.Assert(checkBoxList != null);
		Debug.Assert(galleryButtonList != null);
		Debug.Assert(radioButtonArray != null);
		_ribbonColors = schemeColors;
		_checkBoxList = checkBoxList;
		_galleryButtonList = galleryButtonList;
		_radioButtonArray = radioButtonArray;
		_trackBarColors = trackBarColors;
		DefineFonts();
	}

	public override InheritBool GetAllowFormChrome()
	{
		return InheritBool.True;
	}

	public override IRenderer GetRenderer()
	{
		return KryptonManager.RenderOffice2010;
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
		if ((uint)style <= 75u)
		{
			return PaletteGraphicsHint.None;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override Color GetBackColor1(PaletteBackStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideStateExclude(state, PaletteState.NormalDefaultOverride))
		{
			return Color.Empty;
		}
		switch (style)
		{
		case PaletteBackStyle.GridHeaderColumnList:
		case PaletteBackStyle.GridHeaderRowList:
		case PaletteBackStyle.GridHeaderColumnCustom1:
		case PaletteBackStyle.GridHeaderRowCustom1:
			return state switch
			{
				PaletteState.Disabled => _disabledBack, 
				PaletteState.Pressed => _ribbonColors[162], 
				PaletteState.CheckedNormal => _ribbonColors[164], 
				_ => _ribbonColors[160], 
			};
		case PaletteBackStyle.GridHeaderColumnSheet:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBack;
			default:
				return _ribbonColors[165];
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				return _ribbonColors[167];
			case PaletteState.CheckedNormal:
				return _ribbonColors[169];
			}
		case PaletteBackStyle.GridHeaderRowSheet:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBack;
			default:
				return _ribbonColors[171];
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				return _ribbonColors[172];
			case PaletteState.CheckedNormal:
				return _ribbonColors[173];
			}
		case PaletteBackStyle.GridDataCellList:
		case PaletteBackStyle.GridDataCellCustom1:
			if (state == PaletteState.CheckedNormal)
			{
				return _ribbonColors[175];
			}
			return SystemColors.Window;
		case PaletteBackStyle.GridDataCellSheet:
			if (state == PaletteState.CheckedNormal)
			{
				return _buttonBackColors[6];
			}
			return SystemColors.Window;
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
				return SystemColors.Window;
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				switch (style)
				{
				case PaletteBackStyle.TabLowProfile:
					return Color.Empty;
				case PaletteBackStyle.TabHighProfile:
					if (state == PaletteState.Tracking)
					{
						return _buttonBackColors[2];
					}
					return _buttonBackColors[4];
				default:
					return SystemColors.Window;
				}
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				if (style == PaletteBackStyle.TabHighProfile)
				{
					return state switch
					{
						PaletteState.CheckedNormal => _buttonBackColors[6], 
						PaletteState.CheckedPressed => _buttonBackColors[4], 
						_ => _buttonBackColors[8], 
					};
				}
				return SystemColors.Window;
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
				return SystemColors.Window;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.HeaderForm:
			if (state == PaletteState.Disabled)
			{
				return _ribbonColors[48];
			}
			return _ribbonColors[46];
		case PaletteBackStyle.HeaderCalendar:
			if (state == PaletteState.Disabled)
			{
				return _ribbonColors[16];
			}
			return _ribbonColors[17];
		case PaletteBackStyle.HeaderPrimary:
		case PaletteBackStyle.HeaderCustom1:
		case PaletteBackStyle.HeaderCustom2:
			if (state == PaletteState.Disabled)
			{
				return _disabledBack;
			}
			return _ribbonColors[16];
		case PaletteBackStyle.HeaderDockInactive:
			if (state == PaletteState.Disabled)
			{
				return _disabledBack;
			}
			return _ribbonColors[215];
		case PaletteBackStyle.HeaderDockActive:
			if (state == PaletteState.Disabled)
			{
				return _disabledBack;
			}
			return _buttonBackColors[6];
		case PaletteBackStyle.HeaderSecondary:
			if (state == PaletteState.Disabled)
			{
				return _disabledBack;
			}
			return _ribbonColors[18];
		case PaletteBackStyle.SeparatorHighInternalProfile:
			if (state == PaletteState.Disabled)
			{
				return _disabledBack;
			}
			return _ribbonColors[200];
		case PaletteBackStyle.SeparatorHighProfile:
			if (state == PaletteState.Disabled)
			{
				return _disabledBack;
			}
			return _ribbonColors[14];
		case PaletteBackStyle.ControlGroupBox:
		case PaletteBackStyle.GridBackgroundList:
		case PaletteBackStyle.GridBackgroundSheet:
		case PaletteBackStyle.GridBackgroundCustom1:
		case PaletteBackStyle.PanelClient:
		case PaletteBackStyle.PanelCustom1:
		case PaletteBackStyle.SeparatorLowProfile:
		case PaletteBackStyle.SeparatorCustom1:
			return _ribbonColors[11];
		case PaletteBackStyle.PanelAlternate:
			return _ribbonColors[12];
		case PaletteBackStyle.PanelRibbonInactive:
			return _ribbonColors[42];
		case PaletteBackStyle.FormMain:
		case PaletteBackStyle.FormCustom1:
			if (state == PaletteState.Disabled)
			{
				return _ribbonColors[42];
			}
			return _ribbonColors[40];
		case PaletteBackStyle.ControlClient:
		case PaletteBackStyle.ControlAlternate:
		case PaletteBackStyle.ControlCustom1:
			return SystemColors.Window;
		case PaletteBackStyle.InputControlStandalone:
		case PaletteBackStyle.InputControlRibbon:
		case PaletteBackStyle.InputControlCustom1:
			switch (state)
			{
			case PaletteState.Disabled:
				return _ribbonColors[181];
			default:
				if (style != PaletteBackStyle.InputControlStandalone)
				{
					return _ribbonColors[182];
				}
				goto case PaletteState.Tracking;
			case PaletteState.Tracking:
				return _ribbonColors[180];
			}
		case PaletteBackStyle.ControlRibbon:
			return _ribbonColors[75];
		case PaletteBackStyle.ControlRibbonAppMenu:
			return _ribbonColors[190];
		case PaletteBackStyle.ControlToolTip:
			return _toolTipBack1;
		case PaletteBackStyle.ContextMenuOuter:
			return _contextMenuBack;
		case PaletteBackStyle.ContextMenuSeparator:
		case PaletteBackStyle.ContextMenuItemSplit:
			if (state == PaletteState.Tracking)
			{
				return _buttonBackColors[2];
			}
			return _contextMenuBack;
		case PaletteBackStyle.ContextMenuInner:
			return _contextMenuBack;
		case PaletteBackStyle.ContextMenuHeading:
			return _ribbonColors[187];
		case PaletteBackStyle.ContextMenuItemImageColumn:
			return _ribbonColors[189];
		case PaletteBackStyle.ContextMenuItemImage:
			return _contextMenuImageBackChecked;
		case PaletteBackStyle.ButtonForm:
			switch (state)
			{
			case PaletteState.Disabled:
			case PaletteState.Normal:
			case PaletteState.NormalDefaultOverride:
				return Color.Empty;
			case PaletteState.CheckedNormal:
				return _ribbonColors[131];
			case PaletteState.Tracking:
				return _ribbonColors[55];
			case PaletteState.CheckedTracking:
				return _ribbonColors[134];
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				return _ribbonColors[58];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.ButtonFormClose:
			switch (state)
			{
			case PaletteState.Disabled:
			case PaletteState.Normal:
			case PaletteState.NormalDefaultOverride:
				return Color.Empty;
			case PaletteState.CheckedNormal:
				return _formCloseChecked1;
			case PaletteState.Tracking:
				return _formCloseTracking1;
			case PaletteState.CheckedTracking:
				return _formCloseCheckedTracking1;
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				return _formClosePressed1;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.ButtonStandalone:
		case PaletteBackStyle.ButtonAlternate:
		case PaletteBackStyle.ButtonLowProfile:
		case PaletteBackStyle.ButtonButtonSpec:
		case PaletteBackStyle.ButtonBreadCrumb:
		case PaletteBackStyle.ButtonCalendarDay:
		case PaletteBackStyle.ButtonCluster:
		case PaletteBackStyle.ButtonGallery:
		case PaletteBackStyle.ButtonInputControl:
		case PaletteBackStyle.ButtonListItem:
		case PaletteBackStyle.ButtonCommand:
		case PaletteBackStyle.ButtonCustom1:
		case PaletteBackStyle.ButtonCustom2:
		case PaletteBackStyle.ButtonCustom3:
		case PaletteBackStyle.ContextMenuItemHighlight:
			switch (state)
			{
			case PaletteState.Disabled:
				if (style == PaletteBackStyle.ButtonGallery)
				{
					return _ribbonColors[205];
				}
				return _disabledBack;
			case PaletteState.Normal:
				return _ribbonColors[5];
			case PaletteState.NormalDefaultOverride:
				return _ribbonColors[7];
			case PaletteState.CheckedNormal:
				if (style == PaletteBackStyle.ButtonInputControl)
				{
					return _ribbonColors[5];
				}
				return _buttonBackColors[6];
			case PaletteState.Tracking:
				return _buttonBackColors[2];
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				return _buttonBackColors[4];
			case PaletteState.CheckedTracking:
				if (style == PaletteBackStyle.ButtonInputControl)
				{
					return _ribbonColors[5];
				}
				return _buttonBackColors[8];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.ButtonNavigatorStack:
		case PaletteBackStyle.ButtonNavigatorOverflow:
		case PaletteBackStyle.ButtonNavigatorMini:
			switch (state)
			{
			case PaletteState.Disabled:
				return _buttonBackColors[1];
			case PaletteState.Tracking:
				return _ribbonColors[219];
			case PaletteState.Pressed:
				return _ribbonColors[221];
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _ribbonColors[223];
			default:
				return _ribbonColors[9];
			}
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
		case PaletteBackStyle.GridHeaderColumnList:
		case PaletteBackStyle.GridHeaderRowList:
		case PaletteBackStyle.GridHeaderColumnCustom1:
		case PaletteBackStyle.GridHeaderRowCustom1:
			return state switch
			{
				PaletteState.Disabled => _disabledBack, 
				PaletteState.Pressed => _ribbonColors[163], 
				PaletteState.CheckedNormal => _ribbonColors[164], 
				_ => _ribbonColors[161], 
			};
		case PaletteBackStyle.GridHeaderColumnSheet:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBack;
			default:
				return _ribbonColors[166];
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				return _ribbonColors[168];
			case PaletteState.CheckedNormal:
				return _ribbonColors[170];
			}
		case PaletteBackStyle.GridHeaderRowSheet:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBack;
			default:
				return _ribbonColors[171];
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				return _ribbonColors[172];
			case PaletteState.CheckedNormal:
				return _ribbonColors[173];
			}
		case PaletteBackStyle.GridDataCellList:
		case PaletteBackStyle.GridDataCellCustom1:
			if (state == PaletteState.CheckedNormal)
			{
				return _ribbonColors[175];
			}
			return SystemColors.Window;
		case PaletteBackStyle.GridDataCellSheet:
			if (state == PaletteState.CheckedNormal)
			{
				return _buttonBackColors[7];
			}
			return SystemColors.Window;
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
				return _ribbonColors[6];
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				if (style == PaletteBackStyle.TabLowProfile)
				{
					return Color.Empty;
				}
				return SystemColors.Window;
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return SystemColors.Window;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.TabDock:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBack;
			case PaletteState.Normal:
				return _ribbonColors[215];
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				return _buttonBackColors[4];
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return SystemColors.Window;
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
				return _ribbonColors[215];
			case PaletteState.Tracking:
			case PaletteState.Pressed:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _buttonBackColors[4];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.HeaderForm:
			if (state == PaletteState.Disabled)
			{
				return _ribbonColors[49];
			}
			return _ribbonColors[47];
		case PaletteBackStyle.HeaderCalendar:
			if (state == PaletteState.Disabled)
			{
				return _ribbonColors[16];
			}
			return _ribbonColors[17];
		case PaletteBackStyle.HeaderPrimary:
		case PaletteBackStyle.HeaderCustom1:
		case PaletteBackStyle.HeaderCustom2:
			if (state == PaletteState.Disabled)
			{
				return _disabledBack;
			}
			return _ribbonColors[17];
		case PaletteBackStyle.HeaderDockInactive:
			if (state == PaletteState.Disabled)
			{
				return _disabledBack;
			}
			return _ribbonColors[216];
		case PaletteBackStyle.HeaderDockActive:
			if (state == PaletteState.Disabled)
			{
				return _disabledBack;
			}
			return _buttonBackColors[7];
		case PaletteBackStyle.HeaderSecondary:
			if (state == PaletteState.Disabled)
			{
				return _disabledBack;
			}
			return _ribbonColors[19];
		case PaletteBackStyle.SeparatorHighInternalProfile:
			if (state == PaletteState.Disabled)
			{
				return _disabledBack;
			}
			return _ribbonColors[201];
		case PaletteBackStyle.SeparatorHighProfile:
			if (state == PaletteState.Disabled)
			{
				return _disabledBack;
			}
			return _ribbonColors[15];
		case PaletteBackStyle.ControlGroupBox:
		case PaletteBackStyle.GridBackgroundList:
		case PaletteBackStyle.GridBackgroundSheet:
		case PaletteBackStyle.GridBackgroundCustom1:
		case PaletteBackStyle.PanelClient:
		case PaletteBackStyle.PanelCustom1:
		case PaletteBackStyle.SeparatorLowProfile:
		case PaletteBackStyle.SeparatorCustom1:
			return _ribbonColors[11];
		case PaletteBackStyle.PanelAlternate:
			return _ribbonColors[12];
		case PaletteBackStyle.PanelRibbonInactive:
			return _ribbonColors[43];
		case PaletteBackStyle.FormMain:
		case PaletteBackStyle.FormCustom1:
			if (state == PaletteState.Disabled)
			{
				return _ribbonColors[43];
			}
			return _ribbonColors[41];
		case PaletteBackStyle.ControlClient:
		case PaletteBackStyle.ControlAlternate:
		case PaletteBackStyle.ControlCustom1:
			return SystemColors.Window;
		case PaletteBackStyle.InputControlStandalone:
		case PaletteBackStyle.InputControlRibbon:
		case PaletteBackStyle.InputControlCustom1:
			switch (state)
			{
			case PaletteState.Disabled:
				return _ribbonColors[181];
			default:
				if (style != PaletteBackStyle.InputControlStandalone)
				{
					return _ribbonColors[182];
				}
				goto case PaletteState.Tracking;
			case PaletteState.Tracking:
				return _ribbonColors[180];
			}
		case PaletteBackStyle.ControlRibbon:
			return _ribbonColors[75];
		case PaletteBackStyle.ControlRibbonAppMenu:
			return _ribbonColors[191];
		case PaletteBackStyle.ControlToolTip:
			return _ribbonColors[225];
		case PaletteBackStyle.ContextMenuOuter:
			return _contextMenuBack;
		case PaletteBackStyle.ContextMenuSeparator:
		case PaletteBackStyle.ContextMenuItemSplit:
			if (state == PaletteState.Tracking)
			{
				return _buttonBackColors[3];
			}
			return _contextMenuBack;
		case PaletteBackStyle.ContextMenuInner:
			return _contextMenuBack;
		case PaletteBackStyle.ContextMenuHeading:
			return _ribbonColors[187];
		case PaletteBackStyle.ContextMenuItemImageColumn:
			return _ribbonColors[189];
		case PaletteBackStyle.ContextMenuItemImage:
			return _contextMenuImageBackChecked;
		case PaletteBackStyle.ButtonForm:
			switch (state)
			{
			case PaletteState.Disabled:
			case PaletteState.Normal:
			case PaletteState.NormalDefaultOverride:
				return Color.Empty;
			case PaletteState.CheckedNormal:
				return _ribbonColors[132];
			case PaletteState.Tracking:
				return _ribbonColors[56];
			case PaletteState.CheckedTracking:
				return _ribbonColors[135];
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				return _ribbonColors[59];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.ButtonFormClose:
			switch (state)
			{
			case PaletteState.Disabled:
			case PaletteState.Normal:
			case PaletteState.NormalDefaultOverride:
				return Color.Empty;
			case PaletteState.CheckedNormal:
				return _formCloseChecked2;
			case PaletteState.Tracking:
				return _formCloseTracking2;
			case PaletteState.CheckedTracking:
				return _formCloseCheckedTracking2;
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				return _formClosePressed2;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.ButtonStandalone:
		case PaletteBackStyle.ButtonAlternate:
		case PaletteBackStyle.ButtonLowProfile:
		case PaletteBackStyle.ButtonButtonSpec:
		case PaletteBackStyle.ButtonBreadCrumb:
		case PaletteBackStyle.ButtonCalendarDay:
		case PaletteBackStyle.ButtonCluster:
		case PaletteBackStyle.ButtonGallery:
		case PaletteBackStyle.ButtonInputControl:
		case PaletteBackStyle.ButtonListItem:
		case PaletteBackStyle.ButtonCommand:
		case PaletteBackStyle.ButtonCustom1:
		case PaletteBackStyle.ButtonCustom2:
		case PaletteBackStyle.ButtonCustom3:
		case PaletteBackStyle.ContextMenuItemHighlight:
			switch (state)
			{
			case PaletteState.Disabled:
				if (style == PaletteBackStyle.ButtonGallery)
				{
					return _ribbonColors[205];
				}
				return _buttonBackColors[1];
			case PaletteState.Normal:
				return _ribbonColors[6];
			case PaletteState.NormalDefaultOverride:
				if (style == PaletteBackStyle.ButtonLowProfile || style == PaletteBackStyle.ButtonBreadCrumb || style == PaletteBackStyle.ButtonListItem || style == PaletteBackStyle.ButtonCommand || style == PaletteBackStyle.ButtonButtonSpec || style == PaletteBackStyle.ContextMenuItemHighlight)
				{
					return Color.Empty;
				}
				return _ribbonColors[8];
			case PaletteState.CheckedNormal:
				if (style == PaletteBackStyle.ButtonInputControl)
				{
					return _ribbonColors[6];
				}
				return _buttonBackColors[7];
			case PaletteState.Tracking:
				return _buttonBackColors[3];
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				return _buttonBackColors[5];
			case PaletteState.CheckedTracking:
				if (style == PaletteBackStyle.ButtonInputControl)
				{
					return _ribbonColors[5];
				}
				return _buttonBackColors[9];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.ButtonNavigatorStack:
		case PaletteBackStyle.ButtonNavigatorOverflow:
		case PaletteBackStyle.ButtonNavigatorMini:
			switch (state)
			{
			case PaletteState.Disabled:
				return _buttonBackColors[1];
			case PaletteState.Tracking:
				return _ribbonColors[220];
			case PaletteState.Pressed:
				return _ribbonColors[222];
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _ribbonColors[224];
			default:
				return _ribbonColors[10];
			}
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
		case PaletteBackStyle.HeaderForm:
			return PaletteColorStyle.Rounding5;
		case PaletteBackStyle.GridHeaderColumnList:
		case PaletteBackStyle.GridHeaderColumnCustom1:
			return PaletteColorStyle.Rounded;
		case PaletteBackStyle.GridHeaderRowList:
		case PaletteBackStyle.GridHeaderRowCustom1:
			return PaletteColorStyle.Linear;
		case PaletteBackStyle.GridHeaderColumnSheet:
		case PaletteBackStyle.GridHeaderRowSheet:
			return PaletteColorStyle.Linear;
		case PaletteBackStyle.GridDataCellList:
		case PaletteBackStyle.GridDataCellCustom1:
			return PaletteColorStyle.Solid;
		case PaletteBackStyle.GridDataCellSheet:
			return PaletteColorStyle.ExpertChecked;
		case PaletteBackStyle.TabHighProfile:
		case PaletteBackStyle.TabCustom1:
		case PaletteBackStyle.TabCustom2:
		case PaletteBackStyle.TabCustom3:
			switch (state)
			{
			case PaletteState.Tracking:
			case PaletteState.Pressed:
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return PaletteColorStyle.GlassFade;
			default:
				return PaletteColorStyle.QuarterPhase;
			}
		case PaletteBackStyle.TabStandardProfile:
			switch (state)
			{
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return PaletteColorStyle.Solid;
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				return PaletteColorStyle.GlassFade;
			default:
				return PaletteColorStyle.QuarterPhase;
			}
		case PaletteBackStyle.TabLowProfile:
			return PaletteColorStyle.Solid;
		case PaletteBackStyle.TabOneNote:
		case PaletteBackStyle.TabDock:
		case PaletteBackStyle.TabDockAutoHidden:
			return PaletteColorStyle.Linear;
		case PaletteBackStyle.ButtonCalendarDay:
		case PaletteBackStyle.ControlClient:
		case PaletteBackStyle.ControlAlternate:
		case PaletteBackStyle.ControlGroupBox:
		case PaletteBackStyle.ControlRibbon:
		case PaletteBackStyle.ControlCustom1:
		case PaletteBackStyle.ContextMenuOuter:
		case PaletteBackStyle.ContextMenuInner:
		case PaletteBackStyle.ContextMenuHeading:
		case PaletteBackStyle.ContextMenuItemImageColumn:
		case PaletteBackStyle.InputControlStandalone:
		case PaletteBackStyle.InputControlRibbon:
		case PaletteBackStyle.InputControlCustom1:
		case PaletteBackStyle.GridBackgroundList:
		case PaletteBackStyle.GridBackgroundSheet:
		case PaletteBackStyle.GridBackgroundCustom1:
		case PaletteBackStyle.HeaderCalendar:
		case PaletteBackStyle.PanelClient:
		case PaletteBackStyle.PanelAlternate:
		case PaletteBackStyle.PanelRibbonInactive:
		case PaletteBackStyle.PanelCustom1:
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
		case PaletteBackStyle.FormMain:
		case PaletteBackStyle.FormCustom1:
			return PaletteColorStyle.SolidAllLine;
		case PaletteBackStyle.SeparatorHighProfile:
			return PaletteColorStyle.RoundedTopLight;
		case PaletteBackStyle.SeparatorHighInternalProfile:
			return PaletteColorStyle.Linear;
		case PaletteBackStyle.HeaderPrimary:
		case PaletteBackStyle.HeaderSecondary:
		case PaletteBackStyle.HeaderDockInactive:
		case PaletteBackStyle.HeaderDockActive:
		case PaletteBackStyle.HeaderCustom1:
		case PaletteBackStyle.HeaderCustom2:
			return PaletteColorStyle.Rounded;
		case PaletteBackStyle.ButtonForm:
		case PaletteBackStyle.ButtonFormClose:
			switch (state)
			{
			case PaletteState.Disabled:
			case PaletteState.Normal:
			case PaletteState.Tracking:
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.NormalDefaultOverride:
				return PaletteColorStyle.Linear;
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				return PaletteColorStyle.LinearShadow;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.ButtonStandalone:
		case PaletteBackStyle.ButtonAlternate:
		case PaletteBackStyle.ButtonLowProfile:
		case PaletteBackStyle.ButtonButtonSpec:
		case PaletteBackStyle.ButtonBreadCrumb:
		case PaletteBackStyle.ButtonCluster:
		case PaletteBackStyle.ButtonGallery:
		case PaletteBackStyle.ButtonInputControl:
		case PaletteBackStyle.ButtonListItem:
		case PaletteBackStyle.ButtonCommand:
		case PaletteBackStyle.ButtonCustom1:
		case PaletteBackStyle.ButtonCustom2:
		case PaletteBackStyle.ButtonCustom3:
		case PaletteBackStyle.ContextMenuItemHighlight:
			switch (state)
			{
			case PaletteState.Disabled:
				return PaletteColorStyle.Solid;
			case PaletteState.Normal:
				return PaletteColorStyle.Linear;
			case PaletteState.Tracking:
				return PaletteColorStyle.ExpertTracking;
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				return PaletteColorStyle.ExpertPressed;
			case PaletteState.CheckedNormal:
				return PaletteColorStyle.ExpertChecked;
			case PaletteState.CheckedTracking:
				return PaletteColorStyle.ExpertCheckedTracking;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.ContextMenuItemImage:
			return PaletteColorStyle.Solid;
		case PaletteBackStyle.ButtonNavigatorStack:
		case PaletteBackStyle.ButtonNavigatorOverflow:
		case PaletteBackStyle.ButtonNavigatorMini:
			switch (state)
			{
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				return PaletteColorStyle.SolidAllLine;
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return PaletteColorStyle.ExpertSquareHighlight;
			default:
				return PaletteColorStyle.Solid;
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
		case PaletteBorderStyle.HeaderForm:
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
		case PaletteBorderStyle.HeaderCalendar:
		case PaletteBorderStyle.HeaderCustom1:
		case PaletteBorderStyle.HeaderCustom2:
		case PaletteBorderStyle.SeparatorLowProfile:
		case PaletteBorderStyle.SeparatorHighProfile:
		case PaletteBorderStyle.SeparatorHighInternalProfile:
		case PaletteBorderStyle.SeparatorCustom1:
		case PaletteBorderStyle.FormMain:
		case PaletteBorderStyle.FormCustom1:
			return PaletteDrawBorders.All;
		case PaletteBorderStyle.TabHighProfile:
		case PaletteBorderStyle.TabStandardProfile:
		case PaletteBorderStyle.TabLowProfile:
		case PaletteBorderStyle.TabOneNote:
		case PaletteBorderStyle.TabDock:
		case PaletteBorderStyle.TabDockAutoHidden:
		case PaletteBorderStyle.TabCustom1:
		case PaletteBorderStyle.TabCustom2:
		case PaletteBorderStyle.TabCustom3:
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
		case PaletteBorderStyle.ContextMenuInner:
			return PaletteDrawBorders.None;
		case PaletteBorderStyle.HeaderForm:
			return PaletteDrawBorders.TopLeftRight;
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
		if ((uint)style <= 68u)
		{
			return PaletteGraphicsHint.AntiAlias;
		}
		throw new ArgumentOutOfRangeException("style");
	}

	public override Color GetBorderColor1(PaletteBorderStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideStateExclude(state, PaletteState.NormalDefaultOverride))
		{
			if (state == PaletteState.TodayOverride && style == PaletteBorderStyle.ButtonCalendarDay)
			{
				if (state == PaletteState.Disabled)
				{
					return _disabledBorder;
				}
				return _todayBorder;
			}
			return Color.Empty;
		}
		switch (style)
		{
		case PaletteBorderStyle.TabHighProfile:
		case PaletteBorderStyle.TabStandardProfile:
		case PaletteBorderStyle.TabLowProfile:
		case PaletteBorderStyle.TabOneNote:
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
				if (style == PaletteBorderStyle.TabLowProfile)
				{
					return Color.Empty;
				}
				return _ribbonColors[3];
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _ribbonColors[13];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBorderStyle.TabDock:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBorder;
			case PaletteState.Normal:
				return _ribbonColors[3];
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				return _buttonBorderColors[2];
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _ribbonColors[13];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBorderStyle.TabDockAutoHidden:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBorder;
			case PaletteState.Normal:
			case PaletteState.CheckedNormal:
				return _ribbonColors[3];
			case PaletteState.Tracking:
			case PaletteState.Pressed:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _buttonBorderColors[2];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBorderStyle.HeaderCalendar:
			if (state == PaletteState.Disabled)
			{
				return _ribbonColors[16];
			}
			return _ribbonColors[17];
		case PaletteBorderStyle.HeaderForm:
			if (state == PaletteState.Disabled)
			{
				return _ribbonColors[45];
			}
			return _ribbonColors[44];
		case PaletteBorderStyle.ControlClient:
		case PaletteBorderStyle.ControlAlternate:
		case PaletteBorderStyle.ControlGroupBox:
		case PaletteBorderStyle.ControlCustom1:
		case PaletteBorderStyle.GridHeaderColumnList:
		case PaletteBorderStyle.GridHeaderRowList:
		case PaletteBorderStyle.GridHeaderColumnSheet:
		case PaletteBorderStyle.GridHeaderRowSheet:
		case PaletteBorderStyle.GridHeaderColumnCustom1:
		case PaletteBorderStyle.GridHeaderRowCustom1:
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
			return _ribbonColors[13];
		case PaletteBorderStyle.ContextMenuHeading:
		case PaletteBorderStyle.ContextMenuItemImageColumn:
			return _contextMenuHeadingBorder;
		case PaletteBorderStyle.ContextMenuSeparator:
		case PaletteBorderStyle.ContextMenuItemSplit:
			return state switch
			{
				PaletteState.Disabled => _buttonBorderColors[0], 
				PaletteState.Tracking => _buttonBorderColors[1], 
				_ => _contextMenuHeadingBorder, 
			};
		case PaletteBorderStyle.ContextMenuItemImage:
			return _contextMenuImageBorderChecked;
		case PaletteBorderStyle.InputControlStandalone:
		case PaletteBorderStyle.InputControlRibbon:
		case PaletteBorderStyle.InputControlCustom1:
			if (state == PaletteState.Disabled)
			{
				return _ribbonColors[179];
			}
			return _ribbonColors[178];
		case PaletteBorderStyle.GridDataCellList:
		case PaletteBorderStyle.GridDataCellSheet:
		case PaletteBorderStyle.GridDataCellCustom1:
			if (state == PaletteState.Disabled)
			{
				return _disabledBorder;
			}
			return _ribbonColors[174];
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
		case PaletteBorderStyle.ContextMenuOuter:
			return _contextMenuBorder;
		case PaletteBorderStyle.ContextMenuInner:
			return _contextMenuBack;
		case PaletteBorderStyle.ControlToolTip:
			if (state == PaletteState.Disabled)
			{
				return _disabledBorder;
			}
			return _toolTipBorder;
		case PaletteBorderStyle.FormMain:
		case PaletteBorderStyle.FormCustom1:
			if (state == PaletteState.Disabled)
			{
				return _ribbonColors[39];
			}
			return _ribbonColors[38];
		case PaletteBorderStyle.ButtonForm:
			switch (state)
			{
			case PaletteState.Disabled:
			case PaletteState.Normal:
			case PaletteState.NormalDefaultOverride:
				return Color.Empty;
			case PaletteState.CheckedNormal:
				return _ribbonColors[133];
			case PaletteState.Tracking:
			case PaletteState.CheckedTracking:
				return _ribbonColors[54];
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				return _ribbonColors[57];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBorderStyle.ButtonFormClose:
			switch (state)
			{
			case PaletteState.Disabled:
			case PaletteState.Normal:
			case PaletteState.NormalDefaultOverride:
				return Color.Empty;
			case PaletteState.CheckedNormal:
				return _formCloseBorderCheckedNormal;
			case PaletteState.Tracking:
			case PaletteState.CheckedTracking:
				return _formCloseBorderTracking;
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				return _formCloseBorderPressed;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBorderStyle.ButtonStandalone:
		case PaletteBorderStyle.ButtonAlternate:
		case PaletteBorderStyle.ButtonLowProfile:
		case PaletteBorderStyle.ButtonButtonSpec:
		case PaletteBorderStyle.ButtonBreadCrumb:
		case PaletteBorderStyle.ButtonCluster:
		case PaletteBorderStyle.ButtonGallery:
		case PaletteBorderStyle.ButtonListItem:
		case PaletteBorderStyle.ButtonCommand:
		case PaletteBorderStyle.ButtonCustom1:
		case PaletteBorderStyle.ButtonCustom2:
		case PaletteBorderStyle.ButtonCustom3:
		case PaletteBorderStyle.ContextMenuItemHighlight:
			switch (state)
			{
			case PaletteState.Disabled:
				if (style == PaletteBorderStyle.ButtonGallery)
				{
					return _ribbonColors[206];
				}
				return _buttonBorderColors[0];
			case PaletteState.Normal:
				return _ribbonColors[3];
			case PaletteState.NormalDefaultOverride:
				if (style == PaletteBorderStyle.ButtonLowProfile || style == PaletteBorderStyle.ButtonBreadCrumb || style == PaletteBorderStyle.ButtonListItem || style == PaletteBorderStyle.ButtonCommand || style == PaletteBorderStyle.ButtonButtonSpec || style == PaletteBorderStyle.ContextMenuItemHighlight)
				{
					return Color.Empty;
				}
				return _ribbonColors[4];
			case PaletteState.CheckedNormal:
				return _buttonBorderColors[5];
			case PaletteState.Tracking:
				return _buttonBorderColors[1];
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				return _buttonBorderColors[3];
			case PaletteState.CheckedTracking:
				return _buttonBorderColors[3];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBorderStyle.ButtonInputControl:
			switch (state)
			{
			case PaletteState.Disabled:
				return _buttonBorderColors[0];
			case PaletteState.Normal:
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
				return _ribbonColors[3];
			case PaletteState.Tracking:
				return _buttonBorderColors[1];
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				return _buttonBorderColors[3];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBorderStyle.ButtonCalendarDay:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBack;
			case PaletteState.Normal:
				return _ribbonColors[5];
			case PaletteState.NormalDefaultOverride:
				return _ribbonColors[7];
			case PaletteState.CheckedNormal:
				return _buttonBackColors[6];
			case PaletteState.Tracking:
				return _buttonBackColors[2];
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				return _buttonBackColors[4];
			case PaletteState.CheckedTracking:
				return _buttonBackColors[8];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBorderStyle.ButtonNavigatorStack:
		case PaletteBorderStyle.ButtonNavigatorOverflow:
		case PaletteBorderStyle.ButtonNavigatorMini:
			return _ribbonColors[217];
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
				return _todayBorder;
			}
			return Color.Empty;
		}
		switch (style)
		{
		case PaletteBorderStyle.TabHighProfile:
		case PaletteBorderStyle.TabStandardProfile:
		case PaletteBorderStyle.TabLowProfile:
		case PaletteBorderStyle.TabOneNote:
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
				if (style == PaletteBorderStyle.TabLowProfile)
				{
					return Color.Empty;
				}
				return _ribbonColors[3];
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _ribbonColors[13];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBorderStyle.TabDock:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBorder;
			case PaletteState.Normal:
				return _ribbonColors[3];
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				return _buttonBorderColors[2];
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _ribbonColors[13];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBorderStyle.TabDockAutoHidden:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBorder;
			case PaletteState.Normal:
			case PaletteState.CheckedNormal:
				return _ribbonColors[3];
			case PaletteState.Tracking:
			case PaletteState.Pressed:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _buttonBorderColors[2];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBorderStyle.HeaderForm:
			if (state == PaletteState.Disabled)
			{
				return _ribbonColors[45];
			}
			return _ribbonColors[44];
		case PaletteBorderStyle.ControlClient:
		case PaletteBorderStyle.ControlAlternate:
		case PaletteBorderStyle.ControlGroupBox:
		case PaletteBorderStyle.ControlCustom1:
		case PaletteBorderStyle.GridHeaderColumnList:
		case PaletteBorderStyle.GridHeaderRowList:
		case PaletteBorderStyle.GridHeaderColumnSheet:
		case PaletteBorderStyle.GridHeaderRowSheet:
		case PaletteBorderStyle.GridHeaderColumnCustom1:
		case PaletteBorderStyle.GridHeaderRowCustom1:
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
			return _ribbonColors[13];
		case PaletteBorderStyle.HeaderCalendar:
			if (state == PaletteState.Disabled)
			{
				return _ribbonColors[16];
			}
			return _ribbonColors[17];
		case PaletteBorderStyle.ContextMenuHeading:
		case PaletteBorderStyle.ContextMenuItemImageColumn:
			return _contextMenuHeadingBorder;
		case PaletteBorderStyle.ContextMenuSeparator:
		case PaletteBorderStyle.ContextMenuItemSplit:
			return state switch
			{
				PaletteState.Disabled => _buttonBorderColors[0], 
				PaletteState.Tracking => _buttonBorderColors[2], 
				_ => _contextMenuHeadingBorder, 
			};
		case PaletteBorderStyle.ContextMenuItemImage:
			return _contextMenuImageBorderChecked;
		case PaletteBorderStyle.InputControlStandalone:
		case PaletteBorderStyle.InputControlRibbon:
		case PaletteBorderStyle.InputControlCustom1:
			if (state == PaletteState.Disabled)
			{
				return _ribbonColors[179];
			}
			return _ribbonColors[178];
		case PaletteBorderStyle.GridDataCellList:
		case PaletteBorderStyle.GridDataCellSheet:
		case PaletteBorderStyle.GridDataCellCustom1:
			if (state == PaletteState.Disabled)
			{
				return _disabledBorder;
			}
			return _ribbonColors[174];
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
		case PaletteBorderStyle.ContextMenuOuter:
			return _contextMenuBorder;
		case PaletteBorderStyle.ContextMenuInner:
			return _contextMenuBack;
		case PaletteBorderStyle.ControlToolTip:
			if (state == PaletteState.Disabled)
			{
				return _disabledBorder;
			}
			return _toolTipBorder;
		case PaletteBorderStyle.FormMain:
		case PaletteBorderStyle.FormCustom1:
			if (state == PaletteState.Disabled)
			{
				return _ribbonColors[39];
			}
			return _ribbonColors[38];
		case PaletteBorderStyle.ButtonForm:
			switch (state)
			{
			case PaletteState.Disabled:
			case PaletteState.Normal:
			case PaletteState.NormalDefaultOverride:
				return Color.Empty;
			case PaletteState.CheckedNormal:
				return _ribbonColors[133];
			case PaletteState.Tracking:
			case PaletteState.CheckedTracking:
				return _ribbonColors[54];
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				return _ribbonColors[57];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBorderStyle.ButtonFormClose:
			switch (state)
			{
			case PaletteState.Disabled:
			case PaletteState.Normal:
			case PaletteState.NormalDefaultOverride:
				return Color.Empty;
			case PaletteState.CheckedNormal:
				return _formCloseBorderCheckedNormal;
			case PaletteState.Tracking:
			case PaletteState.CheckedTracking:
				return _formCloseBorderTracking;
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				return _formCloseBorderPressed;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBorderStyle.ButtonStandalone:
		case PaletteBorderStyle.ButtonAlternate:
		case PaletteBorderStyle.ButtonLowProfile:
		case PaletteBorderStyle.ButtonButtonSpec:
		case PaletteBorderStyle.ButtonBreadCrumb:
		case PaletteBorderStyle.ButtonCluster:
		case PaletteBorderStyle.ButtonGallery:
		case PaletteBorderStyle.ButtonListItem:
		case PaletteBorderStyle.ButtonCommand:
		case PaletteBorderStyle.ButtonCustom1:
		case PaletteBorderStyle.ButtonCustom2:
		case PaletteBorderStyle.ButtonCustom3:
		case PaletteBorderStyle.ContextMenuItemHighlight:
			switch (state)
			{
			case PaletteState.Disabled:
				if (style == PaletteBorderStyle.ButtonGallery)
				{
					return _ribbonColors[206];
				}
				return _buttonBorderColors[0];
			case PaletteState.Normal:
				return _ribbonColors[3];
			case PaletteState.NormalDefaultOverride:
				return _ribbonColors[4];
			case PaletteState.CheckedNormal:
				return _buttonBorderColors[6];
			case PaletteState.Tracking:
				return _buttonBorderColors[2];
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				return _buttonBorderColors[4];
			case PaletteState.CheckedTracking:
				return _buttonBorderColors[4];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBorderStyle.ButtonInputControl:
			switch (state)
			{
			case PaletteState.Disabled:
				return _buttonBorderColors[0];
			case PaletteState.Normal:
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
				return _ribbonColors[3];
			case PaletteState.Tracking:
				return _buttonBorderColors[2];
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				return _buttonBorderColors[4];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBorderStyle.ButtonCalendarDay:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledBack;
			case PaletteState.Normal:
				return _ribbonColors[5];
			case PaletteState.NormalDefaultOverride:
				return _ribbonColors[7];
			case PaletteState.CheckedNormal:
				return _buttonBackColors[6];
			case PaletteState.Tracking:
				return _buttonBackColors[2];
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				return _buttonBackColors[4];
			case PaletteState.CheckedTracking:
				return _buttonBackColors[8];
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBorderStyle.ButtonNavigatorStack:
		case PaletteBorderStyle.ButtonNavigatorOverflow:
		case PaletteBorderStyle.ButtonNavigatorMini:
			return _ribbonColors[217];
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
		case PaletteBorderStyle.TabCustom1:
		case PaletteBorderStyle.TabCustom2:
		case PaletteBorderStyle.TabCustom3:
			return PaletteColorStyle.Sigma;
		case PaletteBorderStyle.TabDock:
			if (state == PaletteState.Tracking || state == PaletteState.Pressed)
			{
				return PaletteColorStyle.Solid;
			}
			return PaletteColorStyle.Sigma;
		case PaletteBorderStyle.TabDockAutoHidden:
			switch (state)
			{
			case PaletteState.Tracking:
			case PaletteState.Pressed:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return PaletteColorStyle.Solid;
			default:
				return PaletteColorStyle.Sigma;
			}
		case PaletteBorderStyle.ButtonCalendarDay:
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
		case PaletteBorderStyle.ContextMenuItemSplit:
			if (state == PaletteState.Tracking)
			{
				return PaletteColorStyle.Sigma;
			}
			return PaletteColorStyle.Solid;
		case PaletteBorderStyle.ContextMenuSeparator:
			return PaletteColorStyle.Dashed;
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
		case PaletteBorderStyle.ButtonListItem:
		case PaletteBorderStyle.ButtonCommand:
		case PaletteBorderStyle.ButtonCustom1:
		case PaletteBorderStyle.ButtonCustom2:
		case PaletteBorderStyle.ButtonCustom3:
		case PaletteBorderStyle.ContextMenuItemHighlight:
			switch (state)
			{
			case PaletteState.Normal:
				return PaletteColorStyle.Solid;
			case PaletteState.Disabled:
			case PaletteState.NormalDefaultOverride:
				return PaletteColorStyle.Solid;
			default:
				return PaletteColorStyle.Linear;
			}
		case PaletteBorderStyle.ButtonForm:
		case PaletteBorderStyle.ButtonFormClose:
			return PaletteColorStyle.Solid;
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
		case PaletteBorderStyle.ButtonNavigatorStack:
		case PaletteBorderStyle.ButtonNavigatorOverflow:
		case PaletteBorderStyle.ButtonNavigatorMini:
		case PaletteBorderStyle.ButtonInputControl:
		case PaletteBorderStyle.ControlClient:
		case PaletteBorderStyle.ControlAlternate:
		case PaletteBorderStyle.ControlCustom1:
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
			return 0;
		case PaletteBorderStyle.ControlToolTip:
		case PaletteBorderStyle.ContextMenuItemImage:
			return 1;
		case PaletteBorderStyle.ButtonStandalone:
		case PaletteBorderStyle.ButtonAlternate:
		case PaletteBorderStyle.ButtonLowProfile:
		case PaletteBorderStyle.ButtonButtonSpec:
		case PaletteBorderStyle.ButtonBreadCrumb:
		case PaletteBorderStyle.ButtonCluster:
		case PaletteBorderStyle.ButtonGallery:
		case PaletteBorderStyle.ButtonListItem:
		case PaletteBorderStyle.ButtonForm:
		case PaletteBorderStyle.ButtonFormClose:
		case PaletteBorderStyle.ButtonCommand:
		case PaletteBorderStyle.ButtonCustom1:
		case PaletteBorderStyle.ButtonCustom2:
		case PaletteBorderStyle.ButtonCustom3:
		case PaletteBorderStyle.ContextMenuOuter:
		case PaletteBorderStyle.ContextMenuItemHighlight:
			return 2;
		case PaletteBorderStyle.ControlGroupBox:
		case PaletteBorderStyle.ControlRibbon:
		case PaletteBorderStyle.ControlRibbonAppMenu:
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
		if ((uint)style <= 67u)
		{
			if (state == PaletteState.Disabled)
			{
				return PaletteImageEffect.Disabled;
			}
			return PaletteImageEffect.Normal;
		}
		throw new ArgumentOutOfRangeException("style");
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
				return _ribbonColors[51];
			}
			return _ribbonColors[50];
		}
		if (state == PaletteState.Disabled && style != PaletteContentStyle.LabelToolTip && style != PaletteContentStyle.LabelSuperTip && style != PaletteContentStyle.LabelKeyTip && style != PaletteContentStyle.InputControlStandalone && style != PaletteContentStyle.InputControlRibbon && style != PaletteContentStyle.InputControlCustom1 && style != PaletteContentStyle.ButtonInputControl && style != PaletteContentStyle.ButtonCalendarDay)
		{
			return _disabledText;
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
			return _gridTextColor;
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderSecondary:
		case PaletteContentStyle.HeaderDockInactive:
		case PaletteContentStyle.HeaderCustom1:
		case PaletteContentStyle.HeaderCustom2:
			return _ribbonColors[20];
		case PaletteContentStyle.HeaderDockActive:
			return Color.Black;
		case PaletteContentStyle.InputControlStandalone:
		case PaletteContentStyle.InputControlRibbon:
		case PaletteContentStyle.InputControlCustom1:
			if (state == PaletteState.Disabled)
			{
				return _ribbonColors[177];
			}
			return _ribbonColors[176];
		case PaletteContentStyle.LabelNormalPanel:
		case PaletteContentStyle.LabelBoldPanel:
		case PaletteContentStyle.LabelItalicPanel:
		case PaletteContentStyle.LabelTitlePanel:
		case PaletteContentStyle.LabelGroupBoxCaption:
			return _ribbonColors[69];
		case PaletteContentStyle.ContextMenuItemImage:
		case PaletteContentStyle.ContextMenuItemTextStandard:
		case PaletteContentStyle.ContextMenuItemTextAlternate:
		case PaletteContentStyle.ContextMenuItemShortcutText:
		case PaletteContentStyle.LabelNormalControl:
		case PaletteContentStyle.LabelBoldControl:
		case PaletteContentStyle.LabelItalicControl:
		case PaletteContentStyle.LabelTitleControl:
		case PaletteContentStyle.LabelCustom1:
		case PaletteContentStyle.LabelCustom2:
		case PaletteContentStyle.LabelCustom3:
			return _ribbonColors[0];
		case PaletteContentStyle.LabelToolTip:
		case PaletteContentStyle.LabelSuperTip:
		case PaletteContentStyle.LabelKeyTip:
			return _toolTipText;
		case PaletteContentStyle.ContextMenuHeading:
			return _ribbonColors[188];
		case PaletteContentStyle.ButtonStandalone:
		case PaletteContentStyle.ButtonAlternate:
		case PaletteContentStyle.ButtonCluster:
		case PaletteContentStyle.ButtonGallery:
		case PaletteContentStyle.ButtonCustom1:
		case PaletteContentStyle.ButtonCustom2:
		case PaletteContentStyle.ButtonCustom3:
		case PaletteContentStyle.TabHighProfile:
		case PaletteContentStyle.TabStandardProfile:
		case PaletteContentStyle.TabLowProfile:
		case PaletteContentStyle.TabOneNote:
		case PaletteContentStyle.TabDock:
		case PaletteContentStyle.TabCustom1:
		case PaletteContentStyle.TabCustom2:
		case PaletteContentStyle.TabCustom3:
			if (state != PaletteState.Normal)
			{
				return _ribbonColors[2];
			}
			return _ribbonColors[1];
		case PaletteContentStyle.TabDockAutoHidden:
			return _ribbonColors[1];
		case PaletteContentStyle.ButtonCalendarDay:
			if (state == PaletteState.Disabled)
			{
				return _disabledText2;
			}
			return Color.Black;
		case PaletteContentStyle.ButtonLowProfile:
		case PaletteContentStyle.ButtonButtonSpec:
		case PaletteContentStyle.ButtonBreadCrumb:
		case PaletteContentStyle.ButtonListItem:
		case PaletteContentStyle.ButtonCommand:
			switch (state)
			{
			case PaletteState.Normal:
				if (style == PaletteContentStyle.ButtonListItem)
				{
					return _ribbonColors[0];
				}
				return _ribbonColors[69];
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _ribbonColors[2];
			default:
				return _ribbonColors[1];
			}
		case PaletteContentStyle.ButtonForm:
		case PaletteContentStyle.ButtonFormClose:
			switch (state)
			{
			case PaletteState.Tracking:
			case PaletteState.CheckedTracking:
				return _ribbonColors[61];
			case PaletteState.Pressed:
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedPressed:
				return _ribbonColors[62];
			default:
				return _ribbonColors[60];
			}
		case PaletteContentStyle.ButtonInputControl:
			if (state != PaletteState.Disabled)
			{
				return _ribbonColors[183];
			}
			return _ribbonColors[185];
		case PaletteContentStyle.ButtonNavigatorStack:
		case PaletteContentStyle.ButtonNavigatorOverflow:
		case PaletteContentStyle.ButtonNavigatorMini:
			if (state != PaletteState.Normal)
			{
				return _ribbonColors[218];
			}
			return _ribbonColors[1];
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
				return _ribbonColors[51];
			}
			return _ribbonColors[50];
		}
		if (state == PaletteState.Disabled && style != PaletteContentStyle.LabelToolTip && style != PaletteContentStyle.LabelSuperTip && style != PaletteContentStyle.LabelKeyTip && style != PaletteContentStyle.InputControlStandalone && style != PaletteContentStyle.InputControlRibbon && style != PaletteContentStyle.InputControlCustom1 && style != PaletteContentStyle.ButtonInputControl && style != PaletteContentStyle.ButtonCalendarDay)
		{
			return _disabledText;
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
			return _gridTextColor;
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderSecondary:
		case PaletteContentStyle.HeaderDockInactive:
		case PaletteContentStyle.HeaderCustom1:
		case PaletteContentStyle.HeaderCustom2:
			return _ribbonColors[20];
		case PaletteContentStyle.HeaderDockActive:
			return Color.Black;
		case PaletteContentStyle.InputControlStandalone:
		case PaletteContentStyle.InputControlRibbon:
		case PaletteContentStyle.InputControlCustom1:
			if (state == PaletteState.Disabled)
			{
				return _ribbonColors[177];
			}
			return _ribbonColors[176];
		case PaletteContentStyle.LabelNormalPanel:
		case PaletteContentStyle.LabelBoldPanel:
		case PaletteContentStyle.LabelItalicPanel:
		case PaletteContentStyle.LabelTitlePanel:
		case PaletteContentStyle.LabelGroupBoxCaption:
			return _ribbonColors[69];
		case PaletteContentStyle.ContextMenuItemImage:
		case PaletteContentStyle.ContextMenuItemTextStandard:
		case PaletteContentStyle.ContextMenuItemTextAlternate:
		case PaletteContentStyle.ContextMenuItemShortcutText:
		case PaletteContentStyle.LabelNormalControl:
		case PaletteContentStyle.LabelBoldControl:
		case PaletteContentStyle.LabelItalicControl:
		case PaletteContentStyle.LabelTitleControl:
		case PaletteContentStyle.LabelCustom1:
		case PaletteContentStyle.LabelCustom2:
		case PaletteContentStyle.LabelCustom3:
			return _ribbonColors[0];
		case PaletteContentStyle.LabelToolTip:
		case PaletteContentStyle.LabelSuperTip:
		case PaletteContentStyle.LabelKeyTip:
			return _toolTipText;
		case PaletteContentStyle.ContextMenuHeading:
			return _ribbonColors[188];
		case PaletteContentStyle.ButtonStandalone:
		case PaletteContentStyle.ButtonAlternate:
		case PaletteContentStyle.ButtonCluster:
		case PaletteContentStyle.ButtonGallery:
		case PaletteContentStyle.ButtonCustom1:
		case PaletteContentStyle.ButtonCustom2:
		case PaletteContentStyle.ButtonCustom3:
		case PaletteContentStyle.TabHighProfile:
		case PaletteContentStyle.TabStandardProfile:
		case PaletteContentStyle.TabLowProfile:
		case PaletteContentStyle.TabOneNote:
		case PaletteContentStyle.TabDock:
		case PaletteContentStyle.TabCustom1:
		case PaletteContentStyle.TabCustom2:
		case PaletteContentStyle.TabCustom3:
			if (state != PaletteState.Normal)
			{
				return _ribbonColors[2];
			}
			return _ribbonColors[1];
		case PaletteContentStyle.TabDockAutoHidden:
			return _ribbonColors[1];
		case PaletteContentStyle.ButtonCalendarDay:
			if (state == PaletteState.Disabled)
			{
				return _disabledText2;
			}
			return Color.Black;
		case PaletteContentStyle.ButtonLowProfile:
		case PaletteContentStyle.ButtonButtonSpec:
		case PaletteContentStyle.ButtonBreadCrumb:
		case PaletteContentStyle.ButtonListItem:
		case PaletteContentStyle.ButtonCommand:
			switch (state)
			{
			case PaletteState.Normal:
				if (style == PaletteContentStyle.ButtonListItem)
				{
					return _ribbonColors[0];
				}
				return _ribbonColors[69];
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _ribbonColors[2];
			default:
				return _ribbonColors[1];
			}
		case PaletteContentStyle.ButtonForm:
		case PaletteContentStyle.ButtonFormClose:
			switch (state)
			{
			case PaletteState.Tracking:
			case PaletteState.CheckedTracking:
				return _ribbonColors[61];
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				return _ribbonColors[62];
			default:
				return _ribbonColors[60];
			}
		case PaletteContentStyle.ButtonInputControl:
			if (state != PaletteState.Disabled)
			{
				return _ribbonColors[184];
			}
			return _ribbonColors[186];
		case PaletteContentStyle.ButtonNavigatorStack:
		case PaletteContentStyle.ButtonNavigatorOverflow:
		case PaletteContentStyle.ButtonNavigatorMini:
			if (state != PaletteState.Normal)
			{
				return _ribbonColors[218];
			}
			return _ribbonColors[1];
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
		case PaletteContentStyle.ButtonCalendarDay:
			return _calendarFont;
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
		case PaletteContentStyle.ButtonCalendarDay:
			return PaletteRelativeAlign.Far;
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
				return _ribbonColors[53];
			}
			return _ribbonColors[52];
		}
		if (state == PaletteState.Disabled && style != PaletteContentStyle.LabelToolTip && style != PaletteContentStyle.LabelSuperTip && style != PaletteContentStyle.LabelKeyTip && style != PaletteContentStyle.InputControlStandalone && style != PaletteContentStyle.InputControlRibbon && style != PaletteContentStyle.InputControlCustom1 && style != PaletteContentStyle.ButtonInputControl)
		{
			return _disabledText;
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
			return _gridTextColor;
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderSecondary:
		case PaletteContentStyle.HeaderDockInactive:
		case PaletteContentStyle.HeaderCustom1:
		case PaletteContentStyle.HeaderCustom2:
			return _ribbonColors[20];
		case PaletteContentStyle.HeaderDockActive:
			return Color.Black;
		case PaletteContentStyle.InputControlStandalone:
		case PaletteContentStyle.InputControlRibbon:
		case PaletteContentStyle.InputControlCustom1:
			if (state == PaletteState.Disabled)
			{
				return _ribbonColors[177];
			}
			return _ribbonColors[176];
		case PaletteContentStyle.LabelNormalPanel:
		case PaletteContentStyle.LabelBoldPanel:
		case PaletteContentStyle.LabelItalicPanel:
		case PaletteContentStyle.LabelTitlePanel:
		case PaletteContentStyle.LabelGroupBoxCaption:
			return _ribbonColors[69];
		case PaletteContentStyle.ContextMenuItemImage:
		case PaletteContentStyle.ContextMenuItemTextStandard:
		case PaletteContentStyle.ContextMenuItemTextAlternate:
		case PaletteContentStyle.ContextMenuItemShortcutText:
		case PaletteContentStyle.LabelNormalControl:
		case PaletteContentStyle.LabelBoldControl:
		case PaletteContentStyle.LabelItalicControl:
		case PaletteContentStyle.LabelTitleControl:
		case PaletteContentStyle.LabelCustom1:
		case PaletteContentStyle.LabelCustom2:
		case PaletteContentStyle.LabelCustom3:
			return _ribbonColors[0];
		case PaletteContentStyle.LabelToolTip:
		case PaletteContentStyle.LabelSuperTip:
		case PaletteContentStyle.LabelKeyTip:
			return _toolTipText;
		case PaletteContentStyle.ContextMenuHeading:
			return _ribbonColors[188];
		case PaletteContentStyle.ButtonStandalone:
		case PaletteContentStyle.ButtonAlternate:
		case PaletteContentStyle.ButtonCluster:
		case PaletteContentStyle.ButtonGallery:
		case PaletteContentStyle.ButtonCustom1:
		case PaletteContentStyle.ButtonCustom2:
		case PaletteContentStyle.ButtonCustom3:
		case PaletteContentStyle.TabHighProfile:
		case PaletteContentStyle.TabStandardProfile:
		case PaletteContentStyle.TabLowProfile:
		case PaletteContentStyle.TabOneNote:
		case PaletteContentStyle.TabDock:
		case PaletteContentStyle.TabCustom1:
		case PaletteContentStyle.TabCustom2:
		case PaletteContentStyle.TabCustom3:
			if (state != PaletteState.Normal)
			{
				return _ribbonColors[2];
			}
			return _ribbonColors[1];
		case PaletteContentStyle.TabDockAutoHidden:
			return _ribbonColors[1];
		case PaletteContentStyle.ButtonLowProfile:
		case PaletteContentStyle.ButtonButtonSpec:
		case PaletteContentStyle.ButtonBreadCrumb:
		case PaletteContentStyle.ButtonCalendarDay:
		case PaletteContentStyle.ButtonListItem:
		case PaletteContentStyle.ButtonCommand:
			switch (state)
			{
			case PaletteState.Normal:
				if (style == PaletteContentStyle.ButtonListItem)
				{
					return _ribbonColors[0];
				}
				return _ribbonColors[69];
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _ribbonColors[2];
			default:
				return _ribbonColors[1];
			}
		case PaletteContentStyle.ButtonForm:
		case PaletteContentStyle.ButtonFormClose:
			switch (state)
			{
			case PaletteState.Tracking:
			case PaletteState.CheckedTracking:
				return _ribbonColors[61];
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				return _ribbonColors[62];
			default:
				return _ribbonColors[60];
			}
		case PaletteContentStyle.ButtonInputControl:
			if (state != PaletteState.Disabled)
			{
				return _ribbonColors[183];
			}
			return _ribbonColors[185];
		case PaletteContentStyle.ButtonNavigatorStack:
		case PaletteContentStyle.ButtonNavigatorOverflow:
		case PaletteContentStyle.ButtonNavigatorMini:
			if (state != PaletteState.Normal)
			{
				return _ribbonColors[218];
			}
			return _ribbonColors[1];
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
				return _ribbonColors[53];
			}
			return _ribbonColors[52];
		}
		if (state == PaletteState.Disabled && style != PaletteContentStyle.LabelToolTip && style != PaletteContentStyle.LabelSuperTip && style != PaletteContentStyle.LabelKeyTip && style != PaletteContentStyle.InputControlStandalone && style != PaletteContentStyle.InputControlRibbon && style != PaletteContentStyle.InputControlCustom1 && style != PaletteContentStyle.ButtonInputControl)
		{
			return _disabledText;
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
			return _gridTextColor;
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderSecondary:
		case PaletteContentStyle.HeaderDockInactive:
		case PaletteContentStyle.HeaderCustom1:
		case PaletteContentStyle.HeaderCustom2:
			return _ribbonColors[20];
		case PaletteContentStyle.HeaderDockActive:
			return Color.Black;
		case PaletteContentStyle.InputControlStandalone:
		case PaletteContentStyle.InputControlRibbon:
		case PaletteContentStyle.InputControlCustom1:
			if (state == PaletteState.Disabled)
			{
				return _ribbonColors[177];
			}
			return _ribbonColors[176];
		case PaletteContentStyle.LabelNormalPanel:
		case PaletteContentStyle.LabelBoldPanel:
		case PaletteContentStyle.LabelItalicPanel:
		case PaletteContentStyle.LabelTitlePanel:
		case PaletteContentStyle.LabelGroupBoxCaption:
			return _ribbonColors[69];
		case PaletteContentStyle.ContextMenuItemImage:
		case PaletteContentStyle.ContextMenuItemTextStandard:
		case PaletteContentStyle.ContextMenuItemTextAlternate:
		case PaletteContentStyle.ContextMenuItemShortcutText:
		case PaletteContentStyle.LabelNormalControl:
		case PaletteContentStyle.LabelBoldControl:
		case PaletteContentStyle.LabelItalicControl:
		case PaletteContentStyle.LabelTitleControl:
		case PaletteContentStyle.LabelCustom1:
		case PaletteContentStyle.LabelCustom2:
		case PaletteContentStyle.LabelCustom3:
			return _ribbonColors[0];
		case PaletteContentStyle.LabelToolTip:
		case PaletteContentStyle.LabelSuperTip:
		case PaletteContentStyle.LabelKeyTip:
			return _toolTipText;
		case PaletteContentStyle.ContextMenuHeading:
			return _ribbonColors[188];
		case PaletteContentStyle.ButtonStandalone:
		case PaletteContentStyle.ButtonAlternate:
		case PaletteContentStyle.ButtonCluster:
		case PaletteContentStyle.ButtonGallery:
		case PaletteContentStyle.ButtonCustom1:
		case PaletteContentStyle.ButtonCustom2:
		case PaletteContentStyle.ButtonCustom3:
		case PaletteContentStyle.TabHighProfile:
		case PaletteContentStyle.TabStandardProfile:
		case PaletteContentStyle.TabLowProfile:
		case PaletteContentStyle.TabOneNote:
		case PaletteContentStyle.TabDock:
		case PaletteContentStyle.TabCustom1:
		case PaletteContentStyle.TabCustom2:
		case PaletteContentStyle.TabCustom3:
			if (state != PaletteState.Normal)
			{
				return _ribbonColors[2];
			}
			return _ribbonColors[1];
		case PaletteContentStyle.TabDockAutoHidden:
			return _ribbonColors[1];
		case PaletteContentStyle.ButtonLowProfile:
		case PaletteContentStyle.ButtonButtonSpec:
		case PaletteContentStyle.ButtonBreadCrumb:
		case PaletteContentStyle.ButtonCalendarDay:
		case PaletteContentStyle.ButtonListItem:
		case PaletteContentStyle.ButtonCommand:
			switch (state)
			{
			case PaletteState.Normal:
				if (style == PaletteContentStyle.ButtonListItem)
				{
					return _ribbonColors[0];
				}
				return _ribbonColors[69];
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return _ribbonColors[2];
			default:
				return _ribbonColors[1];
			}
		case PaletteContentStyle.ButtonForm:
		case PaletteContentStyle.ButtonFormClose:
			switch (state)
			{
			case PaletteState.Tracking:
			case PaletteState.CheckedTracking:
				return _ribbonColors[61];
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				return _ribbonColors[62];
			default:
				return _ribbonColors[60];
			}
		case PaletteContentStyle.ButtonInputControl:
			if (state != PaletteState.Disabled)
			{
				return _ribbonColors[184];
			}
			return _ribbonColors[186];
		case PaletteContentStyle.ButtonNavigatorStack:
		case PaletteContentStyle.ButtonNavigatorOverflow:
		case PaletteContentStyle.ButtonNavigatorMini:
			if (state != PaletteState.Normal)
			{
				return _ribbonColors[218];
			}
			return _ribbonColors[1];
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
		case PaletteContentStyle.HeaderDockInactive:
		case PaletteContentStyle.HeaderDockActive:
			return _contentPaddingDock;
		case PaletteContentStyle.HeaderSecondary:
			return _contentPaddingHeader2;
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
		case PaletteContentStyle.ButtonForm:
		case PaletteContentStyle.ButtonFormClose:
			return _contentPaddingButtonForm;
		case PaletteContentStyle.ButtonGallery:
			return _contentPaddingButtonGallery;
		case PaletteContentStyle.ButtonListItem:
			return _contentPaddingButtonListItem;
		case PaletteContentStyle.ButtonBreadCrumb:
			return _contentPaddingButton6;
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
		switch (metric)
		{
		case PaletteMetricBool.HeaderGroupOverlay:
		case PaletteMetricBool.SplitWithFading:
		case PaletteMetricBool.RibbonTabsSpareCaption:
			return InheritBool.True;
		case PaletteMetricBool.TreeViewLines:
			return InheritBool.False;
		default:
			Debug.Assert(condition: false);
			return InheritBool.Inherit;
		}
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
		case PaletteMetricPadding.HeaderGroupPaddingPrimary:
		case PaletteMetricPadding.HeaderGroupPaddingSecondary:
		case PaletteMetricPadding.HeaderGroupPaddingDockInactive:
		case PaletteMetricPadding.HeaderGroupPaddingDockActive:
		case PaletteMetricPadding.SeparatorPaddingLowProfile:
		case PaletteMetricPadding.SeparatorPaddingHighProfile:
		case PaletteMetricPadding.SeparatorPaddingHighInternalProfile:
		case PaletteMetricPadding.SeparatorPaddingCustom1:
		case PaletteMetricPadding.ContextMenuItemHighlight:
		case PaletteMetricPadding.ContextMenuItemsCollection:
		case PaletteMetricPadding.ContextMenuItemOuter:
			return Padding.Empty;
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
		return _disabledDropDown;
	}

	public override Image GetContextMenuCheckedImage()
	{
		return _contextMenuChecked;
	}

	public override Image GetContextMenuIndeterminateImage()
	{
		return _contextMenuIndeterminate;
	}

	public override Image GetGalleryButtonImage(PaletteRibbonGalleryButton button, PaletteState state)
	{
		return button switch
		{
			PaletteRibbonGalleryButton.Up => _galleryButtonList.Images[1], 
			PaletteRibbonGalleryButton.DropDown => _galleryButtonList.Images[2], 
			_ => _galleryButtonList.Images[0], 
		};
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
			return Color.Black;
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
		return PaletteRibbonShape.Office2010;
	}

	public override PaletteRelativeAlign GetRibbonContextTextAlign(PaletteState state)
	{
		return PaletteRelativeAlign.Center;
	}

	public override Font GetRibbonContextTextFont(PaletteState state)
	{
		return _ribbonTabContextFont;
	}

	public override Color GetRibbonContextTextColor(PaletteState state)
	{
		return _contextTextColor;
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
		return _ribbonColors[213];
	}

	public override Color GetRibbonDropArrowDark(PaletteState state)
	{
		return _ribbonColors[214];
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
		return _contextTabSeparator;
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
			return PaletteRibbonColorStyle.RibbonQATFullbarSquare;
		case PaletteRibbonBackStyle.RibbonQATOverflow:
			return PaletteRibbonColorStyle.RibbonQATOverflow;
		case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBorder:
			return PaletteRibbonColorStyle.LinearBorder;
		case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBack:
			if (state == PaletteState.Pressed)
			{
				return PaletteRibbonColorStyle.Empty;
			}
			return PaletteRibbonColorStyle.Linear;
		case PaletteRibbonBackStyle.RibbonGroupNormalBorder:
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBorder:
			switch (state)
			{
			case PaletteState.Normal:
			case PaletteState.ContextNormal:
				return PaletteRibbonColorStyle.RibbonGroupNormalBorderSep;
			case PaletteState.Tracking:
			case PaletteState.ContextTracking:
				return PaletteRibbonColorStyle.RibbonGroupNormalBorderSepTrackingLight;
			case PaletteState.Pressed:
			case PaletteState.ContextPressed:
				return PaletteRibbonColorStyle.RibbonGroupNormalBorderSepPressedLight;
			}
			Debug.Assert(condition: false);
			break;
		case PaletteRibbonBackStyle.RibbonGroupNormalTitle:
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBack:
			return PaletteRibbonColorStyle.Empty;
		case PaletteRibbonBackStyle.RibbonGroupArea:
			switch (state)
			{
			case PaletteState.Normal:
			case PaletteState.CheckedNormal:
				return PaletteRibbonColorStyle.RibbonGroupAreaBorder3;
			case PaletteState.ContextCheckedNormal:
				return PaletteRibbonColorStyle.RibbonGroupAreaBorder4;
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
			case PaletteState.Pressed:
			case PaletteState.ContextTracking:
				return PaletteRibbonColorStyle.RibbonTabTracking2010;
			case PaletteState.FocusOverride:
				return PaletteRibbonColorStyle.RibbonTabFocus2010;
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
			case PaletteState.ContextCheckedNormal:
			case PaletteState.ContextCheckedTracking:
				return PaletteRibbonColorStyle.RibbonTabSelected2010;
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
				PaletteState.Tracking => _ribbonColors[204], 
				_ => _ribbonColors[203], 
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
			return _ribbonColors[120];
		case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBack:
			return _ribbonColors[122];
		case PaletteRibbonBackStyle.RibbonGroupNormalTitle:
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBack:
			return Color.Empty;
		case PaletteRibbonBackStyle.RibbonGroupNormalBorder:
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBorder:
			switch (state)
			{
			case PaletteState.Normal:
			case PaletteState.Tracking:
			case PaletteState.Pressed:
			case PaletteState.ContextNormal:
			case PaletteState.ContextTracking:
			case PaletteState.ContextPressed:
				return _ribbonColors[90];
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
			if (state == PaletteState.ContextCheckedNormal)
			{
				return Color.Empty;
			}
			return _ribbonColors[85];
		case PaletteRibbonBackStyle.RibbonTab:
			switch (state)
			{
			case PaletteState.Tracking:
			case PaletteState.Pressed:
			case PaletteState.ContextTracking:
				return _ribbonColors[77];
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
			case PaletteState.ContextCheckedNormal:
			case PaletteState.ContextCheckedTracking:
				return _ribbonColors[72];
			case PaletteState.FocusOverride:
				return _contextCheckedTabBorder1;
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
			return _ribbonColors[121];
		case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBack:
			return _ribbonColors[123];
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
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBorder:
			switch (state)
			{
			case PaletteState.Normal:
			case PaletteState.Tracking:
			case PaletteState.Pressed:
			case PaletteState.ContextNormal:
			case PaletteState.ContextTracking:
			case PaletteState.ContextPressed:
				return _ribbonColors[91];
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
			case PaletteState.Pressed:
			case PaletteState.ContextTracking:
				return _ribbonColors[78];
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
			case PaletteState.ContextCheckedNormal:
			case PaletteState.ContextCheckedTracking:
				return _ribbonColors[73];
			case PaletteState.FocusOverride:
				return _contextCheckedTabBorder2;
			case PaletteState.Normal:
				return Color.Empty;
			}
			Debug.Assert(condition: false);
			break;
		case PaletteRibbonBackStyle.RibbonAppMenuDocs:
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBack:
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
		case PaletteRibbonBackStyle.RibbonGroupNormalBorder:
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBorder:
			return _ribbonColors[209];
		case PaletteRibbonBackStyle.RibbonAppMenuInner:
		case PaletteRibbonBackStyle.RibbonAppMenuDocs:
		case PaletteRibbonBackStyle.RibbonGroupNormalTitle:
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBack:
		case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBack:
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
			case PaletteState.ContextTracking:
				return _ribbonColors[207];
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
			case PaletteState.ContextCheckedNormal:
			case PaletteState.ContextCheckedTracking:
				return _ribbonColors[74];
			case PaletteState.FocusOverride:
				return _contextCheckedTabBorder3;
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
		case PaletteRibbonBackStyle.RibbonGroupNormalBorder:
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBorder:
			return _ribbonColors[210];
		case PaletteRibbonBackStyle.RibbonAppMenuInner:
		case PaletteRibbonBackStyle.RibbonAppMenuOuter:
		case PaletteRibbonBackStyle.RibbonAppMenuDocs:
		case PaletteRibbonBackStyle.RibbonGroupNormalTitle:
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBack:
		case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBack:
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
			case PaletteState.ContextTracking:
				return _ribbonColors[208];
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
			case PaletteState.ContextCheckedNormal:
			case PaletteState.ContextCheckedTracking:
				return _ribbonColors[75];
			case PaletteState.FocusOverride:
				return _contextCheckedTabBorder4;
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

	public override Color GetRibbonBackColor5(PaletteRibbonBackStyle style, PaletteState state)
	{
		switch (style)
		{
		case PaletteRibbonBackStyle.RibbonAppMenuInner:
		case PaletteRibbonBackStyle.RibbonAppMenuOuter:
		case PaletteRibbonBackStyle.RibbonAppMenuDocs:
		case PaletteRibbonBackStyle.RibbonGroupNormalTitle:
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBack:
		case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBack:
		case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBorder:
		case PaletteRibbonBackStyle.RibbonQATFullbar:
		case PaletteRibbonBackStyle.RibbonQATOverflow:
		case PaletteRibbonBackStyle.RibbonGalleryBack:
		case PaletteRibbonBackStyle.RibbonGalleryBorder:
			return Color.Empty;
		case PaletteRibbonBackStyle.RibbonGroupNormalBorder:
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBorder:
			return _ribbonColors[211];
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
			return _ribbonColors[89];
		case PaletteRibbonBackStyle.RibbonTab:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledText;
			case PaletteState.Pressed:
				return _ribbonColors[78];
			case PaletteState.Normal:
			case PaletteState.Tracking:
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
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
		case PaletteRibbonTextStyle.RibbonGroupNormalTitle:
			if (state == PaletteState.Disabled)
			{
				return _disabledText;
			}
			return _ribbonColors[212];
		case PaletteRibbonTextStyle.RibbonTab:
			switch (state)
			{
			case PaletteState.Disabled:
				return _disabledText;
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
			case PaletteState.ContextCheckedNormal:
			case PaletteState.ContextCheckedTracking:
			case PaletteState.FocusOverride:
				return _ribbonColors[71];
			default:
				return _ribbonColors[70];
			}
		case PaletteRibbonTextStyle.RibbonGroupCollapsedText:
			return _ribbonColors[126];
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
			if (state == PaletteState.Disabled)
			{
				return Color.Empty;
			}
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
				return ControlPaint.Light(_ribbonColors[3]);
			case PaletteState.Normal:
				return _ribbonColors[3];
			case PaletteState.Tracking:
			case PaletteState.FocusOverride:
				return _buttonBorderColors[1];
			case PaletteState.Pressed:
				return _buttonBorderColors[3];
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
			return state switch
			{
				PaletteState.Disabled => ControlPaint.LightLight(_ribbonColors[5]), 
				PaletteState.Normal => ControlPaint.Light(_ribbonColors[5]), 
				PaletteState.Tracking => ControlPaint.Light(_buttonBackColors[2]), 
				PaletteState.Pressed => ControlPaint.Light(_buttonBackColors[4]), 
				_ => throw new ArgumentOutOfRangeException("state"), 
			};
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
				return ControlPaint.LightLight(_ribbonColors[5]);
			case PaletteState.Normal:
				return _ribbonColors[5];
			case PaletteState.Tracking:
			case PaletteState.FocusOverride:
				return _buttonBackColors[2];
			case PaletteState.Pressed:
				return _buttonBackColors[4];
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
				return ControlPaint.LightLight(_ribbonColors[5]);
			case PaletteState.Normal:
				return _ribbonColors[6];
			case PaletteState.Tracking:
			case PaletteState.FocusOverride:
				return _buttonBackColors[3];
			case PaletteState.Pressed:
				return _buttonBackColors[5];
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
		if (_ribbonTabContextFont != null)
		{
			_ribbonTabContextFont.Dispose();
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
		_buttonFontNavigatorMini = new Font(baseFontName, baseFontSize + 3f, FontStyle.Bold);
		_tabFontNormal = new Font(baseFontName, baseFontSize, FontStyle.Regular);
		_tabFontSelected = new Font(_tabFontNormal, FontStyle.Bold);
		_ribbonTabFont = new Font(baseFontName, baseFontSize, FontStyle.Regular);
		_ribbonTabContextFont = new Font(_ribbonTabFont, FontStyle.Bold);
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
