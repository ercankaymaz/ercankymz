// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Foam.F_FoamPattern
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms.File;
using buEyeBaseVer5.Forms.Holes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Foam;

public class F_FoamPattern : Form
{
  public Label label6;
  public Label label7;
  public NumericUpDown spn_rectangleangle;
  public Label label8;
  public NumericUpDown spn_ellipseangle;
  public Label label15;
  public CheckBox chk_rectanglecatchcenter;
  public Label label9;
  public CheckBox chk_circlecatchcenter;
  public Label label23;
  public CheckBox chk_ellipsecatchcenter;
  public Label lbl_singlecorner_height;
  public NumericUpDown spn_singlecorner_height;
  public NumericUpDown spn_singlecorner_width;
  public NumericUpDown spn_singlecorner_depth;
  public Label lbl_singlecorner_depth;
  public Label lbl_singlecorner_width;
  public TabPage tabPage_singlecorner;
  public Label label24;
  public CheckBox chk_rectanglepocket;
  public Label label25;
  public CheckBox chk_circlepocket;
  public Label label26;
  public CheckBox chk_ellipsepocket;
  public Label label27;
  public CheckBox chk_singlecornerpocket;
  public Label label28;
  public CheckBox chk_drillmode1_usemilling;
  public Label label29;
  public CheckBox chk_polygonispocket;
  public Label label31;
  public NumericUpDown spn_polygonangle;
  public NumericUpDown spn_polygonx;
  public NumericUpDown spn_polygonz;
  public Label label33;
  public Label label34;
  public NumericUpDown spn_polygondiameter;
  public NumericUpDown spn_polygondepth;
  public Label label35;
  public NumericUpDown spn_polygony;
  public Label label36;
  public Label label37;
  public Label label38;
  public NumericUpDown spn_slotshape_angle;
  public Label label39;
  public NumericUpDown spn_slotshape_x;
  public NumericUpDown spn_slotshape_z;
  public NumericUpDown spn_slotshape_height;
  public Label label40;
  public Label label41;
  public NumericUpDown spn_slotshape_width;
  public NumericUpDown spn_slotshape_depth;
  public Label label42;
  public NumericUpDown spn_slotshape_y;
  public Label label43;
  public Label label44;
  public Label label32;
  public NumericUpDown spn_polygonsides;
  public TabPage tabPage_polygon;
  public TabPage tabPage_slotshape;
  internal Label \u0003;
  public NumericUpDown spn_slotmode1_z;
  public Label label30;
  public CheckBox chk_slotpocket;
  public Label label51;
  public NumericUpDown spn_slotmode3_angle;
  public NumericUpDown spn_slotmode3_x;
  public NumericUpDown spn_slotmode3_width;
  public Label label45;
  public Label label46;
  public NumericUpDown spn_slotmode3_length;
  public Label label47;
  public NumericUpDown spn_slotmode3_depth;
  internal Label \u0004;
  internal Label \u0005;

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_FoamSlices) this).\u0001.Name)
    {
      ((F_FoamSlices) this).Commands = drillCommands.ProfilingSingleCorner;
      ((F_FoamSlices) this).CommandsBase = drillCommandBase.Profilling;
    }
    if (control2.Name == ((F_FoamSlices) this).\u0002.Name)
    {
      ((F_FoamSlices) this).Commands = drillCommands.ProfilingSingleRoundCorner;
      ((F_FoamSlices) this).CommandsBase = drillCommandBase.Profilling;
    }
    if (control2.Name == ((F_FoamSlices) this).\u0003.Name)
    {
      ((F_FoamSlices) this).Commands = drillCommands.ProfilingAllCorner;
      ((F_FoamSlices) this).CommandsBase = drillCommandBase.Profilling;
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
    if ((!disposing ? 0 : (((F_FoamSlices) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_FoamSlices) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_FoamPattern() => F_FoamSlices.Captions = new List<string>();

  public F_FoamPattern()
  {
    ((F_FoamSlices) this).PropertiesForm = new FormProperties();
    ((F_FoamSlices) this).Commands = drillCommands.SingleHole;
    ((F_FoamSlices) this).CommandsBase = drillCommandBase.Shape;
    ((F_FoamSlices) this).\u0001 = new Timer();
    ((F_FoamSlices) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_DrawingMenu) this);
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

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_FoamSlices) this).\u0001.Name)
    {
      ((F_FoamSlices) this).Commands = drillCommands.DrawingRectangle;
      ((F_FoamSlices) this).CommandsBase = drillCommandBase.Shape;
    }
    if (control2.Name == ((F_FoamSlices) this).\u0002.Name)
    {
      ((F_FoamSlices) this).Commands = drillCommands.DrawingEllipse;
      ((F_FoamSlices) this).CommandsBase = drillCommandBase.Shape;
    }
    if (control2.Name == ((F_FoamSlices) this).\u0003.Name)
    {
      ((F_FoamSlices) this).Commands = drillCommands.DrawingCircle;
      ((F_FoamSlices) this).CommandsBase = drillCommandBase.Shape;
    }
    if (control2.Name == ((F_FoamSlices) this).\u0004.Name)
    {
      ((F_FoamSlices) this).Commands = drillCommands.DrawingPoliygon;
      ((F_FoamSlices) this).CommandsBase = drillCommandBase.Shape;
    }
    if (control2.Name == ((F_FoamSlices) this).\u0005.Name)
    {
      ((F_FoamSlices) this).Commands = drillCommands.DrawingSlot;
      ((F_FoamSlices) this).CommandsBase = drillCommandBase.Shape;
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
    if ((!disposing ? 0 : (((F_FoamSlices) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_FoamSlices) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_FoamPattern() => F_FoamSlices.Captions = new List<string>();

  public F_FoamPattern()
  {
    ((F_FoamSlices) this).PropertiesForm = new FormProperties();
    ((F_FoamSlices) this).Commands = drillCommands.SingleHole;
    ((F_FoamSlices) this).CommandsBase = drillCommandBase.Slot;
    ((F_FoamSlices) this).\u0001 = new Timer();
    ((F_FoamSlices) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_CutMenu) this);
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
    ((F_AddImageFromFile) this).ControlUpdate();
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

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    Control control1 = new Control();
    Control control2 = (Control) obj0;
    if (control2.Name == ((F_FoamSlices) this).\u0005.Name)
    {
      ((F_FoamSlices) this).Commands = drillCommands.CutHorizontal;
      ((F_FoamSlices) this).CommandsBase = drillCommandBase.Slot;
    }
    if (control2.Name == ((F_FoamSlices) this).\u0003.Name)
    {
      ((F_FoamSlices) this).Commands = drillCommands.CutFree;
      ((F_FoamSlices) this).CommandsBase = drillCommandBase.Slot;
    }
    if (control2.Name == ((F_FoamSlices) this).\u0004.Name)
    {
      ((F_FoamSlices) this).Commands = drillCommands.CutVertical;
      ((F_FoamSlices) this).CommandsBase = drillCommandBase.Slot;
    }
    if (control2.Name == ((F_FoamSlices) this).\u0001.Name)
    {
      ((F_FoamSlices) this).Commands = drillCommands.CutVerticalLine;
      ((F_FoamSlices) this).CommandsBase = drillCommandBase.Slot;
    }
    if (control2.Name == ((F_FoamSlices) this).\u0002.Name)
    {
      ((F_FoamSlices) this).Commands = drillCommands.CutHorizontalLine;
      ((F_FoamSlices) this).CommandsBase = drillCommandBase.Slot;
    }
    if (((F_FoamSlices) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_FoamSlices) this).PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
      this.Visible = false;
    ((F_FoamSlices) this).PropertiesForm.Result = DialogResult.OK;
  }

  public event OkCommandWithTwoDataEventHandler DataChanged;

  public event OkCommandWithTwoDataEventHandler ParameterChanged;

  public event CancelCommandEventHandler DataCancel;
}
