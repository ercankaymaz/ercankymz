// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleSawMillingContourSetting
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleSawMillingContourSetting : Form
{
  public double AngleValue;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  private IContainer \u0001;
  internal buGround \u0001;
  internal buButton \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  public buButton btn_0;
  public buSpin spn_cutangle;
  public buButton btn_47;
  public buButton btn_46;
  public buButton btn_45;
  public buButton btn_40;
  public buButton btn_30;
  public buButton btn_15;
  public buButton btn_5;
  public buButton btn_3;
  public buButton btn_minus;
  public static byte f002AA6;
  public static List<string> Captions;
  public FormProperties Properties;
  public bool isHorizontal;
  private IContainer \u0001;
  public buSpin spn_itemEA5;
  public buSpin spn_itemSA5;
  public buSpin spn_itemcount5;
  public buSpin spn_itemlen5;
  public buSpin spn_itemEA4;
  public buSpin spn_itemSA4;
  public buSpin spn_itemcount4;
  public buSpin spn_itemlen4;
  public buSpin spn_itemEA3;
  public buSpin spn_itemSA3;
  public buSpin spn_itemcount3;
  public buSpin spn_itemlen3;

  public void Init()
  {
    ((F_MarbleSetAngle) this).PropertiesForm.Inited = false;
    if (((F_MarbleSetAngle) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleSetAngle) this).PropertiesForm.Height;
    if (((F_MarbleSetAngle) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleSetAngle) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleSetAngle) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleSetAngle) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    this.ToolToImageIndex();
    this.StrategyFromToolType();
    ((F_MarbleHorVerCut) this).buGround1.DisplayTop.BackColor = ((F_MarbleHorVerCut) this).clrFormCaption;
    ((F_MarbleHorVerCut) this).buGround1.Display.GradientType = GradientMode.Lineer;
    ((F_MarbleHorVerCut) this).buGround1.Display.LineerGradient.FirstColor = ((F_MarbleHorVerCut) this).clrFormBackUpper;
    ((F_MarbleHorVerCut) this).buGround1.Display.LineerGradient.SecondColor = ((F_MarbleHorVerCut) this).clrFormBackDown;
    ((F_MarbleHorVerCut) this).btn_close.Display.BackColor = ((F_MarbleHorVerCut) this).clrFormCaption;
    ((F_MarbleHorVerCut) this).btn_close.ButtonDownDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleHorVerCut) this).clrFormCaption, 0.9);
    ((F_MarbleHorVerCut) this).btn_close.ButtonOverDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleHorVerCut) this).clrFormCaption, 0.95);
    ((F_MarbleHorVerCut) this).lbl_contourtype.Display.BackColor = ((F_MarbleHorVerCut) this).clrLabel;
    ((F_MarbleHorVerCut) this).lbl_strategytype.Display.BackColor = ((F_MarbleHorVerCut) this).clrLabel;
    ((F_MarbleHorVerCut) this).lbl_tooltype.Display.BackColor = ((F_MarbleHorVerCut) this).clrLabel;
    ((F_MarbleHorVerCut) this).btn_contourmenueditor.Display.BackColor = ((F_MarbleHorVerCut) this).clrButtonDisplay;
    ((F_MarbleHorVerCut) this).btn_contourmenueditor.ButtonDownDisplay.BackColor = ((F_MarbleHorVerCut) this).clrButtonDown;
    ((F_MarbleHorVerCut) this).btn_contourmenueditor.ButtonOverDisplay.BackColor = ((F_MarbleHorVerCut) this).clrButtonOver;
    ((F_MarbleHorVerCut) this).btn_contourmenufilelist.Display.BackColor = ((F_MarbleHorVerCut) this).clrButtonDisplay;
    ((F_MarbleHorVerCut) this).btn_contourmenufilelist.ButtonDownDisplay.BackColor = ((F_MarbleHorVerCut) this).clrButtonDown;
    ((F_MarbleHorVerCut) this).btn_contourmenufilelist.ButtonOverDisplay.BackColor = ((F_MarbleHorVerCut) this).clrButtonOver;
    ((F_MarbleHorVerCut) this).btn_contourmenufromfile.Display.BackColor = ((F_MarbleHorVerCut) this).clrButtonDisplay;
    ((F_MarbleHorVerCut) this).btn_contourmenufromfile.ButtonDownDisplay.BackColor = ((F_MarbleHorVerCut) this).clrButtonDown;
    ((F_MarbleHorVerCut) this).btn_contourmenufromfile.ButtonOverDisplay.BackColor = ((F_MarbleHorVerCut) this).clrButtonOver;
    ((F_MarbleHorVerCut) this).btn_strategy.Display.BackColor = ((F_MarbleHorVerCut) this).clrButtonDisplay;
    ((F_MarbleHorVerCut) this).btn_strategy.ButtonDownDisplay.BackColor = ((F_MarbleHorVerCut) this).clrButtonDown;
    ((F_MarbleHorVerCut) this).btn_strategy.ButtonOverDisplay.BackColor = ((F_MarbleHorVerCut) this).clrButtonOver;
    ((F_MarbleHorVerCut) this).btn_tool.Display.BackColor = ((F_MarbleHorVerCut) this).clrButtonDisplay;
    ((F_MarbleHorVerCut) this).btn_tool.ButtonDownDisplay.BackColor = ((F_MarbleHorVerCut) this).clrButtonDown;
    ((F_MarbleHorVerCut) this).btn_tool.ButtonOverDisplay.BackColor = ((F_MarbleHorVerCut) this).clrButtonOver;
    ((F_MarbleHorVerCut) this).btn_toolsettings.Display.BackColor = ((F_MarbleHorVerCut) this).clrButtonDisplay;
    ((F_MarbleHorVerCut) this).btn_toolsettings.ButtonDownDisplay.BackColor = ((F_MarbleHorVerCut) this).clrButtonDown;
    ((F_MarbleHorVerCut) this).btn_toolsettings.ButtonOverDisplay.BackColor = ((F_MarbleHorVerCut) this).clrButtonOver;
    ((F_MarbleHorVerCut) this).btn_camsettings.Display.BackColor = ((F_MarbleHorVerCut) this).clrButtonDisplay;
    ((F_MarbleHorVerCut) this).btn_camsettings.ButtonDownDisplay.BackColor = ((F_MarbleHorVerCut) this).clrButtonDown;
    ((F_MarbleHorVerCut) this).btn_camsettings.ButtonOverDisplay.BackColor = ((F_MarbleHorVerCut) this).clrButtonOver;
    ((F_MarbleSetAngle) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleSetAngle) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleHorVerCut) this).lbl_contourtype.Text = $"{buLangTranslate.preDef.Profile} {buLangTranslate.preDef.Type}";
      ((F_MarbleHorVerCut) this).lbl_strategytype.Text = $"{buLangTranslate.preDef.Strategy} {buLangTranslate.preDef.Type}";
      ((F_MarbleHorVerCut) this).lbl_tooltype.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Type}";
      ((F_MarbleHorVerCut) this).btn_contourmenueditor.Text = buLangTranslate.preDef.Editor;
      ((F_MarbleHorVerCut) this).btn_contourmenufilelist.Text = buLangTranslate.preDef.FromList;
      ((F_MarbleHorVerCut) this).btn_contourmenufromfile.Text = buLangTranslate.preDef.FromFile;
      ((F_MarbleHorVerCut) this).btn_strategy.Text = buLangTranslate.preDef.Strategy;
      ((F_MarbleHorVerCut) this).btn_tool.Text = buLangTranslate.preDef.Tool;
      ((F_MarbleHorVerCut) this).chk_addtonesting.Text = $"{buLangTranslate.preDef.Nesting} {buLangTranslate.preDef.Add}";
      ((F_MarbleHorVerCut) this).buGround1.Text = $"{buLangTranslate.preDef.Profile} {buLangTranslate.preDef.Menu}";
    }
    catch (Exception ex)
    {
    }
  }

  public void StrategyMillingToImageIndex()
  {
    if (((MarbleMotionCommands) ((F_MarbleHorVerCut) this).MenuType).selectedMeshType == CamTriangularMeshType.Rough)
      ((F_MarbleHorVerCut) this).btn_strategy.Image = ((F_MarbleHorVerCut) this).\u0001.Images[12];
    if (((MarbleMotionCommands) ((F_MarbleHorVerCut) this).MenuType).selectedMeshType == CamTriangularMeshType.ParallelCuts)
      ((F_MarbleHorVerCut) this).btn_strategy.Image = ((F_MarbleHorVerCut) this).\u0001.Images[13];
    if (((MarbleMotionCommands) ((F_MarbleHorVerCut) this).MenuType).selectedMeshType == CamTriangularMeshType.ConstantZ)
      ((F_MarbleHorVerCut) this).btn_strategy.Image = ((F_MarbleHorVerCut) this).\u0001.Images[14];
    if (((MarbleMotionCommands) ((F_MarbleHorVerCut) this).MenuType).selectedMeshType == CamTriangularMeshType.Flatlands)
      ((F_MarbleHorVerCut) this).btn_strategy.Image = ((F_MarbleHorVerCut) this).\u0001.Images[15];
    if (((MarbleMotionCommands) ((F_MarbleHorVerCut) this).MenuType).selectedMeshType == CamTriangularMeshType.Pencil)
      ((F_MarbleHorVerCut) this).btn_strategy.Image = ((F_MarbleHorVerCut) this).\u0001.Images[16 /*0x10*/];
    ((F_MarbleHorVerCut) this).btn_strategy.Text = $"{buLangTranslate.preDef.Cam} : {((MarbleMotionCommands) ((F_MarbleHorVerCut) this).MenuType).selectedMeshType.ToString()}";
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
    if (((F_MarbleSetAngle) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleSetAngle) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleSetAngle) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleSetAngle) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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
}
