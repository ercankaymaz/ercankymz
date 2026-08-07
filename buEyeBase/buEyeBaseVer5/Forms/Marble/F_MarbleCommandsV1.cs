// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleCommandsV1
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

public class F_MarbleCommandsV1 : Form
{
  public buButton btn_toolmillinheadset;
  public buButton btn_toolmillinset;
  public buButton btn_toolsawset;
  public buLabel lbl_sawdia;
  public buLabel lbl_material;
  internal buSeparator \u0002;
  internal buSeparator \u0003;
  public TreeView tree_operation;
  public buButton btn_OPDown;
  public buButton btn_OPUp;
  public buButton btn_GCodeDown;
  public buButton btn_GCodeUp;
  public Panel pnl_info;
  public buButton btn_mdi;
  public static byte f001A8E;
  private string \u0001;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public buLabel lbl_machine;

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleStartLine) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleStartLine) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleStartLine) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleStartLine) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init()
  {
    ((F_MarbleStartLine) this).PropertiesForm.Inited = false;
    if (((F_MarbleStartLine) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleStartLine) this).PropertiesForm.Height;
    if (((F_MarbleStartLine) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleStartLine) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleStartLine) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleStartLine) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleJobOPListV1) this).buGround1.DisplayTop.BackColor = ((F_MarbleWarnings) this).clrFormCaption;
    ((F_MarbleJobOPListV1) this).buGround1.Display.GradientType = GradientMode.Lineer;
    ((F_MarbleJobOPListV1) this).buGround1.Display.LineerGradient.FirstColor = ((F_MarbleWarnings) this).clrFormBackUpper;
    ((F_MarbleJobOPListV1) this).buGround1.Display.LineerGradient.SecondColor = ((F_MarbleWarnings) this).clrFormBackDown;
    ((F_MarbleWarnings) this).btn_close.Display.BackColor = ((F_MarbleWarnings) this).clrFormCaption;
    ((F_MarbleWarnings) this).btn_close.ButtonDownDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleWarnings) this).clrFormCaption, 0.9);
    ((F_MarbleWarnings) this).btn_close.ButtonOverDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleWarnings) this).clrFormCaption, 0.95);
    ((F_MarbleStartLine) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleStartLine) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleJobOPListV1) this).btn_constantZ3AX.Text = $"3 {buLangTranslate.preDef.Axis} {buLangTranslate.preDef.ConstantZ}";
      ((F_MarbleJobOPListV1) this).btn_paralllelcut3AX.Text = $"3 {buLangTranslate.preDef.Axis} {buLangTranslate.preDef.ParalelCuts}";
      ((F_MarbleJobOPListV1) this).btn_Rough3AX.Text = $"3 {buLangTranslate.preDef.Axis} {buLangTranslate.preDef.Rough}";
      ((F_MarbleJobOPListV1) this).btn_pencil3AX.Text = $"3 {buLangTranslate.preDef.Axis} {buLangTranslate.preDef.Pencil}";
      ((F_MarbleJobOPListV1) this).btn_flatland3AX.Text = $"3 {buLangTranslate.preDef.Axis} {buLangTranslate.preDef.Flatlands}";
      ((F_MarbleJobOPListV1) this).buGround1.Text = $"{buLangTranslate.preDef.Cam} {buLangTranslate.preDef.Strategy}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleStartLine) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleStartLine) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleStartLine) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleStartLine) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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
    // ISSUE: unable to decompile the method.
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleWarnings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleWarnings) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleCommandsV1() => F_MarbleStartLine.Captions = new List<string>();
}
