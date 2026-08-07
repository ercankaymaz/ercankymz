// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Layer.F_Layer
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.DialogBox;
using buCore;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Layer;

public class F_Layer : Form
{
  public static List<string> Captions = new List<string>();
  public LayerBase Value = new LayerBase();
  public List<drawingPattern> Patterns = new List<drawingPattern>();
  public List<ToolBase> Tools = new List<ToolBase>();
  public DialogResult Result = DialogResult.None;
  private IContainer icontainer_0 = (IContainer) null;
  internal ComboBox comboBox_0;
  internal Label label_0;
  internal Label label_1;
  internal NumericUpDown numericUpDown_0;
  internal CheckBox checkBox_0;
  internal Label label_2;
  internal TextBox textBox_0;
  internal Label label_3;
  internal Label label_4;
  internal Label label_5;
  internal CheckBox checkBox_1;
  internal Label label_6;
  internal TextBox textBox_1;
  public Button btn_cancel;
  public Button btn_ok;
  internal ComboBox comboBox_1;
  internal Label label_7;
  internal Label label_8;
  internal NumericUpDown numericUpDown_1;
  internal Label label_9;
  internal NumericUpDown numericUpDown_2;
  internal Label label_10;

  public F_Layer() => Class39.smethod_609(this);

  public void Init(List<drawingPattern> pattern, List<ToolBase> tool)
  {
    this.label_10.BackColor = this.Value.LayerColor;
    this.label_10.Text = buImage.GetColorKnownName(this.Value.LayerColor);
    this.label_10.ForeColor = buImage.InvertColorNoGray(this.Value.LayerColor);
    this.numericUpDown_0.Value = (Decimal) this.Value.LayerThickness;
    this.numericUpDown_2.Value = (Decimal) this.Value.Transparency;
    this.textBox_0.Text = this.Value.Name;
    this.textBox_1.Text = this.Value.Tag;
    this.checkBox_0.Checked = this.Value.Enable;
    this.checkBox_1.Checked = this.Value.Lock;
    this.comboBox_0.Enabled = true;
    this.comboBox_1.Enabled = true;
    this.Patterns.Clear();
    this.Tools.Clear();
    if (pattern != null)
    {
      for (int index = 0; index <= pattern.Count - 1; ++index)
        this.Patterns.Add(new drawingPattern(pattern[index]));
    }
    for (int index = 0; index <= tool.Count - 1; ++index)
      this.Tools.Add(new ToolBase(tool[index]));
    this.comboBox_0.Items.Clear();
    if (this.Patterns != null)
    {
      for (int index = 0; index <= this.Patterns.Count - 1; ++index)
        this.comboBox_0.Items.Add((object) this.Patterns[index].Name);
      this.comboBox_0.Text = this.Value.Pattern.Name;
      if (this.comboBox_0.Items.Count == 0)
        this.comboBox_0.Enabled = false;
    }
    else
      this.comboBox_0.Enabled = false;
    this.comboBox_1.Items.Clear();
    for (int index = 0; index <= this.Tools.Count - 1; ++index)
      this.comboBox_1.Items.Add((object) $"T{this.Tools[index].Data.No.ToString()} - {this.Tools[index].Data.Name}");
    this.comboBox_1.Text = $"T{this.Value.Cam.CamTool.Data.No.ToString()} - {this.Value.Cam.CamTool.Data.Name}";
    if (this.comboBox_1.Items.Count == 0)
      this.comboBox_1.Enabled = false;
    this.LoadLanguage();
  }

  public void LoadLanguage()
  {
    string callMethod = "Layer LoadLanguage";
    try
    {
      if (F_Layer.Captions.Count <= 6)
        return;
      this.Text = F_Layer.Captions[0];
      this.label_3.Text = F_Layer.Captions[1];
      this.label_4.Text = F_Layer.Captions[2];
      this.label_5.Text = F_Layer.Captions[3];
      this.label_2.Text = F_Layer.Captions[4];
      this.label_1.Text = F_Layer.Captions[5];
      this.label_0.Text = F_Layer.Captions[6];
      this.label_6.Text = F_Layer.Captions[7];
      this.label_8.Text = F_Layer.Captions[8];
      this.label_7.Text = F_Layer.Captions[9];
      this.btn_ok.Text = F_Layer.Captions[10];
      this.btn_cancel.Text = F_Layer.Captions[11];
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
      this.Value.LayerThickness = (float) this.numericUpDown_0.Value;
    this.Value.Transparency = (int) this.numericUpDown_2.Value;
    this.Value.LayerColor = this.label_10.BackColor;
    this.Value.Enable = this.checkBox_0.Checked;
    this.Value.Lock = this.checkBox_1.Checked;
    this.Value.Name = this.textBox_0.Text;
    this.Value.Tag = this.textBox_1.Text;
    for (int index = 0; index <= this.Patterns.Count - 1; ++index)
    {
      if (this.Patterns[index].Name == this.comboBox_0.Text)
        this.Value.Pattern = new drawingPattern(this.Patterns[index]);
    }
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
    ColorDialogBox.ShowDialog(this.label_10.BackColor);
    if (ColorDialogBox.Result != DialogResult.OK)
      return;
    this.label_10.BackColor = ColorDialogBox.Color;
    this.label_10.ForeColor = buImage.InvertColorNoGray(this.label_10.BackColor);
    this.label_10.Text = buImage.GetColorKnownName(this.label_10.BackColor);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
