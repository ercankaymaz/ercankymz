// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_RestRough
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
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

public class F_RestRough : Form
{
  internal System.Windows.Forms.Label \u0005;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal NumericUpDown \u0005;
  internal System.Windows.Forms.Label \u0006;
  internal System.Windows.Forms.Label \u0007;
  public ComboBox cmb_profilepassofsettype;
  public FormProperties PropertiesForm = new FormProperties();
  public GeoLib mwCamParameter = (GeoLib) null;
  public camParameters5 buCamParameter = (camParameters5) null;
  public MWCalculationOptions Configration = new MWCalculationOptions();
  public ToolBase5 Tool = (ToolBase5) null;
  public static List<string> Captions;
  internal IContainer \u0001 = (IContainer) null;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal System.Windows.Forms.Label \u0001;
  internal PictureBox \u0001;
  internal ImageList \u0002;
  internal Panel \u0001;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal Panel \u0002;
  internal System.Windows.Forms.Label \u0002;
  internal Panel \u0003;
  internal System.Windows.Forms.Label \u0003;
  internal CheckBox \u0001;
  internal NumericUpDown \u0001;
  internal NumericUpDown \u0002;
  internal System.Windows.Forms.Label \u0004;
  internal NumericUpDown \u0003;
  internal System.Windows.Forms.Label \u0005;
  internal System.Windows.Forms.Label \u0006;

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!((F_ProfilePass) this).PropertiesForm.Inited)
      return;
    if (control2.Name == this.cmb_profilepassofsettype.Name)
    {
      if (this.cmb_profilepassofsettype.SelectedIndex == 0)
        ((F_ProfilePass) this).\u0001.Image = (Image) ResourceImage.ProfilePassCompensationTypeComputerTriMeshRough;
      else if (this.cmb_profilepassofsettype.SelectedIndex == 1)
        ((F_ProfilePass) this).\u0001.Image = (Image) ResourceImage.ProfilePassCompensationTypeControlRough;
      else if (this.cmb_profilepassofsettype.SelectedIndex == 2)
        ((F_ProfilePass) this).\u0001.Image = (Image) ResourceImage.ProfilePassCompensationTypeWearRough;
      else if (this.cmb_profilepassofsettype.SelectedIndex == 3)
        ((F_ProfilePass) this).\u0001.Image = (Image) ResourceImage.ProfilePassCompensationTypeInverseWearRough;
      else if (this.cmb_profilepassofsettype.SelectedIndex == 4)
        ((F_ProfilePass) this).\u0001.Image = (Image) ResourceImage.ProfilePassCompensationTypeOffRough;
    }
    ((F_ProfilePass) this).PropertiesForm.Inited = false;
    ((F_ProfilePass) this).Apply();
    ((F_ProfilePass) this).ControlUpdate();
    ((F_ProfilePass) this).PropertiesForm.Inited = true;
  }

  internal void \u0006([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == this.\u0002.Name)
      ((F_ProfilePass) this).\u0001.Image = (Image) ResourceImage.ProfilePassAllSlicesTriMesh;
    else if (control2.Name == this.\u0001.Name)
      ((F_ProfilePass) this).\u0001.Image = (Image) ResourceImage.ProfilePassLastSlicesTriMeshRough;
    else if (control2.Name == this.\u0005.Name)
      ((F_ProfilePass) this).\u0001.Image = (Image) ResourceImage.ProfilePassSpacingTriMeshRough;
    else if (control2.Name == ((F_ProfilePass) this).\u0001.Name)
      ((F_ProfilePass) this).\u0001.Image = (Image) ResourceImage.ProfilePassCompensationTypeRadiusRough;
    else if (control2.Name == this.\u0005.Name)
      ((F_ProfilePass) this).\u0001.Image = (Image) ResourceImage.ProfilePassSpacingTriMeshRough;
    else if (control2.Name == ((F_ProfilePass) this).\u0004.Name)
      ((F_ProfilePass) this).\u0001.Image = (Image) ResourceImage.ProfilePassArcSweep;
    else if (control2.Name == ((F_ProfilePass) this).\u0003.Name)
      ((F_ProfilePass) this).\u0001.Image = (Image) ResourceImage.ProfilePassArcDiameter;
    else if (control2.Name == ((F_ProfilePass) this).\u0002.Name)
      ((F_ProfilePass) this).\u0001.Image = (Image) ResourceImage.ProfilePassTangentLineLength;
    ((F_ProfilePass) this).\u0001.Checked = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ProfilePass) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ProfilePass) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_RestRough() => F_ProfilePass.Captions = new List<string>();

  public F_RestRough() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    if (this.Configration.Mode == CamMode.TriangularMesh)
    {
      this.\u0003.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RoughingToolDiameter;
      this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DetectThickerThan;
      this.\u0002.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RoughingToolCornerRad;
      ((F_Silhouette) this).\u0006.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RoughingOffset;
      ((F_Silhouette) this).\u0004.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RoughingRadialOffset;
      ((F_Silhouette) this).\u0005.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RoughingAxialOffset;
      if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RoughingOffsetType == MachiningAreaRoughingParamsRoughingOffsetType.RotGlobal)
        this.\u0002.Checked = true;
      else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RoughingOffsetType == MachiningAreaRoughingParamsRoughingOffsetType.RotRadialAndAxial)
        this.\u0001.Checked = true;
    }
    else if (this.Configration.Mode == CamMode.WireFrame)
    {
      this.\u0001.Enabled = false;
      if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.RoughingOffsetType != 0)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.RoughingOffsetType = MachiningAreaRoughingParamsRoughingOffsetType.RotGlobal;
      this.\u0002.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.RoughingToolDiameter;
      this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.DetectThickerThan;
      this.\u0003.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.RoughingToolCornerRad;
      ((F_Silhouette) this).\u0006.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.RoughingOffset;
      ((F_Silhouette) this).\u0004.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.RoughingRadialOffset;
      ((F_Silhouette) this).\u0005.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.RoughingAxialOffset;
      if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.RoughingOffsetType == MachiningAreaRoughingParamsRoughingOffsetType.RotGlobal)
        this.\u0002.Checked = true;
      else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.RoughingOffsetType == MachiningAreaRoughingParamsRoughingOffsetType.RotRadialAndAxial)
        this.\u0001.Checked = true;
    }
    this.ControlUpdate();
    \u0005.\u0002.\u0001(this);
    this.\u0001.Image = (Image) null;
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
    ((F_Silhouette) this).\u0005.Enabled = false;
    ((F_Silhouette) this).\u000E.Enabled = false;
    ((F_Silhouette) this).\u0004.Enabled = false;
    ((F_Silhouette) this).\u0008.Enabled = false;
    ((F_Silhouette) this).\u0006.Enabled = false;
    ((F_Silhouette) this).\u000F.Enabled = false;
    if (this.\u0002.Checked)
    {
      ((F_Silhouette) this).\u0006.Enabled = true;
      ((F_Silhouette) this).\u000F.Enabled = true;
    }
    else
    {
      ((F_Silhouette) this).\u0005.Enabled = true;
      ((F_Silhouette) this).\u000E.Enabled = true;
      ((F_Silhouette) this).\u0004.Enabled = true;
      ((F_Silhouette) this).\u0008.Enabled = true;
    }
  }

  public void Apply()
  {
    if (this.Configration.Mode == CamMode.TriangularMesh)
    {
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RoughingToolDiameter = (double) this.\u0003.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DetectThickerThan = (double) this.\u0001.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RoughingToolCornerRad = (double) this.\u0002.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RoughingOffset = (double) ((F_Silhouette) this).\u0006.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RoughingRadialOffset = (double) ((F_Silhouette) this).\u0004.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RoughingAxialOffset = (double) ((F_Silhouette) this).\u0005.Value;
      if (this.\u0002.Checked)
      {
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RoughingOffsetType = MachiningAreaRoughingParamsRoughingOffsetType.RotGlobal;
      }
      else
      {
        if (!this.\u0001.Checked)
          return;
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.RoughingOffsetType = MachiningAreaRoughingParamsRoughingOffsetType.RotRadialAndAxial;
      }
    }
    else
    {
      if (this.Configration.Mode != CamMode.WireFrame)
        return;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.RoughingToolDiameter = (double) this.\u0002.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.DetectThickerThan = (double) this.\u0001.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.RoughingToolCornerRad = (double) this.\u0003.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.RoughingOffset = (double) ((F_Silhouette) this).\u0006.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.RoughingRadialOffset = (double) ((F_Silhouette) this).\u0004.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.RoughingAxialOffset = (double) ((F_Silhouette) this).\u0005.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.RoughingOffsetType = MachiningAreaRoughingParamsRoughingOffsetType.RotGlobal;
    }
  }
}
