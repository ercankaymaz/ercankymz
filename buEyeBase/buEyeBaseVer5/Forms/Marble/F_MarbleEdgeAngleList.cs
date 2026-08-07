// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleEdgeAngleList
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleEdgeAngleList : Form
{
  public buButton btn_move_left;
  public buButton btn_move_up;
  public buButton btn_move_rightdown;
  public buButton btn_move_down;
  public buButton btn_move_leftup;
  public buButton btn_move_leftdown;
  public buButton btn_move_rightup;
  public buSpin spn_moveval;
  public buButton btn_removevacuum;

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    // ISSUE: reference to a compiler-generated field
    if (((F_MarbleCountertopSlat) this).\u0001 == null)
      return;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).AlignMoveValue = this.spn_moveval.Value;
    if (control.Name == ((F_MarblePhotoCalibration) this).btn_addvacuum.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarbleCountertopSlat) this).\u0001((object) (MarbleCadCamCommands) 23, (object) 0, (object) (MarbleVacuumCommands) 2, (object) null, (object) null);
    }
    if (control.Name == this.btn_removevacuum.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarbleCountertopSlat) this).\u0001((object) (MarbleCadCamCommands) 24, (object) 0, (object) (MarbleVacuumCommands) 2, (object) null, (object) null);
    }
    if (control.Name == this.btn_move_leftup.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarbleCountertopSlat) this).\u0001((object) (MarbleCadCamCommands) 10, (object) this.spn_moveval.Value, (object) (MarbleVacuumCommands) 1, (object) null, (object) null);
    }
    if (control.Name == this.btn_move_leftdown.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarbleCountertopSlat) this).\u0001((object) (MarbleCadCamCommands) 11, (object) this.spn_moveval.Value, (object) (MarbleVacuumCommands) 1, (object) null, (object) null);
    }
    if (control.Name == this.btn_move_left.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarbleCountertopSlat) this).\u0001((object) (MarbleCadCamCommands) 9, (object) this.spn_moveval.Value, (object) (MarbleVacuumCommands) 1, (object) null, (object) null);
    }
    if (control.Name == this.btn_move_up.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarbleCountertopSlat) this).\u0001((object) (MarbleCadCamCommands) 12, (object) this.spn_moveval.Value, (object) (MarbleVacuumCommands) 1, (object) null, (object) null);
    }
    if (control.Name == this.btn_move_down.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarbleCountertopSlat) this).\u0001((object) (MarbleCadCamCommands) 13, (object) this.spn_moveval.Value, (object) (MarbleVacuumCommands) 1, (object) null, (object) null);
    }
    if (control.Name == ((F_MarbleCountertopSlat) this).btn_move_right.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarbleCountertopSlat) this).\u0001((object) (MarbleCadCamCommands) 14, (object) this.spn_moveval.Value, (object) (MarbleVacuumCommands) 1, (object) null, (object) null);
    }
    if (control.Name == this.btn_move_rightdown.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarbleCountertopSlat) this).\u0001((object) (MarbleCadCamCommands) 16 /*0x10*/, (object) this.spn_moveval.Value, (object) (MarbleVacuumCommands) 1, (object) null, (object) null);
    }
    if (!(control.Name == this.btn_move_rightup.Name))
      return;
    // ISSUE: reference to a compiler-generated field
    ((F_MarbleCountertopSlat) this).\u0001((object) (MarbleCadCamCommands) 15, (object) this.spn_moveval.Value, (object) (MarbleVacuumCommands) 1, (object) null, (object) null);
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleCountertopSlat) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleCountertopSlat) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleCountertopSlat) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    buSpin buSpin = obj0 as buSpin;
    if (!AppBool.TouchPad)
      return;
    F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString(), (IWin32Window) this);
    if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
    this.Focus();
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    // ISSUE: reference to a compiler-generated field
    ((F_MarbleCountertopSlat) this).\u0001((object) (MarbleCadCamCommands) 25, (object) ((F_MarblePhotoCalibration) this).lst_vacuumlist.SelectedIndex, (object) (MarbleVacuumCommands) 2, (object) null, (object) null);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleCountertopSlat) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleCountertopSlat) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleEdgeAngleList() => F_MarbleCountertopSlat.Captions = new List<string>();
}
