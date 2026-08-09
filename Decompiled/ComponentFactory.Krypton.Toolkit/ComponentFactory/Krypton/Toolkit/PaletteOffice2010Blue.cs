using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit.Properties;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteOffice2010Blue : PaletteOffice2010Base
{
	private static readonly ImageList _checkBoxList;

	private static readonly ImageList _galleryButtonList;

	private static readonly Image[] _radioButtonArray;

	private static readonly Image _blueDropDownButton;

	private static readonly Image _contextMenuSubMenu;

	private static readonly Image _formCloseH;

	private static readonly Image _formClose;

	private static readonly Image _formMax;

	private static readonly Image _formMin;

	private static readonly Image _formRestore;

	private static readonly Color[] _trackBarColors;

	private static readonly Color[] _schemeColors;

	static PaletteOffice2010Blue()
	{
		_blueDropDownButton = Resources._2010BlueDropDownButton;
		_contextMenuSubMenu = Resources._2010BlueContextMenuSub;
		_formCloseH = Resources._2010ButtonCloseH;
		_formClose = Resources._2010ButtonClose;
		_formMax = Resources._2010ButtonMax;
		_formMin = Resources._2010ButtonMin;
		_formRestore = Resources._2010ButtonRestore;
		_trackBarColors = new Color[6]
		{
			Color.FromArgb(116, 150, 194),
			Color.FromArgb(116, 150, 194),
			Color.FromArgb(152, 190, 241),
			Color.FromArgb(142, 180, 231),
			Color.FromArgb(64, Color.White),
			Color.FromArgb(63, 101, 152)
		};
		_schemeColors = new Color[226]
		{
			Color.FromArgb(30, 57, 91),
			Color.FromArgb(30, 57, 91),
			Color.Black,
			Color.FromArgb(171, 186, 208),
			Color.FromArgb(117, 144, 175),
			Color.FromArgb(225, 237, 250),
			Color.FromArgb(208, 223, 238),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(210, 229, 250),
			Color.FromArgb(174, 194, 219),
			Color.FromArgb(174, 194, 219),
			Color.FromArgb(187, 206, 230),
			Color.FromArgb(174, 194, 219),
			Color.FromArgb(133, 158, 191),
			Color.FromArgb(239, 245, 255),
			Color.FromArgb(200, 217, 239),
			Color.FromArgb(207, 221, 238),
			Color.FromArgb(174, 194, 219),
			Color.FromArgb(239, 246, 253),
			Color.FromArgb(216, 228, 242),
			Color.FromArgb(30, 57, 91),
			Color.FromArgb(30, 57, 91),
			Color.FromArgb(236, 199, 87),
			Color.FromArgb(245, 249, 255),
			Color.FromArgb(120, 141, 165),
			Color.FromArgb(212, 225, 241),
			Color.FromArgb(132, 157, 189),
			Color.FromArgb(187, 206, 230),
			Color.FromArgb(220, 232, 246),
			Color.FromArgb(179, 196, 216),
			Color.White,
			Color.FromArgb(220, 232, 246),
			Color.FromArgb(179, 196, 216),
			Color.FromArgb(179, 196, 216),
			Color.FromArgb(132, 157, 189),
			Color.FromArgb(132, 157, 189),
			Color.FromArgb(132, 157, 189),
			Color.FromArgb(132, 157, 189),
			Color.FromArgb(144, 154, 166),
			Color.FromArgb(162, 173, 185),
			Color.FromArgb(187, 206, 230),
			Color.FromArgb(212, 230, 245),
			Color.FromArgb(223, 235, 247),
			Color.FromArgb(223, 235, 247),
			Color.FromArgb(144, 154, 166),
			Color.FromArgb(162, 173, 185),
			Color.FromArgb(193, 212, 236),
			Color.FromArgb(187, 206, 230),
			Color.FromArgb(223, 235, 247),
			Color.FromArgb(223, 235, 247),
			Color.FromArgb(30, 57, 91),
			Color.FromArgb(106, 128, 168),
			Color.FromArgb(30, 57, 91),
			Color.FromArgb(106, 128, 168),
			Color.FromArgb(143, 165, 191),
			Color.FromArgb(214, 234, 255),
			Color.FromArgb(188, 207, 231),
			Color.FromArgb(143, 165, 191),
			Color.FromArgb(187, 206, 230),
			Color.FromArgb(166, 182, 213),
			Color.FromArgb(21, 66, 139),
			Color.FromArgb(21, 66, 139),
			Color.FromArgb(21, 66, 139),
			Color.Blue,
			Color.Purple,
			Color.Red,
			Color.Blue,
			Color.Purple,
			Color.Red,
			Color.FromArgb(30, 57, 91),
			Color.FromArgb(30, 57, 91),
			Color.FromArgb(30, 57, 91),
			Color.FromArgb(159, 178, 199),
			Color.FromArgb(245, 250, 255),
			Color.FromArgb(239, 246, 253),
			Color.FromArgb(239, 246, 253),
			Color.FromArgb(239, 246, 253),
			Color.FromArgb(159, 178, 199),
			Color.FromArgb(237, 241, 247),
			Color.FromArgb(159, 178, 199),
			Color.FromArgb(245, 250, 255),
			Color.FromArgb(239, 246, 253),
			Color.FromArgb(239, 246, 253),
			Color.FromArgb(239, 246, 253),
			Color.FromArgb(182, 186, 191),
			Color.FromArgb(159, 178, 199),
			Color.FromArgb(114, 142, 173),
			Color.FromArgb(239, 246, 253),
			Color.FromArgb(221, 234, 247),
			Color.FromArgb(216, 228, 242),
			Color.FromArgb(235, 240, 246),
			Color.FromArgb(240, 246, 252),
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.Empty,
			Color.FromArgb(135, 142, 152),
			Color.FromArgb(165, 174, 183),
			Color.Empty,
			Color.Empty,
			Color.FromArgb(139, 160, 188),
			Color.FromArgb(198, 218, 240),
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
			Color.FromArgb(189, 203, 218),
			Color.FromArgb(184, 199, 216),
			Color.FromArgb(233, 241, 250),
			Color.FromArgb(222, 233, 246),
			Color.Empty,
			Color.Empty,
			Color.FromArgb(30, 57, 91),
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
			Color.FromArgb(213, 232, 254),
			Color.FromArgb(205, 223, 245),
			Color.FromArgb(114, 142, 173),
			Color.FromArgb(90, 90, 90),
			Color.FromArgb(207, 214, 224),
			Color.FromArgb(222, 236, 252),
			Color.FromArgb(123, 139, 156),
			Color.FromArgb(145, 166, 194),
			Color.FromArgb(239, 245, 250),
			Color.FromArgb(192, 212, 241),
			Color.FromArgb(200, 219, 238),
			Color.FromArgb(155, 183, 224),
			Color.FromArgb(117, 150, 191),
			Color.FromArgb(213, 228, 242),
			Color.FromArgb(244, 249, 255),
			Color.FromArgb(218, 231, 245),
			Color.FromArgb(198, 211, 225),
			Color.FromArgb(244, 249, 255),
			Color.FromArgb(160, 185, 230),
			Color.FromArgb(233, 246, 255),
			Color.FromArgb(213, 226, 240),
			Color.FromArgb(255, 223, 107),
			Color.FromArgb(255, 252, 230),
			Color.FromArgb(255, 211, 89),
			Color.FromArgb(255, 239, 113),
			Color.FromArgb(218, 231, 245),
			Color.FromArgb(255, 223, 107),
			Color.FromArgb(245, 210, 87),
			Color.FromArgb(218, 220, 221),
			Color.FromArgb(183, 219, 255),
			Color.Black,
			Color.FromArgb(168, 168, 168),
			Color.FromArgb(177, 192, 214),
			Color.FromArgb(177, 187, 198),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(240, 240, 240),
			Color.FromArgb(237, 245, 253),
			Color.Black,
			Color.Transparent,
			Color.FromArgb(172, 168, 153),
			Color.Transparent,
			Color.FromArgb(240, 242, 245),
			Color.FromArgb(30, 57, 91),
			Color.White,
			Color.FromArgb(195, 212, 235),
			Color.FromArgb(195, 212, 235),
			Color.FromArgb(114, 142, 173),
			Color.FromArgb(195, 212, 235),
			Color.FromArgb(195, 212, 235),
			Color.FromArgb(195, 212, 235),
			Color.Empty,
			Color.FromArgb(114, 142, 173),
			Color.White,
			Color.Black,
			Color.FromArgb(239, 245, 255),
			Color.FromArgb(200, 217, 239),
			Color.FromArgb(177, 192, 214),
			Color.FromArgb(237, 245, 253),
			Color.FromArgb(242, 247, 252),
			Color.FromArgb(237, 245, 253),
			Color.FromArgb(206, 221, 237),
			Color.FromArgb(214, 222, 234),
			Color.FromArgb(200, 215, 233),
			Color.FromArgb(147, 167, 195),
			Color.FromArgb(226, 236, 247),
			Color.FromArgb(251, 251, 252),
			Color.FromArgb(56, 78, 115),
			Color.FromArgb(151, 156, 163),
			Color.FromArgb(39, 49, 60),
			Color.FromArgb(208, 226, 248),
			Color.FromArgb(178, 196, 218),
			Color.FromArgb(133, 158, 191),
			Color.FromArgb(0, 25, 56),
			Color.FromArgb(177, 198, 224),
			Color.FromArgb(211, 224, 240),
			Color.FromArgb(148, 174, 205),
			Color.FromArgb(198, 214, 231),
			Color.FromArgb(200, 219, 240),
			Color.FromArgb(177, 201, 228),
			Color.FromArgb(201, 217, 239)
		};
		_checkBoxList = new ImageList();
		_checkBoxList.ImageSize = new Size(13, 13);
		_checkBoxList.ColorDepth = ColorDepth.Depth24Bit;
		_checkBoxList.Images.AddStrip(Resources.CB2010Blue);
		_galleryButtonList = new ImageList();
		_galleryButtonList.ImageSize = new Size(13, 7);
		_galleryButtonList.ColorDepth = ColorDepth.Depth24Bit;
		_galleryButtonList.TransparentColor = Color.Magenta;
		_galleryButtonList.Images.AddStrip(Resources.Gallery2010);
		_radioButtonArray = new Image[8]
		{
			Resources.RB2010BlueD,
			Resources.RB2010BlueN,
			Resources.RB2010BlueT,
			Resources.RB2010BlueP,
			Resources.RB2010BlueDC,
			Resources.RB2010BlueNC,
			Resources.RB2010BlueTC,
			Resources.RB2010BluePC
		};
	}

	public PaletteOffice2010Blue()
		: base(_schemeColors, _checkBoxList, _galleryButtonList, _radioButtonArray, _trackBarColors)
	{
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
