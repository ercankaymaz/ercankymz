// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleVacuum
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

public class F_MarbleVacuum : Form
{
  public buButton btn_move_rightdown;
  public buButton btn_move_down;
  public buButton btn_move_leftup;
  public buButton btn_move_leftdown;
  public buButton btn_move_rightup;
  internal TabPage \u0003;
  public buButton btn_side_right;
  public buButton btn_side_left;
  public buButton btn_side_up;
  public buButton btn_side_down;
  public buButton btn_side_centerver;
  public buButton btn_side_centerhor;
  public buSpin spn_moveval;
  public buSpin spn_sideoffset;
  public static byte f001CB4;
  private string \u0001;
  public static List<string> Captions = new List<string>();
  public FormProperties PropertiesForm;
  public MarbleRuntimeSettings RuntimeSettings;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buGround ground_base;
  public buButton btn_close;
  public buSpin spn_collapseoffset;
  public buSpin spn_collapsedepth;
  public buButton btn_ok;
  public buButton btn_cancel;
  public buCheckBox chk_collapseenable;
  public buCheckBox chk_collapseoutside;
  public buCheckBox chk_collapseinside;
  internal buCheckBox \u0001;
  internal buCheckBox \u0002;
  public buLabel lbl_Tool;
  public static byte f001CC8;
  private string \u0001 = "F_MarbleEventScale";
  public static List<string> Captions;
  public FormProperties PropertiesForm = new FormProperties();
  private IContainer \u0001 = (IContainer) null;
  public buGround ground_base;

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
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

  public void Apply()
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control = obj0 as Control;
      if (control.Name == this.btn_ok.Name)
      {
        this.Apply();
        this.PropertiesForm.Result = DialogResult.OK;
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control.Name == this.btn_cancel.Name | control.Name == this.btn_close.Name)
      {
        this.PropertiesForm.Result = DialogResult.Cancel;
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control.Name == this.\u0001.Name)
      {
        this.\u0001.Check = true;
        this.\u0002.Check = false;
      }
      if (control.Name == this.\u0002.Name)
      {
        this.\u0001.Check = false;
        this.\u0002.Check = true;
      }
      if (control.Name == this.chk_collapseoutside.Name)
      {
        this.chk_collapseoutside.Check = true;
        this.chk_collapseinside.Check = false;
      }
      if (!(control.Name == this.chk_collapseinside.Name))
        return;
      this.chk_collapseoutside.Check = false;
      this.chk_collapseinside.Check = true;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
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

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.\u0001 != null ? 1 : 0)) != 0)
      this.\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MarbleVacuum()
  {
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleEventScale) this);
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
      ((F_MarbleEasyDraw) this).spn_width.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ScaleWidth;
      ((F_MarbleEasyDraw) this).spn_height.Value = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ScaleHeight;
      ((F_MarbleEasyDraw) this).chk_keepratio.Check = ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ScaleKeepRatio;
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
      this.ground_base.Text = buLangTranslate.preDef.Scale;
      ((F_MarbleEasyDraw) this).chk_keepratio.Text = buLangTranslate.preDef.KeepRatio;
      ((F_MarbleEasyDraw) this).spn_width.Caption.Caption = buLangTranslate.preDef.Width;
      ((F_MarbleEasyDraw) this).spn_height.Caption.Caption = buLangTranslate.preDef.Height;
      ((F_MarbleEasyDraw) this).btn_ok.Text = buLangTranslate.preDef.Ok;
      ((F_MarbleEasyDraw) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
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
      ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ScaleKeepRatio = ((F_MarbleEasyDraw) this).chk_keepratio.Check;
      ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ScaleWidth = ((F_MarbleEasyDraw) this).spn_width.Value;
      ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).ScaleHeight = ((F_MarbleEasyDraw) this).spn_height.Value;
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
      if (control.Name == ((F_MarbleEasyDraw) this).btn_cancel.Name | control.Name == ((F_MarbleEasyDraw) this).btn_close.Name)
      {
        this.PropertiesForm.Result = DialogResult.Cancel;
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control.Name == ((F_MarbleEasyDraw) this).btn_ok.Name))
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
}
