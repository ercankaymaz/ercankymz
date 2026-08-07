// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleDrillMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleDrillMenu : Form
{
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buSpin spn_baseheight;
  public buSpin spn_sweepangle;
  public buSpin spn_startangle;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buButton \u0001;
  public buSpin spn_radius;
  public buButton btn_settings;
  public buCheckBox chk_finish;
  public buCheckBox chk_rough;
  internal buLabel \u0001;
  public buCheckBox chk_cutprofileend;
  public buCheckBox chk_cutprofilestart;
  internal buLabel \u0002;
  public buSpin spn_twistEA;
  public buSpin spn_twistSA;
  public buCheckBox chk_twistenable;
  internal buLabel \u0003;
  internal Panel \u0001;
  public buCheckBox chk_verticalcut;
  internal buLabel \u0004;
  public FormProperties Properties;
  public static List<string> Captions;
  public marbleAirDryPars varAirDry;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buButton \u0001;

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleSweepCut) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleSweepCut) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init()
  {
    ((F_MarbleSweepCut) this).PropertiesForm.Inited = false;
    if (((F_MarbleSweepCut) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleSweepCut) this).PropertiesForm.Height;
    if (((F_MarbleSweepCut) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleSweepCut) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleSweepCut) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleSweepCut) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    this.ToolToImageIndex();
    this.StrategyFromToolType(0);
    this.StrategyFromToolType(1);
    ((F_MarbleSweepMenu) this).buGround1.DisplayTop.BackColor = ((F_MarbleSweepCut) this).clrFormCaption;
    ((F_MarbleSweepMenu) this).buGround1.Display.GradientType = GradientMode.Lineer;
    ((F_MarbleSweepMenu) this).buGround1.Display.LineerGradient.FirstColor = ((F_MarbleSweepCut) this).clrFormBackUpper;
    ((F_MarbleSweepMenu) this).buGround1.Display.LineerGradient.SecondColor = ((F_MarbleSweepCut) this).clrFormBackDown;
    ((F_MarbleSweepCut) this).btn_close.Display.BackColor = ((F_MarbleSweepCut) this).clrFormCaption;
    ((F_MarbleSweepCut) this).btn_close.ButtonDownDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleSweepCut) this).clrFormCaption, 0.9);
    ((F_MarbleSweepCut) this).btn_close.ButtonOverDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleSweepCut) this).clrFormCaption, 0.95);
    ((F_MarbleSweepMenu) this).lbl_contourtype.Display.BackColor = ((F_MarbleSweepCut) this).clrLabel;
    ((F_MarbleSweepMenu) this).lbl_strategytype.Display.BackColor = ((F_MarbleSweepCut) this).clrLabel;
    ((F_MarbleSweepMenu) this).lbl_tooltype.Display.BackColor = ((F_MarbleSweepCut) this).clrLabel;
    ((F_MarbleSweepCut) this).btn_contourmenueditor.Display.BackColor = ((F_MarbleSweepCut) this).clrButtonDisplay;
    ((F_MarbleSweepCut) this).btn_contourmenueditor.ButtonDownDisplay.BackColor = ((F_MarbleSweepCut) this).clrButtonDown;
    ((F_MarbleSweepCut) this).btn_contourmenueditor.ButtonOverDisplay.BackColor = ((F_MarbleSweepCut) this).clrButtonOver;
    ((F_MarbleSweepCut) this).btn_contourmenufilelist.Display.BackColor = ((F_MarbleSweepCut) this).clrButtonDisplay;
    ((F_MarbleSweepCut) this).btn_contourmenufilelist.ButtonDownDisplay.BackColor = ((F_MarbleSweepCut) this).clrButtonDown;
    ((F_MarbleSweepCut) this).btn_contourmenufilelist.ButtonOverDisplay.BackColor = ((F_MarbleSweepCut) this).clrButtonOver;
    ((F_MarbleSweepCut) this).btn_contourmenufromfile.Display.BackColor = ((F_MarbleSweepCut) this).clrButtonDisplay;
    ((F_MarbleSweepCut) this).btn_contourmenufromfile.ButtonDownDisplay.BackColor = ((F_MarbleSweepCut) this).clrButtonDown;
    ((F_MarbleSweepCut) this).btn_contourmenufromfile.ButtonOverDisplay.BackColor = ((F_MarbleSweepCut) this).clrButtonOver;
    ((F_MarbleSweepMenu) this).btn_strategy.Display.BackColor = ((F_MarbleSweepCut) this).clrButtonDisplay;
    ((F_MarbleSweepMenu) this).btn_strategy.ButtonDownDisplay.BackColor = ((F_MarbleSweepCut) this).clrButtonDown;
    ((F_MarbleSweepMenu) this).btn_strategy.ButtonOverDisplay.BackColor = ((F_MarbleSweepCut) this).clrButtonOver;
    ((F_MarbleSweepMenu) this).btn_strategy2.Display.BackColor = ((F_MarbleSweepCut) this).clrButtonDisplay;
    ((F_MarbleSweepMenu) this).btn_strategy2.ButtonDownDisplay.BackColor = ((F_MarbleSweepCut) this).clrButtonDown;
    ((F_MarbleSweepMenu) this).btn_strategy2.ButtonOverDisplay.BackColor = ((F_MarbleSweepCut) this).clrButtonOver;
    ((F_MarbleSweepMenu) this).btn_tool.Display.BackColor = ((F_MarbleSweepCut) this).clrButtonDisplay;
    ((F_MarbleSweepMenu) this).btn_tool.ButtonDownDisplay.BackColor = ((F_MarbleSweepCut) this).clrButtonDown;
    ((F_MarbleSweepMenu) this).btn_tool.ButtonOverDisplay.BackColor = ((F_MarbleSweepCut) this).clrButtonOver;
    ((F_MarbleSweepMenu) this).btn_toolsettings.Display.BackColor = ((F_MarbleSweepCut) this).clrButtonDisplay;
    ((F_MarbleSweepMenu) this).btn_toolsettings.ButtonDownDisplay.BackColor = ((F_MarbleSweepCut) this).clrButtonDown;
    ((F_MarbleSweepMenu) this).btn_toolsettings.ButtonOverDisplay.BackColor = ((F_MarbleSweepCut) this).clrButtonOver;
    ((F_MarbleSweepMenu) this).btn_camsettings.Display.BackColor = ((F_MarbleSweepCut) this).clrButtonDisplay;
    ((F_MarbleSweepMenu) this).btn_camsettings.ButtonDownDisplay.BackColor = ((F_MarbleSweepCut) this).clrButtonDown;
    ((F_MarbleSweepMenu) this).btn_camsettings.ButtonOverDisplay.BackColor = ((F_MarbleSweepCut) this).clrButtonOver;
    ((F_MarbleSweepCut) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleSweepCut) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleSweepMenu) this).lbl_contourtype.Text = $"{buLangTranslate.preDef.Engrave} {buLangTranslate.preDef.Type}";
      ((F_MarbleSweepMenu) this).lbl_strategytype.Text = $"{buLangTranslate.preDef.Strategy} {buLangTranslate.preDef.Type}";
      ((F_MarbleSweepMenu) this).lbl_tooltype.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Type}";
      ((F_MarbleSweepCut) this).btn_contourmenueditor.Text = buLangTranslate.preDef.Editor;
      ((F_MarbleSweepCut) this).btn_contourmenufilelist.Text = buLangTranslate.preDef.FromList;
      ((F_MarbleSweepCut) this).btn_contourmenufromfile.Text = buLangTranslate.preDef.FromFile;
      ((F_MarbleSweepMenu) this).btn_strategy.Text = buLangTranslate.preDef.Strategy;
      ((F_MarbleSweepMenu) this).chk_5Axismilling.Text = $"5 {buLangTranslate.preDef.Axes} {buLangTranslate.preDef.Milling}";
      ((F_MarbleSweepMenu) this).btn_tool.Text = buLangTranslate.preDef.Tool;
      ((F_MarbleSweepMenu) this).buGround1.Text = $"{buLangTranslate.preDef.Engrave} {buLangTranslate.preDef.Menu}";
    }
    catch (Exception ex)
    {
    }
  }

  public void StrategyMillingToImageIndex(int Index)
  {
    if (Index == 0)
    {
      if (((MarbleMotionCommands) ((F_MarbleSweepCut) this).MenuType).selectedMeshType == CamTriangularMeshType.Rough)
        ((F_MarbleSweepMenu) this).btn_strategy.Image = ((F_MarbleSweepMenu) this).\u0001.Images[0];
      if (((MarbleMotionCommands) ((F_MarbleSweepCut) this).MenuType).selectedMeshType == CamTriangularMeshType.ParallelCuts)
        ((F_MarbleSweepMenu) this).btn_strategy.Image = ((F_MarbleSweepMenu) this).\u0001.Images[1];
      if (((MarbleMotionCommands) ((F_MarbleSweepCut) this).MenuType).selectedMeshType == CamTriangularMeshType.ConstantZ)
        ((F_MarbleSweepMenu) this).btn_strategy.Image = ((F_MarbleSweepMenu) this).\u0001.Images[2];
      if (((MarbleMotionCommands) ((F_MarbleSweepCut) this).MenuType).selectedMeshType == CamTriangularMeshType.Flatlands)
        ((F_MarbleSweepMenu) this).btn_strategy.Image = ((F_MarbleSweepMenu) this).\u0001.Images[3];
      if (((MarbleMotionCommands) ((F_MarbleSweepCut) this).MenuType).selectedMeshType == CamTriangularMeshType.Pencil)
        ((F_MarbleSweepMenu) this).btn_strategy.Image = ((F_MarbleSweepMenu) this).\u0001.Images[4];
      if (((MarbleMotionCommands) ((F_MarbleSweepCut) this).MenuType).selectedMeshType == CamTriangularMeshType.None)
        ((F_MarbleSweepMenu) this).btn_strategy.Image = ((F_MarbleSweepMenu) this).\u0001.Images[5];
      ((F_MarbleSweepMenu) this).btn_strategy.Text = $"{buLangTranslate.preDef.Cam} : {((MarbleMotionCommands) ((F_MarbleSweepCut) this).MenuType).selectedMeshType.ToString()}";
    }
    if (Index != 1)
      return;
    if (((MarbleMotionCommands) ((F_MarbleSweepCut) this).MenuType).selectedMeshType2 == CamTriangularMeshType.Rough)
      ((F_MarbleSweepMenu) this).btn_strategy2.Image = ((F_MarbleSweepMenu) this).\u0001.Images[0];
    if (((MarbleMotionCommands) ((F_MarbleSweepCut) this).MenuType).selectedMeshType2 == CamTriangularMeshType.ParallelCuts)
      ((F_MarbleSweepMenu) this).btn_strategy2.Image = ((F_MarbleSweepMenu) this).\u0001.Images[1];
    if (((MarbleMotionCommands) ((F_MarbleSweepCut) this).MenuType).selectedMeshType2 == CamTriangularMeshType.ConstantZ)
      ((F_MarbleSweepMenu) this).btn_strategy2.Image = ((F_MarbleSweepMenu) this).\u0001.Images[2];
    if (((MarbleMotionCommands) ((F_MarbleSweepCut) this).MenuType).selectedMeshType2 == CamTriangularMeshType.Flatlands)
      ((F_MarbleSweepMenu) this).btn_strategy2.Image = ((F_MarbleSweepMenu) this).\u0001.Images[3];
    if (((MarbleMotionCommands) ((F_MarbleSweepCut) this).MenuType).selectedMeshType2 == CamTriangularMeshType.Pencil)
      ((F_MarbleSweepMenu) this).btn_strategy2.Image = ((F_MarbleSweepMenu) this).\u0001.Images[4];
    if (((MarbleMotionCommands) ((F_MarbleSweepCut) this).MenuType).selectedMeshType2 == CamTriangularMeshType.None)
      ((F_MarbleSweepMenu) this).btn_strategy2.Image = ((F_MarbleSweepMenu) this).\u0001.Images[5];
    ((F_MarbleSweepMenu) this).btn_strategy2.Text = $"{buLangTranslate.preDef.Cam} : {((MarbleMotionCommands) ((F_MarbleSweepCut) this).MenuType).selectedMeshType2.ToString()}";
  }

  public void ToolToImageIndex()
  {
    // ISSUE: unable to decompile the method.
  }

  public void StrategyFromToolType(int Index)
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleSweepCut) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleSweepCut) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleSweepCut) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleSweepCut) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleSweepCut) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleSweepCut) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleSweepCut) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleSweepCut) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleSweepCut) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleDrillMenu() => F_MarbleSweepCut.Captions = new List<string>();

  public F_MarbleDrillMenu()
  {
    // ISSUE: unable to decompile the method.
  }

  public void Init()
  {
    ((F_MarbleSweepMenu) this).PropertiesForm.Inited = false;
    if (((F_MarbleSweepMenu) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleSweepMenu) this).PropertiesForm.Height;
    if (((F_MarbleSweepMenu) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleSweepMenu) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleSweepMenu) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleSweepMenu) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleSweepMenu) this).chk_toolmilling.Check = false;
    ((F_MarbleSweepMenu) this).chk_toolmilling.Check = true;
    ((F_MarbleSweepMenu) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleSweepMenu) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleSweepMenu) this).chk_toolmilling.Text = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Tool}";
      ((F_MarbleSweepMenu) this).buGround1.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Menu}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleSweepMenu) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleSweepMenu) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleSweepMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleSweepMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public event OkCommandWithFiveDataEventHandler CommandExecute;
}
