// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleSingleCutV2
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleSingleCutV2 : Form
{
  public buSpin spn_singlelayerdepth;
  public buCheckBox chk_singlelayer;
  public buCheckBox chk_splinenebale;
  public buSpin spn_resolution;
  internal buLabel \u0005;
  public buSpin spn_curvedegree;
  public buButton btn_advanced;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public marbleProfileCurveCutPars varProfileCurveCut;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buSpin spn_finishsurfoffset;
  public buSpin spn_finishminZ;
  public buSpin spn_finishstepang;

  public void Init()
  {
    ((F_MarbleProfileCurveCam) this).PropertiesForm.Inited = false;
    if (((F_MarbleProfileCurveCam) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleProfileCurveCam) this).PropertiesForm.Height;
    if (((F_MarbleProfileCurveCam) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleProfileCurveCam) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleProfileCurveCam) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleProfileCurveCam) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleProfileCam) this).buGround1.DisplayTop.BackColor = ((F_MarbleProfileCurveCam) this).clrFormCaption;
    ((F_MarbleProfileCam) this).buGround1.Display.GradientType = GradientMode.Lineer;
    ((F_MarbleProfileCam) this).buGround1.Display.LineerGradient.FirstColor = ((F_MarbleProfileCam) this).clrFormBackUpper;
    ((F_MarbleProfileCam) this).buGround1.Display.LineerGradient.SecondColor = ((F_MarbleProfileCam) this).clrFormBackDown;
    ((F_MarbleProfileCam) this).btn_close.Display.BackColor = ((F_MarbleProfileCurveCam) this).clrFormCaption;
    ((F_MarbleProfileCam) this).btn_close.ButtonDownDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleProfileCurveCam) this).clrFormCaption, 0.9);
    ((F_MarbleProfileCam) this).btn_close.ButtonOverDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleProfileCurveCam) this).clrFormCaption, 0.95);
    ((F_MarbleProfileCam) this).lbl_contourtype.Display.BackColor = ((F_MarbleProfileCurveCam) this).clrLabel;
    ((F_MarbleProfileCam) this).btn_contourmenueditor.Display.BackColor = ((F_MarbleProfileCam) this).clrButtonDisplay;
    ((F_MarbleProfileCam) this).btn_contourmenueditor.ButtonDownDisplay.BackColor = ((F_MarbleProfileCam) this).clrButtonDown;
    ((F_MarbleProfileCam) this).btn_contourmenueditor.ButtonOverDisplay.BackColor = ((F_MarbleProfileCam) this).clrButtonOver;
    ((F_MarbleProfileCam) this).btn_contourmenufilelist.Display.BackColor = ((F_MarbleProfileCam) this).clrButtonDisplay;
    ((F_MarbleProfileCam) this).btn_contourmenufilelist.ButtonDownDisplay.BackColor = ((F_MarbleProfileCam) this).clrButtonDown;
    ((F_MarbleProfileCam) this).btn_contourmenufilelist.ButtonOverDisplay.BackColor = ((F_MarbleProfileCam) this).clrButtonOver;
    ((F_MarbleProfileCam) this).btn_contourmenufromfile.Display.BackColor = ((F_MarbleProfileCam) this).clrButtonDisplay;
    ((F_MarbleProfileCam) this).btn_contourmenufromfile.ButtonDownDisplay.BackColor = ((F_MarbleProfileCam) this).clrButtonDown;
    ((F_MarbleProfileCam) this).btn_contourmenufromfile.ButtonOverDisplay.BackColor = ((F_MarbleProfileCam) this).clrButtonOver;
    ((F_MarbleProfileCurveCam) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleProfileCurveCam) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleProfileCam) this).lbl_contourtype.Text = $"{buLangTranslate.preDef.Engrave} {buLangTranslate.preDef.Type}";
      ((F_MarbleProfileCam) this).btn_contourmenueditor.Text = buLangTranslate.preDef.Editor;
      ((F_MarbleProfileCam) this).btn_contourmenufilelist.Text = buLangTranslate.preDef.FromList;
      ((F_MarbleProfileCam) this).btn_contourmenufromfile.Text = buLangTranslate.preDef.FromFile;
      ((F_MarbleProfileCam) this).buGround1.Text = $"{buLangTranslate.preDef.Engrave} {buLangTranslate.preDef.Menu}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleProfileCurveCam) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleProfileCurveCam) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleProfileCurveCam) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleProfileCurveCam) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleProfileCurveCam) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleProfileCurveCam) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleProfileCurveCam) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleProfileCam) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleProfileCam) this).\u0001.Dispose();
    base.Dispose(disposing);
  }
}
