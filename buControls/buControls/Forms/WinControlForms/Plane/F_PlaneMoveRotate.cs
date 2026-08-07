// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Plane.F_PlaneMoveRotate
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using ns7;
using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Plane;

public class F_PlaneMoveRotate : Form
{
  public FormProperties Properties = new FormProperties();
  internal IContainer icontainer_0 = (IContainer) null;
  public Button btn_movezminus;
  internal ImageList imageList_0;
  public Button btn_movezplus;
  public Button btn_rotateplus;
  public Button btn_rotateminus;
  public Button btn_moveyminus;
  public Button btn_movexplus;
  public Button btn_moveyplus;
  public Button btn_movexminus;
  internal ImageList imageList_1;
  public Button btn_cancel;
  public NumericUpDown spn_movez;
  public NumericUpDown spn_rotate;
  public NumericUpDown spn_movey;
  public NumericUpDown spn_movex;

  public F_PlaneMoveRotate() => Class39.smethod_544(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
  }

  internal void method_0(object sender, EventArgs e)
  {
    Control control = new Control();
    if (!(((Control) sender).Name == this.btn_cancel.Name))
      return;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, FormClosingEventArgs e)
  {
    if (this.Properties.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
