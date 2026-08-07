// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleDigitalInputOutput
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

public class F_MarbleDigitalInputOutput : Form
{
  internal Panel \u0001;
  internal PictureBox \u0001;
  internal TabPage \u0001;
  internal Panel \u0002;
  internal PictureBox \u0002;
  public buButton btn_millinghead_activate;
  public buButton btn_millinghead_zeroposition;
  public buButton btn_millinghead_limitdisable;
  public buButton btn_millinghead_measure;
  public buSpin spn_millinghead_speed;
  public buSpin spn_millinghead_length;
  public buSpin spn_millinghead_diameter;
  public buButton btn_stop;
  public static byte f00249C;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public ToolBase5 ToolMilling;
  public ToolBase5 ToolSaw;
  public ToolBase5 ToolMillingHead;
  public FormProperties PropertiesForm;
  private IContainer \u0001;
  internal buGround \u0001;
  internal buButton \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  public buButton btn_opentools;
  public buButton btn_savetools;
  public buTab buTab_command_settings;
  public TabPage tabPage_saw;
  public TabPage tabPage_mlling;
  internal Panel \u0001;
  public buButton btn_saw_activate;
  public buButton btn_saw_zeroposition;
  public buButton btn_sawgonyele;
  public buButton btn_sawlimitdisable;
  public buButton btn_saw_measure;
  public buSpin spn_sawspeed;
  public buSpin spn_sawthickness;
  public buSpin spn_sawdia;
  public buButton btn_milling_activate;
  public buButton btn_milling_zeroposition;
  public buButton btn_milling_limitdisable;
  public buButton btn_milling_measure;
  public buSpin spn_milling_speed;
  public buSpin spn_milling_length;
  public buSpin spn_milling_diameter;
  internal Panel \u0002;
  internal PictureBox \u0001;
  internal PictureBox \u0002;
  internal TabPage \u0001;
  internal Panel \u0003;
  internal PictureBox \u0003;
  public buButton btn_millinghead_activate;
  public buButton btn_millinghead_zeroposition;
  public buButton btn_millinghead_limitdisable;
  public buButton btn_millinghead_measure;
  public buSpin spn_millinghead_speed;
  public buSpin spn_millinghead_length;
  public buSpin spn_millinghead_diameter;
  public buButton btn_stop;
  public static byte f0024CC;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public ToolBase5 ToolMilling;
  public ToolBase5 ToolSaw;
  public FormProperties PropertiesForm;
  private IContainer \u0001;
  internal buGround \u0001;
  internal buButton \u0001;
  public buButton btn_ok;
  public buButton btn_cancel;
  public buButton btn_opentools;
  public buButton btn_savetools;
  public buTab buTab_command_settings;
  public TabPage tabPage_saw;
  public TabPage tabPage_mlling;
  internal Panel \u0001;
  public buButton btn_saw_activate;
  public buButton btn_saw_zeroposition;
  public buButton btn_sawgonyele;
  public buButton btn_sawlimitdisable;
  public buButton btn_saw_measure;
  public buSpin spn_sawspeed;
  public buSpin spn_sawthickness;
  public buSpin spn_sawdia;
  public buButton btn_milling_activate;
  public buButton btn_milling_zeroposition;
  public buButton btn_milling_limitdisable;
  public buButton btn_milling_measure;
  public buSpin spn_milling_speed;
  public buSpin spn_milling_length;
  public buSpin spn_milling_diameter;
  internal Panel \u0002;
  internal PictureBox \u0001;
  internal PictureBox \u0002;
  public buButton btn_stop;
  public static byte f0024F1;
  public MarbleCountertopTypes CountertopType;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public marbleMenuType MenuType;
  public MarbleItemType ItemType;
  public MarbleContourMenuType ContourType;
  public Color clrLabel;
  public Color clrFormCaption;
  public Color clrFormBackUpper;
  public Color clrFormBackDown;
  public Color clrButtonDisplay;
  public Color clrButtonOver;
  public Color clrButtonDown;
  internal IContainer \u0001;
  public buButton btn_close;
  internal buSeparator \u0001;
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buButton btn_camsettings;
  public buButton btn_toolsettings;
  public buButton btn_strategy;
  public buButton btn_tool;
  public buGround buGround1;
  public buLabel lbl_strategytype;
  public buLabel lbl_tooltype;
  public buButton btn_settings;
  public static byte f00250F;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public MarbleSawCamType SawCamType;
  private IContainer \u0001;
  internal buGround \u0001;
  public buButton btn_close;
  public buCheckBox chk_finish;
  public buCheckBox chk_rough;
  public static byte f00251A;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleImageMenu) this).\u0001.Text = buLangTranslate.preDef.Tools;
      ((F_MarbleImageMenu) this).btn_ok.Text = buLangTranslate.preDef.Ok;
      ((F_MarbleImageMenu) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
      ((F_MarbleToolSawMenu) this).tabPage_saw.Text = buLangTranslate.preDef.Saw;
      this.\u0001.Text = buLangTranslate.preDef.MillingHead;
      ((F_MarbleToolSawMenu) this).btn_sawgonyele.Text = buLangTranslate.preDef.Perpendicular;
      ((F_MarbleToolSawMenu) this).btn_sawlimitdisable.Text = $"{buLangTranslate.preDef.Limit} {buLangTranslate.preDef.Disable}";
      ((F_MarbleToolSawMenu) this).btn_saw_activate.Text = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Activate}";
      ((F_MarbleToolSawMenu) this).btn_saw_measure.Text = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Measure}";
      ((F_MarbleToolSawMenu) this).btn_saw_zeroposition.Text = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Zero}";
      this.btn_millinghead_limitdisable.Text = $"{buLangTranslate.preDef.Limit} {buLangTranslate.preDef.Disable}";
      this.btn_millinghead_activate.Text = $"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Activate}";
      this.btn_millinghead_measure.Text = $"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Measure}";
      this.btn_millinghead_zeroposition.Text = $"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Zero}";
      ((F_MarbleImageMenu) this).btn_savetools.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Save}";
      ((F_MarbleImageMenu) this).btn_opentools.Text = $"{buLangTranslate.preDef.Tool} {buLangTranslate.preDef.Open}";
      ((F_MarbleToolSawMenu) this).spn_sawdia.Caption.Caption = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Diameter}";
      ((F_MarbleToolSawMenu) this).spn_sawthickness.Caption.Caption = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Thickness}";
      ((F_MarbleToolSawMenu) this).spn_sawspeed.Caption.Caption = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Speed}";
      this.spn_millinghead_diameter.Caption.Caption = $"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Diameter}";
      this.spn_millinghead_length.Caption.Caption = $"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Length}";
      this.spn_millinghead_speed.Caption.Caption = $"{buLangTranslate.preDef.MillingHead} {buLangTranslate.preDef.Speed}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleImageMenu) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleImageMenu) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleImageMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleImageMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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
    ((ToolGeometry5) ((F_MarbleImageMenu) this).ToolSaw).Geometry.Diameter = ((F_MarbleToolSawMenu) this).spn_sawdia.Value;
    ((ToolDisplay5) ((ToolGeometry5) ((F_MarbleImageMenu) this).ToolSaw).Geometry).Thickness = ((F_MarbleToolSawMenu) this).spn_sawthickness.Value;
    ((ToolPositions5) ((ToolGeometry5) ((F_MarbleImageMenu) this).ToolSaw).CamData).SpindleSpeed = ((F_MarbleToolSawMenu) this).spn_sawspeed.Value;
    ((ToolGeometry5) ((F_MarbleImageMenu) this).ToolMillingHead).Geometry.Diameter = this.spn_millinghead_diameter.Value;
    ((ToolGeometry5) ((F_MarbleImageMenu) this).ToolMillingHead).Geometry.Length = this.spn_millinghead_length.Value;
    ((ToolPositions5) ((ToolGeometry5) ((F_MarbleImageMenu) this).ToolMillingHead).CamData).SpindleSpeed = this.spn_millinghead_speed.Value;
  }

  public void UpdateSawDiameter(double Diameter)
  {
    if (Diameter <= 0.0)
      return;
    ((F_MarbleToolSawMenu) this).spn_sawdia.Value = Diameter;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    this.Apply();
    ((F_MarbleImageMenu) this).PropertiesForm.Result = DialogResult.OK;
    if (((F_MarbleImageMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleImageMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MarbleImageMenu) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleImageMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleImageMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
