using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ns27;

namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
public class Line : UserControl
{
	private Container container_0 = null;

	private DashStyle dashStyle_0 = DashStyle.Solid;

	private Color color_0 = Color.FromKnownColor(KnownColor.ControlDark);

	private Color color_1 = Color.FromKnownColor(KnownColor.ControlLightLight);

	private LineStyle lineStyle_0 = LineStyle.Horizontal;

	public DashStyle DashStyle
	{
		get
		{
			return dashStyle_0;
		}
		set
		{
			dashStyle_0 = value;
			Invalidate();
		}
	}

	public Color FirstColor
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
			Invalidate();
		}
	}

	public Color SecondColor
	{
		get
		{
			return color_1;
		}
		set
		{
			color_1 = value;
			Invalidate();
		}
	}

	public LineStyle LineStyle
	{
		get
		{
			return lineStyle_0;
		}
		set
		{
			lineStyle_0 = value;
			base.Size = new Size(base.Height, base.Width);
			Invalidate();
		}
	}

	public Line()
	{
		Class76.smethod_451(this);
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.FixedWidth | ControlStyles.FixedHeight | ControlStyles.AllPaintingInWmPaint, value: true);
		SetStyle(ControlStyles.Selectable, value: false);
		base.TabStop = false;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && container_0 != null)
		{
			container_0.Dispose();
		}
		base.Dispose(disposing);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		int x;
		int y;
		int x2;
		int y2;
		int x3;
		int y3;
		int x4;
		int y4;
		if (LineStyle != LineStyle.Horizontal)
		{
			x = 0;
			y = 0;
			x2 = 0;
			y2 = base.ClientRectangle.Height;
			x3 = 1;
			y3 = 0;
			x4 = 1;
			y4 = base.ClientRectangle.Height;
		}
		else
		{
			x = 0;
			y = 0;
			x2 = base.ClientRectangle.Width;
			y2 = 0;
			x3 = 0;
			y3 = 1;
			x4 = base.ClientRectangle.Width;
			y4 = 1;
		}
		using (Pen pen = new Pen(color_0, 1f))
		{
			pen.DashStyle = dashStyle_0;
			e.Graphics.DrawLine(pen, x, y, x2, y2);
		}
		using Pen pen2 = new Pen(color_1, 1f);
		pen2.DashStyle = dashStyle_0;
		e.Graphics.DrawLine(pen2, x3, y3, x4, y4);
	}

	protected override void OnSizeChanged(EventArgs e)
	{
		base.OnSizeChanged(e);
		Class76.smethod_136(this);
	}
}
