// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwTriMFlatland
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

public class F_MwTriMFlatland : Form
{
  internal Panel \u0001;
  internal System.Windows.Forms.Label \u0003;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  internal IContainer \u0001 = (IContainer) null;
  internal System.Windows.Forms.Label \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal NumericUpDown \u0001;
  internal Panel \u0001;
  internal RadioButton \u0001;
  internal System.Windows.Forms.Label \u0003;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  internal System.Windows.Forms.Label \u0004;
  internal System.Windows.Forms.Label \u0005;
  internal Button \u0001;
  internal Panel \u0002;
  internal NumericUpDown \u0002;
  internal System.Windows.Forms.Label \u0006;
  internal NumericUpDown \u0003;
  internal Panel \u0003;
  internal System.Windows.Forms.Label \u0007;
  internal NumericUpDown \u0004;
  internal System.Windows.Forms.Label \u0008;
  internal System.Windows.Forms.Label \u000E;
  internal NumericUpDown \u0005;
  internal NumericUpDown \u0006;
  internal System.Windows.Forms.Label \u000F;
  internal Button \u0002;
  internal System.Windows.Forms.Label \u0010;
  internal NumericUpDown \u0007;
  internal Panel \u0004;
  internal CheckBox \u0001;
  internal CheckBox \u0002;
  internal CheckBox \u0003;
  internal System.Windows.Forms.Label \u0011;
  internal NumericUpDown \u0008;
  internal System.Windows.Forms.Label \u0012;
  internal NumericUpDown \u000E;
  internal System.Windows.Forms.Label \u0013;
  internal NumericUpDown \u000F;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal PictureBox \u0001;
  internal System.Windows.Forms.Label \u0014;
  internal Button \u0003;
  internal Button \u0004;
  internal Button \u0005;
  internal Panel \u0005;
  internal CheckBox \u0004;
  internal Button \u0006;
  internal System.Windows.Forms.Label \u0015;
  internal System.Windows.Forms.Label \u0016;
  internal Button \u0007;
  internal Button \u0008;
  internal Panel \u0006;
  internal Button \u000E;
  internal TabPage \u0001;
  internal Panel \u0007;
  internal Panel \u0008;
  internal System.Windows.Forms.Label \u0017;
  internal RadioButton \u0004;
  internal RadioButton \u0005;
  internal Panel \u000E;
  internal System.Windows.Forms.Label \u0018;
  internal RadioButton \u0006;
  internal RadioButton \u0007;
  internal System.Windows.Forms.Label \u0019;
  internal TabControl \u0001;

  public void Apply()
  {
    ((F_MwTriMFixtureCurves) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FixtureCurveHeight = (double) ((F_MwTriMFixtureCurves) this).\u0001.Value;
    if (this.\u0001.Checked)
    {
      ((F_MwTriMFixtureCurves) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FixtureCurveMode = TriangleMeshBasedTpCalcParamsFixtureCurveMode.FcmCenter;
    }
    else
    {
      if (!this.\u0002.Checked)
        return;
      ((F_MwTriMFixtureCurves) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FixtureCurveMode = TriangleMeshBasedTpCalcParamsFixtureCurveMode.FcmOutside;
    }
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MwTriMFixtureCurves) this).UpdateControlFromType();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwTriMFixtureCurves) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwTriMFixtureCurves) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwTriMFlatland() => \u0005.\u0002.\u0001(this);

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
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RoughType == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtOffset)
      this.\u0003.Checked = true;
    else if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RoughType == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtParallel)
      this.\u0002.Checked = true;
    else
      this.\u0001.Checked = true;
    if (this.Par.MachDirForOneWay == MachiningParamsDirection.DirClimb)
      this.\u0005.Checked = true;
    else if (this.Par.MachDirForOneWay == MachiningParamsDirection.DirConventional)
    {
      this.\u0004.Checked = true;
    }
    else
    {
      this.\u0005.Checked = true;
      this.Par.MachDirForOneWay = MachiningParamsDirection.DirClimb;
    }
    if (this.Par.CurMachType == MachiningParamsMachType.MachtypeOneway)
      this.\u0006.Checked = true;
    else if (this.Par.CurMachType == MachiningParamsMachType.MachtypeZigzag)
    {
      this.\u0007.Checked = true;
    }
    else
    {
      this.\u0007.Checked = true;
      this.Par.CurMachType = MachiningParamsMachType.MachtypeZigzag;
    }
    this.\u0001.Value = (Decimal) this.Par.ParallelMachAngleInYX;
    ((F_MwTriMMirror) this).\u0010.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MaxWidth;
    ((F_MwTriMMirror) this).\u0011.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinWidth;
    this.\u0006.Value = (Decimal) this.Par.MaxStepoverDistance;
    this.\u0002.Value = (Decimal) this.Par.CutTolerance;
    this.\u0005.Value = (Decimal) this.Par.DesiredStepover;
    this.\u0004.Value = (Decimal) this.Par.ClimbStepoverAsMaxStepoverPercentage;
    this.\u0003.Value = (Decimal) this.Par.ConventionalStepoverAsMaxStepoverPercentage;
    this.\u0004.Checked = this.Par.Containment2dParams.IsUsedFlg;
    this.\u0007.Value = (Decimal) this.Par.MinFeedRateAsFeedRatePercentage;
    this.\u0001.Checked = this.Par.AdaptiveFeedRateFlg;
    this.\u0008.Value = (Decimal) this.Par.RetractFeedRate;
    this.\u000E.Value = (Decimal) this.Par.PlungeFeedRate;
    this.\u000F.Value = (Decimal) this.Par.FeedRate;
    this.\u0003.Checked = this.Par.RapidRetractFlg;
    this.\u0002.Checked = this.Par.RapidApproachFlg;
    this.UpdateControlFromType();
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
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
    this.\u0006.Enabled = this.\u0004.Checked;
    ((F_MwTriMMirror) this).\u0010.Enabled = ((F_MwTriMMirror) this).\u0005.Checked;
    this.\u0010.Enabled = this.\u0001.Checked;
    this.\u0007.Enabled = this.\u0001.Checked;
    if (this.\u0003.Checked)
    {
      this.\u0002.Visible = false;
      this.\u0001.Visible = false;
      this.\u0008.Visible = false;
      this.\u0005.Visible = false;
      this.\u0007.Visible = false;
      this.\u0004.Visible = false;
      this.\u0001.Visible = false;
      this.\u0003.Visible = false;
    }
    if (this.\u0002.Checked)
    {
      this.\u0002.Visible = true;
      this.\u0001.Visible = true;
      this.\u0008.Visible = false;
      this.\u0005.Visible = false;
      this.\u0007.Visible = false;
      this.\u0004.Visible = false;
      this.\u0001.Visible = false;
      this.\u0003.Visible = false;
    }
    if (!this.\u0001.Checked)
      return;
    this.\u0002.Visible = false;
    this.\u0001.Visible = false;
    this.\u0008.Visible = true;
    this.\u0005.Visible = true;
    this.\u0007.Visible = true;
    this.\u0004.Visible = true;
    this.\u0001.Visible = true;
    this.\u0003.Visible = true;
  }

  public void Apply()
  {
    this.Par.ParallelMachAngleInYX = (double) this.\u0001.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinWidth = (double) ((F_MwTriMMirror) this).\u0011.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MaxWidth = (double) (int) ((F_MwTriMMirror) this).\u0010.Value;
    this.Par.MaxStepoverDistance = (double) this.\u0006.Value;
    this.Par.CutTolerance = (double) this.\u0002.Value;
    this.Par.DesiredStepover = (double) this.\u0005.Value;
    this.Par.ClimbStepoverAsMaxStepoverPercentage = (double) this.\u0004.Value;
    this.Par.ConventionalStepoverAsMaxStepoverPercentage = (double) this.\u0003.Value;
    this.Par.Containment2dParams.IsUsedFlg = this.\u0004.Checked;
    this.Par.MinFeedRateAsFeedRatePercentage = (double) this.\u0007.Value;
    this.Par.AdaptiveFeedRateFlg = this.\u0001.Checked;
    this.Par.RetractFeedRate = (double) this.\u0008.Value;
    this.Par.PlungeFeedRate = (double) this.\u000E.Value;
    this.Par.FeedRate = (double) this.\u000F.Value;
    this.Par.RapidRetractFlg = this.\u0003.Checked;
    this.Par.RapidApproachFlg = this.\u0002.Checked;
    if (this.\u0003.Checked)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RoughType = TriangleMeshBasedTpCalcParamsRoughType.TmbRghtOffset;
    else if (this.\u0002.Checked)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RoughType = TriangleMeshBasedTpCalcParamsRoughType.TmbRghtParallel;
    else if (this.\u0001.Checked)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RoughType = TriangleMeshBasedTpCalcParamsRoughType.TmbRghtAdaptive;
    if (this.\u0005.Checked)
      this.Par.MachDirForOneWay = MachiningParamsDirection.DirClimb;
    else if (this.\u0004.Checked)
      this.Par.MachDirForOneWay = MachiningParamsDirection.DirConventional;
    if (this.\u0006.Checked)
    {
      this.Par.CurMachType = MachiningParamsMachType.MachtypeOneway;
    }
    else
    {
      if (!this.\u0007.Checked)
        return;
      this.Par.CurMachType = MachiningParamsMachType.MachtypeZigzag;
    }
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RoughType = !this.\u0003.Checked ? (!this.\u0002.Checked ? TriangleMeshBasedTpCalcParamsRoughType.TmbRghtAdaptive : TriangleMeshBasedTpCalcParamsRoughType.TmbRghtParallel) : TriangleMeshBasedTpCalcParamsRoughType.TmbRghtOffset;
    this.UpdateControlFromType();
  }
}
