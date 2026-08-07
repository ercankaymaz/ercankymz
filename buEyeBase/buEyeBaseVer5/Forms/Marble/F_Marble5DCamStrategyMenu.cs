// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_Marble5DCamStrategyMenu
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
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_Marble5DCamStrategyMenu : Form
{
  public buButton btn_gorightbwd;
  public buButton btn_goleftforward;
  public buButton btn_gorightforward;
  public static byte f002086;
  public static List<string> Captions;
  public FormProperties Properties;
  public bool isHorizontal;
  public bool isDialog;
  private IContainer \u0001;
  public buButton btn_minimise;
  public buButton btn_maximize;
  public buButton btn_close;

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleProfileCam) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleProfileCam) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleProfileCam) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleProfileCam) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleProfileCam) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleProfileCam) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleProfileCam) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
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
      fKeyPadNumV1.ShowDialog(buSpin.Value.ToString(), (IWin32Window) this);
      if (buFile5.IsNumeric(fKeyPadNumV1.Value))
        buSpin.Value = double.Parse(fKeyPadNumV1.Value);
      if (this.Owner == null)
        return;
      this.Owner.Focus();
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleProfileCam) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleProfileCam) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_Marble5DCamStrategyMenu() => F_MarbleProfileCam.Captions = new List<string>();

  public F_Marble5DCamStrategyMenu()
  {
    ((F_MarbleProfileCam) this).Settings = (marbleCutRemainMaterial) new \u0007.\u0001();
    ((F_MarbleProfileCam) this).SettingsMaterial = (marbleMaterialPars) new \u0007.\u0001();
    ((F_MarbleProfileCam) this).PropertiesForm = new FormProperties();
    ((F_MarbleProfileCam) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleCutRemailMaterial) this);
  }

  public void Init()
  {
    ((F_MarbleProfileCam) this).PropertiesForm.Inited = false;
    if (((F_MarbleProfileCam) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleProfileCam) this).PropertiesForm.Height;
    if (((F_MarbleProfileCam) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleProfileCam) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleProfileCam) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleProfileCam) this).PropertiesForm.FormPosition;
    ((F_MarbleProfileCam) this).spn_materialheight.Value = ((MarbleCamType) ((F_MarbleProfileCam) this).SettingsMaterial).MaterialHeight;
    ((F_MarbleProfileCam) this).spn_materialwidth.Value = ((MarbleCamType) ((F_MarbleProfileCam) this).SettingsMaterial).MaterialWidth;
    ((F_MarbleProfileCam) this).spn_materialhorlimit.Value = ((marbleCountertopInsideData) ((F_MarbleProfileCam) this).Settings).MaterialHorizontalMinDistance;
    ((F_MarbleProfileCam) this).spn_materialverlimit.Value = ((marbleCountertopInsideData) ((F_MarbleProfileCam) this).Settings).MaterialVerticalMinDistance;
    ((F_MarbleProfileCam) this).spn_materialcutheight.Value = ((marbleCountertopInsideData) ((F_MarbleProfileCam) this).Settings).MaterialCutHeight;
    ((F_MarbleProfileCam) this).spn_matrialcutWidth.Value = ((marbleCountertopInsideData) ((F_MarbleProfileCam) this).Settings).MaterialCutWidth;
    ((F_MarbleProfileCam) this).spn_verticaloffset.Value = ((marbleCountertopInsideData) ((F_MarbleProfileCam) this).Settings).VerticalOffset;
    ((F_MarbleProfileCam) this).spn_horizontaloffset.Value = ((marbleCountertopInsideData) ((F_MarbleProfileCam) this).Settings).HorizontalOffset;
    ((F_MarbleProfileCam) this).chk_pasueaftercut.Check = ((marbleCountertopInsideData) ((F_MarbleProfileCam) this).Settings).PauseAfterCut;
    ((F_MarbleProfileCam) this).chk_horizontalcutenable.Check = ((marbleCountertopInsideData) ((F_MarbleProfileCam) this).Settings).HorizontalCutEnable;
    ((F_MarbleProfileCam) this).chk_verticalcutenable.Check = ((marbleCountertopInsideData) ((F_MarbleProfileCam) this).Settings).VerticalCutEnable;
    if (((marbleCountertopInsideData) ((F_MarbleProfileCam) this).Settings).UseMaterialData)
    {
      ((F_MarbleProfileCam) this).\u0002.Checked = true;
      ((F_MarbleProfileCam) this).\u0001.Checked = false;
    }
    else
    {
      ((F_MarbleProfileCam) this).\u0002.Checked = false;
      ((F_MarbleProfileCam) this).\u0001.Checked = true;
    }
    ((F_MarbleMilling5AxisMenu) this).LoadLanguage();
    if (!((F_MarbleProfileCam) this).PropertiesForm.VisualUpdated)
      this.InitVisual();
    ((F_MarbleProfileCam) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleProfileCam) this).PropertiesForm.Inited = true;
  }

  public void InitVisual()
  {
    if (new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm").Exists)
    {
      Control.ControlCollection controlCollection = (Control.ControlCollection) null;
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleProfileCam) this).\u0001.Controls);
    }
    ((F_MarbleProfileCam) this).PropertiesForm.VisualUpdated = true;
  }
}
