using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoBackGlassThreeEdge : MementoDouble
{
	public Rectangle rect;

	public Color color1;

	public Color color2;

	public VisualOrientation orientation;

	public Color colorA1L;

	public Color colorA2L;

	public Color colorA2LL;

	public Color colorB2LL;

	public Rectangle rectB;

	public MementoBackGlassThreeEdge(Rectangle r, Color c1, Color c2, VisualOrientation orient)
	{
		rect = r;
		color1 = c1;
		color2 = c2;
		orientation = orient;
	}

	public bool UseCachedValues(Rectangle r, Color c1, Color c2, VisualOrientation orient)
	{
		bool result = rect.Equals(r) && color1.Equals(c1) && color2.Equals(c2) && orientation == orient;
		rect = r;
		color1 = c1;
		color2 = c2;
		orientation = orient;
		return result;
	}
}
