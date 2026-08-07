// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Tools.F_ToolPunch1
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

public class F_ToolPunch1 : Form
{
  public FormProperties Properties = new FormProperties();
  public static List<string> Captions = new List<string>();
  public List<ToolBase> Tools = new List<ToolBase>();
  public ToolAreaVisible ToolVarVisible = new ToolAreaVisible();
  internal IContainer icontainer_0 = (IContainer) null;
  internal PictureBox pictureBox_0;
  internal Panel panel_0;
  internal Label label_0;
  internal Label label_1;
  internal Label label_2;
  internal Label label_3;
  internal Label label_4;
  internal Label label_5;
  internal TextBox textBox_0;
  internal NumericUpDown numericUpDown_0;
  internal NumericUpDown numericUpDown_1;
  internal ComboBox comboBox_0;
  internal NumericUpDown numericUpDown_2;
  internal Panel panel_1;
  internal TextBox textBox_1;
  internal NumericUpDown numericUpDown_3;
  internal NumericUpDown numericUpDown_4;
  internal ComboBox comboBox_1;
  internal NumericUpDown numericUpDown_5;
  internal Label label_6;
  internal Label label_7;
  internal Label label_8;
  internal Label label_9;
  internal Label label_10;
  internal Label label_11;
  internal Panel panel_2;
  internal TextBox textBox_2;
  internal NumericUpDown numericUpDown_6;
  internal NumericUpDown numericUpDown_7;
  internal ComboBox comboBox_2;
  internal NumericUpDown numericUpDown_8;
  internal Label label_12;
  internal Label label_13;
  internal Label label_14;
  internal Label label_15;
  internal Label label_16;
  internal Label label_17;
  internal Panel panel_3;
  internal TextBox textBox_3;
  internal NumericUpDown numericUpDown_9;
  internal NumericUpDown numericUpDown_10;
  internal ComboBox comboBox_3;
  internal NumericUpDown numericUpDown_11;
  internal Label label_18;
  internal Label label_19;
  internal Label label_20;
  internal Label label_21;
  internal Panel panel_4;
  internal TextBox textBox_4;
  internal NumericUpDown numericUpDown_12;
  internal NumericUpDown numericUpDown_13;
  internal ComboBox comboBox_4;
  internal NumericUpDown numericUpDown_14;
  internal Label label_22;
  internal Label label_23;
  internal Label label_24;
  internal Label label_25;
  internal Panel panel_5;
  internal TextBox textBox_5;
  internal NumericUpDown numericUpDown_15;
  internal NumericUpDown numericUpDown_16;
  internal ComboBox comboBox_5;
  internal NumericUpDown numericUpDown_17;
  internal Label label_26;
  internal Label label_27;
  internal Label label_28;
  internal Label label_29;
  internal Label label_30;
  internal Label label_31;
  internal Panel panel_6;
  internal TextBox textBox_6;
  internal NumericUpDown numericUpDown_18;
  internal NumericUpDown numericUpDown_19;
  internal ComboBox comboBox_6;
  internal NumericUpDown numericUpDown_20;
  internal Label label_32;
  internal Label label_33;
  internal Label label_34;
  internal Label label_35;
  internal Label label_36;
  internal Label label_37;
  internal Panel panel_7;
  internal TextBox textBox_7;
  internal NumericUpDown numericUpDown_21;
  internal NumericUpDown numericUpDown_22;
  internal ComboBox comboBox_7;
  internal NumericUpDown numericUpDown_23;
  internal Label label_38;
  internal Label label_39;
  internal Label label_40;
  internal Label label_41;
  internal Label label_42;
  internal Label label_43;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;

  public F_ToolPunch1() => Class39.smethod_682(this);

  public void Init()
  {
    this.Properties.Inited = false;
    ArrayList arrayList = new ArrayList();
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    if (this.Tools.Count < 8)
    {
      for (int index = 0; index < 8 - this.Tools.Count; ++index)
        this.Tools.Add(new ToolBase());
    }
    ArrayList EnumItems1 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Tools[0].Geometry.FlatGeometry, ref EnumItems1);
    buControlCommands.ComboboxAddItem(EnumItems1, Convert.ToInt32((object) this.Tools[0].Geometry.FlatGeometry), ref this.comboBox_2);
    ArrayList EnumItems2 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Tools[1].Geometry.FlatGeometry, ref EnumItems2);
    buControlCommands.ComboboxAddItem(EnumItems2, Convert.ToInt32((object) this.Tools[1].Geometry.FlatGeometry), ref this.comboBox_4);
    EnumItems2 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Tools[2].Geometry.FlatGeometry, ref EnumItems2);
    buControlCommands.ComboboxAddItem(EnumItems2, Convert.ToInt32((object) this.Tools[2].Geometry.FlatGeometry), ref this.comboBox_5);
    EnumItems2 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Tools[3].Geometry.FlatGeometry, ref EnumItems2);
    buControlCommands.ComboboxAddItem(EnumItems2, Convert.ToInt32((object) this.Tools[3].Geometry.FlatGeometry), ref this.comboBox_0);
    EnumItems2 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Tools[4].Geometry.FlatGeometry, ref EnumItems2);
    buControlCommands.ComboboxAddItem(EnumItems2, Convert.ToInt32((object) this.Tools[4].Geometry.FlatGeometry), ref this.comboBox_3);
    EnumItems2 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Tools[5].Geometry.FlatGeometry, ref EnumItems2);
    buControlCommands.ComboboxAddItem(EnumItems2, Convert.ToInt32((object) this.Tools[5].Geometry.FlatGeometry), ref this.comboBox_7);
    EnumItems2 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Tools[6].Geometry.FlatGeometry, ref EnumItems2);
    buControlCommands.ComboboxAddItem(EnumItems2, Convert.ToInt32((object) this.Tools[6].Geometry.FlatGeometry), ref this.comboBox_1);
    EnumItems2 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Tools[7].Geometry.FlatGeometry, ref EnumItems2);
    buControlCommands.ComboboxAddItem(EnumItems2, Convert.ToInt32((object) this.Tools[7].Geometry.FlatGeometry), ref this.comboBox_6);
    this.textBox_2.Text = this.Tools[0].Data.Name;
    this.textBox_4.Text = this.Tools[1].Data.Name;
    this.textBox_5.Text = this.Tools[2].Data.Name;
    this.textBox_0.Text = this.Tools[3].Data.Name;
    this.textBox_3.Text = this.Tools[4].Data.Name;
    this.textBox_7.Text = this.Tools[5].Data.Name;
    this.textBox_1.Text = this.Tools[6].Data.Name;
    this.textBox_6.Text = this.Tools[7].Data.Name;
    this.numericUpDown_8.Value = (Decimal) this.Tools[0].Geometry.SizeWidth;
    this.numericUpDown_14.Value = (Decimal) this.Tools[1].Geometry.SizeWidth;
    this.numericUpDown_17.Value = (Decimal) this.Tools[2].Geometry.SizeWidth;
    this.numericUpDown_2.Value = (Decimal) this.Tools[3].Geometry.SizeWidth;
    this.numericUpDown_11.Value = (Decimal) this.Tools[4].Geometry.SizeWidth;
    this.numericUpDown_23.Value = (Decimal) this.Tools[5].Geometry.SizeWidth;
    this.numericUpDown_5.Value = (Decimal) this.Tools[6].Geometry.SizeWidth;
    this.numericUpDown_20.Value = (Decimal) this.Tools[7].Geometry.SizeWidth;
    this.numericUpDown_7.Value = (Decimal) this.Tools[0].Geometry.SizeDepth;
    this.numericUpDown_13.Value = (Decimal) this.Tools[1].Geometry.SizeDepth;
    this.numericUpDown_16.Value = (Decimal) this.Tools[2].Geometry.SizeDepth;
    this.numericUpDown_1.Value = (Decimal) this.Tools[3].Geometry.SizeDepth;
    this.numericUpDown_10.Value = (Decimal) this.Tools[4].Geometry.SizeDepth;
    this.numericUpDown_22.Value = (Decimal) this.Tools[5].Geometry.SizeDepth;
    this.numericUpDown_4.Value = (Decimal) this.Tools[6].Geometry.SizeDepth;
    this.numericUpDown_19.Value = (Decimal) this.Tools[7].Geometry.SizeDepth;
    this.numericUpDown_6.Value = (Decimal) this.Tools[0].Geometry.PositionAngle;
    this.numericUpDown_12.Value = (Decimal) this.Tools[1].Geometry.PositionAngle;
    this.numericUpDown_15.Value = (Decimal) this.Tools[2].Geometry.PositionAngle;
    this.numericUpDown_0.Value = (Decimal) this.Tools[3].Geometry.PositionAngle;
    this.numericUpDown_9.Value = (Decimal) this.Tools[4].Geometry.PositionAngle;
    this.numericUpDown_21.Value = (Decimal) this.Tools[5].Geometry.PositionAngle;
    this.numericUpDown_3.Value = (Decimal) this.Tools[6].Geometry.PositionAngle;
    this.numericUpDown_18.Value = (Decimal) this.Tools[7].Geometry.PositionAngle;
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "ToolDetailed LoadLanguage";
    try
    {
      if (F_ToolPunch1.Captions.Count < 67)
        return;
      this.Text = F_ToolPunch1.Captions[0];
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
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (!this.Properties.Inited)
      return;
    if (control2.Name == this.btn_ok.Name)
    {
      Class39.smethod_68(this);
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

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
