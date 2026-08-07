// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleEngraveCamSetting
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
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleEngraveCamSetting : Form
{
  public buLabel lbl_4;
  public buLabel lbl_3;
  public buLabel lbl_2;
  public buLabel lbl_1;
  public buLabel lbl_ea;
  public buLabel lbl_sa;
  public buLabel lbl_count;
  public Panel pnl_ver_viewport;
  public buLabel lbl_7;
  public buSpin spn_itemEA7;
  public buSpin spn_itemSA7;
  public buSpin spn_itemcount7;
  public buSpin spn_itemlen7;
  public buLabel lbl_6;
  public buSpin spn_itemEA6;
  public buSpin spn_itemSA6;
  public buSpin spn_itemcount6;
  public buSpin spn_itemlen6;
  public buCheckBox chk_horizotalvertical;
  public buCheckBox chk_verticalhorizontal;
  public buCheckBox chk_onlyhorizontal;
  public buCheckBox chk_onlyvertical;
  public Panel pnl_base;
  public buSpin spn_cvalVer;
  public buCheckBox chk_FromvalueVer;
  public buButton btn_clearallVer;
  public buSpin spn_x;
  public buSpin spn_c;
  public buSpin spn_a;
  public buSpin spn_z;
  public buSpin spn_y;
  public buButton btn_showcoordsVer;
  internal PictureBox \u0001;
  public Panel pnl_coords;
  public Panel pnl_data;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public ToolBase5 ToolMilling;
  public ToolBase5 ToolSaw;
  public ToolBase5[] Tools;
  public FormProperties PropertiesForm;
  private IContainer \u0001;
  internal buGround \u0001;
  internal buButton \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  public buButton btn_opentools;
  public buButton btn_savetools;
  public buTab buTab_command_settings;
  public TabPage tabPage_saw;
  public TabPage tabPage_mlling;
  internal Panel \u0001;
  public buButton btn_saw_activate;
  public buButton btn_saw_zeroposition;
  public buButton btn_sawgonyele;
  public buButton btn_sawlimitdisable;
  public buButton btn_saw_measure;
  public buSpin spn_sawspeed;
  public buSpin spn_sawthickness;
  public buSpin spn_sawdia;
  public buButton btn_milling_activate;
  public buButton btn_milling_zeroposition;
  public buButton btn_milling_limitdisable;
  public buButton btn_milling_measure;
  public buSpin spn_milling_speed;
  public buSpin spn_milling_length;
  public buSpin spn_milling_diameter;
  internal Panel \u0002;
  internal PictureBox \u0001;
  internal PictureBox \u0002;
  public buButton btn_magazine_zero;
  public buButton btn_magazine_disablelimit;
  public buButton btn_magazine_measure;
  public buSpin spn_toolspeed6;
  public buSpin spn_tooldia6;
  public buSpin spn_toollen6;
  public buSpin spn_toolspeed5;
  public buSpin spn_tooldia5;
  public buSpin spn_toollen5;
  public buSpin spn_toolspeed4;
  public buSpin spn_tooldia4;
  public buSpin spn_toollen4;
  public buSpin spn_toolspeed3;
  public buSpin spn_tooldia3;

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleHorVerCut) this).lbl_contourtype.Text = $"{buLangTranslate.preDef.Shape} {buLangTranslate.preDef.Type}";
      ((F_MarbleHorVerCut) this).lbl_strategytype.Text = $"{buLangTranslate.preDef.Strategy} {buLangTranslate.preDef.Type}";
      ((F_MarbleHorVerCut) this).lbl_tooltype.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Type}";
      ((F_MarbleHorVerCut) this).btn_rectangle.Text = buLangTranslate.preDef.Rectangle;
      ((F_MarbleHorVerCut) this).btn_circle.Text = buLangTranslate.preDef.Cirlce;
      ((F_MarbleHorVerCut) this).btn_ellipse.Text = buLangTranslate.preDef.Ellipse;
      ((F_MarbleHorVerCut) this).btn_polygon.Text = buLangTranslate.preDef.Polygon;
      ((F_MarbleHorVerCut) this).btn_slot.Text = buLangTranslate.preDef.Slot;
      ((F_MarbleHorVerCut) this).btn_trapezoid.Text = buLangTranslate.preDef.Trapezoid;
      ((F_MarbleHorVerCut) this).btn_triangle.Text = buLangTranslate.preDef.Triangle;
      ((F_MarbleVerticalCut) this).btn_arc.Text = buLangTranslate.preDef.Arc;
      ((F_MarbleVerticalCut) this).btn_rectanglechamfer.Text = $"{buLangTranslate.preDef.Rectangle} {buLangTranslate.preDef.Chamfer}";
      ((F_MarbleVerticalCut) this).btn_rectanglecross.Text = $"{buLangTranslate.preDef.Rectangle} {buLangTranslate.preDef.Cross}";
      ((F_MarbleVerticalCut) this).btn_rectangleround.Text = $"{buLangTranslate.preDef.Rectangle} {buLangTranslate.preDef.Round}";
      ((F_MarbleVerticalCut) this).btn_ellipsepie.Text = $"{buLangTranslate.preDef.Ellipse} {buLangTranslate.preDef.Pie}";
      ((F_MarbleVerticalCut) this).btn_arcpie.Text = $"{buLangTranslate.preDef.Arc} {buLangTranslate.preDef.Pie}";
      ((F_MarbleVerticalCut) this).btn_shipnose.Text = buLangTranslate.preDef.ShipNose;
      ((F_MarbleHorVerCut) this).btn_strategy.Text = buLangTranslate.preDef.Strategy;
      ((F_MarbleHorVerCut) this).btn_tool.Text = buLangTranslate.preDef.Tool;
      ((F_MarbleHorVerCut) this).chk_addtonesting.Text = $"{buLangTranslate.preDef.Nesting} {buLangTranslate.preDef.Add}";
      ((F_MarbleHorVerCut) this).buGround1.Text = $"{buLangTranslate.preDef.Shape} {buLangTranslate.preDef.Menu}";
      ((F_MarbleVerticalCut) this).chk_mirrorX.Text = buLangTranslate.preDef.Mirror + " X";
      ((F_MarbleVerticalCut) this).chk_mirroY.Text = buLangTranslate.preDef.Mirror + " Y";
      ((F_MarbleVerticalCut) this).lbl_events.Text = buLangTranslate.preDef.Events;
    }
    catch (Exception ex)
    {
    }
  }

  public void StrategyMillingToImageIndex()
  {
    if (((MarbleMotionCommands) ((F_MarbleHorVerCut) this).MenuType).selectedWireframeType == CamWireFrameType.CenterPath)
      ((F_MarbleHorVerCut) this).btn_strategy.Image = ((F_MarbleHorVerCut) this).\u0001.Images[0];
    if (((MarbleMotionCommands) ((F_MarbleHorVerCut) this).MenuType).selectedWireframeType == CamWireFrameType.Chamfer2D)
      ((F_MarbleHorVerCut) this).btn_strategy.Image = ((F_MarbleHorVerCut) this).\u0001.Images[1];
    if (((MarbleMotionCommands) ((F_MarbleHorVerCut) this).MenuType).selectedWireframeType == CamWireFrameType.Contour)
      ((F_MarbleHorVerCut) this).btn_strategy.Image = ((F_MarbleHorVerCut) this).\u0001.Images[6];
    if (((MarbleMotionCommands) ((F_MarbleHorVerCut) this).MenuType).selectedWireframeType == CamWireFrameType.Engrave)
      ((F_MarbleHorVerCut) this).btn_strategy.Image = ((F_MarbleHorVerCut) this).\u0001.Images[3];
    if (((MarbleMotionCommands) ((F_MarbleHorVerCut) this).MenuType).selectedWireframeType == CamWireFrameType.Face)
      ((F_MarbleHorVerCut) this).btn_strategy.Image = ((F_MarbleHorVerCut) this).\u0001.Images[4];
    if (((MarbleMotionCommands) ((F_MarbleHorVerCut) this).MenuType).selectedWireframeType == CamWireFrameType.FloorFinish)
      ((F_MarbleHorVerCut) this).btn_strategy.Image = ((F_MarbleHorVerCut) this).\u0001.Images[5];
    if (((MarbleMotionCommands) ((F_MarbleHorVerCut) this).MenuType).selectedWireframeType == CamWireFrameType.Pocket)
      ((F_MarbleHorVerCut) this).btn_strategy.Image = ((F_MarbleHorVerCut) this).\u0001.Images[7];
    if (((MarbleMotionCommands) ((F_MarbleHorVerCut) this).MenuType).selectedWireframeType == CamWireFrameType.TextEngrave)
      ((F_MarbleHorVerCut) this).btn_strategy.Image = ((F_MarbleHorVerCut) this).\u0001.Images[8];
    if (((MarbleMotionCommands) ((F_MarbleHorVerCut) this).MenuType).selectedWireframeType == CamWireFrameType.Trochoidal)
      ((F_MarbleHorVerCut) this).btn_strategy.Image = ((F_MarbleHorVerCut) this).\u0001.Images[9];
    ((F_MarbleHorVerCut) this).btn_strategy.Text = $"{buLangTranslate.preDef.Cam} : {((MarbleMotionCommands) ((F_MarbleHorVerCut) this).MenuType).selectedWireframeType.ToString()}";
  }

  public void StrategyMillingHeadToImageIndex()
  {
    if (((MarbleMotionCommands) ((F_MarbleHorVerCut) this).MenuType).selectedWireframeType == CamWireFrameType.CenterPath)
      ((F_MarbleHorVerCut) this).btn_strategy.Image = ((F_MarbleHorVerCut) this).\u0001.Images[0];
    if (((MarbleMotionCommands) ((F_MarbleHorVerCut) this).MenuType).selectedWireframeType == CamWireFrameType.Chamfer2D)
      ((F_MarbleHorVerCut) this).btn_strategy.Image = ((F_MarbleHorVerCut) this).\u0001.Images[1];
    if (((MarbleMotionCommands) ((F_MarbleHorVerCut) this).MenuType).selectedWireframeType == CamWireFrameType.Contour)
      ((F_MarbleHorVerCut) this).btn_strategy.Image = ((F_MarbleHorVerCut) this).\u0001.Images[6];
    if (((MarbleMotionCommands) ((F_MarbleHorVerCut) this).MenuType).selectedWireframeType == CamWireFrameType.Engrave)
      ((F_MarbleHorVerCut) this).btn_strategy.Image = ((F_MarbleHorVerCut) this).\u0001.Images[3];
    if (((MarbleMotionCommands) ((F_MarbleHorVerCut) this).MenuType).selectedWireframeType == CamWireFrameType.Face)
      ((F_MarbleHorVerCut) this).btn_strategy.Image = ((F_MarbleHorVerCut) this).\u0001.Images[4];
    if (((MarbleMotionCommands) ((F_MarbleHorVerCut) this).MenuType).selectedWireframeType == CamWireFrameType.FloorFinish)
      ((F_MarbleHorVerCut) this).btn_strategy.Image = ((F_MarbleHorVerCut) this).\u0001.Images[5];
    if (((MarbleMotionCommands) ((F_MarbleHorVerCut) this).MenuType).selectedWireframeType == CamWireFrameType.Pocket)
      ((F_MarbleHorVerCut) this).btn_strategy.Image = ((F_MarbleHorVerCut) this).\u0001.Images[7];
    if (((MarbleMotionCommands) ((F_MarbleHorVerCut) this).MenuType).selectedWireframeType == CamWireFrameType.TextEngrave)
      ((F_MarbleHorVerCut) this).btn_strategy.Image = ((F_MarbleHorVerCut) this).\u0001.Images[8];
    if (((MarbleMotionCommands) ((F_MarbleHorVerCut) this).MenuType).selectedWireframeType == CamWireFrameType.Trochoidal)
      ((F_MarbleHorVerCut) this).btn_strategy.Image = ((F_MarbleHorVerCut) this).\u0001.Images[9];
    ((F_MarbleHorVerCut) this).btn_strategy.Text = $"{buLangTranslate.preDef.Cam} : {((MarbleMotionCommands) ((F_MarbleHorVerCut) this).MenuType).selectedWireframeType.ToString()}";
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
    if (((F_MarbleHorVerCut) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleHorVerCut) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleHorVerCut) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleHorVerCut) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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
