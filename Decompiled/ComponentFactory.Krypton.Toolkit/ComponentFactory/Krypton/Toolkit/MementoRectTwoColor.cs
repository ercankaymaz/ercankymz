using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRectTwoColor : MementoDisposable
{
	public Rectangle rect;

	public Color c1;

	public Color c2;

	public MementoRectTwoColor(Rectangle r, Color color1, Color color2)
	{
		rect = r;
		c1 = color1;
		c2 = color2;
	}

	public bool UseCachedValues(Rectangle r, Color color1, Color color2)
	{
		bool result = rect.Equals(r) && c1.Equals(color1) && c2.Equals(color2);
		rect = r;
		c1 = color1;
		c2 = color2;
		return result;
	}
}
