// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Profile.ProfileTemplate.F_ProfileOperationDataTemplate
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Profile.ProfileTemplate;

public class F_ProfileOperationDataTemplate : Form
{
  private IContainer icontainer_0 = (IContainer) null;
  internal ImageList imageList_0;
  internal Panel panel_0;
  internal Label label_0;
  public NumericUpDown spn_planefreelen;
  public Button btn_planefreesettings;
  public Button btn_free;
  public Button btn_planeleft;
  public Button btn_planeright;
  internal Label label_1;
  public Button btn_planetop;
  public NumericUpDown spn_posycommon;
  public NumericUpDown spn_posxcommon;
  public NumericUpDown spn_depth;
  public Label lbl_y;
  public Label lbl_x;
  public Label label1;
  public CheckBox chk_eachlayer;
  public Button btn_editfreeplane;
  public Button btn_camsettibgs;
  public Button btn_array;
  public CheckBox chk_Extradepth;
  public NumericUpDown spn_extradepth;
  public CheckBox chk_incrementalmode;
  internal PictureBox pictureBox_0;
  internal PictureBox pictureBox_1;
  public Label label2;
  public Button btn_planeselect;

  public F_ProfileOperationDataTemplate() => Class39.smethod_578(this);

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
