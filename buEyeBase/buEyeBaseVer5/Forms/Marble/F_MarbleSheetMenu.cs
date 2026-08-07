// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleSheetMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleSheetMenu : Form
{
  public buSpin spn_toolY2;
  public buSpin spn_toolX2;
  public buLabel buLabel1;
  public buLabel buLabel2;
  public buLabel buLabel3;
  public buLabel buLabel4;
  public buLabel buLabel5;
  public buLabel buLabel6;
  public buLabel buLabel7;
  public buLabel buLabel8;
  public buSpin spn_toolZ1;
  public buSpin spn_toolY1;
  public buSpin spn_toolX1;
  public buLabel buLabel9;
  public buButton btn_tooltake6;
  public buButton btn_tooltake5;
  public buButton btn_tooltake4;
  public buButton btn_tooltake3;
  public buButton btn_tooltake2;
  public buButton btn_tooltake1;
  public buButton btn_magazineclose;
  public buButton btn_doorclose;
  public buButton btn_pensopen;
  public buButton btn_pensclose;
  public buButton btn_magazineopen;

  internal void \u0001([In] object obj0, [In] bool obj1)
  {
    if (!((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Inited)
      return;
    ((F_MarbleToolSpindleAndMagazine) this).btn_tr.Check = true;
    ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0002([In] object obj0, [In] bool obj1)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleToolSpindleAndMagazine) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleToolSpindleAndMagazine) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleSheetMenu() => F_MarbleToolSpindleAndMagazine.Captions = new List<string>();

  public F_MarbleSheetMenu()
  {
    ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm = new FormProperties();
    ((F_MarbleToolSpindleAndMagazine) this).Settings = (marbleCamPars) new \u0007.\u0001();
    ((F_MarbleToolSpindleAndMagazine) this).SettingsProgram = (MarbleProgramSettings) new MarbleCommandHandler();
    ((F_MarbleToolSpindleAndMagazine) this).Sequences = new List<MarbleOperationSequence>();
    ((F_MarbleToolSpindleAndMagazine) this).indexMat = -1;
    ((F_MarbleToolSpindleAndMagazine) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleCamSettings) this);
  }

  public void Init(int Index)
  {
    // ISSUE: unable to decompile the method.
  }

  public void InitVisual()
  {
    if (new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm").Exists)
    {
      Control.ControlCollection controlCollection = (Control.ControlCollection) null;
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleToolSpindleAndMagazine) this).buGround1.Controls);
      controlCollection = ((F_MarbleToolSawMillingHeadMilling) this).tabPage_saw.Controls;
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleToolSawMillingHeadMilling) this).tabPage_saw.Controls);
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleToolSawMillingHeadMilling) this).tabPage_mlling.Controls);
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleToolSawMillingHeadMilling) this).\u0003.Controls);
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleToolSawMillingHeadMilling) this).\u0002.Controls);
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleToolSpindleAndMagazine) this).tabPage_mainpage.Controls);
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleToolSpindleAndMagazine) this).tabPage_sawmain.Controls);
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleToolSpindleAndMagazine) this).tabPage_millihmain.Controls);
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleToolSpindleAndMagazine) this).\u0001.Controls);
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleToolSawMilling) this).\u0004.Controls);
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleSawMillingStrategyMenu) this).\u0005.Controls);
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleToolAndStrategyMenu) this).\u0006.Controls);
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleToolAndStrategyMenu) this).\u0005.Controls);
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleToolAndStrategyMenu) this).\u0008.Controls);
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleToolAndStrategyMenu) this).\u0007.Controls);
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleToolSpindleAndMagazine) this).\u0001.Controls);
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleToolSpindleAndMagazine) this).\u0002.Controls);
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleToolSawMilling) this).\u0003.Controls);
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleToolSawMilling) this).\u0004.Controls);
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleSawMillingMenu) this).\u000E.Controls);
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleSawMillingMenu) this).\u000F.Controls);
    }
    ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.VisualUpdated = true;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleToolSpindleAndMagazine) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
    // ISSUE: unable to decompile the method.
  }

  public void MenuButtonColors(int PageIndex)
  {
    ((F_MarbleToolSpindleAndMagazine) this).buTab_Main.SelectedIndex = PageIndex;
    buEyeShotFunctions.SetVisualItem(((F_MarbleToolSpindleAndMagazine) this).buGround1.Controls);
    if (PageIndex == 0)
      ((F_MarbleToolSpindleAndMagazine) this).btn_strategy = buControlCommands.SetButtonColorAll(((F_MarbleToolSpindleAndMagazine) this).btn_strategy, ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor);
    if (PageIndex == 1)
      ((F_MarbleSawMillingMenu) this).btn_options = buControlCommands.SetButtonColorAll(((F_MarbleSawMillingMenu) this).btn_options, ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor);
    if (PageIndex == 2)
      ((F_MarbleSawMillingMenu) this).btn_advanced = buControlCommands.SetButtonColorAll(((F_MarbleSawMillingMenu) this).btn_advanced, ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor);
    if (PageIndex == 3)
      ((F_MarbleToolSpindleAndMagazine) this).btn_saw = buControlCommands.SetButtonColorAll(((F_MarbleToolSpindleAndMagazine) this).btn_saw, ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor);
    if (PageIndex == 4)
      ((F_MarbleToolSpindleAndMagazine) this).btn_milling = buControlCommands.SetButtonColorAll(((F_MarbleToolSpindleAndMagazine) this).btn_milling, ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor);
    if (PageIndex == 5)
      ((F_MarbleToolSpindleAndMagazine) this).btn_millinghead = buControlCommands.SetButtonColorAll(((F_MarbleToolSpindleAndMagazine) this).btn_millinghead, ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor);
    if (PageIndex != 6)
      return;
    ((F_MarbleToolSawMillingHeadMilling) this).btn_material = buControlCommands.SetButtonColorAll(((F_MarbleToolSawMillingHeadMilling) this).btn_material, ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor);
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  public event OkCommandWithThreeDataEventHandler CommandExecute;
}
