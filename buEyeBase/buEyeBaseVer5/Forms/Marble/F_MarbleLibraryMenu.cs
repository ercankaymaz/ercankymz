// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleLibraryMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms.Layer;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleLibraryMenu : Form
{
  public MarbleItemSettings varSettings;
  public string strMessageRoughtFinish;
  public string strMessageRoughtFinishSelect;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public buSpin spn_Width;
  public buButton btn_ok;
  public buButton btn_cancel;
  public buCheckBox chk_maxtomin;
  public buSpin spn_height;
  public buSpin spn_lengthstep;
  internal buGround \u0001;
  internal buButton \u0001;
  public buCheckBox buCheckBox1;
  public static byte f00272D;
  public FormProperties Properties;
  public static List<string> Captions;
  public MarbleItemSettings varSettings;
  public string strMessageRoughtFinish;
  public string strMessageRoughtFinishSelect;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public buSpin spn_safedistance;
  public buButton btn_ok;
  public buButton btn_cancel;
  public buSpin spn_plungespeed;
  public buSpin spn_cutspeed;
  internal buGround \u0001;
  internal buButton \u0001;
  public buSpin spn_radiustopdistance;
  public buSpin spn_baseheight;
  public buSpin spn_zstep;
  public buCheckBox chk_zigzag;
  public static byte f002740;
  public FormProperties Properties;
  public static List<string> Captions;
  public MarbleItemSettings varSettings;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public buSpin spn_InnerCutSafeDistance;
  public buButton btn_ok;
  public buButton btn_cancel;
  public buSpin spn_OutterCutSafeDistance;

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleDrillMenu) this).btn_ok.Name)
      {
        \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleProfileCurveCutCad) this);
        ((F_MarbleTextMenu) this).Properties.Result = DialogResult.OK;
        if (((F_MarbleTextMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleTextMenu) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_MarbleDrillMenu) this).btn_cancel.Name | control2.Name == ((F_MarbleDrillMenu) this).\u0001.Name)
      {
        ((F_MarbleTextMenu) this).Properties.Result = DialogResult.Cancel;
        if (((F_MarbleTextMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleTextMenu) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_MarbleDrillMenu) this).btn_settings.Name))
        return;
      F_MarbleProfileCurveSettings profileCurveSettings = (F_MarbleProfileCurveSettings) new buEyeBaseVer5.Forms.KeyPad.F_KeyPadCharV1();
      ((F_LayerOptionList) profileCurveSettings).varProfileCurveCut = (marbleProfileCurveCutPars) new \u0007.\u0001(((F_MarbleTextMenu) this).varProfileCurveCut);
      ((F_LayerOptionList) profileCurveSettings).Properties.FormCloseMode = FormCloseModeType.Dispose;
      ((F_LayerOptionList) profileCurveSettings).Properties.FormPosition = FormStartPosition.CenterParent;
      ((buEyeBaseVer5.Forms.KeyPad.F_KeyPadCharV1) profileCurveSettings).Init();
      int num = (int) profileCurveSettings.ShowDialog();
      if (((F_LayerOptionList) profileCurveSettings).Properties.Result != DialogResult.OK)
        return;
      ((F_MarbleTextMenu) this).varProfileCurveCut = (marbleProfileCurveCutPars) new \u0007.\u0001(((F_LayerOptionList) profileCurveSettings).varProfileCurveCut);
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    buSpin buSpin = obj0 as buSpin;
    if (!AppBool.TouchPad)
      return;
    buControls.Forms.buControlForms.KeyPad.F_KeyPadNumV1 fKeyPadNumV1 = new buControls.Forms.buControlForms.KeyPad.F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
    if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleDrillMenu) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleDrillMenu) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleLibraryMenu() => F_MarbleTextMenu.Captions = new List<string>();

  public F_MarbleLibraryMenu()
  {
    ((F_MarbleDrillMenu) this).Properties = new FormProperties();
    ((F_MarbleDrillMenu) this).varAirDry = (marbleAirDryPars) new \u0007.\u0001();
    ((F_MarbleDrillMenu) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleAirBlow) this);
  }

  public void Init()
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleDrillMenu) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleDrillMenu) this).Properties.Result = DialogResult.Cancel;
    if (((F_MarbleDrillMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleDrillMenu) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleDrillMenu) this).btn_ok.Name)
      {
        \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleAirBlow) this);
        ((F_MarbleDrillMenu) this).Properties.Result = DialogResult.OK;
        if (((F_MarbleDrillMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleDrillMenu) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_MarbleDrillMenu) this).btn_cancel.Name | control2.Name == ((F_MarbleDrillMenu) this).\u0001.Name))
        return;
      ((F_MarbleDrillMenu) this).Properties.Result = DialogResult.Cancel;
      if (((F_MarbleDrillMenu) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleDrillMenu) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    buSpin buSpin = obj0 as buSpin;
    if (!AppBool.TouchPad)
      return;
    buControls.Forms.buControlForms.KeyPad.F_KeyPadNumV1 fKeyPadNumV1 = new buControls.Forms.buControlForms.KeyPad.F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
    if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }

  internal void \u0001([In] object obj0, [In] bool obj1)
  {
    if (!((F_MarbleDrillMenu) this).Properties.Inited)
      ;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_MarbleDrillMenu) this).Properties.Inited)
      return;
    buCheckBox buCheckBox = obj0 as buCheckBox;
    if (buCheckBox.Name == ((F_MarbleBaseMatClear) this).chk_allblock.Name)
    {
      ((F_MarbleBaseMatClear) this).chk_allblock.Check = true;
      ((F_MarbleBaseMatClear) this).chk_onlyparts.Check = false;
    }
    if (buCheckBox.Name == ((F_MarbleBaseMatClear) this).chk_onlyparts.Name)
    {
      ((F_MarbleBaseMatClear) this).chk_allblock.Check = false;
      ((F_MarbleBaseMatClear) this).chk_onlyparts.Check = true;
    }
    if (buCheckBox.Name == ((F_MarbleBaseMatClear) this).chk_horizontal.Name)
    {
      ((F_MarbleBaseMatClear) this).chk_horizontal.Check = true;
      ((F_MarbleBaseMatClear) this).chk_vertical.Check = false;
    }
    if (!(buCheckBox.Name == ((F_MarbleBaseMatClear) this).chk_vertical.Name))
      return;
    ((F_MarbleBaseMatClear) this).chk_horizontal.Check = false;
    ((F_MarbleBaseMatClear) this).chk_vertical.Check = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleDrillMenu) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleDrillMenu) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleLibraryMenu() => F_MarbleDrillMenu.Captions = new List<string>();

  public F_MarbleLibraryMenu()
  {
    ((F_MarbleBaseMatClear) this).Properties = new FormProperties();
    ((F_MarbleBaseMatClear) this).varProfileCut = (marbleProfileCutPars) new \u0007.\u0001();
    ((F_MarbleBaseMatClear) this).CamVisible = true;
    ((F_MarbleBaseMatClear) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleProfileCutCad) this);
  }

  public void Init()
  {
    ((F_MarbleBaseMatClear) this).Properties.Inited = false;
    if (((F_MarbleBaseMatClear) this).Properties.Height > 10)
      this.Height = ((F_MarbleBaseMatClear) this).Properties.Height;
    if (((F_MarbleBaseMatClear) this).Properties.Width > 10)
      this.Width = ((F_MarbleBaseMatClear) this).Properties.Width;
    this.TopMost = ((F_MarbleBaseMatClear) this).Properties.TopMost;
    this.StartPosition = ((F_MarbleBaseMatClear) this).Properties.FormPosition;
    ((F_MarbleBaseMatClear) this).Properties.Result = DialogResult.None;
    ((F_MarbleBaseMatClear) this).Properties.Inited = true;
    ((F_MarbleBaseMatClear) this).spn_length.Value = ((buLogMarbleVer5) ((F_MarbleBaseMatClear) this).varProfileCut).Length;
    ((F_MarbleBaseMatClear) this).spn_baseheight.Value = ((buLogMarbleVer5) ((F_MarbleBaseMatClear) this).varProfileCut).BaseHeight;
    ((F_MarbleBaseMatClear) this).spn_ang.Value = ((CounterTopDrawEventArg) ((F_MarbleBaseMatClear) this).varProfileCut).RotationAngle;
    ((F_MarbleBaseMatClear) this).chk_finish.Check = ((CounterTopFormImageIndex) ((F_MarbleBaseMatClear) this).varProfileCut).FinishEnable;
    ((F_MarbleBaseMatClear) this).chk_rough.Check = ((MarbleCamParameterSetArg) ((F_MarbleBaseMatClear) this).varProfileCut).RoughEnable;
    ((F_MarbleBaseMatClear) this).chk_cutprofileend.Check = ((MarbleProfileCalcParameters) ((F_MarbleBaseMatClear) this).varProfileCut).CutProfileStart;
    ((F_MarbleBaseMatClear) this).chk_cutprofilestart.Check = ((MarbleProfileCalcParameters) ((F_MarbleBaseMatClear) this).varProfileCut).CutProfileEnd;
    ((F_MarbleMaterialSize) this).chk_twistenable.Check = ((MarbleSawCalcParameters) ((F_MarbleBaseMatClear) this).varProfileCut).TwistEnable;
    ((F_MarbleBaseMatClear) this).spn_twistEA.Value = ((MarbleSawCalcParameters) ((F_MarbleBaseMatClear) this).varProfileCut).TwistEndAngle;
    ((F_MarbleMaterialSize) this).spn_twistSA.Value = ((MarbleSawCalcParameters) ((F_MarbleBaseMatClear) this).varProfileCut).TwistStartAngle;
    ((F_MarbleMaterialSize) this).\u0001.Visible = ((F_MarbleBaseMatClear) this).CamVisible;
    if (((F_MarbleBaseMatClear) this).CamVisible)
      this.Height = 645;
    else
      this.Height = 410;
    \u001F.\u0001.\u0001((F_MarbleProfileCutCad) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleBaseMatClear) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleBaseMatClear) this).Properties.Result = DialogResult.Cancel;
    if (((F_MarbleBaseMatClear) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleBaseMatClear) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public event OkCommandWithFiveDataEventHandler CommandExecute;
}
