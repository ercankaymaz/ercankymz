using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonAppButton : MementoRectFiveColor
{
	public RectangleF borderShadow1;

	public RectangleF borderShadow2;

	public RectangleF borderMain1;

	public RectangleF borderMain2;

	public RectangleF borderMain3;

	public RectangleF borderMain4;

	public RectangleF rectLower;

	public RectangleF rectBottomGlow;

	public RectangleF rectUpperGlow;

	public LinearGradientBrush brushUpper1;

	public LinearGradientBrush brushLower;

	public MementoRibbonAppButton(Rectangle r, Color color1, Color color2, Color color3, Color color4, Color color5)
		: base(r, color1, color2, color3, color4, color5)
	{
	}

	public override void Dispose(bool disposing)
	{
		if (brushUpper1 != null)
		{
			brushUpper1.Dispose();
			brushUpper1 = null;
			brushLower.Dispose();
			brushLower = null;
		}
		base.Dispose(disposing);
	}
}
