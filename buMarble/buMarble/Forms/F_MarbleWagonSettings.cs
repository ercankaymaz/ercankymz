// Decompiled with JetBrains decompiler
// Type: buMarble.Forms.F_MarbleWagonSettings
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMarble.Forms;

public class F_MarbleWagonSettings : Form
{
  internal buLabel \u0002;
  internal buLabel \u0003;
  public buCheckBox chk_slot;
  public buCheckBox chk_grinding;
  internal buSeparator \u0001;
  internal buLabel \u0004;
  public buCheckBox chk_cornerfull;
  public buCheckBox chk_cornercorner;
  public buCheckBox chk_cornernone;
  public buSpin spn_tooloutsidedia;
  public buCheckBox chk_barrel;
  public buCheckBox chk_dove;
  public buCheckBox chk_lollipop;
  public buCheckBox chk_chamfer;
  public buCheckBox chk_taper;
  public buCheckBox chk_boolnose;
  public buCheckBox chk_sphare;
  public buCheckBox chk_flat;
  public buSpin spn_tooltaperangle;

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_MarbleToolTypes) this).PropertiesForm.Inited)
      return;
    buSpin buSpin = obj0 as buSpin;
    buSpin.Display.BackColor = buEyeVars.parVisual.colorDataFocus;
    buSpin.SelectAll();
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    buSpin buSpin = obj0 as buSpin;
    if (!AppBool.TouchPad)
      return;
    F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
    if (!buNumeric5.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }

  internal void \u0001([In] object obj0, [In] double obj1)
  {
    try
    {
      if (!((F_MarbleToolTypes) this).PropertiesForm.Inited)
        return;
      ((F_MarbleToolTypes) this).Apply();
    }
    catch (Exception ex)
    {
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleToolTypes) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleToolTypes) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleWagonSettings() => F_MarbleToolTypes.Captions = new List<string>();

  public F_MarbleWagonSettings()
  {
    ((\u0007.\u0001) this).PropertiesForm = new FormProperties();
    ((\u0007.\u0001) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0005.\u0003.\u0001(this);
  }

  public void Init()
  {
    ((\u0007.\u0001) this).PropertiesForm.Inited = false;
    if (((\u0007.\u0001) this).PropertiesForm.Height > 10)
      this.Height = ((\u0007.\u0001) this).PropertiesForm.Height;
    if (((\u0007.\u0001) this).PropertiesForm.Width > 10)
      this.Width = ((\u0007.\u0001) this).PropertiesForm.Width;
    this.TopMost = ((\u0007.\u0001) this).PropertiesForm.TopMost;
    this.StartPosition = ((\u0007.\u0001) this).PropertiesForm.FormPosition;
    ((\u0006.\u0004) this).spn_WagonHidroStopSec.Value = clsAppMarbleVars.varApp.WagonHidroStopSec;
    ((\u0006.\u0004) this).spn_WagonPosTimeOutSec.Value = clsAppMarbleVars.varApp.WagonPosTimeOutSec;
    ((\u0006.\u0004) this).spn_WagonUpPositionA.Value = clsAppMarbleVars.varApp.WagonUpPositionA;
    ((\u0006.\u0004) this).spn_WagonUpPositionC.Value = clsAppMarbleVars.varApp.WagonUpPositionC;
    ((\u0006.\u0005.\u0001) this).spn_WagonUpPositionX.Value = clsAppMarbleVars.varApp.WagonUpPositionX;
    ((\u0006.\u0005.\u0001) this).spn_WagonUpPositionY.Value = clsAppMarbleVars.varApp.WagonUpPositionY;
    ((\u0006.\u0005.\u0001) this).spn_WagonUpPositionZ.Value = clsAppMarbleVars.varApp.WagonUpPositionZ;
    ((\u0007.\u0001) this).PropertiesForm.Result = DialogResult.None;
    ((\u0007.\u0001) this).PropertiesForm.Inited = true;
    \u0005.\u0003.\u0001(this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((\u0007.\u0001) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((\u0007.\u0001) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((\u0007.\u0001) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((\u0007.\u0001) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
