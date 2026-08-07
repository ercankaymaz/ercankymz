// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwTriMConstantZ
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

public class F_MwTriMConstantZ : Form
{
  internal System.Windows.Forms.Label \u0004;
  internal NumericUpDown \u0003;
  internal System.Windows.Forms.Label \u0005;
  internal ImageList \u0002;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  internal IContainer \u0001 = (IContainer) null;
  internal Button \u0001;
  internal Panel \u0001;
  internal System.Windows.Forms.Label \u0001;
  internal Button \u0002;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal TabControl \u0001;
  internal TabPage \u0001;
  internal Panel \u0002;
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
  internal Button \u0008;
  internal System.Windows.Forms.Label \u0003;
  internal Panel \u0003;
  internal Panel \u0004;
  internal System.Windows.Forms.Label \u0004;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal Panel \u0005;
  internal RadioButton \u0003;
  internal System.Windows.Forms.Label \u0005;
  internal RadioButton \u0004;
  internal RadioButton \u0005;
  internal System.Windows.Forms.Label \u0006;
  public Button btn_ok;
  internal ImageList \u0001;
  internal Panel \u0006;
  internal System.Windows.Forms.Label \u0007;
  internal NumericUpDown \u0002;
  internal System.Windows.Forms.Label \u0008;
  internal NumericUpDown \u0003;
  internal System.Windows.Forms.Label \u000E;
  internal NumericUpDown \u0004;
  internal System.Windows.Forms.Label \u000F;
  public Button btn_cancel;
  internal Button \u000E;
  internal Button \u000F;
  internal Button \u0010;
  internal System.Windows.Forms.Label \u0010;
  internal PictureBox \u0001;
  internal CheckBox \u0007;
  internal Button \u0011;
  internal Panel \u0007;
  internal Button \u0012;
  internal Button \u0013;
  internal System.Windows.Forms.Label \u0011;
  internal Button \u0014;
  internal Panel \u0008;
  internal Button \u0015;
  internal NumericUpDown \u0005;
  internal NumericUpDown \u0006;
  internal RadioButton \u0006;
  internal RadioButton \u0007;
  internal System.Windows.Forms.Label \u0012;
  internal CheckBox \u0008;
  internal Button \u0016;
  internal Panel \u000E;
  internal System.Windows.Forms.Label \u0013;
  internal RadioButton \u0008;
  internal RadioButton \u000E;
  internal Panel \u000F;
  internal System.Windows.Forms.Label \u0014;
  internal RadioButton \u000F;
  internal RadioButton \u0010;
  internal Button \u0017;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MwTriMOffset) this).UpdateControlFromType();
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Tag == null)
      return;
    ((F_MwTriMOffset) this).\u0001.Image = this.\u0002.Images[Convert.ToInt32(control2.Tag)];
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwTriMOffset) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwTriMOffset) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwTriMConstantZ() => \u0005.\u0002.\u0001(this);

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
      this.Par.StartPosFlag = false;
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.RestFinishingFlg = false;
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaUndercutsParams.UndercutsFlg = false;
    }
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.ConstantZStart == SharedMiscParamsConstantZStart.ShbZsTop)
      this.\u0002.Checked = true;
    else if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.ConstantZStart == SharedMiscParamsConstantZStart.ShbZsBottom)
      this.\u0001.Checked = true;
    if (this.Par.CurMachType == MachiningParamsMachType.MachtypeOneway)
      this.\u0004.Checked = true;
    else if (this.Par.CurMachType == MachiningParamsMachType.MachtypeZigzag)
      this.\u0005.Checked = true;
    else if (this.Par.CurMachType == MachiningParamsMachType.MachtypeSpiral)
      this.\u0003.Checked = true;
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepMode == MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep)
      this.\u0007.Checked = true;
    else
      this.\u0006.Checked = true;
    if (this.Par.MachiningAreaMode == MachiningParamsMachiningAreaMode.MachByLanes)
      this.\u000E.Checked = true;
    else
      this.\u0008.Checked = true;
    if (this.Par.MachDirForOneWay == MachiningParamsDirection.DirConventional)
      this.\u000F.Checked = true;
    else
      this.\u0010.Checked = true;
    this.\u0006.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStep;
    this.\u0001.Value = (Decimal) this.Par.CutTolerance;
    this.\u0002.Value = (Decimal) this.Par.RetractFeedRate;
    this.\u0003.Value = (Decimal) this.Par.PlungeFeedRate;
    this.\u0004.Value = (Decimal) this.Par.FeedRate;
    this.\u0005.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.NumberOfSlices4DepthStep;
    ((F_MwTriMProjectCurves) this).\u0007.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.OverlapLength;
    this.\u0005.Checked = this.Par.Containment2dParams.IsUsedFlg;
    this.\u0006.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentFlg;
    this.\u0002.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaUndercutsParams.UndercutsFlg;
    this.\u0004.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.RestFinishingFlg;
    this.\u0001.Checked = this.Par.ShallowAndSteepAreaParams.IsUsedFlg;
    this.\u0003.Checked = this.Par.RadiusFitFlg;
    this.\u0007.Checked = this.Par.RapidRetractFlg;
    ((F_MwTriMProjectCurves) this).\u000E.Checked = this.Par.StartPosFlag;
    this.\u0008.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ExcludeUndercutAreasFlg;
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
    this.\u0002.Visible = false;
    this.\u0004.Visible = false;
    this.\u0008.Visible = false;
    this.\u0016.Visible = false;
    ((F_MwTriMProjectCurves) this).\u000F.Enabled = false;
    this.\u0006.Enabled = this.\u0007.Checked;
    this.\u0005.Enabled = this.\u0006.Checked;
    if (this.\u0005.Checked)
    {
      this.\u000E.Enabled = true;
      this.\u0011.Enabled = false;
      ((F_MwTriMProjectCurves) this).\u000F.Enabled = true;
    }
    else if (this.\u0004.Checked)
    {
      this.\u000E.Enabled = true;
      this.\u0011.Enabled = false;
    }
    else if (this.\u0003.Checked)
    {
      this.\u000E.Enabled = false;
      this.\u0011.Enabled = true;
    }
    this.\u0002.Enabled = !this.\u0008.Checked;
    this.\u0004.Enabled = this.\u0002.Checked & this.\u0002.Enabled;
    this.\u0008.Enabled = !this.\u0002.Checked;
    this.\u0016.Enabled = this.\u0008.Enabled & this.\u0008.Checked;
    this.\u0003.Enabled = !this.\u0002.Checked;
    this.\u0005.Enabled = this.\u0003.Enabled & this.\u0003.Checked;
    this.\u0006.Enabled = !this.\u0002.Checked;
    this.\u0008.Enabled = this.\u0006.Enabled & this.\u0006.Checked;
    this.\u0004.Enabled = !this.\u0002.Checked;
    this.\u0006.Enabled = this.\u0004.Enabled & this.\u0004.Checked;
    this.\u0005.Enabled = !this.\u0002.Checked;
    this.\u0007.Enabled = this.\u0005.Enabled & this.\u0005.Checked;
    this.\u0001.Enabled = !this.\u0002.Checked;
    this.\u0003.Enabled = this.\u0001.Enabled & this.\u0001.Checked;
    this.\u0017.Enabled = ((F_MwTriMProjectCurves) this).\u000E.Enabled & ((F_MwTriMProjectCurves) this).\u000E.Checked;
    if (buMWCalcs.AdvancedTriMesh)
      return;
    this.\u0004.Enabled = false;
    this.\u0006.Enabled = false;
    this.\u0002.Enabled = false;
    this.\u0004.Enabled = false;
    ((F_MwTriMProjectCurves) this).\u000E.Enabled = false;
    this.\u0017.Enabled = false;
    this.\u0014.Enabled = false;
  }

  public void Apply()
  {
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStep = (double) this.\u0006.Value;
    this.Par.CutTolerance = (double) this.\u0001.Value;
    this.Par.RetractFeedRate = (double) this.\u0002.Value;
    this.Par.PlungeFeedRate = (double) this.\u0003.Value;
    this.Par.FeedRate = (double) this.\u0004.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.NumberOfSlices4DepthStep = (int) this.\u0005.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.OverlapLength = (double) ((F_MwTriMProjectCurves) this).\u0007.Value;
    this.Par.Containment2dParams.IsUsedFlg = this.\u0005.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentFlg = this.\u0006.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaUndercutsParams.UndercutsFlg = this.\u0002.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.RestFinishingFlg = this.\u0004.Checked;
    this.Par.ShallowAndSteepAreaParams.IsUsedFlg = this.\u0001.Checked;
    this.Par.RadiusFitFlg = this.\u0003.Checked;
    this.Par.RapidRetractFlg = this.\u0007.Checked;
    this.Par.StartPosFlag = ((F_MwTriMProjectCurves) this).\u000E.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ExcludeUndercutAreasFlg = this.\u0008.Checked;
    if (this.\u0002.Checked)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.ConstantZStart = SharedMiscParamsConstantZStart.ShbZsTop;
    else if (this.\u0001.Checked)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.ConstantZStart = SharedMiscParamsConstantZStart.ShbZsBottom;
    if (this.\u0004.Checked)
      this.Par.CurMachType = MachiningParamsMachType.MachtypeOneway;
    else if (this.\u0005.Checked)
      this.Par.CurMachType = MachiningParamsMachType.MachtypeZigzag;
    else if (this.\u0003.Checked)
      this.Par.CurMachType = MachiningParamsMachType.MachtypeSpiral;
    if (this.\u0010.Checked)
      this.Par.MachDirForOneWay = MachiningParamsDirection.DirClimb;
    else if (this.\u000F.Checked)
      this.Par.MachDirForOneWay = MachiningParamsDirection.DirConventional;
    if (this.\u000E.Checked)
      this.Par.MachiningAreaMode = MachiningParamsMachiningAreaMode.MachByLanes;
    else if (this.\u0008.Checked)
      this.Par.MachiningAreaMode = MachiningParamsMachiningAreaMode.MachByRegions;
    if (this.\u0007.Checked)
    {
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepMode = MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep;
    }
    else
    {
      if (!this.\u0006.Checked)
        return;
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepMode = MachiningAreaRoughingParamsDepthStepMode.DsmNumberOfSlices;
    }
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1) => this.UpdateControlFromType();
}
