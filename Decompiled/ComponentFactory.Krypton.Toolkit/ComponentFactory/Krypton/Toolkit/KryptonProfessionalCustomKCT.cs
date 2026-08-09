using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonProfessionalCustomKCT : KryptonProfessionalKCT
{
	private Color[] _colors;

	public override Color ButtonCheckedGradientBegin
	{
		get
		{
			if (_colors[0] == Color.Empty)
			{
				return base.ButtonCheckedGradientBegin;
			}
			return _colors[0];
		}
	}

	public override Color ButtonCheckedGradientEnd
	{
		get
		{
			if (_colors[1] == Color.Empty)
			{
				return base.ButtonCheckedGradientEnd;
			}
			return _colors[1];
		}
	}

	public override Color ButtonCheckedGradientMiddle
	{
		get
		{
			if (_colors[2] == Color.Empty)
			{
				return base.ButtonCheckedGradientMiddle;
			}
			return _colors[2];
		}
	}

	public override Color ButtonCheckedHighlight
	{
		get
		{
			if (_colors[3] == Color.Empty)
			{
				return base.ButtonCheckedHighlight;
			}
			return _colors[3];
		}
	}

	public override Color ButtonCheckedHighlightBorder
	{
		get
		{
			if (_colors[4] == Color.Empty)
			{
				return base.ButtonCheckedHighlightBorder;
			}
			return _colors[4];
		}
	}

	public override Color ButtonPressedBorder
	{
		get
		{
			if (_colors[5] == Color.Empty)
			{
				return base.ButtonPressedBorder;
			}
			return _colors[5];
		}
	}

	public override Color ButtonPressedGradientBegin
	{
		get
		{
			if (_colors[6] == Color.Empty)
			{
				return base.ButtonPressedGradientBegin;
			}
			return _colors[6];
		}
	}

	public override Color ButtonPressedGradientEnd
	{
		get
		{
			if (_colors[7] == Color.Empty)
			{
				return base.ButtonPressedGradientEnd;
			}
			return _colors[7];
		}
	}

	public override Color ButtonPressedGradientMiddle
	{
		get
		{
			if (_colors[8] == Color.Empty)
			{
				return base.ButtonPressedGradientMiddle;
			}
			return _colors[8];
		}
	}

	public override Color ButtonPressedHighlight
	{
		get
		{
			if (_colors[9] == Color.Empty)
			{
				return base.ButtonPressedHighlight;
			}
			return _colors[9];
		}
	}

	public override Color ButtonPressedHighlightBorder
	{
		get
		{
			if (_colors[10] == Color.Empty)
			{
				return base.ButtonPressedHighlightBorder;
			}
			return _colors[10];
		}
	}

	public override Color ButtonSelectedBorder
	{
		get
		{
			if (_colors[11] == Color.Empty)
			{
				return base.ButtonSelectedBorder;
			}
			return _colors[11];
		}
	}

	public override Color ButtonSelectedGradientBegin
	{
		get
		{
			if (_colors[12] == Color.Empty)
			{
				return base.ButtonSelectedGradientBegin;
			}
			return _colors[12];
		}
	}

	public override Color ButtonSelectedGradientEnd
	{
		get
		{
			if (_colors[13] == Color.Empty)
			{
				return base.ButtonSelectedGradientEnd;
			}
			return _colors[13];
		}
	}

	public override Color ButtonSelectedGradientMiddle
	{
		get
		{
			if (_colors[14] == Color.Empty)
			{
				return base.ButtonSelectedGradientMiddle;
			}
			return _colors[14];
		}
	}

	public override Color ButtonSelectedHighlight
	{
		get
		{
			if (_colors[15] == Color.Empty)
			{
				return base.ButtonSelectedHighlight;
			}
			return _colors[15];
		}
	}

	public override Color ButtonSelectedHighlightBorder
	{
		get
		{
			if (_colors[16] == Color.Empty)
			{
				return base.ButtonSelectedHighlightBorder;
			}
			return _colors[16];
		}
	}

	public override Color CheckBackground
	{
		get
		{
			if (_colors[17] == Color.Empty)
			{
				return base.CheckBackground;
			}
			return _colors[17];
		}
	}

	public override Color CheckPressedBackground
	{
		get
		{
			if (_colors[18] == Color.Empty)
			{
				return base.CheckPressedBackground;
			}
			return _colors[18];
		}
	}

	public override Color CheckSelectedBackground
	{
		get
		{
			if (_colors[19] == Color.Empty)
			{
				return base.CheckSelectedBackground;
			}
			return _colors[19];
		}
	}

	public override Color GripDark
	{
		get
		{
			if (_colors[20] == Color.Empty)
			{
				return base.GripDark;
			}
			return _colors[20];
		}
	}

	public override Color GripLight
	{
		get
		{
			if (_colors[21] == Color.Empty)
			{
				return base.GripLight;
			}
			return _colors[21];
		}
	}

	public override Color ImageMarginGradientBegin
	{
		get
		{
			if (_colors[22] == Color.Empty)
			{
				return base.ImageMarginGradientBegin;
			}
			return _colors[22];
		}
	}

	public override Color ImageMarginGradientEnd
	{
		get
		{
			if (_colors[23] == Color.Empty)
			{
				return base.ImageMarginGradientEnd;
			}
			return _colors[23];
		}
	}

	public override Color ImageMarginGradientMiddle
	{
		get
		{
			if (_colors[24] == Color.Empty)
			{
				return base.ImageMarginGradientMiddle;
			}
			return _colors[24];
		}
	}

	public override Color ImageMarginRevealedGradientBegin
	{
		get
		{
			if (_colors[25] == Color.Empty)
			{
				return base.ImageMarginRevealedGradientBegin;
			}
			return _colors[25];
		}
	}

	public override Color ImageMarginRevealedGradientEnd
	{
		get
		{
			if (_colors[26] == Color.Empty)
			{
				return base.ImageMarginRevealedGradientEnd;
			}
			return _colors[26];
		}
	}

	public override Color ImageMarginRevealedGradientMiddle
	{
		get
		{
			if (_colors[27] == Color.Empty)
			{
				return base.ImageMarginRevealedGradientMiddle;
			}
			return _colors[27];
		}
	}

	public override Color MenuBorder
	{
		get
		{
			if (_colors[28] == Color.Empty)
			{
				return base.MenuBorder;
			}
			return _colors[28];
		}
	}

	public override Color MenuItemText
	{
		get
		{
			if (_colors[29] == Color.Empty)
			{
				return base.MenuItemText;
			}
			return _colors[29];
		}
	}

	public override Color MenuItemBorder
	{
		get
		{
			if (_colors[30] == Color.Empty)
			{
				return base.MenuItemBorder;
			}
			return _colors[30];
		}
	}

	public override Color MenuItemPressedGradientBegin
	{
		get
		{
			if (_colors[31] == Color.Empty)
			{
				return base.MenuItemPressedGradientBegin;
			}
			return _colors[31];
		}
	}

	public override Color MenuItemPressedGradientEnd
	{
		get
		{
			if (_colors[32] == Color.Empty)
			{
				return base.MenuItemPressedGradientEnd;
			}
			return _colors[32];
		}
	}

	public override Color MenuItemPressedGradientMiddle
	{
		get
		{
			if (_colors[33] == Color.Empty)
			{
				return base.MenuItemPressedGradientMiddle;
			}
			return _colors[33];
		}
	}

	public override Color MenuItemSelected
	{
		get
		{
			if (_colors[34] == Color.Empty)
			{
				return base.MenuItemSelected;
			}
			return _colors[34];
		}
	}

	public override Color MenuItemSelectedGradientBegin
	{
		get
		{
			if (_colors[35] == Color.Empty)
			{
				return base.MenuItemSelectedGradientBegin;
			}
			return _colors[35];
		}
	}

	public override Color MenuItemSelectedGradientEnd
	{
		get
		{
			if (_colors[36] == Color.Empty)
			{
				return base.MenuItemSelectedGradientEnd;
			}
			return _colors[36];
		}
	}

	public override Color MenuStripText
	{
		get
		{
			if (_colors[37] == Color.Empty)
			{
				return base.MenuStripText;
			}
			return _colors[37];
		}
	}

	public override Color MenuStripGradientBegin
	{
		get
		{
			if (_colors[38] == Color.Empty)
			{
				return base.MenuStripGradientBegin;
			}
			return _colors[38];
		}
	}

	public override Color MenuStripGradientEnd
	{
		get
		{
			if (_colors[39] == Color.Empty)
			{
				return base.MenuStripGradientEnd;
			}
			return _colors[39];
		}
	}

	public override Color OverflowButtonGradientBegin
	{
		get
		{
			if (_colors[40] == Color.Empty)
			{
				return base.OverflowButtonGradientBegin;
			}
			return _colors[40];
		}
	}

	public override Color OverflowButtonGradientEnd
	{
		get
		{
			if (_colors[41] == Color.Empty)
			{
				return base.OverflowButtonGradientEnd;
			}
			return _colors[41];
		}
	}

	public override Color OverflowButtonGradientMiddle
	{
		get
		{
			if (_colors[42] == Color.Empty)
			{
				return base.OverflowButtonGradientMiddle;
			}
			return _colors[42];
		}
	}

	public override Color RaftingContainerGradientBegin
	{
		get
		{
			if (_colors[43] == Color.Empty)
			{
				return base.RaftingContainerGradientBegin;
			}
			return _colors[43];
		}
	}

	public override Color RaftingContainerGradientEnd
	{
		get
		{
			if (_colors[44] == Color.Empty)
			{
				return base.RaftingContainerGradientEnd;
			}
			return _colors[44];
		}
	}

	public override Color SeparatorDark
	{
		get
		{
			if (_colors[45] == Color.Empty)
			{
				return base.SeparatorDark;
			}
			return _colors[45];
		}
	}

	public override Color SeparatorLight
	{
		get
		{
			if (_colors[46] == Color.Empty)
			{
				return base.SeparatorLight;
			}
			return _colors[46];
		}
	}

	public override Color StatusStripText
	{
		get
		{
			if (_colors[47] == Color.Empty)
			{
				return base.StatusStripText;
			}
			return _colors[47];
		}
	}

	public override Color StatusStripGradientBegin
	{
		get
		{
			if (_colors[48] == Color.Empty)
			{
				return base.StatusStripGradientBegin;
			}
			return _colors[48];
		}
	}

	public override Color StatusStripGradientEnd
	{
		get
		{
			if (_colors[49] == Color.Empty)
			{
				return base.StatusStripGradientEnd;
			}
			return _colors[49];
		}
	}

	public override Color ToolStripText
	{
		get
		{
			if (_colors[50] == Color.Empty)
			{
				return base.ToolStripText;
			}
			return _colors[50];
		}
	}

	public override Color ToolStripBorder
	{
		get
		{
			if (_colors[51] == Color.Empty)
			{
				return base.ToolStripBorder;
			}
			return _colors[51];
		}
	}

	public override Color ToolStripContentPanelGradientBegin
	{
		get
		{
			if (_colors[52] == Color.Empty)
			{
				return base.ToolStripContentPanelGradientBegin;
			}
			return _colors[52];
		}
	}

	public override Color ToolStripContentPanelGradientEnd
	{
		get
		{
			if (_colors[53] == Color.Empty)
			{
				return base.ToolStripContentPanelGradientEnd;
			}
			return _colors[53];
		}
	}

	public override Color ToolStripDropDownBackground
	{
		get
		{
			if (_colors[54] == Color.Empty)
			{
				return base.ToolStripDropDownBackground;
			}
			return _colors[54];
		}
	}

	public override Color ToolStripGradientBegin
	{
		get
		{
			if (_colors[55] == Color.Empty)
			{
				return base.ToolStripGradientBegin;
			}
			return _colors[55];
		}
	}

	public override Color ToolStripGradientEnd
	{
		get
		{
			if (_colors[56] == Color.Empty)
			{
				return base.ToolStripGradientEnd;
			}
			return _colors[56];
		}
	}

	public override Color ToolStripGradientMiddle
	{
		get
		{
			if (_colors[57] == Color.Empty)
			{
				return base.ToolStripGradientMiddle;
			}
			return _colors[57];
		}
	}

	public override Color ToolStripPanelGradientBegin
	{
		get
		{
			if (_colors[58] == Color.Empty)
			{
				return base.ToolStripPanelGradientBegin;
			}
			return _colors[58];
		}
	}

	public override Color ToolStripPanelGradientEnd
	{
		get
		{
			if (_colors[59] == Color.Empty)
			{
				return base.ToolStripPanelGradientEnd;
			}
			return _colors[59];
		}
	}

	public KryptonProfessionalCustomKCT(Color[] headerColors, Color[] colorTableColors, bool useSystemColors, IPalette palette)
		: base(headerColors, useSystemColors, palette)
	{
		_colors = colorTableColors;
	}
}
