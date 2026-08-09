using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonQATOverflow : MementoRectTwoColor
{
	public SolidBrush backBrush;

	public Pen borderPen;

	public MementoRibbonQATOverflow(Rectangle r, Color color1, Color color2)
		: base(r, color1, color2)
	{
	}

	public override void Dispose(bool disposing)
	{
		if (backBrush != null)
		{
			backBrush.Dispose();
			borderPen.Dispose();
			backBrush = null;
			borderPen = null;
		}
		base.Dispose(disposing);
	}
}
