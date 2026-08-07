// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Forms.F_LayerPanel
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buControls.Components;
using ns8;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Forms;

public class F_LayerPanel : Form
{
  internal IContainer icontainer_0 = (IContainer) null;
  public Panel pnl_controls;
  public TextBox txt_layerexplanatiom;
  public Panel pnl_cmd;
  internal ImageList imageList_0;
  public Button btn_down;
  public Button btn_add;
  public Button btn_up;
  public Button btn_remove;
  public Button btn_copy;
  public Button btn_properties;
  public Label lbl_layers;
  public buLayerList buLayerList1;

  public F_LayerPanel() => Class5.smethod_101(this);

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
