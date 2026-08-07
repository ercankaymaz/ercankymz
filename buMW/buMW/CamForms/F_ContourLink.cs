// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_ContourLink
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

public class F_ContourLink : Form
{
  public Button btn_ok;
  internal ImageList \u0002;
  internal Panel \u0002;
  internal Panel \u0003;
  internal RadioButton \u0003;
  internal RadioButton \u0004;
  internal RadioButton \u0005;
  internal CheckBox \u0001;
  public FormProperties Properties = new FormProperties();
  public GeoLib mwCamParameter = (GeoLib) null;
  public camParameters5 buCamParameter = (camParameters5) null;
  public ToolBase5 Tool = (ToolBase5) null;
  public MWCalculationOptions Configration = new MWCalculationOptions();
  public static List<string> Captions;
  internal IContainer \u0001 = (IContainer) null;
  internal Panel \u0001;
  internal System.Windows.Forms.Label \u0001;
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal System.Windows.Forms.Label \u0003;
  internal Button \u0001;
  internal CheckBox \u0001;
  internal CheckBox \u0002;
  internal Panel \u0002;
  internal RadioButton \u0001;
  internal System.Windows.Forms.Label \u0004;
  internal System.Windows.Forms.Label \u0005;
  internal System.Windows.Forms.Label \u0006;
  internal RadioButton \u0002;
  public ComboBox cmb_firstEntry;
  internal Button \u0002;
  public ComboBox cmb_lastexitleadout;
  public ComboBox cmb_firstleadin;
  public ComboBox cmb_lastexit;
  internal System.Windows.Forms.Label \u0007;
  internal NumericUpDown \u0002;
  public ComboBox cmb_gapsalong_largeleadinout;
  public ComboBox cmb_gapsalong_langegap;
  internal Button \u0003;
  public ComboBox cmb_gapsalong_smallleadinout;
  public ComboBox cmb_gapsalong_smallgap;
  internal Button \u0004;
  internal Panel \u0003;
  internal System.Windows.Forms.Label \u0008;
  internal NumericUpDown \u0003;
  public ComboBox cmb_slices_largeleadinout;
  internal RadioButton \u0003;
  public ComboBox cmb_slices_largemoves;
  internal RadioButton \u0004;
  internal Button \u0005;
  internal NumericUpDown \u0004;
  public ComboBox cmb_slices_smallleadinout;
  public ComboBox cmb_slices_smallmoves;
  internal Button \u0006;
  internal System.Windows.Forms.Label \u000E;
  internal System.Windows.Forms.Label \u000F;
  internal System.Windows.Forms.Label \u0010;
  internal Panel \u0004;
  internal System.Windows.Forms.Label \u0011;
  public ComboBox cmb_pass_largeleadinout;
  public ComboBox cmb_pass_largemoves;
  internal Button \u0007;
  internal NumericUpDown \u0005;
  public ComboBox cmb_pass_smallleadinout;
  public ComboBox cmb_pass_smallmoves;
  internal Button \u0008;
  internal System.Windows.Forms.Label \u0012;
  internal System.Windows.Forms.Label \u0013;
  internal System.Windows.Forms.Label \u0014;
  internal System.Windows.Forms.Label \u0015;
  internal PictureBox \u0001;
  public Button btn_cancel;
  internal ImageList \u0001;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!((F_Height) this).PropertiesForm.Inited)
      return;
    ((F_Height) this).PropertiesForm.Inited = false;
    ((F_Height) this).Apply();
    ((F_Height) this).ControlUpdate();
    ((F_Height) this).PropertiesForm.Inited = true;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_Height) this).\u0002.Name)
      ((F_Height) this).\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == this.\u0005.Name)
    {
      ((F_Height) this).\u0001.Image = (Image) ResourceImage.MinMaxMachiningSurfaces;
      if (this.\u0001.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == this.\u0004.Name)
    {
      ((F_Height) this).\u0001.Image = (Image) ResourceImage.NoImage;
      if (this.\u0001.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == this.\u0003.Name)
    {
      ((F_Height) this).\u0001.Image = (Image) ResourceImage.NoImage;
      if (this.\u0001.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_Height) this).\u0002.Name)
      ((F_Height) this).\u0001.Image = (Image) ResourceImage.StartHeightRough;
    else if (control2.Name == ((F_Height) this).\u0001.Name)
      ((F_Height) this).\u0001.Image = (Image) ResourceImage.EndHeightRough;
    this.\u0001.Checked = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_Height) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_Height) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ContourLink() => F_Height.Captions = new List<string>();

  public F_ContourLink() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    this.\u0002.Checked = this.mwCamParameter.MachParam.LinkParams.FirstEntry.UseHomePositionFlg;
    this.\u0001.Checked = this.mwCamParameter.MachParam.LinkParams.LastExit.UseHomePositionFlg;
    this.cmb_firstEntry.Items.Clear();
    this.cmb_firstEntry.Items.Add((object) buMWCaptions.FirstEntryType[0]);
    this.cmb_firstEntry.Items.Add((object) buMWCaptions.FirstEntryType[1]);
    this.cmb_firstEntry.Items.Add((object) buMWCaptions.FirstEntryType[2]);
    this.cmb_firstEntry.Items.Add((object) buMWCaptions.FirstEntryType[3]);
    if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.Type == FirstEntryType.FromRapidPlane)
      this.cmb_firstEntry.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.Type == FirstEntryType.UseRapidDistance)
      this.cmb_firstEntry.SelectedIndex = 1;
    else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.Type == FirstEntryType.UseFeedDistance)
      this.cmb_firstEntry.SelectedIndex = 2;
    else if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.Type == FirstEntryType.Direct)
      this.cmb_firstEntry.SelectedIndex = 3;
    this.cmb_firstleadin.Items.Clear();
    this.cmb_firstleadin.Items.Add((object) buMWCaptions.LeadInUsage[0]);
    this.cmb_firstleadin.Items.Add((object) buMWCaptions.LeadInUsage[1]);
    if (this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.IsUsed)
      this.cmb_firstleadin.SelectedIndex = 0;
    else
      this.cmb_firstleadin.SelectedIndex = 1;
    this.cmb_lastexit.Items.Clear();
    this.cmb_lastexit.Items.Add((object) buMWCaptions.LastExitType[0]);
    this.cmb_lastexit.Items.Add((object) buMWCaptions.LastExitType[1]);
    this.cmb_lastexit.Items.Add((object) buMWCaptions.LastExitType[2]);
    this.cmb_lastexit.Items.Add((object) buMWCaptions.LastExitType[4]);
    if (this.mwCamParameter.MachParam.LinkParams.LastExit.Type == LastExitType.BackToRapidPlane)
      this.cmb_lastexit.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.LinkParams.LastExit.Type == LastExitType.UseRapidDistance)
      this.cmb_lastexit.SelectedIndex = 1;
    else if (this.mwCamParameter.MachParam.LinkParams.LastExit.Type == LastExitType.UseFeedDistance)
      this.cmb_lastexit.SelectedIndex = 2;
    else if (this.mwCamParameter.MachParam.LinkParams.LastExit.Type == LastExitType.Direct)
      this.cmb_lastexit.SelectedIndex = 3;
    this.cmb_lastexitleadout.Items.Clear();
    this.cmb_lastexitleadout.Items.Add((object) buMWCaptions.LeadOutUsage[0]);
    this.cmb_lastexitleadout.Items.Add((object) buMWCaptions.LeadOutUsage[1]);
    if (this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.IsUsed)
      this.cmb_lastexitleadout.SelectedIndex = 0;
    else
      this.cmb_lastexitleadout.SelectedIndex = 1;
    if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.GetGapSize().IsPercent)
    {
      this.\u0001.Checked = true;
      this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.GetGapSize().Percent;
    }
    else
    {
      this.\u0002.Checked = false;
      this.\u0002.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.GetGapSize().Value;
    }
    this.cmb_gapsalong_langegap.Items.Clear();
    this.cmb_gapsalong_langegap.Items.Add((object) buMWCaptions.MoveHandlingAction[0]);
    this.cmb_gapsalong_langegap.Items.Add((object) buMWCaptions.MoveHandlingAction[3]);
    this.cmb_gapsalong_langegap.Items.Add((object) buMWCaptions.MoveHandlingAction[4]);
    this.cmb_gapsalong_langegap.Items.Add((object) buMWCaptions.MoveHandlingAction[7]);
    this.cmb_gapsalong_langegap.Items.Add((object) buMWCaptions.MoveHandlingAction[2]);
    this.cmb_gapsalong_langegap.Items.Add((object) buMWCaptions.MoveHandlingAction[5]);
    this.cmb_gapsalong_langegap.Items.Add((object) buMWCaptions.MoveHandlingAction[1]);
    if (this.Configration.Mode == CamMode.TriangularMesh)
      this.cmb_gapsalong_langegap.Items.Add((object) buMWCaptions.MoveHandlingAction[9]);
    if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action == MoveHandlingAction.ActionGapDirect)
      this.cmb_gapsalong_langegap.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action == MoveHandlingAction.ActionGapFollowSurfs)
      this.cmb_gapsalong_langegap.SelectedIndex = 1;
    else if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action == MoveHandlingAction.ActionGapBlendSpline)
      this.cmb_gapsalong_langegap.SelectedIndex = 2;
    else if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action == MoveHandlingAction.ActionGapStep)
      this.cmb_gapsalong_langegap.SelectedIndex = 3;
    else if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action == MoveHandlingAction.ActionGapRapidPlane)
      this.cmb_gapsalong_langegap.SelectedIndex = 4;
    else if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action == MoveHandlingAction.ActionGapBrokenFeedRap)
      this.cmb_gapsalong_langegap.SelectedIndex = 5;
    else if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action == MoveHandlingAction.ActionGapBrokenFeed)
      this.cmb_gapsalong_langegap.SelectedIndex = 6;
    else if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action == MoveHandlingAction.ActionGapShortestPath)
      this.cmb_gapsalong_langegap.SelectedIndex = 7;
    this.cmb_gapsalong_largeleadinout.Items.Clear();
    this.cmb_gapsalong_largeleadinout.Items.Add((object) buMWCaptions.LeadInOutUsage[0]);
    this.cmb_gapsalong_largeleadinout.Items.Add((object) buMWCaptions.LeadInOutUsage[1]);
    this.cmb_gapsalong_largeleadinout.Items.Add((object) buMWCaptions.LeadInOutUsage[2]);
    this.cmb_gapsalong_largeleadinout.Items.Add((object) buMWCaptions.LeadInOutUsage[3]);
    if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed & !this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadOutController.IsUsed)
      this.cmb_gapsalong_largeleadinout.SelectedIndex = 0;
    else if (!this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed & this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadOutController.IsUsed)
      this.cmb_gapsalong_largeleadinout.SelectedIndex = 1;
    else if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed & this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadOutController.IsUsed)
      this.cmb_gapsalong_largeleadinout.SelectedIndex = 2;
    else
      this.cmb_gapsalong_largeleadinout.SelectedIndex = 3;
    this.cmb_gapsalong_smallgap.Items.Clear();
    this.cmb_gapsalong_smallgap.Items.Add((object) buMWCaptions.MoveHandlingAction[0]);
    this.cmb_gapsalong_smallgap.Items.Add((object) buMWCaptions.MoveHandlingAction[3]);
    this.cmb_gapsalong_smallgap.Items.Add((object) buMWCaptions.MoveHandlingAction[4]);
    this.cmb_gapsalong_smallgap.Items.Add((object) buMWCaptions.MoveHandlingAction[7]);
    this.cmb_gapsalong_smallgap.Items.Add((object) buMWCaptions.MoveHandlingAction[2]);
    this.cmb_gapsalong_smallgap.Items.Add((object) buMWCaptions.MoveHandlingAction[5]);
    this.cmb_gapsalong_smallgap.Items.Add((object) buMWCaptions.MoveHandlingAction[1]);
    if (this.Configration.Mode == CamMode.TriangularMesh)
      this.cmb_gapsalong_smallgap.Items.Add((object) buMWCaptions.MoveHandlingAction[9]);
    if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action == MoveHandlingAction.ActionGapDirect)
      this.cmb_gapsalong_smallgap.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action == MoveHandlingAction.ActionGapFollowSurfs)
      this.cmb_gapsalong_smallgap.SelectedIndex = 1;
    else if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action == MoveHandlingAction.ActionGapBlendSpline)
      this.cmb_gapsalong_smallgap.SelectedIndex = 2;
    else if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action == MoveHandlingAction.ActionGapStep)
      this.cmb_gapsalong_smallgap.SelectedIndex = 3;
    else if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action == MoveHandlingAction.ActionGapRapidPlane)
      this.cmb_gapsalong_smallgap.SelectedIndex = 4;
    else if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action == MoveHandlingAction.ActionGapBrokenFeedRap)
      this.cmb_gapsalong_smallgap.SelectedIndex = 5;
    else if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action == MoveHandlingAction.ActionGapBrokenFeed)
      this.cmb_gapsalong_smallgap.SelectedIndex = 6;
    else if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action == MoveHandlingAction.ActionGapShortestPath)
      this.cmb_gapsalong_smallgap.SelectedIndex = 7;
    this.cmb_gapsalong_smallleadinout.Items.Clear();
    this.cmb_gapsalong_smallleadinout.Items.Add((object) buMWCaptions.LeadInOutUsage[0]);
    this.cmb_gapsalong_smallleadinout.Items.Add((object) buMWCaptions.LeadInOutUsage[1]);
    this.cmb_gapsalong_smallleadinout.Items.Add((object) buMWCaptions.LeadInOutUsage[2]);
    this.cmb_gapsalong_smallleadinout.Items.Add((object) buMWCaptions.LeadInOutUsage[3]);
    if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed & !this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadOutController.IsUsed)
      this.cmb_gapsalong_smallleadinout.SelectedIndex = 0;
    else if (!this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed & this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadOutController.IsUsed)
      this.cmb_gapsalong_smallleadinout.SelectedIndex = 1;
    else if (this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed & this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadOutController.IsUsed)
      this.cmb_gapsalong_smallleadinout.SelectedIndex = 2;
    else
      this.cmb_gapsalong_smallleadinout.SelectedIndex = 3;
    this.\u0005.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.GetGapSize().Value;
    this.cmb_pass_largemoves.Items.Clear();
    this.cmb_pass_largemoves.Items.Add((object) buMWCaptions.MoveHandlingAction[0]);
    this.cmb_pass_largemoves.Items.Add((object) buMWCaptions.MoveHandlingAction[3]);
    this.cmb_pass_largemoves.Items.Add((object) buMWCaptions.MoveHandlingAction[4]);
    this.cmb_pass_largemoves.Items.Add((object) buMWCaptions.MoveHandlingAction[7]);
    this.cmb_pass_largemoves.Items.Add((object) buMWCaptions.MoveHandlingAction[2]);
    this.cmb_pass_largemoves.Items.Add((object) buMWCaptions.MoveHandlingAction[5]);
    this.cmb_pass_largemoves.Items.Add((object) buMWCaptions.MoveHandlingAction[1]);
    if (this.Configration.Mode == CamMode.TriangularMesh)
      this.cmb_pass_largemoves.Items.Add((object) buMWCaptions.MoveHandlingAction[9]);
    if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action == MoveHandlingAction.ActionGapDirect)
      this.cmb_pass_largemoves.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action == MoveHandlingAction.ActionGapFollowSurfs)
      this.cmb_pass_largemoves.SelectedIndex = 1;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action == MoveHandlingAction.ActionGapBlendSpline)
      this.cmb_pass_largemoves.SelectedIndex = 2;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action == MoveHandlingAction.ActionGapStep)
      this.cmb_pass_largemoves.SelectedIndex = 3;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action == MoveHandlingAction.ActionGapRapidPlane)
      this.cmb_pass_largemoves.SelectedIndex = 4;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action == MoveHandlingAction.ActionGapBrokenFeedRap)
      this.cmb_pass_largemoves.SelectedIndex = 5;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action == MoveHandlingAction.ActionGapBrokenFeed)
      this.cmb_pass_largemoves.SelectedIndex = 6;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action == MoveHandlingAction.ActionGapShortestPath)
      this.cmb_pass_largemoves.SelectedIndex = 7;
    this.cmb_pass_largeleadinout.Items.Clear();
    this.cmb_pass_largeleadinout.Items.Add((object) buMWCaptions.LeadInOutUsage[0]);
    this.cmb_pass_largeleadinout.Items.Add((object) buMWCaptions.LeadInOutUsage[1]);
    this.cmb_pass_largeleadinout.Items.Add((object) buMWCaptions.LeadInOutUsage[2]);
    this.cmb_pass_largeleadinout.Items.Add((object) buMWCaptions.LeadInOutUsage[3]);
    if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed & !this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.MoveLeadController.LeadOutController.IsUsed)
      this.cmb_pass_largeleadinout.SelectedIndex = 0;
    else if (!this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed & this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.MoveLeadController.LeadOutController.IsUsed)
      this.cmb_pass_largeleadinout.SelectedIndex = 1;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed & this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.MoveLeadController.LeadOutController.IsUsed)
      this.cmb_pass_largeleadinout.SelectedIndex = 2;
    else
      this.cmb_pass_largeleadinout.SelectedIndex = 3;
    this.cmb_pass_smallmoves.Items.Clear();
    this.cmb_pass_smallmoves.Items.Add((object) buMWCaptions.MoveHandlingAction[0]);
    this.cmb_pass_smallmoves.Items.Add((object) buMWCaptions.MoveHandlingAction[3]);
    this.cmb_pass_smallmoves.Items.Add((object) buMWCaptions.MoveHandlingAction[4]);
    this.cmb_pass_smallmoves.Items.Add((object) buMWCaptions.MoveHandlingAction[7]);
    this.cmb_pass_smallmoves.Items.Add((object) buMWCaptions.MoveHandlingAction[2]);
    this.cmb_pass_smallmoves.Items.Add((object) buMWCaptions.MoveHandlingAction[5]);
    this.cmb_pass_smallmoves.Items.Add((object) buMWCaptions.MoveHandlingAction[1]);
    if (this.Configration.Mode == CamMode.TriangularMesh)
      this.cmb_pass_smallmoves.Items.Add((object) buMWCaptions.MoveHandlingAction[9]);
    if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action == MoveHandlingAction.ActionGapDirect)
      this.cmb_pass_smallmoves.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action == MoveHandlingAction.ActionGapFollowSurfs)
      this.cmb_pass_smallmoves.SelectedIndex = 1;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action == MoveHandlingAction.ActionGapBlendSpline)
      this.cmb_pass_smallmoves.SelectedIndex = 2;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action == MoveHandlingAction.ActionGapStep)
      this.cmb_pass_smallmoves.SelectedIndex = 3;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action == MoveHandlingAction.ActionGapRapidPlane)
      this.cmb_pass_smallmoves.SelectedIndex = 4;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action == MoveHandlingAction.ActionGapBrokenFeedRap)
      this.cmb_pass_smallmoves.SelectedIndex = 5;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action == MoveHandlingAction.ActionGapBrokenFeed)
      this.cmb_pass_smallmoves.SelectedIndex = 6;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action == MoveHandlingAction.ActionGapShortestPath)
      this.cmb_pass_smallmoves.SelectedIndex = 7;
    this.cmb_pass_smallleadinout.Items.Clear();
    this.cmb_pass_smallleadinout.Items.Add((object) buMWCaptions.LeadInOutUsage[0]);
    this.cmb_pass_smallleadinout.Items.Add((object) buMWCaptions.LeadInOutUsage[1]);
    this.cmb_pass_smallleadinout.Items.Add((object) buMWCaptions.LeadInOutUsage[2]);
    this.cmb_pass_smallleadinout.Items.Add((object) buMWCaptions.LeadInOutUsage[3]);
    if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed & !this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadOutController.IsUsed)
      this.cmb_pass_smallleadinout.SelectedIndex = 0;
    else if (!this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed & this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadOutController.IsUsed)
      this.cmb_pass_smallleadinout.SelectedIndex = 1;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed & this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadOutController.IsUsed)
      this.cmb_pass_smallleadinout.SelectedIndex = 2;
    else
      this.cmb_pass_smallleadinout.SelectedIndex = 3;
    if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.GetGapSize().IsPercent)
    {
      this.\u0004.Checked = true;
      this.\u0004.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.GetGapSize().Percent;
    }
    else
    {
      this.\u0003.Checked = false;
      this.\u0003.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.GetGapSize().Value;
    }
    this.cmb_slices_largemoves.Items.Clear();
    this.cmb_slices_largemoves.Items.Add((object) buMWCaptions.MoveHandlingAction[0]);
    this.cmb_slices_largemoves.Items.Add((object) buMWCaptions.MoveHandlingAction[3]);
    this.cmb_slices_largemoves.Items.Add((object) buMWCaptions.MoveHandlingAction[4]);
    this.cmb_slices_largemoves.Items.Add((object) buMWCaptions.MoveHandlingAction[7]);
    this.cmb_slices_largemoves.Items.Add((object) buMWCaptions.MoveHandlingAction[2]);
    this.cmb_slices_largemoves.Items.Add((object) buMWCaptions.MoveHandlingAction[5]);
    this.cmb_slices_largemoves.Items.Add((object) buMWCaptions.MoveHandlingAction[1]);
    if (this.Configration.Mode == CamMode.TriangularMesh)
      this.cmb_slices_largemoves.Items.Add((object) buMWCaptions.MoveHandlingAction[9]);
    if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action == MoveHandlingAction.ActionGapDirect)
      this.cmb_slices_largemoves.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action == MoveHandlingAction.ActionGapFollowSurfs)
      this.cmb_slices_largemoves.SelectedIndex = 1;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action == MoveHandlingAction.ActionGapBlendSpline)
      this.cmb_slices_largemoves.SelectedIndex = 2;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action == MoveHandlingAction.ActionGapStep)
      this.cmb_slices_largemoves.SelectedIndex = 3;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action == MoveHandlingAction.ActionGapRapidPlane)
      this.cmb_slices_largemoves.SelectedIndex = 4;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action == MoveHandlingAction.ActionGapBrokenFeedRap)
      this.cmb_slices_largemoves.SelectedIndex = 5;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action == MoveHandlingAction.ActionGapBrokenFeed)
      this.cmb_slices_largemoves.SelectedIndex = 6;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action == MoveHandlingAction.ActionGapShortestPath)
      this.cmb_slices_largemoves.SelectedIndex = 7;
    this.cmb_slices_largeleadinout.Items.Clear();
    this.cmb_slices_largeleadinout.Items.Add((object) buMWCaptions.LeadInOutUsage[0]);
    this.cmb_slices_largeleadinout.Items.Add((object) buMWCaptions.LeadInOutUsage[1]);
    this.cmb_slices_largeleadinout.Items.Add((object) buMWCaptions.LeadInOutUsage[2]);
    this.cmb_slices_largeleadinout.Items.Add((object) buMWCaptions.LeadInOutUsage[3]);
    if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed & !this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.MoveLeadController.LeadOutController.IsUsed)
      this.cmb_slices_largeleadinout.SelectedIndex = 0;
    else if (!this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed & this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.MoveLeadController.LeadOutController.IsUsed)
      this.cmb_slices_largeleadinout.SelectedIndex = 1;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed & this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.MoveLeadController.LeadOutController.IsUsed)
      this.cmb_slices_largeleadinout.SelectedIndex = 2;
    else
      this.cmb_slices_largeleadinout.SelectedIndex = 3;
    this.cmb_slices_smallmoves.Items.Clear();
    this.cmb_slices_smallmoves.Items.Add((object) buMWCaptions.MoveHandlingAction[0]);
    this.cmb_slices_smallmoves.Items.Add((object) buMWCaptions.MoveHandlingAction[3]);
    this.cmb_slices_smallmoves.Items.Add((object) buMWCaptions.MoveHandlingAction[4]);
    this.cmb_slices_smallmoves.Items.Add((object) buMWCaptions.MoveHandlingAction[7]);
    this.cmb_slices_smallmoves.Items.Add((object) buMWCaptions.MoveHandlingAction[2]);
    this.cmb_slices_smallmoves.Items.Add((object) buMWCaptions.MoveHandlingAction[5]);
    this.cmb_slices_smallmoves.Items.Add((object) buMWCaptions.MoveHandlingAction[1]);
    if (this.Configration.Mode == CamMode.TriangularMesh)
      this.cmb_slices_smallmoves.Items.Add((object) buMWCaptions.MoveHandlingAction[9]);
    if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action == MoveHandlingAction.ActionGapDirect)
      this.cmb_slices_smallmoves.SelectedIndex = 0;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action == MoveHandlingAction.ActionGapFollowSurfs)
      this.cmb_slices_smallmoves.SelectedIndex = 1;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action == MoveHandlingAction.ActionGapBlendSpline)
      this.cmb_slices_smallmoves.SelectedIndex = 2;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action == MoveHandlingAction.ActionGapStep)
      this.cmb_slices_smallmoves.SelectedIndex = 3;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action == MoveHandlingAction.ActionGapRapidPlane)
      this.cmb_slices_smallmoves.SelectedIndex = 4;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action == MoveHandlingAction.ActionGapBrokenFeedRap)
      this.cmb_slices_smallmoves.SelectedIndex = 5;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action == MoveHandlingAction.ActionGapBrokenFeed)
      this.cmb_slices_smallmoves.SelectedIndex = 6;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action == MoveHandlingAction.ActionGapShortestPath)
      this.cmb_slices_smallmoves.SelectedIndex = 7;
    this.cmb_slices_smallleadinout.Items.Clear();
    this.cmb_slices_smallleadinout.Items.Add((object) buMWCaptions.LeadInOutUsage[0]);
    this.cmb_slices_smallleadinout.Items.Add((object) buMWCaptions.LeadInOutUsage[1]);
    this.cmb_slices_smallleadinout.Items.Add((object) buMWCaptions.LeadInOutUsage[2]);
    this.cmb_slices_smallleadinout.Items.Add((object) buMWCaptions.LeadInOutUsage[3]);
    if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed & !this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadOutController.IsUsed)
      this.cmb_slices_smallleadinout.SelectedIndex = 0;
    else if (!this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed & this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadOutController.IsUsed)
      this.cmb_slices_smallleadinout.SelectedIndex = 1;
    else if (this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed & this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadOutController.IsUsed)
      this.cmb_slices_smallleadinout.SelectedIndex = 2;
    else
      this.cmb_slices_smallleadinout.SelectedIndex = 3;
    this.ControlUpdate();
    \u0005.\u0002.\u0001(this);
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
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_RoughingAdvanced) this).btn_ok.Name)
    {
      this.Apply();
      this.Properties.Result = DialogResult.OK;
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.btn_cancel.Name)
    {
      this.Properties.Result = DialogResult.Cancel;
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.\u0001.Name)
    {
      F_LeadControl fLeadControl = new F_LeadControl();
      fLeadControl.mwCamLeadController = this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController;
      fLeadControl.buCamParameter = new camParameters5(this.buCamParameter);
      fLeadControl.Init();
      int num = (int) fLeadControl.ShowDialog();
      if (fLeadControl.Properties.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController = fLeadControl.mwCamLeadController;
        this.buCamParameter = new camParameters5(fLeadControl.buCamParameter);
      }
    }
    if (control2.Name == this.\u0002.Name)
    {
      F_LeadControl fLeadControl = new F_LeadControl();
      fLeadControl.mwCamLeadController = this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController;
      fLeadControl.buCamParameter = new camParameters5(this.buCamParameter);
      fLeadControl.Init();
      int num = (int) fLeadControl.ShowDialog();
      if (fLeadControl.Properties.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController = fLeadControl.mwCamLeadController;
        this.buCamParameter = new camParameters5(fLeadControl.buCamParameter);
      }
    }
    if (control2.Name == this.\u0004.Name)
    {
      F_LeadControl fLeadControl = new F_LeadControl();
      fLeadControl.mwCamLeadController = this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadInController;
      fLeadControl.buCamParameter = new camParameters5(this.buCamParameter);
      fLeadControl.Init();
      int num = (int) fLeadControl.ShowDialog();
      if (fLeadControl.Properties.Result == DialogResult.OK)
      {
        this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadInController = fLeadControl.mwCamLeadController;
        this.buCamParameter = new camParameters5(fLeadControl.buCamParameter);
      }
    }
    if (!(control2.Name == ((F_RoughingAdvanced) this).\u000F.Name))
      return;
    F_LeadControl fLeadControl1 = new F_LeadControl();
    fLeadControl1.mwCamLeadController = this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadOutController;
    fLeadControl1.buCamParameter = new camParameters5(this.buCamParameter);
    fLeadControl1.Init();
    int num1 = (int) fLeadControl1.ShowDialog();
    if (fLeadControl1.Properties.Result != DialogResult.OK)
      return;
    this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadOutController = fLeadControl1.mwCamLeadController;
    this.buCamParameter = new camParameters5(fLeadControl1.buCamParameter);
  }

  public void ControlUpdate()
  {
    this.\u0001.Enabled = true;
    this.\u0002.Enabled = true;
    if (this.\u0001.Checked)
      this.\u0002.Enabled = false;
    else
      this.\u0001.Enabled = false;
    this.\u0004.Enabled = true;
    this.\u0003.Enabled = true;
    if (this.\u0004.Checked)
      this.\u0003.Enabled = false;
    else
      this.\u0004.Enabled = false;
  }

  public void Apply()
  {
    this.mwCamParameter.MachParam.LinkParams.FirstEntry.UseHomePositionFlg = this.\u0002.Checked;
    this.mwCamParameter.MachParam.LinkParams.LastExit.UseHomePositionFlg = this.\u0001.Checked;
    if (this.cmb_firstEntry.SelectedIndex == 0)
      this.mwCamParameter.MachParam.LinkParams.FirstEntry.Type = FirstEntryType.FromRapidPlane;
    else if (this.cmb_firstEntry.SelectedIndex == 1)
      this.mwCamParameter.MachParam.LinkParams.FirstEntry.Type = FirstEntryType.UseRapidDistance;
    else if (this.cmb_firstEntry.SelectedIndex == 2)
      this.mwCamParameter.MachParam.LinkParams.FirstEntry.Type = FirstEntryType.UseFeedDistance;
    else if (this.cmb_firstEntry.SelectedIndex == 3)
      this.mwCamParameter.MachParam.LinkParams.FirstEntry.Type = FirstEntryType.Direct;
    this.mwCamParameter.MachParam.LinkParams.FirstEntry.LeadController.IsUsed = this.cmb_firstleadin.SelectedIndex == 0;
    if (this.cmb_lastexit.SelectedIndex == 0)
      this.mwCamParameter.MachParam.LinkParams.LastExit.Type = LastExitType.BackToRapidPlane;
    else if (this.cmb_lastexit.SelectedIndex == 1)
      this.mwCamParameter.MachParam.LinkParams.LastExit.Type = LastExitType.UseRapidDistance;
    else if (this.cmb_lastexit.SelectedIndex == 2)
      this.mwCamParameter.MachParam.LinkParams.LastExit.Type = LastExitType.UseFeedDistance;
    else if (this.cmb_lastexit.SelectedIndex == 3)
      this.mwCamParameter.MachParam.LinkParams.LastExit.Type = LastExitType.Direct;
    this.mwCamParameter.MachParam.LinkParams.LastExit.LeadController.IsUsed = this.cmb_lastexitleadout.SelectedIndex == 0;
    if (this.\u0001.Checked)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SetGapSize(new PercentOrValueParameter(this.mwCamParameter.Units, true)
      {
        Percent = (double) this.\u0001.Value
      });
    else
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SetGapSize(new PercentOrValueParameter(this.mwCamParameter.Units, false)
      {
        Value = (double) this.\u0002.Value
      });
    if (this.cmb_gapsalong_langegap.SelectedIndex == 0)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
    else if (this.cmb_gapsalong_langegap.SelectedIndex == 1)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapFollowSurfs;
    else if (this.cmb_gapsalong_langegap.SelectedIndex == 2)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
    else if (this.cmb_gapsalong_langegap.SelectedIndex == 3)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapStep;
    else if (this.cmb_gapsalong_langegap.SelectedIndex == 4)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
    else if (this.cmb_gapsalong_langegap.SelectedIndex == 5)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeedRap;
    else if (this.cmb_gapsalong_langegap.SelectedIndex == 6)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeed;
    else if (this.cmb_gapsalong_langegap.SelectedIndex == 7)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.Action = MoveHandlingAction.ActionGapShortestPath;
    if (this.cmb_gapsalong_largeleadinout.SelectedIndex == 0)
    {
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed = true;
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadOutController.IsUsed = false;
    }
    else if (this.cmb_gapsalong_largeleadinout.SelectedIndex == 1)
    {
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed = false;
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadOutController.IsUsed = true;
    }
    else if (this.cmb_gapsalong_largeleadinout.SelectedIndex == 2)
    {
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed = true;
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadOutController.IsUsed = true;
    }
    else
    {
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed = false;
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.LargeMoveHandling.MoveLeadController.LeadOutController.IsUsed = false;
    }
    if (this.cmb_gapsalong_smallgap.SelectedIndex == 0)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
    else if (this.cmb_gapsalong_smallgap.SelectedIndex == 1)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapFollowSurfs;
    else if (this.cmb_gapsalong_smallgap.SelectedIndex == 2)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
    else if (this.cmb_gapsalong_smallgap.SelectedIndex == 3)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapStep;
    else if (this.cmb_gapsalong_smallgap.SelectedIndex == 4)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
    else if (this.cmb_gapsalong_smallgap.SelectedIndex == 5)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeedRap;
    else if (this.cmb_gapsalong_smallgap.SelectedIndex == 6)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeed;
    else if (this.cmb_gapsalong_smallgap.SelectedIndex == 7)
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.Action = MoveHandlingAction.ActionGapShortestPath;
    if (this.cmb_gapsalong_smallleadinout.SelectedIndex == 0)
    {
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed = true;
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadOutController.IsUsed = false;
    }
    else if (this.cmb_gapsalong_smallleadinout.SelectedIndex == 1)
    {
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed = false;
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadOutController.IsUsed = true;
    }
    else if (this.cmb_gapsalong_smallleadinout.SelectedIndex == 2)
    {
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed = true;
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadOutController.IsUsed = true;
    }
    else
    {
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed = false;
      this.mwCamParameter.MachParam.LinkParams.GapsAlongCut.SmallMoveHandling.MoveLeadController.LeadOutController.IsUsed = false;
    }
    this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SetGapSize(new PercentOrValueParameter(this.mwCamParameter.Units, false)
    {
      Value = (double) this.\u0005.Value
    });
    if (this.cmb_pass_largemoves.SelectedIndex == 0)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
    else if (this.cmb_pass_largemoves.SelectedIndex == 1)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action = MoveHandlingAction.ActionGapFollowSurfs;
    else if (this.cmb_pass_largemoves.SelectedIndex == 2)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
    else if (this.cmb_pass_largemoves.SelectedIndex == 3)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action = MoveHandlingAction.ActionGapStep;
    else if (this.cmb_pass_largemoves.SelectedIndex == 4)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
    else if (this.cmb_pass_largemoves.SelectedIndex == 5)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeedRap;
    else if (this.cmb_pass_largemoves.SelectedIndex == 6)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeed;
    else if (this.cmb_pass_largemoves.SelectedIndex == 7)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.Action = MoveHandlingAction.ActionGapShortestPath;
    if (this.cmb_pass_largeleadinout.SelectedIndex == 0)
    {
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed = true;
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.MoveLeadController.LeadOutController.IsUsed = false;
    }
    else if (this.cmb_pass_largeleadinout.SelectedIndex == 1)
    {
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed = false;
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.MoveLeadController.LeadOutController.IsUsed = true;
    }
    else if (this.cmb_pass_largeleadinout.SelectedIndex == 2)
    {
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed = true;
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.MoveLeadController.LeadOutController.IsUsed = true;
    }
    else
    {
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed = false;
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.LargeMoveHandling.MoveLeadController.LeadOutController.IsUsed = false;
    }
    if (this.cmb_pass_smallmoves.SelectedIndex == 0)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
    else if (this.cmb_pass_smallmoves.SelectedIndex == 1)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action = MoveHandlingAction.ActionGapFollowSurfs;
    else if (this.cmb_pass_smallmoves.SelectedIndex == 2)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
    else if (this.cmb_pass_smallmoves.SelectedIndex == 3)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action = MoveHandlingAction.ActionGapStep;
    else if (this.cmb_pass_smallmoves.SelectedIndex == 4)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
    else if (this.cmb_pass_smallmoves.SelectedIndex == 5)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeedRap;
    else if (this.cmb_pass_smallmoves.SelectedIndex == 6)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeed;
    else if (this.cmb_pass_smallmoves.SelectedIndex == 7)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.Action = MoveHandlingAction.ActionGapShortestPath;
    if (this.cmb_pass_smallleadinout.SelectedIndex == 0)
    {
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed = true;
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadOutController.IsUsed = false;
    }
    else if (this.cmb_pass_smallleadinout.SelectedIndex == 1)
    {
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed = false;
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadOutController.IsUsed = true;
    }
    else if (this.cmb_pass_smallleadinout.SelectedIndex == 2)
    {
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed = true;
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadOutController.IsUsed = true;
    }
    else
    {
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed = false;
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenPasses.SmallMoveHandling.MoveLeadController.LeadOutController.IsUsed = false;
    }
    if (this.\u0004.Checked)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SetGapSize(new PercentOrValueParameter(this.mwCamParameter.Units, true)
      {
        Percent = (double) this.\u0004.Value
      });
    else
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SetGapSize(new PercentOrValueParameter(this.mwCamParameter.Units, false)
      {
        Value = (double) this.\u0003.Value
      });
    if (this.cmb_slices_largemoves.SelectedIndex == 0)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
    else if (this.cmb_slices_largemoves.SelectedIndex == 1)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action = MoveHandlingAction.ActionGapFollowSurfs;
    else if (this.cmb_slices_largemoves.SelectedIndex == 2)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
    else if (this.cmb_slices_largemoves.SelectedIndex == 3)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action = MoveHandlingAction.ActionGapStep;
    else if (this.cmb_slices_largemoves.SelectedIndex == 4)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
    else if (this.cmb_slices_largemoves.SelectedIndex == 5)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeedRap;
    else if (this.cmb_slices_largemoves.SelectedIndex == 6)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeed;
    else if (this.cmb_slices_largemoves.SelectedIndex == 7)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.Action = MoveHandlingAction.ActionGapShortestPath;
    if (this.cmb_slices_largeleadinout.SelectedIndex == 0)
    {
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed = true;
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.MoveLeadController.LeadOutController.IsUsed = false;
    }
    else if (this.cmb_slices_largeleadinout.SelectedIndex == 1)
    {
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed = false;
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.MoveLeadController.LeadOutController.IsUsed = true;
    }
    else if (this.cmb_slices_largeleadinout.SelectedIndex == 2)
    {
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed = true;
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.MoveLeadController.LeadOutController.IsUsed = true;
    }
    else
    {
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.MoveLeadController.LeadInController.IsUsed = false;
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.LargeMoveHandling.MoveLeadController.LeadOutController.IsUsed = false;
    }
    if (this.cmb_slices_smallmoves.SelectedIndex == 0)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action = MoveHandlingAction.ActionGapDirect;
    else if (this.cmb_slices_smallmoves.SelectedIndex == 1)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action = MoveHandlingAction.ActionGapFollowSurfs;
    else if (this.cmb_slices_smallmoves.SelectedIndex == 2)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBlendSpline;
    else if (this.cmb_slices_smallmoves.SelectedIndex == 3)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action = MoveHandlingAction.ActionGapStep;
    else if (this.cmb_slices_smallmoves.SelectedIndex == 4)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
    else if (this.cmb_slices_smallmoves.SelectedIndex == 5)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeedRap;
    else if (this.cmb_slices_smallmoves.SelectedIndex == 6)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action = MoveHandlingAction.ActionGapBrokenFeed;
    else if (this.cmb_slices_smallmoves.SelectedIndex == 7)
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.Action = MoveHandlingAction.ActionGapShortestPath;
    if (this.cmb_slices_smallleadinout.SelectedIndex == 0)
    {
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed = true;
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadOutController.IsUsed = false;
    }
    else if (this.cmb_slices_smallleadinout.SelectedIndex == 1)
    {
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed = false;
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadOutController.IsUsed = true;
    }
    else if (this.cmb_slices_smallleadinout.SelectedIndex == 2)
    {
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed = true;
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadOutController.IsUsed = true;
    }
    else
    {
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadInController.IsUsed = false;
      this.mwCamParameter.MachParam.LinkParams.LinkBetweenSlices.SmallMoveHandling.MoveLeadController.LeadOutController.IsUsed = false;
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1) => this.ControlUpdate();

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == this.\u0002.Name)
      this.\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == this.\u0001.Name)
      this.\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == this.\u0001.Name)
      this.\u0001.Image = (Image) ResourceImage.SmallGapSizeGapsAlongCut;
    else if (control2.Name == this.\u0002.Name)
      this.\u0001.Image = (Image) ResourceImage.SmallGapSizeGapsAlongCut;
    else if (control2.Name == this.\u0001.Name)
      this.\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == this.\u0002.Name)
      this.\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == this.\u0004.Name)
    {
      this.\u0001.Image = (Image) ResourceImage.LinkBetweenSlicesSmallMoveSize;
    }
    else
    {
      if (!(control2.Name == this.\u0003.Name))
        return;
      this.\u0001.Image = (Image) ResourceImage.LinkBetweenSlicesSmallMoveSize;
    }
  }
}
