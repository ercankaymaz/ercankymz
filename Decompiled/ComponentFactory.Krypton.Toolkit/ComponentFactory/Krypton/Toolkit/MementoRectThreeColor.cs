using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRectThreeColor : MementoRectTwoColor
{
	public Color c3;

	public MementoRectThreeColor(Rectangle r, Color color1, Color color2, Color color3)
		: base(r, color1, color2)
	{
		c3 = color3;
	}

	public bool UseCachedValues(Rectangle r, Color color1, Color color2, Color color3)
	{
		bool result = UseCachedValues(r, color1, color2) && c3.Equals(color3);
		c3 = color3;
		return result;
	}
}
