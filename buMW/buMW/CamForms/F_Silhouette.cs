// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_Silhouette
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buControls;
using buControls.Forms.WinControlForms.Views;
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

public class F_Silhouette : Form
{
  internal NumericUpDown \u0004;
  internal System.Windows.Forms.Label \u0007;
  internal NumericUpDown \u0005;
  internal System.Windows.Forms.Label \u0008;
  internal NumericUpDown \u0006;
  internal System.Windows.Forms.Label \u000E;
  internal System.Windows.Forms.Label \u000F;
  public FormProperties PropertiesForm = new FormProperties();
  public GeoLib mwCamParameter = (GeoLib) null;
  public camParameters5 buCamParameter = (camParameters5) null;
  public MWCalculationOptions Configration = new MWCalculationOptions();
  public ToolBase5 Tool = (ToolBase5) null;
  public static List<string> Captions;
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

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_RestRough) this).PropertiesForm.Inited)
      return;
    ((F_RestRough) this).PropertiesForm.Inited = false;
    ((F_RestRough) this).Apply();
    ((F_RestRough) this).ControlUpdate();
    ((F_RestRough) this).PropertiesForm.Inited = true;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_RestRough) this).\u0002.Name)
      ((F_RestRough) this).\u0001.Image = (Image) ResourceImage.ToolCornerRadRestRoughTriMesh;
    else if (control2.Name == ((F_RestRough) this).\u0001.Name)
    {
      ((F_RestRough) this).\u0001.Image = (Image) ResourceImage.RestFinishDetectThickerThan;
      if (((F_RestRough) this).\u0001.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_RestRough) this).\u0003.Name)
      ((F_RestRough) this).\u0001.Image = (Image) ResourceImage.ToolDiaRestRoughTriMesh;
    else if (control2.Name == ((F_RestRough) this).\u0002.Name)
      ((F_RestRough) this).\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == ((F_RestRough) this).\u0001.Name)
      ((F_RestRough) this).\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == this.\u0006.Name)
      ((F_RestRough) this).\u0001.Image = (Image) ResourceImage.OffsetRestRoughTriMesh;
    else if (control2.Name == this.\u0005.Name)
      ((F_RestRough) this).\u0001.Image = (Image) ResourceImage.AxialOffsetRestRoughTriangleMesh;
    else if (control2.Name == this.\u0004.Name)
      ((F_RestRough) this).\u0001.Image = (Image) ResourceImage.RadialOffsetRestRoughTriMesh;
    ((F_RestRough) this).\u0001.Checked = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_RestRough) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_RestRough) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_Silhouette() => F_RestRough.Captions = new List<string>();

  public F_Silhouette() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    if (!this.Configration.isRough)
    {
      if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentCreationType == TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctTop | this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentCreationType == TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctBottom)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentCreationType = TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctPartEnd;
      ((F_RoundCorner) this).\u0004.Enabled = false;
      ((F_RoundCorner) this).\u0005.Enabled = false;
    }
    if (!this.Configration.isTriangularMeshAdvanced)
    {
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentCreationType = TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctPartEnd;
      this.\u0003.Enabled = false;
      this.\u0001.Enabled = false;
      ((F_RoundCorner) this).\u0004.Enabled = false;
      ((F_RoundCorner) this).\u0005.Enabled = false;
    }
    if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentCreationType == TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctTop)
      ((F_RoundCorner) this).\u0005.Checked = true;
    else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentCreationType == TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctBottom)
      ((F_RoundCorner) this).\u0004.Checked = true;
    else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentCreationType == TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctPartEnd)
      this.\u0002.Checked = true;
    else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentCreationType == TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctToolContact)
      this.\u0001.Checked = true;
    else
      this.\u0003.Checked = true;
    this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteStockRemain;
    this.ControlUpdate();
    \u0005.\u0002.\u0001(this);
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_RoundCorner) this).btn_ok.Name)
    {
      this.Apply();
      this.PropertiesForm.Result = DialogResult.OK;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_RoundCorner) this).btn_cancel.Name))
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
    if (!buMWCalcs.AdvancedTriMesh)
    {
      ((F_RoundCorner) this).\u0004.Enabled = false;
      this.\u0003.Enabled = false;
      this.\u0001.Enabled = false;
      ((F_RoundCorner) this).\u0005.Enabled = false;
    }
    else
    {
      ((F_RoundCorner) this).\u0004.Enabled = true;
      this.\u0003.Enabled = true;
      this.\u0001.Enabled = true;
      ((F_RoundCorner) this).\u0005.Enabled = true;
    }
    if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern == TriangleMeshBasedTpCalcParamsPattern.TcTmbRough)
    {
      ((F_RoundCorner) this).\u0004.Enabled = false;
      ((F_RoundCorner) this).\u0005.Enabled = false;
    }
    if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern == TriangleMeshBasedTpCalcParamsPattern.TcTmbConstantZ)
    {
      ((F_RoundCorner) this).\u0004.Enabled = true;
      ((F_RoundCorner) this).\u0005.Enabled = true;
    }
    if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern == TriangleMeshBasedTpCalcParamsPattern.TcTmbPencil)
    {
      ((F_RoundCorner) this).\u0004.Enabled = false;
      ((F_RoundCorner) this).\u0005.Enabled = false;
    }
    ((F_RoundCorner) this).\u0004.Enabled = this.SilhouetteBottomEnable;
    ((F_RoundCorner) this).\u0005.Enabled = this.SilhouetteTopEnable;
    if (buMWCalcs.AdvancedTriMesh)
      return;
    ((F_RoundCorner) this).\u0004.Enabled = false;
    this.\u0003.Enabled = false;
    this.\u0001.Enabled = false;
    ((F_RoundCorner) this).\u0005.Enabled = false;
  }

  public void Apply()
  {
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteStockRemain = (double) this.\u0001.Value;
    if (((F_RoundCorner) this).\u0004.Checked)
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentCreationType = TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctBottom;
    else if (this.\u0003.Checked)
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentCreationType = TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctPartSilhouette;
    else if (this.\u0002.Checked)
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentCreationType = TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctPartEnd;
    else if (this.\u0001.Checked)
    {
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentCreationType = TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctToolContact;
    }
    else
    {
      if (!((F_RoundCorner) this).\u0005.Checked)
        return;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentCreationType = TriangleMeshBasedTpCalcParamsSilhouetteContainmentCreationType.ScctTop;
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1) => this.ControlUpdate();

  internal void \u0001([In] object obj0, [In] KeyEventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!(obj1.KeyCode == Keys.Return | obj1.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKeyDown(this.Controls, result, obj1.Shift);
  }
}
