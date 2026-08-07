// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Profile.F_ProfileFreeDrawCmd
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms.Sewing;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Profile;

public class F_ProfileFreeDrawCmd : Form
{
  public bool ShowCamSettings;
  public bool ShowTool;
  public bool ShowObjectPosition;
  public bool ShowCornerLocation;
  public bool EnableLeftPlane;
  public bool EnableRightPlane;
  public bool EnableFrontPlane;
  public bool EnableBackPlane;
  public bool EnableFreePlane;
  public bool ClosePageAfterOk;
  public List<ToolBase5> Tools;
  public ToolBase5 activeTool;
  public ShapeRuntimeData parShape;

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
      \u0007.\u0001.\u0001((F_SewingPunteriz) this);
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

  static F_ProfileFreeDrawCmd() => F_Settnigs.Captions = new List<string>();

  public F_ProfileFreeDrawCmd()
  {
    ((F_Settnigs) this).Properties = new FormProperties();
    ((F_Settnigs) this).StitchLength = 3.0;
    ((F_Settnigs) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_SewingStitchLen) this);
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
    ((F_Settnigs) this).\u0001.Value = (Decimal) ((F_Settnigs) this).StitchLength;
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

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_Settnigs) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_Settnigs) this).Properties.Result = DialogResult.Cancel;
    if (((F_Settnigs) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_Settnigs) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
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
      \u0007.\u0001.\u0001((F_SewingStitchLen) this);
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

  public event OkCommandWithDataEventHandler CommandOk;
}
