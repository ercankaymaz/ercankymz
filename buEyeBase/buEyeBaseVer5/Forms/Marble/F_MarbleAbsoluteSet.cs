// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleAbsoluteSet
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

public class F_MarbleAbsoluteSet : Form
{
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public MarbleToolType ToolType;
  private IContainer \u0001;
  public buButton btn_close;
  public buCheckBox chk_toolsaw;
  public buGround buGround1;
  public static byte f0025CB;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  internal IContainer \u0001;
  internal buGround \u0001;
  public buButton btn_close;
  public buButton btn_DI31;
  public buButton btn_DI16;
  public buButton btn_DI30;
  public buButton btn_DI17;
  public buButton btn_DI29;
  public buButton btn_DI18;
  public buButton btn_DI28;
  public buButton btn_DI19;
  public buButton btn_DI27;
  public buButton btn_DI20;

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleDigitalInputOutput) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleDigitalInputOutput) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init()
  {
    ((F_MarbleDigitalInputOutput) this).PropertiesForm.Inited = false;
    if (((F_MarbleDigitalInputOutput) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleDigitalInputOutput) this).PropertiesForm.Height;
    if (((F_MarbleDigitalInputOutput) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleDigitalInputOutput) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleDigitalInputOutput) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleDigitalInputOutput) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    this.ToolToImageIndex();
    this.StrategyFromToolType();
    ((F_MarbleDigitalInputOutput) this).buGround1.DisplayTop.BackColor = ((F_MarbleDigitalInputOutput) this).clrFormCaption;
    ((F_MarbleDigitalInputOutput) this).buGround1.Display.GradientType = GradientMode.Lineer;
    ((F_MarbleDigitalInputOutput) this).buGround1.Display.LineerGradient.FirstColor = ((F_MarbleDigitalInputOutput) this).clrFormBackUpper;
    ((F_MarbleDigitalInputOutput) this).buGround1.Display.LineerGradient.SecondColor = ((F_MarbleDigitalInputOutput) this).clrFormBackDown;
    ((F_MarbleDigitalInputOutput) this).btn_close.Display.BackColor = ((F_MarbleDigitalInputOutput) this).clrFormCaption;
    ((F_MarbleDigitalInputOutput) this).btn_close.ButtonDownDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleDigitalInputOutput) this).clrFormCaption, 0.9);
    ((F_MarbleDigitalInputOutput) this).btn_close.ButtonOverDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleDigitalInputOutput) this).clrFormCaption, 0.95);
    ((F_MarbleDigitalInputOutput) this).lbl_strategytype.Display.BackColor = ((F_MarbleDigitalInputOutput) this).clrLabel;
    ((F_MarbleDigitalInputOutput) this).lbl_tooltype.Display.BackColor = ((F_MarbleDigitalInputOutput) this).clrLabel;
    ((F_MarbleDigitalInputOutput) this).btn_strategy.Display.BackColor = ((F_MarbleDigitalInputOutput) this).clrButtonDisplay;
    ((F_MarbleDigitalInputOutput) this).btn_strategy.ButtonDownDisplay.BackColor = ((F_MarbleDigitalInputOutput) this).clrButtonDown;
    ((F_MarbleDigitalInputOutput) this).btn_strategy.ButtonOverDisplay.BackColor = ((F_MarbleDigitalInputOutput) this).clrButtonOver;
    ((F_MarbleDigitalInputOutput) this).btn_tool.Display.BackColor = ((F_MarbleDigitalInputOutput) this).clrButtonDisplay;
    ((F_MarbleDigitalInputOutput) this).btn_tool.ButtonDownDisplay.BackColor = ((F_MarbleDigitalInputOutput) this).clrButtonDown;
    ((F_MarbleDigitalInputOutput) this).btn_tool.ButtonOverDisplay.BackColor = ((F_MarbleDigitalInputOutput) this).clrButtonOver;
    ((F_MarbleDigitalInputOutput) this).btn_toolsettings.Display.BackColor = ((F_MarbleDigitalInputOutput) this).clrButtonDisplay;
    ((F_MarbleDigitalInputOutput) this).btn_toolsettings.ButtonDownDisplay.BackColor = ((F_MarbleDigitalInputOutput) this).clrButtonDown;
    ((F_MarbleDigitalInputOutput) this).btn_toolsettings.ButtonOverDisplay.BackColor = ((F_MarbleDigitalInputOutput) this).clrButtonOver;
    ((F_MarbleDigitalInputOutput) this).btn_camsettings.Display.BackColor = ((F_MarbleDigitalInputOutput) this).clrButtonDisplay;
    ((F_MarbleDigitalInputOutput) this).btn_camsettings.ButtonDownDisplay.BackColor = ((F_MarbleDigitalInputOutput) this).clrButtonDown;
    ((F_MarbleDigitalInputOutput) this).btn_camsettings.ButtonOverDisplay.BackColor = ((F_MarbleDigitalInputOutput) this).clrButtonOver;
    ((F_MarbleDigitalInputOutput) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleDigitalInputOutput) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleDigitalInputOutput) this).lbl_strategytype.Text = $"{buLangTranslate.preDef.Strategy} {buLangTranslate.preDef.Type}";
      ((F_MarbleDigitalInputOutput) this).lbl_tooltype.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Type}";
      ((F_MarbleDigitalInputOutput) this).btn_strategy.Text = buLangTranslate.preDef.Strategy;
      ((F_MarbleDigitalInputOutput) this).btn_tool.Text = buLangTranslate.preDef.Tool;
      ((F_MarbleDigitalInputOutput) this).buGround1.Text = $"{buLangTranslate.preDef.Tool} & {buLangTranslate.preDef.Strategy} {buLangTranslate.preDef.Menu}";
    }
    catch (Exception ex)
    {
    }
  }

  public void StrategyMillingToImageIndex()
  {
    if (((MarbleMotionCommands) ((F_MarbleDigitalInputOutput) this).MenuType).selectedWireframeType == CamWireFrameType.CenterPath)
      ((F_MarbleDigitalInputOutput) this).btn_strategy.Image = ((F_MarbleDigitalInputOutput) this).\u0001.Images[0];
    if (((MarbleMotionCommands) ((F_MarbleDigitalInputOutput) this).MenuType).selectedWireframeType == CamWireFrameType.Chamfer2D)
      ((F_MarbleDigitalInputOutput) this).btn_strategy.Image = ((F_MarbleDigitalInputOutput) this).\u0001.Images[1];
    if (((MarbleMotionCommands) ((F_MarbleDigitalInputOutput) this).MenuType).selectedWireframeType == CamWireFrameType.Contour)
      ((F_MarbleDigitalInputOutput) this).btn_strategy.Image = ((F_MarbleDigitalInputOutput) this).\u0001.Images[6];
    if (((MarbleMotionCommands) ((F_MarbleDigitalInputOutput) this).MenuType).selectedWireframeType == CamWireFrameType.Engrave)
      ((F_MarbleDigitalInputOutput) this).btn_strategy.Image = ((F_MarbleDigitalInputOutput) this).\u0001.Images[3];
    if (((MarbleMotionCommands) ((F_MarbleDigitalInputOutput) this).MenuType).selectedWireframeType == CamWireFrameType.Face)
      ((F_MarbleDigitalInputOutput) this).btn_strategy.Image = ((F_MarbleDigitalInputOutput) this).\u0001.Images[4];
    if (((MarbleMotionCommands) ((F_MarbleDigitalInputOutput) this).MenuType).selectedWireframeType == CamWireFrameType.FloorFinish)
      ((F_MarbleDigitalInputOutput) this).btn_strategy.Image = ((F_MarbleDigitalInputOutput) this).\u0001.Images[5];
    if (((MarbleMotionCommands) ((F_MarbleDigitalInputOutput) this).MenuType).selectedWireframeType == CamWireFrameType.Pocket)
      ((F_MarbleDigitalInputOutput) this).btn_strategy.Image = ((F_MarbleDigitalInputOutput) this).\u0001.Images[7];
    if (((MarbleMotionCommands) ((F_MarbleDigitalInputOutput) this).MenuType).selectedWireframeType == CamWireFrameType.TextEngrave)
      ((F_MarbleDigitalInputOutput) this).btn_strategy.Image = ((F_MarbleDigitalInputOutput) this).\u0001.Images[8];
    if (((MarbleMotionCommands) ((F_MarbleDigitalInputOutput) this).MenuType).selectedWireframeType == CamWireFrameType.Trochoidal)
      ((F_MarbleDigitalInputOutput) this).btn_strategy.Image = ((F_MarbleDigitalInputOutput) this).\u0001.Images[9];
    ((F_MarbleDigitalInputOutput) this).btn_strategy.Text = $"{buLangTranslate.preDef.Cam} : {((MarbleMotionCommands) ((F_MarbleDigitalInputOutput) this).MenuType).selectedWireframeType.ToString()}";
  }

  public void StrategySawToImageIndex()
  {
    // ISSUE: unable to decompile the method.
  }

  public void StrategyWaterToImageIndex()
  {
    // ISSUE: unable to decompile the method.
  }

  public void ToolToImageIndex()
  {
    // ISSUE: unable to decompile the method.
  }

  public void StrategyFromToolType()
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleDigitalInputOutput) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleDigitalInputOutput) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleDigitalInputOutput) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleDigitalInputOutput) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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

  public event OkCommandWithTwoDataEventHandler ResetCommand;
}
