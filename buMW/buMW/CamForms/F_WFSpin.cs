// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_WFSpin
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buControls;
using buControls.Forms.WinControlForms.Views;
using buEyeBaseVer5;
using buEyeBaseVer5.Forms;
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

public class F_WFSpin : Form
{
  internal System.Windows.Forms.Label \u0018;
  internal RadioButton \u000E;
  internal RadioButton \u000F;
  internal RadioButton \u0010;
  internal NumericUpDown \u0013;
  internal System.Windows.Forms.Label \u0019;
  internal NumericUpDown \u0014;
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
  internal ComboBox \u0001;
  internal System.Windows.Forms.Label \u0001;
  internal CheckBox \u0001;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal NumericUpDown \u0002;
  internal System.Windows.Forms.Label \u0003;
  internal NumericUpDown \u0003;
  internal System.Windows.Forms.Label \u0004;
  internal Panel \u0001;
  internal System.Windows.Forms.Label \u0005;
  internal System.Windows.Forms.Label \u0006;
  internal NumericUpDown \u0004;
  internal NumericUpDown \u0005;
  internal NumericUpDown \u0006;
  internal System.Windows.Forms.Label \u0007;
  internal ComboBox \u0002;
  internal System.Windows.Forms.Label \u0008;
  internal Panel \u0002;
  internal Button \u0001;
  internal NumericUpDown \u0007;
  internal System.Windows.Forms.Label \u000E;
  internal Panel \u0003;
  internal Panel \u0004;
  internal Button \u0002;
  internal NumericUpDown \u0008;
  internal NumericUpDown \u000E;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal System.Windows.Forms.Label \u000F;
  internal NumericUpDown \u000F;
  internal RadioButton \u0003;
  internal RadioButton \u0004;
  internal RadioButton \u0005;
  internal RadioButton \u0006;
  internal NumericUpDown \u0010;
  internal System.Windows.Forms.Label \u0010;
  internal Panel \u0005;
  internal ComboBox \u0003;
  internal System.Windows.Forms.Label \u0011;
  internal Panel \u0006;
  internal System.Windows.Forms.Label \u0012;
  internal System.Windows.Forms.Label \u0013;
  internal System.Windows.Forms.Label \u0014;
  internal Panel \u0007;
  internal System.Windows.Forms.Label \u0015;
  internal System.Windows.Forms.Label \u0016;
  internal System.Windows.Forms.Label \u0017;
  internal Panel \u0008;
  internal Button \u0003;
  internal System.Windows.Forms.Label \u0018;
  internal NumericUpDown \u0011;
  internal System.Windows.Forms.Label \u0019;
  internal System.Windows.Forms.Label \u001A;
  internal System.Windows.Forms.Label \u001B;
  internal NumericUpDown \u0012;
  internal System.Windows.Forms.Label \u001C;
  internal NumericUpDown \u0013;
  internal NumericUpDown \u0014;
  internal PictureBox \u0001;
  internal ImageList \u0002;
  internal CheckBox \u0002;
  internal Panel \u000E;
  internal System.Windows.Forms.Label \u001D;
  internal CheckBox \u0003;
  internal Panel \u000F;
  internal Button \u0004;
  internal System.Windows.Forms.Label \u001E;
  public ComboBox cmb_leadouttype;
  internal System.Windows.Forms.Label \u001F;
  internal CheckBox \u0004;
  internal Button \u0005;
  internal System.Windows.Forms.Label \u007F;
  public ComboBox cmb_leadintype;
  internal NumericUpDown \u0015;
  internal CheckBox \u0005;
  internal Panel \u0010;
  internal System.Windows.Forms.Label \u0080;
  internal NumericUpDown \u0016;
  internal System.Windows.Forms.Label \u0081;
  internal CheckBox \u0006;
  internal System.Windows.Forms.Label \u0082;
  internal ComboBox \u0004;
  internal Button \u0006;

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_WFScan) this).\u0005.Name)
    {
      ((F_WFScan) this).\u0001.Image = (Image) ResourceImage.Offset;
      if (((F_WFScan) this).\u0001.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_WFScan) this).\u0008.Name)
      ((F_WFScan) this).\u0001.Image = (Image) ResourceImage.ConstantHeight;
    else if (control2.Name == ((F_WFScan) this).\u0003.Name)
      ((F_WFScan) this).\u0001.Image = (Image) ResourceImage.StartHeight;
    else if (control2.Name == ((F_WFScan) this).\u0004.Name)
      ((F_WFScan) this).\u0001.Image = (Image) ResourceImage.EndHeight;
    else if (control2.Name == ((F_WFScan) this).\u0002.Name)
      ((F_WFScan) this).\u0001.Image = (Image) ResourceImage.ContantDepthStepMode;
    else if (control2.Name == ((F_WFScan) this).\u0001.Name)
      ((F_WFScan) this).\u0001.Image = (Image) ResourceImage.NumberOfSliceMode;
    else if (control2.Name == ((F_WFScan) this).\u0006.Name)
      ((F_WFScan) this).\u0001.Image = (Image) ResourceImage.NumberOfSliceMode;
    else if (control2.Name == ((F_WFScan) this).\u0007.Name)
      ((F_WFScan) this).\u0001.Image = (Image) ResourceImage.ConstantDepth;
    else if (control2.Name == ((F_WFScan) this).\u0004.Name)
      ((F_WFScan) this).\u0001.Image = (Image) ResourceImage.StepDepth;
    else if (control2.Name == ((F_WFScan) this).\u0003.Name)
      ((F_WFScan) this).\u0001.Image = (Image) ResourceImage.ConstantDepth;
    else if (control2.Name == ((F_WFScan) this).\u0001.Name)
    {
      ((F_WFScan) this).\u0001.Image = (Image) ResourceImage.FeedRate;
      if (((F_WFScan) this).\u0001.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_WFScan) this).\u0002.Name)
    {
      ((F_WFScan) this).\u0001.Image = (Image) ResourceImage.PlungeRate;
      if (((F_WFScan) this).\u0001.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_WFScan) this).\u0010.Name)
      ((F_WFScan) this).\u0001.Image = (Image) ResourceImage.SafeDistance;
    else if (control2.Name == ((F_WFScan) this).\u000F.Name)
      ((F_WFScan) this).\u0001.Image = (Image) ResourceImage.RapidDistance;
    else if (control2.Name == ((F_WFScan) this).\u000E.Name)
    {
      if (((F_WFScan) this).\u0005.Checked)
        ((F_WFScan) this).\u0001.Image = (Image) ResourceImage.SpindleCCW;
      else
        ((F_WFScan) this).\u0001.Image = (Image) ResourceImage.SpindleCW;
    }
    else if (control2.Name == ((F_WFScan) this).\u0005.Name)
      ((F_WFScan) this).\u0001.Image = (Image) ResourceImage.SpindleCCW;
    else if (control2.Name == ((F_WFScan) this).\u0006.Name)
      ((F_WFScan) this).\u0001.Image = (Image) ResourceImage.SpindleCW;
    ((F_WFScan) this).\u0001.Checked = false;
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1) => ((F_WFScan) this).ControlUpdate();

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_WFScan) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_WFScan) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_WFSpin() => F_WFScan.Captions = new List<string>();

  public F_WFSpin() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.\u0002.Visible = this.PropertiesForm.ShowHelp;
    this.\u000E.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.DepthStep;
    this.\u0008.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.NumberOfSlices4DepthStep;
    this.\u0007.Value = (Decimal) this.mwCamParameter.MachParam.CutTolerance;
    this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.FeedRate;
    this.\u0002.Value = (Decimal) this.mwCamParameter.MachParam.PlungeFeedRate;
    this.\u0003.Value = (Decimal) this.mwCamParameter.MachParam.RetractFeedRate;
    this.\u0012.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.ApproachFeedPlaneIncremental;
    this.\u0013.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.RetractPlaneIncremental;
    this.\u0014.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.ClearancePlaneHeight;
    this.\u0011.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.AirMoveSafetyDistance;
    this.\u0005.Value = (Decimal) this.buCamParameter.Steps.EndValue;
    this.\u0004.Value = (Decimal) this.buCamParameter.Steps.StartValue;
    this.\u000F.Value = (Decimal) this.buCamParameter.Operations.Height;
    this.\u0006.Value = (Decimal) this.mwCamParameter.MachParam.StockRemain;
    this.\u0010.Value = (Decimal) this.buCamParameter.Speeds.SpindleSpeed;
    ((F_WFContour4AX) this).\u0018.Value = (Decimal) this.buCamParameter.Strategy.SpinCStartAngle;
    ((F_WFContour4AX) this).\u0017.Value = (Decimal) this.buCamParameter.Strategy.SpinCEndAngle;
    this.\u0016.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharedMiscParams.OverlapLength;
    this.\u0001.Checked = this.mwCamParameter.MachParam.RapidRetractFlg;
    this.\u0005.Checked = this.mwCamParameter.MachParam.RapidFeedFlg;
    this.\u0006.Checked = this.buCamParameter.Offsets.AddToolDiameterAsOffset;
    if (!this.buCamParameter.Operations.isClosed)
    {
      this.\u0001.Items.Clear();
      this.\u0001.Items.Add((object) buMWCaptions.CamOpenContourType[0]);
      this.\u0001.Items.Add((object) buMWCaptions.CamOpenContourType[1]);
      this.\u0001.Items.Add((object) buMWCaptions.CamOpenContourType[2]);
      if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide == WireframeBasedTpCalcParamsCuttingSide.WfbCsLeft)
        this.\u0001.SelectedIndex = 0;
      else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide == WireframeBasedTpCalcParamsCuttingSide.WfbCsRight)
        this.\u0001.SelectedIndex = 2;
      else
        this.\u0001.SelectedIndex = 1;
      if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CutterRadiusCompParams.CompensationType == CutterRadiusCompParamsCompensationType.CtOff)
        this.\u0001.SelectedIndex = 1;
    }
    else
    {
      this.\u0001.Items.Clear();
      this.\u0001.Items.Add((object) buMWCaptions.CamClosedContourType[0]);
      this.\u0001.Items.Add((object) buMWCaptions.CamClosedContourType[1]);
      this.\u0001.Items.Add((object) buMWCaptions.CamClosedContourType[2]);
      if (this.buCamParameter.Offsets.ClosedContour == CamClosedContourType.Inner)
        this.\u0001.SelectedIndex = 0;
      else if (this.buCamParameter.Offsets.ClosedContour == CamClosedContourType.Outter)
        this.\u0001.SelectedIndex = 2;
      else
        this.\u0001.SelectedIndex = 1;
      if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CutterRadiusCompParams.CompensationType == CutterRadiusCompParamsCompensationType.CtOff)
        this.\u0001.SelectedIndex = 1;
    }
    this.\u0002.Items.Clear();
    this.\u0002.Items.Add((object) buMWCaptions.MachiningParamsMachType[0]);
    this.\u0002.Items.Add((object) buMWCaptions.MachiningParamsMachType[1]);
    this.\u0002.Items.Add((object) buMWCaptions.MachiningParamsMachType[2]);
    if (this.mwCamParameter.MachParam.CurMachType == MachiningParamsMachType.MachtypeOneway)
      this.\u0002.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.CurMachType == MachiningParamsMachType.MachtypeZigzag)
      this.\u0002.SelectedIndex = 1;
    else
      this.\u0002.SelectedIndex = 2;
    this.\u0003.Items.Clear();
    this.\u0003.Items.Add((object) buMWCaptions.MachiningParamsMachiningAreaMode[0]);
    this.\u0003.Items.Add((object) buMWCaptions.MachiningParamsMachiningAreaMode[1]);
    if (this.mwCamParameter.MachParam.MachiningAreaMode == MachiningParamsMachiningAreaMode.MachByLanes)
      this.\u0003.SelectedIndex = 0;
    else
      this.\u0003.SelectedIndex = 1;
    this.\u0004.Items.Clear();
    this.\u0004.Items.Add((object) buMWCaptions.ClockDirectionType[0]);
    this.\u0004.Items.Add((object) buMWCaptions.ClockDirectionType[1]);
    if (this.buCamParameter.Operations.Direction == ClockDirectionType.CW)
      this.\u0004.SelectedIndex = 0;
    else if (this.buCamParameter.Operations.Direction == ClockDirectionType.CCW)
      this.\u0004.SelectedIndex = 1;
    if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.DepthStepMode == MachiningAreaRoughingParamsDepthStepMode.DsmConstantDepthStep)
    {
      this.\u0002.Checked = true;
      this.\u0001.Checked = false;
    }
    else
    {
      this.\u0002.Checked = false;
      this.\u0001.Checked = true;
    }
    if (!this.buCamParameter.Steps.Enable)
    {
      this.\u0003.Checked = true;
      this.\u0004.Checked = false;
    }
    else
    {
      this.\u0003.Checked = false;
      this.\u0004.Checked = true;
    }
    if (this.buCamParameter.Speeds.SpindleDirection == ClockDirectionType.CW)
    {
      this.\u0006.Checked = true;
      this.\u0005.Checked = false;
    }
    else
    {
      this.\u0006.Checked = false;
      this.\u0005.Checked = true;
    }
    this.\u0003.Checked = this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.IsUsed;
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
    this.Configration.Mode = CamMode.WireFrame;
    this.Configration.CamWireframeType = CamWireFrameType.Contour;
    if (!this.buCamParameter.Operations.isClosed)
    {
      this.\u0001.Image = (Image) ResourceImage.wireframeProfile2DOpen;
      this.Icon = ResourceIcon.CamContourOpenCenter2;
    }
    else
    {
      this.\u0001.Image = (Image) ResourceImage.wireframeProfile2DClosed;
      this.Icon = ResourceIcon.CamContourCenter2;
    }
    this.Refresh();
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
    \u0005.\u0002.\u0001(this);
    this.ControlUpdate();
  }

  public void ControlUpdate()
  {
    if (!this.buCamParameter.Operations.isClosed)
    {
      this.\u0082.Visible = false;
      this.\u0004.Visible = false;
      this.\u0080.Visible = false;
      this.\u0016.Visible = false;
    }
    else
    {
      this.\u0082.Visible = true;
      this.\u0004.Visible = true;
      this.\u0080.Visible = true;
      this.\u0016.Visible = true;
    }
    this.\u0015.Enabled = this.\u0005.Checked;
    if (this.\u0003.Checked)
    {
      this.\u0005.Enabled = true;
      this.\u0004.Enabled = false;
    }
    else
    {
      this.\u0005.Enabled = false;
      this.\u0004.Enabled = true;
    }
    if (this.\u0002.Checked)
    {
      this.\u000E.Enabled = true;
      this.\u0008.Enabled = false;
    }
    else
    {
      this.\u000E.Enabled = false;
      this.\u0008.Enabled = true;
    }
    this.\u0005.Enabled = this.\u0003.Checked;
    this.cmb_leadintype.Enabled = this.\u0003.Checked;
    this.\u007F.Enabled = this.\u0003.Checked;
    this.\u0004.Enabled = this.\u0004.Checked;
    this.cmb_leadouttype.Enabled = this.\u0004.Checked;
    this.\u001E.Enabled = this.\u0004.Checked;
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
    if (control2.Name == ((F_WFContour4AX) this).\u0007.Name)
    {
      F_SortingSettings fSortingSettings = new F_SortingSettings();
      fSortingSettings.SortSetting = new SortSettings(this.buCamParameter.Sorting);
      fSortingSettings.Init();
      int num = (int) fSortingSettings.ShowDialog();
      if (fSortingSettings.PropertiesForm.Result == DialogResult.OK)
        this.buCamParameter.Sorting = new SortSettings(fSortingSettings.SortSetting);
    }
    if (control2.Name == this.\u0002.Name)
    {
      F_DepthStepAdvanced depthStepAdvanced = new F_DepthStepAdvanced()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      depthStepAdvanced.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      depthStepAdvanced.buCamParameter = new camParameters5(this.buCamParameter);
      depthStepAdvanced.Init();
      int num = (int) depthStepAdvanced.ShowDialog();
      if (depthStepAdvanced.PropertiesForm.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(depthStepAdvanced.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(depthStepAdvanced.buCamParameter);
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
      fSurfaceQuality.Init();
      int num = (int) fSurfaceQuality.ShowDialog();
      if (fSurfaceQuality.Properties.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(fSurfaceQuality.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(fSurfaceQuality.buCamParameter);
      }
    }
    if (control2.Name == this.\u0006.Name)
    {
      F_ContourLink fContourLink = new F_ContourLink()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      fContourLink.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      fContourLink.buCamParameter = new camParameters5(this.buCamParameter);
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
        this.\u0003.Checked = this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.IsUsed;
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
    if (control2.Name == this.\u0003.Name)
    {
      F_HeightAdvanced fHeightAdvanced = new F_HeightAdvanced()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      fHeightAdvanced.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      fHeightAdvanced.buCamParameter = new camParameters5(this.buCamParameter);
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
        this.\u0003.Checked = this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.IsUsed;
      }
    }
    if (!(control2.Name == this.\u0004.Name))
      return;
    F_LeadControl fLeadControl1 = new F_LeadControl();
    fLeadControl1.mwCamLeadController = this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController;
    fLeadControl1.buCamParameter = new camParameters5(this.buCamParameter);
    fLeadControl1.Init();
    int num1 = (int) fLeadControl1.ShowDialog();
    if (fLeadControl1.Properties.Result != DialogResult.OK)
      return;
    this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController = fLeadControl1.mwCamLeadController;
    this.buCamParameter = new camParameters5(fLeadControl1.buCamParameter);
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

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (!(this.PropertiesForm.TouchPad & !this.\u0002.Checked))
      return;
    NumericUpDown numericUpDown = new NumericUpDown();
    NumericUpDown Ctrl = (NumericUpDown) obj0;
    if (!Ctrl.Enabled)
      return;
    buControlCommands.ShowKeyPadWinControl((Form) this, (Control) Ctrl);
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1) => this.ControlUpdate();

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!this.PropertiesForm.Inited)
      return;
    this.ControlUpdate();
    if (control2.Name == this.\u0001.Name)
    {
      if (!this.buCamParameter.Operations.isClosed)
      {
        if (this.\u0001.SelectedIndex == 0)
          this.\u0001.Image = (Image) ResourceImage.OffsetOpenLeft;
        else if (this.\u0001.SelectedIndex == 1)
          this.\u0001.Image = (Image) ResourceImage.OffsetOpenCenter;
        else if (this.\u0001.SelectedIndex == 2)
          this.\u0001.Image = (Image) ResourceImage.OffsetOpenRight;
      }
      else if (this.\u0001.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.OffsetInside;
      else if (this.\u0001.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.OffsetCenter;
      else if (this.\u0001.SelectedIndex == 2)
        this.\u0001.Image = (Image) ResourceImage.OffsetOutside;
    }
    if (control2.Name == this.\u0004.Name)
    {
      if (this.\u0004.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.ContourCW;
      else if (this.\u0004.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.ContourCCW;
    }
    if (control2.Name == this.\u0002.Name)
    {
      if (this.\u0002.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.SortOneway;
      else if (this.\u0002.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.SortZigzag;
      else if (this.\u0002.SelectedIndex == 2)
        this.\u0001.Image = (Image) ResourceImage.SortSpiral;
    }
    if (control2.Name == this.\u0003.Name)
    {
      if (this.\u0003.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.GroupLevel;
      else if (this.\u0003.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.GroupRegion;
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
