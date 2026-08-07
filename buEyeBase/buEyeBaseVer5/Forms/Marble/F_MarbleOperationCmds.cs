// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleOperationCmds
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleOperationCmds : Form
{
  public buCheckBox chk_CommonPathCalculation;
  public buSpin spn_drilltargetZ;
  public buSpin spn_convexcornerextraoffset;
  public buSpin spn_concavecornerextraoffset;
  public static byte f002409;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public ToolBase5 ToolMilling;
  public ToolBase5[] Tools;
  public FormProperties PropertiesForm;
  private IContainer \u0001;
  internal buGround \u0001;
  internal buButton \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  public buButton btn_opentools;
  public buButton btn_savetools;
  public buTab buTab_command_settings;
  public TabPage tabPage_mlling;
  internal Panel \u0001;
  public buButton btn_milling_activate;
  public buButton btn_milling_zeroposition;
  public buButton btn_milling_limitdisable;
  public buButton btn_milling_measure;
  public buSpin spn_milling_speed;
  public buSpin spn_milling_length;
  public buSpin spn_milling_diameter;
  internal PictureBox \u0001;
  public buButton btn_magazine_zero;
  public buButton btn_magazine_disablelimit;
  public buButton btn_magazine_measure;
  public buSpin spn_toolspeed6;
  public buSpin spn_tooldia6;
  public buSpin spn_toollen6;
  public buSpin spn_toolspeed5;
  public buSpin spn_tooldia5;
  public buSpin spn_toollen5;
  public buSpin spn_toolspeed4;
  public buSpin spn_tooldia4;
  public buSpin spn_toollen4;
  public buSpin spn_toolspeed3;
  public buSpin spn_tooldia3;
  public buSpin spn_toollen3;
  public buSpin spn_toolspeed2;
  public buSpin spn_tooldia2;

  static F_MarbleOperationCmds() => F_MarbleToolSpindleAndMagazine.Captions = new List<string>();

  public F_MarbleOperationCmds()
  {
    ((F_MarbleToolSpindleAndMagazine) this).SpinBaseColor = Color.LightGreen;
    ((F_MarbleToolSpindleAndMagazine) this).SpinFocusColor = Color.MistyRose;
    ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm = new FormProperties();
    ((F_MarbleToolSpindleAndMagazine) this).Holes = new List<DiameterDepthPoint>();
    ((F_MarbleToolSpindleAndMagazine) this).Hole = (DiameterDepthPoint) new ShapeUpdateArg();
    ((F_MarbleToolSpindleAndMagazine) this).SelectedRowSheet = -1;
    ((F_MarbleToolSpindleAndMagazine) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleHoleTable) this);
  }

  public void Init()
  {
    ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Inited = false;
    if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Height;
    if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.FormPosition;
    ((F_MarbleToolSpindleAndMagazine) this).spn_depth.Value = ((SortResolutionSet) ((F_MarbleToolSpindleAndMagazine) this).Hole).Depth;
    ((F_MarbleToolSpindleAndMagazine) this).spn_dia.Value = ((SortResolutionSet) ((F_MarbleToolSpindleAndMagazine) this).Hole).Diameter;
    ((F_MarbleToolSpindleAndMagazine) this).spn_x.Value = ((SortResolutionSet) ((F_MarbleToolSpindleAndMagazine) this).Hole).Position.X;
    ((F_MarbleToolSpindleAndMagazine) this).spn_y.Value = ((SortResolutionSet) ((F_MarbleToolSpindleAndMagazine) this).Hole).Position.Y;
    ((F_MarbleToolSpindleAndMagazine) this).spn_z.Value = ((SortResolutionSet) ((F_MarbleToolSpindleAndMagazine) this).Hole).Position.Z;
    if (((F_MarbleToolSpindleAndMagazine) this).\u0001.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn1.Width = 40;
      dataGridViewColumn1.HeaderText = buLangTranslate.preDef.No;
      dataGridViewColumn1.Name = "No";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleToolSpindleAndMagazine) this).\u0001.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = 100;
      dataGridViewColumn2.HeaderText = "X";
      dataGridViewColumn2.Name = "X";
      dataGridViewColumn2.ReadOnly = false;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleToolSpindleAndMagazine) this).\u0001.Columns.Add(dataGridViewColumn2);
      DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
      dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn3.Width = 100;
      dataGridViewColumn3.HeaderText = "Y";
      dataGridViewColumn3.Name = "Y";
      dataGridViewColumn3.ReadOnly = false;
      dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleToolSpindleAndMagazine) this).\u0001.Columns.Add(dataGridViewColumn3);
      DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
      dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn4.Width = 100;
      dataGridViewColumn4.HeaderText = "Z";
      dataGridViewColumn4.Name = "Z";
      dataGridViewColumn4.ReadOnly = false;
      dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleToolSpindleAndMagazine) this).\u0001.Columns.Add(dataGridViewColumn4);
      DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
      dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn5.Width = 100;
      dataGridViewColumn5.HeaderText = buLangTranslate.preDef.Diameter;
      dataGridViewColumn5.Name = "Diameter";
      dataGridViewColumn5.ReadOnly = false;
      dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn5.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleToolSpindleAndMagazine) this).\u0001.Columns.Add(dataGridViewColumn5);
      DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
      dataGridViewColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn6.Width = 100;
      dataGridViewColumn6.HeaderText = buLangTranslate.preDef.Depth;
      dataGridViewColumn6.Name = "Depth";
      dataGridViewColumn6.ReadOnly = false;
      dataGridViewColumn6.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn6.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      ((F_MarbleToolSpindleAndMagazine) this).\u0001.Columns.Add(dataGridViewColumn6);
    }
    ((F_MarbleToolSpindleAndMagazine) this).\u0001.RowHeadersVisible = false;
    ((F_MarbleToolSpindleAndMagazine) this).\u0001.AllowUserToAddRows = false;
    ((F_MarbleToolSpindleAndMagazine) this).\u0001.AllowUserToResizeColumns = false;
    for (int index = 0; index <= ((F_MarbleToolSpindleAndMagazine) this).Holes.Count - 1; ++index)
    {
      DataGridViewRowCollection rows = ((F_MarbleToolSpindleAndMagazine) this).\u0001.Rows;
      double x = ((SortResolutionSet) ((F_MarbleToolSpindleAndMagazine) this).Holes[index]).Position.X;
      double y = ((SortResolutionSet) ((F_MarbleToolSpindleAndMagazine) this).Holes[index]).Position.Y;
      double z = ((SortResolutionSet) ((F_MarbleToolSpindleAndMagazine) this).Holes[index]).Position.Z;
      double diameter = ((SortResolutionSet) ((F_MarbleToolSpindleAndMagazine) this).Holes[index]).Diameter;
      double depth = ((SortResolutionSet) ((F_MarbleToolSpindleAndMagazine) this).Holes[index]).Depth;
      object[] objArray = \u0007.\u0001.\u0001(x, z, y, diameter, index + 1, (F_MarbleHoleTable) this, depth);
      rows.Add(objArray);
    }
    this.LoadLanguage();
    ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      if (F_MarbleToolSpindleAndMagazine.Captions.Count <= 14)
        return;
      ((F_MarbleToolSpindleAndMagazine) this).\u0001.Text = F_MarbleToolSpindleAndMagazine.Captions[0];
      ((F_MarbleToolSpindleAndMagazine) this).btn_ok.Text = F_MarbleToolSpindleAndMagazine.Captions[13];
      ((F_MarbleToolSpindleAndMagazine) this).btn_cancel.Text = F_MarbleToolSpindleAndMagazine.Captions[14];
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      buSpin buSpin = obj0 as buSpin;
      if (!AppBool.TouchPad)
        return;
      F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
      fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
      fKeyPadNumV1.Caption = buSpin.Caption.Caption;
      fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
      if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
        return;
      buSpin.Value = double.Parse(fKeyPadNumV1.Value);
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  internal void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!(obj1.RowIndex >= 0 & obj1.RowIndex <= ((F_MarbleToolSpindleAndMagazine) this).\u0001.Rows.Count - 1))
      return;
    ((F_MarbleToolSpindleAndMagazine) this).SelectedRowSheet = obj1.RowIndex;
    if (!AppBool.TouchPad)
      return;
    F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.ShowDialog(((F_MarbleToolSpindleAndMagazine) this).\u0001.Rows[((F_MarbleToolSpindleAndMagazine) this).SelectedRowSheet].Cells[obj1.ColumnIndex].Value.ToString());
    if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
      return;
    ((F_MarbleToolSpindleAndMagazine) this).\u0001.Rows[((F_MarbleToolSpindleAndMagazine) this).SelectedRowSheet].Cells[obj1.ColumnIndex].Value = (object) fKeyPadNumV1.Value.ToString();
  }

  internal void \u0002([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (obj1.RowIndex >= 0 & obj1.RowIndex <= ((F_MarbleToolSpindleAndMagazine) this).\u0001.Rows.Count - 1)
      ;
  }

  internal void \u0003([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!(obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0) || obj1.ColumnIndex == 1 & obj1.RowIndex <= ((F_MarbleToolSpindleAndMagazine) this).\u0001.Rows.Count - 1)
      ;
  }

  public void Apply()
  {
    ((SortResolutionSet) ((F_MarbleToolSpindleAndMagazine) this).Hole).Depth = ((F_MarbleToolSpindleAndMagazine) this).spn_depth.Value;
    ((SortResolutionSet) ((F_MarbleToolSpindleAndMagazine) this).Hole).Diameter = ((F_MarbleToolSpindleAndMagazine) this).spn_dia.Value;
    ((SortResolutionSet) ((F_MarbleToolSpindleAndMagazine) this).Hole).Position.X = ((F_MarbleToolSpindleAndMagazine) this).spn_x.Value;
    ((SortResolutionSet) ((F_MarbleToolSpindleAndMagazine) this).Hole).Position.Y = ((F_MarbleToolSpindleAndMagazine) this).spn_y.Value;
    ((SortResolutionSet) ((F_MarbleToolSpindleAndMagazine) this).Hole).Position.Z = ((F_MarbleToolSpindleAndMagazine) this).spn_z.Value;
    for (int index = 0; index <= ((F_MarbleToolSpindleAndMagazine) this).\u0001.Rows.Count - 1; ++index)
    {
      if (index <= ((F_MarbleToolSpindleAndMagazine) this).Holes.Count - 1)
      {
        if (buFile5.IsNumeric(((F_MarbleToolSpindleAndMagazine) this).\u0001.Rows[index].Cells[1].Value.ToString()))
          ((SortResolutionSet) ((F_MarbleToolSpindleAndMagazine) this).Holes[index]).Position.X = Convert.ToDouble(((F_MarbleToolSpindleAndMagazine) this).\u0001.Rows[index].Cells[1].Value.ToString());
        if (buFile5.IsNumeric(((F_MarbleToolSpindleAndMagazine) this).\u0001.Rows[index].Cells[2].Value.ToString()))
          ((SortResolutionSet) ((F_MarbleToolSpindleAndMagazine) this).Holes[index]).Position.Y = Convert.ToDouble(((F_MarbleToolSpindleAndMagazine) this).\u0001.Rows[index].Cells[2].Value.ToString());
        if (buFile5.IsNumeric(((F_MarbleToolSpindleAndMagazine) this).\u0001.Rows[index].Cells[3].Value.ToString()))
          ((SortResolutionSet) ((F_MarbleToolSpindleAndMagazine) this).Holes[index]).Position.Z = Convert.ToDouble(((F_MarbleToolSpindleAndMagazine) this).\u0001.Rows[index].Cells[3].Value.ToString());
        if (buFile5.IsNumeric(((F_MarbleToolSpindleAndMagazine) this).\u0001.Rows[index].Cells[4].Value.ToString()))
          ((SortResolutionSet) ((F_MarbleToolSpindleAndMagazine) this).Holes[index]).Diameter = Convert.ToDouble(((F_MarbleToolSpindleAndMagazine) this).\u0001.Rows[index].Cells[4].Value.ToString());
        if (buFile5.IsNumeric(((F_MarbleToolSpindleAndMagazine) this).\u0001.Rows[index].Cells[5].Value.ToString()))
          ((SortResolutionSet) ((F_MarbleToolSpindleAndMagazine) this).Holes[index]).Depth = Convert.ToDouble(((F_MarbleToolSpindleAndMagazine) this).\u0001.Rows[index].Cells[5].Value.ToString());
      }
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_MarbleToolSpindleAndMagazine) this).btn_add.Name)
      ((F_MarbleToolSpindleAndMagazine) this).\u0001.Visible = true;
    if (control.Name == ((F_MarbleToolSpindleAndMagazine) this).btn_closehole.Name)
      ((F_MarbleToolSpindleAndMagazine) this).\u0001.Visible = false;
    if (control.Name == ((F_MarbleToolSpindleAndMagazine) this).btn_addhole.Name)
    {
      DiameterDepthPoint diameterDepthPoint = (DiameterDepthPoint) new ShapeUpdateArg();
      ((SortResolutionSet) diameterDepthPoint).Diameter = ((F_MarbleToolSpindleAndMagazine) this).spn_dia.Value;
      ((SortResolutionSet) diameterDepthPoint).Depth = ((F_MarbleToolSpindleAndMagazine) this).spn_depth.Value;
      ((SortResolutionSet) diameterDepthPoint).Position.X = ((F_MarbleToolSpindleAndMagazine) this).spn_x.Value;
      ((SortResolutionSet) diameterDepthPoint).Position.Y = ((F_MarbleToolSpindleAndMagazine) this).spn_y.Value;
      ((SortResolutionSet) diameterDepthPoint).Position.Z = ((F_MarbleToolSpindleAndMagazine) this).spn_z.Value;
      ((F_MarbleToolSpindleAndMagazine) this).Holes.Add(diameterDepthPoint);
      DataGridViewRowCollection rows = ((F_MarbleToolSpindleAndMagazine) this).\u0001.Rows;
      int count = ((F_MarbleToolSpindleAndMagazine) this).Holes.Count;
      double x = ((SortResolutionSet) diameterDepthPoint).Position.X;
      double y = ((SortResolutionSet) diameterDepthPoint).Position.Y;
      double z = ((SortResolutionSet) diameterDepthPoint).Position.Z;
      double diameter = ((SortResolutionSet) diameterDepthPoint).Diameter;
      double depth = ((SortResolutionSet) diameterDepthPoint).Depth;
      object[] objArray = \u0007.\u0001.\u0001(x, z, y, diameter, count, (F_MarbleHoleTable) this, depth);
      rows.Add(objArray);
      ((F_MarbleToolSpindleAndMagazine) this).\u0001.Visible = false;
    }
    if (control.Name == ((F_MarbleToolSpindleAndMagazine) this).btn_remove.Name && ((F_MarbleToolSpindleAndMagazine) this).SelectedRowSheet >= 0 & ((F_MarbleToolSpindleAndMagazine) this).SelectedRowSheet <= ((F_MarbleToolSpindleAndMagazine) this).\u0001.Rows.Count - 1)
      ((F_MarbleToolSpindleAndMagazine) this).\u0001.Rows.RemoveAt(((F_MarbleToolSpindleAndMagazine) this).SelectedRowSheet);
    if (control.Name == ((F_MarbleToolSpindleAndMagazine) this).btn_delete.Name)
      ((F_MarbleToolSpindleAndMagazine) this).\u0001.Rows.Clear();
    if (!(control.Name == ((F_MarbleToolSpindleAndMagazine) this).btn_ok.Name))
      return;
    this.Apply();
    ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public event OkCommandWithFiveDataEventHandler CommandExecute;
}
