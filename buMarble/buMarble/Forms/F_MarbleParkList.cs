// Decompiled with JetBrains decompiler
// Type: buMarble.Forms.F_MarbleParkList
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using \u0005;
using buClass;
using buControls.Controls;
using buCore;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMarble.Forms;

public class F_MarbleParkList : Form
{
  internal RadioButton \u0001;
  public buButton btn_matgetpos;
  public buButton btn_matsave;
  public buButton btn_matopen;
  internal RadioButton \u0002;
  public buButton btn_point1;
  public buButton btn_point9;
  public buButton btn_point5;
  public buButton btn_point4;
  public buButton btn_point3;
  public buButton btn_point2;
  public buSpin spn_matwidth;
  public buSpin spn_matheight;
  public buButton btn_materialmeasure;
  public DataGridView DGV_list;
  public buButton btn_point16;
  public buButton btn_matmeasuresettings;
  public buButton btn_stop;
  public static byte f000505;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public List<Pnt9DS> Parks;
  public int indexPark;
  public int indexMachine;
  public bool ParkSelected;
  public bool MachineSelected;
  public bool ShowGeneralParks;

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control = obj0 as Control;
      if (control.Name == this.btn_stop.Name && clsAppMarbleVars.cmdMarble != null)
        clsAppMarbleVars.cmdMarble.ClickCommand((MarbleMotionCommands) 2);
      if (control.Name == ((F_MarbleMaterialMeasurement) this).btn_ok.Name)
      {
        clsAppMarbleVars.varApp.SelectedParkPosition = ((F_MarbleMaterialMeasurement) this).indexList;
        ((F_MarbleMaterialMeasurement) this).Apply();
        ((F_MarbleMaterialMeasurement) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_MarbleMaterialMeasurement) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleMaterialMeasurement) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control.Name == ((F_MarbleMaterialMeasurement) this).btn_close.Name | control.Name == ((F_MarbleMaterialMeasurement) this).btn_cancel.Name)
      {
        ((F_MarbleMaterialMeasurement) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((F_MarbleMaterialMeasurement) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleMaterialMeasurement) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control.Name == this.\u0001.Name)
        ((F_MarbleMaterialMeasurement) this).FillList();
      if (control.Name == this.\u0002.Name)
        ((F_MarbleMaterialMeasurement) this).FillList();
      if (control.Name == this.btn_materialmeasure.Name)
      {
        ((F_MarbleMaterialMeasurement) this).Apply();
        if (clsAppMarbleVars.varApp.MaterialMeasureMode == AutoManuel.Manuel)
        {
          ((F_MarbleMaterialMeasurement) this).indexList = 0;
          ((F_MarbleMaterialMeasurement) this).FillList();
          if (((F_MarbleMaterialMeasurement) this).indexList >= 0 & ((F_MarbleMaterialMeasurement) this).indexList <= this.DGV_list.Rows.Count - 1)
          {
            this.DGV_list.Rows[((F_MarbleMaterialMeasurement) this).indexList].Cells[4].Value = this.DGV_list.Rows[((F_MarbleMaterialMeasurement) this).indexList].Cells[3].Value;
            clsAppMarbleVars.cMachine.MaterialMeasureList[((F_MarbleMaterialMeasurement) this).indexList].W = clsAppMarbleVars.cMachine.MaterialMeasureList[((F_MarbleMaterialMeasurement) this).indexList].Z;
            clsAppMarbleVars.varRuntime.MaterialIndex = ((F_MarbleMaterialMeasurement) this).indexList + 1;
            double Val1 = Convert.ToDouble(this.DGV_list.Rows[((F_MarbleMaterialMeasurement) this).indexList].Cells[1].Value);
            clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val1, "AppRun.MaterialMeasurePosX");
            double Val2 = Convert.ToDouble(this.DGV_list.Rows[((F_MarbleMaterialMeasurement) this).indexList].Cells[2].Value);
            clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val2, "AppRun.MaterialMeasurePosY");
            clsAppMarbleVars.cmdMarble.writeDINTVar(CodesysVariableBaseType.Persistent, (int) clsAppMarbleVars.varApp.MaterialMeasureMode, "AppSet.MaterialMeasureMode");
            clsAppMarbleVars.cmdMarble.writeDINTVar(CodesysVariableBaseType.Global, clsAppMarbleVars.varRuntime.MaterialIndex, "AppRun.MaterialMeasureIndex");
            clsAppMarbleVars.cmdMarble.ClickCommand((MarbleMotionCommands) 28);
          }
        }
        else
        {
          clsAppMarbleVars.cmdMarble.writeDINTVar(CodesysVariableBaseType.Global, 1, "AppRun.MaterialMeasureIndex");
          clsAppMarbleVars.cmdMarble.writeDINTVar(CodesysVariableBaseType.Global, this.DGV_list.Rows.Count, "AppRun.MaterialCalcAutoListCount");
          clsAppMarbleVars.cmdMarble.writeDINTVar(CodesysVariableBaseType.Persistent, (int) clsAppMarbleVars.varApp.MaterialMeasureMode, "AppSet.MaterialMeasureMode");
          for (int index = 0; index <= this.DGV_list.Rows.Count - 1; ++index)
          {
            this.DGV_list.Rows[index].Cells[4].Value = this.DGV_list.Rows[index].Cells[3].Value;
            clsAppMarbleVars.cMachine.MaterialMeasureList[index].W = clsAppMarbleVars.cMachine.MaterialMeasureList[index].Z;
            double Val3 = Convert.ToDouble(this.DGV_list.Rows[index].Cells[1].Value);
            clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val3, $"AppRun.MaterialCalcAutoPos[{index.ToString()}].X");
            double Val4 = Convert.ToDouble(this.DGV_list.Rows[index].Cells[2].Value);
            clsAppMarbleVars.cmdMarble.writeLREALVar(CodesysVariableBaseType.Global, Val4, $"AppRun.MaterialCalcAutoPos[{index.ToString()}].Y");
          }
          clsAppMarbleVars.cmdMarble.writeBOOLVar(CodesysVariableBaseType.Global, true, "AppExe.MaterialMeasureAutoStart");
        }
      }
      if (control.Name == this.btn_point1.Name)
      {
        clsAppMarbleVars.varApp.MaterialMeasureType = MarbleMaterialMeasureType.YDirection;
        ((F_MarbleMaterialMeasurement) this).MenuButtonColors(Convert.ToInt32((object) clsAppMarbleVars.varApp.MaterialMeasureType));
        ((F_MarbleMaterialMeasurement) this).Apply();
        ((F_MarbleMaterialMeasurement) this).UpdateList(clsAppMarbleVars.varApp.MaterialMeasureType);
        ((F_MarbleMaterialMeasurement) this).FillList();
      }
      if (control.Name == this.btn_point2.Name)
      {
        clsAppMarbleVars.varApp.MaterialMeasureType = (MarbleMaterialMeasureType) 2;
        ((F_MarbleMaterialMeasurement) this).MenuButtonColors(Convert.ToInt32((object) clsAppMarbleVars.varApp.MaterialMeasureType));
        ((F_MarbleMaterialMeasurement) this).Apply();
        ((F_MarbleMaterialMeasurement) this).UpdateList(clsAppMarbleVars.varApp.MaterialMeasureType);
        ((F_MarbleMaterialMeasurement) this).FillList();
      }
      if (control.Name == this.btn_point3.Name)
      {
        clsAppMarbleVars.varApp.MaterialMeasureType = (MarbleMaterialMeasureType) 3;
        ((F_MarbleMaterialMeasurement) this).MenuButtonColors(Convert.ToInt32((object) clsAppMarbleVars.varApp.MaterialMeasureType));
        ((F_MarbleMaterialMeasurement) this).Apply();
        ((F_MarbleMaterialMeasurement) this).UpdateList(clsAppMarbleVars.varApp.MaterialMeasureType);
        ((F_MarbleMaterialMeasurement) this).FillList();
      }
      if (control.Name == this.btn_point4.Name)
      {
        clsAppMarbleVars.varApp.MaterialMeasureType = (MarbleMaterialMeasureType) 4;
        ((F_MarbleMaterialMeasurement) this).MenuButtonColors(Convert.ToInt32((object) clsAppMarbleVars.varApp.MaterialMeasureType));
        ((F_MarbleMaterialMeasurement) this).Apply();
        ((F_MarbleMaterialMeasurement) this).UpdateList(clsAppMarbleVars.varApp.MaterialMeasureType);
        ((F_MarbleMaterialMeasurement) this).FillList();
      }
      if (control.Name == this.btn_point5.Name)
      {
        clsAppMarbleVars.varApp.MaterialMeasureType = (MarbleMaterialMeasureType) 5;
        ((F_MarbleMaterialMeasurement) this).MenuButtonColors(Convert.ToInt32((object) clsAppMarbleVars.varApp.MaterialMeasureType));
        ((F_MarbleMaterialMeasurement) this).Apply();
        ((F_MarbleMaterialMeasurement) this).UpdateList(clsAppMarbleVars.varApp.MaterialMeasureType);
        ((F_MarbleMaterialMeasurement) this).FillList();
      }
      if (control.Name == this.btn_point9.Name)
      {
        clsAppMarbleVars.varApp.MaterialMeasureType = (MarbleMaterialMeasureType) 9;
        ((F_MarbleMaterialMeasurement) this).Apply();
        ((F_MarbleMaterialMeasurement) this).MenuButtonColors(Convert.ToInt32((object) clsAppMarbleVars.varApp.MaterialMeasureType));
        ((F_MarbleMaterialMeasurement) this).UpdateList(clsAppMarbleVars.varApp.MaterialMeasureType);
        ((F_MarbleMaterialMeasurement) this).FillList();
      }
      if (control.Name == this.btn_point16.Name)
      {
        clsAppMarbleVars.varApp.MaterialMeasureType = (MarbleMaterialMeasureType) 16 /*0x10*/;
        ((F_MarbleMaterialMeasurement) this).Apply();
        ((F_MarbleMaterialMeasurement) this).MenuButtonColors(Convert.ToInt32((object) clsAppMarbleVars.varApp.MaterialMeasureType));
        ((F_MarbleMaterialMeasurement) this).UpdateList(clsAppMarbleVars.varApp.MaterialMeasureType);
        ((F_MarbleMaterialMeasurement) this).FillList();
      }
      if (control.Name == this.btn_matopen.Name)
      {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.InitialDirectory = buMarbleCalc.varMarbleRunSettings.pathMaterialMeasure;
        openFileDialog.Multiselect = false;
        openFileDialog.Filter = "Marble Material Measure File (*.bumatmeasure)|*.bumatmeasure";
        openFileDialog.FilterIndex = 1;
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
          buMarbleCalc.varMarbleRunSettings.pathMaterialMeasure = fileInfo.DirectoryName;
          ArrayList StringList = new ArrayList();
          buFile.OpenFromFile(fileInfo.FullName, ref StringList);
          List<string> CalcList = new List<string>();
          buString.ListToSpecificList("<MatList>", "</MatList>", false, StringList, ref CalcList);
          if (CalcList.Count > 0)
          {
            clsAppMarbleVars.cMachine.MaterialMeasureList.Clear();
            for (int index = 0; index <= CalcList.Count - 1; ++index)
            {
              Pnt9DS pnt9Ds = Pnt9DS.DecodeFromString(CalcList[index]);
              clsAppMarbleVars.cMachine.MaterialMeasureList.Add(pnt9Ds);
            }
            ((F_MarbleMaterialMeasurement) this).FillList();
          }
        }
      }
      if (control.Name == this.btn_matsave.Name)
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = buMarbleCalc.varMarbleRunSettings.pathMaterialMeasure;
        saveFileDialog.Filter = "Marble Material Measure (*.bumatmeasure)|*.bumatmeasure";
        saveFileDialog.FilterIndex = 1;
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
          FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
          buMarbleCalc.varMarbleRunSettings.pathMaterialMeasure = fileInfo.DirectoryName;
          ArrayList StringList = new ArrayList();
          StringList.Add((object) "------------------------------------------------------------------------");
          StringList.Add((object) "  Marble Material Measure  ");
          StringList.Add((object) "------------------------------------------------------------------------");
          StringList.Add((object) "<MatList>");
          for (int index = 0; index <= clsAppMarbleVars.cMachine.MaterialMeasureList.Count - 1; ++index)
            StringList.Add((object) clsAppMarbleVars.cMachine.MaterialMeasureList[index].ToDef(2));
          StringList.Add((object) "</MatList>");
          buFile.SaveToFile(StringList, saveFileDialog.FileName);
        }
      }
      if (control.Name == this.btn_matmeasuresettings.Name)
        clsAppMarbleVars.cmdMarble.ShowMachineSettingsV1(8);
      if (!(control.Name == this.btn_matgetpos.Name) || !(AppBool.Connected & ((F_MarbleMaterialMeasurement) this).indexList >= 0))
        return;
      if (clsAppMarbleVars.varRuntime.AxX >= 0)
        this.DGV_list.Rows[((F_MarbleMaterialMeasurement) this).indexList].Cells[1].Value = (object) Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Runtime.Actual.actualPosition, 2);
      if (clsAppMarbleVars.varRuntime.AxY < 0)
        return;
      this.DGV_list.Rows[((F_MarbleMaterialMeasurement) this).indexList].Cells[2].Value = (object) Math.Round(clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Runtime.Actual.actualPosition, 2);
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
  }

  internal void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    ((F_MarbleMaterialMeasurement) this).indexList = obj1.RowIndex;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleMaterialMeasurement) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleMaterialMeasurement) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleParkList() => F_MarbleMaterialMeasurement.Captions = new List<string>();

  public F_MarbleParkList()
  {
    ((F_MarbleMachineInstall) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0003.\u0001(this);
  }

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    if (clsAppMarbleVars.varApp.ParkPositionAfterFinishType == (MarbleParkModeAfterJob) 1)
      ((F_MarbleMachineInstall) this).\u0002.Checked = true;
    else if (clsAppMarbleVars.varApp.ParkPositionAfterFinishType == (MarbleParkModeAfterJob) 2)
      ((F_MarbleMachineInstall) this).\u0001.Checked = true;
    else if (clsAppMarbleVars.varApp.ParkPositionAfterFinishType == MarbleParkModeAfterJob.Saw)
      ((F_MarbleMachineInstall) this).\u0003.Checked = true;
    this.ParkSelected = false;
    this.MachineSelected = false;
    if (((F_MarbleMachineInstall) this).\u0001.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn1.Width = 35;
      dataGridViewColumn1.HeaderText = buLangTranslate.preDef.No;
      dataGridViewColumn1.Name = "No";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleMachineInstall) this).\u0001.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = 60;
      dataGridViewColumn2.HeaderText = buLangTranslate.preDef.Image;
      dataGridViewColumn2.Name = "Image";
      dataGridViewColumn2.ReadOnly = true;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewImageCell();
      dataGridViewColumn2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleMachineInstall) this).\u0001.Columns.Add(dataGridViewColumn2);
      DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
      dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn3.Width = 240 /*0xF0*/;
      dataGridViewColumn3.HeaderText = buLangTranslate.preDef.Explanation;
      dataGridViewColumn3.Name = "Name";
      dataGridViewColumn3.ReadOnly = false;
      dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleMachineInstall) this).\u0001.Columns.Add(dataGridViewColumn3);
      DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
      dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn4.Width = 90;
      dataGridViewColumn4.HeaderText = buLangTranslate.preChar.X;
      dataGridViewColumn4.Name = "X";
      dataGridViewColumn4.ReadOnly = false;
      dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleMachineInstall) this).\u0001.Columns.Add(dataGridViewColumn4);
      DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
      dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn5.Width = 90;
      dataGridViewColumn5.HeaderText = buLangTranslate.preChar.Y;
      dataGridViewColumn5.Name = "Y";
      dataGridViewColumn5.ReadOnly = false;
      dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn5.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleMachineInstall) this).\u0001.Columns.Add(dataGridViewColumn5);
      DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
      dataGridViewColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn6.Width = 90;
      dataGridViewColumn6.HeaderText = buLangTranslate.preChar.Z;
      dataGridViewColumn6.Name = "Z";
      dataGridViewColumn6.ReadOnly = false;
      dataGridViewColumn6.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn6.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn6.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleMachineInstall) this).\u0001.Columns.Add(dataGridViewColumn6);
      DataGridViewColumn dataGridViewColumn7 = new DataGridViewColumn();
      dataGridViewColumn7.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn7.Width = 90;
      dataGridViewColumn7.HeaderText = buLangTranslate.preChar.C;
      dataGridViewColumn7.Name = "C";
      dataGridViewColumn7.ReadOnly = false;
      dataGridViewColumn7.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn7.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn7.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleMachineInstall) this).\u0001.Columns.Add(dataGridViewColumn7);
      DataGridViewColumn dataGridViewColumn8 = new DataGridViewColumn();
      dataGridViewColumn8.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn8.Width = 90;
      dataGridViewColumn8.HeaderText = buLangTranslate.preChar.A;
      dataGridViewColumn8.Name = "A";
      dataGridViewColumn8.ReadOnly = false;
      dataGridViewColumn8.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn8.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn8.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleMachineInstall) this).\u0001.Columns.Add(dataGridViewColumn8);
      ((F_MarbleMachineInstall) this).\u0001.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12f, FontStyle.Bold);
    }
    ((F_MarbleMachineInstall) this).\u0001.RowHeadersVisible = false;
    ((F_MarbleMachineInstall) this).\u0001.AllowUserToAddRows = false;
    ((F_MarbleMachineInstall) this).\u0001.AllowUserToResizeColumns = false;
    ((F_MarbleMachineInstall) this).\u0001.ColumnHeadersVisible = true;
    if (((F_MarbleMachineInstall) this).\u0002.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn9 = new DataGridViewColumn();
      dataGridViewColumn9.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn9.Width = 35;
      dataGridViewColumn9.HeaderText = buLangTranslate.preDef.No;
      dataGridViewColumn9.Name = "No";
      dataGridViewColumn9.ReadOnly = true;
      dataGridViewColumn9.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn9.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn9.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleMachineInstall) this).\u0002.Columns.Add(dataGridViewColumn9);
      DataGridViewColumn dataGridViewColumn10 = new DataGridViewColumn();
      dataGridViewColumn10.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn10.Width = 60;
      dataGridViewColumn10.HeaderText = buLangTranslate.preDef.Image;
      dataGridViewColumn10.Name = "Image";
      dataGridViewColumn10.ReadOnly = true;
      dataGridViewColumn10.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn10.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn10.CellTemplate = (DataGridViewCell) new DataGridViewImageCell();
      dataGridViewColumn10.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleMachineInstall) this).\u0002.Columns.Add(dataGridViewColumn10);
      DataGridViewColumn dataGridViewColumn11 = new DataGridViewColumn();
      dataGridViewColumn11.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn11.Width = 240 /*0xF0*/;
      dataGridViewColumn11.HeaderText = buLangTranslate.preDef.Explanation;
      dataGridViewColumn11.Name = "Name";
      dataGridViewColumn11.ReadOnly = false;
      dataGridViewColumn11.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn11.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn11.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn11.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleMachineInstall) this).\u0002.Columns.Add(dataGridViewColumn11);
      DataGridViewColumn dataGridViewColumn12 = new DataGridViewColumn();
      dataGridViewColumn12.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn12.Width = 90;
      dataGridViewColumn12.HeaderText = buLangTranslate.preChar.X;
      dataGridViewColumn12.Name = "X";
      dataGridViewColumn12.ReadOnly = false;
      dataGridViewColumn12.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn12.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn12.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn12.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleMachineInstall) this).\u0002.Columns.Add(dataGridViewColumn12);
      DataGridViewColumn dataGridViewColumn13 = new DataGridViewColumn();
      dataGridViewColumn13.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn13.Width = 90;
      dataGridViewColumn13.HeaderText = buLangTranslate.preChar.Y;
      dataGridViewColumn13.Name = "Y";
      dataGridViewColumn13.ReadOnly = false;
      dataGridViewColumn13.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn13.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn13.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn13.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleMachineInstall) this).\u0002.Columns.Add(dataGridViewColumn13);
      DataGridViewColumn dataGridViewColumn14 = new DataGridViewColumn();
      dataGridViewColumn14.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn14.Width = 90;
      dataGridViewColumn14.HeaderText = buLangTranslate.preChar.Z;
      dataGridViewColumn14.Name = "Z";
      dataGridViewColumn14.ReadOnly = false;
      dataGridViewColumn14.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn14.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn14.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn14.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleMachineInstall) this).\u0002.Columns.Add(dataGridViewColumn14);
      DataGridViewColumn dataGridViewColumn15 = new DataGridViewColumn();
      dataGridViewColumn15.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn15.Width = 90;
      dataGridViewColumn15.HeaderText = buLangTranslate.preChar.C;
      dataGridViewColumn15.Name = "C";
      dataGridViewColumn15.ReadOnly = false;
      dataGridViewColumn15.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn15.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn15.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn15.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleMachineInstall) this).\u0002.Columns.Add(dataGridViewColumn15);
      DataGridViewColumn dataGridViewColumn16 = new DataGridViewColumn();
      dataGridViewColumn16.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn16.Width = 90;
      dataGridViewColumn16.HeaderText = buLangTranslate.preChar.A;
      dataGridViewColumn16.Name = "A";
      dataGridViewColumn16.ReadOnly = false;
      dataGridViewColumn16.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn16.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn16.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn16.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleMachineInstall) this).\u0002.Columns.Add(dataGridViewColumn16);
    }
    ((F_MarbleMachineInstall) this).\u0002.RowHeadersVisible = false;
    ((F_MarbleMachineInstall) this).\u0002.AllowUserToAddRows = false;
    ((F_MarbleMachineInstall) this).\u0002.AllowUserToResizeColumns = false;
    ((F_MarbleMachineInstall) this).\u0002.ColumnHeadersVisible = false;
    ((F_MarbleMachineInstall) this).FillG54();
    this.indexPark = clsAppMarbleVars.varApp.SelectedParkPosition;
    if (this.Parks.Count > 0 & this.indexPark == -1)
      this.indexPark = 0;
    if (this.ShowGeneralParks)
    {
      this.Height = 914;
      ((F_MarbleMachineInstall) this).\u0002.Visible = true;
      ((F_MarbleMachineInstall) this).\u0002.Visible = true;
    }
    else
    {
      this.Height = 655;
      ((F_MarbleMachineInstall) this).\u0002.Visible = false;
      ((F_MarbleMachineInstall) this).\u0002.Visible = false;
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

  public void Apply()
  {
    clsAppMarbleVars.varApp.ParkPositionAfterFinishType = !((F_MarbleMachineInstall) this).\u0002.Checked ? (!((F_MarbleMachineInstall) this).\u0003.Checked ? (MarbleParkModeAfterJob) 2 : MarbleParkModeAfterJob.Saw) : (MarbleParkModeAfterJob) 1;
    for (int index = 0; index <= this.Parks.Count - 1; ++index)
    {
      this.Parks[index].X = double.Parse(((F_MarbleMachineInstall) this).\u0001.Rows[index].Cells[3].Value.ToString());
      this.Parks[index].Y = double.Parse(((F_MarbleMachineInstall) this).\u0001.Rows[index].Cells[4].Value.ToString());
      this.Parks[index].Z = double.Parse(((F_MarbleMachineInstall) this).\u0001.Rows[index].Cells[5].Value.ToString());
      this.Parks[index].C = double.Parse(((F_MarbleMachineInstall) this).\u0001.Rows[index].Cells[6].Value.ToString());
      this.Parks[index].A = double.Parse(((F_MarbleMachineInstall) this).\u0001.Rows[index].Cells[7].Value.ToString());
      this.Parks[index].S = ((F_MarbleMachineInstall) this).\u0001.Rows[index].Cells[2].Value.ToString();
    }
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxX].AxisPar.Sets.setParkPosition = double.Parse(((F_MarbleMachineInstall) this).\u0002.Rows[0].Cells[3].Value.ToString());
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxY].AxisPar.Sets.setParkPosition = double.Parse(((F_MarbleMachineInstall) this).\u0002.Rows[0].Cells[4].Value.ToString());
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxZ].AxisPar.Sets.setParkPosition = double.Parse(((F_MarbleMachineInstall) this).\u0002.Rows[0].Cells[5].Value.ToString());
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxC].AxisPar.Sets.setParkPosition = double.Parse(((F_MarbleMachineInstall) this).\u0002.Rows[0].Cells[6].Value.ToString());
    clsAppMarbleVars.cMachine.AppAxis[clsAppMarbleVars.varRuntime.AxA].AxisPar.Sets.setParkPosition = double.Parse(((F_MarbleMachineInstall) this).\u0002.Rows[0].Cells[7].Value.ToString());
    clsAppMarbleVars.varApp.SawModePositionX = double.Parse(((F_MarbleMachineInstall) this).\u0002.Rows[1].Cells[3].Value.ToString());
    clsAppMarbleVars.varApp.SawModePositionY = double.Parse(((F_MarbleMachineInstall) this).\u0002.Rows[1].Cells[4].Value.ToString());
    clsAppMarbleVars.varApp.SawModePositionZ = double.Parse(((F_MarbleMachineInstall) this).\u0002.Rows[1].Cells[5].Value.ToString());
    clsAppMarbleVars.varApp.SawModePositionC = double.Parse(((F_MarbleMachineInstall) this).\u0002.Rows[1].Cells[6].Value.ToString());
    clsAppMarbleVars.varApp.SawModePositionA = double.Parse(((F_MarbleMachineInstall) this).\u0002.Rows[1].Cells[7].Value.ToString());
    clsAppMarbleVars.varApp.MillingModePositionX = double.Parse(((F_MarbleMachineInstall) this).\u0002.Rows[2].Cells[3].Value.ToString());
    clsAppMarbleVars.varApp.MillingModePositionY = double.Parse(((F_MarbleMachineInstall) this).\u0002.Rows[2].Cells[4].Value.ToString());
    clsAppMarbleVars.varApp.MillingModePositionZ = double.Parse(((F_MarbleMachineInstall) this).\u0002.Rows[2].Cells[5].Value.ToString());
    clsAppMarbleVars.varApp.MillingModePositionC = double.Parse(((F_MarbleMachineInstall) this).\u0002.Rows[2].Cells[6].Value.ToString());
    clsAppMarbleVars.varApp.MillingModePositionA = double.Parse(((F_MarbleMachineInstall) this).\u0002.Rows[2].Cells[7].Value.ToString());
    clsAppMarbleVars.varApp.MillingHeadModePositionX = double.Parse(((F_MarbleMachineInstall) this).\u0002.Rows[3].Cells[3].Value.ToString());
    clsAppMarbleVars.varApp.MillingHeadModePositionY = double.Parse(((F_MarbleMachineInstall) this).\u0002.Rows[3].Cells[4].Value.ToString());
    clsAppMarbleVars.varApp.MillingHeadModePositionZ = double.Parse(((F_MarbleMachineInstall) this).\u0002.Rows[3].Cells[5].Value.ToString());
    clsAppMarbleVars.varApp.MillingHeadModePositionC = double.Parse(((F_MarbleMachineInstall) this).\u0002.Rows[3].Cells[6].Value.ToString());
    clsAppMarbleVars.varApp.MillingHeadModePositionA = double.Parse(((F_MarbleMachineInstall) this).\u0002.Rows[3].Cells[7].Value.ToString());
    clsAppMarbleVars.varApp.WagonUpPositionX = double.Parse(((F_MarbleMachineInstall) this).\u0002.Rows[4].Cells[3].Value.ToString());
    clsAppMarbleVars.varApp.WagonUpPositionY = double.Parse(((F_MarbleMachineInstall) this).\u0002.Rows[4].Cells[4].Value.ToString());
    clsAppMarbleVars.varApp.WagonUpPositionZ = double.Parse(((F_MarbleMachineInstall) this).\u0002.Rows[4].Cells[5].Value.ToString());
    clsAppMarbleVars.varApp.WagonUpPositionC = double.Parse(((F_MarbleMachineInstall) this).\u0002.Rows[4].Cells[6].Value.ToString());
    clsAppMarbleVars.varApp.WagonUpPositionA = double.Parse(((F_MarbleMachineInstall) this).\u0002.Rows[4].Cells[7].Value.ToString());
  }
}
