// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_WFScan
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

public class F_WFScan : Form
{
  internal System.Windows.Forms.Label \u000F;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal System.Windows.Forms.Label \u0010;
  internal PictureBox \u0001;
  internal CheckBox \u0005;
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
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0001;
  internal NumericUpDown \u0002;
  internal System.Windows.Forms.Label \u0002;
  internal Panel \u0001;
  internal System.Windows.Forms.Label \u0003;
  internal System.Windows.Forms.Label \u0004;
  internal NumericUpDown \u0003;
  internal NumericUpDown \u0004;
  internal NumericUpDown \u0005;
  internal System.Windows.Forms.Label \u0005;
  internal Panel \u0002;
  internal Panel \u0003;
  internal Button \u0001;
  internal NumericUpDown \u0006;
  internal NumericUpDown \u0007;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal System.Windows.Forms.Label \u0006;
  internal NumericUpDown \u0008;
  internal RadioButton \u0003;
  internal RadioButton \u0004;
  internal RadioButton \u0005;
  internal RadioButton \u0006;
  internal NumericUpDown \u000E;
  internal System.Windows.Forms.Label \u0007;
  internal Panel \u0004;
  internal Panel \u0005;
  internal System.Windows.Forms.Label \u0008;
  internal System.Windows.Forms.Label \u000E;
  internal Panel \u0006;
  internal System.Windows.Forms.Label \u000F;
  internal System.Windows.Forms.Label \u0010;
  internal System.Windows.Forms.Label \u0011;
  internal Panel \u0007;
  internal System.Windows.Forms.Label \u0012;
  internal System.Windows.Forms.Label \u0013;
  internal System.Windows.Forms.Label \u0014;
  internal NumericUpDown \u000F;
  internal NumericUpDown \u0010;
  internal PictureBox \u0001;
  internal ImageList \u0002;
  internal CheckBox \u0001;
  internal NumericUpDown \u0011;
  internal System.Windows.Forms.Label \u0015;
  internal NumericUpDown \u0012;
  internal System.Windows.Forms.Label \u0016;
  internal Panel \u0008;
  internal System.Windows.Forms.Label \u0017;
  internal RadioButton \u0007;
  internal RadioButton \u0008;
  internal Panel \u000E;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_RoughLink) this).\u0004.Name)
      this.\u0001.Image = (Image) ResourceImage.EntryExitStartsFromHomePosRough;
    else if (control2.Name == ((F_RoughLink) this).\u0003.Name)
      this.\u0001.Image = (Image) ResourceImage.EntryExitReturnToHomePosRough;
    else if (control2.Name == ((F_RoughLink) this).\u0002.Name)
      this.\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == ((F_RoughLink) this).\u0001.Name)
      this.\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == ((F_RoughLink) this).cmb_arealinkswithingroup.Name)
    {
      if (((F_RoughLink) this).cmb_arealinkswithingroup.SelectedIndex == 0)
      {
        this.\u0001.Image = (Image) ResourceImage.AreaLinkWithinGroupDirectRough;
        if (this.\u0005.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_RoughLink) this).cmb_arealinkswithingroup.SelectedIndex == 1)
      {
        this.\u0001.Image = (Image) ResourceImage.AreaLinkWithinGroupBlendSplineRough;
        if (this.\u0005.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_RoughLink) this).cmb_arealinkswithingroup.SelectedIndex == 2)
      {
        this.\u0001.Image = (Image) ResourceImage.AreaLinkWithinGroupRetractToFeedDistanceRough;
        if (this.\u0005.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_RoughLink) this).cmb_arealinkswithingroup.SelectedIndex == 3)
      {
        this.\u0001.Image = (Image) ResourceImage.AreaLinkWithinGroupRetractToRapidDistanceRough;
        if (this.\u0005.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_RoughLink) this).cmb_arealinkswithingroup.SelectedIndex == 4)
      {
        this.\u0001.Image = (Image) ResourceImage.AreaLinkWithinGroupRetractToClearanceAreaRough;
        if (this.\u0005.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
    }
    else if (control2.Name == ((F_RoughLink) this).cmb_arealinkbetweengroup.Name)
    {
      if (((F_RoughLink) this).cmb_arealinkbetweengroup.SelectedIndex == 0)
      {
        this.\u0001.Image = (Image) ResourceImage.AreaLinkBetweenGroupsDirectRough;
        if (this.\u0005.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_RoughLink) this).cmb_arealinkbetweengroup.SelectedIndex == 1)
      {
        this.\u0001.Image = (Image) ResourceImage.AreaLinkBetweenGroupsBlendSplineRough;
        if (this.\u0005.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_RoughLink) this).cmb_arealinkbetweengroup.SelectedIndex == 2)
      {
        this.\u0001.Image = (Image) ResourceImage.AreaLinkBetweenGroupsRetractToFeedDistanceRough;
        if (this.\u0005.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_RoughLink) this).cmb_arealinkbetweengroup.SelectedIndex == 3)
      {
        this.\u0001.Image = (Image) ResourceImage.AreaLinkBetweenGroupsRetractToRapidDistanceRough;
        if (this.\u0005.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (((F_RoughLink) this).cmb_arealinkbetweengroup.SelectedIndex == 4)
      {
        this.\u0001.Image = (Image) ResourceImage.AreaLinkBetweenGroupsRetractToClearanceAreaRough;
        if (this.\u0005.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
    }
    this.\u0005.Checked = false;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!((F_RoughLink) this).PropertiesForm.Inited)
      return;
    ((F_RoughLink) this).ControlUpdate();
    if (control2.Name == ((F_RoughLink) this).cmb_firstentry.Name)
    {
      if (((F_RoughLink) this).cmb_firstentry.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.FirstEntryFromRapidPlaneRough;
      else if (((F_RoughLink) this).cmb_firstentry.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.FirstEntryUseRapidDistanceRough;
      else if (((F_RoughLink) this).cmb_firstentry.SelectedIndex == 2)
        this.\u0001.Image = (Image) ResourceImage.FirstEntryUseFeedDistanceRough;
    }
    if (control2.Name == ((F_RoughLink) this).cmb_firstentryramp.Name)
    {
      if (((F_RoughLink) this).cmb_firstentryramp.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.FirstEntryUseRampRough;
      else if (((F_RoughLink) this).cmb_firstentryramp.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.FirstEntryFromRapidPlaneRough;
    }
    if (control2.Name == ((F_RoughLink) this).cmb_lastexit.Name)
    {
      if (((F_RoughLink) this).cmb_lastexit.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.LastExitUseRapidPlaneRough;
      else if (((F_RoughLink) this).cmb_lastexit.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.LastExitUseRapidDistanceRough;
      else if (((F_RoughLink) this).cmb_lastexit.SelectedIndex == 2)
        this.\u0001.Image = (Image) ResourceImage.LastExitUseFeedDistanceRough;
    }
    if (control2.Name == ((F_RoughLink) this).cmb_arealinkswithingroup.Name)
    {
      if (((F_RoughLink) this).cmb_arealinkswithingroup.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.AreaLinkWithinGroupDirectRough;
      else if (((F_RoughLink) this).cmb_arealinkswithingroup.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.AreaLinkWithinGroupBlendSplineRough;
      else if (((F_RoughLink) this).cmb_arealinkswithingroup.SelectedIndex == 2)
        this.\u0001.Image = (Image) ResourceImage.AreaLinkWithinGroupRetractToFeedDistanceRough;
      else if (((F_RoughLink) this).cmb_arealinkswithingroup.SelectedIndex == 3)
        this.\u0001.Image = (Image) ResourceImage.AreaLinkWithinGroupRetractToRapidDistanceRough;
      else if (((F_RoughLink) this).cmb_arealinkswithingroup.SelectedIndex == 4)
        this.\u0001.Image = (Image) ResourceImage.AreaLinkWithinGroupRetractToClearanceAreaRough;
    }
    if (control2.Name == ((F_RoughLink) this).cmb_arealinkwithingroupramp.Name)
    {
      if (((F_RoughLink) this).cmb_arealinkwithingroupramp.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.AreaLinkWithinGroupUseRampRough;
      else if (((F_RoughLink) this).cmb_arealinkwithingroupramp.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.AreaLinkWithinGroupDontUseRampRough;
    }
    if (control2.Name == ((F_RoughLink) this).cmb_arealinkbetweengroup.Name)
    {
      if (((F_RoughLink) this).cmb_arealinkbetweengroup.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.AreaLinkBetweenGroupsDirectRough;
      else if (((F_RoughLink) this).cmb_arealinkbetweengroup.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.AreaLinkBetweenGroupsBlendSplineRough;
      else if (((F_RoughLink) this).cmb_arealinkbetweengroup.SelectedIndex == 2)
        this.\u0001.Image = (Image) ResourceImage.AreaLinkBetweenGroupsRetractToFeedDistanceRough;
      else if (((F_RoughLink) this).cmb_arealinkbetweengroup.SelectedIndex == 3)
        this.\u0001.Image = (Image) ResourceImage.AreaLinkBetweenGroupsRetractToRapidDistanceRough;
      else if (((F_RoughLink) this).cmb_arealinkbetweengroup.SelectedIndex == 4)
        this.\u0001.Image = (Image) ResourceImage.AreaLinkBetweenGroupsRetractToClearanceAreaRough;
    }
    if (control2.Name == ((F_RoughLink) this).cmb_arealinkbetweengroupramp.Name)
    {
      if (((F_RoughLink) this).cmb_arealinkbetweengroupramp.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.AreaLinkBetweenGroupsUseRampRough;
      else if (((F_RoughLink) this).cmb_arealinkbetweengroupramp.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.AreaLinkBetweenGroupsDontUseRampRough;
    }
    if (control2.Name == ((F_RoughLink) this).cmb_linkbetweenslices.Name)
    {
      if (((F_RoughLink) this).cmb_linkbetweenslices.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.LinkBetweenSliceDirectRough;
      else if (((F_RoughLink) this).cmb_linkbetweenslices.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.LinkBetweenSliceBlendSplineRough;
      else if (((F_RoughLink) this).cmb_linkbetweenslices.SelectedIndex == 2)
        this.\u0001.Image = (Image) ResourceImage.LinkBetweenSliceStepRough;
      else if (((F_RoughLink) this).cmb_linkbetweenslices.SelectedIndex == 3)
        this.\u0001.Image = (Image) ResourceImage.LinkBetweenSliceRetractToFeedDistanceRough;
      else if (((F_RoughLink) this).cmb_linkbetweenslices.SelectedIndex == 4)
        this.\u0001.Image = (Image) ResourceImage.LinkBetweenSliceRetractToRapidDistanceRough;
      else if (((F_RoughLink) this).cmb_linkbetweenslices.SelectedIndex == 5)
        this.\u0001.Image = (Image) ResourceImage.LinkBetweenSliceRetractToClearanceAreaRough;
    }
    if (control2.Name == ((F_RoughLink) this).cmb_linkbetweenslicesramp.Name)
    {
      if (((F_RoughLink) this).cmb_linkbetweenslicesramp.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.LinkBetweenSliceUseRampRough;
      else if (((F_RoughLink) this).cmb_linkbetweenslicesramp.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.LinkBetweenSliceDontUseRampRough;
    }
    if (control2.Name == ((F_RoughLink) this).cmb_linkbetweenregion.Name)
    {
      if (((F_RoughLink) this).cmb_linkbetweenregion.SelectedIndex == 0)
        this.\u0001.Image = (Image) ResourceImage.LinksBetweenRegionsDirectRough;
      else if (((F_RoughLink) this).cmb_linkbetweenregion.SelectedIndex == 1)
        this.\u0001.Image = (Image) ResourceImage.LinksBetweenRegionsBlendSplineRough;
      else if (((F_RoughLink) this).cmb_linkbetweenregion.SelectedIndex == 2)
        this.\u0001.Image = (Image) ResourceImage.LinksBetweenRegionsRetractToFeedDistanceRough;
      else if (((F_RoughLink) this).cmb_linkbetweenregion.SelectedIndex == 3)
        this.\u0001.Image = (Image) ResourceImage.LinksBetweenRegionsRetractToRapidDistanceRough;
      else if (((F_RoughLink) this).cmb_linkbetweenregion.SelectedIndex == 4)
        this.\u0001.Image = (Image) ResourceImage.LinksBetweenRegionsRetractToClearanceAreaRough;
    }
    if (!(control2.Name == ((F_RoughLink) this).cmb_linkbetweenregionrapm.Name))
      return;
    if (((F_RoughLink) this).cmb_linkbetweenregionrapm.SelectedIndex == 0)
    {
      this.\u0001.Image = (Image) ResourceImage.LinksBetweenRegionsUseRampRough;
    }
    else
    {
      if (((F_RoughLink) this).cmb_linkbetweenregionrapm.SelectedIndex != 1)
        return;
      this.\u0001.Image = (Image) ResourceImage.LinksBetweenRegionsDontUseRampRough;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_RoughLink) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_RoughLink) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_WFScan() => F_RoughLink.Captions = new List<string>();

  public F_WFScan() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.\u0001.Visible = this.PropertiesForm.ShowHelp;
    this.\u0007.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.DepthStep;
    this.\u0006.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRoughingParams.NumberOfSlices4DepthStep;
    this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.FeedRate;
    this.\u0002.Value = (Decimal) this.mwCamParameter.MachParam.PlungeFeedRate;
    this.\u000F.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.RetractPlaneIncremental;
    this.\u0010.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.ClearancePlaneHeight;
    this.\u0004.Value = (Decimal) this.buCamParameter.Steps.EndValue;
    this.\u0003.Value = (Decimal) this.buCamParameter.Steps.StartValue;
    this.\u0008.Value = (Decimal) this.buCamParameter.Operations.Height;
    this.\u000E.Value = (Decimal) this.buCamParameter.Speeds.SpindleSpeed;
    this.\u0005.Value = (Decimal) this.buCamParameter.Hatch.XDirectionLength;
    this.\u0011.Value = (Decimal) this.buCamParameter.Hatch.YDirectionWidth;
    this.\u0012.Value = (Decimal) this.buCamParameter.Hatch.CutStep;
    ((F_WFSpin) this).\u0014.Value = (Decimal) this.buCamParameter.Hatch.CornerPoint.X;
    ((F_WFSpin) this).\u0013.Value = (Decimal) this.buCamParameter.Hatch.CornerPoint.Y;
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
    if (this.buCamParameter.Hatch.CuttingDirection == CamHatchCuttingDirection.XDirection)
    {
      ((F_WFSpin) this).\u000F.Checked = true;
      ((F_WFSpin) this).\u000E.Checked = false;
    }
    else
    {
      ((F_WFSpin) this).\u000F.Checked = false;
      ((F_WFSpin) this).\u000E.Checked = true;
    }
    if (this.buCamParameter.Hatch.CuttingModes == CamHatchCuttingMode.Forward)
    {
      this.\u0008.Checked = true;
      this.\u0007.Checked = false;
      ((F_WFSpin) this).\u0010.Checked = false;
    }
    else if (this.buCamParameter.Hatch.CuttingModes == CamHatchCuttingMode.ForwardBackward)
    {
      this.\u0008.Checked = false;
      this.\u0007.Checked = true;
      ((F_WFSpin) this).\u0010.Checked = false;
    }
    else
    {
      this.\u0008.Checked = false;
      this.\u0007.Checked = false;
      ((F_WFSpin) this).\u0010.Checked = true;
    }
    this.Configration.Mode = CamMode.WireFrame;
    this.Configration.CamWireframeType = CamWireFrameType.Contour;
    this.Refresh();
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
    \u0005.\u0002.\u0001(this);
    this.ControlUpdate();
  }

  public void ControlUpdate()
  {
    if (this.\u0003.Checked)
    {
      this.\u0004.Enabled = true;
      this.\u0003.Enabled = false;
    }
    else
    {
      this.\u0004.Enabled = false;
      this.\u0003.Enabled = true;
    }
    if (this.\u0002.Checked)
    {
      this.\u0007.Enabled = true;
      this.\u0006.Enabled = false;
    }
    else
    {
      this.\u0007.Enabled = false;
      this.\u0006.Enabled = true;
    }
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
    if (!(control2.Name == this.\u0001.Name))
      return;
    F_DepthStepAdvanced depthStepAdvanced = new F_DepthStepAdvanced()
    {
      mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
    };
    depthStepAdvanced.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
    depthStepAdvanced.buCamParameter = new camParameters5(this.buCamParameter);
    depthStepAdvanced.Init();
    int num = (int) depthStepAdvanced.ShowDialog();
    if (depthStepAdvanced.PropertiesForm.Result != DialogResult.OK)
      return;
    this.mwCamParameter.MachParam = new MachiningParams(depthStepAdvanced.mwCamParameter.MachParam);
    this.buCamParameter = new camParameters5(depthStepAdvanced.buCamParameter);
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
    if (!(this.PropertiesForm.TouchPad & !this.\u0001.Checked))
      return;
    NumericUpDown numericUpDown = new NumericUpDown();
    NumericUpDown Ctrl = (NumericUpDown) obj0;
    if (!Ctrl.Enabled)
      return;
    buControlCommands.ShowKeyPadWinControl((Form) this, (Control) Ctrl);
  }
}
