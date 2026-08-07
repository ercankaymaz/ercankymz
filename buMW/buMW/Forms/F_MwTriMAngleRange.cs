// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwTriMAngleRange
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

public class F_MwTriMAngleRange : Form
{
  internal System.Windows.Forms.Label \u0004;
  internal RadioButton \u0004;
  internal RadioButton \u0005;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  private IContainer \u0001 = (IContainer) null;
  internal System.Windows.Forms.Label \u0001;
  internal Panel \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0003;
  internal Panel \u0002;
  internal System.Windows.Forms.Label \u0004;
  internal NumericUpDown \u0002;
  internal RadioButton \u0001;
  internal Panel \u0003;
  internal RadioButton \u0002;
  internal ImageList \u0001;
  internal System.Windows.Forms.Label \u0005;
  internal PictureBox \u0001;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MwTriM2dContainment) this).UpdateControlFromType();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwTriM2dContainment) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwTriM2dContainment) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwTriMAngleRange() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.\u0002.Value = (Decimal) this.Par.ShallowAndSteepAreaParams.SlopeAngleStart;
    this.\u0001.Value = (Decimal) this.Par.ShallowAndSteepAreaParams.SlopeAngleEnd;
    if (this.Par.ShallowAndSteepAreaParams.MachiningAreaType == ShallowAndSteepAreaParamsMachiningAreaType.MatSteepAreas)
      this.\u0002.Checked = true;
    else
      this.\u0001.Checked = true;
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
    ((F_MwTriMDepthAdvanced) this).Apply();
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
  }
}
