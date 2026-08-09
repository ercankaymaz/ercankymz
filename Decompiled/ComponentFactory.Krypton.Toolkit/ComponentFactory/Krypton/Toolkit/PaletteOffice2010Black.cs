using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit.Properties;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteOffice2010Black : PaletteOffice2010Base
{
	private static readonly ImageList _checkBoxList;

	private static readonly ImageList _galleryButtonList;

	private static readonly Image[] _radioButtonArray;

	private static readonly Image _blackDropDownButton;

	private static readonly Image _contextMenuSubMenu;

	private static readonly Image _formCloseH;

	private static readonly Image _formClose;

	private static readonly Image _formMax;

	private static readonly Image _formMin;

	private static readonly Image _formRestore;

	private static readonly Image _buttonSpecPendantClose;

	private static readonly Image _buttonSpecPendantMin;

	private static readonly Image _buttonSpecPendantRestore;

	private static readonly Image _buttonSpecRibbonMinimize;

	private static readonly Image _buttonSpecRibbonExpand;

	private static readonly Color _disabledRibbonText;

	private static readonly Color[] _trackBarColors;

	private static readonly Color[] _schemeColors;

	static PaletteOffice2010Black()
	{
		_blackDropDownButton = Resources._2010BlackDropDownButton;
		_contextMenuSubMenu = Resources._2010BlackContextMenuSub;
		_formCloseH = Resources._2010ButtonCloseH;
		_formClose = Resources._2010ButtonCloseBlack;
		_formMax = Resources._2010ButtonMaxBlack;
		_formMin = Resources._2010ButtonMinBlack;
		_formRestore = Resources._2010ButtonRestore;
		_buttonSpecPendantClose = Resources._2010ButtonMDICloseBlack;
		_buttonSpecPendantMin = Resources._2010ButtonMDIMinBlack;
		_buttonSpecPendantRestore = Resources._2010ButtonMDIRestoreBlack;
		_buttonSpecRibbonMinimize = Resources.RibbonUp2010Black;
		_buttonSpecRibbonExpand = Resources.RibbonDown2010Black;
		_disabledRibbonText = Color.FromArgb(205, 205, 205);
		_trackBarColors = new Color[6]
		{
			Color.FromArgb(17, 17, 17),
			Color.FromArgb(37, 37, 37),
			Color.FromArgb(174, 174, 174),
			Color.FromArgb(131, 132, 132),
			Color.FromArgb(64, Color.White),
			Color.FromArgb(35, 35, 35)
		};
		_schemeColors = new Color[226]
		{
			Color.FromArgb(76, 83, 92),
			Color.Black,
			Color.Black,
			Color.FromArgb(106, 106, 106),
			Color.FromArgb(94, 94, 94),
			Color.FromArgb(189, 189, 189),
			Color.FromArgb(169, 169, 169),
			Color.FromArgb(225, 225, 225),
			Color.FromArgb(185, 185, 185),
			Color.FromArgb(94, 94, 94),
			Color.FromArgb(94, 94, 94),
			Color.FromArgb(113, 113, 113),
			Color.FromArgb(71, 71, 71),
			Color.FromArgb(46, 46, 46),
			Color.FromArgb(172, 172, 172),
			Color.FromArgb(111, 111, 111),
			Color.FromArgb(139, 139, 139),
			Color.FromArgb(72, 72, 72),
			Color.FromArgb(190, 190, 190),
			Color.FromArgb(145, 145, 145),
			Color.Black,
			Color.FromArgb(226, 226, 226),
			Color.FromArgb(236, 199, 87),
			Color.FromArgb(89, 89, 89),
			Color.Black,
			Color.FromArgb(89, 89, 89),
			Color.FromArgb(27, 27, 27),
			Color.FromArgb(113, 113, 113),
			Color.FromArgb(75, 75, 75),
			Color.FromArgb(50, 50, 50),
			Color.White,
			Color.FromArgb(75, 75, 75),
			Color.FromArgb(50, 50, 50),
			Color.FromArgb(50, 50, 50),
			Color.FromArgb(44, 44, 44),
			Color.FromArgb(167, 167, 167),
			Color.FromArgb(44, 44, 44),
			Color.FromArgb(44, 44, 44),
			Color.FromArgb(99, 99, 99),
			Color.FromArgb(119, 119, 119),
			Color.FromArgb(113, 113, 113),
			Color.FromArgb(131, 131, 131),
			Color.FromArgb(158, 158, 158),
			Color.FromArgb(158, 158, 158),
			Color.FromArgb(65, 65, 65),
			Color.FromArgb(154, 154, 154),
			Color.FromArgb(121, 121, 121),
			Color.FromArgb(113, 113, 113),
			Color.FromArgb(158, 158, 158),
			Color.FromArgb(158, 158, 158),
			Color.FromArgb(226, 226, 226),
			Color.FromArgb(212, 212, 212),
			Color.FromArgb(226, 226, 226),
			Color.FromArgb(212, 212, 212),
			Color.FromArgb(81, 81, 81),
			Color.FromArgb(151, 151, 151),
			Color.FromArgb(116, 116, 116),
			Color.FromArgb(81, 81, 81),
			Color.FromArgb(113, 113, 113),
			Color.FromArgb(93, 93, 93),
			Color.FromArgb(70, 70, 70),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.Blue,
			Color.Purple,
			Color.Red,
			Color.FromArgb(180, 210, 255),
			Color.Violet,
			Color.FromArgb(255, 90, 90),
			Color.White,
			Color.FromArgb(226, 226, 226),
			Color.Black,
			Color.FromArgb(94, 94, 94),
			Color.FromArgb(201, 201, 201),
			Color.FromArgb(192, 192, 192),
			Color.FromArgb(192, 192, 192),
			Color.FromArgb(192, 192, 192),
			Color.FromArgb(94, 94, 94),
			Color.FromArgb(183, 183, 183),
			Color.FromArgb(94, 94, 94),
			Color.FromArgb(201, 201, 201),
			Color.FromArgb(192, 192, 192),
			Color.FromArgb(192, 192, 192),
			Color.FromArgb(192, 192, 192),
			Color.FromArgb(54, 54, 54),
			Color.FromArgb(94, 94, 94),
			Color.FromArgb(50, 50, 50),
			Color.FromArgb(191, 191, 191),
			Color.FromArgb(164, 164, 164),
			Color.FromArgb(145, 145, 145),
			Color.FromArgb(159, 159, 159),
			Color.FromArgb(194, 194, 194),
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.FromArgb(92, 92, 94),
			Color.FromArgb(123, 125, 125),
			Color.Empty,
			Color.Empty,
			Color.FromArgb(78, 78, 78),
			Color.FromArgb(110, 110, 110),
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.FromArgb(147, 147, 147),
			Color.FromArgb(139, 139, 139),
			Color.FromArgb(187, 187, 188),
			Color.FromArgb(167, 167, 168),
			Color.Empty,
			Color.Empty,
			Color.FromArgb(59, 59, 59),
			Color.FromArgb(158, 163, 172),
			Color.FromArgb(212, 215, 216),
			Color.FromArgb(124, 125, 125),
			Color.FromArgb(186, 186, 186),
			Color.FromArgb(43, 55, 67),
			Color.FromArgb(106, 122, 140),
			Color.FromArgb(18, 18, 18),
			Color.FromArgb(33, 45, 57),
			Color.FromArgb(136, 152, 170),
			Color.FromArgb(55, 55, 55),
			Color.FromArgb(100, 100, 100),
			Color.FromArgb(73, 73, 73),
			Color.FromArgb(12, Color.White),
			Color.FromArgb(14, Color.White),
			Color.FromArgb(100, 100, 100),
			Color.FromArgb(170, 170, 170),
			Color.FromArgb(140, 140, 140),
			Color.FromArgb(12, Color.White),
			Color.FromArgb(14, Color.White),
			Color.FromArgb(132, 132, 132),
			Color.FromArgb(121, 121, 121),
			Color.FromArgb(50, 49, 49),
			Color.FromArgb(90, 90, 90),
			Color.FromArgb(174, 174, 175),
			Color.FromArgb(161, 161, 161),
			Color.FromArgb(68, 68, 68),
			Color.FromArgb(82, 82, 82),
			Color.FromArgb(190, 190, 190),
			Color.FromArgb(210, 217, 219),
			Color.FromArgb(214, 222, 223),
			Color.FromArgb(179, 188, 191),
			Color.FromArgb(145, 156, 159),
			Color.FromArgb(235, 235, 235),
			Color.FromArgb(205, 205, 205),
			Color.FromArgb(166, 166, 166),
			Color.FromArgb(166, 166, 166),
			Color.FromArgb(205, 205, 205),
			Color.FromArgb(150, 150, 150),
			Color.FromArgb(220, 220, 220),
			Color.FromArgb(200, 200, 200),
			Color.FromArgb(255, 223, 107),
			Color.FromArgb(255, 252, 230),
			Color.FromArgb(255, 211, 89),
			Color.FromArgb(255, 239, 113),
			Color.FromArgb(205, 205, 205),
			Color.FromArgb(255, 223, 107),
			Color.FromArgb(245, 210, 87),
			Color.FromArgb(218, 220, 221),
			Color.FromArgb(183, 219, 255),
			Color.Black,
			Color.FromArgb(168, 168, 168),
			Color.FromArgb(132, 132, 132),
			Color.FromArgb(187, 187, 187),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(240, 240, 240),
			Color.FromArgb(192, 192, 192),
			Color.Black,
			Color.Transparent,
			Color.FromArgb(172, 168, 153),
			Color.Transparent,
			Color.FromArgb(240, 242, 245),
			Color.Black,
			Color.White,
			Color.FromArgb(70, 70, 70),
			Color.FromArgb(70, 70, 70),
			Color.FromArgb(50, 50, 50),
			Color.FromArgb(70, 70, 70),
			Color.FromArgb(70, 70, 70),
			Color.FromArgb(70, 70, 70),
			Color.Empty,
			Color.FromArgb(50, 50, 50),
			Color.White,
			Color.Black,
			Color.FromArgb(172, 172, 172),
			Color.FromArgb(111, 111, 111),
			Color.FromArgb(132, 132, 132),
			Color.FromArgb(187, 187, 187),
			Color.FromArgb(193, 193, 193),
			Color.FromArgb(176, 176, 176),
			Color.FromArgb(150, 150, 150),
			Color.FromArgb(148, 149, 151),
			Color.FromArgb(127, 127, 127),
			Color.FromArgb(82, 82, 82),
			Color.FromArgb(176, 176, 176),
			Color.FromArgb(178, 178, 178),
			Color.FromArgb(36, 36, 36),
			Color.FromArgb(155, 157, 160),
			Color.FromArgb(27, 29, 40),
			Color.FromArgb(137, 137, 137),
			Color.FromArgb(125, 125, 125),
			Color.FromArgb(46, 46, 46),
			Color.White,
			Color.FromArgb(76, 76, 76),
			Color.FromArgb(147, 147, 143),
			Color.FromArgb(66, 66, 66),
			Color.FromArgb(148, 148, 143),
			Color.FromArgb(91, 91, 91),
			Color.FromArgb(73, 73, 73),
			Color.FromArgb(201, 201, 201)
		};
		_checkBoxList = new ImageList();
		_checkBoxList.ImageSize = new Size(13, 13);
		_checkBoxList.ColorDepth = ColorDepth.Depth24Bit;
		_checkBoxList.Images.AddStrip(Resources.CB2010Black);
		_galleryButtonList = new ImageList();
		_galleryButtonList.ImageSize = new Size(13, 7);
		_galleryButtonList.ColorDepth = ColorDepth.Depth24Bit;
		_galleryButtonList.TransparentColor = Color.Magenta;
		_galleryButtonList.Images.AddStrip(Resources.Gallery2010);
		_radioButtonArray = new Image[8]
		{
			Resources.RB2010BlueD,
			Resources.RB2010SilverN,
			Resources.RB2010BlueT,
			Resources.RB2010BlueP,
			Resources.RB2010BlueDC,
			Resources.RB2010SilverNC,
			Resources.RB2010SilverTC,
			Resources.RB2010SilverPC
		};
	}

	public PaletteOffice2010Black()
		: base(_schemeColors, _checkBoxList, _galleryButtonList, _radioButtonArray, _trackBarColors)
	{
	}

	public override PaletteColorStyle GetBackColorStyle(PaletteBackStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return PaletteColorStyle.Inherit;
		}
		if ((uint)(style - 8) <= 2u)
		{
			if (state == PaletteState.CheckedNormal || state == PaletteState.CheckedTracking || state == PaletteState.CheckedPressed)
			{
				return PaletteColorStyle.ExpertSquareHighlight2;
			}
		}
		return base.GetBackColorStyle(style, state);
	}

	public override Color GetBackColor2(PaletteBackStyle style, PaletteState state)
	{
		if (style == PaletteBackStyle.TabDock)
		{
			if (state == PaletteState.Normal)
			{
				return _schemeColors[18];
			}
		}
		return base.GetBackColor2(style, state);
	}

	public override Color GetBorderColor1(PaletteBorderStyle style, PaletteState state)
	{
		if (style == PaletteBorderStyle.TabDock)
		{
			if (state == PaletteState.Normal)
			{
				return _schemeColors[13];
			}
		}
		return base.GetBorderColor1(style, state);
	}

	public override Color GetBorderColor2(PaletteBorderStyle style, PaletteState state)
	{
		if (style == PaletteBorderStyle.TabDock)
		{
			if (state == PaletteState.Normal)
			{
				return _schemeColors[13];
			}
		}
		return base.GetBorderColor2(style, state);
	}

	public override Color GetContentShortTextColor1(PaletteContentStyle style, PaletteState state)
	{
		switch (style)
		{
		case PaletteContentStyle.ButtonStandalone:
		case PaletteContentStyle.ButtonAlternate:
		case PaletteContentStyle.ButtonCluster:
		case PaletteContentStyle.ButtonGallery:
		case PaletteContentStyle.ButtonCustom1:
		case PaletteContentStyle.ButtonCustom2:
		case PaletteContentStyle.ButtonCustom3:
			if (state == PaletteState.NormalDefaultOverride)
			{
				return _schemeColors[2];
			}
			break;
		case PaletteContentStyle.ButtonNavigatorStack:
		case PaletteContentStyle.ButtonNavigatorOverflow:
		case PaletteContentStyle.ButtonNavigatorMini:
			if (state == PaletteState.NormalDefaultOverride)
			{
				return _schemeColors[2];
			}
			return _schemeColors[218];
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderDockInactive:
		case PaletteContentStyle.HeaderCalendar:
			if (state != PaletteState.Disabled)
			{
				return Color.White;
			}
			break;
		}
		return base.GetContentShortTextColor1(style, state);
	}

	public override Color GetContentShortTextColor2(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return Color.Empty;
		}
		switch (style)
		{
		case PaletteContentStyle.ButtonNavigatorStack:
		case PaletteContentStyle.ButtonNavigatorOverflow:
		case PaletteContentStyle.ButtonNavigatorMini:
			if (state == PaletteState.NormalDefaultOverride)
			{
				return _schemeColors[2];
			}
			return _schemeColors[218];
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderDockInactive:
		case PaletteContentStyle.HeaderCalendar:
			if (state != PaletteState.Disabled)
			{
				return Color.White;
			}
			break;
		}
		return base.GetContentShortTextColor2(style, state);
	}

	public override Color GetContentLongTextColor1(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return Color.Empty;
		}
		switch (style)
		{
		case PaletteContentStyle.ButtonNavigatorStack:
		case PaletteContentStyle.ButtonNavigatorOverflow:
		case PaletteContentStyle.ButtonNavigatorMini:
			if (state == PaletteState.NormalDefaultOverride)
			{
				return _schemeColors[2];
			}
			return _schemeColors[218];
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderDockInactive:
		case PaletteContentStyle.HeaderCalendar:
			if (state != PaletteState.Disabled)
			{
				return Color.White;
			}
			break;
		}
		return base.GetContentLongTextColor1(style, state);
	}

	public override Color GetContentLongTextColor2(PaletteContentStyle style, PaletteState state)
	{
		if (CommonHelper.IsOverrideState(state))
		{
			return Color.Empty;
		}
		switch (style)
		{
		case PaletteContentStyle.ButtonNavigatorStack:
		case PaletteContentStyle.ButtonNavigatorOverflow:
		case PaletteContentStyle.ButtonNavigatorMini:
			if (state == PaletteState.NormalDefaultOverride)
			{
				return _schemeColors[2];
			}
			return _schemeColors[218];
		case PaletteContentStyle.HeaderPrimary:
		case PaletteContentStyle.HeaderDockInactive:
		case PaletteContentStyle.HeaderCalendar:
			if (state != PaletteState.Disabled)
			{
				return Color.White;
			}
			break;
		}
		return base.GetContentLongTextColor2(style, state);
	}

	public override Image GetDropDownButtonImage(PaletteState state)
	{
		if (state != PaletteState.Disabled)
		{
			return _blackDropDownButton;
		}
		return base.GetDropDownButtonImage(state);
	}

	public override Image GetContextMenuSubMenuImage()
	{
		return _contextMenuSubMenu;
	}

	public override Image GetButtonSpecImage(PaletteButtonSpecStyle style, PaletteState state)
	{
		switch (style)
		{
		case PaletteButtonSpecStyle.PendantClose:
			return _buttonSpecPendantClose;
		case PaletteButtonSpecStyle.PendantMin:
			return _buttonSpecPendantMin;
		case PaletteButtonSpecStyle.PendantRestore:
			return _buttonSpecPendantRestore;
		case PaletteButtonSpecStyle.FormClose:
			if (state == PaletteState.Tracking || state == PaletteState.Pressed)
			{
				return _formCloseH;
			}
			return _formClose;
		case PaletteButtonSpecStyle.FormMin:
			return _formMin;
		case PaletteButtonSpecStyle.FormMax:
			return _formMax;
		case PaletteButtonSpecStyle.FormRestore:
			return _formRestore;
		case PaletteButtonSpecStyle.RibbonMinimize:
			return _buttonSpecRibbonMinimize;
		case PaletteButtonSpecStyle.RibbonExpand:
			return _buttonSpecRibbonExpand;
		default:
			return base.GetButtonSpecImage(style, state);
		}
	}

	public override Color GetRibbonTextColor(PaletteRibbonTextStyle style, PaletteState state)
	{
		switch (style)
		{
		case PaletteRibbonTextStyle.RibbonGroupNormalTitle:
			if (state == PaletteState.Disabled)
			{
				return _disabledRibbonText;
			}
			break;
		case PaletteRibbonTextStyle.RibbonGroupButtonText:
		case PaletteRibbonTextStyle.RibbonGroupLabelText:
		case PaletteRibbonTextStyle.RibbonGroupCheckBoxText:
		case PaletteRibbonTextStyle.RibbonGroupRadioButtonText:
			if (state == PaletteState.Disabled)
			{
				return _disabledRibbonText;
			}
			break;
		}
		return base.GetRibbonTextColor(style, state);
	}

	public override PaletteRibbonColorStyle GetRibbonBackColorStyle(PaletteRibbonBackStyle style, PaletteState state)
	{
		switch (style)
		{
		case PaletteRibbonBackStyle.RibbonTab:
			switch (state)
			{
			case PaletteState.Tracking:
			case PaletteState.Pressed:
			case PaletteState.ContextTracking:
				return PaletteRibbonColorStyle.RibbonTabTracking2010Alt;
			case PaletteState.CheckedNormal:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
			case PaletteState.ContextCheckedNormal:
			case PaletteState.ContextCheckedTracking:
				return PaletteRibbonColorStyle.RibbonTabSelected2010Alt;
			}
			break;
		case PaletteRibbonBackStyle.RibbonGroupNormalBorder:
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBorder:
			switch (state)
			{
			case PaletteState.Tracking:
			case PaletteState.ContextTracking:
				return PaletteRibbonColorStyle.RibbonGroupNormalBorderSepTrackingDark;
			case PaletteState.Pressed:
				return PaletteRibbonColorStyle.RibbonGroupNormalBorderSepPressedDark;
			}
			break;
		}
		return base.GetRibbonBackColorStyle(style, state);
	}
}
