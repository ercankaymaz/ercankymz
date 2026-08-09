using System;
using System.ComponentModel;
using System.Windows.Forms;
using ns8;

namespace buCadCamResVer5.Forms;

public class F_ProfileJob : Form
{
	private IContainer icontainer_0 = null;

	public TreeView tree_jobs;

	public Panel pnl_controls;

	public Panel pnl_cmd;

	public Button btn_down;

	public Button btn_up;

	public Button btn_tool;

	public Button btn_add;

	public Label lbl_jobs;

	public Button btn_remove;

	internal ImageList imageList_0;

	public Button btn_move;

	public Button btn_rotate;

	public Button btn_disable;

	public Button btn_copy;

	public Button btn_array;

	public Button btn_mirror;

	public Button btn_edit;

	internal ImageList imageList_1;

	public Panel pnl_viewport;

	public ToolStripMenuItem mnu_up;

	public ToolStripMenuItem mnu_down;

	public ToolStripMenuItem mnu_add;

	public ToolStripMenuItem mnu_remove;

	public ToolStripMenuItem mnu_edit;

	public ToolStripMenuItem mnu_tool;

	public ToolStripMenuItem mnu_copy;

	public ToolStripMenuItem mnu_array;

	public ToolStripMenuItem mnu_mirror;

	public ToolStripMenuItem mnu_rotate;

	public ToolStripMenuItem mnu_move;

	public ToolStripMenuItem mnu_disable;

	public ToolStripMenuItem mnu_removeall;

	public ToolStripMenuItem mnu_addprofile;

	public ToolStripMenuItem mnu_deleteprofile;

	public ToolStripMenuItem mnu_editprofile;

	public ToolStripMenuItem mnu_renameprofile;

	public ToolStripMenuItem mnu_selectall;

	public ToolStripMenuItem mnu_unselectall;

	public CheckBox chk_selectmode;

	public ToolStripMenuItem mnu_priorityoperation;

	public ToolStripMenuItem mnu_copyprofile;

	public ToolStripMenuItem mnu_operationfromfile;

	public ToolStripMenuItem mnu_redraw;

	public ToolStripMenuItem mnu_addprofilelist;

	public ToolStripMenuItem mnu_enable;

	public ContextMenuStrip mnu_profile;

	public ToolStripSeparator toolStripSeparator1;

	public ToolStripSeparator toolStripSeparator2;

	public ToolStripSeparator toolStripSeparator3;

	public ToolStripSeparator toolStripSeparator4;

	public ToolStripSeparator toolStripSeparator5;

	public ToolStripSeparator toolStripSeparator6;

	public ToolStripSeparator toolStripSeparator7;

	public ToolStripMenuItem mnu_simulation;

	public ToolStripMenuItem mnu_addboxprofile;

	public ToolStripMenuItem mnu_enableprofile;

	public ToolStripMenuItem mnu_disableprofile;

	public Label lbl_info;

	public ToolStripMenuItem mnu_removeplaneoperations;

	public ToolStripMenuItem mnu_deleteplaneoperationtop;

	public ToolStripMenuItem mnu_deleteplaneoperationfront;

	public ToolStripMenuItem mnu_deleteplaneoperationback;

	public ToolStripMenuItem mnu_deleteplaneoperationfree;

	public ToolStripMenuItem mnu_deleteplaneoperationbottom;

	public F_ProfileJob()
	{
		Class5.smethod_174(this);
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
		mnu_addprofile.Image = imageList_0.Images[15];
		mnu_deleteprofile.Image = imageList_0.Images[16];
		mnu_editprofile.Image = imageList_0.Images[17];
		mnu_renameprofile.Image = imageList_0.Images[18];
		mnu_copyprofile.Image = imageList_0.Images[19];
		mnu_priorityoperation.Image = imageList_0.Images[20];
		mnu_selectall.Image = imageList_0.Images[21];
		mnu_unselectall.Image = imageList_0.Images[22];
		mnu_operationfromfile.Image = imageList_0.Images[23];
		mnu_addprofilelist.Image = imageList_0.Images[24];
		mnu_enable.Image = imageList_0.Images[13];
		mnu_redraw.Image = imageList_0.Images[25];
		mnu_simulation.Image = imageList_0.Images[26];
		mnu_addboxprofile.Image = imageList_0.Images[27];
		mnu_enableprofile.Image = imageList_0.Images[28];
		mnu_disableprofile.Image = imageList_0.Images[29];
	}

	internal void method_0(object sender, EventArgs e)
	{
	}

	internal void method_1(object sender, CancelEventArgs e)
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
