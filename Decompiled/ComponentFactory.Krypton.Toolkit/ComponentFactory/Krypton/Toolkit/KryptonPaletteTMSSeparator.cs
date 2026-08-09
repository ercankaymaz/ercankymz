using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteTMSSeparator : KryptonPaletteTMSBase
{
	[Browsable(false)]
	public override bool IsDefault => base.InternalKCT.InternalSeparatorDark == Color.Empty && base.InternalKCT.InternalSeparatorLight == Color.Empty;

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Color to use for shadow effects on the ToolStripSeparator.")]
	[KryptonDefaultColor]
	public Color SeparatorDark
	{
		get
		{
			return base.InternalKCT.InternalSeparatorDark;
		}
		set
		{
			base.InternalKCT.InternalSeparatorDark = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Color to use for highlight effects on the ToolStripSeparator.")]
	[KryptonDefaultColor]
	public Color SeparatorLight
	{
		get
		{
			return base.InternalKCT.InternalSeparatorLight;
		}
		set
		{
			base.InternalKCT.InternalSeparatorLight = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	internal KryptonPaletteTMSSeparator(KryptonInternalKCT internalKCT, NeedPaintHandler needPaint)
		: base(internalKCT, needPaint)
	{
	}

	public void PopulateFromBase()
	{
		SeparatorDark = base.InternalKCT.SeparatorDark;
		SeparatorLight = base.InternalKCT.SeparatorLight;
	}

	public void ResetSeparatorDark()
	{
		SeparatorDark = Color.Empty;
	}

	public void ResetSeparatorLight()
	{
		SeparatorLight = Color.Empty;
	}
}
