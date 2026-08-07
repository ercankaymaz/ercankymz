// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleVacuumMove
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleVacuumMove : Form
{
  internal buButton \u0001;
  public buSpin spn_finishzsafedis;
  public buCheckBox chk_finishzigzag;
  public buSpin spn_finishapproachdis;
  internal buTab \u0001;
  internal TabPage \u0001;
  internal TabPage \u0002;
  public buSpin spn_roughzsafedis;
  public buSpin spn_roughapproachsafe;
  public buSpin spn_roughsurfoffset;
  public buCheckBox chk_rougjzigzag;
  public buSpin spn_roughtopoffset;
  internal buLabel \u0001;
  internal buLabel \u0002;
  public buSpin spn_finishbwdcuttingfeed;
  public buSpin spn_finishfwdcutfeed;
  public buSpin spn_finishplungefeed;
  public buSpin spn_roughbwdcuttingfeed;

  static F_MarbleVacuumMove() => F_MarbleProfileCurveCam.Captions = new List<string>();

  public F_MarbleVacuumMove()
  {
    // ISSUE: unable to decompile the method.
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleProfileCurveCam) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleProfileCurveCam) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleProfileCurveCam) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleProfileCurveCam) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init()
  {
    ((F_MarbleProfileCurveCam) this).PropertiesForm.Inited = false;
    if (((F_MarbleProfileCurveCam) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleProfileCurveCam) this).PropertiesForm.Height;
    if (((F_MarbleProfileCurveCam) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleProfileCurveCam) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleProfileCurveCam) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleProfileCurveCam) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    this.ToolToImageIndex();
    this.StrategyFromToolType();
    ((F_MarbleProfileCurveCam) this).buGround1.DisplayTop.BackColor = ((F_MarbleProfileCurveCam) this).clrFormCaption;
    ((F_MarbleProfileCurveCam) this).buGround1.Display.GradientType = GradientMode.Lineer;
    ((F_MarbleProfileCurveCam) this).buGround1.Display.LineerGradient.FirstColor = ((F_MarbleProfileCurveCam) this).clrFormBackUpper;
    ((F_MarbleProfileCurveCam) this).buGround1.Display.LineerGradient.SecondColor = ((F_MarbleProfileCurveCam) this).clrFormBackDown;
    ((F_MarbleProfileCurveCam) this).btn_close.Display.BackColor = ((F_MarbleProfileCurveCam) this).clrFormCaption;
    ((F_MarbleProfileCurveCam) this).btn_close.ButtonDownDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleProfileCurveCam) this).clrFormCaption, 0.9);
    ((F_MarbleProfileCurveCam) this).btn_close.ButtonOverDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleProfileCurveCam) this).clrFormCaption, 0.95);
    ((F_MarbleProfileCurveCam) this).lbl_contourtype.Display.BackColor = ((F_MarbleProfileCurveCam) this).clrLabel;
    ((F_MarbleProfileCurveCam) this).lbl_strategytype.Display.BackColor = ((F_MarbleProfileCurveCam) this).clrLabel;
    ((F_MarbleProfileCurveCam) this).lbl_tooltype.Display.BackColor = ((F_MarbleProfileCurveCam) this).clrLabel;
    ((F_MarbleProfileCurveCam) this).btn_circle.Display.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonDisplay;
    ((F_MarbleProfileCurveCam) this).btn_circle.ButtonDownDisplay.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonDown;
    ((F_MarbleProfileCurveCam) this).btn_circle.ButtonOverDisplay.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonOver;
    ((F_MarbleProfileCurveCam) this).btn_ellipse.Display.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonDisplay;
    ((F_MarbleProfileCurveCam) this).btn_ellipse.ButtonDownDisplay.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonDown;
    ((F_MarbleProfileCurveCam) this).btn_ellipse.ButtonOverDisplay.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonOver;
    ((F_MarbleProfileCurveCam) this).btn_polygon.Display.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonDisplay;
    ((F_MarbleProfileCurveCam) this).btn_polygon.ButtonDownDisplay.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonDown;
    ((F_MarbleProfileCurveCam) this).btn_polygon.ButtonOverDisplay.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonOver;
    ((F_MarbleProfileCurveCam) this).btn_rectangle.Display.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonDisplay;
    ((F_MarbleProfileCurveCam) this).btn_rectangle.ButtonDownDisplay.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonDown;
    ((F_MarbleProfileCurveCam) this).btn_rectangle.ButtonOverDisplay.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonOver;
    ((F_MarbleProfileCurveCam) this).btn_slot.Display.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonDisplay;
    ((F_MarbleProfileCurveCam) this).btn_slot.ButtonDownDisplay.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonDown;
    ((F_MarbleProfileCurveCam) this).btn_slot.ButtonOverDisplay.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonOver;
    ((F_MarbleProfileCurveCam) this).btn_trapezoid.Display.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonDisplay;
    ((F_MarbleProfileCurveCam) this).btn_trapezoid.ButtonDownDisplay.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonDown;
    ((F_MarbleProfileCurveCam) this).btn_trapezoid.ButtonOverDisplay.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonOver;
    ((F_MarbleProfileCurveCam) this).btn_triangle.Display.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonDisplay;
    ((F_MarbleProfileCurveCam) this).btn_triangle.ButtonDownDisplay.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonDown;
    ((F_MarbleProfileCurveCam) this).btn_triangle.ButtonOverDisplay.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonOver;
    ((F_MarbleProfileCurveCam) this).btn_strategy.Display.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonDisplay;
    ((F_MarbleProfileCurveCam) this).btn_strategy.ButtonDownDisplay.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonDown;
    ((F_MarbleProfileCurveCam) this).btn_strategy.ButtonOverDisplay.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonOver;
    ((F_MarbleProfileCurveCam) this).btn_tool.Display.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonDisplay;
    ((F_MarbleProfileCurveCam) this).btn_tool.ButtonDownDisplay.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonDown;
    ((F_MarbleProfileCurveCam) this).btn_tool.ButtonOverDisplay.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonOver;
    ((F_MarbleProfileCurveCam) this).btn_toolsettings.Display.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonDisplay;
    ((F_MarbleProfileCurveCam) this).btn_toolsettings.ButtonDownDisplay.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonDown;
    ((F_MarbleProfileCurveCam) this).btn_toolsettings.ButtonOverDisplay.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonOver;
    ((F_MarbleProfileCurveCam) this).btn_camsettings.Display.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonDisplay;
    ((F_MarbleProfileCurveCam) this).btn_camsettings.ButtonDownDisplay.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonDown;
    ((F_MarbleProfileCurveCam) this).btn_camsettings.ButtonOverDisplay.BackColor = ((F_MarbleProfileCurveCam) this).clrButtonOver;
    ((F_MarbleProfileCurveCam) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleProfileCurveCam) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleProfileCurveCam) this).lbl_contourtype.Text = $"{buLangTranslate.preDef.Shape} {buLangTranslate.preDef.Type}";
      ((F_MarbleProfileCurveCam) this).lbl_strategytype.Text = $"{buLangTranslate.preDef.Strategy} {buLangTranslate.preDef.Type}";
      ((F_MarbleProfileCurveCam) this).lbl_tooltype.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Type}";
      ((F_MarbleProfileCurveCam) this).btn_rectangle.Text = buLangTranslate.preDef.Rectangle;
      ((F_MarbleProfileCurveCam) this).btn_circle.Text = buLangTranslate.preDef.Cirlce;
      ((F_MarbleProfileCurveCam) this).btn_ellipse.Text = buLangTranslate.preDef.Ellipse;
      ((F_MarbleProfileCurveCam) this).btn_polygon.Text = buLangTranslate.preDef.Polygon;
      ((F_MarbleProfileCurveCam) this).btn_slot.Text = buLangTranslate.preDef.Slot;
      ((F_MarbleProfileCurveCam) this).btn_trapezoid.Text = buLangTranslate.preDef.Trapezoid;
      ((F_MarbleProfileCurveCam) this).btn_triangle.Text = buLangTranslate.preDef.Triangle;
      ((F_MarbleProfileCurveCam) this).btn_arc.Text = buLangTranslate.preDef.Arc;
      ((F_MarbleProfileCurveCam) this).btn_strategy.Text = buLangTranslate.preDef.Strategy;
      ((F_MarbleProfileCurveCam) this).btn_tool.Text = buLangTranslate.preDef.Tool;
      ((F_MarbleProfileCurveCam) this).buGround1.Text = $"{buLangTranslate.preDef.Shape} {buLangTranslate.preDef.Menu}";
    }
    catch (Exception ex)
    {
    }
  }

  public void StrategyMillingToImageIndex()
  {
    if (((MarbleMotionCommands) ((F_MarbleProfileCurveCam) this).MenuType).selectedWireframeType == CamWireFrameType.CenterPath)
      ((F_MarbleProfileCurveCam) this).btn_strategy.Image = ((F_MarbleProfileCurveCam) this).\u0001.Images[0];
    if (((MarbleMotionCommands) ((F_MarbleProfileCurveCam) this).MenuType).selectedWireframeType == CamWireFrameType.Chamfer2D)
      ((F_MarbleProfileCurveCam) this).btn_strategy.Image = ((F_MarbleProfileCurveCam) this).\u0001.Images[1];
    if (((MarbleMotionCommands) ((F_MarbleProfileCurveCam) this).MenuType).selectedWireframeType == CamWireFrameType.Contour)
      ((F_MarbleProfileCurveCam) this).btn_strategy.Image = ((F_MarbleProfileCurveCam) this).\u0001.Images[6];
    if (((MarbleMotionCommands) ((F_MarbleProfileCurveCam) this).MenuType).selectedWireframeType == CamWireFrameType.Engrave)
      ((F_MarbleProfileCurveCam) this).btn_strategy.Image = ((F_MarbleProfileCurveCam) this).\u0001.Images[3];
    if (((MarbleMotionCommands) ((F_MarbleProfileCurveCam) this).MenuType).selectedWireframeType == CamWireFrameType.Face)
      ((F_MarbleProfileCurveCam) this).btn_strategy.Image = ((F_MarbleProfileCurveCam) this).\u0001.Images[4];
    if (((MarbleMotionCommands) ((F_MarbleProfileCurveCam) this).MenuType).selectedWireframeType == CamWireFrameType.FloorFinish)
      ((F_MarbleProfileCurveCam) this).btn_strategy.Image = ((F_MarbleProfileCurveCam) this).\u0001.Images[5];
    if (((MarbleMotionCommands) ((F_MarbleProfileCurveCam) this).MenuType).selectedWireframeType == CamWireFrameType.Pocket)
      ((F_MarbleProfileCurveCam) this).btn_strategy.Image = ((F_MarbleProfileCurveCam) this).\u0001.Images[7];
    if (((MarbleMotionCommands) ((F_MarbleProfileCurveCam) this).MenuType).selectedWireframeType == CamWireFrameType.TextEngrave)
      ((F_MarbleProfileCurveCam) this).btn_strategy.Image = ((F_MarbleProfileCurveCam) this).\u0001.Images[8];
    if (((MarbleMotionCommands) ((F_MarbleProfileCurveCam) this).MenuType).selectedWireframeType == CamWireFrameType.Trochoidal)
      ((F_MarbleProfileCurveCam) this).btn_strategy.Image = ((F_MarbleProfileCurveCam) this).\u0001.Images[9];
    ((F_MarbleProfileCurveCam) this).btn_strategy.Text = $"{buLangTranslate.preDef.Cam} : {((MarbleMotionCommands) ((F_MarbleProfileCurveCam) this).MenuType).selectedWireframeType.ToString()}";
  }

  public void StrategyMillingHeadToImageIndex()
  {
    if (((MarbleMotionCommands) ((F_MarbleProfileCurveCam) this).MenuType).selectedWireframeType == CamWireFrameType.CenterPath)
      ((F_MarbleProfileCurveCam) this).btn_strategy.Image = ((F_MarbleProfileCurveCam) this).\u0001.Images[0];
    if (((MarbleMotionCommands) ((F_MarbleProfileCurveCam) this).MenuType).selectedWireframeType == CamWireFrameType.Chamfer2D)
      ((F_MarbleProfileCurveCam) this).btn_strategy.Image = ((F_MarbleProfileCurveCam) this).\u0001.Images[1];
    if (((MarbleMotionCommands) ((F_MarbleProfileCurveCam) this).MenuType).selectedWireframeType == CamWireFrameType.Contour)
      ((F_MarbleProfileCurveCam) this).btn_strategy.Image = ((F_MarbleProfileCurveCam) this).\u0001.Images[6];
    if (((MarbleMotionCommands) ((F_MarbleProfileCurveCam) this).MenuType).selectedWireframeType == CamWireFrameType.Engrave)
      ((F_MarbleProfileCurveCam) this).btn_strategy.Image = ((F_MarbleProfileCurveCam) this).\u0001.Images[3];
    if (((MarbleMotionCommands) ((F_MarbleProfileCurveCam) this).MenuType).selectedWireframeType == CamWireFrameType.Face)
      ((F_MarbleProfileCurveCam) this).btn_strategy.Image = ((F_MarbleProfileCurveCam) this).\u0001.Images[4];
    if (((MarbleMotionCommands) ((F_MarbleProfileCurveCam) this).MenuType).selectedWireframeType == CamWireFrameType.FloorFinish)
      ((F_MarbleProfileCurveCam) this).btn_strategy.Image = ((F_MarbleProfileCurveCam) this).\u0001.Images[5];
    if (((MarbleMotionCommands) ((F_MarbleProfileCurveCam) this).MenuType).selectedWireframeType == CamWireFrameType.Pocket)
      ((F_MarbleProfileCurveCam) this).btn_strategy.Image = ((F_MarbleProfileCurveCam) this).\u0001.Images[7];
    if (((MarbleMotionCommands) ((F_MarbleProfileCurveCam) this).MenuType).selectedWireframeType == CamWireFrameType.TextEngrave)
      ((F_MarbleProfileCurveCam) this).btn_strategy.Image = ((F_MarbleProfileCurveCam) this).\u0001.Images[8];
    if (((MarbleMotionCommands) ((F_MarbleProfileCurveCam) this).MenuType).selectedWireframeType == CamWireFrameType.Trochoidal)
      ((F_MarbleProfileCurveCam) this).btn_strategy.Image = ((F_MarbleProfileCurveCam) this).\u0001.Images[9];
    ((F_MarbleProfileCurveCam) this).btn_strategy.Text = $"{buLangTranslate.preDef.Cam} : {((MarbleMotionCommands) ((F_MarbleProfileCurveCam) this).MenuType).selectedWireframeType.ToString()}";
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

  public event OkCommandWithFiveDataEventHandler VacuumCommand;
}
