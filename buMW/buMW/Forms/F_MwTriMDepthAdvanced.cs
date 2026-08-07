// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwTriMDepthAdvanced
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buControls.DialogBox;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW.Forms;

public class F_MwTriMDepthAdvanced : Form
{
  public Button btn_ok;
  internal ImageList \u0002;
  public Button btn_cancel;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  internal IContainer \u0001 = (IContainer) null;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal CheckBox \u0001;
  internal NumericUpDown \u0001;
  internal Panel \u0001;
  internal CheckBox \u0002;
  internal System.Windows.Forms.Label \u0001;
  internal NumericUpDown \u0002;
  internal CheckBox \u0003;
  internal CheckBox \u0004;
  internal ListBox \u0001;
  internal NumericUpDown \u0003;
  internal NumericUpDown \u0004;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal System.Windows.Forms.Label \u0002;
  internal NumericUpDown \u0005;
  internal Panel \u0002;
  internal CheckBox \u0005;
  internal System.Windows.Forms.Label \u0003;
  internal NumericUpDown \u0006;
  internal NumericUpDown \u0007;
  internal CheckBox \u0006;
  internal System.Windows.Forms.Label \u0004;
  internal System.Windows.Forms.Label \u0005;
  internal PictureBox \u0001;
  internal Button \u0001;
  internal Button \u0002;
  internal Panel \u0003;
  internal Panel \u0004;
  internal CheckBox \u0007;
  internal System.Windows.Forms.Label \u0006;
  internal NumericUpDown \u0008;
  internal System.Windows.Forms.Label \u0007;
  internal NumericUpDown \u000E;
  internal CheckBox \u0008;

  public void Apply()
  {
    ((F_MwTriMAngleRange) this).Par.ShallowAndSteepAreaParams.SlopeAngleEnd = (double) ((F_MwTriMAngleRange) this).\u0001.Value;
    ((F_MwTriMAngleRange) this).Par.ShallowAndSteepAreaParams.SlopeAngleStart = (double) ((F_MwTriMAngleRange) this).\u0002.Value;
    if (((F_MwTriMAngleRange) this).\u0002.Checked)
      ((F_MwTriMAngleRange) this).Par.ShallowAndSteepAreaParams.MachiningAreaType = ShallowAndSteepAreaParamsMachiningAreaType.MatSteepAreas;
    else
      ((F_MwTriMAngleRange) this).Par.ShallowAndSteepAreaParams.MachiningAreaType = ShallowAndSteepAreaParamsMachiningAreaType.MatShallowAreas;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwTriMAngleRange) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwTriMAngleRange) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwTriMDepthAdvanced() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepModeOfIntermediateSlices == MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep)
      this.\u0002.Checked = true;
    else if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepModeOfIntermediateSlices == MachiningAreaRoughingParamsDepthStepMode.DsmNumberOfSlices)
      this.\u0001.Checked = true;
    this.\u0004.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepOfIntermediateSlices;
    this.\u0003.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.NumberOfIntermediateSlices;
    this.\u0005.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DetectThickerThanOfIntermediateSlices;
    this.\u0002.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.FinalDepthStep;
    this.\u0001.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.FirstDepthStep;
    this.\u0006.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MaxWidth;
    this.\u0007.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinWidth;
    this.\u0005.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseMaxWidthFlag;
    this.\u0003.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.FinalDepthStepFlg;
    this.\u0001.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.FirstDepthStepFlg;
    this.\u0002.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.IntermediateSlicesFlg;
    this.\u0004.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.ZValues4DepthStepFlg;
    ((F_MWTriMDynamicalHolderColl) this).\u000E.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachineVerticalWallsFlg;
    this.\u0008.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.AdaptiveDepthStepFlg;
    this.\u0007.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.TrimAdaptiveDepthStepPassesFlg;
    this.\u000E.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.MinDepthStep;
    this.\u0008.Value = (Decimal) this.Par.MaxStepoverDistance;
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern == TriangleMeshBasedTpCalcParamsPattern.TcTmbRough)
    {
      this.\u0006.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachineFlatlandsFlg;
      this.\u0004.Visible = false;
      this.\u0003.Visible = true;
    }
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern == TriangleMeshBasedTpCalcParamsPattern.TcTmbConstantZ)
    {
      ((F_MWTriMDynamicalHolderColl) this).\u000F.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachineFlatlandsFlg;
      this.\u0004.Visible = true;
      this.\u0003.Visible = false;
      this.\u0004.Location = new Point(5, 204);
    }
    this.\u0001.Items.Clear();
    for (int i = 0; i <= this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.ZValues4DepthStep.Count - 1; ++i)
      this.\u0001.Items.Add((object) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.ZValues4DepthStep[i]);
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
    this.\u0001.Enabled = this.\u0004.Checked;
    this.\u0007.Enabled = this.\u0005.Checked;
    this.\u0002.Enabled = this.\u0003.Checked;
    this.\u0001.Enabled = this.\u0001.Checked;
    this.\u0001.Enabled = this.\u0002.Checked;
    this.\u0002.Enabled = this.\u0006.Checked;
    if (this.\u0002.Checked)
    {
      this.\u0004.Enabled = true;
      this.\u0003.Enabled = false;
    }
    if (this.\u0001.Checked)
    {
      this.\u0004.Enabled = false;
      this.\u0003.Enabled = true;
    }
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern == TriangleMeshBasedTpCalcParamsPattern.TcTmbConstantZ)
    {
      this.\u0008.Enabled = !((F_MWTriMDynamicalHolderColl) this).\u000E.Checked;
      ((F_MWTriMDynamicalHolderColl) this).\u000F.Enabled = !this.\u0008.Checked;
      ((F_MWTriMDynamicalHolderColl) this).\u000E.Enabled = !this.\u0008.Checked;
      ((F_MWTriMDynamicalHolderColl) this).\u0005.Enabled = this.\u0008.Checked & this.\u0008.Enabled;
    }
    if (buMWCalcs.AdvancedTriMesh)
      return;
    this.\u0003.Enabled = false;
    ((F_MWTriMDynamicalHolderColl) this).\u000F.Enabled = false;
  }

  public void Apply()
  {
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepOfIntermediateSlices = (double) this.\u0004.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.NumberOfIntermediateSlices = (int) this.\u0003.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DetectThickerThanOfIntermediateSlices = (double) this.\u0005.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.FinalDepthStep = (double) this.\u0002.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.FirstDepthStep = (double) this.\u0001.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MaxWidth = (double) this.\u0006.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinWidth = (double) this.\u0007.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseMaxWidthFlag = this.\u0005.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.FinalDepthStepFlg = this.\u0003.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.FirstDepthStepFlg = this.\u0001.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.IntermediateSlicesFlg = this.\u0002.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.ZValues4DepthStepFlg = this.\u0004.Checked;
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern == TriangleMeshBasedTpCalcParamsPattern.TcTmbRough)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachineFlatlandsFlg = this.\u0006.Checked;
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern == TriangleMeshBasedTpCalcParamsPattern.TcTmbConstantZ)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachineFlatlandsFlg = ((F_MWTriMDynamicalHolderColl) this).\u000F.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachineVerticalWallsFlg = ((F_MWTriMDynamicalHolderColl) this).\u000E.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.AdaptiveDepthStepFlg = this.\u0008.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.TrimAdaptiveDepthStepPassesFlg = this.\u0007.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.MinDepthStep = (double) this.\u000E.Value;
    this.Par.MaxStepoverDistance = (double) this.\u0008.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.ZValues4DepthStep.Clear();
    for (int index = 0; index <= this.\u0001.Items.Count - 1; ++index)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.ZValues4DepthStep.Add(Convert.ToDouble(this.\u0001.Items[index]));
    if (this.\u0002.Checked)
    {
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepModeOfIntermediateSlices = MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep;
    }
    else
    {
      if (!this.\u0001.Checked)
        return;
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepModeOfIntermediateSlices = MachiningAreaRoughingParamsDepthStepMode.DsmNumberOfSlices;
    }
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    if (this.\u0002.Checked)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RoughType = TriangleMeshBasedTpCalcParamsRoughType.TmbRghtOffset;
    else if (this.\u0001.Checked)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RoughType = TriangleMeshBasedTpCalcParamsRoughType.TmbRghtParallel;
    this.UpdateControlFromType();
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!this.Properties.Inited)
      return;
    this.Properties.Inited = false;
    this.Apply();
    this.UpdateControlFromType();
    this.Properties.Inited = true;
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    DialogBoxInput dialogBoxInput = new DialogBoxInput();
    dialogBoxInput.ValueCaption = "Value";
    dialogBoxInput.StartPosition = FormStartPosition.CenterParent;
    dialogBoxInput.FormCaption = "Value";
    dialogBoxInput.Init();
    int num = (int) dialogBoxInput.ShowDialog();
    if (dialogBoxInput.Result != DialogResult.OK)
      return;
    this.\u0001.Items.Add((object) dialogBoxInput.Value);
  }
}
