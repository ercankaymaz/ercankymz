using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteTMSGrip : KryptonPaletteTMSBase
{
	[Browsable(false)]
	public override bool IsDefault => base.InternalKCT.InternalGripDark == Color.Empty && base.InternalKCT.InternalGripLight == Color.Empty;

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Color to use for shadow effects on the grip (move handle).")]
	[KryptonDefaultColor]
	public Color GripDark
	{
		get
		{
			return base.InternalKCT.InternalGripDark;
		}
		set
		{
			base.InternalKCT.InternalGripDark = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Color to use for highlight effects on the grip (move handle).")]
	[KryptonDefaultColor]
	public Color GripLight
	{
		get
		{
			return base.InternalKCT.InternalGripLight;
		}
		set
		{
			base.InternalKCT.InternalGripLight = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	internal KryptonPaletteTMSGrip(KryptonInternalKCT internalKCT, NeedPaintHandler needPaint)
		: base(internalKCT, needPaint)
	{
	}

	public void PopulateFromBase()
	{
		GripDark = base.InternalKCT.GripDark;
		GripLight = base.InternalKCT.GripLight;
	}

	public void ResetGripDark()
	{
		GripDark = Color.Empty;
	}

	public void ResetGripLight()
	{
		GripLight = Color.Empty;
	}
}
