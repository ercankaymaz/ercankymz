using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonGroupNormalTitle : MementoRectTwoColor
{
	public GraphicsPath titlePath;

	public LinearGradientBrush titleBrush;

	public MementoRibbonGroupNormalTitle(Rectangle r, Color color1, Color color2)
		: base(r, color1, color2)
	{
	}

	public override void Dispose(bool disposing)
	{
		if (titlePath != null)
		{
			titlePath.Dispose();
			titleBrush.Dispose();
			titlePath = null;
			titleBrush = null;
		}
		base.Dispose(disposing);
	}
}
