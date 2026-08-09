using System;
using System.ComponentModel;
using System.Windows.Forms;
using ns8;

namespace buCadCamResVer5.Forms;

public class F_PanelCutJob : Form
{
	private IContainer icontainer_0 = null;

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

	public ToolStripMenuItem mnu_remove;

	internal ToolStripSeparator toolStripSeparator_1;

	public ToolStripMenuItem mnu_edit;

	public ToolStripMenuItem mnu_copy;

	public ToolStripMenuItem mnu_array;

	public ToolStripMenuItem mnu_mirror;

	public ToolStripMenuItem mnu_rotate;

	public ToolStripMenuItem mnu_move;

	internal ToolStripSeparator toolStripSeparator_2;

	public ToolStripMenuItem mnu_disable;

	public ToolStripMenuItem mnu_removeall;

	internal ToolStripSeparator toolStripSeparator_3;

	public ToolStripMenuItem mnu_addfoam;

	public ToolStripMenuItem mnu_deletefoam;

	public ToolStripMenuItem mnu_editblock;

	public ToolStripMenuItem mnu_renameblock;

	internal ToolStripSeparator toolStripSeparator_4;

	public ToolStripMenuItem mnu_addlayer;

	public ToolStripMenuItem mnu_deletelayer;

	public ToolStripMenuItem mnu_renamelayer;

	public ToolStripMenuItem mnu_deletealllayer;

	public Panel pnl_cmd;

	public Button btn_back;

	public Button btn_selectionOk;

	public ToolStripMenuItem mnu_deleteXZselection;

	public ToolStripMenuItem mnu_deleteYZselection;

	internal ToolStripSeparator toolStripSeparator_5;

	public ToolStripMenuItem mnu_reverse;

	public Button btn_planeXZ;

	public Button btn_planeYZ;

	public Button btn_viewiso;

	public Button btn_viewleft;

	public Button btn_viewfront;

	public Button btn_zoomfit;

	public Panel pnl_cmd2;

	public DataGridView dgv_sheets;

	public F_PanelCutJob()
	{
		Class5.smethod_104(this);
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
