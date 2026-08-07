// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleCountertopCornerMenu
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

public class F_MarbleCountertopCornerMenu : Form
{
  public buButton btn_rectangle;
  public buButton btn_delete;
  public static byte f001AC6;
  private string \u0001;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  internal IContainer \u0001;
  public buPanel pnl_base;
  public TreeView tree_jobs;
  public buButton btn_opUp;
  public buButton btn_opDown;
  internal ImageList \u0001;
  public buButton btn_opdirchange;
  public buButton btn_opDisable;
  public buButton btn_opAddcam;
  public buButton btn_opDelete;
  public buButton btn_opEdit;
  public buButton btn_opvisible;
  public buButton btn_next;
  public buButton btn_pre;
  public buButton btn_pause;

  static F_MarbleCountertopCornerMenu() => F_MarbleJobOPListV1.Captions = new List<string>();

  public F_MarbleCountertopCornerMenu()
  {
    // ISSUE: unable to decompile the method.
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleCoordinatesV1) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleCoordinatesV1) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleCoordinatesV1) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleCoordinatesV1) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init()
  {
    ((F_MarbleCoordinatesV1) this).PropertiesForm.Inited = false;
    if (((F_MarbleCoordinatesV1) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleCoordinatesV1) this).PropertiesForm.Height;
    if (((F_MarbleCoordinatesV1) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleCoordinatesV1) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleCoordinatesV1) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleCoordinatesV1) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleGCodeViewV1) this).buGround1.DisplayTop.BackColor = ((F_MarbleCoordinatesV1) this).clrFormCaption;
    ((F_MarbleGCodeViewV1) this).buGround1.Display.GradientType = GradientMode.Lineer;
    ((F_MarbleGCodeViewV1) this).buGround1.Display.LineerGradient.FirstColor = ((F_MarbleCoordinatesV1) this).clrFormBackUpper;
    ((F_MarbleGCodeViewV1) this).buGround1.Display.LineerGradient.SecondColor = ((F_MarbleCoordinatesV1) this).clrFormBackDown;
    ((F_MarbleCoordinatesV1) this).btn_close.Display.BackColor = ((F_MarbleCoordinatesV1) this).clrFormCaption;
    ((F_MarbleCoordinatesV1) this).btn_close.ButtonDownDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleCoordinatesV1) this).clrFormCaption, 0.9);
    ((F_MarbleCoordinatesV1) this).btn_close.ButtonOverDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleCoordinatesV1) this).clrFormCaption, 0.95);
    ((F_MarbleCoordinatesV1) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleCoordinatesV1) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleGCodeViewV1) this).btn_constantZ3AX.Text = $"3 {buLangTranslate.preDef.Axis} {buLangTranslate.preDef.ConstantZ}";
      ((F_MarbleGCodeViewV1) this).btn_paralllelcut3AX.Text = $"3 {buLangTranslate.preDef.Axis} {buLangTranslate.preDef.ParalelCuts}";
      ((F_MarbleGCodeViewV1) this).btn_Rough3AX.Text = $"3 {buLangTranslate.preDef.Axis} {buLangTranslate.preDef.Rough}";
      ((F_MarbleGCodeViewV1) this).btn_pencil3AX.Text = $"3 {buLangTranslate.preDef.Axis} {buLangTranslate.preDef.Pencil}";
      ((F_MarbleGCodeViewV1) this).btn_flatland3AX.Text = $"3 {buLangTranslate.preDef.Axis} {buLangTranslate.preDef.Flatlands}";
      ((F_MarbleGCodeViewV1) this).btn_sawveralrough.Text = $"4 {buLangTranslate.preDef.Axis} {buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Vertical} {buLangTranslate.preDef.Rough}";
      ((F_MarbleGCodeViewV1) this).btn_sawhorizontalrough.Text = $"3 {buLangTranslate.preDef.Axis} {buLangTranslate.preDef.Slice} {buLangTranslate.preDef.Horizontal} {buLangTranslate.preDef.Rough}";
      ((F_MarbleGCodeViewV1) this).btn_sawveralfinis.Text = $"4 {buLangTranslate.preDef.Axis} {buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Vertical} {buLangTranslate.preDef.Finish}";
      ((F_MarbleGCodeViewV1) this).btn_sawhorizontalfinish.Text = $"3 {buLangTranslate.preDef.Axis} {buLangTranslate.preDef.Slice} {buLangTranslate.preDef.Horizontal} {buLangTranslate.preDef.Finish}";
      ((F_MarbleGCodeViewV1) this).btn_5axisflatmilling.Text = $"5 {buLangTranslate.preDef.Axis} {buLangTranslate.preDef.FlatMilling}";
      ((F_MarbleGCodeViewV1) this).btn_5axisrotartmilling.Text = $"5 {buLangTranslate.preDef.Axis} {buLangTranslate.preDef.Rotary} {buLangTranslate.preDef.Milling}";
      ((F_MarbleGCodeViewV1) this).btn_pocketbydrill.Text = $"{buLangTranslate.preDef.Drill} {buLangTranslate.preDef.Pocket}";
      ((F_MarbleGCodeViewV1) this).btn_surfaceclear.Text = $"2.5 {buLangTranslate.preDef.Axis} {buLangTranslate.preDef.Surface} {buLangTranslate.preDef.Cleaning}";
      ((F_MarbleGCodeViewV1) this).btn_roughoutside.Text = $"3 {buLangTranslate.preDef.Axis} {buLangTranslate.preDef.Rough} {buLangTranslate.preDef.Offset}";
      ((F_MarbleGCodeViewV1) this).buGround1.Text = $"{buLangTranslate.preDef.Cam} {buLangTranslate.preDef.Strategy}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleCoordinatesV1) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleCoordinatesV1) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleCoordinatesV1) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleCoordinatesV1) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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
