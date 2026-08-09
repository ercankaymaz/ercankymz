using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.UserControls;
using ns27;

namespace buControls.Forms.WinControlForms.Drawings;

public class F_CustomText : Form
{
	public static List<string> Captions = new List<string>();

	public TextCustomData TextData = new TextCustomData();

	public DialogResult Result = DialogResult.None;

	public bool ShowFont = false;

	private IContainer icontainer_0 = null;

	public Button btn_cancel;

	public Button btn_ok;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_1;

	internal TextBox textBox_0;

	internal buContentAlignment buContentAlignment_0;

	internal Label label_2;

	internal Label label_3;

	public Button btn_font;

	internal Label label_4;

	internal NumericUpDown numericUpDown_1;

	internal Label label_5;

	internal NumericUpDown numericUpDown_2;

	public F_CustomText()
	{
		Class76.smethod_812(this);
	}

	public void Init()
	{
		TextData.FontName = "";
		textBox_0.Text = TextData.Text;
		numericUpDown_0.Value = (decimal)TextData.Height;
		numericUpDown_1.Value = (decimal)TextData.CharSpace;
		numericUpDown_2.Value = (decimal)TextData.SpaceValue;
		btn_font.Text = TextData.FontName;
		btn_font.Visible = ShowFont;
		label_3.Visible = ShowFont;
		buContentAlignment_0.Alignment = TextData.Alignment;
		Class76.smethod_316(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
		{
			TextData.Text = textBox_0.Text;
			TextData.Height = (double)numericUpDown_0.Value;
			TextData.SpaceValue = (double)numericUpDown_2.Value;
			TextData.CharSpace = (double)numericUpDown_1.Value;
			TextData.Alignment = buContentAlignment_0.Alignment;
			Result = DialogResult.OK;
			Dispose();
		}
		if (control.Name == btn_cancel.Name)
		{
			Result = DialogResult.Cancel;
			Dispose();
		}
		if (!(control.Name == btn_font.Name))
		{
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
