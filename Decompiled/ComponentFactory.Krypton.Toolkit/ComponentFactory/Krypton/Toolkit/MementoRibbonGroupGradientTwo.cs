using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonGroupGradientTwo : MementoRectFourColor
{
	public Rectangle topRect;

	public Rectangle bottomRect;

	public LinearGradientBrush topBrush;

	public LinearGradientBrush bottomBrush;

	public MementoRibbonGroupGradientTwo(Rectangle r, Color color1, Color color2, Color color3, Color color4)
		: base(r, color1, color2, color3, color4)
	{
	}

	public override void Dispose(bool disposing)
	{
		if (topBrush != null)
		{
			topBrush.Dispose();
			bottomBrush.Dispose();
			topBrush = null;
			bottomBrush = null;
		}
		base.Dispose(disposing);
	}
}
