// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Machine.F_MachineGCodeCfg
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Forms.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Machine;

public class F_MachineGCodeCfg : Form
{
  public buCheckBox chk_contouroffsetinside;
  internal buLabel \u000F;
  public buSpin spn_roughtoolpersentage;
  internal buLabel \u0010;
  internal buLabel \u0011;
  public buCheckBox chk_spiral;
  public buCheckBox chk_zigzag;
  public buCheckBox chk_oneway;
  public buCheckBox chk_level;
  public buCheckBox chk_region;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public camParameters5 varRoughSettings;
  public camParameters5 varParalelCutSettings;
  public camParameters5 varContantZSettings;
  public camParameters5 varFlatlandSettings;
  public camParameters5 varPencilSettings;
  public camParameters5 varProjectionRoughSettings;
  public camParameters5 varProjectionFinishSettings;
  public camParameters5 varGeoDesicSettings;
  public MarbleCamType CamType;
  internal IContainer \u0001;
  internal ImageList \u0001;
  internal buGround \u0001;
  public buSpin spn_roughcuttingvel;
  public buSpin spn_roughplungevel;

  public F_MachineGCodeCfg()
  {
    ((F_MarbleEngraveCamSetting) this).SpinBaseColor = Color.LightGreen;
    ((F_MarbleEngraveCamSetting) this).SpinFocusColor = Color.MistyRose;
    ((F_MarbleEngraveCamSetting) this).ToolMilling = (ToolBase5) new ToolGeometry5();
    ((F_MarbleEngraveCamSetting) this).ToolSaw = (ToolBase5) new ToolGeometry5();
    ((F_MarbleEngraveCamSetting) this).Tools = (ToolBase5[]) null;
    ((F_MarbleEngraveCamSetting) this).PropertiesForm = new FormProperties();
    ((F_MarbleEngraveCamSetting) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleTools) this);
  }

  public void Init()
  {
    ((F_MarbleEngraveCamSetting) this).PropertiesForm.Inited = false;
    if (((F_MarbleEngraveCamSetting) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleEngraveCamSetting) this).PropertiesForm.Height;
    if (((F_MarbleEngraveCamSetting) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleEngraveCamSetting) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleEngraveCamSetting) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleEngraveCamSetting) this).PropertiesForm.FormPosition;
    ((F_MarbleEngraveCamSetting) this).spn_milling_diameter.Value = ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).ToolMilling).Geometry.Diameter;
    ((F_MarbleEngraveCamSetting) this).spn_milling_length.Value = ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).ToolMilling).Geometry.Length;
    ((F_MarbleEngraveCamSetting) this).spn_milling_speed.Value = ((ToolPositions5) ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).ToolMilling).CamData).SpindleSpeed;
    ((F_MarbleEngraveCamSetting) this).spn_sawdia.Value = ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).ToolSaw).Geometry.Diameter;
    ((F_MarbleEngraveCamSetting) this).spn_sawthickness.Value = ((ToolDisplay5) ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).ToolSaw).Geometry).Thickness;
    ((F_MarbleEngraveCamSetting) this).spn_sawspeed.Value = ((ToolPositions5) ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).ToolSaw).CamData).SpindleSpeed;
    ((F_MarbleContourAdvancedSettings) this).spn_toollen1.Value = ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[1]).Geometry.Length;
    ((F_MarbleContourAdvancedSettings) this).spn_toollen2.Value = ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[2]).Geometry.Length;
    ((F_MarbleContourAdvancedSettings) this).spn_toollen3.Value = ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[3]).Geometry.Length;
    ((F_MarbleEngraveCamSetting) this).spn_toollen4.Value = ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[4]).Geometry.Length;
    ((F_MarbleEngraveCamSetting) this).spn_toollen5.Value = ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[5]).Geometry.Length;
    if (((F_MarbleEngraveCamSetting) this).Tools.Length >= 6)
      ((F_MarbleEngraveCamSetting) this).spn_toollen6.Value = ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[6]).Geometry.Length;
    ((F_MarbleContourAdvancedSettings) this).spn_tooldia1.Value = ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[1]).Geometry.Diameter;
    ((F_MarbleContourAdvancedSettings) this).spn_tooldia2.Value = ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[2]).Geometry.Diameter;
    ((F_MarbleEngraveCamSetting) this).spn_tooldia3.Value = ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[3]).Geometry.Diameter;
    ((F_MarbleEngraveCamSetting) this).spn_tooldia4.Value = ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[4]).Geometry.Diameter;
    ((F_MarbleEngraveCamSetting) this).spn_tooldia5.Value = ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[5]).Geometry.Diameter;
    if (((F_MarbleEngraveCamSetting) this).Tools.Length >= 6)
      ((F_MarbleContourAdvancedSettings) this).spn_tooldia1.Value = ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[1]).Geometry.Diameter;
    ((F_MarbleContourAdvancedSettings) this).spn_toolspeed1.Value = ((ToolPositions5) ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[1]).CamData).SpindleSpeed;
    ((F_MarbleContourAdvancedSettings) this).spn_toolspeed2.Value = ((ToolPositions5) ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[2]).CamData).SpindleSpeed;
    ((F_MarbleEngraveCamSetting) this).spn_toolspeed3.Value = ((ToolPositions5) ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[3]).CamData).SpindleSpeed;
    ((F_MarbleEngraveCamSetting) this).spn_toolspeed4.Value = ((ToolPositions5) ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[4]).CamData).SpindleSpeed;
    ((F_MarbleEngraveCamSetting) this).spn_toolspeed5.Value = ((ToolPositions5) ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[5]).CamData).SpindleSpeed;
    if (((F_MarbleEngraveCamSetting) this).Tools.Length >= 6)
      ((F_MarbleEngraveCamSetting) this).spn_toolspeed6.Value = ((ToolPositions5) ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[6]).CamData).SpindleSpeed;
    this.LoadLanguage();
    ((F_MarbleEngraveCamSetting) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleEngraveCamSetting) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleEngraveCamSetting) this).\u0001.Text = buLangTranslate.preDef.Tools;
      ((F_MarbleEngraveCamSetting) this).btn_ok.Text = buLangTranslate.preDef.Ok;
      ((F_MarbleEngraveCamSetting) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
      ((F_MarbleEngraveCamSetting) this).tabPage_saw.Text = buLangTranslate.preDef.Saw;
      ((F_MarbleEngraveCamSetting) this).tabPage_mlling.Text = buLangTranslate.preDef.Milling;
      ((F_MarbleEngraveCamSetting) this).btn_sawgonyele.Text = buLangTranslate.preDef.Perpendicular;
      ((F_MarbleEngraveCamSetting) this).btn_sawlimitdisable.Text = $"{buLangTranslate.preDef.Limit} {buLangTranslate.preDef.Disable}";
      ((F_MarbleEngraveCamSetting) this).btn_saw_activate.Text = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Activate}";
      ((F_MarbleEngraveCamSetting) this).btn_saw_measure.Text = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Measure}";
      ((F_MarbleEngraveCamSetting) this).btn_saw_zeroposition.Text = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Zero}";
      ((F_MarbleEngraveCamSetting) this).btn_milling_limitdisable.Text = $"{buLangTranslate.preDef.Limit} {buLangTranslate.preDef.Disable}";
      ((F_MarbleEngraveCamSetting) this).btn_milling_activate.Text = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Activate}";
      ((F_MarbleEngraveCamSetting) this).btn_milling_measure.Text = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Measure}";
      ((F_MarbleEngraveCamSetting) this).btn_milling_zeroposition.Text = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Zero}";
      ((F_MarbleEngraveCamSetting) this).btn_savetools.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Save}";
      ((F_MarbleEngraveCamSetting) this).btn_opentools.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Open}";
      ((F_MarbleEngraveCamSetting) this).spn_sawdia.Caption.Caption = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Diameter}";
      ((F_MarbleEngraveCamSetting) this).spn_sawthickness.Caption.Caption = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Thickness}";
      ((F_MarbleEngraveCamSetting) this).spn_sawspeed.Caption.Caption = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Speed}";
      ((F_MarbleEngraveCamSetting) this).spn_milling_diameter.Caption.Caption = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Diameter}";
      ((F_MarbleEngraveCamSetting) this).spn_milling_length.Caption.Caption = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Length}";
      ((F_MarbleEngraveCamSetting) this).spn_milling_speed.Caption.Caption = $"{buLangTranslate.preDef.Milling} {buLangTranslate.preDef.Speed}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleEngraveCamSetting) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleEngraveCamSetting) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleEngraveCamSetting) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleEngraveCamSetting) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
    ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).ToolMilling).Geometry.Diameter = ((F_MarbleEngraveCamSetting) this).spn_milling_diameter.Value;
    ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).ToolMilling).Geometry.Length = ((F_MarbleEngraveCamSetting) this).spn_milling_length.Value;
    ((ToolPositions5) ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).ToolMilling).CamData).SpindleSpeed = ((F_MarbleEngraveCamSetting) this).spn_milling_speed.Value;
    ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).ToolSaw).Geometry.Diameter = ((F_MarbleEngraveCamSetting) this).spn_sawdia.Value;
    ((ToolDisplay5) ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).ToolSaw).Geometry).Thickness = ((F_MarbleEngraveCamSetting) this).spn_sawthickness.Value;
    ((ToolPositions5) ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).ToolSaw).CamData).SpindleSpeed = ((F_MarbleEngraveCamSetting) this).spn_sawspeed.Value;
    ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[1]).Geometry.Length = ((F_MarbleContourAdvancedSettings) this).spn_toollen1.Value;
    ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[2]).Geometry.Length = ((F_MarbleContourAdvancedSettings) this).spn_toollen2.Value;
    ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[3]).Geometry.Length = ((F_MarbleContourAdvancedSettings) this).spn_toollen3.Value;
    ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[4]).Geometry.Length = ((F_MarbleEngraveCamSetting) this).spn_toollen4.Value;
    ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[5]).Geometry.Length = ((F_MarbleEngraveCamSetting) this).spn_toollen5.Value;
    if (((F_MarbleEngraveCamSetting) this).Tools.Length >= 6)
      ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[6]).Geometry.Length = ((F_MarbleEngraveCamSetting) this).spn_toollen6.Value;
    ((ToolPositions5) ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[1]).CamData).SpindleSpeed = ((F_MarbleContourAdvancedSettings) this).spn_toolspeed1.Value;
    ((ToolPositions5) ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[2]).CamData).SpindleSpeed = ((F_MarbleContourAdvancedSettings) this).spn_toolspeed2.Value;
    ((ToolPositions5) ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[3]).CamData).SpindleSpeed = ((F_MarbleEngraveCamSetting) this).spn_toolspeed3.Value;
    ((ToolPositions5) ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[4]).CamData).SpindleSpeed = ((F_MarbleEngraveCamSetting) this).spn_toolspeed4.Value;
    ((ToolPositions5) ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[5]).CamData).SpindleSpeed = ((F_MarbleEngraveCamSetting) this).spn_toolspeed5.Value;
    if (((F_MarbleEngraveCamSetting) this).Tools.Length < 6)
      return;
    ((ToolPositions5) ((ToolGeometry5) ((F_MarbleEngraveCamSetting) this).Tools[1]).CamData).SpindleSpeed = ((F_MarbleEngraveCamSetting) this).spn_toolspeed6.Value;
  }

  public void UpdateSawDiameter(double Diameter)
  {
    if (Diameter <= 0.0)
      return;
    ((F_MarbleEngraveCamSetting) this).spn_sawdia.Value = Diameter;
  }

  public void UpdateMagazineLength(int activetool, double Length)
  {
    if (!(activetool >= 1 & activetool <= 6) || Length <= 0.0)
      return;
    if (activetool == 1)
      ((F_MarbleContourAdvancedSettings) this).spn_toollen1.Value = Length;
    if (activetool == 2)
      ((F_MarbleContourAdvancedSettings) this).spn_toollen2.Value = Length;
    if (activetool == 3)
      ((F_MarbleContourAdvancedSettings) this).spn_toollen3.Value = Length;
    if (activetool == 4)
      ((F_MarbleEngraveCamSetting) this).spn_toollen4.Value = Length;
    if (activetool == 5)
      ((F_MarbleEngraveCamSetting) this).spn_toollen5.Value = Length;
    if (activetool != 6)
      return;
    ((F_MarbleEngraveCamSetting) this).spn_toollen6.Value = Length;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    this.Apply();
    ((F_MarbleEngraveCamSetting) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_MarbleEngraveCamSetting) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleEngraveCamSetting) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
