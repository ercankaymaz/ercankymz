using System.Drawing;
using System.Runtime.CompilerServices;

namespace buMutliTextbox;

public class MarkerStyle : Style
{
	[CompilerGenerated]
	private Brush brush_0;

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

	public MarkerStyle(Brush backgroundBrush)
	{
		BackgroundBrush = backgroundBrush;
		IsExportable = true;
	}

	public override void Draw(Graphics gr, Point position, Range range)
	{
		if (BackgroundBrush != null)
		{
			Rectangle rect = new Rectangle(position.X, position.Y, (range.End.iChar - range.Start.iChar) * range.tb.CharWidth, range.tb.CharHeight);
			if (rect.Width != 0)
			{
				gr.FillRectangle(BackgroundBrush, rect);
			}
		}
	}

	public override string GetCSS()
	{
		string text = "";
		if (BackgroundBrush is SolidBrush)
		{
			string colorAsString = ExportToHTML.GetColorAsString((BackgroundBrush as SolidBrush).Color);
			if (colorAsString != "")
			{
				text = text + "background-color:" + colorAsString + ";";
			}
		}
		return text;
	}
}
