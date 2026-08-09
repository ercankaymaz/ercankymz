using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRectFiveColor : MementoRectFourColor
{
	public Color c5;

	public MementoRectFiveColor(Rectangle r, Color color1, Color color2, Color color3, Color color4, Color color5)
		: base(r, color1, color2, color3, color4)
	{
		c5 = color5;
	}

	public bool UseCachedValues(Rectangle r, Color color1, Color color2, Color color3, Color color4, Color color5)
	{
		bool result = UseCachedValues(r, color1, color2, color3, color4) && c5.Equals(color5);
		c5 = color5;
		return result;
	}
}
