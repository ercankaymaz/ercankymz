// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleCircularSpeed
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.DialogBox;
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

public class F_MarbleCircularSpeed : Form
{
  public buSpin spn_itemSA4;
  public buSpin spn_itemcount4;
  public buSpin spn_itemlen4;
  public buSpin spn_itemEA3;
  public buSpin spn_itemSA3;
  public buSpin spn_itemcount3;
  public buSpin spn_itemlen3;
  public buSpin spn_itemEA2;
  public buSpin spn_itemSA2;
  public buSpin spn_itemcount2;
  public buSpin spn_itemlen2;

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleHorVerCutV2) this).btn_ok.Name)
      {
        \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleSawCornerClean) this);
        ((F_MarbleHorVerCutV2) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_MarbleHorVerCutV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleHorVerCutV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_MarbleHorVerCutV2) this).btn_cancel.Name)
      {
        ((F_MarbleHorVerCutV2) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((F_MarbleHorVerCutV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleHorVerCutV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_MarbleHorVerCutV2) this).btn_advanced.Name)
      {
        if (!((F_MarbleHorVerCutV2) this).\u0001.Visible)
          ((F_MarbleHorVerCutV2) this).\u0001.Visible = true;
        else
          ((F_MarbleHorVerCutV2) this).\u0001.Visible = false;
      }
      if (control2.Name == ((F_MarbleHorVerCutV2) this).btn_closeadvanced.Name)
        ((F_MarbleHorVerCutV2) this).\u0001.Visible = false;
      if (!(control2.Name == ((F_MarbleHorVerCutV2) this).btn_color.Name))
        return;
      ColorDialogBox colorDialogBox = new ColorDialogBox();
      Color sawMillingCamColor = ((MarbleCountertopModes) ((F_MarbleHorVerCutV2) this).varSawMilling).SawMillingCamColor;
      if (ColorDialogBox.ShowDialog(ref sawMillingCamColor) != DialogResult.OK)
        return;
      ((MarbleCountertopModes) ((F_MarbleHorVerCutV2) this).varSawMilling).SawMillingCamColor = sawMillingCamColor;
      ((F_MarbleHorVerCutV2) this).btn_color.Display.BackColor = sawMillingCamColor;
      ((F_MarbleHorVerCutV2) this).btn_color.ButtonDownDisplay.BackColor = sawMillingCamColor;
      ((F_MarbleHorVerCutV2) this).btn_color.ButtonOverDisplay.BackColor = sawMillingCamColor;
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
    if ((!disposing ? 0 : (((F_MarbleHorVerCutV2) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleHorVerCutV2) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleCircularSpeed() => F_MarbleHorVerCutV2.Captions = new List<string>();

  public F_MarbleCircularSpeed()
  {
    ((F_MarbleHorVerCutV2) this).PropertiesForm = new FormProperties();
    ((F_MarbleHorVerCutV2) this).varSawMilling = (marbleSawMillingPars) new \u0007.\u0001();
    ((F_MarbleHorVerCutV2) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleSawMillingRough) this);
  }

  public void Init()
  {
    ((F_MarbleHorVerCutV2) this).PropertiesForm.Inited = false;
    if (((F_MarbleHorVerCutV2) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleHorVerCutV2) this).PropertiesForm.Height;
    if (((F_MarbleHorVerCutV2) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleHorVerCutV2) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleHorVerCutV2) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleHorVerCutV2) this).PropertiesForm.FormPosition;
    ((F_MarbleHorVerCutV2) this).spn_safedis.Value = ((MarbleOsnapCalcType) ((F_MarbleHorVerCutV2) this).varSawMilling).SawMillingSafeDistance;
    ((F_MarbleHorVerCutV2) this).spn_rapiddis.Value = ((MarbleOsnapCalcType) ((F_MarbleHorVerCutV2) this).varSawMilling).SawMillingRapidDistance;
    ((F_MarbleHorVerCutV2) this).spn_stepdistance.Value = ((MarbleCountertopCommands) ((F_MarbleHorVerCutV2) this).varSawMilling).SawMillingZStepDown;
    ((F_MarbleHorVerCutV2) this).spn_plunfefeed.Value = ((MarbleCountertopCommands) ((F_MarbleHorVerCutV2) this).varSawMilling).SawMillingPlungeFeed;
    ((F_MarbleHorVerCutV2) this).spn_xyoffset.Value = ((MarbleCountertopCommands) ((F_MarbleHorVerCutV2) this).varSawMilling).SawMillingXYOffset;
    ((F_MarbleHorVerCutV2) this).chk_zigzag.Check = ((MarbleCountertopCommands) ((F_MarbleHorVerCutV2) this).varSawMilling).SawMillingZigzag;
    ((F_MarbleHorVerCutV2) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleHorVerCutV2) this).PropertiesForm.Inited = true;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleSawMillingRough) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleHorVerCutV2) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleHorVerCutV2) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleHorVerCutV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleHorVerCutV2) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleHorVerCutV2) this).btn_ok.Name)
      {
        \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleSawMillingRough) this);
        ((F_MarbleHorVerCutV2) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_MarbleHorVerCutV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleHorVerCutV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_MarbleHorVerCutV2) this).btn_cancel.Name))
        return;
      ((F_MarbleHorVerCutV2) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_MarbleHorVerCutV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleHorVerCutV2) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_MarbleHorVerCutV2) this).PropertiesForm.Inited)
      ;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleHorVerCutV2) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleHorVerCutV2) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleCircularSpeed() => F_MarbleHorVerCutV2.Captions = new List<string>();
}
