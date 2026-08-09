using System;
using System.ComponentModel;
using System.Windows.Forms;
using ns27;

namespace buControls.Forms.WinControlForms.Profile.ProfileTemplate;

public class F_ProfileOperationDataTemplate : Form
{
	private IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal Panel panel_0;

	internal Label label_0;

	public NumericUpDown spn_planefreelen;

	public Button btn_planefreesettings;

	public Button btn_free;

	public Button btn_planeleft;

	public Button btn_planeright;

	internal Label label_1;

	public Button btn_planetop;

	public NumericUpDown spn_posycommon;

	public NumericUpDown spn_posxcommon;

	public NumericUpDown spn_depth;

	public Label lbl_y;

	public Label lbl_x;

	public Label label1;

	public CheckBox chk_eachlayer;

	public Button btn_editfreeplane;

	public Button btn_camsettibgs;

	public Button btn_array;

	public CheckBox chk_Extradepth;

	public NumericUpDown spn_extradepth;

	public CheckBox chk_incrementalmode;

	internal PictureBox pictureBox_0;

	internal PictureBox pictureBox_1;

	public Label label2;

	public Button btn_planeselect;

	public F_ProfileOperationDataTemplate()
	{
		Class76.smethod_578(this);
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
