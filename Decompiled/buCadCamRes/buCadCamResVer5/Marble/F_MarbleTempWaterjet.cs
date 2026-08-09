using System.ComponentModel;
using System.Windows.Forms;
using buControls.Controls;
using ns8;

namespace buCadCamResVer5.Marble;

public class F_MarbleTempWaterjet : Form
{
	private IContainer icontainer_0 = null;

	public buButton btn_hydrolic;

	public buButton btn_sand;

	public buButton btn_motor;

	public buButton btn_valve;

	public buButton btn_water;

	public Panel pnl_controls;

	public buLabel lbl_sandspeed;

	public buTrack track_sandspeed;

	public F_MarbleTempWaterjet()
	{
		Class5.smethod_152(this);
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
