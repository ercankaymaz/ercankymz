// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleToolAndStrategyMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleToolAndStrategyMenu : Form
{
  internal buLabel \u0083;
  internal Panel \u0005;
  internal RadioButton \u0015;
  internal RadioButton \u0016;
  internal buLabel \u0084;
  internal RadioButton \u0017;
  internal buSeparator \u0001;
  internal buLabel \u0086;
  public buCheckBox chk_automagnet;
  public buCheckBox chk_HorizontalLeftToRight;
  public buCheckBox chk_VerticalBackToFront;
  public buCheckBox chk_OutsideContourLeadInOutForArc;
  public buCheckBox chk_circularfirst;
  public buCheckBox chk_insidefirst;
  public buCheckBox chk_A45First;
  public buCheckBox chk_autowater;
  internal Panel \u0006;
  internal RadioButton \u0018;
  internal buLabel \u0087;
  internal RadioButton \u0019;
  internal Panel \u0007;
  internal RadioButton \u001A;
  internal buLabel \u0088;
  internal RadioButton \u001B;
  internal Panel \u0008;
  internal RadioButton \u001C;
  internal buLabel \u0089;
  internal RadioButton \u001D;
  public buSpin spn_OutsideContourLeadOut;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleCamSettings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleCamSettings) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleToolAndStrategyMenu() => F_MarbleCamSettings.Captions = new List<string>();

  public F_MarbleToolAndStrategyMenu()
  {
    ((F_MarbleCamSettings) this).SpinBaseColor = Color.LightGreen;
    ((F_MarbleCamSettings) this).SpinFocusColor = Color.MistyRose;
    ((F_MarbleCamSettings) this).Settings = (MarbleItemSettings) new buLogMarbleVer5();
    ((F_MarbleCamSettings) this).PropertiesForm = new FormProperties();
    ((F_MarbleCamSettings) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleSawCutParameters) this);
  }

  public void Init()
  {
    ((F_MarbleCamSettings) this).PropertiesForm.Inited = false;
    if (((F_MarbleCamSettings) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleCamSettings) this).PropertiesForm.Height;
    if (((F_MarbleCamSettings) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleCamSettings) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleCamSettings) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleCamSettings) this).PropertiesForm.FormPosition;
    ((F_MarbleCamSettings) this).spn_bwdvel.Value = ((marbleEdgeItem) ((MarbleMachineSimultionSettings) ((F_MarbleCamSettings) this).Settings).settingMarbleCam).SawBackwardCuttingVelocity;
    ((F_MarbleCamSettings) this).spn_fwdvel.Value = ((marbleEdgeItem) ((MarbleMachineSimultionSettings) ((F_MarbleCamSettings) this).Settings).settingMarbleCam).SawForwardCuttingVelocity;
    ((F_MarbleCamSettings) this).spn_plungevel.Value = ((marbleCollapseItem) ((MarbleMachineSimultionSettings) ((F_MarbleCamSettings) this).Settings).settingMarbleCam).SawPlungeVelocity;
    ((F_MarbleCamSettings) this).spn_leavevel.Value = ((marbleCollapseItem) ((MarbleMachineSimultionSettings) ((F_MarbleCamSettings) this).Settings).settingMarbleCam).SawLeaveVelocity;
    ((F_MarbleCamSettings) this).spn_matthickness.Value = ((MarbleCamType) ((MarbleMachineSimultionSettings) ((F_MarbleCamSettings) this).Settings).MaterialParameter).MaterialThickness;
    ((F_MarbleCamSettings) this).spn_forwardcutstep.Value = ((marbleEdgeItem) ((MarbleMachineSimultionSettings) ((F_MarbleCamSettings) this).Settings).settingMarbleCam).SawForwardStepDownDistance;
    ((F_MarbleCamSettings) this).spn_safedistance.Value = ((marbleCollapseItem) ((MarbleMachineSimultionSettings) ((F_MarbleCamSettings) this).Settings).settingMarbleCam).SawSafeDistance;
    ((F_MarbleCamSettings) this).spn_sliceoffset.Value = ((MarbleCountertopActiveModes) ((MarbleMachineSimultionSettings) ((F_MarbleCamSettings) this).Settings).settingSliceCut).SliceOffset;
    ((F_MarbleCamSettings) this).chk_RotateCForReverseDirection.Check = ((MarbleCountertopActiveModes) ((MarbleMachineSimultionSettings) ((F_MarbleCamSettings) this).Settings).settingSliceCut).RotateCForReverseDirection;
    if (((MarbleCountertopActiveModes) ((MarbleMachineSimultionSettings) ((F_MarbleCamSettings) this).Settings).settingSliceCut).SliceDirection == CamCuttingDirectionType.Forward)
    {
      ((F_MarbleCamSettings) this).\u0001.Checked = true;
      ((F_MarbleCamSettings) this).\u0002.Checked = false;
    }
    else
    {
      ((F_MarbleCamSettings) this).\u0001.Checked = false;
      ((F_MarbleCamSettings) this).\u0002.Checked = true;
    }
    if (((MarbleCountertopActiveModes) ((MarbleMachineSimultionSettings) ((F_MarbleCamSettings) this).Settings).settingSliceCut).HorizontalVerticalSequence == HorizontalVertical.Horizontal)
    {
      ((F_MarbleCamSettings) this).\u0003.Checked = true;
      ((F_MarbleCamSettings) this).\u0004.Checked = false;
    }
    else
    {
      ((F_MarbleCamSettings) this).\u0003.Checked = false;
      ((F_MarbleCamSettings) this).\u0004.Checked = true;
    }
    this.LoadLanguage();
    ((F_MarbleCamSettings) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleCamSettings) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleCamSettings) this).\u0001.Text = buLangTranslate.preDef.Settings;
      ((F_MarbleCamSettings) this).spn_fwdvel.Caption.Caption = $"{buLangTranslate.preDef.Forward} {buLangTranslate.preDef.Direction} {buLangTranslate.preDef.Velocity}";
      ((F_MarbleCamSettings) this).spn_bwdvel.Caption.Caption = $"{buLangTranslate.preDef.Backward} {buLangTranslate.preDef.Direction} {buLangTranslate.preDef.Velocity}";
      ((F_MarbleCamSettings) this).spn_plungevel.Caption.Caption = $"{buLangTranslate.preDef.Plunge} {buLangTranslate.preDef.Velocity}";
      ((F_MarbleCamSettings) this).spn_leavevel.Caption.Caption = $"{buLangTranslate.preDef.Leave} {buLangTranslate.preDef.Velocity}";
      ((F_MarbleCamSettings) this).spn_forwardcutstep.Caption.Caption = $"{buLangTranslate.preDef.Forward} {buLangTranslate.preDef.Cutting} {buLangTranslate.preDef.Step}";
      ((F_MarbleCamSettings) this).spn_matthickness.Caption.Caption = $"{buLangTranslate.preDef.Material} {buLangTranslate.preDef.Thickness}";
      ((F_MarbleCamSettings) this).spn_safedistance.Caption.Caption = buLangTranslate.preDef.SafeDistance;
      ((F_MarbleCamSettings) this).spn_sliceoffset.Caption.Caption = $"{buLangTranslate.preDef.Slice} {buLangTranslate.preDef.Offset}";
      ((F_MarbleCamSettings) this).\u0001.Text = $"{buLangTranslate.preDef.Cutting} {buLangTranslate.preDef.Direction}";
      ((F_MarbleCamSettings) this).\u0001.Text = buLangTranslate.preDef.Ok;
      ((F_MarbleCamSettings) this).\u0002.Text = buLangTranslate.preDef.Cancel;
    }
    catch (Exception ex)
    {
    }
  }

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

  internal void \u0001([In] object obj0, [In] KeyEventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (!(obj1.KeyCode == Keys.Return | obj1.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(((F_MarbleCamSettings) this).\u0001.Controls, result, obj1.Shift);
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
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
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((marbleEdgeItem) ((MarbleMachineSimultionSettings) ((F_MarbleCamSettings) this).Settings).settingMarbleCam).SawBackwardCuttingVelocity = ((F_MarbleCamSettings) this).spn_bwdvel.Value;
    ((marbleEdgeItem) ((MarbleMachineSimultionSettings) ((F_MarbleCamSettings) this).Settings).settingMarbleCam).SawForwardCuttingVelocity = ((F_MarbleCamSettings) this).spn_fwdvel.Value;
    ((marbleCollapseItem) ((MarbleMachineSimultionSettings) ((F_MarbleCamSettings) this).Settings).settingMarbleCam).SawPlungeVelocity = ((F_MarbleCamSettings) this).spn_plungevel.Value;
    ((marbleCollapseItem) ((MarbleMachineSimultionSettings) ((F_MarbleCamSettings) this).Settings).settingMarbleCam).SawLeaveVelocity = ((F_MarbleCamSettings) this).spn_leavevel.Value;
    ((MarbleCamType) ((MarbleMachineSimultionSettings) ((F_MarbleCamSettings) this).Settings).MaterialParameter).MaterialThickness = ((F_MarbleCamSettings) this).spn_matthickness.Value;
    ((marbleEdgeItem) ((MarbleMachineSimultionSettings) ((F_MarbleCamSettings) this).Settings).settingMarbleCam).SawForwardStepDownDistance = ((F_MarbleCamSettings) this).spn_forwardcutstep.Value;
    ((marbleCollapseItem) ((MarbleMachineSimultionSettings) ((F_MarbleCamSettings) this).Settings).settingMarbleCam).SawSafeDistance = ((F_MarbleCamSettings) this).spn_safedistance.Value;
    ((MarbleCountertopActiveModes) ((MarbleMachineSimultionSettings) ((F_MarbleCamSettings) this).Settings).settingSliceCut).SliceOffset = ((F_MarbleCamSettings) this).spn_sliceoffset.Value;
    ((MarbleCountertopActiveModes) ((MarbleMachineSimultionSettings) ((F_MarbleCamSettings) this).Settings).settingSliceCut).RotateCForReverseDirection = ((F_MarbleCamSettings) this).chk_RotateCForReverseDirection.Check;
    if (((F_MarbleCamSettings) this).\u0001.Checked)
      ((MarbleCountertopActiveModes) ((MarbleMachineSimultionSettings) ((F_MarbleCamSettings) this).Settings).settingSliceCut).SliceDirection = CamCuttingDirectionType.Forward;
    else
      ((MarbleCountertopActiveModes) ((MarbleMachineSimultionSettings) ((F_MarbleCamSettings) this).Settings).settingSliceCut).SliceDirection = CamCuttingDirectionType.ForwardBackward;
    if (((F_MarbleCamSettings) this).\u0003.Checked)
      ((MarbleCountertopActiveModes) ((MarbleMachineSimultionSettings) ((F_MarbleCamSettings) this).Settings).settingSliceCut).HorizontalVerticalSequence = HorizontalVertical.Horizontal;
    else
      ((MarbleCountertopActiveModes) ((MarbleMachineSimultionSettings) ((F_MarbleCamSettings) this).Settings).settingSliceCut).HorizontalVerticalSequence = HorizontalVertical.Vertical;
    ((F_MarbleCamSettings) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_MarbleCamSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleCamSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleCamSettings) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleCamSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleCamSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
    ((buControl) obj0).Display.BackColor = ((F_MarbleCamSettings) this).SpinFocusColor;
  }

  internal void \u0005([In] object obj0, [In] EventArgs obj1)
  {
    ((buControl) obj0).Display.BackColor = ((F_MarbleCamSettings) this).SpinBaseColor;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleCamSettings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleCamSettings) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleToolAndStrategyMenu() => F_MarbleCamSettings.Captions = new List<string>();

  public F_MarbleToolAndStrategyMenu()
  {
    ((F_MarbleCamSettings) this).PropertiesForm = new FormProperties();
    ((F_MarbleCamSettings) this).Chamfer = (marbleChamferBothSidePars) new \u0007.\u0001();
    ((F_MarbleCamSettings) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleCountertopChamfer) this);
  }

  public void Init()
  {
    ((F_MarbleCamSettings) this).PropertiesForm.Inited = false;
    if (((F_MarbleCamSettings) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleCamSettings) this).PropertiesForm.Height;
    if (((F_MarbleCamSettings) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleCamSettings) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleCamSettings) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleCamSettings) this).PropertiesForm.FormPosition;
    ((F_MarbleCamSettings) this).spn_chamferbottomangle.Value = ((MarbleMotionCommands) ((MarbleHMICommands) ((F_MarbleCamSettings) this).Chamfer).DataChamfer).BottomAngle;
    ((F_MarbleCamSettings) this).spn_chamferbottomheiht.Value = ((MarbleMotionCommands) ((MarbleHMICommands) ((F_MarbleCamSettings) this).Chamfer).DataChamfer).BottomHeight;
    ((F_MarbleCamSettings) this).spn_chamfertopangle.Value = ((MarbleMotionCommands) ((MarbleHMICommands) ((F_MarbleCamSettings) this).Chamfer).DataChamfer).TopAngle;
    ((F_MarbleCamSettings) this).spn_chamfertopheight.Value = ((MarbleMotionCommands) ((MarbleHMICommands) ((F_MarbleCamSettings) this).Chamfer).DataChamfer).TopHeight;
    ((F_MarbleCamSettings) this).chk_bottomchamfer.Check = ((MarbleMotionCommands) ((MarbleHMICommands) ((F_MarbleCamSettings) this).Chamfer).DataChamfer).BottomEnable;
    ((F_MarbleCamSettings) this).chk_topchamfer.Check = ((MarbleMotionCommands) ((MarbleHMICommands) ((F_MarbleCamSettings) this).Chamfer).DataChamfer).TopEnable;
    ((F_MarbleCamSettings) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleCamSettings) this).PropertiesForm.Inited = true;
    \u0007.\u0001.\u0001((F_MarbleCountertopChamfer) this);
  }

  public event OkCommandWithFiveDataEventHandler CommandExecute;
}
