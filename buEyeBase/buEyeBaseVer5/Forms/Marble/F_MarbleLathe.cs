// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleLathe
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleLathe : Form
{
  public buLabel lbl_tooltype;
  public buLabel lbl_contourtype;
  public buCheckBox chk_addtonesting;
  public buButton btn_camsettings2;
  public buButton btn_strategy2;
  public static byte f0028BE;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public MarbleDrillMenuType DrillType;
  public MarbleItemType ItemType;
  public marbleMenuType MenuType;
  public Color clrLabel;
  public Color clrFormCaption;
  public Color clrFormBackUpper;
  public Color clrFormBackDown;
  public Color clrButtonDisplay;
  public Color clrButtonOver;
  public Color clrButtonDown;
  internal IContainer \u0001;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleCutting) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleCutting) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleLathe() => F_MarbleCutting.Captions = new List<string>();

  public F_MarbleLathe()
  {
    // ISSUE: unable to decompile the method.
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleCutting) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleCutting) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleCutting) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleCutting) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init()
  {
    ((F_MarbleCutting) this).PropertiesForm.Inited = false;
    if (((F_MarbleCutting) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleCutting) this).PropertiesForm.Height;
    if (((F_MarbleCutting) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleCutting) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleCutting) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleCutting) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleProfileCut) this).ToolToImageIndex();
    ((F_MarbleProfileCut) this).StrategyFromToolType();
    if (!((F_MarbleCutting) this).PropertiesForm.VisualUpdated)
      this.InitVisual();
    ((F_MarbleHorizontalCutV2) this).btn_objectlocation.Image = ((F_MarbleHorizontalCutV2) this).\u0003.Images[Convert.ToInt32((object) ((MarbleMotionCommands) ((F_MarbleCutting) this).MenuType).objectAlignment)];
    ((F_MarbleHorizontalCutV2) this).chk_insidemilling.Check = ((MarbleMotionCommands) ((F_MarbleCutting) this).MenuType).InsideMilling;
    ((F_MarbleHorizontalCutV2) this).buGround1.DisplayTop.BackColor = ((F_MarbleCutting) this).clrFormCaption;
    ((F_MarbleHorizontalCutV2) this).buGround1.Display.GradientType = GradientMode.Lineer;
    ((F_MarbleHorizontalCutV2) this).buGround1.Display.LineerGradient.FirstColor = ((F_MarbleCutting) this).clrFormBackUpper;
    ((F_MarbleHorizontalCutV2) this).buGround1.Display.LineerGradient.SecondColor = ((F_MarbleCutting) this).clrFormBackDown;
    ((F_MarbleHorizontalCutV2) this).btn_close.Display.BackColor = ((F_MarbleCutting) this).clrFormCaption;
    ((F_MarbleHorizontalCutV2) this).btn_close.ButtonDownDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleCutting) this).clrFormCaption, 0.9);
    ((F_MarbleHorizontalCutV2) this).btn_close.ButtonOverDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleCutting) this).clrFormCaption, 0.95);
    ((F_MarbleHorizontalCutV2) this).lbl_contourtype.Display.BackColor = ((F_MarbleCutting) this).clrLabel;
    ((F_MarbleHorizontalCutV2) this).lbl_strategytype.Display.BackColor = ((F_MarbleCutting) this).clrLabel;
    ((F_MarbleHorizontalCutV2) this).lbl_tooltype.Display.BackColor = ((F_MarbleCutting) this).clrLabel;
    ((F_MarbleHorizontalCutV2) this).chk_mirrorX.Check = false;
    ((F_MarbleHorizontalCutV2) this).chk_mirroY.Check = false;
    ((F_MarbleHorizontalCutV2) this).chk_rotate180plus.Check = false;
    ((F_MarbleHorizontalCutV2) this).chk_rotate90plus.Check = false;
    ((F_MarbleHorizontalCutV2) this).chk_rotate180minus.Check = false;
    ((F_MarbleHorizontalCutV2) this).chk_rotate90minus.Check = false;
    ((F_MarbleHorizontalCutV2) this).btn_contourmenueditor.Display.BackColor = ((F_MarbleCutting) this).clrButtonDisplay;
    ((F_MarbleHorizontalCutV2) this).btn_contourmenueditor.ButtonDownDisplay.BackColor = ((F_MarbleHorizontalCutV2) this).clrButtonDown;
    ((F_MarbleHorizontalCutV2) this).btn_contourmenueditor.ButtonOverDisplay.BackColor = ((F_MarbleCutting) this).clrButtonOver;
    ((F_MarbleHorizontalCutV2) this).btn_contourmenufilelist.Display.BackColor = ((F_MarbleCutting) this).clrButtonDisplay;
    ((F_MarbleHorizontalCutV2) this).btn_contourmenufilelist.ButtonDownDisplay.BackColor = ((F_MarbleHorizontalCutV2) this).clrButtonDown;
    ((F_MarbleHorizontalCutV2) this).btn_contourmenufilelist.ButtonOverDisplay.BackColor = ((F_MarbleCutting) this).clrButtonOver;
    ((F_MarbleHorizontalCutV2) this).btn_strategy.Display.BackColor = ((F_MarbleCutting) this).clrButtonDisplay;
    ((F_MarbleHorizontalCutV2) this).btn_strategy.ButtonDownDisplay.BackColor = ((F_MarbleHorizontalCutV2) this).clrButtonDown;
    ((F_MarbleHorizontalCutV2) this).btn_strategy.ButtonOverDisplay.BackColor = ((F_MarbleCutting) this).clrButtonOver;
    ((F_MarbleHorizontalCutV2) this).btn_tool.Display.BackColor = ((F_MarbleCutting) this).clrButtonDisplay;
    ((F_MarbleHorizontalCutV2) this).btn_tool.ButtonDownDisplay.BackColor = ((F_MarbleHorizontalCutV2) this).clrButtonDown;
    ((F_MarbleHorizontalCutV2) this).btn_tool.ButtonOverDisplay.BackColor = ((F_MarbleCutting) this).clrButtonOver;
    ((F_MarbleHorizontalCutV2) this).btn_toolsettings.Display.BackColor = ((F_MarbleCutting) this).clrButtonDisplay;
    ((F_MarbleHorizontalCutV2) this).btn_toolsettings.ButtonDownDisplay.BackColor = ((F_MarbleHorizontalCutV2) this).clrButtonDown;
    ((F_MarbleHorizontalCutV2) this).btn_toolsettings.ButtonOverDisplay.BackColor = ((F_MarbleCutting) this).clrButtonOver;
    ((F_MarbleHorizontalCutV2) this).btn_camsettings.Display.BackColor = ((F_MarbleCutting) this).clrButtonDisplay;
    ((F_MarbleHorizontalCutV2) this).btn_camsettings.ButtonDownDisplay.BackColor = ((F_MarbleHorizontalCutV2) this).clrButtonDown;
    ((F_MarbleHorizontalCutV2) this).btn_camsettings.ButtonOverDisplay.BackColor = ((F_MarbleCutting) this).clrButtonOver;
    ((F_MarbleCutting) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleCutting) this).PropertiesForm.Inited = true;
  }

  public void InitVisual()
  {
    if (new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm").Exists)
    {
      Control.ControlCollection controlCollection = (Control.ControlCollection) null;
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleHorizontalCutV2) this).buGround1.Controls);
    }
    ((F_MarbleCutting) this).PropertiesForm.VisualUpdated = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleHorizontalCutV2) this).lbl_contourtype.Text = $"{buLangTranslate.preDef.Library} {buLangTranslate.preDef.Type}";
      ((F_MarbleHorizontalCutV2) this).lbl_strategytype.Text = $"{buLangTranslate.preDef.Strategy} {buLangTranslate.preDef.Type}";
      ((F_MarbleHorizontalCutV2) this).lbl_tooltype.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Type}";
      ((F_MarbleHorizontalCutV2) this).btn_contourmenueditor.Text = buLangTranslate.preDef.Editor;
      ((F_MarbleHorizontalCutV2) this).btn_contourmenufilelist.Text = buLangTranslate.preDef.FromList;
      ((F_MarbleHorizontalCutV2) this).btn_strategy.Text = buLangTranslate.preDef.Strategy;
      ((F_MarbleHorizontalCutV2) this).btn_tool.Text = buLangTranslate.preDef.Tool;
      ((F_MarbleHorizontalCutV2) this).chk_addtonesting.Text = $"{buLangTranslate.preDef.Nesting} {buLangTranslate.preDef.Add}";
      ((F_MarbleHorizontalCutV2) this).buGround1.Text = $"{buLangTranslate.preDef.Library} {buLangTranslate.preDef.Menu}";
      ((F_MarbleHorizontalCutV2) this).chk_mirrorX.Text = buLangTranslate.preDef.Mirror + " X";
      ((F_MarbleHorizontalCutV2) this).chk_mirroY.Text = buLangTranslate.preDef.Mirror + " Y";
      ((F_MarbleHorizontalCutV2) this).lbl_events.Text = buLangTranslate.preDef.Events;
    }
    catch (Exception ex)
    {
    }
  }

  public void StrategyMillingToImageIndex()
  {
    if (((MarbleMotionCommands) ((F_MarbleCutting) this).MenuType).selectedWireframeType == CamWireFrameType.CenterPath)
      ((F_MarbleHorizontalCutV2) this).btn_strategy.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[0];
    if (((MarbleMotionCommands) ((F_MarbleCutting) this).MenuType).selectedWireframeType == CamWireFrameType.Chamfer2D)
      ((F_MarbleHorizontalCutV2) this).btn_strategy.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[1];
    if (((MarbleMotionCommands) ((F_MarbleCutting) this).MenuType).selectedWireframeType == CamWireFrameType.Contour)
      ((F_MarbleHorizontalCutV2) this).btn_strategy.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[6];
    if (((MarbleMotionCommands) ((F_MarbleCutting) this).MenuType).selectedWireframeType == CamWireFrameType.Engrave)
      ((F_MarbleHorizontalCutV2) this).btn_strategy.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[3];
    if (((MarbleMotionCommands) ((F_MarbleCutting) this).MenuType).selectedWireframeType == CamWireFrameType.Face)
      ((F_MarbleHorizontalCutV2) this).btn_strategy.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[4];
    if (((MarbleMotionCommands) ((F_MarbleCutting) this).MenuType).selectedWireframeType == CamWireFrameType.FloorFinish)
      ((F_MarbleHorizontalCutV2) this).btn_strategy.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[5];
    if (((MarbleMotionCommands) ((F_MarbleCutting) this).MenuType).selectedWireframeType == CamWireFrameType.Pocket)
      ((F_MarbleHorizontalCutV2) this).btn_strategy.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[7];
    if (((MarbleMotionCommands) ((F_MarbleCutting) this).MenuType).selectedWireframeType == CamWireFrameType.TextEngrave)
      ((F_MarbleHorizontalCutV2) this).btn_strategy.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[8];
    if (((MarbleMotionCommands) ((F_MarbleCutting) this).MenuType).selectedWireframeType == CamWireFrameType.Trochoidal)
      ((F_MarbleHorizontalCutV2) this).btn_strategy.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[9];
    ((F_MarbleHorizontalCutV2) this).btn_strategy.Text = $"{buLangTranslate.preDef.Cam} : {((MarbleMotionCommands) ((F_MarbleCutting) this).MenuType).selectedWireframeType.ToString()}";
  }
}
