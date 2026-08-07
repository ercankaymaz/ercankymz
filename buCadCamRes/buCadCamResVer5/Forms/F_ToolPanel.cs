// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Forms.F_ToolPanel
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using ns8;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Forms;

public class F_ToolPanel : Form
{
  private IContainer icontainer_0 = (IContainer) null;
  public Panel pnl_controls;
  public TreeView tree_tools;
  internal ImageList imageList_0;
  internal ImageList imageList_1;
  public TextBox txt_toolexplanatiom;
  public Panel pnl_model;
  public Panel pnl_cmd;
  internal ImageList imageList_2;
  public Button btn_remove;
  public Button btn_add;
  public Button btn_down;
  public Button btn_copy;
  public Button btn_properties;
  public Button btn_up;
  public Label lbl_Tool;

  public F_ToolPanel() => Class5.smethod_204(this);

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
