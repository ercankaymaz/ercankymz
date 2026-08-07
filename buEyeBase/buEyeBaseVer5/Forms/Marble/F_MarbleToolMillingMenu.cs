// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleToolMillingMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleToolMillingMenu : Form
{
  public buButton btn_DO51;
  public buButton btn_DO59;
  public buButton btn_DO52;
  public buButton btn_DO58;
  public buButton btn_DO53;
  public buButton btn_DO57;
  public buButton btn_DO54;
  public buButton btn_DO56;
  public buButton btn_DO55;

  static F_MarbleToolMillingMenu() => F_MarbleDigitalInput.Captions = new List<string>();

  public F_MarbleToolMillingMenu()
  {
    // ISSUE: unable to decompile the method.
  }

  public void Init()
  {
    ((F_MarbleAbsoluteSet) this).PropertiesForm.Inited = false;
    if (((F_MarbleAbsoluteSet) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleAbsoluteSet) this).PropertiesForm.Height;
    if (((F_MarbleAbsoluteSet) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleAbsoluteSet) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleAbsoluteSet) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleAbsoluteSet) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleAbsoluteSet) this).chk_toolsaw.Check = true;
    ((F_MarbleAbsoluteSet) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleAbsoluteSet) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleAbsoluteSet) this).chk_toolsaw.Text = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Tool}";
      ((F_MarbleAbsoluteSet) this).buGround1.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Menu}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleAbsoluteSet) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleAbsoluteSet) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleAbsoluteSet) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleAbsoluteSet) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleAbsoluteSet) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleAbsoluteSet) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleAbsoluteSet) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] bool obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleAbsoluteSet) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleAbsoluteSet) this).\u0001.Dispose();
    base.Dispose(disposing);
  }
}
