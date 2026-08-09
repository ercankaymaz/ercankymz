using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using buControls.ColorPicker;
using ns27;

namespace buControls.Forms.WinControlForms.ClassForm;

public class F_SolidItemDisplay : Form
{
	public static List<string> Captions = new List<string>();

	public SolidItemDisplay Value = new SolidItemDisplay();

	public DialogResult Result = DialogResult.None;

	private IContainer icontainer_0 = null;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	internal Label label_2;

	internal buColorComboBox buColorComboBox_0;

	internal Label label_3;

	internal buColorComboBox buColorComboBox_1;

	public Button btn_cancel;

	public Button btn_ok;

	public F_SolidItemDisplay()
	{
		Class76.smethod_353(this);
	}

	public void Init()
	{
		buColorComboBox_1.Color = Value.BorderColor;
		buColorComboBox_0.Color = Value.SkinColor;
		numericUpDown_1.Value = Value.SkinTransperancy;
		numericUpDown_0.Value = Value.BorderTransperancy;
		Class76.smethod_610(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
		Value.SkinColor = buColorComboBox_0.Color;
		Value.BorderColor = buColorComboBox_1.Color;
		Value.SkinTransperancy = (int)numericUpDown_1.Value;
		Value.BorderTransperancy = (int)numericUpDown_1.Value;
		Result = DialogResult.OK;
		Dispose();
	}

	internal void method_1(object sender, EventArgs e)
	{
		Result = DialogResult.Cancel;
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
