// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleProfileMenu
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

public class F_MarbleProfileMenu : Form
{
  public buButton btn_close;
  public buCheckBox chk_toolsaw;
  public buCheckBox chk_toolmilling;
  public buGround buGround1;
  public static byte f0027F6;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public MarbleWaterJetCamType WaterJetCamType;
  private IContainer \u0001;
  public buButton btn_close;
  public buCheckBox chk_contour;
  public buGround buGround1;
  public static byte f002800;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public MarbleSawCamType SawCamType;
  private IContainer \u0001;
  public buButton btn_close;
  public buCheckBox chk_contour;
  public buGround buGround1;
  public static byte f00280A;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions = new List<string>();
  public FormProperties PropertiesForm;
  public CamWireFrameType WireframeType;
  private IContainer \u0001;
  internal buGround \u0001;
  public buButton btn_close;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.\u0001 != null ? 1 : 0)) != 0)
      this.\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleProfileMenu()
  {
  }

  public F_MarbleProfileMenu()
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
      ((F_MarbleShapeMenu) this).chk_toolmilling.Text = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Tool}";
      ((F_MarbleShapeMenu) this).chk_toolmillinghead.Text = $"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Tool}";
      ((F_MarbleShapeMenu) this).chk_toolsaw.Text = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Tool}";
      ((F_MarbleShapeMenu) this).chk_toolwaterjet.Text = $"{buLangTranslate.preDef.WaterJet} {buLangTranslate.preDef.Tool}";
      ((F_MarbleShapeMenu) this).buGround1.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Menu}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleShapeMenu) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleShapeMenu) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleShapeMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleShapeMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleShapeMenu) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleShapeMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleShapeMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] bool obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleShapeMenu) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleShapeMenu) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleProfileMenu() => F_MarbleShapeMenu.Captions = new List<string>();

  public F_MarbleProfileMenu()
  {
    // ISSUE: unable to decompile the method.
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleShapeMenu) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleShapeMenu) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleShapeMenu) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleShapeMenu) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init()
  {
    ((F_MarbleShapeMenu) this).PropertiesForm.Inited = false;
    if (((F_MarbleShapeMenu) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleShapeMenu) this).PropertiesForm.Height;
    if (((F_MarbleShapeMenu) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleShapeMenu) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleShapeMenu) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleShapeMenu) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleShapeMenu) this).ToolToImageIndex();
    ((F_MarbleShapeMenu) this).StrategyFromToolType();
    ((F_MarbleShapeMenu) this).buGround1.DisplayTop.BackColor = ((F_MarbleShapeMenu) this).clrFormCaption;
    ((F_MarbleShapeMenu) this).buGround1.Display.GradientType = GradientMode.Lineer;
    ((F_MarbleShapeMenu) this).buGround1.Display.LineerGradient.FirstColor = ((F_MarbleShapeMenu) this).clrFormBackUpper;
    ((F_MarbleShapeMenu) this).buGround1.Display.LineerGradient.SecondColor = ((F_MarbleShapeMenu) this).clrFormBackDown;
    ((F_MarbleShapeMenu) this).btn_close.Display.BackColor = ((F_MarbleShapeMenu) this).clrFormCaption;
    ((F_MarbleShapeMenu) this).btn_close.ButtonDownDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleShapeMenu) this).clrFormCaption, 0.9);
    ((F_MarbleShapeMenu) this).btn_close.ButtonOverDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleShapeMenu) this).clrFormCaption, 0.95);
    ((F_MarbleCutting) this).lbl_contourtype.Display.BackColor = ((F_MarbleShapeMenu) this).clrLabel;
    ((F_MarbleShapeMenu) this).lbl_strategytype.Display.BackColor = ((F_MarbleShapeMenu) this).clrLabel;
    ((F_MarbleCutting) this).lbl_tooltype.Display.BackColor = ((F_MarbleShapeMenu) this).clrLabel;
    ((F_MarbleShapeMenu) this).btn_contourmenueditor.Display.BackColor = ((F_MarbleShapeMenu) this).clrButtonDisplay;
    ((F_MarbleShapeMenu) this).btn_contourmenueditor.ButtonDownDisplay.BackColor = ((F_MarbleShapeMenu) this).clrButtonDown;
    ((F_MarbleShapeMenu) this).btn_contourmenueditor.ButtonOverDisplay.BackColor = ((F_MarbleShapeMenu) this).clrButtonOver;
    ((F_MarbleShapeMenu) this).btn_contourmenufilelist.Display.BackColor = ((F_MarbleShapeMenu) this).clrButtonDisplay;
    ((F_MarbleShapeMenu) this).btn_contourmenufilelist.ButtonDownDisplay.BackColor = ((F_MarbleShapeMenu) this).clrButtonDown;
    ((F_MarbleShapeMenu) this).btn_contourmenufilelist.ButtonOverDisplay.BackColor = ((F_MarbleShapeMenu) this).clrButtonOver;
    ((F_MarbleShapeMenu) this).btn_contourmenufromfile.Display.BackColor = ((F_MarbleShapeMenu) this).clrButtonDisplay;
    ((F_MarbleShapeMenu) this).btn_contourmenufromfile.ButtonDownDisplay.BackColor = ((F_MarbleShapeMenu) this).clrButtonDown;
    ((F_MarbleShapeMenu) this).btn_contourmenufromfile.ButtonOverDisplay.BackColor = ((F_MarbleShapeMenu) this).clrButtonOver;
    ((F_MarbleShapeMenu) this).btn_strategy.Display.BackColor = ((F_MarbleShapeMenu) this).clrButtonDisplay;
    ((F_MarbleShapeMenu) this).btn_strategy.ButtonDownDisplay.BackColor = ((F_MarbleShapeMenu) this).clrButtonDown;
    ((F_MarbleShapeMenu) this).btn_strategy.ButtonOverDisplay.BackColor = ((F_MarbleShapeMenu) this).clrButtonOver;
    ((F_MarbleShapeMenu) this).btn_tool.Display.BackColor = ((F_MarbleShapeMenu) this).clrButtonDisplay;
    ((F_MarbleShapeMenu) this).btn_tool.ButtonDownDisplay.BackColor = ((F_MarbleShapeMenu) this).clrButtonDown;
    ((F_MarbleShapeMenu) this).btn_tool.ButtonOverDisplay.BackColor = ((F_MarbleShapeMenu) this).clrButtonOver;
    ((F_MarbleShapeMenu) this).btn_toolsettings.Display.BackColor = ((F_MarbleShapeMenu) this).clrButtonDisplay;
    ((F_MarbleShapeMenu) this).btn_toolsettings.ButtonDownDisplay.BackColor = ((F_MarbleShapeMenu) this).clrButtonDown;
    ((F_MarbleShapeMenu) this).btn_toolsettings.ButtonOverDisplay.BackColor = ((F_MarbleShapeMenu) this).clrButtonOver;
    ((F_MarbleShapeMenu) this).btn_camsettings.Display.BackColor = ((F_MarbleShapeMenu) this).clrButtonDisplay;
    ((F_MarbleShapeMenu) this).btn_camsettings.ButtonDownDisplay.BackColor = ((F_MarbleShapeMenu) this).clrButtonDown;
    ((F_MarbleShapeMenu) this).btn_camsettings.ButtonOverDisplay.BackColor = ((F_MarbleShapeMenu) this).clrButtonOver;
    ((F_MarbleShapeMenu) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleShapeMenu) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleCutting) this).lbl_contourtype.Text = $"{buLangTranslate.preDef.Lathe} {buLangTranslate.preDef.Type}";
      ((F_MarbleShapeMenu) this).lbl_strategytype.Text = $"{buLangTranslate.preDef.Strategy} {buLangTranslate.preDef.Type}";
      ((F_MarbleCutting) this).lbl_tooltype.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Type}";
      ((F_MarbleShapeMenu) this).btn_contourmenueditor.Text = buLangTranslate.preDef.Editor;
      ((F_MarbleShapeMenu) this).btn_contourmenufilelist.Text = buLangTranslate.preDef.FromList;
      ((F_MarbleShapeMenu) this).btn_contourmenufromfile.Text = buLangTranslate.preDef.FromFile;
      ((F_MarbleShapeMenu) this).btn_strategy.Text = buLangTranslate.preDef.Strategy;
      ((F_MarbleShapeMenu) this).btn_tool.Text = buLangTranslate.preDef.Tool;
      ((F_MarbleShapeMenu) this).buGround1.Text = $"{buLangTranslate.preDef.Lathe} {buLangTranslate.preDef.Menu}";
    }
    catch (Exception ex)
    {
    }
  }

  public event OkCommandWithFiveDataEventHandler CommandExecute;
}
