// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Profile.F_PlaneMoveRotate
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms.Sewing;
using devDept.Eyeshot.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Profile;

public class F_PlaneMoveRotate : Form
{
  internal RadioButton \u0006;
  internal PictureBox \u0004;
  internal Label \u0008;
  internal PictureBox \u0005;
  internal Label \u000E;
  internal Label \u000F;
  public NumericUpDown spn_toolpersentage;
  internal Label \u0010;
  public NumericUpDown spn_spindlespeed;
  internal CheckBox \u0001;
  public static byte f0015CD;
  public FormProperties PropertiesForm;
  public Design viewportLayout;
  public static List<string> Captions;
  public bool ShowViewport;

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    if (control2.Name == ((F_Settnigs) this).btn_ok.Name)
    {
      if (!((F_Settnigs) this).Properties.Inited)
        return;
      if (((F_Settnigs) this).Properties.ReadOnly)
      {
        this.Dispose();
        return;
      }
      \u0007.\u0001.\u0001((F_SewingExtend) this);
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

  static F_PlaneMoveRotate() => F_Settnigs.Captions = new List<string>();

  public F_PlaneMoveRotate()
  {
    ((F_Settnigs) this).Properties = new FormProperties();
    ((F_Settnigs) this).PunterizWidth = 30.0;
    ((F_Settnigs) this).PunterizHeight = 3.0;
    ((F_Settnigs) this).PunterizLength = 2.0;
    ((F_Settnigs) this).PunterizType = SewingPunterizType.CenterLeft;
    ((F_Settnigs) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_SewingPunteriz) this);
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
    ((F_Settnigs) this).\u0001.Value = (Decimal) ((F_Settnigs) this).PunterizLength;
    ((F_Settnigs) this).\u0002.Value = (Decimal) ((F_Settnigs) this).PunterizWidth;
    ((F_Settnigs) this).\u0003.Value = (Decimal) ((F_Settnigs) this).PunterizHeight;
    if (((F_Settnigs) this).PunterizType == SewingPunterizType.CenterLeft)
      ((F_Settnigs) this).\u0001.Checked = true;
    else if (((F_Settnigs) this).PunterizType == SewingPunterizType.CenterRigth)
      ((F_Settnigs) this).\u0002.Checked = true;
    else if (((F_Settnigs) this).PunterizType == SewingPunterizType.MinLeft)
      ((F_Settnigs) this).\u0003.Checked = true;
    else if (((F_Settnigs) this).PunterizType == SewingPunterizType.MinRigth)
      ((F_Settnigs) this).\u0004.Checked = true;
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

  public event OkCommandWithTwoDataEventHandler DataChanged;
}
