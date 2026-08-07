// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleWaterJetCamStrategyMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleWaterJetCamStrategyMenu : Form
{
  public buButton btn_DI31;
  public buButton btn_DI16;
  public buButton btn_DI30;
  public buButton btn_DI17;
  public buButton btn_DI29;
  public buButton btn_DI18;
  public buButton btn_DI28;
  public buButton btn_DI19;
  public buButton btn_DI27;

  public void Init()
  {
    ((F_MarbleProfileCutCad) this).PropertiesForm.Inited = false;
    if (((F_MarbleProfileCutCad) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleProfileCutCad) this).PropertiesForm.Height;
    if (((F_MarbleProfileCutCad) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleProfileCutCad) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleProfileCutCad) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleProfileCutCad) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleProfileCutCad) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleProfileCutCad) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleProfileCutCad) this).\u0001.Text = $"{buLangTranslate.preDef.Digital} {buLangTranslate.preDef.Output}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleProfileCutCad) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleProfileCutCad) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleProfileCutCad) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleProfileCutCad) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleProfileCutCad) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleProfileCutCad) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleProfileCutCad) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleProfileCutCad) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleProfileCutCad) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleWaterJetCamStrategyMenu() => F_MarbleProfileCutCad.Captions = new List<string>();

  public F_MarbleWaterJetCamStrategyMenu()
  {
    ((F_MarbleToolMillingSawMenu) this).PropertiesForm = new FormProperties();
    ((F_MarbleToolMillingSawMenu) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleDigitalInput) this);
  }

  public void Init()
  {
    ((F_MarbleToolMillingSawMenu) this).PropertiesForm.Inited = false;
    if (((F_MarbleToolMillingSawMenu) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleToolMillingSawMenu) this).PropertiesForm.Height;
    if (((F_MarbleToolMillingSawMenu) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleToolMillingSawMenu) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleToolMillingSawMenu) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleToolMillingSawMenu) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleToolMillingSawMenu) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleToolMillingSawMenu) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleToolMillingSawMenu) this).\u0001.Text = $"{buLangTranslate.preDef.Digital} {buLangTranslate.preDef.Input}";
    }
    catch (Exception ex)
    {
    }
  }
}
