// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleCuttingSequence
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
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

public class F_MarbleCuttingSequence : Form
{
  public buButton btn_itemok;
  public buButton btn_cancel;
  public buLabel lbl_length;
  public buLabel lbl_5;
  public buLabel lbl_4;
  public buLabel lbl_3;
  public buLabel lbl_2;
  public buLabel lbl_1;
  public buLabel lbl_ea;
  public buLabel lbl_sa;
  public buLabel lbl_count;
  public buLabel lbl_7;
  public buSpin spn_itemEA7;
  public buSpin spn_itemSA7;
  public buSpin spn_itemcount7;
  public buSpin spn_itemlen7;

  public void UpdateVisuals()
  {
    string str = nameof (UpdateVisuals);
    try
    {
      if (clsVisualVars.parVisual == null)
        return;
      if (!((F_MarbleHorVerCutV2) this).PropertiesForm.VisualUpdated | AppBool.VisualUpdateForce && new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm").Exists)
      {
        Control.ControlCollection controlCollection = (Control.ControlCollection) null;
        controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleHorVerCutV2) this).buGround1.Controls);
        ((F_MarbleHorVerCutV2) this).PropertiesForm.VisualUpdated = true;
      }
      \u0007.\u0001.\u0001((F_MarbleVacuumMove) this);
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleHorVerCutV2) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleHorVerCutV2) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleHorVerCutV2) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleHorVerCutV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleHorVerCutV2) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control = obj0 as Control;
      if (control.Name == ((F_MarbleHorVerCutV2) this).btn_close.Name)
      {
        ((F_MarbleHorVerCutV2) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((F_MarbleHorVerCutV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleHorVerCutV2) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        if (((F_MarbleHorVerCutV2) this).\u0001 == null)
          return;
        ((F_MarbleHorVerCutV2) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_MarbleHorVerCutV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleHorVerCutV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
        if (control.Name == ((F_MarbleHorVerCutV2) this).btn_goleft.Name)
        {
          // ISSUE: reference to a compiler-generated field
          ((F_MarbleHorVerCutV2) this).\u0001((object) (MarbleCadCamCommands) 9, (object) ((F_MarbleHorVerCutV2) this).spn_distance.Value, (object) (MarbleVacuumCommands) 1, (object) null, (object) null);
        }
        if (control.Name == ((F_MarbleHorVerCutV2) this).btn_gofwd.Name)
        {
          // ISSUE: reference to a compiler-generated field
          ((F_MarbleHorVerCutV2) this).\u0001((object) (MarbleCadCamCommands) 12, (object) ((F_MarbleHorVerCutV2) this).spn_distance.Value, (object) (MarbleVacuumCommands) 1, (object) null, (object) null);
        }
        if (control.Name == ((F_MarbleHorVerCutV2) this).btn_gobwd.Name)
        {
          // ISSUE: reference to a compiler-generated field
          ((F_MarbleHorVerCutV2) this).\u0001((object) (MarbleCadCamCommands) 13, (object) ((F_MarbleHorVerCutV2) this).spn_distance.Value, (object) (MarbleVacuumCommands) 1, (object) null, (object) null);
        }
        if (control.Name == ((F_MarbleHorVerCutV2) this).btn_goright.Name)
        {
          // ISSUE: reference to a compiler-generated field
          ((F_MarbleHorVerCutV2) this).\u0001((object) (MarbleCadCamCommands) 14, (object) ((F_MarbleHorVerCutV2) this).spn_distance.Value, (object) (MarbleVacuumCommands) 1, (object) null, (object) null);
        }
        if (control.Name == ((F_MarbleHorVerCutV2) this).btn_goleftbwd.Name)
        {
          // ISSUE: reference to a compiler-generated field
          ((F_MarbleHorVerCutV2) this).\u0001((object) (MarbleCadCamCommands) 11, (object) ((F_MarbleHorVerCutV2) this).spn_distance.Value, (object) (MarbleVacuumCommands) 1, (object) null, (object) null);
        }
        if (control.Name == ((F_Marble5DCamStrategyMenu) this).btn_goleftforward.Name)
        {
          // ISSUE: reference to a compiler-generated field
          ((F_MarbleHorVerCutV2) this).\u0001((object) (MarbleCadCamCommands) 10, (object) ((F_MarbleHorVerCutV2) this).spn_distance.Value, (object) (MarbleVacuumCommands) 1, (object) null, (object) null);
        }
        if (control.Name == ((F_Marble5DCamStrategyMenu) this).btn_gorightbwd.Name)
        {
          // ISSUE: reference to a compiler-generated field
          ((F_MarbleHorVerCutV2) this).\u0001((object) (MarbleCadCamCommands) 16 /*0x10*/, (object) ((F_MarbleHorVerCutV2) this).spn_distance.Value, (object) (MarbleVacuumCommands) 1, (object) null, (object) null);
        }
        if (!(control.Name == ((F_Marble5DCamStrategyMenu) this).btn_gorightforward.Name))
          return;
        // ISSUE: reference to a compiler-generated field
        ((F_MarbleHorVerCutV2) this).\u0001((object) (MarbleCadCamCommands) 15, (object) ((F_MarbleHorVerCutV2) this).spn_distance.Value, (object) (MarbleVacuumCommands) 1, (object) null, (object) null);
      }
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

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleHorVerCutV2) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleHorVerCutV2) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleCuttingSequence() => F_MarbleHorVerCutV2.Captions = new List<string>();

  public F_MarbleCuttingSequence()
  {
    ((F_Marble5DCamStrategyMenu) this).Properties = new FormProperties();
    ((F_Marble5DCamStrategyMenu) this).isHorizontal = false;
    ((F_Marble5DCamStrategyMenu) this).isDialog = false;
    ((F_Marble5DCamStrategyMenu) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleHorVerCutV4) this);
  }

  public void Init()
  {
    ((F_Marble5DCamStrategyMenu) this).Properties.Inited = false;
    if (((F_Marble5DCamStrategyMenu) this).Properties.Height > 10)
      this.Height = ((F_Marble5DCamStrategyMenu) this).Properties.Height;
    if (((F_Marble5DCamStrategyMenu) this).Properties.Width > 10)
      this.Width = ((F_Marble5DCamStrategyMenu) this).Properties.Width;
    this.TopMost = ((F_Marble5DCamStrategyMenu) this).Properties.TopMost;
    this.StartPosition = ((F_Marble5DCamStrategyMenu) this).Properties.FormPosition;
    if (((F_MarbleMilling5AxisMenu) this).DGV_items.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn1.Width = 50;
      dataGridViewColumn1.HeaderText = buLangTranslate.preDef.Number;
      dataGridViewColumn1.Name = "No";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleMilling5AxisMenu) this).DGV_items.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = 120;
      dataGridViewColumn2.HeaderText = buLangTranslate.preDef.Width;
      dataGridViewColumn2.Name = "X";
      dataGridViewColumn2.ReadOnly = false;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleMilling5AxisMenu) this).DGV_items.Columns.Add(dataGridViewColumn2);
      DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
      dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn3.Width = 70;
      dataGridViewColumn3.HeaderText = buLangTranslate.preDef.Count;
      dataGridViewColumn3.Name = "Y";
      dataGridViewColumn3.ReadOnly = false;
      dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleMilling5AxisMenu) this).DGV_items.Columns.Add(dataGridViewColumn3);
      DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
      dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn4.Width = 110;
      dataGridViewColumn4.HeaderText = buLangTranslate.preDef.StartAngle;
      dataGridViewColumn4.Name = "Z";
      dataGridViewColumn4.ReadOnly = true;
      dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleMilling5AxisMenu) this).DGV_items.Columns.Add(dataGridViewColumn4);
      DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
      dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn5.Width = 110;
      dataGridViewColumn5.HeaderText = buLangTranslate.preDef.EndAngle;
      dataGridViewColumn5.Name = "C";
      dataGridViewColumn5.ReadOnly = false;
      dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn5.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_MarbleMilling5AxisMenu) this).DGV_items.Columns.Add(dataGridViewColumn5);
    }
    ((F_MarbleMilling5AxisMenu) this).DGV_items.RowHeadersVisible = false;
    ((F_MarbleMilling5AxisMenu) this).DGV_items.AllowUserToAddRows = false;
    ((F_MarbleMilling5AxisMenu) this).DGV_items.AllowUserToResizeColumns = false;
    ((F_Marble5DCamStrategyMenu) this).Properties.Result = DialogResult.None;
    ((F_Marble5DCamStrategyMenu) this).Properties.Inited = true;
    ((F_MarbleSawCutParameters) this).LoadLanguage();
  }
}
