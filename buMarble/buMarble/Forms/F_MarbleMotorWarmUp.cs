// Decompiled with JetBrains decompiler
// Type: buMarble.Forms.F_MarbleMotorWarmUp
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using \u0005;
using buClass;
using buControls.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMarble.Forms;

public class F_MarbleMotorWarmUp : Form
{
  public buButton btn_A90;
  public buButton btn_A0;
  public buButton btn_A45;
  public buButton btn_c270;
  public buButton btn_c90;
  public buButton btn_c0;
  public buButton btn_c180;
  public static List<string> Captions = new List<string>();
  public FormProperties PropertiesForm;
  public List<InfoType> InfoList;
  internal IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal DataGridView \u0001;
  public ImageList IC32;
  public static byte f0004C9;
  public static List<string> Captions;
  public FormProperties PropertiesForm = new FormProperties();
  internal IContainer \u0001 = (IContainer) null;
  public buButton btn_close;
  public buGround buGround1;
  public buButton btn_cancel;
  public buButton btn_startsaw;
  internal ImageList \u0001;
  public buSpin spn_timemilling3;
  public buSpin spn_timesaw3;
  public buSpin spn_timemilling2;
  public buSpin spn_timesaw2;
  public buSpin spn_timemilling1;
  public buSpin spn_timesaw1;

  public void FillInfo()
  {
    this.\u0001.Rows.Clear();
    if (this.InfoList == null)
      return;
    for (int index = 0; index <= this.InfoList.Count - 1; ++index)
    {
      Image image = (Image) null;
      if (this.InfoList[index].Mode == InfoTypeMode.Warning)
        image = this.IC32.Images[0];
      else if (this.InfoList[index].Mode == InfoTypeMode.Alarm)
        image = this.IC32.Images[1];
      else if (this.InfoList[index].Mode == InfoTypeMode.Message)
        image = this.IC32.Images[2];
      this.\u0001.Rows.Add(\u0003.\u0001(this.InfoList[index].Message, index, (F_MarbleInfoList) this, image));
      this.\u0001.Rows[this.\u0001.Rows.Count - 1].Height = 40;
      if (this.InfoList[index].Mode == InfoTypeMode.Warning)
        this.\u0001.Rows[index].Cells[2].Style.BackColor = Color.Gold;
      else if (this.InfoList[index].Mode == InfoTypeMode.Alarm)
        this.\u0001.Rows[index].Cells[2].Style.BackColor = Color.LightSalmon;
      else if (this.InfoList[index].Mode == InfoTypeMode.Message)
        this.\u0001.Rows[index].Cells[2].Style.BackColor = Color.LightBlue;
    }
    if (this.\u0001.Rows.Count > 0)
      ;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control = obj0 as Control;
      if (control.Name == this.btn_ok.Name)
      {
        ((F_MarbleInfoList) this).Apply();
        this.PropertiesForm.Result = DialogResult.OK;
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control.Name == this.btn_close.Name | control.Name == this.btn_cancel.Name))
        return;
      this.PropertiesForm.Result = DialogResult.Cancel;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  internal void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.\u0001 != null ? 1 : 0)) != 0)
      this.\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MarbleMotorWarmUp() => \u0003.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    ((F_MarbleMaterialMeasurement) this).spn_speedmilling1.Value = clsAppMarbleVars.varApp.WarmUpMillingSpeed1;
    ((F_MarbleMaterialMeasurement) this).spn_speedmilling2.Value = clsAppMarbleVars.varApp.WarmUpMillingSpeed2;
    ((F_MarbleMaterialMeasurement) this).spn_speedmilling3.Value = clsAppMarbleVars.varApp.WarmUpMillingSpeed3;
    ((F_MarbleMaterialMeasurement) this).spn_speedsaw1.Value = clsAppMarbleVars.varApp.WarmUpSawSpeed1;
    ((F_MarbleMaterialMeasurement) this).spn_speedsaw2.Value = clsAppMarbleVars.varApp.WarmUpSawSpeed2;
    ((F_MarbleMaterialMeasurement) this).spn_speedsaw3.Value = clsAppMarbleVars.varApp.WarmUpSawSpeed3;
    this.spn_timemilling1.Value = clsAppMarbleVars.varApp.WarmUpMillingTimeSec1;
    this.spn_timemilling2.Value = clsAppMarbleVars.varApp.WarmUpMillingTimeSec2;
    this.spn_timemilling3.Value = clsAppMarbleVars.varApp.WarmUpMillingTimeSec3;
    this.spn_timesaw1.Value = clsAppMarbleVars.varApp.WarmUpSawTimeSec1;
    this.spn_timesaw2.Value = clsAppMarbleVars.varApp.WarmUpSawTimeSec2;
    this.spn_timesaw3.Value = clsAppMarbleVars.varApp.WarmUpSawTimeSec3;
    ((F_MarbleMaterialMeasurement) this).spn_speedmilling1.ReadOnly = false;
    ((F_MarbleMaterialMeasurement) this).spn_speedmilling2.ReadOnly = false;
    ((F_MarbleMaterialMeasurement) this).spn_speedmilling3.ReadOnly = false;
    ((F_MarbleMaterialMeasurement) this).spn_speedsaw1.ReadOnly = false;
    ((F_MarbleMaterialMeasurement) this).spn_speedsaw2.ReadOnly = false;
    ((F_MarbleMaterialMeasurement) this).spn_speedsaw3.ReadOnly = false;
    this.spn_timemilling1.ReadOnly = false;
    this.spn_timemilling2.ReadOnly = false;
    this.spn_timemilling3.ReadOnly = false;
    this.spn_timesaw1.ReadOnly = false;
    this.spn_timesaw2.ReadOnly = false;
    this.spn_timesaw3.ReadOnly = false;
    if (AppSecurity.PasswordLevel <= 1)
    {
      ((F_MarbleMaterialMeasurement) this).spn_speedmilling1.ReadOnly = true;
      ((F_MarbleMaterialMeasurement) this).spn_speedmilling2.ReadOnly = true;
      ((F_MarbleMaterialMeasurement) this).spn_speedmilling3.ReadOnly = true;
      ((F_MarbleMaterialMeasurement) this).spn_speedsaw1.ReadOnly = true;
      ((F_MarbleMaterialMeasurement) this).spn_speedsaw2.ReadOnly = true;
      ((F_MarbleMaterialMeasurement) this).spn_speedsaw3.ReadOnly = true;
      this.spn_timemilling1.ReadOnly = true;
      this.spn_timemilling2.ReadOnly = true;
      this.spn_timemilling3.ReadOnly = true;
      this.spn_timesaw1.ReadOnly = true;
      this.spn_timesaw2.ReadOnly = true;
      this.spn_timesaw3.ReadOnly = true;
    }
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
    \u0003.\u0001(this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
