using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns27;

namespace buControls.UserControls;

public class buContentAlignment : UserControl
{
	private Color color_0 = Color.LightGray;

	private Color color_1 = Color.Gray;

	private ContentAlignment contentAlignment_0 = ContentAlignment.MiddleCenter;

	private IContainer icontainer_0 = null;

	internal Button button_0;

	internal Button button_1;

	internal Button button_2;

	internal Button button_3;

	internal Button button_4;

	internal Button button_5;

	internal Button button_6;

	internal Button button_7;

	internal Button button_8;

	[Description("BackColor")]
	[Browsable(true)]
	[DefaultValue(typeof(Color), "LightGray")]
	[Category("Appearance")]
	public Color ActiveColor
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
				button_2.BackColor = color_0;
				button_1.BackColor = color_0;
				button_0.BackColor = color_0;
				button_6.BackColor = color_0;
				button_7.BackColor = color_0;
				button_8.BackColor = color_0;
				button_3.BackColor = color_0;
				button_4.BackColor = color_0;
				button_5.BackColor = color_0;
				Invalidate();
			}
		}
	}

	[Description("Selected Color")]
	[Browsable(true)]
	[DefaultValue(typeof(Color), "Gray")]
	[Category("Appearance")]
	public Color SelectedColor
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
				Invalidate();
			}
		}
	}

	[Description("Content Alignment")]
	[Browsable(true)]
	[DefaultValue(typeof(ContentAlignment), "MiddleCenter")]
	[Category("Appearance")]
	public ContentAlignment Alignment
	{
		get
		{
			return contentAlignment_0;
		}
		set
		{
			contentAlignment_0 = value;
			button_2.BackColor = color_0;
			button_1.BackColor = color_0;
			button_0.BackColor = color_0;
			button_6.BackColor = color_0;
			button_7.BackColor = color_0;
			button_8.BackColor = color_0;
			button_3.BackColor = color_0;
			button_4.BackColor = color_0;
			button_5.BackColor = color_0;
			if (contentAlignment_0 == ContentAlignment.BottomLeft)
			{
				button_2.BackColor = SelectedColor;
			}
			if (contentAlignment_0 == ContentAlignment.BottomRight)
			{
				button_6.BackColor = SelectedColor;
			}
			if (contentAlignment_0 == ContentAlignment.BottomCenter)
			{
				button_3.BackColor = SelectedColor;
			}
			if (contentAlignment_0 == ContentAlignment.TopCenter)
			{
				button_5.BackColor = SelectedColor;
			}
			if (contentAlignment_0 == ContentAlignment.TopLeft)
			{
				button_0.BackColor = SelectedColor;
			}
			if (contentAlignment_0 == ContentAlignment.TopRight)
			{
				button_8.BackColor = SelectedColor;
			}
			if (contentAlignment_0 == ContentAlignment.MiddleCenter)
			{
				button_4.BackColor = SelectedColor;
			}
			if (contentAlignment_0 == ContentAlignment.MiddleLeft)
			{
				button_1.BackColor = SelectedColor;
			}
			if (contentAlignment_0 == ContentAlignment.MiddleRight)
			{
				button_7.BackColor = SelectedColor;
			}
			Invalidate();
		}
	}

	public buContentAlignment()
	{
		Class76.smethod_208(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_3.Name)
		{
			Alignment = ContentAlignment.BottomCenter;
		}
		if (control.Name == button_2.Name)
		{
			Alignment = ContentAlignment.BottomLeft;
		}
		if (control.Name == button_6.Name)
		{
			Alignment = ContentAlignment.BottomRight;
		}
		if (control.Name == button_5.Name)
		{
			Alignment = ContentAlignment.TopCenter;
		}
		if (control.Name == button_0.Name)
		{
			Alignment = ContentAlignment.TopLeft;
		}
		if (control.Name == button_8.Name)
		{
			Alignment = ContentAlignment.TopRight;
		}
		if (control.Name == button_4.Name)
		{
			Alignment = ContentAlignment.MiddleCenter;
		}
		if (control.Name == button_1.Name)
		{
			Alignment = ContentAlignment.MiddleLeft;
		}
		if (control.Name == button_7.Name)
		{
			Alignment = ContentAlignment.MiddleRight;
		}
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
