// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Forms.F_DrillJob
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using ns8;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Forms;

public class F_DrillJob : Form
{
  internal IContainer icontainer_0 = (IContainer) null;
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
    this.mnu_removeoperation.Image = this.imageList_1.Images[9];
    this.mnu_upmove.Image = this.imageList_1.Images[11];
    this.mnu_downmove.Image = this.imageList_1.Images[7];
    this.mnu_copyoperation.Image = this.imageList_1.Images[0];
    this.mnu_disableoperation.Image = this.imageList_1.Images[1];
    this.mnu_editoperation.Image = this.imageList_1.Images[8];
    this.mnu_mirroroperation.Image = this.imageList_1.Images[3];
    this.mnu_disableoperation.Image = this.imageList_1.Images[12];
    this.mnu_removealloperation.Image = this.imageList_1.Images[14];
    this.mnu_addpanel.Image = this.imageList_1.Images[15];
    this.mnu_deletepanel.Image = this.imageList_1.Images[16 /*0x10*/];
    this.mnu_editpanel.Image = this.imageList_1.Images[17];
    this.mnu_renamepanel.Image = this.imageList_1.Images[18];
    this.mnu_rotatepanel.Image = this.imageList_1.Images[5];
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
