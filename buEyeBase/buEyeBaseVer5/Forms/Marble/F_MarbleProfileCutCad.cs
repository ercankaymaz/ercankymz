// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleProfileCutCad
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleProfileCutCad : Form
{
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
  public buTab buTab_IO;
  public static byte f00265D;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  internal IContainer \u0001;
  internal buGround \u0001;
  public buButton btn_close;
  public buButton btn_DO31;
  public buButton btn_DO16;
  public buButton btn_DO30;
  public buButton btn_DO17;
  public buButton btn_DO29;
  public buButton btn_DO18;
  public buButton btn_DO28;

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleDigitalInput) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleDigitalInput) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleDigitalInput) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleDigitalInput) this).\u0001, comparand - value, comparand);
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
    ((F_MarbleDigitalInput) this).lbl_contourtype.Display.BackColor = ((F_MarbleDigitalInput) this).clrLabel;
    ((F_MarbleDigitalInput) this).btn_lshape.Display.BackColor = ((F_MarbleDigitalInput) this).clrButtonDisplay;
    ((F_MarbleDigitalInput) this).btn_lshape.ButtonDownDisplay.BackColor = ((F_MarbleDigitalInput) this).clrButtonDown;
    ((F_MarbleDigitalInput) this).btn_lshape.ButtonOverDisplay.BackColor = ((F_MarbleDigitalInput) this).clrButtonOver;
    ((F_MarbleDigitalInput) this).btn_trapez.Display.BackColor = ((F_MarbleDigitalInput) this).clrButtonDisplay;
    ((F_MarbleDigitalInput) this).btn_trapez.ButtonDownDisplay.BackColor = ((F_MarbleDigitalInput) this).clrButtonDown;
    ((F_MarbleDigitalInput) this).btn_trapez.ButtonOverDisplay.BackColor = ((F_MarbleDigitalInput) this).clrButtonOver;
    ((F_MarbleDigitalInput) this).btn_rectangle.Display.BackColor = ((F_MarbleDigitalInput) this).clrButtonDisplay;
    ((F_MarbleDigitalInput) this).btn_rectangle.ButtonDownDisplay.BackColor = ((F_MarbleDigitalInput) this).clrButtonDown;
    ((F_MarbleDigitalInput) this).btn_rectangle.ButtonOverDisplay.BackColor = ((F_MarbleDigitalInput) this).clrButtonOver;
    ((F_MarbleDigitalInput) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleDigitalInput) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleDigitalInput) this).lbl_contourtype.Text = buLangTranslate.preDef.Countertop;
      ((F_MarbleDigitalInput) this).btn_rectangle.Text = buLangTranslate.preDef.Rectangle;
      ((F_MarbleDigitalInput) this).btn_lshape.Text = "L " + buLangTranslate.preDef.Shape;
      ((F_MarbleDigitalInput) this).btn_trapez.Text = buLangTranslate.preDef.Trapezoid;
      ((F_MarbleDigitalInput) this).buGround1.Text = buLangTranslate.preDef.Countertop;
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
    Control control = obj0 as Control;
    ((F_MarbleDigitalInput) this).PropertiesForm.Result = DialogResult.OK;
    if (control.Name == ((F_MarbleDigitalInput) this).btn_rectangle.Name)
      ((F_MarbleDigitalInput) this).CountertopType = MarbleCountertopMenuTypes.Rectangle;
    if (control.Name == ((F_MarbleDigitalInput) this).btn_lshape.Name)
      ((F_MarbleDigitalInput) this).CountertopType = MarbleCountertopMenuTypes.LShape;
    if (control.Name == ((F_MarbleDigitalInput) this).btn_trapez.Name)
      ((F_MarbleDigitalInput) this).CountertopType = MarbleCountertopMenuTypes.Trapez;
    if (((F_MarbleDigitalInput) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleDigitalInput) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
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
}
