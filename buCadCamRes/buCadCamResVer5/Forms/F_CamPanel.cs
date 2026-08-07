// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Forms.F_CamPanel
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using ns8;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Forms;

public class F_CamPanel : Form
{
  private IContainer icontainer_0 = (IContainer) null;
  public Panel pnl_controls;
  public Panel pnl_cmd;
  public TreeView tree_cam;
  internal ImageList imageList_0;
  public Label lbl_step;
  public Panel pnl_simulation;
  public TextBox txt_camexplanatiom;
  public PictureBox pic_seperator_sim;
  internal ImageList imageList_1;
  internal ImageList imageList_2;
  public TrackBar track_simspet;
  public NumericUpDown spn_simtick;
  public TextBox txt_simc;
  public TextBox txt_simb;
  public TextBox txt_sima;
  public TextBox txt_simz;
  public TextBox txt_simy;
  public TextBox txt_simx;
  public Button btn_simnextcam;
  public Button btn_simprecam;
  public Button btn_simnext;
  public Button btn_simpre;
  public Button btn_simstop;
  public Button btn_simstart;
  public Button btn_editcam;
  public Button btn_showcode;
  public Button btn_preview;
  public Button btn_createcode;
  public Button btn_deletecam;
  public Label lbl_tick;
  public Label lbl_simc;
  public Label lbl_simb;
  public Label lbl_sima;
  public Label lbl_simz;
  public Label lbl_simy;
  public Label lbl_simx;
  public Label lbl_cam;

  public F_CamPanel() => Class5.smethod_8(this);

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
