// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_Height
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

public class F_Height : Form
{
  public Button btn_cancel;
  internal Panel \u0002;
  internal CheckBox \u0003;
  internal PictureBox \u0001;
  internal ComboBox \u0001;
  internal System.Windows.Forms.Label \u0005;
  internal CheckBox \u0004;
  internal System.Windows.Forms.Label \u0006;
  public FormProperties PropertiesForm = new FormProperties();
  public GeoLib mwCamParameter = (GeoLib) null;
  public camParameters5 buCamParameter = (camParameters5) null;
  public MWCalculationOptions Configration = new MWCalculationOptions();
  public ToolBase5 Tool = (ToolBase5) null;
  public static List<string> Captions;
  internal IContainer \u0001 = (IContainer) null;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal System.Windows.Forms.Label \u0001;
  internal PictureBox \u0001;
  public Button btn_cancel;
  internal ImageList \u0001;
  internal Panel \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0003;
  internal NumericUpDown \u0002;
  internal System.Windows.Forms.Label \u0004;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == this.\u0001.Name)
      this.\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == ((F_SurfaceQuality) this).\u0002.Name)
    {
      this.\u0001.Image = (Image) ResourceImage.AdvancedAny;
      if (this.\u0003.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_SurfaceQuality) this).\u0001.Name)
    {
      this.\u0001.Image = (Image) ResourceImage.AdvancedCoordinate;
      if (this.\u0003.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == this.\u0004.Name)
      this.\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == ((F_SurfaceQuality) this).\u0001.Name)
    {
      this.\u0001.Image = (Image) ResourceImage.MaxDistance;
      if (this.\u0003.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_SurfaceQuality) this).\u0002.Name)
    {
      this.\u0001.Image = (Image) ResourceImage.MinDistance;
      if (this.\u0003.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_SurfaceQuality) this).\u0004.Name)
      this.\u0001.Image = (Image) ResourceImage.AdvancedArcFitFactor;
    else if (control2.Name == ((F_SurfaceQuality) this).\u0002.Name)
      this.\u0001.Image = (Image) ResourceImage.DeviationFactor;
    else if (control2.Name == ((F_SurfaceQuality) this).\u0001.Name)
    {
      this.\u0001.Image = (Image) ResourceImage.MaxDistance;
      if (this.\u0003.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_SurfaceQuality) this).\u0003.Name)
    {
      this.\u0001.Image = (Image) ResourceImage.MinDistance;
      if (this.\u0003.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    this.\u0003.Checked = false;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    ((F_SurfaceQuality) this).ControlUpdate();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_SurfaceQuality) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_SurfaceQuality) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_Height() => F_SurfaceQuality.Captions = new List<string>();

  public F_Height() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    ((F_ContourLink) this).\u0003.Enabled = true;
    ((F_ContourLink) this).\u0004.Enabled = true;
    if (this.Configration.Mode == CamMode.TriangularMesh)
    {
      if (this.Configration.CamTriMeshType == CamTriangularMeshType.ConstantZ)
      {
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf;
        ((F_ContourLink) this).\u0003.Enabled = false;
        ((F_ContourLink) this).\u0004.Enabled = false;
      }
      this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight;
      this.\u0002.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight;
      if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType == MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf)
        ((F_ContourLink) this).\u0005.Checked = true;
      else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType == MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromStock)
        ((F_ContourLink) this).\u0004.Checked = true;
      else
        ((F_ContourLink) this).\u0003.Checked = true;
      if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType == MachiningAreaHeightsParamsHeightsType.ShpHtAutomatic)
        this.\u0002.Checked = true;
      else
        this.\u0001.Checked = true;
    }
    else
    {
      this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight;
      this.\u0002.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight;
      if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType == MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf)
        ((F_ContourLink) this).\u0005.Checked = true;
      else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType == MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromStock)
        ((F_ContourLink) this).\u0004.Checked = true;
      else
        ((F_ContourLink) this).\u0003.Checked = true;
      if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType == MachiningAreaHeightsParamsHeightsType.ShpHtAutomatic)
        this.\u0002.Checked = true;
      else
        this.\u0001.Checked = true;
    }
    this.Refresh();
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
    \u0005.\u0002.\u0001(this);
    this.ControlUpdate();
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_ContourLink) this).btn_ok.Name)
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
      ((F_ContourLink) this).\u0003.Enabled = true;
      ((F_ContourLink) this).\u0002.Enabled = false;
    }
    else
    {
      ((F_ContourLink) this).\u0003.Enabled = false;
      ((F_ContourLink) this).\u0002.Enabled = true;
    }
  }

  public void Apply()
  {
    if (this.Configration.Mode == CamMode.TriangularMesh)
    {
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = (double) this.\u0001.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = (double) this.\u0002.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = !this.\u0002.Checked ? MachiningAreaHeightsParamsHeightsType.ShpHtUserDefined : MachiningAreaHeightsParamsHeightsType.ShpHtAutomatic;
      if (((F_ContourLink) this).\u0005.Checked)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf;
      else if (((F_ContourLink) this).\u0004.Checked)
      {
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromStock;
      }
      else
      {
        if (!((F_ContourLink) this).\u0003.Checked)
          return;
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromBoth;
      }
    }
    else
    {
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = (double) this.\u0001.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = (double) this.\u0002.Value;
      this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = !this.\u0002.Checked ? MachiningAreaHeightsParamsHeightsType.ShpHtUserDefined : MachiningAreaHeightsParamsHeightsType.ShpHtAutomatic;
      if (((F_ContourLink) this).\u0005.Checked)
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf;
      else if (((F_ContourLink) this).\u0004.Checked)
      {
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromStock;
      }
      else
      {
        if (!((F_ContourLink) this).\u0003.Checked)
          return;
        this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromBoth;
      }
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!this.PropertiesForm.Inited)
      return;
    this.PropertiesForm.Inited = false;
    this.Apply();
    this.ControlUpdate();
    this.PropertiesForm.Inited = true;
  }
}
