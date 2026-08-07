// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Forms.F_PagesPanel
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using ns8;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Forms;

public class F_PagesPanel : Form
{
  internal IContainer icontainer_0 = (IContainer) null;
  public TreeView tree_pages;
  internal ImageList imageList_0;
  public Panel pnl_controls;
  public Panel pnl_cmd;
  public TextBox txt_pageexplanatiom;
  internal ImageList imageList_1;
  public Button btn_setplane;
  public Button btn_addpage;
  public Button btn_addscene;
  public Button btn_preview;
  public Label lbl_pages;

  public F_PagesPanel() => Class5.smethod_181(this);

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
