// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Foam.F_FoamLeadInOut
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.Holes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Foam;

public class F_FoamLeadInOut : Form
{
  public NumericUpDown spn_slotmode2_startdis;
  public Label lbl_slotmode2_startdis;
  public NumericUpDown spn_slotmode2_enddis;
  public Label lbl_slotmode2_enddis;
  public NumericUpDown spn_slotmode2_depth;
  public Label lbl_slotmode2_width;
  public Label lbl_slotmode2_depth;
  public NumericUpDown spn_slotmode2_width;
  public TabPage tabPage_slotdistance;
  public TabPage tabPage_Slot;
  public TabPage tabPage_rectangle;
  public TabPage tabPage_Circle;
  public TabPage tabPage_ellipse;
  public Label label1;
  public NumericUpDown spn_ellipseX;
  public NumericUpDown spn_ellipseZ;
  public NumericUpDown spn_ellipseheight;
  public Label label2;
  public Label label3;
  public NumericUpDown spn_ellipsewidth;
  public NumericUpDown spn_ellipsedepth;
  public Label label4;
  public NumericUpDown spn_ellipseY;
  public Label label5;

  public void Apply()
  {
    ((buNestingVar) ((F_FoamSlices) this).settingRuntime).ContourOffset = (double) ((F_FoamSlices) this).\u0001.Value;
    ((buNestingVar) ((F_FoamSlices) this).settingRuntime).ContourDepth = (double) ((F_FoamSlices) this).\u0002.Value;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_FoamWaveMenu) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_FoamWaveMenu) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_FoamWaveMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_FoamWaveMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
      this.Visible = false;
    // ISSUE: reference to a compiler-generated field
    if (((F_FoamSlices) this).\u0001 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    ((F_FoamSlices) this).\u0001();
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_FoamSlices) this).btn_ok.Name)
    {
      if (((buNestingVar) ((F_FoamSlices) this).settingRuntime).DrillCommand == drillCommands.CutHorizontal && ((buNestingDraw) ((F_FoamSlices) this).settingRuntime).slotPoint.Y < ((TuftingSequenceItem) ((F_FoamSlices) this).settingCNC).ClamperCatchWidth)
      {
        if (((buNestingResultSettings) ((F_FoamSlices) this).settingRuntime).lastDrillPlaneNames == planeBoxNames.Top && ((SortResult) ((DrillSettings) ((F_FoamSlices) this).Job).Material).Size.Width < ((buNestingPartData) ((F_FoamSlices) this).settingCNC).ContourMinLengthForTopSpindleAtClamperArea)
        {
          buNumeric5.MessageBoxWarning($"{DrillMachineSettings.LangDrillMessage[29]} : {((buNestingPartData) ((F_FoamSlices) this).settingCNC).ContourMinLengthForTopSpindleAtClamperArea.ToString("f1")}");
          return;
        }
        if (((buNestingResultSettings) ((F_FoamSlices) this).settingRuntime).lastDrillPlaneNames == planeBoxNames.Bottom && ((SortResult) ((DrillSettings) ((F_FoamSlices) this).Job).Material).Size.Width < ((buNestingPartData) ((F_FoamSlices) this).settingCNC).ContourMinLengthForBottomSpindleAtClamperArea)
        {
          buNumeric5.MessageBoxWarning($"{DrillMachineSettings.LangDrillMessage[30]} : {((buNestingPartData) ((F_FoamSlices) this).settingCNC).ContourMinLengthForBottomSpindleAtClamperArea.ToString("f1")}");
          return;
        }
      }
      this.Apply();
      \u0007.\u0001.\u0001((F_Contour) this, true);
      ((F_FoamWaveMenu) this).PropertiesForm.Result = DialogResult.OK;
      if (((F_FoamWaveMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_FoamWaveMenu) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    else if (control2.Name == ((F_FoamSlices) this).btn_cancel.Name)
    {
      ((F_FoamWaveMenu) this).PropertiesForm.Result = DialogResult.Cancel;
      if (((F_FoamWaveMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_FoamWaveMenu) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
      // ISSUE: reference to a compiler-generated field
      if (((F_FoamSlices) this).\u0001 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      ((F_FoamSlices) this).\u0001();
    }
    else
    {
      if (control2.Name == ((F_FoamSlices) this).btn_top.Name)
      {
        ((buNestingResultSettings) ((F_FoamSlices) this).settingRuntime).lastContourPlaneNames = planeBoxNames.Top;
        ((F_FoamSlices) this).btn_bottom.BackColor = Color.Gainsboro;
        ((F_FoamSlices) this).btn_top.BackColor = Color.PaleGreen;
      }
      if (!(control2.Name == ((F_FoamSlices) this).btn_bottom.Name))
        return;
      ((buNestingResultSettings) ((F_FoamSlices) this).settingRuntime).lastContourPlaneNames = planeBoxNames.Bottom;
      ((F_FoamSlices) this).btn_top.BackColor = Color.Gainsboro;
      ((F_FoamSlices) this).btn_bottom.BackColor = Color.PaleGreen;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_FoamSlices) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_FoamSlices) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_FoamLeadInOut() => F_FoamSlices.Captions = new List<string>();

  public F_FoamLeadInOut()
  {
    ((F_FoamSlices) this).PropertiesForm = new FormProperties();
    ((F_FoamSlices) this).Commands = drillCommands.SingleHole;
    ((F_FoamSlices) this).CommandsBase = drillCommandBase.Profilling;
    ((F_FoamSlices) this).\u0001 = new Timer();
    ((F_FoamSlices) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_ProfilingMenu) this);
  }

  public void Init()
  {
    ((F_FoamSlices) this).PropertiesForm.Inited = false;
    if (((F_FoamSlices) this).PropertiesForm.Height > 10)
      this.Height = ((F_FoamSlices) this).PropertiesForm.Height;
    if (((F_FoamSlices) this).PropertiesForm.Width > 10)
      this.Width = ((F_FoamSlices) this).PropertiesForm.Width;
    this.TopMost = ((F_FoamSlices) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_FoamSlices) this).PropertiesForm.FormPosition;
    ((F_FoamPattern) this).ControlUpdate();
    this.LoadLanguage();
    ((F_FoamSlices) this).PropertiesForm.Inited = false;
    ((F_FoamSlices) this).PropertiesForm.Result = DialogResult.None;
    ((F_FoamSlices) this).PropertiesForm.Inited = true;
  }

  public void LoadLanguage()
  {
    string callMethod = nameof (LoadLanguage);
    try
    {
      if (F_FoamSlices.Captions.Count >= 9)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_FoamSlices) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_FoamSlices) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_FoamSlices) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_FoamSlices) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
