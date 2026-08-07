// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwTriMParallelCut
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

public class F_MwTriMParallelCut : Form
{
  internal System.Windows.Forms.Label \u0006;
  internal NumericUpDown \u0005;
  internal System.Windows.Forms.Label \u0007;
  internal NumericUpDown \u0006;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  private IContainer \u0001 = (IContainer) null;
  internal Button \u0001;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0001;
  internal Panel \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal Button \u0002;
  internal NumericUpDown \u0002;
  internal System.Windows.Forms.Label \u0003;
  internal CheckBox \u0001;
  internal System.Windows.Forms.Label \u0004;
  internal NumericUpDown \u0003;
  internal Panel \u0002;
  internal System.Windows.Forms.Label \u0005;
  internal NumericUpDown \u0004;
  internal TabControl \u0001;
  internal TabPage \u0001;
  internal Panel \u0003;
  internal CheckBox \u0002;
  internal Button \u0003;
  internal CheckBox \u0003;
  internal Button \u0004;
  internal CheckBox \u0004;
  internal Button \u0005;
  internal CheckBox \u0005;
  internal Button \u0006;
  internal CheckBox \u0006;
  internal Button \u0007;
  internal CheckBox \u0007;
  internal Button \u0008;
  internal CheckBox \u0008;
  internal System.Windows.Forms.Label \u0006;
  internal Panel \u0004;
  internal Panel \u0005;
  internal System.Windows.Forms.Label \u0007;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal Panel \u0006;
  internal RadioButton \u0003;
  internal System.Windows.Forms.Label \u0008;
  internal RadioButton \u0004;
  internal RadioButton \u0005;
  internal System.Windows.Forms.Label \u000E;
  internal Panel \u0007;
  internal System.Windows.Forms.Label \u000F;
  internal NumericUpDown \u0005;
  internal System.Windows.Forms.Label \u0010;
  internal NumericUpDown \u0006;
  internal System.Windows.Forms.Label \u0011;
  internal System.Windows.Forms.Label \u0012;
  public Button btn_ok;
  internal ImageList \u0001;
  internal Panel \u0008;
  internal NumericUpDown \u0007;
  internal System.Windows.Forms.Label \u0013;
  internal NumericUpDown \u0008;
  internal System.Windows.Forms.Label \u0014;
  internal NumericUpDown \u000E;
  internal System.Windows.Forms.Label \u0015;
  internal NumericUpDown \u000F;
  internal System.Windows.Forms.Label \u0016;
  public Button btn_cancel;
  internal Button \u000E;
  internal Button \u000F;
  internal Button \u0010;
  internal System.Windows.Forms.Label \u0017;
  internal PictureBox \u0001;
  internal CheckBox \u000E;
  internal CheckBox \u000F;
  internal CheckBox \u0010;
  internal RadioButton \u0006;
  internal RadioButton \u0007;
  internal RadioButton \u0008;
  internal System.Windows.Forms.Label \u0018;
  internal System.Windows.Forms.Label \u0019;
  internal NumericUpDown \u0010;
  internal System.Windows.Forms.Label \u001A;
  internal NumericUpDown \u0011;
  internal Button \u0011;
  internal Panel \u000E;

  public void Apply()
  {
    ((F_MwTriMRestRough) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RoughingOffset = (double) ((F_MwTriMRestRough) this).\u0004.Value;
    ((F_MwTriMRestRough) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RoughingAxialOffset = (double) this.\u0005.Value;
    ((F_MwTriMRestRough) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DetectThickerThan = (double) this.\u0006.Value;
    ((F_MwTriMRestRough) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RoughingRadialOffset = (double) ((F_MwTriMRestRough) this).\u0003.Value;
    ((F_MwTriMRestRough) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RoughingToolCornerRad = (double) ((F_MwTriMRestRough) this).\u0002.Value;
    ((F_MwTriMRestRough) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RoughingToolDiameter = (double) ((F_MwTriMRestRough) this).\u0001.Value;
    if (((F_MwTriMRestRough) this).\u0002.Checked)
    {
      ((F_MwTriMRestRough) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RoughingOffsetType = MachiningAreaRoughingParamsRoughingOffsetType.RotGlobal;
    }
    else
    {
      if (!((F_MwTriMRestRough) this).\u0001.Checked)
        return;
      ((F_MwTriMRestRough) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RoughingOffsetType = MachiningAreaRoughingParamsRoughingOffsetType.RotRadialAndAxial;
    }
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MwTriMRestRough) this).UpdateControlFromType();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwTriMRestRough) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwTriMRestRough) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwTriMParallelCut() => \u0005.\u0002.\u0001(this);

  public event MWDataOrjOkHandler OkClick;

  public event CancelCommandEventHandler CancelClick;

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    if (!buMWCalcs.AdvancedTriMesh)
    {
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.RestFinishingFlg = false;
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaUndercutsParams.UndercutsFlg = false;
    }
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ParallelCutsStartCorner == TriangleMeshBasedTpCalcParamsParallelCutsStartCorner.TmbScLowerLeft)
      this.\u0002.Checked = true;
    else if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ParallelCutsStartCorner == TriangleMeshBasedTpCalcParamsParallelCutsStartCorner.TmbScLowerRight)
      this.\u0001.Checked = true;
    else if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ParallelCutsStartCorner == TriangleMeshBasedTpCalcParamsParallelCutsStartCorner.TmbScUpperLeft)
      this.\u0007.Checked = true;
    else
      this.\u0006.Checked = true;
    if (this.Par.CurMachType == MachiningParamsMachType.MachtypeOneway)
      this.\u0004.Checked = true;
    else if (this.Par.CurMachType == MachiningParamsMachType.MachtypeZigzag)
      this.\u0005.Checked = true;
    else if (this.Par.CurMachType == MachiningParamsMachType.MachtypeUp)
    {
      this.\u0003.Checked = true;
    }
    else
    {
      this.\u0008.Checked = true;
      this.Par.CurMachType = MachiningParamsMachType.MachtypeDown;
    }
    this.\u0001.Value = (Decimal) this.Par.ParallelMachAngleInYX;
    this.\u0003.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStep;
    this.\u0006.Value = (Decimal) this.Par.MaxStepoverDistance;
    this.\u0002.Value = (Decimal) this.Par.CutTolerance;
    this.\u0005.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.DetectionThresholdDistance;
    this.\u0004.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.PassExtension;
    this.\u0011.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinStepover;
    this.\u0008.Value = (Decimal) this.Par.RetractFeedRate;
    this.\u000E.Value = (Decimal) this.Par.PlungeFeedRate;
    this.\u000F.Value = (Decimal) this.Par.FeedRate;
    this.\u0007.Value = (Decimal) this.Par.UpFeedRatePercentage;
    this.\u0010.Value = (Decimal) this.Par.DownFeedRatePercentage;
    this.\u0006.Checked = this.Par.Containment2dParams.IsUsedFlg;
    this.\u0007.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentFlg;
    this.\u0003.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaUndercutsParams.UndercutsFlg;
    this.\u0005.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.RestFinishingFlg;
    this.\u0008.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.TrimToFluteLengthFlg;
    this.\u000F.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.PerpendicularFlg;
    this.\u000E.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.AdaptiveFlg;
    this.\u0002.Checked = this.Par.ShallowAndSteepAreaParams.IsUsedFlg;
    this.\u0001.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MultiPassesOnFullWidthCutFlg;
    this.\u0004.Checked = this.Par.RadiusFitFlg;
    this.\u0010.Checked = this.Par.RapidRetractFlg;
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
    // ISSUE: reference to a compiler-generated field
    if (this.\u0001 == null)
      return;
    this.Apply();
    this.Properties.Result = DialogResult.OK;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
      this.Visible = false;
    // ISSUE: reference to a compiler-generated field
    int num = this.\u0001(this.Par) ? 1 : 0;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.\u0001 == null)
      return;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void UpdateControlFromType()
  {
    this.\u0003.Visible = false;
    this.\u0004.Visible = false;
    this.\u0018.Enabled = this.\u0001.Checked;
    this.\u0003.Enabled = this.\u0001.Checked;
    this.\u0004.Enabled = !this.\u0003.Checked;
    this.\u0005.Enabled = this.\u0004.Enabled & this.\u0004.Checked;
    this.\u0004.Enabled = this.\u0003.Checked;
    this.\u0008.Enabled = this.\u0007.Checked;
    this.\u0006.Enabled = this.\u0005.Checked;
    this.\u0007.Enabled = this.\u0006.Checked;
    this.\u0003.Enabled = this.\u0002.Checked;
    if (this.\u0008.Checked | this.\u0003.Checked)
      this.\u0011.Enabled = true;
    else
      this.\u0011.Enabled = false;
    this.\u000F.Enabled = !this.\u000E.Checked;
    this.\u001A.Enabled = this.\u000E.Checked & this.\u000E.Enabled;
    this.\u0011.Enabled = this.\u000E.Checked & this.\u000E.Enabled;
    this.\u000E.Enabled = !this.\u000F.Checked;
    this.\u000F.Enabled = this.\u000F.Checked & this.\u000F.Enabled;
    this.\u0005.Enabled = this.\u000F.Checked & this.\u000F.Enabled;
    this.\u0005.Enabled = this.\u000F.Checked & this.\u000F.Enabled;
    this.\u0004.Enabled = this.\u000F.Checked & this.\u000F.Enabled;
    if (buMWCalcs.AdvancedTriMesh)
      return;
    this.\u0005.Enabled = false;
    this.\u0006.Enabled = false;
    this.\u0003.Enabled = false;
    this.\u0004.Enabled = false;
    ((F_MwTriMRough) this).\u0014.Enabled = false;
  }

  public void Apply()
  {
    this.Par.ParallelMachAngleInYX = (double) this.\u0001.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStep = (double) this.\u0003.Value;
    this.Par.MaxStepoverDistance = (double) this.\u0006.Value;
    this.Par.CutTolerance = (double) this.\u0002.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.DetectionThresholdDistance = (double) this.\u0005.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.PassExtension = (double) this.\u0004.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinStepover = (double) this.\u0011.Value;
    this.Par.RetractFeedRate = (double) this.\u0008.Value;
    this.Par.PlungeFeedRate = (double) this.\u000E.Value;
    this.Par.FeedRate = (double) this.\u000F.Value;
    this.Par.UpFeedRatePercentage = (double) this.\u0007.Value;
    this.Par.DownFeedRatePercentage = (double) this.\u0010.Value;
    this.Par.Containment2dParams.IsUsedFlg = this.\u0006.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentFlg = this.\u0007.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaUndercutsParams.UndercutsFlg = this.\u0003.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.RestFinishingFlg = this.\u0005.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.TrimToFluteLengthFlg = this.\u0008.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.PerpendicularFlg = this.\u000F.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.AdaptiveFlg = this.\u000E.Checked;
    this.Par.ShallowAndSteepAreaParams.IsUsedFlg = this.\u0002.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MultiPassesOnFullWidthCutFlg = this.\u0001.Checked;
    this.Par.RadiusFitFlg = this.\u0004.Checked;
    this.Par.RapidRetractFlg = this.\u0010.Checked;
    if (this.\u0002.Checked)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ParallelCutsStartCorner = TriangleMeshBasedTpCalcParamsParallelCutsStartCorner.TmbScLowerLeft;
    else if (this.\u0001.Checked)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ParallelCutsStartCorner = TriangleMeshBasedTpCalcParamsParallelCutsStartCorner.TmbScLowerRight;
    else if (this.\u0007.Checked)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ParallelCutsStartCorner = TriangleMeshBasedTpCalcParamsParallelCutsStartCorner.TmbScUpperLeft;
    else if (this.\u0006.Checked)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ParallelCutsStartCorner = TriangleMeshBasedTpCalcParamsParallelCutsStartCorner.TmbScUpperRight;
    if (this.\u0004.Checked)
      this.Par.CurMachType = MachiningParamsMachType.MachtypeOneway;
    else if (this.\u0005.Checked)
      this.Par.CurMachType = MachiningParamsMachType.MachtypeZigzag;
    else if (this.\u0003.Checked)
    {
      this.Par.CurMachType = MachiningParamsMachType.MachtypeUp;
    }
    else
    {
      if (!this.\u0008.Checked)
        return;
      this.Par.CurMachType = MachiningParamsMachType.MachtypeDown;
    }
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1) => this.UpdateControlFromType();
}
