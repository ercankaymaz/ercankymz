// Decompiled with JetBrains decompiler
// Type: buMarble.Forms.F_MarbleMaterialMeasurement
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMarble.Forms;

public class F_MarbleMaterialMeasurement : Form
{
  public buSpin spn_speedmilling3;
  public buSpin spn_speedsaw3;
  public buSpin spn_speedmilling2;
  public buSpin spn_speedsaw2;
  internal buLabel \u0001;
  internal buLabel \u0002;
  public buSpin spn_speedmilling1;
  public buSpin spn_speedsaw1;
  public buButton btn_stopsaw;
  public buButton btn_stopmilling;
  public buButton btn_startmilling;
  public buButton btn_ok;
  public buLabel lnl_speed1;
  public buLabel lnl_time3;
  public buLabel lnl_time2;
  public buLabel lnl_time1;
  public buLabel lnl_speed3;
  public buLabel lnl_speed2;
  public static List<string> Captions;
  public FormProperties PropertiesForm = new FormProperties();
  public int indexList = -1;
  internal IContainer \u0001 = (IContainer) null;
  public buButton btn_close;
  public buGround buGround1;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal ImageList \u0001;

  public void Apply()
  {
    clsAppMarbleVars.varApp.WarmUpMillingSpeed1 = this.spn_speedmilling1.Value;
    clsAppMarbleVars.varApp.WarmUpMillingSpeed2 = this.spn_speedmilling2.Value;
    clsAppMarbleVars.varApp.WarmUpMillingSpeed3 = this.spn_speedmilling3.Value;
    clsAppMarbleVars.varApp.WarmUpSawSpeed1 = this.spn_speedsaw1.Value;
    clsAppMarbleVars.varApp.WarmUpSawSpeed2 = this.spn_speedsaw2.Value;
    clsAppMarbleVars.varApp.WarmUpSawSpeed3 = this.spn_speedsaw3.Value;
    clsAppMarbleVars.varApp.WarmUpMillingTimeSec1 = ((F_MarbleMotorWarmUp) this).spn_timemilling1.Value;
    clsAppMarbleVars.varApp.WarmUpMillingTimeSec2 = ((F_MarbleMotorWarmUp) this).spn_timemilling2.Value;
    clsAppMarbleVars.varApp.WarmUpMillingTimeSec3 = ((F_MarbleMotorWarmUp) this).spn_timemilling3.Value;
    clsAppMarbleVars.varApp.WarmUpSawTimeSec1 = ((F_MarbleMotorWarmUp) this).spn_timesaw1.Value;
    clsAppMarbleVars.varApp.WarmUpSawTimeSec2 = ((F_MarbleMotorWarmUp) this).spn_timesaw2.Value;
    clsAppMarbleVars.varApp.WarmUpSawTimeSec3 = ((F_MarbleMotorWarmUp) this).spn_timesaw3.Value;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control = obj0 as Control;
      if (control.Name == this.btn_ok.Name)
      {
        ((F_MarbleMotorWarmUp) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_MarbleMotorWarmUp) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleMotorWarmUp) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control.Name == ((F_MarbleMotorWarmUp) this).btn_close.Name | control.Name == ((F_MarbleMotorWarmUp) this).btn_cancel.Name))
        return;
      this.Apply();
      ((F_MarbleMotorWarmUp) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_MarbleMotorWarmUp) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleMotorWarmUp) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    buSpin buSpin = obj0 as buSpin;
    if (!(AppBool.TouchPad & !buSpin.ReadOnly))
      return;
    F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
    if (!buNumeric5.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleMotorWarmUp) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleMotorWarmUp) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleMaterialMeasurement() => F_MarbleMotorWarmUp.Captions = new List<string>();

  public F_MarbleMaterialMeasurement() => \u0005.\u0003.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    ((F_MarbleParkList) this).spn_matwidth.Value = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth;
    ((F_MarbleParkList) this).spn_matheight.Value = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight;
    clsAppMarbleVars.varApp.MaterialWidth = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth;
    clsAppMarbleVars.varApp.MaterialHeight = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight;
    if (clsAppMarbleVars.varApp.MaterialMeasureMode == AutoManuel.Auto)
      ((F_MarbleParkList) this).\u0001.Checked = true;
    else
      ((F_MarbleParkList) this).\u0002.Checked = true;
    this.MenuButtonColors(Convert.ToInt32((object) clsAppMarbleVars.varApp.MaterialMeasureType));
    if (((F_MarbleParkList) this).DGV_list.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn1.Width = 70;
      dataGridViewColumn1.HeaderText = buLangTranslate.preDef.Number;
      dataGridViewColumn1.Name = "No";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleParkList) this).DGV_list.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = 140;
      dataGridViewColumn2.HeaderText = buLangTranslate.preChar.X;
      dataGridViewColumn2.Name = "X";
      dataGridViewColumn2.ReadOnly = false;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleParkList) this).DGV_list.Columns.Add(dataGridViewColumn2);
      DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
      dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn3.Width = 140;
      dataGridViewColumn3.HeaderText = buLangTranslate.preChar.Y;
      dataGridViewColumn3.Name = "Y";
      dataGridViewColumn3.ReadOnly = false;
      dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleParkList) this).DGV_list.Columns.Add(dataGridViewColumn3);
      DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
      dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn4.Width = 140;
      dataGridViewColumn4.HeaderText = buLangTranslate.preDef.Thickness;
      dataGridViewColumn4.Name = "Thickness";
      dataGridViewColumn4.ReadOnly = false;
      dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleParkList) this).DGV_list.Columns.Add(dataGridViewColumn4);
      DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
      dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn5.Width = 140;
      dataGridViewColumn5.HeaderText = buLangTranslate.preDef.Old + buLangTranslate.preDef.Thickness;
      dataGridViewColumn5.Name = "OldThickness";
      dataGridViewColumn5.ReadOnly = false;
      dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn5.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleParkList) this).DGV_list.Columns.Add(dataGridViewColumn5);
    }
    ((F_MarbleParkList) this).DGV_list.RowHeadersVisible = false;
    ((F_MarbleParkList) this).DGV_list.AllowUserToAddRows = false;
    ((F_MarbleParkList) this).DGV_list.AllowUserToResizeColumns = false;
    ((F_MarbleParkList) this).DGV_list.ColumnHeadersVisible = true;
    this.UpdateList(clsAppMarbleVars.varApp.MaterialMeasureType);
    this.FillList();
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
    \u0005.\u0003.\u0001(this);
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

  public void Apply()
  {
    buMarbleCalc.varOperation.MaterialParameter.MaterialWidth = ((F_MarbleParkList) this).spn_matwidth.Value;
    buMarbleCalc.varOperation.MaterialParameter.MaterialHeight = ((F_MarbleParkList) this).spn_matheight.Value;
    clsAppMarbleVars.varApp.MaterialWidth = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth;
    clsAppMarbleVars.varApp.MaterialHeight = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight;
    clsAppMarbleVars.varApp.MaterialMeasureMode = !((F_MarbleParkList) this).\u0002.Checked ? AutoManuel.Auto : AutoManuel.Manuel;
    for (int index = 0; index <= ((F_MarbleParkList) this).DGV_list.Rows.Count - 1; ++index)
    {
      clsAppMarbleVars.cMachine.MaterialMeasureList[index].X = double.Parse(((F_MarbleParkList) this).DGV_list.Rows[index].Cells[1].Value.ToString());
      clsAppMarbleVars.cMachine.MaterialMeasureList[index].Y = double.Parse(((F_MarbleParkList) this).DGV_list.Rows[index].Cells[2].Value.ToString());
      clsAppMarbleVars.cMachine.MaterialMeasureList[index].Z = double.Parse(((F_MarbleParkList) this).DGV_list.Rows[index].Cells[3].Value.ToString());
      clsAppMarbleVars.cMachine.MaterialMeasureList[index].W = double.Parse(((F_MarbleParkList) this).DGV_list.Rows[index].Cells[4].Value.ToString());
    }
  }

  public void UpdateList(MarbleMaterialMeasureType PointType)
  {
    int int32 = Convert.ToInt32((object) PointType);
    if (int32 > clsAppMarbleVars.cMachine.MaterialMeasureList.Count)
    {
      int num = int32 - clsAppMarbleVars.cMachine.MaterialMeasureList.Count;
      for (int index = 1; index <= num; ++index)
        clsAppMarbleVars.cMachine.MaterialMeasureList.Add(new Pnt9DS());
    }
    else if (int32 < clsAppMarbleVars.cMachine.MaterialMeasureList.Count)
    {
      int count = clsAppMarbleVars.cMachine.MaterialMeasureList.Count - int32;
      clsAppMarbleVars.cMachine.MaterialMeasureList.RemoveRange(int32, count);
    }
    if (clsAppMarbleVars.varApp.MaterialMeasureMode != AutoManuel.Auto)
      return;
    if (PointType == MarbleMaterialMeasureType.YDirection)
    {
      clsAppMarbleVars.cMachine.MaterialMeasureList[0].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth / 2.0;
      clsAppMarbleVars.cMachine.MaterialMeasureList[0].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight / 2.0;
    }
    if (PointType == (MarbleMaterialMeasureType) 2)
    {
      clsAppMarbleVars.cMachine.MaterialMeasureList[0].X = clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[0].Y = clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[1].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth - clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[1].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight - clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
    }
    if (PointType == (MarbleMaterialMeasureType) 3)
    {
      clsAppMarbleVars.cMachine.MaterialMeasureList[0].X = clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[0].Y = clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[1].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth / 2.0;
      clsAppMarbleVars.cMachine.MaterialMeasureList[1].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight / 2.0;
      clsAppMarbleVars.cMachine.MaterialMeasureList[2].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth - clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[2].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight - clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
    }
    if (PointType == (MarbleMaterialMeasureType) 4)
    {
      clsAppMarbleVars.cMachine.MaterialMeasureList[0].X = clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[0].Y = clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[1].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth - clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[1].Y = clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[2].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth - clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[2].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight - clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[3].X = clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[3].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight - clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
    }
    if (PointType == (MarbleMaterialMeasureType) 5)
    {
      clsAppMarbleVars.cMachine.MaterialMeasureList[0].X = clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[0].Y = clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[1].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth - clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[1].Y = clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[2].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth - clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[2].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight - clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[3].X = clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[3].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight - clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[4].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth / 2.0;
      clsAppMarbleVars.cMachine.MaterialMeasureList[4].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight / 2.0;
    }
    if (PointType == (MarbleMaterialMeasureType) 9)
    {
      clsAppMarbleVars.cMachine.MaterialMeasureList[0].X = clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[0].Y = clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[1].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth / 2.0;
      clsAppMarbleVars.cMachine.MaterialMeasureList[1].Y = clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[2].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth - clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[2].Y = clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[3].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth - clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[3].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight / 2.0;
      clsAppMarbleVars.cMachine.MaterialMeasureList[4].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth / 2.0;
      clsAppMarbleVars.cMachine.MaterialMeasureList[4].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight / 2.0;
      clsAppMarbleVars.cMachine.MaterialMeasureList[5].X = clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[5].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight / 2.0;
      clsAppMarbleVars.cMachine.MaterialMeasureList[6].X = clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[6].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight - clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[7].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth / 2.0;
      clsAppMarbleVars.cMachine.MaterialMeasureList[7].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight - clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[8].X = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth - clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
      clsAppMarbleVars.cMachine.MaterialMeasureList[8].Y = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight - clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
    }
    if (PointType != (MarbleMaterialMeasureType) 16 /*0x10*/)
      return;
    double measureXborderOffset = clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
    double num1 = Math.Round(buMarbleCalc.varOperation.MaterialParameter.MaterialWidth * 0.3333, 3);
    double num2 = Math.Round(buMarbleCalc.varOperation.MaterialParameter.MaterialWidth * 0.6666, 3);
    double num3 = buMarbleCalc.varOperation.MaterialParameter.MaterialWidth - clsAppMarbleVars.varApp.MaterialMeasureXBorderOffset;
    double measureYborderOffset = clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
    double num4 = Math.Round(buMarbleCalc.varOperation.MaterialParameter.MaterialHeight * 0.3333, 3);
    double num5 = Math.Round(buMarbleCalc.varOperation.MaterialParameter.MaterialHeight * 0.6666, 3);
    double num6 = buMarbleCalc.varOperation.MaterialParameter.MaterialHeight - clsAppMarbleVars.varApp.MaterialMeasureYBorderOffset;
    clsAppMarbleVars.cMachine.MaterialMeasureList[0].X = measureXborderOffset;
    clsAppMarbleVars.cMachine.MaterialMeasureList[0].Y = measureYborderOffset;
    clsAppMarbleVars.cMachine.MaterialMeasureList[1].X = num1;
    clsAppMarbleVars.cMachine.MaterialMeasureList[1].Y = measureYborderOffset;
    clsAppMarbleVars.cMachine.MaterialMeasureList[2].X = num2;
    clsAppMarbleVars.cMachine.MaterialMeasureList[2].Y = measureYborderOffset;
    clsAppMarbleVars.cMachine.MaterialMeasureList[3].X = num3;
    clsAppMarbleVars.cMachine.MaterialMeasureList[3].Y = measureYborderOffset;
    clsAppMarbleVars.cMachine.MaterialMeasureList[4].X = num3;
    clsAppMarbleVars.cMachine.MaterialMeasureList[4].Y = num4;
    clsAppMarbleVars.cMachine.MaterialMeasureList[5].X = num2;
    clsAppMarbleVars.cMachine.MaterialMeasureList[5].Y = num4;
    clsAppMarbleVars.cMachine.MaterialMeasureList[6].X = num1;
    clsAppMarbleVars.cMachine.MaterialMeasureList[6].Y = num4;
    clsAppMarbleVars.cMachine.MaterialMeasureList[7].X = measureXborderOffset;
    clsAppMarbleVars.cMachine.MaterialMeasureList[7].Y = num4;
    clsAppMarbleVars.cMachine.MaterialMeasureList[8].X = measureXborderOffset;
    clsAppMarbleVars.cMachine.MaterialMeasureList[8].Y = num5;
    clsAppMarbleVars.cMachine.MaterialMeasureList[9].X = num1;
    clsAppMarbleVars.cMachine.MaterialMeasureList[9].Y = num5;
    clsAppMarbleVars.cMachine.MaterialMeasureList[10].X = num2;
    clsAppMarbleVars.cMachine.MaterialMeasureList[10].Y = num5;
    clsAppMarbleVars.cMachine.MaterialMeasureList[11].X = num3;
    clsAppMarbleVars.cMachine.MaterialMeasureList[11].Y = num5;
    clsAppMarbleVars.cMachine.MaterialMeasureList[12].X = num3;
    clsAppMarbleVars.cMachine.MaterialMeasureList[12].Y = num6;
    clsAppMarbleVars.cMachine.MaterialMeasureList[13].X = num2;
    clsAppMarbleVars.cMachine.MaterialMeasureList[13].Y = num6;
    clsAppMarbleVars.cMachine.MaterialMeasureList[14].X = num1;
    clsAppMarbleVars.cMachine.MaterialMeasureList[14].Y = num6;
    clsAppMarbleVars.cMachine.MaterialMeasureList[15].X = measureXborderOffset;
    clsAppMarbleVars.cMachine.MaterialMeasureList[15].Y = num6;
  }

  public void FillList()
  {
    ((F_MarbleParkList) this).DGV_list.Rows.Clear();
    if (((F_MarbleParkList) this).\u0001.Checked)
    {
      for (int index = 0; index <= clsAppMarbleVars.cMachine.MaterialMeasureList.Count - 1; ++index)
      {
        Pnt9DS materialMeasure = clsAppMarbleVars.cMachine.MaterialMeasureList[index];
        if (index <= Convert.ToInt32((object) clsAppMarbleVars.varApp.MaterialMeasureType) - 1)
        {
          DataGridViewRowCollection rows = ((F_MarbleParkList) this).DGV_list.Rows;
          double x = materialMeasure.X;
          double y = materialMeasure.Y;
          double z = materialMeasure.Z;
          double w = materialMeasure.W;
          object[] objArray = \u0005.\u0003.\u0001(y, this, w, x, z, index + 1);
          rows.Add(objArray);
          ((F_MarbleParkList) this).DGV_list.Rows[((F_MarbleParkList) this).DGV_list.Rows.Count - 1].Height = 35;
          ((F_MarbleParkList) this).DGV_list.Rows[((F_MarbleParkList) this).DGV_list.Rows.Count - 1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
          ((F_MarbleParkList) this).DGV_list.Rows[((F_MarbleParkList) this).DGV_list.Rows.Count - 1].Cells[4].Style.ForeColor = Color.Red;
        }
      }
    }
    else
    {
      Pnt9DS pnt9Ds = new Pnt9DS(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, clsAppMarbleVars.cMachine.MaterialMeasureList[0].Z, 0.0, 0.0, 0.0, 0.0, 0.0, clsAppMarbleVars.cMachine.MaterialMeasureList[0].W);
      DataGridViewRowCollection rows = ((F_MarbleParkList) this).DGV_list.Rows;
      double x = pnt9Ds.X;
      double y = pnt9Ds.Y;
      double z = pnt9Ds.Z;
      double w = pnt9Ds.W;
      object[] objArray = \u0005.\u0003.\u0001(y, this, w, x, z, 1);
      rows.Add(objArray);
      ((F_MarbleParkList) this).DGV_list.Rows[((F_MarbleParkList) this).DGV_list.Rows.Count - 1].Height = 35;
      ((F_MarbleParkList) this).DGV_list.Rows[((F_MarbleParkList) this).DGV_list.Rows.Count - 1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
      ((F_MarbleParkList) this).DGV_list.Rows[((F_MarbleParkList) this).DGV_list.Rows.Count - 1].Cells[4].Style.ForeColor = Color.Red;
    }
  }

  public void MenuButtonColors(int PageIndex)
  {
    hmiUICommands.SetVisualItem(this.buGround1.Controls);
    if (PageIndex == 1)
    {
      ((F_MarbleParkList) this).btn_point1.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      ((F_MarbleParkList) this).btn_point1.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 2)
    {
      ((F_MarbleParkList) this).btn_point2.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      ((F_MarbleParkList) this).btn_point2.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 3)
    {
      ((F_MarbleParkList) this).btn_point3.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      ((F_MarbleParkList) this).btn_point3.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 4)
    {
      ((F_MarbleParkList) this).btn_point4.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      ((F_MarbleParkList) this).btn_point4.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 5)
    {
      ((F_MarbleParkList) this).btn_point5.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      ((F_MarbleParkList) this).btn_point5.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex == 9)
    {
      ((F_MarbleParkList) this).btn_point9.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
      ((F_MarbleParkList) this).btn_point9.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    }
    if (PageIndex != 16 /*0x10*/)
      return;
    ((F_MarbleParkList) this).btn_point16.Display.LineerGradient.FirstColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
    ((F_MarbleParkList) this).btn_point16.Display.LineerGradient.SecondColor = buEyeVars.parVisual.hmiButtonMenu2.ButtonNormal.SelectionColor;
  }
}
