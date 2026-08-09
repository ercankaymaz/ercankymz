using System.ComponentModel;
using System.Windows.Forms;
using buControls.Controls;
using buMutliTextbox;
using ns8;

namespace buCadCamResVer5.Marble;

public class F_MarbleTempCodes : Form
{
	private IContainer icontainer_0 = null;

	public buLabel lbl_c;

	public buLabel lbl_part;

	public buLabel lbl_a;

	public buLabel lbl_machinec;

	public buLabel lbl_z;

	public buLabel lbl_machine;

	public buLabel lbl_y;

	public buLabel lbl_partc;

	public buLabel lbl_x;

	public buLabel lbl_quickspeed;

	public buButton btn_laser;

	public buLabel lbl_machinea;

	public buTrack track_quickspeed;

	public buLabel lbl_parta;

	public buLabel lbl_operationspeed;

	public buTrack track_operationspeed;

	public buLabel lbl_machinez;

	public buButton btn_start;

	public buLabel lbl_partz;

	public buButton btn_pause;

	public buButton btn_water;

	public buLabel lbl_machiney;

	public buButton btn_spindlemain;

	public buLabel lbl_party;

	public buButton btn_stop;

	public buLabel lbl_machinex;

	public buLabel lbl_partx;

	public Panel pnl_controls;

	public buMultiTextBox txt_gcode;

	public F_MarbleTempCodes()
	{
		Class5.smethod_220(this);
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
