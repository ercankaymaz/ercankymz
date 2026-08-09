using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buControls.ColorPicker;
using ns71;

namespace buEyeBaseVer5.Forms.ClassForm;

public class F_ColorDrawType : Form
{
	public ColorDrawType Value = new ColorDrawType();

	public static List<string> Captions = new List<string>();

	private IContainer icontainer_0 = null;

	public Button btn_cancel;

	public Button btn_ok;

	internal buColorComboBox buColorComboBox_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	public F_ColorDrawType()
	{
		Class186.smethod_49(this);
	}

	public void Init()
	{
		buColorComboBox_0.Color = Value.Color;
		numericUpDown_0.Value = Value.Transperancy;
		numericUpDown_1.Value = (decimal)Value.Thickess;
		Class186.smethod_824(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
		if (numericUpDown_0.Value > 0m)
		{
			Value.Transperancy = (int)numericUpDown_0.Value;
		}
		if (numericUpDown_1.Value > 0m)
		{
			Value.Thickess = (double)numericUpDown_1.Value;
		}
		Value.Color = buColorComboBox_0.Color;
		Dispose();
	}

	internal void method_1(object sender, EventArgs e)
	{
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
