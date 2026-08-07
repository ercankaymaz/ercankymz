// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwTriMRoughLink
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

public class F_MwTriMRoughLink : Form
{
  internal System.Windows.Forms.Label \u0014;
  public ComboBox combo_applylink;
  internal System.Windows.Forms.Label \u0015;
  internal System.Windows.Forms.Label \u0016;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  internal IContainer \u0001 = (IContainer) null;
  internal Panel \u0001;
  internal System.Windows.Forms.Label \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal System.Windows.Forms.Label \u0003;
  internal CheckBox \u0001;
  internal CheckBox \u0002;
  internal CheckBox \u0003;
  internal CheckBox \u0004;
  internal Panel \u0002;
  internal System.Windows.Forms.Label \u0004;
  internal System.Windows.Forms.Label \u0005;
  internal System.Windows.Forms.Label \u0006;
  public ComboBox combo_firstentry;
  public ComboBox combo_lastexitramp;
  public ComboBox combo_firstentryramp;
  public ComboBox combo_lastexit;
  public ComboBox combo_arealinkbetweengroupramp;
  public ComboBox combo_arealinkbetweengroup;
  public ComboBox combo_arealinkwithingroupramp;
  public ComboBox combo_arealinkswithingroup;
  internal Panel \u0003;
  public ComboBox combo_linkbetweenslicesramp;
  public ComboBox combo_linkbetweenslices;
  internal System.Windows.Forms.Label \u0007;
  internal System.Windows.Forms.Label \u0008;
  internal Panel \u0004;
  public ComboBox combo_linkbetweenregionrapm;
  public ComboBox combo_linkbetweenregion;
  internal System.Windows.Forms.Label \u000E;
  internal System.Windows.Forms.Label \u000F;
  internal Button \u0001;
  internal System.Windows.Forms.Label \u0010;

  public void Apply()
  {
    ((F_MwTriMRotate) this).Par.RoughingParams.TPRotationRoughParams.StepoverShiftDistance = (double) ((F_MwTriMRotate) this).\u0007.Value;
    ((F_MwTriMRotate) this).Par.RoughingParams.TPRotationRoughParams.StartShiftDistance = (double) ((F_MwTriMRotate) this).\u0008.Value;
    ((F_MwTriMRotate) this).Par.RoughingParams.TPRotationRoughParams.RotationAngle = (double) ((F_MwTriMRotate) this).\u0005.Value;
    ((F_MwTriMRotate) this).Par.RoughingParams.TPRotationRoughParams.StartAngle = (double) ((F_MwTriMRotate) this).\u0006.Value;
    ((F_MwTriMRotate) this).Par.RoughingParams.TPRotationRoughParams.NumberOfSteps = (uint) ((F_MwTriMRotate) this).\u0004.Value;
    ((F_MwTriMRotate) this).Par.RoughingParams.TPRotationRoughParams.RotaryAxisBasePoint = new Point3d<double>((double) ((F_MwTriMRotate) this).\u0001.Value, (double) ((F_MwTriMRotate) this).\u0002.Value, (double) ((F_MwTriMRotate) this).\u0003.Value);
    if (((F_MwTriMRotate) this).combo_direction.SelectedIndex == 0)
      ((F_MwTriMRotate) this).Par.RoughingParams.TPRotationRoughParams.RotaryAxisDirection = new Vectord(1.0, 0.0, 0.0);
    if (((F_MwTriMRotate) this).combo_direction.SelectedIndex == 1)
      ((F_MwTriMRotate) this).Par.RoughingParams.TPRotationRoughParams.RotaryAxisDirection = new Vectord(0.0, 1.0, 0.0);
    if (((F_MwTriMRotate) this).combo_direction.SelectedIndex == 2)
      ((F_MwTriMRotate) this).Par.RoughingParams.TPRotationRoughParams.RotaryAxisDirection = new Vectord(0.0, 0.0, 1.0);
    if (this.combo_applylink.SelectedIndex == 0)
      ((F_MwTriMRotate) this).Par.RoughingParams.TPRotationRoughParams.LinkingApplicationStage = TPRotationRoughParamsLinkingApplicationStage.TprLinkBeforeRotate;
    else if (this.combo_applylink.SelectedIndex == 1)
      ((F_MwTriMRotate) this).Par.RoughingParams.TPRotationRoughParams.LinkingApplicationStage = TPRotationRoughParamsLinkingApplicationStage.TprLinkAfterRotate;
    if (((F_MwTriMRotate) this).combo_applystock.SelectedIndex == 0)
    {
      ((F_MwTriMRotate) this).Par.RoughingParams.TPRotationRoughParams.StockApplicationStage = TPRotationRoughParamsStockApplicationStage.TprApplyStockBeforeRotation;
    }
    else
    {
      if (((F_MwTriMRotate) this).combo_applystock.SelectedIndex != 1)
        return;
      ((F_MwTriMRotate) this).Par.RoughingParams.TPRotationRoughParams.StockApplicationStage = TPRotationRoughParamsStockApplicationStage.TprApplyStockAfterRotation;
    }
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_MwTriMRotate) this).Properties.Inited)
      return;
    ((F_MwTriMRotate) this).Properties.Inited = false;
    this.Apply();
    ((F_MwTriMRotate) this).UpdateControlFromType();
    ((F_MwTriMRotate) this).Properties.Inited = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MwTriMRotate) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MwTriMRotate) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MwTriMRoughLink() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    if (this.Par.LinkParams.FirstEntry.Type == FirstEntryType.FromRapidPlane)
      this.combo_firstentry.SelectedIndex = 0;
    else if (this.Par.LinkParams.FirstEntry.Type == FirstEntryType.UseRapidDistance)
      this.combo_firstentry.SelectedIndex = 1;
    else if (this.Par.LinkParams.FirstEntry.Type == FirstEntryType.UseFeedDistance)
      this.combo_firstentry.SelectedIndex = 2;
    else
      this.combo_firstentry.SelectedIndex = 0;
    if (this.Par.LinkParams.LastExit.Type == LastExitType.BackToRapidPlane)
      this.combo_lastexit.SelectedIndex = 0;
    else if (this.Par.LinkParams.LastExit.Type == LastExitType.UseRapidDistance)
      this.combo_lastexit.SelectedIndex = 1;
    else if (this.Par.LinkParams.LastExit.Type == LastExitType.UseFeedDistance)
      this.combo_lastexit.SelectedIndex = 2;
    else
      this.combo_lastexit.SelectedIndex = 0;
    if (this.Par.LinkParams.FirstEntry.LeadController.IsUsed)
      this.combo_firstentryramp.SelectedIndex = 0;
    else
      this.combo_firstentryramp.SelectedIndex = 1;
    if (this.Par.LinkParams.GapsAlongCut.SmallMoveHandling.Action == MoveHandlingAction.ActionGapDirect)
      this.combo_arealinkswithingroup.SelectedIndex = 0;
    else if (this.Par.LinkParams.GapsAlongCut.SmallMoveHandling.Action == MoveHandlingAction.ActionGapBlendSpline)
      this.combo_arealinkswithingroup.SelectedIndex = 1;
    else if (this.Par.LinkParams.GapsAlongCut.SmallMoveHandling.Action == MoveHandlingAction.ActionGapBrokenFeed)
      this.combo_arealinkswithingroup.SelectedIndex = 2;
    else if (this.Par.LinkParams.GapsAlongCut.SmallMoveHandling.Action == MoveHandlingAction.ActionGapBrokenFeedRap)
      this.combo_arealinkswithingroup.SelectedIndex = 3;
    else if (this.Par.LinkParams.GapsAlongCut.SmallMoveHandling.Action == MoveHandlingAction.ActionGapRapidPlane)
      this.combo_arealinkswithingroup.SelectedIndex = 4;
    else
      this.combo_arealinkswithingroup.SelectedIndex = 3;
    if (this.Par.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed)
      this.combo_arealinkwithingroupramp.SelectedIndex = 0;
    else
      this.combo_arealinkwithingroupramp.SelectedIndex = 1;
    if (this.Par.LinkParams.GapsAlongCut.LargeMoveHandling.Action == MoveHandlingAction.ActionGapDirect)
      this.combo_arealinkbetweengroup.SelectedIndex = 0;
    else if (this.Par.LinkParams.GapsAlongCut.LargeMoveHandling.Action == MoveHandlingAction.ActionGapBlendSpline)
      this.combo_arealinkbetweengroup.SelectedIndex = 1;
    else if (this.Par.LinkParams.GapsAlongCut.LargeMoveHandling.Action == MoveHandlingAction.ActionGapBrokenFeed)
      this.combo_arealinkbetweengroup.SelectedIndex = 2;
    else if (this.Par.LinkParams.GapsAlongCut.LargeMoveHandling.Action == MoveHandlingAction.ActionGapBrokenFeedRap)
      this.combo_arealinkbetweengroup.SelectedIndex = 3;
    else if (this.Par.LinkParams.GapsAlongCut.LargeMoveHandling.Action == MoveHandlingAction.ActionGapRapidPlane)
      this.combo_arealinkbetweengroup.SelectedIndex = 4;
    else
      this.combo_arealinkbetweengroup.SelectedIndex = 3;
    if (this.Par.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed)
      this.combo_arealinkbetweengroupramp.SelectedIndex = 0;
    else
      this.combo_arealinkbetweengroupramp.SelectedIndex = 1;
    if (this.Par.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action == MoveHandlingAction.ActionGapDirect)
      this.combo_linkbetweenslices.SelectedIndex = 0;
    else if (this.Par.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action == MoveHandlingAction.ActionGapBlendSpline)
      this.combo_linkbetweenslices.SelectedIndex = 1;
    else if (this.Par.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action == MoveHandlingAction.ActionGapStep)
      this.combo_linkbetweenslices.SelectedIndex = 2;
    else if (this.Par.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action == MoveHandlingAction.ActionGapBrokenFeed)
      this.combo_linkbetweenslices.SelectedIndex = 3;
    else if (this.Par.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action == MoveHandlingAction.ActionGapBrokenFeedRap)
      this.combo_linkbetweenslices.SelectedIndex = 4;
    else if (this.Par.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action == MoveHandlingAction.ActionGapRapidPlane)
      this.combo_linkbetweenslices.SelectedIndex = 5;
    else
      this.combo_linkbetweenslices.SelectedIndex = 3;
    if (this.Par.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed)
      this.combo_linkbetweenslicesramp.SelectedIndex = 0;
    else
      this.combo_linkbetweenslicesramp.SelectedIndex = 1;
    if (this.Par.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action == MoveHandlingAction.ActionGapDirect)
      this.combo_linkbetweenregion.SelectedIndex = 0;
    else if (this.Par.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action == MoveHandlingAction.ActionGapBlendSpline)
      this.combo_linkbetweenregion.SelectedIndex = 1;
    else if (this.Par.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action == MoveHandlingAction.ActionGapBrokenFeed)
      this.combo_linkbetweenregion.SelectedIndex = 2;
    else if (this.Par.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action == MoveHandlingAction.ActionGapBrokenFeedRap)
      this.combo_linkbetweenregion.SelectedIndex = 3;
    else if (this.Par.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action == MoveHandlingAction.ActionGapRapidPlane)
      this.combo_linkbetweenregion.SelectedIndex = 4;
    else
      this.combo_linkbetweenregion.SelectedIndex = 3;
    if (this.Par.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed)
      this.combo_linkbetweenregionrapm.SelectedIndex = 0;
    else
      this.combo_linkbetweenregionrapm.SelectedIndex = 1;
    this.\u0003.Checked = this.Par.LinkParams.LastExit.UseHomePositionFlg;
    this.\u0001.Checked = this.Par.LinkParams.LastExit.ReturnToMaximumZFlg;
    this.\u0004.Checked = this.Par.LinkParams.FirstEntry.UseHomePositionFlg;
    this.\u0002.Checked = this.Par.LinkParams.FirstEntry.StartFromMaximumZFlg;
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
  }

  public void Apply()
  {
    this.Par.LinkParams.LastExit.UseHomePositionFlg = this.\u0003.Checked;
    this.Par.LinkParams.LastExit.ReturnToMaximumZFlg = this.\u0001.Checked;
    this.Par.LinkParams.FirstEntry.UseHomePositionFlg = this.\u0004.Checked;
    this.Par.LinkParams.FirstEntry.StartFromMaximumZFlg = this.\u0002.Checked;
    if (this.combo_firstentry.SelectedIndex == 0)
      this.Par.LinkParams.FirstEntry.Type = FirstEntryType.FromRapidPlane;
    else if (this.combo_firstentry.SelectedIndex == 1)
      this.Par.LinkParams.FirstEntry.Type = FirstEntryType.UseRapidDistance;
    else if (this.combo_firstentry.SelectedIndex == 2)
      this.Par.LinkParams.FirstEntry.Type = FirstEntryType.UseFeedDistance;
    this.Par.LinkParams.FirstEntry.LeadController.IsUsed = this.combo_firstentryramp.SelectedIndex == 0;
    if (this.combo_lastexit.SelectedIndex == 0)
      this.Par.LinkParams.LastExit.Type = LastExitType.BackToRapidPlane;
    else if (this.combo_lastexit.SelectedIndex == 1)
      this.Par.LinkParams.LastExit.Type = LastExitType.UseRapidDistance;
    else if (this.combo_lastexit.SelectedIndex == 2)
      this.Par.LinkParams.LastExit.Type = LastExitType.UseFeedDistance;
    this.Par.LinkParams.LastExit.LeadController.IsUsed = false;
    if (this.combo_arealinkswithingroup.SelectedIndex == 0)
      this.Par.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
    else if (this.combo_arealinkswithingroup.SelectedIndex == 1)
      this.Par.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
    else if (this.combo_arealinkswithingroup.SelectedIndex == 2)
      this.Par.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeed;
    else if (this.combo_arealinkswithingroup.SelectedIndex == 3)
      this.Par.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeedRap;
    else if (this.combo_arealinkswithingroup.SelectedIndex == 4)
      this.Par.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
    if (this.combo_arealinkwithingroupramp.SelectedIndex == 0)
      this.Par.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed = true;
    else
      this.Par.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed = false;
    if (this.combo_arealinkbetweengroup.SelectedIndex == 0)
      this.Par.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
    else if (this.combo_arealinkbetweengroup.SelectedIndex == 1)
      this.Par.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
    else if (this.combo_arealinkbetweengroup.SelectedIndex == 2)
      this.Par.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeed;
    else if (this.combo_arealinkbetweengroup.SelectedIndex == 3)
      this.Par.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeedRap;
    else if (this.combo_arealinkbetweengroup.SelectedIndex == 4)
      this.Par.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
    if (this.combo_arealinkbetweengroupramp.SelectedIndex == 0)
      this.Par.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed = true;
    else
      this.Par.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed = false;
    if (this.combo_linkbetweenslices.SelectedIndex == 0)
      this.Par.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
    else if (this.combo_linkbetweenslices.SelectedIndex == 1)
      this.Par.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
    else if (this.combo_linkbetweenslices.SelectedIndex == 2)
      this.Par.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action = MoveHandlingAction.ActionGapStep;
    else if (this.combo_linkbetweenslices.SelectedIndex == 3)
      this.Par.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeed;
    else if (this.combo_linkbetweenslices.SelectedIndex == 4)
      this.Par.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeedRap;
    else if (this.combo_linkbetweenslices.SelectedIndex == 5)
      this.Par.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
    if (this.combo_linkbetweenslicesramp.SelectedIndex == 0)
      this.Par.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed = true;
    else
      this.Par.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed = false;
    if (this.combo_linkbetweenregion.SelectedIndex == 0)
      this.Par.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
    else if (this.combo_linkbetweenregion.SelectedIndex == 1)
      this.Par.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
    else if (this.combo_linkbetweenregion.SelectedIndex == 2)
      this.Par.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeed;
    else if (this.combo_linkbetweenregion.SelectedIndex == 3)
      this.Par.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeedRap;
    else if (this.combo_linkbetweenregion.SelectedIndex == 4)
      this.Par.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
    if (this.combo_linkbetweenregionrapm.SelectedIndex == 0)
      this.Par.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed = true;
    else
      this.Par.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed = false;
  }
}
