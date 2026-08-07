// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Materials.F_Material
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.ColorPicker;
using buControls.Viewer;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Materials;

public class F_Material : Form
{
  public MaterialBase Material = new MaterialBase();
  public DialogResult Result = DialogResult.None;
  public static List<string> Captions = new List<string>();
  internal IContainer icontainer_0 = (IContainer) null;
  internal TabControl tabControl_0;
  internal TabPage tabPage_0;
  internal NumericUpDown numericUpDown_0;
  internal Label label_0;
  internal PictureBox pictureBox_0;
  internal NumericUpDown numericUpDown_1;
  internal Label label_1;
  internal TabPage tabPage_1;
  internal NumericUpDown numericUpDown_2;
  internal Label label_2;
  internal PictureBox pictureBox_1;
  internal TabPage tabPage_2;
  internal NumericUpDown numericUpDown_3;
  internal Label label_3;
  internal NumericUpDown numericUpDown_4;
  internal Label label_4;
  internal PictureBox pictureBox_2;
  internal TabPage tabPage_3;
  internal NumericUpDown numericUpDown_5;
  internal Label label_5;
  internal NumericUpDown numericUpDown_6;
  internal Label label_6;
  internal Label label_7;
  internal TextBox textBox_0;
  internal buColorComboBox buColorComboBox_0;
  internal Label label_8;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  internal buViewer buViewer_0;
  public Button btn_add;
  public Button btn_remove;
  internal NumericUpDown numericUpDown_7;
  internal Label label_9;
  internal NumericUpDown numericUpDown_8;
  internal Label label_10;
  internal ListBox listBox_0;
  internal NumericUpDown numericUpDown_9;
  internal NumericUpDown numericUpDown_10;
  internal NumericUpDown numericUpDown_11;
  internal Label label_11;
  internal NumericUpDown numericUpDown_12;
  internal Label label_12;

  public F_Material() => Class39.smethod_628(this);

  public void Init()
  {
    this.numericUpDown_1.Value = (Decimal) this.Material.Width;
    this.numericUpDown_0.Value = (Decimal) this.Material.Height;
    this.numericUpDown_2.Value = (Decimal) this.Material.Radius;
    this.numericUpDown_4.Value = (Decimal) this.Material.MajorRadius;
    this.numericUpDown_3.Value = (Decimal) this.Material.MinorRadius;
    this.numericUpDown_6.Value = (Decimal) this.Material.Thickness;
    this.numericUpDown_5.Value = (Decimal) this.Material.Angle;
    this.numericUpDown_11.Value = (Decimal) this.Material.StartPoint.X;
    this.numericUpDown_10.Value = (Decimal) this.Material.StartPoint.Y;
    this.numericUpDown_9.Value = (Decimal) this.Material.StartPoint.Z;
    this.buColorComboBox_0.Color = this.Material.Display.SkinColor;
    this.numericUpDown_12.Value = (Decimal) this.Material.Display.SkinTransperancy;
    this.textBox_0.Text = this.Material.Name;
    if (this.Material.Shapes == MaterialShapes.Rectangle)
      this.tabControl_0.SelectedIndex = 0;
    if (this.Material.Shapes == MaterialShapes.Circle)
      this.tabControl_0.SelectedIndex = 1;
    if (this.Material.Shapes == MaterialShapes.Ellipse)
      this.tabControl_0.SelectedIndex = 2;
    if (this.Material.Shapes == MaterialShapes.Irregular)
      this.tabControl_0.SelectedIndex = 3;
    this.Result = DialogResult.None;
    this.listBox_0.Items.Clear();
    for (int index = 0; index <= this.Material.Points.Count - 1; ++index)
      this.listBox_0.Items.Add((object) $"{this.Material.Points[index].X.ToString("f1")} , {this.Material.Points[index].Y.ToString("f1")}");
    Class39.smethod_591(this);
    Class39.smethod_416(this);
  }

  internal void method_0(object sender, EventArgs e)
  {
    Class39.smethod_226(this);
    this.Result = DialogResult.OK;
    this.Dispose();
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.Result = DialogResult.Cancel;
    this.Dispose();
  }

  internal void method_2(object sender, EventArgs e)
  {
    this.Material.Points.Add(new Pnt3D((double) this.numericUpDown_8.Value, (double) this.numericUpDown_7.Value));
    this.listBox_0.Items.Add((object) $"{this.Material.Points[this.Material.Points.Count - 1].X.ToString("f1")} , {this.Material.Points[this.Material.Points.Count - 1].Y.ToString("f1")}");
    Class39.smethod_416(this);
  }

  internal void method_3(object sender, EventArgs e)
  {
    if (!(this.listBox_0.SelectedIndex >= 0 & this.listBox_0.SelectedIndex <= this.Material.Points.Count - 1))
      return;
    this.Material.Points.RemoveAt(this.listBox_0.SelectedIndex);
    this.listBox_0.Items.RemoveAt(this.listBox_0.SelectedIndex);
    Class39.smethod_416(this);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
