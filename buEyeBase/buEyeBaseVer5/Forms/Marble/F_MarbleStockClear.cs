// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleStockClear
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

public class F_MarbleStockClear : Form
{
  public buCheckBox chk_zigzag;
  internal PictureBox \u0001;
  public buCheckBox chk_toolmillinghead;
  public buCheckBox chk_toolsaw;
  public buCheckBox chk_toolmilling;
  public buButton btn_closecross;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public marbleSawMillingPars varSettings;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buSpin spn_finishsurfoffset;
  public buSpin spn_finishzdownstep;
  public buSpin spn_finishstepang;
  public buButton btn_ok;
  public buButton btn_cancel;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleSawMillingCam) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleSawMillingCam) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleStockClear() => F_MarbleSawMillingCam.Captions = new List<string>();

  public F_MarbleStockClear()
  {
    ((F_MarbleProfileCurveCam) this).Properties = new FormProperties();
    ((F_MarbleProfileCurveCam) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleSlice) this);
  }

  public void Init()
  {
    ((F_MarbleProfileCurveCam) this).Properties.Inited = false;
    if (((F_MarbleProfileCurveCam) this).Properties.Height > 10)
      this.Height = ((F_MarbleProfileCurveCam) this).Properties.Height;
    if (((F_MarbleProfileCurveCam) this).Properties.Width > 10)
      this.Width = ((F_MarbleProfileCurveCam) this).Properties.Width;
    this.TopMost = ((F_MarbleProfileCurveCam) this).Properties.TopMost;
    this.StartPosition = ((F_MarbleProfileCurveCam) this).Properties.FormPosition;
    ((F_MarbleProfileCurveCam) this).Properties.Result = DialogResult.None;
    ((F_MarbleProfileCurveCam) this).Properties.Inited = true;
    this.LoadLanguage();
  }

  public void LoadLanguage()
  {
    ((F_MarbleProfileCurveCam) this).lbl_count.Text = buLangTranslate.preDef.Count;
    ((F_MarbleProfileCurveCam) this).lbl_ea.Text = buLangTranslate.preDef.EndAngle;
    ((F_MarbleProfileCurveCam) this).lbl_length.Text = buLangTranslate.preDef.Length;
    ((F_MarbleProfileCurveCam) this).lbl_sa.Text = buLangTranslate.preDef.StartAngle;
    ((F_MarbleProfileCurveCam) this).btn_cancel.Text = buLangTranslate.preDef.Open;
    ((F_MarbleProfileCurveCam) this).btn_ok.Text = buLangTranslate.preDef.Ok;
    ((F_MarbleProfileCurveCam) this).chk_horizontal.Text = buLangTranslate.preDef.Horizontal;
    ((F_MarbleProfileCurveCam) this).chk_vertical.Text = buLangTranslate.preDef.Vertical;
    this.Text = buLangTranslate.preDef.Slice;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleProfileCurveCam) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleProfileCurveCam) this).Properties.Result = DialogResult.Cancel;
    if (((F_MarbleProfileCurveCam) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleProfileCurveCam) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control = obj0 as Control;
      if (control.Name == ((F_MarbleProfileCurveCam) this).btn_ok.Name)
      {
        ((F_MarbleProfileCurveCam) this).Properties.Result = DialogResult.OK;
        if (((F_MarbleProfileCurveCam) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleProfileCurveCam) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control.Name == ((F_MarbleProfileCurveCam) this).btn_close.Name | control.Name == ((F_MarbleProfileCurveCam) this).btn_cancel.Name))
        return;
      ((F_MarbleProfileCurveCam) this).Properties.Result = DialogResult.Cancel;
      if (((F_MarbleProfileCurveCam) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleProfileCurveCam) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleProfileCurveCam) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleProfileCurveCam) this).\u0001.Dispose();
    base.Dispose(disposing);
  }
}
