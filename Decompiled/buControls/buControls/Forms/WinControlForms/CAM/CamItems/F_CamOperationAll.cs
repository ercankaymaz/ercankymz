using System.ComponentModel;
using System.Windows.Forms;
using ns27;

namespace buControls.Forms.WinControlForms.CAM.CamItems;

public class F_CamOperationAll : Form
{
	private IContainer icontainer_0 = null;

	internal Panel panel_0;

	internal Label label_0;

	internal Label label_1;

	internal Panel panel_1;

	internal Label label_2;

	internal NumericUpDown numericUpDown_0;

	internal Label label_3;

	internal Label label_4;

	internal Label label_5;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal Panel panel_2;

	internal Label label_6;

	internal Label label_7;

	internal Label label_8;

	public RadioButton radio_right;

	public RadioButton radio_left;

	public RadioButton radioButton1;

	public F_CamOperationAll()
	{
		Class76.smethod_684(this);
	}

	public F_CamOperationAll(bool ShowExplanation, int DecimalCount)
	{
		Class76.smethod_684(this);
		label_3.Visible = ShowExplanation;
		label_1.Visible = ShowExplanation;
		if (DecimalCount >= 0 && DecimalCount <= 5)
		{
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
