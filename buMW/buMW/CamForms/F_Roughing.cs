// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_Roughing
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buControls.Forms.WinControlForms.ClassForm;
using buControls.Forms.WinControlForms.Views;
using buEyeBaseVer5;
using buImages;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW.CamForms;

public class F_Roughing : Form
{
  internal NumericUpDown \u0008;
  internal System.Windows.Forms.Label \u0012;
  internal CheckBox \u0007;
  public ComboBox cmb_removecornerpeg;
  internal System.Windows.Forms.Label \u0013;
  internal NumericUpDown \u000E;
  internal CheckBox \u0008;
  internal CheckBox \u000E;
  public static byte f000E64;
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
  internal System.Windows.Forms.Label \u0002;
  internal CheckBox \u0001;
  internal Button \u0001;
  internal Button \u0002;
  internal System.Windows.Forms.Label \u0003;
  internal NumericUpDown \u0001;
  public ComboBox cmb_ramptype;
  internal System.Windows.Forms.Label \u0004;
  internal Button \u0003;
  internal System.Windows.Forms.Label \u0005;
  internal NumericUpDown \u0002;
  internal CheckBox \u0002;
  internal System.Windows.Forms.Label \u0006;
  internal NumericUpDown \u0003;
  internal CheckBox \u0003;
  internal CheckBox \u0004;
  internal NumericUpDown \u0004;
  internal Panel \u0002;
  internal NumericUpDown \u0005;
  internal NumericUpDown \u0006;
  internal RadioButton \u0001;
  internal RadioButton \u0002;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!((F_RoughingAdvanced) this).PropertiesForm.Inited)
      return;
    ((F_RoughingAdvanced) this).ControlUpdate();
    if (control2.Name == ((F_RoughingAdvanced) this).combo_filterby.Name)
    {
      if (((F_RoughingAdvanced) this).combo_filterby.SelectedIndex == 0)
        ((F_RoughingAdvanced) this).\u0001.Image = (Image) ResourceImage.FilterByRegionsRough;
      else if (((F_RoughingAdvanced) this).combo_filterby.SelectedIndex == 1)
        ((F_RoughingAdvanced) this).\u0001.Image = (Image) ResourceImage.FilterByContoursRough;
    }
    else if (control2.Name == ((F_RoughingAdvanced) this).combo_type.Name)
    {
      if (((F_RoughingAdvanced) this).combo_type.SelectedIndex == 0)
        ((F_RoughingAdvanced) this).\u0001.Image = (Image) ResourceImage.InscribedCircleRough;
      else if (((F_RoughingAdvanced) this).combo_type.SelectedIndex == 1)
        ((F_RoughingAdvanced) this).\u0001.Image = (Image) ResourceImage.DiagonalLengthRough;
    }
    else if (control2.Name == this.cmb_removecornerpeg.Name)
    {
      if (this.cmb_removecornerpeg.SelectedIndex == 0)
        ((F_RoughingAdvanced) this).\u0001.Image = (Image) ResourceImage.AdvancedLineArcLineRough;
      else if (this.cmb_removecornerpeg.SelectedIndex == 1)
        ((F_RoughingAdvanced) this).\u0001.Image = (Image) ResourceImage.AdvancedArcRough;
      else if (this.cmb_removecornerpeg.SelectedIndex == 2)
        ((F_RoughingAdvanced) this).\u0001.Image = (Image) ResourceImage.AdvancedLineRough;
    }
    ((F_RoughingAdvanced) this).PropertiesForm.Inited = false;
    ((F_RoughingAdvanced) this).Apply();
    ((F_RoughingAdvanced) this).ControlUpdate();
    ((F_RoughingAdvanced) this).PropertiesForm.Inited = true;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_RoughingAdvanced) this).\u0007.Name)
      ((F_RoughingAdvanced) this).\u0001.Image = (Image) ResourceImage.SmoothDistanceSteopver;
    else if (control2.Name == ((F_RoughingAdvanced) this).\u0006.Name)
      ((F_RoughingAdvanced) this).\u0001.Image = (Image) ResourceImage.SmoothLinkGapSizeStepover;
    else if (control2.Name == ((F_RoughingAdvanced) this).\u0002.Name)
    {
      ((F_RoughingAdvanced) this).\u0001.Image = (Image) ResourceImage.SmoothConnectionsRough;
      if (this.\u000E.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_RoughingAdvanced) this).\u0004.Name)
      ((F_RoughingAdvanced) this).\u0001.Image = (Image) ResourceImage.SmoothConnectionRadiusRough;
    else if (control2.Name == this.\u000E.Name)
    {
      ((F_RoughingAdvanced) this).\u0001.Image = (Image) ResourceImage.LeadOutsRadiusStepoverRough;
      if (this.\u000E.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == this.\u0008.Name)
    {
      ((F_RoughingAdvanced) this).\u0001.Image = (Image) ResourceImage.NoImage;
      if (this.\u000E.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == this.cmb_removecornerpeg.Name)
    {
      if (this.cmb_removecornerpeg.SelectedIndex == 0)
      {
        ((F_RoughingAdvanced) this).\u0001.Image = (Image) ResourceImage.AdvancedLineArcLineRough;
        if (this.\u000E.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_removecornerpeg.SelectedIndex == 1)
      {
        ((F_RoughingAdvanced) this).\u0001.Image = (Image) ResourceImage.AdvancedArcRough;
        if (this.\u000E.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.cmb_removecornerpeg.SelectedIndex == 2)
      {
        ((F_RoughingAdvanced) this).\u0001.Image = (Image) ResourceImage.AdvancedLineRough;
        if (this.\u000E.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
    }
    else if (control2.Name == ((F_RoughingAdvanced) this).\u0003.Name)
      ((F_RoughingAdvanced) this).\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == ((F_RoughingAdvanced) this).\u0001.Name)
      ((F_RoughingAdvanced) this).\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == ((F_RoughingAdvanced) this).\u0005.Name)
      ((F_RoughingAdvanced) this).\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == ((F_RoughingAdvanced) this).\u0002.Name)
      ((F_RoughingAdvanced) this).\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == ((F_RoughingAdvanced) this).\u0002.Name)
      ((F_RoughingAdvanced) this).\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == ((F_RoughingAdvanced) this).\u0001.Name)
      ((F_RoughingAdvanced) this).\u0001.Image = (Image) ResourceImage.NoImage;
    this.\u000E.Checked = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_RoughingAdvanced) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_RoughingAdvanced) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_Roughing() => F_RoughingAdvanced.Captions = new List<string>();

  public F_Roughing() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    ((F_StockDef) this).\u0001.Items.Clear();
    for (int index = 0; index <= this.mwCamParameter.DrillPoints.Count<Point3d<double>>() - 1; ++index)
    {
      ListBox.ObjectCollection items = ((F_StockDef) this).\u0001.Items;
      string[] strArray = new string[5];
      double num = this.mwCamParameter.DrillPoints.ElementAt<Point3d<double>>(index).X;
      strArray[0] = num.ToString();
      strArray[1] = " ; ";
      num = this.mwCamParameter.DrillPoints.ElementAt<Point3d<double>>(index).Y;
      strArray[2] = num.ToString();
      strArray[3] = " ; ";
      num = this.mwCamParameter.DrillPoints.ElementAt<Point3d<double>>(index).Z;
      strArray[4] = num.ToString();
      string str = string.Concat(strArray);
      items.Add((object) str);
    }
    this.\u0002.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.AllowToolOutsideStockFlg;
    this.\u0002.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.StockClearancePercent;
    ((F_StockDef) this).\u0005.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.DrillPositionsFlg;
    this.\u0003.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.CenterCuttingToolFlg;
    this.\u0003.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinRampDiameterPercent;
    this.\u0004.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampLengthPercent;
    this.\u0005.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampPitch;
    this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampAngle;
    this.\u0006.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampAngle;
    this.\u0001.Checked = this.mwCamParameter.MachParam.CollCtrlOpStockParams.Status;
    ((F_StockDef) this).chk_transformrotate.Checked = this.mwCamParameter.MachParam.RoughingParams.TPRotationRoughParams.IsUsedFlg;
    ((F_StockDef) this).chk_mirror.Checked = this.mwCamParameter.MachParam.RoughingParams.MirrorTpRoughParams.IsUsedFlg;
    if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampMode == TriangleMeshBasedTpCalcParamsRampMode.TmbRmAngle)
      this.\u0002.Checked = true;
    else
      this.\u0001.Checked = true;
    this.cmb_ramptype.Items.Clear();
    this.cmb_ramptype.Items.Add((object) buMWCaptions.TriangleMeshBasedTpCalcParamsRampType[0]);
    this.cmb_ramptype.Items.Add((object) buMWCaptions.TriangleMeshBasedTpCalcParamsRampType[1]);
    this.cmb_ramptype.Items.Add((object) buMWCaptions.TriangleMeshBasedTpCalcParamsRampType[2]);
    this.cmb_ramptype.Items.Add((object) buMWCaptions.TriangleMeshBasedTpCalcParamsRampType[3]);
    this.cmb_ramptype.Items.Add((object) buMWCaptions.TriangleMeshBasedTpCalcParamsRampType[4]);
    if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampType == TriangleMeshBasedTpCalcParamsRampType.TmbRtAutomatic)
      this.cmb_ramptype.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampType == TriangleMeshBasedTpCalcParamsRampType.TmbRtLine)
      this.cmb_ramptype.SelectedIndex = 1;
    else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampType == TriangleMeshBasedTpCalcParamsRampType.TmbRtHelical)
      this.cmb_ramptype.SelectedIndex = 2;
    else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampType == TriangleMeshBasedTpCalcParamsRampType.TmbRtZigzag)
      this.cmb_ramptype.SelectedIndex = 3;
    else
      this.cmb_ramptype.SelectedIndex = 4;
    this.ControlUpdate();
    \u0005.\u0002.\u0001(this);
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
    if (control2.Name == this.btn_cancel.Name)
    {
      this.PropertiesForm.Result = DialogResult.Cancel;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == ((F_StockDef) this).\u0004.Name)
    {
      F_Pnt3D fPnt3D = new F_Pnt3D();
      fPnt3D.StartPosition = FormStartPosition.CenterParent;
      fPnt3D.Value = new Pnt3D();
      fPnt3D.Init();
      int num = (int) fPnt3D.ShowDialog();
      if (fPnt3D.Result == DialogResult.OK)
        ((F_StockDef) this).\u0001.Items.Add((object) $"{fPnt3D.Value.X.ToString()};{fPnt3D.Value.Y.ToString()};{fPnt3D.Value.Z.ToString()}");
    }
    if (control2.Name == ((F_StockDef) this).\u0005.Name && ((F_StockDef) this).\u0001.SelectedIndex >= 0 & ((F_StockDef) this).\u0001.SelectedIndex <= ((F_StockDef) this).\u0001.Items.Count - 1)
      ((F_StockDef) this).\u0001.Items.RemoveAt(((F_StockDef) this).\u0001.SelectedIndex);
    if (control2.Name == this.\u0001.Name)
    {
      F_StockDef fStockDef = new F_StockDef()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      fStockDef.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      fStockDef.buCamParameter = new camParameters5(this.buCamParameter);
      ((\u0006.\u0001.\u0001) fStockDef).pnl_area.Visible = false;
      fStockDef.Init();
      int num = (int) fStockDef.ShowDialog();
      if (fStockDef.PropertiesForm.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(fStockDef.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(fStockDef.buCamParameter);
        fStockDef.Dispose();
      }
    }
    if (control2.Name == this.\u0002.Name)
    {
      F_RoughingAdvanced roughingAdvanced = new F_RoughingAdvanced()
      {
        mwCamParameter = new GeoLib(this.mwCamParameter.Units, 0)
      };
      roughingAdvanced.mwCamParameter.MachParam = new MachiningParams(this.mwCamParameter.MachParam);
      roughingAdvanced.buCamParameter = new camParameters5(this.buCamParameter);
      roughingAdvanced.Init();
      int num = (int) roughingAdvanced.ShowDialog();
      if (roughingAdvanced.PropertiesForm.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam = new MachiningParams(roughingAdvanced.mwCamParameter.MachParam);
        this.buCamParameter = new camParameters5(roughingAdvanced.buCamParameter);
        roughingAdvanced.Dispose();
      }
    }
    if (control2.Name == ((F_StockDef) this).btn_transformrotate.Name)
      ;
    if (control2.Name == ((F_StockDef) this).btn_mirror.Name)
      ;
  }

  public void ControlUpdate()
  {
    if (this.cmb_ramptype.SelectedIndex == 0)
    {
      this.\u0001.Enabled = this.\u0003.Checked;
      this.\u0003.Enabled = this.\u0003.Checked;
      NumericUpDown numericUpDown1 = this.\u0006;
      int num1 = this.\u0003.Checked ? 1 : 0;
      numericUpDown1.Enabled = false;
      RadioButton radioButton1 = this.\u0002;
      int num2 = this.\u0003.Checked ? 1 : 0;
      radioButton1.Enabled = false;
      NumericUpDown numericUpDown2 = this.\u0005;
      int num3 = this.\u0003.Checked ? 1 : 0;
      numericUpDown2.Enabled = false;
      RadioButton radioButton2 = this.\u0001;
      int num4 = this.\u0003.Checked ? 1 : 0;
      radioButton2.Enabled = false;
      this.\u0004.Enabled = this.\u0003.Checked;
      this.\u0003.Enabled = this.\u0003.Checked;
      this.\u0004.Enabled = this.\u0003.Checked;
      this.\u0006.Enabled = this.\u0003.Checked;
    }
    if (this.cmb_ramptype.SelectedIndex == 1)
    {
      NumericUpDown numericUpDown = this.\u0001;
      int num5 = this.\u0003.Checked ? 1 : 0;
      numericUpDown.Enabled = false;
      System.Windows.Forms.Label label = this.\u0003;
      int num6 = this.\u0003.Checked ? 1 : 0;
      label.Enabled = false;
      this.\u0006.Enabled = this.\u0003.Checked;
      this.\u0002.Enabled = this.\u0003.Checked;
      this.\u0005.Enabled = this.\u0003.Checked;
      this.\u0001.Enabled = this.\u0003.Checked;
      this.\u0004.Enabled = this.\u0003.Checked;
      this.\u0003.Enabled = this.\u0003.Checked;
      this.\u0004.Enabled = this.\u0003.Checked;
      this.\u0006.Enabled = this.\u0003.Checked;
    }
    if (this.cmb_ramptype.SelectedIndex == 2)
    {
      this.\u0001.Enabled = this.\u0003.Checked;
      this.\u0003.Enabled = this.\u0003.Checked;
      NumericUpDown numericUpDown3 = this.\u0006;
      int num7 = this.\u0003.Checked ? 1 : 0;
      numericUpDown3.Enabled = false;
      RadioButton radioButton3 = this.\u0002;
      int num8 = this.\u0003.Checked ? 1 : 0;
      radioButton3.Enabled = false;
      NumericUpDown numericUpDown4 = this.\u0005;
      int num9 = this.\u0003.Checked ? 1 : 0;
      numericUpDown4.Enabled = false;
      RadioButton radioButton4 = this.\u0001;
      int num10 = this.\u0003.Checked ? 1 : 0;
      radioButton4.Enabled = false;
      this.\u0004.Enabled = this.\u0003.Checked;
      this.\u0003.Enabled = this.\u0003.Checked;
      this.\u0004.Enabled = this.\u0003.Checked;
      this.\u0006.Enabled = this.\u0003.Checked;
    }
    if (this.cmb_ramptype.SelectedIndex == 3)
    {
      this.\u0001.Enabled = this.\u0003.Checked;
      this.\u0003.Enabled = this.\u0003.Checked;
      NumericUpDown numericUpDown5 = this.\u0006;
      int num11 = this.\u0003.Checked ? 1 : 0;
      numericUpDown5.Enabled = false;
      RadioButton radioButton5 = this.\u0002;
      int num12 = this.\u0003.Checked ? 1 : 0;
      radioButton5.Enabled = false;
      NumericUpDown numericUpDown6 = this.\u0005;
      int num13 = this.\u0003.Checked ? 1 : 0;
      numericUpDown6.Enabled = false;
      RadioButton radioButton6 = this.\u0001;
      int num14 = this.\u0003.Checked ? 1 : 0;
      radioButton6.Enabled = false;
      CheckBox checkBox = this.\u0004;
      int num15 = this.\u0003.Checked ? 1 : 0;
      checkBox.Enabled = false;
      NumericUpDown numericUpDown7 = this.\u0003;
      int num16 = this.\u0003.Checked ? 1 : 0;
      numericUpDown7.Enabled = false;
      NumericUpDown numericUpDown8 = this.\u0004;
      int num17 = this.\u0003.Checked ? 1 : 0;
      numericUpDown8.Enabled = false;
      System.Windows.Forms.Label label = this.\u0006;
      int num18 = this.\u0003.Checked ? 1 : 0;
      label.Enabled = false;
    }
    if (this.cmb_ramptype.SelectedIndex == 4)
    {
      this.\u0001.Enabled = this.\u0003.Checked;
      this.\u0003.Enabled = this.\u0003.Checked;
      NumericUpDown numericUpDown9 = this.\u0006;
      int num19 = this.\u0003.Checked ? 1 : 0;
      numericUpDown9.Enabled = false;
      RadioButton radioButton7 = this.\u0002;
      int num20 = this.\u0003.Checked ? 1 : 0;
      radioButton7.Enabled = false;
      NumericUpDown numericUpDown10 = this.\u0005;
      int num21 = this.\u0003.Checked ? 1 : 0;
      numericUpDown10.Enabled = false;
      RadioButton radioButton8 = this.\u0001;
      int num22 = this.\u0003.Checked ? 1 : 0;
      radioButton8.Enabled = false;
      CheckBox checkBox = this.\u0004;
      int num23 = this.\u0003.Checked ? 1 : 0;
      checkBox.Enabled = false;
      NumericUpDown numericUpDown11 = this.\u0003;
      int num24 = this.\u0003.Checked ? 1 : 0;
      numericUpDown11.Enabled = false;
      NumericUpDown numericUpDown12 = this.\u0004;
      int num25 = this.\u0003.Checked ? 1 : 0;
      numericUpDown12.Enabled = false;
      System.Windows.Forms.Label label = this.\u0006;
      int num26 = this.\u0003.Checked ? 1 : 0;
      label.Enabled = false;
    }
    if (this.\u0002.Checked)
    {
      this.\u0006.Enabled = this.\u0002.Enabled & this.\u0001.Enabled;
      NumericUpDown numericUpDown = this.\u0005;
      int num27 = this.\u0002.Enabled ? 1 : 0;
      int num28 = 0 & (this.\u0001.Enabled ? 1 : 0);
      numericUpDown.Enabled = num28 != 0;
    }
    else
    {
      NumericUpDown numericUpDown = this.\u0006;
      int num29 = this.\u0002.Enabled ? 1 : 0;
      int num30 = 0 & (this.\u0001.Enabled ? 1 : 0);
      numericUpDown.Enabled = num30 != 0;
      this.\u0005.Enabled = this.\u0002.Enabled & this.\u0001.Enabled;
    }
    ((F_StockDef) this).btn_mirror.Enabled = ((F_StockDef) this).chk_mirror.Checked;
    this.\u0001.Enabled = this.\u0001.Checked;
    ((F_StockDef) this).btn_transformrotate.Enabled = ((F_StockDef) this).chk_transformrotate.Checked;
    this.\u0003.Enabled = this.\u0004.Checked & this.\u0003.Checked;
    this.\u0004.Enabled = this.\u0003.Checked;
    this.cmb_ramptype.Enabled = this.\u0003.Checked;
  }

  public void Apply()
  {
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.AllowToolOutsideStockFlg = this.\u0002.Checked;
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.StockClearancePercent = (double) this.\u0002.Value;
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.DrillPositionsFlg = ((F_StockDef) this).\u0005.Checked;
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.CenterCuttingToolFlg = this.\u0003.Checked;
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinRampDiameterPercent = (double) this.\u0003.Value;
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampLengthPercent = (double) this.\u0004.Value;
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampPitch = (double) this.\u0005.Value;
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampAngle = (double) this.\u0001.Value;
    this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampAngle = (double) this.\u0006.Value;
    this.mwCamParameter.MachParam.CollCtrlOpStockParams.Status = this.\u0001.Checked;
    this.mwCamParameter.MachParam.RoughingParams.TPRotationRoughParams.IsUsedFlg = ((F_StockDef) this).chk_transformrotate.Checked;
    this.mwCamParameter.MachParam.RoughingParams.MirrorTpRoughParams.IsUsedFlg = ((F_StockDef) this).chk_mirror.Checked;
    List<Point3d<double>> list = this.mwCamParameter.DrillPoints.ToList<Point3d<double>>();
    list.Clear();
    for (int index = 0; index <= ((F_StockDef) this).\u0001.Items.Count - 1; ++index)
    {
      string[] strArray = ((F_StockDef) this).\u0001.Items[index].ToString().Split(';');
      if (strArray != null && strArray.Length == 3)
      {
        double result1 = 0.0;
        double result2 = 0.0;
        double result3 = 0.0;
        double.TryParse(strArray[0], out result1);
        double.TryParse(strArray[1], out result2);
        double.TryParse(strArray[2], out result3);
        list.Add(new Point3d<double>(result1, result2, result3));
      }
    }
    this.mwCamParameter.DrillPoints = (IEnumerable<Point3d<double>>) list;
    if (this.cmb_ramptype.SelectedIndex == 0)
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampType = TriangleMeshBasedTpCalcParamsRampType.TmbRtAutomatic;
    else if (this.cmb_ramptype.SelectedIndex == 1)
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampType = TriangleMeshBasedTpCalcParamsRampType.TmbRtLine;
    else if (this.cmb_ramptype.SelectedIndex == 2)
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampType = TriangleMeshBasedTpCalcParamsRampType.TmbRtHelical;
    else if (this.cmb_ramptype.SelectedIndex == 3)
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampType = TriangleMeshBasedTpCalcParamsRampType.TmbRtZigzag;
    else if (this.cmb_ramptype.SelectedIndex == 4)
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampType = TriangleMeshBasedTpCalcParamsRampType.TmbRtProfile;
    if (this.\u0002.Checked)
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampMode = TriangleMeshBasedTpCalcParamsRampMode.TmbRmAngle;
    else
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.RampMode = TriangleMeshBasedTpCalcParamsRampMode.TmbRmPitch;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1) => this.ControlUpdate();
}
