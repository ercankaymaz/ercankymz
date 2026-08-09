using System.ComponentModel;
using System.Windows.Forms;
using buControls.Controls;
using ns8;

namespace buCadCamResVer5.Marble;

public class F_MarbleTempMovements : Form
{
	private IContainer icontainer_0 = null;

	public buButton btn_park;

	public buButton btn_cminus;

	public buButton btn_100;

	public buButton btn_camera;

	public buCheckBox chk_absolute;

	public buButton btn_0_01;

	public buButton btn_cplus;

	public buButton btn_homing;

	public buButton btn_yplus;

	public buCheckBox chk_incremental;

	public buButton btn_10;

	public buCheckBox chk_addsawthickness;

	public buButton btn_xminus;

	public buLabel lbl_presetvalues;

	public buButton btn_stopmanuel;

	public buButton btn_zplus;

	public buButton btn_5;

	public buSpin spn_go;

	public buButton btn_xplus;

	public buButton btn_zminus;

	public buButton btn_aminus;

	public buButton btn_0_1;

	public buButton btn_1;

	public buButton btn_aplus;

	public buButton btn_yminus;

	public Panel pnl_controls;

	public F_MarbleTempMovements()
	{
		Class5.smethod_46(this);
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
