// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Tools.F_ToolTypeSaw
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.ColorPicker;
using buCore;
using ns7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Tools;

public class F_ToolTypeSaw : Form
{
  public static List<string> Captions = new List<string>();
  public DialogResult Result = DialogResult.None;
  public ToolBase Value = new ToolBase();
  internal IContainer icontainer_0 = (IContainer) null;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;
  internal ComboBox comboBox_0;
  internal Label label_0;
  internal Label label_1;
  internal buColorComboBox buColorComboBox_0;
  internal Label label_2;
  internal buColorComboBox buColorComboBox_1;
  internal Label label_3;
  internal NumericUpDown numericUpDown_0;
  internal Label label_4;
  internal NumericUpDown numericUpDown_1;
  internal Label label_5;
  internal NumericUpDown numericUpDown_2;
  internal Label label_6;
  internal NumericUpDown numericUpDown_3;
  internal Label label_7;
  internal NumericUpDown numericUpDown_4;
  internal Label label_8;
  internal NumericUpDown numericUpDown_5;
  internal Label label_9;
  internal TextBox textBox_0;
  internal Label label_10;
  internal ComboBox comboBox_1;
  internal Label label_11;
  internal buColorComboBox buColorComboBox_2;
  internal ComboBox comboBox_2;
  internal Label label_12;

  public F_ToolTypeSaw() => Class39.smethod_153(this);

  public void Init(ToolBase tool)
  {
    this.Value = new ToolBase(tool);
    this.textBox_0.Text = this.Value.Data.Name;
    this.numericUpDown_5.Value = (Decimal) this.Value.Data.No;
    this.numericUpDown_4.Value = (Decimal) this.Value.Geometry.Thickness;
    this.numericUpDown_3.Value = (Decimal) this.Value.Geometry.Diameter;
    this.numericUpDown_2.Value = (Decimal) this.Value.CamData.SpindleSpeed;
    this.numericUpDown_1.Value = (Decimal) this.Value.CamData.FeedSpeed;
    this.numericUpDown_0.Value = (Decimal) this.Value.CamData.PlungeSpeed;
    this.buColorComboBox_2.Color = this.Value.Display.Solid.SkinColor;
    this.buColorComboBox_1.Color = this.Value.Display.CamColor;
    this.buColorComboBox_0.Color = this.Value.Display.UpperCamColor;
    ArrayList EnumItems1 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Value.CamData.SpindleDirection, ref EnumItems1);
    buControlCommands.ComboboxAddItem(EnumItems1, Convert.ToInt32((object) this.Value.CamData.SpindleDirection), ref this.comboBox_1);
    ArrayList EnumItems2 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Value.Purpose, ref EnumItems2);
    buControlCommands.ComboboxAddItem(EnumItems2, Convert.ToInt32((object) this.Value.Purpose), ref this.comboBox_0);
    ArrayList EnumItems3 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Value.Geometry.GeometryType, ref EnumItems3);
    buControlCommands.ComboboxAddItem(EnumItems3, Convert.ToInt32((object) this.Value.Geometry.GeometryType), ref this.comboBox_2);
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "ToolTypeSaw LoadLanguage";
    try
    {
      if (F_ToolTypeSaw.Captions.Count < 16 /*0x10*/)
        return;
      this.Text = F_ToolTypeSaw.Captions[0];
      this.label_9.Text = F_ToolTypeSaw.Captions[1];
      this.label_8.Text = F_ToolTypeSaw.Captions[2];
      this.label_7.Text = F_ToolTypeSaw.Captions[3];
      this.label_6.Text = F_ToolTypeSaw.Captions[4];
      this.label_5.Text = F_ToolTypeSaw.Captions[5];
      this.label_11.Text = F_ToolTypeSaw.Captions[6];
      this.label_4.Text = F_ToolTypeSaw.Captions[7];
      this.label_3.Text = F_ToolTypeSaw.Captions[8];
      this.label_10.Text = F_ToolTypeSaw.Captions[9];
      this.label_2.Text = F_ToolTypeSaw.Captions[10];
      this.label_1.Text = F_ToolTypeSaw.Captions[11];
      this.label_0.Text = F_ToolTypeSaw.Captions[12];
      this.label_12.Text = F_ToolTypeSaw.Captions[13];
      this.btn_ok.Text = F_ToolTypeSaw.Captions[14];
      this.btn_cancel.Text = F_ToolTypeSaw.Captions[15];
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
    this.Value.Data.No = (int) this.numericUpDown_5.Value;
    this.Value.Geometry.Thickness = (double) this.numericUpDown_4.Value;
    this.Value.Geometry.Diameter = (double) this.numericUpDown_3.Value;
    this.Value.CamData.SpindleSpeed = (double) this.numericUpDown_2.Value;
    this.Value.CamData.FeedSpeed = (double) this.numericUpDown_1.Value;
    this.Value.CamData.PlungeSpeed = (double) this.numericUpDown_0.Value;
    this.Value.Geometry.GeometryType = (ToolType) buGeneral.EnumValueFromInt((object) this.Value.Geometry.GeometryType, this.comboBox_2.SelectedIndex);
    this.Value.Purpose = (ToolPurpose) buGeneral.EnumValueFromInt((object) this.Value.Purpose, this.comboBox_0.SelectedIndex);
    this.Value.CamData.SpindleDirection = (ClockDirectionType) buGeneral.EnumValueFromInt((object) this.Value.CamData.SpindleDirection, this.comboBox_1.SelectedIndex);
    this.Value.Display.Solid.SkinColor = this.buColorComboBox_2.Color;
    this.Value.Display.CamColor = this.buColorComboBox_1.Color;
    this.Value.Display.UpperCamColor = this.buColorComboBox_0.Color;
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
