// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleDigitalOutput
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleDigitalOutput : Form
{
  public MarbleEngraveMenuType EngraveType;
  public MarbleItemType ItemType;
  public marbleMenuType MenuType;
  public Color clrLabel;
  public Color clrFormCaption;
  public Color clrFormBackUpper;
  public Color clrFormBackDown;
  public Color clrButtonDisplay;
  public Color clrButtonOver;
  public Color clrButtonDown;
  internal IContainer \u0001;
  public buButton btn_contourmenueditor;
  public buButton btn_contourmenufilelist;
  public buButton btn_contourmenufromfile;
  public buButton btn_close;
  internal ImageList \u0001;
  internal ImageList \u0002;
  internal buSeparator \u0001;
  internal buSeparator \u0002;
  public buButton btn_strategy;
  public buButton btn_tool;
  public buButton btn_camsettings;
  public buButton btn_toolsettings;
  public buGround buGround1;
  public buLabel lbl_strategytype;
  public buLabel lbl_tooltype;
  public buLabel lbl_contourtype;
  public static byte f00253B;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public MarbleItemType CommandType;
  public Color clrLabel;
  public Color clrFormCaption;
  public Color clrFormBackUpper;
  public Color clrFormBackDown;
  public Color clrButtonDisplay;
  public Color clrButtonOver;
  public Color clrButtonDown;
  internal IContainer \u0001;
  public buButton btn_vertical;
  public buButton btn_close;
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buGround buGround1;
  public buButton btn_drill;
  public buButton btn_air;
  public buButton btn_verticallathe;
  public buButton btn_horizontallathe;
  public buButton btn_columns;
  public buButton btn_sweep;
  public buButton btn_engrave;
  public buButton btn_cleaning;
  public buButton btn_text;
  public buButton btn_shapes;
  public buButton btn_arcprofile;
  public buButton btn_profile;
  public buButton btn_library;
  public buButton btn_contour;
  public buButton btn_single;
  public buButton btn_horizontal;
  public buButton btn_editor;
  public buButton btn_gcode;
  public buButton btn_countertop;
  public buButton btn_slices;
  public buButton btn_sawveralmilling;
  public buButton btn_sawhorizontalmilling;
  public buButton btn_easydraw;
  public buButton btn_pocketbydrill;
  public buButton btn_5axisrotartmilling;
  public buButton btn_5axisflatmilling;
  public buButton btn_horver;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_MarbleImageMenu) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleImageMenu) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleDigitalOutput() => F_MarbleImageMenu.Captions = new List<string>();

  public F_MarbleDigitalOutput()
  {
    ((F_MarbleDigitalInputOutput) this).SpinBaseColor = Color.LightGreen;
    ((F_MarbleDigitalInputOutput) this).SpinFocusColor = Color.MistyRose;
    ((F_MarbleDigitalInputOutput) this).ToolMilling = (ToolBase5) new ToolGeometry5();
    ((F_MarbleDigitalInputOutput) this).ToolSaw = (ToolBase5) new ToolGeometry5();
    ((F_MarbleDigitalInputOutput) this).ToolMillingHead = (ToolBase5) new ToolGeometry5();
    ((F_MarbleDigitalInputOutput) this).PropertiesForm = new FormProperties();
    ((F_MarbleDigitalInputOutput) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleToolSawMillingHeadMilling) this);
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
    ((F_MarbleDigitalInputOutput) this).spn_milling_diameter.Value = ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolMilling).Geometry.Diameter;
    ((F_MarbleDigitalInputOutput) this).spn_milling_length.Value = ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolMilling).Geometry.Length;
    ((F_MarbleDigitalInputOutput) this).spn_milling_speed.Value = ((ToolPositions5) ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolMilling).CamData).SpindleSpeed;
    ((F_MarbleDigitalInputOutput) this).spn_sawdia.Value = ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolSaw).Geometry.Diameter;
    ((F_MarbleDigitalInputOutput) this).spn_sawthickness.Value = ((ToolDisplay5) ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolSaw).Geometry).Thickness;
    ((F_MarbleDigitalInputOutput) this).spn_sawspeed.Value = ((ToolPositions5) ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolSaw).CamData).SpindleSpeed;
    ((F_MarbleDigitalInputOutput) this).spn_millinghead_diameter.Value = ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolMillingHead).Geometry.Diameter;
    ((F_MarbleDigitalInputOutput) this).spn_millinghead_length.Value = ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolMillingHead).Geometry.Length;
    ((F_MarbleDigitalInputOutput) this).spn_millinghead_speed.Value = ((ToolPositions5) ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolMillingHead).CamData).SpindleSpeed;
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
      ((F_MarbleDigitalInputOutput) this).\u0001.Text = buLangTranslate.preDef.MillingHead;
      ((F_MarbleDigitalInputOutput) this).btn_sawgonyele.Text = buLangTranslate.preDef.Perpendicular;
      ((F_MarbleDigitalInputOutput) this).btn_sawlimitdisable.Text = $"{buLangTranslate.preDef.Limit} {buLangTranslate.preDef.Disable}";
      ((F_MarbleDigitalInputOutput) this).btn_saw_activate.Text = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Activate}";
      ((F_MarbleDigitalInputOutput) this).btn_saw_measure.Text = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Measure}";
      ((F_MarbleDigitalInputOutput) this).btn_saw_zeroposition.Text = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Zero}";
      ((F_MarbleDigitalInputOutput) this).btn_milling_limitdisable.Text = $"{buLangTranslate.preDef.Limit} {buLangTranslate.preDef.Disable}";
      ((F_MarbleDigitalInputOutput) this).btn_milling_activate.Text = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Activate}";
      ((F_MarbleDigitalInputOutput) this).btn_milling_measure.Text = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Measure}";
      ((F_MarbleDigitalInputOutput) this).btn_milling_zeroposition.Text = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Zero}";
      ((F_MarbleDigitalInputOutput) this).btn_millinghead_limitdisable.Text = $"{buLangTranslate.preDef.Limit} {buLangTranslate.preDef.Disable}";
      ((F_MarbleDigitalInputOutput) this).btn_millinghead_activate.Text = $"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Activate}";
      ((F_MarbleDigitalInputOutput) this).btn_millinghead_measure.Text = $"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Measure}";
      ((F_MarbleDigitalInputOutput) this).btn_millinghead_zeroposition.Text = $"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Zero}";
      ((F_MarbleDigitalInputOutput) this).btn_savetools.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Save}";
      ((F_MarbleDigitalInputOutput) this).btn_opentools.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Open}";
      ((F_MarbleDigitalInputOutput) this).spn_sawdia.Caption.Caption = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Diameter}";
      ((F_MarbleDigitalInputOutput) this).spn_sawthickness.Caption.Caption = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Thickness}";
      ((F_MarbleDigitalInputOutput) this).spn_sawspeed.Caption.Caption = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Speed}";
      ((F_MarbleDigitalInputOutput) this).spn_milling_diameter.Caption.Caption = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Diameter}";
      ((F_MarbleDigitalInputOutput) this).spn_milling_length.Caption.Caption = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Length}";
      ((F_MarbleDigitalInputOutput) this).spn_milling_speed.Caption.Caption = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Speed}";
      ((F_MarbleDigitalInputOutput) this).spn_millinghead_diameter.Caption.Caption = $"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Diameter}";
      ((F_MarbleDigitalInputOutput) this).spn_millinghead_length.Caption.Caption = $"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Length}";
      ((F_MarbleDigitalInputOutput) this).spn_millinghead_speed.Caption.Caption = $"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Speed}";
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
}
