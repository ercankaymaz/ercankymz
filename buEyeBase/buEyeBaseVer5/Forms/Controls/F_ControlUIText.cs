// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Controls.F_ControlUIText
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Forms.ClassForm;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Controls;

public class F_ControlUIText : Form
{
  public NumericUpDown spn_angle_finishoperationcount;
  internal Label \u0086;
  internal Label \u0087;
  public NumericUpDown spn_grindinglength;
  public RadioButton radiolineartype;
  public RadioButton radio_circulartype;
  internal CheckBox \u0002;
  internal Label \u0088;
  internal CheckBox \u0003;
  internal Label \u0089;
  public NumericUpDown spn_toolpersentage;
  public FormProperties Properties;
  public static List<string> Captions;
  public double OPWidth;
  public double OPHeight;

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_ControlUISettings) this).\u0001.Name)
      ((F_ControlUISettings) this).\u0001.Display = ((F_ControlUISettings) this).\u0001.Display;
    if (control.Name == ((F_ControlUISettings) this).\u0002.Name)
      ((F_ControlUISettings) this).\u0001.CheckTick.TickDisplay = ((F_ControlUISettings) this).\u0002.Display;
    if (control.Name == ((F_ControlUISettings) this).\u0003.Name)
      ((F_ControlUISettings) this).\u0001.CheckTick.ColorModeDisplay = ((F_ControlUISettings) this).\u0003.Display;
    ((F_ControlUISettings) this).\u0001.Invalidate();
  }

  internal void \u0001([In] object obj0, [In] double obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_ControlUISettings) this).spn_geometryrad.Name)
    {
      ((F_ControlUISettings) this).\u0001.Geometry.ArcDiameter = (int) ((F_ControlUISettings) this).spn_geometryrad.Value;
      ((F_ControlUISettings) this).refCheck.Geometry.ArcDiameter = (int) ((F_ControlUISettings) this).spn_geometryrad.Value;
    }
    if (!(control.Name == ((F_ControlUISettings) this).spn_iconsize.Name))
      return;
    ((F_ControlUISettings) this).\u0001.CheckTick.BoxSize = (int) ((F_ControlUISettings) this).spn_iconsize.Value;
    ((F_ControlUISettings) this).refCheck.CheckTick.BoxSize = (int) ((F_ControlUISettings) this).spn_iconsize.Value;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_ControlUISettings) this).\u0002.Name)
    {
      ShapeType result;
      Enum.TryParse<ShapeType>(((F_ControlUISettings) this).\u0002.SelectedItem.ToString(), out result);
      ((F_ControlUISettings) this).\u0001.Geometry.ShapeMode = result;
      ((F_ControlUISettings) this).refCheck.Geometry.ShapeMode = result;
    }
    if (!(control.Name == ((F_ControlUISettings) this).\u0001.Name))
      return;
    ContentAlignment result1;
    Enum.TryParse<ContentAlignment>(((F_ControlUISettings) this).\u0001.SelectedItem.ToString(), out result1);
    ((F_ControlUISettings) this).\u0001.ImageAlign = result1;
    ((F_ControlUISettings) this).refCheck.ImageAlign = result1;
  }

  internal void \u0001([In] object obj0, [In] bool obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_ControlUISettings) this).\u0002.Name)
    {
      ((F_ControlUISettings) this).\u0001.CheckTick.ColorModeEnable = ((F_ControlUISettings) this).\u0002.Check;
      ((F_ControlUISettings) this).refCheck.CheckTick.ColorModeEnable = ((F_ControlUISettings) this).\u0002.Check;
    }
    if (control.Name == ((F_ControlUISettings) this).\u0003.Name)
    {
      ((F_ControlUISettings) this).\u0001.CheckTick.Visible = ((F_ControlUISettings) this).\u0002.Check;
      ((F_ControlUISettings) this).refCheck.CheckTick.Visible = ((F_ControlUISettings) this).\u0002.Check;
    }
    if (!(control.Name == ((F_ControlUISettings) this).\u0004.Name))
      return;
    if (((F_ControlUISettings) this).\u0004.Check)
    {
      ((F_ControlUISettings) this).\u0001.CheckTick.Shape = ShapeType.Rectangle;
      ((F_ControlUISettings) this).refCheck.CheckTick.Shape = ShapeType.Rectangle;
    }
    else
    {
      ((F_ControlUISettings) this).\u0001.CheckTick.Shape = ShapeType.Arc;
      ((F_ControlUISettings) this).refCheck.CheckTick.Shape = ShapeType.Arc;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ControlUISettings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ControlUISettings) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ControlUIText() => F_ControlUISettings.Captions = new List<string>();

  public F_ControlUIText()
  {
    ((F_ControlUISettings) this).PropertiesForm = new FormProperties();
    ((F_ControlUISettings) this).Settings = (hmiUISettings) new buEyeShotFunctions();
    ((F_ControlUISettings) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ControlUICoordinate) this);
  }

  public void Init()
  {
    ((F_ControlUISettings) this).PropertiesForm.Inited = false;
    if (((F_ControlUISettings) this).PropertiesForm.Height > 10)
      this.Height = ((F_ControlUISettings) this).PropertiesForm.Height;
    if (((F_ControlUISettings) this).PropertiesForm.Width > 10)
      this.Width = ((F_ControlUISettings) this).PropertiesForm.Width;
    this.TopMost = ((F_ControlUISettings) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_ControlUISettings) this).PropertiesForm.FormPosition;
    ((F_ControlUISettings) this).\u0001.Items.Clear();
    ((F_ControlUISettings) this).\u0001.Items.AddRange(Enum.GetValues(typeof (ContentAlignment)).Cast<object>().ToArray<object>());
    ((F_ControlUISettings) this).\u0002.Items.Clear();
    ((F_ControlUISettings) this).\u0002.Items.AddRange(Enum.GetValues(typeof (ShapeType)).Cast<object>().ToArray<object>());
    ((F_ControlUISettings) this).\u0001.Display = ((buFile5.PLYToSchematic.\u0001) ((F_ControlUISettings) this).Settings).Display;
    ((F_ColorDrawType) this).\u0002.Display = ((buFile5.PLYToSchematic.\u0001) ((F_ControlUISettings) this).Settings).Caption;
    ((F_ColorDrawType) this).lbl_caption.Display = ((F_ColorDrawType) this).\u0002.Display;
    ((F_ControlUISettings) this).lbl_val.Display = ((F_ControlUISettings) this).\u0001.Display;
    ((F_ColorDrawType) this).lbl_title.Display.BackColor = Color.Linen;
    ((F_ColorDrawType) this).lbl_title.Display.Fonts.ForeColor = ((F_ControlUISettings) this).\u0001.Display.TitleForeColor;
    ((F_ControlUISettings) this).spn_geometryrad.Value = (double) ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_ControlUISettings) this).Settings).Parameters).GeometryArcDiameer;
    ((F_ControlUISettings) this).\u0002.SelectedItem = (object) ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_ControlUISettings) this).Settings).Parameters).GeometryType;
    ((F_ControlUISettings) this).\u0001.SelectedItem = (object) ((buFile5.PLYToSchematic.\u0001) ((buFile5.PLYToSchematic.\u0001) ((F_ControlUISettings) this).Settings).Parameters).ImageAlignment;
    ((F_ControlUISettings) this).\u0001.UpdateControl();
    ((F_ColorDrawType) this).\u0002.UpdateControl();
    ((F_ControlUISettings) this).PropertiesForm.Result = DialogResult.None;
    ((F_ControlUISettings) this).PropertiesForm.Inited = true;
    \u0007.\u0001.\u0001((F_ControlUICoordinate) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_ControlUISettings) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_ControlUISettings) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_ControlUISettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ControlUISettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  public void Apply()
  {
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control = obj0 as Control;
      if (control.Name == ((F_ControlUISettings) this).btn_ok.Name)
      {
        this.Apply();
        ((F_ControlUISettings) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_ControlUISettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_ControlUISettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
      }
      else
      {
        if (!(control.Name == ((F_ControlUISettings) this).btn_close.Name | control.Name == ((F_ControlUISettings) this).btn_cancel.Name))
          return;
        ((F_ControlUISettings) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((F_ControlUISettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_ControlUISettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
      }
    }
    catch (Exception ex)
    {
    }
  }
}
