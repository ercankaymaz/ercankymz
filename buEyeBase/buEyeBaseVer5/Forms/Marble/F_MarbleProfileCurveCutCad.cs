// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.F_MarbleProfileCurveCutCad
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble;

public class F_MarbleProfileCurveCutCad : Form
{
  public buButton btn_DO57;
  public buButton btn_DO54;
  public buButton btn_DO56;
  public buButton btn_DO55;
  public buPanel pnl_output2;
  public buButton btn_DO31;
  public buButton btn_DO16;
  public buButton btn_DO30;
  public buButton btn_DO17;
  public buButton btn_DO29;
  public buButton btn_DO18;
  public buButton btn_DO28;
  public buButton btn_DO19;
  public buButton btn_DO27;
  public buButton btn_DO20;
  public buButton btn_DO26;
  public buButton btn_DO21;
  public buButton btn_DO25;
  public buButton btn_DO22;
  public buButton btn_DO24;
  public buButton btn_DO23;
  public buPanel pnl_output3;
  public buButton btn_DO47;
  public buButton btn_DO32;
  public buButton btn_DO46;
  public buButton btn_DO33;
  public buButton btn_DO45;
  public buButton btn_DO34;

  public void Init()
  {
    ((F_MarbleDigitalOutput) this).PropertiesForm.Inited = false;
    if (((F_MarbleDigitalOutput) this).PropertiesForm.Height > 10)
      this.Height = ((F_MarbleDigitalOutput) this).PropertiesForm.Height;
    if (((F_MarbleDigitalOutput) this).PropertiesForm.Width > 10)
      this.Width = ((F_MarbleDigitalOutput) this).PropertiesForm.Width;
    this.TopMost = ((F_MarbleDigitalOutput) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_MarbleDigitalOutput) this).PropertiesForm.FormPosition;
    this.LoadLanguage();
    ((F_MarbleDigitalOutput) this).buGround1.DisplayTop.BackColor = ((F_MarbleDigitalOutput) this).clrFormCaption;
    ((F_MarbleDigitalOutput) this).buGround1.Display.GradientType = GradientMode.Lineer;
    ((F_MarbleDigitalOutput) this).buGround1.Display.LineerGradient.FirstColor = ((F_MarbleDigitalOutput) this).clrFormBackUpper;
    ((F_MarbleDigitalOutput) this).buGround1.Display.LineerGradient.SecondColor = ((F_MarbleDigitalOutput) this).clrFormBackDown;
    ((F_MarbleDigitalOutput) this).btn_close.Display.BackColor = ((F_MarbleDigitalOutput) this).clrFormCaption;
    ((F_MarbleDigitalOutput) this).btn_close.ButtonDownDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleDigitalOutput) this).clrFormCaption, 0.9);
    ((F_MarbleDigitalOutput) this).btn_close.ButtonOverDisplay.BackColor = buFile5.ColorToneChange(((F_MarbleDigitalOutput) this).clrFormCaption, 0.95);
    ((F_MarbleDigitalOutput) this).btn_vertical.Display.BackColor = ((F_MarbleDigitalOutput) this).clrButtonDisplay;
    ((F_MarbleDigitalOutput) this).btn_vertical.ButtonDownDisplay.BackColor = ((F_MarbleDigitalOutput) this).clrButtonDown;
    ((F_MarbleDigitalOutput) this).btn_vertical.ButtonOverDisplay.BackColor = ((F_MarbleDigitalOutput) this).clrButtonOver;
    ((F_MarbleDigitalOutput) this).PropertiesForm.Result = DialogResult.None;
    ((F_MarbleDigitalOutput) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    try
    {
      ((F_MarbleDigitalOutput) this).btn_air.Text = $"{buLangTranslate.preDef.Air} {buLangTranslate.preDef.Dry}";
      ((F_MarbleDigitalOutput) this).btn_arcprofile.Text = $"{buLangTranslate.preDef.Profile} {buLangTranslate.preDef.Curve}";
      ((F_MarbleDigitalOutput) this).btn_cleaning.Text = buLangTranslate.preDef.Cleaning;
      ((F_MarbleDigitalOutput) this).btn_columns.Text = buLangTranslate.preDef.Columns;
      ((F_MarbleDigitalOutput) this).btn_contour.Text = buLangTranslate.preDef.Contour;
      ((F_MarbleDigitalOutput) this).btn_drill.Text = buLangTranslate.preDef.Drill;
      ((F_MarbleDigitalOutput) this).btn_editor.Text = buLangTranslate.preDef.Editor;
      ((F_MarbleDigitalOutput) this).btn_engrave.Text = buLangTranslate.preDef.Engraving;
      ((F_MarbleDigitalOutput) this).btn_horizontal.Text = buLangTranslate.preDef.Horizontal;
      ((F_MarbleDigitalOutput) this).btn_horizontallathe.Text = $"{buLangTranslate.preDef.Horizontal} {buLangTranslate.preDef.Lathe}";
      ((F_MarbleDigitalOutput) this).btn_library.Text = buLangTranslate.preDef.Library;
      ((F_MarbleDigitalOutput) this).btn_profile.Text = buLangTranslate.preDef.Profile;
      ((F_MarbleDigitalOutput) this).btn_shapes.Text = buLangTranslate.preDef.Shape;
      ((F_MarbleDigitalOutput) this).btn_single.Text = $"{buLangTranslate.preDef.Single} {buLangTranslate.preDef.Cut}";
      ((F_MarbleDigitalOutput) this).btn_sweep.Text = buLangTranslate.preDef.Sweep;
      ((F_MarbleDigitalOutput) this).btn_text.Text = buLangTranslate.preDef.Text;
      ((F_MarbleDigitalOutput) this).btn_vertical.Text = $"{buLangTranslate.preDef.Vertical} {buLangTranslate.preDef.Cut}";
      ((F_MarbleDigitalOutput) this).btn_verticallathe.Text = $"{buLangTranslate.preDef.Vertical} {buLangTranslate.preDef.Lathe}";
      ((F_MarbleDigitalOutput) this).btn_gcode.Text = buLangTranslate.preDef.GCode;
      ((F_MarbleDigitalOutput) this).btn_countertop.Text = buLangTranslate.preDef.Countertop;
      ((F_MarbleDigitalOutput) this).btn_slices.Text = buLangTranslate.preDef.Slice;
      ((F_MarbleDigitalOutput) this).btn_sawveralmilling.Text = $"{buLangTranslate.preDef.Saw} {buLangTranslate.preDef.Vertical} {buLangTranslate.preDef.Milling}";
      ((F_MarbleDigitalOutput) this).btn_sawhorizontalmilling.Text = $"{buLangTranslate.preDef.Slice} {buLangTranslate.preDef.Horizontal} {buLangTranslate.preDef.Milling}";
      ((F_MarbleDigitalOutput) this).btn_easydraw.Text = $"{buLangTranslate.preDef.Easy} {buLangTranslate.preDef.Drawing}";
      ((F_MarbleDigitalOutput) this).btn_horver.Text = $"{buLangTranslate.preDef.Horizontal} {buLangTranslate.preDef.Vertical}";
      ((F_MarbleDigitalInput) this).btn_cutremainmaterial.Text = $"{buLangTranslate.preDef.Cut} {buLangTranslate.preDef.Remnant} {buLangTranslate.preDef.Material}";
      ((F_MarbleDigitalOutput) this).btn_5axisrotartmilling.Text = $"{buLangTranslate.preDef.Rotary} {buLangTranslate.preDef.Milling}";
      ((F_MarbleDigitalOutput) this).btn_5axisflatmilling.Text = $"{buLangTranslate.preDef.Flat} {buLangTranslate.preDef.Milling}";
      ((F_MarbleDigitalOutput) this).btn_pocketbydrill.Text = $"{buLangTranslate.preDef.Pocket} {buLangTranslate.preDef.Drill}";
      ((F_MarbleDigitalOutput) this).buGround1.Text = $"{buLangTranslate.preDef.Operation} {buLangTranslate.preDef.Menu}";
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_MarbleDigitalOutput) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_MarbleDigitalOutput) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_MarbleDigitalOutput) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_MarbleDigitalOutput) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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
    if ((!disposing ? 0 : (((F_MarbleDigitalOutput) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_MarbleDigitalOutput) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_MarbleProfileCurveCutCad() => F_MarbleDigitalOutput.Captions = new List<string>();
}
