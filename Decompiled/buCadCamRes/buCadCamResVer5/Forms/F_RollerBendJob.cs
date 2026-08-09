using System;
using System.ComponentModel;
using System.Windows.Forms;
using ns8;

namespace buCadCamResVer5.Forms;

public class F_RollerBendJob : Form
{
	internal IContainer icontainer_0 = null;

	public TreeView tree_jobs;

	public Panel pnl_controls;

	public Label lbl_jobs;

	internal ImageList imageList_0;

	internal ImageList imageList_1;

	public Panel pnl_viewport;

	internal ContextMenuStrip contextMenuStrip_0;

	internal ToolStripSeparator toolStripSeparator_0;

	public ToolStripMenuItem mnu_up;

	public ToolStripMenuItem mnu_down;

	internal ToolStripSeparator toolStripSeparator_1;

	public Panel pnl_info;

	public Button btn_viewiso;

	public Button btn_viewleft;

	public Button btn_viewfront;

	public Button btn_zoomfit;

	public Panel pnl_cmd2;

	public ToolStripMenuItem mnu_camedit;

	public ToolStripMenuItem mnu_camrename;

	public ToolStripMenuItem mnu_camdelete;

	public ToolStripMenuItem mnu_redraw;

	public TextBox txt_info;

	internal ToolStripSeparator toolStripSeparator_2;

	public ToolStripMenuItem mnu_camenabledisable;

	public ToolStripMenuItem mnu_camedittool;

	public ToolStripMenuItem mnu_camdeleteall;

	public F_RollerBendJob()
	{
		Class5.smethod_30(this);
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
