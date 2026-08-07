// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_Marble3DCamStrategyMenu
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_Marble3DCamStrategyMenu : Form
{
  public buButton btn_DO19;
  public buButton btn_DO27;
  public buButton btn_DO20;
  public buButton btn_DO26;
  public buButton btn_DO21;
  public buButton btn_DO25;
  public buButton btn_DO22;
  public buButton btn_DO24;
  public buButton btn_DO23;
  public buButton btn_DO47;
  public buButton btn_DO32;
  public buButton btn_DO46;
  public buButton btn_DO33;
  public buButton btn_DO45;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleDigitalInput) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleDigitalInput) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_Marble3DCamStrategyMenu() => F_MarbleDigitalInput.Captions = new List<string>();

  public F_Marble3DCamStrategyMenu()
  {
    // ISSUE: unable to decompile the method.
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandExecute(OkCommandWithThreeDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithThreeDataEventHandler dataEventHandler = ((F_MarbleDigitalInput) this).\u0001;
    OkCommandWithThreeDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithThreeDataEventHandler>(ref ((F_MarbleDigitalInput) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandExecute(OkCommandWithThreeDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithThreeDataEventHandler dataEventHandler = ((F_MarbleDigitalInput) this).\u0001;
    OkCommandWithThreeDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithThreeDataEventHandler>(ref ((F_MarbleDigitalInput) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init()
  {
    ((F_MarbleDigitalInput) this).PropertiesForm.Inited = false;
    if (((F_MarbleDigitalInput) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleDigitalInput) this).PropertiesForm.Height;
    if (((F_MarbleDigitalInput) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleDigitalInput) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleDigitalInput) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleDigitalInput) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleDigitalInput) this).buGround1.DisplayTop.BackColor = ((F_MarbleDigitalInput) this).clrFormCaption;
    ((F_MarbleDigitalInput) this).buGround1.Display.GradientType = GradientMode.Lineer;
    ((F_MarbleDigitalInput) this).buGround1.Display.LineerGradient.FirstColor = ((F_MarbleDigitalInput) this).clrFormBackUpper;
    ((F_MarbleDigitalInput) this).buGround1.Display.LineerGradient.SecondColor = ((F_MarbleDigitalInput) this).clrFormBackDown;
    ((F_MarbleDigitalInput) this).btn_close.Display.BackColor = ((F_MarbleDigitalInput) this).clrFormCaption;
    ((F_MarbleDigitalInput) this).btn_close.ButtonDownDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleDigitalInput) this).clrFormCaption, 0.9);
    ((F_MarbleDigitalInput) this).btn_close.ButtonOverDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleDigitalInput) this).clrFormCaption, 0.95);
    ((F_MarbleDigitalInput) this).lbl_sheettype.Display.BackColor = ((F_MarbleDigitalInput) this).clrLabel;
    ((F_MarbleDigitalInput) this).btn_filelist.Display.BackColor = ((F_MarbleDigitalInput) this).clrButtonDisplay;
    ((F_MarbleDigitalInput) this).btn_filelist.ButtonDownDisplay.BackColor = ((F_MarbleDigitalInput) this).clrButtonDown;
    ((F_MarbleDigitalInput) this).btn_filelist.ButtonOverDisplay.BackColor = ((F_MarbleDigitalInput) this).clrButtonOver;
    ((F_MarbleDigitalInput) this).btn_fromfile.Display.BackColor = ((F_MarbleDigitalInput) this).clrButtonDisplay;
    ((F_MarbleDigitalInput) this).btn_fromfile.ButtonDownDisplay.BackColor = ((F_MarbleDigitalInput) this).clrButtonDown;
    ((F_MarbleDigitalInput) this).btn_fromfile.ButtonOverDisplay.BackColor = ((F_MarbleDigitalInput) this).clrButtonOver;
    ((F_MarbleDigitalInput) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleDigitalInput) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleDigitalInput) this).lbl_sheettype.Text = $"{buLangTranslate.preDef.Sheet} {buLangTranslate.preDef.Type}";
      ((F_MarbleDigitalInput) this).btn_filelist.Text = buLangTranslate.preDef.FromList;
      ((F_MarbleDigitalInput) this).btn_fromfile.Text = buLangTranslate.preDef.FromFile;
      ((F_MarbleDigitalInput) this).btn_editor.Text = buLangTranslate.preDef.Editor;
      ((F_MarbleDigitalInput) this).btn_fromdata.Text = buLangTranslate.preDef.Data;
      ((F_MarbleDigitalInput) this).buGround1.Text = $"{buLangTranslate.preDef.Sheet} {buLangTranslate.preDef.Menu}";
      ((F_MarbleDigitalInput) this).chk_addtonesting.Text = $"{buLangTranslate.preDef.Nesting} {buLangTranslate.preDef.Add}";
      ((F_MarbleDigitalInput) this).chk_editimage.Text = $"{buLangTranslate.preDef.Image} {buLangTranslate.preDef.Edit}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleDigitalInput) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleDigitalInput) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleDigitalInput) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleDigitalInput) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }
}
