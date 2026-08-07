// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleToolSawMillingHeadMilling
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.DialogBox;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleToolSawMillingHeadMilling : Form
{
  internal RadioButton \u0007;
  internal RadioButton \u0008;
  internal TabPage \u0002;
  public buTab buTab_command_settings;
  public TabPage tabPage_saw;
  public TabPage tabPage_mlling;
  internal TabPage \u0003;
  internal buListBox \u0001;
  internal buTextBox \u0001;
  public buButton btn_material;
  public buButton btn_matsave;
  internal buTextBox \u0002;
  internal RadioButton \u000E;
  internal RadioButton \u000F;
  internal RadioButton \u0010;
  internal RadioButton \u0011;
  internal RadioButton \u0012;
  internal PictureBox \u0002;
  public buSpin spn_matsawplungespeed;
  public buSpin spn_matsawcircularcutFwdspeed;
  public buSpin spn_matsawstraightcutfirststep;
  public buSpin spn_matsawcircularcutstep;
  public buSpin spn_matsawcircularcutfirststep;
  public buSpin spn_matsawcircularcutfirstspeed;
  public buSpin spn_matsawstraightcutfirstspeed;
  public buSpin spn_matsawstraightcuttingsFwdspeed;
  public buSpin spn_matsawstraightcutstep;
  public buSpin spn_matmillingdrillspeed;
  public buSpin spn_matmillingfirstcutstep;
  public buSpin spn_matmillingcutstep;
  public buSpin spn_matmillingfirstcutspeed;
  public buSpin spn_matmillingplungespeed;
  public buSpin spn_matmillingcutspeed;
  public buSpin spn_matmillingheadfirstcutstep;
  public buSpin spn_matmillingheadcutstep;
  public buSpin spn_matmillingheaddrillspeed;
  public buSpin spn_matmillingheadfirstcutspeed;
  public buSpin spn_matmillingheadcutspeed;
  public buSpin spn_matmillingheadplungespeed;
  public buButton btn_matapply;
  internal buLabel \u000E;
  internal buLabel \u000F;
  public buSpin spn_sawcircularcutBwdspeed;
  public buSpin spn_sawstraightcuttingsBwdspeed;
  internal buLabel \u0010;
  internal buLabel \u0011;
  internal buLabel \u0012;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleCamSettings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleCamSettings) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleToolSawMillingHeadMilling() => F_MarbleCamSettings.Captions = new List<string>();

  public F_MarbleToolSawMillingHeadMilling()
  {
    ((F_MarbleCamSettings) this).PropertiesForm = new FormProperties();
    ((F_MarbleCamSettings) this).SelectedRow = -1;
    ((F_MarbleCamSettings) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleCircularShapeResolution) this);
  }

  public void Init()
  {
    ((F_MarbleCamSettings) this).PropertiesForm.Inited = false;
    if (((F_MarbleCamSettings) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleCamSettings) this).PropertiesForm.Height;
    if (((F_MarbleCamSettings) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleCamSettings) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleCamSettings) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleCamSettings) this).PropertiesForm.FormPosition;
    if (!((F_MarbleCamSettings) this).PropertiesForm.VisualUpdated)
      this.InitVisual();
    if (((F_MarbleCamSettings) this).\u0001.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn1.Width = 40;
      dataGridViewColumn1.HeaderText = buLangTranslate.preDef.Number;
      dataGridViewColumn1.Name = "No";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleCamSettings) this).\u0001.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = 130;
      dataGridViewColumn2.HeaderText = $"{buLangTranslate.preDef.Min} {buLangTranslate.preDef.Diameter}";
      dataGridViewColumn2.Name = "MinDiameter";
      dataGridViewColumn2.ReadOnly = false;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleCamSettings) this).\u0001.Columns.Add(dataGridViewColumn2);
      DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
      dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn3.Width = 130;
      dataGridViewColumn3.HeaderText = $"{buLangTranslate.preDef.Max} {buLangTranslate.preDef.Diameter}";
      dataGridViewColumn3.Name = "MaxDiameter";
      dataGridViewColumn3.ReadOnly = false;
      dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleCamSettings) this).\u0001.Columns.Add(dataGridViewColumn3);
      DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
      dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn4.Width = 140;
      dataGridViewColumn4.HeaderText = $"{buLangTranslate.preDef.Devide} {buLangTranslate.preDef.Length}";
      dataGridViewColumn4.Name = "Len";
      dataGridViewColumn4.ReadOnly = false;
      dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleCamSettings) this).\u0001.Columns.Add(dataGridViewColumn4);
      DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
      dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn5.Width = 180;
      dataGridViewColumn5.HeaderText = buLangTranslate.preSentences.RegenDeviation;
      dataGridViewColumn5.Name = "Regen";
      dataGridViewColumn5.ReadOnly = false;
      dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn5.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleCamSettings) this).\u0001.Columns.Add(dataGridViewColumn5);
    }
    ((F_MarbleCamSettings) this).\u0001.RowHeadersVisible = false;
    ((F_MarbleCamSettings) this).\u0001.AllowUserToAddRows = false;
    ((F_MarbleCamSettings) this).\u0001.AllowUserToResizeColumns = false;
    ((F_MarbleCamSettings) this).\u0001.ColumnHeadersVisible = true;
    this.FillInfo();
    this.LoadLanguage();
    ((F_MarbleCamSettings) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleCamSettings) this).PropertiesForm.Inited = true;
  }

  public void InitVisual()
  {
    if (new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm").Exists)
    {
      Control.ControlCollection controlCollection = (Control.ControlCollection) null;
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleCamSettings) this).\u0001.Controls);
    }
    ((F_MarbleCamSettings) this).PropertiesForm.VisualUpdated = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleCamSettings) this).\u0001.Text = $"{buLangTranslate.preDef.Shape} {buLangTranslate.preDef.Resolution}";
      ((F_MarbleCamSettings) this).\u0001.Text = buLangTranslate.preDef.Ok;
      ((F_MarbleCamSettings) this).\u0002.Text = buLangTranslate.preDef.Cancel;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleCamSettings) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleCamSettings) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleCamSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleCamSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    MarbleEntitiesSettings.CircularShapeResolutions.Clear();
    for (int index = 0; index <= ((F_MarbleCamSettings) this).\u0001.Rows.Count - 1; ++index)
    {
      GeometryTableItem geometryTableItem = (GeometryTableItem) new buCompare5();
      ((buGCodeCreate) geometryTableItem).DiameterMin = double.Parse(((F_MarbleCamSettings) this).\u0001.Rows[index].Cells[1].Value.ToString());
      ((buGCodeCreate) geometryTableItem).DiameterMax = double.Parse(((F_MarbleCamSettings) this).\u0001.Rows[index].Cells[2].Value.ToString());
      ((buGCodeCreate) geometryTableItem).DevideLength = double.Parse(((F_MarbleCamSettings) this).\u0001.Rows[index].Cells[3].Value.ToString());
      ((SerilizationMode5) geometryTableItem).RegenDeviation = double.Parse(((F_MarbleCamSettings) this).\u0001.Rows[index].Cells[4].Value.ToString());
      MarbleEntitiesSettings.CircularShapeResolutions.Add(geometryTableItem);
    }
    ((F_MarbleCamSettings) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_MarbleCamSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleCamSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleCamSettings) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleCamSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleCamSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void FillInfo()
  {
    ((F_MarbleCamSettings) this).\u0001.Rows.Clear();
    for (int index = 0; index <= MarbleEntitiesSettings.CircularShapeResolutions.Count - 1; ++index)
    {
      DataGridViewRowCollection rows = ((F_MarbleCamSettings) this).\u0001.Rows;
      double diameterMin = ((buGCodeCreate) MarbleEntitiesSettings.CircularShapeResolutions[index]).DiameterMin;
      double diameterMax = ((buGCodeCreate) MarbleEntitiesSettings.CircularShapeResolutions[index]).DiameterMax;
      double devideLength = ((buGCodeCreate) MarbleEntitiesSettings.CircularShapeResolutions[index]).DevideLength;
      object[] objArray = \u0007.\u0001.\u0001(((SerilizationMode5) MarbleEntitiesSettings.CircularShapeResolutions[index]).RegenDeviation, diameterMin, devideLength, index + 1, diameterMax, (F_MarbleCircularShapeResolution) this);
      rows.Add(objArray);
      ((F_MarbleCamSettings) this).\u0001.Rows[((F_MarbleCamSettings) this).\u0001.Rows.Count - 1].Height = 40;
    }
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_MarbleCamSettings) this).btn_add.Name)
    {
      ((F_MarbleCamSettings) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(0.0, 0.0, 0.0, ((F_MarbleCamSettings) this).\u0001.Rows.Count, 0.0, (F_MarbleCircularShapeResolution) this));
      ((F_MarbleCamSettings) this).\u0001.Rows[((F_MarbleCamSettings) this).\u0001.Rows.Count - 1].Height = 40;
    }
    if (!(control.Name == ((F_MarbleCamSettings) this).btn_remove.Name) || !(((F_MarbleCamSettings) this).\u0001.Rows.Count > 0 & ((F_MarbleCamSettings) this).SelectedRow >= 0 & ((F_MarbleCamSettings) this).SelectedRow <= ((F_MarbleCamSettings) this).\u0001.Rows.Count - 1))
      return;
    buDialogMessageBoxYesNo dialogMessageBoxYesNo = new buDialogMessageBoxYesNo();
    dialogMessageBoxYesNo.StartPosition = FormStartPosition.CenterScreen;
    dialogMessageBoxYesNo.Init(buLangTranslate.preDef.Delete, buLangTranslate.preSentences.DoYouWantToDelete);
    int num = (int) dialogMessageBoxYesNo.ShowDialog();
    if (dialogMessageBoxYesNo.Result != DialogResult.Yes)
      return;
    ((F_MarbleCamSettings) this).\u0001.Rows.RemoveAt(((F_MarbleCamSettings) this).SelectedRow);
  }
}
