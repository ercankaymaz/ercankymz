// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.File.F_AddImageFromFile
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms.Foam;
using buEyeBaseVer5.Forms.Holes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.File;

public class F_AddImageFromFile : Form
{
  public NumericUpDown spn_slotmode3_z;
  public NumericUpDown spn_slotmode3_y;
  internal Label \u0006;
  public TabPage tabPage_cutfree;
  public NumericUpDown spn_engraving_x;
  public Label label52;
  public NumericUpDown spn_engraving_y;
  public Label label53;
  public TabPage tabPage_engraving;
  public NumericUpDown spn_engraving_z;
  public Label label54;
  public CheckBox chk_engravingfinishoperation;
  public CheckBox chk_engravingroughoperation;
  public NumericUpDown spn_rectanglestepval;
  public Label label55;
  public CheckBox chk_rectanglestepenable;
  public NumericUpDown spn_circlestepval;
  public Label label56;
  public CheckBox chk_circlestepenable;
  public NumericUpDown spn_ellipsestepval;
  public Label label57;
  public CheckBox chk_ellipsestepenable;
  public NumericUpDown spn_polygonstepval;
  public Label label58;
  public CheckBox chk_polygonstepenable;
  public NumericUpDown spn_slotstepval;
  public Label label59;
  public CheckBox chk_slotstepenable;
  public NumericUpDown spn_singlecornerstepval;
  public Label label60;
  public CheckBox chk_singlecornerstep;
  public FormProperties PropertiesForm;
  public GCodeConverter Converter;
  public static List<string> Captions;
  internal IContainer \u0001;
  internal ImageList \u0001;
  public Button btn_cancel;
  public Button btn_ok;
  internal ImageList \u0002;
  internal Label \u0001;
  internal NumericUpDown \u0001;
  internal Label \u0002;
  internal Label \u0003;

  public void ControlUpdate()
  {
  }

  public void Apply()
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_FoamSlices) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_FoamSlices) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_AddImageFromFile() => F_FoamSlices.Captions = new List<string>();

  public F_AddImageFromFile()
  {
    ((F_FoamSlices) this).PropertiesForm = new FormProperties();
    ((F_FoamWaveForm) this).Commands = drillCommands.SingleHole;
    ((F_FoamWaveForm) this).CommandsBase = drillCommandBase.Drill;
    ((F_FoamWaveForm) this).\u0001 = new Timer();
    ((F_FoamWaveForm) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_HoleMenu) this);
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
    this.ControlUpdate();
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
      if (F_FoamWaveForm.Captions.Count >= 9)
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

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_FoamWaveForm) this).\u0001.Name)
    {
      ((F_FoamWaveForm) this).Commands = drillCommands.SingleHole;
      ((F_FoamWaveForm) this).CommandsBase = drillCommandBase.Drill;
    }
    if (control2.Name == ((F_FoamWaveForm) this).\u0003.Name)
    {
      ((F_FoamWaveForm) this).Commands = drillCommands.VerticalHoles;
      ((F_FoamWaveForm) this).CommandsBase = drillCommandBase.Drill;
    }
    if (control2.Name == ((F_FoamWaveForm) this).\u0002.Name)
    {
      ((F_FoamWaveForm) this).Commands = drillCommands.HorizontalHoles;
      ((F_FoamWaveForm) this).CommandsBase = drillCommandBase.Drill;
    }
    if (control2.Name == ((F_FoamWaveForm) this).\u0006.Name)
    {
      ((F_FoamWaveForm) this).Commands = drillCommands.HorizontalLineHoles;
      ((F_FoamWaveForm) this).CommandsBase = drillCommandBase.Drill;
    }
    if (control2.Name == ((F_FoamWaveForm) this).\u0007.Name)
    {
      ((F_FoamWaveForm) this).Commands = drillCommands.VerticalLineHoles;
      ((F_FoamWaveForm) this).CommandsBase = drillCommandBase.Drill;
    }
    if (control2.Name == ((F_FoamWaveForm) this).\u0004.Name)
    {
      ((F_FoamWaveForm) this).Commands = drillCommands.InclineHoles;
      ((F_FoamWaveForm) this).CommandsBase = drillCommandBase.Drill;
    }
    if (control2.Name == ((F_FoamWaveForm) this).\u0005.Name)
    {
      ((F_FoamWaveForm) this).Commands = drillCommands.ThreeHole;
      ((F_FoamWaveForm) this).CommandsBase = drillCommandBase.Drill;
    }
    if (((F_FoamSlices) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_FoamSlices) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
      this.Visible = false;
    ((F_FoamSlices) this).PropertiesForm.Result = DialogResult.OK;
  }

  public void ControlUpdate()
  {
  }

  public void Apply()
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_FoamWaveForm) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_FoamWaveForm) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_AddImageFromFile() => F_FoamWaveForm.Captions = new List<string>();

  public event OkCommandWithTwoDataEventHandler ReadFile;
}
