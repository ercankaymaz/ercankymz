using System;
using System.ComponentModel;
using System.Windows.Forms;
using ns27;

namespace buControls.Forms.WinControlForms.CAM.CamItems;

public class F_CamDistanceAll : Form
{
	internal IContainer icontainer_0 = null;

	internal Panel panel_0;

	internal CheckBox checkBox_0;

	internal Label label_0;

	internal Label label_1;

	internal Panel panel_1;

	internal Label label_2;

	internal NumericUpDown numericUpDown_0;

	internal Label label_3;

	internal Panel panel_2;

	internal Label label_4;

	internal NumericUpDown numericUpDown_1;

	internal Label label_5;

	internal Panel panel_3;

	internal Label label_6;

	internal NumericUpDown numericUpDown_2;

	internal Label label_7;

	internal Label label_8;

	internal ImageList imageList_0;

	internal Label label_9;

	internal Label label_10;

	internal Label label_11;

	internal Panel panel_4;

	internal Label label_12;

	internal Label label_13;

	internal NumericUpDown numericUpDown_3;

	internal Label label_14;

	public F_CamDistanceAll()
	{
		Class76.smethod_453(this);
	}

	public F_CamDistanceAll(bool ShowExplanation, int DecimalCount)
	{
		Class76.smethod_453(this);
		label_5.Visible = ShowExplanation;
		label_7.Visible = ShowExplanation;
		label_1.Visible = ShowExplanation;
		label_3.Visible = ShowExplanation;
		if (DecimalCount >= 0 && DecimalCount <= 5)
		{
			numericUpDown_1.DecimalPlaces = DecimalCount;
			numericUpDown_2.DecimalPlaces = DecimalCount;
			numericUpDown_0.DecimalPlaces = DecimalCount;
		}
	}

	internal void method_0(object sender, EventArgs e)
	{
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
