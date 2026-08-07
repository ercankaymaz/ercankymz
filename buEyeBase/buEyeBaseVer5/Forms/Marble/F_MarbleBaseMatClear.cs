// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleBaseMatClear
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

public class F_MarbleBaseMatClear : Form
{
  public buSpin spn_airblowheight;
  public buCheckBox chk_onlyparts;
  public buCheckBox chk_allblock;
  public buCheckBox chk_vertical;
  public buCheckBox chk_horizontal;
  public buSpin spn_stepdistance;
  public buSpin spn_rapiddistance;
  public FormProperties Properties;
  public static List<string> Captions;
  public marbleProfileCutPars varProfileCut;
  public bool CamVisible;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buSpin spn_ang;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buButton \u0001;
  public buSpin spn_length;
  public buButton btn_settings;
  public buCheckBox chk_finish;
  public buCheckBox chk_rough;
  public buSpin spn_baseheight;
  public buCheckBox chk_cutprofileend;
  public buCheckBox chk_cutprofilestart;
  internal buLabel \u0001;
  internal buLabel \u0002;
  public buSpin spn_twistEA;

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleSweepMenu) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleSweepMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleSweepMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] bool obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleSweepMenu) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleSweepMenu) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleBaseMatClear() => F_MarbleSweepMenu.Captions = new List<string>();

  public F_MarbleBaseMatClear()
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
      ((F_MarbleProfileMenu) this).chk_toolmilling.Text = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Tool}";
      ((F_MarbleProfileMenu) this).chk_toolsaw.Text = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Tool}";
      ((F_MarbleProfileMenu) this).buGround1.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Menu}";
    }
    catch (Exception ex)
    {
    }
  }
}
