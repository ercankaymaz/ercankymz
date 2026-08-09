using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit.Properties;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteOffice2007Black : PaletteOffice2007Base
{
	private static readonly ImageList _checkBoxList;

	private static readonly ImageList _galleryButtonList;

	private static readonly Image[] _radioButtonArray;

	private static readonly Image _blackDropDownButton;

	private static readonly Image _blackCloseA;

	private static readonly Image _blackCloseAH;

	private static readonly Image _blackCloseI;

	private static readonly Image _blackMaxA;

	private static readonly Image _blackMaxAH;

	private static readonly Image _blackMaxI;

	private static readonly Image _blackMinA;

	private static readonly Image _blackMinAH;

	private static readonly Image _blackMinI;

	private static readonly Image _blackRestoreA;

	private static readonly Image _blackRestoreAH;

	private static readonly Image _blackRestoreI;

	private static readonly Image _blackRibbonMinimize;

	private static readonly Image _blackRibbonExpand;

	private static readonly Image _contextMenuSubMenu;

	private static readonly Color[] _trackBarColors;

	private static readonly Color[] _schemeColors;

	static PaletteOffice2007Black()
	{
		_blackDropDownButton = Resources.BlackDropDownButton;
		_blackCloseA = Resources.BlackButtonCloseA;
		_blackCloseAH = Resources.BlackButtonCloseAH;
		_blackCloseI = Resources.BlackButtonCloseI;
		_blackMaxA = Resources.BlackButtonMaxA;
		_blackMaxAH = Resources.BlackButtonMaxAH;
		_blackMaxI = Resources.BlackButtonMaxI;
		_blackMinA = Resources.BlackButtonMinA;
		_blackMinAH = Resources.BlackButtonMinAH;
		_blackMinI = Resources.BlackButtonMinI;
		_blackRestoreA = Resources.BlackButtonRestoreA;
		_blackRestoreAH = Resources.BlackButtonRestoreAH;
		_blackRestoreI = Resources.BlackButtonRestoreI;
		_blackRibbonMinimize = Resources.BlackButtonCollapse;
		_blackRibbonExpand = Resources.BlackButtonExpand;
		_contextMenuSubMenu = Resources.BlackContextMenuSub;
		_trackBarColors = new Color[6]
		{
			Color.FromArgb(170, 170, 170),
			Color.FromArgb(37, 37, 37),
			Color.FromArgb(174, 174, 174),
			Color.FromArgb(131, 132, 132),
			Color.Empty,
			Color.FromArgb(35, 35, 35)
		};
		_schemeColors = new Color[213]
		{
			Color.FromArgb(76, 83, 92),
			Color.FromArgb(70, 70, 70),
			Color.Black,
			Color.FromArgb(137, 135, 133),
			Color.FromArgb(127, 125, 123),
			Color.FromArgb(203, 213, 223),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(187, 192, 198),
			Color.FromArgb(224, 227, 231),
			Color.FromArgb(204, 208, 214),
			Color.FromArgb(229, 232, 236),
			Color.FromArgb(83, 83, 83),
			Color.FromArgb(70, 70, 70),
			Color.FromArgb(30, 30, 30),
			Color.FromArgb(167, 167, 167),
			Color.FromArgb(119, 119, 119),
			Color.FromArgb(240, 241, 242),
			Color.FromArgb(189, 193, 200),
			Color.FromArgb(221, 224, 227),
			Color.FromArgb(221, 224, 227),
			Color.Black,
			Color.White,
			Color.FromArgb(155, 163, 167),
			Color.FromArgb(221, 224, 227),
			Color.FromArgb(145, 153, 164),
			Color.FromArgb(228, 228, 228),
			Color.FromArgb(77, 77, 77),
			Color.FromArgb(83, 83, 83),
			Color.FromArgb(178, 177, 178),
			Color.FromArgb(131, 132, 132),
			Color.FromArgb(239, 239, 239),
			Color.FromArgb(210, 213, 218),
			Color.FromArgb(188, 193, 201),
			Color.FromArgb(138, 146, 156),
			Color.FromArgb(178, 183, 191),
			Color.FromArgb(139, 147, 158),
			Color.FromArgb(76, 83, 92),
			Color.FromArgb(76, 83, 92),
			Color.FromArgb(47, 47, 47),
			Color.FromArgb(146, 146, 146),
			Color.FromArgb(77, 77, 77),
			Color.FromArgb(102, 102, 102),
			Color.FromArgb(153, 153, 153),
			Color.FromArgb(171, 171, 171),
			Color.FromArgb(65, 65, 65),
			Color.FromArgb(154, 154, 154),
			Color.FromArgb(42, 43, 43),
			Color.FromArgb(74, 74, 74),
			Color.FromArgb(146, 146, 146),
			Color.FromArgb(158, 158, 158),
			Color.FromArgb(174, 209, 255),
			Color.FromArgb(225, 225, 225),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(225, 225, 225),
			Color.FromArgb(88, 95, 104),
			Color.FromArgb(91, 105, 123),
			Color.FromArgb(173, 199, 214),
			Color.FromArgb(18, 18, 18),
			Color.FromArgb(0, 0, 0),
			Color.FromArgb(65, 83, 102),
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
			Color.White,
			Color.Black,
			Color.FromArgb(190, 190, 190),
			Color.FromArgb(199, 250, 254),
			Color.FromArgb(238, 239, 241),
			Color.FromArgb(241, 241, 241),
			Color.FromArgb(213, 217, 223),
			Color.FromArgb(159, 156, 150),
			Color.FromArgb(235, 194, 39),
			Color.FromArgb(255, 255, 189),
			Color.FromArgb(249, 237, 198),
			Color.FromArgb(218, 185, 127),
			Color.FromArgb(254, 209, 94),
			Color.FromArgb(123, 111, 68),
			Color.FromArgb(54, 54, 54),
			Color.FromArgb(190, 190, 190),
			Color.FromArgb(210, 210, 210),
			Color.FromArgb(180, 187, 197),
			Color.FromArgb(235, 235, 235),
			Color.FromArgb(215, 219, 224),
			Color.FromArgb(174, 176, 180),
			Color.FromArgb(132, 132, 132),
			Color.FromArgb(182, 184, 184),
			Color.FromArgb(159, 160, 160),
			Color.FromArgb(183, 183, 183),
			Color.FromArgb(131, 131, 131),
			Color.FromArgb(190, 190, 190),
			Color.FromArgb(161, 161, 161),
			Color.FromArgb(101, 104, 112),
			Color.FromArgb(235, 235, 235),
			Color.FromArgb(170, 171, 171),
			Color.FromArgb(109, 110, 110),
			Color.FromArgb(79, 79, 79),
			Color.FromArgb(98, 98, 98),
			Color.FromArgb(182, 183, 183),
			Color.FromArgb(112, 112, 112),
			Color.FromArgb(64, Color.White),
			Color.FromArgb(217, 217, 217),
			Color.FromArgb(244, 244, 245),
			Color.FromArgb(200, 205, 212),
			Color.FromArgb(185, 192, 201),
			Color.FromArgb(235, 235, 235),
			Color.FromArgb(188, 193, 214),
			Color.FromArgb(116, 141, 187),
			Color.FromArgb(192, Color.White),
			Color.White,
			Color.FromArgb(246, 246, 246),
			Color.FromArgb(214, 220, 228),
			Color.FromArgb(203, 210, 221),
			Color.FromArgb(235, 235, 235),
			Color.FromArgb(160, 160, 160),
			Color.FromArgb(194, 194, 194),
			Color.FromArgb(239, 240, 241),
			Color.FromArgb(222, 225, 229),
			Color.FromArgb(214, 218, 223),
			Color.FromArgb(222, 225, 230),
			Color.FromArgb(70, 70, 70),
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
			Color.FromArgb(141, 144, 147),
			Color.FromArgb(133, 135, 137),
			Color.FromArgb(93, 96, 100),
			Color.FromArgb(103, 103, 103),
			Color.FromArgb(225, 225, 225),
			Color.FromArgb(118, 128, 142),
			Color.FromArgb(55, 60, 67),
			Color.FromArgb(163, 168, 170),
			Color.FromArgb(230, 233, 235),
			Color.FromArgb(210, 217, 219),
			Color.FromArgb(214, 222, 223),
			Color.FromArgb(179, 188, 191),
			Color.FromArgb(145, 156, 159),
			Color.FromArgb(235, 235, 235),
			Color.White,
			Color.FromArgb(212, 215, 219),
			Color.FromArgb(210, 213, 218),
			Color.FromArgb(252, 253, 253),
			Color.FromArgb(186, 189, 194),
			Color.FromArgb(248, 248, 248),
			Color.FromArgb(222, 222, 222),
			Color.FromArgb(224, 224, 224),
			Color.FromArgb(195, 195, 195),
			Color.FromArgb(249, 217, 159),
			Color.FromArgb(241, 193, 95),
			Color.FromArgb(237, 237, 237),
			Color.FromArgb(196, 196, 196),
			Color.FromArgb(255, 213, 141),
			Color.FromArgb(188, 195, 209),
			Color.FromArgb(194, 217, 240),
			Color.Black,
			Color.FromArgb(172, 168, 153),
			Color.FromArgb(137, 137, 137),
			Color.FromArgb(204, 204, 204),
			Color.White,
			SystemColors.Control,
			Color.FromArgb(232, 232, 232),
			Color.FromArgb(124, 124, 124),
			Color.FromArgb(255, 248, 203),
			Color.FromArgb(172, 168, 153),
			Color.Transparent,
			Color.FromArgb(235, 235, 235),
			Color.FromArgb(76, 83, 92),
			Color.FromArgb(239, 239, 239),
			Color.FromArgb(109, 108, 108),
			Color.FromArgb(104, 103, 103),
			Color.FromArgb(67, 66, 65),
			Color.FromArgb(78, 78, 79),
			Color.FromArgb(47, 47, 47),
			Color.FromArgb(64, 64, 64),
			Color.FromArgb(107, 108, 113),
			Color.FromArgb(67, 66, 65),
			Color.FromArgb(233, 234, 238),
			Color.FromArgb(70, 70, 70),
			Color.FromArgb(240, 241, 242),
			Color.FromArgb(195, 200, 206),
			Color.FromArgb(172, 172, 172),
			Color.FromArgb(218, 226, 226),
			Color.FromArgb(247, 247, 247),
			Color.FromArgb(195, 200, 209),
			Color.FromArgb(217, 220, 224),
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.FromArgb(225, 225, 225),
			Color.FromArgb(103, 103, 103)
		};
		_checkBoxList = new ImageList();
		_checkBoxList.ImageSize = new Size(13, 13);
		_checkBoxList.ColorDepth = ColorDepth.Depth24Bit;
		_checkBoxList.Images.AddStrip(Resources.CB2007Black);
		_galleryButtonList = new ImageList();
		_galleryButtonList.ImageSize = new Size(13, 7);
		_galleryButtonList.ColorDepth = ColorDepth.Depth24Bit;
		_galleryButtonList.TransparentColor = Color.Magenta;
		_galleryButtonList.Images.AddStrip(Resources.GallerySilverBlack);
		_radioButtonArray = new Image[8]
		{
			Resources.RB2007BlueD,
			Resources.RB2007BlackN,
			Resources.RB2007BlackT,
			Resources.RB2007BlackP,
			Resources.RB2007BlueDC,
			Resources.RB2007BlackNC,
			Resources.RB2007BlackTC,
			Resources.RB2007BlackPC
		};
	}

	public PaletteOffice2007Black()
		: base(_schemeColors, _checkBoxList, _galleryButtonList, _radioButtonArray, _trackBarColors)
	{
	}

	public override PaletteColorStyle GetBackColorStyle(PaletteBackStyle style, PaletteState state)
	{
		switch (style)
		{
		case PaletteBackStyle.ButtonForm:
			switch (state)
			{
			case PaletteState.Tracking:
			case PaletteState.Pressed:
			case PaletteState.CheckedTracking:
			case PaletteState.CheckedPressed:
				return PaletteColorStyle.GlassBottom;
			default:
				return PaletteColorStyle.GlassNormalFull;
			}
		case PaletteBackStyle.HeaderForm:
			return PaletteColorStyle.Rounding3;
		default:
			return base.GetBackColorStyle(style, state);
		}
	}

	public override Color GetBackColor2(PaletteBackStyle style, PaletteState state)
	{
		if (style == PaletteBackStyle.TabDock)
		{
			if (state == PaletteState.Normal)
			{
				return _schemeColors[16];
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
		if (style == PaletteContentStyle.ButtonForm)
		{
			if (state == PaletteState.CheckedNormal || state == PaletteState.FocusOverride)
			{
				return _schemeColors[62];
			}
		}
		return base.GetContentShortTextColor1(style, state);
	}

	public override Color GetContentShortTextColor2(PaletteContentStyle style, PaletteState state)
	{
		if (style == PaletteContentStyle.ButtonForm)
		{
			if (state == PaletteState.CheckedNormal || state == PaletteState.FocusOverride)
			{
				return _schemeColors[62];
			}
		}
		return base.GetContentShortTextColor2(style, state);
	}

	public override Color GetContentLongTextColor1(PaletteContentStyle style, PaletteState state)
	{
		if (style == PaletteContentStyle.ButtonForm)
		{
			if (state == PaletteState.CheckedNormal || state == PaletteState.FocusOverride)
			{
				return _schemeColors[62];
			}
		}
		return base.GetContentLongTextColor1(style, state);
	}

	public override Color GetContentLongTextColor2(PaletteContentStyle style, PaletteState state)
	{
		if (style == PaletteContentStyle.ButtonForm)
		{
			if (state == PaletteState.CheckedNormal || state == PaletteState.FocusOverride)
			{
				return _schemeColors[62];
			}
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
		return style switch
		{
			PaletteButtonSpecStyle.FormClose => state switch
			{
				PaletteState.Disabled => _blackCloseI, 
				PaletteState.Tracking => _blackCloseAH, 
				_ => _blackCloseA, 
			}, 
			PaletteButtonSpecStyle.FormMin => state switch
			{
				PaletteState.Disabled => _blackMinI, 
				PaletteState.Tracking => _blackMinAH, 
				_ => _blackMinA, 
			}, 
			PaletteButtonSpecStyle.FormMax => state switch
			{
				PaletteState.Disabled => _blackMaxI, 
				PaletteState.Tracking => _blackMaxAH, 
				_ => _blackMaxA, 
			}, 
			PaletteButtonSpecStyle.FormRestore => state switch
			{
				PaletteState.Disabled => _blackRestoreI, 
				PaletteState.Tracking => _blackRestoreAH, 
				_ => _blackRestoreA, 
			}, 
			PaletteButtonSpecStyle.RibbonMinimize => _blackRibbonMinimize, 
			PaletteButtonSpecStyle.RibbonExpand => _blackRibbonExpand, 
			_ => base.GetButtonSpecImage(style, state), 
		};
	}

	public override PaletteRibbonColorStyle GetRibbonBackColorStyle(PaletteRibbonBackStyle style, PaletteState state)
	{
		if (style == PaletteRibbonBackStyle.RibbonTab)
		{
			if (state == PaletteState.Tracking || state == PaletteState.ContextTracking)
			{
				return PaletteRibbonColorStyle.RibbonTabGlowing;
			}
		}
		return base.GetRibbonBackColorStyle(style, state);
	}
}
