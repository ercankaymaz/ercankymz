using System.ComponentModel;
using System.Windows.Forms;
using ns27;

namespace buControls.Forms.WinControlForms.CAM.CamItems;

public class F_CamStepStartEndByCount : Form
{
	internal IContainer icontainer_0 = null;

	internal Label label_0;

	internal ImageList imageList_0;

	internal Label label_1;

	internal Label label_2;

	internal CheckBox checkBox_0;

	internal Label label_3;

	internal NumericUpDown numericUpDown_0;

	internal Label label_4;

	internal Panel panel_0;

	internal Label label_5;

	internal Label label_6;

	internal NumericUpDown numericUpDown_1;

	internal Label label_7;

	internal CheckBox checkBox_1;

	internal Label label_8;

	internal NumericUpDown numericUpDown_2;

	internal Label label_9;

	internal Panel panel_1;

	internal Label label_10;

	internal NumericUpDown numericUpDown_3;

	internal Label label_11;

	internal Panel panel_2;

	internal Panel panel_3;

	public F_CamStepStartEndByCount()
	{
		Class76.smethod_277(this);
		numericUpDown_3.DecimalPlaces = 0;
	}

	public F_CamStepStartEndByCount(bool ShowExplanation, int DecimalCount)
	{
		Class76.smethod_277(this);
		label_11.Visible = ShowExplanation;
		label_9.Visible = ShowExplanation;
		label_4.Visible = ShowExplanation;
		label_7.Visible = ShowExplanation;
		if (DecimalCount >= 0 && DecimalCount <= 5)
		{
			numericUpDown_2.DecimalPlaces = DecimalCount;
			numericUpDown_3.DecimalPlaces = 0;
			numericUpDown_0.DecimalPlaces = DecimalCount;
			numericUpDown_1.DecimalPlaces = DecimalCount;
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
