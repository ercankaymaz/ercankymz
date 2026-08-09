using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buControls.Controls;
using ns27;

namespace buControls.UserControls;

public class AxisCoordinates : UserControl
{
	private Color color_0 = Color.LightGray;

	private Color color_1 = Color.Black;

	private Color color_2 = Color.YellowGreen;

	private Color color_3 = Color.Black;

	private Color color_4 = Color.Black;

	private Color color_5 = Color.LimeGreen;

	private Color color_6 = Color.Red;

	private Color color_7 = Color.Black;

	private bool bool_0 = false;

	private bool bool_1 = false;

	private bool bool_2 = false;

	private int int_0 = 8;

	private string string_0 = "0.00";

	private string string_1 = "0.00";

	private string string_2 = "X";

	private int int_1 = 0;

	private int int_2 = 30;

	private IContainer icontainer_0 = null;

	public buLedControl coord_x;

	public buLabel lbl_x;

	public buCheckBox chk_xenable;

	public buCheckBox chk_xhome;

	public buLedControl coord_offsetx;

	[Description("Axis Caption")]
	[Browsable(true)]
	[DefaultValue("X")]
	[Category("Appearance")]
	public string AxisCaption
	{
		get
		{
			return string_2;
		}
		set
		{
			if (!(value == string_2))
			{
				string_2 = value;
				lbl_x.Text = value;
				Invalidate();
			}
		}
	}

	[Description("Axis Width")]
	[Browsable(true)]
	[DefaultValue(30)]
	[Category("Appearance")]
	public int AxisCaptionWidth
	{
		get
		{
			return int_2;
		}
		set
		{
			if (value != int_2)
			{
				int_2 = value;
				lbl_x.Width = value;
				method_0(null, null);
				Invalidate();
			}
		}
	}

	[Description("Axis Index")]
	[Browsable(true)]
	[DefaultValue(0)]
	[Category("Appearance")]
	public int AxisIndex
	{
		get
		{
			return int_1;
		}
		set
		{
			if (value != int_1)
			{
				int_1 = value;
				Invalidate();
			}
		}
	}

	[Description("Axis Value")]
	[Browsable(true)]
	[DefaultValue("0.00")]
	[Category("Appearance")]
	public string AxisValue
	{
		get
		{
			return string_0;
		}
		set
		{
			if (!(value == string_0))
			{
				string_0 = value;
				coord_x.Text = value;
				Invalidate();
			}
		}
	}

	[Description("Axis Offseted Value")]
	[Browsable(true)]
	[DefaultValue("0.00")]
	[Category("Appearance")]
	public string AxisOffsetedValue
	{
		get
		{
			return string_1;
		}
		set
		{
			if (!(value == string_1))
			{
				string_1 = value;
				coord_offsetx.Text = value;
				Invalidate();
			}
		}
	}

	[Description("Axis Value")]
	[Browsable(true)]
	[DefaultValue(8)]
	[Category("Appearance")]
	public int AxisDecimalCount
	{
		get
		{
			return int_0;
		}
		set
		{
			if (value != int_0)
			{
				int_0 = value;
				coord_x.TotalCharCount = value;
				Invalidate();
			}
		}
	}

	[Description("Axis Caption BackColor")]
	[Browsable(true)]
	[DefaultValue(typeof(Color), "LightGray")]
	[Category("Appearance")]
	public Color AxisCaptionBackColor
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
				lbl_x.Display.BackColor = value;
				Invalidate();
			}
		}
	}

	[Description("Axis Caption ForeColor")]
	[Browsable(true)]
	[DefaultValue(typeof(Color), "Black")]
	[Category("Appearance")]
	public Color AxisCaptionForeColor
	{
		get
		{
			return color_1;
		}
		set
		{
			if (!(value == color_1))
			{
				color_1 = value;
				lbl_x.Display.Fonts.ForeColor = value;
				Invalidate();
			}
		}
	}

	[Description("Axis ForeColor")]
	[Browsable(true)]
	[DefaultValue(typeof(Color), "YellowGreen")]
	[Category("Appearance")]
	public Color AxisForeColor
	{
		get
		{
			return color_2;
		}
		set
		{
			if (!(value == color_2))
			{
				color_2 = value;
				coord_x.ForeColor = value;
				Invalidate();
			}
		}
	}

	[Description("Axis BackColor")]
	[Browsable(true)]
	[DefaultValue(typeof(Color), "Black")]
	[Category("Appearance")]
	public Color AxisBackColor
	{
		get
		{
			return color_3;
		}
		set
		{
			if (!(value == color_3))
			{
				color_3 = value;
				coord_x.BackColor_1 = value;
				Invalidate();
			}
		}
	}

	[Description("Axis FadeColor")]
	[Browsable(true)]
	[DefaultValue(typeof(Color), "Black")]
	[Category("Appearance")]
	public Color AxisFadeColor
	{
		get
		{
			return color_4;
		}
		set
		{
			if (!(value == color_4))
			{
				color_4 = value;
				coord_x.FadedColor = value;
				Invalidate();
			}
		}
	}

	[Description("Axis Status ActiveColor")]
	[Browsable(true)]
	[DefaultValue(typeof(Color), "LimeGreen")]
	[Category("Appearance")]
	public Color AxisStatusActiveColor
	{
		get
		{
			return color_5;
		}
		set
		{
			if (!(value == color_5))
			{
				color_5 = value;
				Invalidate();
			}
		}
	}

	[Description("Axis Status PassiveColor")]
	[Browsable(true)]
	[DefaultValue(typeof(Color), "Red")]
	[Category("Appearance")]
	public Color AxisStatusPassiveColor
	{
		get
		{
			return color_6;
		}
		set
		{
			if (!(value == color_6))
			{
				color_6 = value;
				Invalidate();
			}
		}
	}

	[Description("Axis Status PassiveColor")]
	[Browsable(true)]
	[DefaultValue(typeof(Color), "Red")]
	[Category("Appearance")]
	public Color AxisStatusForeColor
	{
		get
		{
			return color_7;
		}
		set
		{
			if (!(value == color_7))
			{
				color_7 = value;
				chk_xenable.Display.Fonts.ForeColor = value;
				chk_xhome.Display.Fonts.ForeColor = value;
				Invalidate();
			}
		}
	}

	[Description("Axis Offset Position Show")]
	[Browsable(true)]
	[DefaultValue(false)]
	[Category("Appearance")]
	public bool AxisOffsetPositionShow
	{
		get
		{
			return bool_2;
		}
		set
		{
			if (value != bool_2)
			{
				bool_2 = value;
				coord_offsetx.Visible = value;
				method_0(null, null);
				Invalidate();
			}
		}
	}

	[Description("Axis Enable")]
	[Browsable(true)]
	[DefaultValue(false)]
	[Category("Appearance")]
	public bool AxisEnable
	{
		get
		{
			return bool_0;
		}
		set
		{
			if (value != bool_0)
			{
				bool_0 = value;
				chk_xenable.Check = value;
				if (!chk_xenable.Check)
				{
					chk_xenable.Display.BackColor = color_6;
					chk_xenable.CheckTick.ColorModeDisplay.BackColor = color_6;
				}
				else
				{
					chk_xenable.Display.BackColor = color_5;
					chk_xenable.CheckTick.ColorModeDisplay.BackColor = color_5;
				}
				Invalidate();
			}
		}
	}

	[Description("Axis Home")]
	[Browsable(true)]
	[DefaultValue(false)]
	[Category("Appearance")]
	public bool AxisHome
	{
		get
		{
			return bool_1;
		}
		set
		{
			if (value != bool_1)
			{
				bool_1 = value;
				chk_xhome.Check = value;
				if (!chk_xhome.Check)
				{
					chk_xhome.Display.BackColor = color_6;
					chk_xhome.CheckTick.ColorModeDisplay.BackColor = color_6;
				}
				else
				{
					chk_xhome.Display.BackColor = color_5;
					chk_xhome.CheckTick.ColorModeDisplay.BackColor = color_5;
				}
				Invalidate();
			}
		}
	}

	public AxisCoordinates()
	{
		Class76.smethod_784(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
		chk_xenable.Height = Convert.ToInt32(base.Height / 2);
		chk_xhome.Top = chk_xenable.Top + chk_xenable.Height;
		chk_xhome.Height = Convert.ToInt32(base.Height / 2);
		float num = base.Width - lbl_x.Width - chk_xenable.Width - 2;
		if (bool_2)
		{
			coord_x.Left = lbl_x.Width + 2;
			coord_x.Width = Convert.ToInt32(num / 2f) - 1;
			coord_offsetx.Left = coord_x.Left + coord_x.Width + 2;
			coord_offsetx.Width = Convert.ToInt32(num / 2f) - 2;
		}
		else
		{
			coord_x.Left = lbl_x.Width + 2;
			coord_x.Width = Convert.ToInt32(num);
		}
	}

	internal void method_1(object sender, EventArgs e)
	{
		OnDoubleClick(e);
	}

	internal void method_2(object sender, EventArgs e)
	{
		OnClick(e);
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
