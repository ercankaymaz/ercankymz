// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleCountertopEdge
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleCountertopEdge : Form
{
  public buSpin spn_baseheight;
  internal Panel \u0001;
  public FormProperties Properties;
  public static List<string> Captions;
  public MarbleRuntimeSettings varRuntime;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buButton \u0001;
  public buSpin spn_length;
  public FormProperties Properties;
  public static List<string> Captions;
  public MarbleRuntimeSettings varRuntime;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buButton \u0001;
  public buSpin spn_baseheight;
  private string \u0001;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  private IContainer \u0001;
  public buGround ground_base;
  public buButton btn_close;
  public buSpin spn_breakdistance;
  public buButton btn_ok;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleCountertopSlat) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleCountertopSlat) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleCountertopEdge() => F_MarbleCountertopSlat.Captions = new List<string>();

  public F_MarbleCountertopEdge()
  {
    ((F_MarbleCountertopSlat) this).\u0001 = "F_MarbleEventExtend";
    ((F_MarbleCountertopSlat) this).PropertiesForm = new FormProperties();
    ((F_MarbleCountertopSlat) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleEventExtend) this);
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
      buLogVer5.addToLog(((F_MarbleCountertopSlat) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void Init()
  {
    string str = nameof (Init);
    try
    {
      ((F_MarbleCountertopSlat) this).PropertiesForm.Inited = false;
      if (!((F_MarbleCountertopSlat) this).PropertiesForm.Updated)
        ((F_MarbleCountertopSlat) this).PropertiesForm.Updated = true;
      if (((F_MarbleCountertopSlat) this).PropertiesForm.Height > 10)
        this.Height = ((F_MarbleCountertopSlat) this).PropertiesForm.Height;
      if (((F_MarbleCountertopSlat) this).PropertiesForm.Width > 10)
        this.Width = ((F_MarbleCountertopSlat) this).PropertiesForm.Width;
      this.TopMost = ((F_MarbleCountertopSlat) this).PropertiesForm.TopMost;
      this.StartPosition = ((F_MarbleCountertopSlat) this).PropertiesForm.FormPosition;
      this.LoadLanguage();
      ((F_MarbleCountertopSlat) this).spn_extend.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ExtendLength;
      ((F_MarbleCountertopSlat) this).PropertiesForm.Result = DialogResult.None;
      ((F_MarbleCountertopSlat) this).PropertiesForm.Inited = true;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleCountertopSlat) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void LoadLanguage()
  {
    string str = nameof (LoadLanguage);
    try
    {
      ((F_MarbleCountertopSlat) this).ground_base.Text = buLangTranslate.preDef.Extend;
      ((F_MarbleCountertopSlat) this).spn_extend.Caption.Caption = buLangTranslate.preDef.Length;
      ((F_MarbleCountertopSlat) this).btn_ok.Text = buLangTranslate.preDef.Ok;
      ((F_MarbleCountertopSlat) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleCountertopSlat) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    string str = "F_FormClosing";
    try
    {
      if (((F_MarbleCountertopSlat) this).PropertiesForm.Result == DialogResult.OK)
        return;
      obj1.Cancel = true;
      ((F_MarbleCountertopSlat) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_MarbleCountertopSlat) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleCountertopSlat) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleCountertopSlat) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void Apply()
  {
    string str = nameof (Apply);
    try
    {
      ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ExtendLength = ((F_MarbleCountertopSlat) this).spn_extend.Value;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleCountertopSlat) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    string str = "btn_Click";
    try
    {
      Control control = obj0 as Control;
      if (control.Name == ((F_MarbleCountertopSlat) this).btn_cancel.Name | control.Name == ((F_MarbleCountertopSlat) this).btn_close.Name)
      {
        ((F_MarbleCountertopSlat) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((F_MarbleCountertopSlat) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleCountertopSlat) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control.Name == ((F_MarbleCountertopSlat) this).btn_ok.Name))
        return;
      this.Apply();
      ((F_MarbleCountertopSlat) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_MarbleCountertopSlat) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleCountertopSlat) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleCountertopSlat) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
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
      buLogVer5.addToLog(((F_MarbleCountertopSlat) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }
}
