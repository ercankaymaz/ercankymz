// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleContourAdvancedSettings
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

public class F_MarbleContourAdvancedSettings : Form
{
  public buSpin spn_toollen3;
  public buSpin spn_toolspeed2;
  public buSpin spn_tooldia2;
  public buSpin spn_toollen2;
  public buSpin spn_toolspeed1;
  public buSpin spn_tooldia1;
  public buSpin spn_toollen1;
  public buButton btn_toolacitve6;
  public buButton btn_toolacitve5;
  public buButton btn_toolacitve4;
  public buButton btn_toolacitve3;

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleHorVerCut) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleHorVerCut) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleHorVerCut) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_MarbleVerticalCut) this).chk_rotate180minus.Name)
    {
      ((F_MarbleVerticalCut) this).chk_rotate180plus.Check = false;
      ((F_MarbleVerticalCut) this).chk_rotate90minus.Check = false;
      ((F_MarbleVerticalCut) this).chk_rotate90plus.Check = false;
    }
    if (control.Name == ((F_MarbleVerticalCut) this).chk_rotate180plus.Name)
    {
      ((F_MarbleVerticalCut) this).chk_rotate180minus.Check = false;
      ((F_MarbleVerticalCut) this).chk_rotate90minus.Check = false;
      ((F_MarbleVerticalCut) this).chk_rotate90plus.Check = false;
    }
    if (control.Name == ((F_MarbleVerticalCut) this).chk_rotate90minus.Name)
    {
      ((F_MarbleVerticalCut) this).chk_rotate180minus.Check = false;
      ((F_MarbleVerticalCut) this).chk_rotate180plus.Check = false;
      ((F_MarbleVerticalCut) this).chk_rotate90plus.Check = false;
    }
    if (!(control.Name == ((F_MarbleVerticalCut) this).chk_rotate90plus.Name))
      return;
    ((F_MarbleVerticalCut) this).chk_rotate180minus.Check = false;
    ((F_MarbleVerticalCut) this).chk_rotate180plus.Check = false;
    ((F_MarbleVerticalCut) this).chk_rotate90minus.Check = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleHorVerCut) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleHorVerCut) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleContourAdvancedSettings() => F_MarbleHorVerCut.Captions = new List<string>();

  public F_MarbleContourAdvancedSettings()
  {
    ((F_MarbleVerticalCut) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleCutting) this);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleVerticalCut) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleVerticalCut) this).\u0001.Dispose();
    base.Dispose(disposing);
  }
}
