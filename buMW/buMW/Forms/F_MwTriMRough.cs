// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwTriMRough
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

public class F_MwTriMRough : Form
{
  internal Button \u0012;
  internal Button \u0013;
  internal System.Windows.Forms.Label \u001B;
  internal Button \u0014;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  internal IContainer \u0001 = (IContainer) null;
  internal TabControl \u0001;
  internal TabPage \u0001;
  internal Panel \u0001;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal System.Windows.Forms.Label \u0001;
  internal Panel \u0002;
  internal System.Windows.Forms.Label \u0002;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0003;
  internal NumericUpDown \u0002;
  internal System.Windows.Forms.Label \u0004;
  internal System.Windows.Forms.Label \u0005;
  internal NumericUpDown \u0003;
  internal NumericUpDown \u0004;
  internal System.Windows.Forms.Label \u0006;
  internal Panel \u0003;
  internal System.Windows.Forms.Label \u0007;
  internal Button \u0001;
  internal NumericUpDown \u0005;
  internal System.Windows.Forms.Label \u0008;
  internal Panel \u0004;
  internal Button \u0002;
  internal NumericUpDown \u0006;
  internal NumericUpDown \u0007;
  internal RadioButton \u0003;
  internal RadioButton \u0004;
  internal System.Windows.Forms.Label \u000E;
  internal Panel \u0005;
  internal NumericUpDown \u0008;
  internal RadioButton \u0005;
  internal System.Windows.Forms.Label \u000F;
  internal RadioButton \u0006;
  internal RadioButton \u0007;
  internal Panel \u0006;
  internal System.Windows.Forms.Label \u0010;
  internal RadioButton \u0008;
  internal RadioButton \u000E;
  internal Panel \u0007;
  internal RadioButton \u000F;
  internal System.Windows.Forms.Label \u0011;
  internal Panel \u0008;
  internal CheckBox \u0001;
  internal Button \u0003;
  internal CheckBox \u0002;
  internal Button \u0004;
  internal CheckBox \u0003;
  internal Button \u0005;
  internal CheckBox \u0004;
  internal Button \u0006;
  internal CheckBox \u0005;
  internal Button \u0007;
  internal CheckBox \u0006;
  internal System.Windows.Forms.Label \u0012;
  internal NumericUpDown \u000E;
  internal System.Windows.Forms.Label \u0013;
  internal CheckBox \u0007;
  internal Panel \u000E;
  internal System.Windows.Forms.Label \u0014;
  internal RadioButton \u0010;
  internal RadioButton \u0011;
  internal PictureBox \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal System.Windows.Forms.Label \u0015;
  internal System.Windows.Forms.Label \u0016;
  internal Panel \u000F;
  internal CheckBox \u0008;
  internal System.Windows.Forms.Label \u0017;
  internal NumericUpDown \u000F;
  internal System.Windows.Forms.Label \u0018;
  internal NumericUpDown \u0010;
  internal System.Windows.Forms.Label \u0019;
  internal NumericUpDown \u0011;
  internal System.Windows.Forms.Label \u001A;
  internal System.Windows.Forms.Label \u001B;
  internal NumericUpDown \u0012;
  internal CheckBox \u000E;
  internal CheckBox \u000F;
  internal Button \u0008;
  internal Button \u000E;
  internal Button \u000F;
  internal Button \u0010;
  internal Panel \u0010;

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_MwTriMParallelCut) this).Properties.Inited)
      return;
    ((F_MwTriMParallelCut) this).Properties.Inited = false;
    ((F_MwTriMParallelCut) this).Apply();
    ((F_MwTriMParallelCut) this).UpdateControlFromType();
    ((F_MwTriMParallelCut) this).Properties.Inited = true;
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == this.\u0014.Name)
    {
      F_MWTriMDynamicalHolderColl mdynamicalHolderColl = new F_MWTriMDynamicalHolderColl();
      mdynamicalHolderColl.Par = new MachiningParams(((F_MwTriMParallelCut) this).Par);
      mdynamicalHolderColl.Init();
      int num = (int) mdynamicalHolderColl.ShowDialog();
      if (mdynamicalHolderColl.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMParallelCut) this).Par = new MachiningParams(mdynamicalHolderColl.Par);
        mdynamicalHolderColl.Dispose();
      }
    }
    if (control2.Name == this.\u0013.Name)
    {
      F_MwTriMHeights fMwTriMheights = new F_MwTriMHeights();
      fMwTriMheights.Par = new MachiningParams(((F_MwTriMParallelCut) this).Par);
      fMwTriMheights.Init();
      int num = (int) fMwTriMheights.ShowDialog();
      if (fMwTriMheights.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMParallelCut) this).Par = new MachiningParams(fMwTriMheights.Par);
        fMwTriMheights.Dispose();
      }
    }
    if (control2.Name == this.\u0012.Name)
    {
      F_MwTriMOffset fMwTriMoffset = new F_MwTriMOffset();
      fMwTriMoffset.Par = new MachiningParams(((F_MwTriMParallelCut) this).Par);
      fMwTriMoffset.Init();
      int num = (int) fMwTriMoffset.ShowDialog();
      if (fMwTriMoffset.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMParallelCut) this).Par = new MachiningParams(fMwTriMoffset.Par);
        fMwTriMoffset.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMParallelCut) this).\u0010.Name)
    {
      F_MwTriMRoughLink fMwTriMroughLink = new F_MwTriMRoughLink();
      fMwTriMroughLink.Par = new MachiningParams(((F_MwTriMParallelCut) this).Par);
      fMwTriMroughLink.Init();
      int num = (int) fMwTriMroughLink.ShowDialog();
      if (fMwTriMroughLink.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMParallelCut) this).Par = new MachiningParams(fMwTriMroughLink.Par);
        fMwTriMroughLink.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMParallelCut) this).\u0001.Name)
    {
      F_MwTriMRoughing fMwTriMroughing = new F_MwTriMRoughing();
      fMwTriMroughing.Par = new MachiningParams(((F_MwTriMParallelCut) this).Par);
      fMwTriMroughing.Init();
      int num = (int) fMwTriMroughing.ShowDialog();
      if (fMwTriMroughing.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMParallelCut) this).Par = new MachiningParams(fMwTriMroughing.Par);
        fMwTriMroughing.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMParallelCut) this).\u000F.Name)
    {
      F_MwGaugeCheck fMwGaugeCheck = new F_MwGaugeCheck();
      fMwGaugeCheck.Par = new MachiningParams(((F_MwTriMParallelCut) this).Par);
      fMwGaugeCheck.Init();
      int num = (int) fMwGaugeCheck.ShowDialog();
      if (fMwGaugeCheck.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMParallelCut) this).Par = new MachiningParams(fMwGaugeCheck.Par);
        fMwGaugeCheck.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMParallelCut) this).\u0003.Name)
    {
      F_MwTriMAngleRange mwTriMangleRange = new F_MwTriMAngleRange();
      mwTriMangleRange.Par = new MachiningParams(((F_MwTriMParallelCut) this).Par);
      mwTriMangleRange.Init();
      int num = (int) mwTriMangleRange.ShowDialog();
      if (mwTriMangleRange.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMParallelCut) this).Par = new MachiningParams(mwTriMangleRange.Par);
        mwTriMangleRange.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMParallelCut) this).\u0002.Name)
    {
      F_MwTriMSurfaceQuality triMsurfaceQuality = new F_MwTriMSurfaceQuality();
      triMsurfaceQuality.Par = new MachiningParams(((F_MwTriMParallelCut) this).Par);
      triMsurfaceQuality.Init();
      int num = (int) triMsurfaceQuality.ShowDialog();
      if (triMsurfaceQuality.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMParallelCut) this).Par = new MachiningParams(triMsurfaceQuality.Par);
        triMsurfaceQuality.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMParallelCut) this).\u0008.Name)
    {
      F_MwTriMSilhouette mwTriMsilhouette = new F_MwTriMSilhouette();
      mwTriMsilhouette.Par = new MachiningParams(((F_MwTriMParallelCut) this).Par);
      mwTriMsilhouette.Init();
      int num = (int) mwTriMsilhouette.ShowDialog();
      if (mwTriMsilhouette.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMParallelCut) this).Par = new MachiningParams(mwTriMsilhouette.Par);
        mwTriMsilhouette.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMParallelCut) this).\u0005.Name)
    {
      F_MwTriMRoundCorner mwTriMroundCorner = new F_MwTriMRoundCorner();
      mwTriMroundCorner.Par = new MachiningParams(((F_MwTriMParallelCut) this).Par);
      mwTriMroundCorner.Init();
      int num = (int) mwTriMroundCorner.ShowDialog();
      if (mwTriMroundCorner.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMParallelCut) this).Par = new MachiningParams(mwTriMroundCorner.Par);
        mwTriMroundCorner.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMParallelCut) this).\u0006.Name)
    {
      F_MwTriMRestFinish mwTriMrestFinish = new F_MwTriMRestFinish();
      mwTriMrestFinish.Par = new MachiningParams(((F_MwTriMParallelCut) this).Par);
      mwTriMrestFinish.Init();
      int num = (int) mwTriMrestFinish.ShowDialog();
      if (mwTriMrestFinish.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMParallelCut) this).Par = new MachiningParams(mwTriMrestFinish.Par);
        mwTriMrestFinish.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMParallelCut) this).\u0007.Name)
    {
      F_MwTriM2dContainment triM2dContainment = new F_MwTriM2dContainment();
      triM2dContainment.Par = new MachiningParams(((F_MwTriMParallelCut) this).Par);
      triM2dContainment.Init();
      int num = (int) triM2dContainment.ShowDialog();
      if (triM2dContainment.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMParallelCut) this).Par = new MachiningParams(triM2dContainment.Par);
        triM2dContainment.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMParallelCut) this).\u0011.Name)
    {
      F_MwTriMUpDownAdvanced triMupDownAdvanced = new F_MwTriMUpDownAdvanced();
      triMupDownAdvanced.Par = new MachiningParams(((F_MwTriMParallelCut) this).Par);
      triMupDownAdvanced.Init();
      int num = (int) triMupDownAdvanced.ShowDialog();
      if (triMupDownAdvanced.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMParallelCut) this).Par = new MachiningParams(triMupDownAdvanced.Par);
        triMupDownAdvanced.Dispose();
      }
    }
    if (!(control2.Name == ((F_MwTriMParallelCut) this).\u000E.Name))
      return;
    F_MwTriMUtility fMwTriMutility = new F_MwTriMUtility();
    fMwTriMutility.Par = new MachiningParams(((F_MwTriMParallelCut) this).Par);
    fMwTriMutility.Init();
    int num1 = (int) fMwTriMutility.ShowDialog();
    if (fMwTriMutility.Properties.Result != DialogResult.OK)
      return;
    ((F_MwTriMParallelCut) this).Par = new MachiningParams(fMwTriMutility.Par);
    fMwTriMutility.Dispose();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwTriMParallelCut) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwTriMParallelCut) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwTriMRough() => \u0005.\u0002.\u0001(this);

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
      if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RoughType == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtAdaptive)
        this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RoughType = TriangleMeshBasedTpCalcParamsRoughType.TmbRghtParallel;
      this.Par.StartPosFlag = false;
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.RestFinishingFlg = false;
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaUndercutsParams.UndercutsFlg = false;
    }
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RoughType == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtOffset)
      this.\u0007.Checked = true;
    else if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RoughType == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtParallel)
      this.\u0006.Checked = true;
    else
      this.\u0005.Checked = true;
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepMode == MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep)
      this.\u0004.Checked = true;
    else
      this.\u0003.Checked = true;
    if (this.Par.MachiningAreaMode == MachiningParamsMachiningAreaMode.MachByLanes)
      this.\u0011.Checked = true;
    else
      this.\u0010.Checked = true;
    if (this.Par.MachDirForOneWay == MachiningParamsDirection.DirClimb)
      this.\u000E.Checked = true;
    else if (this.Par.MachDirForOneWay == MachiningParamsDirection.DirConventional)
    {
      this.\u0008.Checked = true;
    }
    else
    {
      this.\u000E.Checked = true;
      this.Par.MachDirForOneWay = MachiningParamsDirection.DirClimb;
    }
    if (this.Par.CurMachType == MachiningParamsMachType.MachtypeOneway)
      this.\u0001.Checked = true;
    else if (this.Par.CurMachType == MachiningParamsMachType.MachtypeZigzag)
      this.\u0002.Checked = true;
    else if (this.Par.CurMachType == MachiningParamsMachType.MachtypeSpiral)
    {
      this.\u000F.Checked = true;
    }
    else
    {
      this.\u0002.Checked = true;
      this.Par.CurMachType = MachiningParamsMachType.MachtypeZigzag;
    }
    this.\u0008.Value = (Decimal) this.Par.ParallelMachAngleInYX;
    this.\u0007.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStep;
    this.\u0006.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.NumberOfSlices4DepthStep;
    this.\u000E.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.DraftAngle;
    this.\u0004.Value = (Decimal) this.Par.MaxStepoverDistance;
    this.\u0005.Value = (Decimal) this.Par.CutTolerance;
    this.\u0003.Value = (Decimal) this.Par.DesiredStepover;
    this.\u0002.Value = (Decimal) this.Par.ClimbStepoverAsMaxStepoverPercentage;
    this.\u0001.Value = (Decimal) this.Par.ConventionalStepoverAsMaxStepoverPercentage;
    this.\u0004.Checked = this.Par.Containment2dParams.IsUsedFlg;
    this.\u0005.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentFlg;
    this.\u0002.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FixtureCurvesFlg;
    this.\u0001.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaUndercutsParams.UndercutsFlg;
    this.\u0003.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RestRoughFlg;
    this.\u0006.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ClosedOffsetFlg;
    this.\u0007.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ReverseCuttingOrderFlg;
    this.\u0012.Value = (Decimal) this.Par.MinFeedRateAsFeedRatePercentage;
    this.\u000E.Checked = this.Par.AdaptiveFeedRateFlg;
    this.\u000F.Value = (Decimal) this.Par.RetractFeedRate;
    this.\u0010.Value = (Decimal) this.Par.PlungeFeedRate;
    this.\u0011.Value = (Decimal) this.Par.FeedRate;
    this.\u0008.Checked = this.Par.RapidRetractFlg;
    this.\u000F.Checked = this.Par.RapidApproachFlg;
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
    this.\u0006.Enabled = this.\u0004.Checked;
    this.\u0004.Enabled = this.\u0002.Checked;
    this.\u0005.Enabled = this.\u0003.Checked;
    this.\u0007.Enabled = this.\u0005.Checked;
    this.\u0003.Enabled = this.\u0001.Checked;
    this.\u001B.Enabled = this.\u000E.Checked;
    this.\u0012.Enabled = this.\u000E.Checked;
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RoughType == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtOffset)
    {
      this.\u0001.Visible = true;
      this.\u0003.Visible = true;
      this.\u0007.Visible = true;
      this.\u0016.Visible = false;
      this.\u0008.Visible = false;
      this.\u0006.Visible = true;
      this.\u0004.Visible = false;
      this.\u0003.Visible = false;
      this.\u0003.Visible = false;
      this.\u0002.Visible = false;
      this.\u0002.Visible = false;
      this.\u0001.Visible = false;
      this.\u000F.Visible = true;
    }
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RoughType == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtParallel)
    {
      this.\u0001.Visible = false;
      this.\u0003.Visible = false;
      this.\u0007.Visible = false;
      this.\u0016.Visible = true;
      this.\u0008.Visible = true;
      this.\u0006.Visible = false;
      this.\u0004.Visible = false;
      this.\u0003.Visible = false;
      this.\u0003.Visible = false;
      this.\u0002.Visible = false;
      this.\u0002.Visible = false;
      this.\u0001.Visible = false;
      this.\u000F.Visible = false;
    }
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RoughType == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtAdaptive)
    {
      this.\u0001.Visible = false;
      this.\u0003.Visible = false;
      this.\u0007.Visible = false;
      this.\u0016.Visible = false;
      this.\u0008.Visible = false;
      this.\u0006.Visible = false;
      this.\u0004.Visible = true;
      this.\u0003.Visible = true;
      this.\u0003.Visible = true;
      this.\u0002.Visible = true;
      this.\u0002.Visible = true;
      this.\u0001.Visible = true;
      this.\u000F.Visible = false;
    }
    if (buMWCalcs.AdvancedTriMesh)
      return;
    this.\u0005.Enabled = false;
    this.\u0001.Enabled = false;
    this.\u0003.Enabled = false;
    ((F_MwTriMRoundCorner) this).\u0013.Enabled = false;
  }

  public void Apply()
  {
    this.Par.ParallelMachAngleInYX = (double) this.\u0008.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStep = (double) this.\u0007.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.NumberOfSlices4DepthStep = (int) this.\u0006.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.DraftAngle = (double) this.\u000E.Value;
    this.Par.MaxStepoverDistance = (double) this.\u0004.Value;
    this.Par.CutTolerance = (double) this.\u0005.Value;
    this.Par.DesiredStepover = (double) this.\u0003.Value;
    this.Par.ClimbStepoverAsMaxStepoverPercentage = (double) this.\u0002.Value;
    this.Par.ConventionalStepoverAsMaxStepoverPercentage = (double) this.\u0001.Value;
    this.Par.Containment2dParams.IsUsedFlg = this.\u0004.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentFlg = this.\u0005.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FixtureCurvesFlg = this.\u0002.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaUndercutsParams.UndercutsFlg = this.\u0001.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RestRoughFlg = this.\u0003.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ClosedOffsetFlg = this.\u0006.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ReverseCuttingOrderFlg = this.\u0007.Checked;
    this.Par.MinFeedRateAsFeedRatePercentage = (double) this.\u0012.Value;
    this.Par.AdaptiveFeedRateFlg = this.\u000E.Checked;
    this.Par.RetractFeedRate = (double) this.\u000F.Value;
    this.Par.PlungeFeedRate = (double) this.\u0010.Value;
    this.Par.FeedRate = (double) this.\u0011.Value;
    this.Par.RapidRetractFlg = this.\u0008.Checked;
    this.Par.RapidApproachFlg = this.\u000F.Checked;
    if (this.\u0007.Checked)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RoughType = TriangleMeshBasedTpCalcParamsRoughType.TmbRghtOffset;
    else if (this.\u0006.Checked)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RoughType = TriangleMeshBasedTpCalcParamsRoughType.TmbRghtParallel;
    else if (this.\u0005.Checked)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RoughType = TriangleMeshBasedTpCalcParamsRoughType.TmbRghtAdaptive;
    if (this.\u0004.Checked)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepMode = MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep;
    else if (this.\u0003.Checked)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepMode = MachiningAreaRoughingParamsDepthStepMode.DsmNumberOfSlices;
    if (this.\u0011.Checked)
      this.Par.MachiningAreaMode = MachiningParamsMachiningAreaMode.MachByLanes;
    else if (this.\u0010.Checked)
      this.Par.MachiningAreaMode = MachiningParamsMachiningAreaMode.MachByRegions;
    if (this.\u000E.Checked)
      this.Par.MachDirForOneWay = MachiningParamsDirection.DirClimb;
    else if (this.\u0008.Checked)
      this.Par.MachDirForOneWay = MachiningParamsDirection.DirConventional;
    if (this.\u0001.Checked)
      this.Par.CurMachType = MachiningParamsMachType.MachtypeOneway;
    else if (this.\u0002.Checked)
    {
      this.Par.CurMachType = MachiningParamsMachType.MachtypeZigzag;
    }
    else
    {
      if (!this.\u000F.Checked)
        return;
      this.Par.CurMachType = MachiningParamsMachType.MachtypeSpiral;
    }
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RoughType = !this.\u0007.Checked ? (!this.\u0006.Checked ? TriangleMeshBasedTpCalcParamsRoughType.TmbRghtAdaptive : TriangleMeshBasedTpCalcParamsRoughType.TmbRghtParallel) : TriangleMeshBasedTpCalcParamsRoughType.TmbRghtOffset;
    this.UpdateControlFromType();
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!this.Properties.Inited)
      return;
    if (control2.Name == this.\u0004.Name)
    {
      this.Properties.Inited = false;
      this.Par.MaxStepoverDistance = (double) this.\u0004.Value;
      this.Par.DesiredStepover = Math.Round(this.Par.MaxStepoverDistance / 1.25, 3);
      this.\u0003.Value = (Decimal) this.Par.DesiredStepover;
    }
    this.Properties.Inited = true;
  }
}
