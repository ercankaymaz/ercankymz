using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buControls.Controls;
using buCore;
using ns27;

namespace buControls.DialogBox;

public class buDialogInputbox : Form
{
	public string Caption = "MessageBox";

	public double Value = 0.0;

	public int FormWidth = 0;

	public int FormHeight = 0;

	public int DecimalPoint = 2;

	public Color ColorHeader = Color.LightBlue;

	public Color ColorBaseFirst = Color.Black;

	public Color ColorBaseSecond = Color.DarkGray;

	public Color ColorMessage = Color.Silver;

	public Color ColorBottomYes = Color.LightGray;

	public Color ColorBottomNo = Color.LightGray;

	public DialogResult Result = DialogResult.None;

	internal IContainer icontainer_0 = null;

	internal buGround buGround_0;

	public buButton btn_close;

	internal buButton buButton_0;

	internal buButton buButton_1;

	internal ImageList imageList_0;

	internal buSpin buSpin_0;

	public buDialogInputbox()
	{
		Class76.smethod_173(this);
	}

	public void Init()
	{
		buGround_0.Text = Caption;
		buSpin_0.Caption.Caption = Caption;
		if (DecimalPoint >= 0)
		{
			buSpin_0.DecimalPoint = DecimalPoint;
		}
		buSpin_0.Value = Value;
		SetColors();
	}

	public void Init(string caption, double value)
	{
		Caption = caption;
		buGround_0.Text = Caption;
		buSpin_0.Caption.Caption = Caption;
		Value = value;
		if (DecimalPoint >= 0)
		{
			buSpin_0.DecimalPoint = DecimalPoint;
		}
		buSpin_0.Value = value;
		SetColors();
	}

	public void Init(string caption, string varname, double value)
	{
		Caption = caption;
		buGround_0.Text = Caption;
		buSpin_0.Caption.Caption = varname;
		Value = value;
		if (DecimalPoint >= 0)
		{
			buSpin_0.DecimalPoint = DecimalPoint;
		}
		buSpin_0.Value = value;
		SetColors();
	}

	public void SetColors()
	{
		if (FormWidth > 10)
		{
			base.Width = FormWidth;
		}
		if (FormHeight > 10)
		{
			base.Height = FormHeight;
		}
		buButton_1.Display.BackColor = ColorBottomNo;
		buButton_1.ButtonDownDisplay.BackColor = buImage.ColorToneChange(ColorBottomNo, 0.9);
		buButton_1.ButtonOverDisplay.BackColor = buImage.ColorToneChange(ColorBottomNo, 0.8);
		buButton_0.Display.BackColor = ColorBottomNo;
		buButton_0.ButtonDownDisplay.BackColor = buImage.ColorToneChange(ColorBottomYes, 0.9);
		buButton_0.ButtonOverDisplay.BackColor = buImage.ColorToneChange(ColorBottomYes, 0.8);
		buGround_0.Display.LineerGradient.FirstColor = ColorBaseFirst;
		buGround_0.Display.LineerGradient.SecondColor = ColorBaseSecond;
		buGround_0.DisplayTop.BackColor = ColorHeader;
	}

	internal void method_0(object sender, EventArgs e)
	{
		Value = buSpin_0.Value;
		Result = DialogResult.Yes;
		Dispose();
	}

	internal void method_1(object sender, EventArgs e)
	{
		Result = DialogResult.No;
		Dispose();
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
