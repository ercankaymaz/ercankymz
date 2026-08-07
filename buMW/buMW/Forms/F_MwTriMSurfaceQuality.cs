// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwTriMSurfaceQuality
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW.Forms;

public class F_MwTriMSurfaceQuality : Form
{
  internal Panel \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal CheckBox \u0001;
  internal CheckBox \u0002;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  internal IContainer \u0001 = (IContainer) null;
  internal System.Windows.Forms.Label \u0001;
  internal PictureBox \u0001;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal CheckBox \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal Panel \u0001;
  internal System.Windows.Forms.Label \u0003;
  internal NumericUpDown \u0001;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal CheckBox \u0002;
  internal CheckBox \u0003;
  internal NumericUpDown \u0002;
  internal NumericUpDown \u0003;

  public void UpdateControlFromType()
  {
  }

  public void Apply()
  {
    ((F_MwTriMSpiralAdvanced) this).Par.CloseLastSpiralMachContour = this.\u0001.Checked;
    ((F_MwTriMSpiralAdvanced) this).Par.CloseFirstSpiralMachContour = this.\u0002.Checked;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwTriMSpiralAdvanced) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwTriMSpiralAdvanced) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwTriMSurfaceQuality() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ArcFitPlaneType == TriangleMeshBasedTpCalcParamsArcFitPlaneType.AfPlaneAny)
      this.\u0002.Checked = true;
    else if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ArcFitPlaneType == TriangleMeshBasedTpCalcParamsArcFitPlaneType.AfPlaneCoordinate)
      this.\u0001.Checked = true;
    this.\u0001.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ArcFitFactor;
    ((F_MwTriMUpDownAdvanced) this).\u0004.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.DeviationFactor;
    this.\u0002.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.MinimumDistance;
    this.\u0003.Value = (Decimal) this.Par.Distance;
    this.\u0001.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ArcFitFactorFlg;
    this.\u0003.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.UseMinimumDistanceFlg;
    this.\u0002.Checked = this.Par.DistanceFlag;
    this.UpdateControlFromType();
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (this.Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    this.Apply();
    this.Properties.Result = DialogResult.OK;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void UpdateControlFromType()
  {
    this.\u0001.Enabled = this.\u0001.Checked;
    this.\u0003.Enabled = this.\u0002.Checked;
    this.\u0002.Enabled = this.\u0003.Checked;
    ((F_MwTriMUpDownAdvanced) this).\u0004.Enabled = this.\u0003.Checked;
  }

  public void Apply()
  {
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ArcFitFactor = (double) this.\u0001.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.DeviationFactor = (double) ((F_MwTriMUpDownAdvanced) this).\u0004.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.MinimumDistance = (double) this.\u0002.Value;
    this.Par.Distance = (double) this.\u0003.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ArcFitFactorFlg = this.\u0001.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.UseMinimumDistanceFlg = this.\u0003.Checked;
    this.Par.DistanceFlag = this.\u0002.Checked;
    if (this.\u0002.Checked)
    {
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ArcFitPlaneType = TriangleMeshBasedTpCalcParamsArcFitPlaneType.AfPlaneAny;
    }
    else
    {
      if (!this.\u0001.Checked)
        return;
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ArcFitPlaneType = TriangleMeshBasedTpCalcParamsArcFitPlaneType.AfPlaneCoordinate;
    }
  }
}
