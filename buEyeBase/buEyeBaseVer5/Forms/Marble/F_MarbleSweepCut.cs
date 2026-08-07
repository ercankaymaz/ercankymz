// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleSweepCut
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleSweepCut : Form
{
  public buCheckBox chk_rough;
  public buCheckBox chk_none;
  public static byte f0027BD;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public MarbleEngraveMenuType EngraveType;
  public MarbleItemType ItemType;
  public marbleMenuType MenuType;
  public Color clrLabel;
  public Color clrFormCaption;
  public Color clrFormBackUpper;
  public Color clrFormBackDown;
  public Color clrButtonDisplay;
  public Color clrButtonOver;
  public Color clrButtonDown;
  internal IContainer \u0001;
  public buButton btn_contourmenueditor;
  public buButton btn_contourmenufilelist;
  public buButton btn_contourmenufromfile;
  public buButton btn_close;

  public void Init()
  {
    // ISSUE: unable to decompile the method.
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleProfileMenu) this).chk_contour.Text = $"{buLangTranslate.preDef.Contour} {buLangTranslate.preDef.Strategy}";
      ((F_MarbleProfileMenu) this).buGround1.Text = $"{buLangTranslate.preDef.WaterJet} {buLangTranslate.preDef.Strategy}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleProfileMenu) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleProfileMenu) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleProfileMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleProfileMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleProfileMenu) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleProfileMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleProfileMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] bool obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleProfileMenu) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleProfileMenu) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleSweepCut() => F_MarbleProfileMenu.Captions = new List<string>();
}
