// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ClassViewer.buClassViewerColor5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Forms.Cam;
using buEyeBaseVer5.Forms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.ClassViewer;

public class buClassViewerColor5 : UserControl
{
  public buCheckBox chk_flatlandparallel;
  public buCheckBox chk_flatlandadaptive;
  public buSpin spn_flattolerancefactorflatland;
  public buSpin spn_sepoverflatland;
  internal buGroup \u0018;
  public buCheckBox chk_maxwidhtenableflatland;
  public buSpin spn_maxwidthflatland;
  public buSpin spn_minwidthflatland;
  internal buGroup \u0019;
  public buCheckBox chk_singlestepnarrowflatland;
  public buCheckBox chk_singlestepawideflatland;
  public buCheckBox chk_singlestepnarrowandwideflatland;
  public buCheckBox chk_singlestepflatland;
  internal buGroup \u001A;
  public buCheckBox chk_reversecuttingorderflatland;
  public buSpin spn_chaningdistanceflatland;
  internal buGroup \u001B;
  public buCheckBox chk_cutorderstandartpencil;
  public buCheckBox chk_cutorderfromcenterawaypencil;
  public buCheckBox chk_cutorderfromoutsidetocenterpencil;
  internal buGroup \u001C;
  public buCheckBox chk_overthicknesspnecil;
  public buSpin spn_overthicknesspnecil;
  public buCheckBox chk_cornerdetectionthresholdpencil;
  public buSpin spn_cornerdetectionthresholdpencil;
  public buCheckBox chk_multipencil;
  public buSpin spn_multipencil;
  public buSpin spn_stepoverpencil;
  public buCheckBox chk_cutorderfrombottomtotoppencil;
  public buCheckBox chk_cutorderfromtoptobottompencil;
  internal TabPage \u000E;
  internal buGroup \u001D;
  public buCheckBox chk_leftcutnumberConstcusp;

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_CamTriMeshSettings) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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
      if (control.Name == ((F_CamTriMeshSettings) this).btn_ok.Name)
      {
        this.Apply();
        ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
      }
      else if (control.Name == ((F_CamTriMeshSettings) this).btn_close.Name | control.Name == ((F_CamTriMeshSettings) this).btn_cancel.Name)
      {
        ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
      }
      else if (control.Name == ((F_CamTriMeshSettings) this).btn_displaytoover.Name)
      {
        ((F_CamTriMeshSettings) this).\u0003.Display.BackColor = buFile5.ColorToneChange(((F_CamTriMeshSettings) this).\u0001.Display.BackColor, ((F_CamTriMeshSettings) this).spn_displaytoovertone.Value);
        ((F_CamTriMeshSettings) this).\u0003.Display.LineerGradient.FirstColor = buFile5.ColorToneChange(((F_CamTriMeshSettings) this).\u0001.Display.LineerGradient.FirstColor, ((F_CamTriMeshSettings) this).spn_displaytoovertone.Value);
        ((F_CamTriMeshSettings) this).\u0003.Display.LineerGradient.SecondColor = buFile5.ColorToneChange(((F_CamTriMeshSettings) this).\u0001.Display.LineerGradient.SecondColor, ((F_CamTriMeshSettings) this).spn_displaytoovertone.Value);
        ((F_CamTriMeshSettings) this).\u0003.Display.PathGradient.CenterColor = buFile5.ColorToneChange(((F_CamTriMeshSettings) this).\u0001.Display.PathGradient.CenterColor, ((F_CamTriMeshSettings) this).spn_displaytoovertone.Value);
        ((F_CamTriMeshSettings) this).\u0003.Display.PathGradient.SurroundColor = buFile5.ColorToneChange(((F_CamTriMeshSettings) this).\u0001.Display.PathGradient.SurroundColor, ((F_CamTriMeshSettings) this).spn_displaytoovertone.Value);
        ((F_CamTriMeshSettings) this).\u0003.Display.PathInterpolatedGradient.FirstColor = buFile5.ColorToneChange(((F_CamTriMeshSettings) this).\u0001.Display.PathInterpolatedGradient.FirstColor, ((F_CamTriMeshSettings) this).spn_displaytoovertone.Value);
        ((F_CamTriMeshSettings) this).\u0003.Display.PathInterpolatedGradient.SecondColor = buFile5.ColorToneChange(((F_CamTriMeshSettings) this).\u0001.Display.PathInterpolatedGradient.SecondColor, ((F_CamTriMeshSettings) this).spn_displaytoovertone.Value);
        ((F_CamTriMeshSettings) this).\u0003.Display.PathInterpolatedGradient.ThirdColor = buFile5.ColorToneChange(((F_CamTriMeshSettings) this).\u0001.Display.PathInterpolatedGradient.ThirdColor, ((F_CamTriMeshSettings) this).spn_displaytoovertone.Value);
        ((F_CamTriMeshSettings) this).\u0003.Display.PathInterpolatedGradient.FourthColor = buFile5.ColorToneChange(((F_CamTriMeshSettings) this).\u0001.Display.PathInterpolatedGradient.FourthColor, ((F_CamTriMeshSettings) this).spn_displaytoovertone.Value);
        ((F_CamTriMeshSettings) this).\u0003.UpdateControl();
        ((F_CamTriMeshSettings) this).btn_ref.Invalidate();
      }
      else
      {
        if (!(control.Name == ((F_CamTriMeshSettings) this).btn_displaytodown.Name))
          return;
        ((F_CamTriMeshSettings) this).\u0002.Display.BackColor = buFile5.ColorToneChange(((F_CamTriMeshSettings) this).\u0001.Display.BackColor, ((F_CamTriMeshSettings) this).spn_displaytodowntone.Value);
        ((F_CamTriMeshSettings) this).\u0002.Display.LineerGradient.FirstColor = buFile5.ColorToneChange(((F_CamTriMeshSettings) this).\u0001.Display.LineerGradient.FirstColor, ((F_CamTriMeshSettings) this).spn_displaytodowntone.Value);
        ((F_CamTriMeshSettings) this).\u0002.Display.LineerGradient.SecondColor = buFile5.ColorToneChange(((F_CamTriMeshSettings) this).\u0001.Display.LineerGradient.SecondColor, ((F_CamTriMeshSettings) this).spn_displaytodowntone.Value);
        ((F_CamTriMeshSettings) this).\u0002.Display.PathGradient.CenterColor = buFile5.ColorToneChange(((F_CamTriMeshSettings) this).\u0001.Display.PathGradient.CenterColor, ((F_CamTriMeshSettings) this).spn_displaytodowntone.Value);
        ((F_CamTriMeshSettings) this).\u0002.Display.PathGradient.SurroundColor = buFile5.ColorToneChange(((F_CamTriMeshSettings) this).\u0001.Display.PathGradient.SurroundColor, ((F_CamTriMeshSettings) this).spn_displaytodowntone.Value);
        ((F_CamTriMeshSettings) this).\u0002.Display.PathInterpolatedGradient.FirstColor = buFile5.ColorToneChange(((F_CamTriMeshSettings) this).\u0001.Display.PathInterpolatedGradient.FirstColor, ((F_CamTriMeshSettings) this).spn_displaytodowntone.Value);
        ((F_CamTriMeshSettings) this).\u0002.Display.PathInterpolatedGradient.SecondColor = buFile5.ColorToneChange(((F_CamTriMeshSettings) this).\u0001.Display.PathInterpolatedGradient.SecondColor, ((F_CamTriMeshSettings) this).spn_displaytodowntone.Value);
        ((F_CamTriMeshSettings) this).\u0002.Display.PathInterpolatedGradient.ThirdColor = buFile5.ColorToneChange(((F_CamTriMeshSettings) this).\u0001.Display.PathInterpolatedGradient.ThirdColor, ((F_CamTriMeshSettings) this).spn_displaytodowntone.Value);
        ((F_CamTriMeshSettings) this).\u0002.Display.PathInterpolatedGradient.FourthColor = buFile5.ColorToneChange(((F_CamTriMeshSettings) this).\u0001.Display.PathInterpolatedGradient.FourthColor, ((F_CamTriMeshSettings) this).spn_displaytodowntone.Value);
        ((F_CamTriMeshSettings) this).\u0002.UpdateControl();
        ((F_CamTriMeshSettings) this).btn_ref.Invalidate();
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
    Control control = obj0 as Control;
    if (control.Name == ((F_CamTriMeshSettings) this).\u0001.Name)
      ((F_CamTriMeshSettings) this).btn_ref.Display = ((F_CamTriMeshSettings) this).\u0001.Display;
    if (control.Name == ((F_CamTriMeshSettings) this).\u0002.Name)
      ((F_CamTriMeshSettings) this).btn_ref.ButtonDownDisplay = ((F_CamTriMeshSettings) this).\u0002.Display;
    if (control.Name == ((F_CamTriMeshSettings) this).\u0003.Name)
      ((F_CamTriMeshSettings) this).btn_ref.ButtonOverDisplay = ((F_CamTriMeshSettings) this).\u0003.Display;
    ((F_CamTriMeshSettings) this).btn_ref.Invalidate();
  }

  internal void \u0001([In] object obj0, [In] double obj1)
  {
    if (!((obj0 as Control).Name == ((F_CamTriMeshSettings) this).spn_geometryrad.Name))
      return;
    ((F_CamTriMeshSettings) this).btn_ref.Geometry.ArcDiameter = (int) ((F_CamTriMeshSettings) this).spn_geometryrad.Value;
    ((F_CamTriMeshSettings) this).refButton.Geometry.ArcDiameter = (int) ((F_CamTriMeshSettings) this).spn_geometryrad.Value;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_CamTriMeshSettings) this).\u0002.Name)
    {
      ShapeType result;
      Enum.TryParse<ShapeType>(((F_CamTriMeshSettings) this).\u0002.SelectedItem.ToString(), out result);
      ((F_CamTriMeshSettings) this).btn_ref.Geometry.ShapeMode = result;
      ((F_CamTriMeshSettings) this).refButton.Geometry.ShapeMode = result;
    }
    if (!(control.Name == ((F_CamTriMeshSettings) this).\u0001.Name))
      return;
    ContentAlignment result1;
    Enum.TryParse<ContentAlignment>(((F_CamTriMeshSettings) this).\u0001.SelectedItem.ToString(), out result1);
    ((F_CamTriMeshSettings) this).btn_ref.ImageAlign = result1;
    ((F_CamTriMeshSettings) this).refButton.ImageAlign = result1;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_CamTriMeshSettings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_CamTriMeshSettings) this).\u0001.Dispose();
    // ISSUE: explicit non-virtual call
    __nonvirtual (((Form) this).Dispose(disposing));
  }

  static buClassViewerColor5() => F_CamTriMeshSettings.Captions = new List<string>();

  public buClassViewerColor5()
  {
    ((F_CamTriMeshSettings) this).PropertiesForm = new FormProperties();
    ((F_CamTriMeshSettings) this).\u0001 = new Timer();
    ((F_CamTriMeshSettings) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    ((Form) this).\u002Ector();
    \u0007.\u0001.\u0001((F_ControlUISettings) this);
    ((F_CamTriMeshSettings) this).\u0001.Interval = 1000;
    ((F_CamTriMeshSettings) this).\u0001.Tick += new EventHandler(((buClassViewerColor5.ClassViewerEventHandler5) this).\u0001);
  }

  public void Init()
  {
    ((F_CamTriMeshSettings) this).PropertiesForm.Inited = false;
    if (((F_CamTriMeshSettings) this).PropertiesForm.Height > 10)
      this.Height = ((F_CamTriMeshSettings) this).PropertiesForm.Height;
    if (((F_CamTriMeshSettings) this).PropertiesForm.Width > 10)
      this.Width = ((F_CamTriMeshSettings) this).PropertiesForm.Width;
    ((Form) this).TopMost = ((F_CamTriMeshSettings) this).PropertiesForm.TopMost;
    ((Form) this).StartPosition = ((F_CamTriMeshSettings) this).PropertiesForm.FormPosition;
    if (((F_CamParallelCutSettings) this).\u0002.Columns.Count == 0)
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
      ((F_CamParallelCutSettings) this).\u0002.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = ((F_CamParallelCutSettings) this).\u0002.Width - 40;
      dataGridViewColumn2.HeaderText = buLangTranslate.preDef.Text;
      dataGridViewColumn2.Name = "Text";
      dataGridViewColumn2.ReadOnly = true;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_CamParallelCutSettings) this).\u0002.Columns.Add(dataGridViewColumn2);
      ((F_CamParallelCutSettings) this).\u0002.Rows.Add(\u0007.\u0001.\u0001("DataGridView1", (F_ControlUISettings) this, 1));
      ((F_CamParallelCutSettings) this).\u0002.Rows[((F_CamParallelCutSettings) this).\u0002.Rows.Count - 1].Height = 12;
      ((F_CamParallelCutSettings) this).\u0002.Rows.Add(\u0007.\u0001.\u0001("DataGridView1", (F_ControlUISettings) this, 2));
      ((F_CamParallelCutSettings) this).\u0002.Rows[((F_CamParallelCutSettings) this).\u0002.Rows.Count - 1].Height = 12;
    }
    if (((F_CamParallelCutSettings) this).\u0001.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
      dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn3.Width = 35;
      dataGridViewColumn3.HeaderText = buLangTranslate.preDef.Number;
      dataGridViewColumn3.Name = "No";
      dataGridViewColumn3.ReadOnly = true;
      dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_CamParallelCutSettings) this).\u0001.Columns.Add(dataGridViewColumn3);
      DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
      dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn4.Width = ((F_CamParallelCutSettings) this).\u0001.Width - 40;
      dataGridViewColumn4.HeaderText = buLangTranslate.preDef.Text;
      dataGridViewColumn4.Name = "Text";
      dataGridViewColumn4.ReadOnly = true;
      dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      dataGridViewColumn4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ((F_CamParallelCutSettings) this).\u0001.Columns.Add(dataGridViewColumn4);
      ((F_CamParallelCutSettings) this).\u0001.Rows.Add(\u0007.\u0001.\u0001("DataGridView2", (F_ControlUISettings) this, 1));
      ((F_CamParallelCutSettings) this).\u0001.Rows[((F_CamParallelCutSettings) this).\u0001.Rows.Count - 1].Height = 12;
      ((F_CamParallelCutSettings) this).\u0001.Rows.Add(\u0007.\u0001.\u0001("DataGridView2", (F_ControlUISettings) this, 2));
      ((F_CamParallelCutSettings) this).\u0001.Rows[((F_CamParallelCutSettings) this).\u0001.Rows.Count - 1].Height = 12;
    }
    ((F_CamParallelCutSettings) this).\u0002.RowHeadersVisible = false;
    ((F_CamParallelCutSettings) this).\u0002.AllowUserToAddRows = false;
    ((F_CamParallelCutSettings) this).\u0002.AllowUserToResizeColumns = false;
    ((F_CamParallelCutSettings) this).\u0002.ColumnHeadersVisible = true;
    ((F_CamParallelCutSettings) this).\u0002.ColumnHeadersHeight = 8;
    ((F_CamParallelCutSettings) this).\u0001.RowHeadersVisible = false;
    ((F_CamParallelCutSettings) this).\u0001.AllowUserToAddRows = false;
    ((F_CamParallelCutSettings) this).\u0001.AllowUserToResizeColumns = false;
    ((F_CamParallelCutSettings) this).\u0001.ColumnHeadersVisible = true;
    ((F_CamParallelCutSettings) this).\u0001.ColumnHeadersHeight = 8;
    ((buClassViewerColor5.ClassViewerEventHandler5) this).InitVisual();
    ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.None;
    ((F_CamTriMeshSettings) this).\u0001.Enabled = true;
    \u0007.\u0001.\u0001((F_ControlUISettings) this);
  }

  public event buClassViewerColor5.ClassViewerEventHandler5 ValueChanged;

  public event EventHandler OkButtonClicked;

  public event EventHandler CancelButtonClicked;

  public delegate void ClassViewerEventHandler5();
}
