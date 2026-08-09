using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns27;

namespace buControls.Components;

[ToolboxItem(true)]
[DefaultProperty("ClockFaceColor")]
public class buClock : Control
{
	private readonly Timer timer_0;

	private bool bool_0;

	[CompilerGenerated]
	private Color color_0 = Color.FromArgb(30, 30, 35);

	[CompilerGenerated]
	private Color color_1 = Color.FromArgb(80, 80, 90);

	[CompilerGenerated]
	private Color color_2 = Color.WhiteSmoke;

	[CompilerGenerated]
	private Color color_3 = Color.White;

	[CompilerGenerated]
	private Color color_4 = Color.Gainsboro;

	[CompilerGenerated]
	private Color color_5 = Color.OrangeRed;

	[CompilerGenerated]
	private Color color_6 = Color.DeepSkyBlue;

	[CompilerGenerated]
	private Color color_7 = Color.White;

	[CompilerGenerated]
	private Font font_0 = new Font("Segoe UI", 10f, FontStyle.Bold);

	[CompilerGenerated]
	private int int_0 = 45;

	[CompilerGenerated]
	private bool bool_1 = true;

	[CompilerGenerated]
	private bool bool_2 = true;

	[CompilerGenerated]
	private bool bool_3 = true;

	[CompilerGenerated]
	private bool bool_4 = false;

	[CompilerGenerated]
	private float float_0 = 6f;

	[CompilerGenerated]
	private float float_1 = 6f;

	[CompilerGenerated]
	private float float_2 = 4f;

	[CompilerGenerated]
	private float float_3 = 2f;

	[Category("Appearance")]
	public Color ClockFaceColor
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

	[Category("Appearance")]
	public Color OuterRingColor
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

	[Category("Appearance")]
	public Color TickColor
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

	[Category("Appearance")]
	public Color HourHandColor
	{
		[CompilerGenerated]
		get
		{
			return color_3;
		}
		[CompilerGenerated]
		set
		{
			color_3 = value;
		}
	}

	[Category("Appearance")]
	public Color MinuteHandColor
	{
		[CompilerGenerated]
		get
		{
			return color_4;
		}
		[CompilerGenerated]
		set
		{
			color_4 = value;
		}
	}

	[Category("Appearance")]
	public Color SecondHandColor
	{
		[CompilerGenerated]
		get
		{
			return color_5;
		}
		[CompilerGenerated]
		set
		{
			color_5 = value;
		}
	}

	[Category("Appearance")]
	public Color DigitalTimeColor
	{
		[CompilerGenerated]
		get
		{
			return color_6;
		}
		[CompilerGenerated]
		set
		{
			color_6 = value;
		}
	}

	[Category("Appearance")]
	public Color CenterColor
	{
		[CompilerGenerated]
		get
		{
			return color_7;
		}
		[CompilerGenerated]
		set
		{
			color_7 = value;
		}
	}

	[Category("Appearance")]
	public Font DigitalFont
	{
		[CompilerGenerated]
		get
		{
			return font_0;
		}
		[CompilerGenerated]
		set
		{
			font_0 = value;
		}
	}

	[Category("Appearance")]
	[DefaultValue(45)]
	public int DigitalTimeHeight
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

	[Category("Behavior")]
	public bool Running => bool_0;

	[Category("Behavior")]
	public bool ShowDigitalTime
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	[Category("Behavior")]
	public bool ShowSecondHand
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
	}

	[Category("Behavior")]
	public bool ShowGlow
	{
		[CompilerGenerated]
		get
		{
			return bool_3;
		}
		[CompilerGenerated]
		set
		{
			bool_3 = value;
		}
	}

	[Category("Behavior")]
	public bool ShowNumbers
	{
		[CompilerGenerated]
		get
		{
			return bool_4;
		}
		[CompilerGenerated]
		set
		{
			bool_4 = value;
		}
	}

	[Category("Appearance")]
	public float OuterRingThickness
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
		[CompilerGenerated]
		set
		{
			float_0 = value;
		}
	}

	[Category("Appearance")]
	public float HourHandThickness
	{
		[CompilerGenerated]
		get
		{
			return float_1;
		}
		[CompilerGenerated]
		set
		{
			float_1 = value;
		}
	}

	[Category("Appearance")]
	public float MinuteHandThickness
	{
		[CompilerGenerated]
		get
		{
			return float_2;
		}
		[CompilerGenerated]
		set
		{
			float_2 = value;
		}
	}

	[Category("Appearance")]
	public float SecondHandThickness
	{
		[CompilerGenerated]
		get
		{
			return float_3;
		}
		[CompilerGenerated]
		set
		{
			float_3 = value;
		}
	}

	public buClock()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		DoubleBuffered = true;
		BackColor = Color.Transparent;
		base.Size = new Size(280, 280);
		timer_0 = new Timer();
		timer_0.Interval = 20;
		timer_0.Tick += delegate
		{
			Invalidate();
		};
	}

	public void Start()
	{
		if (!bool_0)
		{
			timer_0.Start();
			bool_0 = true;
		}
	}

	public void Stop()
	{
		if (bool_0)
		{
			timer_0.Stop();
			bool_0 = false;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			timer_0?.Dispose();
		}
		base.Dispose(disposing);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		Graphics graphics = e.Graphics;
		graphics.SmoothingMode = SmoothingMode.AntiAlias;
		graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
		graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		int num = (ShowDigitalTime ? DigitalTimeHeight : 0);
		int num2 = base.Height - num;
		int num3 = Math.Min(base.Width, num2);
		int num4 = num3 / 2 - 15;
		int num5 = (ShowDigitalTime ? (-5) : 0);
		Point point_ = new Point(base.Width / 2, num2 / 2 + num5);
		Rectangle rectangle_ = new Rectangle(point_.X - num4, point_.Y - num4, num4 * 2, num4 * 2);
		Class76.smethod_134(graphics, this, rectangle_);
		Class76.smethod_527(num4, this, graphics, point_);
		if (ShowNumbers)
		{
			method_0(graphics, point_, num4);
		}
		Class76.smethod_452(this, graphics, point_, num4);
		Class76.smethod_736(point_, graphics, this);
		if (ShowDigitalTime)
		{
			Class76.smethod_6(this, graphics);
		}
	}

	private void method_0(Graphics graphics_0, Point point_0, int int_1)
	{
		using Brush brush = new SolidBrush(TickColor);
		for (int i = 1; i <= 12; i++)
		{
			double num = (double)(i * 30) * Math.PI / 180.0;
			int num2 = point_0.X + (int)(Math.Sin(num) * (double)(int_1 - 40));
			int num3 = point_0.Y - (int)(Math.Cos(num) * (double)(int_1 - 40));
			string s = i.ToString();
			SizeF sizeF = graphics_0.MeasureString(s, Font);
			graphics_0.DrawString(s, Font, brush, (float)num2 - sizeF.Width / 2f, (float)num3 - sizeF.Height / 2f);
		}
	}

	[CompilerGenerated]
	private void timer_0_Tick(object sender, EventArgs e)
	{
		Invalidate();
	}
}
