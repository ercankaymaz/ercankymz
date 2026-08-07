// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Forms.F_MarbleJob
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buControls.Controls;
using ns8;
using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Forms;

public class F_MarbleJob : Form
{
  private IContainer icontainer_0 = (IContainer) null;
  public TreeView tree_jobs;
  public Panel pnl_controls;
  public Label lbl_jobs;
  internal ImageList imageList_0;
  internal ImageList imageList_1;
  public Panel pnl_viewport;
  internal ContextMenuStrip contextMenuStrip_0;
  internal ToolStripSeparator toolStripSeparator_0;
  public ToolStripMenuItem mnu_OPup;
  public ToolStripMenuItem mnu_OPdown;
  internal ToolStripSeparator toolStripSeparator_1;
  public Panel pnl_info;
  public Button btn_viewtri;
  public Button btn_viewleft;
  public Button btn_viewfront;
  public Button btn_zoomfit;
  public Panel pnl_cmd2;
  public ToolStripMenuItem mnu_camedit;
  public ToolStripMenuItem mnu_camdelete;
  public ToolStripMenuItem mnu_redraw;
  internal ToolStripSeparator toolStripSeparator_2;
  public ToolStripMenuItem mnu_edittool;
  public ToolStripMenuItem mnu_camdeleteall;
  internal ImageList imageList_2;
  public buButton btn_itemedit;
  public buButton btn_itemremove;
  public buButton btn_itemmove;
  public buButton btn_itemup;
  public buButton btn_itemdown;
  public buButton btn_OPdown;
  public buButton btn_OPup;
  public buButton btn_OPedit;
  public buButton btn_OPdelete;
  public buButton btn_deletecam;
  public buButton btn_menuclose;
  public buButton btn_menu;
  public buButton btn_OPDisable;
  public buButton btn_OPmove;
  public buPanel pnl_menu;
  public buLabel buLabel2;
  public buLabel lbl_menu;
  public buLabel lbl_deleteall;
  public buCheckBox chk_deleteall;
  public buButton btn_tooledit;
  public ToolStripMenuItem mnu_OPdelete;
  public ToolStripMenuItem mnu_OPedit;
  public ToolStripMenuItem mnu_OPMove;
  public ToolStripMenuItem mnu_OPdisable;
  public ToolStripMenuItem mnu_OPdeleteall;
  public buButton btn_addcam;
  public buLabel lbl_all2;
  public buCheckBox chk_deletaallcam;
  public ToolStripMenuItem mnu_camadd;
  public Button btn_viewtop;
  public Button btn_preview;

  public F_MarbleJob() => Class5.smethod_159(this);

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
