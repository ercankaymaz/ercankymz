// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleProfileCurveCam
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleProfileCurveCam : Form
{
  public buButton btn_save;
  public buButton btn_open;
  public static byte f001E76;
  public static List<string> Captions;
  public FormProperties Properties;
  private IContainer \u0001;
  public buSpin spn_itemEA;
  public buSpin spn_itemSA;
  public buSpin spn_itemcount;
  public buSpin spn_itemwidth;
  public buButton btn_close;
  public buGround buGround1;
  public buButton btn_ok;
  public buLabel lbl_length;
  public buLabel lbl_ea;
  public buLabel lbl_sa;
  public buLabel lbl_count;
  public Panel pnl_base;
  public Panel pnl_data;
  public buSpin spn_itemlength;
  public buButton btn_cancel;
  public buCheckBox chk_vertical;
  public buCheckBox chk_horizontal;
  public Panel pnl_viewport;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public MarbleShapeTypes ShapeType;
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
  public buButton btn_rectangle;
  public buButton btn_ellipse;
  public buButton btn_circle;
  public buButton btn_trapezoid;
  public buButton btn_triangle;
  public buButton btn_slot;
  public buButton btn_polygon;
  internal ImageList \u0001;
  internal ImageList \u0002;
  internal buSeparator \u0001;
  public buButton btn_camsettings;
  public buButton btn_toolsettings;
  public buButton btn_strategy;
  public buButton btn_tool;
  public buGround buGround1;
  public buLabel lbl_strategytype;
  public buLabel lbl_tooltype;
  public buLabel lbl_contourtype;
  public buButton btn_settings;
  public buButton btn_close;
  public buButton btn_arc;
  public buButton btn_shipnose;
  public buButton btn_rectanglecross;
  public buButton btn_rectanglechamfer;
  public buButton btn_rectangleround;
  public buButton btn_ellipsepie;
  public buButton btn_arcpie;
  public buButton btn_library;
  public buButton btn_contour;
  public static byte f001EB9;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public MarbleEngraveMenuType EngraveType;
  public Color clrLabel;
  public Color clrFormCaption;

  public void spn_Leave(object sender, EventArgs e)
  {
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    buSpin buSpin = obj0 as buSpin;
    if (!AppBool.TouchPad)
      return;
    F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
    if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }

  public void MenuButtonColors(int PageIndex)
  {
    buEyeShotFunctions.SetVisualItem(((F_MarbleDrillPocketCam) this).\u0001.Controls);
    if (PageIndex == 0)
    {
      ((F_MarbleSawMillingCam) this).btn_angle.Display.BackColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleSawMillingCam) this).btn_angle.Display.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleSawMillingCam) this).btn_angle.Display.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    }
    if (PageIndex == 1)
    {
      ((F_MarbleSawMillingCam) this).btn_length.Display.BackColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleSawMillingCam) this).btn_length.Display.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleSawMillingCam) this).btn_length.Display.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    }
    ((F_MarbleSawMillingCam) this).buTab2.SelectedIndex = PageIndex;
  }

  public void MenuButtonDrawColors(DrawingTypes T)
  {
    buEyeShotFunctions.SetVisualItem(((F_MarbleTap) this).pnl_data.Controls);
    if (T == DrawingTypes.Line)
    {
      ((F_MarbleDrillPocketCam) this).btn_polyline.Display.BackColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleDrillPocketCam) this).btn_polyline.Display.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleDrillPocketCam) this).btn_polyline.Display.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleDrillPocketCam) this).buTab1.SelectedIndex = 0;
    }
    if (T == DrawingTypes.Arc)
    {
      ((F_MarbleDrillPocketCam) this).btn_arc.Display.BackColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleDrillPocketCam) this).btn_arc.Display.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleDrillPocketCam) this).btn_arc.Display.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleDrillPocketCam) this).buTab1.SelectedIndex = 0;
    }
    if (T == DrawingTypes.Circle)
    {
      ((F_MarbleDrillPocketCam) this).btn_circle.Display.BackColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleDrillPocketCam) this).btn_circle.Display.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleDrillPocketCam) this).btn_circle.Display.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleDrillPocketCam) this).buTab1.SelectedIndex = 1;
    }
    if (T != DrawingTypes.Rectangle)
      return;
    ((F_MarbleDrillPocketCam) this).btn_rectangle.Display.BackColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    ((F_MarbleDrillPocketCam) this).btn_rectangle.Display.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    ((F_MarbleDrillPocketCam) this).btn_rectangle.Display.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    ((F_MarbleDrillPocketCam) this).buTab1.SelectedIndex = 2;
  }

  public void MenuButtonAngleColors(double Angle)
  {
    buEyeShotFunctions.SetVisualItem(((F_MarbleSawMillingCam) this).\u0004.Controls);
    if (Angle == 0.0)
    {
      ((F_MarbleCavity) this).btn_right.Display.BackColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleCavity) this).btn_right.Display.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleCavity) this).btn_right.Display.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    }
    if (Angle == 45.0)
    {
      ((F_MarbleCavity) this).btn_rightup.Display.BackColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleCavity) this).btn_rightup.Display.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleCavity) this).btn_rightup.Display.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    }
    if (Angle == 90.0)
    {
      ((F_MarbleCavity) this).btn_up.Display.BackColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleCavity) this).btn_up.Display.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleCavity) this).btn_up.Display.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    }
    if (Angle == 135.0)
    {
      ((F_MarbleCavity) this).btn_leftup.Display.BackColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleCavity) this).btn_leftup.Display.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleCavity) this).btn_leftup.Display.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    }
    if (Angle == 180.0)
    {
      ((F_MarbleCavity) this).btn_left.Display.BackColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleCavity) this).btn_left.Display.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleCavity) this).btn_left.Display.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    }
    if (Angle == 225.0)
    {
      ((F_MarbleCavity) this).btn_leftdown.Display.BackColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleCavity) this).btn_leftdown.Display.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleCavity) this).btn_leftdown.Display.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    }
    if (Angle == 270.0)
    {
      ((F_MarbleCavity) this).btn_down.Display.BackColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleCavity) this).btn_down.Display.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
      ((F_MarbleCavity) this).btn_down.Display.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    }
    if (Angle != 315.0)
      return;
    ((F_MarbleCavity) this).btn_rightdown.Display.BackColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    ((F_MarbleCavity) this).btn_rightdown.Display.LineerGradient.FirstColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
    ((F_MarbleCavity) this).btn_rightdown.Display.LineerGradient.SecondColor = ((buFile5) clsVisualVars.parVisual.hmiButtonMenu2).ButtonNormal.SelectionColor;
  }

  internal void \u0001([In] object obj0, [In] TreeViewEventArgs obj1)
  {
  }

  internal void \u0004([In] object obj0, [In] EventArgs obj1)
  {
  }

  internal void \u0001([In] object obj0, [In] TreeNodeMouseClickEventArgs obj1)
  {
    if (AppBool.ListFilling | AppBool.TreeCollapsing | AppBool.TreeExpanding)
    {
      AppBool.TreeCollapsing = false;
      AppBool.TreeExpanding = false;
    }
    else
    {
      AppBool.TreeNodeClicked = true;
      if (((buTreeNode) obj1.Node).Command == "main")
        ((F_MarbleDrillPocketCam) this).buTab1.SelectedIndex = 0;
      AppBool.TreeNodeClicked = false;
    }
  }
}
