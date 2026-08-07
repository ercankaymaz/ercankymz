// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwTriM2dContainment
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

public class F_MwTriM2dContainment : Form
{
  internal CheckBox \u0001;
  internal Panel \u0002;
  internal System.Windows.Forms.Label \u0001;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  public bool Advanced = false;
  internal IContainer \u0001 = (IContainer) null;
  internal System.Windows.Forms.Label \u0001;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal PictureBox \u0001;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal Panel \u0001;
  internal System.Windows.Forms.Label \u0003;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  internal Panel \u0002;

  public void Apply()
  {
    ((F_MwGaugeRemainCollsion) this).Par.CollControl.ReportRemainingColls = this.\u0001.Checked;
    if (((F_MwGaugeRemainCollsion) this).\u0003.Checked)
    {
      ((F_MwGaugeRemainCollsion) this).Par.CollControl.CollCtrlOperations[0].StopTpCalcOnFirstRemainingGougeFlg = true;
      ((F_MwGaugeRemainCollsion) this).Par.CollControl.CollCtrlOperations[0].RemoveRemainingGougesForContoursFlg = false;
      ((F_MwGaugeRemainCollsion) this).Par.CollControl.CollCtrlOperations[1].StopTpCalcOnFirstRemainingGougeFlg = true;
      ((F_MwGaugeRemainCollsion) this).Par.CollControl.CollCtrlOperations[1].RemoveRemainingGougesForContoursFlg = false;
      ((F_MwGaugeRemainCollsion) this).Par.CollControl.CollCtrlOperations[2].StopTpCalcOnFirstRemainingGougeFlg = true;
      ((F_MwGaugeRemainCollsion) this).Par.CollControl.CollCtrlOperations[2].RemoveRemainingGougesForContoursFlg = false;
      ((F_MwGaugeRemainCollsion) this).Par.CollControl.CollCtrlOperations[3].StopTpCalcOnFirstRemainingGougeFlg = true;
      ((F_MwGaugeRemainCollsion) this).Par.CollControl.CollCtrlOperations[3].RemoveRemainingGougesForContoursFlg = false;
    }
    if (((F_MwGaugeRemainCollsion) this).\u0001.Checked)
    {
      ((F_MwGaugeRemainCollsion) this).Par.CollControl.CollCtrlOperations[0].StopTpCalcOnFirstRemainingGougeFlg = false;
      ((F_MwGaugeRemainCollsion) this).Par.CollControl.CollCtrlOperations[0].RemoveRemainingGougesForContoursFlg = true;
      ((F_MwGaugeRemainCollsion) this).Par.CollControl.CollCtrlOperations[1].StopTpCalcOnFirstRemainingGougeFlg = false;
      ((F_MwGaugeRemainCollsion) this).Par.CollControl.CollCtrlOperations[1].RemoveRemainingGougesForContoursFlg = true;
      ((F_MwGaugeRemainCollsion) this).Par.CollControl.CollCtrlOperations[2].StopTpCalcOnFirstRemainingGougeFlg = false;
      ((F_MwGaugeRemainCollsion) this).Par.CollControl.CollCtrlOperations[2].RemoveRemainingGougesForContoursFlg = true;
      ((F_MwGaugeRemainCollsion) this).Par.CollControl.CollCtrlOperations[3].StopTpCalcOnFirstRemainingGougeFlg = false;
      ((F_MwGaugeRemainCollsion) this).Par.CollControl.CollCtrlOperations[3].RemoveRemainingGougesForContoursFlg = true;
    }
    if (!((F_MwGaugeRemainCollsion) this).\u0002.Checked)
      return;
    ((F_MwGaugeRemainCollsion) this).Par.CollControl.CollCtrlOperations[0].StopTpCalcOnFirstRemainingGougeFlg = false;
    ((F_MwGaugeRemainCollsion) this).Par.CollControl.CollCtrlOperations[0].RemoveRemainingGougesForContoursFlg = false;
    ((F_MwGaugeRemainCollsion) this).Par.CollControl.CollCtrlOperations[1].StopTpCalcOnFirstRemainingGougeFlg = false;
    ((F_MwGaugeRemainCollsion) this).Par.CollControl.CollCtrlOperations[1].RemoveRemainingGougesForContoursFlg = false;
    ((F_MwGaugeRemainCollsion) this).Par.CollControl.CollCtrlOperations[2].StopTpCalcOnFirstRemainingGougeFlg = false;
    ((F_MwGaugeRemainCollsion) this).Par.CollControl.CollCtrlOperations[2].RemoveRemainingGougesForContoursFlg = false;
    ((F_MwGaugeRemainCollsion) this).Par.CollControl.CollCtrlOperations[3].StopTpCalcOnFirstRemainingGougeFlg = false;
    ((F_MwGaugeRemainCollsion) this).Par.CollControl.CollCtrlOperations[3].RemoveRemainingGougesForContoursFlg = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwGaugeRemainCollsion) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwGaugeRemainCollsion) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwTriM2dContainment() => \u0005.\u0002.\u0001(this);

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
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.ContainmentTrimmingCriteria = SharedMiscParamsContainmentTrimmingCriteria.CtcToolTipPoint;
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.Offset2dContainmentMethod == SharedMiscParamsOffset2dContainmentMethod.ShbOffsetNone)
      this.\u0002.Checked = true;
    else if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.Offset2dContainmentMethod == SharedMiscParamsOffset2dContainmentMethod.ShbOffsetInside)
      this.\u0003.Checked = true;
    else if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.Offset2dContainmentMethod == SharedMiscParamsOffset2dContainmentMethod.ShbOffsetOutside)
      this.\u0001.Checked = true;
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern == TriangleMeshBasedTpCalcParamsPattern.TcTmbRough)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.ContainmentTrimmingCriteria = SharedMiscParamsContainmentTrimmingCriteria.CtcToolTipPoint;
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.ContainmentTrimmingCriteria == SharedMiscParamsContainmentTrimmingCriteria.CtcToolTipPoint)
      ((F_MwTriMAngleRange) this).\u0004.Checked = true;
    else
      ((F_MwTriMAngleRange) this).\u0005.Checked = true;
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern == TriangleMeshBasedTpCalcParamsPattern.TcTmbRough)
      ;
    this.\u0001.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.Offset2dContainmentValue;
    this.UpdateControlFromType();
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
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
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern == TriangleMeshBasedTpCalcParamsPattern.TcTmbRough | this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern == TriangleMeshBasedTpCalcParamsPattern.TcTmbPencil)
      ((F_MwTriMAngleRange) this).\u0005.Enabled = false;
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern == TriangleMeshBasedTpCalcParamsPattern.TcTmbConstantZ | this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern == TriangleMeshBasedTpCalcParamsPattern.TcTmbParallelCuts)
      ((F_MwTriMAngleRange) this).\u0005.Enabled = true;
    this.\u0001.Enabled = !((F_MwTriMAngleRange) this).\u0005.Checked;
    if (this.\u0003.Checked | this.\u0001.Checked)
    {
      this.\u0001.Enabled = this.\u0001.Enabled;
      this.\u0001.Enabled = this.\u0001.Enabled;
    }
    if (this.\u0002.Checked)
    {
      this.\u0001.Enabled = false;
      this.\u0001.Enabled = false;
    }
    if (buMWCalcs.AdvancedTriMesh)
      return;
    this.\u0002.Enabled = false;
  }

  public void Apply()
  {
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.Offset2dContainmentValue = (double) this.\u0001.Value;
    if (this.\u0002.Checked)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.Offset2dContainmentMethod = SharedMiscParamsOffset2dContainmentMethod.ShbOffsetNone;
    else if (this.\u0003.Checked)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.Offset2dContainmentMethod = SharedMiscParamsOffset2dContainmentMethod.ShbOffsetInside;
    else if (this.\u0001.Checked)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.Offset2dContainmentMethod = SharedMiscParamsOffset2dContainmentMethod.ShbOffsetOutside;
    if (((F_MwTriMAngleRange) this).\u0004.Checked)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.Offset2dContainmentMethod = SharedMiscParamsOffset2dContainmentMethod.ShbOffsetNone;
    else if (((F_MwTriMAngleRange) this).\u0005.Checked)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.Offset2dContainmentMethod = SharedMiscParamsOffset2dContainmentMethod.ShbOffsetInside;
    if (((F_MwTriMAngleRange) this).\u0004.Checked)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.ContainmentTrimmingCriteria = SharedMiscParamsContainmentTrimmingCriteria.CtcToolTipPoint;
    else
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.ContainmentTrimmingCriteria = SharedMiscParamsContainmentTrimmingCriteria.CtcToolContactPoint;
  }
}
