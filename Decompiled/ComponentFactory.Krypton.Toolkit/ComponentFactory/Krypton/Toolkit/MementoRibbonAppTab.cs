using System.Drawing;
using System.Drawing.Drawing2D;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoRibbonAppTab : MementoRectTwoColor
{
	public GraphicsPath borderPath;

	public GraphicsPath borderFillPath;

	public GraphicsPath insideFillPath;

	public GraphicsPath highlightPath;

	public PathGradientBrush highlightBrush;

	public Rectangle highlightRect;

	public Pen borderPen;

	public Brush borderBrush;

	public LinearGradientBrush insideFillBrush;

	public MementoRibbonAppTab(Rectangle r, Color color1, Color color2)
		: base(r, color1, color2)
	{
	}

	public void GeneratePaths(Rectangle rect, PaletteState state)
	{
		borderPath = new GraphicsPath();
		borderPath.AddLine(rect.Left, rect.Bottom - 2, rect.Left, (float)rect.Top + 1.75f);
		borderPath.AddLine(rect.Left, (float)rect.Top + 1.75f, rect.Left + 1, rect.Top);
		borderPath.AddLine(rect.Left + 1, rect.Top, rect.Right - 2, rect.Top);
		borderPath.AddLine(rect.Right - 2, rect.Top, rect.Right - 1, (float)rect.Top + 1.75f);
		borderPath.AddLine(rect.Right - 1, (float)rect.Top + 1.75f, rect.Right - 1, rect.Bottom - 2);
		borderFillPath = new GraphicsPath();
		borderFillPath.AddLine(rect.Left, rect.Bottom - 1, rect.Left, (float)rect.Top + 1.75f);
		borderFillPath.AddLine(rect.Left, (float)rect.Top + 1.75f, rect.Left + 1, rect.Top);
		borderFillPath.AddLine(rect.Left + 1, rect.Top, rect.Right - 2, rect.Top);
		borderFillPath.AddLine(rect.Right - 2, rect.Top, rect.Right - 1, (float)rect.Top + 1.75f);
		borderFillPath.AddLine(rect.Right - 1, (float)rect.Top + 1.75f, rect.Right - 1, rect.Bottom - 1);
		highlightRect = new Rectangle(rect.Left - rect.Width / 8, rect.Top + rect.Height / 2 - 2, rect.Width + rect.Width / 5, rect.Height + 4);
		highlightPath = new GraphicsPath();
		highlightPath.AddEllipse(highlightRect);
		highlightBrush = new PathGradientBrush(highlightPath);
		highlightBrush.CenterPoint = new PointF(highlightRect.Left + highlightRect.Width / 2, highlightRect.Top + highlightRect.Height / 2);
		highlightBrush.SurroundColors = new Color[1] { Color.Transparent };
		rect.X += 2;
		rect.Y += 2;
		rect.Width -= 3;
		rect.Height -= 2;
		insideFillPath = new GraphicsPath();
		insideFillPath.AddLine(rect.Left, rect.Bottom - 1, rect.Left, (float)rect.Top + 1f);
		insideFillPath.AddLine(rect.Left, (float)rect.Top + 1f, rect.Left + 1, rect.Top);
		insideFillPath.AddLine(rect.Left + 1, rect.Top, rect.Right - 2, rect.Top);
		insideFillPath.AddLine(rect.Right - 2, rect.Top, rect.Right - 1, (float)rect.Top + 1.75f);
		insideFillPath.AddLine(rect.Right - 1, (float)rect.Top + 1.75f, rect.Right - 1, rect.Bottom - 1);
	}

	public override void Dispose(bool disposing)
	{
		if (borderPath != null)
		{
			borderPath.Dispose();
			borderFillPath.Dispose();
			insideFillPath.Dispose();
			borderPen.Dispose();
			borderBrush.Dispose();
			insideFillBrush.Dispose();
			borderPath = null;
			borderFillPath = null;
			insideFillPath = null;
			borderPen = null;
			borderBrush = null;
			insideFillBrush = null;
		}
		base.Dispose(disposing);
	}
}
