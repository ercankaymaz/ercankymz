#define DEBUG
using System.Diagnostics;
using System.Drawing;
using Microsoft.Win32;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonColorTableSparkle : KryptonColorTable
{
	private static readonly Color _menuBorder;

	private static readonly Color _menuItemText;

	private static readonly Color _contextMenuBackground;

	private static readonly Color _imageMarginMiddle;

	private static readonly Color _imageMarginEnd;

	private static Font _menuToolFont;

	private static Font _statusFont;

	private Color[] _colors;

	private Color[] _sparkleColors;

	private InheritBool _roundedEdges;

	public override InheritBool UseRoundedEdges => _roundedEdges;

	public override Color ButtonPressedBorder => Color.Black;

	public override Color ButtonPressedGradientBegin => _sparkleColors[8];

	public override Color ButtonPressedGradientMiddle => _sparkleColors[8];

	public override Color ButtonPressedGradientEnd => _sparkleColors[9];

	public override Color ButtonPressedHighlight => _sparkleColors[8];

	public override Color ButtonPressedHighlightBorder => _colors[22];

	public override Color ButtonSelectedBorder => Color.Black;

	public override Color ButtonSelectedGradientBegin => _sparkleColors[6];

	public override Color ButtonSelectedGradientMiddle => _sparkleColors[17];

	public override Color ButtonSelectedGradientEnd => _sparkleColors[7];

	public override Color ButtonSelectedHighlight => _sparkleColors[12];

	public override Color ButtonSelectedHighlightBorder => _colors[22];

	public override Color ButtonCheckedGradientBegin => _sparkleColors[10];

	public override Color ButtonCheckedGradientMiddle => _sparkleColors[10];

	public override Color ButtonCheckedGradientEnd => _sparkleColors[11];

	public override Color ButtonCheckedHighlight => _sparkleColors[10];

	public override Color ButtonCheckedHighlightBorder => _colors[22];

	public override Color CheckBackground => _sparkleColors[20];

	public override Color CheckPressedBackground => _sparkleColors[20];

	public override Color CheckSelectedBackground => _sparkleColors[20];

	public override Color GripLight => _colors[25];

	public override Color GripDark => _colors[26];

	public override Color ImageMarginGradientBegin => _colors[30];

	public override Color ImageMarginGradientMiddle => _imageMarginMiddle;

	public override Color ImageMarginGradientEnd => _imageMarginEnd;

	public override Color ImageMarginRevealedGradientBegin => _colors[30];

	public override Color ImageMarginRevealedGradientMiddle => _colors[30];

	public override Color ImageMarginRevealedGradientEnd => _colors[30];

	public override Color MenuBorder => _menuBorder;

	public override Color MenuItemBorder => _menuBorder;

	public override Color MenuItemSelected => _colors[22];

	public override Color MenuItemPressedGradientBegin => _colors[31];

	public override Color MenuItemPressedGradientEnd => _colors[33];

	public override Color MenuItemPressedGradientMiddle => _colors[32];

	public override Color MenuItemSelectedGradientBegin => _colors[22];

	public override Color MenuItemSelectedGradientEnd => _colors[22];

	public override Color MenuStripGradientBegin => _colors[27];

	public override Color MenuStripGradientEnd => _colors[27];

	public override Color OverflowButtonGradientBegin => _colors[34];

	public override Color OverflowButtonGradientEnd => _colors[36];

	public override Color OverflowButtonGradientMiddle => _colors[35];

	public override Color RaftingContainerGradientBegin => _colors[27];

	public override Color RaftingContainerGradientEnd => _colors[27];

	public override Color SeparatorLight => _colors[23];

	public override Color SeparatorDark => _colors[24];

	public override Color StatusStripGradientBegin => _colors[28];

	public override Color StatusStripGradientEnd => _colors[29];

	public override Color MenuItemText => _menuItemText;

	public override Color MenuStripText => _colors[69];

	public override Color ToolStripText => _colors[69];

	public override Color StatusStripText => _colors[21];

	public override Font MenuStripFont => _menuToolFont;

	public override Font ToolStripFont => _menuToolFont;

	public override Font StatusStripFont => _statusFont;

	public override Color ToolStripBorder => _colors[37];

	public override Color ToolStripContentPanelGradientBegin => _colors[27];

	public override Color ToolStripContentPanelGradientEnd => _colors[27];

	public override Color ToolStripDropDownBackground => _contextMenuBackground;

	public override Color ToolStripGradientBegin => _colors[31];

	public override Color ToolStripGradientEnd => _colors[33];

	public override Color ToolStripGradientMiddle => _colors[32];

	public override Color ToolStripPanelGradientBegin => _colors[27];

	public override Color ToolStripPanelGradientEnd => _colors[27];

	static KryptonColorTableSparkle()
	{
		_menuBorder = Color.Black;
		_menuItemText = Color.Black;
		_contextMenuBackground = Color.FromArgb(240, 240, 240);
		_imageMarginMiddle = Color.FromArgb(226, 227, 227);
		_imageMarginEnd = Color.White;
		DefineFonts();
		SystemEvents.UserPreferenceChanged += OnUserPreferenceChanged;
	}

	public KryptonColorTableSparkle(Color[] colors, Color[] sparkleColors, InheritBool roundedEdges, IPalette palette)
		: base(palette)
	{
		Debug.Assert(colors != null);
		Debug.Assert(sparkleColors != null);
		_colors = colors;
		_sparkleColors = sparkleColors;
		_roundedEdges = roundedEdges;
	}

	private static void DefineFonts()
	{
		if (_menuToolFont != null)
		{
			_menuToolFont.Dispose();
		}
		if (_statusFont != null)
		{
			_statusFont.Dispose();
		}
		_menuToolFont = new Font("Segoe UI", SystemFonts.MenuFont.SizeInPoints, FontStyle.Regular);
		_statusFont = new Font("Segoe UI", SystemFonts.StatusFont.SizeInPoints, FontStyle.Regular);
	}

	private static void OnUserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
	{
		DefineFonts();
	}
}
