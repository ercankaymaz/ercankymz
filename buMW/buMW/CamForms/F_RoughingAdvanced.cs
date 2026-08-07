// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_RoughingAdvanced
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

public class F_RoughingAdvanced : Form
{
  public Button btn_ok;
  internal Button \u000E;
  internal Button \u000F;
  internal Button \u0010;
  internal Button \u0011;
  internal Button \u0012;
  internal Button \u0013;
  internal CheckBox \u0003;
  public FormProperties PropertiesForm = new FormProperties();
  public GeoLib mwCamParameter = (GeoLib) null;
  public camParameters5 buCamParameter = (camParameters5) null;
  public ToolBase5 Tool = (ToolBase5) null;
  public MWCalculationOptions Configration = new MWCalculationOptions();
  public static List<string> Captions;
  internal IContainer \u0001 = (IContainer) null;
  internal System.Windows.Forms.Label \u0001;
  internal PictureBox \u0001;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal Panel \u0001;
  public ComboBox combo_type;
  internal System.Windows.Forms.Label \u0002;
  internal System.Windows.Forms.Label \u0003;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0004;
  public ComboBox combo_filterby;
  internal System.Windows.Forms.Label \u0005;
  internal Panel \u0002;
  internal System.Windows.Forms.Label \u0006;
  internal NumericUpDown \u0002;
  internal Panel \u0003;
  internal Panel \u0004;
  internal NumericUpDown \u0003;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal CheckBox \u0001;
  internal System.Windows.Forms.Label \u0007;
  internal NumericUpDown \u0004;
  internal CheckBox \u0002;
  internal System.Windows.Forms.Label \u0008;
  internal NumericUpDown \u0005;
  internal CheckBox \u0003;
  internal System.Windows.Forms.Label \u000E;
  internal NumericUpDown \u0006;
  internal CheckBox \u0004;
  internal System.Windows.Forms.Label \u000F;
  internal NumericUpDown \u0007;
  internal CheckBox \u0005;
  internal System.Windows.Forms.Label \u0010;
  internal CheckBox \u0006;
  internal Panel \u0005;
  internal System.Windows.Forms.Label \u0011;

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    ((F_ContourLink) this).ControlUpdate();
    if (!((F_ContourLink) this).Properties.Inited)
      return;
    if (control2.Name == ((F_ContourLink) this).cmb_firstEntry.Name)
    {
      if (((F_ContourLink) this).cmb_firstEntry.SelectedIndex == 0)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.FirstEntryFromRapidPlane;
      else if (((F_ContourLink) this).cmb_firstEntry.SelectedIndex == 1)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.FirstEntryFromRapidDistance;
      else if (((F_ContourLink) this).cmb_firstEntry.SelectedIndex == 2)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.FirstEntryFromFeedDistance;
      else if (((F_ContourLink) this).cmb_firstEntry.SelectedIndex == 3)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.FirstEntryDirect;
    }
    if (control2.Name == ((F_ContourLink) this).cmb_lastexit.Name)
    {
      if (((F_ContourLink) this).cmb_lastexit.SelectedIndex == 0)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.LastExitBackToRapidPlane;
      else if (((F_ContourLink) this).cmb_lastexit.SelectedIndex == 1)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.LastExitRetractToRapidDistance;
      else if (((F_ContourLink) this).cmb_lastexit.SelectedIndex == 2)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.LastExitRetractToFeedDistance;
      else if (((F_ContourLink) this).cmb_lastexit.SelectedIndex == 3)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.LastExitDirect;
    }
    if (control2.Name == ((F_ContourLink) this).cmb_firstleadin.Name)
    {
      if (((F_ContourLink) this).cmb_firstleadin.SelectedIndex == 0)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.FirstEntryDontUseMacro;
      else if (((F_ContourLink) this).cmb_firstleadin.SelectedIndex == 1)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.FirstEntryUseEntryMacro;
    }
    if (control2.Name == ((F_ContourLink) this).cmb_lastexitleadout.Name)
    {
      if (((F_ContourLink) this).cmb_lastexitleadout.SelectedIndex == 0)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.LastExitDontUseMacro;
      else if (((F_ContourLink) this).cmb_lastexitleadout.SelectedIndex == 1)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.LastExitUseExitMacro;
    }
    if (control2.Name == ((F_ContourLink) this).cmb_gapsalong_smallgap.Name)
    {
      if (((F_ContourLink) this).cmb_gapsalong_smallgap.SelectedIndex == 0)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.RetractToClearanceAreaGapsAlongCut;
      else if (((F_ContourLink) this).cmb_gapsalong_smallgap.SelectedIndex == 1)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.RetractToRapidDistanceGapsAlongCut;
      else if (((F_ContourLink) this).cmb_gapsalong_smallgap.SelectedIndex == 2)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.RetractToFeedDistanceGapsAlongCut;
      else if (((F_ContourLink) this).cmb_gapsalong_smallgap.SelectedIndex == 3)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.FollowSurfacesGapsAlongCut;
      else if (((F_ContourLink) this).cmb_gapsalong_smallgap.SelectedIndex == 4)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.BlendSplineGapsAlongCut;
      else if (((F_ContourLink) this).cmb_gapsalong_smallgap.SelectedIndex == 5)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.DirectGapsAlongCut;
      else if (((F_ContourLink) this).cmb_gapsalong_smallgap.SelectedIndex == 6)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.StepGapsAlongCut;
    }
    if (control2.Name == ((F_ContourLink) this).cmb_gapsalong_langegap.Name)
    {
      if (((F_ContourLink) this).cmb_gapsalong_langegap.SelectedIndex == 0)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.RetractToClearanceAreaGapsAlongCut;
      else if (((F_ContourLink) this).cmb_gapsalong_langegap.SelectedIndex == 1)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.RetractToRapidDistanceGapsAlongCut;
      else if (((F_ContourLink) this).cmb_gapsalong_langegap.SelectedIndex == 2)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.RetractToFeedDistanceGapsAlongCut;
      else if (((F_ContourLink) this).cmb_gapsalong_langegap.SelectedIndex == 3)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.FollowSurfacesGapsAlongCut;
      else if (((F_ContourLink) this).cmb_gapsalong_langegap.SelectedIndex == 4)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.BlendSplineGapsAlongCut;
      else if (((F_ContourLink) this).cmb_gapsalong_langegap.SelectedIndex == 5)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.DirectGapsAlongCut;
      else if (((F_ContourLink) this).cmb_gapsalong_langegap.SelectedIndex == 6)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.StepGapsAlongCut;
    }
    if (control2.Name == ((F_ContourLink) this).cmb_gapsalong_smallleadinout.Name)
    {
      if (((F_ContourLink) this).cmb_gapsalong_smallleadinout.SelectedIndex == 0)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.DontUseLeadInOutGapsAlongCut;
      else if (((F_ContourLink) this).cmb_gapsalong_smallleadinout.SelectedIndex == 1)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.UseLeadInGapsAlongCut;
      else if (((F_ContourLink) this).cmb_gapsalong_smallleadinout.SelectedIndex == 2)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.UseLeadOutGapsAlongCut;
      else if (((F_ContourLink) this).cmb_gapsalong_smallleadinout.SelectedIndex == 3)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.DontUseLeadInOutGapsAlongCut;
    }
    if (control2.Name == ((F_ContourLink) this).cmb_gapsalong_largeleadinout.Name)
    {
      if (((F_ContourLink) this).cmb_gapsalong_largeleadinout.SelectedIndex == 0)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.DontUseLeadInOutGapsAlongCut;
      else if (((F_ContourLink) this).cmb_gapsalong_largeleadinout.SelectedIndex == 1)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.UseLeadInGapsAlongCut;
      else if (((F_ContourLink) this).cmb_gapsalong_largeleadinout.SelectedIndex == 2)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.UseLeadOutGapsAlongCut;
      else if (((F_ContourLink) this).cmb_gapsalong_largeleadinout.SelectedIndex == 3)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.DontUseLeadInOutGapsAlongCut;
    }
    if (control2.Name == ((F_ContourLink) this).cmb_slices_smallmoves.Name)
    {
      if (((F_ContourLink) this).cmb_slices_smallmoves.SelectedIndex == 0)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.LinkBetweenSlicesRetractToClearanceArea;
      else if (((F_ContourLink) this).cmb_slices_smallmoves.SelectedIndex == 1)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.LinkBetweenSlicesRetractToRapidDistance;
      else if (((F_ContourLink) this).cmb_slices_smallmoves.SelectedIndex == 2)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.LinkBetweenSlicesRetractToFeedDistance;
      else if (((F_ContourLink) this).cmb_slices_smallmoves.SelectedIndex == 3)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.LinkBetweenSlicesFollowSurfaces;
      else if (((F_ContourLink) this).cmb_slices_smallmoves.SelectedIndex == 4)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.LinkBetweenSlicesBlendSpline;
      else if (((F_ContourLink) this).cmb_slices_smallmoves.SelectedIndex == 5)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.LinkBetweenSlicesDirect;
      else if (((F_ContourLink) this).cmb_slices_smallmoves.SelectedIndex == 6)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.LinkBetweenSlicesStep;
    }
    if (control2.Name == ((F_ContourLink) this).cmb_slices_smallleadinout.Name)
    {
      if (((F_ContourLink) this).cmb_slices_smallleadinout.SelectedIndex == 0)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.LinkBetweenSlicesSmallMovesDontUseLeadInOut;
      else if (((F_ContourLink) this).cmb_slices_smallleadinout.SelectedIndex == 1)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.LinkBetweenSlicesSmallMovesUseLeadIn;
      else if (((F_ContourLink) this).cmb_slices_smallleadinout.SelectedIndex == 2)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.LinkBetweenSlicesSmallMovesUseLeadOut;
      else if (((F_ContourLink) this).cmb_slices_smallleadinout.SelectedIndex == 3)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.LinkBetweenSlicesSmallMovesUseLeadInOut;
    }
    if (control2.Name == ((F_ContourLink) this).cmb_slices_largemoves.Name)
    {
      if (((F_ContourLink) this).cmb_slices_largemoves.SelectedIndex == 0)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.LinkBetweenSlicesRetractToClearanceArea;
      else if (((F_ContourLink) this).cmb_slices_largemoves.SelectedIndex == 1)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.LinkBetweenSlicesRetractToRapidDistance;
      else if (((F_ContourLink) this).cmb_slices_largemoves.SelectedIndex == 2)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.LinkBetweenSlicesRetractToFeedDistance;
      else if (((F_ContourLink) this).cmb_slices_largemoves.SelectedIndex == 3)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.LinkBetweenSlicesFollowSurfaces;
      else if (((F_ContourLink) this).cmb_slices_largemoves.SelectedIndex == 4)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.LinkBetweenSlicesBlendSpline;
      else if (((F_ContourLink) this).cmb_slices_largemoves.SelectedIndex == 5)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.LinkBetweenSlicesDirect;
      else if (((F_ContourLink) this).cmb_slices_largemoves.SelectedIndex == 6)
        ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.LinkBetweenSlicesStep;
    }
    if (!(control2.Name == ((F_ContourLink) this).cmb_slices_largeleadinout.Name))
      return;
    if (((F_ContourLink) this).cmb_slices_largeleadinout.SelectedIndex == 0)
      ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.LinkBetweenSlicesLargeMovesDontUseLeadInOut;
    else if (((F_ContourLink) this).cmb_slices_largeleadinout.SelectedIndex == 1)
      ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.LinkBetweenSlicesLargeMovesUseLeadIn;
    else if (((F_ContourLink) this).cmb_slices_largeleadinout.SelectedIndex == 2)
    {
      ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.LinkBetweenSlicesLargeMovesUseLeadOut;
    }
    else
    {
      if (((F_ContourLink) this).cmb_slices_largeleadinout.SelectedIndex != 3)
        return;
      ((F_ContourLink) this).\u0001.Image = (Image) ResourceImage.LinkBetweenSlicesLargeMovesUseLeadInOut;
    }
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    ((F_ContourLink) this).ControlUpdate();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ContourLink) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ContourLink) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_RoughingAdvanced() => F_ContourLink.Captions = new List<string>();

  public F_RoughingAdvanced() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    if (!buMWCalcs.AdvancedTriMesh)
    {
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ParallelRoughingSmoothConnectionsFlg = false;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothFinalPassFlg = false;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothLinksFlg = false;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothCornersFlg = false;
    }
    this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FilteringThresholdInPercOfToolDiameter;
    this.\u0005.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothFinalPassFactor;
    this.\u0007.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothCornersFactor;
    this.\u0006.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothLinkGapSize;
    this.\u0004.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ParallelRoughingSmoothConnectionRadius;
    this.\u0003.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Spacing;
    this.\u0002.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinCurvatureRadiusForAdaptiveRough;
    ((F_Roughing) this).\u000E.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.LeadOutsRadiusFactor;
    ((F_Roughing) this).\u0007.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinimizeLinksFlg;
    this.\u0006.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RemoveCornerPegsFlg;
    this.\u0002.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ParallelRoughingSmoothConnectionsFlg;
    this.\u0001.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FinalContourPassFlg;
    this.\u0003.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothFinalPassFlg;
    this.\u0004.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothLinksFlg;
    this.\u0005.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothCornersFlg;
    ((F_Roughing) this).\u0008.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseLeadOutsFlg;
    if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ContourPassType == TriangleMeshBasedTpCalcParamsContourPassType.TmbCptAllSlices)
      this.\u0002.Checked = true;
    else
      this.\u0001.Checked = true;
    this.combo_filterby.Items.Clear();
    this.combo_filterby.Items.Add((object) buMWCaptions.TriangleMeshBasedTpCalcParamsFilteringMode[0]);
    this.combo_filterby.Items.Add((object) buMWCaptions.TriangleMeshBasedTpCalcParamsFilteringMode[1]);
    if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FilteringMode == TriangleMeshBasedTpCalcParamsFilteringMode.TmbFmByRegions)
      this.combo_filterby.SelectedIndex = 0;
    else
      this.combo_filterby.SelectedIndex = 1;
    this.combo_type.Items.Clear();
    this.combo_type.Items.Add((object) buMWCaptions.TriangleMeshBasedTpCalcParamsFilteringType[0]);
    this.combo_type.Items.Add((object) buMWCaptions.TriangleMeshBasedTpCalcParamsFilteringType[1]);
    if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FilteringType == TriangleMeshBasedTpCalcParamsFilteringType.TmbFtInscribedCircle)
      this.combo_type.SelectedIndex = 0;
    else
      this.combo_type.SelectedIndex = 1;
    ((F_Roughing) this).cmb_removecornerpeg.Items.Clear();
    ((F_Roughing) this).cmb_removecornerpeg.Items.Add((object) buMWCaptions.TriangleMeshBasedTpCalcParamsCornerPegs[0]);
    ((F_Roughing) this).cmb_removecornerpeg.Items.Add((object) buMWCaptions.TriangleMeshBasedTpCalcParamsCornerPegs[1]);
    ((F_Roughing) this).cmb_removecornerpeg.Items.Add((object) buMWCaptions.TriangleMeshBasedTpCalcParamsCornerPegs[2]);
    if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.CornerPegs == TriangleMeshBasedTpCalcParamsCornerPegs.CpLineArcLine)
      ((F_Roughing) this).cmb_removecornerpeg.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.CornerPegs == TriangleMeshBasedTpCalcParamsCornerPegs.CpArc)
      ((F_Roughing) this).cmb_removecornerpeg.SelectedIndex = 1;
    else
      ((F_Roughing) this).cmb_removecornerpeg.SelectedIndex = 2;
    this.ControlUpdate();
    this.LoadLanguage();
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_RoughingAdvanced.Captions.Count < 26)
        return;
      this.\u0010.Text = F_RoughingAdvanced.Captions[0];
      this.\u0005.Text = F_RoughingAdvanced.Captions[1];
      this.\u000F.Text = F_RoughingAdvanced.Captions[2];
      this.\u0004.Text = F_RoughingAdvanced.Captions[3];
      this.\u000E.Text = F_RoughingAdvanced.Captions[4];
      this.\u0003.Text = F_RoughingAdvanced.Captions[5];
      this.\u0008.Text = F_RoughingAdvanced.Captions[6];
      this.\u0002.Text = F_RoughingAdvanced.Captions[7];
      this.\u0007.Text = F_RoughingAdvanced.Captions[8];
      this.\u0006.Text = F_RoughingAdvanced.Captions[9];
      ((F_Roughing) this).\u0007.Text = F_RoughingAdvanced.Captions[10];
      this.\u0001.Text = F_RoughingAdvanced.Captions[11];
      this.\u0002.Text = F_RoughingAdvanced.Captions[12];
      this.\u0001.Text = F_RoughingAdvanced.Captions[13];
      this.\u0004.Text = F_RoughingAdvanced.Captions[14];
      this.\u0005.Text = F_RoughingAdvanced.Captions[15];
      this.\u0002.Text = F_RoughingAdvanced.Captions[16 /*0x10*/];
      this.\u0003.Text = F_RoughingAdvanced.Captions[17];
      ((F_Roughing) this).\u0012.Text = F_RoughingAdvanced.Captions[18];
      this.\u0011.Text = F_RoughingAdvanced.Captions[19];
      this.\u0006.Text = F_RoughingAdvanced.Captions[20];
      ((F_Roughing) this).\u0008.Text = F_RoughingAdvanced.Captions[21];
      ((F_Roughing) this).\u0013.Text = F_RoughingAdvanced.Captions[22];
      ((F_Roughing) this).\u000E.Text = F_RoughingAdvanced.Captions[23];
      this.btn_ok.Text = F_RoughingAdvanced.Captions[24];
      this.btn_cancel.Text = F_RoughingAdvanced.Captions[25];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
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
    if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RoughType == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtOffset)
    {
      this.\u0005.Enabled = true;
      this.\u000F.Enabled = this.\u0005.Checked & this.\u0005.Enabled;
      this.\u0007.Enabled = this.\u0005.Checked & this.\u0005.Enabled;
      this.\u0004.Enabled = true;
      this.\u000E.Enabled = this.\u0004.Checked & this.\u0004.Enabled;
      this.\u0006.Enabled = this.\u0004.Checked & this.\u0004.Enabled;
      this.\u0003.Enabled = this.\u0005.Checked & this.\u0005.Enabled;
      this.\u0008.Enabled = this.\u0005.Checked & this.\u0005.Enabled & this.\u0003.Checked;
      this.\u0005.Enabled = this.\u0005.Checked & this.\u0005.Enabled & this.\u0003.Checked;
      ((F_Roughing) this).\u0007.Enabled = true;
      this.\u0006.Enabled = true;
      this.\u0002.Enabled = false;
      this.\u0007.Enabled = this.\u0002.Enabled & this.\u0002.Checked;
      this.\u0004.Enabled = this.\u0002.Enabled & this.\u0002.Checked;
      this.\u0006.Enabled = false;
      this.\u0002.Enabled = false;
      ((F_Roughing) this).cmb_removecornerpeg.Enabled = this.\u0006.Checked;
      ((F_Roughing) this).\u0013.Enabled = ((F_Roughing) this).\u0008.Checked;
      ((F_Roughing) this).\u000E.Enabled = ((F_Roughing) this).\u0008.Checked;
      this.\u0003.Enabled = false;
      this.\u0005.Enabled = false;
      this.combo_filterby.Enabled = true;
      this.\u0005.Enabled = true;
      this.combo_type.Enabled = true;
      this.\u0002.Enabled = true;
    }
    if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RoughType == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtParallel)
    {
      this.\u0005.Enabled = false;
      this.\u000F.Enabled = this.\u0005.Checked & this.\u0005.Enabled;
      this.\u0007.Enabled = this.\u0005.Checked & this.\u0005.Enabled;
      this.\u0004.Enabled = false;
      this.\u000E.Enabled = this.\u0004.Checked & this.\u0004.Enabled;
      this.\u0006.Enabled = this.\u0004.Checked & this.\u0004.Enabled;
      this.\u0003.Enabled = true;
      this.\u0008.Enabled = this.\u0003.Checked;
      this.\u0005.Enabled = this.\u0003.Checked;
      ((F_Roughing) this).\u0007.Enabled = false;
      this.\u0006.Enabled = false;
      this.\u0002.Enabled = true;
      this.\u0007.Enabled = this.\u0002.Enabled & this.\u0002.Checked;
      this.\u0004.Enabled = this.\u0002.Enabled & this.\u0002.Checked;
      this.\u0006.Enabled = false;
      this.\u0002.Enabled = false;
      this.\u0003.Enabled = true;
      this.\u0005.Enabled = false;
      this.combo_filterby.Enabled = false;
      this.\u0005.Enabled = false;
      this.combo_type.Enabled = true;
      this.\u0002.Enabled = true;
      this.\u0002.Enabled = this.\u0001.Checked;
      this.\u0001.Enabled = this.\u0001.Checked;
      this.\u0003.Enabled = this.\u0001.Checked;
      if (!buMWCalcs.AdvancedTriMesh)
      {
        this.\u0002.Enabled = false;
        this.\u0005.Enabled = false;
        this.\u0003.Enabled = false;
        this.\u0004.Enabled = false;
      }
    }
    if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RoughType == TriangleMeshBasedTpCalcParamsRoughType.TmbRghtAdaptive)
    {
      this.\u0005.Enabled = false;
      this.\u000F.Enabled = this.\u0005.Checked & this.\u0005.Enabled;
      this.\u0007.Enabled = this.\u0005.Checked & this.\u0005.Enabled;
      this.\u0004.Enabled = false;
      this.\u000E.Enabled = this.\u0004.Checked & this.\u0004.Enabled;
      this.\u0006.Enabled = this.\u0004.Checked & this.\u0004.Enabled;
      this.\u0003.Enabled = false;
      this.\u0008.Enabled = this.\u0005.Checked & this.\u0005.Enabled & this.\u0003.Checked;
      this.\u0005.Enabled = this.\u0005.Checked & this.\u0005.Enabled & this.\u0003.Checked;
      ((F_Roughing) this).\u0007.Enabled = false;
      this.\u0006.Enabled = false;
      this.\u0002.Enabled = false;
      this.\u0007.Enabled = this.\u0002.Enabled & this.\u0002.Checked;
      this.\u0004.Enabled = this.\u0002.Enabled & this.\u0002.Checked;
      this.\u0006.Enabled = true;
      this.\u0002.Enabled = true;
      this.\u0003.Enabled = false;
      this.\u0005.Enabled = true;
      this.combo_filterby.Enabled = false;
      this.\u0005.Enabled = false;
      this.combo_type.Enabled = true;
      this.\u0002.Enabled = true;
    }
    if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern != TriangleMeshBasedTpCalcParamsPattern.TcTmbParallelCuts)
      return;
    this.\u0005.Enabled = false;
    this.\u0002.Enabled = false;
    this.\u0006.Enabled = false;
    this.\u0001.Enabled = true;
    this.combo_filterby.Enabled = false;
    this.\u0005.Enabled = false;
    this.combo_type.Enabled = false;
    this.\u0002.Enabled = false;
  }

  public void Apply()
  {
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.LeadOutsRadiusFactor = (double) ((F_Roughing) this).\u000E.Value;
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FilteringThresholdInPercOfToolDiameter = (double) (int) this.\u0001.Value;
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothFinalPassFactor = (double) this.\u0005.Value;
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothCornersFactor = (double) this.\u0007.Value;
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothLinkGapSize = (double) this.\u0006.Value;
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ParallelRoughingSmoothConnectionRadius = (double) this.\u0004.Value;
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Spacing = (double) this.\u0003.Value;
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinCurvatureRadiusForAdaptiveRough = (double) this.\u0002.Value;
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinimizeLinksFlg = ((F_Roughing) this).\u0007.Checked;
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RemoveCornerPegsFlg = this.\u0006.Checked;
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ParallelRoughingSmoothConnectionsFlg = this.\u0002.Checked;
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FinalContourPassFlg = this.\u0001.Checked;
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothFinalPassFlg = this.\u0003.Checked;
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothLinksFlg = this.\u0004.Checked;
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SmoothCornersFlg = this.\u0005.Checked;
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseLeadOutsFlg = ((F_Roughing) this).\u0008.Checked;
    if (((F_Roughing) this).cmb_removecornerpeg.SelectedIndex == 0)
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.CornerPegs = TriangleMeshBasedTpCalcParamsCornerPegs.CpLineArcLine;
    else if (((F_Roughing) this).cmb_removecornerpeg.SelectedIndex == 1)
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.CornerPegs = TriangleMeshBasedTpCalcParamsCornerPegs.CpArc;
    else if (((F_Roughing) this).cmb_removecornerpeg.SelectedIndex == 2)
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.CornerPegs = TriangleMeshBasedTpCalcParamsCornerPegs.CpLine;
    if (this.combo_filterby.SelectedIndex == 0)
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FilteringMode = TriangleMeshBasedTpCalcParamsFilteringMode.TmbFmByRegions;
    else if (this.combo_filterby.SelectedIndex == 1)
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FilteringMode = TriangleMeshBasedTpCalcParamsFilteringMode.TmbFmByContours;
    if (this.combo_type.SelectedIndex == 0)
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FilteringType = TriangleMeshBasedTpCalcParamsFilteringType.TmbFtInscribedCircle;
    else if (this.combo_type.SelectedIndex == 1)
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FilteringType = TriangleMeshBasedTpCalcParamsFilteringType.TmbFtDiagonalLength;
    if (this.\u0002.Checked)
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ContourPassType = TriangleMeshBasedTpCalcParamsContourPassType.TmbCptAllSlices;
    else
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ContourPassType = TriangleMeshBasedTpCalcParamsContourPassType.TmbCptLastSlice;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!this.PropertiesForm.Inited)
      return;
    this.ControlUpdate();
    if (control2.Name == this.\u0005.Name)
      this.\u0001.Image = (Image) ResourceImage.SmoothCornersRough;
    else if (control2.Name == this.\u0004.Name)
      this.\u0001.Image = (Image) ResourceImage.SmoothLinksRough;
    else if (control2.Name == ((F_Roughing) this).\u0007.Name)
      this.\u0001.Image = (Image) ResourceImage.MinimizeLink;
    else if (control2.Name == this.\u0001.Name)
      this.\u0001.Image = (Image) ResourceImage.FinalContourPass;
    else if (control2.Name == this.\u0002.Name)
      this.\u0001.Image = (Image) ResourceImage.SmoothConnectionsRough;
    else if (control2.Name == ((F_Roughing) this).\u0008.Name)
      this.\u0001.Image = (Image) ResourceImage.UseLeadOutsRough;
    else if (control2.Name == this.\u0006.Name)
      this.\u0001.Image = (Image) ResourceImage.RemoveCornerPegsRough;
    else if (control2.Name == this.\u0003.Name)
      this.\u0001.Image = (Image) ResourceImage.NoImage;
    this.PropertiesForm.Inited = false;
    this.Apply();
    this.ControlUpdate();
    this.PropertiesForm.Inited = true;
  }
}
