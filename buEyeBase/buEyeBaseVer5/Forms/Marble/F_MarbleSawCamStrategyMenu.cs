// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleSawCamStrategyMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleSawCamStrategyMenu : Form
{
  public buButton btn_DI20;
  public buButton btn_DI26;
  public buButton btn_DI21;
  public buButton btn_DI25;
  public buButton btn_DI22;
  public buButton btn_DI24;
  public buButton btn_DI23;
  public buButton btn_DI47;
  public buButton btn_DI32;

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleToolMillingSawMenu) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleToolMillingSawMenu) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleToolMillingSawMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleToolMillingSawMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleToolMillingSawMenu) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleToolMillingSawMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleToolMillingSawMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleToolMillingSawMenu) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleToolMillingSawMenu) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleSawCamStrategyMenu() => F_MarbleToolMillingSawMenu.Captions = new List<string>();

  public F_MarbleSawCamStrategyMenu()
  {
    ((F_MarbleLatheMenu) this).SpinBaseColor = Color.LightGreen;
    ((F_MarbleLatheMenu) this).SpinFocusColor = Color.MistyRose;
    ((F_MarbleLatheMenu) this).PropertiesForm = new FormProperties();
    ((F_MarbleLatheMenu) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleG54Set) this);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_G54Command(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_MarbleLatheMenu) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_MarbleLatheMenu) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_G54Command(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_MarbleLatheMenu) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_MarbleLatheMenu) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init()
  {
    ((F_MarbleLatheMenu) this).PropertiesForm.Inited = false;
    if (((F_MarbleLatheMenu) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleLatheMenu) this).PropertiesForm.Height;
    if (((F_MarbleLatheMenu) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleLatheMenu) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleLatheMenu) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleLatheMenu) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleLatheMenu) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleLatheMenu) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleLatheMenu) this).\u0001.Text = "G54 " + buLangTranslate.preDef.Set;
      ((F_MarbleLatheMenu) this).btn_xG54set.Text = $"{buLangTranslate.preDef.Position} {buLangTranslate.preDef.Set}";
      ((F_MarbleLatheMenu) this).btn_yG54set.Text = $"{buLangTranslate.preDef.Position} {buLangTranslate.preDef.Set}";
      ((F_MarbleLatheMenu) this).btn_zG54set.Text = $"{buLangTranslate.preDef.Position} {buLangTranslate.preDef.Set}";
    }
    catch (Exception ex)
    {
    }
  }
}
