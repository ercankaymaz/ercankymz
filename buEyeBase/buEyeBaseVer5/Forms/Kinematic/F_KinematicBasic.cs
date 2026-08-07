// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Kinematic.F_KinematicBasic
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms.Library;
using buEyeBaseVer5.Forms.Machine;
using buEyeBaseVer5.Forms.Marble;
using buMutliTextbox;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Kinematic;

public class F_KinematicBasic : Form
{
  public buLabel lbl_machinea;
  public buTrack track_quickspeed;
  public buLabel lbl_parta;
  public buLabel lbl_operationspeed;
  public buTrack track_operationspeed;
  public buLabel lbl_machinez;
  public buButton btn_start;
  public buLabel lbl_partz;
  public buButton btn_pause;
  public buButton btn_water;
  public buLabel lbl_machiney;
  public buButton btn_spindlemain;
  public buLabel lbl_party;
  public buButton btn_stop;
  public buLabel lbl_machinex;
  public buLabel lbl_partx;
  public Panel pnl_controls;
  public buMultiTextBox txt_gcode;
  private IContainer \u0001;
  public buButton btn_park;
  public buButton btn_cminus;
  public buButton btn_100;
  public buButton btn_camera;
  public buCheckBox chk_absolute;
  public buButton btn_0_01;
  public buButton btn_cplus;
  public buButton btn_homing;
  public buButton btn_yplus;
  public buCheckBox chk_incremental;
  public buButton btn_10;
  public buCheckBox chk_addsawthickness;
  public buButton btn_xminus;
  public buLabel lbl_presetvalues;
  public buButton btn_stopmanuel;
  public buButton btn_zplus;
  public buButton btn_5;
  public buSpin spn_go;
  public buButton btn_xplus;
  public buButton btn_zminus;
  public buButton btn_aminus;
  public buButton btn_0_1;
  public buButton btn_1;
  public buButton btn_aplus;
  public buButton btn_yminus;
  public Panel pnl_controls;
  private IContainer \u0001;
  public buButton btn_hydrolic;
  public buButton btn_sand;
  public buButton btn_motor;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MachineGCodeCfg) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MachineGCodeCfg) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_KinematicBasic() => F_MachineGCodeCfg.Captions = new List<string>();

  public F_KinematicBasic()
  {
    ((F_SketchLibrary) this).Properties = new FormProperties();
    ((F_SketchLibrary) this).varOperation = (MarbleItemSettings) new buLogMarbleVer5();
    ((F_SketchLibrary) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleContourAdvancedSettings) this);
  }

  public void Init()
  {
    ((F_SketchLibrary) this).Properties.Inited = false;
    if (((F_SketchLibrary) this).Properties.Height > 10)
      this.Height = ((F_SketchLibrary) this).Properties.Height;
    if (((F_SketchLibrary) this).Properties.Width > 10)
      this.Width = ((F_SketchLibrary) this).Properties.Width;
    this.TopMost = ((F_SketchLibrary) this).Properties.TopMost;
    this.StartPosition = ((F_SketchLibrary) this).Properties.FormPosition;
    ((F_SketchLibrary) this).Properties.Result = DialogResult.None;
    ((F_SketchLibrary) this).chk_outsideentityreferance.Check = ((marbleProfileCurveCutPars) MarbleRuntimeSettings.varMarbleSettings).OutsideEntityIsReferance;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleContourAdvancedSettings) this);
    ((F_SketchLibrary) this).Properties.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_SketchLibrary) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_SketchLibrary) this).Properties.Result = DialogResult.Cancel;
    if (((F_SketchLibrary) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_SketchLibrary) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_SketchLibrary) this).btn_ok.Name)
      {
        \u001F.\u0002.\u0001((F_MarbleContourAdvancedSettings) this);
        ((F_SketchLibrary) this).Properties.Result = DialogResult.OK;
        if (((F_SketchLibrary) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_SketchLibrary) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_SketchLibrary) this).btn_cancel.Name | control2.Name == ((F_SketchLibrary) this).\u0001.Name))
        return;
      ((F_SketchLibrary) this).Properties.Result = DialogResult.Cancel;
      if (((F_SketchLibrary) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_SketchLibrary) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_SketchLibrary) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_SketchLibrary) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_KinematicBasic() => F_SketchLibrary.Captions = new List<string>();

  public F_KinematicBasic()
  {
    ((F_SketchLibrary) this).Properties = new FormProperties();
    ((F_SketchLibrary) this).varOperation = (MarbleItemSettings) new buLogMarbleVer5();
    ((F_SketchLibrary) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleSawContourSettings) this);
  }
}
