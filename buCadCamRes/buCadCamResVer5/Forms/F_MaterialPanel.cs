// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Forms.F_MaterialPanel
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using ns8;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Forms;

public class F_MaterialPanel : Form
{
  private IContainer icontainer_0 = (IContainer) null;
  public TextBox txt_notes;
  public Panel pnl_controls;
  public Panel pnl_materials;
  public Panel pnl_cmd;
  public TreeView tree_mats;
  internal ImageList imageList_0;
  public TextBox txt_materialexplanatiom;
  public ToolTip toolTip1;
  internal ImageList imageList_1;
  public Button btn_remove;
  public Button btn_add;
  public Button btn_down;
  public Button btn_copy;
  public Button btn_properties;
  public Button btn_up;
  public Label lbl_materials;
  public Label lbl_notes;

  public F_MaterialPanel() => Class5.smethod_98(this);

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
