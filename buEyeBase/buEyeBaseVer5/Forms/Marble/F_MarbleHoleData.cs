// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleHoleData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleHoleData : Form
{
  public buSpin spn_width;
  public buButton btn_ok;
  public buButton btn_cancel;
  public buSpin spn_offset;
  public buCheckBox chk_addangletoselectededge;
  public static byte f001D22;
  private string \u0001;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buGround ground_base;
  public buButton btn_close;
  public buButton btn_90;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleEasyDraw) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleEasyDraw) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleHoleData() => F_MarbleEasyDraw.Captions = new List<string>();

  public F_MarbleHoleData()
  {
    ((F_MarbleEasyDraw) this).\u0001 = "F_MarbleEventCopy";
    ((F_MarbleEasyDraw) this).PropertiesForm = new FormProperties();
    ((F_MarbleEasyDraw) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleEventCopy) this);
  }

  public void UpdateVisuals()
  {
    string str = nameof (UpdateVisuals);
    try
    {
      if (clsVisualVars.parVisual == null)
        return;
      this.LoadLanguage();
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleEasyDraw) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void Init()
  {
    // ISSUE: unable to decompile the method.
  }

  public void LoadLanguage()
  {
    string str = nameof (LoadLanguage);
    try
    {
      ((F_MarbleEasyDraw) this).ground_base.Text = $"{buLangTranslate.preDef.Linear} {buLangTranslate.preDef.Copy}";
      ((F_MarbleEasyDraw) this).spn_xdistance.Caption.Caption = $"{buLangTranslate.preChar.X} {buLangTranslate.preDef.Distance}";
      ((F_MarbleEasyDraw) this).spn_ydistance.Caption.Caption = $"{buLangTranslate.preChar.Y} {buLangTranslate.preDef.Distance}";
      ((F_MarbleEasyDraw) this).\u0003.Text = $"{buLangTranslate.preChar.X} {buLangTranslate.preDef.Direction}";
      ((F_MarbleEasyDraw) this).\u0002.Text = $"{buLangTranslate.preChar.Y} {buLangTranslate.preDef.Direction}";
      ((F_MarbleEasyDraw) this).\u0001.Text = $"{buLangTranslate.preChar.X}{buLangTranslate.preChar.Y} {buLangTranslate.preDef.Direction}";
      ((F_MarbleEasyDraw) this).btn_ok.Text = buLangTranslate.preDef.Ok;
      ((F_MarbleEasyDraw) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleEasyDraw) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    string str = "F_FormClosing";
    try
    {
      if (((F_MarbleEasyDraw) this).PropertiesForm.Result == DialogResult.OK)
        return;
      obj1.Cancel = true;
      ((F_MarbleEasyDraw) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_MarbleEasyDraw) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleEasyDraw) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleEasyDraw) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void Apply()
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    string str = "btn_Click";
    try
    {
      Control control = obj0 as Control;
      if (control.Name == ((F_MarbleEasyDraw) this).btn_cancel.Name | control.Name == ((F_MarbleEasyDraw) this).btn_close.Name)
      {
        ((F_MarbleEasyDraw) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((F_MarbleEasyDraw) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleEasyDraw) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control.Name == ((F_MarbleEasyDraw) this).btn_ok.Name))
        return;
      this.Apply();
      ((F_MarbleEasyDraw) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_MarbleEasyDraw) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleEasyDraw) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleEasyDraw) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    string str = "spn_Click";
    try
    {
      buSpin buSpin = obj0 as buSpin;
      if (!AppBool.TouchPad)
        return;
      F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
      fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
      fKeyPadNumV1.Caption = buSpin.Caption.Caption;
      fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
      if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
        return;
      buSpin.Value = double.Parse(fKeyPadNumV1.Value);
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleEasyDraw) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }
}
