using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.ClassForm;

public class F_Pnt3D : Form
{
	public Pnt3D Value = new Pnt3D();

	public bool Mode2D = false;

	public bool IntergerMode = false;

	public DialogResult Result = DialogResult.None;

	public static List<string> Captions = new List<string>();

	private IContainer icontainer_0 = null;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	public Button btn_cancel;

	public Button btn_ok;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	internal Label label_2;

	internal NumericUpDown numericUpDown_2;

	public F_Pnt3D()
	{
		Class76.smethod_719(this);
	}

	public void Init()
	{
		Result = DialogResult.None;
		numericUpDown_0.Value = (decimal)Value.X;
		numericUpDown_1.Value = (decimal)Value.Y;
		numericUpDown_2.Value = (decimal)Value.Z;
		if (!Mode2D)
		{
			numericUpDown_2.Visible = true;
			label_2.Visible = true;
		}
		else
		{
			numericUpDown_2.Visible = false;
			label_2.Visible = false;
		}
		if (!IntergerMode)
		{
			numericUpDown_0.DecimalPlaces = 3;
			numericUpDown_1.DecimalPlaces = 3;
			numericUpDown_2.DecimalPlaces = 3;
		}
		else
		{
			numericUpDown_0.DecimalPlaces = 0;
			numericUpDown_1.DecimalPlaces = 0;
			numericUpDown_2.DecimalPlaces = 0;
		}
		Class76.smethod_456(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
		Value.X = (double)numericUpDown_0.Value;
		Value.Y = (double)numericUpDown_1.Value;
		Value.Z = (double)numericUpDown_2.Value;
		Result = DialogResult.OK;
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
