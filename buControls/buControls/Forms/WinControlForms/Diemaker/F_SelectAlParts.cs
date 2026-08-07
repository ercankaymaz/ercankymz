// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Diemaker.F_SelectAlParts
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buClass.Apps;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Diemaker;

public class F_SelectAlParts : Form
{
  public static List<string> Captions = new List<string>();
  public DialogResult Result = DialogResult.None;
  public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;
  public DiemakerSelectAllParts SelectAllVar = new DiemakerSelectAllParts();
  public Color colorActive = Color.DarkGray;
  public Color colorPassive = Color.WhiteSmoke;
  public bool EnablePt1 = false;
  private bool bool_0 = false;
  private IContainer icontainer_0 = (IContainer) null;
  internal Button button_0;
  internal Button button_1;
  internal Button button_2;
  internal Button button_3;
  internal CheckBox checkBox_0;
  internal CheckBox checkBox_1;
  internal CheckBox checkBox_2;
  internal CheckBox checkBox_3;
  internal ComboBox comboBox_0;
  internal CheckBox checkBox_4;
  internal CheckBox checkBox_5;
  internal PictureBox pictureBox_0;
  internal PictureBox pictureBox_1;
  internal PictureBox pictureBox_2;
  internal Button button_4;
  internal Button button_5;

  public F_SelectAlParts() => Class39.smethod_374(this);

  public void Init()
  {
    this.bool_0 = false;
    this.button_2.BackColor = this.colorPassive;
    this.button_1.BackColor = this.colorPassive;
    this.button_0.BackColor = this.colorPassive;
    this.button_3.BackColor = this.colorPassive;
    this.button_2.Enabled = this.EnablePt1;
    if (this.SelectAllVar.PtValue <= 1.0)
      this.button_2.BackColor = this.colorActive;
    if (this.SelectAllVar.PtValue == 2.0)
      this.button_1.BackColor = this.colorActive;
    if (this.SelectAllVar.PtValue == 3.0)
      this.button_0.BackColor = this.colorActive;
    if (this.SelectAllVar.PtValue >= 4.0)
      this.button_3.BackColor = this.colorActive;
    this.checkBox_0.Checked = this.SelectAllVar.SelectAll;
    this.checkBox_5.Checked = this.SelectAllVar.SelectHeight;
    this.checkBox_3.Checked = this.SelectAllVar.SelectAngle;
    this.checkBox_2.Checked = this.SelectAllVar.SelectHorizontal;
    this.checkBox_4.Checked = this.SelectAllVar.SelectNegative;
    this.checkBox_1.Checked = this.SelectAllVar.SelectVertical;
    this.Result = DialogResult.Cancel;
    this.bool_0 = true;
    Class39.smethod_506(this);
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.Result = DialogResult.Cancel;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    this.button_2.BackColor = this.colorPassive;
    this.button_1.BackColor = this.colorPassive;
    this.button_0.BackColor = this.colorPassive;
    this.button_3.BackColor = this.colorPassive;
    if (control2.Name == this.button_2.Name)
    {
      this.button_2.BackColor = this.colorActive;
      this.SelectAllVar.PtValue = 1.0;
    }
    if (control2.Name == this.button_1.Name)
    {
      this.button_1.BackColor = this.colorActive;
      this.SelectAllVar.PtValue = 2.0;
    }
    if (control2.Name == this.button_0.Name)
    {
      this.button_0.BackColor = this.colorActive;
      this.SelectAllVar.PtValue = 3.0;
    }
    if (!(control2.Name == this.button_3.Name))
      return;
    this.button_3.BackColor = this.colorActive;
    this.SelectAllVar.PtValue = 4.0;
  }

  internal void method_2(object sender, EventArgs e)
  {
    if (!this.bool_0 || !this.checkBox_0.Checked)
      return;
    this.checkBox_3.Checked = false;
    this.checkBox_5.Checked = false;
    this.checkBox_2.Checked = false;
    this.checkBox_4.Checked = false;
    this.checkBox_1.Checked = false;
  }

  internal void method_3(object sender, EventArgs e)
  {
    if (!this.bool_0 || !this.checkBox_1.Checked)
      return;
    this.checkBox_0.Checked = false;
  }

  internal void method_4(object sender, EventArgs e)
  {
    if (!this.bool_0 || !this.checkBox_2.Checked)
      return;
    this.checkBox_0.Checked = false;
  }

  internal void method_5(object sender, EventArgs e)
  {
    if (!this.bool_0 || !this.checkBox_3.Checked)
      return;
    this.checkBox_0.Checked = false;
  }

  internal void method_6(object sender, EventArgs e)
  {
    if (!this.bool_0 || !this.checkBox_4.Checked)
      return;
    this.checkBox_0.Checked = false;
  }

  internal void method_7(object sender, EventArgs e)
  {
    if (!this.bool_0 || !this.checkBox_5.Checked)
      return;
    this.checkBox_0.Checked = false;
  }

  internal void method_8(object sender, EventArgs e)
  {
    this.Result = DialogResult.Cancel;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_9(object sender, EventArgs e)
  {
    this.SelectAllVar.SelectAll = this.checkBox_0.Checked;
    this.SelectAllVar.SelectHeight = this.checkBox_5.Checked;
    this.SelectAllVar.SelectAngle = this.checkBox_3.Checked;
    this.SelectAllVar.SelectHorizontal = this.checkBox_2.Checked;
    this.SelectAllVar.SelectNegative = this.checkBox_4.Checked;
    this.SelectAllVar.SelectVertical = this.checkBox_1.Checked;
    if (!this.checkBox_3.Checked & !this.checkBox_5.Checked & !this.checkBox_2.Checked & !this.checkBox_4.Checked & !this.checkBox_1.Checked)
      this.SelectAllVar.SelectAll = true;
    this.Result = DialogResult.OK;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
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
