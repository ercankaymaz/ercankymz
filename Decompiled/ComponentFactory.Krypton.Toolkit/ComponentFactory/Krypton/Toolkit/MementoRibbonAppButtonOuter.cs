using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonAppButtonOuter : MementoRectThreeColor
{
	public SolidBrush wholeBrush;

	public GraphicsPath backPath;

	public LinearGradientBrush bottomDarkGradient;

	public LinearGradientBrush topLightenGradient;

	public MementoRibbonAppButtonOuter(Rectangle r, Color color1, Color color2, Color color3)
		: base(r, color1, color2, color3)
	{
	}

	public override void Dispose(bool disposing)
	{
		if (wholeBrush != null)
		{
			wholeBrush.Dispose();
			wholeBrush = null;
			backPath.Dispose();
			backPath = null;
			bottomDarkGradient.Dispose();
			bottomDarkGradient = null;
			topLightenGradient.Dispose();
			topLightenGradient = null;
		}
		base.Dispose(disposing);
	}
}
