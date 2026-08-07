// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleMillingCamSetting
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleMillingCamSetting : Form
{
  public buSpin spn_itemEA2;
  public buSpin spn_itemSA2;
  public buSpin spn_itemcount2;
  public buSpin spn_itemlen2;
  public buSpin spn_itemEA1;
  public buSpin spn_itemSA1;
  public buSpin spn_itemcount1;
  public buSpin spn_itemlen1;
  public buButton btn_minimize;
  public buButton btn_maximize;
  public buButton btn_close;
  public buGround buGround1;
  public buButton btn_save;
  public buButton btn_open;
  public buButton btn_downVer;
  public buButton btn_upVer;
  public buButton btn_okVer;
  public buButton btn_cancel;
  public buLabel lbl_length;
  public buLabel lbl_5;
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
  public Panel pnl_base;
  public buButton btn_clearallVer;
  public buSpin spn_anglever;
  public buSpin spn_lengthVer;
  internal buLabel \u0001;
  public Panel pnl_data;
  public buSpin spn_y;
  public buSpin spn_x;
  public TextBox txt_info;
  public buCheckBox chk_showalldrawing;
  public static List<string> Captions;
  private IContainer \u0001;
  public buSpin spn_lengthVer;
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
  public buSpin spn_itemEA2;
  public buSpin spn_itemSA2;
  public buSpin spn_itemcount2;
  public buSpin spn_itemlen2;
  public buSpin spn_itemEA1;
  public buSpin spn_itemSA1;
  public buSpin spn_itemcount1;
  public buSpin spn_itemlen1;
  public buButton buButton1;
  public buButton btn_maximize;
  public buButton btn_close;
  public buGround buGround1;
  public buLabel lbl_total;
  public buLabel lbl_totalcounthor;
  public buLabel lbl_totallenhor;
  public buButton btn_save;
  public buButton btn_open;
  public buButton btn_endposVer;
  public buButton btn_startposVer;
  public buButton btn_downVer;
  public buButton btn_upVer;
  public buButton btn_okVer;
  public buButton btn_cancel;
  public buLabel lbl_length;
  public buLabel lbl_5;

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleSetAngle) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleSetAngle) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleSetAngle) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleHorVerCut) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleHorVerCut) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleMillingCamSetting() => F_MarbleSetAngle.Captions = new List<string>();

  public F_MarbleMillingCamSetting()
  {
    // ISSUE: unable to decompile the method.
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleHorVerCut) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleHorVerCut) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleHorVerCut) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleHorVerCut) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init()
  {
    ((F_MarbleHorVerCut) this).PropertiesForm.Inited = false;
    if (((F_MarbleHorVerCut) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleHorVerCut) this).PropertiesForm.Height;
    if (((F_MarbleHorVerCut) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleHorVerCut) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleHorVerCut) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleHorVerCut) this).PropertiesForm.FormPosition;
    ((F_MarbleEngraveCamSetting) this).LoadLanguage();
    ((F_MarbleEngraveCamSetting) this).ToolToImageIndex();
    ((F_MarbleEngraveCamSetting) this).StrategyFromToolType();
    if (!((F_MarbleHorVerCut) this).PropertiesForm.VisualUpdated)
      this.InitVisual();
    ((F_MarbleVerticalCut) this).btn_objectlocation.Image = ((F_MarbleVerticalCut) this).\u0003.Images[Convert.ToInt32((object) ((MarbleMotionCommands) ((F_MarbleHorVerCut) this).MenuType).objectAlignment)];
    ((F_MarbleHorVerCut) this).buGround1.DisplayTop.BackColor = ((F_MarbleHorVerCut) this).clrFormCaption;
    ((F_MarbleHorVerCut) this).buGround1.Display.GradientType = GradientMode.Lineer;
    ((F_MarbleHorVerCut) this).buGround1.Display.LineerGradient.FirstColor = ((F_MarbleHorVerCut) this).clrFormBackUpper;
    ((F_MarbleHorVerCut) this).buGround1.Display.LineerGradient.SecondColor = ((F_MarbleHorVerCut) this).clrFormBackDown;
    ((F_MarbleVerticalCut) this).btn_close.Display.BackColor = ((F_MarbleHorVerCut) this).clrFormCaption;
    ((F_MarbleVerticalCut) this).btn_close.ButtonDownDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleHorVerCut) this).clrFormCaption, 0.9);
    ((F_MarbleVerticalCut) this).btn_close.ButtonOverDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleHorVerCut) this).clrFormCaption, 0.95);
    ((F_MarbleHorVerCut) this).lbl_contourtype.Display.BackColor = ((F_MarbleHorVerCut) this).clrLabel;
    ((F_MarbleHorVerCut) this).lbl_strategytype.Display.BackColor = ((F_MarbleHorVerCut) this).clrLabel;
    ((F_MarbleHorVerCut) this).lbl_tooltype.Display.BackColor = ((F_MarbleHorVerCut) this).clrLabel;
    ((F_MarbleVerticalCut) this).chk_mirrorX.Check = false;
    ((F_MarbleVerticalCut) this).chk_mirroY.Check = false;
    ((F_MarbleVerticalCut) this).chk_rotate180plus.Check = false;
    ((F_MarbleVerticalCut) this).chk_rotate90plus.Check = false;
    ((F_MarbleVerticalCut) this).chk_rotate180minus.Check = false;
    ((F_MarbleVerticalCut) this).chk_rotate90minus.Check = false;
    ((F_MarbleHorVerCut) this).btn_circle.Display.BackColor = ((F_MarbleHorVerCut) this).clrButtonDisplay;
    ((F_MarbleHorVerCut) this).btn_circle.ButtonDownDisplay.BackColor = ((F_MarbleHorVerCut) this).clrButtonDown;
    ((F_MarbleHorVerCut) this).btn_circle.ButtonOverDisplay.BackColor = ((F_MarbleHorVerCut) this).clrButtonOver;
    ((F_MarbleHorVerCut) this).btn_ellipse.Display.BackColor = ((F_MarbleHorVerCut) this).clrButtonDisplay;
    ((F_MarbleHorVerCut) this).btn_ellipse.ButtonDownDisplay.BackColor = ((F_MarbleHorVerCut) this).clrButtonDown;
    ((F_MarbleHorVerCut) this).btn_ellipse.ButtonOverDisplay.BackColor = ((F_MarbleHorVerCut) this).clrButtonOver;
    ((F_MarbleHorVerCut) this).btn_polygon.Display.BackColor = ((F_MarbleHorVerCut) this).clrButtonDisplay;
    ((F_MarbleHorVerCut) this).btn_polygon.ButtonDownDisplay.BackColor = ((F_MarbleHorVerCut) this).clrButtonDown;
    ((F_MarbleHorVerCut) this).btn_polygon.ButtonOverDisplay.BackColor = ((F_MarbleHorVerCut) this).clrButtonOver;
    ((F_MarbleHorVerCut) this).btn_rectangle.Display.BackColor = ((F_MarbleHorVerCut) this).clrButtonDisplay;
    ((F_MarbleHorVerCut) this).btn_rectangle.ButtonDownDisplay.BackColor = ((F_MarbleHorVerCut) this).clrButtonDown;
    ((F_MarbleHorVerCut) this).btn_rectangle.ButtonOverDisplay.BackColor = ((F_MarbleHorVerCut) this).clrButtonOver;
    ((F_MarbleHorVerCut) this).btn_slot.Display.BackColor = ((F_MarbleHorVerCut) this).clrButtonDisplay;
    ((F_MarbleHorVerCut) this).btn_slot.ButtonDownDisplay.BackColor = ((F_MarbleHorVerCut) this).clrButtonDown;
    ((F_MarbleHorVerCut) this).btn_slot.ButtonOverDisplay.BackColor = ((F_MarbleHorVerCut) this).clrButtonOver;
    ((F_MarbleHorVerCut) this).btn_trapezoid.Display.BackColor = ((F_MarbleHorVerCut) this).clrButtonDisplay;
    ((F_MarbleHorVerCut) this).btn_trapezoid.ButtonDownDisplay.BackColor = ((F_MarbleHorVerCut) this).clrButtonDown;
    ((F_MarbleHorVerCut) this).btn_trapezoid.ButtonOverDisplay.BackColor = ((F_MarbleHorVerCut) this).clrButtonOver;
    ((F_MarbleHorVerCut) this).btn_triangle.Display.BackColor = ((F_MarbleHorVerCut) this).clrButtonDisplay;
    ((F_MarbleHorVerCut) this).btn_triangle.ButtonDownDisplay.BackColor = ((F_MarbleHorVerCut) this).clrButtonDown;
    ((F_MarbleHorVerCut) this).btn_triangle.ButtonOverDisplay.BackColor = ((F_MarbleHorVerCut) this).clrButtonOver;
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
    ((F_MarbleHorVerCut) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleHorVerCut) this).PropertiesForm.Inited = true;
  }

  public void InitVisual()
  {
    if (new FileInfo(AppPath.MachineSettings + "\\ApplicationVisual.prm").Exists)
    {
      Control.ControlCollection controlCollection = (Control.ControlCollection) null;
      controlCollection = buEyeShotFunctions.SetVisualItem(((F_MarbleHorVerCut) this).buGround1.Controls);
    }
    ((F_MarbleHorVerCut) this).PropertiesForm.VisualUpdated = true;
  }
}
