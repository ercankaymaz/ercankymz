// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_LeadControl
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buControls.Forms.WinControlForms.Views;
using buEyeBaseVer5;
using buImages;
using ModuleWorks.ToolpathParameters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW.CamForms;

public class F_LeadControl : Form
{
  internal Panel \u0005;
  internal CheckBox \u000F;
  internal Label \u0005;
  internal NumericUpDown \u0008;
  internal NumericUpDown \u000E;
  internal CheckBox \u0010;
  internal Label \u0006;
  public static byte f000D6F;
  public FormProperties Properties = new FormProperties();
  public LeadController mwCamLeadController = (LeadController) null;
  public camParameters5 buCamParameter = (camParameters5) null;
  public ToolBase5 Tool = (ToolBase5) null;
  public MWCalculationOptions Configration = new MWCalculationOptions();
  public static List<string> Captions;
  internal IContainer \u0001 = (IContainer) null;
  public ComboBox cmb_leadtype;
  internal Label \u0001;
  internal CheckBox \u0001;
  public ComboBox cmb_axisorientation;
  internal Label \u0002;
  internal Label \u0003;
  internal NumericUpDown \u0001;
  internal RadioButton \u0001;
  internal Panel \u0001;
  internal NumericUpDown \u0002;
  internal Label \u0004;
  internal NumericUpDown \u0003;
  internal Label \u0005;
  internal NumericUpDown \u0004;
  internal Label \u0006;
  internal NumericUpDown \u0005;
  internal Label \u0007;
  internal Panel \u0002;
  internal NumericUpDown \u0006;
  internal Label \u0008;
  internal NumericUpDown \u0007;
  internal Label \u000E;
  internal RadioButton \u0002;
  internal NumericUpDown \u0008;
  internal Label \u000F;
  internal NumericUpDown \u000E;
  internal Label \u0010;
  public ComboBox cmb_extensiontype;
  internal Label \u0011;
  internal Panel \u0003;
  internal Panel \u0004;
  internal NumericUpDown \u000F;
  internal Label \u0012;
  internal NumericUpDown \u0010;
  internal Label \u0013;
  internal Panel \u0005;
  internal NumericUpDown \u0011;
  internal Label \u0014;
  internal NumericUpDown \u0012;
  internal Label \u0015;
  internal Label \u0016;
  internal RadioButton \u0003;
  internal RadioButton \u0004;
  internal CheckBox \u0002;
  internal Label \u0017;
  internal Panel \u0006;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_DepthStepAdvanced) this).PropertiesForm.Inited)
      return;
    ((F_DepthStepAdvanced) this).PropertiesForm.Inited = false;
    ((F_DepthStepAdvanced) this).Apply();
    ((F_DepthStepAdvanced) this).ControlUpdate();
    ((F_DepthStepAdvanced) this).PropertiesForm.Inited = true;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_DepthStepAdvanced) this).\u0001.Name)
    {
      ((F_DepthStepAdvanced) this).\u0001.Image = (Image) ResourceImage.NoImage;
      if (!((F_DepthStepAdvanced) this).\u0004.Checked)
        return;
      F_GifView fGifView = new F_GifView();
      fGifView.Init();
      fGifView.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fGifView.ShowDialog();
    }
    else if (control2.Name == ((F_DepthStepAdvanced) this).\u0002.Name)
    {
      ((F_DepthStepAdvanced) this).\u0001.Image = (Image) ResourceImage.NoImage;
      if (!((F_DepthStepAdvanced) this).\u0004.Checked)
        return;
      F_GifView fGifView = new F_GifView();
      fGifView.Init();
      fGifView.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fGifView.ShowDialog();
    }
    else if (control2.Name == ((F_DepthStepAdvanced) this).\u0003.Name)
      ((F_DepthStepAdvanced) this).\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == ((F_DepthStepAdvanced) this).\u0004.Name)
      ((F_DepthStepAdvanced) this).\u0001.Image = (Image) ResourceImage.MaxStepoverConstantZ;
    else if (control2.Name == ((F_DepthStepAdvanced) this).\u0007.Name)
      ((F_DepthStepAdvanced) this).\u0001.Image = (Image) ResourceImage.ContantDepthStepMode;
    else if (control2.Name == ((F_DepthStepAdvanced) this).\u0006.Name)
      ((F_DepthStepAdvanced) this).\u0001.Image = (Image) ResourceImage.NumberOfSliceMode;
    else if (control2.Name == ((F_DepthStepAdvanced) this).\u0005.Name)
    {
      ((F_DepthStepAdvanced) this).\u0001.Image = (Image) ResourceImage.NoImage;
      if (!((F_DepthStepAdvanced) this).\u0004.Checked)
        return;
      F_GifView fGifView = new F_GifView();
      fGifView.Init();
      fGifView.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fGifView.ShowDialog();
    }
    else if (control2.Name == this.\u000E.Name)
      ((F_DepthStepAdvanced) this).\u0001.Image = (Image) ResourceImage.MinWidthFlatlands;
    else if (control2.Name == this.\u0008.Name)
    {
      ((F_DepthStepAdvanced) this).\u0001.Image = (Image) ResourceImage.MaxWidthFlatlands;
      if (!((F_DepthStepAdvanced) this).\u0004.Checked)
        return;
      F_GifView fGifView = new F_GifView();
      fGifView.Init();
      fGifView.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fGifView.ShowDialog();
    }
    else if (control2.Name == ((F_DepthStepAdvanced) this).\u0002.Name)
    {
      ((F_DepthStepAdvanced) this).\u0001.Image = (Image) ResourceImage.NoImage;
      if (!((F_DepthStepAdvanced) this).\u0004.Checked)
        return;
      F_GifView fGifView = new F_GifView();
      fGifView.Init();
      fGifView.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fGifView.ShowDialog();
    }
    else if (control2.Name == ((F_DepthStepAdvanced) this).\u0003.Name)
    {
      ((F_DepthStepAdvanced) this).\u0001.Image = (Image) ResourceImage.NoImage;
      if (!((F_DepthStepAdvanced) this).\u0004.Checked)
        return;
      F_GifView fGifView = new F_GifView();
      fGifView.Init();
      fGifView.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fGifView.ShowDialog();
    }
    else if (control2.Name == ((F_DepthStepAdvanced) this).\u0001.Name)
    {
      ((F_DepthStepAdvanced) this).\u0001.Image = (Image) ResourceImage.NoImage;
      if (!((F_DepthStepAdvanced) this).\u0004.Checked)
        return;
      F_GifView fGifView = new F_GifView();
      fGifView.Init();
      fGifView.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fGifView.ShowDialog();
    }
    else if (control2.Name == ((F_DepthStepAdvanced) this).\u0008.Name)
    {
      ((F_DepthStepAdvanced) this).\u0001.Image = (Image) ResourceImage.MachineFlatlandsConstantZ;
      if (((F_DepthStepAdvanced) this).\u0008.Checked)
      {
        if (!((F_DepthStepAdvanced) this).\u0004.Checked)
          return;
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
      else
      {
        if (!((F_DepthStepAdvanced) this).\u0004.Checked)
          return;
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_DepthStepAdvanced) this).\u0007.Name)
      ((F_DepthStepAdvanced) this).\u0001.Image = (Image) ResourceImage.MachineVerticalWallsConstantZ;
    else if (control2.Name == ((F_DepthStepAdvanced) this).\u0006.Name)
    {
      ((F_DepthStepAdvanced) this).\u0001.Image = (Image) ResourceImage.AdaptiveDeptStep;
      if (!((F_DepthStepAdvanced) this).\u0004.Checked)
        return;
      F_GifView fGifView = new F_GifView();
      fGifView.Init();
      fGifView.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fGifView.ShowDialog();
    }
    else if (control2.Name == ((F_DepthStepAdvanced) this).\u0005.Name)
    {
      ((F_DepthStepAdvanced) this).\u0001.Image = (Image) ResourceImage.NoImage;
      if (!((F_DepthStepAdvanced) this).\u0004.Checked)
        return;
      F_GifView fGifView = new F_GifView();
      fGifView.Init();
      fGifView.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fGifView.ShowDialog();
    }
    else if (control2.Name == ((F_DepthStepAdvanced) this).\u000E.Name)
    {
      ((F_DepthStepAdvanced) this).\u0001.Image = (Image) ResourceImage.IntermediateSlices;
      if (!((F_DepthStepAdvanced) this).\u0004.Checked)
        return;
      F_GifView fGifView = new F_GifView();
      fGifView.Init();
      fGifView.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fGifView.ShowDialog();
    }
    else if (control2.Name == this.\u0010.Name)
    {
      ((F_DepthStepAdvanced) this).\u0001.Image = (Image) ResourceImage.MachineFlatlandsConstantZ;
      if (((F_DepthStepAdvanced) this).\u0008.Checked)
      {
        if (!((F_DepthStepAdvanced) this).\u0004.Checked)
          return;
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
      else
      {
        if (!((F_DepthStepAdvanced) this).\u0004.Checked)
          return;
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == this.\u000F.Name)
      ((F_DepthStepAdvanced) this).\u0001.Image = (Image) ResourceImage.MinWidthFlatlands;
    else if (control2.Name == ((F_DepthStepAdvanced) this).\u0002.Name)
    {
      ((F_DepthStepAdvanced) this).\u0001.Image = (Image) ResourceImage.ContantDepthStepMode;
    }
    else
    {
      if (!(control2.Name == ((F_DepthStepAdvanced) this).\u0001.Name))
        return;
      ((F_DepthStepAdvanced) this).\u0001.Image = (Image) ResourceImage.NumberOfSliceMode;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_DepthStepAdvanced) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_DepthStepAdvanced) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_LeadControl() => F_DepthStepAdvanced.Captions = new List<string>();

  public F_LeadControl() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.cmb_leadtype.Items.Clear();
    this.cmb_leadtype.Items.Add((object) buMWCaptions.LeadParamsType[0]);
    this.cmb_leadtype.Items.Add((object) buMWCaptions.LeadParamsType[1]);
    this.cmb_leadtype.Items.Add((object) buMWCaptions.LeadParamsType[2]);
    this.cmb_leadtype.Items.Add((object) buMWCaptions.LeadParamsType[8]);
    this.cmb_leadtype.Items.Add((object) buMWCaptions.LeadParamsType[3]);
    this.cmb_leadtype.Items.Add((object) buMWCaptions.LeadParamsType[4]);
    this.cmb_leadtype.Items.Add((object) buMWCaptions.LeadParamsType[5]);
    this.cmb_leadtype.Items.Add((object) buMWCaptions.LeadParamsType[7]);
    this.cmb_leadtype.Items.Add((object) buMWCaptions.LeadParamsType[6]);
    this.cmb_leadtype.Items.Add((object) buMWCaptions.LeadParamsType[14]);
    this.cmb_leadtype.Items.Add((object) buMWCaptions.LeadParamsType[11]);
    this.cmb_leadtype.Items.Add((object) buMWCaptions.LeadParamsType[9]);
    this.cmb_leadtype.Items.Add((object) buMWCaptions.LeadParamsType[10]);
    this.cmb_leadtype.Items.Add((object) buMWCaptions.LeadParamsType[19]);
    if (this.mwCamLeadController.LeadParams.Type == LeadParamsType.TangentialArc)
      this.cmb_leadtype.SelectedIndex = 0;
    else if (this.mwCamLeadController.LeadParams.Type == LeadParamsType.ReverseTangArc)
      this.cmb_leadtype.SelectedIndex = 1;
    else if (this.mwCamLeadController.LeadParams.Type == LeadParamsType.VerticalTangArc)
      this.cmb_leadtype.SelectedIndex = 2;
    else if (this.mwCamLeadController.LeadParams.Type == LeadParamsType.ReverseVertTangArc)
      this.cmb_leadtype.SelectedIndex = 3;
    else if (this.mwCamLeadController.LeadParams.Type == LeadParamsType.HorizontalTangArc)
      this.cmb_leadtype.SelectedIndex = 4;
    else if (this.mwCamLeadController.LeadParams.Type == LeadParamsType.OrthogonalArc)
      this.cmb_leadtype.SelectedIndex = 5;
    else if (this.mwCamLeadController.LeadParams.Type == LeadParamsType.TangentialLine)
      this.cmb_leadtype.SelectedIndex = 6;
    else if (this.mwCamLeadController.LeadParams.Type == LeadParamsType.ReverseTangLine)
      this.cmb_leadtype.SelectedIndex = 7;
    else if (this.mwCamLeadController.LeadParams.Type == LeadParamsType.OrthogonalLine)
      this.cmb_leadtype.SelectedIndex = 8;
    else if (this.mwCamLeadController.LeadParams.Type == LeadParamsType.ReverseOrthogonalLine)
      this.cmb_leadtype.SelectedIndex = 9;
    else if (this.mwCamLeadController.LeadParams.Type == LeadParamsType.VertProfileRamp)
      this.cmb_leadtype.SelectedIndex = 10;
    else if (this.mwCamLeadController.LeadParams.Type == LeadParamsType.ReverseVertProfileRamp)
      this.cmb_leadtype.SelectedIndex = 11;
    else if (this.mwCamLeadController.LeadParams.Type == LeadParamsType.PositionLine)
      this.cmb_leadtype.SelectedIndex = 12;
    else if (this.mwCamLeadController.LeadParams.Type == LeadParamsType.SlantLine)
      this.cmb_leadtype.SelectedIndex = 13;
    this.cmb_axisorientation.Items.Clear();
    this.cmb_axisorientation.Items.Add((object) buMWCaptions.LeadParamsAxisOrientation[0]);
    this.cmb_axisorientation.Items.Add((object) buMWCaptions.LeadParamsAxisOrientation[1]);
    if (this.mwCamLeadController.LeadParams.AxisOrientation == LeadParamsAxisOrientation.Fixed)
      this.cmb_axisorientation.SelectedIndex = 0;
    else if (this.mwCamLeadController.LeadParams.AxisOrientation == LeadParamsAxisOrientation.Tangential)
      this.cmb_axisorientation.SelectedIndex = 1;
    this.cmb_extensiontype.Items.Clear();
    this.cmb_extensiontype.Items.Add((object) buMWCaptions.LeadExtensionParamsType[0]);
    this.cmb_extensiontype.Items.Add((object) buMWCaptions.LeadExtensionParamsType[3]);
    this.cmb_extensiontype.Items.Add((object) buMWCaptions.LeadExtensionParamsType[2]);
    this.cmb_extensiontype.Items.Add((object) buMWCaptions.LeadExtensionParamsType[1]);
    this.cmb_extensiontype.Items.Add((object) buMWCaptions.LeadExtensionParamsType[4]);
    if (this.mwCamLeadController.LeadParams.Extension.Type == LeadExtensionParamsType.TpNone)
      this.cmb_extensiontype.SelectedIndex = 0;
    else if (this.mwCamLeadController.LeadParams.Extension.Type == LeadExtensionParamsType.TpVerticalTangArc)
      this.cmb_extensiontype.SelectedIndex = 1;
    else if (this.mwCamLeadController.LeadParams.Extension.Type == LeadExtensionParamsType.TpHorizontalTangArc)
      this.cmb_extensiontype.SelectedIndex = 2;
    else if (this.mwCamLeadController.LeadParams.Extension.Type == LeadExtensionParamsType.TpTangentialLine)
      this.cmb_extensiontype.SelectedIndex = 3;
    else if (this.mwCamLeadController.LeadParams.Extension.Type == LeadExtensionParamsType.TpOrthogonalLine)
      this.cmb_extensiontype.SelectedIndex = 4;
    if (this.mwCamLeadController.LeadParams.UseWidthLength)
    {
      this.\u0001.Checked = true;
      this.\u0002.Checked = false;
    }
    else
    {
      this.\u0001.Checked = false;
      this.\u0002.Checked = true;
    }
    if (this.mwCamLeadController.LeadParams.Extension.UseWidthLength)
    {
      this.\u0003.Checked = false;
      this.\u0004.Checked = true;
    }
    else
    {
      this.\u0003.Checked = true;
      this.\u0004.Checked = false;
    }
    ((F_SurfaceQuality) this).\u0003.Checked = this.mwCamLeadController.LeadParams.AutomaticArcSweepFlg;
    this.\u0002.Checked = this.mwCamLeadController.LeadParams.FlipArcFlg;
    this.\u0001.Checked = this.mwCamLeadController.LeadParams.Extension.FlipArcFlg;
    this.\u000E.Value = (Decimal) this.mwCamLeadController.LeadParams.Height;
    this.\u0008.Value = (Decimal) this.mwCamLeadController.LeadParams.FeedRatePercent;
    this.\u0007.Value = (Decimal) this.mwCamLeadController.LeadParams.ArcSweep;
    this.\u0006.Value = (Decimal) this.mwCamLeadController.LeadParams.ArcDiaOverToolDia;
    this.\u0003.Value = (Decimal) this.mwCamLeadController.LeadParams.Angle;
    this.\u0002.Value = (Decimal) this.mwCamLeadController.LeadParams.FilletRadius;
    this.\u0004.Value = (Decimal) this.mwCamLeadController.LeadParams.Length;
    this.\u0005.Value = (Decimal) this.mwCamLeadController.LeadParams.Width;
    this.\u0001.Value = (Decimal) this.mwCamLeadController.LeadParams.MaxAngleChange;
    this.\u000F.Value = (Decimal) this.mwCamLeadController.LeadParams.Extension.ArcDiaOverToolDia;
    this.\u0010.Value = (Decimal) this.mwCamLeadController.LeadParams.Extension.ArcSweep;
    this.\u0011.Value = (Decimal) this.mwCamLeadController.LeadParams.Extension.Length;
    this.\u0012.Value = (Decimal) this.mwCamLeadController.LeadParams.Extension.Width;
    this.ControlUpdate();
    \u0005.\u0002.\u0001(this);
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
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_SurfaceQuality) this).btn_ok.Name)
    {
      this.Apply();
      this.Properties.Result = DialogResult.OK;
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_SurfaceQuality) this).btn_cancel.Name))
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
    this.\u0001.Enabled = false;
    if (this.cmb_axisorientation.SelectedIndex == 1)
      this.\u0001.Enabled = true;
    this.\u0008.Enabled = true;
    this.\u000E.Enabled = true;
    this.\u0005.Enabled = true;
    this.\u0003.Enabled = false;
    this.\u0002.Enabled = false;
    this.\u0002.Enabled = true;
    this.\u0001.Enabled = true;
    this.\u0002.Enabled = true;
    ((F_SurfaceQuality) this).\u0003.Visible = false;
    ((F_SurfaceQuality) this).\u0001.Visible = false;
    if (this.cmb_leadtype.SelectedIndex == 0 | this.cmb_leadtype.SelectedIndex == 1 | this.cmb_leadtype.SelectedIndex == 2 | this.cmb_leadtype.SelectedIndex == 3 | this.cmb_leadtype.SelectedIndex == 4 | this.cmb_leadtype.SelectedIndex == 5)
    {
      if (this.\u0002.Checked)
      {
        this.\u0002.Enabled = true;
        this.\u0001.Enabled = false;
      }
      else
      {
        this.\u0002.Enabled = false;
        this.\u0001.Enabled = true;
      }
      if (this.cmb_leadtype.SelectedIndex == 2)
        ((F_SurfaceQuality) this).\u0003.Visible = true;
    }
    else if (this.cmb_leadtype.SelectedIndex == 6 | this.cmb_leadtype.SelectedIndex == 7 | this.cmb_leadtype.SelectedIndex == 8 | this.cmb_leadtype.SelectedIndex == 9 | this.cmb_leadtype.SelectedIndex == 10 | this.cmb_leadtype.SelectedIndex == 11 | this.cmb_leadtype.SelectedIndex == 13)
    {
      this.\u0002.Enabled = false;
      this.\u0001.Checked = true;
      this.\u0002.Checked = false;
      this.\u0002.Enabled = false;
      this.\u0001.Enabled = true;
      this.\u0005.Enabled = false;
      this.\u0002.Enabled = false;
      if (this.cmb_leadtype.SelectedIndex == 8 | this.cmb_leadtype.SelectedIndex == 9)
        this.\u0002.Enabled = true;
      if (this.cmb_leadtype.SelectedIndex == 10 | this.cmb_leadtype.SelectedIndex == 13)
        this.\u0003.Enabled = true;
    }
    else if (this.cmb_leadtype.SelectedIndex == 12)
    {
      ((F_SurfaceQuality) this).\u0001.Visible = true;
      this.\u0002.Enabled = false;
      this.\u0001.Enabled = false;
      this.\u000E.Enabled = false;
      this.\u0002.Enabled = false;
      this.\u0005.Enabled = false;
    }
    if (this.cmb_extensiontype.SelectedIndex == 0)
    {
      this.\u0003.Enabled = false;
      this.\u0004.Enabled = false;
      this.\u0001.Enabled = false;
      this.\u0004.Enabled = false;
      this.\u0005.Enabled = false;
    }
    else if (this.cmb_extensiontype.SelectedIndex == 1 | this.cmb_extensiontype.SelectedIndex == 2)
    {
      this.\u0003.Enabled = true;
      this.\u0004.Enabled = true;
      this.\u0001.Enabled = true;
      this.\u0012.Enabled = true;
      this.\u0011.Enabled = true;
      if (this.\u0003.Checked)
      {
        this.\u0004.Enabled = true;
        this.\u0005.Enabled = false;
      }
      else
      {
        this.\u0004.Enabled = false;
        this.\u0005.Enabled = true;
      }
    }
    else
    {
      if (!(this.cmb_extensiontype.SelectedIndex == 3 | this.cmb_extensiontype.SelectedIndex == 4))
        return;
      this.\u0003.Enabled = false;
      this.\u0004.Enabled = false;
      this.\u0001.Enabled = false;
      this.\u0004.Enabled = false;
      this.\u0005.Enabled = true;
      this.\u0004.Enabled = false;
      this.\u0005.Enabled = true;
      this.\u0012.Enabled = false;
      this.\u0011.Enabled = true;
    }
  }

  public void Apply()
  {
    if (this.cmb_leadtype.SelectedIndex == 0)
      this.mwCamLeadController.LeadParams.Type = LeadParamsType.TangentialArc;
    else if (this.cmb_leadtype.SelectedIndex == 1)
      this.mwCamLeadController.LeadParams.Type = LeadParamsType.ReverseTangArc;
    else if (this.cmb_leadtype.SelectedIndex == 2)
      this.mwCamLeadController.LeadParams.Type = LeadParamsType.VerticalTangArc;
    else if (this.cmb_leadtype.SelectedIndex == 3)
      this.mwCamLeadController.LeadParams.Type = LeadParamsType.ReverseVertTangArc;
    else if (this.cmb_leadtype.SelectedIndex == 4)
      this.mwCamLeadController.LeadParams.Type = LeadParamsType.HorizontalTangArc;
    else if (this.cmb_leadtype.SelectedIndex == 5)
      this.mwCamLeadController.LeadParams.Type = LeadParamsType.OrthogonalArc;
    else if (this.cmb_leadtype.SelectedIndex == 6)
      this.mwCamLeadController.LeadParams.Type = LeadParamsType.TangentialLine;
    else if (this.cmb_leadtype.SelectedIndex == 7)
      this.mwCamLeadController.LeadParams.Type = LeadParamsType.ReverseTangLine;
    else if (this.cmb_leadtype.SelectedIndex == 8)
      this.mwCamLeadController.LeadParams.Type = LeadParamsType.OrthogonalLine;
    else if (this.cmb_leadtype.SelectedIndex == 9)
      this.mwCamLeadController.LeadParams.Type = LeadParamsType.ReverseOrthogonalLine;
    else if (this.cmb_leadtype.SelectedIndex == 10)
      this.mwCamLeadController.LeadParams.Type = LeadParamsType.VertProfileRamp;
    else if (this.cmb_leadtype.SelectedIndex == 11)
      this.mwCamLeadController.LeadParams.Type = LeadParamsType.ReverseVertProfileRamp;
    else if (this.cmb_leadtype.SelectedIndex == 12)
      this.mwCamLeadController.LeadParams.Type = LeadParamsType.PositionLine;
    else if (this.cmb_leadtype.SelectedIndex == 13)
      this.mwCamLeadController.LeadParams.Type = LeadParamsType.SlantLine;
    if (this.cmb_extensiontype.SelectedIndex == 0)
      this.mwCamLeadController.LeadParams.Extension.Type = LeadExtensionParamsType.TpNone;
    else if (this.cmb_extensiontype.SelectedIndex == 1)
      this.mwCamLeadController.LeadParams.Extension.Type = LeadExtensionParamsType.TpVerticalTangArc;
    else if (this.cmb_extensiontype.SelectedIndex == 2)
      this.mwCamLeadController.LeadParams.Extension.Type = LeadExtensionParamsType.TpHorizontalTangArc;
    else if (this.cmb_extensiontype.SelectedIndex == 3)
      this.mwCamLeadController.LeadParams.Extension.Type = LeadExtensionParamsType.TpTangentialLine;
    else if (this.cmb_extensiontype.SelectedIndex == 4)
      this.mwCamLeadController.LeadParams.Extension.Type = LeadExtensionParamsType.TpOrthogonalLine;
    if (this.cmb_axisorientation.SelectedIndex == 0)
      this.mwCamLeadController.LeadParams.AxisOrientation = LeadParamsAxisOrientation.Fixed;
    else if (this.cmb_axisorientation.SelectedIndex == 1)
      this.mwCamLeadController.LeadParams.AxisOrientation = LeadParamsAxisOrientation.Tangential;
    this.mwCamLeadController.LeadParams.UseWidthLength = !this.\u0002.Checked;
    this.mwCamLeadController.LeadParams.Extension.UseWidthLength = !this.\u0003.Checked;
    this.mwCamLeadController.LeadParams.AutomaticArcSweepFlg = ((F_SurfaceQuality) this).\u0003.Checked;
    this.mwCamLeadController.LeadParams.FlipArcFlg = this.\u0002.Checked;
    this.mwCamLeadController.LeadParams.Extension.FlipArcFlg = this.\u0001.Checked;
    this.mwCamLeadController.LeadParams.Height = (double) this.\u000E.Value;
    this.mwCamLeadController.LeadParams.FeedRatePercent = (double) this.\u0008.Value;
    this.mwCamLeadController.LeadParams.ArcSweep = (double) this.\u0007.Value;
    this.mwCamLeadController.LeadParams.ArcDiaOverToolDia = (double) this.\u0006.Value;
    this.mwCamLeadController.LeadParams.Angle = (double) this.\u0003.Value;
    this.mwCamLeadController.LeadParams.FilletRadius = (double) this.\u0002.Value;
    this.mwCamLeadController.LeadParams.Length = (double) this.\u0004.Value;
    this.mwCamLeadController.LeadParams.Width = (double) this.\u0005.Value;
    this.mwCamLeadController.LeadParams.MaxAngleChange = (double) this.\u0001.Value;
    this.mwCamLeadController.LeadParams.Extension.ArcDiaOverToolDia = (double) this.\u000F.Value;
    this.mwCamLeadController.LeadParams.Extension.ArcSweep = (double) this.\u0010.Value;
    this.mwCamLeadController.LeadParams.Extension.Length = (double) this.\u0011.Value;
    this.mwCamLeadController.LeadParams.Extension.Width = (double) this.\u0012.Value;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1) => this.ControlUpdate();

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == this.\u0011.Name)
    {
      ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.LeadInLength;
      if (this.cmb_extensiontype.SelectedIndex == 3)
        ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.LeadInExtensionTangLineLength;
    }
    else if (control2.Name == this.\u0004.Name)
      ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.LeadInLength;
    else if (control2.Name == this.\u0012.Name)
      ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.LeadInWidth;
    else if (control2.Name == this.\u0005.Name)
      ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.LeadInWidth;
    else if (control2.Name == this.\u0010.Name)
      ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.LeadInArcSweep;
    else if (control2.Name == this.\u0007.Name)
      ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.LeadInArcSweep;
    else if (control2.Name == this.\u000F.Name)
      ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.LeadInArcDiameter;
    else if (control2.Name == this.\u0006.Name)
      ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.LeadInArcDiameter;
    else if (control2.Name == this.\u0001.Name)
      ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == this.\u0004.Name)
      ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == this.\u0003.Name)
      ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == this.\u0002.Name)
      ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == this.\u0001.Name)
      ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == this.\u0002.Name)
      ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == this.\u0001.Name)
      ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.LeadInToolAxisOriMaxAngleChange;
    else if (control2.Name == this.\u0003.Name)
    {
      ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.NoImage;
      if (this.cmb_leadtype.SelectedIndex == 10)
        ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.LeadInVertProfRampAngle;
    }
    else if (control2.Name == ((F_SurfaceQuality) this).\u0003.Name)
      ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == this.\u000E.Name)
      ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.LeadInHeight;
    else if (control2.Name == this.\u0008.Name)
      ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == this.\u0002.Name)
      ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == this.cmb_leadtype.Name)
    {
      if (this.cmb_leadtype.SelectedIndex == 0)
      {
        ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.LeadInTangArc;
        if (((F_SurfaceQuality) this).\u0004.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_leadtype.SelectedIndex == 1)
      {
        ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.LeadInRevTangArc;
        if (((F_SurfaceQuality) this).\u0004.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_leadtype.SelectedIndex == 2)
      {
        ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.LeadInVerTangArc;
        if (((F_SurfaceQuality) this).\u0004.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_leadtype.SelectedIndex == 3)
      {
        ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.LeadInRevVerTangArc;
        if (((F_SurfaceQuality) this).\u0004.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_leadtype.SelectedIndex == 4)
      {
        ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.LeadInHorTangArc;
        if (((F_SurfaceQuality) this).\u0004.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_leadtype.SelectedIndex == 5)
      {
        ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.LeadInOrthArc;
        if (((F_SurfaceQuality) this).\u0004.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_leadtype.SelectedIndex == 6)
      {
        ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.LeadInTangLine;
        if (((F_SurfaceQuality) this).\u0004.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_leadtype.SelectedIndex == 7)
      {
        ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.LeadInRevTangLine;
        if (((F_SurfaceQuality) this).\u0004.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_leadtype.SelectedIndex == 8)
      {
        ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.LeadInOrthLine;
        if (((F_SurfaceQuality) this).\u0004.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_leadtype.SelectedIndex == 9)
        ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.NoImage;
      else if (this.cmb_leadtype.SelectedIndex == 10)
      {
        ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.LeadInVerProfRamp;
        if (((F_SurfaceQuality) this).\u0004.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_leadtype.SelectedIndex == 11)
      {
        ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.LeadInRevVertProfRamp;
        if (((F_SurfaceQuality) this).\u0004.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_leadtype.SelectedIndex == 12)
      {
        ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.NoImage;
        if (((F_SurfaceQuality) this).\u0004.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_leadtype.SelectedIndex == 13)
        ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.NoImage;
    }
    else if (control2.Name == this.cmb_extensiontype.Name)
    {
      if (this.cmb_extensiontype.SelectedIndex == 0)
      {
        ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.NoImage;
        if (((F_SurfaceQuality) this).\u0004.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_extensiontype.SelectedIndex == 1)
      {
        ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.LeadInExtensionVerTangArc;
        if (((F_SurfaceQuality) this).\u0004.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_extensiontype.SelectedIndex == 2)
      {
        ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.LeadInExtensionHorTangArc;
        if (((F_SurfaceQuality) this).\u0004.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_extensiontype.SelectedIndex == 3)
      {
        ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.LeadInExtensionTangLine;
        if (((F_SurfaceQuality) this).\u0004.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_extensiontype.SelectedIndex == 4)
      {
        ((F_SurfaceQuality) this).\u0001.Image = (Image) ResourceImage.LeadInExtensionOrthLine;
        if (((F_SurfaceQuality) this).\u0004.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
    }
    ((F_SurfaceQuality) this).\u0004.Checked = false;
  }
}
