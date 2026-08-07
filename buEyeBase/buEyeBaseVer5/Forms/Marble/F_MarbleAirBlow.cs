// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleAirBlow
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleAirBlow : Form
{
  public buButton btn_DO44;
  public buButton btn_DO35;
  public buButton btn_DO43;
  public buButton btn_DO36;
  public buButton btn_DO42;
  public buButton btn_DO37;
  public buButton btn_DO41;
  public buButton btn_DO38;
  public buButton btn_DO40;
  public buButton btn_DO39;
  public buPanel pnl_output1;
  public buButton btn_DO15;
  public buButton btn_DO14;
  public buButton btn_DO13;
  public buButton btn_DO12;
  public buButton btn_DO11;

  public F_MarbleAirBlow()
  {
    // ISSUE: unable to decompile the method.
  }

  public void Init()
  {
    // ISSUE: unable to decompile the method.
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleDigitalInput) this).chk_finish.Text = $"{buLangTranslate.preDef.Finish} {buLangTranslate.preDef.Strategy}";
      ((F_MarbleDigitalInput) this).chk_rough.Text = $"{buLangTranslate.preDef.Rough} {buLangTranslate.preDef.Strategy}";
      ((F_MarbleDigitalInput) this).\u0001.Text = $"{buLangTranslate.preDef.Profile} {buLangTranslate.preDef.Strategy}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleDigitalInput) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleDigitalInput) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleDigitalInput) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleDigitalInput) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleDigitalInput) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleDigitalInput) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleDigitalInput) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] bool obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleDigitalInput) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleDigitalInput) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleAirBlow() => F_MarbleDigitalInput.Captions = new List<string>();

  public F_MarbleAirBlow()
  {
    ((F_MarbleDigitalInput) this).SpinBaseColor = Color.LightGreen;
    ((F_MarbleDigitalInput) this).SpinFocusColor = Color.MistyRose;
    ((F_MarbleDigitalInput) this).PropertiesForm = new FormProperties();
    ((F_MarbleDigitalInput) this).CountertopType = MarbleCountertopMenuTypes.Rectangle;
    ((F_MarbleDigitalInput) this).MenuType = (marbleMenuType) new \u0007.\u0001();
    ((F_MarbleDigitalInput) this).clrLabel = Color.DarkSeaGreen;
    ((F_MarbleDigitalInput) this).clrFormCaption = Color.LightBlue;
    ((F_MarbleDigitalInput) this).clrFormBackUpper = Color.Black;
    ((F_MarbleDigitalInput) this).clrFormBackDown = Color.DarkGray;
    ((F_MarbleDigitalInput) this).clrButtonDisplay = Color.DarkGray;
    ((F_MarbleDigitalInput) this).clrButtonOver = Color.Gold;
    ((F_MarbleDigitalInput) this).clrButtonDown = Color.Goldenrod;
    ((F_MarbleDigitalInput) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleCounterTopMenu) this);
  }
}
