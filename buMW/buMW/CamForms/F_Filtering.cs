// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_Filtering
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
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

public class F_Filtering : Form
{
  public Button btn_cancel;
  internal CheckBox \u0001;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0003;
  internal NumericUpDown \u0002;
  internal System.Windows.Forms.Label \u0004;
  public FormProperties PropertiesForm = new FormProperties();
  public GeoLib mwCamParameter = (GeoLib) null;
  public camParameters5 buCamParameter = (camParameters5) null;
  public MWCalculationOptions Configration = new MWCalculationOptions();
  public ToolBase5 Tool = (ToolBase5) null;
  public static List<string> Captions;
  internal IContainer \u0001 = (IContainer) null;
  internal ImageList \u0001;
  internal System.Windows.Forms.Label \u0001;
  internal PictureBox \u0001;
  public Button btn_ok;
  internal ImageList \u0002;
  public Button btn_cancel;
  internal CheckBox \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal NumericUpDown \u0001;

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_Fixtures) this).ControlUpdate();
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_Fixtures) this).\u0002.Name)
      ((F_Fixtures) this).\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == ((F_Fixtures) this).\u0001.Name)
      ((F_Fixtures) this).\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == this.\u0001.Name)
    {
      ((F_Fixtures) this).\u0001.Image = (Image) ResourceImage.AdditionalOffsetRough;
      if (this.\u0001.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == this.\u0002.Name)
      ((F_Fixtures) this).\u0001.Image = (Image) ResourceImage.CurveHighRough;
    this.\u0001.Checked = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_Fixtures) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_Fixtures) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_Filtering() => F_Fixtures.Captions = new List<string>();

  public F_Filtering() => \u0005.\u0002.\u0001(this);

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
      ((F_ProfilePass) this).cmb_filteringfilterby.Items.Clear();
      ((F_ProfilePass) this).cmb_filteringfilterby.Items.Add((object) buMWCaptions.TriangleMeshBasedTpCalcParamsFilteringMode[0]);
      ((F_ProfilePass) this).cmb_filteringfilterby.Items.Add((object) buMWCaptions.TriangleMeshBasedTpCalcParamsFilteringMode[1]);
      if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FilteringMode == TriangleMeshBasedTpCalcParamsFilteringMode.TmbFmByRegions)
        ((F_ProfilePass) this).cmb_filteringfilterby.SelectedIndex = 0;
      else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FilteringMode == TriangleMeshBasedTpCalcParamsFilteringMode.TmbFmByContours)
        ((F_ProfilePass) this).cmb_filteringfilterby.SelectedIndex = 1;
      ((F_ProfilePass) this).cmb_filteringtype.Items.Clear();
      ((F_ProfilePass) this).cmb_filteringtype.Items.Add((object) buMWCaptions.TriangleMeshBasedTpCalcParamsFilteringType[0]);
      ((F_ProfilePass) this).cmb_filteringtype.Items.Add((object) buMWCaptions.TriangleMeshBasedTpCalcParamsFilteringType[1]);
      ((F_ProfilePass) this).cmb_filteringtype.Items.Add((object) buMWCaptions.TriangleMeshBasedTpCalcParamsFilteringType[2]);
      if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FilteringType == TriangleMeshBasedTpCalcParamsFilteringType.TmbFtInscribedCircle)
        ((F_ProfilePass) this).cmb_filteringtype.SelectedIndex = 0;
      else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FilteringType == TriangleMeshBasedTpCalcParamsFilteringType.TmbFtCircumscribedCircle)
        ((F_ProfilePass) this).cmb_filteringtype.SelectedIndex = 1;
      else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FilteringType == TriangleMeshBasedTpCalcParamsFilteringType.TmbFtDiagonalLength)
        ((F_ProfilePass) this).cmb_filteringtype.SelectedIndex = 2;
      ((F_ProfilePass) this).\u0002.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FilteringThresholdInPercOfToolDiameter;
      this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinimumToolpathSegmentLengthInPercOfToolDiameter;
      ((F_ProfilePass) this).\u0002.Visible = false;
      ((F_ProfilePass) this).\u0004.Visible = false;
      ((F_ProfilePass) this).\u0005.Visible = false;
      ((F_ProfilePass) this).\u0003.Visible = false;
      ((F_ProfilePass) this).cmb_filteringfilterby.Visible = false;
      ((F_ProfilePass) this).cmb_filteringtype.Visible = false;
      if (this.Configration.isRough)
      {
        ((F_ProfilePass) this).\u0002.Visible = true;
        ((F_ProfilePass) this).\u0004.Visible = true;
        ((F_ProfilePass) this).\u0005.Visible = true;
        ((F_ProfilePass) this).\u0003.Visible = true;
        ((F_ProfilePass) this).cmb_filteringfilterby.Visible = true;
        ((F_ProfilePass) this).cmb_filteringtype.Visible = true;
      }
    }
    this.ControlUpdate();
    this.LoadLanguage();
    this.\u0001.Image = (Image) null;
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_Filtering.Captions.Count < 9)
        return;
      this.Text = F_Filtering.Captions[0];
      this.\u0002.Text = F_Filtering.Captions[1];
      ((F_ProfilePass) this).\u0004.Text = F_Filtering.Captions[2];
      ((F_ProfilePass) this).\u0005.Text = F_Filtering.Captions[3];
      ((F_ProfilePass) this).\u0003.Text = F_Filtering.Captions[4];
      this.\u0001.Text = F_Filtering.Captions[5];
      this.btn_ok.Text = F_Filtering.Captions[6];
      this.btn_cancel.Text = F_Filtering.Captions[7];
      this.\u0001.Text = F_Filtering.Captions[8];
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
    this.Apply();
    this.PropertiesForm.Result = DialogResult.OK;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void ControlUpdate()
  {
  }

  public void Apply()
  {
    if (this.Configration.Mode != CamMode.TriangularMesh)
      return;
    if (((F_ProfilePass) this).cmb_filteringfilterby.SelectedIndex == 0)
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FilteringMode = TriangleMeshBasedTpCalcParamsFilteringMode.TmbFmByRegions;
    else if (((F_ProfilePass) this).cmb_filteringfilterby.SelectedIndex == 1)
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FilteringMode = TriangleMeshBasedTpCalcParamsFilteringMode.TmbFmByContours;
    if (((F_ProfilePass) this).cmb_filteringtype.SelectedIndex == 0)
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FilteringType = TriangleMeshBasedTpCalcParamsFilteringType.TmbFtInscribedCircle;
    else if (((F_ProfilePass) this).cmb_filteringtype.SelectedIndex == 1)
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FilteringType = TriangleMeshBasedTpCalcParamsFilteringType.TmbFtCircumscribedCircle;
    else if (((F_ProfilePass) this).cmb_filteringtype.SelectedIndex == 2)
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FilteringType = TriangleMeshBasedTpCalcParamsFilteringType.TmbFtDiagonalLength;
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FilteringThresholdInPercOfToolDiameter = (double) (int) ((F_ProfilePass) this).\u0002.Value;
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinimumToolpathSegmentLengthInPercOfToolDiameter = (double) this.\u0001.Value;
  }
}
