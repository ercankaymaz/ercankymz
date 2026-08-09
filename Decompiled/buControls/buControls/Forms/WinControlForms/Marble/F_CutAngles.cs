using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ns27;

namespace buControls.Forms.WinControlForms.Marble;

public class F_CutAngles : Form
{
	public DialogResult Result = DialogResult.None;

	public double Value = 0.0;

	public static List<string> Captions = new List<string>();

	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal NumericUpDown numericUpDown_0;

	internal Label label_0;

	public Button btn_0;

	public Button btn_3;

	public Button btn_5;

	public Button btn_47;

	public Button btn_46;

	public Button btn_45;

	public Button btn_40;

	public Button btn_30;

	public Button btn_15;

	public F_CutAngles()
	{
		Class76.smethod_203(this);
	}

	public void Init(double value)
	{
		Value = value;
		numericUpDown_0.Value = (decimal)Value;
		Class76.smethod_3(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
		Value = (double)numericUpDown_0.Value;
		Result = DialogResult.OK;
		Dispose();
	}

	internal void method_1(object sender, EventArgs e)
	{
		Result = DialogResult.Cancel;
		Dispose();
	}

	internal void method_2(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_0.Name)
		{
			numericUpDown_0.Value = decimal.Parse(btn_0.Text);
		}
		if (control.Name == btn_3.Name)
		{
			numericUpDown_0.Value = decimal.Parse(btn_3.Text);
		}
		if (control.Name == btn_5.Name)
		{
			numericUpDown_0.Value = decimal.Parse(btn_5.Text);
		}
		if (control.Name == btn_15.Name)
		{
			numericUpDown_0.Value = decimal.Parse(btn_15.Text);
		}
		if (control.Name == btn_30.Name)
		{
			numericUpDown_0.Value = decimal.Parse(btn_30.Text);
		}
		if (control.Name == btn_40.Name)
		{
			numericUpDown_0.Value = decimal.Parse(btn_40.Text);
		}
		if (control.Name == btn_45.Name)
		{
			numericUpDown_0.Value = decimal.Parse(btn_45.Text);
		}
		if (control.Name == btn_46.Name)
		{
			numericUpDown_0.Value = decimal.Parse(btn_46.Text);
		}
		if (control.Name == btn_47.Name)
		{
			numericUpDown_0.Value = decimal.Parse(btn_47.Text);
		}
		method_0(btn_ok, e);
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
