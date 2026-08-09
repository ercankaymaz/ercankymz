using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit.Properties;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteOffice2007Silver : PaletteOffice2007Base
{
	private static readonly ImageList _checkBoxList;

	private static readonly ImageList _galleryButtonList;

	private static readonly Image[] _radioButtonArray;

	private static readonly Image _silverDropDownButton;

	private static readonly Image _silverCloseA;

	private static readonly Image _silverCloseI;

	private static readonly Image _silverMaxA;

	private static readonly Image _silverMaxI;

	private static readonly Image _silverMinA;

	private static readonly Image _silverMinI;

	private static readonly Image _silverRestoreA;

	private static readonly Image _silverRestoreI;

	private static readonly Image _contextMenuSubMenu;

	private static readonly Color[] _trackBarColors;

	private static readonly Color[] _schemeColors;

	static PaletteOffice2007Silver()
	{
		_silverDropDownButton = Resources.SilverDropDownButton;
		_silverCloseA = Resources.SilverButtonCloseA;
		_silverCloseI = Resources.SilverButtonCloseI;
		_silverMaxA = Resources.SilverButtonMaxA;
		_silverMaxI = Resources.SilverButtonMaxI;
		_silverMinA = Resources.SilverButtonMinA;
		_silverMinI = Resources.SilverButtonMinI;
		_silverRestoreA = Resources.SilverButtonRestoreA;
		_silverRestoreI = Resources.SilverButtonRestoreI;
		_contextMenuSubMenu = Resources.SilverContextMenuSub;
		_trackBarColors = new Color[6]
		{
			Color.FromArgb(130, 130, 130),
			Color.FromArgb(156, 160, 165),
			Color.FromArgb(226, 220, 235),
			Color.FromArgb(196, 190, 205),
			Color.FromArgb(64, Color.White),
			Color.FromArgb(80, 81, 82)
		};
		_schemeColors = new Color[213]
		{
			Color.FromArgb(56, 63, 70),
			Color.FromArgb(56, 63, 70),
			Color.Black,
			Color.FromArgb(141, 148, 157),
			Color.FromArgb(131, 138, 147),
			Color.FromArgb(203, 210, 219),
			Color.FromArgb(240, 244, 249),
			Color.FromArgb(186, 185, 206),
			Color.FromArgb(222, 226, 236),
			Color.FromArgb(202, 204, 214),
			Color.FromArgb(222, 226, 236),
			Color.FromArgb(208, 212, 221),
			Color.FromArgb(200, 204, 211),
			Color.FromArgb(111, 112, 116),
			Color.FromArgb(240, 241, 242),
			Color.FromArgb(195, 200, 206),
			Color.FromArgb(246, 247, 248),
			Color.FromArgb(218, 223, 230),
			Color.FromArgb(213, 219, 231),
			Color.FromArgb(213, 219, 231),
			Color.FromArgb(21, 66, 139),
			Color.FromArgb(46, 53, 62),
			Color.FromArgb(155, 163, 167),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(110, 109, 143),
			Color.FromArgb(248, 248, 248),
			Color.FromArgb(112, 118, 126),
			Color.FromArgb(208, 212, 221),
			Color.FromArgb(230, 232, 237),
			Color.FromArgb(189, 195, 202),
			Color.FromArgb(239, 239, 239),
			Color.FromArgb(243, 244, 250),
			Color.FromArgb(218, 219, 231),
			Color.FromArgb(173, 171, 201),
			Color.FromArgb(179, 178, 200),
			Color.FromArgb(152, 151, 177),
			Color.FromArgb(124, 124, 148),
			Color.FromArgb(124, 124, 148),
			Color.FromArgb(114, 120, 128),
			Color.FromArgb(180, 185, 192),
			Color.FromArgb(222, 221, 222),
			Color.FromArgb(187, 186, 186),
			Color.FromArgb(240, 240, 240),
			Color.FromArgb(224, 224, 224),
			Color.FromArgb(172, 175, 183),
			Color.FromArgb(182, 181, 181),
			Color.FromArgb(192, 195, 202),
			Color.FromArgb(240, 243, 250),
			Color.FromArgb(217, 219, 225),
			Color.FromArgb(244, 247, 251),
			Color.FromArgb(53, 110, 170),
			Color.FromArgb(138, 138, 138),
			Color.FromArgb(92, 98, 106),
			Color.FromArgb(138, 138, 138),
			Color.FromArgb(189, 199, 212),
			Color.FromArgb(222, 230, 242),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(149, 154, 160),
			Color.FromArgb(125, 131, 140),
			Color.FromArgb(213, 226, 233),
			Color.Black,
			Color.Black,
			Color.Black,
			Color.Blue,
			Color.Purple,
			Color.Red,
			Color.Blue,
			Color.Purple,
			Color.Red,
			Color.FromArgb(56, 63, 70),
			Color.FromArgb(76, 83, 92),
			Color.FromArgb(76, 83, 92),
			Color.FromArgb(190, 190, 190),
			Color.FromArgb(198, 250, 255),
			Color.FromArgb(247, 248, 249),
			Color.FromArgb(245, 245, 247),
			Color.FromArgb(239, 234, 241),
			Color.FromArgb(189, 190, 193),
			Color.FromArgb(255, 180, 86),
			Color.FromArgb(255, 255, 189),
			Color.FromArgb(249, 237, 198),
			Color.FromArgb(218, 185, 127),
			Color.FromArgb(254, 209, 94),
			Color.FromArgb(205, 209, 180),
			Color.FromArgb(175, 176, 179),
			Color.FromArgb(190, 190, 190),
			Color.FromArgb(210, 210, 210),
			Color.FromArgb(213, 219, 231),
			Color.FromArgb(249, 249, 249),
			Color.FromArgb(243, 245, 249),
			Color.FromArgb(189, 191, 193),
			Color.FromArgb(133, 133, 133),
			Color.FromArgb(223, 227, 239),
			Color.FromArgb(195, 199, 209),
			Color.FromArgb(183, 183, 183),
			Color.FromArgb(131, 131, 131),
			Color.FromArgb(223, 227, 239),
			Color.FromArgb(195, 199, 209),
			Color.FromArgb(101, 104, 112),
			Color.FromArgb(242, 242, 242),
			Color.FromArgb(222, 226, 238),
			Color.FromArgb(179, 185, 199),
			Color.FromArgb(128, 128, 128),
			Color.FromArgb(220, 225, 235),
			Color.FromArgb(183, 183, 183),
			Color.FromArgb(145, 145, 145),
			Color.FromArgb(64, Color.White),
			Color.FromArgb(225, 227, 227),
			Color.FromArgb(242, 246, 246),
			Color.FromArgb(207, 212, 220),
			Color.FromArgb(196, 203, 214),
			Color.FromArgb(234, 235, 235),
			Color.FromArgb(188, 193, 213),
			Color.FromArgb(142, 178, 179),
			Color.FromArgb(192, Color.White),
			Color.White,
			Color.FromArgb(245, 248, 248),
			Color.FromArgb(242, 244, 247),
			Color.FromArgb(238, 241, 245),
			Color.FromArgb(234, 235, 235),
			Color.FromArgb(160, 160, 160),
			Color.FromArgb(209, 209, 209),
			Color.FromArgb(239, 242, 243),
			Color.FromArgb(226, 229, 234),
			Color.FromArgb(220, 224, 231),
			Color.FromArgb(232, 234, 238),
			Color.FromArgb(76, 83, 92),
			Color.FromArgb(179, 185, 195),
			Color.FromArgb(216, 224, 224),
			Color.FromArgb(125, 125, 125),
			Color.FromArgb(186, 186, 186),
			Color.FromArgb(157, 166, 174),
			Color.FromArgb(222, 230, 242),
			Color.FromArgb(149, 154, 160),
			Color.FromArgb(147, 156, 164),
			Color.FromArgb(237, 245, 250),
			Color.FromArgb(180, 180, 180),
			Color.FromArgb(210, 215, 221),
			Color.FromArgb(195, 200, 206),
			Color.FromArgb(10, Color.White),
			Color.FromArgb(32, Color.White),
			Color.FromArgb(200, 200, 200),
			Color.FromArgb(233, 234, 238),
			Color.FromArgb(223, 224, 228),
			Color.FromArgb(10, Color.White),
			Color.FromArgb(32, Color.White),
			Color.FromArgb(217, 222, 230),
			Color.FromArgb(214, 219, 227),
			Color.FromArgb(194, 201, 212),
			Color.FromArgb(103, 103, 103),
			Color.FromArgb(225, 225, 225),
			Color.FromArgb(219, 218, 228),
			Color.FromArgb(55, 100, 160),
			Color.FromArgb(173, 177, 181),
			Color.FromArgb(232, 235, 237),
			Color.FromArgb(231, 234, 238),
			Color.FromArgb(241, 243, 243),
			Color.FromArgb(197, 198, 199),
			Color.FromArgb(157, 158, 159),
			Color.FromArgb(238, 238, 244),
			Color.White,
			Color.FromArgb(212, 215, 219),
			Color.FromArgb(210, 213, 218),
			Color.FromArgb(252, 253, 253),
			Color.FromArgb(186, 189, 194),
			Color.FromArgb(241, 243, 243),
			Color.FromArgb(200, 201, 202),
			Color.FromArgb(208, 208, 208),
			Color.FromArgb(166, 166, 166),
			Color.FromArgb(255, 204, 153),
			Color.FromArgb(255, 155, 104),
			Color.FromArgb(231, 231, 231),
			Color.FromArgb(184, 191, 196),
			Color.FromArgb(245, 199, 149),
			Color.FromArgb(188, 195, 209),
			Color.FromArgb(194, 217, 240),
			Color.Black,
			Color.FromArgb(172, 168, 153),
			Color.FromArgb(169, 177, 184),
			Color.FromArgb(177, 187, 198),
			Color.FromArgb(255, 255, 255),
			SystemColors.Control,
			Color.FromArgb(232, 234, 236),
			Color.FromArgb(124, 124, 124),
			Color.FromArgb(255, 248, 203),
			Color.FromArgb(172, 168, 153),
			Color.Transparent,
			Color.FromArgb(235, 235, 235),
			Color.FromArgb(76, 83, 92),
			Color.FromArgb(239, 239, 239),
			Color.FromArgb(250, 250, 250),
			Color.FromArgb(217, 226, 230),
			Color.FromArgb(169, 174, 180),
			Color.FromArgb(207, 212, 217),
			Color.FromArgb(194, 200, 208),
			Color.FromArgb(217, 221, 226),
			Color.FromArgb(250, 250, 250),
			Color.FromArgb(169, 174, 180),
			Color.FromArgb(241, 242, 245),
			Color.FromArgb(76, 83, 92),
			Color.FromArgb(168, 167, 191),
			Color.FromArgb(119, 118, 151),
			Color.FromArgb(169, 177, 184),
			Color.FromArgb(232, 234, 236),
			Color.FromArgb(240, 241, 242),
			Color.FromArgb(195, 200, 209),
			Color.FromArgb(217, 220, 224),
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
		_checkBoxList.Images.AddStrip(Resources.CB2007Silver);
		_galleryButtonList = new ImageList();
		_galleryButtonList.ImageSize = new Size(13, 7);
		_galleryButtonList.ColorDepth = ColorDepth.Depth24Bit;
		_galleryButtonList.TransparentColor = Color.Magenta;
		_galleryButtonList.Images.AddStrip(Resources.GallerySilverBlack);
		_radioButtonArray = new Image[8]
		{
			Resources.RB2007BlueD,
			Resources.RB2007SilverN,
			Resources.RB2007SilverT,
			Resources.RB2007SilverP,
			Resources.RB2007BlueDC,
			Resources.RB2007SilverNC,
			Resources.RB2007SilverTC,
			Resources.RB2007SilverPC
		};
	}

	public PaletteOffice2007Silver()
		: base(_schemeColors, _checkBoxList, _galleryButtonList, _radioButtonArray, _trackBarColors)
	{
	}

	public override PaletteColorStyle GetBackColorStyle(PaletteBackStyle style, PaletteState state)
	{
		if (style == PaletteBackStyle.HeaderForm)
		{
			return PaletteColorStyle.Rounding2;
		}
		return base.GetBackColorStyle(style, state);
	}

	public override Image GetDropDownButtonImage(PaletteState state)
	{
		if (state != PaletteState.Disabled)
		{
			return _silverDropDownButton;
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
				return _silverCloseI;
			}
			return _silverCloseA;
		case PaletteButtonSpecStyle.FormMin:
			if (state == PaletteState.Disabled)
			{
				return _silverMinI;
			}
			return _silverMinA;
		case PaletteButtonSpecStyle.FormMax:
			if (state == PaletteState.Disabled)
			{
				return _silverMaxI;
			}
			return _silverMaxA;
		case PaletteButtonSpecStyle.FormRestore:
			if (state == PaletteState.Disabled)
			{
				return _silverRestoreI;
			}
			return _silverRestoreA;
		default:
			return base.GetButtonSpecImage(style, state);
		}
	}
}
