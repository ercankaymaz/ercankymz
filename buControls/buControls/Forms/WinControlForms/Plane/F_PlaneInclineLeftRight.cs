// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Plane.F_PlaneInclineLeftRight
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buClass.Apps;
using ns7;
using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Plane;

public class F_PlaneInclineLeftRight : Form
{
  public FormProperties Properties = new FormProperties();
  public ProfilePlaneData Plane = new ProfilePlaneData();
  public Pnt3D PlanePoint = new Pnt3D();
  public double Angle = 45.0;
  public double Length = 100.0;
  public planeInclineType PlaneType = planeInclineType.Distance;
  public LeftRightLocationType Direction = LeftRightLocationType.Right;
  public double ProfileW = 100.0;
  public double ProfileH = 0.0;
  private IContainer icontainer_0 = (IContainer) null;
  internal PictureBox pictureBox_0;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  internal NumericUpDown numericUpDown_1;
  internal Label label_1;
  internal Label label_2;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  internal ImageList imageList_1;
  internal RadioButton radioButton_0;
  internal RadioButton radioButton_1;
  internal Label label_3;
  internal Label label_4;
  internal TabControl tabControl_0;
  internal TabPage tabPage_0;
  internal TabPage tabPage_1;
  internal Label label_5;
  internal PictureBox pictureBox_1;
  internal Label label_6;
  internal NumericUpDown numericUpDown_2;
  internal Label label_7;
  internal NumericUpDown numericUpDown_3;
  internal ImageList imageList_2;
  internal Label label_8;
  internal NumericUpDown numericUpDown_4;
  internal Label label_9;
  internal NumericUpDown numericUpDown_5;

  public F_PlaneInclineLeftRight() => Class39.smethod_243(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.numericUpDown_0.Value = (Decimal) this.PlanePoint.Y;
    this.numericUpDown_1.Value = (Decimal) this.PlanePoint.Z;
    this.numericUpDown_2.Value = (Decimal) this.PlanePoint.Y;
    this.numericUpDown_3.Value = (Decimal) this.PlanePoint.Z;
    this.numericUpDown_5.Value = (Decimal) this.Angle;
    this.numericUpDown_4.Value = (Decimal) this.Length;
    this.label_3.Text = "W= " + this.ProfileW.ToString("f2");
    this.label_4.Text = "H= " + this.ProfileH.ToString("f2");
    if (this.Direction == LeftRightLocationType.Left)
    {
      this.radioButton_0.Checked = true;
      this.pictureBox_0.Image = this.imageList_1.Images[0];
      this.pictureBox_1.Image = this.imageList_2.Images[0];
    }
    if (this.Direction == LeftRightLocationType.Right)
    {
      this.radioButton_1.Checked = true;
      this.pictureBox_0.Image = this.imageList_1.Images[1];
      this.pictureBox_1.Image = this.imageList_2.Images[1];
    }
    if (this.PlaneType == planeInclineType.Distance)
      this.tabControl_0.SelectedIndex = 0;
    if (this.PlaneType == planeInclineType.Angle)
      this.tabControl_0.SelectedIndex = 1;
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
      Class39.smethod_658(this);
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

  internal void method_2(object sender, EventArgs e)
  {
    if (!this.Properties.Inited)
      return;
    if (this.tabControl_0.SelectedIndex == 0)
      this.PlaneType = planeInclineType.Distance;
    if (this.tabControl_0.SelectedIndex != 1)
      return;
    this.PlaneType = planeInclineType.Angle;
  }

  internal void method_3(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (!this.Properties.Inited)
      return;
    if (control2.Name == this.radioButton_0.Name)
    {
      this.pictureBox_0.Image = this.imageList_1.Images[0];
      this.Direction = LeftRightLocationType.Left;
    }
    if (!(control2.Name == this.radioButton_1.Name))
      return;
    this.pictureBox_0.Image = this.imageList_1.Images[1];
    this.Direction = LeftRightLocationType.Right;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
