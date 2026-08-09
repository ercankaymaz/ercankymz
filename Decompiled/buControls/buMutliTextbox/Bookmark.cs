using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

namespace buMutliTextbox;

public class Bookmark
{
	[CompilerGenerated]
	private buMultiTextBox buMultiTextBox_0;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private Color color_0;

	public buMultiTextBox TB
	{
		[CompilerGenerated]
		get
		{
			return buMultiTextBox_0;
		}
		[CompilerGenerated]
		private set
		{
			buMultiTextBox_0 = value;
		}
	}

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public int LineIndex
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public Color Color
	{
		[CompilerGenerated]
		get
		{
			return color_0;
		}
		[CompilerGenerated]
		set
		{
			color_0 = value;
		}
	}

	public virtual void DoVisible()
	{
		TB.Selection.Start = new Place(0, LineIndex);
		TB.DoRangeVisible(TB.Selection, tryToCentre: true);
		TB.Invalidate();
	}

	public Bookmark(buMultiTextBox tb, string name, int lineIndex)
	{
		TB = tb;
		Name = name;
		LineIndex = lineIndex;
		Color = tb.BookmarkColor;
	}

	public virtual void Paint(Graphics gr, Rectangle lineRect)
	{
		int num = TB.CharHeight - 1;
		using (LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, lineRect.Top, num, num), Color.White, Color, 45f))
		{
			gr.FillEllipse(brush, 0, lineRect.Top, num, num);
		}
		using Pen pen = new Pen(Color);
		gr.DrawEllipse(pen, 0, lineRect.Top, num, num);
	}
}
