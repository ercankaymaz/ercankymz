using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteTMSStatusStrip : KryptonPaletteTMSBase
{
	[Browsable(false)]
	public override bool IsDefault => base.InternalKCT.InternalStatusStripText == Color.Empty && base.InternalKCT.InternalStatusStripFont == null && base.InternalKCT.InternalStatusStripGradientBegin == Color.Empty && base.InternalKCT.InternalStatusStripGradientEnd == Color.Empty;

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Color to draw text on the StatusStrip.")]
	[KryptonDefaultColor]
	public Color StatusStripText
	{
		get
		{
			return base.InternalKCT.InternalStatusStripText;
		}
		set
		{
			base.InternalKCT.InternalStatusStripText = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Font to draw text on the StatusStrip.")]
	[DefaultValue(null)]
	public Font StatusStripFont
	{
		get
		{
			return base.InternalKCT.InternalStatusStripFont;
		}
		set
		{
			base.InternalKCT.InternalStatusStripFont = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Starting color of the gradient used on the StatusStrip.")]
	[KryptonDefaultColor]
	public Color StatusStripGradientBegin
	{
		get
		{
			return base.InternalKCT.InternalStatusStripGradientBegin;
		}
		set
		{
			base.InternalKCT.InternalStatusStripGradientBegin = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Ending color of the gradient used on the StatusStrip.")]
	[KryptonDefaultColor]
	public Color StatusStripGradientEnd
	{
		get
		{
			return base.InternalKCT.InternalStatusStripGradientEnd;
		}
		set
		{
			base.InternalKCT.InternalStatusStripGradientEnd = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	internal KryptonPaletteTMSStatusStrip(KryptonInternalKCT internalKCT, NeedPaintHandler needPaint)
		: base(internalKCT, needPaint)
	{
	}

	public void PopulateFromBase()
	{
		StatusStripText = base.InternalKCT.StatusStripText;
		StatusStripFont = base.InternalKCT.StatusStripFont;
		StatusStripGradientBegin = base.InternalKCT.StatusStripGradientBegin;
		StatusStripGradientEnd = base.InternalKCT.StatusStripGradientEnd;
	}

	public void ResetStatusStripText()
	{
		StatusStripText = Color.Empty;
	}

	public void ResetStatusStripFont()
	{
		StatusStripText = Color.Empty;
	}

	public void ResetStatusStripGradientBegin()
	{
		StatusStripGradientBegin = Color.Empty;
	}

	public void ResetStatusStripGradientEnd()
	{
		StatusStripGradientEnd = Color.Empty;
	}
}
