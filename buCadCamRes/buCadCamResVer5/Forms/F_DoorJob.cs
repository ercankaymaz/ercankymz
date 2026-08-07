// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Forms.F_DoorJob
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using ns8;
using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Forms;

public class F_DoorJob : Form
{
  internal IContainer icontainer_0 = (IContainer) null;
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
    this.mnu_add.Image = this.imageList_0.Images[6];
    this.mnu_remove.Image = this.imageList_0.Images[9];
    this.mnu_up.Image = this.imageList_0.Images[11];
    this.mnu_down.Image = this.imageList_0.Images[7];
    this.mnu_array.Image = this.imageList_0.Images[2];
    this.mnu_copy.Image = this.imageList_0.Images[0];
    this.mnu_disable.Image = this.imageList_0.Images[1];
    this.mnu_edit.Image = this.imageList_0.Images[8];
    this.mnu_mirror.Image = this.imageList_0.Images[3];
    this.mnu_move.Image = this.imageList_0.Images[15];
    this.mnu_rotate.Image = this.imageList_0.Images[4];
    this.mnu_tool.Image = this.imageList_0.Images[10];
    this.mnu_disable.Image = this.imageList_0.Images[12];
    this.mnu_removeall.Image = this.imageList_0.Images[14];
    this.mnu_addpanel.Image = this.imageList_0.Images[15];
    this.mnu_deletepanel.Image = this.imageList_0.Images[16 /*0x10*/];
    this.mnu_editpanel.Image = this.imageList_0.Images[17];
    this.mnu_renamepanel.Image = this.imageList_0.Images[18];
  }

  internal void method_0(object sender, EventArgs e)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
