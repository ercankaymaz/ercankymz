// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.KeyPad.Form1
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms.Library;
using buEyeBaseVer5.Forms.Marble;
using dummy_ptr;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.KeyPad;

public class Form1 : Form
{
  public buButton btn_valve;
  public buButton btn_water;
  public Panel pnl_controls;
  public buLabel lbl_sandspeed;
  public buTrack track_sandspeed;

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
    ((F_SketchLibrary) this).spn_Targetz.Value = ((marbleEdgeItem) ((MarbleMachineSimultionSettings) ((F_SketchLibrary) this).varOperation).settingMarbleCam).TargetZ;
    ((F_SketchLibrary) this).spn_safedis.Value = ((marbleCollapseItem) ((MarbleMachineSimultionSettings) ((F_SketchLibrary) this).varOperation).settingMarbleCam).SawSafeDistance;
    ((F_SketchLibrary) this).spn_backwardstep.Value = ((marbleEdgeItem) ((MarbleMachineSimultionSettings) ((F_SketchLibrary) this).varOperation).settingMarbleCam).SawBackwardStepDownDistance;
    ((F_SketchLibrary) this).spn_forwardstep.Value = ((marbleEdgeItem) ((MarbleMachineSimultionSettings) ((F_SketchLibrary) this).varOperation).settingMarbleCam).SawForwardStepDownDistance;
    ((F_SketchLibrary) this).spn_rapiddis.Value = ((marbleCollapseItem) ((MarbleMachineSimultionSettings) ((F_SketchLibrary) this).varOperation).settingMarbleCam).SawRapidDistance;
    ((F_SketchLibrary) this).spn_plungevel.Value = ((marbleCollapseItem) ((MarbleMachineSimultionSettings) ((F_SketchLibrary) this).varOperation).settingMarbleCam).SawPlungeVelocity;
    ((F_SketchLibrary) this).spn_forwardvel.Value = ((marbleEdgeItem) ((MarbleMachineSimultionSettings) ((F_SketchLibrary) this).varOperation).settingMarbleCam).SawForwardCuttingVelocity;
    ((F_SketchLibrary) this).spn_backwardvel.Value = ((marbleEdgeItem) ((MarbleMachineSimultionSettings) ((F_SketchLibrary) this).varOperation).settingMarbleCam).SawBackwardCuttingVelocity;
    ((F_SketchLibrary) this).spn_materialthickness.Value = ((MarbleCamType) ((MarbleMachineSimultionSettings) ((F_SketchLibrary) this).varOperation).MaterialParameter).MaterialThickness;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleSawContourSettings) this);
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
        \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleSawContourSettings) this);
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

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    buSpin buSpin = obj0 as buSpin;
    if (!AppBool.TouchPad)
      return;
    buControls.Forms.buControlForms.KeyPad.F_KeyPadNumV1 fKeyPadNumV1 = new buControls.Forms.buControlForms.KeyPad.F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
    if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }
}
