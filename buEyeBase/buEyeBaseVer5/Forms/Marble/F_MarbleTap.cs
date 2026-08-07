// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleTap
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Apps.Robotic;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleTap : Form
{
  private Timer \u0001;
  private DrawingTypes \u0001;
  private List<buEntity> \u0001;
  private Point3D \u0001;
  private Point3D \u0002;
  internal IContainer \u0001;
  public buButton buButton1;
  public buButton btn_maximize;
  public buButton btn_close;
  public buGround buGround1;
  public buButton btn_open;
  public buButton btn_ok;
  public buLabel lbl_countertop;
  public Panel pnl_base;
  public buButton btn_save;
  public Panel pnl_data;
  public buButton btn_addtolist;
  internal buCheckBox \u0001;
  public buButton btn_cancel;
  public buButton btn_settings;
  public Panel pnl_viewport;
  public buLabel lbl_commands;
  public buButton btn_viewtop;
  public buButton btn_viewback;
  public buButton btn_viewfront;

  public F_MarbleTap()
  {
    ((F_Marble3DAddMenu) this).PropertiesForm = new FormProperties();
    ((F_Marble3DAddMenu) this).ImageList = new List<MarbleImageThicknessData>();
    ((F_Marble3DAddMenu) this).indexG54 = -1;
    ((F_Marble3DAddMenu) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleImageThicknessList) this);
  }

  public void Init()
  {
    ((F_Marble3DAddMenu) this).PropertiesForm.Inited = false;
    if (((F_Marble3DAddMenu) this).PropertiesForm.Height > 10)
      this.Height = ((F_Marble3DAddMenu) this).PropertiesForm.Height;
    if (((F_Marble3DAddMenu) this).PropertiesForm.Width > 10)
      this.Width = ((F_Marble3DAddMenu) this).PropertiesForm.Width;
    this.TopMost = ((F_Marble3DAddMenu) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_Marble3DAddMenu) this).PropertiesForm.FormPosition;
    if (((F_MarbleBackupLoad) this).\u0001.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn1.Width = 35;
      dataGridViewColumn1.HeaderText = buLangTranslate.preDef.Number;
      dataGridViewColumn1.Name = "No";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleBackupLoad) this).\u0001.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = 90;
      dataGridViewColumn2.HeaderText = buLangTranslate.preChar.X;
      dataGridViewColumn2.Name = "X";
      dataGridViewColumn2.ReadOnly = false;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleBackupLoad) this).\u0001.Columns.Add(dataGridViewColumn2);
      DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
      dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn3.Width = 90;
      dataGridViewColumn3.HeaderText = buLangTranslate.preChar.Y;
      dataGridViewColumn3.Name = "Y";
      dataGridViewColumn3.ReadOnly = false;
      dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleBackupLoad) this).\u0001.Columns.Add(dataGridViewColumn3);
      DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
      dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn4.Width = 90;
      dataGridViewColumn4.HeaderText = buLangTranslate.preDef.Width;
      dataGridViewColumn4.Name = "Width";
      dataGridViewColumn4.ReadOnly = false;
      dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleBackupLoad) this).\u0001.Columns.Add(dataGridViewColumn4);
      DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
      dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn5.Width = 90;
      dataGridViewColumn5.HeaderText = buLangTranslate.preDef.Height;
      dataGridViewColumn5.Name = "Height";
      dataGridViewColumn5.ReadOnly = false;
      dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn5.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleBackupLoad) this).\u0001.Columns.Add(dataGridViewColumn5);
      DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
      dataGridViewColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn6.Width = 90;
      dataGridViewColumn6.HeaderText = buLangTranslate.preDef.Thickness;
      dataGridViewColumn6.Name = "Thickness";
      dataGridViewColumn6.ReadOnly = false;
      dataGridViewColumn6.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn6.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn6.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleBackupLoad) this).\u0001.Columns.Add(dataGridViewColumn6);
      DataGridViewColumn dataGridViewColumn7 = new DataGridViewColumn();
      dataGridViewColumn7.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn7.Width = 200;
      dataGridViewColumn7.HeaderText = buLangTranslate.preDef.Explanation;
      dataGridViewColumn7.Name = "Name";
      dataGridViewColumn7.ReadOnly = false;
      dataGridViewColumn7.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn7.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn7.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleBackupLoad) this).\u0001.Columns.Add(dataGridViewColumn7);
    }
    ((F_MarbleBackupLoad) this).\u0001.RowHeadersVisible = false;
    ((F_MarbleBackupLoad) this).\u0001.AllowUserToAddRows = false;
    ((F_MarbleBackupLoad) this).\u0001.AllowUserToResizeColumns = false;
    this.FillG54();
    ((F_Marble3DAddMenu) this).indexG54 = -1;
    if (((F_Marble3DAddMenu) this).ImageList.Count > 0)
      ((F_Marble3DAddMenu) this).indexG54 = 0;
    ((F_Marble3DAddMenu) this).PropertiesForm.Result = DialogResult.None;
    ((F_Marble3DAddMenu) this).PropertiesForm.Inited = true;
    \u0007.\u0001.\u0001((F_MarbleImageThicknessList) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_Marble3DAddMenu) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_Marble3DAddMenu) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_Marble3DAddMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_Marble3DAddMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
    ((F_Marble3DAddMenu) this).ImageList.Clear();
    for (int index = 0; index <= ((F_MarbleBackupLoad) this).\u0001.Rows.Count - 1; ++index)
    {
      MarbleImageThicknessData imageThicknessData = (MarbleImageThicknessData) new \u0007.\u0001();
      ((RoboticSettings) imageThicknessData).XOffset = double.Parse(((F_MarbleBackupLoad) this).\u0001.Rows[index].Cells[1].Value.ToString());
      ((RoboticSettings) imageThicknessData).YOffset = double.Parse(((F_MarbleBackupLoad) this).\u0001.Rows[index].Cells[2].Value.ToString());
      ((RoboticSettings) imageThicknessData).DeltaWidth = double.Parse(((F_MarbleBackupLoad) this).\u0001.Rows[index].Cells[3].Value.ToString());
      ((RoboticSettings) imageThicknessData).DeltaHeight = double.Parse(((F_MarbleBackupLoad) this).\u0001.Rows[index].Cells[4].Value.ToString());
      ((RoboticSettings) imageThicknessData).Thickness = double.Parse(((F_MarbleBackupLoad) this).\u0001.Rows[index].Cells[5].Value.ToString());
      ((RoboticSettings) imageThicknessData).Explanation = ((F_MarbleBackupLoad) this).\u0001.Rows[index].Cells[5].Value.ToString();
      ((F_Marble3DAddMenu) this).ImageList.Add(imageThicknessData);
    }
  }

  public void FillG54()
  {
    ((F_MarbleBackupLoad) this).\u0001.Rows.Clear();
    for (int index = 0; index <= ((F_Marble3DAddMenu) this).ImageList.Count - 1; ++index)
    {
      DataGridViewRowCollection rows = ((F_MarbleBackupLoad) this).\u0001.Rows;
      double xoffset = ((RoboticSettings) ((F_Marble3DAddMenu) this).ImageList[index]).XOffset;
      double yoffset = ((RoboticSettings) ((F_Marble3DAddMenu) this).ImageList[index]).YOffset;
      double deltaWidth = ((RoboticSettings) ((F_Marble3DAddMenu) this).ImageList[index]).DeltaWidth;
      double deltaHeight = ((RoboticSettings) ((F_Marble3DAddMenu) this).ImageList[index]).DeltaHeight;
      double thickness = ((RoboticSettings) ((F_Marble3DAddMenu) this).ImageList[index]).Thickness;
      string explanation = ((RoboticSettings) ((F_Marble3DAddMenu) this).ImageList[index]).Explanation;
      object[] objArray = \u0007.\u0001.\u0001(index + 1, explanation, xoffset, deltaWidth, yoffset, (F_MarbleImageThicknessList) this, thickness, deltaHeight);
      rows.Add(objArray);
      ((F_MarbleBackupLoad) this).\u0001.Rows[((F_MarbleBackupLoad) this).\u0001.Rows.Count - 1].Height = 40;
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control = obj0 as Control;
      if (control.Name == ((F_Marble3DAddMenu) this).btn_ok.Name)
      {
        this.Apply();
        ((F_Marble3DAddMenu) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_Marble3DAddMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_Marble3DAddMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control.Name == ((F_Marble3DAddMenu) this).btn_close.Name | control.Name == ((F_MarbleBackupLoad) this).btn_cancel.Name)
      {
        ((F_Marble3DAddMenu) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((F_Marble3DAddMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_Marble3DAddMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control.Name == ((F_MarbleBackupLoad) this).btn_add.Name)
        ((F_MarbleBackupLoad) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(((F_Marble3DAddMenu) this).ImageList.Count, "", 0.0, 0.0, 0.0, (F_MarbleImageThicknessList) this, 0.0, 0.0));
      if (control.Name == ((F_MarbleBackupLoad) this).btn_g54open.Name)
        ;
      if (control.Name == ((F_MarbleBackupLoad) this).btn_g54save.Name)
        ;
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
    ((F_Marble3DAddMenu) this).indexG54 = obj1.RowIndex;
    if (((F_Marble3DAddMenu) this).indexG54 >= 0)
      ;
  }
}
