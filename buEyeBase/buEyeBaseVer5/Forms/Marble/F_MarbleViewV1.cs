// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleViewV1
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

public class F_MarbleViewV1 : Form
{
  public buLabel lbl_part;
  public buLabel lbl_c;
  public buLabel lbl_machinec;
  public buLabel lbl_partc;
  public buLabel lbl_a;
  public buLabel lbl_machinea;
  public buLabel lbl_parta;
  public buLabel lbl_z;
  public buLabel lbl_machinez;
  public buLabel lbl_partz;
  public buLabel lbl_y;
  public buLabel lbl_machiney;
  public buLabel lbl_party;
  public buLabel lbl_x;
  public buLabel lbl_machinex;
  public buLabel lbl_partx;
  public buPanel pnl_base;
  public buLabel lbl_toolname;
  public buLabel lbl_spindlespeed;
  public buTrack track_spidle;
  public buLabel lbl_operationspeed;
  public buTrack track_operationspeed;
  public buTrack track_quickspeed;
  public buLabel lbl_quickspeed;
  public buSeparator buSeparator1;
  public buSpin spn_toolno;
  public PictureBox pic_tool;
  public buSpin spn_toolthickness;
  public buSpin spn_tooldiameter;
  public buButton btn_pause;
  public buButton btn_reset;
  public buButton btn_start;
  public buProgressBar progress_spindleCurrent;
  public ImageList IC48Tool;
  public static byte f001AB7;
  private string \u0001;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buButton btn_polyline;
  public buGround ground_base;
  public buButton btn_close;
  public buButton btn_arc;
  public buButton btn_circle;
  public buButton btn_ok;

  public F_MarbleViewV1()
  {
    // ISSUE: unable to decompile the method.
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleJobOPListV1) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleJobOPListV1) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleJobOPListV1) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleJobOPListV1) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public void Init()
  {
    ((F_MarbleJobOPListV1) this).PropertiesForm.Inited = false;
    if (((F_MarbleJobOPListV1) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleJobOPListV1) this).PropertiesForm.Height;
    if (((F_MarbleJobOPListV1) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleJobOPListV1) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleJobOPListV1) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleJobOPListV1) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleJobOPListV1) this).buGround1.DisplayTop.BackColor = ((F_MarbleJobOPListV1) this).clrFormCaption;
    ((F_MarbleJobOPListV1) this).buGround1.Display.GradientType = GradientMode.Lineer;
    ((F_MarbleJobOPListV1) this).buGround1.Display.LineerGradient.FirstColor = ((F_MarbleJobOPListV1) this).clrFormBackUpper;
    ((F_MarbleJobOPListV1) this).buGround1.Display.LineerGradient.SecondColor = ((F_MarbleJobOPListV1) this).clrFormBackDown;
    ((F_MarbleJobOPListV1) this).btn_close.Display.BackColor = ((F_MarbleJobOPListV1) this).clrFormCaption;
    ((F_MarbleJobOPListV1) this).btn_close.ButtonDownDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleJobOPListV1) this).clrFormCaption, 0.9);
    ((F_MarbleJobOPListV1) this).btn_close.ButtonOverDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleJobOPListV1) this).clrFormCaption, 0.95);
    ((F_MarbleJobOPListV1) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleJobOPListV1) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleCoordinatesV1) this).btn_constantZ3AX.Text = $"3 {buLangTranslate.preDef.Axis} {buLangTranslate.preDef.ConstantZ}";
      ((F_MarbleCoordinatesV1) this).btn_paralllelcut3AX.Text = $"3 {buLangTranslate.preDef.Axis} {buLangTranslate.preDef.ParalelCuts}";
      ((F_MarbleCoordinatesV1) this).btn_Rough3AX.Text = $"3 {buLangTranslate.preDef.Axis} {buLangTranslate.preDef.Rough}";
      ((F_MarbleCoordinatesV1) this).btn_profilefinish.Text = $"{buLangTranslate.preDef.Profile} {buLangTranslate.preDef.Finish}";
      ((F_MarbleCoordinatesV1) this).btn_profilerough.Text = $"{buLangTranslate.preDef.Profile} {buLangTranslate.preDef.Rough}";
      ((F_MarbleCoordinatesV1) this).btn_surfaceclear.Text = $"{buLangTranslate.preDef.Surface} {buLangTranslate.preDef.Cleaning}";
      ((F_MarbleCoordinatesV1) this).btn_profileroughoutside.Text = $"{buLangTranslate.preDef.Rough} {buLangTranslate.preDef.Outside}";
      ((F_MarbleCoordinatesV1) this).btn_profiloffset.Text = $"{buLangTranslate.preDef.Profile} {buLangTranslate.preDef.Offset}";
      ((F_MarbleJobOPListV1) this).buGround1.Text = $"{buLangTranslate.preDef.Cam} {buLangTranslate.preDef.Strategy}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleJobOPListV1) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleJobOPListV1) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleJobOPListV1) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleJobOPListV1) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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
    if ((!disposing ? 0 : (((F_MarbleJobOPListV1) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleJobOPListV1) this).\u0001.Dispose();
    base.Dispose(disposing);
  }
}
