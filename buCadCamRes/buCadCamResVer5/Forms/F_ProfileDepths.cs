// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Forms.F_ProfileDepths
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using ns8;
using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Forms;

public class F_ProfileDepths : Form
{
  internal IContainer icontainer_0 = (IContainer) null;
  internal ImageList imageList_0;
  public Button btn_depthdelete;
  public Button btn_depthadd;
  public DataGridView DGV_Depths;
  public Button btn_depthsave;
  public Button btn_depthopen;
  public Panel pnl_control;
  public Button btn_depthcalculate;

  public F_ProfileDepths() => Class5.smethod_78(this);

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
