// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleHorVerCutV4
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleHorVerCutV4 : Form
{
  public buSpin spn_roughfwdcuttingfeed;
  public buSpin spn_roughplungefeed;
  public buSpin spn_roughbottomoffset;
  public buCheckBox chk_finishreverseC;
  public buCheckBox chk_roughreverseC;
  public buSpin spn_finishbottomoffset;
  public buSpin spn_finishtopoffet;
  public buSpin spn_roughzdownstep;
  public buSpin spn_roughstepoverXY;
  internal buLabel \u0003;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal TabPage \u0003;
  internal buLabel \u0004;
  public buSpin spn_offsetedgeoffsey;
  public buCheckBox chk_offsetcutedges;
  public buCheckBox chk_offsetcutoutside;
  public buCheckBox chk_offsetcutinside;
  public buSpin spn_offsetzdownstep;
  public buSpin spn_offsetoutsideoffset;
  public buSpin spn_offsetinsideoffset;
  public buCheckBox chk_offsetreverseC;
  public buSpin spn_offsetleadoutangle;
  public buSpin spn_offsetleadinangle;
  public buSpin spn_offsetbackwardcuttingspeed;
  public buSpin spn_offsetforwardcuttingspeed;
  public buSpin spn_offsetplungefeed;
  public buSpin spn_offsetsafedistance;
  public buSpin spn_offsetstepangle;
  public buSpin spn_offsetminZHeight;
  public buCheckBox chk_offsetzigzag;
  public buSpin spn_offsetAAngle;
  public buCheckBox chk_finishmoveupsafe;
  internal buPanel \u0001;
  internal buPanel \u0002;
  public buButton btn_closeadvanced;
  public buButton btn_color;

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleProfileCurveCam) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleProfileCurveCam) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleProfileCurveCam) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleProfileCurveCam) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleProfileCurveCam) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleProfileCurveCam) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleProfileCurveCam) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleProfileCurveCam) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleProfileCurveCam) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleHorVerCutV4() => F_MarbleProfileCurveCam.Captions = new List<string>();

  public F_MarbleHorVerCutV4()
  {
    // ISSUE: unable to decompile the method.
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleProfileCurveCam) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleProfileCurveCam) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleProfileCurveCam) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleProfileCurveCam) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }
}
