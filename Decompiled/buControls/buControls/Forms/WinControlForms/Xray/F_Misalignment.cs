using System;
using System.ComponentModel;
using System.Windows.Forms;
using ns27;

namespace buControls.Forms.WinControlForms.Xray;

public class F_Misalignment : Form
{
	private IContainer icontainer_0 = null;

	internal Label label_0;

	internal Label label_1;

	internal Label label_2;

	internal Label label_3;

	internal Label label_4;

	internal Label label_5;

	internal Label label_6;

	internal Label label_7;

	internal Button button_0;

	public TextBox txt_cAxisdx;

	public TextBox txt_cAxisdy;

	public TextBox txt_cAxisdz;

	public TextBox txt_aAxisdz;

	public TextBox txt_aAxisdy;

	public TextBox txt_aAxisdx;

	public TextBox txt_aAxisangle;

	public TextBox txt_cAxisangle;

	public F_Misalignment()
	{
		Class76.smethod_175(this);
	}

	internal void method_0(object sender, EventArgs e)
	{
		Close();
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
