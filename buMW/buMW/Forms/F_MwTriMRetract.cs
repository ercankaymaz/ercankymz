// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwTriMRetract
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

public class F_MwTriMRetract : Form
{
  internal Button \u0001;
  internal System.Windows.Forms.Label \u0007;
  internal System.Windows.Forms.Label \u0008;
  internal NumericUpDown \u0004;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  internal IContainer \u0001 = (IContainer) null;
  internal Panel \u0001;
  internal System.Windows.Forms.Label \u0001;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal CheckBox \u0001;
  internal CheckBox \u0002;
  internal CheckBox \u0003;
  public ComboBox combo_type;
  internal Panel \u0002;
  internal System.Windows.Forms.Label \u0003;
  internal NumericUpDown \u0002;
  internal System.Windows.Forms.Label \u0004;
  internal NumericUpDown \u0003;
  internal System.Windows.Forms.Label \u0005;
  internal NumericUpDown \u0004;
  internal System.Windows.Forms.Label \u0006;
  internal Panel \u0003;
  internal System.Windows.Forms.Label \u0007;
  public ComboBox combo_heights;
  internal System.Windows.Forms.Label \u0008;
  public ComboBox combo_dir;
  internal System.Windows.Forms.Label \u000E;
  internal System.Windows.Forms.Label \u000F;
  internal Panel \u0004;
  internal System.Windows.Forms.Label \u0010;
  internal NumericUpDown \u0005;
  internal System.Windows.Forms.Label \u0011;
  internal NumericUpDown \u0006;
  internal NumericUpDown \u0007;
  internal CheckBox \u0004;
  internal CheckBox \u0005;
  internal System.Windows.Forms.Label \u0012;
  internal Panel \u0005;
  internal System.Windows.Forms.Label \u0013;
  internal NumericUpDown \u0008;
  internal System.Windows.Forms.Label \u0014;
  internal NumericUpDown \u000E;
  public ComboBox combo_distances;
  internal System.Windows.Forms.Label \u0015;
  internal System.Windows.Forms.Label \u0016;
  internal NumericUpDown \u000F;
  internal System.Windows.Forms.Label \u0017;
  internal NumericUpDown \u0010;
  internal System.Windows.Forms.Label \u0018;
  internal System.Windows.Forms.Label \u0019;
  internal PictureBox \u0001;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_MwTriMRestFinish) this).Properties.Inited)
      return;
    ((F_MwTriMRestFinish) this).Properties.Inited = false;
    ((F_MwTriMRestFinish) this).Apply();
    ((F_MwTriMRestFinish) this).UpdateControlFromType();
    ((F_MwTriMRestFinish) this).Properties.Inited = true;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!(control2.Tag != null & ((F_MwTriMRestFinish) this).Properties.Inited))
      return;
    ((F_MwTriMRestFinish) this).\u0001.Image = ((F_MwTriMRestFinish) this).\u0002.Images[Convert.ToInt32(control2.Tag)];
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwTriMRestFinish) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwTriMRestFinish) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwTriMRetract() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.\u0005.Value = (Decimal) this.Par.LinkParams.AngleStepForFeedMoves;
    this.\u0001.Value = (Decimal) this.Par.LinkParams.LinkSmoothingRadius;
    this.\u0007.Value = (Decimal) this.Par.LinkParams.ToolInitialOrientationDistance;
    this.\u0001.Checked = this.Par.LinkParams.ArcFitFeedDistanceFlg;
    this.\u0002.Checked = this.Par.LinkParams.ArcFitRapidDistanceFlg;
    this.\u0003.Checked = this.Par.LinkParams.ChangeToolDir2ClearanceDirFlg;
    this.\u0005.Checked = this.Par.LinkParams.InterpolateLinkMovesFlg;
    this.\u0004.Checked = this.Par.LinkParams.ChangeToolDir2ClearanceDirFlg;
    this.\u0003.Checked = this.Par.LinkParams.LinkSmoothingFlg;
    this.\u0006.Value = (Decimal) this.Par.LinkParams.AngleStepForRapidMoves;
    this.\u0008.Value = (Decimal) this.Par.LinkParams.AirMoveSafetyDistance;
    this.\u0010.Value = (Decimal) this.Par.LinkParams.RetractPlaneIncremental;
    this.\u000E.Value = (Decimal) this.Par.LinkParams.RetractFeedPlaneIncremental;
    this.\u000F.Value = (Decimal) this.Par.LinkParams.ApproachFeedPlaneIncremental;
    ((F_MwTriMRotate) this).\u0011.Value = (Decimal) this.Par.LinkParams.ClearancePlaneHeight;
    if (this.Par.LinkParams.ClearanceAxis == LinkParamsClearanceAxis.AxisX)
      this.combo_dir.SelectedIndex = 0;
    else if (this.Par.LinkParams.ClearanceAxis == LinkParamsClearanceAxis.AxisY)
      this.combo_dir.SelectedIndex = 1;
    else if (this.Par.LinkParams.ClearanceAxis == LinkParamsClearanceAxis.AxisZ)
      this.combo_dir.SelectedIndex = 2;
    else if (this.Par.LinkParams.ClearanceAxis == LinkParamsClearanceAxis.AxisCustom)
      this.combo_dir.SelectedIndex = 3;
    else if (this.Par.LinkParams.ClearanceAxis == LinkParamsClearanceAxis.MachiningDirection)
      this.combo_dir.SelectedIndex = 4;
    if (this.Par.LinkParams.FeedDistanceMode == LinkParamsFeedDistanceMode.FdmPreviousZHeight)
      this.combo_distances.SelectedIndex = 0;
    else if (this.Par.LinkParams.FeedDistanceMode == LinkParamsFeedDistanceMode.FdmCurrentZHeight)
      this.combo_distances.SelectedIndex = 1;
    if (this.Par.LinkParams.ClearancePlaneHeightDefinition == LinkParamsClearancePlaneHeightDefinition.CphdAutomatic)
      this.combo_heights.SelectedIndex = 0;
    else
      this.combo_heights.SelectedIndex = 1;
    this.combo_type.SelectedIndex = 0;
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
    this.\u0007.Enabled = this.\u0004.Checked;
    this.\u0001.Enabled = this.\u0003.Checked | this.\u0002.Checked | this.\u0001.Checked;
    if (this.combo_heights.SelectedIndex == 0)
      ((F_MwTriMRotate) this).\u0011.Enabled = false;
    else
      ((F_MwTriMRotate) this).\u0011.Enabled = true;
  }

  public void Apply()
  {
    this.Par.LinkParams.AngleStepForFeedMoves = (double) this.\u0005.Value;
    this.Par.LinkParams.LinkSmoothingRadius = (double) this.\u0001.Value;
    this.Par.LinkParams.ToolInitialOrientationDistance = (double) this.\u0007.Value;
    this.Par.LinkParams.ArcFitFeedDistanceFlg = this.\u0001.Checked;
    this.Par.LinkParams.ArcFitRapidDistanceFlg = this.\u0002.Checked;
    this.Par.LinkParams.ChangeToolDir2ClearanceDirFlg = this.\u0003.Checked;
    this.Par.LinkParams.InterpolateLinkMovesFlg = this.\u0005.Checked;
    this.Par.LinkParams.ChangeToolDir2ClearanceDirFlg = this.\u0004.Checked;
    this.Par.LinkParams.LinkSmoothingFlg = this.\u0003.Checked;
    this.Par.LinkParams.AngleStepForRapidMoves = (double) this.\u0006.Value;
    this.Par.LinkParams.AirMoveSafetyDistance = (double) this.\u0008.Value;
    this.Par.LinkParams.RetractPlaneIncremental = (double) this.\u0010.Value;
    this.Par.LinkParams.RetractFeedPlaneIncremental = (double) this.\u000E.Value;
    this.Par.LinkParams.ApproachFeedPlaneIncremental = (double) this.\u000F.Value;
    this.Par.LinkParams.FeedPlaneIncremental = this.Par.LinkParams.ApproachFeedPlaneIncremental;
    this.Par.LinkParams.ClearancePlaneHeight = (double) ((F_MwTriMRotate) this).\u0011.Value;
    if (this.combo_dir.SelectedIndex == 0)
      this.Par.LinkParams.ClearanceAxis = LinkParamsClearanceAxis.AxisX;
    else if (this.combo_dir.SelectedIndex == 1)
      this.Par.LinkParams.ClearanceAxis = LinkParamsClearanceAxis.AxisY;
    else if (this.combo_dir.SelectedIndex == 2)
      this.Par.LinkParams.ClearanceAxis = LinkParamsClearanceAxis.AxisZ;
    else if (this.combo_dir.SelectedIndex == 3)
      this.Par.LinkParams.ClearanceAxis = LinkParamsClearanceAxis.AxisCustom;
    else if (this.combo_dir.SelectedIndex == 4)
      this.Par.LinkParams.ClearanceAxis = LinkParamsClearanceAxis.MachiningDirection;
    this.Par.LinkParams.FeedDistanceMode = this.combo_distances.SelectedIndex != 0 ? LinkParamsFeedDistanceMode.FdmCurrentZHeight : LinkParamsFeedDistanceMode.FdmPreviousZHeight;
    if (this.combo_heights.SelectedIndex == 0)
      this.Par.LinkParams.ClearancePlaneHeightDefinition = LinkParamsClearancePlaneHeightDefinition.CphdAutomatic;
    else
      this.Par.LinkParams.ClearancePlaneHeightDefinition = LinkParamsClearancePlaneHeightDefinition.CphdUserDefined;
  }
}
