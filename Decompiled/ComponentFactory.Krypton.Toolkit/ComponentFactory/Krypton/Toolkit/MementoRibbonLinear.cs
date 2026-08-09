using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonLinear : MementoRectTwoColor
{
	public LinearGradientBrush linearBrush;

	public MementoRibbonLinear(Rectangle r, Color color1, Color color2)
		: base(r, color1, color2)
	{
	}

	public override void Dispose(bool disposing)
	{
		if (linearBrush != null)
		{
			linearBrush.Dispose();
			linearBrush = null;
		}
		base.Dispose(disposing);
	}
}
