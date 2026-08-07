// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleG54Set
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleG54Set : Form
{
  public Color clrButtonDisplay;
  public Color clrButtonOver;
  public Color clrButtonDown;
  private IContainer \u0001;
  public buButton btn_photomenufilelist;
  public buButton btn_photomenufromfile;
  public buButton btn_close;
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buGround buGround1;
  public buLabel lbl_phototype;
  public buCheckBox chk_editimage;
  public buCheckBox chk_addtonesting;
  public static byte f0025C1;
  public Color SpinBaseColor;
  public Color SpinFocusColor;

  public void Init()
  {
    ((F_MarbleDigitalInputOutput) this).PropertiesForm.Inited = false;
    if (((F_MarbleDigitalInputOutput) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleDigitalInputOutput) this).PropertiesForm.Height;
    if (((F_MarbleDigitalInputOutput) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleDigitalInputOutput) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleDigitalInputOutput) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleDigitalInputOutput) this).PropertiesForm.FormPosition;
    ((F_MarbleDigitalInputOutput) this).spn_milling_diameter.Value = ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolMilling).Geometry.Diameter;
    ((F_MarbleDigitalInputOutput) this).spn_milling_length.Value = ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolMilling).Geometry.Length;
    ((F_MarbleDigitalInputOutput) this).spn_milling_speed.Value = ((ToolPositions5) ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolMilling).CamData).SpindleSpeed;
    ((F_MarbleDigitalInputOutput) this).spn_sawdia.Value = ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolSaw).Geometry.Diameter;
    ((F_MarbleDigitalInputOutput) this).spn_sawthickness.Value = ((ToolDisplay5) ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolSaw).Geometry).Thickness;
    ((F_MarbleDigitalInputOutput) this).spn_sawspeed.Value = ((ToolPositions5) ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolSaw).CamData).SpindleSpeed;
    this.LoadLanguage();
    ((F_MarbleDigitalInputOutput) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleDigitalInputOutput) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleDigitalInputOutput) this).\u0001.Text = buLangTranslate.preDef.Tools;
      ((F_MarbleDigitalInputOutput) this).btn_ok.Text = buLangTranslate.preDef.Ok;
      ((F_MarbleDigitalInputOutput) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
      ((F_MarbleDigitalInputOutput) this).tabPage_saw.Text = buLangTranslate.preDef.Saw;
      ((F_MarbleDigitalInputOutput) this).tabPage_mlling.Text = buLangTranslate.preDef.Milling;
      ((F_MarbleDigitalInputOutput) this).btn_sawgonyele.Text = buLangTranslate.preDef.Perpendicular;
      ((F_MarbleDigitalInputOutput) this).btn_sawlimitdisable.Text = $"{buLangTranslate.preDef.Limit} {buLangTranslate.preDef.Disable}";
      ((F_MarbleDigitalInputOutput) this).btn_saw_activate.Text = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Activate}";
      ((F_MarbleDigitalInputOutput) this).btn_saw_measure.Text = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Measure}";
      ((F_MarbleDigitalInputOutput) this).btn_saw_zeroposition.Text = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Zero}";
      ((F_MarbleDigitalInputOutput) this).btn_milling_limitdisable.Text = $"{buLangTranslate.preDef.Limit} {buLangTranslate.preDef.Disable}";
      ((F_MarbleDigitalInputOutput) this).btn_milling_activate.Text = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Activate}";
      ((F_MarbleDigitalInputOutput) this).btn_milling_measure.Text = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Measure}";
      ((F_MarbleDigitalInputOutput) this).btn_milling_zeroposition.Text = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Zero}";
      ((F_MarbleDigitalInputOutput) this).btn_savetools.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Save}";
      ((F_MarbleDigitalInputOutput) this).btn_opentools.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Open}";
      ((F_MarbleDigitalInputOutput) this).spn_sawdia.Caption.Caption = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Diameter}";
      ((F_MarbleDigitalInputOutput) this).spn_sawthickness.Caption.Caption = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Thickness}";
      ((F_MarbleDigitalInputOutput) this).spn_sawspeed.Caption.Caption = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Speed}";
      ((F_MarbleDigitalInputOutput) this).spn_milling_diameter.Caption.Caption = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Diameter}";
      ((F_MarbleDigitalInputOutput) this).spn_milling_length.Caption.Caption = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Length}";
      ((F_MarbleDigitalInputOutput) this).spn_milling_speed.Caption.Caption = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Speed}";
    }
    catch (Exception ex)
    {
    }
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

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      buSpin buSpin = obj0 as buSpin;
      if (!AppBool.TouchPad)
        return;
      F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
      fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
      fKeyPadNumV1.Caption = buSpin.Caption.Caption;
      fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
      if (!buFile5.IsNumeric(fKeyPadNumV1.Value))
        return;
      buSpin.Value = double.Parse(fKeyPadNumV1.Value);
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  public void Apply()
  {
    ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolMilling).Geometry.Diameter = ((F_MarbleDigitalInputOutput) this).spn_milling_diameter.Value;
    ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolMilling).Geometry.Length = ((F_MarbleDigitalInputOutput) this).spn_milling_length.Value;
    ((ToolPositions5) ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolMilling).CamData).SpindleSpeed = ((F_MarbleDigitalInputOutput) this).spn_milling_speed.Value;
    ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolSaw).Geometry.Diameter = ((F_MarbleDigitalInputOutput) this).spn_sawdia.Value;
    ((ToolDisplay5) ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolSaw).Geometry).Thickness = ((F_MarbleDigitalInputOutput) this).spn_sawthickness.Value;
    ((ToolPositions5) ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolSaw).CamData).SpindleSpeed = ((F_MarbleDigitalInputOutput) this).spn_sawspeed.Value;
  }

  public void UpdateSawDiameter(double Diameter)
  {
    if (Diameter <= 0.0)
      return;
    ((F_MarbleDigitalInputOutput) this).spn_sawdia.Value = Diameter;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    this.Apply();
    ((F_MarbleDigitalInputOutput) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_MarbleDigitalInputOutput) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleDigitalInputOutput) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleDigitalInputOutput) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleDigitalInputOutput) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleDigitalInputOutput) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleDigitalInputOutput) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleDigitalInputOutput) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleG54Set() => F_MarbleDigitalInputOutput.Captions = new List<string>();

  public F_MarbleG54Set()
  {
    // ISSUE: unable to decompile the method.
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandExecute(OkCommandWithFiveDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithFiveDataEventHandler dataEventHandler = ((F_MarbleDigitalInputOutput) this).\u0001;
    OkCommandWithFiveDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithFiveDataEventHandler>(ref ((F_MarbleDigitalInputOutput) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public event OkCommandWithTwoDataEventHandler G54Command;
}
