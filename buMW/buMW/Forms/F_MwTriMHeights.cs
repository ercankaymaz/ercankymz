// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwTriMHeights
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using ModuleWorks.ToolpathParameters;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW.Forms;

public class F_MwTriMHeights : Form
{
  public static MWParameters varCamMeshRough5AX;
  public static MWParameters varCamSurfaceParallel;
  private IContainer \u0001 = (IContainer) null;
  public FormProperties Properties;
  public MachiningParams Par;
  private IContainer \u0001;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal Label \u0001;
  internal PictureBox \u0001;
  public Button btn_cancel;
  internal ImageList \u0001;
  internal Panel \u0001;
  internal Label \u0002;
  internal NumericUpDown \u0001;
  internal Label \u0003;
  internal NumericUpDown \u0002;
  internal Label \u0004;
  public Button btn_ok;
  internal ImageList \u0002;
  internal Panel \u0002;
  internal Panel \u0003;

  public F_MwTriMHeights() => \u0005.\u0002.\u0001((Form1) this);

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.\u0001 != null ? 1 : 0)) != 0)
      this.\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwTriMHeights() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.\u0001.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight;
    this.\u0002.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight;
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType == MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf)
      ((F_MwGaugeAdvancedSettings) this).\u0005.Checked = true;
    else if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType == MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromStock)
      ((F_MwGaugeAdvancedSettings) this).\u0004.Checked = true;
    else
      ((F_MwGaugeAdvancedSettings) this).\u0003.Checked = true;
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType == MachiningAreaHeightsParamsHeightsType.ShpHtAutomatic)
      this.\u0002.Checked = true;
    else
      this.\u0001.Checked = true;
    this.UpdateControlFromType();
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    this.Apply();
    this.Properties.Result = DialogResult.OK;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void UpdateControlFromType()
  {
    if (this.\u0002.Checked)
    {
      this.\u0003.Enabled = true;
      this.\u0002.Enabled = false;
    }
    else
    {
      this.\u0003.Enabled = false;
      this.\u0002.Enabled = true;
    }
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern == TriangleMeshBasedTpCalcParamsPattern.TcTmbRough)
    {
      ((F_MwGaugeAdvancedSettings) this).\u0003.Enabled = true;
      ((F_MwGaugeAdvancedSettings) this).\u0004.Enabled = true;
      ((F_MwGaugeAdvancedSettings) this).\u0005.Enabled = true;
    }
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.Pattern != TriangleMeshBasedTpCalcParamsPattern.TcTmbParallelCuts)
      return;
    ((F_MwGaugeAdvancedSettings) this).\u0003.Enabled = false;
    ((F_MwGaugeAdvancedSettings) this).\u0004.Enabled = false;
    ((F_MwGaugeAdvancedSettings) this).\u0005.Enabled = true;
  }

  public void Apply()
  {
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = (double) this.\u0001.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = (double) this.\u0002.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = !this.\u0002.Checked ? MachiningAreaHeightsParamsHeightsType.ShpHtUserDefined : MachiningAreaHeightsParamsHeightsType.ShpHtAutomatic;
    if (((F_MwGaugeAdvancedSettings) this).\u0005.Checked)
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf;
    else if (((F_MwGaugeAdvancedSettings) this).\u0004.Checked)
    {
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromStock;
    }
    else
    {
      if (!((F_MwGaugeAdvancedSettings) this).\u0003.Checked)
        return;
      this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromBoth;
    }
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!this.Properties.Inited)
      return;
    this.Properties.Inited = false;
    this.Apply();
    this.UpdateControlFromType();
    this.Properties.Inited = true;
  }
}
