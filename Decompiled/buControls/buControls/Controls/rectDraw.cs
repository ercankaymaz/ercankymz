using System.Drawing;

namespace buControls.Controls;

public class rectDraw
{
	public RectangleF rect = default(RectangleF);

	public RectangleF rectText = default(RectangleF);

	public RoundRectangleType RoundType = RoundRectangleType.RoundRectAll;

	public rectDraw()
	{
	}

	public rectDraw(RectangleF rectt, RoundRectangleType round)
	{
		rect = new RectangleF(rectt.X, rectt.Y, rectt.Width, rectt.Height);
		rectText = new RectangleF(rectt.X, rectt.Y, rectt.Width, rectt.Height);
		RoundType = round;
	}
}
