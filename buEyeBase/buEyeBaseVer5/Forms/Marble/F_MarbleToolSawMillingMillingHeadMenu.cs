// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleToolSawMillingMillingHeadMenu
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
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleToolSawMillingMillingHeadMenu : Form
{
  public buButton btn_maximize;
  public buButton btn_close;
  public buGround buGround1;
  public buButton btn_cancel;
  public Panel pnl_base;
  public Panel pnl_data;
  public buButton btn_itemsinglecutok;
  public buSpin spn_signlecutAAngle;
  public buSpin spn_signlecutlength;
  public buSpin spn_signlecutCAngle;
  public static byte f0020BD;

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
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
    if ((!disposing ? 0 : (((F_MarbleProfileCam) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleProfileCam) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleToolSawMillingMillingHeadMenu()
  {
    F_MarbleProfileCam.Captions = new List<string>();
  }

  public F_MarbleToolSawMillingMillingHeadMenu()
  {
    ((F_MarbleSawCornerClean) this).PropertiesForm = new FormProperties();
    ((F_MarbleSawCornerClean) this).varDrill = (marbleDrillPars) new \u0007.\u0001();
    ((F_MarbleSawCornerClean) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleDrillPocketCam) this);
  }

  public void Init(int CamIndex)
  {
    ((F_MarbleSawCornerClean) this).PropertiesForm.Inited = false;
    if (((F_MarbleSawCornerClean) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleSawCornerClean) this).PropertiesForm.Height;
    if (((F_MarbleSawCornerClean) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleSawCornerClean) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleSawCornerClean) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleSawCornerClean) this).PropertiesForm.FormPosition;
    ((F_MarbleSawCornerClean) this).PropertiesForm.Result = DialogResult.None;
    switch (CamIndex)
    {
      case 0:
        ((F_MarbleSawCornerClean) this).\u0001.SelectedIndex = 0;
        ((F_MarbleSawCornerClean) this).\u0001.ItemSize = new Size(1, 1);
        break;
      case 1:
        ((F_MarbleSawCornerClean) this).\u0001.SelectedIndex = 1;
        ((F_MarbleSawCornerClean) this).\u0001.ItemSize = new Size(1, 1);
        break;
      case 2:
        ((F_MarbleSawCornerClean) this).\u0001.SelectedIndex = 2;
        ((F_MarbleSawCornerClean) this).\u0001.ItemSize = new Size(1, 1);
        break;
      default:
        ((F_MarbleSawCornerClean) this).\u0001.SelectedIndex = 0;
        ((F_MarbleSawCornerClean) this).\u0001.ItemSize = new Size(120, 30);
        break;
    }
    ((F_MarbleSawCornerClean) this).spn_drillpocketsafedis.Value = ((MarbleSawCamType) ((F_MarbleSawCornerClean) this).varDrill).HoleSafeDistance;
    ((F_MarbleSawCornerClean) this).spn_drillpocketscanX.Value = ((MarbleWaterJetCamType) ((F_MarbleSawCornerClean) this).varDrill).HoleScanXStep;
    ((F_MarbleSawCornerClean) this).spn_drillpocketscanY.Value = ((MarbleWaterJetCamType) ((F_MarbleSawCornerClean) this).varDrill).HoleScanYStep;
    ((F_MarbleSawCornerClean) this).spn_drillpocketplungefeed.Value = ((MarbleSawCamType) ((F_MarbleSawCornerClean) this).varDrill).PlungeSpeed;
    ((F_MarbleSawMillingRough) this).spn_drillpocketdepthstep.Value = ((MarbleCamMode) ((F_MarbleSawCornerClean) this).varDrill).HoleZDepthStep;
    ((F_MarbleSawMillingRough) this).spn_drillpocketcontouroffset.Value = ((MarbleCamMode) ((F_MarbleSawCornerClean) this).varDrill).HoleContourOffset;
    \u0007.\u0001.\u0001((F_MarbleDrillPocketCam) this);
    ((F_MarbleSawCornerClean) this).PropertiesForm.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleSawCornerClean) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleSawCornerClean) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleSawCornerClean) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleSawCornerClean) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleSawCornerClean) this).btn_ok.Name)
      {
        \u0007.\u0001.\u0001((F_MarbleDrillPocketCam) this);
        ((F_MarbleSawCornerClean) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_MarbleSawCornerClean) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleSawCornerClean) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_MarbleSawCornerClean) this).btn_cancel.Name | control2.Name == ((F_MarbleSawCornerClean) this).\u0001.Name))
        return;
      ((F_MarbleSawCornerClean) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_MarbleSawCornerClean) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleSawCornerClean) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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
}
