using System.Drawing;

namespace System.Windows.Forms;

public class LayoutHelper
{
	public enum RTLLayoutPosition
	{
		Near,
		Far
	}

	private readonly Ribbon _ribbon;

	public LayoutHelper(Ribbon ribbon)
	{
		_ribbon = ribbon;
	}

	public Rectangle CalcNewPosition(Rectangle reference, Rectangle rect, RTLLayoutPosition type, int distance)
	{
		if ((_ribbon.RightToLeft == RightToLeft.No && type == RTLLayoutPosition.Near) || (_ribbon.RightToLeft == RightToLeft.Yes && type == RTLLayoutPosition.Far))
		{
			return new Rectangle(reference.Left - distance - rect.Width, rect.Y, rect.Width, rect.Height);
		}
		return new Rectangle(reference.Right + distance, rect.Y, rect.Width, rect.Height);
	}

	public Point CalcNewPosition(Rectangle reference, Point point, RTLLayoutPosition type, int distance)
	{
		if ((_ribbon.RightToLeft == RightToLeft.No && type == RTLLayoutPosition.Near) || (_ribbon.RightToLeft == RightToLeft.Yes && type == RTLLayoutPosition.Far))
		{
			return new Point(reference.Left - distance, point.Y);
		}
		return new Point(reference.Right + distance, point.Y);
	}

	public Rectangle CalcNewPosition(Point reference, Rectangle rect, RTLLayoutPosition type, int distance)
	{
		if ((_ribbon.RightToLeft == RightToLeft.No && type == RTLLayoutPosition.Near) || (_ribbon.RightToLeft == RightToLeft.Yes && type == RTLLayoutPosition.Far))
		{
			return new Rectangle(reference.X - distance - rect.Width, rect.Y, rect.Width, rect.Height);
		}
		return new Rectangle(reference.X + distance, rect.Y, rect.Width, rect.Height);
	}
}
