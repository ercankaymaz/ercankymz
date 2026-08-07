// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Plane.F_PlaneBasePntAngLen
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

public class F_PlaneBasePntAngLen : Form
{
  public FormProperties Properties = new FormProperties();
  public WorkPlane Plane = new WorkPlane();
  internal IContainer icontainer_0 = (IContainer) null;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  internal Label label_1;
  internal NumericUpDown numericUpDown_1;
  internal Label label_2;
  internal NumericUpDown numericUpDown_2;
  internal Label label_3;
  internal NumericUpDown numericUpDown_3;
  public Button btn_cancel;
  internal ImageList imageList_0;
  public Button btn_ok;
  internal CheckBox checkBox_0;
  internal Label label_4;
  internal Label label_5;
  internal CheckBox checkBox_1;
  internal PictureBox pictureBox_0;
  internal PictureBox pictureBox_1;
  internal Label label_6;
  internal NumericUpDown numericUpDown_4;

  public F_PlaneBasePntAngLen() => Class39.smethod_483(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    if (!this.Plane.UseCenterPoint)
    {
      this.numericUpDown_2.Value = (Decimal) this.Plane.BasePoint.Y;
      this.numericUpDown_3.Value = (Decimal) this.Plane.BasePoint.Z;
    }
    else
    {
      this.numericUpDown_2.Value = (Decimal) this.Plane.MiddlePoint.Y;
      this.numericUpDown_3.Value = (Decimal) this.Plane.MiddlePoint.Z;
    }
    this.numericUpDown_1.Value = (Decimal) this.Plane.Angles.A;
    this.numericUpDown_0.Value = (Decimal) this.Plane.Lenght;
    this.checkBox_0.Checked = this.Plane.UseCenterPoint;
    this.checkBox_1.Checked = this.Plane.isCircular;
    this.numericUpDown_4.Value = (Decimal) this.Plane.CircularAngle;
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
  }

  internal void method_0(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.btn_ok.Name)
    {
      if (!this.Properties.Inited)
        return;
      if (this.Properties.ReadOnly)
      {
        this.Dispose();
        return;
      }
      Class39.smethod_118(this);
      this.Properties.Result = DialogResult.OK;
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == this.btn_cancel.Name))
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
