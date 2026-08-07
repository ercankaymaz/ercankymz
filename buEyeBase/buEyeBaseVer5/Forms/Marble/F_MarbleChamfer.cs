// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleChamfer
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

public class F_MarbleChamfer : Form
{
  public buButton btn_DI26;
  public buButton btn_DI21;
  public buButton btn_DI25;
  public buButton btn_DI22;
  public buButton btn_DI24;
  public buButton btn_DI23;
  public buButton btn_DI47;
  public buButton btn_DI32;
  public buButton btn_DI46;
  public buButton btn_DI33;
  public buButton btn_DI45;
  public buButton btn_DI34;
  public buButton btn_DI44;
  public buButton btn_DI35;
  public buButton btn_DI43;
  public buButton btn_DI36;

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleDigitalInputOutput) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleDigitalInputOutput) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleDigitalInputOutput) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleDigitalInputOutput) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleDigitalInputOutput) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleChamfer() => F_MarbleDigitalInputOutput.Captions = new List<string>();

  public F_MarbleChamfer()
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
      ((F_MarbleDigitalInputOutput) this).chk_finish.Text = $"{buLangTranslate.preDef.Finish} {buLangTranslate.preDef.Strategy}";
      ((F_MarbleDigitalInputOutput) this).chk_rough.Text = $"{buLangTranslate.preDef.Rough} {buLangTranslate.preDef.Strategy}";
      ((F_MarbleDigitalInputOutput) this).\u0001.Text = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Strategy}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleDigitalInputOutput) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleDigitalInputOutput) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleDigitalInputOutput) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleDigitalInputOutput) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
