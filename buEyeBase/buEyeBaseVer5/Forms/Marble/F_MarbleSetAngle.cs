// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleSetAngle
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleSetAngle : Form
{
  public buButton btn_contourmenufilelist;
  public buButton btn_contourmenufromfile;
  public buButton btn_close;
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buButton btn_camsettings;
  public buButton btn_toolsettings;
  public buButton btn_strategy;
  public buButton btn_tool;
  internal buSeparator \u0001;
  internal buSeparator \u0002;
  public buGround buGround1;
  public buLabel lbl_strategytype;
  public buLabel lbl_tooltype;
  public buLabel lbl_contourtype;
  public static byte f002946;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;

  static F_MarbleSetAngle() => F_MarbleHorizontalCutV2.Captions = new List<string>();

  public F_MarbleSetAngle()
  {
    // ISSUE: unable to decompile the method.
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleLathe) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleLathe) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleLathe) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleLathe) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init()
  {
    // ISSUE: unable to decompile the method.
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleProfileCut) this).lbl_contourtype.Text = $"{buLangTranslate.preDef.Drill} {buLangTranslate.preDef.Type}";
      ((F_MarbleProfileCut) this).lbl_strategytype.Text = $"{buLangTranslate.preDef.Strategy} {buLangTranslate.preDef.Type}";
      ((F_MarbleProfileCut) this).lbl_tooltype.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Type}";
      ((F_MarbleProfileCut) this).btn_editor.Text = buLangTranslate.preDef.Editor;
      ((F_MarbleProfileCut) this).btn_fromfile.Text = buLangTranslate.preDef.FromFile;
      ((F_MarbleProfileCut) this).btn_fromtable.Text = buLangTranslate.preDef.FromTable;
      ((F_MarbleProfileCut) this).btn_coordinate.Text = buLangTranslate.preDef.Coordinate;
      ((F_MarbleProfileCut) this).btn_strategy.Text = buLangTranslate.preDef.Strategy;
      ((F_MarbleProfileCut) this).btn_tool.Text = buLangTranslate.preDef.Tool;
      ((F_MarbleProfileCut) this).buGround1.Text = $"{buLangTranslate.preDef.Drill} {buLangTranslate.preDef.Menu}";
    }
    catch (Exception ex)
    {
    }
  }

  public void StrategyMillingToImageIndex()
  {
    if (((MarbleMotionCommands) ((F_MarbleLathe) this).MenuType).selectedWireframeType == CamWireFrameType.CenterPath)
      ((F_MarbleProfileCut) this).btn_strategy.Image = ((F_MarbleProfileCut) this).\u0001.Images[0];
    if (((MarbleMotionCommands) ((F_MarbleLathe) this).MenuType).selectedWireframeType == CamWireFrameType.Chamfer2D)
      ((F_MarbleProfileCut) this).btn_strategy.Image = ((F_MarbleProfileCut) this).\u0001.Images[1];
    if (((MarbleMotionCommands) ((F_MarbleLathe) this).MenuType).selectedWireframeType == CamWireFrameType.Contour)
      ((F_MarbleProfileCut) this).btn_strategy.Image = ((F_MarbleProfileCut) this).\u0001.Images[6];
    if (((MarbleMotionCommands) ((F_MarbleLathe) this).MenuType).selectedWireframeType == CamWireFrameType.Engrave)
      ((F_MarbleProfileCut) this).btn_strategy.Image = ((F_MarbleProfileCut) this).\u0001.Images[3];
    if (((MarbleMotionCommands) ((F_MarbleLathe) this).MenuType).selectedWireframeType == CamWireFrameType.Face)
      ((F_MarbleProfileCut) this).btn_strategy.Image = ((F_MarbleProfileCut) this).\u0001.Images[4];
    if (((MarbleMotionCommands) ((F_MarbleLathe) this).MenuType).selectedWireframeType == CamWireFrameType.FloorFinish)
      ((F_MarbleProfileCut) this).btn_strategy.Image = ((F_MarbleProfileCut) this).\u0001.Images[5];
    if (((MarbleMotionCommands) ((F_MarbleLathe) this).MenuType).selectedWireframeType == CamWireFrameType.Pocket)
      ((F_MarbleProfileCut) this).btn_strategy.Image = ((F_MarbleProfileCut) this).\u0001.Images[7];
    if (((MarbleMotionCommands) ((F_MarbleLathe) this).MenuType).selectedWireframeType == CamWireFrameType.TextEngrave)
      ((F_MarbleProfileCut) this).btn_strategy.Image = ((F_MarbleProfileCut) this).\u0001.Images[8];
    if (((MarbleMotionCommands) ((F_MarbleLathe) this).MenuType).selectedWireframeType == CamWireFrameType.Trochoidal)
      ((F_MarbleProfileCut) this).btn_strategy.Image = ((F_MarbleProfileCut) this).\u0001.Images[9];
    ((F_MarbleProfileCut) this).btn_strategy.Text = $"{buLangTranslate.preDef.Cam} : {((MarbleMotionCommands) ((F_MarbleLathe) this).MenuType).selectedWireframeType.ToString()}";
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
}
