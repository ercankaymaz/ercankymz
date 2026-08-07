// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Forms.F_ToolGrinding
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using ns8;
using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Forms;

public class F_ToolGrinding : Form
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

  public F_ToolGrinding() => Class5.smethod_79(this);

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
