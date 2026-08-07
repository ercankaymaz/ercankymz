// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Materials.F_MaterialList
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.ColorPicker;
using buCore;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Materials;

public class F_MaterialList : Form
{
  public static List<string> Captions = new List<string>();
  public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;
  public DialogResult Result = DialogResult.None;
  public List<MaterialSkin> Materials = new List<MaterialSkin>();
  private bool bool_0 = false;
  internal IContainer icontainer_0 = (IContainer) null;
  public Button btn_cancel;
  internal ImageList imageList_0;
  public Button btn_ok;
  internal Label label_0;
  internal buColorComboBox buColorComboBox_0;
  internal TextBox textBox_0;
  internal Label label_1;
  internal ListBox listBox_0;
  public Button btn_update;
  public Button btn_remove;
  public Button btn_add;

  public F_MaterialList() => Class39.smethod_712(this);

  public void Init()
  {
    this.bool_0 = false;
    this.Result = DialogResult.None;
    this.listBox_0.Items.Clear();
    for (int index = 0; index <= this.Materials.Count - 1; ++index)
      this.listBox_0.Items.Add((object) this.Materials[index].Name);
    this.bool_0 = true;
    if (this.listBox_0.Items.Count > 0)
      this.listBox_0.SelectedIndex = 0;
    Class39.smethod_250(this);
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
    if (control2.Name == this.btn_add.Name)
    {
      MaterialSkin materialSkin = new MaterialSkin();
      materialSkin.Name = this.textBox_0.Text;
      materialSkin.MaterialColor = this.buColorComboBox_0.Color;
      this.Materials.Add(materialSkin);
      this.listBox_0.Items.Add((object) materialSkin.Name);
    }
    if (control2.Name == this.btn_remove.Name && this.listBox_0.SelectedIndex >= 0 & this.listBox_0.SelectedIndex <= this.Materials.Count - 1 && buString.MessageBoxQuestion(AppLanguage.SystemMessages[12]) == DialogResult.Yes)
    {
      this.Materials.RemoveAt(this.listBox_0.SelectedIndex);
      this.listBox_0.Items.RemoveAt(this.listBox_0.SelectedIndex);
    }
    if (control2.Name == this.btn_update.Name && this.listBox_0.SelectedIndex >= 0 & this.listBox_0.SelectedIndex <= this.Materials.Count - 1 && buString.MessageBoxQuestion(AppLanguage.SystemMessages[13]) == DialogResult.Yes)
    {
      this.Materials[this.listBox_0.SelectedIndex].Name = this.textBox_0.Text;
      this.Materials[this.listBox_0.SelectedIndex].MaterialColor = this.buColorComboBox_0.Color;
      this.listBox_0.Items[this.listBox_0.SelectedIndex] = (object) this.textBox_0.Text;
    }
    if (control2.Name == this.btn_cancel.Name)
    {
      this.Result = DialogResult.Cancel;
      if (this.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == this.btn_ok.Name))
      return;
    this.Result = DialogResult.OK;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_2(object sender, EventArgs e)
  {
    if (!this.bool_0 || !(this.listBox_0.SelectedIndex >= 0 & this.listBox_0.SelectedIndex <= this.Materials.Count - 1))
      return;
    this.textBox_0.Text = this.Materials[this.listBox_0.SelectedIndex].Name;
    this.buColorComboBox_0.Color = this.Materials[this.listBox_0.SelectedIndex].MaterialColor;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
