// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_Fixtures
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buEyeBaseVer5;
using buMW.Forms;
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

public class F_Fixtures : Form
{
  internal System.Windows.Forms.Label \u0002;
  internal System.Windows.Forms.Label \u0003;
  internal System.Windows.Forms.Label \u0004;
  internal NumericUpDown \u0001;
  internal NumericUpDown \u0002;
  internal NumericUpDown \u0003;
  public FormProperties PropertiesForm = new FormProperties();
  public GeoLib mwCamParameter = (GeoLib) null;
  public camParameters5 buCamParameter = (camParameters5) null;
  public MWCalculationOptions Configration = new MWCalculationOptions();
  public ToolBase5 Tool = (ToolBase5) null;
  public static List<string> Captions;
  internal IContainer \u0001 = (IContainer) null;
  internal System.Windows.Forms.Label \u0001;
  internal Panel \u0001;
  internal RadioButton \u0001;
  internal Panel \u0002;
  internal RadioButton \u0002;
  internal ImageList \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal PictureBox \u0001;
  public Button btn_ok;
  internal ImageList \u0002;

  public void ControlUpdate()
  {
  }

  public void Apply()
  {
    ((F_FeedZone) this).mwCamParameter.MachParam.FeedControlZoneParams.Offset = (double) this.\u0003.Value;
    ((F_FeedZone) this).mwCamParameter.MachParam.FeedControlZoneParams.OutsideFeedRatePercentage = (double) this.\u0001.Value;
    ((F_FeedZone) this).mwCamParameter.MachParam.FeedControlZoneParams.InsideFeedRatePercentage = (double) this.\u0002.Value;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_FeedZone) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_FeedZone) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_Fixtures() => F_FeedZone.Captions = new List<string>();

  public F_Fixtures() => F_MwTriMUpDownAdvanced.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    if (this.Configration.Mode == CamMode.TriangularMesh)
    {
      if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FixtureCurveMode == TriangleMeshBasedTpCalcParamsFixtureCurveMode.FcmOutside)
        this.\u0002.Checked = true;
      else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FixtureCurveMode == TriangleMeshBasedTpCalcParamsFixtureCurveMode.FcmCenter)
        this.\u0002.Checked = true;
      ((F_Filtering) this).\u0001.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FixtureCurveOffset;
      ((F_Filtering) this).\u0002.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FixtureCurveHeight;
    }
    else if (this.Configration.Mode == CamMode.WireFrame)
    {
      if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.FixtureCurveMode == WireframeBasedTpCalcParamsFixtureCurveMode.FcmOutside)
        this.\u0002.Checked = true;
      else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.FixtureCurveMode == WireframeBasedTpCalcParamsFixtureCurveMode.FcmCenter)
        this.\u0002.Checked = true;
      ((F_Filtering) this).\u0001.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.FixtureCurveOffset;
      ((F_Filtering) this).\u0002.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.FixtureCurveHeight;
    }
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
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == this.btn_ok.Name)
    {
      this.Apply();
      this.PropertiesForm.Result = DialogResult.OK;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_Filtering) this).btn_cancel.Name))
      return;
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
    if (this.Configration.Mode == CamMode.TriangularMesh)
    {
      if (this.\u0002.Checked)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FixtureCurveMode = TriangleMeshBasedTpCalcParamsFixtureCurveMode.FcmOutside;
      else if (this.\u0001.Checked)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FixtureCurveMode = TriangleMeshBasedTpCalcParamsFixtureCurveMode.FcmCenter;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FixtureCurveOffset = (double) ((F_Filtering) this).\u0001.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FixtureCurveHeight = (double) ((F_Filtering) this).\u0002.Value;
    }
    else
    {
      if (this.Configration.Mode != CamMode.WireFrame)
        return;
      if (this.\u0002.Checked)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.FixtureCurveMode = WireframeBasedTpCalcParamsFixtureCurveMode.FcmOutside;
      else if (this.\u0001.Checked)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.FixtureCurveMode = WireframeBasedTpCalcParamsFixtureCurveMode.FcmCenter;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.FixtureCurveOffset = (double) ((F_Filtering) this).\u0001.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.FixtureCurveHeight = (double) ((F_Filtering) this).\u0002.Value;
    }
  }
}
