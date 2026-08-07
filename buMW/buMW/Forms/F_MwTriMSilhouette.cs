// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwTriMSilhouette
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

public class F_MwTriMSilhouette : Form
{
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal ImageList \u0002;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  public bool Advanced = false;
  public bool SilhouetteTopEnable = false;
  public bool SilhouetteBottomEnable = false;
  internal IContainer \u0001 = (IContainer) null;
  internal Panel \u0001;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  internal System.Windows.Forms.Label \u0001;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal PictureBox \u0001;
  public Button btn_cancel;

  public void Apply()
  {
    ((F_MwTriMRoundCorner) this).Par.SplineMaxDeviation = (double) ((F_MwTriMRoundCorner) this).\u0001.Value;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!(control2.Tag != null & ((F_MwTriMRoundCorner) this).Properties.Inited))
      return;
    ((F_MwTriMRoundCorner) this).\u0001.Image = this.\u0002.Images[Convert.ToInt32(control2.Tag)];
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwTriMRoundCorner) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwTriMRoundCorner) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwTriMSilhouette() => \u0005.\u0002.\u0001(this);

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
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentCreationType = TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctPartEnd;
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentCreationType == TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctTop)
      ((F_MwTriMSpiralAdvanced) this).\u0005.Checked = true;
    else if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentCreationType == TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctBottom)
      ((F_MwTriMSpiralAdvanced) this).\u0004.Checked = true;
    else if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentCreationType == TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctPartEnd)
      this.\u0002.Checked = true;
    else if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentCreationType == TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctToolContact)
      this.\u0001.Checked = true;
    else
      this.\u0003.Checked = true;
    this.\u0001.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteStockRemain;
    this.UpdateControlFromType();
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MwTriMSpiralAdvanced) this).Apply();
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
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern == TriangleMeshBasedTpCalcParamsPattern.TcTmbRough)
    {
      ((F_MwTriMSpiralAdvanced) this).\u0004.Enabled = false;
      ((F_MwTriMSpiralAdvanced) this).\u0005.Enabled = false;
    }
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern == TriangleMeshBasedTpCalcParamsPattern.TcTmbConstantZ)
    {
      ((F_MwTriMSpiralAdvanced) this).\u0004.Enabled = true;
      ((F_MwTriMSpiralAdvanced) this).\u0005.Enabled = true;
    }
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern == TriangleMeshBasedTpCalcParamsPattern.TcTmbPencil)
    {
      ((F_MwTriMSpiralAdvanced) this).\u0004.Enabled = false;
      ((F_MwTriMSpiralAdvanced) this).\u0005.Enabled = false;
    }
    ((F_MwTriMSpiralAdvanced) this).\u0004.Enabled = this.SilhouetteBottomEnable;
    ((F_MwTriMSpiralAdvanced) this).\u0005.Enabled = this.SilhouetteTopEnable;
    if (buMWCalcs.AdvancedTriMesh)
      return;
    ((F_MwTriMSpiralAdvanced) this).\u0004.Enabled = false;
    this.\u0003.Enabled = false;
    this.\u0001.Enabled = false;
    ((F_MwTriMSpiralAdvanced) this).\u0005.Enabled = false;
  }
}
