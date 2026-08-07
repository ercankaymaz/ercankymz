// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleLanguageMenu
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

public class F_MarbleLanguageMenu : Form
{
  public static byte f0021EF;
  public FormProperties Properties;
  public static List<string> Captions;
  public MarbleCamMode CamMode;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buButton \u0001;
  public buSpin spn_startzoffset;
  public buSpin spn_endzoffset;
  public buSpin spn_scaleheight;
  public buSpin spn_scalewidth;

  public void Init()
  {
    // ISSUE: unable to decompile the method.
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleEditBaseHAndXY) this).chk_toolmilling.Text = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Tool}";
      ((F_MarbleEditBaseHAndXY) this).chk_toolmillinghead.Text = $"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Tool}";
      ((F_MarbleEditBaseHAndXY) this).buGround1.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Menu}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleEditBaseHAndXY) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleEditBaseHAndXY) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleEditBaseHAndXY) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleEditBaseHAndXY) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleEditBaseHAndXY) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleEditBaseHAndXY) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleEditBaseHAndXY) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] bool obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleEditBaseHAndXY) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleEditBaseHAndXY) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleLanguageMenu() => F_MarbleEditBaseHAndXY.Captions = new List<string>();

  public F_MarbleLanguageMenu()
  {
    // ISSUE: unable to decompile the method.
  }

  public void Init()
  {
    // ISSUE: unable to decompile the method.
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
}
