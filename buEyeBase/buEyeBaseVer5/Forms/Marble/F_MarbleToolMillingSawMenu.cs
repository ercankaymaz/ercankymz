// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleToolMillingSawMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleToolMillingSawMenu : Form
{
  public ImageList IC48;
  public buPanel pnl_output2;
  public buPanel pnl_output3;
  public buPanel pnl_output4;
  public static byte f0026A8;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  internal IContainer \u0001;
  internal buGround \u0001;
  public buButton btn_close;

  static F_MarbleToolMillingSawMenu() => F_MarbleAbsoluteSet.Captions = new List<string>();

  public F_MarbleToolMillingSawMenu()
  {
    ((F_MarbleAbsoluteSet) this).PropertiesForm = new FormProperties();
    ((F_MarbleAbsoluteSet) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleDigitalInputOutput) this);
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
    ((F_MarbleAbsoluteSet) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleAbsoluteSet) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleAbsoluteSet) this).\u0001.Text = $"{buLangTranslate.preDef.Digital} {buLangTranslate.preDef.Input} / {buLangTranslate.preDef.Output}";
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

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleAbsoluteSet) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleAbsoluteSet) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleAbsoluteSet) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleAbsoluteSet) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleAbsoluteSet) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleToolMillingSawMenu() => F_MarbleAbsoluteSet.Captions = new List<string>();

  public F_MarbleToolMillingSawMenu()
  {
    ((F_MarbleProfileCutCad) this).PropertiesForm = new FormProperties();
    ((F_MarbleProfileCutCad) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0001.\u0001.\u0001((F_MarbleDigitalOutput) this);
  }
}
