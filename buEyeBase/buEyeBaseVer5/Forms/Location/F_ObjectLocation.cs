// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Location.F_ObjectLocation
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls;
using buControls.Controls;
using buCore;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms.Marble;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Location;

public class F_ObjectLocation : Form
{
  public buButton btn_ok;
  public buButton btn_cancel;
  public buSpin spn_roughsafedistance;
  public buSpin spn_roughrapiddistance;
  internal buTab \u0001;
  internal TabPage \u0001;
  internal TabPage \u0002;
  internal buLabel \u0001;
  public buSpin spn_roughsteplen;
  internal TabPage \u0003;
  internal TabPage \u0004;
  internal TabPage \u0005;
  internal buLabel \u0002;
  public buSpin spn_finishsafedistance;
  public buSpin spn_finishrapiddis;
  public buSpin spn_finishplungevel;
  public buSpin spn_finishcuttingvel;
  public buSpin spn_constantZsteplen;
  internal buLabel \u0003;
  public buSpin spn_constantZsafedis;
  public buSpin spn_constantZrapiddis;
  public buSpin spn_constantZplungevel;
  public buSpin spn_constantZcuttingvel;
  internal buLabel \u0004;
  public buSpin spn_flatlandsafedis;

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleEngraveCamSetting) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleEngraveCamSetting) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleEngraveCamSetting) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleEngraveCamSetting) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleEngraveCamSetting) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ObjectLocation() => F_MarbleEngraveCamSetting.Captions = new List<string>();

  public F_ObjectLocation()
  {
    ((F_MarbleSawContourSettings) this).SpinBaseColor = Color.LightGreen;
    ((F_MarbleSawContourSettings) this).SpinFocusColor = Color.MistyRose;
    ((F_MarbleSawContourSettings) this).Settings = (MarbleItemSettings) new buLogMarbleVer5();
    ((F_MarbleSawContourSettings) this).PropertiesForm = new FormProperties();
    ((F_MarbleSawContourSettings) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_ItemCutCamParameters) this);
  }

  public void Init()
  {
    ((F_MarbleSawContourSettings) this).PropertiesForm.Inited = false;
    if (((F_MarbleSawContourSettings) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleSawContourSettings) this).PropertiesForm.Height;
    if (((F_MarbleSawContourSettings) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleSawContourSettings) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleSawContourSettings) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleSawContourSettings) this).PropertiesForm.FormPosition;
    ((F_MarbleProfileSettings) this).spn_bwdvel.Value = ((marbleEdgeItem) ((MarbleMachineSimultionSettings) ((F_MarbleSawContourSettings) this).Settings).settingMarbleCam).SawBackwardCuttingVelocity;
    ((F_MarbleProfileSettings) this).spn_fwdvel.Value = ((marbleEdgeItem) ((MarbleMachineSimultionSettings) ((F_MarbleSawContourSettings) this).Settings).settingMarbleCam).SawForwardCuttingVelocity;
    ((F_MarbleProfileSettings) this).spn_plungevel.Value = ((marbleCollapseItem) ((MarbleMachineSimultionSettings) ((F_MarbleSawContourSettings) this).Settings).settingMarbleCam).SawPlungeVelocity;
    ((F_MarbleProfileSettings) this).spn_matthickness.Value = ((MarbleCamType) ((MarbleMachineSimultionSettings) ((F_MarbleSawContourSettings) this).Settings).MaterialParameter).MaterialThickness;
    ((F_MarbleProfileSettings) this).spn_forwardcutstep.Value = ((marbleEdgeItem) ((MarbleMachineSimultionSettings) ((F_MarbleSawContourSettings) this).Settings).settingMarbleCam).SawForwardStepDownDistance;
    ((F_MarbleProfileSettings) this).spn_backwardcutstep.Value = ((marbleEdgeItem) ((MarbleMachineSimultionSettings) ((F_MarbleSawContourSettings) this).Settings).settingMarbleCam).SawBackwardStepDownDistance;
    ((F_MarbleProfileSettings) this).spn_safedistance.Value = ((marbleCollapseItem) ((MarbleMachineSimultionSettings) ((F_MarbleSawContourSettings) this).Settings).settingMarbleCam).SawSafeDistance;
    ((F_CornerLocation) this).LoadLanguage();
    ArrayList EnumItems = new ArrayList();
    buGeneral.GetEnumTypeValues((object) ((marbleSlatPars) ((MarbleMachineSimultionSettings) ((F_MarbleSawContourSettings) this).Settings).settingMarbleCam).CuttingDirection, ref EnumItems);
    buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32((object) ((marbleSlatPars) ((MarbleMachineSimultionSettings) ((F_MarbleSawContourSettings) this).Settings).settingMarbleCam).CuttingDirection), ref ((F_MarbleProfileSettings) this).cmb_cutdir);
    ((F_MarbleSawContourSettings) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleSawContourSettings) this).PropertiesForm.Inited = true;
  }
}
