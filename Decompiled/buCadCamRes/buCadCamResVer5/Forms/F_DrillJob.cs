using System.ComponentModel;
using System.Windows.Forms;
using ns8;

namespace buCadCamResVer5.Forms;

public class F_DrillJob : Form
{
	internal IContainer icontainer_0 = null;

	public TreeView tree_jobs;

	public Panel pnl_controls;

	public TextBox txt_pageexplanatiom;

	public Label lbl_jobs;

	internal ImageList imageList_0;

	internal ContextMenuStrip contextMenuStrip_0;

	public ToolStripMenuItem mnu_upmove;

	public ToolStripMenuItem mnu_downmove;

	internal ToolStripSeparator toolStripSeparator_0;

	public ToolStripMenuItem mnu_addpanel;

	public ToolStripMenuItem mnu_deletepanel;

	public ToolStripMenuItem mnu_editpanel;

	public ToolStripMenuItem mnu_renamepanel;

	internal ToolStripSeparator toolStripSeparator_1;

	public ToolStripMenuItem mnu_removeoperation;

	public ToolStripMenuItem mnu_removealloperation;

	public ToolStripMenuItem mnu_editoperation;

	internal ToolStripSeparator toolStripSeparator_2;

	public ToolStripMenuItem mnu_copyoperation;

	public ToolStripMenuItem mnu_mirroroperation;

	internal ToolStripSeparator toolStripSeparator_3;

	public ToolStripMenuItem mnu_disableoperation;

	internal ImageList imageList_1;

	internal ImageList imageList_2;

	internal ToolStripSeparator toolStripSeparator_4;

	internal ToolStripSeparator toolStripSeparator_5;

	public ToolStripMenuItem mnu_alldrilldisable;

	public ToolStripMenuItem mnu_alldrillenable;

	public ToolStripMenuItem mnu_allslotdisable;

	public ToolStripMenuItem mnu_allslotenable;

	public ToolStripMenuItem mnu_allshapedisable;

	public ToolStripMenuItem mnu_allshapeenable;

	internal ImageList imageList_3;

	public ToolStripMenuItem mnu_rotatepanel;

	internal ToolStripSeparator toolStripSeparator_6;

	public ToolStripMenuItem mnu_enabledisableoperations;

	public F_DrillJob()
	{
		Class5.smethod_92(this);
		mnu_removeoperation.Image = imageList_1.Images[9];
		mnu_upmove.Image = imageList_1.Images[11];
		mnu_downmove.Image = imageList_1.Images[7];
		mnu_copyoperation.Image = imageList_1.Images[0];
		mnu_disableoperation.Image = imageList_1.Images[1];
		mnu_editoperation.Image = imageList_1.Images[8];
		mnu_mirroroperation.Image = imageList_1.Images[3];
		mnu_disableoperation.Image = imageList_1.Images[12];
		mnu_removealloperation.Image = imageList_1.Images[14];
		mnu_addpanel.Image = imageList_1.Images[15];
		mnu_deletepanel.Image = imageList_1.Images[16];
		mnu_editpanel.Image = imageList_1.Images[17];
		mnu_renamepanel.Image = imageList_1.Images[18];
		mnu_rotatepanel.Image = imageList_1.Images[5];
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
