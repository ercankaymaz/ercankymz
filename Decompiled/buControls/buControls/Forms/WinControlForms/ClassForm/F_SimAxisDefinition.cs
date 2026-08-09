using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.ClassForm;

public class F_SimAxisDefinition : Form
{
	public SimulationMoveVar Value = new SimulationMoveVar();

	public DialogResult Result = DialogResult.None;

	public static List<string> Captions = new List<string>();

	private IContainer icontainer_0 = null;

	internal CheckBox checkBox_0;

	internal NumericUpDown numericUpDown_0;

	internal NumericUpDown numericUpDown_1;

	internal NumericUpDown numericUpDown_2;

	internal CheckBox checkBox_1;

	internal CheckBox checkBox_2;

	internal CheckBox checkBox_3;

	internal CheckBox checkBox_4;

	internal CheckBox checkBox_5;

	internal Label label_0;

	internal Label label_1;

	internal Label label_2;

	public Button btn_cancel;

	public Button btn_ok;

	public F_SimAxisDefinition()
	{
		Class76.smethod_253(this);
	}

	public void Init()
	{
		numericUpDown_0.Value = (decimal)Value.RotationPoint.X;
		numericUpDown_1.Value = (decimal)Value.RotationPoint.Y;
		numericUpDown_2.Value = (decimal)Value.RotationPoint.Z;
		checkBox_0.Checked = Value.Axes.X;
		checkBox_1.Checked = Value.Axes.Y;
		checkBox_2.Checked = Value.Axes.Z;
		checkBox_3.Checked = Value.Axes.A;
		checkBox_4.Checked = Value.Axes.B;
		checkBox_5.Checked = Value.Axes.C;
		Class76.smethod_511(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
		Value.RotationPoint.X = (double)numericUpDown_0.Value;
		Value.RotationPoint.Y = (double)numericUpDown_1.Value;
		Value.RotationPoint.Z = (double)numericUpDown_2.Value;
		Value.Axes.X = checkBox_0.Checked;
		Value.Axes.Y = checkBox_1.Checked;
		Value.Axes.Z = checkBox_2.Checked;
		Value.Axes.A = checkBox_3.Checked;
		Value.Axes.B = checkBox_4.Checked;
		Value.Axes.C = checkBox_5.Checked;
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
