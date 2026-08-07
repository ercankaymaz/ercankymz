// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Profile.F_ProfileArrayCircular
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Apps.Marble;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Profile;

public class F_ProfileArrayCircular : Form
{
  internal CheckBox \u0001;
  internal Label \u0013;
  internal CheckBox \u0002;
  internal Label \u0014;
  internal CheckBox \u0003;
  internal Label \u0015;
  internal RadioButton \u0003;
  internal RadioButton \u0004;
  internal Panel \u0003;
  internal Panel \u0004;
  internal RadioButton \u0005;
  internal Label \u0016;
  internal RadioButton \u0006;
  internal RadioButton \u0007;
  internal PictureBox \u0006;
  internal Panel \u0005;
  internal RadioButton \u0008;
  internal Label \u0017;
  internal RadioButton \u000E;
  internal RadioButton \u000F;

  public F_ProfileArrayCircular()
  {
    ((F_Settnigs) this).Properties = new FormProperties();
    ((F_Settnigs) this).varSettings = (ProfileSettings) new MarbleEntitiesSettings();
    ((F_Settnigs) this).\u0001 = new List<cParameter5>();
    ((F_Settnigs) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_Settnigs) this);
  }

  public void Init()
  {
    ((F_Settnigs) this).Properties.Inited = false;
    if (((F_Settnigs) this).Properties.Height > 10)
      this.Height = ((F_Settnigs) this).Properties.Height;
    if (((F_Settnigs) this).Properties.Width > 10)
      this.Width = ((F_Settnigs) this).Properties.Width;
    this.TopMost = ((F_Settnigs) this).Properties.TopMost;
    this.StartPosition = ((F_Settnigs) this).Properties.FormPosition;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_Settnigs) this);
    ((F_Settnigs) this).Properties.Result = DialogResult.None;
    ((F_Settnigs) this).Properties.Inited = true;
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "ToolDetailed LoadLanguage";
    try
    {
      if (F_Settnigs.Captions.Count >= 1)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_Settnigs) this).btn_ok.Name)
    {
      if (!((F_Settnigs) this).Properties.Inited)
        return;
      if (((F_Settnigs) this).Properties.ReadOnly)
      {
        this.Dispose();
        return;
      }
      \u0007.\u0001.\u0001((F_Settnigs) this);
      ((F_Settnigs) this).Properties.Result = DialogResult.OK;
      if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_Settnigs) this).btn_cancel.Name))
      return;
    ((F_Settnigs) this).Properties.Result = DialogResult.Cancel;
    if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_Settnigs) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_Settnigs) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_Settnigs) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ProfileArrayCircular() => F_Settnigs.Captions = new List<string>();

  public F_ProfileArrayCircular()
  {
    ((F_CamSettings) this).varProfileClamperSettings = (ProfileClamperSettings) new MarbleItemExtend();
    ((F_CamSettings) this).Properties = new FormProperties();
    ((F_CamSettings) this).strPath = Application.StartupPath;
    ((F_CamSettings) this).\u0001 = 0;
    ((F_CamSettings) this).Lengths = new List<ProfileLengthClamperCount>();
    ((F_CamSettings) this).Clampers = new List<ProfileClamper>();
    ((F_Clampers) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_ClamperProfileLength) this);
  }
}
