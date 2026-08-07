// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Password.F_PasswordV1
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms.Profile;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Password;

public class F_PasswordV1 : Form
{
  internal Label \u0007;
  internal Panel \u0008;
  internal NumericUpDown \u0008;
  internal Label \u0008;
  internal CheckBox \u0001;
  internal ImageList \u0002;
  internal CheckBox \u0002;
  internal Panel \u000E;
  internal Label \u000E;
  internal Label \u000F;
  public ComboBox cmb_length;
  public TextBox txt_name;
  internal Panel \u000F;
  internal Label \u0010;
  internal Label \u0011;
  internal Label \u0012;
  internal Label \u0013;
  internal Label \u0014;
  internal Label \u0015;

  public void LoadLangueage()
  {
    string callMethod = "ToolDetailed LoadLanguage";
    try
    {
      if (F_NewProfile.Captions.Count >= 1)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_NewProfile) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_NewProfile) this).Properties.Result = DialogResult.Cancel;
    if (((F_NewProfile) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_NewProfile) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_NewProfile) this).btn_ok.Name)
    {
      if (!((F_NewProfile) this).Properties.Inited)
        return;
      if (((F_NewProfile) this).Properties.ReadOnly)
      {
        this.Dispose();
        return;
      }
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ProfilePriority) this);
      ((F_NewProfile) this).Properties.Result = DialogResult.OK;
      if (((F_NewProfile) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_NewProfile) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_NewProfile) this).btn_cancel.Name))
      return;
    ((F_NewProfile) this).Properties.Result = DialogResult.Cancel;
    if (((F_NewProfile) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_NewProfile) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_NewProfile) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_NewProfile) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_PasswordV1() => F_NewProfile.Captions = new List<string>();

  public F_PasswordV1()
  {
    ((F_NewProfile) this).Properties = new FormProperties();
    ((F_NewProfile) this).RuntimeVar = (ProfileRuntimeSettings) new MarbleScreenCaptureSettings();
    ((F_NewProfile) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ProfileTemplate) this);
  }

  public void Init()
  {
    ((F_NewProfile) this).Properties.Inited = false;
    if (((F_NewProfile) this).Properties.Height > 10)
      this.Height = ((F_NewProfile) this).Properties.Height;
    if (((F_NewProfile) this).Properties.Width > 10)
      this.Width = ((F_NewProfile) this).Properties.Width;
    this.TopMost = ((F_NewProfile) this).Properties.TopMost;
    this.StartPosition = ((F_NewProfile) this).Properties.FormPosition;
    ((F_NewProfile) this).spn_startoffset.Value = (Decimal) ((MarbleTempVars) ((F_NewProfile) this).RuntimeVar).TemplateOffset;
    ((F_NewProfile) this).\u0001.Checked = ((MarbleTempVars) ((F_NewProfile) this).RuntimeVar).TemplateScaleXEnable;
    ((F_NewProfile) this).\u0002.Checked = ((MarbleTempVars) ((F_NewProfile) this).RuntimeVar).TemplateScaleYZEnable;
    ((F_NewProfile) this).Properties.Result = DialogResult.None;
    ((F_NewProfile) this).Properties.Inited = true;
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "ToolDetailed LoadLanguage";
    try
    {
      if (F_NewProfile.Captions.Count >= 1)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_NewProfile) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_NewProfile) this).Properties.Result = DialogResult.Cancel;
    if (((F_NewProfile) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_NewProfile) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_NewProfile) this).btn_ok.Name)
    {
      if (!((F_NewProfile) this).Properties.Inited)
        return;
      if (((F_NewProfile) this).Properties.ReadOnly)
      {
        this.Dispose();
        return;
      }
      \u0007.\u0001.\u0001((F_ProfileTemplate) this);
      ((F_NewProfile) this).Properties.Result = DialogResult.OK;
      if (((F_NewProfile) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_NewProfile) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_NewProfile) this).btn_cancel.Name))
      return;
    ((F_NewProfile) this).Properties.Result = DialogResult.Cancel;
    if (((F_NewProfile) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_NewProfile) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
