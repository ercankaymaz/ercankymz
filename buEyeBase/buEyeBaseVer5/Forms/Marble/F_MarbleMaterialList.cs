// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleMaterialList
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

public class F_MarbleMaterialList : Form
{
  public buButton btn_60;
  public buButton btn_45;
  public buButton btn_30;
  public buButton btn_10;
  public buButton btn_5;
  public buButton btn_2;
  public buButton btn_1;
  public buButton btn_01;
  public buButton btn_eventRotateminus;
  public buButton btn_eventrotateplus;
  public buSpin spn_eventrotatevalue;
  public static byte f001D37;
  private string \u0001;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buGround ground_base;
  public buButton btn_close;
  public buSpin spn_eventmovevalue;
  public buButton btn_eventmoveright;
  public buButton btn_eventmovedown;
  public buButton btn_eventmoveup;
  public buButton btn_eventmoveleft;
  public buButton btn_250;
  public buButton btn_100;
  public buButton btn_50;
  public buButton btn_20;
  public buButton btn_10;
  public buButton btn_5;
  public buButton btn_2;
  public buButton btn_1;
  public buButton btn_01;
  public static byte f001D4E;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public marbleEdgeItem Edge;
  private IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public Panel pnl_base;
  public buSpin spn_slatstartangle;
  public buButton btn_okVer;
  public buSpin spn_topchamferstartheight;
  public buSpin spn_topchamferstartangle;
  public buSpin spn_slatwidth;
  public buButton btn_cancel;
  public buCheckBox chk_topchamferstartenable;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleEasyDraw) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleEasyDraw) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleMaterialList() => F_MarbleEasyDraw.Captions = new List<string>();

  public F_MarbleMaterialList()
  {
    ((F_MarbleEasyDraw) this).\u0001 = "F_MarbleEventArray";
    ((F_MarbleEasyDraw) this).PropertiesForm = new FormProperties();
    ((F_MarbleEasyDraw) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleEventArray) this);
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
    string str = nameof (Init);
    try
    {
      ((F_MarbleEasyDraw) this).PropertiesForm.Inited = false;
      if (!((F_MarbleEasyDraw) this).PropertiesForm.Updated)
        ((F_MarbleEasyDraw) this).PropertiesForm.Updated = true;
      if (((F_MarbleEasyDraw) this).PropertiesForm.Height > 10)
        this.Height = ((F_MarbleEasyDraw) this).PropertiesForm.Height;
      if (((F_MarbleEasyDraw) this).PropertiesForm.Width > 10)
        this.Width = ((F_MarbleEasyDraw) this).PropertiesForm.Width;
      this.TopMost = ((F_MarbleEasyDraw) this).PropertiesForm.TopMost;
      this.StartPosition = ((F_MarbleEasyDraw) this).PropertiesForm.FormPosition;
      this.LoadLanguage();
      ((F_MarbleEasyDraw) this).spn_xcount.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ArrayXCount;
      ((F_MarbleEasyDraw) this).spn_xdistance.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ArrayXDistance;
      ((F_MarbleEasyDraw) this).spn_ycount.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ArrayYCount;
      ((F_MarbleEasyDraw) this).spn_ydistance.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ArrayYDistance;
      ((F_MarbleEasyDraw) this).PropertiesForm.Result = DialogResult.None;
      ((F_MarbleEasyDraw) this).PropertiesForm.Inited = true;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleEasyDraw) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void LoadLanguage()
  {
    string str = nameof (LoadLanguage);
    try
    {
      ((F_MarbleEasyDraw) this).ground_base.Text = $"{buLangTranslate.preDef.Linear} {buLangTranslate.preDef.Copy}";
      ((F_MarbleEasyDraw) this).spn_xcount.Caption.Caption = $"{buLangTranslate.preChar.X} {buLangTranslate.preDef.Count}";
      ((F_MarbleEasyDraw) this).spn_xdistance.Caption.Caption = $"{buLangTranslate.preChar.X} {buLangTranslate.preDef.Distance}";
      ((F_MarbleEasyDraw) this).spn_ycount.Caption.Caption = $"{buLangTranslate.preChar.Y} {buLangTranslate.preDef.Count}";
      ((F_MarbleEasyDraw) this).spn_ydistance.Caption.Caption = $"{buLangTranslate.preChar.Y} {buLangTranslate.preDef.Distance}";
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
    string str = nameof (Apply);
    try
    {
      ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ArrayXCount = ((F_MarbleEasyDraw) this).spn_xcount.Value;
      ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ArrayXDistance = ((F_MarbleEasyDraw) this).spn_xdistance.Value;
      ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ArrayYCount = ((F_MarbleEasyDraw) this).spn_ycount.Value;
      ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ArrayYDistance = ((F_MarbleEasyDraw) this).spn_ydistance.Value;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleEasyDraw) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
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
      this.\u0001((object) ((F_MarbleEasyDraw) this).btn_cancel, obj1);
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

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleEasyDraw) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleEasyDraw) this).\u0001.Dispose();
    base.Dispose(disposing);
  }
}
