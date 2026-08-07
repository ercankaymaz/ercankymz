// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleEventExtend
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleEventExtend : Form
{
  public bool ShowSpindle;
  public bool ShowSaw;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buPanel pnl_base;
  public buLabel lbl_operationspeed;
  public buLabel lbl_spindlespeed;
  public buTrack track_operationspeed;
  public buTrack track_Spindlespeed;

  public void LoadLanguage()
  {
    try
    {
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleEventBreak) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleEventBreak) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleEventBreak) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleEventBreak) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleEventBreak) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleEventBreak) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleEventExtend() => F_MarbleEventBreak.Captions = new List<string>();

  public F_MarbleEventExtend()
  {
    ((F_MarbleEventOffset) this).\u0001 = "F_MarbleSpeedsV1";
    ((F_MarbleEventOffset) this).PropertiesForm = new FormProperties();
    this.ShowSpindle = true;
    this.ShowSaw = true;
    this.\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleSpeedsV1) this);
  }

  public void UpdateVisuals()
  {
    string str = nameof (UpdateVisuals);
    try
    {
      this.LoadLanguage();
      if (clsVisualVars.parVisual == null || !(!((F_MarbleEventOffset) this).PropertiesForm.VisualUpdated | AppBool.VisualUpdateForce) || !new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm").Exists)
        return;
      Control.ControlCollection controlCollection = (Control.ControlCollection) null;
      controlCollection = buEyeShotFunctions.SetVisualItem(this.pnl_base.Controls);
      ((F_MarbleEventOffset) this).PropertiesForm.VisualUpdated = true;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleEventOffset) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void Init()
  {
    ((F_MarbleEventOffset) this).PropertiesForm.Inited = false;
    if (((F_MarbleEventOffset) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleEventOffset) this).PropertiesForm.Height;
    if (((F_MarbleEventOffset) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleEventOffset) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleEventOffset) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleEventOffset) this).PropertiesForm.FormPosition;
    this.track_Spindlespeed.Visible = this.ShowSpindle;
    ((F_MarbleEventVacuum) this).spn_spindlespeed.Visible = this.ShowSpindle;
    this.lbl_spindlespeed.Visible = this.ShowSpindle;
    ((F_MarbleEventVacuum) this).btn_spindle.Visible = this.ShowSpindle;
    ((F_MarbleEventVacuum) this).btn_spindleminus.Visible = this.ShowSpindle;
    ((F_MarbleEventVacuum) this).btn_spindleplus.Visible = this.ShowSpindle;
    ((F_MarbleEventVacuum) this).track_sawspeed.Visible = this.ShowSaw;
    ((F_MarbleEventVacuum) this).spn_sawspeed.Visible = this.ShowSaw;
    ((F_MarbleEventVacuum) this).lbl_sawspeed.Visible = this.ShowSaw;
    ((F_MarbleEventVacuum) this).btn_saw.Visible = this.ShowSaw;
    ((F_MarbleEventVacuum) this).btn_sawminus.Visible = this.ShowSaw;
    ((F_MarbleEventVacuum) this).btn_sawplus.Visible = this.ShowSaw;
    if (!this.ShowSaw & this.ShowSpindle)
    {
      this.track_Spindlespeed.Top = ((F_MarbleEventVacuum) this).track_sawspeed.Top;
      ((F_MarbleEventVacuum) this).spn_spindlespeed.Top = ((F_MarbleEventVacuum) this).spn_sawspeed.Top;
      this.lbl_spindlespeed.Top = ((F_MarbleEventVacuum) this).lbl_sawspeed.Top;
      ((F_MarbleEventVacuum) this).btn_spindle.Top = ((F_MarbleEventVacuum) this).btn_saw.Top;
      ((F_MarbleEventVacuum) this).btn_spindleminus.Top = ((F_MarbleEventVacuum) this).btn_sawminus.Top;
      ((F_MarbleEventVacuum) this).btn_spindleplus.Top = ((F_MarbleEventVacuum) this).btn_sawplus.Top;
    }
    this.LoadLanguage();
    ((F_MarbleEventOffset) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleEventOffset) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      this.lbl_operationspeed.Text = $"{buLangTranslate.preDef.Operation} {buLangTranslate.preDef.Speed}";
      ((F_MarbleEventVacuum) this).lbl_quickspeed.Text = $"{buLangTranslate.preDef.Quick} {buLangTranslate.preDef.Speed}";
      ((F_MarbleEventVacuum) this).lbl_sawspeed.Text = buLangTranslate.preDef.Saw;
      this.lbl_spindlespeed.Text = buLangTranslate.preDef.Spindle;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleEventOffset) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleEventOffset) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleEventOffset) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleEventOffset) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
