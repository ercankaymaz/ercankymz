using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit.Properties;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteOffice2007Blue : PaletteOffice2007Base
{
	private static readonly ImageList _checkBoxList;

	private static readonly ImageList _galleryButtonList;

	private static readonly Image[] _radioButtonArray;

	private static readonly Image _blueDropDownButton;

	private static readonly Image _blueCloseA;

	private static readonly Image _blueCloseI;

	private static readonly Image _blueMaxA;

	private static readonly Image _blueMaxI;

	private static readonly Image _blueMinA;

	private static readonly Image _blueMinI;

	private static readonly Image _blueRestoreA;

	private static readonly Image _blueRestoreI;

	private static readonly Image _contextMenuSubMenu;

	private static readonly Color[] _trackBarColors;

	private static readonly Color[] _schemeColors;

	static PaletteOffice2007Blue()
	{
		_blueDropDownButton = Resources.BlueDropDownButton;
		_blueCloseA = Resources.BlueButtonCloseA;
		_blueCloseI = Resources.BlueButtonCloseI;
		_blueMaxA = Resources.BlueButtonMaxA;
		_blueMaxI = Resources.BlueButtonMaxI;
		_blueMinA = Resources.BlueButtonMinA;
		_blueMinI = Resources.BlueButtonMinI;
		_blueRestoreA = Resources.BlueButtonRestoreA;
		_blueRestoreI = Resources.BlueButtonRestoreI;
		_contextMenuSubMenu = Resources.BlueContextMenuSub;
		_trackBarColors = new Color[6]
		{
			Color.FromArgb(116, 150, 194),
			Color.FromArgb(116, 150, 194),
			Color.FromArgb(152, 190, 241),
			Color.FromArgb(142, 180, 231),
			Color.FromArgb(64, Color.White),
			Color.FromArgb(63, 101, 152)
		};
		_schemeColors = new Color[213]
		{
			Color.FromArgb(21, 66, 139),
			Color.FromArgb(21, 66, 139),
			Color.Black,
			Color.FromArgb(161, 189, 207),
			Color.FromArgb(121, 157, 182),
			Color.FromArgb(210, 225, 244),
			Color.FromArgb(235, 243, 254),
			Color.FromArgb(123, 192, 232),
			Color.FromArgb(177, 252, 255),
			Color.FromArgb(178, 214, 255),
			Color.FromArgb(202, 229, 255),
			Color.FromArgb(191, 219, 255),
			Color.FromArgb(177, 208, 248),
			Color.FromArgb(101, 147, 207),
			Color.FromArgb(227, 239, 255),
			Color.FromArgb(182, 214, 255),
			Color.FromArgb(227, 239, 255),
			Color.FromArgb(175, 210, 255),
			Color.FromArgb(214, 232, 255),
			Color.FromArgb(214, 232, 255),
			Color.FromArgb(21, 66, 139),
			Color.FromArgb(21, 66, 139),
			Color.FromArgb(121, 153, 194),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(154, 198, 255),
			Color.FromArgb(248, 248, 248),
			Color.FromArgb(114, 152, 204),
			Color.FromArgb(191, 219, 255),
			Color.FromArgb(215, 229, 247),
			Color.FromArgb(172, 201, 238),
			Color.FromArgb(233, 238, 238),
			Color.FromArgb(227, 239, 255),
			Color.FromArgb(222, 236, 255),
			Color.FromArgb(152, 186, 230),
			Color.FromArgb(167, 204, 251),
			Color.FromArgb(167, 204, 251),
			Color.FromArgb(101, 147, 207),
			Color.FromArgb(111, 157, 217),
			Color.FromArgb(59, 90, 130),
			Color.FromArgb(192, 198, 206),
			Color.FromArgb(176, 203, 239),
			Color.FromArgb(194, 217, 247),
			Color.FromArgb(204, 216, 232),
			Color.FromArgb(212, 222, 236),
			Color.FromArgb(221, 233, 248),
			Color.FromArgb(223, 229, 237),
			Color.FromArgb(176, 207, 247),
			Color.FromArgb(228, 239, 253),
			Color.FromArgb(204, 218, 236),
			Color.FromArgb(227, 232, 239),
			Color.FromArgb(62, 106, 184),
			Color.FromArgb(160, 160, 160),
			Color.FromArgb(105, 112, 121),
			Color.FromArgb(160, 160, 160),
			Color.FromArgb(158, 193, 241),
			Color.FromArgb(210, 228, 254),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(162, 191, 227),
			Color.FromArgb(132, 178, 233),
			Color.FromArgb(192, 231, 252),
			Color.FromArgb(21, 66, 139),
			Color.FromArgb(21, 66, 139),
			Color.FromArgb(21, 66, 139),
			Color.Blue,
			Color.Purple,
			Color.Red,
			Color.Blue,
			Color.Purple,
			Color.Red,
			Color.FromArgb(21, 66, 139),
			Color.FromArgb(21, 66, 139),
			Color.FromArgb(21, 66, 139),
			Color.FromArgb(145, 180, 228),
			Color.FromArgb(209, 251, 255),
			Color.FromArgb(246, 250, 255),
			Color.FromArgb(239, 246, 254),
			Color.FromArgb(222, 232, 245),
			Color.FromArgb(153, 187, 232),
			Color.FromArgb(255, 180, 86),
			Color.FromArgb(255, 255, 189),
			Color.FromArgb(249, 237, 198),
			Color.FromArgb(218, 185, 127),
			Color.FromArgb(254, 209, 94),
			Color.FromArgb(205, 209, 180),
			Color.FromArgb(116, 153, 203),
			Color.FromArgb(141, 178, 227),
			Color.FromArgb(192, 249, 255),
			Color.FromArgb(201, 217, 237),
			Color.FromArgb(231, 242, 255),
			Color.FromArgb(219, 230, 244),
			Color.FromArgb(197, 210, 223),
			Color.FromArgb(158, 191, 219),
			Color.FromArgb(193, 216, 242),
			Color.FromArgb(193, 216, 242),
			Color.FromArgb(202, 202, 202),
			Color.FromArgb(196, 196, 196),
			Color.FromArgb(223, 223, 245),
			Color.FromArgb(210, 221, 242),
			Color.FromArgb(102, 142, 175),
			Color.FromArgb(254, 254, 255),
			Color.FromArgb(200, 224, 255),
			Color.FromArgb(214, 237, 255),
			Color.FromArgb(155, 187, 227),
			Color.FromArgb(213, 226, 243),
			Color.FromArgb(165, 191, 213),
			Color.FromArgb(148, 185, 213),
			Color.FromArgb(64, Color.White),
			Color.FromArgb(202, 244, 254),
			Color.FromArgb(221, 233, 249),
			Color.FromArgb(199, 218, 243),
			Color.FromArgb(186, 209, 240),
			Color.FromArgb(214, 238, 252),
			Color.FromArgb(186, 205, 225),
			Color.FromArgb(177, 230, 235),
			Color.FromArgb(192, Color.White),
			Color.FromArgb(247, 251, 254),
			Color.FromArgb(240, 244, 250),
			Color.FromArgb(226, 234, 245),
			Color.FromArgb(216, 227, 241),
			Color.FromArgb(214, 237, 253),
			Color.FromArgb(170, 195, 217),
			Color.FromArgb(195, 217, 242),
			Color.FromArgb(227, 237, 250),
			Color.FromArgb(221, 233, 248),
			Color.FromArgb(214, 228, 246),
			Color.FromArgb(227, 236, 248),
			Color.FromArgb(21, 66, 139),
			Color.FromArgb(118, 153, 200),
			Color.FromArgb(184, 215, 253),
			Color.FromArgb(135, 156, 175),
			Color.FromArgb(177, 198, 216),
			Color.FromArgb(150, 194, 239),
			Color.FromArgb(210, 228, 254),
			Color.FromArgb(158, 193, 241),
			Color.FromArgb(140, 184, 229),
			Color.FromArgb(225, 241, 255),
			Color.FromArgb(154, 179, 213),
			Color.FromArgb(219, 231, 247),
			Color.FromArgb(195, 213, 236),
			Color.FromArgb(128, Color.White),
			Color.FromArgb(72, Color.White),
			Color.FromArgb(153, 176, 206),
			Color.FromArgb(226, 233, 241),
			Color.FromArgb(198, 210, 226),
			Color.FromArgb(128, Color.White),
			Color.FromArgb(72, Color.White),
			Color.FromArgb(178, 205, 237),
			Color.FromArgb(170, 197, 234),
			Color.FromArgb(126, 161, 205),
			Color.FromArgb(86, 125, 177),
			Color.FromArgb(234, 242, 249),
			Color.FromArgb(192, 220, 255),
			Color.FromArgb(55, 100, 160),
			Color.FromArgb(140, 172, 211),
			Color.FromArgb(248, 250, 252),
			Color.FromArgb(192, 212, 241),
			Color.FromArgb(200, 219, 238),
			Color.FromArgb(155, 183, 224),
			Color.FromArgb(117, 150, 191),
			Color.FromArgb(213, 228, 242),
			Color.White,
			Color.FromArgb(196, 221, 255),
			Color.FromArgb(194, 220, 255),
			Color.FromArgb(252, 253, 255),
			Color.FromArgb(170, 195, 240),
			Color.FromArgb(249, 252, 253),
			Color.FromArgb(211, 219, 233),
			Color.FromArgb(223, 226, 228),
			Color.FromArgb(188, 197, 210),
			Color.FromArgb(249, 217, 159),
			Color.FromArgb(241, 193, 95),
			Color.FromArgb(228, 236, 247),
			Color.FromArgb(187, 196, 209),
			Color.FromArgb(255, 213, 141),
			Color.FromArgb(188, 195, 209),
			Color.FromArgb(194, 217, 240),
			Color.Black,
			Color.FromArgb(172, 168, 153),
			Color.FromArgb(171, 193, 222),
			Color.FromArgb(177, 187, 198),
			Color.FromArgb(255, 255, 255),
			SystemColors.Control,
			Color.FromArgb(234, 242, 251),
			Color.FromArgb(86, 125, 177),
			Color.FromArgb(255, 248, 203),
			Color.FromArgb(172, 168, 153),
			Color.Transparent,
			Color.FromArgb(221, 231, 238),
			Color.FromArgb(0, 21, 110),
			Color.FromArgb(233, 238, 238),
			Color.White,
			Color.FromArgb(201, 238, 255),
			Color.FromArgb(155, 175, 202),
			Color.FromArgb(189, 211, 238),
			Color.FromArgb(176, 201, 234),
			Color.FromArgb(207, 224, 245),
			Color.White,
			Color.FromArgb(155, 175, 202),
			Color.FromArgb(233, 234, 238),
			Color.FromArgb(0, 21, 110),
			Color.FromArgb(227, 239, 255),
			Color.FromArgb(182, 214, 255),
			Color.FromArgb(185, 208, 237),
			Color.FromArgb(212, 230, 248),
			Color.FromArgb(236, 243, 251),
			Color.FromArgb(193, 213, 241),
			Color.FromArgb(215, 233, 251),
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.Empty
		};
		_checkBoxList = new ImageList();
		_checkBoxList.ImageSize = new Size(13, 13);
		_checkBoxList.ColorDepth = ColorDepth.Depth24Bit;
		_checkBoxList.Images.AddStrip(Resources.CB2007Blue);
		_galleryButtonList = new ImageList();
		_galleryButtonList.ImageSize = new Size(13, 7);
		_galleryButtonList.ColorDepth = ColorDepth.Depth24Bit;
		_galleryButtonList.TransparentColor = Color.Magenta;
		_galleryButtonList.Images.AddStrip(Resources.GalleryBlue);
		_radioButtonArray = new Image[8]
		{
			Resources.RB2007BlueD,
			Resources.RB2007BlueN,
			Resources.RB2007BlueT,
			Resources.RB2007BlueP,
			Resources.RB2007BlueDC,
			Resources.RB2007BlueNC,
			Resources.RB2007BlueTC,
			Resources.RB2007BluePC
		};
	}

	public PaletteOffice2007Blue()
		: base(_schemeColors, _checkBoxList, _galleryButtonList, _radioButtonArray, _trackBarColors)
	{
	}

	public override PaletteColorStyle GetBackColorStyle(PaletteBackStyle style, PaletteState state)
	{
		if (style == PaletteBackStyle.HeaderForm)
		{
			return PaletteColorStyle.Rounding4;
		}
		return base.GetBackColorStyle(style, state);
	}

	public override Image GetDropDownButtonImage(PaletteState state)
	{
		if (state != PaletteState.Disabled)
		{
			return _blueDropDownButton;
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
		case PaletteButtonSpecStyle.FormClose:
			if (state == PaletteState.Disabled)
			{
				return _blueCloseI;
			}
			return _blueCloseA;
		case PaletteButtonSpecStyle.FormMin:
			if (state == PaletteState.Disabled)
			{
				return _blueMinI;
			}
			return _blueMinA;
		case PaletteButtonSpecStyle.FormMax:
			if (state == PaletteState.Disabled)
			{
				return _blueMaxI;
			}
			return _blueMaxA;
		case PaletteButtonSpecStyle.FormRestore:
			if (state == PaletteState.Disabled)
			{
				return _blueRestoreI;
			}
			return _blueRestoreA;
		default:
			return base.GetButtonSpecImage(style, state);
		}
	}

	public override PaletteRibbonColorStyle GetRibbonBackColorStyle(PaletteRibbonBackStyle style, PaletteState state)
	{
		switch (style)
		{
		case PaletteRibbonBackStyle.RibbonGroupArea:
			if (state == PaletteState.CheckedNormal)
			{
				return PaletteRibbonColorStyle.RibbonGroupAreaBorder;
			}
			break;
		case PaletteRibbonBackStyle.RibbonGroupNormalBorder:
			if (state == PaletteState.Tracking)
			{
				return PaletteRibbonColorStyle.RibbonGroupNormalBorderTrackingLight;
			}
			break;
		}
		return base.GetRibbonBackColorStyle(style, state);
	}
}
