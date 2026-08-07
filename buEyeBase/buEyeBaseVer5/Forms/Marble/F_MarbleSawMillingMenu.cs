// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleSawMillingMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleSawMillingMenu : Form
{
  public buSpin spn_MaxAllowedAngleA;
  public buSpin spn_AngleCLimit;
  public buSpin spn_AngleCMax;
  public buSpin spn_AngleCMin;
  internal buLabel \u008A;
  public buCheckBox chk_isFirstCutSafeDistance;
  public buSpin spn_RegenDeviatation;
  public buSpin spn_CutTolerance;
  public buCheckBox chk_ToolPathPointDistributionMode;
  public buCheckBox chk_MoveZCAAxesToSafeDistance;
  public buSpin spn_JobFinishZPostion;
  public buButton btn_advanced;
  public buButton btn_options;
  internal Panel \u000E;
  internal RadioButton \u001E;
  internal RadioButton \u001F;
  internal buLabel \u008B;
  internal RadioButton \u007F;
  public buButton btn_matload;
  internal Panel \u000F;
  internal RadioButton \u0080;
  internal RadioButton \u0081;
  internal buLabel \u008C;
  internal RadioButton \u0082;
  internal buLabel \u008D;
  public buSpin spn_sawleavespeed;
  internal buLabel \u008E;
  public buSpin spn_millingdrillleavespeed;
  internal buLabel \u008F;
  public buSpin spn_millingheaddrillleavespeed;
  public buButton btn_helpme;
  public buCheckBox chk_CutSameDirection;

  public void Init()
  {
    ((F_MarbleCamSettings) this).Properties.Inited = false;
    if (((F_MarbleCamSettings) this).Properties.Height > 10)
      this.Height = ((F_MarbleCamSettings) this).Properties.Height;
    if (((F_MarbleCamSettings) this).Properties.Width > 10)
      this.Width = ((F_MarbleCamSettings) this).Properties.Width;
    this.TopMost = ((F_MarbleCamSettings) this).Properties.TopMost;
    this.StartPosition = ((F_MarbleCamSettings) this).Properties.FormPosition;
    ((F_MarbleCamSettings) this).Properties.Result = DialogResult.None;
    ((F_MarbleCamSettings) this).Properties.Inited = true;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleSingleCut) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleCamSettings) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleCamSettings) this).Properties.Result = DialogResult.Cancel;
    if (((F_MarbleCamSettings) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleCamSettings) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleToolSpindleAndMagazine) this).btn_okVer.Name)
      {
        ((F_MarbleCamSettings) this).Properties.Result = DialogResult.OK;
        if (((F_MarbleCamSettings) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleCamSettings) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_MarbleToolSpindleAndMagazine) this).btn_close.Name))
        return;
      ((F_MarbleCamSettings) this).Properties.Result = DialogResult.Cancel;
      if (((F_MarbleCamSettings) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleCamSettings) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleCamSettings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleCamSettings) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleSawMillingMenu() => F_MarbleCamSettings.Captions = new List<string>();

  public F_MarbleSawMillingMenu()
  {
    ((F_MarbleToolSpindleAndMagazine) this).SpinBaseColor = Color.LightGreen;
    ((F_MarbleToolSpindleAndMagazine) this).SpinFocusColor = Color.MistyRose;
    ((F_MarbleToolSpindleAndMagazine) this).AngleValue = 0.0;
    ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm = new FormProperties();
    ((F_MarbleToolSpindleAndMagazine) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleMove) this);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandExecute(OkCommandWithThreeDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithThreeDataEventHandler dataEventHandler = ((F_MarbleToolSpindleAndMagazine) this).\u0001;
    OkCommandWithThreeDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithThreeDataEventHandler>(ref ((F_MarbleToolSpindleAndMagazine) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandExecute(OkCommandWithThreeDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithThreeDataEventHandler dataEventHandler = ((F_MarbleToolSpindleAndMagazine) this).\u0001;
    OkCommandWithThreeDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithThreeDataEventHandler>(ref ((F_MarbleToolSpindleAndMagazine) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init()
  {
    ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Inited = false;
    if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Height;
    if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.FormPosition;
    ((F_MarbleToolSpindleAndMagazine) this).spn_move.Value = ((F_MarbleToolSpindleAndMagazine) this).AngleValue;
    this.LoadLanguage();
    ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      this.Text = buLangTranslate.preDef.Move;
      ((F_MarbleToolSpindleAndMagazine) this).spn_move.Caption.Caption = buLangTranslate.preDef.Move;
      ((F_MarbleToolSpindleAndMagazine) this).spn_rotate.Caption.Caption = buLangTranslate.preDef.Rotate;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Result == DialogResult.OK)
      return;
    // ISSUE: reference to a compiler-generated field
    if (((F_MarbleToolSpindleAndMagazine) this).\u0001 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarbleToolSpindleAndMagazine) this).\u0001((object) "Close", (object) null, (object) null);
    }
    obj1.Cancel = true;
    ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
    ((F_MarbleToolSpindleAndMagazine) this).AngleValue = ((F_MarbleToolSpindleAndMagazine) this).spn_move.Value;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_MarbleToolSpindleAndMagazine) this).btn_ok.Name)
    {
      this.Apply();
      ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Result = DialogResult.OK;
      // ISSUE: reference to a compiler-generated field
      if (((F_MarbleToolSpindleAndMagazine) this).\u0001 != null)
      {
        // ISSUE: reference to a compiler-generated field
        ((F_MarbleToolSpindleAndMagazine) this).\u0001((object) "MoveOk", (object) null, (object) null);
      }
      if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control.Name == ((F_MarbleToolSpindleAndMagazine) this).btn_cancel.Name | control.Name == ((F_MarbleToolSpindleAndMagazine) this).btn_close.Name)
    {
      ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
      {
        this.Visible = false;
        // ISSUE: reference to a compiler-generated field
        if (((F_MarbleToolSpindleAndMagazine) this).\u0001 != null)
        {
          // ISSUE: reference to a compiler-generated field
          ((F_MarbleToolSpindleAndMagazine) this).\u0001((object) "Close", (object) null, (object) null);
        }
      }
    }
    // ISSUE: reference to a compiler-generated field
    if (control.Name == ((F_MarbleToolSpindleAndMagazine) this).btn_movedown.Name && ((F_MarbleToolSpindleAndMagazine) this).\u0001 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarbleToolSpindleAndMagazine) this).\u0001((object) "MoveY", (object) -((F_MarbleToolSpindleAndMagazine) this).spn_move.Value, (object) null);
    }
    // ISSUE: reference to a compiler-generated field
    if (control.Name == ((F_MarbleToolSpindleAndMagazine) this).btn_moveup.Name && ((F_MarbleToolSpindleAndMagazine) this).\u0001 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarbleToolSpindleAndMagazine) this).\u0001((object) "MoveY", (object) ((F_MarbleToolSpindleAndMagazine) this).spn_move.Value, (object) null);
    }
    // ISSUE: reference to a compiler-generated field
    if (control.Name == ((F_MarbleToolSpindleAndMagazine) this).btn_moveleft.Name && ((F_MarbleToolSpindleAndMagazine) this).\u0001 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarbleToolSpindleAndMagazine) this).\u0001((object) "MoveX", (object) -((F_MarbleToolSpindleAndMagazine) this).spn_move.Value, (object) null);
    }
    // ISSUE: reference to a compiler-generated field
    if (control.Name == ((F_MarbleToolSpindleAndMagazine) this).btn_moveright.Name && ((F_MarbleToolSpindleAndMagazine) this).\u0001 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarbleToolSpindleAndMagazine) this).\u0001((object) "MoveX", (object) ((F_MarbleToolSpindleAndMagazine) this).spn_move.Value, (object) null);
    }
    // ISSUE: reference to a compiler-generated field
    if (control.Name == ((F_MarbleToolSpindleAndMagazine) this).btn_rotateccw.Name && ((F_MarbleToolSpindleAndMagazine) this).\u0001 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarbleToolSpindleAndMagazine) this).\u0001((object) "Rotate", (object) ((F_MarbleToolSpindleAndMagazine) this).spn_rotate.Value, (object) null);
    }
    // ISSUE: reference to a compiler-generated field
    if (!(control.Name == ((F_MarbleToolSpindleAndMagazine) this).btn_rotatecw.Name) || ((F_MarbleToolSpindleAndMagazine) this).\u0001 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    ((F_MarbleToolSpindleAndMagazine) this).\u0001((object) "Rotate", (object) -((F_MarbleToolSpindleAndMagazine) this).spn_rotate.Value, (object) null);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleToolSpindleAndMagazine) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleToolSpindleAndMagazine) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public event OkCommandWithFiveDataEventHandler CommandExecute;
}
