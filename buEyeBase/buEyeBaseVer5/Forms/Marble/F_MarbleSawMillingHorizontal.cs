// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleSawMillingHorizontal
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

public class F_MarbleSawMillingHorizontal : Form
{
  public buSpin spn_itemhorSA4;
  public buSpin spn_itemhorcount4;
  public buSpin spn_itemhorlen4;
  public buSpin spn_itemhorEA3;
  public buSpin spn_itemhorSA3;
  public buSpin spn_itemhorcount3;
  public buSpin spn_itemhorlen3;
  public buSpin spn_itemhorEA2;
  public buSpin spn_itemhorSA2;
  public buSpin spn_itemhorcount2;
  public buSpin spn_itemhorlen2;
  public buSpin spn_itemhorEA1;
  public buSpin spn_itemhorSA1;
  public buSpin spn_itemhorcount1;
  public buSpin spn_itemhorlen1;
  public buButton buButton1;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleSawMillingRough) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleSawMillingRough) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleSawMillingHorizontal() => F_MarbleSawMillingRough.Captions = new List<string>();

  public F_MarbleSawMillingHorizontal()
  {
    ((F_MarbleStockClear) this).PropertiesForm = new FormProperties();
    ((F_MarbleStockClear) this).varSettings = (marbleSawMillingPars) new \u0007.\u0001();
    ((F_MarbleStockClear) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleSawMillingCam) this);
  }

  public void Init(MarbleCamType CamType)
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleStockClear) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleStockClear) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleStockClear) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleStockClear) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleStockClear) this).btn_ok.Name)
      {
        \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleSawMillingCam) this);
        ((F_MarbleStockClear) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_MarbleStockClear) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleStockClear) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_MarbleStockClear) this).btn_cancel.Name | control2.Name == ((F_MarbleVacuumMove) this).\u0001.Name)
      {
        ((F_MarbleStockClear) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((F_MarbleStockClear) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleStockClear) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_MarbleSingleCutV2) this).btn_advanced.Name))
        return;
      if (!((F_MarbleHorVerCutV4) this).\u0002.Visible)
        ((F_MarbleHorVerCutV4) this).\u0002.Visible = true;
      else
        ((F_MarbleHorVerCutV4) this).\u0002.Visible = false;
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
