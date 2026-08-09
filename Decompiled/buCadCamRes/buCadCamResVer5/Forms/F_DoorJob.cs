using System;
using System.ComponentModel;
using System.Windows.Forms;
using ns8;

namespace buCadCamResVer5.Forms;

public class F_DoorJob : Form
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

	public ToolStripMenuItem mnu_add;

	public ToolStripMenuItem mnu_remove;

	internal ToolStripSeparator toolStripSeparator_1;

	internal ToolStripSeparator toolStripSeparator_2;

	public ToolStripMenuItem mnu_edit;

	public ToolStripMenuItem mnu_tool;

	public ToolStripMenuItem mnu_copy;

	public ToolStripMenuItem mnu_array;

	public ToolStripMenuItem mnu_mirror;

	public ToolStripMenuItem mnu_rotate;

	public ToolStripMenuItem mnu_move;

	internal ToolStripSeparator toolStripSeparator_3;

	public ToolStripMenuItem mnu_disable;

	public ToolStripMenuItem mnu_removeall;

	internal ToolStripSeparator toolStripSeparator_4;

	public ToolStripMenuItem mnu_addpanel;

	public ToolStripMenuItem mnu_deletepanel;

	public ToolStripMenuItem mnu_editpanel;

	public ToolStripMenuItem mnu_renamepanel;

	internal ToolStripSeparator toolStripSeparator_5;

	public ToolStripMenuItem mnu_removeselectedOP;

	public ToolStripMenuItem mnu_selectall;

	public ToolStripMenuItem mnu_unselectall;

	public CheckBox chk_selectmode;

	public Panel pnl_cmd;

	public Button btn_move;

	public Button btn_rotate;

	public Button btn_disable;

	public Button btn_copy;

	public Button btn_array;

	public Button btn_mirror;

	public Button btn_edit;

	public Button btn_remove;

	public Button btn_tool;

	public Button btn_up;

	public Button btn_down;

	public Button btn_add;

	internal ToolStripSeparator toolStripSeparator_6;

	public ToolStripMenuItem mnu_refresh;

	public F_DoorJob()
	{
		Class5.smethod_3(this);
		mnu_add.Image = imageList_0.Images[6];
		mnu_remove.Image = imageList_0.Images[9];
		mnu_up.Image = imageList_0.Images[11];
		mnu_down.Image = imageList_0.Images[7];
		mnu_array.Image = imageList_0.Images[2];
		mnu_copy.Image = imageList_0.Images[0];
		mnu_disable.Image = imageList_0.Images[1];
		mnu_edit.Image = imageList_0.Images[8];
		mnu_mirror.Image = imageList_0.Images[3];
		mnu_move.Image = imageList_0.Images[15];
		mnu_rotate.Image = imageList_0.Images[4];
		mnu_tool.Image = imageList_0.Images[10];
		mnu_disable.Image = imageList_0.Images[12];
		mnu_removeall.Image = imageList_0.Images[14];
		mnu_addpanel.Image = imageList_0.Images[15];
		mnu_deletepanel.Image = imageList_0.Images[16];
		mnu_editpanel.Image = imageList_0.Images[17];
		mnu_renamepanel.Image = imageList_0.Images[18];
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
