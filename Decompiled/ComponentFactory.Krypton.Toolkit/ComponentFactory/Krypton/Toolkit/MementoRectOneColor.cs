using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRectOneColor : MementoDisposable
{
	public Rectangle rect;

	public Color c1;

	public MementoRectOneColor(Rectangle r, Color color1)
	{
		rect = r;
		c1 = color1;
	}

	public bool UseCachedValues(Rectangle r, Color color1)
	{
		bool result = rect.Equals(r) && c1.Equals(color1);
		rect = r;
		c1 = color1;
		return result;
	}
}
