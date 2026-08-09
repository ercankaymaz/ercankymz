using System;
using System.ComponentModel;
using System.Windows.Forms;
using ns8;

namespace buCadCamResVer5.Forms;

public class F_ProfilePlanes : Form
{
	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	internal ImageList imageList_1;

	public Button btn_save;

	public Button btn_open;

	public Button btn_delete;

	public Button btn_addplane;

	public Label lbl_05;

	public ListBox lst_types;

	public Button btn_yplus;

	public Button btn_yminus;

	public Label lbl_10;

	public Label lbl_01;

	public Label lbl_5;

	public Label lbl_planeAngle;

	public Label lbl_1;

	public NumericUpDown spn_y;

	public NumericUpDown spn_angle;

	public Label label3;

	public Button btn_angminus;

	public Button btn_angplus;

	public Button btn_zplus;

	public Button btn_zminus;

	public NumericUpDown spn_z;

	public Label label4;

	public Panel pnl_controls;

	public F_ProfilePlanes()
	{
		Class5.smethod_20(this);
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
