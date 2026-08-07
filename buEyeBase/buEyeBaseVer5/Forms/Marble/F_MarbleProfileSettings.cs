// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleProfileSettings
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

public class F_MarbleProfileSettings : Form
{
  internal buGround \u0001;
  internal buButton \u0001;
  internal buButton \u0002;
  internal buButton \u0003;
  public buSpin spn_bwdvel;
  public buSpin spn_fwdvel;
  public buSpin spn_plungevel;
  public buSpin spn_matthickness;
  public buSpin spn_leavevel;
  public buSpin spn_backwardcutstep;
  public buSpin spn_forwardcutstep;
  public buSpin spn_safedistance;
  public buComboBox cmb_cutdir;
  public static byte f002B8F;
  public static List<string> Captions;
  private IContainer \u0001;
  public buSpin spn_lengthHor;
  public buSpin spn_itemEA5;
  public buSpin spn_itemSA5;
  public buSpin spn_itemcount5;
  public buSpin spn_itemlen5;
  public buSpin spn_itemEA4;
  public buSpin spn_itemSA4;
  public buSpin spn_itemcount4;
  public buSpin spn_itemlen4;
  public buSpin spn_itemEA3;
  public buSpin spn_itemSA3;
  public buSpin spn_itemcount3;
  public buSpin spn_itemlen3;
  public buSpin spn_itemEA2;
  public buSpin spn_itemSA2;
  public buSpin spn_itemcount2;
  public buSpin spn_itemlen2;
  public buSpin spn_itemEA1;
  public buSpin spn_itemSA1;
  public buSpin spn_itemcount1;
  public buSpin spn_itemlen1;
  public buButton buButton1;
  public buButton btn_maximize;

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleTools) this).btn_ok.Name)
      {
        \u0007.\u0001.\u0001((F_MarbleLathe) this);
        ((F_MarbleTools) this).Properties.Result = DialogResult.OK;
        if (((F_MarbleTools) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleTools) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_MarbleTools) this).btn_cancel.Name))
        return;
      ((F_MarbleTools) this).Properties.Result = DialogResult.Cancel;
      if (((F_MarbleTools) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleTools) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
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
    F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
    if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }

  internal void \u0001([In] object obj0, [In] bool obj1)
  {
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    buCheckBox buCheckBox = obj0 as buCheckBox;
    ((F_MarbleTools) this).chk_maxtomin.Check = false;
    ((F_ItemCutCamParameters) this).chk_midtoleft.Check = false;
    ((F_MarbleTools) this).chk_midtoright.Check = false;
    ((F_ItemCutCamParameters) this).chk_mintomax.Check = false;
    buCheckBox.Check = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleTools) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleTools) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleProfileSettings() => F_MarbleTools.Captions = new List<string>();

  public F_MarbleProfileSettings()
  {
    ((F_ItemCutCamParameters) this).Properties = new FormProperties();
    ((F_ItemCutCamParameters) this).varProfileCut = (marbleProfileCutPars) new \u0007.\u0001();
    ((F_ItemCutCamParameters) this).strMessageRoughtFinish = "Rought and  Finish Both Can't be Enabled";
    ((F_ItemCutCamParameters) this).strMessageRoughtFinishSelect = "Rought or Finish One of them must be Selected";
    ((F_ItemCutCamParameters) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleProfileCut) this);
  }

  public void Init()
  {
    ((F_ItemCutCamParameters) this).Properties.Inited = false;
    if (((F_ItemCutCamParameters) this).Properties.Height > 10)
      this.Height = ((F_ItemCutCamParameters) this).Properties.Height;
    if (((F_ItemCutCamParameters) this).Properties.Width > 10)
      this.Width = ((F_ItemCutCamParameters) this).Properties.Width;
    this.TopMost = ((F_ItemCutCamParameters) this).Properties.TopMost;
    this.StartPosition = ((F_ItemCutCamParameters) this).Properties.FormPosition;
    ((F_ItemCutCamParameters) this).Properties.Result = DialogResult.None;
    ((F_ItemCutCamParameters) this).Properties.Inited = true;
    ((F_MarbleHorizontalCut) this).\u0002.Checked = ((CounterTopFormImageIndex) ((F_ItemCutCamParameters) this).varProfileCut).FinishEnable;
    ((F_MarbleHorizontalCut) this).\u0001.Checked = ((MarbleCamParameterSetArg) ((F_ItemCutCamParameters) this).varProfileCut).RoughEnable;
    ((F_MarbleHorizontalCut) this).\u0003.Checked = ((MarbleProfileCalcParameters) ((F_ItemCutCamParameters) this).varProfileCut).MaxToMinDirection;
    ((F_MarbleHorizontalCut) this).\u0005.Checked = ((CounterTopFormImageIndex) ((F_ItemCutCamParameters) this).varProfileCut).FinishZigzagMode;
    ((F_MarbleHorizontalCut) this).\u0004.Checked = ((MarbleCamParameterSetArg) ((F_ItemCutCamParameters) this).varProfileCut).RoughZigzagMode;
    ((F_MarbleHorizontalCut) this).\u0006.Checked = ((MarbleProfileCalcParameters) ((F_ItemCutCamParameters) this).varProfileCut).MoveSafeDistanceForFinishZigzagMode;
    ((F_MarbleHorizontalCut) this).\u0007.Checked = ((MarbleProfileCalcParameters) ((F_ItemCutCamParameters) this).varProfileCut).MoveSafeDistanceForFinishZigzagMode;
    ((F_MarbleHorizontalCut) this).\u000F.Value = (Decimal) ((CounterTopDrawEventArg) ((F_ItemCutCamParameters) this).varProfileCut).RotationAngle;
    ((F_MarbleHorizontalCut) this).\u0010.Value = (Decimal) ((AddSlatArgs) ((F_ItemCutCamParameters) this).varProfileCut).RoughMinZ;
    ((F_MarbleHorizontalCut) this).\u0011.Value = (Decimal) ((CounterTopFormImageIndex) ((F_ItemCutCamParameters) this).varProfileCut).FinishMinZ;
    ((F_MarbleHorizontalCut) this).\u0006.Value = (Decimal) ((buLogMarbleVer5) ((F_ItemCutCamParameters) this).varProfileCut).StartPosition;
    ((F_MarbleHorizontalCut) this).\u0002.Value = (Decimal) ((buLogMarbleVer5) ((F_ItemCutCamParameters) this).varProfileCut).BaseHeight;
    ((F_ItemCutCamParameters) this).\u0001.Value = (Decimal) ((buLogMarbleVer5) ((F_ItemCutCamParameters) this).varProfileCut).Length;
    ((F_MarbleHorizontalCut) this).\u0003.Value = (Decimal) ((CounterTopFormImageIndex) ((F_ItemCutCamParameters) this).varProfileCut).FinishStep;
    ((F_MarbleHorizontalCut) this).\u0004.Value = (Decimal) ((AddSlatArgs) ((F_ItemCutCamParameters) this).varProfileCut).RoughSurfOffset;
    ((F_MarbleHorizontalCut) this).\u0005.Value = (Decimal) ((CounterTopFormImageIndex) ((F_ItemCutCamParameters) this).varProfileCut).FinishSurfOffset;
    ((F_MarbleHorizontalCut) this).\u000E.Value = (Decimal) ((AddSlatArgs) ((F_ItemCutCamParameters) this).varProfileCut).RoughDevideLen;
    ((F_MarbleHorizontalCut) this).\u0008.Value = (Decimal) ((CounterTopFormImageIndex) ((F_ItemCutCamParameters) this).varProfileCut).FinishDevideLen;
    ((F_MarbleHorizontalCut) this).\u0001.Checked = true;
    if (((MarbleSawCalcParameters) ((F_ItemCutCamParameters) this).varProfileCut).CamTypeRough == CamAxisCountType.Axis3)
      ((F_MarbleHorizontalCut) this).\u0003.Checked = true;
    else
      ((F_MarbleHorizontalCut) this).\u0002.Checked = true;
    if (((MarbleSawCalcParameters) ((F_ItemCutCamParameters) this).varProfileCut).CamTypeFinish == CamAxisCountType.Axis3)
      ((F_MarbleHorizontalCut) this).\u0005.Checked = true;
    else
      ((F_MarbleHorizontalCut) this).\u0004.Checked = true;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleProfileCut) this);
  }
}
