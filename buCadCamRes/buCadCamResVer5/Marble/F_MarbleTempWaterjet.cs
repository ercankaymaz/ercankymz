// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Marble.F_MarbleTempWaterjet
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buControls.Controls;
using ns8;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Marble;

public class F_MarbleTempWaterjet : Form
{
  private IContainer icontainer_0 = (IContainer) null;
  public buButton btn_hydrolic;
  public buButton btn_sand;
  public buButton btn_motor;
  public buButton btn_valve;
  public buButton btn_water;
  public Panel pnl_controls;
  public buLabel lbl_sandspeed;
  public buTrack track_sandspeed;

  public F_MarbleTempWaterjet() => Class5.smethod_152(this);

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
