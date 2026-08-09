using System.ComponentModel;
using System.Windows.Forms;
using ns27;

namespace buControls.Forms.WinControlForms.Bending;

public class F_BendParameterCustom1 : Form
{
	private IContainer icontainer_0 = null;

	internal ListBox listBox_0;

	internal Label label_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_0;

	internal NumericUpDown numericUpDown_1;

	internal Label label_2;

	internal Label label_3;

	internal Label label_4;

	internal NumericUpDown numericUpDown_2;

	internal NumericUpDown numericUpDown_3;

	internal Label label_5;

	internal NumericUpDown numericUpDown_4;

	internal NumericUpDown numericUpDown_5;

	internal Label label_6;

	internal Label label_7;

	internal Label label_8;

	public F_BendParameterCustom1()
	{
		Class76.smethod_597(this);
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
