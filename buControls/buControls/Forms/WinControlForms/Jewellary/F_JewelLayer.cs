// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Jewellary.F_JewelLayer
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buClass.Apps;
using buControls.ColorPicker;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Jewellary;

public class F_JewelLayer : Form
{
  public static List<string> Captions = new List<string>();
  public LayerBase Layer = new LayerBase();
  public List<ToolBase> Tools = new List<ToolBase>();
  public List<JewelVar> Modes = new List<JewelVar>();
  public DialogResult Result = DialogResult.None;
  private IContainer icontainer_0 = (IContainer) null;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  internal buColorComboBox buColorComboBox_0;
  internal CheckBox checkBox_0;
  internal Label label_1;
  internal TextBox textBox_0;
  internal Label label_2;
  internal Label label_3;
  public Button btn_cancel;
  public Button btn_ok;
  internal ComboBox comboBox_0;
  internal Label label_4;
  internal Label label_5;
  internal NumericUpDown numericUpDown_1;
  internal ComboBox comboBox_1;
  internal Label label_6;

  public F_JewelLayer() => Class39.smethod_202(this);

  public void Init()
  {
    this.buColorComboBox_0.Color = this.Layer.LayerColor;
    this.numericUpDown_0.Value = (Decimal) this.Layer.LayerThickness;
    this.textBox_0.Text = this.Layer.Name;
    this.checkBox_0.Checked = this.Layer.Enable;
    if (this.Layer.Jewelary != null)
    {
      this.numericUpDown_1.Value = (Decimal) this.Layer.Jewelary.Depth;
      this.comboBox_1.Enabled = true;
    }
    this.comboBox_0.Enabled = true;
    this.comboBox_1.Items.Clear();
    if (this.Modes != null)
    {
      for (int index = 0; index <= this.Modes.Count - 1; ++index)
        this.comboBox_1.Items.Add((object) this.Modes[index].ModeName);
      this.comboBox_1.Text = this.Layer.Jewelary.JewelMode.ModeName;
      if (this.Layer.Jewelary.JewelMode.ModeName.Trim().Length == 0 && this.Modes.Count > 0)
        this.comboBox_1.Text = this.Modes[0].ModeName;
    }
    if (this.comboBox_1.Items.Count == 0)
      this.comboBox_1.Enabled = false;
    this.comboBox_0.Items.Clear();
    ToolBase toolBase = (ToolBase) null;
    for (int index = 0; index <= this.Tools.Count - 1; ++index)
    {
      if (this.Layer.ToolSelected.Data.No == this.Tools[index].Data.No & this.Layer.ToolSelected.Data.Name == this.Tools[index].Data.Name)
        toolBase = new ToolBase(this.Tools[index]);
      this.comboBox_0.Items.Add((object) $"T{this.Tools[index].Data.No.ToString()} - {this.Tools[index].Data.Name}");
    }
    if (toolBase != null)
      this.comboBox_0.Text = $"T{toolBase.Data.No.ToString()} - {toolBase.Data.Name}";
    else if (this.Tools.Count > 0)
      this.comboBox_0.Text = $"T{this.Tools[0].Data.No.ToString()} - {this.Tools[0].Data.Name}";
    if (this.comboBox_0.Items.Count == 0)
      this.comboBox_0.Enabled = false;
    this.LoadLanguage();
  }

  public void LoadLanguage()
  {
    string callMethod = "Layer LoadLanguage";
    try
    {
      if (F_JewelLayer.Captions.Count <= 6)
        return;
      this.Text = F_JewelLayer.Captions[0];
      this.label_2.Text = F_JewelLayer.Captions[1];
      this.label_3.Text = F_JewelLayer.Captions[2];
      this.label_1.Text = F_JewelLayer.Captions[4];
      this.label_0.Text = F_JewelLayer.Captions[5];
      this.label_5.Text = F_JewelLayer.Captions[8];
      this.label_4.Text = F_JewelLayer.Captions[9];
      this.btn_ok.Text = F_JewelLayer.Captions[10];
      this.btn_cancel.Text = F_JewelLayer.Captions[11];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void method_0(object sender, EventArgs e)
  {
    if (this.numericUpDown_0.Value > 0M)
      this.Layer.LayerThickness = (float) this.numericUpDown_0.Value;
    this.Layer.LayerColor = this.buColorComboBox_0.Color;
    this.Layer.Enable = this.checkBox_0.Checked;
    this.Layer.Name = this.textBox_0.Text;
    if (this.comboBox_0.SelectedIndex >= 0 & this.comboBox_0.SelectedIndex <= this.Tools.Count - 1)
      this.Layer.ToolSelected = new ToolBase(this.Tools[this.comboBox_0.SelectedIndex]);
    if (this.Layer.Jewelary != null)
    {
      if (this.comboBox_1.SelectedIndex >= 0 & this.comboBox_1.SelectedIndex <= this.Modes.Count - 1)
      {
        this.Layer.Jewelary.JewelMode = new JewelVar(this.Modes[this.comboBox_1.SelectedIndex]);
        this.Layer.Jewelary.ModeName = this.Layer.Jewelary.JewelMode.ModeName;
        this.Layer.Jewelary.ModeIndex = this.comboBox_1.SelectedIndex;
      }
      this.Layer.Jewelary.Depth = (double) this.numericUpDown_1.Value;
    }
    this.Result = DialogResult.OK;
    this.Dispose();
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.Result = DialogResult.Cancel;
    this.Dispose();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
