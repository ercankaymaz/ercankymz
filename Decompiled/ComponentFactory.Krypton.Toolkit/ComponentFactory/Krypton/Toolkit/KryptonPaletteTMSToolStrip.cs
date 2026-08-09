using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteTMSToolStrip : KryptonPaletteTMSBase
{
	[Browsable(false)]
	public override bool IsDefault => base.InternalKCT.InternalToolStripText == Color.Empty && base.InternalKCT.InternalToolStripFont == null && base.InternalKCT.InternalToolStripBorder == Color.Empty && base.InternalKCT.InternalToolStripContentPanelGradientBegin == Color.Empty && base.InternalKCT.InternalToolStripContentPanelGradientEnd == Color.Empty && base.InternalKCT.InternalToolStripDropDownBackground == Color.Empty && base.InternalKCT.InternalToolStripGradientBegin == Color.Empty && base.InternalKCT.InternalToolStripGradientEnd == Color.Empty && base.InternalKCT.InternalToolStripGradientMiddle == Color.Empty && base.InternalKCT.InternalToolStripPanelGradientBegin == Color.Empty && base.InternalKCT.InternalToolStripPanelGradientEnd == Color.Empty;

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Color to draw text on the ToolStrip.")]
	[KryptonDefaultColor]
	public Color ToolStripText
	{
		get
		{
			return base.InternalKCT.InternalToolStripText;
		}
		set
		{
			base.InternalKCT.InternalToolStripText = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Font to draw text on the ToolStrip.")]
	[DefaultValue(null)]
	public Font ToolStripFont
	{
		get
		{
			return base.InternalKCT.InternalToolStripFont;
		}
		set
		{
			base.InternalKCT.InternalToolStripFont = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Border color to use on the bottom edge of the ToolStrip.")]
	[KryptonDefaultColor]
	public Color ToolStripBorder
	{
		get
		{
			return base.InternalKCT.InternalToolStripBorder;
		}
		set
		{
			base.InternalKCT.InternalToolStripBorder = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Starting color of the gradient used in the ToolStripContentPanel..")]
	[KryptonDefaultColor]
	public Color ToolStripContentPanelGradientBegin
	{
		get
		{
			return base.InternalKCT.InternalToolStripContentPanelGradientBegin;
		}
		set
		{
			base.InternalKCT.InternalToolStripContentPanelGradientBegin = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Ending color of the gradient used in the ToolStripContentPanel.")]
	[KryptonDefaultColor]
	public Color ToolStripContentPanelGradientEnd
	{
		get
		{
			return base.InternalKCT.InternalToolStripContentPanelGradientEnd;
		}
		set
		{
			base.InternalKCT.InternalToolStripContentPanelGradientEnd = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Solid background color solid background color of the ToolStripDropDown..")]
	[KryptonDefaultColor]
	public Color ToolStripDropDownBackground
	{
		get
		{
			return base.InternalKCT.InternalToolStripDropDownBackground;
		}
		set
		{
			base.InternalKCT.InternalToolStripDropDownBackground = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Starting color of the gradient used in the ToolStrip background..")]
	[KryptonDefaultColor]
	public Color ToolStripGradientBegin
	{
		get
		{
			return base.InternalKCT.InternalToolStripGradientBegin;
		}
		set
		{
			base.InternalKCT.InternalToolStripGradientBegin = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Ending color of the gradient used in the ToolStrip background..")]
	[KryptonDefaultColor]
	public Color ToolStripGradientEnd
	{
		get
		{
			return base.InternalKCT.InternalToolStripGradientEnd;
		}
		set
		{
			base.InternalKCT.InternalToolStripGradientEnd = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Ending color of the gradient used in the ToolStrip background..")]
	[KryptonDefaultColor]
	public Color ToolStripGradientMiddle
	{
		get
		{
			return base.InternalKCT.InternalToolStripGradientMiddle;
		}
		set
		{
			base.InternalKCT.InternalToolStripGradientMiddle = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Starting color of the gradient used in the ToolStripPanel..")]
	[KryptonDefaultColor]
	public Color ToolStripPanelGradientBegin
	{
		get
		{
			return base.InternalKCT.InternalToolStripPanelGradientBegin;
		}
		set
		{
			base.InternalKCT.InternalToolStripPanelGradientBegin = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Ending color of the gradient used in the ToolStripPanel..")]
	[KryptonDefaultColor]
	public Color ToolStripPanelGradientEnd
	{
		get
		{
			return base.InternalKCT.InternalToolStripPanelGradientEnd;
		}
		set
		{
			base.InternalKCT.InternalToolStripPanelGradientEnd = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	internal KryptonPaletteTMSToolStrip(KryptonInternalKCT internalKCT, NeedPaintHandler needPaint)
		: base(internalKCT, needPaint)
	{
	}

	public void PopulateFromBase()
	{
		ToolStripText = base.InternalKCT.ToolStripText;
		ToolStripFont = base.InternalKCT.ToolStripFont;
		ToolStripBorder = base.InternalKCT.ToolStripBorder;
		ToolStripContentPanelGradientBegin = base.InternalKCT.ToolStripContentPanelGradientBegin;
		ToolStripContentPanelGradientEnd = base.InternalKCT.ToolStripContentPanelGradientEnd;
		ToolStripDropDownBackground = base.InternalKCT.ToolStripDropDownBackground;
		ToolStripGradientBegin = base.InternalKCT.ToolStripGradientBegin;
		ToolStripGradientEnd = base.InternalKCT.ToolStripGradientEnd;
		ToolStripGradientMiddle = base.InternalKCT.ToolStripGradientMiddle;
		ToolStripPanelGradientBegin = base.InternalKCT.ToolStripPanelGradientBegin;
		ToolStripPanelGradientEnd = base.InternalKCT.ToolStripPanelGradientEnd;
	}

	public void ResetToolStripText()
	{
		ToolStripText = Color.Empty;
	}

	public void ResetToolStripFont()
	{
		ToolStripFont = null;
	}

	public void ResetToolStripBorder()
	{
		ToolStripBorder = Color.Empty;
	}

	public void ResetToolStripContentPanelGradientBegin()
	{
		ToolStripContentPanelGradientBegin = Color.Empty;
	}

	public void ResetToolStripContentPanelGradientEnd()
	{
		ToolStripContentPanelGradientEnd = Color.Empty;
	}

	public void ResetToolStripDropDownBackground()
	{
		ToolStripDropDownBackground = Color.Empty;
	}

	public void ResetToolStripGradientBegin()
	{
		ToolStripGradientBegin = Color.Empty;
	}

	public void ResetToolStripGradientEnd()
	{
		ToolStripGradientEnd = Color.Empty;
	}

	public void ResetToolStripGradientMiddle()
	{
		ToolStripGradientMiddle = Color.Empty;
	}

	public void ResetToolStripPanelGradientBegin()
	{
		ToolStripPanelGradientBegin = Color.Empty;
	}

	public void ResetToolStripPanelGradientEnd()
	{
		ToolStripPanelGradientEnd = Color.Empty;
	}
}
