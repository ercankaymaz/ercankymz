// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleEasyDraw
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

public class F_MarbleEasyDraw : Form
{
  public buButton btn_close;
  public buSpin spn_width;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buLabel \u0001;
  internal buLabel \u0002;
  public buCheckBox chk_keepratio;
  public buSpin spn_height;
  internal buLabel \u0003;
  public static byte f001CD7;
  private string \u0001 = "F_MarbleEventMirror";
  public static List<string> Captions = new List<string>();
  public FormProperties PropertiesForm = new FormProperties();
  private IContainer \u0001 = (IContainer) null;
  public buGround ground_base;
  public buButton btn_close;
  public buSpin spn_distance;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal buLabel \u0001;
  internal buLabel \u0002;
  public buCheckBox chk_deleteoriginale;
  public static byte f001CE6;
  private string \u0001;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  private IContainer \u0001;
  public buGround ground_base;
  public buButton btn_close;
  public buSpin spn_xdistance;
  public buSpin spn_ydistance;
  public buButton btn_ok;
  public buButton btn_cancel;
  public buSpin spn_ycount;
  public buSpin spn_xcount;
  public static byte f001CF3;
  private string \u0001;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  private IContainer \u0001;
  public buGround ground_base;
  public buButton btn_close;
  public buSpin spn_xdistance;
  public buSpin spn_ydistance;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  internal buLabel \u0001;
  internal buLabel \u0002;
  internal buLabel \u0003;
  public static byte f001D04;
  private string \u0001;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  private IContainer \u0001;
  public buGround ground_base;
  public buButton btn_close;
  public buSpin spn_xcount;
  public buSpin spn_xdistance;
  public buSpin spn_ydistance;
  public buSpin spn_ycount;
  public buButton btn_ok;
  public buButton btn_cancel;
  public static byte f001D11;
  private string \u0001;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public MarbleRuntimeSettings RuntimeSettings;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buGround ground_base;
  public buButton btn_close;
  public buSpin spn_EA;
  public buSpin spn_SA;

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
      buLogVer5.addToLog(((F_MarbleVacuum) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleVacuum) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleVacuum) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleEasyDraw() => F_MarbleVacuum.Captions = new List<string>();

  public F_MarbleEasyDraw() => \u0007.\u0001.\u0001((F_MarbleEventMirror) this);

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
      buLogVer5.addToLog(this.\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void Init()
  {
    string str = nameof (Init);
    try
    {
      this.PropertiesForm.Inited = false;
      if (!this.PropertiesForm.Updated)
        this.PropertiesForm.Updated = true;
      if (this.PropertiesForm.Height > 10)
        this.Height = this.PropertiesForm.Height;
      if (this.PropertiesForm.Width > 10)
        this.Width = this.PropertiesForm.Width;
      this.TopMost = this.PropertiesForm.TopMost;
      this.StartPosition = this.PropertiesForm.FormPosition;
      this.LoadLanguage();
      this.spn_distance.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).MirrorDistance;
      if (((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).MirrorType == MirrorAxisXYType.X)
        this.\u0002.Checked = true;
      else
        this.\u0001.Checked = true;
      this.chk_deleteoriginale.Check = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).MirrorDeleteOriginale;
      this.PropertiesForm.Result = DialogResult.None;
      this.PropertiesForm.Inited = true;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(this.\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void LoadLanguage()
  {
    string str = nameof (LoadLanguage);
    try
    {
      this.ground_base.Text = buLangTranslate.preDef.Mirror;
      this.chk_deleteoriginale.Text = $"{buLangTranslate.preDef.Originale} {buLangTranslate.preDef.Delete}";
      this.spn_distance.Caption.Caption = buLangTranslate.preDef.Distance;
      this.\u0002.Text = $"{buLangTranslate.preChar.X} {buLangTranslate.preDef.Direction}";
      this.\u0001.Text = $"{buLangTranslate.preChar.Y} {buLangTranslate.preDef.Direction}";
      this.btn_ok.Text = buLangTranslate.preDef.Ok;
      this.btn_cancel.Text = buLangTranslate.preDef.Cancel;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(this.\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    string str = "F_FormClosing";
    try
    {
      if (this.PropertiesForm.Result == DialogResult.OK)
        return;
      obj1.Cancel = true;
      this.PropertiesForm.Result = DialogResult.Cancel;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(this.\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void Apply()
  {
    string str = nameof (Apply);
    try
    {
      ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).MirrorDeleteOriginale = this.chk_deleteoriginale.Check;
      ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).MirrorDistance = this.spn_distance.Value;
      if (this.\u0002.Checked)
        ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).MirrorType = MirrorAxisXYType.X;
      else
        ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).MirrorType = MirrorAxisXYType.Y;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(this.\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    string str = "btn_Click";
    try
    {
      Control control = obj0 as Control;
      if (control.Name == this.btn_cancel.Name | control.Name == this.btn_close.Name)
      {
        this.PropertiesForm.Result = DialogResult.Cancel;
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control.Name == this.btn_ok.Name))
        return;
      this.Apply();
      this.PropertiesForm.Result = DialogResult.OK;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(this.\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
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
      buLogVer5.addToLog(this.\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.\u0001 != null ? 1 : 0)) != 0)
      this.\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleEasyDraw()
  {
  }

  public F_MarbleEasyDraw()
  {
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleEventCopyMulti) this);
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
      buLogVer5.addToLog(this.\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void Init()
  {
    string str = nameof (Init);
    try
    {
      this.PropertiesForm.Inited = false;
      if (!this.PropertiesForm.Updated)
        this.PropertiesForm.Updated = true;
      if (this.PropertiesForm.Height > 10)
        this.Height = this.PropertiesForm.Height;
      if (this.PropertiesForm.Width > 10)
        this.Width = this.PropertiesForm.Width;
      this.TopMost = this.PropertiesForm.TopMost;
      this.StartPosition = this.PropertiesForm.FormPosition;
      this.LoadLanguage();
      this.spn_xdistance.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).CopyXDistance;
      this.spn_ydistance.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).CopyYDistance;
      this.spn_xcount.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).CopyXCount;
      this.spn_ycount.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).CopyYCount;
      this.PropertiesForm.Result = DialogResult.None;
      this.PropertiesForm.Inited = true;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(this.\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void LoadLanguage()
  {
    string str = nameof (LoadLanguage);
    try
    {
      this.ground_base.Text = $"{buLangTranslate.preDef.Linear} {buLangTranslate.preDef.Copy}";
      this.spn_xdistance.Caption.Caption = $"{buLangTranslate.preChar.X} {buLangTranslate.preDef.Distance}";
      this.spn_ydistance.Caption.Caption = $"{buLangTranslate.preChar.Y} {buLangTranslate.preDef.Distance}";
      this.spn_xcount.Caption.Caption = $"{buLangTranslate.preChar.X} {buLangTranslate.preDef.Count}";
      this.spn_ycount.Caption.Caption = $"{buLangTranslate.preChar.Y} {buLangTranslate.preDef.Count}";
      this.btn_ok.Text = buLangTranslate.preDef.Ok;
      this.btn_cancel.Text = buLangTranslate.preDef.Cancel;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(this.\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    string str = "F_FormClosing";
    try
    {
      if (this.PropertiesForm.Result == DialogResult.OK)
        return;
      obj1.Cancel = true;
      this.PropertiesForm.Result = DialogResult.Cancel;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(this.\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void Apply()
  {
    string str = nameof (Apply);
    try
    {
      ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).CopyXDistance = this.spn_xdistance.Value;
      ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).CopyYDistance = this.spn_ydistance.Value;
      ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).CopyXCount = this.spn_xcount.Value;
      ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).CopyYCount = this.spn_ycount.Value;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(this.\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    string str = "btn_Click";
    try
    {
      Control control = obj0 as Control;
      if (control.Name == this.btn_cancel.Name | control.Name == this.btn_close.Name)
      {
        this.PropertiesForm.Result = DialogResult.Cancel;
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control.Name == this.btn_ok.Name))
        return;
      this.Apply();
      this.PropertiesForm.Result = DialogResult.OK;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(this.\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
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
      buLogVer5.addToLog(this.\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }
}
