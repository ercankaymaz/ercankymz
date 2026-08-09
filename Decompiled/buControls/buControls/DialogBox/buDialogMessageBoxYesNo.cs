using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buControls.Controls;
using buCore;
using ns27;

namespace buControls.DialogBox;

public class buDialogMessageBoxYesNo : Form
{
	public string Caption = "MessageBox";

	public string Message = "";

	public int FormWidth = 0;

	public int FormHeight = 0;

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

	internal buLabel buLabel_0;

	public buDialogMessageBoxYesNo()
	{
		Class76.smethod_767(this);
	}

	public void Init()
	{
		buGround_0.Text = Caption;
		buLabel_0.Text = Message;
		SetColors();
	}

	public void Init(string Info, string Message)
	{
		buGround_0.Text = Info;
		buLabel_0.Text = Message;
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
		buLabel_0.Display.BackColor = ColorMessage;
		buGround_0.Display.LineerGradient.FirstColor = ColorBaseFirst;
		buGround_0.Display.LineerGradient.SecondColor = ColorBaseSecond;
		buGround_0.DisplayTop.BackColor = ColorHeader;
	}

	internal void method_0(object sender, EventArgs e)
	{
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
