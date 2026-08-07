// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Tools.F_ToolDiemaker
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buCore;
using ns7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Tools;

public class F_ToolDiemaker : Form
{
  public static List<string> Captions = new List<string>();
  public DialogResult Result = DialogResult.None;
  public ToolBase Value = new ToolBase();
  internal IContainer icontainer_0 = (IContainer) null;
  public Button btn_ok;
  internal ImageList imageList_0;
  public Button btn_cancel;
  internal ComboBox comboBox_0;
  internal Label label_0;
  internal Label label_1;
  internal NumericUpDown numericUpDown_0;
  internal Label label_2;
  internal NumericUpDown numericUpDown_1;
  internal Label label_3;
  internal NumericUpDown numericUpDown_2;
  internal Label label_4;
  internal NumericUpDown numericUpDown_3;
  internal Label label_5;
  internal TextBox textBox_0;
  internal CheckBox checkBox_0;
  internal Label label_6;
  internal Label label_7;
  internal CheckBox checkBox_1;
  internal Label label_8;
  internal CheckBox checkBox_2;
  internal Label label_9;
  internal CheckBox checkBox_3;
  internal Label label_10;
  internal NumericUpDown numericUpDown_4;
  internal Label label_11;
  internal Label label_12;
  internal Label label_13;
  internal Label label_14;
  internal Label label_15;
  internal CheckBox checkBox_4;
  internal CheckBox checkBox_5;
  internal CheckBox checkBox_6;
  internal CheckBox checkBox_7;
  internal CheckBox checkBox_8;
  internal Label label_16;
  internal NumericUpDown numericUpDown_5;

  public F_ToolDiemaker() => Class39.smethod_497(this);

  public void Init(ToolBase tool)
  {
    this.Value = new ToolBase(tool);
    this.textBox_0.Text = this.Value.Data.Name;
    this.numericUpDown_3.Value = (Decimal) this.Value.Data.No;
    this.numericUpDown_2.Value = (Decimal) this.Value.Diemaker.NickDiameter;
    this.numericUpDown_1.Value = (Decimal) this.Value.Diemaker.Width;
    this.numericUpDown_5.Value = (Decimal) this.Value.Diemaker.BridgeHeight;
    this.numericUpDown_0.Value = (Decimal) this.Value.Diemaker.ID;
    this.numericUpDown_4.Value = (Decimal) this.Value.Diemaker.PositionOffset;
    this.checkBox_0.Checked = this.Value.Diemaker.Cutting;
    this.checkBox_1.Checked = this.Value.Diemaker.Creasing;
    this.checkBox_2.Checked = this.Value.Diemaker.Perfo;
    this.checkBox_3.Checked = this.Value.Diemaker.CutCrease;
    this.checkBox_7.Checked = this.Value.Diemaker.Pt1;
    this.checkBox_6.Checked = this.Value.Diemaker.Pt2;
    this.checkBox_5.Checked = this.Value.Diemaker.Pt3;
    this.checkBox_4.Checked = this.Value.Diemaker.Pt4;
    this.checkBox_8.Checked = this.Value.Diemaker.Pt6;
    ArrayList EnumItems = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Value.Diemaker.Mode, ref EnumItems);
    buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32((object) this.Value.Diemaker.Mode), ref this.comboBox_0);
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "ToolDiemaker LoadLanguage";
    try
    {
      if (F_ToolDiemaker.Captions.Count < 15)
        return;
      this.Text = F_ToolDiemaker.Captions[0];
      this.label_5.Text = F_ToolDiemaker.Captions[1];
      this.label_4.Text = F_ToolDiemaker.Captions[2];
      this.label_0.Text = F_ToolDiemaker.Captions[3];
      this.label_6.Text = F_ToolDiemaker.Captions[4];
      this.label_7.Text = F_ToolDiemaker.Captions[5];
      this.label_8.Text = F_ToolDiemaker.Captions[6];
      this.label_9.Text = F_ToolDiemaker.Captions[7];
      this.label_1.Text = F_ToolDiemaker.Captions[8];
      this.label_2.Text = F_ToolDiemaker.Captions[9];
      this.label_16.Text = F_ToolDiemaker.Captions[10];
      this.label_10.Text = F_ToolDiemaker.Captions[11];
      this.label_3.Text = F_ToolDiemaker.Captions[12];
      this.btn_ok.Text = F_ToolDiemaker.Captions[13];
      this.btn_cancel.Text = F_ToolDiemaker.Captions[14];
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
    this.Value.Data.Name = this.textBox_0.Text;
    this.Value.Data.No = (int) this.numericUpDown_3.Value;
    this.Value.Diemaker.NickDiameter = (double) this.numericUpDown_2.Value;
    this.Value.Diemaker.Width = (double) this.numericUpDown_1.Value;
    this.Value.Diemaker.BridgeHeight = (double) this.numericUpDown_5.Value;
    this.Value.Diemaker.PositionOffset = (double) this.numericUpDown_4.Value;
    this.Value.Diemaker.ID = (double) (int) this.numericUpDown_0.Value;
    this.Value.Diemaker.Cutting = this.checkBox_0.Checked;
    this.Value.Diemaker.Creasing = this.checkBox_1.Checked;
    this.Value.Diemaker.Perfo = this.checkBox_2.Checked;
    this.Value.Diemaker.CutCrease = this.checkBox_3.Checked;
    this.Value.Diemaker.Pt1 = this.checkBox_7.Checked;
    this.Value.Diemaker.Pt2 = this.checkBox_6.Checked;
    this.Value.Diemaker.Pt3 = this.checkBox_5.Checked;
    this.Value.Diemaker.Pt4 = this.checkBox_4.Checked;
    this.Value.Diemaker.Pt6 = this.checkBox_8.Checked;
    this.Value.Diemaker.Mode = (DiemakerToolModeType) buGeneral.EnumValueFromInt((object) this.Value.Diemaker.Mode, this.comboBox_0.SelectedIndex);
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
