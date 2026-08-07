// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_TriMeshConstantZ
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

public class F_TriMeshConstantZ : Form
{
  internal System.Windows.Forms.Label \u001C;
  internal System.Windows.Forms.Label \u001D;
  internal System.Windows.Forms.Label \u001E;
  internal NumericUpDown \u0015;
  internal NumericUpDown \u0016;
  internal CheckBox \u0006;
  internal Button \u0003;
  public FormProperties PropertiesForm = new FormProperties();
  public GeoLib mwCamParameter = (GeoLib) null;
  public camParameters5 buCamParameter = (camParameters5) null;
  public ToolBase5 Tool = (ToolBase5) null;
  public MWCalculationOptions Configration = new MWCalculationOptions();
  public static List<string> Captions;
  internal IContainer \u0001 = (IContainer) null;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal TabControl \u0001;
  internal TabPage \u0001;
  internal TabPage \u0002;
  internal TabPage \u0003;
  internal TabPage \u0004;
  internal CheckBox \u0001;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0001;
  internal NumericUpDown \u0002;
  internal System.Windows.Forms.Label \u0002;
  internal NumericUpDown \u0003;
  internal System.Windows.Forms.Label \u0003;
  internal Panel \u0001;
  internal Button \u0001;
  internal NumericUpDown \u0004;
  internal System.Windows.Forms.Label \u0004;
  internal Panel \u0002;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal NumericUpDown \u0005;
  internal System.Windows.Forms.Label \u0005;
  internal Panel \u0003;
  internal System.Windows.Forms.Label \u0006;
  internal System.Windows.Forms.Label \u0007;
  internal Panel \u0004;
  internal System.Windows.Forms.Label \u0008;
  internal System.Windows.Forms.Label \u000E;
  internal System.Windows.Forms.Label \u000F;
  internal Panel \u0005;
  internal Button \u0002;
  internal System.Windows.Forms.Label \u0010;
  internal NumericUpDown \u0006;
  internal System.Windows.Forms.Label \u0011;
  internal System.Windows.Forms.Label \u0012;
  internal System.Windows.Forms.Label \u0013;
  internal NumericUpDown \u0007;
  internal System.Windows.Forms.Label \u0014;
  internal NumericUpDown \u0008;
  internal NumericUpDown \u000E;
  internal PictureBox \u0001;
  internal CheckBox \u0002;
  internal NumericUpDown \u000F;
  internal CheckBox \u0003;
  internal NumericUpDown \u0010;
  internal System.Windows.Forms.Label \u0015;
  internal NumericUpDown \u0011;
  internal System.Windows.Forms.Label \u0016;
  internal NumericUpDown \u0012;
  internal System.Windows.Forms.Label \u0017;
  internal ComboBox \u0001;
  internal Button \u0003;
  internal Panel \u0006;
  internal Button \u0004;
  internal System.Windows.Forms.Label \u0018;
  public ComboBox cmb_leadouttype;
  internal System.Windows.Forms.Label \u0019;
  internal CheckBox \u0004;
  internal Panel \u0007;
  internal Button \u0005;
  internal System.Windows.Forms.Label \u001A;
  public ComboBox cmb_leadintype;
  internal System.Windows.Forms.Label \u001B;
  internal CheckBox \u0005;
  internal System.Windows.Forms.Label \u001C;
  internal Panel \u0008;
  internal Button \u0006;
  internal System.Windows.Forms.Label \u001D;
  internal Panel \u000E;
  internal Button \u0007;
  internal CheckBox \u0006;
  internal System.Windows.Forms.Label \u001E;
  internal Panel \u000F;
  internal Button \u0008;
  internal CheckBox \u0007;
  internal System.Windows.Forms.Label \u001F;
  internal Panel \u0010;
  internal Button \u000E;
  internal Button \u000F;
  internal CheckBox \u0008;
  internal System.Windows.Forms.Label \u007F;
  internal Panel \u0011;
  internal Button \u0010;
  internal CheckBox \u000E;
  internal System.Windows.Forms.Label \u0080;
  internal Panel \u0012;
  internal CheckBox \u000F;
  internal Button \u0011;
  internal System.Windows.Forms.Label \u0081;
  internal Panel \u0013;
  internal Button \u0012;
  internal CheckBox \u0010;
  internal System.Windows.Forms.Label \u0082;
  internal Button \u0013;
  internal Panel \u0014;
  internal Button \u0014;
  internal Button \u0015;
  internal CheckBox \u0011;
  internal System.Windows.Forms.Label \u0083;
  internal Panel \u0015;
  internal Button \u0016;
  internal NumericUpDown \u0013;
  internal Button \u0017;
  internal NumericUpDown \u0014;
  internal RadioButton \u0003;
  internal System.Windows.Forms.Label \u0084;
  internal RadioButton \u0004;
  internal Panel \u0016;
  internal System.Windows.Forms.Label \u0086;
  internal ComboBox \u0002;

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_DrillLine) this).\u0003.Name)
      ((F_DrillLine) this).\u0001.Image = (Image) ResourceImage.StartHeight;
    else if (control2.Name == ((F_DrillLine) this).\u0004.Name)
      ((F_DrillLine) this).\u0001.Image = (Image) ResourceImage.EndHeight;
    else if (control2.Name == ((F_DrillLine) this).\u0005.Name)
    {
      ((F_DrillLine) this).\u0001.Image = (Image) ResourceImage.CutTolerance;
      if (((F_DrillLine) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_DrillLine) this).\u0001.Name)
    {
      ((F_DrillLine) this).\u0001.Image = (Image) ResourceImage.PlungeRate;
      if (((F_DrillLine) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_DrillLine) this).\u0002.Name)
    {
      ((F_DrillLine) this).\u0001.Image = (Image) ResourceImage.RetractRate;
      if (((F_DrillLine) this).\u0002.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_DrillLine) this).\u0001.Name)
      ((F_DrillLine) this).\u0001.Image = (Image) ResourceImage.RapidRetract;
    else if (control2.Name == ((F_DrillLine) this).\u000E.Name)
      ((F_DrillLine) this).\u0001.Image = (Image) ResourceImage.SafeDistance;
    else if (control2.Name == ((F_DrillLine) this).\u0008.Name)
      ((F_DrillLine) this).\u0001.Image = (Image) ResourceImage.RapidDistance;
    else if (control2.Name == ((F_DrillLine) this).\u0007.Name)
      ((F_DrillLine) this).\u0001.Image = (Image) ResourceImage.AirSafeDistance;
    else if (control2.Name == ((F_DrillLine) this).\u0006.Name)
    {
      if (((F_DrillLine) this).\u0001.Checked)
        ((F_DrillLine) this).\u0001.Image = (Image) ResourceImage.SpindleCCW;
      else
        ((F_DrillLine) this).\u0001.Image = (Image) ResourceImage.SpindleCW;
    }
    else if (control2.Name == ((F_DrillLine) this).\u0001.Name)
      ((F_DrillLine) this).\u0001.Image = (Image) ResourceImage.SpindleCCW;
    else if (control2.Name == ((F_DrillLine) this).\u0002.Name)
      ((F_DrillLine) this).\u0001.Image = (Image) ResourceImage.SpindleCW;
    ((F_DrillLine) this).\u0002.Checked = false;
  }

  internal void \u0006([In] object obj0, [In] EventArgs obj1)
  {
    ((F_DrillLine) this).ControlUpdate();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_DrillLine) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_DrillLine) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_TriMeshConstantZ() => F_DrillLine.Captions = new List<string>();

  public F_TriMeshConstantZ() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.\u0002.Visible = this.PropertiesForm.ShowHelp;
    this.\u0010.Value = (Decimal) this.mwCamParameter.MachParam.RadialOffset;
    this.\u0011.Value = (Decimal) this.mwCamParameter.MachParam.AxialOffset;
    this.\u0012.Value = (Decimal) this.mwCamParameter.MachParam.StockRemain;
    this.\u0004.Value = (Decimal) this.mwCamParameter.MachParam.CutTolerance;
    this.\u0014.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStep;
    this.\u0013.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.NumberOfSlices4DepthStep;
    this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.FeedRate;
    this.\u0002.Value = (Decimal) this.mwCamParameter.MachParam.PlungeFeedRate;
    this.\u0003.Value = (Decimal) this.mwCamParameter.MachParam.RetractFeedRate;
    this.\u0007.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.ApproachFeedPlaneIncremental;
    this.\u0008.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.RetractPlaneIncremental;
    this.\u000E.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.ClearancePlaneHeight;
    this.\u0006.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.AirMoveSafetyDistance;
    this.\u0005.Value = (Decimal) this.buCamParameter.Speeds.SpindleSpeed;
    this.\u0001.Checked = this.mwCamParameter.MachParam.RapidRetractFlg;
    this.\u0003.Checked = this.mwCamParameter.MachParam.RapidFeedFlg;
    ((F_TriMeshParallelCut) this).\u0015.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SharedMiscParams.OverlapLength;
    this.\u0001.Items.Clear();
    this.\u0001.Items.Add((object) buMWCaptions.MachiningParamsStockRemainType[0]);
    this.\u0001.Items.Add((object) buMWCaptions.MachiningParamsStockRemainType[1]);
    if (this.mwCamParameter.MachParam.StockRemainType == MachiningParamsStockRemainType.SrtGlobal)
      this.\u0001.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.StockRemainType == MachiningParamsStockRemainType.SrtRadialAndAxial)
      this.\u0001.SelectedIndex = 1;
    if (this.buCamParameter.Speeds.SpindleDirection == ClockDirectionType.CW)
    {
      this.\u0002.Checked = true;
      this.\u0001.Checked = false;
    }
    else
    {
      this.\u0002.Checked = false;
      this.\u0001.Checked = true;
    }
    if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepMode == MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep)
    {
      this.\u0004.Checked = true;
      this.\u0003.Checked = false;
    }
    else
    {
      this.\u0004.Checked = false;
      this.\u0003.Checked = true;
    }
    this.\u0002.Items.Clear();
    this.\u0002.Items.Add((object) buMWCaptions.MachiningParamsDirection[2]);
    this.\u0002.Items.Add((object) buMWCaptions.MachiningParamsDirection[3]);
    if (this.mwCamParameter.MachParam.MachDirForOneWay == MachiningParamsDirection.DirClimb)
      this.\u0002.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.MachDirForOneWay == MachiningParamsDirection.DirConventional)
      this.\u0002.SelectedIndex = 1;
    ((F_TriMeshParallelCut) this).\u0004.Items.Clear();
    ((F_TriMeshParallelCut) this).\u0004.Items.Add((object) buMWCaptions.MachiningParamsMachType[0]);
    ((F_TriMeshParallelCut) this).\u0004.Items.Add((object) buMWCaptions.MachiningParamsMachType[1]);
    ((F_TriMeshParallelCut) this).\u0004.Items.Add((object) buMWCaptions.MachiningParamsMachType[2]);
    if (this.mwCamParameter.MachParam.CurMachType == MachiningParamsMachType.MachtypeOneway)
      ((F_TriMeshParallelCut) this).\u0004.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.CurMachType == MachiningParamsMachType.MachtypeZigzag)
      ((F_TriMeshParallelCut) this).\u0004.SelectedIndex = 1;
    else if (this.mwCamParameter.MachParam.CurMachType == MachiningParamsMachType.MachtypeSpiral)
      ((F_TriMeshParallelCut) this).\u0004.SelectedIndex = 2;
    ((F_TriMeshParallelCut) this).\u0003.Items.Clear();
    ((F_TriMeshParallelCut) this).\u0003.Items.Add((object) buMWCaptions.MachiningParamsMachiningAreaMode[0]);
    ((F_TriMeshParallelCut) this).\u0003.Items.Add((object) buMWCaptions.MachiningParamsMachiningAreaMode[1]);
    if (this.mwCamParameter.MachParam.MachiningAreaMode == MachiningParamsMachiningAreaMode.MachByLanes)
      ((F_TriMeshParallelCut) this).\u0003.SelectedIndex = 0;
    else
      ((F_TriMeshParallelCut) this).\u0003.SelectedIndex = 1;
    this.\u0005.Checked = this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.IsUsed;
    this.cmb_leadintype.Items.Clear();
    this.cmb_leadintype.Items.Add((object) buMWCaptions.LeadParamsType[0]);
    this.cmb_leadintype.Items.Add((object) buMWCaptions.LeadParamsType[1]);
    this.cmb_leadintype.Items.Add((object) buMWCaptions.LeadParamsType[2]);
    this.cmb_leadintype.Items.Add((object) buMWCaptions.LeadParamsType[8]);
    this.cmb_leadintype.Items.Add((object) buMWCaptions.LeadParamsType[3]);
    this.cmb_leadintype.Items.Add((object) buMWCaptions.LeadParamsType[4]);
    this.cmb_leadintype.Items.Add((object) buMWCaptions.LeadParamsType[5]);
    this.cmb_leadintype.Items.Add((object) buMWCaptions.LeadParamsType[7]);
    this.cmb_leadintype.Items.Add((object) buMWCaptions.LeadParamsType[6]);
    this.cmb_leadintype.Items.Add((object) buMWCaptions.LeadParamsType[14]);
    this.cmb_leadintype.Items.Add((object) buMWCaptions.LeadParamsType[11]);
    this.cmb_leadintype.Items.Add((object) buMWCaptions.LeadParamsType[9]);
    this.cmb_leadintype.Items.Add((object) buMWCaptions.LeadParamsType[10]);
    this.cmb_leadintype.Items.Add((object) buMWCaptions.LeadParamsType[19]);
    if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.TangentialArc)
      this.cmb_leadintype.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.ReverseTangArc)
      this.cmb_leadintype.SelectedIndex = 1;
    else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.VerticalTangArc)
      this.cmb_leadintype.SelectedIndex = 2;
    else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.ReverseVertTangArc)
      this.cmb_leadintype.SelectedIndex = 3;
    else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.HorizontalTangArc)
      this.cmb_leadintype.SelectedIndex = 4;
    else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.OrthogonalArc)
      this.cmb_leadintype.SelectedIndex = 5;
    else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.TangentialLine)
      this.cmb_leadintype.SelectedIndex = 6;
    else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.ReverseTangLine)
      this.cmb_leadintype.SelectedIndex = 7;
    else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.OrthogonalLine)
      this.cmb_leadintype.SelectedIndex = 8;
    else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.ReverseOrthogonalLine)
      this.cmb_leadintype.SelectedIndex = 9;
    else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.VertProfileRamp)
      this.cmb_leadintype.SelectedIndex = 10;
    else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.ReverseVertProfileRamp)
      this.cmb_leadintype.SelectedIndex = 11;
    else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.PositionLine)
      this.cmb_leadintype.SelectedIndex = 12;
    else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.SlantLine)
      this.cmb_leadintype.SelectedIndex = 13;
    this.\u0004.Checked = this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.IsUsed;
    this.cmb_leadouttype.Items.Clear();
    this.cmb_leadouttype.Items.Add((object) buMWCaptions.LeadParamsType[0]);
    this.cmb_leadouttype.Items.Add((object) buMWCaptions.LeadParamsType[1]);
    this.cmb_leadouttype.Items.Add((object) buMWCaptions.LeadParamsType[2]);
    this.cmb_leadouttype.Items.Add((object) buMWCaptions.LeadParamsType[8]);
    this.cmb_leadouttype.Items.Add((object) buMWCaptions.LeadParamsType[3]);
    this.cmb_leadouttype.Items.Add((object) buMWCaptions.LeadParamsType[4]);
    this.cmb_leadouttype.Items.Add((object) buMWCaptions.LeadParamsType[5]);
    this.cmb_leadouttype.Items.Add((object) buMWCaptions.LeadParamsType[7]);
    this.cmb_leadouttype.Items.Add((object) buMWCaptions.LeadParamsType[6]);
    this.cmb_leadouttype.Items.Add((object) buMWCaptions.LeadParamsType[14]);
    this.cmb_leadouttype.Items.Add((object) buMWCaptions.LeadParamsType[11]);
    this.cmb_leadouttype.Items.Add((object) buMWCaptions.LeadParamsType[9]);
    this.cmb_leadouttype.Items.Add((object) buMWCaptions.LeadParamsType[10]);
    this.cmb_leadouttype.Items.Add((object) buMWCaptions.LeadParamsType[19]);
    if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.TangentialArc)
      this.cmb_leadouttype.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.ReverseTangArc)
      this.cmb_leadouttype.SelectedIndex = 1;
    else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.VerticalTangArc)
      this.cmb_leadouttype.SelectedIndex = 2;
    else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.ReverseVertTangArc)
      this.cmb_leadouttype.SelectedIndex = 3;
    else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.HorizontalTangArc)
      this.cmb_leadouttype.SelectedIndex = 4;
    else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.OrthogonalArc)
      this.cmb_leadouttype.SelectedIndex = 5;
    else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.TangentialLine)
      this.cmb_leadouttype.SelectedIndex = 6;
    else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.ReverseTangLine)
      this.cmb_leadouttype.SelectedIndex = 7;
    else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.OrthogonalLine)
      this.cmb_leadouttype.SelectedIndex = 8;
    else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.ReverseOrthogonalLine)
      this.cmb_leadouttype.SelectedIndex = 9;
    else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.VertProfileRamp)
      this.cmb_leadouttype.SelectedIndex = 10;
    else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.ReverseVertProfileRamp)
      this.cmb_leadouttype.SelectedIndex = 11;
    else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.PositionLine)
      this.cmb_leadouttype.SelectedIndex = 12;
    else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.SlantLine)
      this.cmb_leadouttype.SelectedIndex = 13;
    this.\u0004.Checked = this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.IsUsed;
    this.\u000E.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.RestFinishingFlg;
    this.\u0008.Checked = this.mwCamParameter.MachParam.Containment2dParams.IsUsedFlg;
    this.\u000F.Checked = this.mwCamParameter.MachParam.RoughingParams.MultiCutsRoughParams.IsUsedFlg;
    this.\u0006.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.SilhouetteContainmentFlg;
    this.\u0007.Checked = this.mwCamParameter.MachParam.RadiusFitFlg;
    this.\u0010.Checked = this.mwCamParameter.MachParam.ShallowAndSteepAreaParams.IsUsedFlg;
    this.\u0011.Checked = this.mwCamParameter.MachParam.FeedControlZoneParams.Status;
    this.\u0001.Image = (Image) ResourceImage.RoughtOffset;
    this.Refresh();
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
    \u0005.\u0002.\u0001(this);
    this.ControlUpdate();
  }

  public void ControlUpdate()
  {
    this.\u0012.Enabled = false;
    this.\u001C.Enabled = false;
    this.\u0011.Enabled = false;
    this.\u0016.Enabled = false;
    this.\u0010.Enabled = false;
    this.\u0015.Enabled = false;
    if (this.\u0001.SelectedIndex == 0)
    {
      this.\u0012.Enabled = true;
      this.\u001C.Enabled = true;
    }
    else
    {
      this.\u0011.Enabled = true;
      this.\u0016.Enabled = true;
      this.\u0010.Enabled = true;
      this.\u0015.Enabled = true;
    }
    this.\u0005.Enabled = this.\u0005.Checked;
    this.cmb_leadintype.Enabled = this.\u0005.Checked;
    this.\u001A.Enabled = this.\u0005.Checked;
    this.\u0004.Enabled = this.\u0004.Checked;
    this.cmb_leadouttype.Enabled = this.\u0004.Checked;
    this.\u0018.Enabled = this.\u0004.Checked;
    this.\u0011.Enabled = this.\u000F.Checked;
    this.\u0010.Enabled = this.\u000E.Checked;
    this.\u0008.Enabled = this.\u0007.Checked;
    this.\u0007.Enabled = this.\u0006.Checked;
    this.\u0012.Enabled = this.\u0010.Checked;
    this.\u000E.Enabled = this.\u0008.Checked;
    this.\u000F.Enabled = this.\u0003.Checked;
    if (buMWCalcs.AdvancedTriMesh)
      return;
    this.\u000E.Enabled = false;
    this.\u0010.Enabled = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == this.btn_ok.Name)
    {
      if (!this.PropertiesForm.Inited)
        return;
      if (this.PropertiesForm.ReadOnly)
      {
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
        return;
      }
      \u0005.\u0002.\u0001(this);
      this.PropertiesForm.Result = DialogResult.OK;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.btn_cancel.Name)
    {
      this.PropertiesForm.Result = DialogResult.Cancel;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.\u0017.Name)
    {
      F_DepthStepAdvanced depthStepAdvanced = new F_DepthStepAdvanced()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      depthStepAdvanced.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      depthStepAdvanced.buCamParameter = new camParameters5(this.buCamParameter);
      depthStepAdvanced.Configration = new MWCalculationOptions(this.Configration);
      if (this.Tool != null)
        depthStepAdvanced.Tool = new ToolBase5(depthStepAdvanced.Tool);
      depthStepAdvanced.Init();
      int num = (int) depthStepAdvanced.ShowDialog();
      if (depthStepAdvanced.PropertiesForm.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(depthStepAdvanced.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(depthStepAdvanced.buCamParameter);
      }
    }
    if (control2.Name == this.\u0016.Name)
    {
      F_Height fHeight = new F_Height()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      fHeight.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      fHeight.buCamParameter = new camParameters5(this.buCamParameter);
      fHeight.Configration = new MWCalculationOptions(this.Configration);
      if (this.Tool != null)
        fHeight.Tool = new ToolBase5(fHeight.Tool);
      fHeight.Init();
      int num = (int) fHeight.ShowDialog();
      if (fHeight.PropertiesForm.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(fHeight.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(fHeight.buCamParameter);
      }
    }
    if (control2.Name == this.\u0001.Name)
    {
      F_SurfaceQuality fSurfaceQuality = new F_SurfaceQuality()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      fSurfaceQuality.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      fSurfaceQuality.buCamParameter = new camParameters5(this.buCamParameter);
      fSurfaceQuality.Configration = new MWCalculationOptions(this.Configration);
      if (this.Tool != null)
        fSurfaceQuality.Tool = new ToolBase5(fSurfaceQuality.Tool);
      fSurfaceQuality.Init();
      int num = (int) fSurfaceQuality.ShowDialog();
      if (fSurfaceQuality.Properties.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(fSurfaceQuality.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(fSurfaceQuality.buCamParameter);
      }
    }
    if (control2.Name == this.\u0003.Name)
    {
      F_ContourLink fContourLink = new F_ContourLink()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      fContourLink.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      fContourLink.buCamParameter = new camParameters5(this.buCamParameter);
      fContourLink.Configration = new MWCalculationOptions(this.Configration);
      if (this.Tool != null)
        fContourLink.Tool = new ToolBase5(fContourLink.Tool);
      fContourLink.Init();
      int num = (int) fContourLink.ShowDialog();
      if (fContourLink.Properties.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(fContourLink.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(fContourLink.buCamParameter);
        if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.TangentialArc)
          this.cmb_leadintype.SelectedIndex = 0;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.ReverseTangArc)
          this.cmb_leadintype.SelectedIndex = 1;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.VerticalTangArc)
          this.cmb_leadintype.SelectedIndex = 2;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.ReverseVertTangArc)
          this.cmb_leadintype.SelectedIndex = 3;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.HorizontalTangArc)
          this.cmb_leadintype.SelectedIndex = 4;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.OrthogonalArc)
          this.cmb_leadintype.SelectedIndex = 5;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.TangentialLine)
          this.cmb_leadintype.SelectedIndex = 6;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.ReverseTangLine)
          this.cmb_leadintype.SelectedIndex = 7;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.OrthogonalLine)
          this.cmb_leadintype.SelectedIndex = 8;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.ReverseOrthogonalLine)
          this.cmb_leadintype.SelectedIndex = 9;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.VertProfileRamp)
          this.cmb_leadintype.SelectedIndex = 10;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.ReverseVertProfileRamp)
          this.cmb_leadintype.SelectedIndex = 11;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.SlantLine)
          this.cmb_leadintype.SelectedIndex = 12;
        this.\u0005.Checked = this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.IsUsed;
        if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.TangentialArc)
          this.cmb_leadouttype.SelectedIndex = 0;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.ReverseTangArc)
          this.cmb_leadouttype.SelectedIndex = 1;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.VerticalTangArc)
          this.cmb_leadouttype.SelectedIndex = 2;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.ReverseVertTangArc)
          this.cmb_leadouttype.SelectedIndex = 3;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.HorizontalTangArc)
          this.cmb_leadouttype.SelectedIndex = 4;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.OrthogonalArc)
          this.cmb_leadouttype.SelectedIndex = 5;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.TangentialLine)
          this.cmb_leadouttype.SelectedIndex = 6;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.ReverseTangLine)
          this.cmb_leadouttype.SelectedIndex = 7;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.OrthogonalLine)
          this.cmb_leadouttype.SelectedIndex = 8;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.ReverseOrthogonalLine)
          this.cmb_leadouttype.SelectedIndex = 9;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.VertProfileRamp)
          this.cmb_leadouttype.SelectedIndex = 10;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.ReverseVertProfileRamp)
          this.cmb_leadouttype.SelectedIndex = 11;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.SlantLine)
          this.cmb_leadouttype.SelectedIndex = 12;
        this.\u0004.Checked = this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.IsUsed;
      }
    }
    if (control2.Name == this.\u0002.Name)
    {
      F_HeightAdvanced fHeightAdvanced = new F_HeightAdvanced()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      fHeightAdvanced.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      fHeightAdvanced.buCamParameter = new camParameters5(this.buCamParameter);
      fHeightAdvanced.Configration = new MWCalculationOptions(this.Configration);
      if (this.Tool != null)
        fHeightAdvanced.Tool = new ToolBase5(fHeightAdvanced.Tool);
      fHeightAdvanced.Init();
      int num = (int) fHeightAdvanced.ShowDialog();
      if (fHeightAdvanced.PropertiesForm.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(fHeightAdvanced.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(fHeightAdvanced.buCamParameter);
      }
    }
    if (control2.Name == this.\u0005.Name)
    {
      \u0005.\u0002.\u0001(this);
      F_LeadControl fLeadControl = new F_LeadControl();
      fLeadControl.mwCamLeadController = this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController;
      fLeadControl.buCamParameter = new camParameters5(this.buCamParameter);
      fLeadControl.Configration = new MWCalculationOptions(this.Configration);
      if (this.Tool != null)
        fLeadControl.Tool = new ToolBase5(fLeadControl.Tool);
      fLeadControl.Init();
      int num = (int) fLeadControl.ShowDialog();
      if (fLeadControl.Properties.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController = fLeadControl.mwCamLeadController;
        this.buCamParameter = new camParameters5(fLeadControl.buCamParameter);
        if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.TangentialArc)
          this.cmb_leadintype.SelectedIndex = 0;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.ReverseTangArc)
          this.cmb_leadintype.SelectedIndex = 1;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.VerticalTangArc)
          this.cmb_leadintype.SelectedIndex = 2;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.ReverseVertTangArc)
          this.cmb_leadintype.SelectedIndex = 3;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.HorizontalTangArc)
          this.cmb_leadintype.SelectedIndex = 4;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.OrthogonalArc)
          this.cmb_leadintype.SelectedIndex = 5;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.TangentialLine)
          this.cmb_leadintype.SelectedIndex = 6;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.ReverseTangLine)
          this.cmb_leadintype.SelectedIndex = 7;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.OrthogonalLine)
          this.cmb_leadintype.SelectedIndex = 8;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.ReverseOrthogonalLine)
          this.cmb_leadintype.SelectedIndex = 9;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.VertProfileRamp)
          this.cmb_leadintype.SelectedIndex = 10;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.ReverseVertProfileRamp)
          this.cmb_leadintype.SelectedIndex = 11;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.PositionLine)
          this.cmb_leadintype.SelectedIndex = 12;
        else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.LeadParams.Type == LeadParamsType.SlantLine)
          this.cmb_leadintype.SelectedIndex = 13;
        this.\u0005.Checked = this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.IsUsed;
      }
    }
    if (control2.Name == this.\u0004.Name)
    {
      F_LeadControl fLeadControl = new F_LeadControl();
      fLeadControl.mwCamLeadController = this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController;
      fLeadControl.buCamParameter = new camParameters5(this.buCamParameter);
      fLeadControl.Configration = new MWCalculationOptions(this.Configration);
      if (this.Tool != null)
        fLeadControl.Tool = new ToolBase5(fLeadControl.Tool);
      fLeadControl.Init();
      int num = (int) fLeadControl.ShowDialog();
      if (fLeadControl.Properties.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController = fLeadControl.mwCamLeadController;
        this.buCamParameter = new camParameters5(fLeadControl.buCamParameter);
        if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.TangentialArc)
          this.cmb_leadouttype.SelectedIndex = 0;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.ReverseTangArc)
          this.cmb_leadouttype.SelectedIndex = 1;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.VerticalTangArc)
          this.cmb_leadouttype.SelectedIndex = 2;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.ReverseVertTangArc)
          this.cmb_leadouttype.SelectedIndex = 3;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.HorizontalTangArc)
          this.cmb_leadouttype.SelectedIndex = 4;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.OrthogonalArc)
          this.cmb_leadouttype.SelectedIndex = 5;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.TangentialLine)
          this.cmb_leadouttype.SelectedIndex = 6;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.ReverseTangLine)
          this.cmb_leadouttype.SelectedIndex = 7;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.OrthogonalLine)
          this.cmb_leadouttype.SelectedIndex = 8;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.ReverseOrthogonalLine)
          this.cmb_leadouttype.SelectedIndex = 9;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.VertProfileRamp)
          this.cmb_leadouttype.SelectedIndex = 10;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.ReverseVertProfileRamp)
          this.cmb_leadouttype.SelectedIndex = 11;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.PositionLine)
          this.cmb_leadouttype.SelectedIndex = 12;
        else if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.LeadParams.Type == LeadParamsType.SlantLine)
          this.cmb_leadouttype.SelectedIndex = 13;
        this.\u0004.Checked = this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.IsUsed;
      }
    }
    if (control2.Name == this.\u0012.Name)
    {
      F_AngleRange fAngleRange = new F_AngleRange()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      fAngleRange.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      fAngleRange.buCamParameter = new camParameters5(this.buCamParameter);
      fAngleRange.Configration = new MWCalculationOptions(this.Configration);
      if (this.Tool != null)
        fAngleRange.Tool = new ToolBase5(fAngleRange.Tool);
      fAngleRange.Init();
      int num = (int) fAngleRange.ShowDialog();
      if (fAngleRange.PropertiesForm.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(fAngleRange.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(fAngleRange.buCamParameter);
      }
    }
    if (control2.Name == this.\u0011.Name)
    {
      F_MultiPass fMultiPass = new F_MultiPass()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      fMultiPass.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      fMultiPass.buCamParameter = new camParameters5(this.buCamParameter);
      fMultiPass.Configration = new MWCalculationOptions(this.Configration);
      if (this.Tool != null)
        fMultiPass.Tool = new ToolBase5(fMultiPass.Tool);
      fMultiPass.Init();
      int num = (int) fMultiPass.ShowDialog();
      if (fMultiPass.PropertiesForm.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(fMultiPass.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(fMultiPass.buCamParameter);
      }
    }
    if (control2.Name == this.\u0010.Name)
    {
      F_RestFinish fRestFinish = new F_RestFinish()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      fRestFinish.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      fRestFinish.buCamParameter = new camParameters5(this.buCamParameter);
      fRestFinish.Configration = new MWCalculationOptions(this.Configration);
      if (this.Tool != null)
        fRestFinish.Tool = new ToolBase5(fRestFinish.Tool);
      fRestFinish.Init();
      int num = (int) fRestFinish.ShowDialog();
      if (fRestFinish.PropertiesForm.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(fRestFinish.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(fRestFinish.buCamParameter);
      }
    }
    if (control2.Name == this.\u000E.Name)
    {
      F_2DContainment f2Dcontainment = new F_2DContainment()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      f2Dcontainment.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      f2Dcontainment.buCamParameter = new camParameters5(this.buCamParameter);
      f2Dcontainment.Configration = new MWCalculationOptions(this.Configration);
      if (this.Tool != null)
        f2Dcontainment.Tool = new ToolBase5(f2Dcontainment.Tool);
      f2Dcontainment.Init();
      int num = (int) f2Dcontainment.ShowDialog();
      if (f2Dcontainment.PropertiesForm.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(f2Dcontainment.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(f2Dcontainment.buCamParameter);
      }
    }
    if (control2.Name == this.\u0008.Name)
    {
      F_RoundCorner fRoundCorner = new F_RoundCorner()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      fRoundCorner.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      fRoundCorner.buCamParameter = new camParameters5(this.buCamParameter);
      fRoundCorner.Configration = new MWCalculationOptions(this.Configration);
      if (this.Tool != null)
        fRoundCorner.Tool = new ToolBase5(fRoundCorner.Tool);
      fRoundCorner.Init();
      int num = (int) fRoundCorner.ShowDialog();
      if (fRoundCorner.PropertiesForm.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(fRoundCorner.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(fRoundCorner.buCamParameter);
      }
    }
    if (control2.Name == this.\u0007.Name)
    {
      F_Silhouette fSilhouette = new F_Silhouette()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      fSilhouette.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      fSilhouette.buCamParameter = new camParameters5(this.buCamParameter);
      fSilhouette.Configration = new MWCalculationOptions(this.Configration);
      if (this.Tool != null)
        fSilhouette.Tool = new ToolBase5(fSilhouette.Tool);
      fSilhouette.Init();
      int num = (int) fSilhouette.ShowDialog();
      if (fSilhouette.PropertiesForm.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(fSilhouette.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(fSilhouette.buCamParameter);
      }
    }
    if (control2.Name == this.\u0006.Name)
    {
      F_Filtering fFiltering = new F_Filtering()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      fFiltering.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      fFiltering.buCamParameter = new camParameters5(this.buCamParameter);
      fFiltering.Configration = new MWCalculationOptions(this.Configration);
      if (this.Tool != null)
        fFiltering.Tool = new ToolBase5(fFiltering.Tool);
      fFiltering.Init();
      int num = (int) fFiltering.ShowDialog();
      if (fFiltering.PropertiesForm.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(fFiltering.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(fFiltering.buCamParameter);
      }
    }
    if (control2.Name == this.\u0014.Name)
    {
      F_FeedZone fFeedZone = new F_FeedZone()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      fFeedZone.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      fFeedZone.buCamParameter = new camParameters5(this.buCamParameter);
      fFeedZone.Configration = new MWCalculationOptions(this.Configration);
      if (this.Tool != null)
        fFeedZone.Tool = new ToolBase5(fFeedZone.Tool);
      fFeedZone.Init();
      int num = (int) fFeedZone.ShowDialog();
      if (fFeedZone.PropertiesForm.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(fFeedZone.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(fFeedZone.buCamParameter);
      }
    }
    if (!(control2.Name == this.\u0013.Name))
      return;
    F_FeedAdvanced fFeedAdvanced = new F_FeedAdvanced()
    {
      mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
    };
    fFeedAdvanced.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
    fFeedAdvanced.buCamParameter = new camParameters5(this.buCamParameter);
    fFeedAdvanced.Configration = new MWCalculationOptions(this.Configration);
    if (this.Tool != null)
      fFeedAdvanced.Tool = new ToolBase5(fFeedAdvanced.Tool);
    fFeedAdvanced.Init();
    int num1 = (int) fFeedAdvanced.ShowDialog();
    if (fFeedAdvanced.PropertiesForm.Result != DialogResult.OK)
      return;
    this.mwCamParameter.MachParam = new MachiningParams(fFeedAdvanced.mwCamParameter.MachParam);
    this.buCamParameter = new camParameters5(fFeedAdvanced.buCamParameter);
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (this.PropertiesForm.Inited)
      ;
  }

  internal void \u0001([In] object obj0, [In] KeyEventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!(obj1.KeyCode == Keys.Return | obj1.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKeyDown(this.\u0001.SelectedTab.Controls, result, obj1.Shift);
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    if (!(this.PropertiesForm.TouchPad & !this.\u0002.Checked))
      return;
    NumericUpDown numericUpDown = new NumericUpDown();
    NumericUpDown Ctrl = (NumericUpDown) obj0;
    if (!Ctrl.Enabled)
      return;
    buControlCommands.ShowKeyPadWinControl((Form) this, (Control) Ctrl);
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1) => this.ControlUpdate();

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!this.PropertiesForm.Inited)
      return;
    this.ControlUpdate();
    if (control2.Name == ((F_TriMeshParallelCut) this).\u0004.Name)
    {
      if (((F_TriMeshParallelCut) this).\u0004.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.SortOneway;
      else if (((F_TriMeshParallelCut) this).\u0004.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.SortZigzag;
      else if (((F_TriMeshParallelCut) this).\u0004.SelectedIndex == 2)
        ;
    }
    if (control2.Name == this.cmb_leadintype.Name)
    {
      if (this.cmb_leadintype.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.ArcTangential;
      else if (this.cmb_leadintype.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.ArcReverseTangential;
      else if (this.cmb_leadintype.SelectedIndex == 2)
        this.\u0001.Image = (Image) ResourceImage.ArcVerticalTangential;
      else if (this.cmb_leadintype.SelectedIndex == 3)
        this.\u0001.Image = (Image) ResourceImage.ArcReverseVerticalTangential;
      else if (this.cmb_leadintype.SelectedIndex == 4)
        this.\u0001.Image = (Image) ResourceImage.ArcHorizontalTangential;
      else if (this.cmb_leadintype.SelectedIndex == 5)
        this.\u0001.Image = (Image) ResourceImage.ArcOrthogonal;
      else if (this.cmb_leadintype.SelectedIndex == 6)
        this.\u0001.Image = (Image) ResourceImage.LineTangential;
      else if (this.cmb_leadintype.SelectedIndex == 7)
        this.\u0001.Image = (Image) ResourceImage.LineReverseTangential;
      else if (this.cmb_leadintype.SelectedIndex == 8)
        this.\u0001.Image = (Image) ResourceImage.LineOrthogonal;
      else if (this.cmb_leadintype.SelectedIndex == 9)
        this.\u0001.Image = (Image) ResourceImage.NoImage;
      else if (this.cmb_leadintype.SelectedIndex == 10)
        this.\u0001.Image = (Image) ResourceImage.ProfileVertical;
      else if (this.cmb_leadintype.SelectedIndex == 11)
        this.\u0001.Image = (Image) ResourceImage.ProfileReverseVertical;
      else if (this.cmb_leadintype.SelectedIndex == 12)
        this.\u0001.Image = (Image) ResourceImage.LeadInPosition;
      else if (this.cmb_leadintype.SelectedIndex == 13)
        this.\u0001.Image = (Image) ResourceImage.LineSlant;
    }
    if (!(control2.Name == this.cmb_leadouttype.Name))
      return;
    if (this.cmb_leadouttype.SelectedIndex == 0)
      this.\u0001.Image = (Image) ResourceImage.ArcTangential;
    else if (this.cmb_leadouttype.SelectedIndex == 1)
      this.\u0001.Image = (Image) ResourceImage.ArcReverseTangential;
    else if (this.cmb_leadouttype.SelectedIndex == 2)
      this.\u0001.Image = (Image) ResourceImage.ArcVerticalTangential;
    else if (this.cmb_leadouttype.SelectedIndex == 3)
      this.\u0001.Image = (Image) ResourceImage.ArcReverseVerticalTangential;
    else if (this.cmb_leadouttype.SelectedIndex == 4)
      this.\u0001.Image = (Image) ResourceImage.ArcHorizontalTangential;
    else if (this.cmb_leadouttype.SelectedIndex == 5)
      this.\u0001.Image = (Image) ResourceImage.ArcOrthogonal;
    else if (this.cmb_leadouttype.SelectedIndex == 6)
      this.\u0001.Image = (Image) ResourceImage.LineTangential;
    else if (this.cmb_leadouttype.SelectedIndex == 7)
      this.\u0001.Image = (Image) ResourceImage.LineReverseTangential;
    else if (this.cmb_leadouttype.SelectedIndex == 8)
      this.\u0001.Image = (Image) ResourceImage.LineOrthogonal;
    else if (this.cmb_leadouttype.SelectedIndex == 9)
      this.\u0001.Image = (Image) ResourceImage.NoImage;
    else if (this.cmb_leadouttype.SelectedIndex == 10)
      this.\u0001.Image = (Image) ResourceImage.ProfileVertical;
    else if (this.cmb_leadouttype.SelectedIndex == 11)
      this.\u0001.Image = (Image) ResourceImage.ProfileReverseVertical;
    else if (this.cmb_leadouttype.SelectedIndex == 12)
    {
      this.\u0001.Image = (Image) ResourceImage.LeadInPosition;
    }
    else
    {
      if (this.cmb_leadouttype.SelectedIndex != 13)
        return;
      this.\u0001.Image = (Image) ResourceImage.LineSlant;
    }
  }
}
