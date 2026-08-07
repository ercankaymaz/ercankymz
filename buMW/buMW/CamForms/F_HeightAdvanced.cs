// Decompiled with JetBrains decompiler
// Type: buMW.CamForms.F_HeightAdvanced
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buControls.Forms.WinControlForms.Views;
using buEyeBaseVer5;
using buImages;
using ModuleWorks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW.CamForms;

public class F_HeightAdvanced : Form
{
  internal NumericUpDown \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal System.Windows.Forms.Label \u0003;
  public ComboBox cmb_multipasssort;
  internal NumericUpDown \u0002;
  internal System.Windows.Forms.Label \u0004;
  internal CheckBox \u0002;
  public FormProperties PropertiesForm = new FormProperties();
  public GeoLib mwCamParameter = (GeoLib) null;
  public camParameters5 buCamParameter = (camParameters5) null;
  public ToolBase5 Tool = (ToolBase5) null;
  public MWCalculationOptions Configration = new MWCalculationOptions();
  public static List<string> Captions;
  internal IContainer \u0001 = (IContainer) null;
  internal NumericUpDown \u0001;
  internal CheckBox \u0001;
  internal NumericUpDown \u0002;
  internal CheckBox \u0002;
  public Button btn_ok;
  internal ImageList \u0001;
  public Button btn_cancel;
  internal ImageList \u0002;
  internal CheckBox \u0003;
  internal PictureBox \u0001;
  internal System.Windows.Forms.Label \u0001;
  internal System.Windows.Forms.Label \u0002;
  internal NumericUpDown \u0003;

  internal void \u0006([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!((F_MultiPass) this).PropertiesForm.Inited)
      return;
    if (control2.Name == this.cmb_multipasssort.Name)
    {
      if (this.cmb_multipasssort.SelectedIndex == 0)
        ((F_MultiPass) this).\u0001.Image = (Image) ResourceImage.MultPassRoughtSortSlices;
      else if (this.cmb_multipasssort.SelectedIndex == 1)
        ((F_MultiPass) this).\u0001.Image = (Image) ResourceImage.MultPassRoughtSortPasses;
    }
    ((F_MultiPass) this).PropertiesForm.Inited = false;
    ((F_MultiPass) this).Apply();
    ((F_MultiPass) this).ControlUpdate();
    ((F_MultiPass) this).PropertiesForm.Inited = true;
  }

  internal void \u0007([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == this.\u0002.Name)
      ((F_MultiPass) this).\u0001.Image = (Image) ResourceImage.MultPassRoughtNumber;
    else if (control2.Name == this.\u0001.Name)
    {
      ((F_MultiPass) this).\u0001.Image = (Image) ResourceImage.MultPassRoughtSpacing;
    }
    else
    {
      if (!(control2.Name == this.\u0002.Name))
        return;
      ((F_MultiPass) this).\u0001.Image = (Image) ResourceImage.NoImage;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MultiPass) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MultiPass) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_HeightAdvanced() => F_MultiPass.Captions = new List<string>();

  public F_HeightAdvanced() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.\u0003.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.AngleStepForFeedMoves;
    this.\u0001.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.AngleStepForRapidMoves;
    ((F_AngleRange) this).\u0004.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.LinkSmoothingRadius;
    this.\u0002.Value = (Decimal) this.mwCamParameter.MachParam.LinkParams.ToolInitialOrientationDistance;
    ((F_AngleRange) this).\u0004.Checked = this.mwCamParameter.MachParam.LinkParams.ArcFitFeedDistanceFlg;
    ((F_AngleRange) this).\u0005.Checked = this.mwCamParameter.MachParam.LinkParams.ArcFitRapidDistanceFlg;
    ((F_AngleRange) this).\u0006.Checked = this.mwCamParameter.MachParam.LinkParams.ChangeToolDir2ClearanceDirFlg;
    this.\u0002.Checked = this.mwCamParameter.MachParam.LinkParams.InterpolateLinkMovesFlg;
    this.\u0001.Checked = this.mwCamParameter.MachParam.LinkParams.ChangeToolDir2ClearanceDirFlg;
    this.Refresh();
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
    \u0005.\u0002.\u0001(this);
    this.ControlUpdate();
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
    ((F_AngleRange) this).\u0004.Enabled = ((F_AngleRange) this).\u0006.Checked | ((F_AngleRange) this).\u0005.Checked | ((F_AngleRange) this).\u0004.Checked;
    this.\u0001.Enabled = this.\u0001.Checked | this.\u0002.Checked;
    this.\u0003.Enabled = this.\u0001.Checked | this.\u0002.Checked;
    this.\u0002.Enabled = this.\u0001.Checked | this.\u0001.Checked & this.\u0002.Checked;
  }

  public void Apply()
  {
    this.mwCamParameter.MachParam.LinkParams.AngleStepForFeedMoves = (double) this.\u0003.Value;
    this.mwCamParameter.MachParam.LinkParams.AngleStepForRapidMoves = (double) this.\u0001.Value;
    this.mwCamParameter.MachParam.LinkParams.LinkSmoothingRadius = (double) ((F_AngleRange) this).\u0004.Value;
    this.mwCamParameter.MachParam.LinkParams.ToolInitialOrientationDistance = (double) this.\u0002.Value;
    this.mwCamParameter.MachParam.LinkParams.ArcFitFeedDistanceFlg = ((F_AngleRange) this).\u0004.Checked;
    this.mwCamParameter.MachParam.LinkParams.ArcFitRapidDistanceFlg = ((F_AngleRange) this).\u0005.Checked;
    this.mwCamParameter.MachParam.LinkParams.ChangeToolDir2ClearanceDirFlg = ((F_AngleRange) this).\u0006.Checked;
    this.mwCamParameter.MachParam.LinkParams.InterpolateLinkMovesFlg = this.\u0002.Checked;
    this.mwCamParameter.MachParam.LinkParams.ChangeToolDir2ClearanceDirFlg = this.\u0001.Checked;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control = new Control();
    if (!this.PropertiesForm.Inited)
      return;
    this.PropertiesForm.Inited = false;
    this.Apply();
    this.ControlUpdate();
    this.PropertiesForm.Inited = true;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == this.\u0001.Name)
      this.\u0001.Image = (Image) ResourceImage.RetractsAngleStepForRapidMoves;
    else if (control2.Name == ((F_AngleRange) this).\u0006.Name)
    {
      this.\u0001.Image = (Image) ResourceImage.RetractsArcFitClearanceArea;
      if (this.\u0003.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_AngleRange) this).\u0005.Name)
    {
      this.\u0001.Image = (Image) ResourceImage.RetractsArcFitClearanceArea;
      if (this.\u0003.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == ((F_AngleRange) this).\u0004.Name)
    {
      this.\u0001.Image = (Image) ResourceImage.RetractsArcFitClearanceArea;
      if (((F_AngleRange) this).\u0004.Checked)
      {
        if (this.\u0003.Checked)
        {
          F_GifView fGifView = new F_GifView();
          fGifView.Init();
          fGifView.StartPosition = FormStartPosition.CenterParent;
          int num = (int) fGifView.ShowDialog();
        }
      }
      else if (this.\u0003.Checked)
      {
        F_GifView fGifView = new F_GifView();
        fGifView.Init();
        fGifView.StartPosition = FormStartPosition.CenterParent;
        int num = (int) fGifView.ShowDialog();
      }
    }
    else if (control2.Name == this.\u0002.Name)
      this.\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == this.\u0001.Name)
      this.\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == this.\u0003.Name)
      this.\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == this.\u0002.Name)
      this.\u0001.Image = (Image) ResourceImage.NoImage;
    else if (control2.Name == ((F_AngleRange) this).\u0004.Name)
      this.\u0001.Image = (Image) ResourceImage.NoImage;
    this.\u0003.Checked = false;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    if (this.PropertiesForm.Inited)
      ;
  }
}
