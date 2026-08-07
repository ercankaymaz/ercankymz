// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Entities.F_EntityResolutions
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
namespace buControls.Forms.WinControlForms.Entities;

public class F_EntityResolutions : Form
{
  public FormProperties Properties = new FormProperties();
  public EntitiesResolution Resolutions = new EntitiesResolution();
  public static List<string> Captions = new List<string>();
  internal IContainer icontainer_0 = (IContainer) null;
  internal Panel panel_0;
  internal Label label_0;
  internal NumericUpDown numericUpDown_0;
  internal Label label_1;
  internal Label label_2;
  internal NumericUpDown numericUpDown_1;
  internal Label label_3;
  internal NumericUpDown numericUpDown_2;
  internal ComboBox comboBox_0;
  internal Label label_4;
  internal Panel panel_1;
  internal Label label_5;
  internal ComboBox comboBox_1;
  internal Label label_6;
  internal NumericUpDown numericUpDown_3;
  internal Label label_7;
  internal NumericUpDown numericUpDown_4;
  internal Label label_8;
  internal Label label_9;
  internal NumericUpDown numericUpDown_5;
  internal Panel panel_2;
  internal Label label_10;
  internal ComboBox comboBox_2;
  internal Label label_11;
  internal NumericUpDown numericUpDown_6;
  internal Label label_12;
  internal NumericUpDown numericUpDown_7;
  internal Label label_13;
  internal Label label_14;
  internal NumericUpDown numericUpDown_8;
  internal Panel panel_3;
  internal Label label_15;
  internal NumericUpDown numericUpDown_9;
  internal Label label_16;
  internal ComboBox comboBox_3;
  internal Label label_17;
  internal NumericUpDown numericUpDown_10;
  internal Label label_18;
  internal NumericUpDown numericUpDown_11;
  internal Label label_19;
  internal Label label_20;
  internal NumericUpDown numericUpDown_12;
  internal Panel panel_4;
  internal Label label_21;
  internal NumericUpDown numericUpDown_13;
  internal Label label_22;
  internal ComboBox comboBox_4;
  internal Label label_23;
  internal NumericUpDown numericUpDown_14;
  internal Label label_24;
  internal NumericUpDown numericUpDown_15;
  internal Label label_25;
  internal Label label_26;
  internal NumericUpDown numericUpDown_16;
  internal Panel panel_5;
  internal Label label_27;
  internal NumericUpDown numericUpDown_17;
  internal Label label_28;
  internal ComboBox comboBox_5;
  internal Label label_29;
  internal NumericUpDown numericUpDown_18;
  internal Label label_30;
  internal NumericUpDown numericUpDown_19;
  internal Label label_31;
  internal Label label_32;
  internal NumericUpDown numericUpDown_20;
  internal Panel panel_6;
  internal Label label_33;
  internal ComboBox comboBox_6;
  internal Label label_34;
  internal NumericUpDown numericUpDown_21;
  internal Label label_35;
  internal NumericUpDown numericUpDown_22;
  internal Label label_36;
  internal Label label_37;
  internal NumericUpDown numericUpDown_23;
  internal ImageList imageList_0;
  public Button btn_cancel;
  public Button btn_ok;

  public F_EntityResolutions() => Class39.smethod_4(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.AutoScaleMode = this.Properties.ScaleFromMode;
    ArrayList EnumItems1 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Resolutions.ArcResolution.ResolutionTypes, ref EnumItems1);
    buControlCommands.ComboboxAddItem(EnumItems1, Convert.ToInt32((object) this.Resolutions.ArcResolution.ResolutionTypes), ref this.comboBox_4);
    ArrayList EnumItems2 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Resolutions.CircleResolution.ResolutionTypes, ref EnumItems2);
    buControlCommands.ComboboxAddItem(EnumItems2, Convert.ToInt32((object) this.Resolutions.CircleResolution.ResolutionTypes), ref this.comboBox_3);
    ArrayList EnumItems3 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Resolutions.EllipseResolution.ResolutionTypes, ref EnumItems3);
    buControlCommands.ComboboxAddItem(EnumItems3, Convert.ToInt32((object) this.Resolutions.EllipseResolution.ResolutionTypes), ref this.comboBox_5);
    ArrayList EnumItems4 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Resolutions.LineResolution.ResolutionTypes, ref EnumItems4);
    buControlCommands.ComboboxAddItem(EnumItems4, Convert.ToInt32((object) this.Resolutions.LineResolution.ResolutionTypes), ref this.comboBox_0);
    ArrayList EnumItems5 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Resolutions.PolylineResolution.ResolutionTypes, ref EnumItems5);
    buControlCommands.ComboboxAddItem(EnumItems5, Convert.ToInt32((object) this.Resolutions.PolylineResolution.ResolutionTypes), ref this.comboBox_1);
    ArrayList EnumItems6 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Resolutions.OtherResolution.ResolutionTypes, ref EnumItems6);
    buControlCommands.ComboboxAddItem(EnumItems6, Convert.ToInt32((object) this.Resolutions.OtherResolution.ResolutionTypes), ref this.comboBox_6);
    ArrayList EnumItems7 = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Resolutions.CurveResolution.ResolutionTypes, ref EnumItems7);
    buControlCommands.ComboboxAddItem(EnumItems7, Convert.ToInt32((object) this.Resolutions.CurveResolution.ResolutionTypes), ref this.comboBox_2);
    this.numericUpDown_15.Value = (Decimal) this.Resolutions.ArcResolution.GeometricCount;
    this.numericUpDown_16.Value = (Decimal) this.Resolutions.ArcResolution.GeometricLength;
    this.numericUpDown_13.Value = (Decimal) this.Resolutions.ArcResolution.LnRatio;
    this.numericUpDown_14.Value = (Decimal) this.Resolutions.ArcResolution.MinPointCount;
    this.numericUpDown_11.Value = (Decimal) this.Resolutions.CircleResolution.GeometricCount;
    this.numericUpDown_12.Value = (Decimal) this.Resolutions.CircleResolution.GeometricLength;
    this.numericUpDown_9.Value = (Decimal) this.Resolutions.CircleResolution.LnRatio;
    this.numericUpDown_10.Value = (Decimal) this.Resolutions.CircleResolution.MinPointCount;
    this.numericUpDown_19.Value = (Decimal) this.Resolutions.EllipseResolution.GeometricCount;
    this.numericUpDown_20.Value = (Decimal) this.Resolutions.EllipseResolution.GeometricLength;
    this.numericUpDown_17.Value = (Decimal) this.Resolutions.EllipseResolution.LnRatio;
    this.numericUpDown_18.Value = (Decimal) this.Resolutions.EllipseResolution.MinPointCount;
    this.numericUpDown_0.Value = (Decimal) this.Resolutions.LineResolution.GeometricCount;
    this.numericUpDown_1.Value = (Decimal) this.Resolutions.LineResolution.GeometricLength;
    this.numericUpDown_2.Value = (Decimal) this.Resolutions.LineResolution.MinPointCount;
    this.numericUpDown_4.Value = (Decimal) this.Resolutions.PolylineResolution.GeometricCount;
    this.numericUpDown_5.Value = (Decimal) this.Resolutions.PolylineResolution.GeometricLength;
    this.numericUpDown_3.Value = (Decimal) this.Resolutions.PolylineResolution.MinPointCount;
    this.numericUpDown_7.Value = (Decimal) this.Resolutions.CurveResolution.GeometricCount;
    this.numericUpDown_8.Value = (Decimal) this.Resolutions.CurveResolution.GeometricLength;
    this.numericUpDown_6.Value = (Decimal) this.Resolutions.CurveResolution.dt;
    this.numericUpDown_22.Value = (Decimal) this.Resolutions.OtherResolution.GeometricCount;
    this.numericUpDown_23.Value = (Decimal) this.Resolutions.OtherResolution.GeometricLength;
    this.numericUpDown_21.Value = (Decimal) this.Resolutions.OtherResolution.MinPointCount;
    this.Refresh();
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
    Class39.smethod_130(this);
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
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.btn_ok.Name)
    {
      if (!this.Properties.Inited)
        return;
      if (this.Properties.ReadOnly)
      {
        this.Dispose();
        return;
      }
      Class39.smethod_45(this);
      this.Properties.Result = DialogResult.OK;
      this.Dispose();
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
