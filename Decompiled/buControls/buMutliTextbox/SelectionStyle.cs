using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

namespace buMutliTextbox;

public class SelectionStyle : Style
{
	[CompilerGenerated]
	private Brush brush_0;

	[CompilerGenerated]
	private Brush brush_1;

	public Brush BackgroundBrush
	{
		[CompilerGenerated]
		get
		{
			return brush_0;
		}
		[CompilerGenerated]
		set
		{
			brush_0 = value;
		}
	}

	public Brush ForegroundBrush
	{
		[CompilerGenerated]
		get
		{
			return brush_1;
		}
		[CompilerGenerated]
		private set
		{
			brush_1 = value;
		}
	}

	public override bool IsExportable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public SelectionStyle(Brush backgroundBrush, Brush foregroundBrush = null)
	{
		BackgroundBrush = backgroundBrush;
		ForegroundBrush = foregroundBrush;
	}

	public override void Draw(Graphics gr, Point position, Range range)
	{
		if (BackgroundBrush == null)
		{
			return;
		}
		gr.SmoothingMode = SmoothingMode.None;
		Rectangle rect = new Rectangle(position.X, position.Y, (range.End.iChar - range.Start.iChar) * range.tb.CharWidth, range.tb.CharHeight);
		if (rect.Width == 0)
		{
			return;
		}
		gr.FillRectangle(BackgroundBrush, rect);
		if (ForegroundBrush != null)
		{
			gr.SmoothingMode = SmoothingMode.AntiAlias;
			Range range2 = new Range(range.tb, range.Start.iChar, range.Start.iLine, Math.Min(range.tb[range.End.iLine].Count, range.End.iChar), range.End.iLine);
			using TextStyle textStyle = new TextStyle(ForegroundBrush, null, FontStyle.Regular);
			textStyle.Draw(gr, new Point(position.X, position.Y - 1), range2);
		}
	}
}
