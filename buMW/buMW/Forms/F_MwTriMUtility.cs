// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwTriMUtility
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

public class F_MwTriMUtility : Form
{
  public Button btn_cancel;
  internal System.Windows.Forms.Label \u0001;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal NumericUpDown \u0002;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  internal IContainer \u0001 = (IContainer) null;
  internal Panel \u0001;
  internal CheckBox \u0001;
  internal CheckBox \u0002;
  internal System.Windows.Forms.Label \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal PictureBox \u0001;
  public Button btn_cancel;
  internal ImageList \u0001;
  public Button btn_ok;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal NumericUpDown \u0001;
  internal Panel \u0002;
  internal NumericUpDown \u0002;
  internal CheckBox \u0003;
  internal NumericUpDown \u0003;
  internal CheckBox \u0004;
  internal CheckBox \u0005;
  internal System.Windows.Forms.Label \u0003;
  internal Panel \u0003;
  internal System.Windows.Forms.Label \u0004;
  internal System.Windows.Forms.Label \u0005;
  internal CheckBox \u0006;

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MwTriMUpDownAdvanced) this).Properties.Result = DialogResult.Cancel;
    if (((F_MwTriMUpDownAdvanced) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MwTriMUpDownAdvanced) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void UpdateControlFromType()
  {
  }

  public void Apply()
  {
    ((F_MwTriMUpDownAdvanced) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinHeightChange = (double) this.\u0002.Value;
    ((F_MwTriMUpDownAdvanced) this).Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.OverlapDistance = (double) this.\u0001.Value;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwTriMUpDownAdvanced) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwTriMUpDownAdvanced) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwTriMUtility() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.\u0003.Checked = this.Par.FeedRateForDirectSplineLinksParams.FeedRateForLinksBetweenRegionsFlg;
    this.\u0004.Checked = this.Par.FeedRateForDirectSplineLinksParams.FeedRateForLinksBetweenSlicesFlg;
    this.\u0005.Checked = this.Par.FeedRateForDirectSplineLinksParams.FeedRateForAreaLinksFlg;
    this.\u0002.Value = (Decimal) this.Par.FeedRateForDirectSplineLinksParams.FeedRateForLinksBetweenRegions;
    this.\u0003.Value = (Decimal) this.Par.FeedRateForDirectSplineLinksParams.FeedRateForLinksBetweenSlices;
    ((F_MwTriMPencil) this).\u0006.Value = (Decimal) this.Par.FeedRateForDirectSplineLinksParams.FeedRateForAreaLinks;
    this.\u0002.Checked = this.Par.FeedControlZoneParams.Status;
    this.\u0006.Checked = this.Par.DampAxialShiftFlg;
    this.\u0001.Value = (Decimal) this.Par.RapidFeedrate;
    this.\u0001.Checked = this.Par.RapidFeedFlg;
    if (this.Par.AxialShiftType == MachiningParamsAxialShiftType.AstConstForEachContour)
      this.\u0002.Checked = true;
    else if (this.Par.AxialShiftType == MachiningParamsAxialShiftType.AstGradualForAllCuts)
      this.\u0001.Checked = true;
    else if (this.Par.AxialShiftType == MachiningParamsAxialShiftType.AstGradualForEachContour)
      ((F_MwTriMPencil) this).\u0003.Checked = true;
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
    ((F_MwTriMPencil) this).Apply();
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
      this.\u0004.Enabled = false;
      ((F_MwTriMPencil) this).\u0004.Enabled = false;
    }
    if (this.\u0001.Checked)
    {
      this.\u0004.Enabled = true;
      ((F_MwTriMPencil) this).\u0004.Enabled = true;
    }
    if (((F_MwTriMPencil) this).\u0003.Checked)
    {
      this.\u0004.Enabled = true;
      ((F_MwTriMPencil) this).\u0004.Enabled = true;
    }
    this.\u0001.Enabled = this.\u0001.Checked;
    ((F_MwTriMPencil) this).\u0006.Enabled = this.\u0005.Checked;
    this.\u0002.Enabled = this.\u0003.Checked;
    this.\u0003.Enabled = this.\u0004.Checked;
  }
}
