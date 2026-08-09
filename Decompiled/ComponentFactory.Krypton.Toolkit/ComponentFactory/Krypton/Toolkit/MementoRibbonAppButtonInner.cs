using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonAppButtonInner : MementoRectTwoColor
{
	public SolidBrush outsideBrush;

	public SolidBrush insideBrush;

	public MementoRibbonAppButtonInner(Rectangle r, Color color1, Color color2)
		: base(r, color1, color2)
	{
	}

	public override void Dispose(bool disposing)
	{
		if (outsideBrush != null)
		{
			outsideBrush.Dispose();
			outsideBrush = null;
			insideBrush.Dispose();
			insideBrush = null;
		}
		base.Dispose(disposing);
	}
}
