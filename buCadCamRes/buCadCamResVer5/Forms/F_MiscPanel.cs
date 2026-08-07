// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Forms.F_MiscPanel
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using ns8;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Forms;

public class F_MiscPanel : Form
{
  internal IContainer icontainer_0 = (IContainer) null;
  public TextBox txt_notes;
  public Panel pnl_controls;
  internal ImageList imageList_0;
  public ToolTip toolTip1;
  internal ImageList imageList_1;
  internal Label label_0;
  public Panel pnl_viewport;

  public F_MiscPanel() => Class5.smethod_170(this);

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
