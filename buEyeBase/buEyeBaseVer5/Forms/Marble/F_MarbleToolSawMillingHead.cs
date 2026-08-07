// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleToolSawMillingHead
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

public class F_MarbleToolSawMillingHead : Form
{
  internal RadioButton \u0006;
  public buSpin spn_sawplungespeed;
  public buSpin spn_sawstraightcutfirststep;
  public buSpin spn_sawsafedistance;
  public buSpin spn_sawcircularcutfirststep;
  public buSpin spn_sawrapiddistance;
  public buSpin spn_sawstraightcutfirstspeed;
  public buSpin spn_sawcircularcutFwdspeed;
  public buSpin spn_sawcircularcutstep;
  public buSpin spn_sawstraightcutstep;
  public buSpin spn_sawcircularcutfirstspeed;
  public buSpin spn_sawstraightcuttingsFwdspeed;
  internal buLabel \u0003;
  public buSpin spn_millingdrillspeed;
  public buSpin spn_millingfirstcutstep;
  public buSpin spn_millingcutspeed;
  public buSpin spn_millingplungespeed;
  public buSpin spn_millingfirstcutspeed;
  public buSpin spn_millingcutstep;
  internal buLabel \u0004;
  public buSpin spn_millingheadfirstcutstep;
  public buSpin spn_millingheaddrillspeed;
  public buSpin spn_millingheadcutspeed;
  public buSpin spn_millingheadplungespeed;
  public buSpin spn_millingheadfirstcutspeed;
  public buSpin spn_millingheadcutstep;
  internal buLabel \u0005;
  public buSpin spn_sawplungefirstspeed;
  public buSpin spn_millingplungefirstspeed;
  public buSpin spn_millingheadplungefirstspeed;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal PictureBox \u0001;
  internal buLabel \u0006;
  internal buLabel \u0007;
  internal buLabel \u0008;

  static F_MarbleToolSawMillingHead() => F_MarbleCamSettings.Captions = new List<string>();

  public F_MarbleToolSawMillingHead()
  {
    ((F_MarbleCamSettings) this).PropertiesForm = new FormProperties();
    ((F_MarbleCamSettings) this).SelectedRow = -1;
    ((F_MarbleCamSettings) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0018.\u0002.\u0003.\u0001((F_MarbleCircularSpeed) this);
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
      dataGridViewColumn2.Width = 182;
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
      dataGridViewColumn3.Width = 182;
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
      dataGridViewColumn4.Width = 182;
      dataGridViewColumn4.HeaderText = $"{buLangTranslate.preDef.Speed} {buLangTranslate.preDef.Persentage}";
      dataGridViewColumn4.Name = "Persentage";
      dataGridViewColumn4.ReadOnly = false;
      dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleCamSettings) this).\u0001.Columns.Add(dataGridViewColumn4);
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
    MarbleEntitiesSettings.CircularSpeedReductions.Clear();
    for (int index = 0; index <= ((F_MarbleCamSettings) this).\u0001.Rows.Count - 1; ++index)
    {
      CircularSpeedReduction circularSpeedReduction = (CircularSpeedReduction) new buCompare5();
      ((SerilizationMode5) circularSpeedReduction).MinDiameter = double.Parse(((F_MarbleCamSettings) this).\u0001.Rows[index].Cells[1].Value.ToString());
      ((SerilizationMode5) circularSpeedReduction).MaxDiameter = double.Parse(((F_MarbleCamSettings) this).\u0001.Rows[index].Cells[2].Value.ToString());
      ((cParameter5) circularSpeedReduction).Persentage = double.Parse(((F_MarbleCamSettings) this).\u0001.Rows[index].Cells[3].Value.ToString());
      MarbleEntitiesSettings.CircularSpeedReductions.Add(circularSpeedReduction);
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
    for (int index = 0; index <= MarbleEntitiesSettings.CircularSpeedReductions.Count - 1; ++index)
    {
      DataGridViewRowCollection rows = ((F_MarbleCamSettings) this).\u0001.Rows;
      double minDiameter = ((SerilizationMode5) MarbleEntitiesSettings.CircularSpeedReductions[index]).MinDiameter;
      double maxDiameter = ((SerilizationMode5) MarbleEntitiesSettings.CircularSpeedReductions[index]).MaxDiameter;
      object[] objArray = \u0007.\u0001.\u0001(((cParameter5) MarbleEntitiesSettings.CircularSpeedReductions[index]).Persentage, maxDiameter, index + 1, (F_MarbleCircularSpeed) this, minDiameter);
      rows.Add(objArray);
      ((F_MarbleCamSettings) this).\u0001.Rows[((F_MarbleCamSettings) this).\u0001.Rows.Count - 1].Height = 40;
    }
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_MarbleCamSettings) this).btn_add.Name)
    {
      ((F_MarbleCamSettings) this).\u0001.Rows.Add(\u0007.\u0001.\u0001(0.0, 0.0, ((F_MarbleCamSettings) this).\u0001.Rows.Count, (F_MarbleCircularSpeed) this, 0.0));
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

  internal void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    ((F_MarbleCamSettings) this).SelectedRow = obj1.RowIndex;
  }
}
