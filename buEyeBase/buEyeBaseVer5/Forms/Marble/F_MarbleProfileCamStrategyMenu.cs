// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleProfileCamStrategyMenu
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
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleProfileCamStrategyMenu : Form
{
  public buSpin spn_toollen2;
  public buSpin spn_toolspeed1;
  public buSpin spn_tooldia1;
  public buSpin spn_toollen1;
  public buButton btn_toolacitve6;
  public buButton btn_toolacitve5;
  public buButton btn_toolacitve4;
  public buButton btn_toolacitve3;
  public buButton btn_toolacitve2;
  public buButton btn_toolacitve1;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleToolSpindleAndMagazine) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleToolSpindleAndMagazine) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleProfileCamStrategyMenu()
  {
    F_MarbleToolSpindleAndMagazine.Captions = new List<string>();
  }

  public F_MarbleProfileCamStrategyMenu()
  {
    ((F_MarbleToolSpindleAndMagazine) this).Properties = new FormProperties();
    ((F_MarbleToolSpindleAndMagazine) this).varRuntime = (MarbleRuntimeSettings) new MarbleSawCalcParameters();
    ((F_MarbleToolSpindleAndMagazine) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleEditBaseHAndXY) this);
  }

  public void Init()
  {
    ((F_MarbleToolSpindleAndMagazine) this).Properties.Inited = false;
    if (((F_MarbleToolSpindleAndMagazine) this).Properties.Height > 10)
      this.Height = ((F_MarbleToolSpindleAndMagazine) this).Properties.Height;
    if (((F_MarbleToolSpindleAndMagazine) this).Properties.Width > 10)
      this.Width = ((F_MarbleToolSpindleAndMagazine) this).Properties.Width;
    this.TopMost = ((F_MarbleToolSpindleAndMagazine) this).Properties.TopMost;
    this.StartPosition = ((F_MarbleToolSpindleAndMagazine) this).Properties.FormPosition;
    ((F_MarbleToolSpindleAndMagazine) this).Properties.Result = DialogResult.None;
    ((F_MarbleToolSpindleAndMagazine) this).Properties.Inited = true;
    ((F_MarbleToolSpindleAndMagazine) this).spn_scaleheight.Value = ((marbleCamPars) ((F_MarbleToolSpindleAndMagazine) this).varRuntime).ScaleHeight;
    ((F_MarbleToolSpindleAndMagazine) this).spn_scalewidth.Value = ((marbleCamPars) ((F_MarbleToolSpindleAndMagazine) this).varRuntime).ScaleWidth;
    ((F_MarbleToolSpindleAndMagazine) this).spn_baseheight.Value = ((marbleCamPars) ((F_MarbleToolSpindleAndMagazine) this).varRuntime).ScaleBaseHeight;
    ((F_MarbleToolSpindleAndMagazine) this).chk_keepratio.Check = ((marbleCamPars) ((F_MarbleToolSpindleAndMagazine) this).varRuntime).ScaleKeepRatio;
    \u001F.\u0001.\u0001.\u0001((F_MarbleEditBaseHAndXY) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleToolSpindleAndMagazine) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleToolSpindleAndMagazine) this).Properties.Result = DialogResult.Cancel;
    if (((F_MarbleToolSpindleAndMagazine) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleToolSpindleAndMagazine) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleToolSpindleAndMagazine) this).btn_ok.Name)
      {
        \u0018.\u0002.\u0006.\u0001((F_MarbleEditBaseHAndXY) this);
        ((F_MarbleToolSpindleAndMagazine) this).Properties.Result = DialogResult.OK;
        if (((F_MarbleToolSpindleAndMagazine) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleToolSpindleAndMagazine) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_MarbleToolSpindleAndMagazine) this).btn_cancel.Name | control2.Name == ((F_MarbleToolSpindleAndMagazine) this).\u0001.Name))
        return;
      ((F_MarbleToolSpindleAndMagazine) this).Properties.Result = DialogResult.Cancel;
      if (((F_MarbleToolSpindleAndMagazine) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleToolSpindleAndMagazine) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
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
    F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
    if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }
}
