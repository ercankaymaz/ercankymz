// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.ModuleWorks.F_MwTriangleMeshRough
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using ns7;
using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.ModuleWorks;

public class F_MwTriangleMeshRough : Form
{
  public FormProperties Properties = new FormProperties();
  private IContainer icontainer_0 = (IContainer) null;
  internal TabControl tabControl_0;
  internal TabPage tabPage_0;
  internal TabPage tabPage_1;
  internal Panel panel_0;
  internal RadioButton radioButton_0;
  internal RadioButton radioButton_1;
  internal Label label_0;
  internal Panel panel_1;
  internal Label label_1;
  internal NumericUpDown numericUpDown_0;
  internal Label label_2;
  internal NumericUpDown numericUpDown_1;
  internal Label label_3;
  internal Label label_4;
  internal NumericUpDown numericUpDown_2;
  internal NumericUpDown numericUpDown_3;
  internal Label label_5;
  internal Panel panel_2;
  internal Label label_6;
  internal Button button_0;
  internal NumericUpDown numericUpDown_4;
  internal Label label_7;
  internal Panel panel_3;
  internal Button button_1;
  internal NumericUpDown numericUpDown_5;
  internal NumericUpDown numericUpDown_6;
  internal RadioButton radioButton_2;
  internal RadioButton radioButton_3;
  internal Label label_8;
  internal Panel panel_4;
  internal NumericUpDown numericUpDown_7;
  internal RadioButton radioButton_4;
  internal Label label_9;
  internal RadioButton radioButton_5;
  internal RadioButton radioButton_6;
  internal Panel panel_5;
  internal Label label_10;
  internal RadioButton radioButton_7;
  internal RadioButton radioButton_8;
  internal Panel panel_6;
  internal RadioButton radioButton_9;
  internal Label label_11;
  internal Panel panel_7;
  internal CheckBox checkBox_0;
  internal Button button_2;
  internal CheckBox checkBox_1;
  internal Button button_3;
  internal CheckBox checkBox_2;
  internal Button button_4;
  internal CheckBox checkBox_3;
  internal Button button_5;
  internal CheckBox checkBox_4;
  internal Button button_6;
  internal CheckBox checkBox_5;
  internal Label label_12;
  internal NumericUpDown numericUpDown_8;
  internal Label label_13;
  internal CheckBox checkBox_6;
  internal Panel panel_8;
  internal Label label_14;
  internal RadioButton radioButton_10;
  internal RadioButton radioButton_11;
  internal PictureBox pictureBox_0;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  internal Label label_15;
  internal Label label_16;

  public F_MwTriangleMeshRough() => Class39.smethod_458(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.UpdateControlFromType();
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
  }

  internal void method_0(object sender, FormClosingEventArgs e)
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

  internal void method_1(object sender, EventArgs e)
  {
    this.Apply();
    this.Properties.Result = DialogResult.OK;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_2(object sender, EventArgs e)
  {
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void UpdateControlFromType()
  {
  }

  public void Apply()
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
