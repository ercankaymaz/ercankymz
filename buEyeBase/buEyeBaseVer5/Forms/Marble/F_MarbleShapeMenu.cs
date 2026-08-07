// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleShapeMenu
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

public class F_MarbleShapeMenu : Form
{
  public buCheckBox chk_center;
  public buCheckBox chk_Contour;
  public buCheckBox chk_engrave;
  public buCheckBox chk_chamfer;
  public buCheckBox chk_floorfinish;
  public buCheckBox chk_face;
  public buCheckBox chk_trochoidal;
  public buCheckBox chk_textengrave;
  public buCheckBox chk_rough;
  public buCheckBox chk_none;
  public static byte f00281D;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public MarbleToolType ToolType;
  private IContainer \u0001;
  public buButton btn_close;
  public buCheckBox chk_toolsaw;
  public buCheckBox chk_toolwaterjet;
  public buCheckBox chk_toolmilling;
  public buGround buGround1;
  public buCheckBox chk_toolmillinghead;
  public static byte f00282A;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions = new List<string>();
  public FormProperties PropertiesForm;
  public MarbleLatheMenuType LatheType;
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

  public void StrategyMillingToImageIndex()
  {
    if (((MarbleMotionCommands) this.MenuType).selectedWireframeType == CamWireFrameType.CenterPath)
      this.btn_strategy.Image = this.\u0001.Images[0];
    if (((MarbleMotionCommands) this.MenuType).selectedWireframeType == CamWireFrameType.Chamfer2D)
      this.btn_strategy.Image = this.\u0001.Images[1];
    if (((MarbleMotionCommands) this.MenuType).selectedWireframeType == CamWireFrameType.Contour)
      this.btn_strategy.Image = this.\u0001.Images[6];
    if (((MarbleMotionCommands) this.MenuType).selectedWireframeType == CamWireFrameType.Engrave)
      this.btn_strategy.Image = this.\u0001.Images[3];
    if (((MarbleMotionCommands) this.MenuType).selectedWireframeType == CamWireFrameType.Face)
      this.btn_strategy.Image = this.\u0001.Images[4];
    if (((MarbleMotionCommands) this.MenuType).selectedWireframeType == CamWireFrameType.FloorFinish)
      this.btn_strategy.Image = this.\u0001.Images[5];
    if (((MarbleMotionCommands) this.MenuType).selectedWireframeType == CamWireFrameType.Pocket)
      this.btn_strategy.Image = this.\u0001.Images[7];
    if (((MarbleMotionCommands) this.MenuType).selectedWireframeType == CamWireFrameType.TextEngrave)
      this.btn_strategy.Image = this.\u0001.Images[8];
    if (((MarbleMotionCommands) this.MenuType).selectedWireframeType == CamWireFrameType.Trochoidal)
      this.btn_strategy.Image = this.\u0001.Images[9];
    this.btn_strategy.Text = $"{buLangTranslate.preDef.Cam} : {((MarbleMotionCommands) this.MenuType).selectedWireframeType.ToString()}";
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
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.\u0001 != null ? 1 : 0)) != 0)
      this.\u0001.Dispose();
    base.Dispose(disposing);
  }

  public F_MarbleShapeMenu()
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
    ((F_MarbleCutting) this).ToolToImageIndex();
    ((F_MarbleCutting) this).StrategyFromToolType();
    ((F_MarbleCutting) this).buGround1.DisplayTop.BackColor = ((F_MarbleCutting) this).clrFormCaption;
    ((F_MarbleCutting) this).buGround1.Display.GradientType = GradientMode.Lineer;
    ((F_MarbleCutting) this).buGround1.Display.LineerGradient.FirstColor = ((F_MarbleCutting) this).clrFormBackUpper;
    ((F_MarbleCutting) this).buGround1.Display.LineerGradient.SecondColor = ((F_MarbleCutting) this).clrFormBackDown;
    ((F_MarbleCutting) this).btn_close.Display.BackColor = ((F_MarbleCutting) this).clrFormCaption;
    ((F_MarbleCutting) this).btn_close.ButtonDownDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleCutting) this).clrFormCaption, 0.9);
    ((F_MarbleCutting) this).btn_close.ButtonOverDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleCutting) this).clrFormCaption, 0.95);
    ((F_MarbleCutting) this).lbl_contourtype.Display.BackColor = ((F_MarbleCutting) this).clrLabel;
    ((F_MarbleCutting) this).lbl_strategytype.Display.BackColor = ((F_MarbleCutting) this).clrLabel;
    ((F_MarbleCutting) this).lbl_tooltype.Display.BackColor = ((F_MarbleCutting) this).clrLabel;
    ((F_MarbleCutting) this).btn_contourmenueditor.Display.BackColor = ((F_MarbleCutting) this).clrButtonDisplay;
    ((F_MarbleCutting) this).btn_contourmenueditor.ButtonDownDisplay.BackColor = ((F_MarbleCutting) this).clrButtonDown;
    ((F_MarbleCutting) this).btn_contourmenueditor.ButtonOverDisplay.BackColor = ((F_MarbleCutting) this).clrButtonOver;
    ((F_MarbleCutting) this).btn_contourmenufilelist.Display.BackColor = ((F_MarbleCutting) this).clrButtonDisplay;
    ((F_MarbleCutting) this).btn_contourmenufilelist.ButtonDownDisplay.BackColor = ((F_MarbleCutting) this).clrButtonDown;
    ((F_MarbleCutting) this).btn_contourmenufilelist.ButtonOverDisplay.BackColor = ((F_MarbleCutting) this).clrButtonOver;
    ((F_MarbleCutting) this).btn_contourmenufromfile.Display.BackColor = ((F_MarbleCutting) this).clrButtonDisplay;
    ((F_MarbleCutting) this).btn_contourmenufromfile.ButtonDownDisplay.BackColor = ((F_MarbleCutting) this).clrButtonDown;
    ((F_MarbleCutting) this).btn_contourmenufromfile.ButtonOverDisplay.BackColor = ((F_MarbleCutting) this).clrButtonOver;
    ((F_MarbleCutting) this).btn_strategy.Display.BackColor = ((F_MarbleCutting) this).clrButtonDisplay;
    ((F_MarbleCutting) this).btn_strategy.ButtonDownDisplay.BackColor = ((F_MarbleCutting) this).clrButtonDown;
    ((F_MarbleCutting) this).btn_strategy.ButtonOverDisplay.BackColor = ((F_MarbleCutting) this).clrButtonOver;
    ((F_MarbleCutting) this).btn_tool.Display.BackColor = ((F_MarbleCutting) this).clrButtonDisplay;
    ((F_MarbleCutting) this).btn_tool.ButtonDownDisplay.BackColor = ((F_MarbleCutting) this).clrButtonDown;
    ((F_MarbleCutting) this).btn_tool.ButtonOverDisplay.BackColor = ((F_MarbleCutting) this).clrButtonOver;
    ((F_MarbleCutting) this).btn_toolsettings.Display.BackColor = ((F_MarbleCutting) this).clrButtonDisplay;
    ((F_MarbleCutting) this).btn_toolsettings.ButtonDownDisplay.BackColor = ((F_MarbleCutting) this).clrButtonDown;
    ((F_MarbleCutting) this).btn_toolsettings.ButtonOverDisplay.BackColor = ((F_MarbleCutting) this).clrButtonOver;
    ((F_MarbleCutting) this).btn_camsettings.Display.BackColor = ((F_MarbleCutting) this).clrButtonDisplay;
    ((F_MarbleCutting) this).btn_camsettings.ButtonDownDisplay.BackColor = ((F_MarbleCutting) this).clrButtonDown;
    ((F_MarbleCutting) this).btn_camsettings.ButtonOverDisplay.BackColor = ((F_MarbleCutting) this).clrButtonOver;
    ((F_MarbleCutting) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleCutting) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleCutting) this).lbl_contourtype.Text = $"{buLangTranslate.preDef.Columns} {buLangTranslate.preDef.Type}";
      ((F_MarbleCutting) this).lbl_strategytype.Text = $"{buLangTranslate.preDef.Strategy} {buLangTranslate.preDef.Type}";
      ((F_MarbleCutting) this).lbl_tooltype.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Type}";
      ((F_MarbleCutting) this).btn_contourmenueditor.Text = buLangTranslate.preDef.Editor;
      ((F_MarbleCutting) this).btn_contourmenufilelist.Text = buLangTranslate.preDef.FromList;
      ((F_MarbleCutting) this).btn_contourmenufromfile.Text = buLangTranslate.preDef.FromFile;
      ((F_MarbleCutting) this).btn_strategy.Text = buLangTranslate.preDef.Strategy;
      ((F_MarbleCutting) this).btn_tool.Text = buLangTranslate.preDef.Tool;
      ((F_MarbleCutting) this).chk_5Axismilling.Text = $"5 {buLangTranslate.preDef.Axes} {buLangTranslate.preDef.Milling}";
      ((F_MarbleCutting) this).buGround1.Text = $"{buLangTranslate.preDef.Columns} {buLangTranslate.preDef.Menu}";
    }
    catch (Exception ex)
    {
    }
  }

  public void StrategyMillingToImageIndex()
  {
    if (((MarbleMotionCommands) ((F_MarbleCutting) this).MenuType).selectedWireframeType == CamWireFrameType.CenterPath)
      ((F_MarbleCutting) this).btn_strategy.Image = ((F_MarbleCutting) this).\u0001.Images[0];
    if (((MarbleMotionCommands) ((F_MarbleCutting) this).MenuType).selectedWireframeType == CamWireFrameType.Chamfer2D)
      ((F_MarbleCutting) this).btn_strategy.Image = ((F_MarbleCutting) this).\u0001.Images[1];
    if (((MarbleMotionCommands) ((F_MarbleCutting) this).MenuType).selectedWireframeType == CamWireFrameType.Contour)
      ((F_MarbleCutting) this).btn_strategy.Image = ((F_MarbleCutting) this).\u0001.Images[6];
    if (((MarbleMotionCommands) ((F_MarbleCutting) this).MenuType).selectedWireframeType == CamWireFrameType.Engrave)
      ((F_MarbleCutting) this).btn_strategy.Image = ((F_MarbleCutting) this).\u0001.Images[3];
    if (((MarbleMotionCommands) ((F_MarbleCutting) this).MenuType).selectedWireframeType == CamWireFrameType.Face)
      ((F_MarbleCutting) this).btn_strategy.Image = ((F_MarbleCutting) this).\u0001.Images[4];
    if (((MarbleMotionCommands) ((F_MarbleCutting) this).MenuType).selectedWireframeType == CamWireFrameType.FloorFinish)
      ((F_MarbleCutting) this).btn_strategy.Image = ((F_MarbleCutting) this).\u0001.Images[5];
    if (((MarbleMotionCommands) ((F_MarbleCutting) this).MenuType).selectedWireframeType == CamWireFrameType.Pocket)
      ((F_MarbleCutting) this).btn_strategy.Image = ((F_MarbleCutting) this).\u0001.Images[7];
    if (((MarbleMotionCommands) ((F_MarbleCutting) this).MenuType).selectedWireframeType == CamWireFrameType.TextEngrave)
      ((F_MarbleCutting) this).btn_strategy.Image = ((F_MarbleCutting) this).\u0001.Images[8];
    if (((MarbleMotionCommands) ((F_MarbleCutting) this).MenuType).selectedWireframeType == CamWireFrameType.Trochoidal)
      ((F_MarbleCutting) this).btn_strategy.Image = ((F_MarbleCutting) this).\u0001.Images[9];
    ((F_MarbleCutting) this).btn_strategy.Text = $"{buLangTranslate.preDef.Cam} : {((MarbleMotionCommands) ((F_MarbleCutting) this).MenuType).selectedWireframeType.ToString()}";
  }

  public void StrategySawToImageIndex()
  {
    // ISSUE: unable to decompile the method.
  }

  public void StrategyWaterToImageIndex()
  {
    // ISSUE: unable to decompile the method.
  }

  public event OkCommandWithFiveDataEventHandler CommandExecute;
}
