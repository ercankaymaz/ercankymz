// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MWTriMDynamicalHolderColl
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW.Forms;

public class F_MWTriMDynamicalHolderColl : Form
{
  internal CheckBox \u000E;
  internal CheckBox \u000F;
  internal Panel \u0005;
  public static byte f000290;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  internal IContainer \u0001 = (IContainer) null;
  internal CheckBox \u0001;
  internal CheckBox \u0002;
  internal System.Windows.Forms.Label \u0001;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal PictureBox \u0001;

  internal void \u0006([In] object obj0, [In] EventArgs obj1)
  {
    if (!(((F_MwTriMDepthAdvanced) this).\u0001.SelectedIndex >= 0 & ((F_MwTriMDepthAdvanced) this).\u0001.SelectedIndex <= ((F_MwTriMDepthAdvanced) this).\u0001.Items.Count - 1))
      return;
    ((F_MwTriMDepthAdvanced) this).\u0001.Items.RemoveAt(((F_MwTriMDepthAdvanced) this).\u0001.SelectedIndex);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwTriMDepthAdvanced) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwTriMDepthAdvanced) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public abstract void m0000EA();

  public F_MWTriMDynamicalHolderColl() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.\u0001.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.DynamicHolderCollCtrlParams.Clearance;
    this.\u0001.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.DynamicHolderCollCtrlParams.CheckWithInProcessStockFlg;
    this.\u0002.Checked = this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.DynamicHolderCollCtrlParams.CheckWithMachiningSurfacesFlg;
    this.UpdateControlFromType();
    this.\u0001.Image = (Image) null;
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
    this.\u0001.Enabled = this.\u0002.Checked | this.\u0001.Checked;
    this.\u0001.Enabled = this.\u0002.Checked | this.\u0001.Checked;
  }

  public void Apply()
  {
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.DynamicHolderCollCtrlParams.Clearance = (double) this.\u0001.Value;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.DynamicHolderCollCtrlParams.CheckWithInProcessStockFlg = this.\u0001.Checked;
    this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.DynamicHolderCollCtrlParams.CheckWithMachiningSurfacesFlg = this.\u0002.Checked;
  }
}
