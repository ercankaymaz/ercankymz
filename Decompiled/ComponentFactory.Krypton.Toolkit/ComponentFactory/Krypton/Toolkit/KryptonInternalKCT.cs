#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonInternalKCT : KryptonColorTable
{
	private KryptonColorTable _baseKCT;

	private InheritBool _useRoundedEdges;

	private Color[] _colors;

	private Font _menuFont;

	private Font _toolFont;

	private Font _statusFont;

	[Browsable(false)]
	public bool IsDefault => _useRoundedEdges == InheritBool.Inherit;

	public override Color ButtonCheckedGradientBegin
	{
		get
		{
			if (_colors[0] == Color.Empty)
			{
				return BaseKCT.ButtonCheckedGradientBegin;
			}
			return _colors[0];
		}
	}

	public Color InternalButtonCheckedGradientBegin
	{
		get
		{
			return _colors[0];
		}
		set
		{
			_colors[0] = value;
		}
	}

	public override Color ButtonCheckedGradientEnd
	{
		get
		{
			if (_colors[1] == Color.Empty)
			{
				return BaseKCT.ButtonCheckedGradientEnd;
			}
			return _colors[1];
		}
	}

	public Color InternalButtonCheckedGradientEnd
	{
		get
		{
			return _colors[1];
		}
		set
		{
			_colors[1] = value;
		}
	}

	public override Color ButtonCheckedGradientMiddle
	{
		get
		{
			if (_colors[2] == Color.Empty)
			{
				return BaseKCT.ButtonCheckedGradientMiddle;
			}
			return _colors[2];
		}
	}

	public Color InternalButtonCheckedGradientMiddle
	{
		get
		{
			return _colors[2];
		}
		set
		{
			_colors[2] = value;
		}
	}

	public override Color ButtonCheckedHighlight
	{
		get
		{
			if (_colors[3] == Color.Empty)
			{
				return BaseKCT.ButtonCheckedHighlight;
			}
			return _colors[3];
		}
	}

	public Color InternalButtonCheckedHighlight
	{
		get
		{
			return _colors[3];
		}
		set
		{
			_colors[3] = value;
		}
	}

	public override Color ButtonCheckedHighlightBorder
	{
		get
		{
			if (_colors[4] == Color.Empty)
			{
				return BaseKCT.ButtonCheckedHighlightBorder;
			}
			return _colors[4];
		}
	}

	public Color InternalButtonCheckedHighlightBorder
	{
		get
		{
			return _colors[4];
		}
		set
		{
			_colors[4] = value;
		}
	}

	public override Color ButtonPressedBorder
	{
		get
		{
			if (_colors[5] == Color.Empty)
			{
				return BaseKCT.ButtonPressedBorder;
			}
			return _colors[5];
		}
	}

	public Color InternalButtonPressedBorder
	{
		get
		{
			return _colors[5];
		}
		set
		{
			_colors[5] = value;
		}
	}

	public override Color ButtonPressedGradientBegin
	{
		get
		{
			if (_colors[6] == Color.Empty)
			{
				return BaseKCT.ButtonPressedGradientBegin;
			}
			return _colors[6];
		}
	}

	public Color InternalButtonPressedGradientBegin
	{
		get
		{
			return _colors[6];
		}
		set
		{
			_colors[6] = value;
		}
	}

	public override Color ButtonPressedGradientEnd
	{
		get
		{
			if (_colors[7] == Color.Empty)
			{
				return BaseKCT.ButtonPressedGradientEnd;
			}
			return _colors[7];
		}
	}

	public Color InternalButtonPressedGradientEnd
	{
		get
		{
			return _colors[7];
		}
		set
		{
			_colors[7] = value;
		}
	}

	public override Color ButtonPressedGradientMiddle
	{
		get
		{
			if (_colors[8] == Color.Empty)
			{
				return BaseKCT.ButtonPressedGradientMiddle;
			}
			return _colors[8];
		}
	}

	public Color InternalButtonPressedGradientMiddle
	{
		get
		{
			return _colors[8];
		}
		set
		{
			_colors[8] = value;
		}
	}

	public override Color ButtonPressedHighlight
	{
		get
		{
			if (_colors[9] == Color.Empty)
			{
				return BaseKCT.ButtonPressedHighlight;
			}
			return _colors[9];
		}
	}

	public Color InternalButtonPressedHighlight
	{
		get
		{
			return _colors[9];
		}
		set
		{
			_colors[9] = value;
		}
	}

	public override Color ButtonPressedHighlightBorder
	{
		get
		{
			if (_colors[10] == Color.Empty)
			{
				return BaseKCT.ButtonPressedHighlightBorder;
			}
			return _colors[10];
		}
	}

	public Color InternalButtonPressedHighlightBorder
	{
		get
		{
			return _colors[10];
		}
		set
		{
			_colors[10] = value;
		}
	}

	public override Color ButtonSelectedBorder
	{
		get
		{
			if (_colors[11] == Color.Empty)
			{
				return BaseKCT.ButtonSelectedBorder;
			}
			return _colors[11];
		}
	}

	public Color InternalButtonSelectedBorder
	{
		get
		{
			return _colors[11];
		}
		set
		{
			_colors[11] = value;
		}
	}

	public override Color ButtonSelectedGradientBegin
	{
		get
		{
			if (_colors[12] == Color.Empty)
			{
				return BaseKCT.ButtonSelectedGradientBegin;
			}
			return _colors[12];
		}
	}

	public Color InternalButtonSelectedGradientBegin
	{
		get
		{
			return _colors[12];
		}
		set
		{
			_colors[12] = value;
		}
	}

	public override Color ButtonSelectedGradientEnd
	{
		get
		{
			if (_colors[13] == Color.Empty)
			{
				return BaseKCT.ButtonSelectedGradientEnd;
			}
			return _colors[13];
		}
	}

	public Color InternalButtonSelectedGradientEnd
	{
		get
		{
			return _colors[13];
		}
		set
		{
			_colors[13] = value;
		}
	}

	public override Color ButtonSelectedGradientMiddle
	{
		get
		{
			if (_colors[14] == Color.Empty)
			{
				return BaseKCT.ButtonSelectedGradientMiddle;
			}
			return _colors[14];
		}
	}

	public Color InternalButtonSelectedGradientMiddle
	{
		get
		{
			return _colors[14];
		}
		set
		{
			_colors[14] = value;
		}
	}

	public override Color ButtonSelectedHighlight
	{
		get
		{
			if (_colors[15] == Color.Empty)
			{
				return BaseKCT.ButtonSelectedHighlight;
			}
			return _colors[15];
		}
	}

	public Color InternalButtonSelectedHighlight
	{
		get
		{
			return _colors[15];
		}
		set
		{
			_colors[15] = value;
		}
	}

	public override Color ButtonSelectedHighlightBorder
	{
		get
		{
			if (_colors[16] == Color.Empty)
			{
				return BaseKCT.ButtonSelectedHighlightBorder;
			}
			return _colors[16];
		}
	}

	public Color InternalButtonSelectedHighlightBorder
	{
		get
		{
			return _colors[16];
		}
		set
		{
			_colors[16] = value;
		}
	}

	public override Color CheckBackground
	{
		get
		{
			if (_colors[17] == Color.Empty)
			{
				return BaseKCT.CheckBackground;
			}
			return _colors[17];
		}
	}

	public Color InternalCheckBackground
	{
		get
		{
			return _colors[17];
		}
		set
		{
			_colors[17] = value;
		}
	}

	public override Color CheckPressedBackground
	{
		get
		{
			if (_colors[18] == Color.Empty)
			{
				return BaseKCT.CheckPressedBackground;
			}
			return _colors[18];
		}
	}

	public Color InternalCheckPressedBackground
	{
		get
		{
			return _colors[18];
		}
		set
		{
			_colors[18] = value;
		}
	}

	public override Color CheckSelectedBackground
	{
		get
		{
			if (_colors[19] == Color.Empty)
			{
				return BaseKCT.CheckSelectedBackground;
			}
			return _colors[19];
		}
	}

	public Color InternalCheckSelectedBackground
	{
		get
		{
			return _colors[19];
		}
		set
		{
			_colors[19] = value;
		}
	}

	public override Color GripDark
	{
		get
		{
			if (_colors[20] == Color.Empty)
			{
				return BaseKCT.GripDark;
			}
			return _colors[20];
		}
	}

	public Color InternalGripDark
	{
		get
		{
			return _colors[20];
		}
		set
		{
			_colors[20] = value;
		}
	}

	public override Color GripLight
	{
		get
		{
			if (_colors[21] == Color.Empty)
			{
				return BaseKCT.GripLight;
			}
			return _colors[21];
		}
	}

	public Color InternalGripLight
	{
		get
		{
			return _colors[21];
		}
		set
		{
			_colors[21] = value;
		}
	}

	public override Color ImageMarginGradientBegin
	{
		get
		{
			if (_colors[22] == Color.Empty)
			{
				return BaseKCT.ImageMarginGradientBegin;
			}
			return _colors[22];
		}
	}

	public Color InternalImageMarginGradientBegin
	{
		get
		{
			return _colors[22];
		}
		set
		{
			_colors[22] = value;
		}
	}

	public override Color ImageMarginGradientEnd
	{
		get
		{
			if (_colors[23] == Color.Empty)
			{
				return BaseKCT.ImageMarginGradientEnd;
			}
			return _colors[23];
		}
	}

	public Color InternalImageMarginGradientEnd
	{
		get
		{
			return _colors[23];
		}
		set
		{
			_colors[23] = value;
		}
	}

	public override Color ImageMarginGradientMiddle
	{
		get
		{
			if (_colors[24] == Color.Empty)
			{
				return BaseKCT.ImageMarginGradientMiddle;
			}
			return _colors[24];
		}
	}

	public Color InternalImageMarginGradientMiddle
	{
		get
		{
			return _colors[24];
		}
		set
		{
			_colors[24] = value;
		}
	}

	public override Color ImageMarginRevealedGradientBegin
	{
		get
		{
			if (_colors[25] == Color.Empty)
			{
				return BaseKCT.ImageMarginRevealedGradientBegin;
			}
			return _colors[25];
		}
	}

	public Color InternalImageMarginRevealedGradientBegin
	{
		get
		{
			return _colors[25];
		}
		set
		{
			_colors[25] = value;
		}
	}

	public override Color ImageMarginRevealedGradientEnd
	{
		get
		{
			if (_colors[26] == Color.Empty)
			{
				return BaseKCT.ImageMarginRevealedGradientEnd;
			}
			return _colors[26];
		}
	}

	public Color InternalImageMarginRevealedGradientEnd
	{
		get
		{
			return _colors[26];
		}
		set
		{
			_colors[26] = value;
		}
	}

	public override Color ImageMarginRevealedGradientMiddle
	{
		get
		{
			if (_colors[27] == Color.Empty)
			{
				return BaseKCT.ImageMarginRevealedGradientMiddle;
			}
			return _colors[27];
		}
	}

	public Color InternalImageMarginRevealedGradientMiddle
	{
		get
		{
			return _colors[27];
		}
		set
		{
			_colors[27] = value;
		}
	}

	public override Color MenuBorder
	{
		get
		{
			if (_colors[28] == Color.Empty)
			{
				return BaseKCT.MenuBorder;
			}
			return _colors[28];
		}
	}

	public Color InternalMenuBorder
	{
		get
		{
			return _colors[28];
		}
		set
		{
			_colors[28] = value;
		}
	}

	public override Color MenuItemText
	{
		get
		{
			if (_colors[29] == Color.Empty)
			{
				return BaseKCT.MenuItemText;
			}
			return _colors[29];
		}
	}

	public Color InternalMenuItemText
	{
		get
		{
			return _colors[29];
		}
		set
		{
			_colors[29] = value;
		}
	}

	public override Font MenuStripFont
	{
		get
		{
			if (_menuFont == null)
			{
				return BaseKCT.MenuStripFont;
			}
			return _menuFont;
		}
	}

	public Font InternalMenuStripFont
	{
		get
		{
			return _menuFont;
		}
		set
		{
			_menuFont = value;
		}
	}

	public override Color MenuItemBorder
	{
		get
		{
			if (_colors[30] == Color.Empty)
			{
				return BaseKCT.MenuItemBorder;
			}
			return _colors[30];
		}
	}

	public Color InternalMenuItemBorder
	{
		get
		{
			return _colors[30];
		}
		set
		{
			_colors[30] = value;
		}
	}

	public override Color MenuItemPressedGradientBegin
	{
		get
		{
			if (_colors[31] == Color.Empty)
			{
				return BaseKCT.MenuItemPressedGradientBegin;
			}
			return _colors[31];
		}
	}

	public Color InternalMenuItemPressedGradientBegin
	{
		get
		{
			return _colors[31];
		}
		set
		{
			_colors[31] = value;
		}
	}

	public override Color MenuItemPressedGradientEnd
	{
		get
		{
			if (_colors[32] == Color.Empty)
			{
				return BaseKCT.MenuItemPressedGradientEnd;
			}
			return _colors[32];
		}
	}

	public Color InternalMenuItemPressedGradientEnd
	{
		get
		{
			return _colors[32];
		}
		set
		{
			_colors[32] = value;
		}
	}

	public override Color MenuItemPressedGradientMiddle
	{
		get
		{
			if (_colors[33] == Color.Empty)
			{
				return BaseKCT.MenuItemPressedGradientMiddle;
			}
			return _colors[33];
		}
	}

	public Color InternalMenuItemPressedGradientMiddle
	{
		get
		{
			return _colors[33];
		}
		set
		{
			_colors[33] = value;
		}
	}

	public override Color MenuItemSelected
	{
		get
		{
			if (_colors[34] == Color.Empty)
			{
				return BaseKCT.MenuItemSelected;
			}
			return _colors[34];
		}
	}

	public Color InternalMenuItemSelected
	{
		get
		{
			return _colors[34];
		}
		set
		{
			_colors[34] = value;
		}
	}

	public override Color MenuItemSelectedGradientBegin
	{
		get
		{
			if (_colors[35] == Color.Empty)
			{
				return BaseKCT.MenuItemSelectedGradientBegin;
			}
			return _colors[35];
		}
	}

	public Color InternalMenuItemSelectedGradientBegin
	{
		get
		{
			return _colors[35];
		}
		set
		{
			_colors[35] = value;
		}
	}

	public override Color MenuItemSelectedGradientEnd
	{
		get
		{
			if (_colors[36] == Color.Empty)
			{
				return BaseKCT.MenuItemSelectedGradientEnd;
			}
			return _colors[36];
		}
	}

	public Color InternalMenuItemSelectedGradientEnd
	{
		get
		{
			return _colors[36];
		}
		set
		{
			_colors[36] = value;
		}
	}

	public override Color MenuStripText
	{
		get
		{
			if (_colors[37] == Color.Empty)
			{
				return BaseKCT.MenuStripText;
			}
			return _colors[37];
		}
	}

	public Color InternalMenuStripText
	{
		get
		{
			return _colors[37];
		}
		set
		{
			_colors[37] = value;
		}
	}

	public override Color MenuStripGradientBegin
	{
		get
		{
			if (_colors[38] == Color.Empty)
			{
				return BaseKCT.MenuStripGradientBegin;
			}
			return _colors[38];
		}
	}

	public Color InternalMenuStripGradientBegin
	{
		get
		{
			return _colors[38];
		}
		set
		{
			_colors[38] = value;
		}
	}

	public override Color MenuStripGradientEnd
	{
		get
		{
			if (_colors[39] == Color.Empty)
			{
				return BaseKCT.MenuStripGradientEnd;
			}
			return _colors[39];
		}
	}

	public Color InternalMenuStripGradientEnd
	{
		get
		{
			return _colors[39];
		}
		set
		{
			_colors[39] = value;
		}
	}

	public override Color OverflowButtonGradientBegin
	{
		get
		{
			if (_colors[40] == Color.Empty)
			{
				return BaseKCT.OverflowButtonGradientBegin;
			}
			return _colors[40];
		}
	}

	public Color InternalOverflowButtonGradientBegin
	{
		get
		{
			return _colors[40];
		}
		set
		{
			_colors[40] = value;
		}
	}

	public override Color OverflowButtonGradientEnd
	{
		get
		{
			if (_colors[41] == Color.Empty)
			{
				return BaseKCT.OverflowButtonGradientEnd;
			}
			return _colors[41];
		}
	}

	public Color InternalOverflowButtonGradientEnd
	{
		get
		{
			return _colors[41];
		}
		set
		{
			_colors[41] = value;
		}
	}

	public override Color OverflowButtonGradientMiddle
	{
		get
		{
			if (_colors[42] == Color.Empty)
			{
				return BaseKCT.OverflowButtonGradientMiddle;
			}
			return _colors[42];
		}
	}

	public Color InternalOverflowButtonGradientMiddle
	{
		get
		{
			return _colors[42];
		}
		set
		{
			_colors[42] = value;
		}
	}

	public override Color RaftingContainerGradientBegin
	{
		get
		{
			if (_colors[43] == Color.Empty)
			{
				return BaseKCT.RaftingContainerGradientBegin;
			}
			return _colors[43];
		}
	}

	public Color InternalRaftingContainerGradientBegin
	{
		get
		{
			return _colors[43];
		}
		set
		{
			_colors[43] = value;
		}
	}

	public override Color RaftingContainerGradientEnd
	{
		get
		{
			if (_colors[44] == Color.Empty)
			{
				return BaseKCT.RaftingContainerGradientEnd;
			}
			return _colors[44];
		}
	}

	public Color InternalRaftingContainerGradientEnd
	{
		get
		{
			return _colors[44];
		}
		set
		{
			_colors[44] = value;
		}
	}

	public override Color SeparatorDark
	{
		get
		{
			if (_colors[45] == Color.Empty)
			{
				return BaseKCT.SeparatorDark;
			}
			return _colors[45];
		}
	}

	public Color InternalSeparatorDark
	{
		get
		{
			return _colors[45];
		}
		set
		{
			_colors[45] = value;
		}
	}

	public override Color SeparatorLight
	{
		get
		{
			if (_colors[46] == Color.Empty)
			{
				return BaseKCT.SeparatorLight;
			}
			return _colors[46];
		}
	}

	public Color InternalSeparatorLight
	{
		get
		{
			return _colors[46];
		}
		set
		{
			_colors[46] = value;
		}
	}

	public override Color StatusStripText
	{
		get
		{
			if (_colors[47] == Color.Empty)
			{
				return BaseKCT.StatusStripText;
			}
			return _colors[47];
		}
	}

	public Color InternalStatusStripText
	{
		get
		{
			return _colors[47];
		}
		set
		{
			_colors[47] = value;
		}
	}

	public override Font StatusStripFont
	{
		get
		{
			if (_statusFont == null)
			{
				return BaseKCT.StatusStripFont;
			}
			return _statusFont;
		}
	}

	public Font InternalStatusStripFont
	{
		get
		{
			return _statusFont;
		}
		set
		{
			_statusFont = value;
		}
	}

	public override Color StatusStripGradientBegin
	{
		get
		{
			if (_colors[48] == Color.Empty)
			{
				return BaseKCT.StatusStripGradientBegin;
			}
			return _colors[48];
		}
	}

	public Color InternalStatusStripGradientBegin
	{
		get
		{
			return _colors[48];
		}
		set
		{
			_colors[48] = value;
		}
	}

	public override Color StatusStripGradientEnd
	{
		get
		{
			if (_colors[49] == Color.Empty)
			{
				return BaseKCT.StatusStripGradientEnd;
			}
			return _colors[49];
		}
	}

	public Color InternalStatusStripGradientEnd
	{
		get
		{
			return _colors[49];
		}
		set
		{
			_colors[49] = value;
		}
	}

	public override Color ToolStripText
	{
		get
		{
			if (_colors[50] == Color.Empty)
			{
				return BaseKCT.ToolStripText;
			}
			return _colors[50];
		}
	}

	public Color InternalToolStripText
	{
		get
		{
			return _colors[50];
		}
		set
		{
			_colors[50] = value;
		}
	}

	public override Font ToolStripFont
	{
		get
		{
			if (_toolFont == null)
			{
				return BaseKCT.ToolStripFont;
			}
			return _toolFont;
		}
	}

	public Font InternalToolStripFont
	{
		get
		{
			return _toolFont;
		}
		set
		{
			_toolFont = value;
		}
	}

	public override Color ToolStripBorder
	{
		get
		{
			if (_colors[51] == Color.Empty)
			{
				return BaseKCT.ToolStripBorder;
			}
			return _colors[51];
		}
	}

	public Color InternalToolStripBorder
	{
		get
		{
			return _colors[51];
		}
		set
		{
			_colors[51] = value;
		}
	}

	public override Color ToolStripContentPanelGradientBegin
	{
		get
		{
			if (_colors[52] == Color.Empty)
			{
				return BaseKCT.ToolStripContentPanelGradientBegin;
			}
			return _colors[52];
		}
	}

	public Color InternalToolStripContentPanelGradientBegin
	{
		get
		{
			return _colors[52];
		}
		set
		{
			_colors[52] = value;
		}
	}

	public override Color ToolStripContentPanelGradientEnd
	{
		get
		{
			if (_colors[53] == Color.Empty)
			{
				return BaseKCT.ToolStripContentPanelGradientEnd;
			}
			return _colors[53];
		}
	}

	public Color InternalToolStripContentPanelGradientEnd
	{
		get
		{
			return _colors[53];
		}
		set
		{
			_colors[53] = value;
		}
	}

	public override Color ToolStripDropDownBackground
	{
		get
		{
			if (_colors[54] == Color.Empty)
			{
				return BaseKCT.ToolStripDropDownBackground;
			}
			return _colors[54];
		}
	}

	public Color InternalToolStripDropDownBackground
	{
		get
		{
			return _colors[54];
		}
		set
		{
			_colors[54] = value;
		}
	}

	public override Color ToolStripGradientBegin
	{
		get
		{
			if (_colors[55] == Color.Empty)
			{
				return BaseKCT.ToolStripGradientBegin;
			}
			return _colors[55];
		}
	}

	public Color InternalToolStripGradientBegin
	{
		get
		{
			return _colors[55];
		}
		set
		{
			_colors[55] = value;
		}
	}

	public override Color ToolStripGradientEnd
	{
		get
		{
			if (_colors[56] == Color.Empty)
			{
				return BaseKCT.ToolStripGradientEnd;
			}
			return _colors[56];
		}
	}

	public Color InternalToolStripGradientEnd
	{
		get
		{
			return _colors[56];
		}
		set
		{
			_colors[56] = value;
		}
	}

	public override Color ToolStripGradientMiddle
	{
		get
		{
			if (_colors[57] == Color.Empty)
			{
				return BaseKCT.ToolStripGradientMiddle;
			}
			return _colors[57];
		}
	}

	public Color InternalToolStripGradientMiddle
	{
		get
		{
			return _colors[57];
		}
		set
		{
			_colors[57] = value;
		}
	}

	public override Color ToolStripPanelGradientBegin
	{
		get
		{
			if (_colors[58] == Color.Empty)
			{
				return BaseKCT.ToolStripPanelGradientBegin;
			}
			return _colors[58];
		}
	}

	public Color InternalToolStripPanelGradientBegin
	{
		get
		{
			return _colors[58];
		}
		set
		{
			_colors[58] = value;
		}
	}

	public override Color ToolStripPanelGradientEnd
	{
		get
		{
			if (_colors[59] == Color.Empty)
			{
				return BaseKCT.ToolStripPanelGradientEnd;
			}
			return _colors[59];
		}
	}

	public Color InternalToolStripPanelGradientEnd
	{
		get
		{
			return _colors[59];
		}
		set
		{
			_colors[59] = value;
		}
	}

	public override InheritBool UseRoundedEdges
	{
		get
		{
			if (_useRoundedEdges == InheritBool.Inherit)
			{
				return BaseKCT.UseRoundedEdges;
			}
			return _useRoundedEdges;
		}
	}

	public InheritBool InternalUseRoundedEdges
	{
		get
		{
			return _useRoundedEdges;
		}
		set
		{
			_useRoundedEdges = value;
		}
	}

	internal KryptonColorTable BaseKCT
	{
		get
		{
			return _baseKCT;
		}
		set
		{
			_baseKCT = value;
			base.UseSystemColors = _baseKCT.UseSystemColors;
		}
	}

	public KryptonInternalKCT(KryptonColorTable baseKCT, IPalette palette)
		: base(palette)
	{
		Debug.Assert(baseKCT != null);
		_baseKCT = baseKCT;
		base.UseSystemColors = _baseKCT.UseSystemColors;
		_colors = new Color[60];
		for (int i = 0; i < _colors.Length; i++)
		{
			_colors[i] = Color.Empty;
		}
		_useRoundedEdges = InheritBool.Inherit;
	}
}
