using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ns27;

namespace buControls.Controls;

public class buLedControl : Control, ISupportInitialize
{
	public enum Alignment
	{
		Left,
		Right
	}

	internal GraphicsPath[] graphicsPath_0 = new GraphicsPath[8];

	internal int int_0 = 1;

	internal Color color_0 = Color.Gray;

	internal int int_1 = 5;

	internal int int_2 = 5;

	internal float float_0 = 0.25f;

	internal Color color_1 = Color.DimGray;

	internal Color color_2 = Color.Black;

	internal Color color_3 = Color.DimGray;

	internal float float_1 = 0.2f;

	internal float float_2 = 0.05f;

	internal byte byte_0 = 50;

	internal bool bool_0;

	internal Alignment alignment_0;

	internal bool bool_1;

	internal bool bool_2;

	internal bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	[Browsable(true)]
	[Category("Appearance")]
	[Description("Turn on/off the italic text style.")]
	[DefaultValue(false)]
	public bool UseItalicStyle
	{
		get
		{
			return bool_5;
		}
		set
		{
			if (bool_5 != value)
			{
				bool_5 = value;
				bool_0 = false;
				if (!bool_6)
				{
					Invalidate();
				}
			}
		}
	}

	[Description("Turn on/off the smoothing mode.")]
	[Category("Appearance")]
	[Browsable(true)]
	[DefaultValue(false)]
	public bool UseSmoothingMode
	{
		get
		{
			return bool_4;
		}
		set
		{
			if (bool_4 != value)
			{
				bool_4 = value;
				if (!bool_6)
				{
					Invalidate();
				}
			}
		}
	}

	[DefaultValue(1)]
	[Browsable(true)]
	[Category("Appearance")]
	[Description("Set the border style")]
	public int BorderWidth
	{
		get
		{
			return int_0;
		}
		set
		{
			if (int_0 != value)
			{
				if (value < 0 || value > 5)
				{
					throw new ArgumentException("This value should be between 0 and 5");
				}
				int_0 = value;
				if (!bool_6)
				{
					Invalidate();
				}
			}
		}
	}

	[Description("Set the border color")]
	[Browsable(true)]
	[DefaultValue(typeof(Color), "Gray")]
	[Category("Appearance")]
	public Color BorderColor
	{
		get
		{
			return color_0;
		}
		set
		{
			if (!(value == color_0))
			{
				color_0 = value;
				if (!bool_6)
				{
					Invalidate();
				}
			}
		}
	}

	[Description("Set the opaque value of the highlight")]
	[DefaultValue(50)]
	[Category("Appearance")]
	[Browsable(true)]
	public byte HighlightOpaque
	{
		get
		{
			return byte_0;
		}
		set
		{
			if (value <= 100)
			{
				if (byte_0 != value)
				{
					byte_0 = value;
					if (!bool_6)
					{
						Invalidate();
					}
				}
				return;
			}
			throw new ArgumentException("This value should be between 0 and 50");
		}
	}

	[DefaultValue(false)]
	[Browsable(true)]
	[Category("Appearance")]
	[Description("Set whether to show highlight area on the control")]
	public bool ShowHighlight
	{
		get
		{
			return bool_3;
		}
		set
		{
			if (bool_3 != value)
			{
				bool_3 = value;
				if (!bool_6)
				{
					Invalidate();
				}
			}
		}
	}

	[Description("Set the corner radius for the background rectangle.")]
	[DefaultValue(5)]
	[Category("Appearance")]
	[Browsable(true)]
	public int CornerRadius
	{
		get
		{
			return int_1;
		}
		set
		{
			if (value >= 1 && value <= 10)
			{
				if (int_1 != value)
				{
					int_1 = value;
					if (bool_6)
					{
						Invalidate();
					}
				}
				return;
			}
			throw new ArgumentException("This value should be between 1 and 10");
		}
	}

	[Description("Set if the background was filled in gradient colors")]
	[DefaultValue(false)]
	[Browsable(true)]
	[Category("Appearance")]
	public bool GradientBackground
	{
		get
		{
			return bool_2;
		}
		set
		{
			if (bool_2 != value)
			{
				bool_2 = value;
				if (!bool_6)
				{
					Invalidate();
				}
			}
		}
	}

	[Browsable(true)]
	[Description("Set thr first custom background color")]
	[DefaultValue(typeof(Color), "System.Drawing.Color.Black")]
	[Category("Appearance")]
	public Color BackColor_1
	{
		get
		{
			return color_2;
		}
		set
		{
			color_2 = value;
			if (!bool_6)
			{
				Invalidate();
			}
		}
	}

	[DefaultValue(typeof(Color), "System.Drawing.Color.DimGray")]
	[Description("Set thr second custom background color")]
	[Browsable(true)]
	[Category("Appearance")]
	public Color BackColor_2
	{
		get
		{
			return color_3;
		}
		set
		{
			color_3 = value;
			if (!bool_6)
			{
				Invalidate();
			}
		}
	}

	[DefaultValue(false)]
	[Browsable(true)]
	[Category("Appearance")]
	[Description("Set the background bound style")]
	public bool RoundCorner
	{
		get
		{
			return bool_1;
		}
		set
		{
			if (bool_1 != value)
			{
				bool_1 = value;
				if (!bool_6)
				{
					Invalidate();
				}
			}
		}
	}

	[Category("Behavior")]
	[Browsable(true)]
	[DefaultValue(40)]
	[Description("Set segment interval ratio")]
	public int SegmentIntervalRatio
	{
		get
		{
			return (int)(((double)float_2 - 0.00999999977648258) * 1000.0);
		}
		set
		{
			if (value >= 0 && value <= 100)
			{
				float_2 = (float)(0.00999999977648258 + (double)value * 0.001);
				if (!bool_6)
				{
					bool_0 = false;
					Invalidate();
				}
				return;
			}
			throw new ArgumentException("This value should be between 0 and 100");
		}
	}

	[Browsable(true)]
	[DefaultValue(typeof(Alignment), "Left")]
	[Category("Appearance")]
	[Description("Set the alignment of the text")]
	public Alignment TextAlignment
	{
		get
		{
			return alignment_0;
		}
		set
		{
			alignment_0 = value;
			if (!bool_6)
			{
				Invalidate();
			}
		}
	}

	[Browsable(true)]
	[Category("Behavior")]
	[Description("Set the segment width ratio")]
	[DefaultValue(50)]
	public int SegmentWidthRatio
	{
		get
		{
			return (int)(((double)float_1 - 0.100000001490116) * 500.0);
		}
		set
		{
			if (value >= 0 && value <= 100)
			{
				float_1 = (float)(0.100000001490116 + (double)value * 0.002);
				if (!bool_6)
				{
					bool_0 = false;
					Invalidate();
				}
				return;
			}
			throw new ArgumentException("This value should be between 0 and 100");
		}
	}

	[Description("Set the total number of characters to display")]
	[DefaultValue(5)]
	[Category("Behavior")]
	[Browsable(true)]
	public int TotalCharCount
	{
		get
		{
			return int_2;
		}
		set
		{
			if (value >= 2)
			{
				int_2 = value;
				if (!bool_6)
				{
					Invalidate();
				}
				return;
			}
			throw new ArgumentException("This value should be greater than 2.");
		}
	}

	[Browsable(true)]
	[DefaultValue(0.25)]
	[Category("Behavior")]
	[Description("Set the bevel rate of each segment")]
	public float BevelRate
	{
		get
		{
			return float_0 * 2f;
		}
		set
		{
			if ((double)value >= 0.0 && !((double)value > 1.0))
			{
				float_0 = value / 2f;
				if (!bool_6)
				{
					bool_0 = false;
					Invalidate();
				}
				return;
			}
			throw new ArgumentException("This value should be between 0.0 and 1");
		}
	}

	[DefaultValue(typeof(Color), "System.Color.DimGray")]
	[Description("Set the color of background characters")]
	[Browsable(true)]
	[Category("Appearance")]
	public Color FadedColor
	{
		get
		{
			return color_1;
		}
		set
		{
			if (!(color_1 == value))
			{
				color_1 = value;
				if (!bool_6)
				{
					Invalidate();
				}
			}
		}
	}

	[Description("Set text of the control")]
	[Category("Appearance")]
	[DefaultValue("LED")]
	[Browsable(true)]
	public override string Text
	{
		get
		{
			return base.Text;
		}
		set
		{
			base.Text = value.ToUpper();
			if (!bool_6)
			{
				Invalidate();
			}
		}
	}

	[Browsable(false)]
	public override Image BackgroundImage
	{
		get
		{
			return base.BackgroundImage;
		}
		set
		{
			base.BackgroundImage = null;
		}
	}

	[Browsable(false)]
	public override ImageLayout BackgroundImageLayout
	{
		get
		{
			return base.BackgroundImageLayout;
		}
		set
		{
		}
	}

	[Browsable(false)]
	public override Font Font
	{
		get
		{
			return base.Font;
		}
		set
		{
		}
	}

	public buLedControl()
	{
		SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
		SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
		ForeColor = Color.LightGreen;
		BackColor = Color.Transparent;
	}

	protected override void Dispose(bool disposing)
	{
		Class76.smethod_471(this);
		base.Dispose(disposing);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		Graphics graphics = e.Graphics;
		float num = 0f;
		float num2 = 0f;
		if (base.ClientRectangle.Height >= 20 && base.ClientRectangle.Width >= 20)
		{
			Class76.smethod_806(this, graphics);
			Class76.smethod_766(out num, out num2, this);
			Class76.smethod_450(graphics, this, num, num2);
			Class76.smethod_380(this, graphics);
		}
	}

	protected override void OnPaintBackground(PaintEventArgs pevent)
	{
		base.OnPaintBackground(pevent);
	}

	protected override void OnSizeChanged(EventArgs e)
	{
		bool_0 = false;
		base.OnSizeChanged(e);
	}

	void ISupportInitialize.BeginInit()
	{
		bool_6 = true;
	}

	void ISupportInitialize.EndInit()
	{
		bool_6 = false;
		Invalidate();
	}
}
