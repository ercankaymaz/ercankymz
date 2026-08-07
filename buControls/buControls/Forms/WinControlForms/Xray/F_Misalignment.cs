// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Xray.F_Misalignment
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Xray;

public class F_Misalignment : Form
{
  private IContainer icontainer_0 = (IContainer) null;
  internal Label label_0;
  internal Label label_1;
  internal Label label_2;
  internal Label label_3;
  internal Label label_4;
  internal Label label_5;
  internal Label label_6;
  internal Label label_7;
  internal Button button_0;
  public TextBox txt_cAxisdx;
  public TextBox txt_cAxisdy;
  public TextBox txt_cAxisdz;
  public TextBox txt_aAxisdz;
  public TextBox txt_aAxisdy;
  public TextBox txt_aAxisdx;
  public TextBox txt_aAxisangle;
  public TextBox txt_cAxisangle;

  public F_Misalignment() => Class39.smethod_175(this);

  internal void method_0(object sender, EventArgs e) => this.Close();

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
