// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_2DContainment
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buControls;
using buEyeBaseVer5;
using buImages;
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

public class F_2DContainment : Form
{
  internal ImageList \u0001;
  internal System.Windows.Forms.Label \u0005;
  internal PictureBox \u0001;
  public Button btn_ok;
  internal ImageList \u0002;
  public Button btn_cancel;
  internal CheckBox \u0001;
  public FormProperties PropertiesForm = new FormProperties();
  public GeoLib mwCamParameter = (GeoLib) null;
  public camParameters5 buCamParameter = (camParameters5) null;
  public MWCalculationOptions Configration = new MWCalculationOptions();
  public ToolBase5 Tool = (ToolBase5) null;
  public static List<string> Captions;
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

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    if (!(((F_AngleRange) this).PropertiesForm.TouchPad & !this.\u0001.Checked))
      return;
    NumericUpDown numericUpDown = new NumericUpDown();
    NumericUpDown Ctrl = (NumericUpDown) obj0;
    if (!Ctrl.Enabled)
      return;
    buControlCommands.ShowKeyPadWinControl((Form) this, (Control) Ctrl);
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_AngleRange) this).\u0002.Name)
      this.\u0001.Image = (Image) ResourceImage.AngleRangeSlopeAngleStart;
    else if (control2.Name == ((F_AngleRange) this).\u0001.Name)
      this.\u0001.Image = (Image) ResourceImage.AngleRangeSlopeAngleEnd;
    else if (control2.Name == ((F_AngleRange) this).\u0002.Name)
      this.\u0001.Image = (Image) ResourceImage.AngleRangeMachiningAreaMahineBetweenSlopeAngles;
    else if (control2.Name == ((F_AngleRange) this).\u0001.Name)
      this.\u0001.Image = (Image) ResourceImage.AngleRangeMachiningAreaMachineOutsideSlopeAngle;
    this.\u0001.Checked = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_AngleRange) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_AngleRange) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_2DContainment() => F_AngleRange.Captions = new List<string>();

  public F_2DContainment() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    if (!this.Configration.isTriangularMeshAdvanced)
    {
      if (this.Configration.isRough)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.ContainmentTrimmingCriteria = SharedMiscParamsContainmentTrimmingCriteria.CtcToolTipPoint;
      ((F_RestFinish) this).\u0005.Enabled = false;
    }
    if (this.Configration.Mode == CamMode.TriangularMesh)
    {
      if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.Offset2dContainmentMethod == SharedMiscParamsOffset2dContainmentMethod.ShbOffsetNone)
        ((F_RestFinish) this).\u0002.Checked = true;
      else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.Offset2dContainmentMethod == SharedMiscParamsOffset2dContainmentMethod.ShbOffsetInside)
        ((F_RestFinish) this).\u0003.Checked = true;
      else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.Offset2dContainmentMethod == SharedMiscParamsOffset2dContainmentMethod.ShbOffsetOutside)
        this.\u0001.Checked = true;
      if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.ContainmentTrimmingCriteria == SharedMiscParamsContainmentTrimmingCriteria.CtcToolTipPoint)
        ((F_RestFinish) this).\u0004.Checked = true;
      else
        ((F_RestFinish) this).\u0005.Checked = true;
      this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.Offset2dContainmentValue;
    }
    else if (this.Configration.Mode == CamMode.WireFrame)
    {
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.ContainmentTrimmingCriteria = SharedMiscParamsContainmentTrimmingCriteria.CtcToolTipPoint;
      ((F_RestFinish) this).\u0005.Enabled = false;
      if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.Offset2dContainmentMethod == SharedMiscParamsOffset2dContainmentMethod.ShbOffsetNone)
        ((F_RestFinish) this).\u0002.Checked = true;
      else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.Offset2dContainmentMethod == SharedMiscParamsOffset2dContainmentMethod.ShbOffsetInside)
        ((F_RestFinish) this).\u0003.Checked = true;
      else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.Offset2dContainmentMethod == SharedMiscParamsOffset2dContainmentMethod.ShbOffsetOutside)
        this.\u0001.Checked = true;
      ((F_RestFinish) this).\u0004.Checked = true;
      this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.Offset2dContainmentValue;
    }
    this.ControlUpdate();
    \u0005.\u0002.\u0001(this);
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
    if (!(control2.Name == this.btn_cancel.Name))
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
    if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern == TriangleMeshBasedTpCalcParamsPattern.TcTmbRough | this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern == TriangleMeshBasedTpCalcParamsPattern.TcTmbPencil)
      ((F_RestFinish) this).\u0005.Enabled = false;
    if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern == TriangleMeshBasedTpCalcParamsPattern.TcTmbConstantZ | this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern == TriangleMeshBasedTpCalcParamsPattern.TcTmbParallelCuts)
      ((F_RestFinish) this).\u0005.Enabled = true;
    this.\u0001.Enabled = !((F_RestFinish) this).\u0005.Checked;
    if (((F_RestFinish) this).\u0003.Checked | this.\u0001.Checked)
    {
      this.\u0001.Enabled = this.\u0001.Enabled;
      this.\u0001.Enabled = this.\u0001.Enabled;
    }
    if (((F_RestFinish) this).\u0002.Checked)
    {
      this.\u0001.Enabled = false;
      this.\u0001.Enabled = false;
    }
    this.\u0001.Enabled = false;
    this.\u0001.Enabled = false;
    if (((F_RestFinish) this).\u0003.Checked | this.\u0001.Checked)
    {
      this.\u0001.Enabled = true;
      this.\u0001.Enabled = true;
    }
    if (buMWCalcs.AdvancedTriMesh)
      return;
    ((F_RestFinish) this).\u0002.Enabled = false;
  }

  public void Apply()
  {
    if (this.Configration.Mode == CamMode.TriangularMesh)
    {
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.Offset2dContainmentValue = (double) this.\u0001.Value;
      if (((F_RestFinish) this).\u0002.Checked)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.Offset2dContainmentMethod = SharedMiscParamsOffset2dContainmentMethod.ShbOffsetNone;
      else if (((F_RestFinish) this).\u0003.Checked)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.Offset2dContainmentMethod = SharedMiscParamsOffset2dContainmentMethod.ShbOffsetInside;
      else if (this.\u0001.Checked)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.Offset2dContainmentMethod = SharedMiscParamsOffset2dContainmentMethod.ShbOffsetOutside;
      if (((F_RestFinish) this).\u0004.Checked)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.ContainmentTrimmingCriteria = SharedMiscParamsContainmentTrimmingCriteria.CtcToolTipPoint;
      else
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.ContainmentTrimmingCriteria = SharedMiscParamsContainmentTrimmingCriteria.CtcToolContactPoint;
    }
    else
    {
      if (this.Configration.Mode != CamMode.WireFrame)
        return;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.Offset2dContainmentValue = (double) this.\u0001.Value;
      if (((F_RestFinish) this).\u0002.Checked)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.Offset2dContainmentMethod = SharedMiscParamsOffset2dContainmentMethod.ShbOffsetNone;
      else if (((F_RestFinish) this).\u0003.Checked)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.Offset2dContainmentMethod = SharedMiscParamsOffset2dContainmentMethod.ShbOffsetInside;
      else if (this.\u0001.Checked)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.Offset2dContainmentMethod = SharedMiscParamsOffset2dContainmentMethod.ShbOffsetOutside;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.ContainmentTrimmingCriteria = SharedMiscParamsContainmentTrimmingCriteria.CtcToolTipPoint;
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_RestFinish) this).\u0004.Name)
      this.\u0001.Image = (Image) ResourceImage.ToolTipPoint2dContainment;
    else if (control2.Name == ((F_RestFinish) this).\u0005.Name)
      this.\u0001.Image = (Image) ResourceImage.ToolContactPoint2dContainment;
    else if (control2.Name == ((F_RestFinish) this).\u0002.Name)
      this.\u0001.Image = (Image) ResourceImage._2DContainmentCenterRough;
    else if (control2.Name == ((F_RestFinish) this).\u0003.Name)
      this.\u0001.Image = (Image) ResourceImage._2DContainmentInsideRough;
    else if (control2.Name == this.\u0001.Name)
      this.\u0001.Image = (Image) ResourceImage._2DContainmentOutsideRough;
    this.ControlUpdate();
  }
}
