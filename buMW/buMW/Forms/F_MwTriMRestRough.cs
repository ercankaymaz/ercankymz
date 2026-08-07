// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwTriMRestRough
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

public class F_MwTriMRestRough : Form
{
  internal PictureBox \u0001;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  internal IContainer \u0001 = (IContainer) null;
  internal System.Windows.Forms.Label \u0001;
  internal PictureBox \u0001;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal System.Windows.Forms.Label \u0002;
  internal NumericUpDown \u0001;
  internal Panel \u0001;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal System.Windows.Forms.Label \u0003;
  internal NumericUpDown \u0002;
  internal System.Windows.Forms.Label \u0004;
  internal NumericUpDown \u0003;
  internal System.Windows.Forms.Label \u0005;
  internal NumericUpDown \u0004;

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwTriMParalelCutLink) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwTriMParalelCutLink) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwTriMRestRough() => \u0005.\u0002.\u0001(this);

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
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RoughingOffsetType = MachiningAreaRoughingParamsRoughingOffsetType.RotGlobal;
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RoughingOffsetType == MachiningAreaRoughingParamsRoughingOffsetType.RotGlobal)
      this.\u0002.Checked = true;
    else if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentCreationType == TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctBottom)
      this.\u0001.Checked = true;
    ((F_MwTriMParallelCut) this).\u0006.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DetectThickerThan;
    this.\u0004.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RoughingOffset;
    ((F_MwTriMParallelCut) this).\u0005.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RoughingAxialOffset;
    this.\u0003.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RoughingRadialOffset;
    this.\u0002.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RoughingToolCornerRad;
    this.\u0001.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RoughingToolDiameter;
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
    ((F_MwTriMParallelCut) this).Apply();
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
    if (this.\u0002.Checked)
    {
      this.\u0003.Enabled = false;
      ((F_MwTriMParallelCut) this).\u0005.Enabled = false;
      this.\u0004.Enabled = true;
      this.\u0004.Enabled = false;
      ((F_MwTriMParallelCut) this).\u0006.Enabled = false;
      this.\u0005.Enabled = true;
    }
    if (this.\u0001.Checked)
    {
      this.\u0003.Enabled = true;
      ((F_MwTriMParallelCut) this).\u0005.Enabled = true;
      this.\u0004.Enabled = false;
      this.\u0004.Enabled = true;
      ((F_MwTriMParallelCut) this).\u0006.Enabled = true;
      this.\u0005.Enabled = false;
    }
    if (buMWCalcs.AdvancedTriMesh)
      return;
    this.\u0001.Enabled = false;
    this.\u0004.Enabled = false;
    this.\u0003.Enabled = false;
    ((F_MwTriMParallelCut) this).\u0006.Enabled = false;
    ((F_MwTriMParallelCut) this).\u0005.Enabled = false;
    ((F_MwTriMParallelCut) this).\u0007.Enabled = false;
    ((F_MwTriMParallelCut) this).\u0006.Enabled = false;
  }
}
