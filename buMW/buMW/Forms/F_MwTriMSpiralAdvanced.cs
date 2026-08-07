// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwTriMSpiralAdvanced
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

public class F_MwTriMSpiralAdvanced : Form
{
  internal ImageList \u0001;
  public Button btn_ok;
  internal RadioButton \u0004;
  internal RadioButton \u0005;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  public bool Advanced = false;
  internal IContainer \u0001 = (IContainer) null;
  internal ImageList \u0001;
  internal ImageList \u0002;
  internal System.Windows.Forms.Label \u0001;
  internal PictureBox \u0001;
  public Button btn_cancel;
  public Button btn_ok;

  public void Apply()
  {
    ((F_MwTriMSilhouette) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteStockRemain = (double) ((F_MwTriMSilhouette) this).\u0001.Value;
    if (this.\u0004.Checked)
      ((F_MwTriMSilhouette) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentCreationType = TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctBottom;
    else if (((F_MwTriMSilhouette) this).\u0003.Checked)
      ((F_MwTriMSilhouette) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentCreationType = TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctPartSilhouette;
    else if (((F_MwTriMSilhouette) this).\u0002.Checked)
      ((F_MwTriMSilhouette) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentCreationType = TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctPartEnd;
    else if (((F_MwTriMSilhouette) this).\u0001.Checked)
    {
      ((F_MwTriMSilhouette) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentCreationType = TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctToolContact;
    }
    else
    {
      if (!this.\u0005.Checked)
        return;
      ((F_MwTriMSilhouette) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentCreationType = TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctTop;
    }
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MwTriMSilhouette) this).UpdateControlFromType();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwTriMSilhouette) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwTriMSilhouette) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwTriMSpiralAdvanced() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    ((F_MwTriMSurfaceQuality) this).\u0001.Checked = this.Par.CloseLastSpiralMachContour;
    ((F_MwTriMSurfaceQuality) this).\u0002.Checked = this.Par.CloseFirstSpiralMachContour;
    ((F_MwTriMSurfaceQuality) this).UpdateControlFromType();
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
    ((F_MwTriMSurfaceQuality) this).Apply();
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
}
