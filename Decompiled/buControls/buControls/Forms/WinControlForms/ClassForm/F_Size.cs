using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns27;

namespace buControls.Forms.WinControlForms.ClassForm;

public class F_Size : Form
{
	public SizeF Value = default(SizeF);

	public bool IntergerMode = false;

	public static List<string> Captions = new List<string>();

	private IContainer icontainer_0 = null;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_1;

	public Button btn_cancel;

	public Button btn_ok;

	public F_Size()
	{
		Class76.smethod_737(this);
	}

	public void Init()
	{
		numericUpDown_1.Value = (decimal)Value.Width;
		numericUpDown_0.Value = (decimal)Value.Height;
		if (!IntergerMode)
		{
			numericUpDown_1.DecimalPlaces = 3;
			numericUpDown_0.DecimalPlaces = 3;
		}
		else
		{
			numericUpDown_1.DecimalPlaces = 0;
			numericUpDown_0.DecimalPlaces = 0;
		}
		Class76.smethod_403(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
		Value.Width = (float)numericUpDown_1.Value;
		Value.Height = (float)numericUpDown_0.Value;
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
