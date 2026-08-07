// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_MultiPass
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buControls;
using buEyeBaseVer5;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW.CamForms;

public class F_MultiPass : Form
{
  internal ImageList \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0003;
  internal NumericUpDown \u0002;
  public Button btn_ok;
  internal CheckBox \u0001;
  public FormProperties PropertiesForm = new FormProperties();
  public GeoLib mwCamParameter = (GeoLib) null;
  public camParameters5 buCamParameter = (camParameters5) null;
  public MWCalculationOptions Configration = new MWCalculationOptions();
  public ToolBase5 Tool = (ToolBase5) null;
  public static List<string> Captions;
  internal IContainer \u0001 = (IContainer) null;
  internal ImageList \u0001;
  internal System.Windows.Forms.Label \u0001;
  internal PictureBox \u0001;
  public Button btn_ok;
  internal ImageList \u0002;
  public Button btn_cancel;
  internal CheckBox \u0001;

  public void Apply()
  {
    if (((F_CuttingMethodAdvanced) this).Configration.Mode != CamMode.TriangularMesh)
      return;
    ((F_CuttingMethodAdvanced) this).mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.OverlapDistance = (double) this.\u0002.Value;
    ((F_CuttingMethodAdvanced) this).mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinHeightChange = (double) this.\u0001.Value;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_CuttingMethodAdvanced) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_CuttingMethodAdvanced) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MultiPass() => F_CuttingMethodAdvanced.Captions = new List<string>();

  public F_MultiPass() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    ((F_HeightAdvanced) this).\u0002.Checked = this.mwCamParameter.MachParam.RoughingParams.MultiCutsRoughParams.IsUsedFlg;
    ((F_HeightAdvanced) this).\u0002.Value = (Decimal) this.mwCamParameter.MachParam.RoughingParams.MultiCutsRoughParams.NumberOfRoughCuts;
    ((F_HeightAdvanced) this).\u0001.Value = (Decimal) this.mwCamParameter.MachParam.RoughingParams.MultiCutsRoughParams.RoughPassSpacing;
    ((F_HeightAdvanced) this).cmb_multipasssort.Items.Clear();
    ((F_HeightAdvanced) this).cmb_multipasssort.Items.Add((object) buMWCaptions.MultiCutsRoughParamsSortType[0]);
    ((F_HeightAdvanced) this).cmb_multipasssort.Items.Add((object) buMWCaptions.MultiCutsRoughParamsSortType[1]);
    if (this.mwCamParameter.MachParam.RoughingParams.MultiCutsRoughParams.SortType == MultiCutsRoughParamsSortType.McSortBySlices)
      ((F_HeightAdvanced) this).cmb_multipasssort.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.RoughingParams.MultiCutsRoughParams.SortType == MultiCutsRoughParamsSortType.McSortByPasses)
      ((F_HeightAdvanced) this).cmb_multipasssort.SelectedIndex = 1;
    this.ControlUpdate();
    \u0005.\u0002.\u0001(this);
    this.\u0001.Image = (Image) null;
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
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

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    this.Apply();
    this.PropertiesForm.Result = DialogResult.OK;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void ControlUpdate()
  {
  }

  public void Apply()
  {
    this.mwCamParameter.MachParam.RoughingParams.MultiCutsRoughParams.IsUsedFlg = ((F_HeightAdvanced) this).\u0002.Checked;
    this.mwCamParameter.MachParam.RoughingParams.MultiCutsRoughParams.NumberOfRoughCuts = (uint) ((F_HeightAdvanced) this).\u0002.Value;
    this.mwCamParameter.MachParam.RoughingParams.MultiCutsRoughParams.RoughPassSpacing = (double) ((F_HeightAdvanced) this).\u0001.Value;
    if (((F_HeightAdvanced) this).cmb_multipasssort.SelectedIndex == 0)
    {
      this.mwCamParameter.MachParam.RoughingParams.MultiCutsRoughParams.SortType = MultiCutsRoughParamsSortType.McSortBySlices;
    }
    else
    {
      if (((F_HeightAdvanced) this).cmb_multipasssort.SelectedIndex != 1)
        return;
      this.mwCamParameter.MachParam.RoughingParams.MultiCutsRoughParams.SortType = MultiCutsRoughParamsSortType.McSortByPasses;
    }
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!this.PropertiesForm.Inited)
      return;
    this.PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] KeyEventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!(obj1.KeyCode == Keys.Return | obj1.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKeyDown(this.Controls, result, obj1.Shift);
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    if (!(this.PropertiesForm.TouchPad & !this.\u0001.Checked))
      return;
    NumericUpDown numericUpDown = new NumericUpDown();
    NumericUpDown Ctrl = (NumericUpDown) obj0;
    if (!Ctrl.Enabled)
      return;
    buControlCommands.ShowKeyPadWinControl((Form) this, (Control) Ctrl);
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!this.PropertiesForm.Inited)
      return;
    this.PropertiesForm.Inited = false;
    this.Apply();
    this.ControlUpdate();
    this.PropertiesForm.Inited = true;
    ((F_HeightAdvanced) this).\u0007(obj0, (EventArgs) null);
  }
}
