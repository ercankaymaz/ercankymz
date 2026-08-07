// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleEngraveMenu
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

public class F_MarbleEngraveMenu : Form
{
  public buButton btn_DO34;
  public buButton btn_DO44;
  public buButton btn_DO35;
  public buButton btn_DO43;
  public buButton btn_DO36;
  public buButton btn_DO42;
  public buButton btn_DO37;
  public buButton btn_DO41;
  public buButton btn_DO38;
  public buButton btn_DO40;
  public buButton btn_DO39;
  public buPanel pnl_output1;
  public buButton btn_DO15;
  public buButton btn_DO14;
  public buButton btn_DO13;
  public buButton btn_DO12;
  public buButton btn_DO11;
  public buButton btn_DO10;
  public buButton btn_DO9;
  public buButton btn_DO8;
  public buButton btn_DO7;
  public buButton btn_DO6;
  public buButton btn_DO5;
  public buButton btn_DO4;
  public buButton btn_DO3;
  public buButton btn_DO2;
  public buButton btn_DO1;
  public buButton btn_DO0;
  public buButton btn_DO63;
  public buButton btn_DO48;
  public buButton btn_DO62;
  public buButton btn_DO49;
  public buButton btn_DO61;
  public buButton btn_DO50;
  public buButton btn_DO60;

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleDigitalInput) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleDigitalInput) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleDigitalInput) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleDigitalInput) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleDigitalInput) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleEngraveMenu() => F_MarbleDigitalInput.Captions = new List<string>();

  public F_MarbleEngraveMenu()
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
    ((F_MarbleG54Set) this).buGround1.DisplayTop.BackColor = ((F_MarbleDigitalInput) this).clrFormCaption;
    ((F_MarbleG54Set) this).buGround1.Display.GradientType = GradientMode.Lineer;
    ((F_MarbleG54Set) this).buGround1.Display.LineerGradient.FirstColor = ((F_MarbleDigitalInput) this).clrFormBackUpper;
    ((F_MarbleG54Set) this).buGround1.Display.LineerGradient.SecondColor = ((F_MarbleDigitalInput) this).clrFormBackDown;
    ((F_MarbleG54Set) this).btn_close.Display.BackColor = ((F_MarbleDigitalInput) this).clrFormCaption;
    ((F_MarbleG54Set) this).btn_close.ButtonDownDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleDigitalInput) this).clrFormCaption, 0.9);
    ((F_MarbleG54Set) this).btn_close.ButtonOverDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleDigitalInput) this).clrFormCaption, 0.95);
    ((F_MarbleG54Set) this).lbl_phototype.Display.BackColor = ((F_MarbleDigitalInput) this).clrLabel;
    ((F_MarbleG54Set) this).btn_photomenufilelist.Display.BackColor = ((F_MarbleG54Set) this).clrButtonDisplay;
    ((F_MarbleG54Set) this).btn_photomenufilelist.ButtonDownDisplay.BackColor = ((F_MarbleG54Set) this).clrButtonDown;
    ((F_MarbleG54Set) this).btn_photomenufilelist.ButtonOverDisplay.BackColor = ((F_MarbleG54Set) this).clrButtonOver;
    ((F_MarbleG54Set) this).btn_photomenufromfile.Display.BackColor = ((F_MarbleG54Set) this).clrButtonDisplay;
    ((F_MarbleG54Set) this).btn_photomenufromfile.ButtonDownDisplay.BackColor = ((F_MarbleG54Set) this).clrButtonDown;
    ((F_MarbleG54Set) this).btn_photomenufromfile.ButtonOverDisplay.BackColor = ((F_MarbleG54Set) this).clrButtonOver;
    ((F_MarbleDigitalInput) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleDigitalInput) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleG54Set) this).lbl_phototype.Text = $"{buLangTranslate.preDef.Image} {buLangTranslate.preDef.Type}";
      ((F_MarbleG54Set) this).btn_photomenufilelist.Text = buLangTranslate.preDef.FromList;
      ((F_MarbleG54Set) this).btn_photomenufromfile.Text = buLangTranslate.preDef.FromFile;
      ((F_MarbleG54Set) this).chk_addtonesting.Text = $"{buLangTranslate.preDef.Nesting} {buLangTranslate.preDef.Add}";
      ((F_MarbleG54Set) this).chk_editimage.Text = $"{buLangTranslate.preDef.Image} {buLangTranslate.preDef.Edit}";
      ((F_MarbleG54Set) this).buGround1.Text = $"{buLangTranslate.preDef.Image} {buLangTranslate.preDef.Menu}";
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

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    // ISSUE: unable to decompile the method.
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleDigitalInput) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleDigitalInput) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleDigitalInput) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleG54Set) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleG54Set) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public event OkCommandWithFiveDataEventHandler CommandExecute;
}
