// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleTempCodes
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
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleTempCodes : Form
{
  public buSpin spn_c;
  public buSpin spn_a;
  public buSpin spn_z;
  public buSpin spn_y;
  public buButton btn_showcoordsHor;
  internal PictureBox \u0001;
  public Panel pnl_coords;
  public Panel pnl_data;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public Color clrLabel;
  public Color clrFormCaption;
  public Color clrFormBackUpper;
  public Color clrFormBackDown;
  public Color clrButtonDisplay;
  public Color clrButtonOver;
  public Color clrButtonDown;
  internal IContainer \u0001;
  public buButton btn_axessettings;
  public buButton btn_offset;
  public buButton btn_positionreset;
  public buButton btn_close;
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buGround buGround1;
  public buLabel lbl_defination;
  public static byte f002BF0;

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleHorizontalCut) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleHorizontalCut) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init()
  {
    ((F_MarbleHorizontalCut) this).PropertiesForm.Inited = false;
    if (((F_MarbleHorizontalCut) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleHorizontalCut) this).PropertiesForm.Height;
    if (((F_MarbleHorizontalCut) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleHorizontalCut) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleHorizontalCut) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleHorizontalCut) this).PropertiesForm.FormPosition;
    ((F_MarbleTempMovements) this).LoadLanguage();
    ((F_Preset) this).ToolToImageIndex();
    ((F_Preset) this).StrategyFromToolType();
    if (!((F_MarbleHorizontalCut) this).PropertiesForm.VisualUpdated)
      ((F_MarbleTempMovements) this).InitVisual();
    ((F_MarbleAxesSettings) this).btn_objectlocation.Image = ((F_MarbleAxesSettings) this).\u0003.Images[Convert.ToInt32((object) ((MarbleMotionCommands) ((F_MarbleHorizontalCut) this).MenuType).objectAlignment)];
    ((F_MarbleAxesSettings) this).chk_insidemilling.Check = ((MarbleMotionCommands) ((F_MarbleHorizontalCut) this).MenuType).InsideMilling;
    ((F_MarbleAxesSettings) this).buGround1.DisplayTop.BackColor = ((F_MarbleHorizontalCut) this).clrFormCaption;
    ((F_MarbleAxesSettings) this).buGround1.Display.GradientType = GradientMode.Lineer;
    ((F_MarbleAxesSettings) this).buGround1.Display.LineerGradient.FirstColor = ((F_MarbleHorizontalCut) this).clrFormBackUpper;
    ((F_MarbleAxesSettings) this).buGround1.Display.LineerGradient.SecondColor = ((F_MarbleHorizontalCut) this).clrFormBackDown;
    ((F_MarbleHorizontalCut) this).btn_close.Display.BackColor = ((F_MarbleHorizontalCut) this).clrFormCaption;
    ((F_MarbleHorizontalCut) this).btn_close.ButtonDownDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleHorizontalCut) this).clrFormCaption, 0.9);
    ((F_MarbleHorizontalCut) this).btn_close.ButtonOverDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleHorizontalCut) this).clrFormCaption, 0.95);
    ((F_MarbleAxesSettings) this).lbl_contourtype.Display.BackColor = ((F_MarbleHorizontalCut) this).clrLabel;
    ((F_MarbleAxesSettings) this).lbl_strategytype.Display.BackColor = ((F_MarbleHorizontalCut) this).clrLabel;
    ((F_MarbleAxesSettings) this).lbl_tooltype.Display.BackColor = ((F_MarbleHorizontalCut) this).clrLabel;
    ((F_MarbleAxesSettings) this).chk_mirrorX.Check = false;
    ((F_MarbleAxesSettings) this).chk_mirroY.Check = false;
    ((F_MarbleAxesSettings) this).chk_rotate180plus.Check = false;
    ((F_MarbleAxesSettings) this).chk_rotate90plus.Check = false;
    ((F_MarbleAxesSettings) this).chk_rotate180minus.Check = false;
    ((F_MarbleAxesSettings) this).chk_rotate90minus.Check = false;
    ((F_MarbleHorizontalCut) this).btn_contourmenueditor.Display.BackColor = ((F_MarbleHorizontalCut) this).clrButtonDisplay;
    ((F_MarbleHorizontalCut) this).btn_contourmenueditor.ButtonDownDisplay.BackColor = ((F_MarbleHorizontalCut) this).clrButtonDown;
    ((F_MarbleHorizontalCut) this).btn_contourmenueditor.ButtonOverDisplay.BackColor = ((F_MarbleHorizontalCut) this).clrButtonOver;
    ((F_MarbleHorizontalCut) this).btn_contourmenufilelist.Display.BackColor = ((F_MarbleHorizontalCut) this).clrButtonDisplay;
    ((F_MarbleHorizontalCut) this).btn_contourmenufilelist.ButtonDownDisplay.BackColor = ((F_MarbleHorizontalCut) this).clrButtonDown;
    ((F_MarbleHorizontalCut) this).btn_contourmenufilelist.ButtonOverDisplay.BackColor = ((F_MarbleHorizontalCut) this).clrButtonOver;
    ((F_MarbleHorizontalCut) this).btn_contourmenufromfile.Display.BackColor = ((F_MarbleHorizontalCut) this).clrButtonDisplay;
    ((F_MarbleHorizontalCut) this).btn_contourmenufromfile.ButtonDownDisplay.BackColor = ((F_MarbleHorizontalCut) this).clrButtonDown;
    ((F_MarbleHorizontalCut) this).btn_contourmenufromfile.ButtonOverDisplay.BackColor = ((F_MarbleHorizontalCut) this).clrButtonOver;
    ((F_MarbleHorizontalCut) this).btn_strategy.Display.BackColor = ((F_MarbleHorizontalCut) this).clrButtonDisplay;
    ((F_MarbleHorizontalCut) this).btn_strategy.ButtonDownDisplay.BackColor = ((F_MarbleHorizontalCut) this).clrButtonDown;
    ((F_MarbleHorizontalCut) this).btn_strategy.ButtonOverDisplay.BackColor = ((F_MarbleHorizontalCut) this).clrButtonOver;
    ((F_MarbleHorizontalCut) this).btn_tool.Display.BackColor = ((F_MarbleHorizontalCut) this).clrButtonDisplay;
    ((F_MarbleHorizontalCut) this).btn_tool.ButtonDownDisplay.BackColor = ((F_MarbleHorizontalCut) this).clrButtonDown;
    ((F_MarbleHorizontalCut) this).btn_tool.ButtonOverDisplay.BackColor = ((F_MarbleHorizontalCut) this).clrButtonOver;
    ((F_MarbleHorizontalCut) this).btn_toolsettings.Display.BackColor = ((F_MarbleHorizontalCut) this).clrButtonDisplay;
    ((F_MarbleHorizontalCut) this).btn_toolsettings.ButtonDownDisplay.BackColor = ((F_MarbleHorizontalCut) this).clrButtonDown;
    ((F_MarbleHorizontalCut) this).btn_toolsettings.ButtonOverDisplay.BackColor = ((F_MarbleHorizontalCut) this).clrButtonOver;
    ((F_MarbleHorizontalCut) this).btn_camsettings.Display.BackColor = ((F_MarbleHorizontalCut) this).clrButtonDisplay;
    ((F_MarbleHorizontalCut) this).btn_camsettings.ButtonDownDisplay.BackColor = ((F_MarbleHorizontalCut) this).clrButtonDown;
    ((F_MarbleHorizontalCut) this).btn_camsettings.ButtonOverDisplay.BackColor = ((F_MarbleHorizontalCut) this).clrButtonOver;
    ((F_MarbleHorizontalCut) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleHorizontalCut) this).PropertiesForm.Inited = true;
  }
}
