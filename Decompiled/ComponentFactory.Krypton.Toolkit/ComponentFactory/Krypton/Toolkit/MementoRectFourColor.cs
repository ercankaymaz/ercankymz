using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRectFourColor : MementoRectThreeColor
{
	public Color c4;

	public MementoRectFourColor(Rectangle r, Color color1, Color color2, Color color3, Color color4)
		: base(r, color1, color2, color3)
	{
		c4 = color4;
	}

	public bool UseCachedValues(Rectangle r, Color color1, Color color2, Color color3, Color color4)
	{
		bool result = UseCachedValues(r, color1, color2, color3) && c4.Equals(color4);
		c4 = color4;
		return result;
	}
}
