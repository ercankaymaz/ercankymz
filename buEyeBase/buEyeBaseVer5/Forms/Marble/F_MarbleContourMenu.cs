// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleContourMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.buEntities;
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

public class F_MarbleContourMenu : Form
{
  internal buButton \u0001;
  internal ImageList \u0002;
  internal buLabel \u0001;
  public buButton btn_importimage;
  internal PictureBox \u0001;
  public static byte f00290D;
  public FormProperties Properties;
  public static List<string> Captions;
  public marbleSweepPars varSweep;
  public List<buEntity> SweepZFormEntities;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buSpin spn_followoffset;
  public buSpin spn_targetz;
  public buCheckBox chk_circular;
  public buSpin spn_rampheight;
  public buCheckBox chk_linear;
  public buCheckBox chk_none;
  public buSpin spn_rampwidth;
  public buButton btn_ok;
  public buButton btn_cancel;
  internal buButton \u0001;
  internal ImageList \u0002;
  public buSpin spn_safedistance;
  public buButton btn_selectfile;
  public buCheckBox chk_fromfile;
  public buSpin spn_width;
  public buSpin spn_widthstep;
  public static byte f002925;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public MarbleSweepMenuType SweepType;
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
  public buButton btn_contourmenueditor;

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_MarbleHorizontalCutV2) this).chk_rotate180minus.Name)
    {
      ((F_MarbleHorizontalCutV2) this).chk_rotate180plus.Check = false;
      ((F_MarbleHorizontalCutV2) this).chk_rotate90minus.Check = false;
      ((F_MarbleHorizontalCutV2) this).chk_rotate90plus.Check = false;
    }
    if (control.Name == ((F_MarbleHorizontalCutV2) this).chk_rotate180plus.Name)
    {
      ((F_MarbleHorizontalCutV2) this).chk_rotate180minus.Check = false;
      ((F_MarbleHorizontalCutV2) this).chk_rotate90minus.Check = false;
      ((F_MarbleHorizontalCutV2) this).chk_rotate90plus.Check = false;
    }
    if (control.Name == ((F_MarbleHorizontalCutV2) this).chk_rotate90minus.Name)
    {
      ((F_MarbleHorizontalCutV2) this).chk_rotate180minus.Check = false;
      ((F_MarbleHorizontalCutV2) this).chk_rotate180plus.Check = false;
      ((F_MarbleHorizontalCutV2) this).chk_rotate90plus.Check = false;
    }
    if (!(control.Name == ((F_MarbleHorizontalCutV2) this).chk_rotate90plus.Name))
      return;
    ((F_MarbleHorizontalCutV2) this).chk_rotate180minus.Check = false;
    ((F_MarbleHorizontalCutV2) this).chk_rotate180plus.Check = false;
    ((F_MarbleHorizontalCutV2) this).chk_rotate90minus.Check = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleHorizontalCutV2) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleHorizontalCutV2) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleContourMenu() => F_MarbleCutting.Captions = new List<string>();

  public F_MarbleContourMenu()
  {
    // ISSUE: unable to decompile the method.
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleHorizontalCutV2) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleHorizontalCutV2) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleHorizontalCutV2) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleHorizontalCutV2) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init()
  {
    ((F_MarbleHorizontalCutV2) this).PropertiesForm.Inited = false;
    if (((F_MarbleHorizontalCutV2) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleHorizontalCutV2) this).PropertiesForm.Height;
    if (((F_MarbleHorizontalCutV2) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleHorizontalCutV2) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleHorizontalCutV2) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleHorizontalCutV2) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    this.ToolToImageIndex();
    this.StrategyFromToolType(0);
    this.StrategyFromToolType(1);
    ((F_MarbleHorizontalCutV2) this).buGround1.DisplayTop.BackColor = ((F_MarbleHorizontalCutV2) this).clrFormCaption;
    ((F_MarbleHorizontalCutV2) this).buGround1.Display.GradientType = GradientMode.Lineer;
    ((F_MarbleHorizontalCutV2) this).buGround1.Display.LineerGradient.FirstColor = ((F_MarbleHorizontalCutV2) this).clrFormBackUpper;
    ((F_MarbleHorizontalCutV2) this).buGround1.Display.LineerGradient.SecondColor = ((F_MarbleHorizontalCutV2) this).clrFormBackDown;
    ((F_MarbleHorizontalCutV2) this).btn_close.Display.BackColor = ((F_MarbleHorizontalCutV2) this).clrFormCaption;
    ((F_MarbleHorizontalCutV2) this).btn_close.ButtonDownDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleHorizontalCutV2) this).clrFormCaption, 0.9);
    ((F_MarbleHorizontalCutV2) this).btn_close.ButtonOverDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleHorizontalCutV2) this).clrFormCaption, 0.95);
    ((F_MarbleLathe) this).lbl_contourtype.Display.BackColor = ((F_MarbleHorizontalCutV2) this).clrLabel;
    ((F_MarbleHorizontalCutV2) this).lbl_strategytype.Display.BackColor = ((F_MarbleHorizontalCutV2) this).clrLabel;
    ((F_MarbleLathe) this).lbl_tooltype.Display.BackColor = ((F_MarbleHorizontalCutV2) this).clrLabel;
    ((F_MarbleHorizontalCutV2) this).btn_textfont.Display.BackColor = ((F_MarbleHorizontalCutV2) this).clrButtonDisplay;
    ((F_MarbleHorizontalCutV2) this).btn_textfont.ButtonDownDisplay.BackColor = ((F_MarbleHorizontalCutV2) this).clrButtonDown;
    ((F_MarbleHorizontalCutV2) this).btn_textfont.ButtonOverDisplay.BackColor = ((F_MarbleHorizontalCutV2) this).clrButtonOver;
    ((F_MarbleHorizontalCutV2) this).btn_textfromfile.Display.BackColor = ((F_MarbleHorizontalCutV2) this).clrButtonDisplay;
    ((F_MarbleHorizontalCutV2) this).btn_textfromfile.ButtonDownDisplay.BackColor = ((F_MarbleHorizontalCutV2) this).clrButtonDown;
    ((F_MarbleHorizontalCutV2) this).btn_textfromfile.ButtonOverDisplay.BackColor = ((F_MarbleHorizontalCutV2) this).clrButtonOver;
    ((F_MarbleHorizontalCutV2) this).btn_textwireframe.Display.BackColor = ((F_MarbleHorizontalCutV2) this).clrButtonDisplay;
    ((F_MarbleHorizontalCutV2) this).btn_textwireframe.ButtonDownDisplay.BackColor = ((F_MarbleHorizontalCutV2) this).clrButtonDown;
    ((F_MarbleHorizontalCutV2) this).btn_textwireframe.ButtonOverDisplay.BackColor = ((F_MarbleHorizontalCutV2) this).clrButtonOver;
    ((F_MarbleHorizontalCutV2) this).chk_3D.Display.BackColor = ((F_MarbleHorizontalCutV2) this).clrButtonDisplay;
    ((F_MarbleHorizontalCutV2) this).btn_strategy.Display.BackColor = ((F_MarbleHorizontalCutV2) this).clrButtonDisplay;
    ((F_MarbleHorizontalCutV2) this).btn_strategy.ButtonDownDisplay.BackColor = ((F_MarbleHorizontalCutV2) this).clrButtonDown;
    ((F_MarbleHorizontalCutV2) this).btn_strategy.ButtonOverDisplay.BackColor = ((F_MarbleHorizontalCutV2) this).clrButtonOver;
    ((F_MarbleHorizontalCutV2) this).btn_tool.Display.BackColor = ((F_MarbleHorizontalCutV2) this).clrButtonDisplay;
    ((F_MarbleHorizontalCutV2) this).btn_tool.ButtonDownDisplay.BackColor = ((F_MarbleHorizontalCutV2) this).clrButtonDown;
    ((F_MarbleHorizontalCutV2) this).btn_tool.ButtonOverDisplay.BackColor = ((F_MarbleHorizontalCutV2) this).clrButtonOver;
    ((F_MarbleHorizontalCutV2) this).btn_toolsettings.Display.BackColor = ((F_MarbleHorizontalCutV2) this).clrButtonDisplay;
    ((F_MarbleHorizontalCutV2) this).btn_toolsettings.ButtonDownDisplay.BackColor = ((F_MarbleHorizontalCutV2) this).clrButtonDown;
    ((F_MarbleHorizontalCutV2) this).btn_toolsettings.ButtonOverDisplay.BackColor = ((F_MarbleHorizontalCutV2) this).clrButtonOver;
    ((F_MarbleHorizontalCutV2) this).btn_camsettings.Display.BackColor = ((F_MarbleHorizontalCutV2) this).clrButtonDisplay;
    ((F_MarbleHorizontalCutV2) this).btn_camsettings.ButtonDownDisplay.BackColor = ((F_MarbleHorizontalCutV2) this).clrButtonDown;
    ((F_MarbleHorizontalCutV2) this).btn_camsettings.ButtonOverDisplay.BackColor = ((F_MarbleHorizontalCutV2) this).clrButtonOver;
    ((F_MarbleHorizontalCutV2) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleHorizontalCutV2) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleLathe) this).lbl_contourtype.Text = $"{buLangTranslate.preDef.Text} {buLangTranslate.preDef.Type}";
      ((F_MarbleHorizontalCutV2) this).lbl_strategytype.Text = $"{buLangTranslate.preDef.Strategy} {buLangTranslate.preDef.Type}";
      ((F_MarbleLathe) this).lbl_tooltype.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Type}";
      ((F_MarbleHorizontalCutV2) this).btn_textfont.Text = buLangTranslate.preDef.Font;
      ((F_MarbleHorizontalCutV2) this).btn_textfromfile.Text = buLangTranslate.preDef.FromFile;
      ((F_MarbleHorizontalCutV2) this).btn_textwireframe.Text = buLangTranslate.preDef.Wireframe;
      ((F_MarbleHorizontalCutV2) this).btn_strategy.Text = buLangTranslate.preDef.Strategy;
      ((F_MarbleLathe) this).btn_strategy2.Text = buLangTranslate.preDef.Strategy;
      ((F_MarbleHorizontalCutV2) this).btn_tool.Text = buLangTranslate.preDef.Tool;
      ((F_MarbleHorizontalCutV2) this).buGround1.Text = $"{buLangTranslate.preDef.Text} {buLangTranslate.preDef.Menu}";
      ((F_MarbleLathe) this).chk_addtonesting.Text = $"{buLangTranslate.preDef.Nesting} {buLangTranslate.preDef.Add}";
    }
    catch (Exception ex)
    {
    }
  }

  public void StrategyMillingToImageIndex(int Index)
  {
    if (!((F_MarbleHorizontalCutV2) this).chk_3D.Check)
    {
      if (Index == 0)
      {
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedWireframeType == CamWireFrameType.CenterPath)
          ((F_MarbleHorizontalCutV2) this).btn_strategy.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[0];
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedWireframeType == CamWireFrameType.Chamfer2D)
          ((F_MarbleHorizontalCutV2) this).btn_strategy.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[1];
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedWireframeType == CamWireFrameType.Contour)
          ((F_MarbleHorizontalCutV2) this).btn_strategy.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[6];
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedWireframeType == CamWireFrameType.Engrave)
          ((F_MarbleHorizontalCutV2) this).btn_strategy.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[3];
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedWireframeType == CamWireFrameType.Face)
          ((F_MarbleHorizontalCutV2) this).btn_strategy.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[4];
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedWireframeType == CamWireFrameType.FloorFinish)
          ((F_MarbleHorizontalCutV2) this).btn_strategy.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[5];
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedWireframeType == CamWireFrameType.Pocket)
          ((F_MarbleHorizontalCutV2) this).btn_strategy.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[7];
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedWireframeType == CamWireFrameType.TextEngrave)
          ((F_MarbleHorizontalCutV2) this).btn_strategy.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[8];
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedWireframeType == CamWireFrameType.Trochoidal)
          ((F_MarbleHorizontalCutV2) this).btn_strategy.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[9];
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedWireframeType == CamWireFrameType.None)
          ((F_MarbleHorizontalCutV2) this).btn_strategy.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[12];
      }
      if (Index == 1)
      {
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedWireframeType2 == CamWireFrameType.CenterPath)
          ((F_MarbleLathe) this).btn_strategy2.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[0];
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedWireframeType2 == CamWireFrameType.Chamfer2D)
          ((F_MarbleLathe) this).btn_strategy2.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[1];
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedWireframeType2 == CamWireFrameType.Contour)
          ((F_MarbleLathe) this).btn_strategy2.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[6];
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedWireframeType2 == CamWireFrameType.Engrave)
          ((F_MarbleLathe) this).btn_strategy2.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[3];
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedWireframeType2 == CamWireFrameType.Face)
          ((F_MarbleLathe) this).btn_strategy2.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[4];
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedWireframeType2 == CamWireFrameType.FloorFinish)
          ((F_MarbleLathe) this).btn_strategy2.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[5];
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedWireframeType2 == CamWireFrameType.Pocket)
          ((F_MarbleLathe) this).btn_strategy2.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[7];
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedWireframeType2 == CamWireFrameType.TextEngrave)
          ((F_MarbleLathe) this).btn_strategy2.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[8];
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedWireframeType2 == CamWireFrameType.Trochoidal)
          ((F_MarbleLathe) this).btn_strategy2.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[9];
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedWireframeType2 == CamWireFrameType.None)
          ((F_MarbleLathe) this).btn_strategy2.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[12];
      }
      ((F_MarbleHorizontalCutV2) this).btn_strategy.Text = $"{buLangTranslate.preDef.Cam} : {((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedWireframeType.ToString()}";
      ((F_MarbleLathe) this).btn_strategy2.Text = $"{buLangTranslate.preDef.Cam} : {((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedWireframeType2.ToString()}";
    }
    else
    {
      if (Index == 0)
      {
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedMeshType == CamTriangularMeshType.Rough)
          ((F_MarbleHorizontalCutV2) this).btn_strategy.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[19];
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedMeshType == CamTriangularMeshType.ParallelCuts)
          ((F_MarbleHorizontalCutV2) this).btn_strategy.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[17];
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedMeshType == CamTriangularMeshType.ConstantZ)
          ((F_MarbleHorizontalCutV2) this).btn_strategy.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[15];
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedMeshType == CamTriangularMeshType.Flatlands)
          ((F_MarbleHorizontalCutV2) this).btn_strategy.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[16 /*0x10*/];
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedMeshType == CamTriangularMeshType.Pencil)
          ((F_MarbleHorizontalCutV2) this).btn_strategy.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[18];
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedMeshType == CamTriangularMeshType.None)
          ((F_MarbleHorizontalCutV2) this).btn_strategy.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[14];
      }
      if (Index == 1)
      {
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedMeshType2 == CamTriangularMeshType.Rough)
          ((F_MarbleLathe) this).btn_strategy2.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[19];
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedMeshType2 == CamTriangularMeshType.ParallelCuts)
          ((F_MarbleLathe) this).btn_strategy2.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[17];
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedMeshType2 == CamTriangularMeshType.ConstantZ)
          ((F_MarbleLathe) this).btn_strategy2.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[15];
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedMeshType2 == CamTriangularMeshType.Flatlands)
          ((F_MarbleLathe) this).btn_strategy2.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[16 /*0x10*/];
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedMeshType2 == CamTriangularMeshType.Pencil)
          ((F_MarbleLathe) this).btn_strategy2.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[18];
        if (((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedMeshType2 == CamTriangularMeshType.None)
          ((F_MarbleLathe) this).btn_strategy2.Image = ((F_MarbleHorizontalCutV2) this).\u0001.Images[14];
      }
      ((F_MarbleHorizontalCutV2) this).btn_strategy.Text = $"{buLangTranslate.preDef.Cam} : {((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedMeshType.ToString()}";
      ((F_MarbleLathe) this).btn_strategy2.Text = $"{buLangTranslate.preDef.Cam} : {((MarbleMotionCommands) ((F_MarbleHorizontalCutV2) this).MenuType).selectedMeshType2.ToString()}";
    }
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

  public void StrategyFromToolType(int Index)
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleHorizontalCutV2) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleHorizontalCutV2) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleHorizontalCutV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleHorizontalCutV2) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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
    ((F_MarbleHorizontalCutV2) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleHorizontalCutV2) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleHorizontalCutV2) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleHorizontalCutV2) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleHorizontalCutV2) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public event OkCommandWithFiveDataEventHandler CommandExecute;
}
