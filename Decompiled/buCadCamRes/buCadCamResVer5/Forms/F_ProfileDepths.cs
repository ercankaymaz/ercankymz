using System;
using System.ComponentModel;
using System.Windows.Forms;
using ns8;

namespace buCadCamResVer5.Forms;

public class F_ProfileDepths : Form
{
	internal IContainer icontainer_0 = null;

	internal ImageList imageList_0;

	public Button btn_depthdelete;

	public Button btn_depthadd;

	public DataGridView DGV_Depths;

	public Button btn_depthsave;

	public Button btn_depthopen;

	public Panel pnl_control;

	public Button btn_depthcalculate;

	public F_ProfileDepths()
	{
		Class5.smethod_78(this);
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
