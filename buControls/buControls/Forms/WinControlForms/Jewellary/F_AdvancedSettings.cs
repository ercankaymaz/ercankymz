// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Jewellary.F_AdvancedSettings
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buClass.Apps;
using buCore;
using ns7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Jewellary;

public class F_AdvancedSettings : Form
{
  public static List<string> Captions = new List<string>();
  public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;
  public JewelVar ParJewel = new JewelVar();
  public DialogResult Result = DialogResult.None;
  private IContainer icontainer_0 = (IContainer) null;
  internal Panel panel_0;
  internal Button button_0;
  internal Button button_1;
  internal Label label_0;
  internal CheckBox checkBox_0;
  internal Panel panel_1;
  internal NumericUpDown numericUpDown_0;
  internal Label label_1;
  internal NumericUpDown numericUpDown_1;
  internal Label label_2;
  internal NumericUpDown numericUpDown_2;
  internal Label label_3;
  internal Label label_4;
  internal NumericUpDown numericUpDown_3;
  internal Label label_5;
  internal NumericUpDown numericUpDown_4;
  internal Label label_6;
  internal NumericUpDown numericUpDown_5;
  internal Label label_7;
  internal NumericUpDown numericUpDown_6;
  internal Label label_8;
  internal ComboBox comboBox_0;
  internal Label label_9;
  internal ComboBox comboBox_1;
  internal Label label_10;
  internal ComboBox comboBox_2;
  internal Label label_11;
  internal Panel panel_2;
  internal NumericUpDown numericUpDown_7;
  internal Label label_12;
  internal NumericUpDown numericUpDown_8;
  internal Label label_13;
  internal NumericUpDown numericUpDown_9;
  internal Label label_14;
  internal NumericUpDown numericUpDown_10;
  internal Label label_15;
  internal NumericUpDown numericUpDown_11;
  internal Label label_16;
  internal Label label_17;
  internal Button button_2;
  internal Button button_3;
  internal Label label_18;
  internal NumericUpDown numericUpDown_12;
  internal Label label_19;
  internal NumericUpDown numericUpDown_13;
  internal Label label_20;
  internal NumericUpDown numericUpDown_14;
  internal Label label_21;
  internal NumericUpDown numericUpDown_15;
  internal Label label_22;
  internal CheckBox checkBox_1;
  internal CheckBox checkBox_2;

  public F_AdvancedSettings() => Class39.smethod_818(this);

  public void Init()
  {
    this.numericUpDown_1.Value = (Decimal) this.ParJewel.JewelCamProp.G0CalculationWithFollowingSurfaceZOffset;
    this.numericUpDown_0.Value = (Decimal) this.ParJewel.JewelCamProp.G0CalculationWithFollowingSurfaceSpeed;
    this.numericUpDown_12.Value = (Decimal) this.ParJewel.JewelCamProp.Leave5AxisSpeed;
    this.numericUpDown_6.Value = (Decimal) this.ParJewel.JewelMode.RingRotateCenterX;
    this.numericUpDown_5.Value = (Decimal) this.ParJewel.JewelMode.RingRotateCenterZ;
    this.numericUpDown_4.Value = (Decimal) this.ParJewel.JewelMode.BraceletRotateCenterX;
    this.numericUpDown_3.Value = (Decimal) this.ParJewel.JewelMode.BraceletRotateCenterZ;
    this.numericUpDown_15.Value = (Decimal) this.ParJewel.JewelCamProp.AirZ;
    this.numericUpDown_14.Value = (Decimal) this.ParJewel.JewelCamProp.SafeAbsZ;
    this.numericUpDown_13.Value = (Decimal) this.ParJewel.JewelCamProp.SafeIncZ;
    this.checkBox_1.Checked = this.ParJewel.JewelCamProp.ZSafeAbsoluteMode;
    this.checkBox_2.Checked = this.ParJewel.JewelCamProp.BValueEffectedByZDepth;
    this.numericUpDown_11.Value = (Decimal) this.ParJewel.JewelMode.SpindleSpeed;
    this.numericUpDown_10.Value = (Decimal) this.ParJewel.JewelMode.EngravingSpeed;
    this.numericUpDown_8.Value = (Decimal) this.ParJewel.JewelMode.DiamondCutSpeed1;
    this.numericUpDown_7.Value = (Decimal) this.ParJewel.JewelMode.DiamondCutSpeed2;
    this.numericUpDown_9.Value = (Decimal) this.ParJewel.JewelMode.LatheSpeed;
    this.checkBox_0.Checked = this.ParJewel.JewelCamProp.G0CalculationWithFollowingSurfaceEnable;
    ArrayList EnumItems1 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.ParJewel.JewelMode.CamCoreMoveUpType, ref EnumItems1);
    buControlCommands.ComboboxAddItem(EnumItems1, Convert.ToInt32((object) this.ParJewel.JewelMode.CamCoreMoveUpType), ref this.comboBox_1);
    ArrayList EnumItems2 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.ParJewel.SortNextGRoupRules, ref EnumItems2);
    buControlCommands.ComboboxAddItem(EnumItems2, Convert.ToInt32((object) this.ParJewel.SortNextGRoupRules), ref this.comboBox_0);
    ArrayList EnumItems3 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.ParJewel.JewelScaleProp.Method, ref EnumItems3);
    buControlCommands.ComboboxAddItem(EnumItems3, Convert.ToInt32((object) this.ParJewel.JewelScaleProp.Method), ref this.comboBox_2);
    this.button_1.BackColor = Color.Silver;
    this.button_0.BackColor = Color.Silver;
    if (this.ParJewel.JewelMode.MaterialMode == jewelMaterialType.Ring)
      this.button_1.BackColor = Color.Cyan;
    if (this.ParJewel.JewelMode.MaterialMode == jewelMaterialType.Bracelet)
      this.button_0.BackColor = Color.Cyan;
    Class39.smethod_65(this);
  }

  internal void method_0(object sender, EventArgs e)
  {
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
    this.button_1.BackColor = Color.Silver;
    this.button_0.BackColor = Color.Silver;
    if (control2.Name == this.button_1.Name)
      this.ParJewel.JewelMode.MaterialMode = jewelMaterialType.Ring;
    if (control2.Name == this.button_0.Name)
      this.ParJewel.JewelMode.MaterialMode = jewelMaterialType.Bracelet;
    if (this.ParJewel.JewelMode.MaterialMode == jewelMaterialType.Ring)
      this.button_1.BackColor = Color.Cyan;
    if (this.ParJewel.JewelMode.MaterialMode != jewelMaterialType.Bracelet)
      return;
    this.button_0.BackColor = Color.Cyan;
  }

  internal void method_2(object sender, EventArgs e)
  {
    this.ParJewel.JewelCamProp.G0CalculationWithFollowingSurfaceZOffset = (double) this.numericUpDown_1.Value;
    this.ParJewel.JewelCamProp.G0CalculationWithFollowingSurfaceSpeed = (double) this.numericUpDown_0.Value;
    this.ParJewel.JewelCamProp.Leave5AxisSpeed = (double) this.numericUpDown_12.Value;
    this.ParJewel.JewelMode.RingRotateCenterX = (double) this.numericUpDown_6.Value;
    this.ParJewel.JewelMode.RingRotateCenterZ = (double) this.numericUpDown_5.Value;
    this.ParJewel.JewelMode.BraceletRotateCenterX = (double) this.numericUpDown_4.Value;
    this.ParJewel.JewelMode.BraceletRotateCenterZ = (double) this.numericUpDown_3.Value;
    this.ParJewel.JewelMode.SpindleSpeed = (double) this.numericUpDown_11.Value;
    this.ParJewel.JewelMode.EngravingSpeed = (double) this.numericUpDown_10.Value;
    this.ParJewel.JewelMode.DiamondCutSpeed1 = (double) this.numericUpDown_8.Value;
    this.ParJewel.JewelMode.DiamondCutSpeed2 = (double) this.numericUpDown_7.Value;
    this.ParJewel.JewelMode.LatheSpeed = (double) this.numericUpDown_9.Value;
    this.ParJewel.JewelCamProp.G0CalculationWithFollowingSurfaceEnable = this.checkBox_0.Checked;
    this.ParJewel.JewelCamProp.BValueEffectedByZDepth = this.checkBox_2.Checked;
    this.ParJewel.JewelCamProp.AirZ = (double) this.numericUpDown_15.Value;
    this.ParJewel.JewelCamProp.SafeAbsZ = (double) this.numericUpDown_14.Value;
    this.ParJewel.JewelCamProp.SafeIncZ = (double) this.numericUpDown_13.Value;
    this.ParJewel.JewelCamProp.ZSafeAbsoluteMode = this.checkBox_1.Checked;
    this.ParJewel.JewelMode.CamCoreMoveUpType = (CamMoveUpType) buGeneral.EnumValueFromInt((object) this.ParJewel.JewelMode.CamCoreMoveUpType, this.comboBox_1.SelectedIndex);
    this.ParJewel.JewelScaleProp.Method = (jewelScaleMehod) buGeneral.EnumValueFromInt((object) this.ParJewel.JewelScaleProp.Method, this.comboBox_2.SelectedIndex);
    this.ParJewel.SortNextGRoupRules = (SortingNextGroupFindRulesType) buGeneral.EnumValueFromInt((object) this.ParJewel.SortNextGRoupRules, this.comboBox_0.SelectedIndex);
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
