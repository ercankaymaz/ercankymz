using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns27;

namespace buMutliTextbox;

public class Ruler : UserControl
{
	public EventHandler TargetChanged;

	[CompilerGenerated]
	private Color color_0;

	[CompilerGenerated]
	private Color color_1;

	[CompilerGenerated]
	private Color color_2;

	private buMultiTextBox buMultiTextBox_0;

	internal IContainer icontainer_0 = null;

	[DefaultValue(typeof(Color), "ControlLight")]
	public Color BackColor2
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

	[DefaultValue(typeof(Color), "DarkGray")]
	public Color TickColor
	{
		[CompilerGenerated]
		get
		{
			return color_1;
		}
		[CompilerGenerated]
		set
		{
			color_1 = value;
		}
	}

	[DefaultValue(typeof(Color), "Black")]
	public Color CaretTickColor
	{
		[CompilerGenerated]
		get
		{
			return color_2;
		}
		[CompilerGenerated]
		set
		{
			color_2 = value;
		}
	}

	[Description("Target FastColoredTextBox")]
	public buMultiTextBox Target
	{
		get
		{
			return buMultiTextBox_0;
		}
		set
		{
			if (buMultiTextBox_0 != null)
			{
				UnSubscribe(buMultiTextBox_0);
			}
			buMultiTextBox_0 = value;
			Subscribe(buMultiTextBox_0);
			OnTargetChanged();
		}
	}

	public Ruler()
	{
		Class76.smethod_167(this);
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		MinimumSize = new Size(0, 24);
		MaximumSize = new Size(1073741823, 24);
		BackColor2 = SystemColors.ControlLight;
		TickColor = Color.DarkGray;
		CaretTickColor = Color.Black;
	}

	protected virtual void OnTargetChanged()
	{
		if (TargetChanged != null)
		{
			TargetChanged(this, EventArgs.Empty);
		}
	}

	protected virtual void UnSubscribe(buMultiTextBox target)
	{
		target.Scroll -= target_Scroll;
		target.SelectionChanged -= method_1;
		target.VisibleRangeChanged -= method_0;
	}

	protected virtual void Subscribe(buMultiTextBox target)
	{
		target.Scroll += target_Scroll;
		target.SelectionChanged += method_1;
		target.VisibleRangeChanged += method_0;
	}

	private void method_0(object sender, EventArgs e)
	{
		Invalidate();
	}

	private void method_1(object sender, EventArgs e)
	{
		Invalidate();
	}

	protected virtual void target_Scroll(object sender, ScrollEventArgs e)
	{
		Invalidate();
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		Invalidate();
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		if (buMultiTextBox_0 == null)
		{
			return;
		}
		Point point = PointToClient(buMultiTextBox_0.PointToScreen(buMultiTextBox_0.PlaceToPoint(buMultiTextBox_0.Selection.Start)));
		Size size = TextRenderer.MeasureText("W", Font);
		int num = 0;
		e.Graphics.FillRectangle(new LinearGradientBrush(new Rectangle(0, 0, base.Width, base.Height), BackColor, BackColor2, 270f), new Rectangle(0, 0, base.Width, base.Height));
		float num2 = buMultiTextBox_0.CharWidth;
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = StringAlignment.Center;
		stringFormat.LineAlignment = StringAlignment.Near;
		Point p = buMultiTextBox_0.PositionToPoint(0);
		p = PointToClient(buMultiTextBox_0.PointToScreen(p));
		using (Pen pen = new Pen(TickColor))
		{
			using SolidBrush brush = new SolidBrush(ForeColor);
			float num3 = p.X;
			while (num3 < (float)base.Right)
			{
				if (num % 10 == 0)
				{
					e.Graphics.DrawString(num.ToString(), Font, brush, num3, 0f, stringFormat);
				}
				e.Graphics.DrawLine(pen, (int)num3, size.Height + ((num % 5 == 0) ? 1 : 3), (int)num3, base.Height - 4);
				num3 += num2;
				num++;
			}
		}
		using (Pen pen2 = new Pen(TickColor))
		{
			e.Graphics.DrawLine(pen2, new Point(point.X - 3, base.Height - 3), new Point(point.X + 3, base.Height - 3));
		}
		using Pen pen3 = new Pen(CaretTickColor);
		e.Graphics.DrawLine(pen3, new Point(point.X - 2, size.Height + 3), new Point(point.X - 2, base.Height - 4));
		e.Graphics.DrawLine(pen3, new Point(point.X, size.Height + 1), new Point(point.X, base.Height - 4));
		e.Graphics.DrawLine(pen3, new Point(point.X + 2, size.Height + 3), new Point(point.X + 2, base.Height - 4));
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
