// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_RestFinish
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

public class F_RestFinish : Form
{
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  internal Panel \u0002;
  internal System.Windows.Forms.Label \u0004;
  internal RadioButton \u0004;
  internal RadioButton \u0005;
  internal CheckBox \u0001;
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
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal PictureBox \u0001;
  internal ImageList \u0002;
  internal Panel \u0001;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal Panel \u0002;
  internal System.Windows.Forms.Label \u0003;
  internal NumericUpDown \u0002;
  internal System.Windows.Forms.Label \u0004;
  internal System.Windows.Forms.Label \u0005;
  internal System.Windows.Forms.Label \u0006;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    if (!(((F_2DContainment) this).PropertiesForm.TouchPad & !this.\u0001.Checked))
      return;
    NumericUpDown numericUpDown = new NumericUpDown();
    NumericUpDown Ctrl = (NumericUpDown) obj0;
    if (!Ctrl.Enabled)
      return;
    buControlCommands.ShowKeyPadWinControl((Form) this, (Control) Ctrl);
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_2DContainment) this).\u0001.Name)
    {
      if (this.\u0003.Checked)
        ((F_2DContainment) this).\u0001.Image = (Image) ResourceImage._2DContainmentOffsetInsideRough;
      else if (((F_2DContainment) this).\u0001.Checked)
        ((F_2DContainment) this).\u0001.Image = (Image) ResourceImage._2DContainmentOffsetOutsideRough;
      if (this.\u0001.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == this.\u0002.Name)
    {
      ((F_2DContainment) this).\u0001.Image = (Image) ResourceImage._2DContainmentCenterRough;
      if (this.\u0001.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_2DContainment) this).\u0001.Name)
    {
      ((F_2DContainment) this).\u0001.Image = (Image) ResourceImage._2DContainmentOutsideRough;
      if (this.\u0001.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == this.\u0003.Name)
    {
      ((F_2DContainment) this).\u0001.Image = (Image) ResourceImage._2DContainmentInsideRough;
      if (this.\u0001.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == this.\u0004.Name)
    {
      ((F_2DContainment) this).\u0001.Image = (Image) ResourceImage.ToolTipPoint2dContainment;
      if (this.\u0001.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == this.\u0005.Name)
    {
      ((F_2DContainment) this).\u0001.Image = (Image) ResourceImage.ToolContactPoint2dContainment;
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
    if ((!disposing ? 0 : (((F_2DContainment) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_2DContainment) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_RestFinish() => F_2DContainment.Captions = new List<string>();

  public F_RestFinish() => \u0005.\u0002.\u0001(this);

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
      ((F_DrillLine) this).\u0003.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.ExpandRestArea;
      ((F_DrillLine) this).\u0004.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.DetectThickerThan;
      this.\u0002.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.BigToolCornerRadius;
      this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.RestFinishingBigToolDia;
      if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.Type == MachiningAreaRestFinishingParamsType.RfBasedOnTool)
        this.\u0002.Checked = true;
      else
        this.\u0001.Checked = true;
    }
    else if (this.Configration.Mode == CamMode.WireFrame)
    {
      ((F_DrillLine) this).\u0003.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRestFinishingParams.ExpandRestArea;
      ((F_DrillLine) this).\u0004.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRestFinishingParams.DetectThickerThan;
      this.\u0002.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRestFinishingParams.BigToolCornerRadius;
      this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRestFinishingParams.RestFinishingBigToolDia;
      if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRestFinishingParams.Type == MachiningAreaRestFinishingParamsType.RfBasedOnTool)
        this.\u0002.Checked = true;
      else
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
    if (this.\u0002.Checked)
    {
      this.\u0002.Enabled = true;
      ((F_DrillLine) this).\u0003.Enabled = false;
    }
    else
    {
      this.\u0002.Enabled = false;
      ((F_DrillLine) this).\u0003.Enabled = true;
    }
  }

  public void Apply()
  {
    if (this.Configration.Mode == CamMode.TriangularMesh)
    {
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.ExpandRestArea = (double) ((F_DrillLine) this).\u0003.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.DetectThickerThan = (double) ((F_DrillLine) this).\u0004.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.BigToolCornerRadius = (double) this.\u0002.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.RestFinishingBigToolDia = (double) this.\u0001.Value;
      if (this.\u0002.Checked)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.Type = MachiningAreaRestFinishingParamsType.RfBasedOnTool;
      else
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaRestFinishingParams.Type = MachiningAreaRestFinishingParamsType.RfBasedOnStock;
    }
    else
    {
      if (this.Configration.Mode != CamMode.WireFrame)
        return;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRestFinishingParams.ExpandRestArea = (double) ((F_DrillLine) this).\u0003.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRestFinishingParams.DetectThickerThan = (double) ((F_DrillLine) this).\u0004.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRestFinishingParams.BigToolCornerRadius = (double) this.\u0002.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRestFinishingParams.RestFinishingBigToolDia = (double) this.\u0001.Value;
      if (this.\u0002.Checked)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRestFinishingParams.Type = MachiningAreaRestFinishingParamsType.RfBasedOnTool;
      else
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaRestFinishingParams.Type = MachiningAreaRestFinishingParamsType.RfBasedOnStock;
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!this.PropertiesForm.Inited)
      return;
    this.PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] KeyEventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!(obj1.KeyCode == Keys.Return | obj1.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKeyDown(this.Controls, result, obj1.Shift);
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    if (!(this.PropertiesForm.TouchPad & !((F_DrillLine) this).\u0001.Checked))
      return;
    NumericUpDown numericUpDown = new NumericUpDown();
    NumericUpDown Ctrl = (NumericUpDown) obj0;
    if (!Ctrl.Enabled)
      return;
    buControlCommands.ShowKeyPadWinControl((Form) this, (Control) Ctrl);
  }
}
