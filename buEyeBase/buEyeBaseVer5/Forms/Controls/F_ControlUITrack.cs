// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Controls.F_ControlUITrack
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Forms.Customer.DincMak;
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

public class F_ControlUITrack : Form
{
  internal RadioButton \u0008;
  internal RadioButton \u000E;
  internal Label \u001D;
  public NumericUpDown spn_nick_finishspindlespeed;
  internal Label \u001E;
  internal Label \u001F;
  public NumericUpDown spn_nick_depth;
  public NumericUpDown spn_nick_roughspindlespeed;
  internal Label \u007F;
  internal Label \u0080;
  public NumericUpDown spn_nick_width;
  public NumericUpDown spn_nick_finishvel;
  internal Label \u0081;
  internal Label \u0082;
  public NumericUpDown spn_nick_finishdepth;
  public NumericUpDown spn_nick_roughtvel;
  internal Label \u0083;
  internal Panel \u0005;
  internal Label \u0084;
  public NumericUpDown spn_feedcount;

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_ControlUISettings) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_ControlUISettings) this).Properties.Result = DialogResult.Cancel;
    if (((F_ControlUISettings) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ControlUISettings) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      Control control1 = new Control();
      Control control2 = (Control) obj0;
      if (control2.Name == ((F_ControlUISettings) this).btn_ok.Name)
      {
        \u0018.\u0002.\u0005.\u0001((F_VShapePocket) this);
        ((F_ControlUISettings) this).Properties.Result = DialogResult.OK;
        if (((F_ControlUISettings) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_ControlUISettings) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (!(control2.Name == ((F_ControlUISettings) this).btn_cancel.Name | control2.Name == ((F_ControlUISettings) this).\u0001.Name))
        return;
      ((F_ControlUISettings) this).Properties.Result = DialogResult.Cancel;
      if (((F_ControlUISettings) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_ControlUISettings) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
        return;
      this.Visible = false;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0001([In] object obj0, [In] bool obj1)
  {
    if (!((F_ControlUISettings) this).Properties.Inited)
      ;
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_ControlUISettings) this).Properties.Inited)
      return;
    buCheckBox buCheckBox = obj0 as buCheckBox;
    ((F_ControlUISettings) this).chk_vleft.Check = false;
    ((F_ControlUISettings) this).chk_vmiddle.Check = false;
    ((F_ControlUISettings) this).chk_vright.Check = false;
    if (buCheckBox.Name == ((F_ControlUISettings) this).chk_vleft.Name)
      ((F_ControlUISettings) this).chk_vleft.Check = true;
    if (buCheckBox.Name == ((F_ControlUISettings) this).chk_vmiddle.Name)
      ((F_ControlUISettings) this).chk_vmiddle.Check = true;
    if (!(buCheckBox.Name == ((F_ControlUISettings) this).chk_vright.Name))
      return;
    ((F_ControlUISettings) this).chk_vright.Check = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_ControlUISettings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_ControlUISettings) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_ControlUITrack() => F_ControlUISettings.Captions = new List<string>();

  public F_ControlUITrack()
  {
    ((F_ControlUISettings) this).PropertiesForm = new FormProperties();
    ((F_ControlUISettings) this).refCheck = (buCheckBox) null;
    ((F_ControlUISettings) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_ControlUICheck) this);
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
    if (((F_ControlUISettings) this).refCheck != null)
    {
      ((F_ControlUISettings) this).\u0001.Display = ((F_ControlUISettings) this).refCheck.Display;
      ((F_ControlUISettings) this).\u0002.Display = ((F_ControlUISettings) this).refCheck.CheckTick.TickDisplay;
      ((F_ControlUISettings) this).\u0003.Display = ((F_ControlUISettings) this).refCheck.CheckTick.ColorModeDisplay;
      ((F_ControlUISettings) this).spn_geometryrad.Value = (double) ((F_ControlUISettings) this).refCheck.Geometry.ArcDiameter;
      ((F_ControlUISettings) this).\u0002.SelectedItem = (object) ((F_ControlUISettings) this).refCheck.Geometry.ShapeMode;
      ((F_ControlUISettings) this).\u0001.SelectedItem = (object) ((F_ControlUISettings) this).refCheck.ImageAlign;
      ((F_ControlUISettings) this).\u0001.Display = ((F_ControlUISettings) this).\u0001.Display;
      ((F_ControlUISettings) this).\u0001.CheckTick.TickDisplay = ((F_ControlUISettings) this).\u0002.Display;
      ((F_ControlUISettings) this).\u0001.CheckTick.ColorModeDisplay = ((F_ControlUISettings) this).\u0003.Display;
      ((F_ControlUISettings) this).\u0002.Check = ((F_ControlUISettings) this).refCheck.CheckTick.ColorModeEnable;
      ((F_ControlUISettings) this).\u0001.CheckTick.ColorModeEnable = ((F_ControlUISettings) this).refCheck.CheckTick.ColorModeEnable;
      ((F_ControlUISettings) this).\u0003.Check = ((F_ControlUISettings) this).refCheck.CheckTick.Visible;
      ((F_ControlUISettings) this).\u0001.CheckTick.Visible = ((F_ControlUISettings) this).refCheck.CheckTick.Visible;
      if (((F_ControlUISettings) this).refCheck.CheckTick.Shape == ShapeType.Rectangle)
        ((F_ControlUISettings) this).\u0004.Check = true;
      else
        ((F_ControlUISettings) this).\u0004.Check = false;
      ((F_ControlUISettings) this).\u0001.CheckTick.Shape = ((F_ControlUISettings) this).refCheck.CheckTick.Shape;
      ((F_ControlUISettings) this).\u0001.CheckTick.BoxSize = ((F_ControlUISettings) this).refCheck.CheckTick.BoxSize;
      if (((F_ControlUISettings) this).refCheck.CheckTick.BoxSize > 0)
        ((F_ControlUISettings) this).spn_iconsize.Value = (double) ((F_ControlUISettings) this).refCheck.CheckTick.BoxSize;
      ((F_ControlUISettings) this).\u0001.UpdateControl();
      ((F_ControlUISettings) this).\u0002.UpdateControl();
      ((F_ControlUISettings) this).\u0003.UpdateControl();
    }
    ((F_ControlUISettings) this).PropertiesForm.Result = DialogResult.None;
    ((F_ControlUISettings) this).PropertiesForm.Inited = true;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ControlUICheck) this);
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

  public void spn_Leave(object sender, EventArgs e)
  {
  }
}
