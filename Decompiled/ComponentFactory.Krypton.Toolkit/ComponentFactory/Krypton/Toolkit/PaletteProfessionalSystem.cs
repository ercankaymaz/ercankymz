#define DEBUG
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit.Properties;
using Microsoft.Win32;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteProfessionalSystem : PaletteBase
{
	private static readonly Padding _contentPaddingGrid = new Padding(2, 1, 2, 1);

	private static readonly Padding _contentPaddingHeader1 = new Padding(3, 2, 3, 2);

	private static readonly Padding _contentPaddingHeader2 = new Padding(3, 2, 3, 2);

	private static readonly Padding _contentPaddingHeader3 = new Padding(2, 1, 2, 1);

	private static readonly Padding _contentPaddingCalendar = new Padding(2);

	private static readonly Padding _contentPaddingHeaderForm = new Padding(5, 1, 3, 1);

	private static readonly Padding _contentPaddingLabel = new Padding(3, 2, 3, 2);

	private static readonly Padding _contentPaddingLabel2 = new Padding(8, 2, 8, 2);

	private static readonly Padding _contentPaddingButtonCalendar = new Padding(0);

	private static readonly Padding _contentPaddingButtonInputControl = new Padding(1);

	private static readonly Padding _contentPaddingButton12 = new Padding(3, 2, 3, 2);

	private static readonly Padding _contentPaddingButton3 = new Padding(1, 1, 1, 1);

	private static readonly Padding _contentPaddingButton4 = new Padding(4, 3, 4, 3);

	private static readonly Padding _contentPaddingButton5 = new Padding(3, 3, 3, 2);

	private static readonly Padding _contentPaddingButton6 = new Padding(3);

	private static readonly Padding _contentPaddingButton7 = new Padding(1, 1, 3, 1);

	private static readonly Padding _contentPaddingButtonForm = new Padding(5, 5, 5, 5);

	private static readonly Padding _contentPaddingButtonGallery = new Padding(1, 0, 1, 0);

	private static readonly Padding _contentPaddingToolTip = new Padding(2, 2, 2, 2);

	private static readonly Padding _contentPaddingSuperTip = new Padding(4, 4, 4, 4);

	private static readonly Padding _contentPaddingKeyTip = new Padding(1, -1, 0, -2);

	private static readonly Padding _contentPaddingContextMenuHeading = new Padding(8, 2, 8, 0);

	private static readonly Padding _contentPaddingContextMenuImage = new Padding(1);

	private static readonly Padding _contentPaddingContextMenuItemText = new Padding(9, 1, 7, 0);

	private static readonly Padding _contentPaddingContextMenuItemTextAlt = new Padding(7, 1, 6, 0);

	private static readonly Padding _contentPaddingContextMenuItemShortcutText = new Padding(3, 1, 4, 0);

	private static readonly Padding _metricPaddingInputControl = new Padding(0, 1, 0, 1);

	private static readonly Padding _metricPaddingRibbon = new Padding(0, 1, 1, 1);

	private static readonly Padding _metricPaddingRibbonAppButton = new Padding(3, 0, 3, 0);

	private static readonly Padding _metricPaddingHeader = new Padding(0, 3, 1, 3);

	private static readonly Padding _metricPaddingHeaderForm = new Padding(0, 0, 0, 0);

	private static readonly Padding _metricPaddingBarInside = new Padding(3, 3, 3, 3);

	private static readonly Padding _metricPaddingBarTabs = new Padding(0, 0, 0, 0);

	private static readonly Padding _metricPaddingBarOutside = new Padding(0, 0, 0, 3);

	private static readonly Padding _metricPaddingPageButtons = new Padding(1, 3, 1, 3);

	private static readonly Padding _metricPaddingContextMenuItemHighlight = new Padding(1, 0, 1, 0);

	private static readonly Padding _metricPaddingContextMenuItemsCollection = new Padding(0, 1, 0, 1);

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

	private static readonly Image _buttonSpecWorkspaceMaximize = Resources.ProfessionalMaximize;

	private static readonly Image _buttonSpecWorkspaceRestore = Resources.ProfessionalRestore;

	private static readonly Image _buttonSpecRibbonMinimize = Resources.RibbonUp2010;

	private static readonly Image _buttonSpecRibbonExpand = Resources.RibbonDown2010;

	private static readonly Image _systemCloseA = Resources.ProfessionalButtonCloseA;

	private static readonly Image _systemCloseI = Resources.ProfessionalButtonCloseI;

	private static readonly Image _systemMaxA = Resources.ProfessionalButtonMaxA;

	private static readonly Image _systemMaxI = Resources.ProfessionalButtonMaxI;

	private static readonly Image _systemMinA = Resources.ProfessionalButtonMinA;

	private static readonly Image _systemMinI = Resources.ProfessionalButtonMinI;

	private static readonly Image _systemRestoreA = Resources.ProfessionalButtonRestoreA;

	private static readonly Image _systemRestoreI = Resources.ProfessionalButtonRestoreI;

	private static readonly Image _pendantCloseA = Resources.ProfessionalPendantCloseA;

	private static readonly Image _pendantCloseI = Resources.ProfessionalPendantCloseI;

	private static readonly Image _pendantMinA = Resources.ProfessionalPendantMinA;

	private static readonly Image _pendantMinI = Resources.ProfessionalPendantMinI;

	private static readonly Image _pendantRestoreA = Resources.ProfessionalPendantRestoreA;

	private static readonly Image _pendantRestoreI = Resources.ProfessionalPendantRestoreI;

	private static readonly Image _pendantExpandA = Resources.ProfessionalPendantExpandA;

	private static readonly Image _pendantExpandI = Resources.ProfessionalPendantExpandI;

	private static readonly Image _pendantMinimizeA = Resources.ProfessionalPendantMinimizeA;

	private static readonly Image _pendantMinimizeI = Resources.ProfessionalPendantMinimizeI;

	private static readonly Image _contextMenuChecked = Resources.SystemChecked;

	private static readonly Image _contextMenuIndeterminate = Resources.SystemIndeterminate;

	private static readonly Image _contextMenuSubMenu = Resources.SystemContextMenuSub;

	private static readonly Image _treeExpandPlus = Resources.TreeExpandPlus;

	private static readonly Image _treeCollapseMinus = Resources.TreeCollapseMinus;

	private static readonly Color _contextTextColor = Color.White;

	private static readonly Color _lightGray = Color.FromArgb(242, 242, 242);

	private static readonly Color _contextCheckedTabBorder1 = Color.FromArgb(223, 119, 0);

	private static readonly Color _contextCheckedTabBorder2 = Color.FromArgb(230, 190, 129);

	private static readonly Color _contextCheckedTabBorder3 = Color.FromArgb(220, 202, 171);

	private static readonly Color _contextCheckedTabBorder4 = Color.FromArgb(255, 252, 247);

	private KryptonProfessionalKCT _table;

	private Font _header1ShortFont;

	private Font _header2ShortFont;

	private Font _header1LongFont;

	private Font _header2LongFont;

	private Font _superToolFont;

	private Font _headerFormFont;

	private Font _buttonFont;

	private Font _buttonFontNavigatorMini;

	private Font _tabFontNormal;

	private Font _tabFontSelected;

	private Font _gridFont;

	private Font _calendarFont;

	private Font _calendarBoldFont;

	private Font _boldFont;

	private Font _italicFont;

	private Image _disabledDropDownImage;

	private Image _normalDropDownImage;

	private Color _disabledDropDownColor;

	private Color _normalDropDownColor;

	private Color[] _ribbonColors;

	private Color _disabledText;

	private Color _disabledGlyphDark;

	private Color _disabledGlyphLight;

	private Color _contextCheckedTabBorder;

	private Color _contextCheckedTabFill;

	private Color _contextGroupAreaBorder;

	private Color _contextGroupAreaInside;

	private Color _contextGroupFrameTop;

	private Color _contextGroupFrameBottom;

	private Color _contextTabSeparator;

	private Color _focusTabFill;

	private Color _toolTipBack1;

	private Color _toolTipBack2;

	private Color _toolTipBorder;

	private Color _toolTipText;

	private Color[] _ribbonGroupCollapsedBackContext;

	private Color[] _ribbonGroupCollapsedBackContextTracking;

	private Color[] _ribbonGroupCollapsedBorderContext;

	private Color[] _ribbonGroupCollapsedBorderContextTracking;

	private Color[] _appButtonNormal;

	private Color[] _appButtonTrack;

	private Color[] _appButtonPressed;

	private Image _galleryImageUp;

	private Image _galleryImageDown;

	private Image _galleryImageDropDown;

	public override KryptonColorTable ColorTable => Table;

	internal KryptonProfessionalKCT Table
	{
		get
		{
			if (_table == null)
			{
				_table = GenerateColorTable();
			}
			return _table;
		}
	}

	public PaletteProfessionalSystem()
	{
		DefineFonts();
		DefineRibbonColors();
	}

	public override InheritBool GetAllowFormChrome()
	{
		return InheritBool.False;
	}

	public override IRenderer GetRenderer()
	{
		return KryptonManager.RenderProfessional;
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
		case PaletteBackStyle.ButtonInputControl:
		case PaletteBackStyle.ContextMenuItemImage:
		case PaletteBackStyle.ContextMenuItemHighlight:
			if (state == PaletteState.Normal || state == PaletteState.NormalDefaultOverride)
			{
				return InheritBool.False;
			}
			return InheritBool.True;
		case PaletteBackStyle.ButtonLowProfile:
		case PaletteBackStyle.ButtonButtonSpec:
		case PaletteBackStyle.ButtonBreadCrumb:
		case PaletteBackStyle.ButtonCalendarDay:
		case PaletteBackStyle.ButtonNavigatorOverflow:
		case PaletteBackStyle.ButtonListItem:
		case PaletteBackStyle.ButtonCommand:
			if ((uint)(state - 1) <= 1u || state == PaletteState.NormalDefaultOverride)
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
		case PaletteBackStyle.GridHeaderColumnSheet:
		case PaletteBackStyle.GridHeaderRowSheet:
		case PaletteBackStyle.GridHeaderColumnCustom1:
		case PaletteBackStyle.GridHeaderRowCustom1:
			return state switch
			{
				PaletteState.Disabled => SystemColors.Control, 
				PaletteState.CheckedNormal => ColorTable.CheckBackground, 
				_ => ColorTable.MenuStripGradientBegin, 
			};
		case PaletteBackStyle.GridDataCellList:
		case PaletteBackStyle.GridDataCellSheet:
		case PaletteBackStyle.GridDataCellCustom1:
			if (state == PaletteState.CheckedNormal)
			{
				return ColorTable.ButtonPressedHighlight;
			}
			return SystemColors.Window;
		case PaletteBackStyle.FormMain:
		case PaletteBackStyle.FormCustom1:
			return ColorTable.MenuStripGradientBegin;
		case PaletteBackStyle.HeaderForm:
			return Table.Header1Begin;
		case PaletteBackStyle.ControlGroupBox:
		case PaletteBackStyle.GridBackgroundList:
		case PaletteBackStyle.GridBackgroundSheet:
		case PaletteBackStyle.GridBackgroundCustom1:
		case PaletteBackStyle.PanelClient:
		case PaletteBackStyle.PanelRibbonInactive:
		case PaletteBackStyle.PanelCustom1:
		case PaletteBackStyle.SeparatorLowProfile:
		case PaletteBackStyle.SeparatorCustom1:
			return ColorTable.MenuStripGradientEnd;
		case PaletteBackStyle.PanelAlternate:
			return ColorTable.MenuStripGradientBegin;
		case PaletteBackStyle.ControlClient:
		case PaletteBackStyle.ControlAlternate:
		case PaletteBackStyle.ControlCustom1:
			return SystemColors.Window;
		case PaletteBackStyle.ContextMenuHeading:
			return ColorTable.OverflowButtonGradientBegin;
		case PaletteBackStyle.ContextMenuSeparator:
		case PaletteBackStyle.ContextMenuItemSplit:
			return state switch
			{
				PaletteState.Disabled => SystemColors.Control, 
				PaletteState.Tracking => ColorTable.ButtonSelectedBorder, 
				_ => ColorTable.MenuBorder, 
			};
		case PaletteBackStyle.ContextMenuItemImageColumn:
			return ColorTable.ImageMarginGradientBegin;
		case PaletteBackStyle.ContextMenuItemImage:
			return ColorTable.ButtonSelectedHighlight;
		case PaletteBackStyle.InputControlStandalone:
		case PaletteBackStyle.InputControlRibbon:
		case PaletteBackStyle.InputControlCustom1:
			if (state == PaletteState.Disabled)
			{
				return SystemColors.Control;
			}
			return SystemColors.Window;
		case PaletteBackStyle.ControlRibbon:
			return _ribbonColors[75];
		case PaletteBackStyle.ControlRibbonAppMenu:
			return _ribbonColors[190];
		case PaletteBackStyle.ContextMenuOuter:
		case PaletteBackStyle.ContextMenuInner:
			return ColorTable.ToolStripDropDownBackground;
		case PaletteBackStyle.HeaderPrimary:
		case PaletteBackStyle.HeaderCalendar:
		case PaletteBackStyle.HeaderCustom1:
		case PaletteBackStyle.HeaderCustom2:
		case PaletteBackStyle.SeparatorHighProfile:
		case PaletteBackStyle.SeparatorHighInternalProfile:
			if (state == PaletteState.Disabled)
			{
				return SystemColors.Control;
			}
			return Table.Header1Begin;
		case PaletteBackStyle.HeaderDockInactive:
			if (state == PaletteState.Disabled)
			{
				return SystemColors.Control;
			}
			return SystemColors.InactiveCaption;
		case PaletteBackStyle.HeaderDockActive:
			if (state == PaletteState.Disabled)
			{
				return SystemColors.Control;
			}
			return SystemColors.ActiveCaption;
		case PaletteBackStyle.HeaderSecondary:
			if (state == PaletteState.Disabled)
			{
				return SystemColors.Control;
			}
			return ColorTable.MenuStripGradientEnd;
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
				return SystemColors.Control;
			case PaletteState.Normal:
				if (style == PaletteBackStyle.TabLowProfile)
				{
					return Color.Empty;
				}
				return SystemColors.Window;
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				return style switch
				{
					PaletteBackStyle.TabLowProfile => Color.Empty, 
					PaletteBackStyle.TabHighProfile => ColorTable.ButtonPressedGradientMiddle, 
					_ => SystemColors.Window, 
				};
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				if (style == PaletteBackStyle.TabHighProfile)
				{
					return ColorTable.ButtonPressedGradientMiddle;
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
				return SystemColors.Control;
			case PaletteState.Normal:
				return SystemColors.Window;
			case PaletteState.Tracking:
			case PaletteState.Pressed:
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return SystemColors.Window;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.ControlToolTip:
			return _toolTipBack1;
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
		case PaletteBackStyle.ButtonListItem:
		case PaletteBackStyle.ButtonForm:
		case PaletteBackStyle.ButtonFormClose:
		case PaletteBackStyle.ButtonCommand:
		case PaletteBackStyle.ButtonCustom1:
		case PaletteBackStyle.ButtonCustom2:
		case PaletteBackStyle.ButtonCustom3:
			switch (state)
			{
			case PaletteState.Disabled:
				return SystemColors.Control;
			case PaletteState.Normal:
				return ColorTable.MenuStripGradientEnd;
			case PaletteState.CheckedNormal:
				return ColorTable.ButtonPressedGradientEnd;
			case PaletteState.NormalDefaultOverride:
				return ColorTable.MenuStripGradientBegin;
			case PaletteState.Tracking:
				return ColorTable.ButtonSelectedGradientBegin;
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				if (style == PaletteBackStyle.ButtonAlternate)
				{
					return ColorTable.SeparatorDark;
				}
				return ColorTable.ButtonPressedGradientBegin;
			case PaletteState.CheckedTracking:
				return ColorTable.ButtonPressedGradientBegin;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.ButtonCalendarDay:
			switch (state)
			{
			case PaletteState.Disabled:
				return SystemColors.Control;
			case PaletteState.Normal:
			case PaletteState.NormalDefaultOverride:
				return ColorTable.MenuStripGradientEnd;
			case PaletteState.CheckedNormal:
				return ColorTable.ButtonPressedGradientEnd;
			case PaletteState.Tracking:
				return ColorTable.ButtonSelectedGradientBegin;
			case PaletteState.Pressed:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return ColorTable.ButtonPressedGradientBegin;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.ButtonInputControl:
			switch (state)
			{
			case PaletteState.Disabled:
				return SystemColors.Control;
			case PaletteState.Normal:
				return ColorTable.MenuStripGradientEnd;
			case PaletteState.CheckedNormal:
				return ColorTable.MenuStripGradientEnd;
			case PaletteState.Tracking:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return ColorTable.ButtonSelectedGradientBegin;
			case PaletteState.Pressed:
				return ColorTable.ButtonPressedGradientBegin;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.ContextMenuItemHighlight:
			return state switch
			{
				PaletteState.Disabled => SystemColors.Control, 
				PaletteState.Normal => Color.Empty, 
				PaletteState.Tracking => ColorTable.MenuItemSelectedGradientBegin, 
				_ => throw new ArgumentOutOfRangeException("state"), 
			};
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
		case PaletteBackStyle.GridHeaderColumnSheet:
		case PaletteBackStyle.GridHeaderRowSheet:
		case PaletteBackStyle.GridHeaderColumnCustom1:
		case PaletteBackStyle.GridHeaderRowCustom1:
			return state switch
			{
				PaletteState.Disabled => SystemColors.Control, 
				PaletteState.CheckedNormal => ColorTable.CheckBackground, 
				_ => ColorTable.MenuStripGradientBegin, 
			};
		case PaletteBackStyle.GridDataCellList:
		case PaletteBackStyle.GridDataCellSheet:
		case PaletteBackStyle.GridDataCellCustom1:
			if (state == PaletteState.CheckedNormal)
			{
				return ColorTable.ButtonPressedHighlight;
			}
			return SystemColors.Window;
		case PaletteBackStyle.FormMain:
		case PaletteBackStyle.FormCustom1:
			return ColorTable.MenuStripGradientBegin;
		case PaletteBackStyle.HeaderForm:
			return Table.Header1End;
		case PaletteBackStyle.ControlGroupBox:
		case PaletteBackStyle.GridBackgroundList:
		case PaletteBackStyle.GridBackgroundSheet:
		case PaletteBackStyle.GridBackgroundCustom1:
		case PaletteBackStyle.PanelClient:
		case PaletteBackStyle.PanelRibbonInactive:
		case PaletteBackStyle.PanelCustom1:
		case PaletteBackStyle.SeparatorLowProfile:
		case PaletteBackStyle.SeparatorCustom1:
			return ColorTable.MenuStripGradientEnd;
		case PaletteBackStyle.PanelAlternate:
			return ColorTable.MenuStripGradientBegin;
		case PaletteBackStyle.ControlClient:
		case PaletteBackStyle.ControlAlternate:
		case PaletteBackStyle.ControlCustom1:
			return SystemColors.Window;
		case PaletteBackStyle.ContextMenuHeading:
			return ColorTable.OverflowButtonGradientBegin;
		case PaletteBackStyle.ContextMenuSeparator:
		case PaletteBackStyle.ContextMenuItemSplit:
			return state switch
			{
				PaletteState.Disabled => SystemColors.Control, 
				PaletteState.Tracking => ColorTable.ButtonSelectedBorder, 
				_ => ColorTable.MenuBorder, 
			};
		case PaletteBackStyle.ContextMenuItemImageColumn:
			return ColorTable.ImageMarginGradientEnd;
		case PaletteBackStyle.InputControlStandalone:
		case PaletteBackStyle.InputControlRibbon:
		case PaletteBackStyle.InputControlCustom1:
			if (state == PaletteState.Disabled)
			{
				return SystemColors.Control;
			}
			return SystemColors.Window;
		case PaletteBackStyle.ControlRibbon:
			return _ribbonColors[75];
		case PaletteBackStyle.ControlRibbonAppMenu:
			return _ribbonColors[191];
		case PaletteBackStyle.ContextMenuOuter:
		case PaletteBackStyle.ContextMenuInner:
			return ColorTable.ToolStripDropDownBackground;
		case PaletteBackStyle.ContextMenuItemImage:
			return ColorTable.ButtonSelectedHighlight;
		case PaletteBackStyle.HeaderPrimary:
		case PaletteBackStyle.HeaderCalendar:
		case PaletteBackStyle.HeaderCustom1:
		case PaletteBackStyle.HeaderCustom2:
		case PaletteBackStyle.SeparatorHighProfile:
		case PaletteBackStyle.SeparatorHighInternalProfile:
			if (state == PaletteState.Disabled)
			{
				return SystemColors.Control;
			}
			return Table.Header1End;
		case PaletteBackStyle.HeaderSecondary:
			if (state == PaletteState.Disabled)
			{
				return SystemColors.Control;
			}
			return ColorTable.MenuStripGradientBegin;
		case PaletteBackStyle.HeaderDockInactive:
			if (state == PaletteState.Disabled)
			{
				return SystemColors.Control;
			}
			return ControlPaint.Light(SystemColors.GradientInactiveCaption);
		case PaletteBackStyle.HeaderDockActive:
			if (state == PaletteState.Disabled)
			{
				return SystemColors.Control;
			}
			return ControlPaint.Light(SystemColors.GradientActiveCaption);
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
				return SystemColors.Control;
			case PaletteState.Normal:
				if (style == PaletteBackStyle.TabLowProfile)
				{
					return Color.Empty;
				}
				return PaletteBase.MergeColors(SystemColors.Window, 0.9f, SystemColors.ControlText, 0.1f);
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				if (style == PaletteBackStyle.TabLowProfile)
				{
					return Color.Empty;
				}
				return PaletteBase.MergeColors(SystemColors.Window, 0.95f, SystemColors.ControlText, 0.05f);
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
				return SystemColors.Control;
			case PaletteState.Normal:
				return PaletteBase.MergeColors(SystemColors.Control, 0.8f, SystemColors.ControlDark, 0.2f);
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				return PaletteBase.MergeColors(SystemColors.Window, 0.8f, SystemColors.Highlight, 0.2f);
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
				return SystemColors.Control;
			case PaletteState.Normal:
			case PaletteState.CheckedNormal:
				return PaletteBase.MergeColors(SystemColors.Control, 0.8f, SystemColors.ControlDark, 0.2f);
			case PaletteState.Tracking:
			case PaletteState.Pressed:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return PaletteBase.MergeColors(SystemColors.Window, 0.8f, SystemColors.Highlight, 0.2f);
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.ControlToolTip:
			return _toolTipBack2;
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
		case PaletteBackStyle.ButtonListItem:
		case PaletteBackStyle.ButtonForm:
		case PaletteBackStyle.ButtonFormClose:
		case PaletteBackStyle.ButtonCommand:
		case PaletteBackStyle.ButtonCustom1:
		case PaletteBackStyle.ButtonCustom2:
		case PaletteBackStyle.ButtonCustom3:
			switch (state)
			{
			case PaletteState.Disabled:
				return SystemColors.Control;
			case PaletteState.Normal:
				return ColorTable.MenuStripGradientBegin;
			case PaletteState.CheckedNormal:
				return ColorTable.ButtonPressedGradientMiddle;
			case PaletteState.NormalDefaultOverride:
				return ColorTable.MenuStripGradientBegin;
			case PaletteState.Tracking:
				return ColorTable.ButtonSelectedGradientEnd;
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				if (style == PaletteBackStyle.ButtonAlternate)
				{
					return ColorTable.MenuStripGradientBegin;
				}
				return ColorTable.ButtonPressedGradientEnd;
			case PaletteState.CheckedTracking:
				return ColorTable.ButtonPressedGradientEnd;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.ButtonCalendarDay:
			switch (state)
			{
			case PaletteState.Disabled:
				return SystemColors.Control;
			case PaletteState.Normal:
			case PaletteState.NormalDefaultOverride:
				return ColorTable.MenuStripGradientEnd;
			case PaletteState.CheckedNormal:
				return ColorTable.ButtonPressedGradientEnd;
			case PaletteState.Tracking:
				return ColorTable.ButtonSelectedGradientBegin;
			case PaletteState.Pressed:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return ColorTable.ButtonPressedGradientBegin;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.ButtonInputControl:
			switch (state)
			{
			case PaletteState.Disabled:
				return SystemColors.Control;
			case PaletteState.Normal:
				return ColorTable.MenuStripGradientBegin;
			case PaletteState.CheckedNormal:
				return ColorTable.MenuStripGradientBegin;
			case PaletteState.Tracking:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return ColorTable.ButtonSelectedGradientEnd;
			case PaletteState.Pressed:
				return ColorTable.ButtonPressedGradientEnd;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBackStyle.ContextMenuItemHighlight:
			return state switch
			{
				PaletteState.Disabled => SystemColors.Control, 
				PaletteState.Normal => Color.Empty, 
				PaletteState.Tracking => ColorTable.MenuItemSelectedGradientEnd, 
				_ => throw new ArgumentOutOfRangeException("state"), 
			};
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
		case PaletteBackStyle.ControlToolTip:
		case PaletteBackStyle.ContextMenuItemImageColumn:
		case PaletteBackStyle.GridHeaderColumnList:
		case PaletteBackStyle.GridHeaderRowList:
		case PaletteBackStyle.GridHeaderColumnSheet:
		case PaletteBackStyle.GridHeaderRowSheet:
		case PaletteBackStyle.GridHeaderColumnCustom1:
		case PaletteBackStyle.GridHeaderRowCustom1:
		case PaletteBackStyle.HeaderDockInactive:
		case PaletteBackStyle.HeaderDockActive:
			return PaletteColorStyle.Linear;
		case PaletteBackStyle.ButtonNavigatorMini:
		case PaletteBackStyle.ControlClient:
		case PaletteBackStyle.ControlAlternate:
		case PaletteBackStyle.ControlGroupBox:
		case PaletteBackStyle.ControlRibbon:
		case PaletteBackStyle.ControlCustom1:
		case PaletteBackStyle.ContextMenuOuter:
		case PaletteBackStyle.ContextMenuInner:
		case PaletteBackStyle.ContextMenuHeading:
		case PaletteBackStyle.ContextMenuSeparator:
		case PaletteBackStyle.ContextMenuItemImage:
		case PaletteBackStyle.ContextMenuItemSplit:
		case PaletteBackStyle.InputControlStandalone:
		case PaletteBackStyle.InputControlRibbon:
		case PaletteBackStyle.InputControlCustom1:
		case PaletteBackStyle.GridDataCellList:
		case PaletteBackStyle.GridBackgroundList:
		case PaletteBackStyle.GridDataCellSheet:
		case PaletteBackStyle.GridBackgroundSheet:
		case PaletteBackStyle.GridDataCellCustom1:
		case PaletteBackStyle.GridBackgroundCustom1:
		case PaletteBackStyle.HeaderCalendar:
		case PaletteBackStyle.PanelClient:
		case PaletteBackStyle.PanelAlternate:
		case PaletteBackStyle.PanelRibbonInactive:
		case PaletteBackStyle.PanelCustom1:
		case PaletteBackStyle.SeparatorLowProfile:
		case PaletteBackStyle.SeparatorCustom1:
		case PaletteBackStyle.FormMain:
		case PaletteBackStyle.FormCustom1:
			return PaletteColorStyle.Solid;
		case PaletteBackStyle.ControlRibbonAppMenu:
			return PaletteColorStyle.Switch90;
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
		case PaletteBackStyle.ButtonInputControl:
		case PaletteBackStyle.ButtonListItem:
		case PaletteBackStyle.ButtonForm:
		case PaletteBackStyle.ButtonFormClose:
		case PaletteBackStyle.ButtonCommand:
		case PaletteBackStyle.ButtonCustom1:
		case PaletteBackStyle.ButtonCustom2:
		case PaletteBackStyle.ButtonCustom3:
		case PaletteBackStyle.ContextMenuItemHighlight:
		case PaletteBackStyle.HeaderPrimary:
		case PaletteBackStyle.HeaderSecondary:
		case PaletteBackStyle.HeaderForm:
		case PaletteBackStyle.HeaderCustom1:
		case PaletteBackStyle.HeaderCustom2:
		case PaletteBackStyle.SeparatorHighProfile:
		case PaletteBackStyle.SeparatorHighInternalProfile:
			return PaletteColorStyle.Rounded;
		case PaletteBackStyle.TabHighProfile:
		case PaletteBackStyle.TabStandardProfile:
		case PaletteBackStyle.TabLowProfile:
		case PaletteBackStyle.TabCustom1:
		case PaletteBackStyle.TabCustom2:
		case PaletteBackStyle.TabCustom3:
			return PaletteColorStyle.QuarterPhase;
		case PaletteBackStyle.TabOneNote:
		case PaletteBackStyle.TabDock:
		case PaletteBackStyle.TabDockAutoHidden:
			return PaletteColorStyle.OneNote;
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
		case PaletteBackStyle.ContextMenuOuter:
		case PaletteBackStyle.ContextMenuInner:
		case PaletteBackStyle.ContextMenuHeading:
		case PaletteBackStyle.ContextMenuSeparator:
		case PaletteBackStyle.ContextMenuItemSplit:
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
		case PaletteBackStyle.ContextMenuItemImage:
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
		switch (style)
		{
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
		case PaletteBackStyle.HeaderForm:
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
		case PaletteBackStyle.FormMain:
		case PaletteBackStyle.FormCustom1:
			return 90f;
		case PaletteBackStyle.ContextMenuItemImageColumn:
			return 0f;
		default:
			throw new ArgumentOutOfRangeException("style");
		}
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
		case PaletteBorderStyle.ContextMenuSeparator:
		case PaletteBorderStyle.ContextMenuItemSplit:
		case PaletteBorderStyle.SeparatorLowProfile:
		case PaletteBorderStyle.SeparatorHighProfile:
		case PaletteBorderStyle.SeparatorHighInternalProfile:
		case PaletteBorderStyle.SeparatorCustom1:
			return InheritBool.False;
		case PaletteBorderStyle.ButtonStandalone:
		case PaletteBorderStyle.ButtonAlternate:
		case PaletteBorderStyle.ButtonCluster:
		case PaletteBorderStyle.ButtonGallery:
		case PaletteBorderStyle.ButtonForm:
		case PaletteBorderStyle.ButtonFormClose:
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
		case PaletteBorderStyle.ButtonInputControl:
		case PaletteBorderStyle.ContextMenuItemImage:
		case PaletteBorderStyle.ContextMenuItemHighlight:
			if (state == PaletteState.Normal || state == PaletteState.NormalDefaultOverride)
			{
				return InheritBool.False;
			}
			return InheritBool.True;
		case PaletteBorderStyle.ButtonNavigatorStack:
		case PaletteBorderStyle.ButtonNavigatorOverflow:
			return InheritBool.False;
		case PaletteBorderStyle.ButtonLowProfile:
		case PaletteBorderStyle.ButtonButtonSpec:
		case PaletteBorderStyle.ButtonBreadCrumb:
		case PaletteBorderStyle.ButtonCalendarDay:
		case PaletteBorderStyle.ButtonListItem:
		case PaletteBorderStyle.ButtonCommand:
			if ((uint)(state - 1) <= 1u || state == PaletteState.NormalDefaultOverride)
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
			return PaletteDrawBorders.All;
		case PaletteBorderStyle.ContextMenuHeading:
			return PaletteDrawBorders.Bottom;
		case PaletteBorderStyle.ButtonNavigatorStack:
		case PaletteBorderStyle.ButtonNavigatorOverflow:
		case PaletteBorderStyle.ButtonNavigatorMini:
		case PaletteBorderStyle.ButtonInputControl:
		case PaletteBorderStyle.ContextMenuInner:
		case PaletteBorderStyle.ContextMenuSeparator:
		case PaletteBorderStyle.ContextMenuItemSplit:
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
		case PaletteBorderStyle.ControlToolTip:
		case PaletteBorderStyle.ControlRibbon:
		case PaletteBorderStyle.ControlRibbonAppMenu:
		case PaletteBorderStyle.TabHighProfile:
		case PaletteBorderStyle.TabStandardProfile:
		case PaletteBorderStyle.TabLowProfile:
		case PaletteBorderStyle.TabOneNote:
		case PaletteBorderStyle.TabDock:
		case PaletteBorderStyle.TabDockAutoHidden:
		case PaletteBorderStyle.TabCustom1:
		case PaletteBorderStyle.TabCustom2:
		case PaletteBorderStyle.TabCustom3:
			return PaletteGraphicsHint.AntiAlias;
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
		case PaletteBorderStyle.ControlCustom1:
		case PaletteBorderStyle.ContextMenuOuter:
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
		case PaletteBorderStyle.FormMain:
		case PaletteBorderStyle.FormCustom1:
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
					return PaletteBase.FadedColor(ColorTable.ButtonSelectedBorder);
				}
				return ColorTable.ButtonPressedBorder;
			}
			return Color.Empty;
		}
		switch (style)
		{
		case PaletteBorderStyle.HeaderForm:
		case PaletteBorderStyle.FormMain:
		case PaletteBorderStyle.FormCustom1:
			return ColorTable.MenuBorder;
		case PaletteBorderStyle.ControlToolTip:
			if (state == PaletteState.Disabled)
			{
				return PaletteBase.FadedColor(ColorTable.ButtonSelectedBorder);
			}
			return _toolTipBorder;
		case PaletteBorderStyle.HeaderCalendar:
			if (state == PaletteState.Disabled)
			{
				return SystemColors.Control;
			}
			return Table.Header1Begin;
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
				return PaletteBase.FadedColor(ColorTable.ButtonSelectedBorder);
			}
			return ColorTable.MenuBorder;
		case PaletteBorderStyle.ContextMenuHeading:
			return ColorTable.MenuBorder;
		case PaletteBorderStyle.ContextMenuSeparator:
		case PaletteBorderStyle.ContextMenuItemSplit:
			return state switch
			{
				PaletteState.Disabled => SystemColors.Control, 
				PaletteState.Tracking => ColorTable.ButtonSelectedBorder, 
				_ => ColorTable.MenuBorder, 
			};
		case PaletteBorderStyle.ContextMenuItemImageColumn:
			return ColorTable.ToolStripDropDownBackground;
		case PaletteBorderStyle.InputControlStandalone:
		case PaletteBorderStyle.InputControlCustom1:
			if (state == PaletteState.Disabled)
			{
				return PaletteBase.FadedColor(ColorTable.ButtonSelectedBorder);
			}
			return ColorTable.MenuBorder;
		case PaletteBorderStyle.InputControlRibbon:
			return state switch
			{
				PaletteState.Disabled => PaletteBase.FadedColor(ColorTable.ButtonSelectedBorder), 
				PaletteState.Normal => ColorTable.MenuStripGradientBegin, 
				_ => ColorTable.ButtonSelectedBorder, 
			};
		case PaletteBorderStyle.GridDataCellList:
		case PaletteBorderStyle.GridDataCellSheet:
		case PaletteBorderStyle.GridDataCellCustom1:
			if (state == PaletteState.Disabled)
			{
				return PaletteBase.FadedColor(ColorTable.ButtonSelectedBorder);
			}
			return ColorTable.SeparatorDark;
		case PaletteBorderStyle.ControlRibbon:
			if (state == PaletteState.Disabled)
			{
				return PaletteBase.FadedColor(ColorTable.ButtonSelectedBorder);
			}
			return _ribbonColors[85];
		case PaletteBorderStyle.ControlRibbonAppMenu:
			if (state == PaletteState.Disabled)
			{
				return PaletteBase.FadedColor(_ribbonColors[192]);
			}
			return _ribbonColors[192];
		case PaletteBorderStyle.ContextMenuOuter:
		case PaletteBorderStyle.ContextMenuInner:
			return ColorTable.MenuBorder;
		case PaletteBorderStyle.ContextMenuItemImage:
			return ColorTable.MenuItemBorder;
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
				return PaletteBase.FadedColor(ColorTable.ButtonSelectedBorder);
			case PaletteState.Normal:
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				if (style == PaletteBorderStyle.TabLowProfile)
				{
					return Color.Empty;
				}
				return ColorTable.OverflowButtonGradientEnd;
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return ColorTable.MenuBorder;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBorderStyle.TabDock:
			switch (state)
			{
			case PaletteState.Disabled:
				return PaletteBase.FadedColor(ColorTable.ButtonSelectedBorder);
			case PaletteState.Normal:
				return ColorTable.OverflowButtonGradientEnd;
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				return PaletteBase.MergeColors(ColorTable.OverflowButtonGradientEnd, 0.5f, SystemColors.Highlight, 0.5f);
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return ColorTable.MenuBorder;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBorderStyle.TabDockAutoHidden:
			switch (state)
			{
			case PaletteState.Disabled:
				return PaletteBase.FadedColor(ColorTable.ButtonSelectedBorder);
			case PaletteState.Normal:
			case PaletteState.CheckedNormal:
				return ColorTable.OverflowButtonGradientEnd;
			case PaletteState.Tracking:
			case PaletteState.Pressed:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return PaletteBase.MergeColors(ColorTable.OverflowButtonGradientEnd, 0.5f, SystemColors.Highlight, 0.5f);
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
		case PaletteBorderStyle.ContextMenuItemHighlight:
			switch (state)
			{
			case PaletteState.Disabled:
				return PaletteBase.FadedColor(ColorTable.ButtonSelectedBorder);
			case PaletteState.Normal:
				return ColorTable.MenuBorder;
			case PaletteState.CheckedNormal:
				return ColorTable.MenuBorder;
			case PaletteState.Tracking:
				return ColorTable.ButtonSelectedBorder;
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				if (style == PaletteBorderStyle.ButtonAlternate)
				{
					return ColorTable.SeparatorDark;
				}
				return ColorTable.ButtonPressedBorder;
			case PaletteState.CheckedTracking:
				return ColorTable.ButtonPressedBorder;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBorderStyle.ButtonCalendarDay:
			switch (state)
			{
			case PaletteState.Disabled:
				return SystemColors.Control;
			case PaletteState.Normal:
				return ColorTable.MenuStripGradientEnd;
			case PaletteState.CheckedNormal:
				return ColorTable.ButtonPressedGradientEnd;
			case PaletteState.NormalDefaultOverride:
				return ColorTable.MenuStripGradientBegin;
			case PaletteState.Tracking:
				return ColorTable.ButtonSelectedGradientBegin;
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				return ColorTable.ButtonPressedGradientBegin;
			case PaletteState.CheckedTracking:
				return ColorTable.ButtonPressedGradientBegin;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
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
					return PaletteBase.FadedColor(ColorTable.ButtonSelectedBorder);
				}
				return ColorTable.ButtonPressedBorder;
			}
			return Color.Empty;
		}
		switch (style)
		{
		case PaletteBorderStyle.HeaderForm:
		case PaletteBorderStyle.FormMain:
		case PaletteBorderStyle.FormCustom1:
			return ColorTable.MenuBorder;
		case PaletteBorderStyle.ControlToolTip:
			if (state == PaletteState.Disabled)
			{
				return PaletteBase.FadedColor(ColorTable.ButtonSelectedBorder);
			}
			return _toolTipBorder;
		case PaletteBorderStyle.ControlClient:
		case PaletteBorderStyle.ControlAlternate:
		case PaletteBorderStyle.ControlGroupBox:
		case PaletteBorderStyle.ControlCustom1:
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
		case PaletteBorderStyle.HeaderCustom1:
		case PaletteBorderStyle.HeaderCustom2:
		case PaletteBorderStyle.SeparatorLowProfile:
		case PaletteBorderStyle.SeparatorHighProfile:
		case PaletteBorderStyle.SeparatorHighInternalProfile:
		case PaletteBorderStyle.SeparatorCustom1:
			if (state == PaletteState.Disabled)
			{
				return PaletteBase.FadedColor(ColorTable.ButtonSelectedBorder);
			}
			return ColorTable.MenuBorder;
		case PaletteBorderStyle.HeaderCalendar:
			if (state == PaletteState.Disabled)
			{
				return SystemColors.Control;
			}
			return Table.Header1Begin;
		case PaletteBorderStyle.ContextMenuHeading:
			return ColorTable.MenuBorder;
		case PaletteBorderStyle.ContextMenuSeparator:
		case PaletteBorderStyle.ContextMenuItemSplit:
			return state switch
			{
				PaletteState.Disabled => SystemColors.Control, 
				PaletteState.Tracking => ColorTable.ButtonSelectedBorder, 
				_ => ColorTable.MenuBorder, 
			};
		case PaletteBorderStyle.ContextMenuItemImageColumn:
			return ColorTable.ToolStripDropDownBackground;
		case PaletteBorderStyle.ContextMenuItemImage:
			return ColorTable.MenuItemBorder;
		case PaletteBorderStyle.InputControlStandalone:
		case PaletteBorderStyle.InputControlCustom1:
			if (state == PaletteState.Disabled)
			{
				return PaletteBase.FadedColor(ColorTable.ButtonSelectedBorder);
			}
			return ColorTable.MenuBorder;
		case PaletteBorderStyle.InputControlRibbon:
			return state switch
			{
				PaletteState.Disabled => PaletteBase.FadedColor(ColorTable.ButtonSelectedBorder), 
				PaletteState.Normal => ColorTable.MenuStripGradientBegin, 
				_ => ColorTable.ButtonSelectedBorder, 
			};
		case PaletteBorderStyle.ControlRibbon:
			if (state == PaletteState.Disabled)
			{
				return PaletteBase.FadedColor(ColorTable.ButtonSelectedBorder);
			}
			return _ribbonColors[85];
		case PaletteBorderStyle.ControlRibbonAppMenu:
			if (state == PaletteState.Disabled)
			{
				return PaletteBase.FadedColor(_ribbonColors[192]);
			}
			return _ribbonColors[192];
		case PaletteBorderStyle.ContextMenuOuter:
		case PaletteBorderStyle.ContextMenuInner:
			return ColorTable.MenuBorder;
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
				return PaletteBase.FadedColor(ColorTable.ButtonSelectedBorder);
			case PaletteState.Normal:
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				if (style == PaletteBorderStyle.TabLowProfile)
				{
					return Color.Empty;
				}
				return ColorTable.ButtonPressedHighlightBorder;
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return ColorTable.MenuBorder;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBorderStyle.TabDock:
			switch (state)
			{
			case PaletteState.Disabled:
				return PaletteBase.FadedColor(ColorTable.ButtonSelectedBorder);
			case PaletteState.Normal:
				return ColorTable.OverflowButtonGradientEnd;
			case PaletteState.Tracking:
			case PaletteState.Pressed:
				return PaletteBase.MergeColors(ColorTable.OverflowButtonGradientEnd, 0.5f, SystemColors.Highlight, 0.5f);
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return ColorTable.MenuBorder;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBorderStyle.TabDockAutoHidden:
			switch (state)
			{
			case PaletteState.Disabled:
				return PaletteBase.FadedColor(ColorTable.ButtonSelectedBorder);
			case PaletteState.Normal:
			case PaletteState.CheckedNormal:
				return ColorTable.OverflowButtonGradientEnd;
			case PaletteState.Tracking:
			case PaletteState.Pressed:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return PaletteBase.MergeColors(ColorTable.OverflowButtonGradientEnd, 0.5f, SystemColors.Highlight, 0.5f);
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
		case PaletteBorderStyle.ContextMenuItemHighlight:
			switch (state)
			{
			case PaletteState.Disabled:
				return PaletteBase.FadedColor(ColorTable.ButtonSelectedBorder);
			case PaletteState.Normal:
				return ColorTable.MenuBorder;
			case PaletteState.CheckedNormal:
				return ColorTable.MenuBorder;
			case PaletteState.Tracking:
				return ColorTable.ButtonSelectedBorder;
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				if (style == PaletteBorderStyle.ButtonAlternate)
				{
					return ColorTable.SeparatorDark;
				}
				return ColorTable.ButtonPressedBorder;
			case PaletteState.CheckedTracking:
				return ColorTable.ButtonPressedBorder;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		case PaletteBorderStyle.ButtonCalendarDay:
			switch (state)
			{
			case PaletteState.Disabled:
				return SystemColors.Control;
			case PaletteState.Normal:
				return ColorTable.MenuStripGradientEnd;
			case PaletteState.CheckedNormal:
				return ColorTable.ButtonPressedGradientEnd;
			case PaletteState.NormalDefaultOverride:
				return ColorTable.MenuStripGradientBegin;
			case PaletteState.Tracking:
				return ColorTable.ButtonSelectedGradientBegin;
			case PaletteState.Pressed:
			case PaletteState.CheckedPressed:
				return ColorTable.ButtonPressedGradientBegin;
			case PaletteState.CheckedTracking:
				return ColorTable.ButtonPressedGradientBegin;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		default:
			throw new ArgumentOutOfRangeException("style");
		}
	}

	public override PaletteColorStyle GetBorderColorStyle(PaletteBorderStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteColorStyle.Inherit;
		}
		if ((uint)style <= 68u)
		{
			return PaletteColorStyle.Solid;
		}
		throw new ArgumentOutOfRangeException("style");
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
		case PaletteBorderStyle.ContextMenuOuter:
		case PaletteBorderStyle.ContextMenuInner:
		case PaletteBorderStyle.ContextMenuHeading:
		case PaletteBorderStyle.ContextMenuSeparator:
		case PaletteBorderStyle.ContextMenuItemSplit:
		case PaletteBorderStyle.ContextMenuItemImageColumn:
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
		case PaletteBorderStyle.ContextMenuItemImage:
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
		case PaletteBorderStyle.ContextMenuSeparator:
		case PaletteBorderStyle.ContextMenuItemSplit:
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
		case PaletteBorderStyle.ContextMenuItemImage:
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
		case PaletteBorderStyle.ControlToolTip:
		case PaletteBorderStyle.ControlCustom1:
		case PaletteBorderStyle.ContextMenuOuter:
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
			return 0;
		case PaletteBorderStyle.ControlGroupBox:
		case PaletteBorderStyle.ControlRibbon:
		case PaletteBorderStyle.ControlRibbonAppMenu:
			return 3;
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
		case PaletteContentStyle.ContextMenuItemTextStandard:
		case PaletteContentStyle.ContextMenuItemTextAlternate:
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
		case PaletteContentStyle.ContextMenuItemShortcutText:
			return PaletteRelativeAlign.Far;
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
		case PaletteContentStyle.ContextMenuItemImage:
		case PaletteContentStyle.LabelSuperTip:
			return _superToolFont;
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
		case PaletteContentStyle.ButtonNavigatorStack:
		case PaletteContentStyle.ButtonNavigatorOverflow:
		case PaletteContentStyle.ButtonInputControl:
		case PaletteContentStyle.ButtonListItem:
		case PaletteContentStyle.ButtonForm:
		case PaletteContentStyle.ButtonFormClose:
		case PaletteContentStyle.ButtonCustom1:
		case PaletteContentStyle.ButtonCustom2:
		case PaletteContentStyle.ButtonCustom3:
			return _buttonFont;
		case PaletteContentStyle.ButtonNavigatorMini:
			return _buttonFontNavigatorMini;
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
		case PaletteContentStyle.HeaderCalendar:
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
			return state switch
			{
				PaletteState.LinkNotVisitedOverride => Color.Blue, 
				PaletteState.LinkVisitedOverride => Color.Purple, 
				PaletteState.LinkPressedOverride => Color.Red, 
				_ => Color.Empty, 
			};
		}
		if (style == PaletteContentStyle.HeaderForm)
		{
			return ColorTable.SeparatorLight;
		}
		if (state == PaletteState.Disabled)
		{
			return SystemColors.ControlDark;
		}
		switch (style)
		{
		case PaletteContentStyle.LabelToolTip:
		case PaletteContentStyle.LabelSuperTip:
		case PaletteContentStyle.LabelKeyTip:
			return _toolTipText;
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderCalendar:
		case PaletteContentStyle.HeaderCustom1:
		case PaletteContentStyle.HeaderCustom2:
			return ColorTable.SeparatorLight;
		case PaletteContentStyle.HeaderDockInactive:
			return SystemColors.InactiveCaptionText;
		case PaletteContentStyle.HeaderDockActive:
			return SystemColors.ActiveCaptionText;
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
		case PaletteContentStyle.GridDataCellList:
		case PaletteContentStyle.GridDataCellSheet:
		case PaletteContentStyle.GridDataCellCustom1:
		case PaletteContentStyle.HeaderSecondary:
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
		case PaletteContentStyle.TabCustom1:
		case PaletteContentStyle.TabCustom2:
		case PaletteContentStyle.TabCustom3:
		case PaletteContentStyle.InputControlStandalone:
		case PaletteContentStyle.InputControlRibbon:
		case PaletteContentStyle.InputControlCustom1:
			return SystemColors.ControlText;
		case PaletteContentStyle.GridHeaderColumnList:
		case PaletteContentStyle.GridHeaderRowList:
		case PaletteContentStyle.GridHeaderColumnSheet:
		case PaletteContentStyle.GridHeaderRowSheet:
		case PaletteContentStyle.GridHeaderColumnCustom1:
		case PaletteContentStyle.GridHeaderRowCustom1:
			if (state == PaletteState.CheckedNormal)
			{
				return SystemColors.HighlightText;
			}
			return SystemColors.ControlText;
		case PaletteContentStyle.TabDock:
			if (state == PaletteState.CheckedNormal || state == PaletteState.CheckedTracking || state == PaletteState.CheckedPressed)
			{
				return SystemColors.ControlText;
			}
			return PaletteBase.MergeColors(SystemColors.Window, 0.3f, SystemColors.ControlText, 0.7f);
		case PaletteContentStyle.TabDockAutoHidden:
			return PaletteBase.MergeColors(SystemColors.Window, 0.3f, SystemColors.ControlText, 0.7f);
		case PaletteContentStyle.ContextMenuHeading:
		case PaletteContentStyle.ContextMenuItemImage:
		case PaletteContentStyle.ContextMenuItemTextStandard:
		case PaletteContentStyle.ContextMenuItemTextAlternate:
		case PaletteContentStyle.ContextMenuItemShortcutText:
			return ColorTable.MenuItemText;
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
			return ColorTable.SeparatorLight;
		}
		if (state == PaletteState.Disabled && style != PaletteContentStyle.ButtonInputControl)
		{
			return SystemColors.ControlDark;
		}
		switch (style)
		{
		case PaletteContentStyle.LabelToolTip:
		case PaletteContentStyle.LabelSuperTip:
		case PaletteContentStyle.LabelKeyTip:
			return _toolTipText;
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderCalendar:
		case PaletteContentStyle.HeaderCustom1:
		case PaletteContentStyle.HeaderCustom2:
			return ColorTable.SeparatorLight;
		case PaletteContentStyle.HeaderDockInactive:
			return SystemColors.InactiveCaptionText;
		case PaletteContentStyle.HeaderDockActive:
			return SystemColors.ActiveCaptionText;
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
		case PaletteContentStyle.ButtonListItem:
		case PaletteContentStyle.ButtonForm:
		case PaletteContentStyle.ButtonFormClose:
		case PaletteContentStyle.ButtonCommand:
		case PaletteContentStyle.ButtonCustom1:
		case PaletteContentStyle.ButtonCustom2:
		case PaletteContentStyle.ButtonCustom3:
		case PaletteContentStyle.GridDataCellList:
		case PaletteContentStyle.GridDataCellSheet:
		case PaletteContentStyle.GridDataCellCustom1:
		case PaletteContentStyle.HeaderSecondary:
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
		case PaletteContentStyle.TabCustom1:
		case PaletteContentStyle.TabCustom2:
		case PaletteContentStyle.TabCustom3:
		case PaletteContentStyle.InputControlStandalone:
		case PaletteContentStyle.InputControlRibbon:
		case PaletteContentStyle.InputControlCustom1:
			return SystemColors.ControlText;
		case PaletteContentStyle.TabDock:
			if (state == PaletteState.CheckedNormal || state == PaletteState.CheckedTracking || state == PaletteState.CheckedPressed)
			{
				return SystemColors.ControlText;
			}
			return PaletteBase.MergeColors(SystemColors.Window, 0.3f, SystemColors.ControlText, 0.7f);
		case PaletteContentStyle.TabDockAutoHidden:
			return PaletteBase.MergeColors(SystemColors.Window, 0.3f, SystemColors.ControlText, 0.7f);
		case PaletteContentStyle.GridHeaderColumnList:
		case PaletteContentStyle.GridHeaderRowList:
		case PaletteContentStyle.GridHeaderColumnSheet:
		case PaletteContentStyle.GridHeaderRowSheet:
		case PaletteContentStyle.GridHeaderColumnCustom1:
		case PaletteContentStyle.GridHeaderRowCustom1:
			if (state == PaletteState.CheckedNormal)
			{
				return SystemColors.HighlightText;
			}
			return SystemColors.ControlText;
		case PaletteContentStyle.ButtonInputControl:
			return Color.Transparent;
		case PaletteContentStyle.ContextMenuHeading:
		case PaletteContentStyle.ContextMenuItemImage:
		case PaletteContentStyle.ContextMenuItemTextStandard:
		case PaletteContentStyle.ContextMenuItemTextAlternate:
		case PaletteContentStyle.ContextMenuItemShortcutText:
			return ColorTable.MenuItemText;
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
			return InheritBool.True;
		case PaletteContentStyle.GridHeaderColumnList:
		case PaletteContentStyle.GridHeaderRowList:
		case PaletteContentStyle.GridDataCellList:
		case PaletteContentStyle.GridHeaderColumnSheet:
		case PaletteContentStyle.GridHeaderRowSheet:
		case PaletteContentStyle.GridDataCellSheet:
		case PaletteContentStyle.GridHeaderColumnCustom1:
		case PaletteContentStyle.GridHeaderRowCustom1:
		case PaletteContentStyle.GridDataCellCustom1:
			return InheritBool.False;
		default:
			throw new ArgumentOutOfRangeException("style");
		}
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
			return PaletteRelativeAlign.Near;
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
			return ColorTable.SeparatorLight;
		}
		if (state == PaletteState.Disabled)
		{
			return SystemColors.ControlDark;
		}
		switch (style)
		{
		case PaletteContentStyle.LabelToolTip:
		case PaletteContentStyle.LabelSuperTip:
		case PaletteContentStyle.LabelKeyTip:
			return _toolTipText;
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderCalendar:
		case PaletteContentStyle.HeaderCustom1:
		case PaletteContentStyle.HeaderCustom2:
			return ColorTable.SeparatorLight;
		case PaletteContentStyle.HeaderDockInactive:
			return SystemColors.InactiveCaptionText;
		case PaletteContentStyle.HeaderDockActive:
			return SystemColors.ActiveCaptionText;
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
		case PaletteContentStyle.GridHeaderColumnList:
		case PaletteContentStyle.GridHeaderRowList:
		case PaletteContentStyle.GridDataCellList:
		case PaletteContentStyle.GridHeaderColumnSheet:
		case PaletteContentStyle.GridHeaderRowSheet:
		case PaletteContentStyle.GridDataCellSheet:
		case PaletteContentStyle.GridHeaderColumnCustom1:
		case PaletteContentStyle.GridHeaderRowCustom1:
		case PaletteContentStyle.GridDataCellCustom1:
		case PaletteContentStyle.HeaderSecondary:
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
		case PaletteContentStyle.TabCustom1:
		case PaletteContentStyle.TabCustom2:
		case PaletteContentStyle.TabCustom3:
		case PaletteContentStyle.InputControlStandalone:
		case PaletteContentStyle.InputControlRibbon:
		case PaletteContentStyle.InputControlCustom1:
			return SystemColors.ControlText;
		case PaletteContentStyle.TabDock:
			if (state == PaletteState.CheckedNormal || state == PaletteState.CheckedTracking || state == PaletteState.CheckedPressed)
			{
				return SystemColors.ControlText;
			}
			return PaletteBase.MergeColors(SystemColors.Window, 0.3f, SystemColors.ControlText, 0.7f);
		case PaletteContentStyle.TabDockAutoHidden:
			return PaletteBase.MergeColors(SystemColors.Window, 0.3f, SystemColors.ControlText, 0.7f);
		case PaletteContentStyle.ContextMenuHeading:
		case PaletteContentStyle.ContextMenuItemImage:
		case PaletteContentStyle.ContextMenuItemTextStandard:
		case PaletteContentStyle.ContextMenuItemTextAlternate:
		case PaletteContentStyle.ContextMenuItemShortcutText:
			return ColorTable.MenuItemText;
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
			return ColorTable.SeparatorLight;
		}
		if (state == PaletteState.Disabled && style != PaletteContentStyle.ButtonInputControl)
		{
			return SystemColors.ControlDark;
		}
		switch (style)
		{
		case PaletteContentStyle.LabelToolTip:
		case PaletteContentStyle.LabelSuperTip:
		case PaletteContentStyle.LabelKeyTip:
			return _toolTipText;
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderCalendar:
		case PaletteContentStyle.HeaderCustom1:
		case PaletteContentStyle.HeaderCustom2:
			return ColorTable.SeparatorLight;
		case PaletteContentStyle.HeaderDockInactive:
			return SystemColors.InactiveCaptionText;
		case PaletteContentStyle.HeaderDockActive:
			return SystemColors.ActiveCaptionText;
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
		case PaletteContentStyle.ButtonListItem:
		case PaletteContentStyle.ButtonForm:
		case PaletteContentStyle.ButtonFormClose:
		case PaletteContentStyle.ButtonCommand:
		case PaletteContentStyle.ButtonCustom1:
		case PaletteContentStyle.ButtonCustom2:
		case PaletteContentStyle.ButtonCustom3:
		case PaletteContentStyle.GridHeaderColumnList:
		case PaletteContentStyle.GridHeaderRowList:
		case PaletteContentStyle.GridDataCellList:
		case PaletteContentStyle.GridHeaderColumnSheet:
		case PaletteContentStyle.GridHeaderRowSheet:
		case PaletteContentStyle.GridDataCellSheet:
		case PaletteContentStyle.GridHeaderColumnCustom1:
		case PaletteContentStyle.GridHeaderRowCustom1:
		case PaletteContentStyle.GridDataCellCustom1:
		case PaletteContentStyle.HeaderSecondary:
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
		case PaletteContentStyle.TabCustom1:
		case PaletteContentStyle.TabCustom2:
		case PaletteContentStyle.TabCustom3:
		case PaletteContentStyle.InputControlStandalone:
		case PaletteContentStyle.InputControlRibbon:
		case PaletteContentStyle.InputControlCustom1:
			return SystemColors.ControlText;
		case PaletteContentStyle.TabDock:
			if (state == PaletteState.CheckedNormal || state == PaletteState.CheckedTracking || state == PaletteState.CheckedPressed)
			{
				return SystemColors.ControlText;
			}
			return PaletteBase.MergeColors(SystemColors.Window, 0.3f, SystemColors.ControlText, 0.7f);
		case PaletteContentStyle.TabDockAutoHidden:
			return PaletteBase.MergeColors(SystemColors.Window, 0.3f, SystemColors.ControlText, 0.7f);
		case PaletteContentStyle.ButtonInputControl:
			return Color.Transparent;
		case PaletteContentStyle.ContextMenuHeading:
		case PaletteContentStyle.ContextMenuItemImage:
		case PaletteContentStyle.ContextMenuItemTextStandard:
		case PaletteContentStyle.ContextMenuItemTextAlternate:
		case PaletteContentStyle.ContextMenuItemShortcutText:
			return ColorTable.MenuItemText;
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
		case PaletteContentStyle.LabelToolTip:
			return _contentPaddingToolTip;
		case PaletteContentStyle.LabelSuperTip:
			return _contentPaddingSuperTip;
		case PaletteContentStyle.LabelKeyTip:
			return _contentPaddingKeyTip;
		case PaletteContentStyle.ContextMenuHeading:
			return _contentPaddingContextMenuHeading;
		case PaletteContentStyle.ContextMenuItemImage:
			return _contentPaddingContextMenuImage;
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
		case PaletteContentStyle.ButtonInputControl:
			return _contentPaddingButtonInputControl;
		case PaletteContentStyle.ButtonCalendarDay:
			return _contentPaddingButtonCalendar;
		case PaletteContentStyle.ButtonButtonSpec:
		case PaletteContentStyle.ButtonListItem:
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
		case PaletteMetricBool.TreeViewLines:
			return InheritBool.True;
		case PaletteMetricBool.RibbonTabsSpareCaption:
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
		case PaletteMetricPadding.ContextMenuItemHighlight:
			return _metricPaddingContextMenuItemHighlight;
		case PaletteMetricPadding.ContextMenuItemsCollection:
			return _metricPaddingContextMenuItemsCollection;
		case PaletteMetricPadding.HeaderGroupPaddingPrimary:
		case PaletteMetricPadding.HeaderGroupPaddingSecondary:
		case PaletteMetricPadding.HeaderGroupPaddingDockInactive:
		case PaletteMetricPadding.HeaderGroupPaddingDockActive:
		case PaletteMetricPadding.SeparatorPaddingLowProfile:
		case PaletteMetricPadding.SeparatorPaddingHighProfile:
		case PaletteMetricPadding.SeparatorPaddingHighInternalProfile:
		case PaletteMetricPadding.SeparatorPaddingCustom1:
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
			return _treeCollapseMinus;
		}
		return _treeExpandPlus;
	}

	public override Image GetCheckBoxImage(bool enabled, CheckState checkState, bool tracking, bool pressed)
	{
		return null;
	}

	public override Image GetRadioButtonImage(bool enabled, bool checkState, bool tracking, bool pressed)
	{
		return null;
	}

	public override Image GetDropDownButtonImage(PaletteState state)
	{
		if (state != PaletteState.Disabled)
		{
			if (_normalDropDownImage == null)
			{
				_normalDropDownImage = CreateDropDownImage(SystemColors.ControlText);
				_normalDropDownColor = SystemColors.ControlText;
			}
			return _normalDropDownImage;
		}
		if (_disabledDropDownImage == null)
		{
			_disabledDropDownImage = CreateDropDownImage(SystemColors.ControlDark);
			_disabledDropDownColor = SystemColors.ControlDark;
		}
		return _disabledDropDownImage;
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
			if (_galleryImageUp == null)
			{
				_galleryImageUp = CreateGalleryUpImage(SystemColors.ControlText);
			}
			return _galleryImageUp;
		case PaletteRibbonGalleryButton.Down:
			if (_galleryImageDown == null)
			{
				_galleryImageDown = CreateGalleryDownImage(SystemColors.ControlText);
			}
			return _galleryImageDown;
		case PaletteRibbonGalleryButton.DropDown:
			if (_galleryImageDropDown == null)
			{
				_galleryImageDropDown = CreateGalleryDropDownImage(SystemColors.ControlText);
			}
			return _galleryImageDropDown;
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
		case PaletteButtonSpecStyle.WorkspaceMaximize:
			return _buttonSpecWorkspaceMaximize;
		case PaletteButtonSpecStyle.WorkspaceRestore:
			return _buttonSpecWorkspaceRestore;
		case PaletteButtonSpecStyle.RibbonMinimize:
			if (state == PaletteState.Disabled)
			{
				return _pendantMinimizeI;
			}
			return _pendantMinimizeA;
		case PaletteButtonSpecStyle.RibbonExpand:
			if (state == PaletteState.Disabled)
			{
				return _pendantExpandI;
			}
			return _pendantExpandA;
		case PaletteButtonSpecStyle.FormClose:
			if (state == PaletteState.Disabled)
			{
				return _systemCloseI;
			}
			return _systemCloseA;
		case PaletteButtonSpecStyle.FormMin:
			if (state == PaletteState.Disabled)
			{
				return _systemMinI;
			}
			return _systemMinA;
		case PaletteButtonSpecStyle.FormMax:
			if (state == PaletteState.Disabled)
			{
				return _systemMaxI;
			}
			return _systemMaxA;
		case PaletteButtonSpecStyle.FormRestore:
			if (state == PaletteState.Disabled)
			{
				return _systemRestoreI;
			}
			return _systemRestoreA;
		case PaletteButtonSpecStyle.PendantClose:
			if (state == PaletteState.Disabled)
			{
				return _pendantCloseI;
			}
			return _pendantCloseA;
		case PaletteButtonSpecStyle.PendantMin:
			if (state == PaletteState.Disabled)
			{
				return _pendantMinI;
			}
			return _pendantMinA;
		case PaletteButtonSpecStyle.PendantRestore:
			if (state == PaletteState.Disabled)
			{
				return _pendantRestoreI;
			}
			return _pendantRestoreA;
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
		case PaletteButtonSpecStyle.PendantClose:
		case PaletteButtonSpecStyle.PendantMin:
		case PaletteButtonSpecStyle.PendantRestore:
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
		return PaletteRelativeAlign.Near;
	}

	public override Font GetRibbonContextTextFont(PaletteState state)
	{
		return _buttonFont;
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
		return _contextTabSeparator;
	}

	public override Font GetRibbonTextFont(PaletteState state)
	{
		return _buttonFont;
	}

	public override PaletteTextHint GetRibbonTextHint(PaletteState state)
	{
		return PaletteTextHint.SystemDefault;
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
				PaletteState.Disabled => SystemColors.Control, 
				PaletteState.Tracking => _ribbonColors[204], 
				_ => _ribbonColors[203], 
			};
		case PaletteRibbonBackStyle.RibbonGalleryBorder:
			return state switch
			{
				PaletteState.Disabled => PaletteBase.FadedColor(ColorTable.ButtonSelectedBorder), 
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
		case PaletteRibbonBackStyle.RibbonGroupNormalTitle:
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBack:
			return Color.Empty;
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
				return _contextGroupAreaBorder;
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
		case PaletteRibbonBackStyle.RibbonGroupNormalTitle:
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBack:
			return Color.Empty;
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
			return Color.Empty;
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
		case PaletteRibbonBackStyle.RibbonGroupNormalBorder:
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBorder:
			return _ribbonColors[211];
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
			return SystemColors.ControlText;
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
			return ColorTable.SeparatorDark;
		case PaletteElement.TrackBarTrack:
			return ColorTable.OverflowButtonGradientEnd;
		case PaletteElement.TrackBarPosition:
			return Color.FromArgb(128, Color.White);
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
			return ColorTable.SeparatorDark;
		case PaletteElement.TrackBarTrack:
			return ColorTable.MenuStripGradientBegin;
		case PaletteElement.TrackBarPosition:
			return state switch
			{
				PaletteState.Disabled => ControlPaint.LightLight(ColorTable.MenuBorder), 
				PaletteState.Normal => ColorTable.MenuBorder, 
				PaletteState.Tracking => ColorTable.ButtonSelectedBorder, 
				PaletteState.Pressed => ColorTable.ButtonPressedBorder, 
				_ => throw new ArgumentOutOfRangeException("state"), 
			};
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
			return ColorTable.SeparatorDark;
		case PaletteElement.TrackBarTrack:
			return ColorTable.OverflowButtonGradientBegin;
		case PaletteElement.TrackBarPosition:
			switch (state)
			{
			case PaletteState.Disabled:
				return ControlPaint.LightLight(ColorTable.MenuStripGradientBegin);
			case PaletteState.Normal:
			case PaletteState.FocusOverride:
				return ControlPaint.Light(ColorTable.MenuStripGradientBegin);
			case PaletteState.Tracking:
				return ControlPaint.Light(ColorTable.ButtonSelectedGradientBegin);
			case PaletteState.Pressed:
				return ControlPaint.Light(ColorTable.ButtonPressedGradientBegin);
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
			return ColorTable.SeparatorDark;
		case PaletteElement.TrackBarTrack:
			if (CommonHelper.IsOverrideState(state))
			{
				return Color.Empty;
			}
			return SystemColors.Control;
		case PaletteElement.TrackBarPosition:
			if (CommonHelper.IsOverrideStateExclude(state, PaletteState.FocusOverride))
			{
				return Color.Empty;
			}
			switch (state)
			{
			case PaletteState.Disabled:
				return ControlPaint.LightLight(ColorTable.MenuStripGradientEnd);
			case PaletteState.Normal:
				return ColorTable.MenuStripGradientEnd;
			case PaletteState.Tracking:
			case PaletteState.FocusOverride:
				return ColorTable.ButtonSelectedGradientBegin;
			case PaletteState.Pressed:
				return ColorTable.ButtonPressedGradientBegin;
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
			return ColorTable.SeparatorDark;
		case PaletteElement.TrackBarTrack:
			if (CommonHelper.IsOverrideState(state))
			{
				return Color.Empty;
			}
			return SystemColors.Control;
		case PaletteElement.TrackBarPosition:
			if (CommonHelper.IsOverrideStateExclude(state, PaletteState.FocusOverride))
			{
				return Color.Empty;
			}
			switch (state)
			{
			case PaletteState.Disabled:
				return ControlPaint.LightLight(ColorTable.MenuStripGradientBegin);
			case PaletteState.Normal:
				return ColorTable.MenuStripGradientBegin;
			case PaletteState.Tracking:
			case PaletteState.FocusOverride:
				return ColorTable.ButtonSelectedGradientEnd;
			case PaletteState.Pressed:
				return ColorTable.ButtonPressedGradientEnd;
			default:
				throw new ArgumentOutOfRangeException("state");
			}
		default:
			Debug.Assert(condition: false);
			return Color.Red;
		}
	}

	internal virtual KryptonProfessionalKCT GenerateColorTable()
	{
		KryptonColorTable kryptonColorTable = new KryptonColorTable(this);
		kryptonColorTable.UseSystemColors = true;
		Color[] colors = new Color[2] { kryptonColorTable.OverflowButtonGradientEnd, kryptonColorTable.OverflowButtonGradientEnd };
		return new KryptonProfessionalKCT(colors, useSystemColors: true, this);
	}

	protected override void OnUserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
	{
		_table = null;
		if (_disabledDropDownImage != null)
		{
			_disabledDropDownImage.Dispose();
			_disabledDropDownImage = null;
		}
		if (_normalDropDownImage != null)
		{
			_normalDropDownImage.Dispose();
			_normalDropDownImage = null;
		}
		if (_galleryImageUp != null)
		{
			_galleryImageUp.Dispose();
			_galleryImageUp = null;
		}
		if (_galleryImageDown != null)
		{
			_galleryImageDown.Dispose();
			_galleryImageDown = null;
		}
		if (_galleryImageDropDown != null)
		{
			_galleryImageDropDown.Dispose();
			_galleryImageDropDown = null;
		}
		DefineFonts();
		DefineRibbonColors();
		base.OnUserPreferenceChanged(sender, e);
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
		if (_header1LongFont != null)
		{
			_header1LongFont.Dispose();
		}
		if (_header2LongFont != null)
		{
			_header2LongFont.Dispose();
		}
		if (_headerFormFont != null)
		{
			_headerFormFont.Dispose();
		}
		if (_buttonFont != null)
		{
			_buttonFont.Dispose();
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
		_header1ShortFont = new Font("Arial", baseFontSize + 4.5f, FontStyle.Bold);
		_header2ShortFont = SystemFonts.IconTitleFont;
		_header1LongFont = new Font(SystemFonts.MenuFont.FontFamily, baseFontSize + 1.5f, FontStyle.Regular);
		_header2LongFont = SystemFonts.IconTitleFont;
		_headerFormFont = new Font("Arial", SystemFonts.CaptionFont.SizeInPoints, FontStyle.Bold);
		_buttonFont = SystemFonts.IconTitleFont;
		_buttonFontNavigatorMini = new Font("Arial", baseFontSize + 3.5f, FontStyle.Bold);
		_tabFontNormal = SystemFonts.IconTitleFont;
		_tabFontSelected = new Font(_tabFontNormal, FontStyle.Bold);
		_gridFont = SystemFonts.IconTitleFont;
		_superToolFont = new Font(SystemFonts.MenuFont.FontFamily, baseFontSize, FontStyle.Bold);
		_calendarFont = new Font(SystemFonts.IconTitleFont.FontFamily, baseFontSize, FontStyle.Regular);
		_calendarBoldFont = new Font(SystemFonts.IconTitleFont.FontFamily, baseFontSize, FontStyle.Bold);
		_boldFont = new Font(SystemFonts.IconTitleFont.FontFamily, baseFontSize, FontStyle.Bold);
		_italicFont = new Font(SystemFonts.IconTitleFont.FontFamily, baseFontSize, FontStyle.Italic);
	}

	private void DefineRibbonColors()
	{
		Color menuStripGradientEnd = ColorTable.MenuStripGradientEnd;
		Color color = ColorTable.RaftingContainerGradientBegin;
		Color color2 = ColorTable.MenuBorder;
		switch (SystemColors.Control.ToArgb())
		{
		case -2039837:
		case -1250856:
		case -986896:
			menuStripGradientEnd = PaletteBase.MergeColors(menuStripGradientEnd, 0.93f, Color.Black, 0.07f);
			color = PaletteBase.MergeColors(color, 0.93f, Color.Black, 0.07f);
			color2 = PaletteBase.MergeColors(color2, 0.93f, Color.Black, 0.07f);
			break;
		case -4144960:
		case -2830136:
			menuStripGradientEnd = PaletteBase.MergeColors(menuStripGradientEnd, 0.95f, Color.Black, 0.05f);
			color = PaletteBase.MergeColors(color, 0.95f, Color.Black, 0.05f);
			color2 = PaletteBase.MergeColors(color2, 0.95f, Color.Black, 0.05f);
			break;
		}
		Color color3 = PaletteBase.MergeColors(color, 0.8f, color2, 0.2f);
		Color color4 = PaletteBase.MergeColors(color, 0.2f, color2, 0.8f);
		Color color5 = PaletteBase.MergeColors(color, 0.1f, Color.White, 0.9f);
		Color color6 = PaletteBase.MergeColors(color, 0.7f, Color.White, 0.3f);
		Color color7 = PaletteBase.MergeColors(color, 0.9f, color2, 0.1f);
		Color color8 = Color.FromArgb(128, Color.White);
		Color color9 = Color.FromArgb(196, Color.White);
		Color color10 = PaletteBase.MergeColors(color, 0.2f, color2, 0.8f);
		Color color11 = PaletteBase.MergeColors(color, 0.3f, Color.White, 0.7f);
		Color color12 = Color.FromArgb(249, 250, 250);
		Color color13 = PaletteBase.MergeColors(color, 0.6f, color2, 0.4f);
		Color color14 = PaletteBase.MergeColors(color, 0.4f, Color.White, 0.6f);
		Color color15 = Color.FromArgb(152, SystemColors.ControlText);
		Color color16 = Color.FromArgb(104, SystemColors.ControlText);
		Color color17 = Color.FromArgb(72, SystemColors.ControlText);
		Color color18 = PaletteBase.MergeColors(color, 0.5f, color2, 0.5f);
		Color color19 = PaletteBase.MergeColors(ColorTable.MenuStripGradientEnd, 0.4f, Color.White, 0.6f);
		Color color20 = PaletteBase.MergeColors(color, 0.7f, color2, 0.3f);
		Color color21 = PaletteBase.MergeColors(color, 0.8f, color2, 0.2f);
		Color color22 = PaletteBase.MergeColors(color, 0.1f, Color.White, 0.9f);
		Color color23 = PaletteBase.MergeColors(color, 0.1f, Color.White, 0.9f);
		Color color24 = PaletteBase.MergeColors(color, 0.1f, Color.White, 0.9f);
		Color color25 = PaletteBase.MergeColors(color, 0.8f, color2, 0.2f);
		Color color26 = PaletteBase.MergeColors(color, 0.2f, Color.White, 0.8f);
		Color color27 = PaletteBase.MergeColors(color, 0.5f, Color.White, 0.5f);
		Color color28 = PaletteBase.MergeColors(color, 0.75f, Color.White, 0.25f);
		Color color29 = PaletteBase.MergeColors(ColorTable.MenuStripGradientEnd, 0.75f, color, 0.25f);
		Color color30 = PaletteBase.MergeColors(ColorTable.MenuStripGradientEnd, 0.65f, color, 0.35f);
		Color color31 = PaletteBase.MergeColors(color, 0.7f, color2, 0.3f);
		Color color32 = PaletteBase.MergeColors(color, 0.9f, color2, 0.1f);
		_ribbonColors = new Color[225]
		{
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			SystemColors.ControlText,
			SystemColors.ControlText,
			color21,
			color22,
			color23,
			color24,
			Color.Empty,
			color25,
			color26,
			Color.FromArgb(196, ColorTable.ButtonSelectedGradientMiddle),
			ColorTable.ButtonSelectedGradientMiddle,
			ColorTable.ButtonPressedGradientMiddle,
			ColorTable.ButtonPressedGradientMiddle,
			ColorTable.ButtonSelectedGradientMiddle,
			ColorTable.MenuBorder,
			color3,
			color4,
			color5,
			color6,
			color6,
			color8,
			color9,
			Color.Red,
			Color.Red,
			color8,
			color9,
			Color.Red,
			Color.Red,
			color16,
			color17,
			Color.Red,
			Color.Red,
			color20,
			color19,
			color8,
			color9,
			color6,
			color4,
			color6,
			Color.Red,
			Color.Red,
			color4,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			color13,
			color13,
			color14,
			color14,
			Color.Empty,
			Color.Empty,
			SystemColors.ControlText,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			ColorTable.MenuBorder,
			color,
			color32,
			Color.FromArgb(32, Color.White),
			Color.FromArgb(32, Color.White),
			ColorTable.MenuBorder,
			color,
			color32,
			Color.FromArgb(32, Color.White),
			Color.FromArgb(32, Color.White),
			color,
			color32,
			color3,
			SystemColors.ControlText,
			SystemColors.ControlLight,
			color,
			ColorTable.MenuBorder,
			color18,
			ColorTable.GripLight,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			SystemColors.Window,
			color3,
			ColorTable.MenuBorder,
			ColorTable.SeparatorDark,
			ColorTable.SeparatorDark,
			ColorTable.StatusStripGradientBegin,
			ColorTable.ToolStripDropDownBackground,
			ColorTable.MenuBorder,
			ColorTable.ImageMarginGradientMiddle,
			SystemColors.ControlText,
			Color.Red,
			Color.Red,
			ColorTable.MenuBorder,
			color24,
			SystemColors.Window,
			Color.Red,
			Color.Red,
			color27,
			color28,
			color10,
			color11,
			color12,
			color15,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red,
			Color.Red
		};
		_disabledText = SystemColors.ControlDark;
		_disabledGlyphDark = Color.FromArgb(183, 183, 183);
		_disabledGlyphLight = Color.FromArgb(237, 237, 237);
		_contextCheckedTabBorder = color3;
		_contextCheckedTabFill = ColorTable.CheckBackground;
		_contextGroupAreaBorder = color3;
		_contextGroupAreaInside = color4;
		_contextGroupFrameTop = Color.FromArgb(250, 250, 250);
		_contextGroupFrameBottom = _contextGroupFrameTop;
		_contextTabSeparator = ColorTable.MenuBorder;
		_focusTabFill = ColorTable.CheckBackground;
		_toolTipBack1 = SystemColors.Info;
		_toolTipBack2 = SystemColors.Info;
		_toolTipBorder = SystemColors.WindowFrame;
		_toolTipText = SystemColors.InfoText;
		_disabledDropDownColor = Color.Empty;
		_normalDropDownColor = Color.Empty;
		_ribbonGroupCollapsedBackContext = new Color[2]
		{
			Color.FromArgb(48, 235, 235, 235),
			Color.FromArgb(235, 235, 235)
		};
		_ribbonGroupCollapsedBackContextTracking = _ribbonGroupCollapsedBackContext;
		_ribbonGroupCollapsedBorderContext = new Color[4]
		{
			Color.FromArgb(160, color8),
			color8,
			Color.FromArgb(48, color6),
			color6
		};
		_ribbonGroupCollapsedBorderContextTracking = new Color[4]
		{
			Color.FromArgb(200, color8),
			color8,
			Color.FromArgb(48, color8),
			Color.FromArgb(196, color8)
		};
		Color color33 = PaletteBase.MergeColors(Color.White, 0.5f, ColorTable.ButtonSelectedGradientEnd, 0.5f);
		Color color34 = PaletteBase.MergeColors(Color.White, 0.25f, ColorTable.ButtonSelectedGradientEnd, 0.75f);
		Color color35 = PaletteBase.MergeColors(Color.White, 0.6f, ColorTable.ButtonPressedGradientMiddle, 0.4f);
		Color color36 = PaletteBase.MergeColors(Color.White, 0.25f, ColorTable.ButtonPressedGradientMiddle, 0.75f);
		Color color37 = PaletteBase.MergeColors(Color.White, 0.5f, ColorTable.CheckBackground, 0.5f);
		Color color38 = PaletteBase.MergeColors(Color.White, 0.25f, ColorTable.CheckPressedBackground, 0.75f);
		_appButtonNormal = new Color[5] { ColorTable.SeparatorLight, ColorTable.ImageMarginGradientBegin, ColorTable.ImageMarginGradientMiddle, ColorTable.GripLight, ColorTable.ImageMarginGradientBegin };
		_appButtonTrack = new Color[5] { color33, color34, ColorTable.ButtonSelectedGradientEnd, color35, color36 };
		_appButtonPressed = new Color[5] { color33, color38, ColorTable.CheckPressedBackground, color34, color38 };
	}

	private Image CreateDropDownImage(Color color)
	{
		Image image = new Bitmap(9, 9, PixelFormat.Format32bppArgb);
		using (Graphics graphics = Graphics.FromImage(image))
		{
			using (SolidBrush brush = new SolidBrush(color))
			{
				graphics.FillPolygon(brush, new Point[3]
				{
					new Point(2, 3),
					new Point(4, 6),
					new Point(7, 3)
				});
			}
			using Pen pen = new Pen(Color.FromArgb(128, color));
			graphics.DrawLines(pen, new Point[3]
			{
				new Point(1, 3),
				new Point(4, 6),
				new Point(7, 3)
			});
		}
		return image;
	}

	private Image CreateGalleryUpImage(Color color)
	{
		Image image = new Bitmap(13, 7, PixelFormat.Format32bppArgb);
		using (Graphics graphics = Graphics.FromImage(image))
		{
			using SolidBrush brush = new SolidBrush(color);
			graphics.FillPolygon(brush, new Point[3]
			{
				new Point(3, 6),
				new Point(6, 2),
				new Point(9, 6)
			});
		}
		return image;
	}

	private Image CreateGalleryDownImage(Color color)
	{
		Image image = new Bitmap(13, 7, PixelFormat.Format32bppArgb);
		using (Graphics graphics = Graphics.FromImage(image))
		{
			using SolidBrush brush = new SolidBrush(color);
			graphics.FillPolygon(brush, new Point[3]
			{
				new Point(4, 3),
				new Point(6, 6),
				new Point(9, 3)
			});
		}
		return image;
	}

	private Image CreateGalleryDropDownImage(Color color)
	{
		Image image = new Bitmap(13, 7, PixelFormat.Format32bppArgb);
		using (Graphics graphics = Graphics.FromImage(image))
		{
			using (SolidBrush brush = new SolidBrush(color))
			{
				graphics.FillPolygon(brush, new Point[3]
				{
					new Point(4, 3),
					new Point(6, 6),
					new Point(9, 3)
				});
			}
			using Pen pen = new Pen(color);
			graphics.DrawLine(pen, 4, 1, 8, 1);
		}
		return image;
	}
}
