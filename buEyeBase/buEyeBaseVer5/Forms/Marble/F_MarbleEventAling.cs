// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleEventAling
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleEventAling : Form
{
  public buLabel lbl_millingdia;
  public buLabel lbl_sawtickness;
  public static byte f001B82;
  private string \u0001;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public bool DryRunEnable;
  public double DryRunOffsetZ;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buButton btn_addmaterial;
  public buButton btn_deletephoto;
  public buGround ground_base;
  public buButton btn_close;
  public buButton btn_importphoto;
  public buButton btn_deletematerial;
  public buButton btn_materialcontour;
  public buButton btn_drawing;
  public buCheckBox chk_Dryrun;
  public buSpin spn_dryrunoffset;
  public buButton btn_draw;
  public buSpin spn_goposy;
  public buSpin spn_goposx;
  public static byte f001B98;
  private string \u0001 = "F_MarbleViewV1";
  public static List<string> Captions = new List<string>();
  public FormProperties PropertiesForm = new FormProperties();
  internal IContainer \u0001 = (IContainer) null;
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buButton btn_viewleft;
  public buButton btn_viewfront;
  public buButton btn_zoomfit;
  public buButton btn_viewiso;
  public buButton btn_viewtop;
  public buButton btn_zoomwindow;
  public buButton btn_viewclose;
  public buButton btn_viewrotate;
  public buButton btn_viewpan;
  public buButton btn_zoomout;

  public F_MarbleEventAling()
  {
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleViewV1) this);
  }

  public void UpdateVisuals()
  {
    string str = nameof (UpdateVisuals);
    try
    {
      this.LoadLanguage();
      if (clsVisualVars.parVisual == null || !(!this.PropertiesForm.VisualUpdated | AppBool.VisualUpdateForce) || !new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm").Exists)
        return;
      Control.ControlCollection controlCollection = (Control.ControlCollection) null;
      controlCollection = buEyeShotFunctions.SetVisualItem(this.Controls);
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleCollapse) this).ground_base.Controls);
      this.PropertiesForm.VisualUpdated = true;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(this.\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    if (this.PropertiesForm.Height > 10)
      this.Height = this.PropertiesForm.Height;
    if (this.PropertiesForm.Width > 10)
      this.Width = this.PropertiesForm.Width;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleCollapse) this).btn_viewcube.Visible = AppBool.DeveloperMode;
    ((F_MarbleCollapse) this).btn_zoomratio.Visible = AppBool.DeveloperMode;
    ((F_MarbleEventScale) this).spn_zoomratio.Visible = AppBool.DeveloperMode;
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleCollapse) this).ground_base.Text = buLangTranslate.preDef.View;
    }
    catch (Exception ex)
    {
    }
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

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    if (!((obj0 as Control).Name == ((F_MarbleCollapse) this).btn_viewcube.Name))
      return;
    if (((F_MarbleCollapse) this).\u0001.Visible)
      ((F_MarbleCollapse) this).\u0001.Visible = false;
    else
      ((F_MarbleCollapse) this).\u0001.Visible = true;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.\u0001 != null ? 1 : 0)) != 0)
      this.\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MarbleEventAling()
  {
    // ISSUE: unable to decompile the method.
  }

  public void Init()
  {
    ((F_MarbleEventMirror) this).PropertiesForm.Inited = false;
    if (((F_MarbleEventMirror) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleEventMirror) this).PropertiesForm.Height;
    if (((F_MarbleEventMirror) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleEventMirror) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleEventMirror) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleEventMirror) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleEventCopyMulti) this).buGround1.DisplayTop.BackColor = ((F_MarbleEventMirror) this).clrFormCaption;
    ((F_MarbleEventCopyMulti) this).buGround1.Display.GradientType = GradientMode.Lineer;
    ((F_MarbleEventCopyMulti) this).buGround1.Display.LineerGradient.FirstColor = ((F_MarbleEventMirror) this).clrFormBackUpper;
    ((F_MarbleEventCopyMulti) this).buGround1.Display.LineerGradient.SecondColor = ((F_MarbleEventMirror) this).clrFormBackDown;
    ((F_MarbleEventCopyMulti) this).btn_close.Display.BackColor = ((F_MarbleEventMirror) this).clrFormCaption;
    ((F_MarbleEventCopyMulti) this).btn_close.ButtonDownDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleEventMirror) this).clrFormCaption, 0.9);
    ((F_MarbleEventCopyMulti) this).btn_close.ButtonOverDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleEventMirror) this).clrFormCaption, 0.95);
    ((F_MarbleEventMirror) this).btn_chamfer.Display.BackColor = ((F_MarbleEventMirror) this).clrButtonDisplay;
    ((F_MarbleEventMirror) this).btn_chamfer.ButtonDownDisplay.BackColor = ((F_MarbleEventMirror) this).clrButtonDown;
    ((F_MarbleEventMirror) this).btn_chamfer.ButtonOverDisplay.BackColor = ((F_MarbleEventMirror) this).clrButtonOver;
    ((F_MarbleEventMirror) this).btn_rectangle.Display.BackColor = ((F_MarbleEventMirror) this).clrButtonDisplay;
    ((F_MarbleEventMirror) this).btn_rectangle.ButtonDownDisplay.BackColor = ((F_MarbleEventMirror) this).clrButtonDown;
    ((F_MarbleEventMirror) this).btn_rectangle.ButtonOverDisplay.BackColor = ((F_MarbleEventMirror) this).clrButtonOver;
    ((F_MarbleEventMirror) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleEventMirror) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleEventMirror) this).btn_rectangle.Text = buLangTranslate.preDef.Rectangle;
      ((F_MarbleEventMirror) this).btn_chamfer.Text = buLangTranslate.preDef.Chamfer;
      ((F_MarbleEventCopyMulti) this).btn_radius.Text = buLangTranslate.preDef.Radius;
      ((F_MarbleEventCopyMulti) this).buGround1.Text = $"{buLangTranslate.preDef.Corner} {buLangTranslate.preDef.Menu}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleEventMirror) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleEventMirror) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleEventMirror) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleEventMirror) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public event OkCommandWithFiveDataEventHandler AlingCommand;
}
