// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_DrillLine
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

public class F_DrillLine : Form
{
  internal NumericUpDown \u0003;
  internal Panel \u0003;
  internal Button \u0001;
  internal System.Windows.Forms.Label \u0007;
  internal System.Windows.Forms.Label \u0008;
  internal NumericUpDown \u0004;
  internal CheckBox \u0001;
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
  internal CheckBox \u0001;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0001;
  internal NumericUpDown \u0002;
  internal System.Windows.Forms.Label \u0002;
  internal Panel \u0001;
  internal System.Windows.Forms.Label \u0003;
  internal System.Windows.Forms.Label \u0004;
  internal NumericUpDown \u0003;
  internal NumericUpDown \u0004;
  internal Panel \u0002;
  internal NumericUpDown \u0005;
  internal System.Windows.Forms.Label \u0005;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal NumericUpDown \u0006;
  internal System.Windows.Forms.Label \u0006;
  internal Panel \u0003;
  internal System.Windows.Forms.Label \u0007;
  internal System.Windows.Forms.Label \u0008;
  internal Panel \u0004;
  internal System.Windows.Forms.Label \u000E;
  internal System.Windows.Forms.Label \u000F;
  internal System.Windows.Forms.Label \u0010;
  internal Panel \u0005;
  internal Button \u0001;
  internal System.Windows.Forms.Label \u0011;
  internal NumericUpDown \u0007;
  internal System.Windows.Forms.Label \u0012;
  internal System.Windows.Forms.Label \u0013;
  internal System.Windows.Forms.Label \u0014;
  internal NumericUpDown \u0008;
  internal NumericUpDown \u000E;
  internal PictureBox \u0001;
  internal ImageList \u0002;
  internal CheckBox \u0002;
  internal Button \u0002;
  internal Panel \u0006;
  internal CheckBox \u0003;
  internal CheckBox \u0004;
  internal System.Windows.Forms.Label \u0015;
  internal System.Windows.Forms.Label \u0016;
  internal System.Windows.Forms.Label \u0017;
  internal NumericUpDown \u000F;
  internal NumericUpDown \u0010;
  internal Panel \u0007;
  internal RadioButton \u0003;
  internal RadioButton \u0004;
  internal CheckBox \u0005;
  internal PictureBox \u0002;
  internal System.Windows.Forms.Label \u0018;
  internal NumericUpDown \u0011;
  internal NumericUpDown \u0012;
  internal System.Windows.Forms.Label \u0019;
  internal System.Windows.Forms.Label \u001A;
  internal NumericUpDown \u0013;
  internal System.Windows.Forms.Label \u001B;
  internal NumericUpDown \u0014;
  public Panel pnl_rotation;

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_RestFinish) this).PropertiesForm.Inited)
      return;
    ((F_RestFinish) this).PropertiesForm.Inited = false;
    ((F_RestFinish) this).Apply();
    ((F_RestFinish) this).ControlUpdate();
    ((F_RestFinish) this).PropertiesForm.Inited = true;
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_RestFinish) this).\u0002.Name)
    {
      ((F_RestFinish) this).\u0001.Image = (Image) ResourceImage.RestFinishTriMeshParallelCut;
      if (this.\u0001.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_RestFinish) this).\u0001.Name)
    {
      ((F_RestFinish) this).\u0001.Image = (Image) ResourceImage.RestFinishingStockTriMeshParallelCuts;
      if (this.\u0001.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_RestFinish) this).\u0001.Name)
      ((F_RestFinish) this).\u0001.Image = (Image) ResourceImage.RestFinishBigToolDia;
    else if (control2.Name == ((F_RestFinish) this).\u0002.Name)
      ((F_RestFinish) this).\u0001.Image = (Image) ResourceImage.RestFinishBigToolCoornerRadius;
    else if (control2.Name == this.\u0004.Name)
      ((F_RestFinish) this).\u0001.Image = (Image) ResourceImage.RestFinishDetectThickerThan;
    else if (control2.Name == this.\u0003.Name)
    {
      ((F_RestFinish) this).\u0001.Image = (Image) ResourceImage.NoImage;
      if (this.\u0001.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    this.\u0001.Checked = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_RestFinish) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_RestFinish) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_DrillLine() => F_RestFinish.Captions = new List<string>();

  public F_DrillLine() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.\u0002.Visible = this.PropertiesForm.ShowHelp;
    this.\u0005.Value = (Decimal) this.mwCamParameter.MachParam.CutTolerance;
    this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.PlungeFeedRate;
    this.\u0002.Value = (Decimal) this.mwCamParameter.MachParam.RetractFeedRate;
    this.\u0008.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.RetractPlaneIncremental;
    this.\u000E.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.ClearancePlaneHeight;
    this.\u0007.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.AirMoveSafetyDistance;
    this.\u0004.Value = (Decimal) this.buCamParameter.Drill.EndHeight;
    this.\u0003.Value = (Decimal) this.buCamParameter.Drill.StartHeight;
    this.\u0006.Value = (Decimal) this.buCamParameter.Speeds.SpindleSpeed;
    this.\u0001.Checked = this.mwCamParameter.MachParam.RapidRetractFlg;
    this.\u0004.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.DrillingBasedTpCalcParams.PeckDrillFlg;
    this.\u0003.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.DrillingBasedTpCalcParams.FullRetractFlg;
    this.\u0010.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.DrillingBasedTpCalcParams.PeckDepth;
    this.\u000F.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.DrillingBasedTpCalcParams.MinRetractDistance;
    this.\u0012.Value = (Decimal) this.buCamParameter.Strategy.ContantTangent;
    this.\u0013.Value = (Decimal) this.buCamParameter.Strategy.MaxTangentValue;
    this.\u0014.Value = (Decimal) this.buCamParameter.Strategy.MinTangentValue;
    this.\u0011.Value = (Decimal) this.buCamParameter.Strategy.TangentOffset;
    ((F_TriMeshConstantZ) this).\u0016.Value = (Decimal) this.buCamParameter.Drill.StartAngle;
    ((F_TriMeshConstantZ) this).\u0015.Value = (Decimal) this.buCamParameter.Drill.EndAngle;
    ((F_TriMeshConstantZ) this).\u0006.Checked = this.buCamParameter.Drill.IncremantalRotation;
    if (this.buCamParameter.Strategy.UseContantTangent)
    {
      this.\u0004.Checked = true;
      this.\u0003.Checked = false;
    }
    else
    {
      this.\u0004.Checked = false;
      this.\u0003.Checked = true;
    }
    this.\u0005.Checked = this.buCamParameter.Strategy.UseTangentLimit;
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
    this.pnl_rotation.Visible = false;
    this.\u0007.Visible = false;
    if (this.Configration.CamDrillMode == CamDrillMode.Rotation)
    {
      this.pnl_rotation.Visible = true;
      this.\u0007.Visible = true;
    }
    else if (this.Configration.CamDrillMode == CamDrillMode.Tangent)
      this.\u0007.Visible = true;
    this.Refresh();
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
    \u0005.\u0002.\u0001(this);
    this.ControlUpdate();
  }

  public void ControlUpdate()
  {
    this.\u0015.Enabled = this.\u0004.Checked;
    this.\u0010.Enabled = this.\u0004.Checked;
    this.\u0017.Enabled = this.\u0004.Checked;
    this.\u000F.Enabled = this.\u0004.Checked;
    this.\u0003.Enabled = this.\u0004.Checked;
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
    if (control2.Name == this.\u0002.Name)
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
      }
    }
    if (control2.Name == this.\u0001.Name)
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
    if (!(control2.Name == ((F_TriMeshConstantZ) this).\u0003.Name))
      return;
    F_SortingSettings fSortingSettings = new F_SortingSettings();
    fSortingSettings.SortSetting = new SortSettings(this.buCamParameter.Sorting);
    fSortingSettings.Init();
    int num1 = (int) fSortingSettings.ShowDialog();
    if (fSortingSettings.PropertiesForm.Result != DialogResult.OK)
      return;
    this.buCamParameter.Sorting = new SortSettings(fSortingSettings.SortSetting);
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
}
