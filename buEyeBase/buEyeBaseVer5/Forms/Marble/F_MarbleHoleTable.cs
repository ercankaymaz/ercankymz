// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleHoleTable
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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleHoleTable : Form
{
  internal buSeparator \u0002;
  public buButton btn_strategy;
  public buButton btn_tool;
  public buButton btn_camsettings;
  public buButton btn_toolsettings;
  public buGround buGround1;
  public buLabel lbl_strategytype;
  public buLabel lbl_tooltype;
  public buLabel lbl_contourtype;
  public buButton btn_camsettings2;
  public buButton btn_strategy2;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  internal RadioButton \u0003;
  public static byte f0021D8;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public MarbleToolType ToolType;
  private IContainer \u0001;
  public buButton btn_close;
  public buCheckBox chk_toolsaw;
  public buCheckBox chk_toolmilling;

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleSingleCut) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleSingleCut) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleSingleCut) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleSingleCut) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init()
  {
    ((F_MarbleMove) this).PropertiesForm.Inited = false;
    if (((F_MarbleMove) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleMove) this).PropertiesForm.Height;
    if (((F_MarbleMove) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleMove) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleMove) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleMove) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    this.ToolToImageIndex();
    this.StrategyFromToolType(0);
    this.StrategyFromToolType(1);
    this.buGround1.DisplayTop.BackColor = ((F_MarbleMove) this).clrFormCaption;
    this.buGround1.Display.GradientType = GradientMode.Lineer;
    this.buGround1.Display.LineerGradient.FirstColor = ((F_MarbleMove) this).clrFormBackUpper;
    this.buGround1.Display.LineerGradient.SecondColor = ((F_MarbleMove) this).clrFormBackDown;
    ((F_MarbleMove) this).btn_close.Display.BackColor = ((F_MarbleMove) this).clrFormCaption;
    ((F_MarbleMove) this).btn_close.ButtonDownDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleMove) this).clrFormCaption, 0.9);
    ((F_MarbleMove) this).btn_close.ButtonOverDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleMove) this).clrFormCaption, 0.95);
    this.lbl_contourtype.Display.BackColor = ((F_MarbleMove) this).clrLabel;
    this.lbl_strategytype.Display.BackColor = ((F_MarbleMove) this).clrLabel;
    this.lbl_tooltype.Display.BackColor = ((F_MarbleMove) this).clrLabel;
    if (((MarbleMotionCommands) ((F_MarbleMove) this).MenuType).AxesNumber == 3)
      this.\u0003.Checked = true;
    else if (((MarbleMotionCommands) ((F_MarbleMove) this).MenuType).AxesNumber == 4)
      this.\u0002.Checked = true;
    else if (((MarbleMotionCommands) ((F_MarbleMove) this).MenuType).AxesNumber == 5)
      this.\u0001.Checked = true;
    ((F_MarbleMove) this).btn_contourmenufilelist.Display.BackColor = ((F_MarbleMove) this).clrButtonDisplay;
    ((F_MarbleMove) this).btn_contourmenufilelist.ButtonDownDisplay.BackColor = ((F_MarbleMove) this).clrButtonDown;
    ((F_MarbleMove) this).btn_contourmenufilelist.ButtonOverDisplay.BackColor = ((F_MarbleMove) this).clrButtonOver;
    ((F_MarbleMove) this).btn_contourmenufromfile.Display.BackColor = ((F_MarbleMove) this).clrButtonDisplay;
    ((F_MarbleMove) this).btn_contourmenufromfile.ButtonDownDisplay.BackColor = ((F_MarbleMove) this).clrButtonDown;
    ((F_MarbleMove) this).btn_contourmenufromfile.ButtonOverDisplay.BackColor = ((F_MarbleMove) this).clrButtonOver;
    this.btn_strategy.Display.BackColor = ((F_MarbleMove) this).clrButtonDisplay;
    this.btn_strategy.ButtonDownDisplay.BackColor = ((F_MarbleMove) this).clrButtonDown;
    this.btn_strategy.ButtonOverDisplay.BackColor = ((F_MarbleMove) this).clrButtonOver;
    this.btn_strategy2.Display.BackColor = ((F_MarbleMove) this).clrButtonDisplay;
    this.btn_strategy2.ButtonDownDisplay.BackColor = ((F_MarbleMove) this).clrButtonDown;
    this.btn_strategy2.ButtonOverDisplay.BackColor = ((F_MarbleMove) this).clrButtonOver;
    this.btn_tool.Display.BackColor = ((F_MarbleMove) this).clrButtonDisplay;
    this.btn_tool.ButtonDownDisplay.BackColor = ((F_MarbleMove) this).clrButtonDown;
    this.btn_tool.ButtonOverDisplay.BackColor = ((F_MarbleMove) this).clrButtonOver;
    this.btn_toolsettings.Display.BackColor = ((F_MarbleMove) this).clrButtonDisplay;
    this.btn_toolsettings.ButtonDownDisplay.BackColor = ((F_MarbleMove) this).clrButtonDown;
    this.btn_toolsettings.ButtonOverDisplay.BackColor = ((F_MarbleMove) this).clrButtonOver;
    this.btn_camsettings.Display.BackColor = ((F_MarbleMove) this).clrButtonDisplay;
    this.btn_camsettings.ButtonDownDisplay.BackColor = ((F_MarbleMove) this).clrButtonDown;
    this.btn_camsettings.ButtonOverDisplay.BackColor = ((F_MarbleMove) this).clrButtonOver;
    ((F_MarbleMove) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleMove) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      this.lbl_contourtype.Text = $"{buLangTranslate.preDef.Engrave} {buLangTranslate.preDef.Type}";
      this.lbl_strategytype.Text = $"{buLangTranslate.preDef.Strategy} {buLangTranslate.preDef.Type}";
      this.lbl_tooltype.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Type}";
      ((F_MarbleMove) this).btn_contourmenufilelist.Text = buLangTranslate.preDef.FromList;
      ((F_MarbleMove) this).btn_contourmenufromfile.Text = buLangTranslate.preDef.FromFile;
      this.btn_strategy.Text = buLangTranslate.preDef.Strategy;
      this.btn_tool.Text = buLangTranslate.preDef.Tool;
      this.buGround1.Text = $"5 {buLangTranslate.preDef.Axis} {buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Menu}";
    }
    catch (Exception ex)
    {
    }
  }

  public void StrategyMillingToImageIndex(int Index)
  {
    if (Index == 0)
    {
      if (((MarbleMotionCommands) ((F_MarbleMove) this).MenuType).selectedMesh5AxisType == CamTriangularMeshType.Rough)
        this.btn_strategy.Image = ((F_MarbleMove) this).\u0001.Images[0];
      if (((MarbleMotionCommands) ((F_MarbleMove) this).MenuType).selectedMesh5AxisType == CamTriangularMeshType.ParallelCuts)
        this.btn_strategy.Image = ((F_MarbleMove) this).\u0001.Images[1];
      if (((MarbleMotionCommands) ((F_MarbleMove) this).MenuType).selectedMesh5AxisType == CamTriangularMeshType.ConstantZ)
        this.btn_strategy.Image = ((F_MarbleMove) this).\u0001.Images[2];
      if (((MarbleMotionCommands) ((F_MarbleMove) this).MenuType).selectedMesh5AxisType == CamTriangularMeshType.None)
        this.btn_strategy.Image = ((F_MarbleMove) this).\u0001.Images[3];
      this.btn_strategy.Text = $"{buLangTranslate.preDef.Cam} : {((MarbleMotionCommands) ((F_MarbleMove) this).MenuType).selectedMesh5AxisType.ToString()}";
    }
    if (Index != 1)
      return;
    if (((MarbleMotionCommands) ((F_MarbleMove) this).MenuType).selectedMesh5AxisType2 == CamTriangularMeshType.Rough)
      this.btn_strategy2.Image = ((F_MarbleMove) this).\u0001.Images[0];
    if (((MarbleMotionCommands) ((F_MarbleMove) this).MenuType).selectedMesh5AxisType2 == CamTriangularMeshType.ParallelCuts)
      this.btn_strategy2.Image = ((F_MarbleMove) this).\u0001.Images[1];
    if (((MarbleMotionCommands) ((F_MarbleMove) this).MenuType).selectedMesh5AxisType2 == CamTriangularMeshType.ConstantZ)
      this.btn_strategy2.Image = ((F_MarbleMove) this).\u0001.Images[2];
    if (((MarbleMotionCommands) ((F_MarbleMove) this).MenuType).selectedMesh5AxisType2 == CamTriangularMeshType.None)
      this.btn_strategy2.Image = ((F_MarbleMove) this).\u0001.Images[3];
    this.btn_strategy2.Text = $"{buLangTranslate.preDef.Cam} : {((MarbleMotionCommands) ((F_MarbleMove) this).MenuType).selectedMesh5AxisType2.ToString()}";
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
    if (((F_MarbleMove) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleMove) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleMove) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleMove) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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
    ((F_MarbleMove) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleMove) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleMove) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleMove) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleMove) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleHoleTable() => F_MarbleMove.Captions = new List<string>();
}
