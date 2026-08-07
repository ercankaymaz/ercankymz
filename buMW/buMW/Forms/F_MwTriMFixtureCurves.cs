// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwTriMFixtureCurves
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW.Forms;

public class F_MwTriMFixtureCurves : Form
{
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal ImageList \u0002;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  internal IContainer \u0001 = (IContainer) null;
  internal System.Windows.Forms.Label \u0001;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal PictureBox \u0001;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_MWTriMDynamicalHolderColl) this).Properties.Inited)
      return;
    ((F_MWTriMDynamicalHolderColl) this).Properties.Inited = false;
    ((F_MWTriMDynamicalHolderColl) this).Apply();
    ((F_MWTriMDynamicalHolderColl) this).UpdateControlFromType();
    ((F_MWTriMDynamicalHolderColl) this).Properties.Inited = true;
    this.\u0004(obj0, (EventArgs) null);
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!(control2.Tag != null & ((F_MWTriMDynamicalHolderColl) this).Properties.Inited))
      return;
    ((F_MWTriMDynamicalHolderColl) this).\u0001.Image = this.\u0002.Images[Convert.ToInt32(control2.Tag)];
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MWTriMDynamicalHolderColl) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MWTriMDynamicalHolderColl) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwTriMFixtureCurves() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FixtureCurveMode == TriangleMeshBasedTpCalcParamsFixtureCurveMode.FcmCenter)
      ((F_MwTriMFlatland) this).\u0001.Checked = true;
    else if (this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FixtureCurveMode == TriangleMeshBasedTpCalcParamsFixtureCurveMode.FcmOutside)
      ((F_MwTriMFlatland) this).\u0002.Checked = true;
    this.\u0001.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.FixtureCurveHeight;
    this.UpdateControlFromType();
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
    ((F_MwTriMFlatland) this).Apply();
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
