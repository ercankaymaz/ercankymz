// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleToolMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleToolMenu : Form
{
  public buButton btn_DI12;
  public buButton btn_DI11;
  public buButton btn_DI10;
  public buButton btn_DI9;
  public buButton btn_DI8;
  public buButton btn_DI7;
  public buButton btn_DI6;
  public buButton btn_DI5;
  public buButton btn_DI4;
  public buButton btn_DI3;
  public buButton btn_DI2;
  public buButton btn_DI1;

  [CompilerGenerated]
  [SpecialName]
  public void remove_ResetCommand(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_MarbleColumnsMenu) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_MarbleColumnsMenu) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init()
  {
    ((F_MarbleColumnsMenu) this).PropertiesForm.Inited = false;
    if (((F_MarbleColumnsMenu) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleColumnsMenu) this).PropertiesForm.Height;
    if (((F_MarbleColumnsMenu) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleColumnsMenu) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleColumnsMenu) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleColumnsMenu) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleColumnsMenu) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleColumnsMenu) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleColumnsMenu) this).\u0001.Text = $"{buLangTranslate.preDef.Position} {buLangTranslate.preDef.Reset}";
      ((F_MarbleColumnsMenu) this).btn_xrabsoluteeset.Text = $"{buLangTranslate.preDef.Position} {buLangTranslate.preDef.Reset}";
      ((F_MarbleColumnsMenu) this).btn_yabsolutereset.Text = $"{buLangTranslate.preDef.Position} {buLangTranslate.preDef.Reset}";
      ((F_MarbleColumnsMenu) this).btn_zabsolutereset.Text = $"{buLangTranslate.preDef.Position} {buLangTranslate.preDef.Reset}";
      ((F_MarbleColumnsMenu) this).btn_aabsolutereset.Text = $"{buLangTranslate.preDef.Position} {buLangTranslate.preDef.Reset}";
      ((F_MarbleColumnsMenu) this).btn_cabsolutereset.Text = $"{buLangTranslate.preDef.Position} {buLangTranslate.preDef.Reset}";
      ((F_MarbleColumnsMenu) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleColumnsMenu) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleColumnsMenu) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleColumnsMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleColumnsMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleColumnsMenu) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleColumnsMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleColumnsMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleColumnsMenu) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleColumnsMenu) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleToolMenu() => F_MarbleColumnsMenu.Captions = new List<string>();
}
