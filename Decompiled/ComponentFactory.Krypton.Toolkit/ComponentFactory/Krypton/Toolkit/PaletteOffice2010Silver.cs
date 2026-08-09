using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit.Properties;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteOffice2010Silver : PaletteOffice2010Base
{
	private static readonly ImageList _checkBoxList;

	private static readonly ImageList _galleryButtonList;

	private static readonly Image[] _radioButtonArray;

	private static readonly Image _silverDropDownButton;

	private static readonly Image _contextMenuSubMenu;

	private static readonly Image _formCloseH;

	private static readonly Image _formClose;

	private static readonly Image _formMax;

	private static readonly Image _formMin;

	private static readonly Image _formRestore;

	private static readonly Color[] _trackBarColors;

	private static readonly Color[] _schemeColors;

	static PaletteOffice2010Silver()
	{
		_silverDropDownButton = Resources._2010BlueDropDownButton;
		_contextMenuSubMenu = Resources._2010BlueContextMenuSub;
		_formCloseH = Resources._2010ButtonCloseH;
		_formClose = Resources._2010ButtonClose;
		_formMax = Resources._2010ButtonMax;
		_formMin = Resources._2010ButtonMin;
		_formRestore = Resources._2010ButtonRestore;
		_trackBarColors = new Color[6]
		{
			Color.FromArgb(170, 170, 170),
			Color.FromArgb(166, 170, 175),
			Color.FromArgb(226, 220, 235),
			Color.FromArgb(206, 200, 215),
			Color.FromArgb(64, Color.White),
			Color.FromArgb(80, 81, 82)
		};
		_schemeColors = new Color[226]
		{
			Color.FromArgb(59, 59, 59),
			Color.FromArgb(59, 59, 59),
			Color.Black,
			Color.FromArgb(187, 191, 196),
			Color.FromArgb(158, 166, 172),
			Color.FromArgb(247, 250, 252),
			Color.FromArgb(231, 234, 238),
			Color.FromArgb(235, 235, 235),
			Color.FromArgb(195, 195, 195),
			Color.FromArgb(207, 212, 218),
			Color.FromArgb(207, 212, 218),
			Color.FromArgb(227, 230, 232),
			Color.FromArgb(207, 212, 218),
			Color.FromArgb(161, 169, 179),
			Color.FromArgb(250, 253, 255),
			Color.FromArgb(227, 232, 237),
			Color.FromArgb(233, 237, 241),
			Color.FromArgb(207, 212, 218),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(234, 237, 241),
			Color.FromArgb(59, 59, 59),
			Color.FromArgb(59, 59, 59),
			Color.FromArgb(236, 199, 87),
			Color.FromArgb(247, 250, 252),
			Color.FromArgb(119, 123, 127),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(181, 190, 199),
			Color.FromArgb(227, 230, 232),
			Color.FromArgb(230, 234, 238),
			Color.FromArgb(183, 188, 193),
			Color.White,
			Color.FromArgb(230, 234, 238),
			Color.FromArgb(183, 188, 193),
			Color.FromArgb(183, 188, 193),
			Color.FromArgb(147, 154, 163),
			Color.FromArgb(147, 154, 163),
			Color.FromArgb(147, 154, 163),
			Color.FromArgb(147, 154, 163),
			Color.FromArgb(101, 109, 117),
			Color.FromArgb(134, 139, 145),
			Color.FromArgb(228, 230, 232),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(248, 247, 247),
			Color.FromArgb(248, 247, 247),
			Color.FromArgb(101, 109, 117),
			Color.FromArgb(134, 139, 145),
			Color.FromArgb(235, 237, 240),
			Color.FromArgb(228, 230, 232),
			Color.FromArgb(248, 247, 247),
			Color.FromArgb(248, 247, 247),
			Color.FromArgb(59, 59, 59),
			Color.FromArgb(138, 138, 138),
			Color.FromArgb(59, 59, 59),
			Color.FromArgb(138, 138, 138),
			Color.FromArgb(166, 172, 179),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(228, 228, 229),
			Color.FromArgb(166, 172, 179),
			Color.FromArgb(223, 228, 235),
			Color.FromArgb(188, 193, 200),
			Color.Black,
			Color.Black,
			Color.Black,
			Color.Blue,
			Color.Purple,
			Color.Red,
			Color.Blue,
			Color.Purple,
			Color.Red,
			Color.FromArgb(59, 59, 59),
			Color.FromArgb(59, 59, 59),
			Color.FromArgb(76, 83, 92),
			Color.FromArgb(182, 186, 191),
			Color.White,
			Color.White,
			Color.White,
			Color.White,
			Color.FromArgb(177, 181, 186),
			Color.FromArgb(248, 249, 249),
			Color.FromArgb(182, 186, 191),
			Color.White,
			Color.White,
			Color.White,
			Color.White,
			Color.FromArgb(182, 186, 191),
			Color.FromArgb(182, 186, 191),
			Color.FromArgb(135, 140, 146),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(229, 233, 238),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(253, 253, 253),
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.FromArgb(148, 149, 152),
			Color.FromArgb(180, 182, 183),
			Color.Empty,
			Color.Empty,
			Color.FromArgb(139, 144, 151),
			Color.FromArgb(205, 209, 214),
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
			Color.FromArgb(242, 244, 247),
			Color.FromArgb(238, 241, 245),
			Color.FromArgb(234, 235, 235),
			Color.FromArgb(208, 212, 217),
			Color.FromArgb(208, 212, 217),
			Color.FromArgb(254, 254, 254),
			Color.FromArgb(254, 254, 254),
			Color.Empty,
			Color.Empty,
			Color.FromArgb(59, 59, 59),
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
			Color.FromArgb(223, 227, 234),
			Color.FromArgb(213, 217, 222),
			Color.FromArgb(135, 140, 146),
			Color.FromArgb(90, 90, 90),
			Color.FromArgb(210, 212, 215),
			Color.FromArgb(233, 237, 241),
			Color.FromArgb(138, 144, 150),
			Color.FromArgb(191, 195, 199),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(231, 234, 238),
			Color.FromArgb(241, 243, 243),
			Color.FromArgb(197, 198, 199),
			Color.FromArgb(157, 158, 159),
			Color.FromArgb(238, 238, 244),
			Color.FromArgb(248, 252, 255),
			Color.FromArgb(223, 227, 232),
			Color.FromArgb(203, 207, 212),
			Color.White,
			Color.FromArgb(186, 189, 194),
			Color.FromArgb(238, 241, 247),
			Color.FromArgb(218, 222, 227),
			Color.FromArgb(255, 223, 107),
			Color.FromArgb(255, 252, 230),
			Color.FromArgb(255, 211, 89),
			Color.FromArgb(255, 239, 113),
			Color.FromArgb(223, 227, 232),
			Color.FromArgb(255, 223, 107),
			Color.FromArgb(245, 210, 87),
			Color.FromArgb(218, 220, 221),
			Color.FromArgb(183, 219, 255),
			Color.Black,
			Color.FromArgb(168, 168, 168),
			Color.FromArgb(212, 214, 217),
			Color.FromArgb(187, 187, 187),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(240, 240, 240),
			Color.FromArgb(247, 247, 247),
			Color.Black,
			Color.Transparent,
			Color.FromArgb(172, 168, 153),
			Color.Transparent,
			Color.FromArgb(240, 242, 245),
			Color.FromArgb(59, 59, 59),
			Color.White,
			Color.FromArgb(224, 227, 231),
			Color.FromArgb(224, 227, 231),
			Color.FromArgb(135, 140, 146),
			Color.FromArgb(224, 227, 231),
			Color.FromArgb(224, 227, 231),
			Color.FromArgb(224, 227, 231),
			Color.Empty,
			Color.FromArgb(135, 140, 146),
			Color.White,
			Color.Black,
			Color.FromArgb(250, 253, 255),
			Color.FromArgb(227, 232, 237),
			Color.FromArgb(198, 202, 205),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(250, 250, 250),
			Color.FromArgb(228, 231, 235),
			Color.FromArgb(229, 231, 235),
			Color.FromArgb(231, 233, 235),
			Color.FromArgb(176, 182, 188),
			Color.FromArgb(246, 247, 248),
			Color.FromArgb(249, 250, 250),
			Color.FromArgb(102, 109, 124),
			Color.FromArgb(151, 156, 163),
			Color.FromArgb(39, 49, 60),
			Color.FromArgb(237, 242, 248),
			Color.FromArgb(207, 213, 220),
			Color.FromArgb(161, 169, 179),
			Color.Black,
			Color.FromArgb(207, 213, 220),
			Color.FromArgb(232, 234, 238),
			Color.FromArgb(191, 196, 202),
			Color.FromArgb(225, 226, 230),
			Color.FromArgb(222, 227, 234),
			Color.FromArgb(206, 214, 221),
			Color.FromArgb(221, 221, 221)
		};
		_checkBoxList = new ImageList();
		_checkBoxList.ImageSize = new Size(13, 13);
		_checkBoxList.ColorDepth = ColorDepth.Depth24Bit;
		_checkBoxList.Images.AddStrip(Resources.CB2010Silver);
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

	public PaletteOffice2010Silver()
		: base(_schemeColors, _checkBoxList, _galleryButtonList, _radioButtonArray, _trackBarColors)
	{
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
		default:
			return base.GetButtonSpecImage(style, state);
		}
	}
}
