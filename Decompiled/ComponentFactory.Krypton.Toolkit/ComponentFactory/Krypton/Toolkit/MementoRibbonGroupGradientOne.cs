using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonGroupGradientOne : MementoRectTwoColor
{
	public LinearGradientBrush brush;

	public MementoRibbonGroupGradientOne(Rectangle r, Color color1, Color color2)
		: base(r, color1, color2)
	{
	}

	public override void Dispose(bool disposing)
	{
		if (brush != null)
		{
			brush.Dispose();
			brush = null;
		}
		base.Dispose(disposing);
	}
}
