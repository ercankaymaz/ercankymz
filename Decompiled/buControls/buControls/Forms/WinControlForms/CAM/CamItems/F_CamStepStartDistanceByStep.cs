using System.ComponentModel;
using System.Windows.Forms;
using ns27;

namespace buControls.Forms.WinControlForms.CAM.CamItems;

public class F_CamStepStartDistanceByStep : Form
{
	internal IContainer icontainer_0 = null;

	internal Panel panel_0;

	internal Label label_0;

	internal ImageList imageList_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_0;

	internal Label label_2;

	internal Label label_3;

	internal CheckBox checkBox_0;

	internal Label label_4;

	internal NumericUpDown numericUpDown_1;

	internal Panel panel_1;

	internal Label label_5;

	internal CheckBox checkBox_1;

	internal Label label_6;

	internal Label label_7;

	internal NumericUpDown numericUpDown_2;

	internal Label label_8;

	internal Label label_9;

	internal NumericUpDown numericUpDown_3;

	internal Label label_10;

	internal Label label_11;

	internal Panel panel_2;

	internal Panel panel_3;

	public F_CamStepStartDistanceByStep()
	{
		Class76.smethod_670(this);
	}

	public F_CamStepStartDistanceByStep(bool ShowExplanation, int DecimalCount)
	{
		Class76.smethod_670(this);
		label_2.Visible = ShowExplanation;
		label_8.Visible = ShowExplanation;
		label_5.Visible = ShowExplanation;
		label_10.Visible = ShowExplanation;
		if (DecimalCount >= 0 && DecimalCount <= 5)
		{
			numericUpDown_0.DecimalPlaces = DecimalCount;
			numericUpDown_2.DecimalPlaces = DecimalCount;
			numericUpDown_1.DecimalPlaces = DecimalCount;
			numericUpDown_3.DecimalPlaces = DecimalCount;
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
