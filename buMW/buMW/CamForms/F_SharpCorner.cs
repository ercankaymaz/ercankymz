// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_SharpCorner
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

public class F_SharpCorner : Form
{
  internal RadioButton \u0003;
  internal RadioButton \u0004;
  internal NumericUpDown \u0003;
  internal NumericUpDown \u0004;
  internal CheckBox \u0002;
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
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal NumericUpDown \u0002;
  internal System.Windows.Forms.Label \u0003;
  internal NumericUpDown \u0003;
  internal System.Windows.Forms.Label \u0004;
  internal System.Windows.Forms.Label \u0005;

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_ExtendTrim) this).PropertiesForm.Inited)
      return;
    ((F_ExtendTrim) this).PropertiesForm.Inited = false;
    ((F_ExtendTrim) this).Apply();
    ((F_ExtendTrim) this).ControlUpdate();
    ((F_ExtendTrim) this).PropertiesForm.Inited = true;
    this.\u0005(obj0, (EventArgs) null);
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == this.\u0002.Name)
      ((F_ExtendTrim) this).\u0001.Image = (Image) ResourceImage.ExtendTrimGaps;
    else if (control2.Name == this.\u0003.Name | control2.Name == this.\u0004.Name | control2.Name == this.\u0003.Name | control2.Name == this.\u0004.Name)
    {
      ((F_ExtendTrim) this).\u0001.Image = (Image) ResourceImage.ExtendTrimStartPercToolDia;
    }
    else
    {
      if (!(control2.Name == ((F_ExtendTrim) this).\u0002.Name | control2.Name == ((F_ExtendTrim) this).\u0001.Name | control2.Name == ((F_ExtendTrim) this).\u0001.Name | control2.Name == ((F_ExtendTrim) this).\u0002.Name))
        return;
      ((F_ExtendTrim) this).\u0001.Image = (Image) ResourceImage.ExtendTrimEndPercToolDia;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ExtendTrim) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ExtendTrim) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_SharpCorner() => F_ExtendTrim.Captions = new List<string>();

  public F_SharpCorner() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    if (this.Configration.Mode == CamMode.WireFrame)
    {
      ((F_Tabs) this).cmb_sharpcornertype.Items.Clear();
      ((F_Tabs) this).cmb_sharpcornertype.Items.Add((object) buMWCaptions.SharpCorners[0]);
      ((F_Tabs) this).cmb_sharpcornertype.Items.Add((object) buMWCaptions.SharpCorners[1]);
      ((F_Tabs) this).cmb_sharpcornertype.Items.Add((object) buMWCaptions.SharpCorners[2]);
      ((F_Tabs) this).cmb_sharpcornertype.Items.Add((object) buMWCaptions.SharpCorners[3]);
      if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCorners == WireframeBasedTpCalcParamsSharpCorners.WfbScExtension)
      {
        ((F_Tabs) this).cmb_sharpcornertype.SelectedIndex = 0;
        ((F_Tabs) this).\u0002.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersLength.IsPercent;
        if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersLength.IsPercent)
          ((F_Tabs) this).\u0004.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersLength.Percent;
        else
          this.\u0003.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersLength.Value;
      }
      else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCorners == WireframeBasedTpCalcParamsSharpCorners.WfbScLoop)
      {
        ((F_Tabs) this).\u0002.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersLoopRadius.IsPercent;
        ((F_Tabs) this).cmb_sharpcornertype.SelectedIndex = 1;
        if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersLoopRadius.IsPercent)
          ((F_Tabs) this).\u0004.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersLoopRadius.Percent;
        else
          this.\u0003.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersLoopRadius.Value;
      }
      else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCorners == WireframeBasedTpCalcParamsSharpCorners.WfbScFishtail)
      {
        ((F_Tabs) this).\u0002.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersLength.IsPercent;
        ((F_Tabs) this).cmb_sharpcornertype.SelectedIndex = 2;
        if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersLength.IsPercent)
          ((F_Tabs) this).\u0004.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersLength.Percent;
        else
          this.\u0003.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersLength.Value;
      }
      else if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCorners == WireframeBasedTpCalcParamsSharpCorners.WfbScBisectorLine)
      {
        ((F_Tabs) this).\u0002.Checked = this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersLength.IsPercent;
        ((F_Tabs) this).cmb_sharpcornertype.SelectedIndex = 3;
        if (this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersLength.IsPercent)
          ((F_Tabs) this).\u0004.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersLength.Percent;
        else
          this.\u0003.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersLength.Value;
      }
      this.\u0002.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersStartAngle;
      this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersEndAngle;
    }
    ((F_Tabs) this).ControlUpdate();
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
      ((F_Tabs) this).Apply();
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
}
