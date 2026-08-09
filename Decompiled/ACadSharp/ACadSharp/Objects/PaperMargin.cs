using CSMath;

namespace ACadSharp.Objects;

public struct PaperMargin
{
	public double Left { get; set; }

	public double Bottom { get; set; }

	public double Right { get; set; }

	public double Top { get; set; }

	public XY BottomLeftCorner => new XY(Left, Bottom);

	public XY TopCorner => new XY(Right, Top);

	public PaperMargin(double left, double bottom, double right, double top)
	{
		Left = left;
		Bottom = bottom;
		Right = right;
		Top = top;
	}
}
