// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleSweepMenu
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

public class F_MarbleSweepMenu : Form
{
  internal ImageList \u0001;
  internal ImageList \u0002;
  internal buSeparator \u0001;
  internal buSeparator \u0002;
  public buButton btn_strategy;
  public buButton btn_tool;
  public buButton btn_camsettings;
  public buButton btn_toolsettings;
  public buGround buGround1;
  public buLabel lbl_strategytype;
  public buLabel lbl_tooltype;
  public buLabel lbl_contourtype;
  public buCheckBox chk_5Axismilling;
  public buButton btn_camsettings2;
  public buButton btn_strategy2;
  public static byte f0027E1;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public MarbleToolType ToolType;
  private IContainer \u0001;
  public buButton btn_close;
  public buCheckBox chk_toolmilling;
  public buGround buGround1;
  public static byte f0027EB;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public MarbleToolType ToolType;
  private IContainer \u0001;

  public F_MarbleSweepMenu()
  {
    // ISSUE: unable to decompile the method.
  }

  public void Init()
  {
    // ISSUE: unable to decompile the method.
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleProfileMenu) this).chk_contour.Text = $"{buLangTranslate.preDef.Contour} {buLangTranslate.preDef.Strategy}";
      ((F_MarbleProfileMenu) this).buGround1.Text = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Strategy}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleProfileMenu) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleProfileMenu) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleProfileMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleProfileMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleProfileMenu) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleProfileMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleProfileMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] bool obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleProfileMenu) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleProfileMenu) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleSweepMenu() => F_MarbleProfileMenu.Captions = new List<string>();

  public F_MarbleSweepMenu()
  {
    ((F_MarbleProfileMenu) this).SpinBaseColor = Color.LightGreen;
    ((F_MarbleProfileMenu) this).SpinFocusColor = Color.MistyRose;
    ((F_MarbleProfileMenu) this).PropertiesForm = new FormProperties();
    ((F_MarbleProfileMenu) this).WireframeType = CamWireFrameType.Contour;
    ((F_MarbleProfileMenu) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_Marble2DCamStrategyMenu) this);
  }

  public void Init()
  {
    ((F_MarbleProfileMenu) this).PropertiesForm.Inited = false;
    if (((F_MarbleProfileMenu) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleProfileMenu) this).PropertiesForm.Height;
    if (((F_MarbleProfileMenu) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleProfileMenu) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleProfileMenu) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleProfileMenu) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleShapeMenu) this).chk_center.Check = false;
    ((F_MarbleShapeMenu) this).chk_chamfer.Check = false;
    ((F_MarbleShapeMenu) this).chk_Contour.Check = false;
    ((F_MarbleShapeMenu) this).chk_engrave.Check = false;
    ((F_MarbleShapeMenu) this).chk_face.Check = false;
    ((F_MarbleShapeMenu) this).chk_floorfinish.Check = false;
    ((F_MarbleShapeMenu) this).chk_rough.Check = false;
    ((F_MarbleShapeMenu) this).chk_textengrave.Check = false;
    ((F_MarbleShapeMenu) this).chk_trochoidal.Check = false;
    ((F_MarbleShapeMenu) this).chk_none.Check = false;
    if (((F_MarbleProfileMenu) this).WireframeType == CamWireFrameType.CenterPath)
      ((F_MarbleShapeMenu) this).chk_center.Check = true;
    if (((F_MarbleProfileMenu) this).WireframeType == CamWireFrameType.Chamfer2D)
      ((F_MarbleShapeMenu) this).chk_chamfer.Check = true;
    if (((F_MarbleProfileMenu) this).WireframeType == CamWireFrameType.Contour)
      ((F_MarbleShapeMenu) this).chk_Contour.Check = true;
    if (((F_MarbleProfileMenu) this).WireframeType == CamWireFrameType.Engrave)
      ((F_MarbleShapeMenu) this).chk_engrave.Check = true;
    if (((F_MarbleProfileMenu) this).WireframeType == CamWireFrameType.Face)
      ((F_MarbleShapeMenu) this).chk_face.Check = true;
    if (((F_MarbleProfileMenu) this).WireframeType == CamWireFrameType.FloorFinish)
      ((F_MarbleShapeMenu) this).chk_floorfinish.Check = true;
    if (((F_MarbleProfileMenu) this).WireframeType == CamWireFrameType.Pocket)
      ((F_MarbleShapeMenu) this).chk_rough.Check = true;
    if (((F_MarbleProfileMenu) this).WireframeType == CamWireFrameType.TextEngrave)
      ((F_MarbleShapeMenu) this).chk_textengrave.Check = true;
    if (((F_MarbleProfileMenu) this).WireframeType == CamWireFrameType.Trochoidal)
      ((F_MarbleShapeMenu) this).chk_trochoidal.Check = true;
    if (((F_MarbleProfileMenu) this).WireframeType == CamWireFrameType.None)
      ((F_MarbleShapeMenu) this).chk_none.Check = true;
    ((F_MarbleProfileMenu) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleProfileMenu) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleShapeMenu) this).chk_center.Text = $"{buLangTranslate.preDef.Center} {buLangTranslate.preDef.Strategy}";
      ((F_MarbleShapeMenu) this).chk_chamfer.Text = $"{buLangTranslate.preDef.Chamfer} {buLangTranslate.preDef.Strategy}";
      ((F_MarbleShapeMenu) this).chk_Contour.Text = $"{buLangTranslate.preDef.Contour} {buLangTranslate.preDef.Strategy}";
      ((F_MarbleShapeMenu) this).chk_engrave.Text = $"{buLangTranslate.preDef.Engrave} {buLangTranslate.preDef.Strategy}";
      ((F_MarbleShapeMenu) this).chk_face.Text = $"{buLangTranslate.preDef.Face} {buLangTranslate.preDef.Strategy}";
      ((F_MarbleShapeMenu) this).chk_floorfinish.Text = $"{buLangTranslate.preDef.FloorFinish} {buLangTranslate.preDef.Strategy}";
      ((F_MarbleShapeMenu) this).chk_rough.Text = $"{buLangTranslate.preDef.Rough} {buLangTranslate.preDef.Strategy}";
      ((F_MarbleShapeMenu) this).chk_textengrave.Text = $"{buLangTranslate.preDef.TextEngrave} {buLangTranslate.preDef.Strategy}";
      ((F_MarbleShapeMenu) this).chk_trochoidal.Text = $"{buLangTranslate.preDef.Trochoidal} {buLangTranslate.preDef.Strategy}";
      ((F_MarbleShapeMenu) this).chk_none.Text = buLangTranslate.preDef.None;
      ((F_MarbleProfileMenu) this).\u0001.Text = $"{buLangTranslate.preDef.Millind2D} {buLangTranslate.preDef.Strategy}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleProfileMenu) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleProfileMenu) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleProfileMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleProfileMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleProfileMenu) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleProfileMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleProfileMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] bool obj1)
  {
    if (!((F_MarbleProfileMenu) this).PropertiesForm.Inited)
      return;
    Control control = obj0 as Control;
    if (control.Name == ((F_MarbleShapeMenu) this).chk_center.Name)
    {
      ((F_MarbleShapeMenu) this).chk_center.Check = true;
      ((F_MarbleProfileMenu) this).WireframeType = CamWireFrameType.CenterPath;
    }
    if (control.Name == ((F_MarbleShapeMenu) this).chk_chamfer.Name)
    {
      ((F_MarbleShapeMenu) this).chk_chamfer.Check = true;
      ((F_MarbleProfileMenu) this).WireframeType = CamWireFrameType.Chamfer2D;
    }
    if (control.Name == ((F_MarbleShapeMenu) this).chk_Contour.Name)
    {
      ((F_MarbleShapeMenu) this).chk_Contour.Check = false;
      ((F_MarbleProfileMenu) this).WireframeType = CamWireFrameType.Contour;
    }
    if (control.Name == ((F_MarbleShapeMenu) this).chk_engrave.Name)
    {
      ((F_MarbleShapeMenu) this).chk_engrave.Check = false;
      ((F_MarbleProfileMenu) this).WireframeType = CamWireFrameType.Engrave;
    }
    if (control.Name == ((F_MarbleShapeMenu) this).chk_face.Name)
    {
      ((F_MarbleShapeMenu) this).chk_face.Check = false;
      ((F_MarbleProfileMenu) this).WireframeType = CamWireFrameType.Face;
    }
    if (control.Name == ((F_MarbleShapeMenu) this).chk_floorfinish.Name)
    {
      ((F_MarbleShapeMenu) this).chk_floorfinish.Check = false;
      ((F_MarbleProfileMenu) this).WireframeType = CamWireFrameType.FloorFinish;
    }
    if (control.Name == ((F_MarbleShapeMenu) this).chk_rough.Name)
    {
      ((F_MarbleShapeMenu) this).chk_rough.Check = false;
      ((F_MarbleProfileMenu) this).WireframeType = CamWireFrameType.Pocket;
    }
    if (control.Name == ((F_MarbleShapeMenu) this).chk_textengrave.Name)
    {
      ((F_MarbleShapeMenu) this).chk_textengrave.Check = false;
      ((F_MarbleProfileMenu) this).WireframeType = CamWireFrameType.TextEngrave;
    }
    if (control.Name == ((F_MarbleShapeMenu) this).chk_trochoidal.Name)
    {
      ((F_MarbleShapeMenu) this).chk_trochoidal.Check = false;
      ((F_MarbleProfileMenu) this).WireframeType = CamWireFrameType.Trochoidal;
    }
    if (control.Name == ((F_MarbleShapeMenu) this).chk_none.Name)
    {
      ((F_MarbleShapeMenu) this).chk_none.Check = false;
      ((F_MarbleProfileMenu) this).WireframeType = CamWireFrameType.None;
    }
    ((F_MarbleProfileMenu) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_MarbleProfileMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleProfileMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public event OkCommandWithFiveDataEventHandler CommandExecute;
}
