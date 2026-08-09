using System.Drawing;
using System.Runtime.CompilerServices;
using ns27;

namespace buMutliTextbox;

public class WavyLineStyle : Style
{
	[CompilerGenerated]
	private Pen pen_0;

	[SpecialName]
	[CompilerGenerated]
	internal Pen method_0()
	{
		return pen_0;
	}

	[SpecialName]
	[CompilerGenerated]
	private void method_1(Pen pen_1)
	{
		pen_0 = pen_1;
	}

	public WavyLineStyle(int alpha, Color color)
	{
		method_1(new Pen(Color.FromArgb(alpha, color)));
	}

	public override void Draw(Graphics gr, Point pos, Range range)
	{
		Size sizeOfRange = Style.GetSizeOfRange(range);
		Point point_ = new Point(pos.X, pos.Y + sizeOfRange.Height - 1);
		Point point_2 = new Point(pos.X + sizeOfRange.Width, pos.Y + sizeOfRange.Height - 1);
		Class76.smethod_375(point_, gr, point_2, this);
	}

	public override void Dispose()
	{
		base.Dispose();
		if (method_0() != null)
		{
			method_0().Dispose();
		}
	}
}
