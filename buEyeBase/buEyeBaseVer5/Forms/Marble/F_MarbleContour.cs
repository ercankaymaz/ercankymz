// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleContour
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleContour : Form
{
  public buButton btn_DI4;
  public buButton btn_DI3;
  public buButton btn_DI2;
  public buButton btn_DI1;
  public buButton btn_DI0;
  public buButton btn_DI63;
  public buButton btn_DI48;
  public buButton btn_DI62;
  public buButton btn_DI49;
  public buButton btn_DI61;
  public buButton btn_DI50;
  public buButton btn_DI60;
  public buButton btn_DI51;
  public buButton btn_DI59;
  public buButton btn_DI52;
  public buButton btn_DI58;
  public buButton btn_DI53;
  public buButton btn_DI57;
  public buButton btn_DI54;
  public buButton btn_DI56;
  public buButton btn_DI55;
  public ImageList IC48;
  public buPanel pnl_input2;
  public buPanel pnl_input3;

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleDigitalInputOutput) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleDigitalInputOutput) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init()
  {
    ((F_MarbleDigitalInputOutput) this).PropertiesForm.Inited = false;
    if (((F_MarbleDigitalInputOutput) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleDigitalInputOutput) this).PropertiesForm.Height;
    if (((F_MarbleDigitalInputOutput) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleDigitalInputOutput) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleDigitalInputOutput) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleDigitalInputOutput) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    this.ToolToImageIndex();
    this.StrategyFromToolType(0);
    this.StrategyFromToolType(1);
    ((F_MarbleDigitalOutput) this).buGround1.DisplayTop.BackColor = ((F_MarbleDigitalOutput) this).clrFormCaption;
    ((F_MarbleDigitalOutput) this).buGround1.Display.GradientType = GradientMode.Lineer;
    ((F_MarbleDigitalOutput) this).buGround1.Display.LineerGradient.FirstColor = ((F_MarbleDigitalOutput) this).clrFormBackUpper;
    ((F_MarbleDigitalOutput) this).buGround1.Display.LineerGradient.SecondColor = ((F_MarbleDigitalOutput) this).clrFormBackDown;
    ((F_MarbleDigitalOutput) this).btn_close.Display.BackColor = ((F_MarbleDigitalOutput) this).clrFormCaption;
    ((F_MarbleDigitalOutput) this).btn_close.ButtonDownDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleDigitalOutput) this).clrFormCaption, 0.9);
    ((F_MarbleDigitalOutput) this).btn_close.ButtonOverDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleDigitalOutput) this).clrFormCaption, 0.95);
    ((F_MarbleDigitalOutput) this).lbl_contourtype.Display.BackColor = ((F_MarbleDigitalOutput) this).clrLabel;
    ((F_MarbleDigitalOutput) this).lbl_strategytype.Display.BackColor = ((F_MarbleDigitalOutput) this).clrLabel;
    ((F_MarbleDigitalOutput) this).lbl_tooltype.Display.BackColor = ((F_MarbleDigitalOutput) this).clrLabel;
    ((F_MarbleDigitalOutput) this).btn_contourmenueditor.Display.BackColor = ((F_MarbleDigitalOutput) this).clrButtonDisplay;
    ((F_MarbleDigitalOutput) this).btn_contourmenueditor.ButtonDownDisplay.BackColor = ((F_MarbleDigitalOutput) this).clrButtonDown;
    ((F_MarbleDigitalOutput) this).btn_contourmenueditor.ButtonOverDisplay.BackColor = ((F_MarbleDigitalOutput) this).clrButtonOver;
    ((F_MarbleDigitalOutput) this).btn_contourmenufilelist.Display.BackColor = ((F_MarbleDigitalOutput) this).clrButtonDisplay;
    ((F_MarbleDigitalOutput) this).btn_contourmenufilelist.ButtonDownDisplay.BackColor = ((F_MarbleDigitalOutput) this).clrButtonDown;
    ((F_MarbleDigitalOutput) this).btn_contourmenufilelist.ButtonOverDisplay.BackColor = ((F_MarbleDigitalOutput) this).clrButtonOver;
    ((F_MarbleDigitalOutput) this).btn_contourmenufromfile.Display.BackColor = ((F_MarbleDigitalOutput) this).clrButtonDisplay;
    ((F_MarbleDigitalOutput) this).btn_contourmenufromfile.ButtonDownDisplay.BackColor = ((F_MarbleDigitalOutput) this).clrButtonDown;
    ((F_MarbleDigitalOutput) this).btn_contourmenufromfile.ButtonOverDisplay.BackColor = ((F_MarbleDigitalOutput) this).clrButtonOver;
    ((F_MarbleDigitalOutput) this).btn_strategy.Display.BackColor = ((F_MarbleDigitalOutput) this).clrButtonDisplay;
    ((F_MarbleDigitalOutput) this).btn_strategy.ButtonDownDisplay.BackColor = ((F_MarbleDigitalOutput) this).clrButtonDown;
    ((F_MarbleDigitalOutput) this).btn_strategy.ButtonOverDisplay.BackColor = ((F_MarbleDigitalOutput) this).clrButtonOver;
    ((F_MarbleDigitalOutput) this).btn_tool.Display.BackColor = ((F_MarbleDigitalOutput) this).clrButtonDisplay;
    ((F_MarbleDigitalOutput) this).btn_tool.ButtonDownDisplay.BackColor = ((F_MarbleDigitalOutput) this).clrButtonDown;
    ((F_MarbleDigitalOutput) this).btn_tool.ButtonOverDisplay.BackColor = ((F_MarbleDigitalOutput) this).clrButtonOver;
    ((F_MarbleDigitalOutput) this).btn_toolsettings.Display.BackColor = ((F_MarbleDigitalOutput) this).clrButtonDisplay;
    ((F_MarbleDigitalOutput) this).btn_toolsettings.ButtonDownDisplay.BackColor = ((F_MarbleDigitalOutput) this).clrButtonDown;
    ((F_MarbleDigitalOutput) this).btn_toolsettings.ButtonOverDisplay.BackColor = ((F_MarbleDigitalOutput) this).clrButtonOver;
    ((F_MarbleDigitalOutput) this).btn_camsettings.Display.BackColor = ((F_MarbleDigitalOutput) this).clrButtonDisplay;
    ((F_MarbleDigitalOutput) this).btn_camsettings.ButtonDownDisplay.BackColor = ((F_MarbleDigitalOutput) this).clrButtonDown;
    ((F_MarbleDigitalOutput) this).btn_camsettings.ButtonOverDisplay.BackColor = ((F_MarbleDigitalOutput) this).clrButtonOver;
    ((F_MarbleDigitalInputOutput) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleDigitalInputOutput) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleDigitalOutput) this).lbl_contourtype.Text = $"{buLangTranslate.preDef.Engrave} {buLangTranslate.preDef.Type}";
      ((F_MarbleDigitalOutput) this).lbl_strategytype.Text = $"{buLangTranslate.preDef.Strategy} {buLangTranslate.preDef.Type}";
      ((F_MarbleDigitalOutput) this).lbl_tooltype.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Type}";
      ((F_MarbleDigitalOutput) this).btn_contourmenueditor.Text = buLangTranslate.preDef.Editor;
      ((F_MarbleDigitalOutput) this).btn_contourmenufilelist.Text = buLangTranslate.preDef.FromList;
      ((F_MarbleDigitalOutput) this).btn_contourmenufromfile.Text = buLangTranslate.preDef.FromFile;
      ((F_MarbleDigitalOutput) this).btn_strategy.Text = buLangTranslate.preDef.Strategy;
      ((F_MarbleDigitalOutput) this).btn_tool.Text = buLangTranslate.preDef.Tool;
      ((F_MarbleDigitalOutput) this).buGround1.Text = $"{buLangTranslate.preDef.Engrave} {buLangTranslate.preDef.Menu}";
    }
    catch (Exception ex)
    {
    }
  }

  public void StrategyMillingToImageIndex(int Index)
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
    if (((F_MarbleDigitalInputOutput) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleDigitalInputOutput) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleDigitalInputOutput) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleDigitalInputOutput) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }
}
