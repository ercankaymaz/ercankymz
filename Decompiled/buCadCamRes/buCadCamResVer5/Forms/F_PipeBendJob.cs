using System;
using System.ComponentModel;
using System.Windows.Forms;
using ns8;

namespace buCadCamResVer5.Forms;

public class F_PipeBendJob : Form
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

	public ToolStripMenuItem mnu_deleteblock;

	public ToolStripMenuItem mnu_editblock;

	public ToolStripMenuItem mnu_renameblock;

	internal ToolStripSeparator toolStripSeparator_2;

	public Panel pnl_info;

	public ToolStripMenuItem mnu_deleteXZselection;

	public ToolStripMenuItem mnu_deleteYZselection;

	internal ToolStripSeparator toolStripSeparator_3;

	public Button btn_viewiso;

	public Button btn_viewleft;

	public Button btn_viewfront;

	public Button btn_zoomfit;

	public Panel pnl_cmd2;

	public ToolStripMenuItem mnu_foamedit;

	public ToolStripMenuItem mnu_foamrename;

	public ToolStripMenuItem mnu_deleteallblock;

	public ToolStripMenuItem mnu_foamdelete;

	public ToolStripMenuItem mnu_redraw;

	public TextBox txt_info;

	public F_PipeBendJob()
	{
		Class5.smethod_16(this);
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
