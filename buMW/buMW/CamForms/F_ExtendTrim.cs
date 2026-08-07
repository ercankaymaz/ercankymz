// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_ExtendTrim
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buEyeBaseVer5;
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

public class F_ExtendTrim : Form
{
  internal CheckBox \u0004;
  internal NumericUpDown \u0002;
  internal CheckBox \u0005;
  internal NumericUpDown \u0003;
  internal CheckBox \u0006;
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
  internal Panel \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal RadioButton \u0001;
  internal NumericUpDown \u0001;
  internal RadioButton \u0002;
  internal NumericUpDown \u0002;
  internal Panel \u0002;
  internal System.Windows.Forms.Label \u0003;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_FeedAdvanced) this).PropertiesForm.Inited)
      return;
    ((F_FeedAdvanced) this).PropertiesForm.Inited = false;
    ((F_FeedAdvanced) this).Apply();
    ((F_FeedAdvanced) this).ControlUpdate();
    ((F_FeedAdvanced) this).PropertiesForm.Inited = true;
    this.\u0004(obj0, (EventArgs) null);
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_FeedAdvanced) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_FeedAdvanced) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ExtendTrim() => F_FeedAdvanced.Captions = new List<string>();

  public F_ExtendTrim() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    if (this.mwCamParameter.MachParam.ContourStartExtraLength.IsPercent)
      ((F_SharpCorner) this).\u0003.Checked = this.mwCamParameter.MachParam.ContourStartExtraLength.IsPercent;
    else
      ((F_SharpCorner) this).\u0004.Checked = true;
    if (this.mwCamParameter.MachParam.ContourEndExtraLength.IsPercent)
      this.\u0001.Checked = this.mwCamParameter.MachParam.ContourEndExtraLength.IsPercent;
    else
      this.\u0002.Checked = true;
    if (this.mwCamParameter.MachParam.ContourStartExtraLength.IsPercent)
      ((F_SharpCorner) this).\u0003.Value = (Decimal) this.mwCamParameter.MachParam.ContourStartExtraLength.Percent;
    else
      ((F_SharpCorner) this).\u0004.Value = (Decimal) this.mwCamParameter.MachParam.ContourStartExtraLength.Value;
    if (this.mwCamParameter.MachParam.ContourEndExtraLength.IsPercent)
      this.\u0002.Value = (Decimal) this.mwCamParameter.MachParam.ContourEndExtraLength.Percent;
    else
      this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.ContourEndExtraLength.Value;
    ((F_SharpCorner) this).\u0002.Checked = this.mwCamParameter.MachParam.ExtendTrimGapsFlg;
    this.ControlUpdate();
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
    if (((F_SharpCorner) this).\u0003.Checked)
    {
      ((F_SharpCorner) this).\u0003.Enabled = true;
      ((F_SharpCorner) this).\u0004.Enabled = false;
    }
    else
    {
      ((F_SharpCorner) this).\u0003.Enabled = false;
      ((F_SharpCorner) this).\u0004.Enabled = true;
    }
    if (this.\u0001.Checked)
    {
      this.\u0002.Enabled = true;
      this.\u0001.Enabled = false;
    }
    else
    {
      this.\u0002.Enabled = false;
      this.\u0001.Enabled = true;
    }
  }

  public void Apply()
  {
    if (((F_SharpCorner) this).\u0003.Checked)
      this.mwCamParameter.MachParam.ContourStartExtraLength = new PercentOrValueParameter(this.mwCamParameter.Units, true)
      {
        Percent = (double) ((F_SharpCorner) this).\u0003.Value
      };
    else
      this.mwCamParameter.MachParam.ContourStartExtraLength = new PercentOrValueParameter(this.mwCamParameter.Units, false)
      {
        Value = (double) ((F_SharpCorner) this).\u0004.Value
      };
    if (this.\u0001.Checked)
      this.mwCamParameter.MachParam.ContourEndExtraLength = new PercentOrValueParameter(this.mwCamParameter.Units, true)
      {
        Percent = (double) this.\u0002.Value
      };
    else
      this.mwCamParameter.MachParam.ContourEndExtraLength = new PercentOrValueParameter(this.mwCamParameter.Units, false)
      {
        Value = (double) this.\u0001.Value
      };
    this.mwCamParameter.MachParam.ExtendTrimGapsFlg = ((F_SharpCorner) this).\u0002.Checked;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1) => this.ControlUpdate();

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!this.PropertiesForm.Inited)
      return;
    this.PropertiesForm.Inited = true;
  }
}
