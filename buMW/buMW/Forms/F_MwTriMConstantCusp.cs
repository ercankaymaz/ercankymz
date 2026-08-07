// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwTriMConstantCusp
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

public class F_MwTriMConstantCusp : Form
{
  internal NumericUpDown \u0006;
  internal RadioButton \u0004;
  internal Button \u0010;
  internal CheckBox \u0006;
  internal Button \u0011;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  internal IContainer \u0001 = (IContainer) null;
  internal CheckBox \u0001;
  internal Panel \u0001;
  internal RadioButton \u0001;
  internal System.Windows.Forms.Label \u0001;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  internal System.Windows.Forms.Label \u0002;
  internal RadioButton \u0004;
  internal RadioButton \u0005;
  internal NumericUpDown \u0001;
  internal Panel \u0002;
  internal System.Windows.Forms.Label \u0003;
  internal RadioButton \u0006;
  internal RadioButton \u0007;
  internal System.Windows.Forms.Label \u0004;
  internal Panel \u0003;
  internal Button \u0001;
  internal Button \u0002;
  public Button btn_cancel;
  internal ImageList \u0001;
  internal System.Windows.Forms.Label \u0005;
  internal System.Windows.Forms.Label \u0006;
  internal NumericUpDown \u0002;
  internal System.Windows.Forms.Label \u0007;
  internal NumericUpDown \u0003;
  internal System.Windows.Forms.Label \u0008;
  internal Panel \u0004;
  internal NumericUpDown \u0004;
  internal NumericUpDown \u0005;
  internal System.Windows.Forms.Label \u000E;
  internal CheckBox \u0002;
  internal System.Windows.Forms.Label \u000F;
  internal Panel \u0005;
  internal NumericUpDown \u0006;
  public Button btn_ok;
  internal System.Windows.Forms.Label \u0010;
  internal Button \u0003;
  internal Button \u0004;
  internal Panel \u0006;
  internal Button \u0005;
  internal System.Windows.Forms.Label \u0011;
  internal TabPage \u0001;
  internal Panel \u0007;
  internal CheckBox \u0003;
  internal CheckBox \u0004;
  internal Button \u0006;
  internal CheckBox \u0005;
  internal Button \u0007;
  internal CheckBox \u0006;
  internal Button \u0008;
  internal CheckBox \u0007;
  internal Button \u000E;
  internal CheckBox \u0008;
  internal Button \u000F;
  internal CheckBox \u000E;
  internal Button \u0010;
  internal System.Windows.Forms.Label \u0012;
  internal Button \u0011;
  internal Button \u0012;
  internal Panel \u0008;
  internal System.Windows.Forms.Label \u0013;
  internal Button \u0013;
  internal NumericUpDown \u0007;
  internal System.Windows.Forms.Label \u0014;
  internal Button \u0014;
  internal Panel \u000E;
  internal TabControl \u0001;
  internal PictureBox \u0001;
  internal RadioButton \u0008;
  internal RadioButton \u000E;
  internal RadioButton \u000F;
  internal System.Windows.Forms.Label \u0015;
  internal NumericUpDown \u0008;
  internal System.Windows.Forms.Label \u0016;
  internal System.Windows.Forms.Label \u0017;
  public ComboBox combo_stepdirection;
  internal Panel \u000F;
  internal CheckBox \u000F;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MwTriMPencil) this).UpdateControlFromType();
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_MwTriMPencil) this).Properties.Inited)
      return;
    ((F_MwTriMPencil) this).Properties.Inited = false;
    ((F_MwTriMPencil) this).Apply();
    ((F_MwTriMPencil) this).UpdateControlFromType();
    ((F_MwTriMPencil) this).Properties.Inited = true;
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_MwTriMPencil) this).\u0001.Name)
    {
      F_MWTriMDynamicalHolderColl mdynamicalHolderColl = new F_MWTriMDynamicalHolderColl();
      mdynamicalHolderColl.Par = new MachiningParams(((F_MwTriMPencil) this).Par);
      mdynamicalHolderColl.Init();
      int num = (int) mdynamicalHolderColl.ShowDialog();
      if (mdynamicalHolderColl.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMPencil) this).Par = new MachiningParams(mdynamicalHolderColl.Par);
        mdynamicalHolderColl.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMPencil) this).\u0003.Name)
    {
      F_MwTriMHeights fMwTriMheights = new F_MwTriMHeights();
      fMwTriMheights.Par = new MachiningParams(((F_MwTriMPencil) this).Par);
      fMwTriMheights.Init();
      int num = (int) fMwTriMheights.ShowDialog();
      if (fMwTriMheights.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMPencil) this).Par = new MachiningParams(fMwTriMheights.Par);
        fMwTriMheights.Dispose();
      }
    }
    if (control2.Name == this.\u0011.Name)
    {
      F_MwTriMOffset fMwTriMoffset = new F_MwTriMOffset();
      fMwTriMoffset.Par = new MachiningParams(((F_MwTriMPencil) this).Par);
      fMwTriMoffset.Init();
      int num = (int) fMwTriMoffset.ShowDialog();
      if (fMwTriMoffset.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMPencil) this).Par = new MachiningParams(fMwTriMoffset.Par);
        fMwTriMoffset.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMPencil) this).\u000F.Name)
    {
      F_MwTriMRoughLink fMwTriMroughLink = new F_MwTriMRoughLink();
      fMwTriMroughLink.Par = new MachiningParams(((F_MwTriMPencil) this).Par);
      fMwTriMroughLink.Init();
      int num = (int) fMwTriMroughLink.ShowDialog();
      if (fMwTriMroughLink.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMPencil) this).Par = new MachiningParams(fMwTriMroughLink.Par);
        fMwTriMroughLink.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMPencil) this).\u0002.Name)
    {
      F_MwTriMRoughing fMwTriMroughing = new F_MwTriMRoughing();
      fMwTriMroughing.Par = new MachiningParams(((F_MwTriMPencil) this).Par);
      fMwTriMroughing.Init();
      int num = (int) fMwTriMroughing.ShowDialog();
      if (fMwTriMroughing.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMPencil) this).Par = new MachiningParams(fMwTriMroughing.Par);
        fMwTriMroughing.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMPencil) this).\u0008.Name)
    {
      F_MwGaugeCheck fMwGaugeCheck = new F_MwGaugeCheck();
      fMwGaugeCheck.Par = new MachiningParams(((F_MwTriMPencil) this).Par);
      fMwGaugeCheck.Init();
      int num = (int) fMwGaugeCheck.ShowDialog();
      if (fMwGaugeCheck.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMPencil) this).Par = new MachiningParams(fMwGaugeCheck.Par);
        fMwGaugeCheck.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMPencil) this).\u0004.Name)
    {
      F_MwTriMAngleRange mwTriMangleRange = new F_MwTriMAngleRange();
      mwTriMangleRange.Par = new MachiningParams(((F_MwTriMPencil) this).Par);
      mwTriMangleRange.Init();
      int num = (int) mwTriMangleRange.ShowDialog();
      if (mwTriMangleRange.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMPencil) this).Par = new MachiningParams(mwTriMangleRange.Par);
        mwTriMangleRange.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMPencil) this).\u000E.Name)
    {
      F_MwTriMSurfaceQuality triMsurfaceQuality = new F_MwTriMSurfaceQuality();
      triMsurfaceQuality.Par = new MachiningParams(((F_MwTriMPencil) this).Par);
      triMsurfaceQuality.Init();
      int num = (int) triMsurfaceQuality.ShowDialog();
      if (triMsurfaceQuality.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMPencil) this).Par = new MachiningParams(triMsurfaceQuality.Par);
        triMsurfaceQuality.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMPencil) this).\u0006.Name)
    {
      F_MwTriMSilhouette mwTriMsilhouette = new F_MwTriMSilhouette();
      mwTriMsilhouette.Par = new MachiningParams(((F_MwTriMPencil) this).Par);
      mwTriMsilhouette.Init();
      int num = (int) mwTriMsilhouette.ShowDialog();
      if (mwTriMsilhouette.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMPencil) this).Par = new MachiningParams(mwTriMsilhouette.Par);
        mwTriMsilhouette.Dispose();
      }
    }
    if (control2.Name == ((F_MwTriMPencil) this).\u0005.Name)
    {
      F_MwTriM2dContainment triM2dContainment = new F_MwTriM2dContainment();
      triM2dContainment.Par = new MachiningParams(((F_MwTriMPencil) this).Par);
      triM2dContainment.Init();
      int num = (int) triM2dContainment.ShowDialog();
      if (triM2dContainment.Properties.Result == DialogResult.OK)
      {
        ((F_MwTriMPencil) this).Par = new MachiningParams(triM2dContainment.Par);
        triM2dContainment.Dispose();
      }
    }
    if (!(control2.Name == ((F_MwTriMPencil) this).\u0007.Name))
      return;
    F_MwTriMUtility fMwTriMutility = new F_MwTriMUtility();
    fMwTriMutility.Par = new MachiningParams(((F_MwTriMPencil) this).Par);
    fMwTriMutility.Init();
    int num1 = (int) fMwTriMutility.ShowDialog();
    if (fMwTriMutility.Properties.Result != DialogResult.OK)
      return;
    ((F_MwTriMPencil) this).Par = new MachiningParams(fMwTriMutility.Par);
    fMwTriMutility.Dispose();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwTriMPencil) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwTriMPencil) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwTriMConstantCusp() => \u0005.\u0002.\u0001(this);

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
    if (this.Par.ProjectCurvesParams.OffsetDirection == ProjectCurvesParamsOffsetDirection.PcpOdLeft)
      this.combo_stepdirection.SelectedIndex = 0;
    else if (this.Par.ProjectCurvesParams.OffsetDirection == ProjectCurvesParamsOffsetDirection.PcpOdRight)
      this.combo_stepdirection.SelectedIndex = 1;
    else if (this.Par.ProjectCurvesParams.OffsetDirection == ProjectCurvesParamsOffsetDirection.PcpOdBoth)
      this.combo_stepdirection.SelectedIndex = 2;
    if (this.Par.CurMachType == MachiningParamsMachType.MachtypeOneway)
      this.\u0002.Checked = true;
    else if (this.Par.CurMachType == MachiningParamsMachType.MachtypeZigzag)
      this.\u0003.Checked = true;
    else if (this.Par.CurMachType == MachiningParamsMachType.MachtypeSpiral)
      this.\u0001.Checked = true;
    if (this.Par.CurCutOrder == MachiningParamsCutOrder.OrderStandard)
      this.\u0005.Checked = true;
    else if (this.Par.CurCutOrder == MachiningParamsCutOrder.OrderFromBottomToTop)
      this.\u0008.Checked = true;
    else if (this.Par.CurCutOrder == MachiningParamsCutOrder.OrderFromCenter)
      this.\u0004.Checked = true;
    else if (this.Par.CurCutOrder == MachiningParamsCutOrder.OrderFromOuter)
      this.\u000F.Checked = true;
    else if (this.Par.CurCutOrder == MachiningParamsCutOrder.OrderFromTopToBottom)
      this.\u000E.Checked = true;
    if (this.Par.MachDirForOneWay == MachiningParamsDirection.DirConventional)
      this.\u0006.Checked = true;
    else
      this.\u0007.Checked = true;
    this.\u0008.Value = (Decimal) this.Par.MaxStepoverDistance;
    this.\u0005.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ProjectCurvesParams.LeftDirNumberOfCuts;
    this.\u0004.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ProjectCurvesParams.RightDirNumberOfCuts;
    this.\u0007.Value = (Decimal) this.Par.CutTolerance;
    this.\u0006.Value = (Decimal) this.Par.RetractFeedRate;
    this.\u0002.Value = (Decimal) this.Par.PlungeFeedRate;
    this.\u0003.Value = (Decimal) this.Par.FeedRate;
    this.\u0001.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.OverlapLength;
    this.\u0008.Checked = this.Par.Containment2dParams.IsUsedFlg;
    this.\u000E.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentFlg;
    this.\u0005.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaUndercutsParams.UndercutsFlg;
    this.\u0007.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.RestFinishingFlg;
    this.\u0004.Checked = this.Par.ShallowAndSteepAreaParams.IsUsedFlg;
    this.\u0006.Checked = this.Par.RadiusFitFlg;
    this.\u0002.Checked = this.Par.RapidRetractFlg;
    this.\u0001.Checked = this.Par.StartPosFlag;
    this.\u0003.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ExcludeUndercutAreasFlg;
    this.\u000F.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ConstantCuspDriveCurvesFlg;
    ((F_MwTriMRoughing) this).\u0010.Checked = this.Par.ReverseCutsFlg;
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
    this.\u0005.Visible = false;
    this.\u0007.Visible = false;
    this.\u0003.Visible = false;
    this.\u0017.Visible = false;
    if (this.\u0005.Checked)
      ((F_MwTriMRoughing) this).\u0010.Enabled = true;
    else
      ((F_MwTriMRoughing) this).\u0010.Enabled = false;
    if (this.combo_stepdirection.SelectedIndex == 0)
    {
      ((F_MwTriMRoughing) this).\u0012.Enabled = true;
      this.\u0005.Enabled = true;
      ((F_MwTriMRoughing) this).\u0011.Enabled = false;
      this.\u0004.Enabled = false;
    }
    else if (this.combo_stepdirection.SelectedIndex == 1)
    {
      ((F_MwTriMRoughing) this).\u0012.Enabled = false;
      this.\u0005.Enabled = false;
      ((F_MwTriMRoughing) this).\u0011.Enabled = true;
      this.\u0004.Enabled = true;
    }
    else if (this.combo_stepdirection.SelectedIndex == 2)
    {
      ((F_MwTriMRoughing) this).\u0012.Enabled = true;
      this.\u0005.Enabled = true;
      ((F_MwTriMRoughing) this).\u0011.Enabled = true;
      this.\u0004.Enabled = true;
    }
    this.\u0005.Enabled = ((F_MwTriMRoughing) this).\u0012.Enabled & ((F_MwTriMRoughing) this).\u0012.Checked;
    this.\u0004.Enabled = ((F_MwTriMRoughing) this).\u0011.Enabled & ((F_MwTriMRoughing) this).\u0011.Checked;
    this.\u0005.Enabled = !this.\u0003.Checked;
    this.\u0007.Enabled = this.\u0005.Checked & this.\u0005.Enabled;
    this.\u0003.Enabled = !this.\u0005.Checked;
    this.\u0017.Enabled = this.\u0003.Enabled & this.\u0003.Checked;
    this.\u0006.Enabled = !this.\u0005.Checked;
    this.\u0008.Enabled = this.\u0006.Enabled & this.\u0006.Checked;
    this.\u000E.Enabled = !this.\u0005.Checked;
    this.\u0010.Enabled = this.\u000E.Enabled & this.\u000E.Checked;
    this.\u0007.Enabled = !this.\u0005.Checked;
    this.\u000E.Enabled = this.\u0007.Enabled & this.\u0007.Checked;
    this.\u0008.Enabled = !this.\u0005.Checked;
    this.\u000F.Enabled = this.\u0008.Enabled & this.\u0008.Checked;
    this.\u0004.Enabled = !this.\u0005.Checked;
    this.\u0006.Enabled = this.\u0004.Enabled & this.\u0004.Checked;
    this.\u0001.Enabled = this.\u0001.Enabled & this.\u0001.Checked;
    ((F_MwTriMRoughing) this).\u0015.Enabled = this.\u000F.Enabled & this.\u000F.Checked;
  }

  public void Apply()
  {
    this.Par.MaxStepoverDistance = (double) this.\u0008.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ProjectCurvesParams.LeftDirNumberOfCuts = (int) this.\u0005.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ProjectCurvesParams.RightDirNumberOfCuts = (int) this.\u0004.Value;
    this.Par.CutTolerance = (double) this.\u0007.Value;
    this.Par.RetractFeedRate = (double) this.\u0006.Value;
    this.Par.PlungeFeedRate = (double) this.\u0002.Value;
    this.Par.FeedRate = (double) this.\u0003.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.OverlapLength = (double) this.\u0001.Value;
    this.Par.Containment2dParams.IsUsedFlg = this.\u0008.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentFlg = this.\u000E.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaUndercutsParams.UndercutsFlg = this.\u0005.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.RestFinishingFlg = this.\u0007.Checked;
    this.Par.ShallowAndSteepAreaParams.IsUsedFlg = this.\u0004.Checked;
    this.Par.RadiusFitFlg = this.\u0006.Checked;
    this.Par.RapidRetractFlg = this.\u0002.Checked;
    this.Par.StartPosFlag = this.\u0001.Checked;
    this.Par.ReverseCutsFlg = ((F_MwTriMRoughing) this).\u0010.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ConstantCuspDriveCurvesFlg = this.\u000F.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ExcludeUndercutAreasFlg = this.\u0003.Checked;
    if (this.combo_stepdirection.SelectedIndex == 0)
      this.Par.ProjectCurvesParams.OffsetDirection = ProjectCurvesParamsOffsetDirection.PcpOdLeft;
    else if (this.combo_stepdirection.SelectedIndex == 1)
      this.Par.ProjectCurvesParams.OffsetDirection = ProjectCurvesParamsOffsetDirection.PcpOdRight;
    else if (this.combo_stepdirection.SelectedIndex == 2)
      this.Par.ProjectCurvesParams.OffsetDirection = ProjectCurvesParamsOffsetDirection.PcpOdBoth;
    if (this.\u0002.Checked)
      this.Par.CurMachType = MachiningParamsMachType.MachtypeOneway;
    else if (this.\u0003.Checked)
      this.Par.CurMachType = MachiningParamsMachType.MachtypeZigzag;
    else if (this.\u0001.Checked)
      this.Par.CurMachType = MachiningParamsMachType.MachtypeSpiral;
    if (this.\u0007.Checked)
      this.Par.MachDirForOneWay = MachiningParamsDirection.DirClimb;
    else if (this.\u0006.Checked)
      this.Par.MachDirForOneWay = MachiningParamsDirection.DirConventional;
    if (this.\u0005.Checked)
      this.Par.CurCutOrder = MachiningParamsCutOrder.OrderStandard;
    else if (this.\u0008.Checked)
      this.Par.CurCutOrder = MachiningParamsCutOrder.OrderFromBottomToTop;
    else if (this.\u0004.Checked)
      this.Par.CurCutOrder = MachiningParamsCutOrder.OrderFromCenter;
    else if (this.\u000F.Checked)
    {
      this.Par.CurCutOrder = MachiningParamsCutOrder.OrderFromOuter;
    }
    else
    {
      if (!this.\u000E.Checked)
        return;
      this.Par.CurCutOrder = MachiningParamsCutOrder.OrderFromTopToBottom;
    }
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1) => this.UpdateControlFromType();
}
