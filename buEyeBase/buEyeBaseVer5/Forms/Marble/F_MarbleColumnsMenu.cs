// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleColumnsMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms.Kinematic;
using buEyeBaseVer5.Forms.Library;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleColumnsMenu : Form
{
  public buButton btn_close;
  internal buSeparator \u0001;
  internal buSeparator \u0002;
  public buSpin spn_zG54;
  public buSpin spn_yG54;
  public buSpin spn_xG54;
  public static byte f002704;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  private IContainer \u0001;
  internal buGround \u0001;
  public buButton btn_xrabsoluteeset;
  public buButton btn_cancel;
  public buButton btn_cabsolutereset;
  public buButton btn_aabsolutereset;
  public buButton btn_zabsolutereset;
  public buButton btn_yabsolutereset;
  public buButton btn_close;
  internal buSeparator \u0001;
  public buSpin spn_absolutesetC;
  public buSpin spn_absolutesetA;
  public buSpin spn_absolutesetZ;
  public buSpin spn_absolutesetY;
  public buSpin spn_absolutesetX;
  internal buSeparator \u0002;
  internal buSeparator \u0003;
  internal buSeparator \u0004;
  public static byte f00271C;
  public FormProperties Properties;
  public static List<string> Captions;

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
      if (control2.Name == ((F_MarbleTextMenu) this).chk_concavecuttingMilling.Name)
      {
        ((F_MarbleTextMenu) this).chk_concavecuttingMilling.Check = true;
        ((F_MarbleTextMenu) this).chk_concavecuttingNone.Check = false;
        ((F_MarbleTextMenu) this).chk_concavecuttingWaterjet.Check = false;
      }
      else if (control2.Name == ((F_MarbleTextMenu) this).chk_concavecuttingWaterjet.Name)
      {
        ((F_MarbleTextMenu) this).chk_concavecuttingMilling.Check = false;
        ((F_MarbleTextMenu) this).chk_concavecuttingNone.Check = false;
        ((F_MarbleTextMenu) this).chk_concavecuttingWaterjet.Check = true;
      }
      else if (control2.Name == ((F_MarbleTextMenu) this).chk_concavecuttingNone.Name)
      {
        ((F_MarbleTextMenu) this).chk_concavecuttingMilling.Check = false;
        ((F_MarbleTextMenu) this).chk_concavecuttingNone.Check = true;
        ((F_MarbleTextMenu) this).chk_concavecuttingWaterjet.Check = false;
      }
      else if (control2.Name == ((F_MarbleTextMenu) this).chk_concexcuttingmilling.Name)
      {
        ((F_MarbleTextMenu) this).chk_concexcuttingmilling.Check = true;
        ((F_MarbleTextMenu) this).chk_concexcuttingWaterjet.Check = false;
        ((F_MarbleTextMenu) this).chk_concexcuttingNone.Check = false;
      }
      else if (control2.Name == ((F_MarbleTextMenu) this).chk_concexcuttingWaterjet.Name)
      {
        ((F_MarbleTextMenu) this).chk_concexcuttingmilling.Check = false;
        ((F_MarbleTextMenu) this).chk_concexcuttingWaterjet.Check = true;
        ((F_MarbleTextMenu) this).chk_concexcuttingNone.Check = false;
      }
      else if (control2.Name == ((F_MarbleTextMenu) this).chk_concexcuttingNone.Name)
      {
        ((F_MarbleTextMenu) this).chk_concexcuttingmilling.Check = false;
        ((F_MarbleTextMenu) this).chk_concexcuttingWaterjet.Check = false;
        ((F_MarbleTextMenu) this).chk_concexcuttingNone.Check = true;
      }
      else
      {
        if (control2.Name == ((F_MarbleTextMenu) this).btn_advancedsettings.Name)
        {
          F_MarbleContourAdvancedSettings advancedSettings = (F_MarbleContourAdvancedSettings) new F_KinematicBasic();
          ((F_SketchLibrary) advancedSettings).varOperation = (MarbleItemSettings) new buLogMarbleVer5(((F_MarbleLibraryMenu) this).varSettings);
          ((F_SketchLibrary) advancedSettings).Properties.FormCloseMode = FormCloseModeType.Dispose;
          ((F_SketchLibrary) advancedSettings).Properties.FormPosition = FormStartPosition.CenterParent;
          ((F_KinematicBasic) advancedSettings).Init();
          int num = (int) advancedSettings.ShowDialog();
          if (((F_SketchLibrary) advancedSettings).Properties.Result == DialogResult.OK)
            ((F_MarbleLibraryMenu) this).varSettings = (MarbleItemSettings) new buLogMarbleVer5(((F_SketchLibrary) advancedSettings).varOperation);
        }
        if (control2.Name == ((F_MarbleLibraryMenu) this).btn_ok.Name)
        {
          \u0018.\u0002.\u0001.\u0001((F_MarbleContour) this);
          ((F_MarbleLibraryMenu) this).Properties.Result = DialogResult.OK;
          if (((F_MarbleLibraryMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
            this.Dispose();
          if (((F_MarbleLibraryMenu) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
            this.Visible = false;
        }
        if (!(control2.Name == ((F_MarbleLibraryMenu) this).btn_cancel.Name | control2.Name == ((F_MarbleTextMenu) this).btn_close.Name))
          return;
        ((F_MarbleLibraryMenu) this).Properties.Result = DialogResult.Cancel;
        if (((F_MarbleLibraryMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleLibraryMenu) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
      }
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

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    buCheckBox buCheckBox = obj0 as buCheckBox;
    ((F_MarbleTextMenu) this).chk_concavecuttingNone.Check = false;
    ((F_MarbleTextMenu) this).chk_DontAddExtensionEntities.Check = false;
    buCheckBox.Check = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleLibraryMenu) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleLibraryMenu) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleColumnsMenu() => F_MarbleLibraryMenu.Captions = new List<string>();

  public F_MarbleColumnsMenu()
  {
    ((F_MarbleTextMenu) this).Properties = new FormProperties();
    ((F_MarbleTextMenu) this).varSettings = (MarbleItemSettings) new buLogMarbleVer5();
    ((F_MarbleTextMenu) this).strMessageRoughtFinish = "Rought and  Finish Both Can't be Enabled";
    ((F_MarbleTextMenu) this).strMessageRoughtFinishSelect = "Rought or Finish One of them must be Selected";
    ((F_MarbleTextMenu) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleLatheVertical) this);
  }

  public void Init()
  {
    ((F_MarbleTextMenu) this).Properties.Inited = false;
    if (((F_MarbleTextMenu) this).Properties.Height > 10)
      this.Height = ((F_MarbleTextMenu) this).Properties.Height;
    if (((F_MarbleTextMenu) this).Properties.Width > 10)
      this.Width = ((F_MarbleTextMenu) this).Properties.Width;
    this.TopMost = ((F_MarbleTextMenu) this).Properties.TopMost;
    this.StartPosition = ((F_MarbleTextMenu) this).Properties.FormPosition;
    ((F_MarbleTextMenu) this).Properties.Result = DialogResult.None;
    ((F_MarbleTextMenu) this).Properties.Inited = true;
    ((F_MarbleTextMenu) this).spn_cutspeed.Value = ((MarbleLatheDirection) ((MarbleMachineSimultionSettings) ((F_MarbleTextMenu) this).varSettings).settingLatheVerticalCut).LatheCutFeed;
    ((F_MarbleTextMenu) this).spn_plungespeed.Value = ((MarbleLatheDirection) ((MarbleMachineSimultionSettings) ((F_MarbleTextMenu) this).varSettings).settingLatheVerticalCut).LathePlungeFeed;
    ((F_MarbleTextMenu) this).spn_safedistance.Value = ((MarbleLatheDirection) ((MarbleMachineSimultionSettings) ((F_MarbleTextMenu) this).varSettings).settingLatheVerticalCut).LatheSafeDistance;
    ((F_MarbleTextMenu) this).spn_radiustopdistance.Value = ((MarbleLatheDirection) ((MarbleMachineSimultionSettings) ((F_MarbleTextMenu) this).varSettings).settingLatheVerticalCut).LatheRadiusTopDistance;
    ((F_MarbleTextMenu) this).spn_baseheight.Value = ((MarbleLatheDirection) ((MarbleMachineSimultionSettings) ((F_MarbleTextMenu) this).varSettings).settingLatheVerticalCut).LatheBaseHeight;
    \u0007.\u0001.\u0001((F_MarbleLatheVertical) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleTextMenu) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleTextMenu) this).Properties.Result = DialogResult.Cancel;
    if (((F_MarbleTextMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleTextMenu) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleTextMenu) this).btn_ok.Name)
      {
        \u0007.\u0001.\u0001((F_MarbleLatheVertical) this);
        ((F_MarbleTextMenu) this).Properties.Result = DialogResult.OK;
        if (((F_MarbleTextMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleTextMenu) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_MarbleTextMenu) this).btn_cancel.Name))
        return;
      ((F_MarbleTextMenu) this).Properties.Result = DialogResult.Cancel;
      if (((F_MarbleTextMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleTextMenu) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
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
    if ((!disposing ? 0 : (((F_MarbleTextMenu) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleTextMenu) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleColumnsMenu() => F_MarbleTextMenu.Captions = new List<string>();

  public F_MarbleColumnsMenu()
  {
    ((F_MarbleTextMenu) this).Properties = new FormProperties();
    ((F_MarbleTextMenu) this).varProfileCurveCut = (marbleProfileCurveCutPars) new \u0007.\u0001();
    ((F_MarbleTextMenu) this).CamVisible = true;
    ((F_MarbleDrillMenu) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleProfileCurveCutCad) this);
  }

  public void Init()
  {
    ((F_MarbleTextMenu) this).Properties.Inited = false;
    if (((F_MarbleTextMenu) this).Properties.Height > 10)
      this.Height = ((F_MarbleTextMenu) this).Properties.Height;
    if (((F_MarbleTextMenu) this).Properties.Width > 10)
      this.Width = ((F_MarbleTextMenu) this).Properties.Width;
    this.TopMost = ((F_MarbleTextMenu) this).Properties.TopMost;
    this.StartPosition = ((F_MarbleTextMenu) this).Properties.FormPosition;
    ((F_MarbleTextMenu) this).Properties.Result = DialogResult.None;
    ((F_MarbleTextMenu) this).Properties.Inited = true;
    ((F_MarbleDrillMenu) this).spn_radius.Value = ((marbleCountertopCavityData) ((F_MarbleTextMenu) this).varProfileCurveCut).Radius;
    ((F_MarbleDrillMenu) this).spn_baseheight.Value = ((marbleCountertopCavityData) ((F_MarbleTextMenu) this).varProfileCurveCut).BaseHeight;
    ((F_MarbleDrillMenu) this).spn_startangle.Value = ((marbleCountertopCavityData) ((F_MarbleTextMenu) this).varProfileCurveCut).StartAngle;
    ((F_MarbleDrillMenu) this).spn_sweepangle.Value = ((marbleCountertopCavityData) ((F_MarbleTextMenu) this).varProfileCurveCut).SweepAngle;
    ((F_MarbleDrillMenu) this).chk_finish.Check = ((marbleMenuType) ((F_MarbleTextMenu) this).varProfileCurveCut).FinishEnable;
    ((F_MarbleDrillMenu) this).chk_rough.Check = ((marbleChamferBothSideData) ((F_MarbleTextMenu) this).varProfileCurveCut).RoughEnable;
    ((F_MarbleDrillMenu) this).chk_cutprofileend.Check = ((DeleteEntitiesType) ((F_MarbleTextMenu) this).varProfileCurveCut).CutProfileEnd;
    ((F_MarbleDrillMenu) this).chk_cutprofilestart.Check = ((DeleteEntitiesType) ((F_MarbleTextMenu) this).varProfileCurveCut).CutProfileStart;
    ((F_MarbleDrillMenu) this).chk_verticalcut.Check = ((DeleteEntitiesType) ((F_MarbleTextMenu) this).varProfileCurveCut).VerticalCut;
    ((F_MarbleDrillMenu) this).chk_twistenable.Check = ((DeleteEntitiesType) ((F_MarbleTextMenu) this).varProfileCurveCut).TwistEnable;
    ((F_MarbleDrillMenu) this).spn_twistEA.Value = ((buLogMarbleVer5) ((F_MarbleTextMenu) this).varProfileCurveCut).TwistEndAngle;
    ((F_MarbleDrillMenu) this).spn_twistSA.Value = ((DeleteEntitiesType) ((F_MarbleTextMenu) this).varProfileCurveCut).TwistStartAngle;
    ((F_MarbleDrillMenu) this).\u0001.Visible = ((F_MarbleTextMenu) this).CamVisible;
    if (((F_MarbleTextMenu) this).CamVisible)
      this.Height = 755;
    else
      this.Height = 530;
    \u0007.\u0001.\u0001((F_MarbleProfileCurveCutCad) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleTextMenu) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleTextMenu) this).Properties.Result = DialogResult.Cancel;
    if (((F_MarbleTextMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleTextMenu) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public event OkCommandWithFiveDataEventHandler CommandExecute;
}
