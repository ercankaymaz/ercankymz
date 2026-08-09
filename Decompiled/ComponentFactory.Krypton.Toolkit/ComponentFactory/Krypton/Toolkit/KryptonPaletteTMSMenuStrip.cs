using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteTMSMenuStrip : KryptonPaletteTMSBase
{
	[Browsable(false)]
	public override bool IsDefault => base.InternalKCT.InternalMenuStripText == Color.Empty && base.InternalKCT.InternalMenuStripFont == null && base.InternalKCT.InternalMenuStripGradientBegin == Color.Empty && base.InternalKCT.InternalMenuStripGradientEnd == Color.Empty;

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Color to draw text on the MenuStrip.")]
	[KryptonDefaultColor]
	public Color MenuStripText
	{
		get
		{
			return base.InternalKCT.InternalMenuStripText;
		}
		set
		{
			base.InternalKCT.InternalMenuStripText = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Font to draw text on the MenuStrip.")]
	[DefaultValue(null)]
	public Font MenuStripFont
	{
		get
		{
			return base.InternalKCT.InternalMenuStripFont;
		}
		set
		{
			base.InternalKCT.InternalMenuStripFont = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Starting color of the gradient used in the MenuStrip.")]
	[KryptonDefaultColor]
	public Color MenuStripGradientBegin
	{
		get
		{
			return base.InternalKCT.InternalMenuStripGradientBegin;
		}
		set
		{
			base.InternalKCT.InternalMenuStripGradientBegin = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Ending color of the gradient used in the MenuStrip.")]
	[KryptonDefaultColor]
	public Color MenuStripGradientEnd
	{
		get
		{
			return base.InternalKCT.InternalMenuStripGradientEnd;
		}
		set
		{
			base.InternalKCT.InternalMenuStripGradientEnd = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	internal KryptonPaletteTMSMenuStrip(KryptonInternalKCT internalKCT, NeedPaintHandler needPaint)
		: base(internalKCT, needPaint)
	{
	}

	public void PopulateFromBase()
	{
		MenuStripText = base.InternalKCT.MenuStripText;
		MenuStripFont = base.InternalKCT.MenuStripFont;
		MenuStripGradientBegin = base.InternalKCT.MenuStripGradientBegin;
		MenuStripGradientEnd = base.InternalKCT.MenuStripGradientEnd;
	}

	public void ResetMenuStripText()
	{
		MenuStripText = Color.Empty;
	}

	public void ResetMenuStripFont()
	{
		MenuStripFont = null;
	}

	public void ResetMenuStripGradientBegin()
	{
		MenuStripGradientBegin = Color.Empty;
	}

	public void ResetMenuStripGradientEnd()
	{
		MenuStripGradientEnd = Color.Empty;
	}
}
