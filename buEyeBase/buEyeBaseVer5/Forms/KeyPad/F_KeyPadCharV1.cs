// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.KeyPad.F_KeyPadCharV1
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms.Layer;
using buEyeBaseVer5.Forms.Library;
using buEyeBaseVer5.Forms.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.KeyPad;

public class F_KeyPadCharV1 : Form
{
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public double ReturnVal;
  public double Preset1;
  public double Preset2;
  public double Preset3;
  public double Preset4;
  public double Preset5;
  public double Preset6;
  public double Preset7;
  public double Preset8;
  public double Preset9;
  private IContainer \u0001;
  internal buPanel \u0001;
  internal buGround \u0001;
  public buButton btn_close;
  public buButton btn_preset9;
  public buButton btn_preset8;
  public buButton btn_preset7;
  public buButton btn_preset6;
  public buButton btn_preset5;
  public buButton btn_preset4;
  public buButton btn_preset3;
  public buButton btn_preset2;
  public buButton btn_preset1;
  private IContainer \u0001;
  public static List<string> Captions;
  public FormProperties Properties;
  public MachineOtherCodeInfo OtherCode;
  internal string \u0001;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal Label \u0001;
  internal Label \u0002;
  internal Label \u0003;
  internal TextBox \u0001;
  internal TextBox \u0002;
  public NumericUpDown spn_time;
  internal Label \u0004;
  internal TextBox \u0003;
  public static byte f002D9D;
  public static List<string> Captions;
  public FormProperties Properties;
  public MachineMCodeInfo MCode;
  internal string \u0001;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal Label \u0001;
  internal Label \u0002;
  internal Label \u0003;
  internal TextBox \u0001;
  internal TextBox \u0002;
  public NumericUpDown spn_time;
  internal Label \u0004;
  internal TextBox \u0003;
  public static byte f002DAE;
  public static List<string> Captions;
  public FormProperties Properties;
  public MachineAxisInfo Axis;
  internal string \u0001;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  public NumericUpDown spn_acc;
  internal Label \u0001;
  internal Label \u0002;
  public NumericUpDown spn_dec;
  internal Label \u0003;
  public NumericUpDown spn_jerk;
  internal Label \u0004;
  internal Label \u0005;
  internal TextBox \u0001;
  internal TextBox \u0002;
  public NumericUpDown spn_speed;
  internal Label \u0006;
  public static byte f002DC3;
  public FormProperties Properties;
  public static List<string> Captions;
  public MachineGCodeConfigrasyon GCodeCongif;
  internal string \u0001;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal ListBox \u0001;
  internal Label \u0001;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_SketchLibrary) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_SketchLibrary) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_KeyPadCharV1() => F_SketchLibrary.Captions = new List<string>();

  public F_KeyPadCharV1()
  {
    ((F_SketchLibrary) this).Properties = new FormProperties();
    ((F_LayerOptionList) this).varProfileCut = (marbleProfileCutPars) new \u0007.\u0001();
    ((F_LayerOptionList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleProfileSettings) this);
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
    ((F_LayerOptionList) this).spn_finishsafedis.Value = ((CounterTopCreateEventArg) ((F_LayerOptionList) this).varProfileCut).FinishSafeDis;
    ((F_LayerOptionList) this).spn_finishsurfoffset.Value = ((CounterTopFormImageIndex) ((F_LayerOptionList) this).varProfileCut).FinishSurfOffset;
    ((F_LayerOptionList) this).spn_finishstepdistance.Value = ((CounterTopFormImageIndex) ((F_LayerOptionList) this).varProfileCut).FinishStep;
    ((F_LayerOptionList) this).spn_finishminZ.Value = ((CounterTopFormImageIndex) ((F_LayerOptionList) this).varProfileCut).FinishMinZ;
    ((F_LayerOptionList) this).spn_finishrapiddis.Value = ((CounterTopFormImageIndex) ((F_LayerOptionList) this).varProfileCut).FinishRapid;
    ((F_LayerOptionList) this).spn_finishplungefeed.Value = ((CounterTopDrawEventArg) ((F_LayerOptionList) this).varProfileCut).FinishPlungeFeed;
    ((F_LayerOptionList) this).spn_finishfwdcutfeed.Value = ((CounterTopCreateEventArg) ((F_LayerOptionList) this).varProfileCut).FinishCutForwardFeed;
    ((F_LayerOptionList) this).spn_finishbwdcuttingfeed.Value = ((CounterTopCreateEventArg) ((F_LayerOptionList) this).varProfileCut).FinishCutBackwardFeed;
    ((F_LayerOptionList) this).spn_finishverticaldevide.Value = ((CounterTopFormImageIndex) ((F_LayerOptionList) this).varProfileCut).FinishVerticalDevideLen;
    ((F_LayerOptionList) this).spn_finishleadin.Value = ((CounterTopFormImageIndex) ((F_LayerOptionList) this).varProfileCut).FinishLeadIn;
    ((F_LayerOptionList) this).spn_finishleadout.Value = ((CounterTopFormImageIndex) ((F_LayerOptionList) this).varProfileCut).FinishLeadOut;
    ((F_LayerOptionList) this).chk_finishzigzag.Check = ((CounterTopFormImageIndex) ((F_LayerOptionList) this).varProfileCut).FinishZigzagMode;
    ((F_LayerOptionList) this).chk_finishperpendicularA.Check = ((CounterTopFormImageIndex) ((F_LayerOptionList) this).varProfileCut).FinishPerpendicularA;
    ((F_LayerOptionList) this).spn_roughsafedis.Value = ((EntityCommandArgs) ((F_LayerOptionList) this).varProfileCut).RoughSafeDis;
    ((F_LayerOptionList) this).spn_roughsurfoffset.Value = ((AddSlatArgs) ((F_LayerOptionList) this).varProfileCut).RoughSurfOffset;
    ((F_LayerOptionList) this).spn_roughminZ.Value = ((AddSlatArgs) ((F_LayerOptionList) this).varProfileCut).RoughMinZ;
    ((F_LayerOptionList) this).spn_roughrapiddis.Value = ((EntityCommandArgs) ((F_LayerOptionList) this).varProfileCut).RoughRapid;
    ((F_LayerOptionList) this).spn_roughplungefeed.Value = ((EntityCommandArgs) ((F_LayerOptionList) this).varProfileCut).RoughPlungeFeed;
    ((F_LayerOptionList) this).spn_roughfwdcuttingfeed.Value = ((EntityCommandArgs) ((F_LayerOptionList) this).varProfileCut).RoughCutBackwardFeed;
    ((F_LayerOptionList) this).spn_roughbwdcuttingfeed.Value = ((EntityCommandArgs) ((F_LayerOptionList) this).varProfileCut).RoughCutBackwardFeed;
    ((F_LayerOptionList) this).spn_roughverticaldevidelen.Value = ((AddSlatArgs) ((F_LayerOptionList) this).varProfileCut).RoughVerticalDevideLen;
    ((F_LayerOptionList) this).spn_roughleadin.Value = ((AddSlatArgs) ((F_LayerOptionList) this).varProfileCut).RoughLeadIn;
    ((F_LayerOptionList) this).spn_roughleadout.Value = ((AddCollapseArgs) ((F_LayerOptionList) this).varProfileCut).RoughLeadOut;
    ((F_LayerOptionList) this).chk_rougjzigzag.Check = ((MarbleCamParameterSetArg) ((F_LayerOptionList) this).varProfileCut).RoughZigzagMode;
    ((F_LayerOptionList) this).chk_roughperpendicularA.Check = ((MarbleCamParameterSetArg) ((F_LayerOptionList) this).varProfileCut).RoughPerpendicularA;
    \u0007.\u0001.\u0001((F_MarbleProfileSettings) this);
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
      if (control2.Name == ((F_LayerOptionList) this).btn_ok.Name)
      {
        \u0007.\u0001.\u0001((F_MarbleProfileSettings) this);
        ((F_SketchLibrary) this).Properties.Result = DialogResult.OK;
        if (((F_SketchLibrary) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_SketchLibrary) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_LayerOptionList) this).btn_cancel.Name | control2.Name == ((F_LayerOptionList) this).\u0001.Name))
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
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
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

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_LayerOptionList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_LayerOptionList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_KeyPadCharV1() => F_LayerOptionList.Captions = new List<string>();

  public F_KeyPadCharV1()
  {
    ((F_LayerOptionList) this).Properties = new FormProperties();
    ((F_LayerOptionList) this).varProfileCurveCut = (marbleProfileCurveCutPars) new \u0007.\u0001();
    ((F_LayerOptionList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleProfileCurveSettings) this);
  }

  public void Init()
  {
    ((F_LayerOptionList) this).Properties.Inited = false;
    if (((F_LayerOptionList) this).Properties.Height > 10)
      this.Height = ((F_LayerOptionList) this).Properties.Height;
    if (((F_LayerOptionList) this).Properties.Width > 10)
      this.Width = ((F_LayerOptionList) this).Properties.Width;
    this.TopMost = ((F_LayerOptionList) this).Properties.TopMost;
    this.StartPosition = ((F_LayerOptionList) this).Properties.FormPosition;
    ((F_LayerOptionList) this).Properties.Result = DialogResult.None;
    ((F_LayerOptionList) this).spn_finishcoffset.Value = ((marbleMaterialType) ((F_LayerOptionList) this).varProfileCurveCut).FinishCOffsetAngle;
    ((F_LayerOptionList) this).spn_finishsafedis.Value = ((marbleCountertopPocketData) ((F_LayerOptionList) this).varProfileCurveCut).FinishSafeDis;
    ((F_LayerOptionList) this).spn_finishsurfoffset.Value = ((marbleCountertopCornerData) ((F_LayerOptionList) this).varProfileCurveCut).FinishSurfOffset;
    ((F_LayerOptionList) this).spn_finishstepang.Value = ((marbleCountertopCornerData) ((F_LayerOptionList) this).varProfileCurveCut).FinishAngleStep;
    ((F_LayerOptionList) this).spn_finishminZ.Value = ((marbleMaterialType) ((F_LayerOptionList) this).varProfileCurveCut).FinishMinZ;
    ((F_LayerOptionList) this).spn_finishrapiddis.Value = ((marbleCountertopPocketData) ((F_LayerOptionList) this).varProfileCurveCut).FinishRapid;
    ((F_LayerOptionList) this).spn_finishplungefeed.Value = ((marbleChamferBothSideData) ((F_LayerOptionList) this).varProfileCurveCut).FinishPlungeFeed;
    ((F_LayerOptionList) this).spn_finishfwdcutfeed.Value = ((marbleCountertopPocketData) ((F_LayerOptionList) this).varProfileCurveCut).FinishCutForwardFeed;
    ((F_LayerOptionList) this).spn_finishbwdcuttingfeed.Value = ((marbleCountertopPocketData) ((F_LayerOptionList) this).varProfileCurveCut).FinishCutBackwardFeed;
    ((F_LayerOptionList) this).spn_finishverticaldevidedis.Value = ((marbleCountertopCornerData) ((F_LayerOptionList) this).varProfileCurveCut).FinishVerticalDevideLen;
    ((F_LayerOptionList) this).spn_finishleadin.Value = ((marbleMaterialType) ((F_LayerOptionList) this).varProfileCurveCut).FinishLeadInAngle;
    ((F_LayerOptionList) this).spn_finishleadout.Value = ((marbleMenuType) ((F_LayerOptionList) this).varProfileCurveCut).FinishLeadOutAngle;
    ((F_LayerOptionList) this).chk_finishzigzag.Check = ((marbleMenuType) ((F_LayerOptionList) this).varProfileCurveCut).FinishZigzagMode;
    ((F_LayerOptionList) this).chk_finishperpendicularA.Check = ((marbleMenuType) ((F_LayerOptionList) this).varProfileCurveCut).FinishPerpendicularA;
    ((F_LayerOptionList) this).spn_roughcoffset.Value = ((marbleSlatData) ((F_LayerOptionList) this).varProfileCurveCut).RoughCOffsetAngle;
    ((F_LayerOptionList) this).spn_roughsafedis.Value = ((marbleCountertopCavityData) ((F_LayerOptionList) this).varProfileCurveCut).RoughSafeDis;
    ((F_LayerOptionList) this).spn_roughsurfoffset.Value = ((marbleCountertopCavityData) ((F_LayerOptionList) this).varProfileCurveCut).RoughSurfOffset;
    ((F_LayerOptionList) this).spn_roughstepang.Value = ((marbleCountertopCavityData) ((F_LayerOptionList) this).varProfileCurveCut).RoughAngleStep;
    ((F_LayerOptionList) this).spn_roughminZ.Value = ((marbleSlatData) ((F_LayerOptionList) this).varProfileCurveCut).RoughMinZ;
    ((F_LayerOptionList) this).spn_roughrapiddis.Value = ((marbleCountertopCavityData) ((F_LayerOptionList) this).varProfileCurveCut).RoughRapid;
    ((F_LayerOptionList) this).spn_roughplungefeed.Value = ((marbleCountertopCavityData) ((F_LayerOptionList) this).varProfileCurveCut).RoughPlungeFeed;
    ((F_LayerOptionList) this).spn_roughfwdcuttingfeed.Value = ((marbleCountertopCavityData) ((F_LayerOptionList) this).varProfileCurveCut).RoughCutBackwardFeed;
    ((F_LayerOptionList) this).spn_roughbwdcuttingfeed.Value = ((marbleCountertopCavityData) ((F_LayerOptionList) this).varProfileCurveCut).RoughCutBackwardFeed;
    ((F_LayerOptionList) this).spn_roughverticaldevidelen.Value = ((marbleCountertopCavityData) ((F_LayerOptionList) this).varProfileCurveCut).RoughVerticalDevideLen;
    ((F_LayerOptionList) this).spn_roughleadin.Value = ((marbleSlatData) ((F_LayerOptionList) this).varProfileCurveCut).RoughLeadInAngle;
    ((F_LayerOptionList) this).spn_roughleadout.Value = ((marbleSlatData) ((F_LayerOptionList) this).varProfileCurveCut).RoughLeadOutAngle;
    ((F_LayerOptionList) this).chk_roughperpendicularA.Check = ((marbleChamferBothSideData) ((F_LayerOptionList) this).varProfileCurveCut).RoughPerpendicularA;
    ((F_LayerOptionList) this).chk_rougjzigzag.Check = ((marbleChamferBothSideData) ((F_LayerOptionList) this).varProfileCurveCut).RoughZigzagMode;
    \u0018.\u0002.\u0002.\u0001((F_MarbleProfileCurveSettings) this);
    ((F_LayerOptionList) this).Properties.Inited = true;
  }
}
