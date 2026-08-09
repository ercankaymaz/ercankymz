#define DEBUG
using System.Diagnostics;
using System.Drawing;
using Microsoft.Win32;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonColorTable2007 : KryptonColorTable
{
	private static readonly Color _menuBorder;

	private static readonly Color _menuItemSelectedBegin;

	private static readonly Color _menuItemSelectedEnd;

	private static readonly Color _contextMenuBackground;

	private static readonly Color _checkBackground;

	private static readonly Color _buttonSelectedBegin;

	private static readonly Color _buttonSelectedEnd;

	private static readonly Color _buttonPressedBegin;

	private static readonly Color _buttonPressedEnd;

	private static readonly Color _buttonCheckedBegin;

	private static readonly Color _buttonCheckedEnd;

	private static Font _menuToolFont;

	private static Font _statusFont;

	private Color[] _colors;

	private InheritBool _roundedEdges;

	public Color[] Colors => _colors;

	public override InheritBool UseRoundedEdges => _roundedEdges;

	public override Color ButtonPressedBorder => _colors[22];

	public override Color ButtonPressedGradientBegin => _buttonPressedBegin;

	public override Color ButtonPressedGradientMiddle => _buttonPressedBegin;

	public override Color ButtonPressedGradientEnd => _buttonPressedEnd;

	public override Color ButtonPressedHighlight => _buttonPressedBegin;

	public override Color ButtonPressedHighlightBorder => _colors[22];

	public override Color ButtonSelectedBorder => _colors[22];

	public override Color ButtonSelectedGradientBegin => _buttonSelectedBegin;

	public override Color ButtonSelectedGradientMiddle => _buttonSelectedBegin;

	public override Color ButtonSelectedGradientEnd => _buttonSelectedEnd;

	public override Color ButtonSelectedHighlight => _buttonSelectedBegin;

	public override Color ButtonSelectedHighlightBorder => _colors[22];

	public override Color ButtonCheckedGradientBegin => _buttonCheckedBegin;

	public override Color ButtonCheckedGradientMiddle => _buttonCheckedBegin;

	public override Color ButtonCheckedGradientEnd => _buttonCheckedEnd;

	public override Color ButtonCheckedHighlight => _buttonCheckedBegin;

	public override Color ButtonCheckedHighlightBorder => _colors[22];

	public override Color CheckBackground => _checkBackground;

	public override Color CheckPressedBackground => _checkBackground;

	public override Color CheckSelectedBackground => _checkBackground;

	public override Color GripLight => _colors[25];

	public override Color GripDark => _colors[26];

	public override Color ImageMarginGradientBegin => _colors[30];

	public override Color ImageMarginGradientMiddle => _colors[30];

	public override Color ImageMarginGradientEnd => _colors[30];

	public override Color ImageMarginRevealedGradientBegin => _colors[30];

	public override Color ImageMarginRevealedGradientMiddle => _colors[30];

	public override Color ImageMarginRevealedGradientEnd => _colors[30];

	public override Color MenuBorder => _menuBorder;

	public override Color MenuItemBorder => _menuBorder;

	public override Color MenuItemSelected => _colors[22];

	public override Color MenuItemPressedGradientBegin => _colors[31];

	public override Color MenuItemPressedGradientEnd => _colors[33];

	public override Color MenuItemPressedGradientMiddle => _colors[32];

	public override Color MenuItemSelectedGradientBegin => _menuItemSelectedBegin;

	public override Color MenuItemSelectedGradientEnd => _menuItemSelectedEnd;

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

	public override Color MenuItemText => _colors[1];

	public override Color MenuStripText => _colors[69];

	public override Color ToolStripText => _colors[1];

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

	static KryptonColorTable2007()
	{
		_menuBorder = Color.FromArgb(134, 134, 134);
		_menuItemSelectedBegin = Color.FromArgb(255, 213, 103);
		_menuItemSelectedEnd = Color.FromArgb(255, 228, 145);
		_contextMenuBackground = Color.FromArgb(250, 250, 250);
		_checkBackground = Color.FromArgb(255, 227, 149);
		_buttonSelectedBegin = Color.FromArgb(255, 235, 166);
		_buttonSelectedEnd = Color.FromArgb(255, 213, 103);
		_buttonPressedBegin = Color.FromArgb(253, 164, 97);
		_buttonPressedEnd = Color.FromArgb(252, 143, 61);
		_buttonCheckedBegin = Color.FromArgb(252, 180, 100);
		_buttonCheckedEnd = Color.FromArgb(252, 161, 54);
		DefineFonts();
		SystemEvents.UserPreferenceChanged += OnUserPreferenceChanged;
	}

	public KryptonColorTable2007(Color[] colors, InheritBool roundedEdges, IPalette palette)
		: base(palette)
	{
		Debug.Assert(colors != null);
		_colors = colors;
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
