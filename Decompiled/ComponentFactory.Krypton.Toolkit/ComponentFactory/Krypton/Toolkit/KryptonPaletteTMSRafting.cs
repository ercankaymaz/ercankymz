using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteTMSRafting : KryptonPaletteTMSBase
{
	[Browsable(false)]
	public override bool IsDefault => base.InternalKCT.InternalRaftingContainerGradientBegin == Color.Empty && base.InternalKCT.InternalRaftingContainerGradientEnd == Color.Empty;

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Starting color of the gradient used in the ToolStripContainer.")]
	[KryptonDefaultColor]
	public Color RaftingContainerGradientBegin
	{
		get
		{
			return base.InternalKCT.InternalRaftingContainerGradientBegin;
		}
		set
		{
			base.InternalKCT.InternalRaftingContainerGradientBegin = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Ending color of the gradient used in the ToolStripContainer.")]
	[KryptonDefaultColor]
	public Color RaftingContainerGradientEnd
	{
		get
		{
			return base.InternalKCT.InternalRaftingContainerGradientEnd;
		}
		set
		{
			base.InternalKCT.InternalRaftingContainerGradientEnd = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	internal KryptonPaletteTMSRafting(KryptonInternalKCT internalKCT, NeedPaintHandler needPaint)
		: base(internalKCT, needPaint)
	{
	}

	public void PopulateFromBase()
	{
		RaftingContainerGradientBegin = base.InternalKCT.RaftingContainerGradientBegin;
		RaftingContainerGradientEnd = base.InternalKCT.RaftingContainerGradientEnd;
	}

	public void ResetRaftingContainerGradientBegin()
	{
		RaftingContainerGradientBegin = Color.Empty;
	}

	public void ResetRaftingContainerGradientEnd()
	{
		RaftingContainerGradientEnd = Color.Empty;
	}
}
