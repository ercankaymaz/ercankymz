// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleSawMillingStrategyMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleSawMillingStrategyMenu : Form
{
  public buSpin spn_OutsideContourLeadIn;
  public buSpin spn_outsidecutcornerdis;
  public buSpin spn_insidecutcornerdis;
  public buCheckBox chk_OutsideArcCuttingByMilling;
  public buSpin spn_OutsideArcCuttingMinDiameterBySaw;
  public buCheckBox chk_LastStepAtSameTime;
  public buSpin spn_Inside0DegreeExtraOffset;
  public buSpin spn_Inside45DegreeExtraOffset;
  public buCheckBox chk_DontMoveSafeForForwardBackwardDirection;
  internal TabPage \u0005;

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleCamSettings) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleCamSettings) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleCamSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleCamSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
    ((MarbleMotionCommands) ((MarbleHMICommands) ((F_MarbleCamSettings) this).Chamfer).DataChamfer).BottomAngle = ((F_MarbleCamSettings) this).spn_chamferbottomangle.Value;
    ((MarbleMotionCommands) ((MarbleHMICommands) ((F_MarbleCamSettings) this).Chamfer).DataChamfer).BottomHeight = ((F_MarbleCamSettings) this).spn_chamferbottomheiht.Value;
    ((MarbleMotionCommands) ((MarbleHMICommands) ((F_MarbleCamSettings) this).Chamfer).DataChamfer).TopAngle = ((F_MarbleCamSettings) this).spn_chamfertopangle.Value;
    ((MarbleMotionCommands) ((MarbleHMICommands) ((F_MarbleCamSettings) this).Chamfer).DataChamfer).TopHeight = ((F_MarbleCamSettings) this).spn_chamfertopheight.Value;
    ((MarbleMotionCommands) ((MarbleHMICommands) ((F_MarbleCamSettings) this).Chamfer).DataChamfer).BottomEnable = ((F_MarbleCamSettings) this).chk_bottomchamfer.Check;
    ((MarbleMotionCommands) ((MarbleHMICommands) ((F_MarbleCamSettings) this).Chamfer).DataChamfer).TopEnable = ((F_MarbleCamSettings) this).chk_topchamfer.Check;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleCamSettings) this).btn_okVer.Name)
      {
        this.Apply();
        ((F_MarbleCamSettings) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_MarbleCamSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleCamSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_MarbleCamSettings) this).btn_close.Name | control2.Name == ((F_MarbleCamSettings) this).btn_cancel.Name))
        return;
      ((F_MarbleCamSettings) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_MarbleCamSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleCamSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_MarbleCamSettings) this).PropertiesForm.Inited)
      return;
    buSpin buSpin = obj0 as buSpin;
    buSpin.Display.BackColor = clsVisualVars.parVisual.colorDataFocus;
    buSpin.SelectAll();
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
    if ((!disposing ? 0 : (((F_MarbleCamSettings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleCamSettings) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleSawMillingStrategyMenu() => F_MarbleCamSettings.Captions = new List<string>();

  public F_MarbleSawMillingStrategyMenu()
  {
    ((F_MarbleCamSettings) this).Properties = new FormProperties();
    ((F_MarbleCamSettings) this).isHorizontal = false;
    ((F_MarbleCamSettings) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleSingleCut) this);
  }
}
