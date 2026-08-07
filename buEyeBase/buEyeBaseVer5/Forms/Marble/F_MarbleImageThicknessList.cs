// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleImageThicknessList
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

public class F_MarbleImageThicknessList : Form
{
  public buButton btn_magnet_down;
  internal buTab \u0001;
  internal TabPage \u0001;
  internal TabPage \u0002;
  public buButton btn_move;
  public buButton btn_magnet;
  public buButton btn_side;
  public buButton btn_magnet_rightdown;
  public buButton btn_magnet_right;
  public buButton btn_magnet_left;
  public buButton btn_magnet_up;
  public buButton btn_move_right;
  public buButton btn_move_left;
  public buButton btn_move_up;

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    // ISSUE: reference to a compiler-generated field
    if (((F_MarblePhotoCalibration) this).\u0001 == null)
      return;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).AlignMagnetOffset = ((F_MarblePhotoCalibration) this).spn_magnetoffset.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).AlignMoveValue = ((F_MarbleVacuum) this).spn_moveval.Value;
    ((marbleCamPars) MarbleRuntimeSettings.varMarbleRunSettings).AlignSideOffset = ((F_MarbleVacuum) this).spn_sideoffset.Value;
    if (control.Name == ((F_MarblePhotoCalibration) this).btn_magnet_leftup.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarblePhotoCalibration) this).\u0001((object) (MarbleCadCamCommands) 2, (object) ((F_MarblePhotoCalibration) this).spn_magnetoffset.Value, (object) (MarbleAlingmentCommands) 1, (object) null, (object) null);
    }
    if (control.Name == ((F_MarblePhotoCalibration) this).btn_magnet_leftdown.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarblePhotoCalibration) this).\u0001((object) (MarbleCadCamCommands) 3, (object) ((F_MarblePhotoCalibration) this).spn_magnetoffset.Value, (object) (MarbleAlingmentCommands) 1, (object) null, (object) null);
    }
    if (control.Name == this.btn_magnet_left.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarblePhotoCalibration) this).\u0001((object) (MarbleCadCamCommands) 1, (object) ((F_MarblePhotoCalibration) this).spn_magnetoffset.Value, (object) (MarbleAlingmentCommands) 1, (object) null, (object) null);
    }
    if (control.Name == this.btn_magnet_up.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarblePhotoCalibration) this).\u0001((object) (MarbleCadCamCommands) 4, (object) ((F_MarblePhotoCalibration) this).spn_magnetoffset.Value, (object) (MarbleAlingmentCommands) 1, (object) null, (object) null);
    }
    if (control.Name == this.btn_magnet_down.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarblePhotoCalibration) this).\u0001((object) (MarbleCadCamCommands) 5, (object) ((F_MarblePhotoCalibration) this).spn_magnetoffset.Value, (object) (MarbleAlingmentCommands) 1, (object) null, (object) null);
    }
    if (control.Name == this.btn_magnet_right.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarblePhotoCalibration) this).\u0001((object) (MarbleCadCamCommands) 6, (object) ((F_MarblePhotoCalibration) this).spn_magnetoffset.Value, (object) (MarbleAlingmentCommands) 1, (object) null, (object) null);
    }
    if (control.Name == this.btn_magnet_rightdown.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarblePhotoCalibration) this).\u0001((object) (MarbleCadCamCommands) 8, (object) ((F_MarblePhotoCalibration) this).spn_magnetoffset.Value, (object) (MarbleAlingmentCommands) 1, (object) null, (object) null);
    }
    if (control.Name == ((F_MarblePhotoCalibration) this).btn_magnet_rightup.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarblePhotoCalibration) this).\u0001((object) (MarbleCadCamCommands) 7, (object) ((F_MarblePhotoCalibration) this).spn_magnetoffset.Value, (object) (MarbleAlingmentCommands) 1, (object) null, (object) null);
    }
    if (control.Name == ((F_MarbleVacuum) this).btn_move_leftup.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarblePhotoCalibration) this).\u0001((object) (MarbleCadCamCommands) 10, (object) ((F_MarbleVacuum) this).spn_moveval.Value, (object) (MarbleAlingmentCommands) 2, (object) null, (object) null);
    }
    if (control.Name == ((F_MarbleVacuum) this).btn_move_leftdown.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarblePhotoCalibration) this).\u0001((object) (MarbleCadCamCommands) 11, (object) ((F_MarbleVacuum) this).spn_moveval.Value, (object) (MarbleAlingmentCommands) 2, (object) null, (object) null);
    }
    if (control.Name == this.btn_move_left.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarblePhotoCalibration) this).\u0001((object) (MarbleCadCamCommands) 9, (object) ((F_MarbleVacuum) this).spn_moveval.Value, (object) (MarbleAlingmentCommands) 2, (object) null, (object) null);
    }
    if (control.Name == this.btn_move_up.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarblePhotoCalibration) this).\u0001((object) (MarbleCadCamCommands) 12, (object) ((F_MarbleVacuum) this).spn_moveval.Value, (object) (MarbleAlingmentCommands) 2, (object) null, (object) null);
    }
    if (control.Name == ((F_MarbleVacuum) this).btn_move_down.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarblePhotoCalibration) this).\u0001((object) (MarbleCadCamCommands) 13, (object) ((F_MarbleVacuum) this).spn_moveval.Value, (object) (MarbleAlingmentCommands) 2, (object) null, (object) null);
    }
    if (control.Name == this.btn_move_right.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarblePhotoCalibration) this).\u0001((object) (MarbleCadCamCommands) 14, (object) ((F_MarbleVacuum) this).spn_moveval.Value, (object) (MarbleAlingmentCommands) 2, (object) null, (object) null);
    }
    if (control.Name == ((F_MarbleVacuum) this).btn_move_rightdown.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarblePhotoCalibration) this).\u0001((object) (MarbleCadCamCommands) 16 /*0x10*/, (object) ((F_MarbleVacuum) this).spn_moveval.Value, (object) (MarbleAlingmentCommands) 2, (object) null, (object) null);
    }
    if (control.Name == ((F_MarbleVacuum) this).btn_move_rightup.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarblePhotoCalibration) this).\u0001((object) (MarbleCadCamCommands) 15, (object) ((F_MarbleVacuum) this).spn_moveval.Value, (object) (MarbleAlingmentCommands) 2, (object) null, (object) null);
    }
    if (control.Name == ((F_MarbleVacuum) this).btn_side_left.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarblePhotoCalibration) this).\u0001((object) (MarbleCadCamCommands) 17, (object) ((F_MarbleVacuum) this).spn_sideoffset.Value, (object) (MarbleAlingmentCommands) 3, (object) null, (object) null);
    }
    if (control.Name == ((F_MarbleVacuum) this).btn_side_up.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarblePhotoCalibration) this).\u0001((object) (MarbleCadCamCommands) 19, (object) ((F_MarbleVacuum) this).spn_sideoffset.Value, (object) (MarbleAlingmentCommands) 3, (object) null, (object) null);
    }
    if (control.Name == ((F_MarbleVacuum) this).btn_side_down.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarblePhotoCalibration) this).\u0001((object) (MarbleCadCamCommands) 20, (object) ((F_MarbleVacuum) this).spn_sideoffset.Value, (object) (MarbleAlingmentCommands) 3, (object) null, (object) null);
    }
    if (control.Name == ((F_MarbleVacuum) this).btn_side_right.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarblePhotoCalibration) this).\u0001((object) (MarbleCadCamCommands) 18, (object) ((F_MarbleVacuum) this).spn_sideoffset.Value, (object) (MarbleAlingmentCommands) 3, (object) null, (object) null);
    }
    if (control.Name == ((F_MarbleVacuum) this).btn_side_centerhor.Name)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_MarblePhotoCalibration) this).\u0001((object) (MarbleCadCamCommands) 21, (object) ((F_MarbleVacuum) this).spn_sideoffset.Value, (object) (MarbleAlingmentCommands) 3, (object) null, (object) null);
    }
    if (!(control.Name == ((F_MarbleVacuum) this).btn_side_centerver.Name))
      return;
    // ISSUE: reference to a compiler-generated field
    ((F_MarblePhotoCalibration) this).\u0001((object) (MarbleCadCamCommands) 22, (object) ((F_MarbleVacuum) this).spn_sideoffset.Value, (object) (MarbleAlingmentCommands) 3, (object) null, (object) null);
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    buEyeShotFunctions.SetVisualItem(((F_MarblePhotoCalibration) this).ground_base.Controls);
    if (this.btn_magnet.Name == control.Name)
    {
      this.btn_magnet.Display.BackColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      this.btn_magnet.Display.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      this.btn_magnet.Display.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      this.\u0001.SelectedIndex = 0;
    }
    if (this.btn_move.Name == control.Name)
    {
      this.btn_move.Display.BackColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      this.btn_move.Display.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      this.btn_move.Display.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      this.\u0001.SelectedIndex = 1;
    }
    if (!(this.btn_side.Name == control.Name))
      return;
    this.btn_side.Display.BackColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    this.btn_side.Display.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    this.btn_side.Display.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    this.\u0001.SelectedIndex = 2;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarblePhotoCalibration) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarblePhotoCalibration) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarblePhotoCalibration) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
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

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarblePhotoCalibration) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarblePhotoCalibration) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleImageThicknessList() => F_MarblePhotoCalibration.Captions = new List<string>();

  public F_MarbleImageThicknessList()
  {
    ((F_MarbleVacuum) this).\u0001 = "F_MarbleSlat";
    ((F_MarbleVacuum) this).PropertiesForm = new FormProperties();
    ((F_MarbleVacuum) this).RuntimeSettings = (MarbleRuntimeSettings) new MarbleSawCalcParameters();
    ((F_MarbleVacuum) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleCollapse) this);
  }

  public void UpdateVisuals()
  {
    string str = nameof (UpdateVisuals);
    try
    {
      if (clsVisualVars.parVisual == null)
        return;
      this.LoadLanguage();
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_MarbleVacuum) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void Init()
  {
    // ISSUE: unable to decompile the method.
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleVacuum) this).ground_base.Text = buLangTranslate.preDef.Collapse;
      ((F_MarbleVacuum) this).btn_ok.Text = buLangTranslate.preDef.Ok;
      ((F_MarbleVacuum) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
      ((F_MarbleVacuum) this).spn_collapsedepth.Caption.Caption = buLangTranslate.preDef.Depth;
      ((F_MarbleVacuum) this).spn_collapseoffset.Caption.Caption = buLangTranslate.preDef.Offset;
      ((F_MarbleVacuum) this).chk_collapseenable.Text = buLangTranslate.preDef.Enable;
      ((F_MarbleVacuum) this).chk_collapseinside.Text = buLangTranslate.preDef.Inside;
      ((F_MarbleVacuum) this).chk_collapseoutside.Text = buLangTranslate.preDef.Outside;
      ((F_MarbleVacuum) this).lbl_Tool.Text = buLangTranslate.preDef.Tool;
      ((F_MarbleVacuum) this).\u0001.Text = buLangTranslate.preDef.MillingHead;
      ((F_MarbleVacuum) this).\u0002.Text = buLangTranslate.preDef.Milling;
    }
    catch (Exception ex)
    {
    }
  }
}
