using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace buMutliTextbox;

public class PaintLineEventArgs : PaintEventArgs
{
	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private Rectangle rectangle_0;

	public int LineIndex
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		private set
		{
			int_0 = value;
		}
	}

	public Rectangle LineRect
	{
		[CompilerGenerated]
		get
		{
			return rectangle_0;
		}
		[CompilerGenerated]
		private set
		{
			rectangle_0 = value;
		}
	}

	public PaintLineEventArgs(int iLine, Rectangle rect, Graphics gr, Rectangle clipRect)
		: base(gr, clipRect)
	{
		LineIndex = iLine;
		LineRect = rect;
	}
}
