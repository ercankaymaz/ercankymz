// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_SurfaceQuality
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buEyeBaseVer5;
using buImages;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW.CamForms;

public class F_SurfaceQuality : Form
{
  internal System.Windows.Forms.Label \u0018;
  internal PictureBox \u0001;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal CheckBox \u0003;
  internal Button \u0001;
  internal CheckBox \u0004;
  public FormProperties Properties = new FormProperties();
  public GeoLib mwCamParameter = (GeoLib) null;
  public camParameters5 buCamParameter = (camParameters5) null;
  public ToolBase5 Tool = (ToolBase5) null;
  public MWCalculationOptions Configration = new MWCalculationOptions();
  public static List<string> Captions;
  internal IContainer \u0001 = (IContainer) null;
  internal Panel \u0001;
  internal System.Windows.Forms.Label \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal NumericUpDown \u0001;
  internal NumericUpDown \u0002;
  internal CheckBox \u0001;
  internal NumericUpDown \u0003;
  internal CheckBox \u0002;
  internal System.Windows.Forms.Label \u0003;
  internal RadioButton \u0001;
  internal NumericUpDown \u0004;
  internal RadioButton \u0002;
  public Button btn_ok;
  internal ImageList \u0001;
  internal System.Windows.Forms.Label \u0004;

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!((F_LeadControl) this).Properties.Inited)
      return;
    ((F_LeadControl) this).ControlUpdate();
    if (control2.Name == ((F_LeadControl) this).cmb_leadtype.Name)
    {
      if (((F_LeadControl) this).cmb_leadtype.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.LeadInTangArc;
      else if (((F_LeadControl) this).cmb_leadtype.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.LeadInRevTangArc;
      else if (((F_LeadControl) this).cmb_leadtype.SelectedIndex == 2)
        this.\u0001.Image = (Image) ResourceImage.LeadInVerTangArc;
      else if (((F_LeadControl) this).cmb_leadtype.SelectedIndex == 3)
        this.\u0001.Image = (Image) ResourceImage.LeadInRevVerTangArc;
      else if (((F_LeadControl) this).cmb_leadtype.SelectedIndex == 4)
        this.\u0001.Image = (Image) ResourceImage.LeadInHorTangArc;
      else if (((F_LeadControl) this).cmb_leadtype.SelectedIndex == 5)
        this.\u0001.Image = (Image) ResourceImage.LeadInOrthArc;
      else if (((F_LeadControl) this).cmb_leadtype.SelectedIndex == 6)
        this.\u0001.Image = (Image) ResourceImage.LeadInTangLine;
      else if (((F_LeadControl) this).cmb_leadtype.SelectedIndex == 7)
        this.\u0001.Image = (Image) ResourceImage.LeadInRevTangLine;
      else if (((F_LeadControl) this).cmb_leadtype.SelectedIndex == 8)
        this.\u0001.Image = (Image) ResourceImage.LeadInOrthLine;
      else if (((F_LeadControl) this).cmb_leadtype.SelectedIndex == 9)
        this.\u0001.Image = (Image) ResourceImage.NoImage;
      else if (((F_LeadControl) this).cmb_leadtype.SelectedIndex == 10)
        this.\u0001.Image = (Image) ResourceImage.LeadInVerProfRamp;
      else if (((F_LeadControl) this).cmb_leadtype.SelectedIndex == 11)
        this.\u0001.Image = (Image) ResourceImage.LeadInRevVertProfRamp;
      else if (((F_LeadControl) this).cmb_leadtype.SelectedIndex == 12)
        this.\u0001.Image = (Image) ResourceImage.NoImage;
      else if (((F_LeadControl) this).cmb_leadtype.SelectedIndex == 13)
        this.\u0001.Image = (Image) ResourceImage.NoImage;
    }
    if (control2.Name == ((F_LeadControl) this).cmb_extensiontype.Name)
    {
      if (((F_LeadControl) this).cmb_extensiontype.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.NoImage;
      else if (((F_LeadControl) this).cmb_extensiontype.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.LeadInExtensionVerTangArc;
      else if (((F_LeadControl) this).cmb_extensiontype.SelectedIndex == 2)
        this.\u0001.Image = (Image) ResourceImage.LeadInExtensionHorTangArc;
      else if (((F_LeadControl) this).cmb_extensiontype.SelectedIndex == 3)
        this.\u0001.Image = (Image) ResourceImage.LeadInExtensionTangLine;
      else if (((F_LeadControl) this).cmb_extensiontype.SelectedIndex == 4)
        this.\u0001.Image = (Image) ResourceImage.LeadInExtensionOrthLine;
    }
    if (!(control2.Name == ((F_LeadControl) this).cmb_axisorientation.Name))
      return;
    if (((F_LeadControl) this).cmb_axisorientation.SelectedIndex == 0)
    {
      this.\u0001.Image = (Image) ResourceImage.LeadInToolAxisOriFixed;
    }
    else
    {
      if (((F_LeadControl) this).cmb_axisorientation.SelectedIndex != 1)
        return;
      this.\u0001.Image = (Image) ResourceImage.LeadInToolAxisOriTang;
    }
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    ((F_LeadControl) this).ControlUpdate();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_LeadControl) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_LeadControl) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_SurfaceQuality() => F_LeadControl.Captions = new List<string>();

  public F_SurfaceQuality() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.Properties.Inited = false;
    ArrayList arrayList = new ArrayList();
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    ((F_Height) this).\u0001.Items.Clear();
    ((F_Height) this).\u0001.Items.Add((object) buMWCurveEntities.TriangleMeshBasedTpCalcParamsToolpathOutputType[3]);
    ((F_Height) this).\u0001.Items.Add((object) buMWCurveEntities.TriangleMeshBasedTpCalcParamsToolpathOutputType[4]);
    ((F_Height) this).\u0001.Items.Add((object) buMWCurveEntities.TriangleMeshBasedTpCalcParamsToolpathOutputType[2]);
    if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ToolpathOutputType == TriangleMeshBasedTpCalcParamsToolpathOutputType.TotFitArcsAndPointDistribution)
      ((F_Height) this).\u0001.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ToolpathOutputType == TriangleMeshBasedTpCalcParamsToolpathOutputType.TotPolygonizeAndPointDistribution)
      ((F_Height) this).\u0001.SelectedIndex = 1;
    else
      ((F_Height) this).\u0001.SelectedIndex = 2;
    if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ArcFitPlaneType == TriangleMeshBasedTpCalcParamsArcFitPlaneType.AfPlaneAny)
      this.\u0002.Checked = true;
    else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ArcFitPlaneType == TriangleMeshBasedTpCalcParamsArcFitPlaneType.AfPlaneCoordinate)
      this.\u0001.Checked = true;
    ((F_Height) this).\u0004.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ArcFitFactorFlg;
    this.\u0004.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ArcFitFactor;
    this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.Distance;
    this.\u0001.Checked = this.mwCamParameter.MachParam.DistanceFlag;
    if (this.Configration.Mode == CamMode.TriangularMesh)
    {
      this.\u0002.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.DeviationFactor;
      this.\u0003.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.MinimumDistance;
      this.\u0002.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.UseMinimumDistanceFlg;
    }
    else if (this.Configration.Mode == CamMode.WireFrame)
    {
      this.\u0002.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.DeviationFactor;
      this.\u0003.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.MinimumDistance;
      this.\u0002.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.UseMinimumDistanceFlg;
    }
    this.Refresh();
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
    \u0005.\u0002.\u0001(this);
    this.ControlUpdate();
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
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == this.btn_ok.Name)
    {
      this.Apply();
      this.Properties.Result = DialogResult.OK;
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_Height) this).btn_cancel.Name))
      return;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void ControlUpdate()
  {
    ((F_Height) this).\u0004.Enabled = true;
    ((F_Height) this).\u0002.Enabled = true;
    this.\u0001.Enabled = true;
    if (((F_Height) this).\u0001.SelectedIndex == 1)
    {
      ((F_Height) this).\u0004.Enabled = false;
      ((F_Height) this).\u0002.Enabled = false;
    }
    else if (((F_Height) this).\u0001.SelectedIndex == 2)
    {
      ((F_Height) this).\u0004.Enabled = false;
      ((F_Height) this).\u0002.Enabled = false;
      this.\u0001.Enabled = false;
    }
    ((F_Height) this).\u0002.Enabled = ((F_Height) this).\u0004.Checked & ((F_Height) this).\u0004.Enabled;
    this.\u0001.Enabled = this.\u0001.Checked & this.\u0001.Enabled;
    this.\u0003.Enabled = this.\u0002.Checked & this.\u0001.Enabled;
    this.\u0002.Enabled = this.\u0002.Checked & this.\u0001.Enabled;
  }

  public void Apply()
  {
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ArcFitFactor = (double) this.\u0004.Value;
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ArcFitFactorFlg = ((F_Height) this).\u0004.Checked;
    this.mwCamParameter.MachParam.Distance = (double) this.\u0001.Value;
    this.mwCamParameter.MachParam.DistanceFlag = this.\u0001.Checked;
    if (this.Configration.Mode == CamMode.TriangularMesh)
    {
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.DeviationFactor = (double) this.\u0002.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.MinimumDistance = (double) this.\u0003.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.UseMinimumDistanceFlg = this.\u0002.Checked;
    }
    else
    {
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.DeviationFactor = (double) this.\u0002.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.MinimumDistance = (double) this.\u0003.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.UseMinimumDistanceFlg = this.\u0002.Checked;
    }
    if (this.\u0002.Checked)
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ArcFitPlaneType = TriangleMeshBasedTpCalcParamsArcFitPlaneType.AfPlaneAny;
    else if (this.\u0001.Checked)
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ArcFitPlaneType = TriangleMeshBasedTpCalcParamsArcFitPlaneType.AfPlaneCoordinate;
    if (((F_Height) this).\u0001.SelectedIndex == 0)
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ToolpathOutputType = TriangleMeshBasedTpCalcParamsToolpathOutputType.TotFitArcsAndPointDistribution;
    else if (((F_Height) this).\u0001.SelectedIndex == 1)
    {
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ToolpathOutputType = TriangleMeshBasedTpCalcParamsToolpathOutputType.TotPolygonizeAndPointDistribution;
    }
    else
    {
      if (((F_Height) this).\u0001.SelectedIndex != 2)
        return;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ToolpathOutputType = TriangleMeshBasedTpCalcParamsToolpathOutputType.TotHighSurfaceQuality;
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1) => this.ControlUpdate();
}
