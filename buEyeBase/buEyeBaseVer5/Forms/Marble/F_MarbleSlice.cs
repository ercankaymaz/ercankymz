// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleSlice
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleSlice : Form
{
  public buCheckBox chk_slatenable;
  public buSpin spn_slatendangle;
  public buCheckBox chk_topchamferendenable;
  public buSpin spn_topchamferendheight;
  public buSpin spn_topchamferendangle;
  public buCheckBox chk_bottomchamfer;
  public buCheckBox chk_topchamfer;
  public buSpin spn_chamferbottomheiht;
  public buSpin spn_chamferbottomangle;
  public buSpin spn_chamfertopheight;
  public buSpin spn_chamfertopangle;
  public buLabel lbl_chamfer;
  public buLabel lbl_slat;
  public buLabel lbl_edge;
  public buCheckBox chk_reverse;
  public buSpin spn_edgeangle;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public marbleSlatPars Slat;
  private IContainer \u0001;
  public buButton btn_close;

  static F_MarbleSlice() => F_MarbleEasyDraw.Captions = new List<string>();

  public F_MarbleSlice()
  {
    ((F_MarbleEasyDraw) this).\u0001 = "F_MarbleSlat";
    ((F_MarbleEasyDraw) this).PropertiesForm = new FormProperties();
    ((F_MarbleEasyDraw) this).RuntimeSettings = (MarbleRuntimeSettings) new MarbleSawCalcParameters();
    ((F_MarbleEasyDraw) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleSlat) this);
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
      buLogVer5.addToLog(((F_MarbleEasyDraw) this).\u0001, str, "Exception", ex.Message, ex.Data.ToString(), AddException: true);
      buException.throwException(ex, str, true, "");
    }
  }

  public void Init()
  {
    ((F_MarbleEasyDraw) this).PropertiesForm.Inited = false;
    if (((F_MarbleEasyDraw) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleEasyDraw) this).PropertiesForm.Height;
    if (((F_MarbleEasyDraw) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleEasyDraw) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleEasyDraw) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleEasyDraw) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleHoleData) this).spn_width.Value = ((marbleCamPars) ((F_MarbleEasyDraw) this).RuntimeSettings).SlatWidth;
    ((F_MarbleEasyDraw) this).spn_SA.Value = ((marbleCamPars) ((F_MarbleEasyDraw) this).RuntimeSettings).SlatStartAngle;
    ((F_MarbleEasyDraw) this).spn_EA.Value = ((marbleCamPars) ((F_MarbleEasyDraw) this).RuntimeSettings).SlatEndAngle;
    ((F_MarbleHoleData) this).spn_offset.Value = ((marbleCamPars) ((F_MarbleEasyDraw) this).RuntimeSettings).SlatOffset;
    ((F_MarbleHoleData) this).chk_addangletoselectededge.Check = ((marbleCamPars) ((F_MarbleEasyDraw) this).RuntimeSettings).SlatAddAngleSelectedEdge;
    ((F_MarbleEasyDraw) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleEasyDraw) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleEasyDraw) this).ground_base.Text = buLangTranslate.preDef.Slat;
      ((F_MarbleHoleData) this).btn_ok.Text = buLangTranslate.preDef.Ok;
      ((F_MarbleHoleData) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
      ((F_MarbleHoleData) this).spn_width.Caption.Caption = buLangTranslate.preDef.Width;
      ((F_MarbleEasyDraw) this).spn_SA.Caption.Caption = buLangTranslate.preDef.StartAngle;
      ((F_MarbleEasyDraw) this).spn_EA.Caption.Caption = buLangTranslate.preDef.EndAngle;
      ((F_MarbleHoleData) this).spn_offset.Caption.Caption = buLangTranslate.preDef.Offset;
      ((F_MarbleHoleData) this).chk_addangletoselectededge.Text = buLangTranslate.preCaptionMarble.AddAngleValueToSelectedEdge;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleEasyDraw) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleEasyDraw) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleEasyDraw) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleEasyDraw) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
    ((marbleCamPars) ((F_MarbleEasyDraw) this).RuntimeSettings).SlatWidth = ((F_MarbleHoleData) this).spn_width.Value;
    ((marbleCamPars) ((F_MarbleEasyDraw) this).RuntimeSettings).SlatStartAngle = ((F_MarbleEasyDraw) this).spn_SA.Value;
    ((marbleCamPars) ((F_MarbleEasyDraw) this).RuntimeSettings).SlatEndAngle = ((F_MarbleEasyDraw) this).spn_EA.Value;
    ((marbleCamPars) ((F_MarbleEasyDraw) this).RuntimeSettings).SlatOffset = ((F_MarbleHoleData) this).spn_offset.Value;
    ((marbleCamPars) ((F_MarbleEasyDraw) this).RuntimeSettings).SlatAddAngleSelectedEdge = ((F_MarbleHoleData) this).chk_addangletoselectededge.Check;
  }
}
