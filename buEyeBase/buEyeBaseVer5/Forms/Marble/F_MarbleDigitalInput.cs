// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleDigitalInput
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleDigitalInput : Form
{
  public buButton btn_cutremainmaterial;
  public static byte f00256B;
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
  public static byte f002576;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public MarbleCountertopMenuTypes CountertopType;
  public marbleMenuType MenuType;
  public Color clrLabel;
  public Color clrFormCaption;
  public Color clrFormBackUpper;
  public Color clrFormBackDown;
  public Color clrButtonDisplay;
  public Color clrButtonOver;
  public Color clrButtonDown;
  internal IContainer \u0001;
  public buButton btn_rectangle;
  public buButton btn_lshape;
  public buButton btn_trapez;
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buGround buGround1;
  public buLabel lbl_contourtype;
  public buButton btn_settings;
  public buButton btn_close;
  public static byte f00258F;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public MarbleSheetMenuType SheetType;
  public Color clrLabel;
  public Color clrFormCaption;
  public Color clrFormBackUpper;
  public Color clrFormBackDown;
  public Color clrButtonDisplay;
  public Color clrButtonOver;
  public Color clrButtonDown;
  internal IContainer \u0001;
  public buButton btn_filelist;
  public buButton btn_fromfile;
  public buButton btn_close;
  internal ImageList \u0001;
  internal ImageList \u0002;
  public buGround buGround1;
  public buLabel lbl_sheettype;
  public buCheckBox chk_editimage;
  public buCheckBox chk_addtonesting;
  public buButton btn_fromdata;
  public buButton btn_editor;
  public static byte f0025A9;
  public Color SpinBaseColor;
  public Color SpinFocusColor;
  public static List<string> Captions;
  public FormProperties PropertiesForm;
  public MarblePhotoMenuType PhotoType;
  public Color clrLabel;
  public Color clrFormCaption;
  public Color clrFormBackUpper;
  public Color clrFormBackDown;

  public void Apply()
  {
    ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolMilling).Geometry.Diameter = ((F_MarbleDigitalInputOutput) this).spn_milling_diameter.Value;
    ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolMilling).Geometry.Length = ((F_MarbleDigitalInputOutput) this).spn_milling_length.Value;
    ((ToolPositions5) ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolMilling).CamData).SpindleSpeed = ((F_MarbleDigitalInputOutput) this).spn_milling_speed.Value;
    ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolSaw).Geometry.Diameter = ((F_MarbleDigitalInputOutput) this).spn_sawdia.Value;
    ((ToolDisplay5) ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolSaw).Geometry).Thickness = ((F_MarbleDigitalInputOutput) this).spn_sawthickness.Value;
    ((ToolPositions5) ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolSaw).CamData).SpindleSpeed = ((F_MarbleDigitalInputOutput) this).spn_sawspeed.Value;
    ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolMillingHead).Geometry.Diameter = ((F_MarbleDigitalInputOutput) this).spn_millinghead_diameter.Value;
    ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolMillingHead).Geometry.Length = ((F_MarbleDigitalInputOutput) this).spn_millinghead_length.Value;
    ((ToolPositions5) ((ToolGeometry5) ((F_MarbleDigitalInputOutput) this).ToolMillingHead).CamData).SpindleSpeed = ((F_MarbleDigitalInputOutput) this).spn_millinghead_speed.Value;
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

  static F_MarbleDigitalInput() => F_MarbleDigitalInputOutput.Captions = new List<string>();

  public F_MarbleDigitalInput()
  {
    ((F_MarbleDigitalInputOutput) this).SpinBaseColor = Color.LightGreen;
    ((F_MarbleDigitalInputOutput) this).SpinFocusColor = Color.MistyRose;
    ((F_MarbleDigitalInputOutput) this).ToolMilling = (ToolBase5) new ToolGeometry5();
    ((F_MarbleDigitalInputOutput) this).ToolSaw = (ToolBase5) new ToolGeometry5();
    ((F_MarbleDigitalInputOutput) this).PropertiesForm = new FormProperties();
    ((F_MarbleDigitalInputOutput) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_MarbleToolSawMilling) this);
  }
}
