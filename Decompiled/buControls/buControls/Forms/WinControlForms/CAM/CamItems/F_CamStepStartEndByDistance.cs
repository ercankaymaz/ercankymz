using System.ComponentModel;
using System.Windows.Forms;
using ns27;

namespace buControls.Forms.WinControlForms.CAM.CamItems;

public class F_CamStepStartEndByDistance : Form
{
	internal IContainer icontainer_0 = null;

	internal Panel panel_0;

	internal Label label_0;

	internal NumericUpDown numericUpDown_0;

	internal Label label_1;

	internal Panel panel_1;

	internal Label label_2;

	internal NumericUpDown numericUpDown_1;

	internal Label label_3;

	internal CheckBox checkBox_0;

	internal Panel panel_2;

	internal Label label_4;

	internal NumericUpDown numericUpDown_2;

	internal Label label_5;

	internal Panel panel_3;

	internal CheckBox checkBox_1;

	internal Label label_6;

	internal NumericUpDown numericUpDown_3;

	internal Label label_7;

	internal Label label_8;

	internal ImageList imageList_0;

	internal Label label_9;

	internal Label label_10;

	internal Label label_11;

	public F_CamStepStartEndByDistance()
	{
		Class76.smethod_427(this);
	}

	public F_CamStepStartEndByDistance(bool ShowExplanation, int DecimalCount)
	{
		Class76.smethod_427(this);
		label_1.Visible = ShowExplanation;
		label_3.Visible = ShowExplanation;
		label_7.Visible = ShowExplanation;
		label_5.Visible = ShowExplanation;
		if (DecimalCount >= 0 && DecimalCount <= 5)
		{
			numericUpDown_1.DecimalPlaces = DecimalCount;
			numericUpDown_0.DecimalPlaces = DecimalCount;
			numericUpDown_3.DecimalPlaces = DecimalCount;
			numericUpDown_2.DecimalPlaces = DecimalCount;
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
