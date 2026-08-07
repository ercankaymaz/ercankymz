// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwTriMPencil
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

public class F_MwTriMPencil : Form
{
  internal RadioButton \u0003;
  internal NumericUpDown \u0004;
  internal NumericUpDown \u0005;
  internal System.Windows.Forms.Label \u0006;
  internal NumericUpDown \u0006;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  internal IContainer \u0001 = (IContainer) null;
  internal Panel \u0001;
  internal System.Windows.Forms.Label \u0001;
  internal RadioButton \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  internal Panel \u0002;
  internal Button \u0001;
  public Button btn_cancel;
  internal ImageList \u0001;
  internal System.Windows.Forms.Label \u0003;
  internal System.Windows.Forms.Label \u0004;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0005;
  internal NumericUpDown \u0002;
  internal System.Windows.Forms.Label \u0006;
  internal Panel \u0003;
  internal CheckBox \u0001;
  internal System.Windows.Forms.Label \u0007;
  internal NumericUpDown \u0003;
  internal System.Windows.Forms.Label \u0008;
  internal CheckBox \u0002;
  internal System.Windows.Forms.Label \u000E;
  internal Panel \u0004;
  internal NumericUpDown \u0004;
  public Button btn_ok;
  internal System.Windows.Forms.Label \u000F;
  internal Button \u0002;
  internal Button \u0003;
  internal Panel \u0005;
  internal System.Windows.Forms.Label \u0010;
  internal TabPage \u0001;
  internal Panel \u0006;
  internal CheckBox \u0003;
  internal Button \u0004;
  internal CheckBox \u0004;
  internal Button \u0005;
  internal CheckBox \u0005;
  internal Button \u0006;
  internal System.Windows.Forms.Label \u0011;
  internal Button \u0007;
  internal Button \u0008;
  internal Panel \u0007;
  internal System.Windows.Forms.Label \u0012;
  internal Button \u000E;
  internal NumericUpDown \u0005;
  internal System.Windows.Forms.Label \u0013;
  internal Button \u000F;
  internal Panel \u0008;
  internal TabControl \u0001;
  internal PictureBox \u0001;
  internal System.Windows.Forms.Label \u0014;

  public void Apply()
  {
    ((F_MwTriMUtility) this).Par.FeedRateForDirectSplineLinksParams.FeedRateForLinksBetweenRegionsFlg = ((F_MwTriMUtility) this).\u0003.Checked;
    ((F_MwTriMUtility) this).Par.FeedRateForDirectSplineLinksParams.FeedRateForLinksBetweenSlicesFlg = ((F_MwTriMUtility) this).\u0004.Checked;
    ((F_MwTriMUtility) this).Par.FeedRateForDirectSplineLinksParams.FeedRateForAreaLinksFlg = ((F_MwTriMUtility) this).\u0005.Checked;
    ((F_MwTriMUtility) this).Par.FeedRateForDirectSplineLinksParams.FeedRateForLinksBetweenRegions = (double) ((F_MwTriMUtility) this).\u0002.Value;
    ((F_MwTriMUtility) this).Par.FeedRateForDirectSplineLinksParams.FeedRateForLinksBetweenSlices = (double) ((F_MwTriMUtility) this).\u0003.Value;
    ((F_MwTriMUtility) this).Par.FeedRateForDirectSplineLinksParams.FeedRateForAreaLinks = (double) this.\u0006.Value;
    ((F_MwTriMUtility) this).Par.FeedControlZoneParams.Status = ((F_MwTriMUtility) this).\u0002.Checked;
    ((F_MwTriMUtility) this).Par.DampAxialShiftFlg = ((F_MwTriMUtility) this).\u0006.Checked;
    ((F_MwTriMUtility) this).Par.RapidFeedrate = (double) ((F_MwTriMUtility) this).\u0001.Value;
    ((F_MwTriMUtility) this).Par.RapidFeedFlg = ((F_MwTriMUtility) this).\u0001.Checked;
    if (((F_MwTriMUtility) this).\u0002.Checked)
      ((F_MwTriMUtility) this).Par.AxialShiftType = MachiningParamsAxialShiftType.AstConstForEachContour;
    if (((F_MwTriMUtility) this).\u0001.Checked)
      ((F_MwTriMUtility) this).Par.AxialShiftType = MachiningParamsAxialShiftType.AstGradualForAllCuts;
    if (!this.\u0003.Checked)
      return;
    ((F_MwTriMUtility) this).Par.AxialShiftType = MachiningParamsAxialShiftType.AstGradualForEachContour;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MwTriMUtility) this).UpdateControlFromType();
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_MwTriMUtility) this).Properties.Inited)
      return;
    ((F_MwTriMUtility) this).Properties.Inited = false;
    this.Apply();
    ((F_MwTriMUtility) this).UpdateControlFromType();
    ((F_MwTriMUtility) this).Properties.Inited = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwTriMUtility) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwTriMUtility) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwTriMPencil() => \u0005.\u0002.\u0001(this);

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
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MultiPencilFlg = false;
      this.Par.StartPosFlag = false;
    }
    if (this.Par.CurMachType == MachiningParamsMachType.MachtypeOneway)
      this.\u0001.Checked = true;
    else if (this.Par.CurMachType == MachiningParamsMachType.MachtypeZigzag)
      ((F_MwTriMConstantCusp) this).\u0004.Checked = true;
    if (this.Par.MachDirForOneWay == MachiningParamsDirection.DirConventional)
      this.\u0002.Checked = true;
    else
      this.\u0003.Checked = true;
    this.\u0005.Value = (Decimal) this.Par.CutTolerance;
    this.\u0004.Value = (Decimal) this.Par.RetractFeedRate;
    this.\u0001.Value = (Decimal) this.Par.PlungeFeedRate;
    this.\u0002.Value = (Decimal) this.Par.FeedRate;
    this.\u0003.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.NumberOfCuts;
    ((F_MwTriMConstantCusp) this).\u0006.Value = (Decimal) this.Par.MaxStepoverDistance;
    this.\u0004.Checked = this.Par.Containment2dParams.IsUsedFlg;
    this.\u0005.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentFlg;
    this.\u0001.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MultiPencilFlg;
    this.\u0003.Checked = this.Par.ShallowAndSteepAreaParams.IsUsedFlg;
    this.\u0002.Checked = this.Par.RapidRetractFlg;
    ((F_MwTriMConstantCusp) this).\u0006.Checked = this.Par.StartPosFlag;
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
    this.\u0007.Enabled = this.\u0001.Checked;
    this.\u0003.Enabled = this.\u0001.Checked;
    this.\u0014.Enabled = this.\u0001.Checked;
    ((F_MwTriMConstantCusp) this).\u0006.Enabled = this.\u0001.Checked;
    this.\u0006.Enabled = this.\u0005.Enabled & this.\u0005.Checked;
    this.\u0005.Enabled = this.\u0004.Enabled & this.\u0004.Checked;
    this.\u0004.Enabled = this.\u0003.Enabled & this.\u0003.Checked;
    ((F_MwTriMConstantCusp) this).\u0010.Enabled = ((F_MwTriMConstantCusp) this).\u0006.Enabled & ((F_MwTriMConstantCusp) this).\u0006.Checked;
    if (this.\u0001.Checked)
    {
      ((F_MwTriMConstantCusp) this).\u0004.Enabled = true;
    }
    else
    {
      ((F_MwTriMConstantCusp) this).\u0004.Enabled = false;
      this.\u0001.Checked = true;
    }
    if (buMWCalcs.AdvancedTriMesh)
      return;
    this.\u0001.Enabled = false;
    this.\u0003.Enabled = false;
    this.\u0007.Enabled = false;
    ((F_MwTriMConstantCusp) this).\u0006.Enabled = false;
    ((F_MwTriMConstantCusp) this).\u0010.Enabled = false;
    this.\u0001.Enabled = false;
  }

  public void Apply()
  {
    this.Par.MaxStepoverDistance = (double) ((F_MwTriMConstantCusp) this).\u0006.Value;
    this.Par.CutTolerance = (double) this.\u0005.Value;
    this.Par.RetractFeedRate = (double) this.\u0004.Value;
    this.Par.PlungeFeedRate = (double) this.\u0001.Value;
    this.Par.FeedRate = (double) this.\u0002.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.NumberOfCuts = (int) this.\u0003.Value;
    this.Par.Containment2dParams.IsUsedFlg = this.\u0004.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentFlg = this.\u0005.Checked;
    this.Par.ShallowAndSteepAreaParams.IsUsedFlg = this.\u0003.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MultiPencilFlg = this.\u0001.Checked;
    this.Par.RapidRetractFlg = this.\u0002.Checked;
    this.Par.StartPosFlag = ((F_MwTriMConstantCusp) this).\u0006.Checked;
    if (this.\u0001.Checked)
      this.Par.CurMachType = MachiningParamsMachType.MachtypeOneway;
    else if (((F_MwTriMConstantCusp) this).\u0004.Checked)
      this.Par.CurMachType = MachiningParamsMachType.MachtypeZigzag;
    if (this.\u0003.Checked)
    {
      this.Par.MachDirForOneWay = MachiningParamsDirection.DirClimb;
    }
    else
    {
      if (!this.\u0002.Checked)
        return;
      this.Par.MachDirForOneWay = MachiningParamsDirection.DirConventional;
    }
  }
}
