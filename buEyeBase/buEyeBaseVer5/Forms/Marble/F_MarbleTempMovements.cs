// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleTempMovements
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleTempMovements : Form
{
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public marbleCamPars Settings;
  private IContainer \u0001;
  public buButton btn_close;
  public buGround buGround1;
  public Panel pnl_base;
  public buSpin spn_sawstraightcutstep;
  public buButton btn_ok;
  public buSpin spn_sawsafedistance;
  public buSpin spn_sawplungespeed;
  public buSpin spn_sawstraightcuttingsspeed;
  public buButton btn_cancel;
  internal buLabel \u0001;
  public buSpin spn_sawcircularcutstep;
  public buSpin spn_sawrapiddistance;
  public buSpin spn_millingcutspeed;
  public buSpin spn_millingplungespeed;
  public buSpin spn_millingfirstcutspeed;
  public buSpin spn_millingcutstep;
  internal buLabel \u0002;
  internal buLabel \u0003;
  public buSpin spn_millingheaddrillspeed;
  public buSpin spn_millingheadcutspeed;
  public buSpin spn_millingheadplungespeed;
  public buSpin spn_millingheadfirstcutspeed;
  public buSpin spn_millingheadcutstep;

  public void InitVisual()
  {
    if (new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm").Exists)
    {
      Control.ControlCollection controlCollection = (Control.ControlCollection) null;
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleAxesSettings) this).buGround1.Controls);
    }
    ((F_MarbleHorizontalCut) this).PropertiesForm.VisualUpdated = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleAxesSettings) this).lbl_contourtype.Text = $"{buLangTranslate.preDef.Contour} {buLangTranslate.preDef.Type}";
      ((F_MarbleAxesSettings) this).lbl_strategytype.Text = $"{buLangTranslate.preDef.Strategy} {buLangTranslate.preDef.Type}";
      ((F_MarbleAxesSettings) this).lbl_tooltype.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Type}";
      ((F_MarbleHorizontalCut) this).btn_contourmenueditor.Text = buLangTranslate.preDef.Editor;
      ((F_MarbleHorizontalCut) this).btn_contourmenufilelist.Text = buLangTranslate.preDef.FromList;
      ((F_MarbleHorizontalCut) this).btn_contourmenufromfile.Text = buLangTranslate.preDef.FromFile;
      ((F_MarbleAxesSettings) this).btn_digitizer.Text = $"{buLangTranslate.preDef.Image} {buLangTranslate.preDef.Contour}";
      ((F_MarbleHorizontalCut) this).btn_strategy.Text = buLangTranslate.preDef.Strategy;
      ((F_MarbleHorizontalCut) this).btn_tool.Text = buLangTranslate.preDef.Tool;
      ((F_MarbleAxesSettings) this).chk_addtonesting.Text = $"{buLangTranslate.preDef.Nesting} {buLangTranslate.preDef.Add}";
      ((F_MarbleAxesSettings) this).buGround1.Text = $"{buLangTranslate.preDef.Contour} {buLangTranslate.preDef.Menu}";
      ((F_MarbleAxesSettings) this).chk_mirrorX.Text = buLangTranslate.preDef.Mirror + " X";
      ((F_MarbleAxesSettings) this).chk_mirroY.Text = buLangTranslate.preDef.Mirror + " Y";
      ((F_MarbleAxesSettings) this).lbl_events.Text = buLangTranslate.preDef.Events;
    }
    catch (Exception ex)
    {
    }
  }
}
