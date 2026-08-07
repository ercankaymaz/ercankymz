// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Forms.F_ProfileJob
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using ns8;
using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Forms;

public class F_ProfileJob : Form
{
  private IContainer icontainer_0 = (IContainer) null;
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
    this.mnu_addprofile.Image = this.imageList_0.Images[15];
    this.mnu_deleteprofile.Image = this.imageList_0.Images[16 /*0x10*/];
    this.mnu_editprofile.Image = this.imageList_0.Images[17];
    this.mnu_renameprofile.Image = this.imageList_0.Images[18];
    this.mnu_copyprofile.Image = this.imageList_0.Images[19];
    this.mnu_priorityoperation.Image = this.imageList_0.Images[20];
    this.mnu_selectall.Image = this.imageList_0.Images[21];
    this.mnu_unselectall.Image = this.imageList_0.Images[22];
    this.mnu_operationfromfile.Image = this.imageList_0.Images[23];
    this.mnu_addprofilelist.Image = this.imageList_0.Images[24];
    this.mnu_enable.Image = this.imageList_0.Images[13];
    this.mnu_redraw.Image = this.imageList_0.Images[25];
    this.mnu_simulation.Image = this.imageList_0.Images[26];
    this.mnu_addboxprofile.Image = this.imageList_0.Images[27];
    this.mnu_enableprofile.Image = this.imageList_0.Images[28];
    this.mnu_disableprofile.Image = this.imageList_0.Images[29];
  }

  internal void method_0(object sender, EventArgs e)
  {
  }

  internal void method_1(object sender, CancelEventArgs e)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
