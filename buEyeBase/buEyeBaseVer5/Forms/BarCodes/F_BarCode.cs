// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.BarCodes.F_BarCode
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using buEyeBaseVer5.Forms.Cam;
using buEyeBaseVer5.Forms.Controls;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.BarCodes;

public class F_BarCode : Form
{
  public buSpin spn_depthstepconstantZ;
  public buCheckBox chk_edgerollingparallel;
  public buCheckBox chk_edgerollingconstantZ;
  internal buGroup \u000E;
  public buCheckBox chk_verticalwallmachineonlyconstantZ;
  public buCheckBox chk_verticalwallincludeconstantZ;
  public buCheckBox chk_verticalwallexcludeconstantZ;
  public buCheckBox chk_maintaincuttingdirectionroughconstantz;
  public buCheckBox chk_undercut;

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_CamTriMeshSettings) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_CamTriMeshSettings) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_BarCode() => F_CamTriMeshSettings.Captions = new List<string>();

  public F_BarCode()
  {
    ((F_CamTriMeshSettings) this).PropertiesForm = new FormProperties();
    ((F_CamTriMeshSettings) this).refSpin = (buSpin) null;
    ((F_CamTriMeshSettings) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_ControlUISpin) this);
  }

  public void Init()
  {
    ((F_CamTriMeshSettings) this).PropertiesForm.Inited = false;
    if (((F_CamTriMeshSettings) this).PropertiesForm.Height > 10)
      this.Height = ((F_CamTriMeshSettings) this).PropertiesForm.Height;
    if (((F_CamTriMeshSettings) this).PropertiesForm.Width > 10)
      this.Width = ((F_CamTriMeshSettings) this).PropertiesForm.Width;
    this.TopMost = ((F_CamTriMeshSettings) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_CamTriMeshSettings) this).PropertiesForm.FormPosition;
    ((F_CamTriMeshSettings) this).\u0001.Items.Clear();
    ((F_CamTriMeshSettings) this).\u0001.Items.AddRange(Enum.GetValues(typeof (ContentAlignment)).Cast<object>().ToArray<object>());
    ((F_CamTriMeshSettings) this).\u0002.Items.Clear();
    ((F_CamTriMeshSettings) this).\u0002.Items.AddRange(Enum.GetValues(typeof (ShapeType)).Cast<object>().ToArray<object>());
    if (((F_CamTriMeshSettings) this).refSpin != null)
    {
      ((F_CamTriMeshSettings) this).\u0001.Display = ((F_CamTriMeshSettings) this).refSpin.ButtonNormalDisplay;
      ((F_CamTriMeshSettings) this).refSpin.ButtonOverDisplay = buControlDisplay.Copy(((F_CamTriMeshSettings) this).refSpin.ButtonNormalDisplay, ((F_CamTriMeshSettings) this).refSpin.ButtonOverDisplay);
      ((F_CamTriMeshSettings) this).refSpin.ButtonDownDisplay = buControlDisplay.Copy(((F_CamTriMeshSettings) this).refSpin.ButtonNormalDisplay, ((F_CamTriMeshSettings) this).refSpin.ButtonDownDisplay);
      ((F_CamTriMeshSettings) this).\u0002.Display = ((F_CamTriMeshSettings) this).refSpin.Caption.Display;
      ((F_CamTriMeshSettings) this).\u0003.Display = ((F_CamTriMeshSettings) this).refSpin.Display;
      ((F_CamTriMeshSettings) this).spn_geometryrad.Value = (double) ((F_CamTriMeshSettings) this).refSpin.Geometry.ArcDiameter;
      ((F_CamTriMeshSettings) this).\u0002.SelectedItem = (object) ((F_CamTriMeshSettings) this).refSpin.Geometry.ShapeMode;
      ((F_CamTriMeshSettings) this).\u0001.SelectedItem = (object) ((F_CamTriMeshSettings) this).refSpin.ImageAlign;
      ((F_CamTriMeshSettings) this).spn_ref.Display = ((F_CamTriMeshSettings) this).\u0003.Display;
      ((F_CamTriMeshSettings) this).spn_ref.Caption.Display = ((F_CamTriMeshSettings) this).\u0002.Display;
      ((F_CamTriMeshSettings) this).spn_ref.ButtonNormalDisplay = ((F_CamTriMeshSettings) this).\u0001.Display;
      ((F_CamTriMeshSettings) this).spn_ref.ButtonOverDisplay = ((F_CamTriMeshSettings) this).\u0001.Display;
      ((F_CamTriMeshSettings) this).spn_ref.ButtonDownDisplay = ((F_CamTriMeshSettings) this).\u0001.Display;
      ((F_CamTriMeshSettings) this).\u0001.UpdateControl();
      ((F_CamTriMeshSettings) this).\u0002.UpdateControl();
      ((F_CamTriMeshSettings) this).\u0003.UpdateControl();
    }
    ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.None;
    ((F_CamTriMeshSettings) this).PropertiesForm.Inited = true;
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ControlUISpin) this);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_CamTriMeshSettings) this).PropertiesForm.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.Cancel;
    if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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
      if (control.Name == ((F_CamTriMeshSettings) this).btn_ok.Name)
      {
        this.Apply();
        ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.OK;
        if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
          return;
        this.Visible = false;
      }
      else
      {
        if (!(control.Name == ((F_CamTriMeshSettings) this).btn_close.Name | control.Name == ((F_CamTriMeshSettings) this).btn_cancel.Name))
          return;
        ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.Cancel;
        if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_CamTriMeshSettings) this).PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
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

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    Control control = obj0 as Control;
    if (control.Name == ((F_CamTriMeshSettings) this).\u0001.Name)
    {
      ((F_CamTriMeshSettings) this).spn_ref.ButtonDownDisplay = ((F_CamTriMeshSettings) this).\u0001.Display;
      ((F_CamTriMeshSettings) this).spn_ref.ButtonOverDisplay = ((F_CamTriMeshSettings) this).\u0001.Display;
      ((F_CamTriMeshSettings) this).spn_ref.ButtonNormalDisplay = ((F_CamTriMeshSettings) this).\u0001.Display;
    }
    if (control.Name == ((F_CamTriMeshSettings) this).\u0002.Name)
      ((F_CamTriMeshSettings) this).spn_ref.Caption.Display = ((F_CamTriMeshSettings) this).\u0002.Display;
    if (control.Name == ((F_CamTriMeshSettings) this).\u0003.Name)
      ((F_CamTriMeshSettings) this).spn_ref.Display = ((F_CamTriMeshSettings) this).\u0003.Display;
    ((F_CamTriMeshSettings) this).spn_ref.Invalidate();
  }
}
