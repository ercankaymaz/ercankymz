// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Library.F_SketchLibrary
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms.Machine;
using buEyeBaseVer5.Forms.Marble;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Library;

public class F_SketchLibrary : Form
{
  public buSpin spn_roughstartheight;
  internal buLabel \u000F;
  public buCheckBox chk_roughstocksurface;
  public buCheckBox chk_roughstockbox;
  public FormProperties Properties;
  public static List<string> Captions;
  public MarbleItemSettings varOperation;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buButton \u0001;
  internal buLabel \u0001;
  public buCheckBox chk_outsideentityreferance;
  public FormProperties Properties;
  public static List<string> Captions;
  public MarbleItemSettings varOperation;
  private IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buButton \u0001;
  public buSpin spn_materialthickness;
  public buSpin spn_backwardstep;
  public buSpin spn_backwardvel;
  public buSpin spn_forwardvel;
  public buSpin spn_plungevel;
  internal buLabel \u0001;
  public buSpin spn_safedis;
  public buSpin spn_rapiddis;
  public buSpin spn_forwardstep;
  public buSpin spn_Targetz;
  public FormProperties Properties;

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleTempCodes) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleTempCodes) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init()
  {
    ((F_MarbleTempCodes) this).PropertiesForm.Inited = false;
    if (((F_MarbleTempCodes) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleTempCodes) this).PropertiesForm.Height;
    if (((F_MarbleTempCodes) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleTempCodes) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleTempCodes) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleTempCodes) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleTempCodes) this).buGround1.DisplayTop.BackColor = ((F_MarbleTempCodes) this).clrFormCaption;
    ((F_MarbleTempCodes) this).buGround1.Display.GradientType = GradientMode.Lineer;
    ((F_MarbleTempCodes) this).buGround1.Display.LineerGradient.FirstColor = ((F_MarbleTempCodes) this).clrFormBackUpper;
    ((F_MarbleTempCodes) this).buGround1.Display.LineerGradient.SecondColor = ((F_MarbleTempCodes) this).clrFormBackDown;
    ((F_MarbleTempCodes) this).btn_close.Display.BackColor = ((F_MarbleTempCodes) this).clrFormCaption;
    ((F_MarbleTempCodes) this).btn_close.ButtonDownDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleTempCodes) this).clrFormCaption, 0.9);
    ((F_MarbleTempCodes) this).btn_close.ButtonOverDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleTempCodes) this).clrFormCaption, 0.95);
    ((F_MarbleTempCodes) this).lbl_defination.Display.BackColor = ((F_MarbleTempCodes) this).clrLabel;
    ((F_MarbleTempCodes) this).btn_axessettings.Display.BackColor = ((F_MarbleTempCodes) this).clrButtonDisplay;
    ((F_MarbleTempCodes) this).btn_axessettings.ButtonDownDisplay.BackColor = ((F_MarbleTempCodes) this).clrButtonDown;
    ((F_MarbleTempCodes) this).btn_axessettings.ButtonOverDisplay.BackColor = ((F_MarbleTempCodes) this).clrButtonOver;
    ((F_MarbleTempCodes) this).btn_offset.Display.BackColor = ((F_MarbleTempCodes) this).clrButtonDisplay;
    ((F_MarbleTempCodes) this).btn_offset.ButtonDownDisplay.BackColor = ((F_MarbleTempCodes) this).clrButtonDown;
    ((F_MarbleTempCodes) this).btn_offset.ButtonOverDisplay.BackColor = ((F_MarbleTempCodes) this).clrButtonOver;
    ((F_MarbleTempCodes) this).btn_positionreset.Display.BackColor = ((F_MarbleTempCodes) this).clrButtonDisplay;
    ((F_MarbleTempCodes) this).btn_positionreset.ButtonDownDisplay.BackColor = ((F_MarbleTempCodes) this).clrButtonDown;
    ((F_MarbleTempCodes) this).btn_positionreset.ButtonOverDisplay.BackColor = ((F_MarbleTempCodes) this).clrButtonOver;
    ((F_MarbleTempCodes) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleTempCodes) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleTempCodes) this).lbl_defination.Text = $"{buLangTranslate.preDef.Axes} {buLangTranslate.preDef.Settings}";
      ((F_MarbleTempCodes) this).btn_axessettings.Text = $"{buLangTranslate.preDef.Axes} {buLangTranslate.preDef.Parameter}";
      ((F_MarbleTempCodes) this).btn_offset.Text = buLangTranslate.preDef.Offset;
      ((F_MarbleTempCodes) this).btn_positionreset.Text = $"{buLangTranslate.preDef.Position} {buLangTranslate.preDef.Reset}";
      ((F_MarbleTempCodes) this).buGround1.Text = $"{buLangTranslate.preDef.Axes} {buLangTranslate.preDef.Settings}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleTempCodes) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleTempCodes) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleTempCodes) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleTempCodes) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_MarbleTempCodes) this).btn_axessettings.Name)
    {
      ((F_MarbleTempCodes) this).PropertiesForm.Result = DialogResult.OK;
      ((F_MarbleTempCodes) this).PropertiesForm.Message = buCmdExecuteMessages.AxesSettings;
    }
    if (control.Name == ((F_MarbleTempCodes) this).btn_offset.Name)
    {
      ((F_MarbleTempCodes) this).PropertiesForm.Result = DialogResult.OK;
      ((F_MarbleTempCodes) this).PropertiesForm.Message = buCmdExecuteMessages.G54Position;
    }
    if (control.Name == ((F_MarbleTempCodes) this).btn_positionreset.Name)
    {
      ((F_MarbleTempCodes) this).PropertiesForm.Result = DialogResult.OK;
      ((F_MarbleTempCodes) this).PropertiesForm.Message = buCmdExecuteMessages.AxesReset;
    }
    if (((F_MarbleTempCodes) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleTempCodes) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleTempCodes) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleTempCodes) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleTempCodes) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleTempCodes) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleTempCodes) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_SketchLibrary() => F_MarbleTempCodes.Captions = new List<string>();

  public F_SketchLibrary()
  {
    ((F_MarbleTempMovements) this).PropertiesForm = new FormProperties();
    ((F_MarbleTempMovements) this).Settings = (marbleCamPars) new \u0007.\u0001();
    ((F_MarbleTempMovements) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleSawMillingContourSetting) this);
  }

  public void Init()
  {
    ((F_MarbleTempMovements) this).PropertiesForm.Inited = false;
    if (((F_MarbleTempMovements) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleTempMovements) this).PropertiesForm.Height;
    if (((F_MarbleTempMovements) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleTempMovements) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleTempMovements) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleTempMovements) this).PropertiesForm.FormPosition;
    ((F_MarbleTempMovements) this).spn_sawcircularcutstep.Value = ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).SawForwardCircularStepDownDistance;
    ((F_MarbleTempWaterjet) this).spn_sawcircularcutspeed.Value = ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).SawForwardCircularCuttingVelocity;
    ((F_MarbleTempWaterjet) this).spn_sawcircularcutfirstspeed.Value = ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).SawForwardCircularFirstCuttingVelocity;
    ((F_MarbleTempWaterjet) this).spn_sawcircularcutfirststep.Value = ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).SawForwardCircularStepFirstDownDistance;
    ((F_MarbleTempMovements) this).spn_sawstraightcuttingsspeed.Value = ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).SawForwardCuttingVelocity;
    ((F_MarbleTempMovements) this).spn_sawstraightcutstep.Value = ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).SawForwardStepDownDistance;
    ((F_MarbleTempWaterjet) this).spn_sawstraightcutfirstspeed.Value = ((marbleCollapseItem) ((F_MarbleTempMovements) this).Settings).SawForwardFirstCuttingVelocity;
    ((F_MarbleTempWaterjet) this).spn_sawstraightcutfirststep.Value = ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).SawForwardStepFirstDownDistance;
    ((F_MarbleTempMovements) this).spn_sawplungespeed.Value = ((marbleCollapseItem) ((F_MarbleTempMovements) this).Settings).SawPlungeVelocity;
    ((F_MarbleTempMovements) this).spn_sawrapiddistance.Value = ((marbleCollapseItem) ((F_MarbleTempMovements) this).Settings).SawRapidDistance;
    ((F_MarbleTempMovements) this).spn_sawsafedistance.Value = ((marbleCollapseItem) ((F_MarbleTempMovements) this).Settings).SawSafeDistance;
    ((F_MarbleTempMovements) this).spn_millingcutspeed.Value = ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).MillingCuttingVelocity;
    ((F_MarbleTempMovements) this).spn_millingcutstep.Value = ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).MillingStepDown;
    ((F_MarbleTempMovements) this).spn_millingfirstcutspeed.Value = ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).MillingFirstCuttingVelocity;
    ((F_MarbleTempWaterjet) this).spn_millingfirstcutstep.Value = ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).MillingFirstStepDown;
    ((F_MarbleTempMovements) this).spn_millingplungespeed.Value = ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).MillingPlungeVelocity;
    ((F_MarbleTempWaterjet) this).spn_millingdrillspeed.Value = ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).MillingDrillVelocity;
    ((F_MarbleTempMovements) this).spn_millingheadcutspeed.Value = ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).MillingHeadCuttingVelocity;
    ((F_MarbleTempMovements) this).spn_millingheadcutstep.Value = ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).MillingHeadStepDown;
    ((F_MarbleTempMovements) this).spn_millingheadfirstcutspeed.Value = ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).MillingHeadFirstCuttingVelocity;
    ((F_MarbleTempWaterjet) this).spn_millingheadfirstcutstep.Value = ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).MillingHeadFirstStepDown;
    ((F_MarbleTempMovements) this).spn_millingheaddrillspeed.Value = ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).MillingHeadDrillVelocity;
    ((F_MarbleTempMovements) this).spn_millingheadplungespeed.Value = ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).MillingHeadPlungeVelocity;
    ((F_MarbleTempMovements) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleTempMovements) this).PropertiesForm.Inited = true;
    \u0007.\u0001.\u0001((F_MarbleSawMillingContourSetting) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleTempMovements) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleTempMovements) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleTempMovements) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleTempMovements) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
    ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).SawForwardCircularStepDownDistance = ((F_MarbleTempMovements) this).spn_sawcircularcutstep.Value;
    ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).SawForwardCircularCuttingVelocity = ((F_MarbleTempWaterjet) this).spn_sawcircularcutspeed.Value;
    ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).SawForwardCircularFirstCuttingVelocity = ((F_MarbleTempWaterjet) this).spn_sawcircularcutfirstspeed.Value;
    ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).SawForwardCircularStepFirstDownDistance = ((F_MarbleTempWaterjet) this).spn_sawcircularcutfirststep.Value;
    ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).SawForwardCuttingVelocity = ((F_MarbleTempMovements) this).spn_sawstraightcuttingsspeed.Value;
    ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).SawForwardStepDownDistance = ((F_MarbleTempMovements) this).spn_sawstraightcutstep.Value;
    ((marbleCollapseItem) ((F_MarbleTempMovements) this).Settings).SawForwardFirstCuttingVelocity = ((F_MarbleTempWaterjet) this).spn_sawstraightcutfirstspeed.Value;
    ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).SawForwardStepFirstDownDistance = ((F_MarbleTempWaterjet) this).spn_sawstraightcutfirststep.Value;
    ((marbleCollapseItem) ((F_MarbleTempMovements) this).Settings).SawPlungeVelocity = ((F_MarbleTempMovements) this).spn_sawplungespeed.Value;
    ((marbleCollapseItem) ((F_MarbleTempMovements) this).Settings).SawRapidDistance = ((F_MarbleTempMovements) this).spn_sawrapiddistance.Value;
    ((marbleCollapseItem) ((F_MarbleTempMovements) this).Settings).SawSafeDistance = ((F_MarbleTempMovements) this).spn_sawsafedistance.Value;
    ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).MillingCuttingVelocity = ((F_MarbleTempMovements) this).spn_millingcutspeed.Value;
    ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).MillingStepDown = ((F_MarbleTempMovements) this).spn_millingcutstep.Value;
    ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).MillingFirstCuttingVelocity = ((F_MarbleTempMovements) this).spn_millingfirstcutspeed.Value;
    ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).MillingFirstStepDown = ((F_MarbleTempWaterjet) this).spn_millingfirstcutstep.Value;
    ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).MillingPlungeVelocity = ((F_MarbleTempMovements) this).spn_millingplungespeed.Value;
    ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).MillingDrillVelocity = ((F_MarbleTempWaterjet) this).spn_millingdrillspeed.Value;
    ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).MillingHeadCuttingVelocity = ((F_MarbleTempMovements) this).spn_millingheadcutspeed.Value;
    ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).MillingHeadStepDown = ((F_MarbleTempMovements) this).spn_millingheadcutstep.Value;
    ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).MillingHeadFirstCuttingVelocity = ((F_MarbleTempMovements) this).spn_millingheadfirstcutspeed.Value;
    ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).MillingHeadFirstStepDown = ((F_MarbleTempWaterjet) this).spn_millingheadfirstcutstep.Value;
    ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).MillingHeadDrillVelocity = ((F_MarbleTempMovements) this).spn_millingheaddrillspeed.Value;
    ((marbleEdgeItem) ((F_MarbleTempMovements) this).Settings).MillingHeadPlungeVelocity = ((F_MarbleTempMovements) this).spn_millingheadplungespeed.Value;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MarbleTempMovements) this).btn_ok.Name)
      {
        this.Apply();
        ((F_MarbleTempMovements) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_MarbleTempMovements) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_MarbleTempMovements) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_MarbleTempMovements) this).btn_close.Name | control2.Name == ((F_MarbleTempMovements) this).btn_cancel.Name))
        return;
      ((F_MarbleTempMovements) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_MarbleTempMovements) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_MarbleTempMovements) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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
    if (!((F_MarbleTempMovements) this).PropertiesForm.Inited)
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
    if ((!disposing ? 0 : (((F_MarbleTempMovements) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleTempMovements) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_SketchLibrary() => F_MarbleTempMovements.Captions = new List<string>();

  public F_SketchLibrary()
  {
    ((F_Preset) this).Properties = new FormProperties();
    ((F_Preset) this).varRoughSettings = (camParameters5) null;
    ((F_Preset) this).varContourCutSettings = (camParameters5) null;
    ((F_Preset) this).varCenterSettings = (camParameters5) null;
    ((F_Preset) this).varFaceSettings = (camParameters5) null;
    ((F_Preset) this).varFloorFinishSettings = (camParameters5) null;
    ((F_Preset) this).varChamferSettings = (camParameters5) null;
    ((F_Preset) this).varEngraveSettings = (camParameters5) null;
    ((F_Preset) this).varTextEngraveSettings = (camParameters5) null;
    ((F_Preset) this).varTrochoidalSettings = (camParameters5) null;
    ((F_Preset) this).CamType = CamWireFrameType.Pocket;
    ((F_Preset) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleMillingCamSetting) this);
  }

  public void Init()
  {
    ((F_Preset) this).Properties.Inited = false;
    if (((F_Preset) this).Properties.Height > 10)
      this.Height = ((F_Preset) this).Properties.Height;
    if (((F_Preset) this).Properties.Width > 10)
      this.Width = ((F_Preset) this).Properties.Width;
    this.TopMost = ((F_Preset) this).Properties.TopMost;
    this.StartPosition = ((F_Preset) this).Properties.FormPosition;
    ((F_Preset) this).Properties.Result = DialogResult.None;
    if (((F_Preset) this).varRoughSettings != null)
    {
      ((F_Preset) this).spn_roughcuttingvel.Value = ((F_Preset) this).varRoughSettings.Speeds.Feed;
      ((F_Preset) this).spn_roughplungevel.Value = ((F_Preset) this).varRoughSettings.Speeds.Plunge;
      ((F_Preset) this).spn_roughrapiddistance.Value = ((camMaterial5) ((F_Preset) this).varRoughSettings.Distances).Rapid;
      ((F_Preset) this).spn_roughsafedistance.Value = ((F_Preset) this).varRoughSettings.Distances.Safe;
      ((F_MachineOtherCodeCfg) this).spn_roughsteplen.Value = ((F_Preset) this).varRoughSettings.Steps.DepthStep;
      ((F_MachineGCodeCfg) this).spn_roughtoolpersentage.Value = ((camOperation5) ((F_Preset) this).varRoughSettings.Pockets).StepOverPersentage;
    }
    if (((F_Preset) this).varContourCutSettings != null)
    {
      ((F_MachineOtherCodeCfg) this).spn_contourcuttingvel.Value = ((F_Preset) this).varContourCutSettings.Speeds.Feed;
      ((F_MachineOtherCodeCfg) this).spn_contourplungevel.Value = ((F_Preset) this).varContourCutSettings.Speeds.Plunge;
      ((F_MachineOtherCodeCfg) this).spn_contourrapiddis.Value = ((camMaterial5) ((F_Preset) this).varContourCutSettings.Distances).Rapid;
      ((F_MachineOtherCodeCfg) this).spn_contoursafedistance.Value = ((F_Preset) this).varContourCutSettings.Distances.Safe;
      ((F_MachineAxisCfg) this).spn_contoursteplen.Value = ((F_Preset) this).varContourCutSettings.Steps.DepthStep;
      ((F_MachineAxisCfg) this).chk_contouroffsetcenter.Check = false;
      ((F_MachineGCodeCfg) this).chk_contouroffsetinside.Check = false;
      ((F_MachineAxisCfg) this).chk_contouroffsetoutside.Check = false;
      if (((camStep5) ((F_Preset) this).varContourCutSettings.Offsets).ClosedContour == CamClosedContourType.Center)
        ((F_MachineAxisCfg) this).chk_contouroffsetcenter.Check = true;
      else if (((camStep5) ((F_Preset) this).varContourCutSettings.Offsets).ClosedContour == CamClosedContourType.Inner)
        ((F_MachineGCodeCfg) this).chk_contouroffsetinside.Check = true;
      else
        ((F_MachineAxisCfg) this).chk_contouroffsetoutside.Check = true;
    }
    if (((F_Preset) this).varCenterSettings != null)
    {
      ((F_MachineOtherCodeCfg) this).spn_centercuttingvel.Value = ((F_Preset) this).varCenterSettings.Speeds.Feed;
      ((F_MachineOtherCodeCfg) this).spn_centerplungevel.Value = ((F_Preset) this).varCenterSettings.Speeds.Plunge;
      ((F_MachineOtherCodeCfg) this).spn_centerrapiddis.Value = ((camMaterial5) ((F_Preset) this).varCenterSettings.Distances).Rapid;
      ((F_MachineOtherCodeCfg) this).spn_centersafedis.Value = ((F_Preset) this).varCenterSettings.Distances.Safe;
      ((F_MachineAxisCfg) this).spn_centersteplen.Value = ((F_Preset) this).varCenterSettings.Steps.DepthStep;
    }
    if (((F_Preset) this).varFaceSettings != null)
    {
      ((F_MachineMCodeCfg) this).spn_facecuttingvel.Value = ((F_Preset) this).varFaceSettings.Speeds.Feed;
      ((F_MachineMCodeCfg) this).spn_faceplungevel.Value = ((F_Preset) this).varFaceSettings.Speeds.Plunge;
      ((F_MachineMCodeCfg) this).spn_facerapiddis.Value = ((camMaterial5) ((F_Preset) this).varFaceSettings.Distances).Rapid;
      ((F_MachineOtherCodeCfg) this).spn_facesafedis.Value = ((F_Preset) this).varFaceSettings.Distances.Safe;
    }
    if (((F_Preset) this).varFloorFinishSettings != null)
    {
      ((F_MachineMCodeCfg) this).spn_floorfinishcuttingvel.Value = ((F_Preset) this).varFloorFinishSettings.Speeds.Feed;
      ((F_MachineMCodeCfg) this).spn_floorfinishplungevel.Value = ((F_Preset) this).varFloorFinishSettings.Speeds.Plunge;
      ((F_MachineMCodeCfg) this).spn_floorfinishrapiddis.Value = ((camMaterial5) ((F_Preset) this).varFloorFinishSettings.Distances).Rapid;
      ((F_MachineMCodeCfg) this).spn_floorfinishsafedis.Value = ((F_Preset) this).varFloorFinishSettings.Distances.Safe;
    }
    if (((F_Preset) this).varChamferSettings != null)
    {
      ((F_MachineAxisCfg) this).spn_chamfercuttingvel.Value = ((F_Preset) this).varChamferSettings.Speeds.Feed;
      ((F_MachineMCodeCfg) this).spn_chamferplungevel.Value = ((F_Preset) this).varChamferSettings.Speeds.Plunge;
      ((F_MachineMCodeCfg) this).spn_chamferrapiddis.Value = ((camMaterial5) ((F_Preset) this).varChamferSettings.Distances).Rapid;
      ((F_MachineMCodeCfg) this).spn_chamfersafedis.Value = ((F_Preset) this).varChamferSettings.Distances.Safe;
    }
    if (((F_Preset) this).varEngraveSettings != null)
    {
      ((F_MachineAxisCfg) this).spn_engravecuttingvel.Value = ((F_Preset) this).varEngraveSettings.Speeds.Feed;
      ((F_MachineAxisCfg) this).spn_engraveplungevel.Value = ((F_Preset) this).varEngraveSettings.Speeds.Plunge;
      ((F_MachineAxisCfg) this).spn_engraverapiddis.Value = ((camMaterial5) ((F_Preset) this).varEngraveSettings.Distances).Rapid;
      ((F_MachineAxisCfg) this).spn_engravesafedis.Value = ((F_Preset) this).varEngraveSettings.Distances.Safe;
    }
    if (((F_Preset) this).varTextEngraveSettings != null)
    {
      ((F_MachineAxisCfg) this).spn_textengravecuttingvel.Value = ((F_Preset) this).varTextEngraveSettings.Speeds.Feed;
      ((F_MachineAxisCfg) this).spn_textengraveplungevel.Value = ((F_Preset) this).varTextEngraveSettings.Speeds.Plunge;
      ((F_MachineAxisCfg) this).spn_textengraverapiddis.Value = ((camMaterial5) ((F_Preset) this).varTextEngraveSettings.Distances).Rapid;
      ((F_MachineAxisCfg) this).spn_textengravesafedis.Value = ((F_Preset) this).varTextEngraveSettings.Distances.Safe;
    }
    if (((F_Preset) this).varTrochoidalSettings != null)
    {
      ((F_MachineAxisCfg) this).spn_trochoidalcuttingvel.Value = ((F_Preset) this).varTrochoidalSettings.Speeds.Feed;
      ((F_MachineAxisCfg) this).spn_trochoidalplungevel.Value = ((F_Preset) this).varTrochoidalSettings.Speeds.Plunge;
      ((F_MachineAxisCfg) this).spn_trochoidalrapiddis.Value = ((camMaterial5) ((F_Preset) this).varTrochoidalSettings.Distances).Rapid;
      ((F_MachineAxisCfg) this).spn_trochoidalsafedis.Value = ((F_Preset) this).varTrochoidalSettings.Distances.Safe;
    }
    if (((F_Preset) this).varTrochoidalSettings == null)
    {
      for (int index = 0; index <= ((F_Preset) this).\u0001.TabPages.Count - 1; ++index)
      {
        if (((F_Preset) this).\u0001.TabPages[index].Name == ((F_MachineMCodeCfg) this).\u000E.Name)
          ((F_Preset) this).\u0001.TabPages.RemoveAt(index);
      }
    }
    if (((F_Preset) this).varTextEngraveSettings == null)
    {
      for (int index = 0; index <= ((F_Preset) this).\u0001.TabPages.Count - 1; ++index)
      {
        if (((F_Preset) this).\u0001.TabPages[index].Name == ((F_MachineMCodeCfg) this).\u0008.Name)
        {
          ((F_Preset) this).\u0001.TabPages.RemoveAt(index);
          break;
        }
      }
    }
    if (((F_Preset) this).varEngraveSettings == null)
    {
      for (int index = 0; index <= ((F_Preset) this).\u0001.TabPages.Count - 1; ++index)
      {
        if (((F_Preset) this).\u0001.TabPages[index].Name == ((F_MachineMCodeCfg) this).\u0007.Name)
        {
          ((F_Preset) this).\u0001.TabPages.RemoveAt(index);
          break;
        }
      }
    }
    if (((F_Preset) this).varChamferSettings == null)
    {
      for (int index = 0; index <= ((F_Preset) this).\u0001.TabPages.Count - 1; ++index)
      {
        if (((F_Preset) this).\u0001.TabPages[index].Name == ((F_MachineMCodeCfg) this).\u0006.Name)
        {
          ((F_Preset) this).\u0001.TabPages.RemoveAt(index);
          break;
        }
      }
    }
    if (((F_Preset) this).varFloorFinishSettings == null)
    {
      for (int index = 0; index <= ((F_Preset) this).\u0001.TabPages.Count - 1; ++index)
      {
        if (((F_Preset) this).\u0001.TabPages[index].Name == ((F_MachineOtherCodeCfg) this).\u0005.Name)
        {
          ((F_Preset) this).\u0001.TabPages.RemoveAt(index);
          break;
        }
      }
    }
    if (((F_Preset) this).varFaceSettings == null)
    {
      for (int index = 0; index <= ((F_Preset) this).\u0001.TabPages.Count - 1; ++index)
      {
        if (((F_Preset) this).\u0001.TabPages[index].Name == ((F_MachineOtherCodeCfg) this).\u0004.Name)
        {
          ((F_Preset) this).\u0001.TabPages.RemoveAt(index);
          break;
        }
      }
    }
    if (((F_Preset) this).varCenterSettings == null)
    {
      for (int index = 0; index <= ((F_Preset) this).\u0001.TabPages.Count - 1; ++index)
      {
        if (((F_Preset) this).\u0001.TabPages[index].Name == ((F_MachineOtherCodeCfg) this).\u0003.Name)
        {
          ((F_Preset) this).\u0001.TabPages.RemoveAt(index);
          break;
        }
      }
    }
    if (((F_Preset) this).varContourCutSettings == null)
    {
      for (int index = 0; index <= ((F_Preset) this).\u0001.TabPages.Count - 1; ++index)
      {
        if (((F_Preset) this).\u0001.TabPages[index].Name == ((F_Preset) this).\u0002.Name)
        {
          ((F_Preset) this).\u0001.TabPages.RemoveAt(index);
          break;
        }
      }
    }
    if (((F_Preset) this).varRoughSettings == null)
    {
      for (int index = 0; index <= ((F_Preset) this).\u0001.TabPages.Count - 1; ++index)
      {
        if (((F_Preset) this).\u0001.TabPages[index].Name == ((F_Preset) this).\u0001.Name)
        {
          ((F_Preset) this).\u0001.TabPages.RemoveAt(index);
          break;
        }
      }
    }
    if (((F_Preset) this).CamType == CamWireFrameType.Pocket)
    {
      for (int index = 0; index <= ((F_Preset) this).\u0001.TabPages.Count - 1; ++index)
      {
        if (((F_Preset) this).\u0001.TabPages[index].Name == ((F_Preset) this).\u0001.Name)
        {
          ((F_Preset) this).\u0001.SelectedIndex = index;
          break;
        }
      }
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleMillingCamSetting) this, ((F_Preset) this).varRoughSettings);
    }
    if (((F_Preset) this).CamType == CamWireFrameType.Contour)
    {
      for (int index = 0; index <= ((F_Preset) this).\u0001.TabPages.Count - 1; ++index)
      {
        if (((F_Preset) this).\u0001.TabPages[index].Name == ((F_Preset) this).\u0002.Name)
        {
          ((F_Preset) this).\u0001.SelectedIndex = index;
          break;
        }
      }
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleMillingCamSetting) this, ((F_Preset) this).varContourCutSettings);
    }
    if (((F_Preset) this).CamType == CamWireFrameType.CenterPath)
    {
      for (int index = 0; index <= ((F_Preset) this).\u0001.TabPages.Count - 1; ++index)
      {
        if (((F_Preset) this).\u0001.TabPages[index].Name == ((F_MachineOtherCodeCfg) this).\u0003.Name)
        {
          ((F_Preset) this).\u0001.SelectedIndex = index;
          break;
        }
      }
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleMillingCamSetting) this, ((F_Preset) this).varCenterSettings);
    }
    if (((F_Preset) this).CamType == CamWireFrameType.Face)
    {
      for (int index = 0; index <= ((F_Preset) this).\u0001.TabPages.Count - 1; ++index)
      {
        if (((F_Preset) this).\u0001.TabPages[index].Name == ((F_MachineOtherCodeCfg) this).\u0004.Name)
        {
          ((F_Preset) this).\u0001.SelectedIndex = index;
          break;
        }
      }
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleMillingCamSetting) this, ((F_Preset) this).varFaceSettings);
    }
    if (((F_Preset) this).CamType == CamWireFrameType.FloorFinish)
    {
      for (int index = 0; index <= ((F_Preset) this).\u0001.TabPages.Count - 1; ++index)
      {
        if (((F_Preset) this).\u0001.TabPages[index].Name == ((F_MachineOtherCodeCfg) this).\u0005.Name)
        {
          ((F_Preset) this).\u0001.SelectedIndex = index;
          break;
        }
      }
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleMillingCamSetting) this, ((F_Preset) this).varFloorFinishSettings);
    }
    if (((F_Preset) this).CamType == CamWireFrameType.Chamfer2D)
    {
      for (int index = 0; index <= ((F_Preset) this).\u0001.TabPages.Count - 1; ++index)
      {
        if (((F_Preset) this).\u0001.TabPages[index].Name == ((F_MachineMCodeCfg) this).\u0006.Name)
        {
          ((F_Preset) this).\u0001.SelectedIndex = index;
          break;
        }
      }
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleMillingCamSetting) this, ((F_Preset) this).varChamferSettings);
    }
    if (((F_Preset) this).CamType == CamWireFrameType.Engrave)
    {
      for (int index = 0; index <= ((F_Preset) this).\u0001.TabPages.Count - 1; ++index)
      {
        if (((F_Preset) this).\u0001.TabPages[index].Name == ((F_MachineMCodeCfg) this).\u0007.Name)
        {
          ((F_Preset) this).\u0001.SelectedIndex = index;
          break;
        }
      }
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleMillingCamSetting) this, ((F_Preset) this).varEngraveSettings);
    }
    if (((F_Preset) this).CamType == CamWireFrameType.TextEngrave)
    {
      for (int index = 0; index <= ((F_Preset) this).\u0001.TabPages.Count - 1; ++index)
      {
        if (((F_Preset) this).\u0001.TabPages[index].Name == ((F_MachineMCodeCfg) this).\u0008.Name)
        {
          ((F_Preset) this).\u0001.SelectedIndex = index;
          break;
        }
      }
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleMillingCamSetting) this, ((F_Preset) this).varTextEngraveSettings);
    }
    if (((F_Preset) this).CamType == CamWireFrameType.Trochoidal)
    {
      for (int index = 0; index <= ((F_Preset) this).\u0001.TabPages.Count - 1; ++index)
      {
        if (((F_Preset) this).\u0001.TabPages[index].Name == ((F_MachineMCodeCfg) this).\u000E.Name)
        {
          ((F_Preset) this).\u0001.SelectedIndex = index;
          break;
        }
      }
      \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleMillingCamSetting) this, ((F_Preset) this).varTrochoidalSettings);
    }
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleMillingCamSetting) this);
    ((F_Preset) this).Properties.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_Preset) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_Preset) this).Properties.Result = DialogResult.Cancel;
    if (((F_Preset) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_Preset) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_MachineAxisCfg) this).chk_contouroffsetcenter.Name)
      {
        ((F_MachineGCodeCfg) this).chk_contouroffsetinside.Check = false;
        ((F_MachineAxisCfg) this).chk_contouroffsetoutside.Check = false;
        ((F_MachineAxisCfg) this).chk_contouroffsetcenter.Check = true;
      }
      else if (control2.Name == ((F_MachineGCodeCfg) this).chk_contouroffsetinside.Name)
      {
        ((F_MachineGCodeCfg) this).chk_contouroffsetinside.Check = true;
        ((F_MachineAxisCfg) this).chk_contouroffsetoutside.Check = false;
        ((F_MachineAxisCfg) this).chk_contouroffsetcenter.Check = false;
      }
      else if (control2.Name == ((F_MachineAxisCfg) this).chk_contouroffsetoutside.Name)
      {
        ((F_MachineGCodeCfg) this).chk_contouroffsetinside.Check = false;
        ((F_MachineAxisCfg) this).chk_contouroffsetoutside.Check = true;
        ((F_MachineAxisCfg) this).chk_contouroffsetcenter.Check = false;
      }
      else if (control2.Name == ((F_MachineGCodeCfg) this).chk_zigzag.Name)
      {
        ((F_MachineGCodeCfg) this).chk_oneway.Check = false;
        ((F_MachineGCodeCfg) this).chk_zigzag.Check = true;
        ((F_MachineGCodeCfg) this).chk_spiral.Check = false;
      }
      else if (control2.Name == ((F_MachineGCodeCfg) this).chk_oneway.Name)
      {
        ((F_MachineGCodeCfg) this).chk_oneway.Check = true;
        ((F_MachineGCodeCfg) this).chk_zigzag.Check = false;
        ((F_MachineGCodeCfg) this).chk_spiral.Check = false;
      }
      else if (control2.Name == ((F_MachineGCodeCfg) this).chk_spiral.Name)
      {
        ((F_MachineGCodeCfg) this).chk_oneway.Check = false;
        ((F_MachineGCodeCfg) this).chk_zigzag.Check = false;
        ((F_MachineGCodeCfg) this).chk_spiral.Check = true;
      }
      else if (control2.Name == ((F_MachineGCodeCfg) this).chk_region.Name)
      {
        ((F_MachineGCodeCfg) this).chk_region.Check = true;
        ((F_MachineGCodeCfg) this).chk_level.Check = false;
      }
      else if (control2.Name == ((F_MachineGCodeCfg) this).chk_level.Name)
      {
        ((F_MachineGCodeCfg) this).chk_region.Check = false;
        ((F_MachineGCodeCfg) this).chk_level.Check = true;
      }
      else
      {
        if (control2.Name == ((F_Preset) this).btn_ok.Name)
        {
          \u0007.\u0001.\u0001((F_MarbleMillingCamSetting) this);
          ((F_Preset) this).Properties.Result = DialogResult.OK;
          if (((F_Preset) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
            this.Dispose();
          if (((F_Preset) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
            this.Visible = false;
        }
        if (!(control2.Name == ((F_Preset) this).btn_cancel.Name | control2.Name == ((F_Preset) this).\u0001.Name))
          return;
        ((F_Preset) this).Properties.Result = DialogResult.Cancel;
        if (((F_Preset) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_Preset) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
      }
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
    if ((!disposing ? 0 : (((F_Preset) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_Preset) this).\u0001.Dispose();
    base.Dispose(disposing);
  }
}
