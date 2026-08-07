// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleEditBaseHAndXY
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

public class F_MarbleEditBaseHAndXY : Form
{
  public buGround buGround1;
  public buCheckBox chk_toolmillinghead;
  public static byte f0021E4;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public MarbleToolType ToolType;
  private IContainer \u0001;
  public buButton btn_close;
  public buCheckBox chk_toolmillinghead;
  public buCheckBox chk_toolmilling;
  public buGround buGround1;

  public F_MarbleEditBaseHAndXY()
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
      ((F_MarbleHoleTable) this).chk_toolmilling.Text = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Tool}";
      this.chk_toolmillinghead.Text = $"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Tool}";
      ((F_MarbleHoleTable) this).chk_toolsaw.Text = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Tool}";
      this.buGround1.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Menu}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleHoleTable) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleHoleTable) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleHoleTable) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleHoleTable) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleHoleTable) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleHoleTable) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleHoleTable) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] bool obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleHoleTable) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleHoleTable) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleEditBaseHAndXY() => F_MarbleHoleTable.Captions = new List<string>();

  public F_MarbleEditBaseHAndXY()
  {
    // ISSUE: unable to decompile the method.
  }
}
