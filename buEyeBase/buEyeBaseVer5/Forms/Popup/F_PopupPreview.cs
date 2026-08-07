// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Popup.F_PopupPreview
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms.Password;
using buEyeBaseVer5.Forms.Profile;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Popup;

public class F_PopupPreview : Form
{
  internal NumericUpDown \u0001;
  internal Panel \u0001;
  internal Panel \u0002;
  internal NumericUpDown \u0002;
  internal Label \u0002;
  internal Panel \u0003;
  internal NumericUpDown \u0003;
  internal Label \u0003;
  internal Panel \u0004;
  internal NumericUpDown \u0004;
  internal Label \u0004;
  internal Panel \u0005;
  internal NumericUpDown \u0005;
  internal Label \u0005;
  internal Panel \u0006;
  internal NumericUpDown \u0006;
  internal Label \u0006;
  internal Panel \u0007;
  internal NumericUpDown \u0007;

  public F_PopupPreview()
  {
    ((F_NewProfile) this).Properties = new FormProperties();
    ((F_NewProfile) this).ClamperSet = 1;
    ((F_NewProfile) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ProfileClamperSet) this);
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
    ((F_NewProfile) this).spn_priority.Value = (Decimal) ((F_NewProfile) this).ClamperSet;
    ((F_NewProfile) this).spn_priority.Select(0, 100);
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
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ProfileClamperSet) this);
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

  static F_PopupPreview() => F_NewProfile.Captions = new List<string>();

  public F_PopupPreview()
  {
    ((F_NewProfile) this).Properties = new FormProperties();
    ((F_NewProfile) this).Priority = 0;
    ((F_NewProfile) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_ProfilePriority) this);
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
    ((F_NewProfile) this).spn_priority.Value = (Decimal) ((F_NewProfile) this).Priority;
    ((F_NewProfile) this).spn_priority.Select(0, 100);
    ((F_NewProfile) this).Properties.Result = DialogResult.None;
    ((F_NewProfile) this).Properties.Inited = true;
    ((F_PasswordV1) this).LoadLangueage();
  }
}
