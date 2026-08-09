using System.ComponentModel;
using System.Windows.Forms;
using ns27;

namespace buControls.Forms.WinControlForms.CAM.CamItems;

public class F_CamStepStartDistanceByCount : Form
{
	internal IContainer icontainer_0 = null;

	internal Panel panel_0;

	internal Label label_0;

	internal ImageList imageList_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_0;

	internal Label label_2;

	internal NumericUpDown numericUpDown_1;

	internal Label label_3;

	internal Label label_4;

	internal Panel panel_1;

	internal Label label_5;

	internal Label label_6;

	internal NumericUpDown numericUpDown_2;

	internal Label label_7;

	internal CheckBox checkBox_0;

	internal Label label_8;

	internal Panel panel_2;

	internal Label label_9;

	internal CheckBox checkBox_1;

	internal Label label_10;

	internal NumericUpDown numericUpDown_3;

	internal Label label_11;

	internal Panel panel_3;

	public F_CamStepStartDistanceByCount()
	{
		Class76.smethod_273(this);
		numericUpDown_1.DecimalPlaces = 0;
	}

	public F_CamStepStartDistanceByCount(bool ShowExplanation, int DecimalCount)
	{
		Class76.smethod_273(this);
		label_3.Visible = ShowExplanation;
		label_7.Visible = ShowExplanation;
		label_11.Visible = ShowExplanation;
		label_2.Visible = ShowExplanation;
		if (DecimalCount >= 0 && DecimalCount <= 5)
		{
			numericUpDown_1.DecimalPlaces = 0;
			numericUpDown_2.DecimalPlaces = DecimalCount;
			numericUpDown_3.DecimalPlaces = DecimalCount;
			numericUpDown_0.DecimalPlaces = DecimalCount;
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
