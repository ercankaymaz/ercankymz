// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleLatheMenu
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
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleLatheMenu : Form
{
  public buButton btn_DI0;
  public buButton btn_DI63;
  public buButton btn_DI48;
  public buButton btn_DI62;
  public buButton btn_DI49;
  public buButton btn_DI61;
  public buButton btn_DI50;
  public buButton btn_DI60;
  public buButton btn_DI51;
  public buButton btn_DI59;
  public buButton btn_DI52;
  public buButton btn_DI58;
  public buButton btn_DI53;
  public buButton btn_DI57;
  public buButton btn_DI54;
  public buButton btn_DI56;
  public buButton btn_DI55;
  public ImageList IC48;
  public buPanel pnl_input2;
  public buPanel pnl_input3;
  public buPanel pnl_input4;
  public static byte f0026F3;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  private IContainer \u0001;
  internal buGround \u0001;
  public buButton btn_xG54set;
  public buButton btn_zG54set;
  public buButton btn_yG54set;

  public F_MarbleLatheMenu()
  {
    ((F_MarbleColumnsMenu) this).Properties = new FormProperties();
    ((F_MarbleLibraryMenu) this).varSettings = (MarbleItemSettings) new buLogMarbleVer5();
    ((F_MarbleLibraryMenu) this).strMessageRoughtFinish = "Rought and  Finish Both Can't be Enabled";
    ((F_MarbleLibraryMenu) this).strMessageRoughtFinishSelect = "Rought or Finish One of them must be Selected";
    ((F_MarbleLibraryMenu) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleChamfer) this);
  }

  public void Init()
  {
    ((F_MarbleColumnsMenu) this).Properties.Inited = false;
    if (((F_MarbleColumnsMenu) this).Properties.Height > 10)
      this.Height = ((F_MarbleColumnsMenu) this).Properties.Height;
    if (((F_MarbleColumnsMenu) this).Properties.Width > 10)
      this.Width = ((F_MarbleColumnsMenu) this).Properties.Width;
    this.TopMost = ((F_MarbleColumnsMenu) this).Properties.TopMost;
    this.StartPosition = ((F_MarbleColumnsMenu) this).Properties.FormPosition;
    ((F_MarbleColumnsMenu) this).Properties.Result = DialogResult.None;
    ((F_MarbleColumnsMenu) this).Properties.Inited = true;
    ((F_MarbleLibraryMenu) this).spn_lengthstep.Value = ((MarbleCameraType) ((MarbleMachineSimultionSettings) ((F_MarbleLibraryMenu) this).varSettings).settingLatheCut).LatheCutFeed;
    ((F_MarbleLibraryMenu) this).spn_height.Value = ((MarbleCameraType) ((MarbleMachineSimultionSettings) ((F_MarbleLibraryMenu) this).varSettings).settingLatheCut).LathePlungeFeed;
    ((F_MarbleLibraryMenu) this).spn_Width.Value = ((MarbleCameraType) ((MarbleMachineSimultionSettings) ((F_MarbleLibraryMenu) this).varSettings).settingLatheCut).LatheSafeDistance;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleChamfer) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleColumnsMenu) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleColumnsMenu) this).Properties.Result = DialogResult.Cancel;
    if (((F_MarbleColumnsMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleColumnsMenu) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleLibraryMenu) this).btn_ok.Name)
      {
        \u0007.\u0001.\u0001((F_MarbleChamfer) this);
        ((F_MarbleColumnsMenu) this).Properties.Result = DialogResult.OK;
        if (((F_MarbleColumnsMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleColumnsMenu) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_MarbleLibraryMenu) this).btn_cancel.Name))
        return;
      ((F_MarbleColumnsMenu) this).Properties.Result = DialogResult.Cancel;
      if (((F_MarbleColumnsMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleColumnsMenu) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
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
    if ((!disposing ? 0 : (((F_MarbleLibraryMenu) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleLibraryMenu) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleLatheMenu() => F_MarbleColumnsMenu.Captions = new List<string>();

  public F_MarbleLatheMenu()
  {
    ((F_MarbleLibraryMenu) this).Properties = new FormProperties();
    ((F_MarbleLibraryMenu) this).varSettings = (MarbleItemSettings) new buLogMarbleVer5();
    ((F_MarbleLibraryMenu) this).strMessageRoughtFinish = "Rought and  Finish Both Can't be Enabled";
    ((F_MarbleLibraryMenu) this).strMessageRoughtFinishSelect = "Rought or Finish One of them must be Selected";
    ((F_MarbleLibraryMenu) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleColumns) this);
  }

  public void Init()
  {
    ((F_MarbleLibraryMenu) this).Properties.Inited = false;
    if (((F_MarbleLibraryMenu) this).Properties.Height > 10)
      this.Height = ((F_MarbleLibraryMenu) this).Properties.Height;
    if (((F_MarbleLibraryMenu) this).Properties.Width > 10)
      this.Width = ((F_MarbleLibraryMenu) this).Properties.Width;
    this.TopMost = ((F_MarbleLibraryMenu) this).Properties.TopMost;
    this.StartPosition = ((F_MarbleLibraryMenu) this).Properties.FormPosition;
    ((F_MarbleLibraryMenu) this).Properties.Result = DialogResult.None;
    ((F_MarbleLibraryMenu) this).Properties.Inited = true;
    ((F_MarbleLibraryMenu) this).spn_cutspeed.Value = ((MarbleOperationSequence) ((MarbleMachineSimultionSettings) ((F_MarbleLibraryMenu) this).varSettings).settingColoumnsCut).ColoumsCutFeed;
    ((F_MarbleLibraryMenu) this).spn_plungespeed.Value = ((MarbleOperationSequence) ((MarbleMachineSimultionSettings) ((F_MarbleLibraryMenu) this).varSettings).settingColoumnsCut).ColoumsPlungeFeed;
    ((F_MarbleLibraryMenu) this).spn_safedistance.Value = ((MarbleOperationSequence) ((MarbleMachineSimultionSettings) ((F_MarbleLibraryMenu) this).varSettings).settingColoumnsCut).ColoumsSafeDistance;
    ((F_MarbleLibraryMenu) this).spn_radiustopdistance.Value = ((MarbleOperationSequence) ((MarbleMachineSimultionSettings) ((F_MarbleLibraryMenu) this).varSettings).settingColoumnsCut).ColoumsRadiusTopDistance;
    ((F_MarbleLibraryMenu) this).spn_baseheight.Value = ((MarbleOperationSequence) ((MarbleMachineSimultionSettings) ((F_MarbleLibraryMenu) this).varSettings).settingColoumnsCut).ColoumsBaseHeight;
    ((F_MarbleLibraryMenu) this).spn_zstep.Value = ((MarbleOperationSequence) ((MarbleMachineSimultionSettings) ((F_MarbleLibraryMenu) this).varSettings).settingColoumnsCut).ColoumsZStep;
    ((F_MarbleLibraryMenu) this).chk_zigzag.Check = ((MarbleOperationSequence) ((MarbleMachineSimultionSettings) ((F_MarbleLibraryMenu) this).varSettings).settingColoumnsCut).ColoumsZigzagMode;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleColumns) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleLibraryMenu) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleLibraryMenu) this).Properties.Result = DialogResult.Cancel;
    if (((F_MarbleLibraryMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleLibraryMenu) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleLibraryMenu) this).btn_ok.Name)
      {
        \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleColumns) this);
        ((F_MarbleLibraryMenu) this).Properties.Result = DialogResult.OK;
        if (((F_MarbleLibraryMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleLibraryMenu) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_MarbleLibraryMenu) this).btn_cancel.Name))
        return;
      ((F_MarbleLibraryMenu) this).Properties.Result = DialogResult.Cancel;
      if (((F_MarbleLibraryMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleLibraryMenu) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
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
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleLibraryMenu) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleLibraryMenu) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleLatheMenu() => F_MarbleLibraryMenu.Captions = new List<string>();

  public F_MarbleLatheMenu()
  {
    ((F_MarbleLibraryMenu) this).Properties = new FormProperties();
    ((F_MarbleLibraryMenu) this).varSettings = (MarbleItemSettings) new buLogMarbleVer5();
    ((F_MarbleLibraryMenu) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0014.\u0001.\u0001((F_MarbleContour) this);
  }

  public void Init()
  {
    // ISSUE: unable to decompile the method.
  }

  public event OkCommandWithFiveDataEventHandler CommandExecute;
}
