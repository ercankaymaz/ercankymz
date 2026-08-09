using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonTabHighlight : MementoRectFiveColor
{
	public VisualOrientation orientation;

	public LinearGradientBrush topBorderBrush;

	public LinearGradientBrush borderVertBrush;

	public LinearGradientBrush outsideVertBrush;

	public MementoRibbonTabSelected2007 selectedMemento;

	public Pen innerVertPen;

	public Pen innerHorzPen;

	public Pen borderHorzPen;

	public MementoRibbonTabHighlight(Rectangle r, Color color1, Color color2, Color color3, Color color4, Color color5, VisualOrientation orient)
		: base(r, color1, color2, color3, color4, color5)
	{
		orientation = orient;
	}

	public bool UseCachedValues(Rectangle r, Color color1, Color color2, Color color3, Color color4, Color color5, VisualOrientation orient)
	{
		bool result = UseCachedValues(r, color1, color2, color3, color4, color5) && orient == orientation;
		orientation = orient;
		return result;
	}

	public override void Dispose(bool disposing)
	{
		if (selectedMemento != null)
		{
			selectedMemento.Dispose();
			selectedMemento = null;
		}
		if (topBorderBrush != null)
		{
			topBorderBrush.Dispose();
			borderVertBrush.Dispose();
			outsideVertBrush.Dispose();
			innerVertPen.Dispose();
			innerHorzPen.Dispose();
			borderHorzPen.Dispose();
			topBorderBrush = null;
			borderVertBrush = null;
			outsideVertBrush = null;
			innerVertPen = null;
			innerHorzPen = null;
			borderHorzPen = null;
		}
		base.Dispose(disposing);
	}
}
